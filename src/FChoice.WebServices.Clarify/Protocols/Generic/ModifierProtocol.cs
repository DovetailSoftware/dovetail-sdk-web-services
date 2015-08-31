using System;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;

using FChoice.Foundation;
using FChoice.Foundation.Schema;
using FChoice.Foundation.Clarify;
using FChoice.Foundation.Clarify.Schema;

namespace FChoice.WebServices.Clarify.Protocols.Generic
{
	[System.Xml.Serialization.SoapIncludeAttribute(typeof(InsertModifierProtocol))]
	[System.Xml.Serialization.SoapIncludeAttribute(typeof(UpdateModifierProtocol))]
	[System.Xml.Serialization.SoapIncludeAttribute(typeof(DeleteModifierProtocol))]
	[System.Xml.Serialization.SoapIncludeAttribute(typeof(ReferenceModifierProtocol))]
	public abstract class ModifierProtocol
	{
		public string Name;
		public string Table;

		public FieldProtocol[] Fields;
		public FieldProtocol[] UniqueFields;

		public RelationProtocol[] Relations;
		public RelationProtocol[] UniqueRelations;

		[SoapIgnore]internal ClarifyGeneric ClarifyGeneric;
		[SoapIgnore]protected bool IsPreProcessed = false;
		[SoapIgnore]protected int RecordObjID = -1;

		internal abstract void PreProcess();
		internal abstract int GetRecordObjID();
		internal abstract string GetAction();

		#region Apply Fields and Relations

		protected void ApplyFields(ClarifyDataRow row)
		{
			foreach(FieldProtocol field in this.Fields)
			{
				if(!ClarifyApplication.Instance.SchemaCache.IsValidField( this.Table, field.Name ))
					throw new InvalidOperationException(string.Format("Field '{0}' is not valid for object '{1}'", field.Name, this.Table));

				SchemaFieldBase schemaField = ClarifyApplication.Instance.SchemaCache.GetField( this.Table, field.Name );

				object fieldValue = null;
				try
				{
					switch( schemaField.CommonType )
					{
						case (int)SchemaCommonType.String:
							fieldValue = field.Value;
							break;

						case (int)SchemaCommonType.Date:
							fieldValue = DateTime.Parse( field.Value );
							break;

						case (int)SchemaCommonType.Float:
							fieldValue = float.Parse( field.Value );
							break;

						case (int)SchemaCommonType.Double:
							fieldValue = double.Parse( field.Value );
							break;

						case (int)SchemaCommonType.Decimal:
							fieldValue = decimal.Parse( field.Value );
							break;

						case (int)SchemaCommonType.Integer:
							fieldValue = int.Parse( field.Value );
							break;

						default:
							throw new InvalidOperationException(string.Format("Parse logic not implemented for SchemaCommonType.{0}", schemaField.CommonType));
					}
				}
				catch(FormatException ex)
				{
					throw new InvalidOperationException(string.Format("Could not parse field value '{0}' for field '{1}' on object '{2}'.", field.Value, field.Name, this.Table), ex);
				}

				row[field.Name] = fieldValue;
			}
		}

		protected void ApplyRelations(ClarifyDataRow row)
		{
			foreach(RelationProtocol relation in this.Relations)
			{
				ReferenceModifierProtocol reference = relation.ReferenceInstance as ReferenceModifierProtocol;

				if( reference != null )
					row.RelateByID( reference.GetRecordObjID(), relation.Name );
				else
				{
					relation.ReferenceInstance.PreProcess();
					row.RelateRecord( relation.ReferenceInstance.ClarifyGeneric.Rows[0], relation.Name );
				}
			}

		}

		#endregion

		#region Apply Unique Fields and Relations

		protected void ApplyUniqueFields()
		{
			foreach(FieldProtocol field in this.UniqueFields)
			{
				if(!ClarifyApplication.Instance.SchemaCache.IsValidField( this.Table, field.Name ))
					throw new InvalidOperationException(string.Format("Field '{0}' is not valid for object '{1}'", field.Name, this.Table));

				SchemaFieldBase schemaField = ClarifyApplication.Instance.SchemaCache.GetField( this.Table, field.Name );

				try
				{
					switch( schemaField.CommonType )
					{
						case (int)SchemaCommonType.String:
							this.ClarifyGeneric.AppendFilter( field.Name, StringOps.Equals, field.Value );
							break;

						case (int)SchemaCommonType.Date:
							DateTime dateVal = DateTime.Parse( field.Value );
							this.ClarifyGeneric.AppendFilter( field.Name, DateOps.Equals, dateVal );
							break;

						case (int)SchemaCommonType.Float:
						case (int)SchemaCommonType.Double:
						case (int)SchemaCommonType.Decimal:
							decimal decVal = decimal.Parse( field.Value );
							this.ClarifyGeneric.AppendFilter( field.Name, NumberOps.Equals, decVal );
							break;

						case (int)SchemaCommonType.Integer:
							int intVal = int.Parse( field.Value );
							this.ClarifyGeneric.AppendFilter( field.Name, NumberOps.Equals, intVal );
							break;

						default:
							throw new InvalidOperationException(string.Format("Parse logic not implemented for SchemaCommonType.{0}", schemaField.CommonType));
					}
				}
				catch(FormatException ex)
				{
					throw new InvalidOperationException(string.Format("Could not parse field value '{0}' for field '{1}' on object '{2}'.", field.Value, field.Name, this.Table), ex);
				}
				
			}
		}

		protected void ApplyUniqueRelations()
		{
			//Set unique relations
			foreach(RelationProtocol relation in this.UniqueRelations)
			{
				ReferenceModifierProtocol reference = relation.ReferenceInstance as ReferenceModifierProtocol;

				CheckUniqueRelationReference( reference );

				int refId = reference.GetRelationObjID(relation.Name);
				this.ClarifyGeneric.AppendFilter( "objid", NumberOps.Equals, refId );
			}
		}

		protected virtual void CheckUniqueRelationReference(ReferenceModifierProtocol reference){}

		#endregion


		protected void PreQueryBeforeModify()
		{
			ApplyUniqueFields();
			ApplyUniqueRelations();

			Query();
		}

		protected void Query()
		{
			this.ClarifyGeneric.Query();

			if( this.ClarifyGeneric.Rows.Count == 0 )
				throw new InvalidOperationException( String.Format(@"Generic item ""{0}"" fail to select a record.", this.Name) );

			if( this.ClarifyGeneric.Rows.Count > 1 )
				throw new InvalidOperationException( String.Format(@"Generic item ""{0}"" selected more than one record.", this.Name) );

			this.RecordObjID = Convert.ToInt32(this.ClarifyGeneric.Rows[0]["objid"]);
		}



	}
}

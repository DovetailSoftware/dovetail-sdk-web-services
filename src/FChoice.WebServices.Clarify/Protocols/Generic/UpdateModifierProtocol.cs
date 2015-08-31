using System;

using FChoice.Foundation;
using FChoice.Foundation.Schema;
using FChoice.Foundation.Clarify;
using FChoice.Foundation.Clarify.Schema;

namespace FChoice.WebServices.Clarify.Protocols.Generic
{
	public class UpdateModifierProtocol : ModifierProtocol
	{
		internal override void PreProcess()
		{
			if(this.IsPreProcessed)
				return;

			ClarifyDataRow row;

			//We don't prequery if we already know the record we want to update.
			this.RecordObjID = GetObjIDFieldValue();
			if( this.RecordObjID > 0 )
			{
				row = this.ClarifyGeneric.AddForUpdate( this.RecordObjID );
			}
			else
			{
				PreQueryBeforeModify();
				row = this.ClarifyGeneric.Rows[0];
			}
			
			this.ApplyFields(row);
			this.ApplyRelations(row);

			this.IsPreProcessed = true;
		}

		internal override int GetRecordObjID()
		{
			if( !this.IsPreProcessed )
				throw new InvalidOperationException("Update items must be preprocessed before accessing GetRecordObjID()");

			return this.RecordObjID;
		}

		internal override string GetAction()
		{
			return "Update";
		}

		private int GetObjIDFieldValue()
		{
			int objid = -1;
			foreach(FieldProtocol field in this.UniqueFields)
			{
				if( field.Name.ToLower() == "objid" )
				{
					try
					{
						objid = Int32.Parse(field.Value);
						break;
					}
					catch(FormatException ex)
					{
						throw new InvalidOperationException( String.Format(@"Could not evaluate ""{0}"" as an objid.", field.Value), ex );
					}
				}
			}

			return objid;
		}
	}
}

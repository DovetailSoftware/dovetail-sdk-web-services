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
	public class ReferenceModifierProtocol : ModifierProtocol
	{
		internal override void PreProcess()
		{
			//nothing to do for a Reference
		}

		internal override int GetRecordObjID()
		{
			if( this.RecordObjID > 0 )
				return this.RecordObjID;

			ApplyUniqueFields();
			ApplyUniqueRelations();

			this.Query();

			return this.RecordObjID;
		}

		internal override string GetAction()
		{
			return "Reference";
		}

		protected override void CheckUniqueRelationReference(ReferenceModifierProtocol reference)
		{
			if( reference == null )
				throw new InvalidOperationException("Unique relations with a Reference can only reference other References.");
		}


		public int GetRelationObjID(string relationName)
		{
			ApplyUniqueFields();
			ApplyUniqueRelations();

			this.Query();

			object objID = this.ClarifyGeneric.Rows[0][relationName];

			if( objID == null )
				throw new InvalidOperationException( String.Format(@"Could not find relation ""{0}"" in item ""{1}""", relationName, this.Name) );

			return Convert.ToInt32(objID);
		}
	}
}

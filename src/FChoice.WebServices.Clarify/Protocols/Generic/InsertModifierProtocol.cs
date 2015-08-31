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
	public class InsertModifierProtocol : ModifierProtocol
	{
		internal override void PreProcess()
		{
			if(this.IsPreProcessed)
				return;

			ClarifyDataRow row = this.ClarifyGeneric.AddNew();
			this.ApplyFields(row);
			this.ApplyRelations(row);

			this.IsPreProcessed = true;
		}

		internal override int GetRecordObjID()
		{
			if( this.RecordObjID <= 0 )
			{
				if( this.ClarifyGeneric.Rows[0]["objid"] == DBNull.Value )
					throw new InvalidOperationException("Insert items must be processed before accessing GetRecordObjID()");

				this.RecordObjID = Convert.ToInt32(this.ClarifyGeneric.Rows[0]["objid"]);
			}

			return this.RecordObjID;
		}

		internal override string GetAction()
		{
			return "Insert";
		}
	}
}

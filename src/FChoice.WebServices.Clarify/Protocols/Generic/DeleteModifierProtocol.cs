using System;
using System.Data;

using FChoice.Foundation;
using FChoice.Foundation.Schema;
using FChoice.Foundation.Clarify;
using FChoice.Foundation.Clarify.Schema;

namespace FChoice.WebServices.Clarify.Protocols.Generic
{
	public class DeleteModifierProtocol : ModifierProtocol
	{
		internal override void PreProcess()
		{
			if(this.IsPreProcessed)
				return;

			this.PreQueryBeforeModify();

			if(this.ClarifyGeneric.Rows.Count == 1)
			{
				ClarifyDataRow row = this.ClarifyGeneric.Rows[0];
				row.Delete();
			}

			this.IsPreProcessed = true;
		}

		internal override int GetRecordObjID()
		{
			if(!this.IsPreProcessed)
				throw new InvalidOperationException("Delete items must be preprocessed before accessing GetRecordObjID()");

			return this.RecordObjID;
		}

		internal override string GetAction()
		{
			return "Delete";
		}
	}
}

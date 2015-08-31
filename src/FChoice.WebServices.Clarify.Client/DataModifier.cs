using System;
using System.Collections;
using System.Data;

using Protocol = FChoice.WebServices.Clarify.Client.Protocols.ClarifyDataAccessSrv;

namespace FChoice.WebServices.Clarify.Client
{
	public class DataModifier
	{
		private ArrayList modifications = new ArrayList();
		private ClarifyDataAccessWS clarifyDataAccessWS;

		internal DataModifier(ClarifyDataAccessWS clarifyDataAccessWS)
		{
			this.clarifyDataAccessWS = clarifyDataAccessWS;
		}

		public InsertModifier CreateInsertModifier(string name, string table)
		{
			InsertModifier insert = new InsertModifier(name, table);
			modifications.Add( insert );
			return insert;
		}

		public UpdateModifier CreateUpdateModifier(string name, string table)
		{
			UpdateModifier update = new UpdateModifier(name, table);
			modifications.Add( update );
			return update;
		}

		public DeleteModifier CreateDeleteModifier(string name, string table)
		{
			DeleteModifier delete = new DeleteModifier(name, table);
			modifications.Add( delete );
			return delete;
		}

		public ReferenceModifier CreateReferenceModifier(string name, string table)
		{
			ReferenceModifier reference = new ReferenceModifier(name, table);
			modifications.Add( reference );
			return reference;
		}

		public Protocol.ModifierResultProtocol[] Update()
		{
			Protocol.ModifierProtocol[] protocolMods =  new Protocol.ModifierProtocol[modifications.Count];

			for(int i=0;i<modifications.Count;i++)
			{
				Modifier modifyItem = ((Modifier)modifications[i]);
				modifyItem.PrepareProtocalForTransport();

				protocolMods[i] = modifyItem.ModifyProtocol;
			}

			return this.clarifyDataAccessWS.Update( protocolMods );
		}
	}
}

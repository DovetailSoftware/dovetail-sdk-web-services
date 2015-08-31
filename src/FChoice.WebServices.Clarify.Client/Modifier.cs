using System;
using System.Collections;

using Protocol = FChoice.WebServices.Clarify.Client.Protocols.ClarifyDataAccessSrv;

namespace FChoice.WebServices.Clarify.Client
{
	public abstract class Modifier
	{
		protected ArrayList fields = new ArrayList();
		protected ArrayList uniqueFields = new ArrayList();
		protected ArrayList relations = new ArrayList();
		protected ArrayList uniqueRelations = new ArrayList();

		internal Protocol.ModifierProtocol ModifyProtocol;

		private string name;
		private string table;

		public string Name
		{
			get{ return this.name; }
		}

		public string Table
		{
			get{ return this.table; }
		}


		internal Modifier(string name, string table)
		{
			this.name = name;
			this.table = table;

			ModifyProtocol = CreateModifyProtocol();
			ModifyProtocol.Name = name;
			ModifyProtocol.Table = table;
		}

		protected abstract Protocol.ModifierProtocol CreateModifyProtocol();

		internal void PrepareProtocalForTransport()
		{
			ModifyProtocol.Fields = new Protocol.FieldProtocol[fields.Count];
			for(int i=0;i<fields.Count;i++)
			{
				ModifyProtocol.Fields[i] = (Protocol.FieldProtocol)fields[i];
			}

			ModifyProtocol.UniqueFields = new Protocol.FieldProtocol[uniqueFields.Count];
			for(int i=0;i<uniqueFields.Count;i++)
			{
				ModifyProtocol.UniqueFields[i] = (Protocol.FieldProtocol)uniqueFields[i];
			}

			ModifyProtocol.Relations = new Protocol.RelationProtocol[relations.Count];
			for(int i=0;i<relations.Count;i++)
			{
				ModifyProtocol.Relations[i] = (Protocol.RelationProtocol)relations[i];
			}

			ModifyProtocol.UniqueRelations = new Protocol.RelationProtocol[uniqueRelations.Count];
			for(int i=0;i<uniqueRelations.Count;i++)
			{
				ModifyProtocol.UniqueRelations[i] = (Protocol.RelationProtocol)uniqueRelations[i];
			}
		}
	}
}

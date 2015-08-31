using System;
using Protocol = FChoice.WebServices.Clarify.Client.Protocols.ClarifyDataAccessSrv;

namespace FChoice.WebServices.Clarify.Client
{
	public class InsertModifier : Modifier
	{
		internal InsertModifier(string name, string table) : base(name, table)
		{
		}

		public void SetField(string name, object value)
		{
			Protocol.FieldProtocol field = new Protocol.FieldProtocol();
			field.Name = name;
			field.Value = value.ToString();

			this.fields.Add(field);
		}

		private void RelateRecord(string relationName, string reference)
		{
			Protocol.RelationProtocol rel = new Protocol.RelationProtocol();
			rel.Name = relationName;
			rel.Reference = reference;

			this.relations.Add(rel);
		}

		public void RelateRecord(string relationName, Modifier reference)
		{
			this.RelateRecord(relationName, reference.Name);
		}

		protected override Protocol.ModifierProtocol CreateModifyProtocol()
		{
			return new Protocol.InsertModifierProtocol();
		}

	}
}

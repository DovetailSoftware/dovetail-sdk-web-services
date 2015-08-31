using System;
using Protocol = FChoice.WebServices.Clarify.Client.Protocols.ClarifyDataAccessSrv;

namespace FChoice.WebServices.Clarify.Client
{
	public class UpdateModifier : Modifier
	{
		internal UpdateModifier(string name, string table) : base(name, table)
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

		public void AppendUniqueFilter(string name, object value)
		{
			Protocol.FieldProtocol field = new Protocol.FieldProtocol();
			field.Name = name;
			field.Value = value.ToString();

			this.uniqueFields.Add(field);
		}

		private void AppendUniqueRelation(string relationName, string reference)
		{
			Protocol.RelationProtocol rel = new Protocol.RelationProtocol();
			rel.Name = relationName;
			rel.Reference = reference;

			this.uniqueRelations.Add(rel);
		}

		public void AppendUniqueRelation(string relationName, Modifier reference)
		{
			this.AppendUniqueRelation(relationName, reference.Name);
		}

		protected override Protocol.ModifierProtocol CreateModifyProtocol()
		{
			return new Protocol.UpdateModifierProtocol();
		}
	}
}

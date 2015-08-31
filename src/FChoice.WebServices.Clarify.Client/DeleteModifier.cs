using System;
using Protocol = FChoice.WebServices.Clarify.Client.Protocols.ClarifyDataAccessSrv;

namespace FChoice.WebServices.Clarify.Client
{
	public class DeleteModifier : Modifier
	{
		internal DeleteModifier(string name, string table) : base(name, table)
		{
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
			return new Protocol.DeleteModifierProtocol();
		}
	}
}

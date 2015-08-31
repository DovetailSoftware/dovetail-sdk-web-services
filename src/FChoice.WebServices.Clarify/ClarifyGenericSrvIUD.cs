using System;
using System.Collections;
using System.Collections.Generic;
using FChoice.Foundation;
using FChoice.Foundation.Clarify;
using FChoice.WebServices.Clarify.Protocols.Generic;

namespace FChoice.WebServices.Clarify
{
	internal class ClarifyGenericSrvIUD
	{
		private readonly ClarifyDataSet dataSet;
		private readonly Dictionary<string, ModifierProtocol> modifyItems = new Dictionary<string, ModifierProtocol>();

		public ClarifyGenericSrvIUD(ClarifySession session)
		{
			if (session == null)
			{
				throw new ArgumentNullException("session");
			}

			dataSet = new ClarifyDataSet(session);
		}

		public ModifierResultProtocol[] Process(ModifierProtocol[] modifierProtocols)
		{
			if (modifierProtocols == null)
			{
				throw new ArgumentNullException("modifierProtocols");
			}

			LoadModificationsIntoHashtableLookup(modifierProtocols);
			LinkReferences();
			PreProcess();

			FCGeneric[] generics = new FCGeneric[modifierProtocols.Length];

			for (int i = 0; i < modifierProtocols.Length; i++)
				generics[i] = modifierProtocols[i].ClarifyGeneric;

			dataSet.Update(generics);

			return GetResults(modifierProtocols);
		}

		private static ModifierResultProtocol[] GetResults(ModifierProtocol[] modifierProtocols)
		{
			ModifierResultProtocol[] modifierResultProtocols = new ModifierResultProtocol[modifierProtocols.Length];

			for (int i = 0; i < modifierProtocols.Length; i++)
			{
				ModifierProtocol modifierProtocol = modifierProtocols[i];
				modifierResultProtocols[i] = new ModifierResultProtocol(modifierProtocol.Name, modifierProtocol.GetAction(), modifierProtocol.Table, modifierProtocol.GetRecordObjID());
			}

			return modifierResultProtocols;
		}

		private void LoadModificationsIntoHashtableLookup(ModifierProtocol[] queryItems)
		{
			foreach (ModifierProtocol item in queryItems)
			{
				if (modifyItems.ContainsKey(item.Name))
					throw new InvalidOperationException(string.Format("Duplicate modification name '{0}'.", item.Name));

				if (!ClarifyApplication.Instance.SchemaCache.IsValidTableOrView(item.Table))
					throw new InvalidOperationException(
						string.Format("'{0}' is an invalid table name on modification item '{1}'.", item.Table, item.Name));

				item.ClarifyGeneric = dataSet.CreateGeneric(item.Table);

				modifyItems.Add(item.Name, item);
			}
		}

		private void PreProcess()
		{
			foreach (ModifierProtocol item in modifyItems.Values)
			{
				item.PreProcess();
			}
		}

		private void LinkReferences()
		{
			foreach (ModifierProtocol item in modifyItems.Values)
			{
				LinkReferencesRecursive(item, null);
			}
		}

		private void LinkReferencesRecursive(ModifierProtocol item, Hashtable ancestors)
		{
			Hashtable ht = (ancestors == null) ? new Hashtable() : (Hashtable) ancestors.Clone();

			if (ht.ContainsKey(item.Name))
			{
				throw new InvalidOperationException(String.Format(@"Circular reference to item '{0}'.", item.Name));
			}

			ht.Add(item.Name, item);

			foreach (RelationProtocol relation in item.Relations)
			{
				LinkRelation(item, relation, ht);
			}

			foreach (RelationProtocol relation in item.UniqueRelations)
			{
				LinkRelation(item, relation, ht);
			}
		}

		private void LinkRelation(ModifierProtocol item, RelationProtocol relation, Hashtable ancestors)
		{
			if (!modifyItems.ContainsKey(relation.Reference))
			{
				throw new InvalidOperationException(String.Format("Modification item '{0}' defines a reference '{1}' which was not found.", item.Name, relation.Reference));
			}

			relation.ReferenceInstance = modifyItems[relation.Reference];
			LinkReferencesRecursive(relation.ReferenceInstance, ancestors);
		}
	}
}
using System;

using FChoice.Foundation.Clarify.DataObjects;

namespace FChoice.WebServices.Clarify.Protocols
{

	[Serializable]
	public class HierarchicalStringElementProtocol
	{
		public HierarchicalStringElementProtocol(){}

		public HierarchicalStringElementProtocol(IHierarchicalStringElement element)
		{
			this.Title = element.Title;
			this.Rank = element.Rank;
			this.State = element.State;
			this.ObjectID = element.ObjectID;
			this.IsActive = element.IsActive;

			this.Elements = new HierarchicalStringElementProtocol[element.Elements.Count];

			for(int i=0; i<element.Elements.Count; i++)
			{
				this.Elements[i] = new HierarchicalStringElementProtocol( element.Elements[i] );
			}
		}


		public string Title;
		public int Rank;
		public string State;
		public int ObjectID;
		public bool IsActive;
		public HierarchicalStringElementProtocol[] Elements;

	}
}

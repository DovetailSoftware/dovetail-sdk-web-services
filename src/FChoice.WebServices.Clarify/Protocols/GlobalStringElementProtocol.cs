using System;

using FChoice.Foundation.Clarify.DataObjects;

namespace FChoice.WebServices.Clarify.Protocols
{

	[Serializable]
	public class GlobalStringElementProtocol
	{
		public GlobalStringElementProtocol(){}

		public GlobalStringElementProtocol(IGlobalStringElement gbstElement)
		{
			this.AdditionalInfo = gbstElement.AdditionalInfo;
			this.Description = gbstElement.Description;
			this.ObjectID = gbstElement.ObjectID;
			this.Rank = gbstElement.Rank;
			this.State = gbstElement.State;
			this.Title = gbstElement.Title;
		}

		public string AdditionalInfo;
		public string Description;
		public int ObjectID;
		public int Rank;
		public int State;
		public string Title;

		public static GlobalStringElementProtocol[] ConvertCollection(IGlobalStringElementCollection gbstElements)
		{
			var protoGbstElems = new GlobalStringElementProtocol[gbstElements.Count];

			int i = 0;
			foreach(IGlobalStringElement elem in gbstElements)
			{
				protoGbstElems[i] = new GlobalStringElementProtocol( elem );
				i++;
			}

			return protoGbstElems;
		}

	}
}

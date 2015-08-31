using System;

using FChoice.Foundation.Clarify.DataObjects;

namespace FChoice.WebServices.Clarify.Protocols
{

	[Serializable]
	public class GlobalStringListProtocol
	{
		public GlobalStringListProtocol(){}

		public GlobalStringListProtocol(IGlobalStringList gbstList)
		{
			this.AdditionalInfo = gbstList.AdditionalInfo;
			this.DefaultElement = new GlobalStringElementProtocol( gbstList.DefaultElement );
			this.Elements = GlobalStringElementProtocol.ConvertCollection( gbstList.Elements );
			this.ListID = gbstList.ListID;
			this.ListID = gbstList.LocaleID;
			this.ObjectID = gbstList.ObjectID;
			this.Title = gbstList.Title;
		}

		public string AdditionalInfo;
		public GlobalStringElementProtocol DefaultElement;
		public GlobalStringElementProtocol[] Elements;
		public int ListID;
		public int LocaleID;
		public int ObjectID;
		public string Title;

	}
}

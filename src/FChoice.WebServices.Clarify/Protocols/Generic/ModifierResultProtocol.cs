using System;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;

using FChoice.Foundation;
using FChoice.Foundation.Schema;
using FChoice.Foundation.Clarify;
using FChoice.Foundation.Clarify.Schema;

namespace FChoice.WebServices.Clarify.Protocols.Generic
{

	public class ModifierResultProtocol
	{
		public string Name = "";
		public string Action = "";
		public string Table = "";
		public int Objid = -1;

		public ModifierResultProtocol(){}
		public ModifierResultProtocol(string name, string action, string table, int objid)
		{
			this.Name = name;
			this.Action = action;
			this.Table = table;
			this.Objid = objid;
		}

	}
}

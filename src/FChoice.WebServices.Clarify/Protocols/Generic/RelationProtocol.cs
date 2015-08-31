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
	public class RelationProtocol
	{
		public string Name;
		public string Reference;

		[SoapIgnore]internal ModifierProtocol ReferenceInstance;
	}
}

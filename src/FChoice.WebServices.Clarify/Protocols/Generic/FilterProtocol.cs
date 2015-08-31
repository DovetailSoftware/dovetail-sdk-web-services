using System;
using FChoice.Foundation;

namespace FChoice.WebServices.Clarify.Protocols.Generic
{
	[Serializable]
	public class FilterProtocol
	{
		public string Field;
		public string Operation;
		public string Value;
	}
}

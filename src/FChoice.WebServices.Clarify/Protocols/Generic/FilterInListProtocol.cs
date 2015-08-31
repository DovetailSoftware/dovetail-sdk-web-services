using System;
using FChoice.Foundation;

namespace FChoice.WebServices.Clarify.Protocols.Generic
{
	[Serializable]
	public class FilterInListProtocol
	{
		public string Field;
		public bool IsIn;
		public string[] Values;
	}
}

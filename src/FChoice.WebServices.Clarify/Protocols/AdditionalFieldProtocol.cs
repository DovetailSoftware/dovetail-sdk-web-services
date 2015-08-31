using System;

namespace FChoice.WebServices.Clarify.Protocols
{
	[Serializable]
	public class AdditionalFieldProtocol
	{
		public string FieldName;
		public FChoice.Toolkits.Clarify.AdditionalFieldType FieldType;
		public string FieldValue;
	}
}

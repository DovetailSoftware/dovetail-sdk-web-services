using System;

using FChoice.Foundation.DataObjects;
using FChoice.Foundation.Clarify.DataObjects;

namespace FChoice.WebServices.Clarify.Protocols
{

	[Serializable]
	public class ClarifyConfigItemProtocol
	{
		public ClarifyConfigItemProtocol(){}

		public ClarifyConfigItemProtocol(ClarifyConfigItem configItem)
		{
			this.DateValue = configItem.DateValue;
			this.DecimalValue = configItem.DecimalValue;
			this.Description = configItem.Description;
			this.DoubleValue = configItem.DoubleValue;
			this.IntegerValue = configItem.IntegerValue;
			this.LastModTime = configItem.LastModTime;
			this.LongValue = configItem.LongValue;
			this.Name = configItem.Name;
			this.Scope = configItem.Scope;
			this.ValueType = configItem.ValueType;
		}

		public DateTime DateValue;
		public decimal DecimalValue;
		public string Description;
		public double DoubleValue;
		public int IntegerValue;
		public DateTime LastModTime;
		public long LongValue;
		public string Name;
		public ConfigItemScope Scope;
		public ConfigItemValueType ValueType;

	}
}

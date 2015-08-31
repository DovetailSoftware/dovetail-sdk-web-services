using System;

namespace FChoice.WebServices.Clarify.Protocols
{
	[Serializable]
	public class LocationProtocol
	{
		public bool IsPrimaryBinSuggestion;
		public string LocationName;
		public string BinName;

		public FChoice.Toolkits.Clarify.Location ToLocation()
		{
			FChoice.Toolkits.Clarify.Location loc = new FChoice.Toolkits.Clarify.Location();
	        loc.BinName = this.BinName;
			loc.IsPrimaryBinSuggestion = this.IsPrimaryBinSuggestion;
			loc.LocationName = this.LocationName;

			return loc;
		}
	}
}

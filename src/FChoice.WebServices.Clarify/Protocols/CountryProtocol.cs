using System;

using FChoice.Foundation.Clarify.DataObjects;

namespace FChoice.WebServices.Clarify.Protocols
{

	[Serializable]
	public class CountryProtocol
	{
		public CountryProtocol(){}

		public CountryProtocol(Country country)
		{
			if( country.DefaultState != null )
				this.DefaultState = new StateProvinceProtocol( country.DefaultState );

			this.Name = country.Name;

			if( country.DefaultTimeZone != null )
				this.DefaultTimeZone = new TimeZoneProtocol( country.DefaultTimeZone );

			this.Code = country.Code;
			this.IsDefault = country.IsDefault;
			this.ObjectID = country.ObjectID;

			this.States = StateProvinceProtocol.ConvertCollection( country.States );
			this.TimeZones = TimeZoneProtocol.ConvertCollection( country.TimeZones );
		}

		public string Name;
		public StateProvinceProtocol DefaultState;
		public TimeZoneProtocol DefaultTimeZone;
		public int Code;
		public bool IsDefault;
		public int ObjectID;

		public StateProvinceProtocol[] States;
		public TimeZoneProtocol[] TimeZones;

		public static CountryProtocol[] ConvertCollection(CountryCollection countries)
		{
			CountryProtocol[] protoCountries = new CountryProtocol[countries.Count];

			int i = 0;
			foreach(Country country in countries)
			{
				protoCountries[i] = new CountryProtocol( country );
				i++;
			}

			return protoCountries;
		}

	}
}

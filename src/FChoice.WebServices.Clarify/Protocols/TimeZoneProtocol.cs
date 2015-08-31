using System;

using FChoice.Foundation.Clarify.DataObjects;
using FChoice.Foundation.DataObjects;

namespace FChoice.WebServices.Clarify.Protocols
{

	[Serializable]
	public class TimeZoneProtocol
	{
		public TimeZoneProtocol(){}

		public TimeZoneProtocol(ITimeZone timezone)
		{
			this.Name = timezone.Name;
			this.FullName = timezone.FullName;
			this.UtcOffsetSeconds = timezone.UtcOffsetSeconds;
		}

		public string Name;
		public string FullName;
		public int UtcOffsetSeconds;

		public static TimeZoneProtocol[] ConvertCollection(FCTimeZoneCollection timeZones)
		{
			TimeZoneProtocol[] protoTimeZones = new TimeZoneProtocol[timeZones.Count];

			for(int i = 0; i < timeZones.Count; i++)
			{
				protoTimeZones[i] = new TimeZoneProtocol( timeZones[i] );
			}

			return protoTimeZones;
		}

	}
}

using System;
using System.Web;

using Protocol = FChoice.WebServices.Clarify.Client.Protocols.ClarifyApplicationSrv;

namespace FChoice.WebServices.Clarify.Client
{
	public class ClarifyApplicationWS
	{
		private Protocol.ClarifyApplicationSrv appProtocol;

		public ClarifyApplicationWS( string url )
		{
			if( url == null)
				throw new ArgumentNullException("url");

			this.baseUri = new Uri( url.EndsWith("/") ? url : url + "/" );

			this.appProtocol = new Protocol.ClarifyApplicationSrv();
			this.appProtocol.Url = new Uri( BaseUri, "ClarifyApplicationSrv.asmx" ).ToString();
		}

		private Uri baseUri;

		internal Uri BaseUri
		{
			get{ return this.baseUri; }
		}

		public ClarifySessionWS CreateSession( string username, string password )
		{
			return CreateSession( username, password, Protocol.ClarifyLoginType.User );
		}

		public ClarifySessionWS CreateSession( string username, string password, Protocol.ClarifyLoginType loginType )
		{
			string sessionToken = appProtocol.CreateSession( username, password, loginType );
			return new ClarifySessionWS( this, sessionToken );
		}

		public ClarifySessionWS GetSession( string sessionToken )
		{
			bool sessionValid = appProtocol.IsSessionValid( sessionToken );
			return new ClarifySessionWS( this, sessionToken );
		}

		public string GetDatabaseVersion()
		{
			return appProtocol.GetDatabaseVersion();
		}

		public string GetClarifyVersion()
		{
			return appProtocol.GetClarifyVersion();
		}

		public Protocol.TimeZoneProtocol GetServerTimezone()
		{
			return appProtocol.GetServerTimezone();
		}

		public Protocol.TimeZoneProtocol[] GetTimeZonesInCountry(string countryName)
		{
			return appProtocol.GetTimeZonesInCountry( countryName );
		}

		public Protocol.TimeZoneProtocol GetDefaultTimeZone()
		{
			return appProtocol.GetDefaultTimeZone();
		}

		public Protocol.TimeZoneProtocol[] GetTimeZones()
		{
			return appProtocol.GetTimeZones();
		}

		public int GetTimeZoneObjid(string timezoneName, bool fullName)
		{
			return appProtocol.GetTimeZoneObjid( timezoneName, fullName );
		}

		public bool IsTimeZone(string timezoneName)
		{
			return appProtocol.IsTimeZone( timezoneName );
		}

		public Protocol.HierarchicalStringElementProtocol[] GetHgbstList(string listName, params string[] elementTitles)
		{
			return appProtocol.GetHgbstList( listName, elementTitles);
		}

		public string GetHgbstElmDefault(string listName, params string[] elementTitles)
		{
			return appProtocol.GetHgbstElmDefault( listName, elementTitles );
		}

		public bool IsState(string country, string state, bool isFullStateName)
		{
			return appProtocol.IsState( country, state, isFullStateName );
		}

		public Protocol.StateProvinceProtocol GetDefaultState(string country)
		{
			return appProtocol.GetDefaultState( country );
		}

		public Protocol.StateProvinceProtocol[] GetStates(string country)
		{
			return appProtocol.GetStates( country );
		}

		public Protocol.CountryProtocol[] GetCountries()
		{
			return appProtocol.GetCountries();
		}

		public bool IsCountry(string country)
		{
			return appProtocol.IsCountry( country );
		}

		public Protocol.CountryProtocol GetDefaultCountry()
		{
			return appProtocol.GetDefaultCountry();
		}

		public Protocol.GlobalStringListProtocol GetGbstList(string listTitle)
		{
			return appProtocol.GetGbstList( listTitle );
		}

		public string GetGbstDefault(string listTitle)
		{
			return appProtocol.GetGbstDefault( listTitle );
		}

	}
}

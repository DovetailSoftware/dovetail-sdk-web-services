using System;
using System.Web;
using System.Web.Services;

using Protocol = FChoice.WebServices.Clarify.Client.Protocols.ClarifySessionSrv;

namespace FChoice.WebServices.Clarify.Client
{
	public class ClarifySessionWS
	{
		private ClarifyApplicationWS appWS;
		private Protocol.ClarifySessionSrv sessionProtocol;

		internal string SessionToken
		{
			get{ return this.sessionProtocol.AuthenticationHeaderValue.SessionID; }
		}

		internal Uri BaseUri
		{
			get{ return this.appWS.BaseUri; }
		}

		internal ClarifySessionWS( ClarifyApplicationWS applicationWS, string sessionToken )
		{
			if( applicationWS == null)
				throw new ArgumentNullException("applicationWS");

			if( sessionToken == null)
				throw new ArgumentNullException("sessionToken");

			Setup( applicationWS );
			sessionProtocol.AuthenticationHeaderValue.SessionID = sessionToken;
		}

		private void Setup( ClarifyApplicationWS applicationWS )
		{
			this.appWS = applicationWS;

			this.sessionProtocol = new Protocol.ClarifySessionSrv();
			sessionProtocol.AuthenticationHeaderValue = new Protocol.AuthenticationHeader();

			this.sessionProtocol.Url = new Uri( BaseUri, "ClarifySessionSrv.asmx" ).ToString();
		}

		public void Logout()
		{
			this.sessionProtocol.Logout();

		}

		public bool IsActive()
		{
			return this.sessionProtocol.IsActive();
		}

		public string GetItem(string key)
		{
			return this.sessionProtocol.GetItem(key);
		}

		public Protocol.TimeZoneProtocol GetTimeZone()
		{
			return this.sessionProtocol.GetTimeZone();
		}

//		public string GetColor(string purpose)
//		{
//			return this.sessionProtocol.?;
//		}

//		public int AddAttachment(string attach_name, string file_path, string obj_type, string obj_id)
//		{
//			return this.sessionProtocol.?
//		}

		public string GetNextNumScheme(string schemeName)
		{
			return this.sessionProtocol.GetNextNumScheme( schemeName );
		}

		public void ChangePassword(string newPassword)
		{
			this.sessionProtocol.ChangePassword( newPassword );
		}

		public Protocol.ClarifyConfigItemProtocol GetConfigItem(string itemName)
		{
			return this.sessionProtocol.GetConfigItem( itemName );
		}

		public DateTime GetCurrentServerDate()
		{
			return this.sessionProtocol.GetCurrentServerDate(  );
		}

		public DateTime GetCurrentDate()
		{
			return this.sessionProtocol.GetCurrentDate(  );
		}

	}
}

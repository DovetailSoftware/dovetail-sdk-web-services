using System;
using System.ComponentModel;
using System.Web.Services;
using System.Web.Services.Protocols;
using FChoice.Foundation.Clarify;
using FChoice.WebServices.Clarify.Protocols;

namespace FChoice.WebServices.Clarify
{
	[SoapRpcService(RoutingStyle=SoapServiceRoutingStyle.SoapAction)]
	[WebService(Description="fcSDK ClarifySession Web Service", Namespace="http://www.fchoice.com/schemas/FChoice.WebServices.Clarify.ClarifySessionSrv_v1")]
	public class ClarifySessionSrv : WebService
	{
		public ClarifySessionSrv()
		{
			//CODEGEN: This call is required by the ASP.NET Web Services Designer
			InitializeComponent();
		}

		#region Component Designer generated code
		
		//Required by the Web Services Designer 
		private IContainer components = null;
				
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if(disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);		
		}
		
		#endregion

		public AuthenticationHeader AuthHeader;

		[WebMethod]
		[SoapHeader("AuthHeader")]
		public void Logout()
		{
			Global.GetSession( AuthHeader ).CloseSession();
		}

		[WebMethod]
		[SoapHeader("AuthHeader")]
		public bool IsActive()
		{
			return Global.IsSessionTokenValid( AuthHeader.SessionID );
		}

		[WebMethod]
		[SoapHeader("AuthHeader")]
		public string GetItem(string key)
		{
			ClarifySession session = Global.GetSession( AuthHeader );

			return session.Items[key].ToString();
		}

		[WebMethod]
		[SoapHeader("AuthHeader")]
		public TimeZoneProtocol GetTimeZone()
		{
			ClarifySession session = Global.GetSession( AuthHeader );

			return new TimeZoneProtocol( session.LocalTimeZone );
		}

//		[WebMethod]
//		[SoapHeader("AuthHeader")]
//		public string GetColor(string purpose)
//		{
//			ClarifySession session = Global.GetSession( AuthHeader );
//
//			return null;
//		}

//		[WebMethod]
//		[SoapHeader("AuthHeader")]
//		public int AddAttachment(string attach_name, string file_path, string obj_type, string obj_id)
//		{
//			ClarifySession session = Global.GetSession( AuthHeader );
//
//			return null;
//		}

		[WebMethod]
		[SoapHeader("AuthHeader")]
		public string GetNextNumScheme(string schemeName)
		{
			ClarifySession session = Global.GetSession( AuthHeader );

			return session.GetNextNumScheme(schemeName);
		}

		[WebMethod]
		[SoapHeader("AuthHeader")]
		public void ChangePassword(string newPassword)
		{
			ClarifySession session = Global.GetSession( AuthHeader );

			session.ChangePassword(newPassword);
		}

		[WebMethod]
		[SoapHeader("AuthHeader")]
		public ClarifyConfigItemProtocol GetConfigItem(string itemName)
		{
			ClarifySession session = Global.GetSession( AuthHeader );

			return new ClarifyConfigItemProtocol( session.ConfigItems[itemName] );
		}

		[WebMethod]
		[SoapHeader("AuthHeader")]
		public DateTime GetCurrentServerDate()
		{
			ClarifySession session = Global.GetSession( AuthHeader );

			return session.GetCurrentServerDate();
		}

		[WebMethod]
		[SoapHeader("AuthHeader")]
		public DateTime GetCurrentDate()
		{
			ClarifySession session = Global.GetSession( AuthHeader );

			return session.GetCurrentDate();
		}

	}
}

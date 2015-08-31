using System.ComponentModel;
using System.Web.Services;
using System.Web.Services.Protocols;
using FChoice.Foundation.Clarify;
using FChoice.Foundation.Clarify.DataObjects;
using FChoice.WebServices.Clarify.Protocols;

namespace FChoice.WebServices.Clarify
{
	[SoapRpcService(RoutingStyle=SoapServiceRoutingStyle.SoapAction)]
	[WebService(Description="fcSDK ClarifyApplication Web Service", Namespace="http://www.fchoice.com/schemas/FChoice.WebServices.Clarify.ClarifyApplicationSrv_v1")]
	public class ClarifyApplicationSrv : WebService
	{
		private const int WEB_SERVICES_PRODUCT_ID = 109;

		public ClarifyApplicationSrv()
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
		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#endregion

		[WebMethod]
		public string CreateSession(string userName, string password, ClarifyLoginType loginType)
		{
			ClarifySession session = ClarifyApplication.Instance.CreateSession(userName, password, loginType);
			session.RegisterLicenseRequirements(WEB_SERVICES_PRODUCT_ID);

			return session.SessionID.ToString();
		}

		[WebMethod]
		public bool IsSessionValid(string sessionToken)
		{
			return Global.IsSessionTokenValid(sessionToken);
		}

		[WebMethod]
		public string GetDatabaseVersion()
		{
			return ClarifyApplication.Instance.DatabaseVersion.ToString();
		}

		[WebMethod]
		public string GetClarifyVersion()
		{
			return ClarifyApplication.Instance.ClarifyVersion;
		}

		[WebMethod]
		public TimeZoneProtocol GetServerTimezone()
		{
			return new TimeZoneProtocol(ClarifyApplication.Instance.ServerTimeZone);
		}

		[WebMethod]
		public TimeZoneProtocol[] GetTimeZonesInCountry(string countryName)
		{
			return TimeZoneProtocol.ConvertCollection(ClarifyApplication.Instance.LocaleCache.GetTimeZonesInCountry(countryName));
		}

		[WebMethod]
		public TimeZoneProtocol GetDefaultTimeZone()
		{
			return new TimeZoneProtocol(ClarifyApplication.Instance.LocaleCache.GetDefaultTimeZone());
		}

		[WebMethod]
		public TimeZoneProtocol[] GetTimeZones()
		{
			return TimeZoneProtocol.ConvertCollection(ClarifyApplication.Instance.LocaleCache.TimeZones);
		}

		[WebMethod]
		public int GetTimeZoneObjid(string timezoneName, bool fullName)
		{
			return ClarifyApplication.Instance.LocaleCache.TimeZones[timezoneName, fullName].ObjectID;
		}

		[WebMethod]
		public bool IsTimeZone(string timezoneName)
		{
			return ClarifyApplication.Instance.LocaleCache.IsTimeZone(timezoneName);
		}

		[WebMethod]
		public HierarchicalStringElementProtocol[] GetHgbstList(string listName, params string[] elementTitles)
		{
			var elems = ClarifyApplication.Instance.ListCache.GetHgbstList(listName, elementTitles);
			var protoElems = new HierarchicalStringElementProtocol[elems.Count];

			for (int i = 0; i < elems.Count; i++)
			{
				protoElems[i] = new HierarchicalStringElementProtocol(elems[i]);
			}

			return protoElems;
		}

		[WebMethod]
		public string GetHgbstElmDefault(string listName, params string[] elementTitles)
		{
			return ClarifyApplication.Instance.ListCache.GetHgbstElmDefault(listName, elementTitles);
		}

		[WebMethod]
		public bool IsState(string country, string state, bool isFullStateName)
		{
			return ClarifyApplication.Instance.LocaleCache.IsState(country, state, isFullStateName);
		}

		[WebMethod]
		public StateProvinceProtocol GetDefaultState(string country)
		{
			return new StateProvinceProtocol(ClarifyApplication.Instance.LocaleCache.GetDefaultState(country));
		}

		[WebMethod]
		public StateProvinceProtocol[] GetStates(string country)
		{
			return StateProvinceProtocol.ConvertCollection(ClarifyApplication.Instance.LocaleCache.GetStates(country));
		}

		[WebMethod]
		public CountryProtocol[] GetCountries()
		{
			return CountryProtocol.ConvertCollection(ClarifyApplication.Instance.LocaleCache.Countries);
		}

		[WebMethod]
		public bool IsCountry(string country)
		{
			return ClarifyApplication.Instance.LocaleCache.IsCountry(country);
		}

		[WebMethod]
		public CountryProtocol GetDefaultCountry()
		{
			return new CountryProtocol(ClarifyApplication.Instance.LocaleCache.GetDefaultCountry());
		}

		[WebMethod]
		public GlobalStringListProtocol GetGbstList(string listTitle)
		{
			return new GlobalStringListProtocol(ClarifyApplication.Instance.ListCache.GetGbstList(listTitle));
		}

		[WebMethod]
		public string GetGbstDefault(string listTitle)
		{
			return ClarifyApplication.Instance.ListCache.GetGbstDefault(listTitle);
		}

//		[WebMethod]
//		public string GetGlobalStringList(string stringTitle)
//		{
//			return ClarifyApplication.Instance.ListCache.
//		}
	}
}
using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Web;
using FChoice.Common;
using FChoice.Foundation;
using FChoice.Foundation.Clarify;

namespace FChoice.WebServices.Clarify
{
	public class Global : HttpApplication
	{
		private static readonly object InitSyncRoot = new object();
		private static int sessionTimeout = int.Parse(ConfigurationManager.AppSettings["fchoice.webservices.sessiontimeout"]);
		private static Logger log = LogManager.GetLogger(typeof (Global));

		internal static bool IsPropertyDirty(int bitValue, int bitFlags)
		{
			return (bitFlags & bitValue) == bitValue;
		}

		internal static ClarifySession GetSession(AuthenticationHeader header)
		{
			if (header == null
			    || header.SessionID == null
			    || header.SessionID.Trim().Length == 0)
			{
				throw new InvalidOperationException("No Authentication Header provided.");
			}

			Guid sessionGuid = new Guid(header.SessionID);

			if (!ClarifyApplication.Instance.IsSessionValid(sessionGuid))
			{
				throw new InvalidOperationException(String.Format("Session with ID '{0}' does not exist or is no longer valid.", sessionGuid));
			}

			return ClarifyApplication.Instance.GetSession(sessionGuid);
		}

		private void InitializeClarifyApplication()
		{
			if (! ClarifyApplication.IsInitialized)
			{
				lock (InitSyncRoot)
				{
					if (! ClarifyApplication.IsInitialized)
					{
						// Set working directory to the application path
						NameValueCollection envValues = new NameValueCollection(ConfigurationManager.AppSettings);

						envValues[ConfigValues.CACHE_FILE_PATH] = Path.Combine(
							Server.MapPath("."),
							CacheManager.FC_CACHE_PATH_SUFFIX);

						//	Initialize the application
						ClarifyApplication.Initialize(envValues);
					}
				}
			}
		}

		private IContainer components = null;

		public Global()
		{
			InitializeComponent();
		}

		protected void Application_Start(Object sender, EventArgs e)
		{
		}

		protected void Session_Start(Object sender, EventArgs e)
		{
		}

		protected void Application_BeginRequest(Object sender, EventArgs e)
		{
			InitializeClarifyApplication();
		}

		protected void Application_EndRequest(Object sender, EventArgs e)
		{
		}

		protected void Application_AuthenticateRequest(Object sender, EventArgs e)
		{
		}

		protected void Application_Error(Object sender, EventArgs e)
		{
		}

		protected void Session_End(Object sender, EventArgs e)
		{
		}

		protected void Application_End(Object sender, EventArgs e)
		{
		}

		#region Web Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
		}

		#endregion

		internal static bool IsSessionTokenValid(string sessionToken)
		{
			Guid sessionID = new Guid(sessionToken);

			return ClarifyApplication.Instance.IsSessionValid(sessionID);
		}
	}
}
using System;
using System.Configuration;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;

using FChoice.WebServices.Clarify.Client;

namespace FChoice.WebServices.Clarify.Client.Demo
{
	public class Global : System.Web.HttpApplication
	{
		internal static ClarifyApplicationWS ClarifyAppWS;

		internal static ClarifySessionWS ClarifySessWS
		{
			get
			{
				if( clarifySessWS == null || !clarifySessWS.IsActive() )
				{
					NameValueCollection config = ConfigurationManager.AppSettings;

					try
					{
						clarifySessWS = 
							ClarifyAppWS.CreateSession( config["fcsdk.clarifysession.username"], 
							config["fcsdk.clarifysession.password"] );
					}
					catch(Exception ex)
					{
						throw new ApplicationException("Login failed.", ex );
					}

				}

				return clarifySessWS;
			}
		}

		private static ClarifySessionWS clarifySessWS;
		private static readonly object SyncRoot = new object();

		private System.ComponentModel.IContainer components = null;

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
			if( ClarifyAppWS == null )
			{
				lock(SyncRoot)
				{
					if( ClarifyAppWS == null )
					{
						NameValueCollection config = ConfigurationManager.AppSettings;

						if( config["fcsdk.webservices.url"] == null )
							throw new ApplicationException("Could not locate the appSetting 'fcsdk.webservices.url' in the web.config.");

						ClarifyAppWS = new ClarifyApplicationWS(config["fcsdk.webservices.url"]);
					}
				}
			}

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
	}
}


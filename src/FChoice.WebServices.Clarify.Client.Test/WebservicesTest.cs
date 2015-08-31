using System;
using System.Configuration;
using FChoice.Foundation.Clarify.Test;
using NUnit.Framework;

namespace FChoice.WebServices.Clarify.Client.Test
{
	[TestFixture]
	public class WebservicesTest : ClarifyBaseTest
	{
		protected ClarifyApplicationWS _clarifyApplicationWS;
		protected ClarifySessionWS _clarifySessionWS;
		protected Utility _utility;
		private TestWebServer _webServer;
		private Uri _webServerUrl;
		protected string _employeeLoginName;
		protected string _employeePassword;

		protected override void OnTestFixtureSetup()
		{
			string webRootDirectory = ConfigurationManager.AppSettings["ClarifyWebServices.root.dir"];
			_webServer = new TestWebServer(webRootDirectory);
			_webServerUrl = _webServer.Start();

			CreateEmployee(out _employeeLoginName, out _employeePassword);

			_clarifyApplicationWS = new ClarifyApplicationWS(_webServerUrl.AbsoluteUri);
			_clarifySessionWS = _clarifyApplicationWS.CreateSession(_employeeLoginName, _employeePassword);
			_utility = new Utility(_clarifySessionWS);
		}

		protected override void OnTestFixtureTeardown()
		{
			if (_webServer != null)
			{
				_webServer.Stop();
			}
		}
	}
}

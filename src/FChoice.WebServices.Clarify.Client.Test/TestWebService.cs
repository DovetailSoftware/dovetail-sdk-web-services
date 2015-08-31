using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;

namespace FChoice.WebServices.Clarify.Client.Test
{
	/// <summary>
	/// <para>A Web Server useful for unit tests.  Uses the same code used by the 
	/// built in WebServer (formerly known as Cassini) in VisualStudio.NET 2005. 
	/// Specifically, this needs a reference to WebServer.WebHost.dll located in 
	/// the GAC.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>If you unseal this class, make sure to make Dispose(bool disposing) a protected 
	/// virtual method instead of private.
	/// </para>
	/// <para>
	/// For more information, check out: http://haacked.com/archive/2006/12/12/Using_WebServer.WebDev_For_Unit_Tests.aspx
	/// </para>
	/// </remarks>
	public sealed class TestWebServer : IDisposable
	{
		private bool started = false;
		//private Server _webServer;
		private readonly int _webServerPort;
		private string webServerUrl = ""; //built in Start
		private readonly string _webServerVDir;
		private readonly string _webRootDirectory;

		/// <summary>
		/// Initializes a new instance of the <see cref="TestWebServer"/> class on port 8085.
		/// </summary>
		public TestWebServer(string webRootDirectory) : this(17890, "/", webRootDirectory)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="TestWebServer"/> class 
		/// using the specified port and virtual dir.
		/// </summary>
		/// <param name="port">The port.</param>
		/// <param name="virtualDir">The virtual dir.</param>
		/// <param name="webRootDirectory">The absolute directory path of the web application being served.</param>
		public TestWebServer(int port, string virtualDir, string webRootDirectory)
		{
			_webServerPort = port;
			_webServerVDir = virtualDir;
			_webRootDirectory = webRootDirectory;
		}

		#region IDisposable Members

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		#endregion

		public Uri Start()
		{
			//NOTE: WebServer.WebHost is going to load itself AGAIN into another AppDomain 
			//NOTE: so we need to make sure that it is present in the binaries for the web application.
			File.Copy("WebDev.WebHost.dll", Path.Combine(_webRootDirectory, @"bin\WebDev.WebHost.dll"), true);

			////Start the internal Web Server pointing to our test webroot
			//_webServer = new Server(_webServerPort, _webServerVDir, _webRootDirectory);
			//webServerUrl = String.Format("http://localhost:{0}{1}", _webServerPort, _webServerVDir);

			//_webServer.Start();
			started = true;
			Debug.WriteLine(String.Format("Web Server started on port {0} with VDir {1} in physical directory {2}", _webServerPort, _webServerVDir, _webRootDirectory));
			return new Uri(webServerUrl);
		}

		/// <summary>
		/// Makes a  simple GET request to the web server and returns 
		/// the result as a string.
		/// </summary>
		/// <param name="page">The page.</param>
		/// <returns></returns>
		public string RequestPage(string page)
		{
			WebClient client = new WebClient();
			string url = new Uri(new Uri(webServerUrl), page).ToString();
			using (StreamReader reader = new StreamReader(client.OpenRead(url)))
			{
				string result = reader.ReadToEnd();
				return result;
			}
		}

		/// <summary>
		/// Makes a  simple POST request to the web server and returns
		/// the result as a string.
		/// </summary>
		/// <param name="page">The page.</param>
		/// <param name="formParameters">
		/// The form paramater to post. Should be in the format "Name=Value&Name2=Value2&...&NameN=ValueN" 
		/// For extra credit, build a version of this method that uses a NameValue collection. I use a 
		/// string because it's possible you may want to post flat text.
		/// </param>
		/// <returns></returns>
		public string RequestPage(string page, string formParameters)
		{
			HttpWebRequest request = WebRequest.Create(new Uri(new Uri(webServerUrl), page)) as HttpWebRequest;

			if (request == null)
				return null; //can't imagine this happening.

			request.UserAgent = "Sutext UnitTest Webserver";
			request.Timeout = 10000; //10 secs is reasonable, no?
			request.Method = "POST";
			request.ContentLength = formParameters.Length;
			request.ContentType = "application/x-www-form-urlencoded; charset=utf-8";
			request.KeepAlive = true;

			using (StreamWriter myWriter = new StreamWriter(request.GetRequestStream()))
			{
				myWriter.Write(formParameters);
			}

			HttpWebResponse response = (HttpWebResponse) request.GetResponse();
			if (response.StatusCode < HttpStatusCode.OK && response.StatusCode >= HttpStatusCode.Ambiguous)
				return "Http Status" + response.StatusCode;

			string responseText;
			using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
			{
				responseText = reader.ReadToEnd();
			}

			return responseText;
		}

		/// <summary>
		/// Extracts a resources such as an html file or aspx page to the webroot directory
		/// and returns the filepath.
		/// </summary>
		/// <param name="resourceName">Name of the resource.</param>
		/// <param name="destinationFileName">Name of the destination file.</param>
		/// <returns></returns>
		public string ExtractResource(string resourceName, string destinationFileName)
		{
			if (!started)
				throw new InvalidOperationException("Please start the webserver before extracting resources.");

			//NOTE: if you decide to drop this class into a separate assembly (for example, 
			//into a unit test helper assembly to make it more reusable), 
			//call Assembly.GetCallingAssembly() instead.
			Assembly a = Assembly.GetExecutingAssembly();
			string filePath;
			using (Stream stream = a.GetManifestResourceStream(resourceName))
			{
				filePath = Path.Combine(_webRootDirectory, destinationFileName);
				using (StreamWriter outfile = File.CreateText(filePath))
				{
					using (StreamReader infile = new StreamReader(stream))
					{
						outfile.Write(infile.ReadToEnd());
					}
				}
			}
			return filePath;
		}

		/// <summary>
		/// Stops this instance.
		/// </summary>
		public void Stop()
		{
			Dispose();
		}

		~TestWebServer()
		{
			Dispose(false);
		}

		///<summary>
		///Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		///</summary>
		/// <remarks>
		/// If we unseal this class, make sure this is protected virtual.
		/// </remarks>
		///<filterpriority>2</filterpriority>
		private void Dispose(bool disposing)
		{
			if (disposing)
			{
				ReleaseManagedResources();
			}
		}

		private void ReleaseManagedResources()
		{
			//if (_webServer != null)
			//{
			//    _webServer.Stop();
			//    _webServer = null;
			//    started = false;
			//}
		}
	}
}
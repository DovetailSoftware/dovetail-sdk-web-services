using System;
using System.ComponentModel;
using System.Data;
using System.Web.Services;
using System.Web.Services.Protocols;
using FChoice.Foundation.Clarify;
using FChoice.WebServices.Clarify.Protocols.Generic;

namespace FChoice.WebServices.Clarify
{
	[SoapRpcService(RoutingStyle=SoapServiceRoutingStyle.SoapAction)]
	[WebService(Description="fcSDK ClarifyDataAccess Web Service", Namespace="http://www.fchoice.com/schemas/FChoice.WebServices.Clarify.ClarifyDataAccessSrv_v1")]
	public class ClarifyDataAccessSrv : WebService
	{
		public ClarifyDataAccessSrv()
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
		public string Query( QueryProtocol[] generics, bool includeSchema )
		{
			if( generics == null)
			{
				throw new ArgumentNullException("generics");
			}

			ClarifySession session = Global.GetSession( AuthHeader );

			ClarifyGenericSrvQuery query = new ClarifyGenericSrvQuery(session);
			DataSet ds = query.ExecuteDataSet( generics );

			using(System.IO.StringWriter sw = new System.IO.StringWriter() )
			{
				System.Xml.XmlTextWriter xmlWriter = new System.Xml.XmlTextWriter(sw);
				ds.WriteXml(xmlWriter, includeSchema ? XmlWriteMode.WriteSchema : XmlWriteMode.IgnoreSchema);
				sw.Flush();

				return sw.ToString();
			}
		}

		[WebMethod]
		[SoapHeader("AuthHeader")]
		public ModifierResultProtocol[] Update( ModifierProtocol[] modificationItems )
		{
			if( modificationItems == null)
			{
				throw new ArgumentNullException("modificationItems");
			}

			ClarifySession session = Global.GetSession( AuthHeader );

			ClarifyGenericSrvIUD iud = new ClarifyGenericSrvIUD( session );

			return iud.Process( modificationItems );
		}
	}
}

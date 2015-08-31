using System;
using System.Configuration;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using FChoice.WebServices.Clarify.Client;

namespace FChoice.WebServices.Clarify.Client.Demo
{
	/// <summary>
	/// Summary description for portal.
	/// </summary>
	public class portal : System.Web.UI.Page
	{
		protected MyOpenCases openCases;
		protected CreateCase createCase;
		protected CasesCreatedInLastXDays casesCreated;
		protected CreateContact createContact;

		private void Page_Load(object sender, System.EventArgs e)
		{
//			if( !IsPostBack )
//			{
//				this.openCases.UserName = ConfigurationSettings.AppSettings["ClarifySession.username"];
//			}
		}


		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);

			this.createCase.CaseCreated += new EventHandler(createCase_CaseCreated);
			
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion

		private void createCase_CaseCreated(object sender, EventArgs e)
		{
			this.openCases.DataBind();
			this.casesCreated.DataBind();
		}
	}
}

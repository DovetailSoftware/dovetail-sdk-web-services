namespace FChoice.WebServices.Clarify.Client.Demo
{
	using System;
	using System.Configuration;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using FChoice.WebServices.Clarify.Client;
	

	public class CasesCreatedInLastXDays : System.Web.UI.UserControl
	{
		#region Page Controls
		protected Label daysLabel;
		protected DataGrid casesCreatedGrid;
		#endregion

		#region Public Properties

		/// <summary>
		/// Stores how many days back to retrieve cases.
		/// The default is 5 days.
		/// </summary>
		public int DaysBack
		{
			get{ return ViewState["DaysBack"] != null ? (int)ViewState["DaysBack"] : 5; }
			set{ ViewState["DaysBack"] = value; }
		}
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			if( !IsPostBack )
			{
				this.DataBind();
			}
		}

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender (e);

			// Display DaysBack to user
			this.daysLabel.Text = this.DaysBack.ToString();
		}


		public override void DataBind()
		{
			base.DataBind ();

			// Get session from Global.asax.cs
			ClarifySessionWS session = Global.ClarifySessWS;

			// Create ClarifyDataAccessWS
			ClarifyDataAccessWS dataAccess = new ClarifyDataAccessWS( session );

			// Create new DataQuery to query view "qry_case_view"
			DataQuery caseQuery = dataAccess.CreateDataQuery("qry_case_view");

			// Set fields to select
			caseQuery.DataFields.AddRange( 
				new string[]{"id_number", "site_name", "title", "condition", "status", "creation_time", "owner"} );

			// Append filters for query
			caseQuery.AppendFilter( "creation_time", "MoreThanOrEqual", DateTime.Now.AddDays(DaysBack * -1).ToShortDateString() );

			// Append sorting for query
			caseQuery.AppendSort( "creation_time", false );

			// Get Xml result
			string result = caseQuery.Query(true);

			// Create a string reader to read the result
			System.IO.StringReader reader = new System.IO.StringReader(result);

			// Create and load the DataSet with the result
			DataSet ds = new DataSet();
			ds.ReadXml( reader );

			// Data bind DataGrid to result table in DataSet
			this.casesCreatedGrid.DataSource = ds.Tables["qry_case_view"];
			this.casesCreatedGrid.DataBind();
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Load += new System.EventHandler(this.Page_Load);
			this.casesCreatedGrid.PageIndexChanged += new DataGridPageChangedEventHandler(casesCreatedGrid_PageIndexChanged);
		}
		#endregion

		private void casesCreatedGrid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
		{
			this.casesCreatedGrid.CurrentPageIndex = e.NewPageIndex;
			this.DataBind();
		}
	}
}

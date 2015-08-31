namespace FChoice.WebServices.Clarify.Client.Demo
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using System.Configuration;
	using System.Web.Services.Protocols;
	using System.Text.RegularExpressions;

	using FChoice.WebServices.Clarify.Client;
	using FChoice.WebServices.Clarify.Client.Support;
	using FChoice.WebServices.Clarify.Client.Protocols.ClarifyApplicationSrv;
	using FChoice.WebServices.Clarify.Client.Protocols.SupportToolkitSrv;

	/// <summary>
	///		Shows how to create a new case using the FCCS toolkit APIs via web services.
	/// </summary>
	public class CreateCase : System.Web.UI.UserControl
	{

		#region Page Controls
		protected TextBox siteID;
		protected TextBox firstName;
		protected TextBox lastName;
		protected TextBox phoneNumber;
		protected TextBox phoneLog;
		protected TextBox title;
		protected DropDownList caseType;

		protected ValidationSummary validSummary;
		protected RequiredFieldValidator requiredSiteID;
		protected RequiredFieldValidator requiredPhoneLog;
		protected RequiredFieldValidator requiredTitle;
		protected RequiredFieldValidator requiredCaseType;

		protected RequiredFieldValidator requiredFirstName;
		protected RequiredFieldValidator requiredLastName;
		protected RequiredFieldValidator requiredPhoneNumber;

		protected LinkButton createCaseLink;
		protected Label messageLabel;
		#endregion

		#region Events
		public event EventHandler CaseCreated;

		private void OnCaseCreated(EventArgs e)
		{
			if(this.CaseCreated != null )
				this.CaseCreated(this, e);
		}
		#endregion
 
		private void Page_Load(object sender, System.EventArgs e)
		{
			if( !IsPostBack )
			{
				DataBindCaseType();
			}
		}

		private void DataBindCaseType()
		{
			// Get Case Types
			GlobalStringListProtocol caseTypes = Global.ClarifyAppWS.GetGbstList("Case Type");

			// Clear and Add default element
			caseType.Items.Clear();
			caseType.Items.Add( new ListItem("-- Select Type --","") );

			// Add elements to list
			foreach(GlobalStringElementProtocol elem in caseTypes.Elements)
			{
				caseType.Items.Add( new ListItem( elem.Title ) );
			}
		}

		private void CreateNewCase()
		{
			this.EnsureChildControls();

			try
			{
				EnableValidators();
				Page.Validate();

				if( Page.IsValid )
				{
					// Create new Support Toolkit web service client
					SupportToolkitWS supportWS = new SupportToolkitWS( Global.ClarifySessWS );

					// Create setup object for creating a case
					CreateCaseSetupWS setup = new CreateCaseSetupWS(
						siteID.Text, firstName.Text, lastName.Text, phoneNumber.Text );

					// Set additional information
					setup.CaseType = caseType.SelectedValue;
					setup.PhoneLogNotes = phoneLog.Text;
					setup.Title = title.Text;

					// Invoke web service to create case
					ToolkitResultProtocol result = supportWS.CreateCase( setup );

					// Show result ID
					this.messageLabel.Text = String.Format("<b>Case {0} created successfully.</b>", result.IDNum);

					ClearEntryFields();

					// Fire event to let the Page know that the DataGrid need to be rebinded so that our new case will appear there.
					this.OnCaseCreated(EventArgs.Empty);
				}
			}
			catch(SoapException ex)
			{
				string message = ex.Detail.InnerText.Trim().Length > 0 ? ex.Detail.InnerText.Trim() : ex.Message;
				this.messageLabel.Text += String.Format("<b>Error adding case.</b><br/>{0}", message.Replace("\n","<br/>") );
			}
		}

		private void EnableValidators()
		{
			this.validSummary.Enabled = true;
			this.requiredCaseType.Enabled = true;
			this.requiredPhoneLog.Enabled = true;
			this.requiredSiteID.Enabled = true;
			this.requiredTitle.Enabled = true;

			this.requiredFirstName.Enabled = true;
			this.requiredLastName.Enabled = true;
			this.requiredPhoneNumber.Enabled = true;
		}

		private void ClearEntryFields()
		{
			this.siteID.Text = "";
			this.firstName.Text = "";
			this.lastName.Text = "";
			this.phoneNumber.Text = "";
			this.phoneLog.Text = "";
			this.title.Text = "";
			this.caseType.SelectedIndex = 0;
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
			this.createCaseLink.Click += new EventHandler(createCaseLink_Click);
		}
		#endregion

		private void createCaseLink_Click(object sender, EventArgs e)
		{
			this.CreateNewCase();
		}
	}
}

namespace FChoice.WebServices.Clarify.Client.Demo
{
	using System;
	using System.Configuration;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using System.Web.Services.Protocols;
	using System.Text.RegularExpressions;

	using FChoice.WebServices.Clarify.Client;
	using FChoice.WebServices.Clarify.Client.Protocols.ClarifyApplicationSrv;
	using FChoice.WebServices.Clarify.Client.Protocols.ClarifyDataAccessSrv;

	/// <summary>
	///		This class shows an example of how to use FCWSGenericUpdateClient API.
	/// </summary>
	public class CreateContact : System.Web.UI.UserControl
	{
		#region Page Controls
		protected TextBox siteName;

		protected TextBox firstName;
		protected TextBox lastName;
		protected TextBox phoneNumber;

		protected TextBox address1;
		protected TextBox address2;
		protected TextBox city;
		protected DropDownList state;
		protected TextBox zip;

		protected ValidationSummary validSummary;
		protected RequiredFieldValidator requiredSiteName;

		protected RequiredFieldValidator requiredFirstName;
		protected RequiredFieldValidator requiredLastName;
		protected RequiredFieldValidator requiredPhoneNumber;

		protected RequiredFieldValidator requiredAddress1;
		protected RequiredFieldValidator requiredAddress2;
		protected RequiredFieldValidator requiredCity;
		protected RequiredFieldValidator requiredState;
		protected RequiredFieldValidator requiredZip;

		protected LinkButton saveLink;
		protected Label messageLabel;
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			if( !IsPostBack )
			{
				DataBindState();
			}
		}

		/// <summary>
		/// Builds the DropDownList for state selection.
		/// </summary>
		private void DataBindState()
		{
			//	Get default country
			CountryProtocol defaultCountry = Global.ClarifyAppWS.GetDefaultCountry();

			// Get states
			StateProvinceProtocol[] states = Global.ClarifyAppWS.GetStates( defaultCountry.Name );

			// Clear and Add default element
			state.Items.Clear();
			state.Items.Add( new ListItem("-- Select State --","") );

			// Add elements to list
			foreach(StateProvinceProtocol stateProv in states)
			{
				state.Items.Add( new ListItem( stateProv.FullName ) );
			}
		}

		private void CreateNewContact()
		{
			try
			{
				EnableValidators();
				Page.Validate();

				if( Page.IsValid )
				{
					// Create new Clarify Data Access Web Service Client
					ClarifyDataAccessWS dataAccess = new ClarifyDataAccessWS( Global.ClarifySessWS );

					// Create a DataModifier for modifying data on the database
					DataModifier dataModifier = dataAccess.CreateDataModifier();

					// Create modify items for the tables we want to insert new records
					InsertModifier contactInsert = dataModifier.CreateInsertModifier( "contactInsert", "contact" );
					InsertModifier contactRoleInsert = dataModifier.CreateInsertModifier( "contactRoleInsert", "contact_role" );
					InsertModifier siteInsert = dataModifier.CreateInsertModifier( "siteInsert", "site" );
					InsertModifier addressInsert = dataModifier.CreateInsertModifier( "addressInsert", "address" );
					ReferenceModifier stateProvRef = dataModifier.CreateReferenceModifier( "stateProvRef", "state_prov" );
					ReferenceModifier timezoneRef = dataModifier.CreateReferenceModifier( "timezoneRef", "time_zone" );
					ReferenceModifier countryRef = dataModifier.CreateReferenceModifier( "countryRef", "country" );

					// Append fields that we want to insert values into
					contactInsert.SetField("first_name", this.firstName.Text);
					contactInsert.SetField("last_name", this.lastName.Text);
					contactInsert.SetField("phone", this.phoneNumber.Text);

					// Relate this inserted record to another Modifier
					contactInsert.RelateRecord("contact2contact_role", contactRoleInsert);

					contactRoleInsert.SetField("role_name", "Default");
					contactRoleInsert.SetField("primary_site", "1");
					contactRoleInsert.RelateRecord("contact_role2site", siteInsert);

					// Get next Site ID from web service
					string siteID = Global.ClarifySessWS.GetNextNumScheme("Site ID");

					siteInsert.SetField("site_id", siteID);
					siteInsert.SetField("name", this.siteName.Text);
					siteInsert.RelateRecord("cust_primaddr2address", addressInsert);
					siteInsert.RelateRecord("cust_billaddr2address", addressInsert);
					siteInsert.RelateRecord("cust_shipaddr2address", addressInsert);

					addressInsert.SetField("address", this.address1.Text);
					addressInsert.SetField("address_2", this.address2.Text);
					addressInsert.SetField("city", this.city.Text);
					addressInsert.SetField("state", this.state.SelectedValue);
					addressInsert.SetField("zipcode", this.zip.Text);
					addressInsert.RelateRecord("address2state_prov", stateProvRef);
					addressInsert.RelateRecord("address2time_zone", timezoneRef);
					addressInsert.RelateRecord("address2country", countryRef);
				
					// This we select an existing record to use as a relation for addressInsert
					stateProvRef.AppendUniqueFilter("full_name", this.state.SelectedValue);
					timezoneRef.AppendUniqueFilter("name", "CST");
					countryRef.AppendUniqueFilter("name", "USA");

					// Run the query and retrieve the results
					ModifierResultProtocol[] results =  dataModifier.Update();

					//  Show the results to the user
					System.Text.StringBuilder sb = new System.Text.StringBuilder();
					foreach(ModifierResultProtocol result in results)
					{
						if(sb.Length > 0)
							sb.Append("<br/>");

						sb.Append( string.Format("{0} on table [{1}] with objid of [{2}]", result.Action, result.Table, result.Objid) );
					}

					this.messageLabel.Text = String.Format("<b>Save successful.</b><br/>" + sb.ToString() );

					// Clear form
					ClearEntryFields();
				}
			}
			catch(SoapException ex)
			{
				string message = ex.Detail.InnerText.Trim().Length > 0 ? ex.Detail.InnerText.Trim() : ex.Message;
				this.messageLabel.Text += String.Format("<b>Error adding contact.</b><br/>{0}", message.Replace("\n","<br/>") );
			}
		}

		private void EnableValidators()
		{
			this.validSummary.Enabled = true;
			requiredSiteName.Enabled = true;
			requiredFirstName.Enabled = true;
			requiredLastName.Enabled = true;
			requiredPhoneNumber.Enabled = true;
			requiredAddress1.Enabled = true;
			requiredAddress2.Enabled = true;
			requiredCity.Enabled = true;
			requiredState.Enabled = true;
			requiredZip.Enabled = true;
		}

		private void ClearEntryFields()
		{
			siteName.Text = "";

			firstName.Text = "";
			lastName.Text = "";
			phoneNumber.Text = "";

			address1.Text = "";
			address2.Text = "";
			city.Text = "";
			state.SelectedIndex = 0;
			zip.Text = "";
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
			this.saveLink.Click += new EventHandler(saveLink_Click);
		}
		#endregion

		private void saveLink_Click(object sender, EventArgs e)
		{
			CreateNewContact();
		}
	}
}

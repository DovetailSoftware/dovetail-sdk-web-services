<%@ Control Language="c#" AutoEventWireup="false" Codebehind="CreateCase.ascx.cs" Inherits="FChoice.WebServices.Clarify.Client.Demo.CreateCase" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<table cellspacing=0 class="gridFrame" width="100%" >
	<tr>
		<td class="gridTitle">Create New Case</td>
	</tr>
	<tr>
		<td>
			<table cellspacing="0" width="100%" style="border:solid 1px">
				<tr class="gridItemRow">
					<td colspan="2" >
						<asp:Label EnableViewState="False" CssClass="errorMsg" ID="messageLabel" Runat="server"/>
						<asp:ValidationSummary EnableViewState="False" ID="validSummary" Enabled="False" Runat="server" EnableClientScript="True" ShowSummary="True" HeaderText="The following fields are required and are missing:" />
					</td>
				</tr>				
				<tr class="gridItemRow">
					<td valign="top" align="right">Site ID:</td>
					<td>
						<asp:TextBox ID="siteID" Runat="server" Columns="45" />
						<asp:RequiredFieldValidator EnableViewState="False" ID="requiredSiteID" Enabled="false" Runat="server" ControlToValidate="siteID" ErrorMessage="Site ID">*</asp:RequiredFieldValidator>
					</td>
				</tr>
				<tr class="gridItemRow">
					<td valign="top" align="right">First Name:</td>
					<td>
						<asp:TextBox ID="firstName" Runat="server" Columns="45" />
						<asp:RequiredFieldValidator EnableViewState="False" Enabled="false" Runat="server" ControlToValidate="firstName" ErrorMessage="First Name" ID="requiredFirstName" >*</asp:RequiredFieldValidator>
					</td>
				</tr>
				<tr class="gridItemRow">
					<td valign="top" align="right">Last Name:</td>
					<td>
						<asp:TextBox ID="lastName" Runat="server" Columns="45" />
						<asp:RequiredFieldValidator EnableViewState="False" Enabled="false" Runat="server" ControlToValidate="lastName" ErrorMessage="Last Name" ID="requiredLastName" >*</asp:RequiredFieldValidator>
					</td>
				</tr>		
				<tr class="gridItemRow">
					<td valign="top" align="right">Phone Number:</td>
					<td>
						<asp:TextBox ID="phoneNumber" Runat="server" Columns="45" />
						<asp:RequiredFieldValidator EnableViewState="False" Enabled="false" Runat="server" ControlToValidate="phoneNumber" ErrorMessage="Phone Number" ID="requiredPhoneNumber" >*</asp:RequiredFieldValidator>
					</td>
				</tr>	
				<tr class="gridItemRow">
					<td valign="top" align="right">Case Title:</td>
					<td>
						<asp:TextBox ID="title" Runat="server" Columns="45"/>
						<asp:RequiredFieldValidator EnableViewState="False" Enabled="false" Runat="server" ControlToValidate="title" ErrorMessage="Case Title" ID="requiredTitle" >*</asp:RequiredFieldValidator>
					</td>
				</tr>	
				<tr class="gridItemRow">
					<td valign="top" align="right">Case Type:</td>
					<td>
						<asp:DropDownList ID="caseType" Runat="server" />
						<asp:RequiredFieldValidator EnableViewState="False" Enabled="false" Runat="server" ControlToValidate="caseType" ErrorMessage="Case Type" ID="requiredCaseType">*</asp:RequiredFieldValidator>
					</td>
				</tr>					
				<tr class="gridItemRow">
					<td valign="top" align="right">Phone Log:</td>
					<td>
						<asp:TextBox ID="phoneLog" Runat="server" TextMode="MultiLine" Columns="40" Rows="3" />
						<asp:RequiredFieldValidator EnableViewState="False" Enabled="false" Runat="server" ControlToValidate="phoneLog" ErrorMessage="Phone Log" ID="requiredPhoneLog">*</asp:RequiredFieldValidator>
					</td>
				</tr>						
				<tr class="gridItemRow">
					<td class="commandButton" colspan="2" align="center"><asp:LinkButton ID="createCaseLink" Runat="server" CausesValidation="False">Create Case</asp:LinkButton></td>
				</tr>																
			</table>
		</td>
	</tr>
</table>
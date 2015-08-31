<%@ Control Language="c#" AutoEventWireup="false" Codebehind="CreateContact.ascx.cs" Inherits="FChoice.WebServices.Clarify.Client.Demo.CreateContact" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<table cellspacing=0 class="gridFrame" width="100%" >
	<tr>
		<td class="gridTitle">Create New Contact</td>
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
					<td colspan="2" valign="top" align="center"><b>Site</b></td>
				</tr>					
				<tr class="gridItemRow">
					<td valign="top" align="right">Site Name:</td>
					<td>
						<asp:TextBox ID="siteName" Runat="server" Columns="45" />
						<asp:RequiredFieldValidator EnableViewState="False" Enabled="False" Runat="server" ControlToValidate="siteName" ErrorMessage="Site Name" ID="requiredSiteName">*</asp:RequiredFieldValidator>
					</td>
				</tr>
				
				<tr class="gridItemRow">
					<td colspan="2" valign="top" align="center"><hr size="1" width="95%"/></td>
				</tr>
				<tr class="gridItemRow">
					<td colspan="2" valign="top" align="center"><b>Contact</b></td>
				</tr>						
													
				<tr class="gridItemRow">
					<td valign="top" align="right">First Name:</td>
					<td>
						<asp:TextBox ID="firstName" Runat="server" Columns="45" />
						<asp:RequiredFieldValidator EnableViewState="False" Enabled="False" Runat="server" ControlToValidate="firstName" ErrorMessage="First Name" ID="requiredFirstName">*</asp:RequiredFieldValidator>
					</td>
				</tr>
				<tr class="gridItemRow">
					<td valign="top" align="right">Last Name:</td>
					<td>
						<asp:TextBox ID="lastName" Runat="server" Columns="45" />
						<asp:RequiredFieldValidator EnableViewState="False" Enabled="False" Runat="server" ControlToValidate="lastName" ErrorMessage="Last Name" ID="requiredLastName">*</asp:RequiredFieldValidator>						
					</td>
				</tr>		
				<tr class="gridItemRow">
					<td valign="top" align="right">Phone Number:</td>
					<td>
						<asp:TextBox ID="phoneNumber" Runat="server" Columns="45" />
						<asp:RequiredFieldValidator EnableViewState="False" Enabled="False" Runat="server" ControlToValidate="phoneNumber" ErrorMessage="Phone Number" ID="requiredPhoneNumber">*</asp:RequiredFieldValidator>						
					</td>
				</tr>

				<tr class="gridItemRow">
					<td colspan="2" valign="top" align="center"><hr size="1" width="95%"/></td>
				</tr>
				<tr class="gridItemRow">
					<td colspan="2" valign="top" align="center"><b>Address</b></td>
				</tr>						
				
				<tr class="gridItemRow">
					<td valign="top" align="right">Address 1:</td>
					<td>
						<asp:TextBox ID="address1" Runat="server" Columns="45" />
						<asp:RequiredFieldValidator EnableViewState="False" Enabled="False" Runat="server" ControlToValidate="address1" ErrorMessage="Address 1" ID="requiredAddress1">*</asp:RequiredFieldValidator>						
					</td>
				</tr>		
				<tr class="gridItemRow">
					<td valign="top" align="right">Address 2:</td>
					<td>
						<asp:TextBox ID="address2" Runat="server" Columns="45" />
						<asp:RequiredFieldValidator EnableViewState="False" Enabled="False" Runat="server" ControlToValidate="address2" ErrorMessage="Address 2" ID="requiredAddress2">*</asp:RequiredFieldValidator>						
					</td>
				</tr>
				<tr class="gridItemRow">
					<td valign="top" align="right">City:</td>
					<td>
						<asp:TextBox ID="city" Runat="server" Columns="45" />
						<asp:RequiredFieldValidator EnableViewState="False" Enabled="False" Runat="server" ControlToValidate="city" ErrorMessage="City" ID="requiredCity">*</asp:RequiredFieldValidator>						
					</td>
				</tr>		
				<tr class="gridItemRow">
					<td valign="top" align="right">State:</td>
					<td>
						<asp:DropDownList ID="state" Runat="server" />
						<asp:RequiredFieldValidator EnableViewState="False" Enabled="False" Runat="server" ControlToValidate="state" ErrorMessage="State" ID="requiredState">*</asp:RequiredFieldValidator>						
					</td>
				</tr>		
				<tr class="gridItemRow">
					<td valign="top" align="right">Zip:</td>
					<td>
						<asp:TextBox ID="zip" Runat="server" Columns="45" />
						<asp:RequiredFieldValidator EnableViewState="False" Enabled="False" Runat="server" ControlToValidate="zip" ErrorMessage="Zip" ID="requiredZip">*</asp:RequiredFieldValidator>						
					</td>
				</tr>													
				
				<tr class="gridItemRow">
					<td class="commandButton" colspan="2" align="center"><asp:LinkButton ID="saveLink" Runat="server" CausesValidation="False">Save</asp:LinkButton></td>
				</tr>																
			</table>
		</td>
	</tr>
</table>
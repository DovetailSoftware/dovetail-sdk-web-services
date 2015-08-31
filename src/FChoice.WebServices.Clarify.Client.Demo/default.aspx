<%@ Page language="c#" Codebehind="default.aspx.cs" AutoEventWireup="false" Inherits="FChoice.WebServices.Clarify.Client.Demo.portal"  %>
<%@ Register TagPrefix="FChoice" TagName="MyOpenCases" Src="MyOpenCases.ascx" %>
<%@ Register TagPrefix="FChoice" TagName="CasesCreated" Src="CasesCreatedInLastXDays.ascx" %>
<%@ Register TagPrefix="FChoice" TagName="CreateCase" Src="CreateCase.ascx" %>
<%@ Register TagPrefix="FChoice" TagName="CreateContact" Src="CreateContact.ascx" %>
<%@ Register TagPrefix="FChoice" Namespace="FChoice.WebServices.Clarify.Client.Demo" Assembly="FChoice.WebServices.Clarify.Client.Demo" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
    <title>fcSDK WebServices Client Demo</title>
    <meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" Content="C#">
    <meta name=vs_defaultClientScript content="JavaScript">
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
    <LINK rel="stylesheet" type="text/css" href="style.css">
  </HEAD>
  <body >
	
    <form id="Form1" method="post" runat="server">
			<table width="100%" cellspacing=0 cellpadding=5>
				<tr class="pageHeader"><td valign="middle" colspan=2><h3>fcSDK WebServices Portal Sample</h3></td></tr>
				<tr class="pageHeaderBar" height="2"><td colspan=2></td></tr>
				<tr>
					<td colspan="2" class="text" width="100%" valign="top">
						<p>Welcome to the portal sample application which demonstrates how to use our fcSDK WebServices Client to access Clarify data using fcSDK WebServices. 
						All of the samples on this page are broken up into simple ASP.NET users controls which you can use as a starting point in creating our own applications using the web service client. 
						The logic is implemented in the code behind of each user control.</p>
					</td>			
				</tr>
				
				<tr><td colspan=2>&nbsp;</td></tr>
				
				<tr>
					<td width="50%" class="text" valign="top">				
						<p>The <b>My Open Cases</b> examples show how to query data from the Clarify database using ClarifyDataAccessWS class.
						In the DataBind() method of the MyOpenCases user control, the data is return in the form of a DataSet which serves as the DataSource for an ASP.NET DataGrid control.</p>
					</td>
					<td width="50%" valign="top">
						<FChoice:MyOpenCases runat=server ID="openCases" />						
					</td>							
				</tr>
				
				<tr><td colspan=2>&nbsp;</td></tr>
				
				<tr>
					<td valign="top">
						<FChoice:CasesCreated runat=server ID="casesCreated" />
					</td>					
					<td class="text" valign="top">				
					<p>
						The <b>Cases Created in Last 5 Days</b> works the same as the <b>My Open Cases</b> example.
					</p>
					</td>
				</tr>
				
				<tr><td colspan=2>&nbsp;</td></tr>
								
				<tr>
					<td class="text" valign="top">				
						<p>
							The <b>Create New Case</b> example shows you how to call a method using our toolkit APIs.
							Each toolkit can be accessed via the web service client which in turn will call the toolkit API on the web service server.
							The DataBindCaseType() shows how one can data bind a DropDownList control using the ClarifyApplicationWS.GetGbstList() method.
						</p>
					</td>				
					<td valign="top">
						<FChoice:CreateCase runat=server ID="createCase" />
					</td>				
				</tr>
				
				<tr><td colspan=2>&nbsp;</td></tr>

				<tr>
					<td valign="top">
						<FChoice:CreateContact runat=server ID="createContact" />	
					</td>					
					<td class="text" valign="top">				
						<p>
							The <b>Create New Contact</b> example shows you how to update data using DataModifier API which is created from ClarifyDataAccessWS.CreateDataModifier().
							It shows how you can insert and relate new records as well as referencing existing records.
							With the DataModifier API, you can instruct the fcSDK WebServices to Insert, Update and Delete records by respectably using the CreateInsertModifier(), CreateUpdateModifier() and CreateDeleteModifier() methods of the DataModifier class.
							You then can then specify fields to update or use relations as shown in the example.
						</p>
					</td>	
				</tr>									
			</table>
			<FChoice:PostBackPageScroll runat=server ID="postBackPageScroll" />
     </form>
	
  </body>
</HTML>

<%@ Control Language="c#" AutoEventWireup="false" Codebehind="CasesCreatedInLastXDays.ascx.cs" Inherits="FChoice.WebServices.Clarify.Client.Demo.CasesCreatedInLastXDays" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<table cellspacing=0 class="gridFrame" width="100%" >
	<tr>
		<td class="gridTitle">Cases Created in Last <asp:Label ID="daysLabel" Runat="server" /> Days</td>
	</tr>
	<tr>
		<td>
			<asp:DataGrid 
				ID="casesCreatedGrid"
				Runat="server"
				AutoGenerateColumns="false"
				HeaderStyle-CssClass="gridHeading"
				ItemStyle-CssClass="gridItemRow"
				AlternatingItemStyle-CssClass="gridAltItemRow"
				GridLines=Both
				width="100%"
				AllowPaging="True"
				PagerStyle-Mode="NumericPages"
				PagerStyle-HorizontalAlign="Right"				
				>
				
				<Columns>
					<asp:BoundColumn DataField="id_number" HeaderText="ID" />
					<asp:HyperLinkColumn HeaderText="Title" DataNavigateUrlFormatString="javascript:alert('You can add a link to view case {0} information here.');" DataTextField="title" DataNavigateUrlField="id_number" />
					<asp:BoundColumn DataField="condition" HeaderText="Condition" />
					<asp:BoundColumn DataField="status" HeaderText="Status" />
					<asp:BoundColumn DataField="creation_time" HeaderText="Time Created" />
					<asp:BoundColumn DataField="owner" HeaderText="Owner" />
				</Columns>

			</asp:DataGrid>
		</td>
	</tr>
</table>
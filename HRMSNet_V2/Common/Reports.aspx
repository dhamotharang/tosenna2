<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Reports.aspx.cs" Inherits="SchoolNet.Reports" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
 <master:content id="formData" runat="server" height="100%" width="100%">
 <table border="0" cellspacing="0" cellpadding="0" class="primary"> 
  <ASP:PlaceHolder id="ManageCRUD" Runat="server" Visible="true">
    <tr width="100%">
		<td class="colheader"><span class="maintitledesign">Reports Wizard</span></td>
	</tr>
  <tr>
    <td width=100%>
        <table width="100%" border="0" class="Partgrayblock">
       <tr><td>

          <asp:DataGrid ID="Grid" CssClass="Tabular2" runat="server" Width="100%" PageSize="15"  AllowPaging="True"  DataKeyField="ReportID" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" onPageIndexChanged="Grid_PageIndexChanged" 
                         OnEditCommand="Grid_EditCommand" Caption='<table border="0" width="100%" cellpadding="0" cellspacing="0"><tr><td>&nbsp;</td></tr></table>' CaptionAlign="Top">
                      <Columns>
                            <asp:BoundColumn HeaderText="Report ID" DataField="ReportID" ItemStyle-Width="10%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Report Name" DataField="ReportName" ItemStyle-Width="45%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Report Type" DataField="ReportType" ItemStyle-Width="33%"></asp:BoundColumn>
                            <asp:HyperLinkColumn HeaderText="Go To Page" DataNavigateUrlField="ReportURL" Text="Extract" ItemStyle-Width="12%"/>
                            
<%--                            <asp:TemplateColumn HeaderText="" ItemStyle-Width="8%">
                                 <ItemTemplate> 
                                     <asp:LinkButton name="Edit" DataField="ReportURL" CommandName="Edit" Text="Extract" CausesValidation="false" runat="server" /> 
                            </ItemTemplate>
                            </asp:TemplateColumn> --%>                          

                      </Columns>
                        <FooterStyle CssClass="DashGridFooter" />
                        <SelectedItemStyle CssClass="DashGridSelectedItem" />
                        <PagerStyle CssClass="DashGridPagerItem" HorizontalAlign="Center" Mode="NumericPages" />
                        <AlternatingItemStyle CssClass="DashGridAltItem" />
                        <ItemStyle CssClass="DashGridItem" />
                        <HeaderStyle CssClass="DashGridHeader" />
        </asp:DataGrid>
        </td></tr>
        </table>
   </td>     
</tr>
<tr width="100%"><td>&nbsp;</td></tr>
</ASP:PlaceHolder>
</TABLE>
</master:content>






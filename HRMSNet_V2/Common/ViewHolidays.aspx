<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewHolidays.aspx.cs" Inherits="SchoolNet.ViewHolidays" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
 <master:content id="formData" runat="server" height="100%" width="100%">
 <table border="0" cellspacing="0" cellpadding="0" height="100%" width="100%">
 <tr><td class="colheader"><span class="maintitledesign">Company Holidays for the Current Year</span></td></tr>
 <asp:PlaceHolder id="LeaveTypeTab" Runat="server" visible="true">
 <tr><td width="100%"> 
    
      <table width="100%" border="0" class="Partgrayblock">
                <tr><td>&nbsp;</td></tr>
             <tr width="100%">
                <td width="100%">
                    <asp:DataGrid ID="Grid" CssClass="Tabular2" runat="server" Width="100%" PageSize="12" AllowPaging="True" DataKeyField="HolidayID" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="Grid_PageIndexChanged">                                 
                    
                        <Columns>
                            <asp:BoundColumn HeaderText="Holiday Name" DataField="HolidayName" ItemStyle-Width="60%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Holiday Date" DataField="Holiday_Date" ItemStyle-Width="22%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Country" DataField="CountryName" ItemStyle-Width="18%"></asp:BoundColumn>
                       </Columns>                          
                        <FooterStyle CssClass="DashGridFooter" />
                        <SelectedItemStyle CssClass="DashGridSelectedItem" />
                        <PagerStyle CssClass="GridPagerItem" HorizontalAlign="Center" Mode="NumericPages" />
                        <AlternatingItemStyle CssClass="DashGridAltItem" />
                        <ItemStyle CssClass="DashGridItem" />
                        <HeaderStyle CssClass="DashGridHeader" />
                    </asp:DataGrid>
                    <br /><center><asp:label id ="emptyRow" value="" visible=false runat="server" /></center>           
           
                </td>
            </tr>
	       </table>   	 
	
 </td>
</tr>
</asp:placeholder>
</table>
										
</master:content>


<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewHolidays.aspx.cs" Inherits="SchoolNet.ViewHolidays" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
 <master:content id="formData" runat="server" height="100%" width="100%">
 <table border="0" cellspacing="0" cellpadding="0" height="100%" width="100%">
 <asp:PlaceHolder id="LeaveTypeTab" Runat="server" visible="true">
 <tr><td width="100%"> 
    <fieldset><legend>Company Holidays for the Current Year</legend>
      <table width="100%" border="0">
             <tr width="100%">
                <td width="100%">
                    <asp:DataGrid ID="Grid" runat="server" Width="100%" PageSize="12" AllowPaging="True" DataKeyField="HolidayID" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="Grid_PageIndexChanged">                                 
                    
                        <Columns>
                            <asp:BoundColumn HeaderText="Holiday Name" DataField="HolidayName" ItemStyle-Width="60%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Holiday Date" DataField="Holiday_Date" ItemStyle-Width="22%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Country" DataField="CountryName" ItemStyle-Width="18%"></asp:BoundColumn>
                       </Columns>                          
                        <FooterStyle CssClass="GridFooter" />
                        <SelectedItemStyle CssClass="GridSelectedItem" />
                        <PagerStyle CssClass="GridPagerItem" HorizontalAlign="Center" Mode="NumericPages" />
                        <AlternatingItemStyle CssClass="GridAltItem" />
                        <ItemStyle CssClass="GridItem" />
                        <HeaderStyle CssClass="GridHeader" />
                    </asp:DataGrid>
                    <br /><center><asp:label id ="emptyRow" value="" visible=false runat="server" /></center>           
           
                </td>
            </tr>
	       </table>   	 
	</fieldset>
 </td>
</tr>
</asp:placeholder>
</table>
										
</master:content>


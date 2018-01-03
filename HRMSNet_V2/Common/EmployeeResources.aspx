<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmployeeResources.aspx.cs" Inherits="SchoolNet.EmployeeResources" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
 <master:content id="formData" runat="server" height="100%" width="100%">
 <table border="0" cellspacing="0" cellpadding="0" height="100%" width="100%">
 <tr><td class="colheader"><span class="maintitledesign">Employee Manuals and HR Policy Documents</span></td></tr>
 <tr><td>&nbsp;</td></tr>
 <tr>
    <td width="100%"> 
      <table width="100%" border="0" class="Partgrayblock">
        <tr>
            <td width="100%">
 <asp:PlaceHolder id="EmployeeResTab" Runat="server" visible="true">
                    <asp:DataGrid ID="DOCGrid" CssClass="Tabular2" runat="server" Width="100%" PageSize="15" AllowPaging="True" DataKeyField="DocumentID" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="DOCGrid_PageIndexChanged" >                                
                             
                      <Columns>
                            <asp:TemplateColumn HeaderText="Document Name" ItemStyle-Width="45%">                                
                                <ItemTemplate>
                                    <a id="A1" href='<%# "~/DocResources/" + Eval("DocumentName")%>' runat="server" target="_blank"><%# Eval("DocumentName")%></a> 
                                </ItemTemplate> 
                            </asp:TemplateColumn>
                
                            <asp:BoundColumn HeaderText="Document Type" DataField="DocumentTypeName" ItemStyle-Width="15%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Comments" DataField="Doc_Comments" ItemStyle-Width="20%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Last Updated" DataField="Date_Updated" ItemStyle-Width="18%"></asp:BoundColumn>
                       </Columns>     
                        <FooterStyle CssClass="DashGridFooter" />
                        <SelectedItemStyle CssClass="DashGridSelectedItem" />
                        <PagerStyle CssClass="GridPagerItem" HorizontalAlign="Center" Mode="NumericPages" />
                        <AlternatingItemStyle CssClass="DashGridAltItem" />
                        <ItemStyle CssClass="DashGridItem" />
                        <HeaderStyle CssClass="DashGridHeader" />
                    </asp:DataGrid>
                    <br/>
                    <center><asp:label id ="emptyRow3" value="" visible=false runat="server" /></center>           
      </asp:placeholder>     
      </td></tr>
      </table>
       </td>
    </tr>           				    	    

</table>
										
</master:content>





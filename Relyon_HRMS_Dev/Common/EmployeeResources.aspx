<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmployeeResources.aspx.cs" Inherits="SchoolNet.EmployeeResources" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
 <master:content id="formData" runat="server" height="100%" width="100%">
 <table border="0" cellspacing="0" cellpadding="0" height="100%" width="100%">
 <tr width="100%"><td class="colheader" colspan="4"><center>Employee Resources and HR Policy Documents</center></td></tr>
 <tr width="100%"><td colspan="4">&nbsp;</td></tr>
 <tr><td colspan="4">
 <asp:PlaceHolder id="EmployeeResTab" Runat="server" visible="true">
                    <asp:DataGrid ID="DOCGrid" runat="server" Width="100%" PageSize="15" AllowPaging="True" DataKeyField="DocumentID" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="DOCGrid_PageIndexChanged" >                                
                             
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
                        <FooterStyle CssClass="GridFooter" />
                        <SelectedItemStyle CssClass="GridSelectedItem" />
                        <PagerStyle CssClass="GridPagerItem" HorizontalAlign="Center" Mode="NumericPages" />
                        <AlternatingItemStyle CssClass="GridAltItem" />
                        <ItemStyle CssClass="GridItem" />
                        <HeaderStyle CssClass="GridHeader" />
                    </asp:DataGrid>
                    <br/>
                    <center><asp:label id ="emptyRow3" value="" visible=false runat="server" /></center>           
      </asp:placeholder>     
       </td>
    </tr>           				    	    

</table>
										
</master:content>





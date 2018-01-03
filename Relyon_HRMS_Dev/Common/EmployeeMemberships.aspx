<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmployeeMemberships.aspx.cs" Inherits="SchoolNet.EmployeeMemberships" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
 <master:content id="formData" runat="server" height="100%" width="100%">
 <table border="0" cellspacing="0" cellpadding="0" height="100%" width="100%">
 <asp:PlaceHolder id="CertificationTab" Runat="server" visible="true">
 <tr><td width="100%"> 
    <fieldset><legend>Add/Update Employee Memberships</legend>
      <table width="100%" border="0" class="Partgrayblock">
            <!-- Add/Edit Leave Type -->
                    
		    <tr><td colspan="3">&nbsp;</td></tr>
		    <tr>
			    <td class="mainheadtxt">Membership Name<font color="red">*</font></td>			    
			    <td class="mainheadtxt">Affiliation</td>
	            <td class="mainheadtxt">Date Joined</td>		    			    
     		</tr>
			
			<tr>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_Membership  TabIndex=1  CssClass="textfield"  Maxlength="150" width="250px" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_Affilation  TabIndex=2  CssClass="textfield"  Maxlength="150" width="250px" runat="server"></asp:textbox></td>
   			    <td class="mainheadtxt"><asp:textbox id=Tab1_DateJoined  TabIndex=3  CssClass="textfield"  Maxlength="15"  runat="server"></asp:textbox></td>

			</tr>
            <tr><td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_Membership ErrorMessage="Membership Name is required." /></td>   
                <td class="validationtxt"><asp:Label id="Tab1_keyField" runat="server" visible=false /></td>
   			    <td class="validationtxt">&nbsp;</td>
            </tr>               
	        <tr><td colspan="3"><hr /></td></tr>
	        
            <tr  align=center>
			    <td  valign="middle" colspan="3"><center><asp:button id=EmpMem_Save runat="server" BorderStyle="Ridge" CausesValidation="True" CssClass="button" BorderWidth="1px" Text="Save"></asp:button>
			                                    &nbsp;&nbsp;&nbsp;<asp:button id=Reset runat="server" BorderStyle="Ridge" CausesValidation="false" CssClass="button" BorderWidth="1px" Text="Reset"></asp:button></center></td>
            </tr>	
             <tr>
                <td colspan="3" align=center><asp:label id="Hmessage" runat="server" visible=false />                 
               </td>
            </tr>
            <tr><td colspan="3"><hr /></td></tr>
            
            
             <tr>
                <td colspan="3">
                    <asp:DataGrid ID="Grid" runat="server" Width="100%" PageSize="5" AllowPaging="True" DataKeyField="RowId" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="Grid_PageIndexChanged"                                   OnDeleteCommand="Grid_DeleteCommand" OnEditCommand="Grid_EditCommand" >
                                   
                      <Columns>
                            <asp:BoundColumn HeaderText="Membership Name" DataField="MembershipName" ItemStyle-Width="40%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Affiliation" DataField="Affiliation" ItemStyle-Width="40%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Date Joined" DataField="Date_Joined" ItemStyle-Width="15%"></asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="" ItemStyle-Width="8%">
                                    <ItemTemplate> 
                                         <asp:LinkButton name="Edit" commandName="Edit" Text="Edit" CausesValidation="false" runat="server" /> 
                                    </ItemTemplate>
                            </asp:TemplateColumn>                    
                            <asp:TemplateColumn HeaderText="" ItemStyle-Width="8%">
                                   <ItemTemplate> 
                                      <asp:LinkButton name="Delete" commandName="Delete" Text="Delete" CausesValidation="false" runat="server" OnClientClick="return confirm('Are you sure you want to delete the record?');" /> 
                                   </ItemTemplate>
                            </asp:TemplateColumn>                                
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
<!--  End of Tab 4 -->

</table>
	<!--   End of Data Area -->
										
</master:content>





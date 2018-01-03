<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmployeeCertifications.aspx.cs" Inherits="SchoolNet.EmployeeCertifications" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
 <master:content id="formData" runat="server" height="100%" width="100%">
 <table border="0" cellspacing="0" cellpadding="0" height="100%" width="100%">
 <asp:PlaceHolder id="CertificationTab" Runat="server" visible="true">
 <tr><td width="100%"> 
    <fieldset><legend>Add/Update Employee Certifications</legend>
      <table width="100%" border="0" class="Partgrayblock">
            <!-- Add/Edit Leave Type -->
                    
		    <tr><td colspan="3">&nbsp;</td></tr>
		    <tr>
			    <td class="mainheadtxt">Certification Type<font color="red">*</font></td>			    
			    <td class="mainheadtxt">Description<font color="red">*</font></td>			    
			    <td class="mainheadtxt">Certfication Number</td>

     		</tr>
			
			<tr>
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab1_CertTypeList"  TabIndex=1 CssClass="textfield" runat="server" Width="300px" ></asp:dropdownlist></td>
   			    <td class="mainheadtxt"><asp:textbox id=Tab1_Description  TabIndex=2  CssClass="textfield"  Maxlength="100" width="250px" runat="server"></asp:textbox></td>
   			    <td class="mainheadtxt"><asp:textbox id=Tab1_CertNumber  TabIndex=3  CssClass="textfield"  Maxlength="50" runat="server"></asp:textbox></td>  			    

			</tr>
            <tr><td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_CertTypeList InitialValue=-1 ErrorMessage="Certification Type is required." /></td>   
                <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_Description  ErrorMessage="Description is required." /></td>
   			    <td class="validationtxt">&nbsp;</td>
             </tr>               
   	
   			<tr>
			    <td class="mainheadtxt">Issued Date</td>
			    <td class="mainheadtxt">Expiry Date</td>
			    <td class="mainheadtxt"></td>
			</tr>
			<tr>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_IssuedDate  TabIndex=4  CssClass="textfield"  Maxlength="15" runat="server"></asp:textbox></td>
   			    <td class="mainheadtxt"><asp:textbox id=Tab1_ExpiryDate  TabIndex=4  CssClass="textfield"  Maxlength="15" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt">&nbsp;</td>
			</tr>
			<tr><td class="validationtxt">&nbsp;</td>   
                <td class="validationtxt"></td>
   			    <td class="validationtxt">&nbsp;</td>
             </tr>
             
			
  
	        <tr><td colspan="3"><hr /></td></tr>
	        
            <tr  align=center>
			    <td  valign="middle" colspan="3"><center><asp:button id=EmpCert_Save runat="server" BorderStyle="Ridge" CausesValidation="True" CssClass="button" BorderWidth="1px" Text="Save"></asp:button>
			                                    &nbsp;&nbsp;&nbsp;<asp:button id=Reset runat="server" BorderStyle="Ridge" CausesValidation="false" CssClass="button" BorderWidth="1px" Text="Reset"></asp:button></center></td>
            </tr>	
             <tr>
                <td colspan="3" align=center><asp:label id="Hmessage" runat="server" visible=false />&nbsp;
                 <asp:Label id="Tab1_keyField" runat="server" visible=false />
               </td>
            </tr>
            <tr><td colspan="3"><hr /></td></tr>
            
            
             <tr>
                <td colspan="3">
                    <asp:DataGrid ID="Grid" runat="server" Width="100%" PageSize="5" AllowPaging="True" DataKeyField="RowId" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="Grid_PageIndexChanged"                                   OnDeleteCommand="Grid_DeleteCommand" OnEditCommand="Grid_EditCommand" >
                                   
                      <Columns>
                            <asp:BoundColumn HeaderText="Certification Name" DataField="CertificationName" ItemStyle-Width="35%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Description" DataField="Cert_Desc" ItemStyle-Width="18%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Certification Number" DataField="Certification_Number" ItemStyle-Width="18%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Issue Date" DataField="IssueDate" ItemStyle-Width="12%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Expiry Date" DataField="ExpiryDate" ItemStyle-Width="12%"></asp:BoundColumn>
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




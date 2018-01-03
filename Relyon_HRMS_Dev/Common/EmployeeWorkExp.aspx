<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmployeeWorkExp.aspx.cs" Inherits="SchoolNet.EmployeeWorkExp" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
 <master:content id="formData" runat="server" height="100%" width="100%">
 <table border="0" cellspacing="0" cellpadding="0" height="100%" width="100%">
 <asp:PlaceHolder id="CertificationTab" Runat="server" visible="true">
 <tr><td width="100%"> 
    <fieldset><legend>Add/Update Employee Work Experiences</legend>
      <table width="100%" border="0" class="Partgrayblock">
            <!-- Add/Edit Leave Type -->
                    
		    <tr><td colspan="3">&nbsp;</td></tr>
		    <tr>
			    <td class="mainheadtxt">Experience Desc<font color="red">*</font></td>			    
			    <td class="mainheadtxt">Experience Level</td>
	            <td class="mainheadtxt">Note</td>		    			    
     		</tr>
			
			<tr>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_WorkExperience  TabIndex=1  CssClass="textfield"  Maxlength="100" width="250px" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab1_ExperienceLevelList"  TabIndex=2 CssClass="textfield" runat="server" width="150px" ></asp:dropdownlist></td>   			    
   			    <td class="mainheadtxt"><asp:textbox id=Tab1_Note  TabIndex=3  CssClass="textfield"  Maxlength="50" width="250px" runat="server"></asp:textbox></td>  			    

			</tr>
            <tr><td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_WorkExperience ErrorMessage="Experience Description is required." /></td>   
                <td class="validationtxt"><asp:Label id="Tab1_keyField" runat="server" visible=false /></td>
   			    <td class="validationtxt">&nbsp;</td>
             </tr>               
   	
   
	        <tr><td colspan="3"><hr /></td></tr>
	        
            <tr  align=center>
			    <td  valign="middle" colspan="3"><center><asp:button id=EmpWork_Save runat="server" BorderStyle="Ridge" CausesValidation="True" CssClass="button" BorderWidth="1px" Text="Save"></asp:button>
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
                            <asp:BoundColumn HeaderText="Experience Description" DataField="WorkExperience" ItemStyle-Width="40%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Experience Level" DataField="SkillLevelName" ItemStyle-Width="25%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Note" DataField="Note" ItemStyle-Width="35%"></asp:BoundColumn>
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





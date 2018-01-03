<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmployeeTraining.aspx.cs" Inherits="SchoolNet.EmployeeTraining" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
 <master:content id="formData" runat="server" height="100%" width="100%">
 <table border="0" cellspacing="0" cellpadding="0" height="100%" width="100%">
 <asp:PlaceHolder id="CertificationTab" Runat="server" visible="true">
 <tr><td width="100%"> 
    <fieldset><legend>Add/Update Employee Training Information</legend>
      <table width="100%" border="0" class="Partgrayblock">
            <!-- Add/Edit Leave Type -->
                    
		    <tr><td colspan="3">&nbsp;</td></tr>
		    <tr>
			    <td class="mainheadtxt">Training Name<font color="red">*</font></td>			    
			    <td class="mainheadtxt">Training Type<font color="red">*</font></td>
	            <td class="mainheadtxt">Training Duration(Days)</td>		    			    
     		</tr>
			
			<tr>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_TrainingName  TabIndex=1  CssClass="textfield"  Maxlength="100" width="200px" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:dropdownlist id=Tab1_TrainingType  TabIndex=2 CssClass="textfield" runat="server" width="150px" ></asp:dropdownlist></td>   			    
   			    <td class="mainheadtxt"><asp:textbox id=Tab1_Duration  TabIndex=3  CssClass="textfield"  Maxlength="10"  runat="server"></asp:textbox></td>

			</tr>
            <tr><td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_TrainingName ErrorMessage="Training Name is required." /></td>   
                <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_TrainingType InitialValue=-1 ErrorMessage="Training Type is required." /></td>   
   			    <td class="validationtxt"><asp:Label id="Tab1_keyField" runat="server" visible=false /></td>
            </tr> 
		    <tr>
			    <td class="mainheadtxt" colspan="2">Description</td>			    
			    <td class="mainheadtxt">Date Completed</td>
     		</tr>
			
			<tr>
			    <td class="mainheadtxt" colspan="2"><asp:textbox id=Tab1_Description  TabIndex=4  CssClass="textfield"  Maxlength="100" width="300px" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_DateCompleted  TabIndex=5  CssClass="textfield"  Maxlength="15" runat="server"></asp:textbox></td>

			</tr>
                          
	        <tr><td colspan="3"><hr /></td></tr>
	        
            <tr  align=center>
			    <td  valign="middle" colspan="3"><center><asp:button id=EmpTrain_Save runat="server" BorderStyle="Ridge" CausesValidation="True" CssClass="button" BorderWidth="1px" Text="Save"></asp:button>
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
                            <asp:BoundColumn HeaderText="Training Name" DataField="TrainingName" ItemStyle-Width="35%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Training Type" DataField="TrainingTypeName" ItemStyle-Width="22%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Training Duration(Days)" DataField="Training_Duration" ItemStyle-Width="18%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Date Completed" DataField="Date_Completed" ItemStyle-Width="18%"></asp:BoundColumn>
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





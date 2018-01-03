<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmployeeSkills.aspx.cs" Inherits="SchoolNet.EmployeeSkills" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
 <master:content id="formData" runat="server" height="100%" width="100%">
 <table border="0" cellspacing="0" cellpadding="0" height="100%" width="100%">
 <tr><td class="colheader"><span class="maintitledesign">Add/Update Employee Skills</span></td></tr>
 <asp:PlaceHolder id="LeaveTypeTab" Runat="server" visible="true">
 <tr><td width="100%"> 
    
      <table width="100%" border="0" class="Partgrayblock">
            <!-- Add/Edit Leave Type -->
                    
		    <tr><td colspan="3">&nbsp;</td></tr>
		    <tr>
			    <td class="mainheadtxt">Skill Category<font color="red">*</font></td>			    
			    <td class="mainheadtxt">Specific Skill<font color="red">*</font></td>			    
			    <td class="mainheadtxt">Skill Description<font color="red">*</font></td>

     		</tr>
			
			<tr>
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab1_SkillCategoryList" autopostback=true TabIndex=1 CssClass="textfield" runat="server" Width="150px" ></asp:dropdownlist></td>
   			    <td class="mainheadtxt"><asp:dropdownlist id="Tab1_SkillsList" TabIndex=2 CssClass="textfield" runat="server" Width="150px" ></asp:dropdownlist></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_SkillDesc  TabIndex=3  CssClass="textfield" width="300px" Maxlength="100" runat="server"></asp:textbox></td>
			</tr>
            <tr><td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_SkillCategoryList InitialValue=-1 ErrorMessage="Skill Category is required." /></td>   
                <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_SkillsList InitialValue=-1 ErrorMessage="Skill is required." /></td>   
   			    <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_SkillDesc ErrorMessage="Skill Description is required." /></td>
             </tr>               
   	
   			<tr>
			    <td class="mainheadtxt">Competency Level</td>
			    <td class="mainheadtxt">Last Assessed</td>
			    <td class="mainheadtxt">Note</td>
			</tr>
			<tr>
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab1_SkillLevelList" TabIndex=4 CssClass="textfield" runat="server" Width="150px" ></asp:dropdownlist></td>
   			    <td class="mainheadtxt"><asp:textbox id=Tab1_LastAssessed  TabIndex=5  CssClass="textfield"  Maxlength="15" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_Note  TabIndex=6  CssClass="textfield"  width="300px" Maxlength="100" runat="server"></asp:textbox></td>
			</tr>
<tr><td colspan="3">&nbsp;</td></tr>
            
            <tr class="PartButtons" align=center>
			<td  colspan="3">
			<center>
			    <asp:button id=EmpSkill_Save runat="server" CausesValidation="True" CssClass="Button SaveButton" Text="Save"></asp:button>
			    &nbsp;&nbsp;&nbsp;
                <asp:button id=Reset runat="server" CausesValidation="True" CssClass="Button ResetButton" Text="Reset"></asp:button>
			    
			</center>
			</td>
            </tr>
             <tr>
                <td colspan="3" align=center><asp:label id="Hmessage" runat="server" visible=false />&nbsp;
                 <asp:Label id="Tab1_keyField" runat="server" visible=false />
               </td>
            </tr>
            <tr><td colspan="3"><hr /></td></tr>
            
            <!-- Emergency Contact Grid -->
             <tr>
                <td colspan="3">
                    <asp:DataGrid ID="Grid" CssClass="Tabular2" runat="server" Width="100%" PageSize="10" AllowPaging="True" DataKeyField="RowId" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="Grid_PageIndexChanged"                                   OnDeleteCommand="Grid_DeleteCommand" OnEditCommand="Grid_EditCommand" >
                                   
                      <Columns>
                            <asp:BoundColumn HeaderText="Skill Category" DataField="SkillCategoryName" ItemStyle-Width="18%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Skill Name" DataField="SkillName" ItemStyle-Width="22%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Skill Level" DataField="SkillLevelName" ItemStyle-Width="15%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Skill Desc" DataField="Skill_Desc" ItemStyle-Width="28%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Last Assessed" DataField="Last_Assessed" ItemStyle-Width="16%"></asp:BoundColumn>
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
<!--  End of Tab 4 -->

</table>
	<!--   End of Data Area -->
										
</master:content>




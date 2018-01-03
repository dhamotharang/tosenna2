<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmployeeEducation.aspx.cs" Inherits="SchoolNet.EmployeeEducation" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
 <master:content id="formData" runat="server" height="100%" width="100%">
 <table border="0" cellspacing="0" cellpadding="0" height="100%" width="100%">
 <tr><td class="colheader"><span class="maintitledesign">Add/Update Employee Education</span></td></tr>
 <asp:PlaceHolder id="CertificationTab" Runat="server" visible="true">
 <tr><td width="100%"> 
    
      <table width="100%" border="0" class="Partgrayblock">
            <!-- Add/Edit Leave Type -->
                    
		    <tr><td colspan="3">&nbsp;</td></tr>
		    <tr>
			    <td class="mainheadtxt">Education Desc<font color="red">*</font></td>			    
			    <td class="mainheadtxt">School Name<font color="red">*</font></td>			    
			    <td class="mainheadtxt">Date Degree Completed</td>

     		</tr>
			
			<tr>
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab1_EducationList"  TabIndex=1 CssClass="textfield" runat="server" Width="300px" ></asp:dropdownlist></td>
   			    <td class="mainheadtxt"><asp:textbox id=Tab1_SchoolName  TabIndex=2  CssClass="textfield"  Maxlength="100" width="250px" runat="server"></asp:textbox></td>
   			    <td class="mainheadtxt"><asp:textbox id=Tab1_DateDegCompleted  TabIndex=3  CssClass="textfield"  Maxlength="50" runat="server"></asp:textbox></td>  			    

			</tr>
            <tr><td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_EducationList InitialValue=-1 ErrorMessage="Education Desc is required." /></td>   
                <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_SchoolName ErrorMessage="School Name is required." /></td>
   			    <td class="validationtxt">&nbsp;</td>
             </tr>               
   	
   			<tr>
			    <td class="mainheadtxt">Did you graduate?&nbsp;<asp:CheckBox ID="Tab1_Graduated" TabIndex=4 Text="" runat="server"/></td>
   			    <td class="mainheadtxt">GPA Obtained</td>
			    <td class="mainheadtxt">&nbsp;</td>

			</tr>
			<tr>
			    <td class="mainheadtxt"><asp:Label id="Tab1_keyField" runat="server" visible=false /> </td>
   			    <td class="mainheadtxt"><asp:textbox id=Tab1_GPA  TabIndex=6  CssClass="textfield" width="60px" Maxlength="15" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt">&nbsp;</td>   			    
			    
			</tr>
	        <tr><td colspan="3">&nbsp;</td></tr>
	        <tr class="PartButtons" align=center>
			<td  colspan="3">
			<center>
			    <asp:button id=EmpEdu_Save runat="server" CausesValidation="True" CssClass="Button SaveButton" Text="Save"></asp:button>
			    &nbsp;&nbsp;&nbsp;
                <asp:button id=Reset runat="server" CausesValidation="True" CssClass="Button ResetButton" Text="Reset"></asp:button>
			    
			</center>
			</td>
            </tr>
            <tr>
                <td colspan="3" align=center><asp:label id="Hmessage" runat="server" visible=false />                 
               </td>
            </tr>
            <tr><td colspan="3"><hr /></td></tr>
            
            
             <tr>
                <td colspan="3">
                    <asp:DataGrid ID="Grid" CssClass="Tabular2" runat="server" Width="100%" PageSize="5" AllowPaging="True" DataKeyField="RowId" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="Grid_PageIndexChanged"                                   OnDeleteCommand="Grid_DeleteCommand" OnEditCommand="Grid_EditCommand" >
                                   
                      <Columns>
                            <asp:BoundColumn HeaderText="Education Desc" DataField="EducationDesc" ItemStyle-Width="30%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="School Name" DataField="School_Name" ItemStyle-Width="30%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Date Deg Received" DataField="Date_DegreeReceived" ItemStyle-Width="18%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="GPA Obtained" DataField="GradeAverage" ItemStyle-Width="15%"></asp:BoundColumn>
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





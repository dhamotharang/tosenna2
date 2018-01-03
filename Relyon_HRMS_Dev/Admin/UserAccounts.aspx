<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserAccounts.aspx.cs" Inherits="SchoolNet.UserAccounts" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
 <master:content id="formData" runat="server" height="100%" width="100%">
 <table border="0" cellspacing="0" cellpadding="0" height="100%" width="100%">
 <asp:PlaceHolder id="CertificationTab" Runat="server" visible="true">
 <tr><td width="100%"> 
    <fieldset><legend>Manage User Accounts and Role Information</legend>
      <table width="100%" border="0" class="Partgrayblock">
            <!-- Add/Edit Leave Type -->
            <tr><td colspan="4">&nbsp;</td></tr>
        <asp:PlaceHolder id="AddAccount" runat="server" visible="true">
		    <tr>
			    <td class="mainheadtxt">Employee ID<font color="red">*</font></td>
		        <td class="mainheadtxt">Access Level<font color="red">*</font></td>
			    <td class="mainheadtxt">Business Unit</td>
  			    <td class="mainheadtxt">Business Unit Location</td>  
			
		    </tr>
 	        <tr>
   		        <td class="mainheadtxt"><asp:textbox id=Tab1_EmployeeID cssclass="textfield" TabIndex=1 Maxlength="20" runat="server" ></asp:textbox></td>
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab1_RoleTypeList"  TabIndex=2 autopostback=true CssClass="textfield" runat="server" Width="150px" ></asp:dropdownlist></td>
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab1_DivisionListList" Visible=false TabIndex=3 autopostback=true CssClass="textfield" runat="server" Width="150px" ></asp:dropdownlist></td>
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab1_DivisionLocationList" Visible=false TabIndex=4 autopostback=false CssClass="textfield" runat="server" Width="150px" ></asp:dropdownlist></td>   		        
			    
		    </tr>	
	        <tr>
	            <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_EmployeeID  ErrorMessage="Employee ID is Required." /></td>                        
                <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_RoleTypeList  InitialValue =-1 ErrorMessage="Role Type is Required." /></td>                        
                <td>&nbsp;</td>
                <td>&nbsp;</td>
 		    </tr>   
		    <tr>
			    <td class="mainheadtxt">HR System User Name<font color="red">*</font><br />(<small>Work Email address recommended)</small></td>
			    <td class="mainheadtxt">Temp Password<font color="red">*</font></td>
			    <td class="mainheadtxt">Confirm Password<font color="red">*</font></td>
			    <td class="mainheadtxt">Status</td>
		    </tr>
 	        <tr>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_UserName   TabIndex=5 cssclass="textfield" Maxlength="50" width="180px" runat="server" ></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_password   TextMode="Password"  TabIndex=6 cssclass="textfield" Maxlength="15" runat="server" ></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_ConfirmPassword TextMode="Password"  TabIndex=7 cssclass="textfield"  Maxlength="15" runat="server" ></asp:textbox></td>
			    <td class="mainheadtxt"><asp:RadioButton ID="Tab1_RadioButton1" runat="server" Text="Enabled" checked=true value ="1"  GroupName="AccountStatus" AutoPostBack="false" />  
                                        &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="Tab1_RadioButton2" runat="server"  Text="Disabled"  value = "0" GroupName="AccountStatus" AutoPostBack="false" /> 
                                        
			    </td>
            </tr>	
	        <tr>
                <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_UserName  ErrorMessage="User Name is Required." />
                                           <asp:RegularExpressionValidator id=RegExp_EmailAddress runat="server" ControlToValidate="Tab1_UserName"  ErrorMessage="Please enter a valid email address." ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"></asp:RegularExpressionValidator>
                
                </td>                        
                <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_password  ErrorMessage="Password is Required." />
                                           <asp:RegularExpressionValidator  runat=server ControlToValidate=Tab1_password  ValidationExpression="(?=^.{8,15}$)(?=.*\d)(?=.*\W+)(?![.\n])(?=.*[a-zA-Z]).*$" ErrorMessage="Password length should be greater than 8 and less than 15 characters. Password should contain at least one digit [0-9], one alphabet [A-Z] [a-z] and one special character such as [@#&*!]." /> 
                 </td>                        
                <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_ConfirmPassword  ErrorMessage="Confirm Password is Required." />                        
                                          <asp:CompareValidator      runat="server" ErrorMessage="Passwords do not match!"  ControlToValidate="Tab1_ConfirmPassword"  ControlToCompare="Tab1_password"></asp:CompareValidator></td>
	        

                <td class="validationtxt">&nbsp;</td>                             
 		    </tr>    		             
	
	        <tr><td colspan="4"><hr /></td></tr>
	        
            <tr  align=center>
			    <td  valign="middle" colspan="3"><center><asp:button id=PortalAcct_Save runat="server" BorderStyle="Ridge" CausesValidation="True" CssClass="button" BorderWidth="1px" Text="Save"></asp:button>
			                                    &nbsp;&nbsp;&nbsp;<asp:button id=Reset runat="server" BorderStyle="Ridge" CausesValidation="false" CssClass="button" BorderWidth="1px" Text="Reset"></asp:button></center></td>
            </tr>	
             <tr>
                <td colspan="3" align=center><asp:label id="Hmessage" runat="server" visible=false />&nbsp;
                 <asp:Label id="Tab1_keyField" runat="server" visible=false />
               </td>
            </tr>
            
            </asp:PlaceHolder>            
            <!-- Edit Account -->
            <asp:PlaceHolder id="EditAccount" runat="server" visible="false">  
            
            <tr>
			    <td class="mainheadtxt">Employee ID<font color="red">*</font></td>
		        <td class="mainheadtxt">Access Level<font color="red">*</font></td>
			    <td class="mainheadtxt">Division/Entity</td>
  			    <td class="mainheadtxt">Location/Country</td>  
			
		    </tr>
 	        <tr>
   		        <td class="mainheadtxt"><asp:textbox id=Tab2_EmployeeID ReadOnly=true cssclass="textfield" TabIndex=1 Maxlength="20" runat="server" ></asp:textbox></td>
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab2_RoleTypeList"  TabIndex=2 autopostback=true CssClass="textfield" runat="server" Width="150px" ></asp:dropdownlist></td>
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab2_DivisionListList" Visible=false TabIndex=3 autopostback=true CssClass="textfield" runat="server" Width="150px" ></asp:dropdownlist></td>
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab2_DivisionLocationList" Visible=false TabIndex=4 autopostback=false CssClass="textfield" runat="server" Width="150px" ></asp:dropdownlist></td>   		        
			    
		    </tr>	
	        <tr>
	            <td class="validationtxt">&nbsp;</td>                        
                <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab2_RoleTypeList  InitialValue =-1 ErrorMessage="Role Type is Required." /></td>                        
                <td>&nbsp;</td>
                <td>&nbsp;</td>
 		    </tr>   
          
            <tr>
  			    <td class="mainheadtxt">Portal User Name</td>
			    <td class="mainheadtxt">Account Status</td>
			    <td>&nbsp;</td>
			    <td>&nbsp;</td>
		    </tr>
 	        <tr>
			    <td class="mainheadtxt"><asp:textbox id=Tab2_UserName   ReadOnly=true TabIndex=2 cssclass="textfield" Maxlength="50" width="180px" runat="server" ></asp:textbox></td>
			    <td class="mainheadtxt"><asp:RadioButton ID="Tab2_RadioButton1" runat="server" Text="Enabled" value ="1" GroupName="AccountStatus" AutoPostBack="false" />  
                                        &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="Tab2_RadioButton2" runat="server" Text="Disabled"  value = "0" GroupName="AccountStatus" AutoPostBack="false" /> 
                                        
			    </td>
			    <td>&nbsp;</td>
			    <td>&nbsp;</td>
            </tr>
             <tr>
                <td class="validationtxt">&nbsp; </td>                                  
                <td>&nbsp;</td>                                           
                <td>&nbsp;</td>                                           
                <td>&nbsp;</td>   
             </tr>                                           

             <tr><td colspan="4"><hr /></td></tr>
	        
            <tr  align=center>
			    <td  valign="middle" colspan="3"><center><asp:button id=PortalEdit_Save runat="server" BorderStyle="Ridge" CausesValidation="True" CssClass="button" BorderWidth="1px" Text="Save"></asp:button>
			                                    &nbsp;&nbsp;&nbsp;<asp:button id=Edit_Reset runat="server" BorderStyle="Ridge" CausesValidation="false" CssClass="button" BorderWidth="1px" Text="Reset"></asp:button></center></td>
            </tr>	
             <tr>
                <td colspan="3" align=center><asp:label id="Editmessage" runat="server" visible=false />&nbsp;
                 <asp:Label id="Tab2_keyField" runat="server" visible=false />
               </td>
            </tr>
            </asp:PlaceHolder>
            
            
            <tr><td colspan="4"><hr /></td></tr>
            
    
             <tr>
                <td colspan="4" >
                    <asp:DataGrid ID="Grid" runat="server" Width="100%" PageSize="10" AllowSorting="True"  AllowPaging="True" DataKeyField="EmpId" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="Grid_PageIndexChanged"                                   OnDeleteCommand="Grid_DeleteCommand" OnEditCommand="Grid_EditCommand" OnSorting="Grid_SortCommand" >
                                   
                      <Columns>
                            <asp:BoundColumn HeaderText="Employee ID" DataField="Employee_ID" SortExpression="Employee_ID" ItemStyle-Width="8%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Employee Name" DataField="Emp_Name"  SortExpression="Emp_Name" ItemStyle-Width="18%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="User Name" DataField="UserName" SortExpression="UserName" ItemStyle-Width="18%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Role Name" DataField="RoleName" SortExpression="RoleName"  ItemStyle-Width="17%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Business Unit" DataField="DivisionName" SortExpression="DivisionName" ItemStyle-Width="18%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Location" DataField="LocationName" SortExpression="LocationName" ItemStyle-Width="18%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Status" DataField="AccountStatus" SortExpression="AccountStatus" ItemStyle-Width="8%"></asp:BoundColumn>
                            <asp:BoundColumn Visible=false HeaderText="pwd" DataField="password" ItemStyle-Width="0%"></asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="" ItemStyle-Width="4%">
                                    <ItemTemplate> 
                                         <asp:LinkButton name="Edit" commandName="Edit" Text="Edit" CausesValidation="false" runat="server" /> 
                                    </ItemTemplate>
                            </asp:TemplateColumn>                    
                            <asp:TemplateColumn HeaderText="" ItemStyle-Width="4%">
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





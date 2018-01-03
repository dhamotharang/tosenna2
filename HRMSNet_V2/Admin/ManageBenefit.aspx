<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManageBenefit.aspx.cs" Inherits="SchoolNet.ManageBenefit" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
 <master:content id="formData" runat="server" height="100%" width="100%">
 <table  border="0" cellspacing="0" cellpadding="0" width=100% height="100%">
  <!--   Search Box -->
 <ASP:PlaceHolder id="EmpSearchBox" Runat="server">
    <tr width="100%">
		<td class="colheader"><span class="maintitledesign">Employee Benefit Management</span></td>
	</tr>
      <tr width="100%">
    <td>
    <div class="ManageEmpGrid">
        <asp:DataGrid ID="Grid" runat="server" Width="100%" PageSize="10" AllowPaging="True" AllowSorting="True" DataKeyField="EmpId" AutoGenerateColumns="False" CellPadding="4" GridLines="None" OnPageIndexChanged="Grid_PageIndexChanged"                      OnEditCommand="Grid_EditCommand" OnSorting="Grid_SortCommand">
                      <Columns>
                            <asp:TemplateColumn HeaderText="Employee ID" ItemStyle-Width="10%" SortExpression="Employee_ID">
                                        <ItemTemplate> 
                                             <asp:LinkButton name="Edit" commandName="Edit"  CausesValidation="false" runat="server" ToolTip="Click to manage benefit information"> <%# Eval("Employee_ID")%></asp:LinkButton>                                                                 
                                        </ItemTemplate>
                            </asp:TemplateColumn>
                            
                            <asp:TemplateColumn HeaderText="Employee Name" ItemStyle-Width="18%" SortExpression="Name">
                                        <ItemTemplate> 
                                             <asp:LinkButton name="Edit" commandName="Edit"  CausesValidation="false" runat="server" ToolTip="Click to manage benefit information"> <%# Eval("Name")%></asp:LinkButton>                                                                 
                                        </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:BoundColumn HeaderText="Job Title" DataField="Designation" SortExpression="Designation"  ItemStyle-Width="15%"></asp:BoundColumn>                            
                            <asp:BoundColumn HeaderText="Supervisor" DataField="LineManager" SortExpression="LineManager" ItemStyle-Width="15%"></asp:BoundColumn>                            
                            <asp:BoundColumn HeaderText="Status" DataField="EmpStatusName" SortExpression="EmpStatusName" ItemStyle-Width="6%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Business Unit" DataField="DivisionName" SortExpression="DivisionName" ItemStyle-Width="12%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Location" DataField="DivisionLocation" SortExpression="DivisionLocation" ItemStyle-Width="9%"></asp:BoundColumn>                                        
                            <asp:BoundColumn HeaderText="Department" DataField="DeptName" SortExpression="DeptName" ItemStyle-Width="15%" ></asp:BoundColumn>                            
                            
                       </Columns>                                
              
                        <FooterStyle CssClass="EmpsFooter" />
                        <SelectedItemStyle CssClass="EmpsSelectedItem" />
                        <PagerStyle CssClass="EmpsPagerItem" HorizontalAlign="Center" Mode="NumericPages" />
                        <AlternatingItemStyle CssClass="EmpsAltItem" />
                        <ItemStyle CssClass="EmpsItem" />
                        <HeaderStyle CssClass="EmpsHeader" />
        </asp:DataGrid>
        </br>
        <center><asp:label id ="emptyRow" value="" visible=false runat="server" /></center>
        </div>
    </td>
    
</tr>	
	<tr>
		<td>
		    <table width="100%" border="0" class="Partgrayblock">
        <tr class="PartWhite" align=center>
            <td valign="left" class="mainheadtxt">&nbsp;&nbsp;
                <a id="adv_search" href="#" runat="server"><IMG id="adv_search_img" src="~/images/buttons/blue_adv_search.jpg" runat="server" alt="Advanced Search" title="Advanced Search" height="27" width="28" style="float:left;">
                <span style="text-decoration:underline;color:#FFF;float:left;margin:0;padding:5px 0 0 0;">Advanced Search</span></a>
            </td>
			<td  align="right" colspan="2" class="mainsearchtxt">
            Employee ID&nbsp;<asp:textbox id=empID  Maxlength="30" CssClass="textfield" runat="server"></asp:textbox>
			</td>
			<td class="mainheadtxt" align=left>
                <IMG src="~/images/buttons/separator.png" runat="server" alt= "" height="30" width="2" style="vertical-align:bottom;"/>&nbsp;                
                <asp:ImageButton id=Search runat="server" CausesValidation="True" ImageUrl="~/images/buttons/blue_search.png" ToolTip="Search" alt="Search" height="30" width="30" style="vertical-align:middle;"></asp:ImageButton>&nbsp
                <IMG src="~/images/buttons/separator.png" runat="server" alt= "" height="30" width="2" style="vertical-align:bottom;"/>&nbsp;                
			    <asp:ImageButton id=Reset runat="server" CausesValidation="True" ImageUrl="~/images/buttons/blue_reset.png" ToolTip="Reset" alt="Reset" height="30" width="30" style="vertical-align:middle;"></asp:ImageButton>&nbsp;
                <IMG src="~/images/buttons/separator.png" runat="server" alt= "" height="30" width="2" style="vertical-align:bottom;"/>&nbsp;                            
            </td>
        </tr>
		    <tr>
			    <td class="mainheadtxt">Employee Name</td>
			    <td class="mainheadtxt">Supervisor Name</td>
			    <td class="mainheadtxt">Employement Status</td>
                <td class="mainheadtxt">&nbsp;</td>
		    </tr>
		    <tr>
			    <td class="mainheadtxt"><asp:textbox id=empName CssClass="textfield" Maxlength="50" width="180px" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=mgrName CssClass="textfield" Maxlength="50" width="180px" runat="server"></asp:textbox></td>
  			    <td class="mainheadtxt"><asp:dropdownlist id="empStatusDDList" AutoPostBack=false runat="server" Width="180px" CssClass="textfield"></asp:dropdownlist></td>			    
                <td class="mainheadtxt">&nbsp;</td>
		    </tr>

		    <tr>			   
			    <td class="mainheadtxt">Designation</td>
			    <td class="mainheadtxt">Business Unit</td>
			    <td class="mainheadtxt">Business Unit Location</td>
			    <td class="mainheadtxt">&nbsp;</td>
		    </tr>
		    <tr>
			    <td class="mainheadtxt"><asp:dropdownlist id="jobTitleDDList" AutoPostBack=false runat="server" Width="180px" CssClass="textfield"></asp:dropdownlist></td>
			    <td class="mainheadtxt"><asp:dropdownlist id="businessUnitDDList" AutoPostBack=true runat="server" Width="180px" CssClass="textfield"></asp:dropdownlist></td>
			    <td class="mainheadtxt"><asp:dropdownlist id="DivisionLocationList" AutoPostBack=false runat="server" Width="180px" CssClass="textfield"></asp:dropdownlist></td>			    
			    <td class="mainheadtxt">&nbsp;</td>
		    </tr>
			<tr><td colspan="4">&nbsp;</td></tr>
    	
	    </table>
	   </td>						
	</tr>


</ASP:PlaceHolder>

<!--    Edit Employee Data Area -->
<asp:PlaceHolder id=EditArea Runat="server" visible="false">
 <tr width="100%">
		<td class="colheader"><span class="maintitledesign">Manage Employee Benefit Information<span></td>
</tr>
<tr>
  <td>
    <table width="100%" border="0" class="Partgrayblock">
       <tr>
	      <td valign="top" width="20%"> <asp:image id='profile' width="200" height="200" runat="server" /></td>
	      <td valign="top" width="2%">&nbsp;</td>
	     	      <td valign="top" width="38%" align="left">
	                    <table>
	                        <tr><td align="right"><span class="mainheadtxt3">Employee Name&nbsp;&nbsp;</span></td><td><asp:label id="lblEmployeeName" runat="server" cssclass="mainheadtxt2" /></td></tr>
                            <tr><td align="right"><span class="mainheadtxt3">Current Designation&nbsp;&nbsp;</span></td><td><asp:Label id="lblJobTitle" runat="server" cssclass="mainheadtxt2"></asp:Label></td></tr>	
                            <tr><td align="right"><span class="mainheadtxt3">Work Location&nbsp;&nbsp;</span></td><td><asp:Label id="lblJobLocation" runat="server" cssclass="mainheadtxt2" /></td></tr>	
                            <tr><td align="right"><span class="mainheadtxt3">Division&nbsp;&nbsp;</span></td><td><asp:Label id="lblDivision" runat="server" cssclass="mainheadtxt2" /></td></tr>	       
                            <tr><td align="right"><span class="mainheadtxt3">Division Location&nbsp;&nbsp;</span></td><td><asp:Label id="lblDivisionLocation" runat="server" cssclass="mainheadtxt2" /></td></tr>	                                                                      
                            <tr><td align="right"><span class="mainheadtxt3">Work Phone&nbsp;&nbsp;</span></td><td><asp:Label id="lblWorkPhone" runat="server" cssclass="mainheadtxt2" ></asp:Label></td></tr>	    
                            <tr><td align="right"><span class="mainheadtxt3">Mobile Phone&nbsp;&nbsp;</span></td><td><asp:Label id="lblMobile" runat="server" cssclass="mainheadtxt2" /></td></tr>	                                                
                            <tr><td align="right"><span class="mainheadtxt3">Email Address&nbsp;&nbsp;</span></td><td><asp:Label id="lblEmailAddress" runat="server" cssclass="mainheadtxt2" /></td></tr>	
                            <tr><td align="right" colspan="2"><asp:Label id="keyField" runat="server" visible=false /></td></tr>	                                                                                                
                         </table>	                                                
	       </td>
	       <td valign="top" width="40%" align="left">
	                  <table>
	                     <tr><td align="right"><span class="mainheadtxt3">Supervisor Name&nbsp;&nbsp;</span></td><td><asp:label id="lblSuperVisorName" runat="server" cssclass="mainheadtxt2" /></td></tr>                       
                         <tr><td align="right"><span class="mainheadtxt3">Designation&nbsp;&nbsp;</span></td><td><asp:Label id="lblSuperVisor_JobTitle" runat="server" cssclass="mainheadtxt2"></asp:Label></td></tr>	
                         <tr><td align="right"><span class="mainheadtxt3">Work Location&nbsp;&nbsp;</span></td><td><asp:Label id="lblSuperVisor_JobLocation" runat="server" cssclass="mainheadtxt2" /></td></tr>	
                         <tr><td align="right"><span class="mainheadtxt3">Division&nbsp;&nbsp;</span></td><td><asp:Label id="lblSuperVisor_Division" runat="server" cssclass="mainheadtxt2" /></td></tr>	       
                         <tr><td align="right"><span class="mainheadtxt3">Division Location&nbsp;&nbsp;</span></td><td><asp:Label id="lblSuperVisor_DivisionLocation" runat="server" cssclass="mainheadtxt2" /></td></tr>	                                                                                          
	                     <tr><td align="right"><span class="mainheadtxt3">Work Phone&nbsp;&nbsp;</span></td><td><asp:label id="lblSuperVisor_Phone" runat="server" cssclass="mainheadtxt2" /></td></tr>
	                     <tr><td align="right"><span class="mainheadtxt3">Email Address&nbsp;&nbsp;</span></td><td><asp:label id="lblSuperVisor_EmailAddress" runat="server" cssclass="mainheadtxt2" /></td></tr>
	                     <tr><td align="right" colspan="2"><asp:Label id="EOSPayout" runat="server" visible=false /></td></tr>	                                                                                                
	                    </table>	                              
	      </td>				
		</tr>
     </table>
    </td>
</tr>
<tr width="100%">
  <td>
     <div id="nav">
           <ul>
             <li><asp:button id=tab1 runat="server" BorderStyle="Ridge" CausesValidation="false" CssClass="button" BorderWidth="1px" Text="Salary/Allowances"></asp:button></li>
             <li><asp:button id=tab2 runat="server" BorderStyle="Ridge" CausesValidation="false" CssClass="button" BorderWidth="1px" Text="Incentives"></asp:button></li>   
             <li><asp:button id=tab3 runat="server" BorderStyle="Ridge" CausesValidation="false" CssClass="button" BorderWidth="1px" Text="Non-Payroll Benefits"></asp:button></li>                                    
             <li><asp:button id=tab4 runat="server" BorderStyle="Ridge" CausesValidation="false" CssClass="button" BorderWidth="1px" Text="Bank Information"></asp:button></li>
        
            </ul>  
     </div>
  </td>
</tr>
<!-- Tab 1: Salary/Allowances -->
<tr><td width="100%">
<asp:placeholder id="Tab1_Pane" runat="server" Visible=false>
    <table width="100%" border="0" class="Partgrayblock">
            <!-- Benefits Grid -->
            <tr><td colspan="4"><span class="maintitledesign">Manage Salary/Allowances</span></td></tr>               
            <tr><td colspan="4">&nbsp;</td></tr>
             <tr>
                <td colspan="4">
                    <asp:DataGrid ID="Tab1Grid" CssClass="Tabular2" runat="server" Width="100%" PageSize="10" AllowPaging="True" DataKeyField="PayComponentID" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="Tab1Grid_PageIndexChanged"  OnDeleteCommand="Tab1Grid_DeleteCommand" OnEditCommand="Tab1Grid_EditCommand" 
                    Caption='' CaptionAlign="Top">                                  
                      <Columns>
                            <asp:BoundColumn HeaderText="Benefit Component Name" DataField="PayComponentName" ItemStyle-Width="25%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Amount" DataField="Amount" DataFormatString="{0:######.00}" ItemStyle-Width="15%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Pay Frequency" DataField="PayFrequency" ItemStyle-Width="15%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Comment" Visible=true DataField="ChangeReason" ItemStyle-Width="25%"></asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="">
                                <ItemTemplate> 
                                     <asp:LinkButton name="Edit" commandName="Edit" Text="Edit" CausesValidation="false" runat="server"  />                                                                  
                                     &nbsp;&nbsp;<asp:LinkButton name="Delete" commandName="Delete" CausesValidation="false" OnClientClick="return confirm('Are you sure to delete this record');" Text="Delete" runat="server" />
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
         
                </td>
            </tr>
            <tr><td colspan="4"><hr /></td></tr>
            
            <tr>
			    <td class="mainheadtxt">Pay Component Name<font color="red">*</font></td>
			    <td class="mainheadtxt">Amount</td>
			    <td class="mainheadtxt">Reason for Change</td>
			    <td class="mainheadtxt">Change Effective Date</td>
		    </tr>
		    <tr>
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab1_PayComponentList" TabIndex=1 AutoPostBack=false runat="server" Width="220Px" CssClass="textfield"></asp:dropdownlist></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_Amount cssclass="textfield" TabIndex=2 Maxlength="30"  runat="server"></asp:textbox></td>
			    <td class="mainheadtxt">
			                            <asp:RadioButton ID="Tab1_ApprRB1" TabIndex=2 runat="server" Text="Initial Setup/Correction" Checked= 'true' value ="1" GroupName="ChangeType" AutoPostBack="false" />  
                                        &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="Tab1_ApprRB2" runat="server" Text="Salary Revision"  value = "0" GroupName="ChangeType" AutoPostBack="false" /> 
                                        
			    </td>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_Date TabIndex=3 cssclass="textfield" Maxlength="30" runat="server" ></asp:textbox></td>
             </tr>
            <tr>
		        <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_PayComponentList InitialValue=-1 ErrorMessage="Pay Component is required." /></td>   
                <td class="validationtxt"><asp:CompareValidator runat="server" ControlToValidate="Tab1_Amount" Operator="DataTypeCheck" Type="Double" ErrorMessage="Value must be a number" /></td>
                <td class="validationtxt"></td>
                <td class="validationtxt"></td> 		    
		    </tr>

            <tr class="PartButtons" align=center>
			<td  colspan="4">
			<center>
			    <asp:button id=Tab1_Save runat="server" CausesValidation="True" CssClass="Button SaveButton" Text="Save"></asp:button>
			    &nbsp;&nbsp;&nbsp;
			    <asp:button id=Tab1_Reset runat="server" CausesValidation="false" CssClass="Button ResetButton" Text="Reset"></asp:button>
			</center>
			</td>
		    </tr>
             <tr>
                <td colspan="4" align=center><asp:label id="Tab1_Message" runat="server" visible=false />&nbsp;
                                             <asp:Label id="Tab1_keyField" runat="server" visible=false />
                
                </td>
            </tr>
            
	     </table>
	 
  </asp:placeholder>
  </td>
 </tr>
<!--   End of Tab1 -->
<!-- Tab 2: Incentives -->
<tr><td width="100%">
<asp:placeholder id="Tab2_Pane" runat="server" Visible=false>
       <table width="100%" border="0" class="Partgrayblock">
            <!-- Incentives Grid -->
            <tr><td colspan="4"><span class="maintitledesign">Incentives </span></td></tr>               
            <tr><td colspan="4">&nbsp;</td></tr>
             <tr>
                <td colspan="4">
                    <asp:DataGrid ID="Tab2Grid" CssClass="Tabular2" runat="server" Width="100%" PageSize="10" AllowPaging="True" DataKeyField="PayComponentID" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="Tab2Grid_PageIndexChanged"  OnDeleteCommand="Tab2Grid_DeleteCommand" OnEditCommand="Tab2Grid_EditCommand" 
                    Caption='' CaptionAlign="Top">                                  
                      <Columns>
                            <asp:BoundColumn HeaderText="Benefit Component Name" DataField="PayComponentName" ItemStyle-Width="25%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Amount" DataField="Amount" DataFormatString="{0:######.00}" ItemStyle-Width="15%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Pay Frequency" visible=false DataField="PayFrequency" ItemStyle-Width="0%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Comment" Visible=true DataField="ChangeReason" ItemStyle-Width="25%"></asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="">
                                <ItemTemplate> 
                                     <asp:LinkButton name="Edit" commandName="Edit" Text="Edit" CausesValidation="false" runat="server"  />                                                                  
                                     &nbsp;&nbsp;<asp:LinkButton name="Delete" commandName="Delete" CausesValidation="false" OnClientClick="return confirm('Are you sure to delete this record');" Text="Delete" runat="server" />
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
         
                </td>
            </tr>
            <tr><td colspan="4"><hr /></td></tr>
            
            <tr>
			    <td class="mainheadtxt">Pay Component Name<font color="red">*</font></td>
			    <td class="mainheadtxt">Amount</td>
			    <td class="mainheadtxt" colspan="2">Reason for Change</td>
		    </tr>
		    <tr>
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab2_PayComponentList" TabIndex=1 AutoPostBack=false runat="server" Width="220Px" CssClass="textfield"></asp:dropdownlist></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab2_Amount cssclass="textfield" TabIndex=2 Maxlength="30"  runat="server"></asp:textbox></td>
			    <td class="mainheadtxt" colspan="2">
			                            <asp:RadioButton ID="Tab2_ApprRB1" TabIndex=2 runat="server" Text="Initial Setup/Correction" Checked= 'true' value ="1" GroupName="ChangeType" AutoPostBack="false" />  
                                        &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="Tab2_ApprRB2" runat="server" Text="Revision"  value = "0" GroupName="ChangeType" AutoPostBack="false" /> 
                                        
			    </td>
             </tr>
            <tr>
		        <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab2_PayComponentList InitialValue=-1 ErrorMessage="Pay Component is required." /></td>   
                <td class="validationtxt"><asp:CompareValidator runat="server" ControlToValidate="Tab2_Amount" Operator="DataTypeCheck" Type="Double" ErrorMessage="Value must be a number" /></td>
                <td class="validationtxt"></td>
                <td class="validationtxt"></td> 		    
		    </tr>
		    <tr class="PartButtons" align=center>
			<td  colspan="4">
			<center>
			    <asp:button id=Tab2_Save runat="server" CausesValidation="True" CssClass="Button SaveButton" Text="Save"></asp:button>
			    &nbsp;&nbsp;&nbsp;
			    <asp:button id=Tab2_Reset runat="server" CausesValidation="false" CssClass="Button ResetButton" Text="Reset"></asp:button>
			</center>
			</td>
		    </tr>
             <tr>
                <td colspan="4" align=center><asp:label id="Tab2_Message" runat="server" visible=false />&nbsp;
                                             <asp:Label id="Tab2_keyField" runat="server" visible=false />
                
                </td>
            </tr>
            
	     </table>
	  </asp:placeholder>
  </td>
 </tr>
<!--   End of Tab2 -->
<!-- Tab 3: Benefits -->
<tr><td width="100%">
<asp:placeholder id="Tab3_Pane" runat="server" Visible=false>
        <table width="100%" border="0" class="Partgrayblock">
            <!-- Non-Payroll Grid -->
            <tr><td colspan="4"><span class="maintitledesign">Non-Payroll Benefits</span></td></tr>               
            <tr><td colspan="4">&nbsp;</td></tr>
            <tr>
                <td colspan="4">
                    <asp:DataGrid ID="Tab3Grid" CssClass="Tabular2" runat="server" Width="100%" PageSize="10" AllowPaging="True" DataKeyField="PayComponentID" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="Tab3Grid_PageIndexChanged"  OnDeleteCommand="Tab3Grid_DeleteCommand" OnEditCommand="Tab3Grid_EditCommand" 
                    Caption='' CaptionAlign="Top">                                  
                      <Columns>
                            <asp:BoundColumn HeaderText="Benefit Component Name" DataField="PayComponentName" ItemStyle-Width="30%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Amount" DataField="Amount" DataFormatString="{0:######.00}" ItemStyle-Width="15%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Pay Frequency" visible=false DataField="PayFrequency" ItemStyle-Width="0%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Comment" Visible=true DataField="ChangeReason" ItemStyle-Width="40%"></asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="">
                                <ItemTemplate> 
                                     <asp:LinkButton name="Edit" commandName="Edit" Text="Edit" CausesValidation="false" runat="server"  />                                                                  
                                     &nbsp;&nbsp;<asp:LinkButton name="Delete" commandName="Delete" CausesValidation="false" OnClientClick="return confirm('Are you sure to delete this record');" Text="Delete" runat="server" />
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
         
                </td>
            </tr>
            <tr><td colspan="4"><hr /></td></tr>
            
            <tr>
			    <td class="mainheadtxt">Pay Component Name<font color="red">*</font></td>
			    <td class="mainheadtxt">Amount</td>
			    <td class="mainheadtxt" colspan="2">Reason for Change</td>
		    </tr>
		    <tr>
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab3_PayComponentList" TabIndex=1 AutoPostBack=false runat="server" Width="220Px" CssClass="textfield"></asp:dropdownlist></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab3_Amount cssclass="textfield" TabIndex=2 Maxlength="30"  runat="server"></asp:textbox></td>
			    <td class="mainheadtxt" colspan="2">
			                            <asp:RadioButton ID="Tab3_ApprRB1" TabIndex=2 runat="server" Text="Initial Setup/Correction" Checked= 'true' value ="1" GroupName="ChangeType" AutoPostBack="false" />  
                                        &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="Tab3_ApprRB2" runat="server" Text="Revision"  value = "0" GroupName="ChangeType" AutoPostBack="false" /> 
                                        
			    </td>
             </tr>
            <tr>
		        <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab3_PayComponentList InitialValue=-1 ErrorMessage="Pay Component is required." /></td>   
                <td class="validationtxt"><asp:CompareValidator runat="server" ControlToValidate="Tab3_Amount" Operator="DataTypeCheck" Type="Double" ErrorMessage="Value must be a number" /></td>
                <td class="validationtxt"></td>
                <td class="validationtxt"></td> 		    
		    </tr>

            <tr class="PartButtons" align=center>
			<td  colspan="4">
			<center>
			    <asp:button id=Tab3_Save runat="server" CausesValidation="True" CssClass="Button SaveButton" Text="Save"></asp:button>
			    &nbsp;&nbsp;&nbsp;
			    <asp:button id=Tab3_Reset runat="server" CausesValidation="false" CssClass="Button ResetButton" Text="Reset"></asp:button>
			</center>
			</td>
		    </tr>	
             <tr>
                <td colspan="4" align=center><asp:label id="Tab3_Message" runat="server" visible=false />&nbsp;
                                             <asp:Label id="Tab3_keyField" runat="server" visible=false />
                
                </td>
            </tr>

		    
	     </table>
	 
  </asp:placeholder>
  </td>
 </tr>
<!--   End of Tab3 -->



<!-- Tab3: Bank Information -->
<tr><td width="100%">
<asp:placeholder id="Tab4_Pane" runat="server" Visible=false>
        <table width="100%" border="0" class="Partgrayblock">
            <tr><td colspan="5"><span class="maintitledesign">Employee Banking Information</span></td></tr>               
            <tr><td colspan="5">&nbsp;</td></tr>
            
             <tr><td colspan="5">&nbsp;</td></tr>          
		     <tr>
		        <td class="mainheadtxt">Employee Bank Account<font color="red">*</font></td>   
		        <td class="mainheadtxt">Bank Name<font color="red">*</font></td>                           
                <td class="mainheadtxt" colspan="3"></td>                
		    </tr>      
		    
		    <tr>
			    <td class="mainheadtxt" valign=top><asp:textbox id=Tab4_EmployeeBankAccount cssclass="textfield" TabIndex=1 Maxlength="30" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt" valign=top><asp:dropdownlist id="Tab4_BankName" AutoPostBack=false runat="server" TabIndex=2 Width="240px" CssClass="textfield"></asp:dropdownlist></td>			    
			    <td class="mainheadtxt" colspan="3">&nbsp;</td>
		    </tr>	
             <tr>
		        <td class="validationtxt"><asp:RequiredFieldValidator  runat="server" ControlToValidate="Tab4_EmployeeBankAccount" ErrorMessage="Bank Account is required." /></td> 
                <td class="mainheadtxt" colspan="4"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab4_BankName InitialValue=-1 ErrorMessage="Bank Name is required." /></td>   
             </tr>   
  		    <tr class="PartButtons" align=center>
			<td  colspan="5">
			<center>
			    <asp:button id=Bank_Save runat="server" CausesValidation="True" CssClass="Button SaveButton" Text="Save"></asp:button>
			</center>
			</td>
		    </tr>		    
        
            <tr>
                <td colspan="5" align=center><asp:label id="Tab4_Message" runat="server" visible=false />&nbsp;
                                             <asp:Label id="Tab4_keyField" runat="server" visible=false />
                
                </td>
            </tr>
            
	     </table>
	 
  </asp:placeholder>
  </td>
 </tr>

</asp:placeholder>
<tr class="PartBrown" >
   <td width="100%" align=center><asp:label id="message" runat="server" Visible=false /></td>			
</tr> 			
</table>										
</master:content>



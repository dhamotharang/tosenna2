<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManageLeave.aspx.cs" Inherits="SchoolNet.ManageLeave" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
 <master:content id="formData" runat="server" height="100%" width="100%">
 <table  border="0" cellspacing="0" cellpadding="0" width=100% height="100%">
  <!--   Search Box -->
 <ASP:PlaceHolder id="EmpSearchBox" Runat="server">
    <tr width="100%">
		<td class="colheader"><center>Employee Leave Management</center></td>
	</tr>	
	<tr>
		<td>
		    <table width="100%" border="0" class="Partgrayblock">
		    <tr><td colspan="4">&nbsp;</td></tr>
		    <tr>
			    <td class="mainheadtxt">Employee Name</td>
			    <td class="mainheadtxt">Employee ID</td>
			    <td class="mainheadtxt">Supervisor Name</td>
			    <td class="mainheadtxt">Employement Status</td>
		    </tr>
		    <tr>
			    <td class="mainheadtxt"><asp:textbox id=empName  Maxlength="50" width="180px" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=emp_ID  Maxlength="30" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=mgrName  Maxlength="50" width="180px" runat="server"></asp:textbox></td>
  			    <td class="mainheadtxt"><asp:dropdownlist id="empStatusDDList" AutoPostBack=false runat="server" Width="180px" CssClass="textfield"></asp:dropdownlist></td>			    
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
    	<tr class="PartWhite" align=center>
			<td  valign="middle" colspan="4"><center><asp:button id=Search runat="server" BorderStyle="Ridge" CausesValidation="True" CssClass="button" BorderWidth="1px" Text="Search"></asp:button>
			&nbsp;&nbsp;&nbsp;<asp:button id=Reset runat="server" BorderStyle="Ridge" CausesValidation="false" CssClass="button" BorderWidth="1px" Text="Reset"></asp:button>
			</center>
			</td>
		</tr>	
	    </table>
	   </td>						
	</tr>
</asp:PlaceHolder>

<!---  Data Content Area -->						
<asp:PlaceHolder id=searchDataArea Runat="server">
<tr width="100%">
  <td>
  <asp:DataGrid ID="Grid" runat="server" Width="100%" PageSize="10" AllowPaging="True" AllowSorting="True" DataKeyField="EmpId" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="Grid_PageIndexChanged"            OnCancelCommand="Grid_CancelCommand" OnDeleteCommand="Grid_DeleteCommand" OnEditCommand="Grid_EditCommand" OnUpdateCommand="Grid_UpdateCommand" OnSorting="Grid_SortCommand">
              <Columns>
                    <asp:TemplateColumn HeaderText="Employee ID" ItemStyle-Width="10%" SortExpression="Employee_ID">
                                <ItemTemplate> 
                                     <asp:LinkButton name="Edit" commandName="Edit"  CausesValidation="false" runat="server" ToolTip="Click to manage leave information"> <%# Eval("Employee_ID")%></asp:LinkButton>                                                                 
                                </ItemTemplate>
                    </asp:TemplateColumn>
                    
                    <asp:TemplateColumn HeaderText="Employee Name" ItemStyle-Width="15%" SortExpression="Name">
                                <ItemTemplate> 
                                     <asp:LinkButton name="Edit" commandName="Edit"  CausesValidation="false" runat="server" ToolTip="Click to manage leave information"> <%# Eval("Name")%></asp:LinkButton>                                                                 
                                </ItemTemplate>
                    </asp:TemplateColumn>

                    <asp:BoundColumn HeaderText="Job Title" DataField="Designation" SortExpression="Designation" ItemStyle-Width="15%"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Supervisor" DataField="LineManager" SortExpression="LineManager" ItemStyle-Width="15%"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Emp Status" DataField="EmpStatusName" SortExpression="EmpStatusName" ItemStyle-Width="10%"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Business Unit" DataField="DivisionName" SortExpression="DivisionName" ItemStyle-Width="12%"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Location" DataField="DivisionLocation" SortExpression="DivisionLocation" ItemStyle-Width="12%"></asp:BoundColumn>                                        
                    <asp:BoundColumn HeaderText="Department" DataField="DeptName" ItemStyle-Width="15%" SortExpression="DeptName"></asp:BoundColumn>
               </Columns>                                
      
                <FooterStyle CssClass="GridFooter" />
                <SelectedItemStyle CssClass="GridSelectedItem" />
                <PagerStyle CssClass="GridPagerItem" HorizontalAlign="Center" Mode="NumericPages" />
                <AlternatingItemStyle CssClass="GridAltItem" />
                <ItemStyle CssClass="GridItem" />
                <HeaderStyle CssClass="GridHeader" />
</asp:DataGrid>
</br>
<center><asp:label id ="emptyRow" value="" visible=false runat="server" /></center>
</td>
    
</tr>
</ASP:PlaceHolder>

<!--    Edit Employee Data Area -->
<asp:PlaceHolder id=EditArea Runat="server" visible="false">
 <tr width="100%">
		<td class="colheader">Manage Employee Leave Information</td>
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
                            <tr><td align="right"><span class="mainheadtxt3">Business Unit&nbsp;&nbsp;</span></td><td><asp:Label id="lblDivision" runat="server" cssclass="mainheadtxt2" /></td></tr>	       
                            <tr><td align="right"><span class="mainheadtxt3">Business Unit Location&nbsp;&nbsp;</span></td><td><asp:Label id="lblDivisionLocation" runat="server" cssclass="mainheadtxt2" /></td></tr>	                                                                      
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
                         <tr><td align="right"><span class="mainheadtxt3">Business Unit&nbsp;&nbsp;</span></td><td><asp:Label id="lblSuperVisor_Division" runat="server" cssclass="mainheadtxt2" /></td></tr>	       
                         <tr><td align="right"><span class="mainheadtxt3">Business Unit Location&nbsp;&nbsp;</span></td><td><asp:Label id="lblSuperVisor_DivisionLocation" runat="server" cssclass="mainheadtxt2" /></td></tr>	                                                                                          
	                     <tr><td align="right"><span class="mainheadtxt3">Work Phone&nbsp;&nbsp;</span></td><td><asp:label id="lblSuperVisor_Phone" runat="server" cssclass="mainheadtxt2" /></td></tr>
	                     <tr><td align="right"><span class="mainheadtxt3">Email Address&nbsp;&nbsp;</span></td><td><asp:label id="lblSuperVisor_EmailAddress" runat="server" cssclass="mainheadtxt2" /></td></tr>
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
             <li><asp:button id=tab1 runat="server" BorderStyle="Ridge" CausesValidation="false" CssClass="button" BorderWidth="1px" Text="Annual Leave Entitlements/Balances"></asp:button></li>
             <li><asp:button id=tab2 runat="server" BorderStyle="Ridge" CausesValidation="false" CssClass="button" BorderWidth="1px" Text="Past Leave History"></asp:button></li>
             <li><asp:button id=tab3 runat="server" BorderStyle="Ridge" CausesValidation="false" CssClass="button" BorderWidth="1px" Text="Pending Leave Requests"></asp:button></li>
        
            </ul>  
     </div>
  </td>
</tr>  
<!--  Start:Tab 1--->
<tr><td width="100%">
 <asp:PlaceHolder id="Tab1_Pane" Runat="server" visible="false">
  <fieldset><Legend>Annual Leave Entitlements/Balances</Legend>	
        <table width="100%" border="0" class="Partgrayblock">
            <tr><td colspan="4">&nbsp;</td></tr>
 	        <tr>
			    <td class="mainheadtxt">Select Leave Type</td>
			    <td class="mainheadtxt">Leave Period</td>
			    <td class="mainheadtxt">Entitled Days</td>
			    <td class="mainheadtxt">Required Approval</td>
			    
		    </tr>
		    <tr>
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab1_LeaveTypeList"  TabIndex=1 AutoPostBack=false runat="server" Width="150px" CssClass="textfield"></asp:dropdownlist></td>
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab1_LeavePeriodList"  TabIndex=2 AutoPostBack=false runat="server" Width="150px" CssClass="textfield"></asp:dropdownlist></td>
			    <td class="mainheadtxt"><asp:textbox  id=Tab1_Entitlement cssclass="textfield" TabIndex=3  Maxlength="30" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:CheckBox ID="Tab1_ApprCheckBox1" runat="server" Text="Line Manager(Default)" Checked=true/> &nbsp;&nbsp;
			                            <asp:CheckBox ID="Tab1_ApprCheckBox2" runat="Server" Text="Second Approver/Dept.Head" />
			                            &nbsp;&nbsp;<asp:dropdownlist id="Tab1_SuperVisorList" cssclass="textfield" TabIndex=4 AutoPostBack=false runat="server" Width="150px" ></asp:dropdownlist>
			    </td>

		    </tr>	
            <tr>
		        <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_LeaveTypeList InitialValue=-1 ErrorMessage="Leave Type is required." /></td>   
		        <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_LeavePeriodList InitialValue=-1  ErrorMessage="Leave Period is required." /></td>                           
                <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_Entitlement  ErrorMessage="Entitlement is required." />
                            <br /><asp:CompareValidator  ControlToValidate=Tab1_Entitlement Type=double Display=Dynamic Operator="DataTypeCheck"  ErrorMessage="Please enter a valid value" runat="server"></asp:CompareValidator>
                </td>                           
                <td class="validationtxt">&nbsp;</td>
		    </tr>
		    <tr><td colspan="4">&nbsp;</td></tr>	    
            <tr align=center>
			    <td  valign="middle" colspan="4"><center><asp:button id=Entitlement_Save runat="server" BorderStyle="Ridge" CausesValidation="True" CssClass="button" BorderWidth="1px" Text="Save"></asp:button>&nbsp;&nbsp;
			                                             <asp:button id=Entitlement_Cancel runat="server" BorderStyle="Ridge" CausesValidation="false" CssClass="button" BorderWidth="1px" Text="Reset"></asp:button>
			                                    </center>
			    </td>
            </tr>
             <tr>
                <td colspan="4" align=center><asp:label id="Tab1_Message" runat="server" visible=false />&nbsp;&nbsp;
                                             <asp:Label id="Tab1_keyField" runat="server" visible=false /></td>
            </tr>
            <tr><td colspan="4"><hr /></td></tr>
              <!-- DataGrid to display employee's annual leave entitlements -->
             <tr>
                <td colspan="4">
                    <asp:DataGrid ID="EGrid" runat="server" Width="100%" PageSize="5" AllowPaging="True" DataKeyField="EntitlementID" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="EGrid_PageIndexChanged"                                    OnDeleteCommand="EGrid_DeleteCommand" OnEditCommand="EGrid_EditCommand" >                                   
                      <Columns>
                            <asp:BoundColumn HeaderText="Leave Type" DataField="LeaveTypeName" ItemStyle-Width="18%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Entitled Days(FullPay)" DataField="Annual_Entitlement" ItemStyle-Width="16%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Current Balance(Days)" DataField="Annual_Balance" ItemStyle-Width="14%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Current Availed(Days)" DataField="Annual_Availed" ItemStyle-Width="14%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="LM Approval" DataField="LineMgr_Approval" ItemStyle-Width="10%"></asp:BoundColumn>    
                            <asp:BoundColumn HeaderText="DH Approval" DataField="Dept_Approval" ItemStyle-Width="10%"></asp:BoundColumn>                                                    
                            <asp:BoundColumn HeaderText="Current Leave period" DataField="LeavePeriodName" ItemStyle-Width="14%"></asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="" ItemStyle-Width="5%">
                                    <ItemTemplate> 
                                         <asp:LinkButton name="Edit" commandName="Edit" Text="Edit" CausesValidation="false" runat="server" /> 
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
                    <br /><center><asp:label id ="Tab1_EmptyRow" value="" visible=false runat="server" /></center>           
           
                </td>
            </tr> 
       			        
	    </table>
	    
  </fieldset>
 </asp:placeholder>
</td>
</tr>
<!--   End of Tab1 -->
<!--   Tab2 :My Approved Leave Requests -->
<tr><td width="100%"> 
   <asp:PlaceHolder id="Tab2_Pane" Runat="server" visible="false">
    <fieldset><legend>Past Leave History</legend>
      <table width="100%" border="0" class="Partgrayblock">              
		    <tr><td colspan="4">&nbsp;</td></tr>
		    <tr>
			    <td class="mainheadtxt">Select Current Leave Period</td>
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab2_LeavePeriodList"  TabIndex=1 AutoPostBack=true runat="server" Width="150px" CssClass="textfield"></asp:dropdownlist></td>
			    <td class="mainheadtxt"></td>
			    <td class="mainheadtxt"></td>
			</tr>
			<tr>
                <td colspan="4" align=center><asp:label id="Tab2_Message" runat="server" visible=false />&nbsp;
                                             <asp:Label id="Tab2_keyField" runat="server" visible=false />
                
            </td>
            </tr>
            <tr><td colspan="4"><hr /></td></tr>
            
            <!-- Leave Grid -->
             <tr>
                <td colspan="4">
                    <asp:DataGrid ID="LGrid" runat="server" Width="100%" PageSize="10" AllowPaging="True" DataKeyField="LeaveRequestID" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="LGrid_PageIndexChanged" OnEditCommand="LGrid_EditCommand">                                   
                      <Columns>
                            <asp:BoundColumn HeaderText="Employee Name" DataField="Emp_Name" ItemStyle-Width="15%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Leave Start Date" DataField="Leave_StartDate" ItemStyle-Width="12%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Leave Start Date" DataField="Leave_EndDate" ItemStyle-Width="12%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Leave Type" DataField="LeaveTypeName" ItemStyle-Width="15%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Pay Type" DataField="LeavePayType" ItemStyle-Width="12%"></asp:BoundColumn>       
                            <asp:BoundColumn HeaderText="No of Days" DataField="DaysRequested" ItemStyle-Width="12%"></asp:BoundColumn>                                                 
                            <asp:BoundColumn HeaderText="Comments" DataField="Comments" ItemStyle-Width="18%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Status" DataField="StatusName" ItemStyle-Width="12%"></asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="" ItemStyle-Width="8%">
                                <ItemTemplate> 
                                     <asp:LinkButton name="Select" commandName="Edit" CausesValidation="false" Text="Edit/Cancel" runat="server" />
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
                    <br /><center><asp:label id ="Tab2_EmptyRow" value="" visible=false runat="server" /></center>           
           
                </td>
            </tr>
            <tr><td colspan="4"><hr /></td></tr>
      	    <tr>
        	    <td class="mainheadtxt">Leave Start Date</td>
		        <td class="mainheadtxt">Leave End Date</td>
			    <td class="mainheadtxt">Leave Type</td>
			    <td class="mainheadtxt">Employee's Comment</td>
			</tr>

			<tr>
			    <td class="mainheadtxt"><asp:textbox id=Tab2_StartDate disabled="true"  CssClass="textfield" Maxlength="10" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab2_EndDate   disabled="true"  CssClass="textfield" Maxlength="10" runat="server"></asp:textbox></td>		
			    <td class="mainheadtxt"> <asp:dropdownlist id="Tab2_LeaveTypeList" disabled=true  CssClass="textfield" runat="server" Width="180px" ></asp:dropdownlist></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab2_Comments  disabled="true"  CssClass="textfield" Maxlength="100" width="250px" runat="server"></asp:textbox></td>	    			    			
			</tr>

            <tr><td class="validationtxt">&nbsp;</td></tr>
   	        <tr>
   	            <td class="mainheadtxt">Employee Name</td>
   	            <td class="mainheadtxt">Leave Pay Type</td>
   	            <td class="mainheadtxt">Required Approval </td>
   	            <td class="mainheadtxt">Approver's Comment</td>
   	        </tr>
   	        <tr>
   	            <td class="mainheadtxt"><asp:textbox id=Tab2_EmpName  disabled="true"  CssClass="textfield" Maxlength="50"  width="200px" runat="server"></asp:textbox></td>
                                        
			    <td class="mainheadtxt"> <asp:RadioButton disabled="true" ID="Tab2_Rb1_PayType1" runat="server" TabIndex=1 Text="Paid" Checked= 'true' value ="1" GroupName="LeavePayType" AutoPostBack="false" />  
                                        &nbsp;&nbsp;&nbsp;<asp:RadioButton disabled="true" ID="Tab2_Rb1_PayType2" runat="server" Text="Unpaid"  value = "0" GroupName="LeavePayType" AutoPostBack="false" />                                        
			    </td>
			    <td class="mainheadtxt"><asp:RadioButton readonly="true" ID="Tab2_ApprRB1" TabIndex=2 runat="server" Text="Approved" Checked= 'true' value ="1" GroupName="ApprovalType" AutoPostBack="false" />  
                                        &nbsp;&nbsp;&nbsp;<asp:RadioButton readonly="true" ID="Tab2_ApprRB2" runat="server" Text="Rejected"  value = "0" GroupName="ApprovalType" AutoPostBack="false" /> 
                 </td>

                <td class="mainheadtxt"><asp:textbox id=Tab2_ApproverComments  TabIndex=3 CssClass="textfield" Maxlength="100" width="250px" runat="server"></asp:textbox></td>	    			    			
		    </tr>	
		    
	        <tr><td colspan="4"><hr /></td></tr>
            <tr  align=center>
			    <td  valign="middle" colspan="4"><center><asp:button id=Tab2_Cancel runat="server" BorderStyle="Ridge" CausesValidation="True" CssClass="button" BorderWidth="1px" Text="Cancel Leave"></asp:button>
			                                    &nbsp;&nbsp;&nbsp;<asp:button id=Tab2_Reset runat="server" BorderStyle="Ridge" CausesValidation="false" CssClass="button" BorderWidth="1px" Text="Reset"></asp:button></center></td>
            </tr>	
             <tr>
                <td colspan="4" align=center><asp:label id="Tab2_Message2" runat="server" visible=false /> </td>                                           
            </tr>
            <tr><td colspan="4"><hr /></td></tr>
            
            
            
	       </table>   	 
	       </fieldset>
    </asp:placeholder>
</td>
</tr>
<!--   End of Tab2 -->
<!--   Tab3 :Pending Leave Requests for Approval -->
<tr><td width="100%"> 
   <asp:PlaceHolder id="Tab3_Pane" Runat="server" visible="false">
    <fieldset><legend>Pending Leave Requests</legend>
      <table width="100%" border="0" class="Partgrayblock">              
		    <tr><td colspan="4">&nbsp;</td></tr>
		    <tr>
        	    <td class="mainheadtxt">Leave Start Date</td>
		        <td class="mainheadtxt">Leave End Date</td>
			    <td class="mainheadtxt">Leave Type</td>
			    <td class="mainheadtxt">Employee's Comment</td>
			</tr>

			<tr>
			    <td class="mainheadtxt"><asp:textbox id=Tab3_StartDate disabled="true"  CssClass="textfield" Maxlength="10" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab3_EndDate   disabled="true"  CssClass="textfield" Maxlength="10" runat="server"></asp:textbox></td>		
			    <td class="mainheadtxt"> <asp:dropdownlist id="Tab3_LeaveTypeList" disabled=true  CssClass="textfield" runat="server" Width="180px" ></asp:dropdownlist></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab3_Comments  disabled="true"  CssClass="textfield" Maxlength="100" width="250px" runat="server"></asp:textbox></td>	    			    			
			</tr>

            <tr><td colspan="4"></td></tr>
   	        <tr>
   	            <td class="mainheadtxt">Employee Name</td>
   	            <td class="mainheadtxt">Leave Pay Type</td>
   	            <td class="mainheadtxt">Required Approval </td>
   	            <td class="mainheadtxt">Approver's Comment</td>
   	        </tr>
   	        <tr>
   	            <td class="mainheadtxt"><asp:textbox id=Tab3_EmpName  disabled="true"  CssClass="textfield" Maxlength="50"  width="200px" runat="server"></asp:textbox></td>
                                        
			    <td class="mainheadtxt"> <asp:RadioButton ID="Tab3_Rb1_PayType1" runat="server" TabIndex=1 Text="Paid" Checked= 'true' value ="1" GroupName="LeavePayType" AutoPostBack="false" />  
                                        &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="Tab3_Rb1_PayType2" runat="server" Text="Unpaid"  value = "0" GroupName="LeavePayType" AutoPostBack="false" />                                        
			    </td>
			    <td class="mainheadtxt"><asp:RadioButton ID="Tab3_ApprRB1" TabIndex=2 runat="server" Text="Approved" Checked= 'true' value ="1" GroupName="ApprovalType" AutoPostBack="false" />  
                                        &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="Tab3_ApprRB2" runat="server" Text="Rejected"  value = "0" GroupName="ApprovalType" AutoPostBack="false" /> 
                 </td>

                <td class="mainheadtxt"><asp:textbox id=Tab3_ApproverComments  TabIndex=3 CssClass="textfield" Maxlength="100" width="250px" runat="server"></asp:textbox></td>	    			    			
		    </tr>	
		    
	        <tr><td colspan="4"><hr /></td></tr>
            <tr  align=center>
			    <td  valign="middle" colspan="4"><center><asp:button id=Tab3_Approve runat="server" BorderStyle="Ridge" CausesValidation="True" CssClass="button" BorderWidth="1px" Text="Save"></asp:button>
			                                    &nbsp;&nbsp;&nbsp;<asp:button id=Tab3_Reset runat="server" BorderStyle="Ridge" CausesValidation="false" CssClass="button" BorderWidth="1px" Text="Reset"></asp:button></center></td>
            </tr>	
             <tr>
                <td colspan="4" align=center><asp:label id="Tab3_Message" runat="server" visible=false />&nbsp;
                                             <asp:Label id="Tab3_keyField" runat="server" visible=false />
                
                </td>
            </tr>
            <tr><td colspan="4"><hr /></td></tr>
            
            <!-- Emergency Contact Grid -->
             <tr width="100%">
                <td colspan="4">
                    <asp:DataGrid ID="ALGrid" runat="server" Width="100%" PageSize="12" AllowPaging="True" DataKeyField="LeaveRequestID" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="ALGrid_PageIndexChanged"                                    OnEditCommand="ALGrid_EditCommand" >
                                   
                      <Columns>
                            <asp:BoundColumn HeaderText="Employee Name" DataField="Emp_Name" ItemStyle-Width="18%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Leave Start Date" DataField="Leave_StartDate" ItemStyle-Width="15%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Leave End Date" DataField="Leave_EndDate" ItemStyle-Width="15%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Leave Type" DataField="LeaveTypeName" ItemStyle-Width="18%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Leave Pay Type" DataField="LeavePayType" ItemStyle-Width="15%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="No of Days" DataField="DaysRequested" ItemStyle-Width="12%"></asp:BoundColumn>                                                 
                            <asp:BoundColumn Visible=false HeaderText="Comments" DataField="Comments" ItemStyle-Width="0%"></asp:BoundColumn>
                            <asp:BoundColumn Visible=false HeaderText="Approver Comments" DataField="Comments" ItemStyle-Width="0%"></asp:BoundColumn>                            
                            <asp:BoundColumn HeaderText="Status" DataField="StatusName" ItemStyle-Width="15%"></asp:BoundColumn>
                            
                            <asp:TemplateColumn HeaderText="">
                                <ItemTemplate> 
                                     <asp:LinkButton name="Select" commandName="Edit" CausesValidation="false" Text="Select" runat="server" />
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
                    <br /><center><asp:label id ="Tab3_EmptyRow" value="" visible=false runat="server" /></center>           
           
                </td>
            </tr>
	       </table>   	 
	       </fieldset>
    </asp:placeholder>
</td>
</tr>
<!--   End of Tab2 -->



</asp:PlaceHolder>
<!--- Common for all tabs --->

<tr class="PartBrown" >
   <td width="100%" align=center><asp:label id="message" runat="server" visible=false /></td>			
</tr> 			


</table>
	<!--   End of Data Area -->
										
</master:content>


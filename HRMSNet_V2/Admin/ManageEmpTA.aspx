<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManageEmpTA.aspx.cs" Inherits="SchoolNet.ManageEmpTA" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
 <master:content id="formData" runat="server" height="100%" width="100%">
 <table  border="0" cellspacing="0" cellpadding="0" width=100% height="100%">
  <!--   Search Box -->
 <ASP:PlaceHolder id="EmpSearchBox" Runat="server">
    <tr width="100%">
		<td class="colheader"><span class="maintitledesign">Employee Time & Attendance Management</span></td>
	</tr>
    <asp:PlaceHolder id=searchDataArea Runat="server">
<tr width="100%">
  <td>
  <div class="ManageEmpGrid">
  <asp:DataGrid ID="Grid" runat="server" Width="100%" PageSize="10" AllowPaging="True" AllowSorting="True" DataKeyField="EmpId" AutoGenerateColumns="False" CellPadding="4" GridLines="None" OnPageIndexChanged="Grid_PageIndexChanged" 
           OnCancelCommand="Grid_CancelCommand" OnDeleteCommand="Grid_DeleteCommand" OnEditCommand="Grid_EditCommand" OnUpdateCommand="Grid_UpdateCommand" OnSorting="Grid_SortCommand">
              <Columns>
                    <asp:TemplateColumn HeaderText="Employee ID" ItemStyle-Width="10%" SortExpression="Employee_ID">
                                <ItemTemplate> 
                                     <asp:LinkButton name="Edit" commandName="Edit"  CausesValidation="false" runat="server" ToolTip="Click to manage leave information"> <%# Eval("Employee_ID")%></asp:LinkButton>                                                                 
                                </ItemTemplate>
                    </asp:TemplateColumn>
                    
                    <asp:TemplateColumn HeaderText="Employee Name" ItemStyle-Width="18%" SortExpression="Name">
                                <ItemTemplate> 
                                     <asp:LinkButton name="Edit" commandName="Edit"  CausesValidation="false" runat="server" ToolTip="Click to manage leave information"> <%# Eval("Name")%></asp:LinkButton>                                                                 
                                </ItemTemplate>
                    </asp:TemplateColumn>

                    <asp:BoundColumn HeaderText="Job Title" DataField="Designation" SortExpression="Designation" ItemStyle-Width="15%"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Supervisor" DataField="LineManager" SortExpression="LineManager" ItemStyle-Width="15%"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Status" DataField="EmpStatusName" SortExpression="EmpStatusName" ItemStyle-Width="6%"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Business Unit" DataField="DivisionName" SortExpression="DivisionName" ItemStyle-Width="12%"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Location" DataField="DivisionLocation" SortExpression="DivisionLocation" ItemStyle-Width="9%"></asp:BoundColumn>                                        
                    <asp:BoundColumn HeaderText="Department" DataField="DeptName" ItemStyle-Width="15%" SortExpression="DeptName"></asp:BoundColumn>
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
</ASP:PlaceHolder>

	<tr>
		<td>
		    <table width="100%" border="0" class="Partgrayblock">
            <tr class="PartWhite" align=center>
            <td valign="left" class="mainheadtxt">&nbsp;&nbsp;
                <a id="adv_search" href="#" runat="server"><IMG id="adv_search_img" src="~/images/buttons/blue_adv_search.jpg" runat="server" alt="Advanced Search" title="Advanced Search" height="27" width="28" style="float:left;">
                <span style="text-decoration:underline;color:#FFF;float:left;margin:0;padding:5px 0 0 0;">Advanced Search</span></a>
            </td>
			<td  align="right" colspan="2" class="mainsearchtxt">
            Employee ID&nbsp;<asp:textbox id=emp_ID cssclass="textfield" Maxlength="30" runat="server"></asp:textbox>
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
</asp:PlaceHolder>

<!---  Data Content Area -->						

<!--    Edit Employee Data Area -->
<asp:PlaceHolder id=EditArea Runat="server" visible="false">
 <tr width="100%">
		<td class="colheader"><span class="maintitledesign">Manage Employee Leave Details</span></td>
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
             <li><asp:button id=tab1 runat="server" BorderStyle="Ridge" CausesValidation="false" CssClass="button" BorderWidth="1px" Text="Assign Employee Shifts"></asp:button></li>
             <li><asp:button id=tab2 runat="server" BorderStyle="Ridge" CausesValidation="false" CssClass="button" BorderWidth="1px" Text="Change Approver"></asp:button></li>
             <li><asp:button id=tab3 runat="server" BorderStyle="Ridge" CausesValidation="false" CssClass="button" BorderWidth="1px" Text="View Monthly Attendance"></asp:button></li>
        
            </ul>  
     </div>
  </td>
</tr>  
<!--  Start:Tab 1--->
<tr><td width="100%">
 <asp:PlaceHolder id="Tab1_Pane" Runat="server" visible="false">
 
        <table width="100%" border="0" class="Partgrayblock">
            <tr><td colspan="4"><span class="maintitledesign">Assign Employee Shifts</span></td></tr>               
            <tr><td colspan="4">&nbsp;</td></tr>
 	        <tr>
			    <td class="mainheadtxt">Select Shift Type</td>
			    <td class="mainheadtxt">Start Date</td>
			    <td class="mainheadtxt">End Date</td>

			    
		    </tr>
		    <tr>
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab1_ShiftTypeList"  TabIndex=1 AutoPostBack=false runat="server" Width="150px" CssClass="textfield"></asp:dropdownlist></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_StartDate  TabIndex=2 CssClass="textfield" Maxlength="10" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_EndDate    TabIndex=3 CssClass="textfield" Maxlength="10" runat="server"></asp:textbox></td>		
		    </tr>	
            <tr>
                <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_ShiftTypeList InitialValue=-1 ErrorMessage="Shift Type is required." /></td>                   
                <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_StartDate  ErrorMessage="Shift Start Date is required." />
                                        <br /><asp:RegularExpressionValidator  runat=server ControlToValidate=Tab1_StartDate  Display="static" ValidationExpression="(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/\d{4}" ErrorMessage="Date is required DD/MM/YYYY format." />
                </td>   
                <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_EndDate  ErrorMessage="Shift End Date is required." />
                                        <br /><asp:RegularExpressionValidator  runat=server ControlToValidate=Tab1_EndDate  Display="Dynamic" ValidationExpression="(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/\d{4}" ErrorMessage="Date is required DD/MM/YYYY format." />
                </td>   
		    </tr>

            <tr class="PartButtons" align=center>
			<td  colspan="4">
			<center>
			    <asp:button id=AssignShift_Save runat="server" CausesValidation="True" CssClass="Button SaveButton" Text="Save"></asp:button>
			    &nbsp;&nbsp;&nbsp;
			    <asp:button id=AssignShift_Cancel runat="server" CausesValidation="false" CssClass="Button ResetButton" Text="Reset"></asp:button>
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
                    <asp:DataGrid ID="EGrid" class="Tabular2" runat="server" Width="100%" PageSize="5" AllowPaging="True" DataKeyField="ID" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="EGrid_PageIndexChanged" 
                                   OnDeleteCommand="EGrid_DeleteCommand" OnEditCommand="EGrid_EditCommand" >                                   
                      <Columns>
                            <asp:BoundColumn HeaderText="Shift Type" DataField="ShiftName" ItemStyle-Width="20%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Shift ID" DataField="ShiftID" visible= false ItemStyle-Width="20%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Shift Short Name" DataField="ShiftShortName" ItemStyle-Width="20%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Shift Start Date" DataField="ShiftStartDate" ItemStyle-Width="20%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Shift End Date" DataField="ShiftEndDate" ItemStyle-Width="20%"></asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="" ItemStyle-Width="10%">
                                    <ItemTemplate> 
                                         <asp:LinkButton name="Edit" commandName="Edit" Text="Edit" CausesValidation="false" runat="server" /> 
                                    </ItemTemplate>
                            </asp:TemplateColumn>                    
                            <asp:TemplateColumn HeaderText="" ItemStyle-Width="10%">
                                    <ItemTemplate> 
                                         <asp:LinkButton name="Delete" commandName="Delete" Text="Delete" CausesValidation="false" runat="server" /> 
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
                    <br /><center><asp:label id ="Tab1_EmptyRow" value="" visible=false runat="server" /></center>           
           
                </td>
            </tr> 
       			        
	    </table>
	    
 </asp:placeholder>
</td>
</tr>
<!--   End of Tab1 -->
<!--   Tab2 :My Approved Leave Requests -->
<tr><td width="100%"> 
   <asp:PlaceHolder id="Tab2_Pane" Runat="server" visible="false">
    
      <table width="100%" border="0" class="Partgrayblock"> 
            <tr><td colspan="4"><span class="maintitledesign">Change Approver</span></td></tr>               
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

            
            <!-- Leave Grid -->
             <tr>
                <td colspan="4">
                    <asp:DataGrid ID="LGrid" class="Tabular2" runat="server" Width="100%" PageSize="10" AllowPaging="True" DataKeyField="LeaveRequestID" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="LGrid_PageIndexChanged" OnEditCommand="LGrid_EditCommand">                                   
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
                        <FooterStyle CssClass="DashGridFooter" />
                        <SelectedItemStyle CssClass="DashGridSelectedItem" />
                        <PagerStyle CssClass="GridPagerItem" HorizontalAlign="Center" Mode="NumericPages" />
                        <AlternatingItemStyle CssClass="DashGridAltItem" />
                        <ItemStyle CssClass="DashGridItem" />
                        <HeaderStyle CssClass="DashGridHeader" />
                    </asp:DataGrid>
                    <br /><center><asp:label id ="Tab2_EmptyRow" value="" visible=false runat="server" /></center>           
           
                </td>
            </tr>
            <td colspan="4" align=center><hr/> </td>    
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
		    
            <tr class="PartButtons" align=center>
			<td  colspan="4">
			<center>
			    <asp:button id=Tab2_Cancel runat="server" CausesValidation="True" CssClass="Button CancelButton" Text="Cancel"></asp:button>
			    &nbsp;&nbsp;&nbsp;
			    <asp:button id=Tab2_Reset runat="server" CausesValidation="false" CssClass="Button ResetButton" Text="Reset"></asp:button>
			</center>
			</td>
		</tr>		    
        
             <tr>
                <td colspan="4" align=center><asp:label id="Tab2_Message2" runat="server" visible=false /> </td>                                           
            </tr>
            
            
	       </table>   	 
	</asp:placeholder>
</td>
</tr>
<!--   End of Tab2 -->
<!--   Tab3 :Pending Leave Requests for Approval -->
<tr><td width="100%"> 
   <asp:PlaceHolder id="Tab3_Pane" Runat="server" visible="false">
    
      <table width="100%" border="0" class="Partgrayblock"> 
      <tr><td colspan="4"><span class="maintitledesign">View Monthly Attendance</span></td></tr>               
		    <tr><td colspan="4">&nbsp;</td></tr>
		    
            <tr><td width="100%">
                   <table width="100%" border="0" class="Partgrayblock">
                    <tr><td colspan="4">&nbsp;</td></tr>  
		                <tr>
  		                <td class="mainheadtxt">Select Attendance Month<font color="red">*</font></td>   
		                <td class="mainheadtxt" ><asp:textbox id=Attendance_Month cssclass="monthPicker" TabIndex=1 Maxlength="20" runat="server"></asp:textbox>		    
 		         		                    &nbsp;&nbsp;
                            <asp:ImageButton id=Attendance_Go runat="server" CausesValidation="True" ImageUrl="~/images/buttons/blue_go.png" ToolTip="Go" alt="Go" height="30" width="30" style="vertical-align:middle;"></asp:ImageButton>
                        <td class="validationtxt" colspan="2"><asp:RequiredFieldValidator runat=server ControlToValidate=Attendance_Month  ErrorMessage="Attendance Month is Required." /></td>   
		            </tr>
                    <tr><td colspan="4"><hr /></td></tr>  
                    </table>
          
              </td>
            </tr>
            
            <!-- Emergency Contact Grid -->
             <tr><td width="100%"> 
    
      <table width="100%" border="0" class="Partgrayblock">
                <tr><td>&nbsp;</td></tr>
             <tr width="100%">
                <td width="100%">
                    <asp:DataGrid ID="AttendanceGrid" CssClass="Tabular2" runat="server" Width="100%" PageSize="35" AllowPaging="True" DataKeyField="ID" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">                                 
                        <Columns>
                            <asp:BoundColumn HeaderText="Date" DataField="EntryDate" ItemStyle-Width="15%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Shift Name" DataField="ShiftName" ItemStyle-Width="20%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Shift Short" DataField="ShiftShort" ItemStyle-Width="10%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Shift ID" DataField="ShiftID" Visible = false></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Worked Minutes" DataField="WorkedMins"  Visible = false></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Worked Hours" DataField="WorkedHrs" ItemStyle-Width="15%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="OT Hours" DataField="OTHrs" ItemStyle-Width="15%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="OT Hours" DataField="OTMins" Visible = false></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Date Status" DataField="AttendanceStatus" ItemStyle-Width="25%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Date Status ID" DataField="AttendanceStatusID" Visible = false></asp:BoundColumn>

                       </Columns>                          
                        <FooterStyle CssClass="DashGridFooter" />
                        <SelectedItemStyle CssClass="DashGridSelectedItem" />
                        <PagerStyle CssClass="GridPagerItem" HorizontalAlign="Center" Mode="NumericPages" />
                        <AlternatingItemStyle CssClass="DashGridAltItem" />
                        <ItemStyle CssClass="DashGridItem" />
                        <HeaderStyle CssClass="DashGridHeader" />
                    </asp:DataGrid>
                    <br /><center><asp:label id ="emptyRow1" value="" visible=false runat="server" /></center>           
           
                </td>
            </tr>
	       </table>   	 
	
 </td>
</tr>

	       </table>   	 
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


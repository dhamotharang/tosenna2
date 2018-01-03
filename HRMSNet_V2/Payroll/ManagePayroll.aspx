<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManagePayroll.aspx.cs" Inherits="SchoolNet.ManagePayroll" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
 <master:content id="formData" runat="server" height="100%" width="100%">
 <table  border="0" cellspacing="0" cellpadding="0" width=100% height="100%">
  <!--   Search Box -->
 <ASP:PlaceHolder id="EmpSearchBox" Runat="server">
    <tr width="100%">
		<td class="colheader"><span class="maintitledesign">Employee Payroll Management</span></td>
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
			    <td class="mainheadtxt"><asp:textbox id=empName  Maxlength="50" width="180px" runat="server" CssClass="textfield"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=empID  Maxlength="30" runat="server" CssClass="textfield"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=mgrName  Maxlength="50" width="180px" runat="server" CssClass="textfield"></asp:textbox></td>
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
        <tr class="PartButtons" align=center>
			<td  colspan="4">
			<center>
			    <asp:button id=Search runat="server" CausesValidation="True" CssClass="Button SearchButton" Text="Search"></asp:button>
			    &nbsp;&nbsp;&nbsp;
			    <asp:button id=Reset runat="server" CausesValidation="false" CssClass="Button ResetButton" Text="Reset"></asp:button>
			</center>
			</td>
            </tr>
        <tr><td colspan="4">&nbsp;</td></tr>
	    </table>
	   </td>						
	</tr>

  <tr width="100%">
    <td>
        <asp:DataGrid ID="Grid" runat="server" PageSize="10" Width="100%" AllowPaging="True" AllowSorting="True"  DataKeyField="EmpId" AutoGenerateColumns="False" CellPadding="4" GridLines="None" OnPageIndexChanged="Grid_PageIndexChanged"                      OnEditCommand="Grid_EditCommand" OnSorting="Grid_SortCommand">
                      <Columns>
                            <asp:TemplateColumn HeaderText="Employee ID" SortExpression="Employee_ID" ItemStyle-Width="10%">
                                        <ItemTemplate> 
                                             <asp:LinkButton name="Edit" commandName="Edit"  CausesValidation="false" runat="server" ToolTip="Click to manage payroll information"> <%# Eval("Employee_ID")%></asp:LinkButton>                                                                 
                                        </ItemTemplate>
                            </asp:TemplateColumn>
                            
                            <asp:TemplateColumn HeaderText="Employee Name" SortExpression="Name" ItemStyle-Width="18%">
                                        <ItemTemplate> 
                                             <asp:LinkButton name="Edit" commandName="Edit"  CausesValidation="false" runat="server" ToolTip="Click to manage payroll information"> <%# Eval("Name")%></asp:LinkButton>                                                                 
                                        </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:BoundColumn HeaderText="Job Title" DataField="Designation" SortExpression="Designation" ItemStyle-Width="15%"></asp:BoundColumn>                            
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
    </td>
    
</tr>
</ASP:PlaceHolder>

<!--    Edit Employee Data Area -->
<asp:PlaceHolder id=EditArea Runat="server" visible="false">
 <tr width="100%">
		<td class="colheader"><span class="maintitledesign">Review and Reconcilation of Employee Payroll Information</span></td>
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
	                    </table>	                              
	      </td>				
		</tr>
     </table>
    </td>
</tr>
<tr><td width="100%">
<asp:placeholder id="Tab1_Pane" runat="server" Visible=false>

        <table width="100%" border="0" class="Partgrayblock">
            <tr width="100%"><td colspan="4"><span class="maintitledesign">Review and Reconcilation of Monthly Payroll</span></td></tr>
            <tr><td colspan="4">&nbsp;</td></tr>
            <tr>
		        <td class="mainheadtxt">Select Month/Year<font color=red>*</font></td>   
		        <td class="mainheadtxt" ><asp:textbox id=Payroll_Date cssclass="monthPicker2 textfield" TabIndex=1 Maxlength="20" runat="server"></asp:textbox>		    
		          &nbsp;&nbsp;
                  <asp:ImageButton id=Payroll_Go runat="server" CausesValidation="True" ImageUrl="~/images/buttons/blue_go.png" ToolTip="Go" alt="Go" height="30" width="30" style="vertical-align:middle;"></asp:ImageButton>
                </td>
                <td class="mainheadtxt">Payroll Status:&nbsp;<asp:dropdownlist id="Tab1_PayrollStatusType" AutoPostBack=false runat="server" TabIndex=21 Width="110px" CssClass="textfield"></asp:dropdownlist></td>	                             
                <td>&nbsp;</td>                
		    </tr>
	         <tr><td class="validationtxt" colspan="4"><asp:RequiredFieldValidator runat=server ControlToValidate=Payroll_Date  ErrorMessage="Select Month/Year to prepare Payroll." /></td></tr>   
             <tr><td colspan="4" class="mainheadtxt" align=right><asp:HyperLink ID="WPSDownloadLink" runat="server" visible=false></asp:HyperLink></td></tr>  
              <asp:placeholder id="payperiod" runat="server" visible=false>
                <tr><td class="mainheadtxt">Payroll Period:&nbsp;<asp:label  id="Tab1_PayStartDate" runat="server" /> - <asp:label id="Tab1_PayEndDate" runat="server" /></td></tr> 
              </asp:placeholder>  
             <tr><td colspan="4"><hr /></td></tr>
	         <asp:placeholder id="Paycomponents" visible=false runat="server">   
		      <tr class="HomeTitles"><td colspan="3" class="mainheadtxt4" valign="top">Standard Monthly Benefits and Deductions</td>
		           <td align="right" class="validationtxt" valign="top"><asp:label id="Tab1_CurrenyLabel1" runat="server"></asp:label></td>
		      </tr>
		    
		        <!-- Pay and Allowance Grid -->
             <tr>
                <td colspan="4" Width="100%">
                    <asp:DataGrid ID="Tab1Grid" CssClass="Tabular2" runat="server" Width="100%" PageSize="20" AllowPaging="false" DataKeyField="PayComponentID" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">                                  
                      <Columns>
                            <asp:BoundColumn HeaderText="Component Type" DataField="PayComponentTypeName" ItemStyle-Width="18%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Component Name" DataField="PayComponentName" ItemStyle-Width="53%"></asp:BoundColumn>                            
                            <asp:BoundColumn HeaderText="Amount" DataField="Amount" DataFormatString="{0:######.00}" ItemStyle-Width="22%"></asp:BoundColumn>
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
            <!-- Allow to add additional components if any specific for this month-->
            <tr><td colspan="4">&nbsp;</td></tr>
            <tr class="HomeTitles"><td colspan="4" class="mainheadtxt4">Adhoc Monthly Payroll Transactions</td></tr>                         
             <tr>
                <td colspan="4" Width="100%">
                    <asp:DataGrid ID="Tab2Grid" CssClass="Tabular2" runat="server" Width="100%" PageSize="10" AllowPaging="false" DataKeyField="PayComponentID" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="Tab2Grid_PageIndexChanged" >                                   
                      <Columns>
                            <asp:BoundColumn HeaderText="Component Type" DataField="PayComponentTypeName" ItemStyle-Width="18%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Adhoc Component Name" DataField="PayComponentName" ItemStyle-Width="35%"></asp:BoundColumn>                            
                            <asp:BoundColumn HeaderText="Amount" DataField="Amount" DataFormatString="{0:######.00}" ItemStyle-Width="22%"></asp:BoundColumn>
                            <asp:BoundColumn Visible=false HeaderText="Comment" DataField="Note" ItemStyle-Width="0%"></asp:BoundColumn>
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
		    <tr><td colspan="4">&nbsp;</td></tr>
            <tr class="HomeTitles" ><td colspan="4" class="mainheadtxt4">Monthly Payroll Unpaid Leave Information</td></tr> 
            <tr><td colspan="4">&nbsp;</td></tr>                        
            <tr>
		        <td class="mainheadtxt">No of Days in the Pay Cycle</td>   
		        <td class="mainheadtxt">No of UnPaid Days(Leave)</td>                           
                <td class="mainheadtxt">Net Pay Days</td>
                <td class="mainheadtxt">Rem Vac Days at the end of the year</td>                
		    </tr>            
             <tr>
			    <td class="mainheadtxt" valign=top><asp:textbox id=Tab1_NoOfDaysPayCycle disabled = true cssclass="textfield"  Maxlength="30" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt" valign=top><asp:textbox id=Tab1_NofUnpaidDays disabled=true cssclass="textfield"   Maxlength="30" runat="server"></asp:textbox></td>			    
			    <td class="mainheadtxt" valign=top><asp:textbox id=Tab1_NetPayDays  disabled=true cssclass="textfield"   Maxlength="30" runat="server"></asp:textbox></td>			    
			    <td class="mainheadtxt" valign=top><asp:textbox id=Tab1_UnusedVacDays  disabled=true cssclass="textfield"   Maxlength="30" runat="server"></asp:textbox></td>			    
		    </tr>	
		    <tr><td colspan="4">&nbsp;</td></tr>
            <tr class="HomeTitles"><td colspan="4" class="mainheadtxt4">Employee Bank Information</td></tr> 
            <tr><td colspan="4">&nbsp;</td></tr>                                                     
		    <tr>
		        <td class="mainheadtxt">Employee Bank Account</td>   
		        <td class="mainheadtxt">Bank Name</td>                           
                <td class="mainheadtxt">Net Pay</td>                
                <td class="mainheadtxt">&nbsp;</td>

		    </tr>      
		    
		    <tr>
			    <td class="mainheadtxt" valign=top><asp:textbox id=Tab1_EmployeeBankAccount cssclass="textfield" TabIndex=4 Maxlength="30" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt" valign=top><asp:dropdownlist id="Tab1_BankName" AutoPostBack=false runat="server" TabIndex=5 Width="220px" CssClass="textfield"></asp:dropdownlist></td>			    
			    <td class="mainheadtxt"><asp:textbox id=Tab1_NetPay  disabled=true cssclass="textfield"   Maxlength="30" runat="server"></asp:textbox></td>				    
			    <td>&nbsp;</td>
		    </tr>	
             <tr>
		        <td class="validationtxt">&nbsp;</td> 
                <td class="mainheadtxt" colspan="3">&nbsp;</td>
             </tr>   
            <tr>
                <td class="mainheadtxt" colspan="4">End of Service Settlement&nbsp;<asp:CheckBox ID="Tab1_EOSCheckBox" runat="server" Text="" checked=false disabled="true"/></td>
		    </tr>  

		     <tr><td colspan="4">&nbsp;</td>
		     <tr class="HomeTitles"><td colspan="4" class="mainheadtxt4">Payroll Comments</td></tr>                              
		     <tr>
		        <td class="mainheadtxt">Note(<small>Maximum of 500 chars)</small></td>   
	            <td class="mainheadtxt" colspan="3"><asp:textbox id=Tab1_Note TextMode=MultiLine Columns="5" Rows="5" TabIndex=6  Width="560px" runat=server cssclass="textfield"></asp:textbox></td>
		    </tr>   
		     <tr>
     		    <td class="validationtxt">&nbsp;</td>
     		    <td class="validationtxt" colspan="3"><asp:RegularExpressionValidator  ControlToValidate="Tab1_Note" Text="Note should not exceed 500 characters" ValidationExpression="^[\s\S]{0,500}$" runat="server" /></td>
            </tr>

  		    <tr><td colspan="4">&nbsp;</td></tr>		    
            
            <tr class="PartButtons" align=center>
			<td  colspan="4">
			<center>
			    <asp:button id=Payroll_Save runat="server" CausesValidation="True" CssClass="Button SaveButton" Text="Save"></asp:button>
			    &nbsp;&nbsp;&nbsp;
			    <asp:button id=Payroll_StartOver runat="server" CausesValidation="false" CssClass="Button SendButton" Text="StartOver"></asp:button>
			    &nbsp;&nbsp;&nbsp;
			    <asp:button id=Tab_Back runat="server" CausesValidation="false" CssClass="Button BackButton" Text="Back"></asp:button>
            </center>
			</td>
		    </tr>
            <tr><td colspan="4">&nbsp;</td></tr>		    
          
          </asp:placeholder>		 			    	    
	     </table>
 </asp:placeholder>
 </td>
</tr>
</asp:placeholder>
<tr class="PartBrown" >
   <td width="100%" align=center><asp:label id="message" runat="server" visible=false /></td>			
</tr> 			
</table>
	<!--   End of Data Area -->
										
</master:content>



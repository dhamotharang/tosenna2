<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewPayrollHistory.aspx.cs" Inherits="SchoolNet.ViewPayrollHistory" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
 <master:content id="formData" runat="server" height="100%" width="100%">
 <table  border="0" cellspacing="0" cellpadding="0" width=100% height="100%">
  <!--   Search Box -->
 <ASP:PlaceHolder id="EmpSearchBox" Runat="server">
    <tr width="100%">
		<td class="colheader"><center>View Employee Payroll History</center></td>
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
			    <td class="mainheadtxt"><asp:textbox id=empID  Maxlength="30" runat="server"></asp:textbox></td>
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

  <tr width="100%">
    <td>
        <asp:DataGrid ID="Grid" runat="server" PageSize="5" Width="100%" AllowPaging="True" AllowSorting="True"  DataKeyField="EmpId" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="Grid_PageIndexChanged"                      OnEditCommand="Grid_EditCommand" OnSorting="Grid_SortCommand">
                      <Columns>
                            <asp:TemplateColumn HeaderText="Employee ID" SortExpression="Employee_ID" ItemStyle-Width="10%">
                                        <ItemTemplate> 
                                             <asp:LinkButton name="Edit" commandName="Edit"  CausesValidation="false" runat="server" ToolTip="Click to view payroll history"> <%# Eval("Employee_ID")%></asp:LinkButton>                                                                 
                                        </ItemTemplate>
                            </asp:TemplateColumn>
                            
                            <asp:TemplateColumn HeaderText="Employee Name" SortExpression="Name" ItemStyle-Width="15%">
                                        <ItemTemplate> 
                                             <asp:LinkButton name="Edit" commandName="Edit"  CausesValidation="false" runat="server" ToolTip="Click to view payroll history"> <%# Eval("Name")%></asp:LinkButton>                                                                 
                                        </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:BoundColumn HeaderText="Job Title" DataField="Designation" SortExpression="Designation" ItemStyle-Width="15%"></asp:BoundColumn>                            
                            <asp:BoundColumn HeaderText="Supervisor" DataField="LineManager" SortExpression="LineManager" ItemStyle-Width="15%"></asp:BoundColumn>                                                      
                            <asp:BoundColumn HeaderText="Emp Status" DataField="EmpStatusName" SortExpression="EmpStatusName" ItemStyle-Width="10%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Business Unit" DataField="DivisionName" SortExpression="DivisionName" ItemStyle-Width="15%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Location" DataField="DivisionLocation" SortExpression="DivisionLocation" ItemStyle-Width="15%"></asp:BoundColumn>                                        
                            <asp:BoundColumn HeaderText="Department" DataField="DeptName" SortExpression="DeptName" ItemStyle-Width="21%" ></asp:BoundColumn>
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
		<td class="colheader">View Payroll History</td>
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
    <fieldset><legend>View Monthly Payroll</legend>
        <table width="100%" border="0" class="Partgrayblock">
        
            <tr><td colspan="4">&nbsp;</td></tr>
            <tr>
		        <td class="mainheadtxt">Select Month/Year<font color=red>*</font></td>   
		        <td class="mainheadtxt" ><asp:textbox id=Payroll_Date cssclass="monthPicker1" TabIndex=1 Maxlength="20" runat="server"></asp:textbox>		    
		          &nbsp;&nbsp;<asp:button id=Payroll_Go runat="server" BorderStyle="Ridge" CausesValidation="True" CssClass="button" BorderWidth="1px" Text="Go"></asp:button></td>
                
                <td colspan="2" class="mainheadtxt" align=center>     
		             <asp:HyperLink ID="WPSDownloadLink" runat="server" visible=false></asp:HyperLink>		             
		       </td>
		   </tr> 
       
	         <tr><td class="validationtxt" colspan="4"><asp:RequiredFieldValidator runat=server ControlToValidate=Payroll_Date  ErrorMessage="Select Month/Year to prepare Payroll." /></td></tr>   
             <tr><td colspan="4"><hr /></td></tr>
	         <asp:placeholder id="Paycomponents" visible=false runat="server">  
              <tr>
                <td class="mainheadtxt" colspan="4" align="right">Payroll Status:&nbsp;<asp:dropdownlist id="Tab1_PayrollStatusType" disabled=true AutoPostBack=false runat="server" TabIndex=21 Width="110px" CssClass="textfield"></asp:dropdownlist></td>                             
                
		     </tr>
	         
	          
		      <tr><td colspan="3" class="mainheadtxt" valign="top">Pay Components(Allowances and Deductions)</td>
		           <td align="right" class="validationtxt" valign="top"><asp:label id="Tab1_CurrenyLabel1" runat="server"></asp:label></td>
		      </tr>
		    
		        <!-- Pay and Allowance Grid -->
             <tr>
                <td colspan="4" Width="100%">
                    <asp:DataGrid ID="Tab1Grid" runat="server" Width="100%" PageSize="20" AllowPaging="false" DataKeyField="PayComponentID" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">                                  
                      <Columns>
                            <asp:BoundColumn HeaderText="Component Type" DataField="PayComponentTypeName" ItemStyle-Width="18%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Component Name" DataField="PayComponentName" ItemStyle-Width="50%"></asp:BoundColumn>                            
                            <asp:BoundColumn HeaderText="Amount" DataField="Amount" DataFormatString="{0:######.00}" ItemStyle-Width="22%"></asp:BoundColumn>
                      </Columns>     
                        <FooterStyle CssClass="GridFooter" />
                        <SelectedItemStyle CssClass="GridSelectedItem" />
                        <PagerStyle CssClass="GridPagerItem" HorizontalAlign="Center" Mode="NumericPages" />
                        <AlternatingItemStyle CssClass="GridAltItem" />
                        <ItemStyle CssClass="GridItem" />                
                       <HeaderStyle CssClass="GridHeader" />
                   </asp:DataGrid>
         
                </td>
            </tr>
                            
            <tr><td colspan="4">&nbsp;</td></tr>
                  
	
		    <tr><td colspan="4"><hr /></td></tr>
            <tr><td colspan="4" class="mainheadtxt">Monthly Payroll UnPaid Leave Information</td></tr> 
            <tr><td colspan="4">&nbsp;</td></tr>                        
            <tr>
		        <td class="mainheadtxt">No of Days in the Pay Cycle</td>   
		        <td class="mainheadtxt">No of UnPaid Days(Leave)</td>                           
                <td class="mainheadtxt">Net Pay Days</td>
                <td class="mainheadtxt">&nbsp;</td>
                
		    </tr>            
             <tr>
			    <td class="mainheadtxt" valign=top><asp:textbox id=Tab1_NoOfDaysPayCycle disabled = true cssclass="textfield"  Maxlength="30" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt" valign=top><asp:textbox id=Tab1_NofUnpaidDays disabled=true cssclass="textfield"   Maxlength="30" runat="server"></asp:textbox></td>			    
			    <td class="mainheadtxt" valign=top><asp:textbox id=Tab1_NetPayDays  disabled=true cssclass="textfield"   Maxlength="30" runat="server"></asp:textbox></td>			    
			    <td class="mainheadtxt">&nbsp;</td>
		    </tr>	
		    <tr><td colspan="4"><hr /></td></tr>
            <tr><td colspan="4" class="mainheadtxt">Employee Bank Information</td></tr> 
            <tr><td colspan="4">&nbsp;</td></tr>                                                     
		    <tr>
		        <td class="mainheadtxt">Employee Bank Account</td>   
		        <td class="mainheadtxt">Bank Name</td>                           
                <td class="mainheadtxt">Net Pay</td>                
                <td class="mainheadtxt">&nbsp;</td>                                
		    </tr>      
		    
		    <tr>
			    <td class="mainheadtxt" valign=top><asp:textbox id=Tab1_EmployeeBankAccount disabled=true cssclass="textfield" TabIndex=4 Maxlength="30" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt" valign=top><asp:dropdownlist id="Tab1_BankName" disabled=true AutoPostBack=false runat="server" TabIndex=5 Width="220px" CssClass="textfield"></asp:dropdownlist></td>			    
			    <td class="mainheadtxt"><asp:textbox id=Tab1_NetPay  disabled=true cssclass="textfield"   Maxlength="30" runat="server"></asp:textbox></td>	
			    <td>&nbsp;</td>
		    </tr>	
          
            <tr>
                <td class="mainheadtxt" colspan="4">End of Service Settlement&nbsp;<asp:CheckBox ID="Tab1_EOSCheckBox" runat="server" Text="" checked=false disabled="true"/></td>
		    </tr>  

		     <tr><td colspan="4"><hr/></td>
		     <tr><td colspan="4" class="mainheadtxt">Payroll Note</td></tr>                              
		     <tr>
		        <td class="mainheadtxt">Note(<small>Maximum of 500 chars)</small></td>   
	            <td class="mainheadtxt" colspan="3"><asp:textbox id=Tab1_Note TextMode=MultiLine Columns="5" Rows="5" TabIndex=6  Width="560px" runat=server cssclass="textfield"></asp:textbox></td>
		    </tr>   
		     <tr>
     		    <td class="validationtxt">&nbsp;</td>
     		    <td class="validationtxt" colspan="3"><asp:RegularExpressionValidator  ControlToValidate="Tab1_Note" Text="Note should not exceed 500 characters" ValidationExpression="^[\s\S]{0,500}$" runat="server" /></td>
            </tr>

  		    <tr><td colspan="4"><hr /></td></tr>		    
          
          </asp:placeholder>		 			    	    
	     </table>
	</fieldset>
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



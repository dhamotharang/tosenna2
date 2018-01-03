<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManageEOS.aspx.cs" Inherits="SchoolNet.ManageEOS" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
 <master:content id="formData" runat="server" height="100%" width="100%">
 <table  border="0" cellspacing="0" cellpadding="0" width=100% height="100%">
  <!--   Search Box -->
 <ASP:PlaceHolder id="EmpSearchBox" Runat="server">
    <tr width="100%">
		<td class="colheader"><center>Employee End of Service(EOS) Management</center></td>
	</tr>	

  <tr width="100%">
    <td>
        <asp:DataGrid ID="Grid" runat="server" Width="100%" PageSize="15" AllowPaging="True" DataKeyField="EmpId" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="Grid_PageIndexChanged"                      OnEditCommand="Grid_EditCommand" >
                      <Columns>
                            <asp:TemplateColumn HeaderText="Employee ID" ItemStyle-Width="10%" SortExpression="Employee_ID">
                                        <ItemTemplate> 
                                             <asp:LinkButton name="Edit" commandName="Edit"  CausesValidation="false" runat="server" ToolTip="Click to view/manage EOS Information"> <%# Eval("Employee_ID")%></asp:LinkButton>                                                                 
                                        </ItemTemplate>
                            </asp:TemplateColumn>
                            
                            <asp:TemplateColumn HeaderText="Employee Name" ItemStyle-Width="15%" SortExpression="Name">
                                        <ItemTemplate> 
                                             <asp:LinkButton name="Edit" commandName="Edit"  CausesValidation="false" runat="server" ToolTip="Click to view/manage EOS Information"> <%# Eval("Name")%></asp:LinkButton>                                                                 
                                        </ItemTemplate>
                            </asp:TemplateColumn>                    
                            <asp:BoundColumn HeaderText="Emp Status" DataField="EmpStatusName" ItemStyle-Width="10%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Date Of Leaving" DataField="DateofLeaving" ItemStyle-Width="10%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Business Unit" DataField="DivisionName" ItemStyle-Width="15%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Department" DataField="DeptName" ItemStyle-Width="18%" ></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="EOS Status" DataField="EOSProcessStatus" ItemStyle-Width="12%" ></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Process Status" Visible=true DataField="ProcessStatusName" ItemStyle-Width="10%" ></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Pay_MonthYear" Visible=false DataField="Pay_MonthYear" ItemStyle-Width="0" ></asp:BoundColumn>
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
		<td class="colheader">Review and Reconcilation of End of Service Statement</td>
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
<tr><td width="100%">
<asp:placeholder id="Tab1_Pane" runat="server" Visible=false>
    <legend>Review and  Reconciliation of End of Service Settlement</legend>
        <table width="100%" border="0" class="Partgrayblock">
        
            <tr><td colspan="4">&nbsp;</td></tr>
            <tr>
		        <td class="mainheadtxt">Select Month/Year<font color=red>*</font></td>   
		        <td class="mainheadtxt" ><asp:textbox id=Payroll_Date cssclass="monthPicker2" TabIndex=1 Maxlength="20" runat="server"></asp:textbox>		    
		          &nbsp;&nbsp;<asp:button id=Payroll_Go runat="server" BorderStyle="Ridge" CausesValidation="True" CssClass="button" BorderWidth="1px" Text="Go"></asp:button></td>
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
           
            <tr>
                <td class="mainheadtxt">Date of Joining</td>	
                <td class="mainheadtxt">Date of Leaving</td> 	        
		        <td class="mainheadtxt">Total Years of Service</td>  
		        <td class="mainheadtxt">Gratuity Amount Eligible</td>                           
		    </tr>
		    <tr>
 	            <td class="mainheadtxt" ><asp:textbox id=Tab1_DateJoined disabled=true  Maxlength="20" runat="server" CssClass="textfield"></asp:textbox></td> 	            		                 
		        <td class="mainheadtxt"><asp:textbox id=Tab1_DateLeft disabled=true  Maxlength="20" runat="server" CssClass="textfield"></asp:textbox></td> 	            
			    <td class="mainheadtxt"><asp:textbox id=Tab1_TotalServiceYears disabled=true cssclass="textfield"  Maxlength="30" runat="server"></asp:textbox></td>			    
			    <td class="mainheadtxt"><asp:textbox id=Tab1_GratuityAmount disabled=true cssclass="textfield"  Maxlength="30" runat="server"></asp:textbox></td>			    
		    </tr>	
             <tr><td colspan="4"><hr /></td></tr>

		      <tr><td colspan="3" class="mainheadtxt4" valign="top">Standard Monthly Benefits and Deductions(Prorated based on date of leaving).</td>
		           <td align="right" class="validationtxt" valign="top"><asp:label id="Tab1_CurrenyLabel1" runat="server"></asp:label></td>
		      </tr>
		    
		        <!-- Pay and Allowance Grid -->
             <tr>
                <td colspan="4">
                    <asp:DataGrid ID="Tab1Grid" Width="100%" runat="server" PageSize="20" AllowPaging="false" DataKeyField="PayComponentID" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">                                  
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
            <!-- Allow to add additional components if any specific for this month-->
            <tr><td colspan="4"><hr /></td></tr>
            <tr><td colspan="4" class="mainheadtxt4">Adhoc Monthly Payroll Transactions</td></tr>                         
             <tr>
                <td colspan="4">
                    <asp:DataGrid ID="Tab2Grid" runat="server" Width="100%" PageSize="10" AllowPaging="false" DataKeyField="PayComponentID" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="Tab2Grid_PageIndexChanged">                                   
                      <Columns>
                            <asp:BoundColumn HeaderText="Component Type" DataField="PayComponentTypeName" ItemStyle-Width="18%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Adhoc Component Name" DataField="PayComponentName" ItemStyle-Width="35%"></asp:BoundColumn>                            
                            <asp:BoundColumn HeaderText="Amount" DataField="Amount" DataFormatString="{0:######.00}" ItemStyle-Width="22%"></asp:BoundColumn>
                            <asp:BoundColumn Visible=false HeaderText="Comment" DataField="Note" ItemStyle-Width="0%"></asp:BoundColumn>
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
                                
		    <tr><td colspan="4"><hr /></td></tr>
            <tr><td colspan="4" class="mainheadtxt4">Monthly Payroll UnPaid Leave Information</td></tr> 
            <tr><td colspan="4">&nbsp;</td></tr>                        
            <tr>
		        <td class="mainheadtxt">No of Days in the Pay Cycle</td>   
		        <td class="mainheadtxt">No of UnPaid Days(Leave)</td>                           
                <td class="mainheadtxt">Net Pay Days</td>
                <td class="mainheadtxt">&nbsp;</td>                
		    </tr>            
             <tr>
			    <td class="mainheadtxt" valign=top><asp:textbox id=Tab1_NoOfDaysPayCycle disabled = true cssclass="textfield"  Maxlength="30" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt" valign=top><asp:textbox id=Tab1_NofUnpaidDays disabled=true cssclass="textfield"  Maxlength="30" runat="server"></asp:textbox></td>			    
			    <td class="mainheadtxt" valign=top><asp:textbox id=Tab1_NetPayDays  disabled=true cssclass="textfield"   Maxlength="30" runat="server"></asp:textbox></td>			    
			    <td class="mainheadtxt">&nbsp;</td>
		    </tr>	
		    <tr><td colspan="4"><hr /></td></tr>
            <tr><td colspan="4" class="mainheadtxt4">Employee Bank Information</td></tr> 
            <tr><td colspan="4">&nbsp;</td></tr>                                                     
		    <tr>
		        <td class="mainheadtxt">Employee Bank Account</td>   
		        <td class="mainheadtxt">Bank Name</td>                           
                <td class="mainheadtxt">Net Pay</td>                
                <td class="mainheadtxt">Rem Vac Days at the end of the year</td>
		    </tr>      
		    
		    <tr>
			    <td class="mainheadtxt" valign=top><asp:textbox id=Tab1_EmployeeBankAccount disabled= true cssclass="textfield" TabIndex=4 Maxlength="30" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt" valign=top><asp:dropdownlist id="Tab1_BankName" disabled = true AutoPostBack=false runat="server" TabIndex=5 Width="220px" CssClass="textfield"></asp:dropdownlist>	</td>		    
			    <td class="mainheadtxt"  valign=top><asp:textbox id=Tab1_NetPay  disabled=true cssclass="textfield"   Maxlength="30" runat="server"></asp:textbox></td>				    
			    <td class="mainheadtxt" valign=top><asp:textbox id=Tab1_UnusedVacDays  disabled=true cssclass="textfield"   Maxlength="30" runat="server"></asp:textbox></td>			    
		    </tr>	
            <tr>
                <td class="mainheadtxt" colspan="4">End of Service Settlement&nbsp;<asp:CheckBox ID="Tab1_EOSCheckBox" runat="server" Text="" checked=false disabled="true"/></td>
		    </tr>  
		    
		     <tr><td colspan="4"><hr/></td>
		     <tr><td colspan="4" class="mainheadtxt4">Payroll Note</td></tr>                              
		     <tr>
		        <td class="mainheadtxt">Note(<small>Maximum of 500 chars)</small></td>   
	            <td class="mainheadtxt" colspan="3"><asp:textbox id=Tab1_Note TextMode=MultiLine Columns="5" Rows="5"  TabIndex=6 Width="560px" runat=server cssclass="textfield" ></asp:textbox></td>
		    </tr>   
		     <tr>
     		    <td class="validationtxt">&nbsp;</td>
     		    <td class="validationtxt" colspan="3"><asp:RegularExpressionValidator  ControlToValidate="Tab1_Note" Text="Note should not exceed 500 characters" ValidationExpression="^[\s\S]{0,500}$" runat="server" /></td>
            </tr>

  		    <tr><td colspan="4"><hr /></td></tr>		    
            <tr  align=center>
			    <td  valign="middle" colspan="4">
			        <center>
			                <asp:button id=Payroll_Save runat="server" BorderStyle="Ridge" CausesValidation="True" CssClass="button" BorderWidth="1px" Text="Save EOS Payroll" OnClientClick="return confirm('Are you sure you want to save the monthly payroll data?');"></asp:button>
			                &nbsp;&nbsp;<asp:button id=Payroll_StartOver runat="server" BorderStyle="Ridge" CausesValidation="false" CssClass="button" BorderWidth="1px" Text="Start Over" OnClientClick="return confirm('Are you sure you want to delete and redo the monthly payroll data?');"></asp:button>
			                &nbsp;&nbsp;<asp:button id=Tab_Back runat="server" BorderStyle="Ridge" CausesValidation="false" CssClass="button" BorderWidth="1px" Text="Back to Employee List"></asp:button>		        
			                
	                </center>
                 </td>
            </tr>
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



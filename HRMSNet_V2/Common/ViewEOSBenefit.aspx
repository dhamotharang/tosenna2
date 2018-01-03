<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewEOSBenefit.aspx.cs" Inherits="SchoolNet.ViewEOSBenefit" EnableEventValidation="false"%>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
 <master:content id="formData" runat="server" height="100%" width="100%">
 <table  border="0" cellspacing="0" cellpadding="0" width=100% height="100%">
 <tr><td class="colheader"><span class="maintitledesign">My End of Service Benefit Statement (Projected)</span></td></tr>
<!--    Edit Employee Data Area -->
<asp:PlaceHolder id=EditArea Runat="server" visible="true">

<tr><td width="100%">
       <table width="100%" border="0" class="Partgrayblock">
		     <tr>
			    <td class="mainheadtxt3" colspan="4"><font color="red">DISCLAIMER:</font> This is not an actual end of service benefit statement but a projected approximate benefit statement to give an idea of your end of service benefit based on service end date that you choose below for what-if scenario. Also, note that your projected end of service benefit is calculated based on the last day of  expected month/year of service end date(date of leaving) that you choose below. This tool is meant to give you an idea of your expected end of service benefit based on the date that you have chosen below, based on the your current state of benefits, deductions and leave situations affecting your monthly salary (example: unpaid leave or Leave of absence etc.,). The actual end of service benefit may vary significantly and can only be determined at the time of actual end of service by your HR administrator. 
			    </td>
	         </tr>
	         <tr><td colspan="4"><hr /></td></tr>        
		    <tr>
  		        <td class="mainheadtxt">Expected Service End Date(Month/Year)<font color="red">*</font></td>   
		        <td class="mainheadtxt" ><asp:textbox id=Payroll_Date cssclass="monthPicker" TabIndex=1 Maxlength="20" runat="server"></asp:textbox>		    
 		         		          &nbsp;&nbsp;
                    <asp:ImageButton id=Payroll_Go runat="server" CausesValidation="True" ImageUrl="~/images/buttons/blue_go.png" ToolTip="Go" alt="Go" height="30" width="30" style="vertical-align:middle;"></asp:ImageButton>
                 <td class="validationtxt" colspan="2"><asp:RequiredFieldValidator runat=server ControlToValidate=Payroll_Date  ErrorMessage="Expected Service End date(Month/Year)is Required." /></td>   
		    </tr>
            <tr><td colspan="4"><hr /></td></tr>  
        </table>
          
  </td>
</tr>
<!-- Payslip Print Area -->
<asp:placeholder id="PayStubViewPaycomponents" visible=false runat="server">  
<div id="PrintArea"> 	
<tr id="table1"><td width="100%">
      <table width="100%" border="0" class="Partgrayblock" >
             	    
            <tr><td colspan="5"><span class="maintitledesign">Employee End of Service Benefit Statement(Projected)</span></td></tr>
            </tr>  
            
            <tr>
		       <td class="mainheadtxt3" colspan="5" width="100%">
		        <table width="100%">
		            <tr  class="HomeTitles"><td colspan="4">Employee Service Information</td>
		                <td align="right" class="validationtxt" valign="top"><asp:label id=lblcurrencycode runat="server" ></asp:label></td>
		            </tr>   
		            <tr><td colspan="5">&nbsp;</tr>           
                    <tr>
		                <td class="mainheadtxt" width="20%">Employee Name</td> 		
		                <td class="mainheadtxt" width="20%">Employee ID</td>                 
		                <td class="mainheadtxt" width="20%">Date of Joining</td> 
		                <td class="mainheadtxt" width="20%">Date of Leaving</td> 
		                <td class="mainheadtxt" width="20%">Total Service Years</td> 
		            </tr>
                    <tr>
		                <td class="mainheadtxt"><asp:textbox id="Tab1_EmployeeName" runat="server"  cssclass="textfield" width="200px"/></td>
		                <td class="mainheadtxt"><asp:textbox id="Tab1_EmployeeID" runat="server" cssclass="textfield" width="150px" /></td> 
		                <td class="mainheadtxt"><asp:textbox id="Tab1_DOJ" runat="server" cssclass="textfield"    width="150px" /></td> 
		                <td class="mainheadtxt"><asp:textbox id="Tab1_DateLeft" cssclass="textfield"    width="150px" runat="server" /></td> 
   		                <td class="mainheadtxt"><asp:textbox id="Tab1_ServiceYear" cssclass="textfield"    width="150px"     runat="server" /></td> 
		            </tr>		            
		         </table>
		      </td>
	      </tr>  
	      <tr><td colspan="5">&nbsp;</td></tr>  
           <tr>
		       <td class="mainheadtxt3" colspan="5" width=100%>
		        <table width="100%">
		            <tr class="HomeTitles"><td colspan="5">Monthly Entitlements</td></tr>
   		            <tr><td colspan="5">&nbsp;</tr>           
		            <tr>
		                <td class="mainheadtxt" width="20%">Basic Monthly Salary</td> 
		                <td class="mainheadtxt" width="20%">Monthly Allowances</td> 
		                <td class="mainheadtxt" width="20%">Total Monthly Salary</td> 
		                <td class="mainheadtxt" width="20%">Total Earnings</td>
		                <td class="mainheadtxt" width="20%">&nbsp;</td>
		            </tr>		        
		            <tr>
		                <td class="mainheadtxt"><asp:textbox id="Tab1_BaseSalary" runat="server" cssclass="textfield"      /></td> 
		                <td class="mainheadtxt"><asp:textbox id="Tab1_MonthlyAllowance" cssclass="textfield"     runat="server" /></td> 
		                <td class="mainheadtxt"><asp:textbox id="Tab1_MonthlySalary" cssclass="textfield"   runat="server" /></td>
                        <td class="mainheadtxt"><asp:textbox id="Tab1_MonthlyEarnings" cssclass="textfield"   runat="server" /></td>		                
                        <td class="mainheadtxt">&nbsp;</td>
		            </tr>		        
		        </table> 
		       </td>
		    </tr>
		    <tr><td colspan="5">&nbsp;</td></tr>  
            <tr>
		       <td class="mainheadtxt3" colspan="5" width=100%>
		        <table width="100%">
		            <tr ><td class="HomeTitles" colspan="5">End of Service Benefits</td></tr>
  		            <tr><td colspan="5">&nbsp;</tr>           
		            <tr>
		                <td class="mainheadtxt" width="20%">Gratuity Amount</td> 
		                <td class="mainheadtxt" width="20%">Annual Leave Adj. Payment</td> 
		                <td class="mainheadtxt" width="20%">Ex-Gratia Payment</td>
                        <td class="mainheadtxt" width="20%">Total EOS Benefit</td>
                        <td class="mainheadtxt" width="20%">&nbsp;</td>
		            </tr>		        
		            <tr>
		                <td class="mainheadtxt"><asp:textbox id="Tab1_GratuityAmount"  cssclass="textfield"      runat="server" /></td> 
		                <td class="mainheadtxt"><asp:textbox id="Tab1_ALeaveAdjPayment" cssclass="textfield"     runat="server" /></td> 
		                <td class="mainheadtxt"><asp:textbox id="Tab1_ExgratiaPayment" cssclass="textfield"     runat="server" /></td> 
		                <td class="mainheadtxt"><asp:textbox id="Tab1_TotalEOSBenefit" cssclass="textfield"    runat="server" /></td> 		                
		                <td class="mainheadtxt">&nbsp;</td>
		            </tr>		        
		        </table> 
		       </td>
		    </tr>
		    <tr><td colspan="4">&nbsp;</td></tr> 		    
            <tr>
		       <td class="mainheadtxt3" colspan="5">
		        <table width="100%">
		            <tr class="HomeTitles"><td colspan="5">Monthly Deductions</td></tr>
  		            <tr><td colspan="5">&nbsp;</tr>           
		            <tr>
		                <td class="mainheadtxt" width="20%">Standard Deductions</td> 
		                <td class="mainheadtxt" width="20%">Advance Payment Recovery</td> 
		                <td class="mainheadtxt" width="20%">Unpaid Leave Deduction</td> 
		                <td class="mainheadtxt" width="20%">Adhoc Deductions</td>
		                <td class="mainheadtxt" width="20%">Total Deductions</td>
		            </tr>		        
		            <tr>
		                <td class="mainheadtxt"><asp:textbox id="Tab1_StandardDeductions" cssclass="textfield"    runat="server" /></td> 
		                <td class="mainheadtxt"><asp:textbox id="Tab1_AdvanceRecoveryAmount" cssclass="textfield"    runat="server" /></td> 
		                <td class="mainheadtxt"><asp:textbox id="Tab1_LOPDeductions" cssclass="textfield"   runat="server" /></td> 
		                <td class="mainheadtxt"><asp:textbox id="Tab1_AdhocDeductions" cssclass="textfield"    runat="server" /></td> 
		                <td class="mainheadtxt"><asp:textbox id="Tab1_TotalDeductions" cssclass="textfield"    runat="server" /></td> 
		            </tr>		        
		        </table> 
		       </td>
		    </tr>
		    <tr><td colspan="5">&nbsp;</td></tr> 
            <tr>
		       <td class="mainheadtxt3" colspan="4">
		        <table width="100%">
		            <tr class="HomeTitles"><td colspan="5">Total Net EOS Benefits</td></tr>
		            <tr><td colspan="5">&nbsp;</tr>           
		            <tr>
		                <td class="mainheadtxt" colspan="5"><center>Total Net End of Service Payment(Approximate)</center></td> 
		                
		            </tr>		        
		            <tr>
		                <td class="mainheadtxt" colspan="5"><center><asp:textbox id="Tab1_TotalNetPay" cssclass="textfield"    width="200px"  runat="server"/></center></td> 
		                
		            </tr>		        
		        </table> 
		       </td>
		    </tr>
   		     <tr><td colspan="5">&nbsp;</td></tr>  
	     </table>
   </td>
</tr>
</div> 
</asp:placeholder>
<!-- End of Print Area -->
<asp:placeholder id="printbutton" runat="server" visible=false>
    <tr><td width="100%" valign="middle">
    <center><input type="button" id="printbtn" value="Print Pay Slip"  OnClick="getPrint('table1')";></center>
    </td>
    <!-- Commented out due to the issue in saving PDF : Check later
        <td><asp:button id=SavePDF runat="server" BorderStyle="Ridge"  CssClass="button" BorderWidth="1px" Text="Save As PDF"></asp:button></td>
    -->
    </tr>
</asp:placeholder>   
</asp:placeholder>            
<tr class="PartBrown" >
   <td width="100%" align=center><asp:label id="message" runat="server" visible=false /></td>			
</tr> 			
</table>
									
</master:content>





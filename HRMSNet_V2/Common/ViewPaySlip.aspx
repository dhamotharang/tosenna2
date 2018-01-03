<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewPaySlip.aspx.cs" Inherits="SchoolNet.ViewPaySlip" EnableEventValidation="false"%>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
 <master:content id="formData" runat="server" height="100%" width="100%">
 <table  border="0" cellspacing="0" cellpadding="0" width=100% height="100%">
<!--    Edit Employee Data Area -->
<asp:PlaceHolder id=EditArea Runat="server" visible="true">

<tr><td width="100%">
    <fieldset><legend>View Pay Slip</legend>
       <table width="100%" border="0" class="Partgrayblock">
        
            <tr><td colspan="4">&nbsp;</td></tr>
		    <tr>
  		        <td class="mainheadtxt">Select Month/Year<font color="red">*</font></td>   
		        <td class="mainheadtxt" ><asp:textbox id=Payroll_Date cssclass="monthPicker1" TabIndex=1 Maxlength="20" runat="server"></asp:textbox>		    
 		         		          &nbsp;&nbsp;<asp:button id=Payroll_Go runat="server" BorderStyle="Ridge" CausesValidation="True" CssClass="button" BorderWidth="1px" Text="Go"></asp:button></td> 		         
                <td class="validationtxt" colspan="3"><asp:RequiredFieldValidator runat=server ControlToValidate=Payroll_Date  ErrorMessage="Month-Year is Required." /></td>   
		    </tr>
        </table>
    </fieldset>        
  </td>
</tr>
<!-- Payslip Print Area -->
<asp:placeholder id="PayStubViewPaycomponents" visible=false runat="server">  
<div id="PrintArea"> 	
<tr id="table1"><td width="100%">
      <table width="100%" border="1" class="Partgrayblock" >
        	    
            <tr bgcolor="lightgray"><td colspan="4" class="mainheadtxt4" align="center">Employee Monthly Pay Slip</td></tr>  
            <tr class="noBorder">
               <td style="vertical-align:middle"   colspan="2"  align="left">
  <asp:Image ID="CustomerLogo" runat="server" Visible = "false" width="135" height="75"/>

                </td>
               <td colspan="2"  class="mainheadtxt" align="left">
                 <asp:label id="lblCompanyName" runat="server" /><br />
                 <asp:label id="lblDivisionName" runat="server" /><asp:label id="lblLocation" runat="server" />
              </td>
            </tr>         
              
            <tr class="noBorder">
                 <td colspan="3" class="mainheadtxt4" align="Center"><asp:label id="lblPaySlipPeriod" runat="server" /></td>
                 <td align=right class="mainheadtxt"><asp:label id="lblCurrencyName" runat="server" /></td>
            </tr>   
            <tr>
		        <td class="mainheadtxt">Employee Name</td> 
                <td class="mainheadtxt"><asp:label id="lblEmployeeName" runat="server" /></td>		        
		        <td class="mainheadtxt">Designation</td>  
		        <td class="mainheadtxt"><asp:label id="lblDesignation" runat="server" /></td>                           
		    </tr>
		     <tr>
		        <td class="mainheadtxt">Employee No</td> 
                <td class="mainheadtxt"><asp:label id="lblEmployeeNo" runat="server" /></td>		        
		        <td class="mainheadtxt">Department</td>  
		        <td class="mainheadtxt"><asp:label id="lblDepartmentName" runat="server" /></td>                           
		    </tr>
		     <tr>
		        <td class="mainheadtxt">Location</td> 
                <td class="mainheadtxt"><asp:label id="lblLocationName" runat="server" /></td>		        
		        <td class="mainheadtxt">No of Days in the Pay Cycle/LOP</td>  
		        <td class="mainheadtxt"><asp:label id="lblPayCycleDays" runat="server" />/<asp:label id="lblLOPDays" runat="server" /></td>                           
		    </tr>
		     <tr>
		        <td class="mainheadtxt">BankAccount</td> 
                <td class="mainheadtxt"><asp:label id="lblBankAccount" runat="server" /></td>		        
		        <td class="mainheadtxt">Bank Name</td>  
		        <td class="mainheadtxt"><asp:label id="lblBankName" runat="server" /></td>                           
		    </tr>
		    <tr>
		        <td colspan="2" valign="top"><table id="BenefitTableContent"   border="0" width="100%" runat="server"></table></td> 
   		        <td colspan="2" valign="top"><table id="DeductionTableContent" border="0" width="100%" runat="server"></table></td> 
		    </tr>
           
		    <tr bgcolor="lightgray">
		       <td class="mainheadtxt3">Total Earnings</td> 
		       <td class="mainheadtxt3" align="right"><asp:label id="lblTotalEarnings" runat="server" /></td>
               <td class="mainheadtxt3">Total Deductions</td>
               <td class="mainheadtxt3" align="right"><asp:label id="lblTotalDeductions" runat="server" /></td>
            </tr>
             <tr>
		       <td colspan="2"></td>
               <td class="mainheadtxt3">Net Pay</td>		        		    
   		       <td class="mainheadtxt3" align="right"><asp:label id="lblNetPay" runat="server" /></td>		        		    
   		     </tr>
   		       <tr>
		       <td colspan="4">
		        <table border="0" width="100%">
		           <tr>
		               <td colspan="2" class="mainheadtxt">Note:</td>		         
		           </tr>
		           <tr>
		            <td colspan="2" class="mainheadtxt"><asp:label id="lblPayrollNote" runat="server" /></td>
		          
		          
		           </tr>
		         
		          </table>	
		       
		       </td>             		    
   		     </tr>
   		      <tr class="noBorder">
                 <td colspan="3" class="paystubfooter" align="Left">System generated electronic pay slip and requires no signature.</td>
                 <td class="paystubfooter" align="right">Generated on &nbsp;<asp:label id="lblPayrollGeneratedDate" runat="server" /></td>
            </tr>                    
	     </table>
   </td>
</tr>
</div> 
</asp:placeholder>
<!-- End of Print Area -->
<asp:placeholder id="printbutton" runat="server" visible=false>
    <tr>
     <td valign="middle">
    <center><input type="button" id="printbtn" value="Print Pay Slip"  OnClick="getPrint('table1')";>
            &nbsp;&nbsp;<asp:button id=SavePDF runat="server" BorderStyle="Ridge"  CssClass="button" BorderWidth="1px" Text="Save As PDF"></asp:button>
    </center>
    </td>
          
    
    </tr>
</asp:placeholder>   
</asp:placeholder>            
<tr class="PartBrown" >
   <td width="100%" align=center><asp:label id="message" runat="server" visible=false /></td>			
</tr> 			
</table>
									
</master:content>




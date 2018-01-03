<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PaySlipPreview.aspx.cs" Inherits="SchoolNet.PaySlipPreview" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
<master:content id="formData" runat="server" height="100%" width="100%">
<table  border="0" cellspacing="0" cellpadding="0" width=100% height="100%">
<!-- Payslip Print Area -->
<asp:placeholder id="PayStubViewPaycomponents" visible=true runat="server">  
<div id="PrintArea"> 	
<tr><td width="100%">
      <table width="100%" border="0" class="Partgrayblock">
            <tr><td colspan="4"><hr /></td></tr>  	    
            <tr><td colspan="3" class="mainheadtxt4" align="center">Employee Pay Slip</td>
                <td class="mainheadtxt4" align="right"></td>
            </tr>  
            <tr bgcolor="lightgray"><td colspan="4"><hr /></td></tr>  
            <tr>
               <td style="vertical-align:middle" colspan="2" rowspan="4" align="left"><IMG id="CustomerLogo" height="51" src="~/images/Customer_Logo.png" runat="server" alt= "AON Middle East" width="96" style="vertical-align:bottom;"></td>
               <td colspan="2" class="mainheadtxt" align="center"><asp:label id="lblCompanyName" runat="server" /></td>
            </tr>                             
            <tr><td colspan="4" class="mainheadtxt" align="center"><asp:label id="lblDivisionName" runat="server" /><asp:label id="lblLocation" runat="server" /></td></tr>
            <tr><td colspan="4" class="mainheadtxt" align="center"><asp:label id="lblPaySlipPeriod" runat="server" /></td></tr>
            <tr><td colspan="4">&nbsp;</td></tr>  	    
            <tr><td colspan="4" align=right class="mainheadtxt"><asp:label id="lblCurrencyName" runat="server" /></td></tr>  	    
            
            <tr bgcolor="lightgray"><td colspan="4"><hr /></td></tr>  
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
             <tr><td colspan="4">&nbsp;</td></tr>                   
		    <tr>
		        <td colspan="2" valign="top"><table id="BenefitTableContent"  border="0" width="100%" runat="server"></table></td> 
   		        <td colspan="2" valign="top"><table id="DeductionTableContent"  border="0" width="100%" runat="server"></table></td> 
		    </tr>
		    <tr><td colspan="4">&nbsp;</td></tr>          
		    <tr bgcolor="lightgray">
		       <td class="mainheadtxt3">Total Earnings</td> 
		       <td class="mainheadtxt3" align="right"><asp:label id="lblTotalEarnings" runat="server" /></td>
               <td class="mainheadtxt3">Total Deductions</td>
               <td class="mainheadtxt3" align="right"><asp:label id="lblTotalDeductions" runat="server" /></td>
            </tr>
             <tr>
		       <td colspan="2">&nbsp;</td>
               <td class="mainheadtxt3" bgcolor="lightgray">Net Pay</td>		        		    
   		       <td class="mainheadtxt3" align="right" bgcolor="lightgray"><asp:label id="lblNetPay" runat="server" /></td>		        		    
   		     </tr>
   		      <tr><td colspan="4"><hr /></td></tr>  
   		      <tr>
		       <td colspan="4">
		        <table border="0" width="100%">
		           <tr bgcolor="lightgray">
		               <td colspan="2" class="mainheadtxt4">Information</td>		         
		           </tr>
		           <tr>
		            <td colspan="2" class="mainheadtxt"><asp:label id="lblPayrollNote" runat="server" /></td>
		           </tr>
		          </table>	
		       
		       </td>             		    
   		     </tr>
   		     <tr><td colspan="4"><hr /></td></tr>  
             <tr>
                 <td colspan="4" class="mainheadtxt4" align="right"><small>System Generated and requires no signature.</small></td>
            </tr>                    
	     </table>
   </td>
</tr>
</div> 
</asp:placeholder>
<!-- End of Print Area -->


</table>								
</master:content>
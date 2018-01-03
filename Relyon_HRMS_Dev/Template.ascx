<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
<%@ Control Language="c#" AutoEventWireup="true" Inherits="SchoolNet.Template" CodeFile="Template.ascx.cs" %>
<!DOCTYPE html> 
<HTML>
  <HEAD runat="server"> 
		<title>
			<master:contentplaceholder id="pageTitle" runat=server>Relyon HRMS </master:contentplaceholder>
		</title>
		<meta http-equiv="X-UA-Compatible" content="IE=edge" >
  		<meta content="Microsoft FrontPage 5.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<meta name="description"  content="HRMS" />
        				
		<link rel="stylesheet" type="text/css" href="~/CSS/CommonStyles.css" id="CommonCss" />
		<link rel="stylesheet" media="all" href="~/CSS/stylesheet.css" />
				
		<!--  Includes for Jquery date control -->
		<link type="text/css" href="~/CSS/smoothness/jquery-ui-1.7.1.custom.css" rel="stylesheet" />
		<style type="text/css">.ui-datepicker { font-size: 11px; margin-left:10px}</style>

	   <script language="javascript" src='<%= this.ResolveClientUrl("~/_scripts/jquery-1.3.2.min.js") %>' type="text/javascript"></script>
	   <script language="javascript" src='<%= this.ResolveClientUrl("~/_scripts/jquery-ui-1.7.1.custom.min.js") %>' type="text/javascript"></script>
	   <script language="javascript" src='<%= this.ResolveClientUrl("~/_scripts/PrintPage.js") %>' type="text/javascript"></script>
               
        <SCRIPT type="text/javascript">
        $(function() {
        
        $('#Tab8_FileName').bind('change', function() {

          //this.files[0].size gets the size of your file.
          if (this.files[0].size/1024/1024 > 4)
          {
             alert('File size can not exceed more than 4 MB. Please check the file size.'); 
             $('#Doc_Upload').attr("disabled", "true");
             return true; //causes the client side script to run.
          }
          else
          {
           //alert('File size can is less than 4 MB. Please check the file size.'); 
            $('#Doc_Upload').removeAttr('disabled');
             return true; //causes the client side script to run.
          }
          });

        
         $("#Tab1_DateCompleted").datepicker({ dateFormat: "dd/mm/yy" });
         $("#Tab1_DateCompleted").datepicker(); 
         $("#Tab1_DateCompleted").datepicker({beforeShowDay: $.datepicker.noWeekends});
         $("#Tab1_DOB").datepicker({ dateFormat: "dd/mm/yy" });
         $("#Tab1_DOB").datepicker(); 
         $("#Tab1_BVisaIssueDate").datepicker({ dateFormat: "dd/mm/yy" });
         $("#Tab1_BVisaIssueDate").datepicker(); 
         $("#Tab1_BVisaExpiryDate").datepicker({ dateFormat: "dd/mm/yy" });
         $("#Tab1_BVisaExpiryDate").datepicker(); 
         
         $("#Tab1_VisaIssueDate").datepicker({ dateFormat: "dd/mm/yy" });
         $("#Tab1_VisaIssueDate").datepicker(); 
         $("#Tab1_VisaExpiryDate").datepicker({ dateFormat: "dd/mm/yy" });
         $("#Tab1_VisaExpiryDate").datepicker(); 
         $("#Tab1_PassportIssueDate").datepicker({ dateFormat: "dd/mm/yy" });
         $("#Tab1_PassportIssueDate").datepicker(); 
         $("#Tab1_PassportExpiryDate").datepicker({ dateFormat: "dd/mm/yy" });
         $("#Tab1_PassportExpiryDate").datepicker();  
          
         $("#Tab1_LaborCardIssueDate").datepicker({ dateFormat: "dd/mm/yy" });
     
         $("#Tab1_LaborCardExpiryDate").datepicker({ dateFormat: "dd/mm/yy" });

         $("#Tab3_DOB").datepicker({ dateFormat: "dd/mm/yy" });
         $("#Tab3_DOB").datepicker(); 
         $("#Tab3_VisaIssueDate").datepicker({ dateFormat: "dd/mm/yy" });
         $("#Tab3_VisaIssueDate").datepicker(); 
         $("#Tab3_VisaExpiryDate").datepicker({ dateFormat: "dd/mm/yy" });
         $("#Tab3_VisaExpiryDate").datepicker(); 
         $("#Tab3_PassportIssueDate").datepicker({ dateFormat: "dd/mm/yy" });
         $("#Tab3_PassportIssueDate").datepicker(); 
         $("#Tab3_PassportExpiryDate").datepicker({ dateFormat: "dd/mm/yy" });
         $("#Tab3_PassportExpiryDate").datepicker();   
         $("#Tab5_HireDate").datepicker({ dateFormat: "dd/mm/yy" });
         $("#Tab5_HireDate").datepicker(); 
         $("#Tab5_NewPositionStartDate").datepicker({ dateFormat: "dd/mm/yy" });
         $("#Tab5_NewPositionStartDate").datepicker(); 
         $("#Tab5_CRPositionEndDate").datepicker({ dateFormat: "dd/mm/yy" });
         $("#Tab5_CRPositionEndDate").datepicker(); 
         $("#Tab5_DateLeft").datepicker({ dateFormat: "dd/mm/yy" });
         $("#Tab5_DateLeft").datepicker(); 
         $("#Tab5_ResignedDate").datepicker({ dateFormat: "dd/mm/yy" });
         $("#Tab5_ResignedDate").datepicker();          
         $("#Tab1_HireDate").datepicker({ dateFormat: "dd/mm/yy" });
         $("#Tab1_HireDate").datepicker(); 
         $("#Tab5_ProbationEndDate").datepicker({ dateFormat: "dd/mm/yy" });
         $("#Tab5_ProbationEndDate").datepicker(); 
         
         
         $("#Tab1_Date").datepicker({ dateFormat: "dd/mm/yy" });
         $("#Tab1_Date").datepicker({beforeShowDay: $.datepicker.noWeekends});                          
         
         
                     
         $("#Tab1_LastAssessed").datepicker({ dateFormat: "dd/mm/yy" });
         $("#Tab1_LastAssessed").datepicker(); 
         $("#Tab1_IssuedDate").datepicker({ dateFormat: "dd/mm/yy" });
         $("#Tab1_IssuedDate").datepicker();     
         $("#Tab1_ExpiryDate").datepicker({ dateFormat: "dd/mm/yy" });
         $("#Tab1_ExpiryDate").datepicker();                      
         $("#Tab1_DateDegCompleted").datepicker({ dateFormat: "dd/mm/yy" });
         $("#Tab1_DateDegCompleted").datepicker(); 
         $("#Tab1_DateJoined").datepicker({ dateFormat: "dd/mm/yy" });
         $("#Tab1_DateJoined").datepicker(); 
         $("#Tab1_DateCompleted").datepicker({ dateFormat: "dd/mm/yy" });
         $("#Tab1_DateCompleted").datepicker(); 
         $("#Tab1_StartDate").datepicker({ dateFormat: "dd/mm/yy" });
         $("#Tab1_StartDate").datepicker();             
         $("#Tab1_EndDate").datepicker({ dateFormat: "dd/mm/yy" });
         $("#Tab1_EndDate").datepicker();  
        
        
         var dateToday = new Date();
       $(".monthPicker").datepicker({ 
        dateFormat: 'mm-yy',
        changeMonth: true,
        changeYear: true,
        showButtonPanel: true,
        minDate: dateToday,
        onClose: function(dateText, inst) {  
            var month = $("#ui-datepicker-div .ui-datepicker-month :selected").val(); 
            var year = $("#ui-datepicker-div .ui-datepicker-year :selected").val(); 
            $(this).val($.datepicker.formatDate('yy-mm', new Date(year, month, 1)));
        }
    });
 
    $(".monthPicker").focus(function () {
        $(".ui-datepicker-calendar").hide();
        $("#ui-datepicker-div").position({
            my: "center top",
            at: "center bottom",
            of: $(this)
        });    
    });
   // Pay Stub date    
        $(".monthPicker1").datepicker({ 
        dateFormat: 'mm-yy',
        changeMonth: true,
        changeYear: true,
        showButtonPanel: true,
        maxDate: dateToday,
        onClose: function(dateText, inst) {  
            var month = $("#ui-datepicker-div .ui-datepicker-month :selected").val(); 
            var year = $("#ui-datepicker-div .ui-datepicker-year :selected").val(); 
            $(this).val($.datepicker.formatDate('yy-mm', new Date(year, month, 1)));
        }
    });
 
    $(".monthPicker1").focus(function () {
        $(".ui-datepicker-calendar").hide();
        $("#ui-datepicker-div").position({
            my: "center top",
            at: "center bottom",
            of: $(this)
        });    
    });
 
    // Payroll-Only Current Month    
        $(".monthPicker2").datepicker({ 
        dateFormat: 'mm-yy',
        changeMonth: true,
        changeYear: true,
        showButtonPanel: true,
        minDate: dateToday,        
        maxDate: dateToday,
        onClose: function(dateText, inst) {  
            var month = $("#ui-datepicker-div .ui-datepicker-month :selected").val(); 
            var year = $("#ui-datepicker-div .ui-datepicker-year :selected").val(); 
            $(this).val($.datepicker.formatDate('yy-mm', new Date(year, month, 1)));
        }
    });
 
    $(".monthPicker2").focus(function () {
        $(".ui-datepicker-calendar").hide();
        $("#ui-datepicker-div").position({
            my: "center top",
            at: "center bottom",
            of: $(this)
        });    
    });
   // End of MonthPicker2
 
 
   // Year Only
   $('.date-picker-year').datepicker({
        changeYear: true,
        showButtonPanel: true,
        maxDate: dateToday,
        onClose: function(dateText, inst) { 
           //  var month = $("#ui-datepicker-div .ui-datepicker-month :selected").val(); 
            var year = $("#ui-datepicker-div .ui-datepicker-year :selected").val(); 
            $(this).val($.datepicker.formatDate('yy', new Date(year, 1)));
          //  var year = $("#ui-datepicker-div .ui-datepicker-year :selected").val();
           // $(this).datepicker('setDate', new Date(year, 1));
        }
    });
  $(".date-picker-year").focus(function () {
        $(".ui-datepicker-calendar").hide();    
    });    
       
    });	
   
      
	   </SCRIPT>
		   
  <!-- End of date picker -->
  <Script language="javascript">
                
		        function bookmark()
		        {
			        window.external.AddFavorite("http://www.google.com/","google.Com")
        		
		        }
		        function Redirect()
		        {
			        window.document.location.href="http://www.google.com"
        		
		        }
        	  
      function Openpopup(popurl) 
      {
       winpops = window.open(popurl,"","width=800, height=600, left=45, top=15, scrollbars=yes, menubar=no,resizable=no,directories=no,location=no")
      }
  	  
        function basicPopup() 
        {
            popupWindow = window.open("PaySlipPreview.aspx", 'popUpWindow', 'height=300,width=600,left=100,top=30,resizable=No,scrollbars=No,toolbar=no,menubar=no,location=no,directories=no, status=No');
        }

  </SCRIPT>
            
    
 </HEAD>


<BODY>
        
  
   <FORM id="form" method="post" runat="server" enctype="multipart/form-data"> 
   	
       
  		<!-- Header / Company Logo -->
			<table width="100%" height="10%" cellspacing="0" cellpadding="0" border="0" bgcolor=White>
				<tr>
					<td style="vertical-align:middle" width="30%" >&nbsp;&nbsp;&nbsp;&nbsp;<IMG height="80" src="~/images/Arklogo2.jpg" runat="server" alt= "Ark HRMS" width="300" style="vertical-align:bottom;"></td>
					<td style="vertical-align:middle" width="35%"><center><IMG id="IMG1" height="51" src="~/images/Customer_Logo.png" runat="server" alt= "Customer Logo" width="96" style="vertical-align:bottom;"></center></td>
					<td style="vertical-align:middle" width="30%" align="right"><p style="text-align: right;"><asp:Label ID="UserName"  Visible=true Runat=server /></p></td>
					<td style="vertical-align:middle" width="5%">&nbsp;</td>
					
				</tr>
					 			
	        </table>  
		
	         
	   <!-- Main Menu Navigation -->
	   <!-- Pure CSS3 Multi Level Drop Down Navigation Menu by Bloggermint.com -->
	   <table width="100%" height="10%" cellspacing="0" cellpadding="0" border="0">
	   <asp:PlaceHolder ID="AdminMenu" runat="server" Visible=false>
	   <tr bgcolor=#3C4042>
	    <td colspan="3" valign="top">
        
                 <div id="nav">
                    <ul>
                    <li><a href="~/admin/Dashboard.aspx" runat="server">Dashboard</a></li>
                    <li><a href="#" runat="server">Employee Management</a>
	                    <ul>
	                     <li><a href="~/admin/ManageEmployee.aspx" runat="server">Manage Employee Information</a></li>	 
	                     <li><a id="A11" href="~/admin/AddEmployee.aspx" runat="server">Add Employee Profile</a></li>
	                     <li><a id="A31" href="~/admin/DeactivateEmployee.aspx" runat="server">Deactivate Employee Profile</a></li>
	                     <li><a id="A20" href="~/admin/ReactivateEmployee.aspx" runat="server">Reactivate Employee Profile</a></li>
	                     <li><a id="A27" runat="server" visible=true>Employee data Reports</a>
                             <ul>
                                    <li><a id="A46" href="~/admin/EmployeeDataExport.aspx" runat="server">Employees Main Data Export</a></li>                                   
                                    <li><a id="A34" href="~/admin/MainExpiryAlert.aspx" runat="server">Key Data Expiry Alert Enquiry</a></li>
                                    <li><a id="A58" href="~/admin/MissingDataReport.aspx" runat="server">Key Data Missing Alert Enquiry </a></li>
                                    <li><a id="A41" href="~/admin/EmployeeServiceYearsReport.aspx" runat="server">Employee Service Years Report</a></li>                                                                                                                                                                              
                                    <li><a id="A66" href="~/admin/CurrentYearNewHiresReport.aspx" runat="server">Current Year New Hires Report</a></li>
                                    <li><a id="A67" href="~/admin/CurrentYearEmployeeAttritionReport.aspx" runat="server">Current Year Attrition Report</a></li>
                                    
                             </ul> 
                          </li>
                          <li><a id="A59" href="~/Clerical/ManageGeneralTrans.aspx" runat="server" visible=true>Key Data Import & Fast Data Entry</a></li>                    
	                    </ul>
                    </li>
                    <li><a href="#" runat="server">Leave Management</a>
                        <ul>
                            <li><a href="~/admin/LeaveList.aspx" runat="server">Employees Leave List</a></li>
	                        <li><a href="~/admin/ManageLeave.aspx" runat="server">Manage Employee Leave</a></li>
	                        <li><a href="~/admin/ManageLeaveEntitlement.aspx" runat="server">Assign Leave Entitlement</a></li>
                            <li><a id="A47" runat="server" visible=true>Leave Data Reports</a>
                             <ul>
                                    <li><a id="A50" href="~/admin/EmployeeLeaveReport.aspx" runat="server">Employee Leave Report</a></li>
                                    <li><a id="A52" href="~/admin/AnnualLeaveBalance.aspx" runat="server">Annual Leave Balance Report</a></li>                             
                                    <li><a id="A48" href="~/admin/MissingLeaveEntitlement.aspx" runat="server">Missing Annual Leave Entitlements</a></li>
                                    <li><a id="A49" href="~/admin/MissingLeaveApprovalSetting.aspx" runat="server">Missing Leave Approval Settings</a></li>                                    
                                    <li><a id="A42" href="~/Payroll/CurrentPayrollMonthUnPaidLeaveReport.aspx" runat="server">Current Payroll Unpaid Leave Report</a></li>
                             </ul> 
                          </li>               	                        
	                    </ul>
                    </li>
                    <li><a href="#" runat="server">Benefits Management</a>
                        <ul>
                                <li><a  href="~/Admin/ManageBenefit.aspx" runat="server">Manage Employee Benefits</a></li>
                                <li><a id="A7"  href="~/Payroll/ManageEOS.aspx" runat="server" visible=true>End of Service Process</a></li>
                                <li><a id="A53" runat="server" visible=true>Benefits Data Reports</a>
                                <ul>
                                    
                                    <li><a id="A55" href="~/Admin/EmployeeBenefitDataReport.aspx" runat="server">Employees Payroll Benefit  Report</a></li>
                                    <li><a id="A39" href="~/Admin/EmployeeNonpayrollBenefitDataReport.aspx" runat="server">Employee NonPayroll Benefit Report</a></li>
                                    <li><a id="A40" href="~/Admin/EmployeeNonpayrollIncentivesReport.aspx" runat="server">Employees Incentives Data Report</a></li>                                                                        
                                    <li><a id="A57" href="~/Admin/MissingBenefitData.aspx" runat="server">Missing Payroll Benefit Report</a></li>
                                    <li><a id="A44" href="~/Admin/EmployeeBenefitHistoryReport.aspx" runat="server">Employee Benefit History Report</a></li>
                                    <li><a id="A60" href="~/Admin/EmployeeBenefitDataChangeAuditReport.aspx" runat="server">Benefit Data Change Audit Report</a></li>                                                                        
                                    
                                </ul> 
                                
                        </ul>                                          
                    </li>
                   
                    <li><a id="A16" href="#"  runat="server">Manage Transaction</a>
                        <ul>
                                <li><a id="A24"  href="~/Clerical/EnterDailyFnTrans.aspx" runat="server" visible=false>Financial Transactions</a></li>
                                <li><a id="A26"  href="~/Clerical/ManageGeneralTrans.aspx" runat="server" visible=true>General Transactions</a></li>
                        </ul>          
                    </li>
                    
                    <li><a  href="~/Common/ManageRequests.aspx#"  runat="server">Manage Requests</a></li>
                    
                    <li><a href="#" runat="server">HR Administration</a>
	                    <ul>
	                    <li><a href="#">Employee</a>
                            <ul>
                                <li><a href="~/admin/Division.aspx" runat="server">Business Unit</a></li>
                                <li><a id="A1" href="~/admin/Department.aspx" runat="server">Department</a></li>
                                <li><a href="~/admin/Designation.aspx" runat="server">Designation</a></li>                                
                                <li><a href="~/admin/EmpCategory.aspx" runat="server">Employee Category</a></li>
                                <li><a href="~/admin/EmployeeStatus.aspx" runat="server">Employment Status</a></li>
                                <li><a href="~/admin/Education.aspx" runat="server">Education</a></li>
                                <li><a href="~/admin/Bank.aspx" runat="server">Bank</a></li>                              
                                
                             </ul>    
	                    </li>
	                     <li><a href="#">Leave</a>
                           <ul>
                                <li><a href="~/admin/LeaveType.aspx" runat="server">Define Leave Type</a></li>
                                <li><a href="~/admin/LeavePeriod.aspx" runat="server">Define Leave Period</a></li>
                                <li><a href="~/admin/WorkWeek.aspx" runat="server">Define Work Week</a></li>
                                <li><a href="~/admin/Holidays.aspx" runat="server">Define Holidays</a></li>
                                
                           </ul>   
	                    </li>
	                    <li><a href="#">Benefit</a>
                            <ul>
                                <li><a href="~/admin/PayComponents.aspx" runat="server">Pay & Allowance Components</a></li>
                                <li><a href="~/admin/Deductions.aspx" runat="server">Deduction Components</a></li>
                                <li><a href="~/admin/Incentives.aspx" runat="server">Incentive Components</a></li> 
                                <li><a href="~/admin/NonPayrollBenefits.aspx" runat="server">NonPayroll Benefits Components</a></li>                                                                
                                <li><a href="~/admin/GratuityRule.aspx" runat="server">Define EOS Gratuity Rule</a></li>
                         </ul>                                 
                         </li>
                         
                        <li><a href="#">Employee Resources</a>
                           <ul>
                                <li><a href="~/admin/ManageEmpResources.aspx" runat="server">Employee Resources</a></li>
                               
                           </ul>   
	                    </li>
	                    <li><a href="~/admin/UserAccounts.aspx" runat="server">Manage User Accounts</a>
                        </ul>

                        </li>
                        <li><a id="A65" href="~/admin/ChangePassword_HR.aspx" runat="server">Change Password</a> </li>
	                   <li><a href="~/Logout.aspx" runat="server">Sign Out</a> </li>                           
	                    	                    
                    </ul>
                    
	       </div>
	   </td>
	   </tr>   
	   </asp:PlaceHolder>
	   <!-- Payroll Administrator menu -->
	   <asp:PlaceHolder ID="PayrollMenu" runat="server" Visible=false>
	   <tr bgcolor=#3C4042>
	    <td colspan="3" valign="top">
        
                 <div id="nav">
                    <ul>                 
                           <li><a id="A38" href="~/Payroll/payrollDashboard.aspx" runat="server">Payroll Dashboard</a></li>
                            
                         <li>
                            <a id="A12" href="#" runat="server">Prepare</a>
                             <ul>
                                <li><a id="A9"   href="~/Payroll/ManageDeductions.aspx" runat="server">Manage Reoccuring Deductions</a></li>
                                <li><a id="A28"  href="~/Clerical/EnterDailyFnTrans.aspx" runat="server">Manage Adhoc Payroll Transactions</a></li>                                                       
                                <li><a id="A29"  href="~/Payroll/ManageEOS.aspx" runat="server">End of Service List</a></li>                                                                                       
                            </ul>
                         </li>  
                         <li>
                            <a id="A14" href="#" runat="server">Process</a>
                             <ul>
                                <li><a id="A4"   href="~/Payroll/ProcessMonthlyPayroll.aspx" runat="server">Process Monthly Payroll (Batch)</a></li> 
                                <li><a id="A8"   href="~/Payroll/ProcessMonthlyEOSPayroll.aspx" runat="server">Process End of Service (Batch)</a></li> 
                            </ul>
                         </li>  
                                                  
                         <li>
                            <a id="A17" href="#" runat="server">Preview</a>
                             <ul>
                                <li><a id="A21"  href="~/Payroll/ManagePayroll.aspx" runat="server">Review/Reconcile Employee Payroll</a></li>
                                <li><a id="A19"  href="~/Payroll/ManageEOS.aspx" runat="server">Review/Reconcile End of Service</a></li>  
                                <li><a id="A22"  href="~/Payroll/PreviewMonthlyPayroll.aspx" runat="server">Preview Monthly Payroll</a></li>                                                                                                                                                                                                                     
                            </ul>
                         </li>  
                         <li>
                            <a id="A18" href="#" runat="server">Post</a>
                             <ul>
                                <li><a id="A23"  href="~/Payroll/RunMonthlyPayroll.aspx" runat="server">Finalize Monthly Payroll</a></li>
                                <li><a id="A13"  href="~/Payroll/MonthlyWPSPayroll.aspx" runat="server">Extract Monthly WPS</a></li>                                
                            </ul>
                         </li>  
                         
                         <li>
                            <a id="A25" href="#" runat="server">Reports</a>
                             <ul>
                               <li><a id="A15"  href="~/Payroll/ViewPayrollHistory.aspx" runat="server" visible=true>View Payroll History</a></li>                                                                
                                <li><a id="A45" href="~/Payroll/MonthlyPayrollSummary.aspx" runat="server">Monthly  Payroll Summary</a></li>
                                <li><a id="A63" href="~/Payroll/MonthlyPayrollDetailReport.aspx" runat="server">Monthly Payroll Detail Report</a></li>
                                <li><a id="A61" href="~/Payroll/MonthlyPaymentCycleReport.aspx" runat="server">Monthly Payment Cycle Report</a></li>
                                <li><a id="A62" href="~/Payroll/FinancialAccrualSummaryReport.aspx" runat="server">Financial Accrual Report(Annual)</a></li>
                                <li><a id="A51" href="~/Payroll/YTDPayrollSummary.aspx" runat="server">YTD Payroll Summary</a></li>
                                <li><a id="A54" href="~/Payroll/MonthlyProjectedPayrollFundReport.aspx" runat="server">Projected Monthly Payroll Report</a></li>
                                <li><a id="A56" href="~/Payroll/CurrentPayrollMonthUnPaidLeaveReport.aspx" runat="server">Current Payroll Unpaid Leave Report</a></li>           
                                <li><a id="A30" href="~/Payroll/StandardMonthlyDeductionsReport.aspx" runat="server">Standard Monthly Deduction Report</a></li>                                                                                   
                                
                            </ul>
                         </li>  
                    
                      <li><a id="A43" href="~/Logout.aspx" runat="server">Sign Out</a> </li>                           
                    </ul>
                    
	       </div>
	   </td>
	   </tr>   
	   </asp:PlaceHolder>

	   <!-- Entry Clerk Menu -->
	   <asp:PlaceHolder ID="EntryClerkMenu" runat="server" Visible=false>
	   <tr bgcolor=#3C4042>
	    <td colspan="3" valign="top">
        
                 <div id="nav">
                    <ul>
                     <li><a id="A33" href="#"  runat="server">Manage Transaction</a>
                        <ul>
                                <li><a id="A35"  href="~/Clerical/EnterDailyFnTrans.aspx" runat="server" visible=false>Financial Transactions</a></li>
                                <li><a id="A36"  href="~/Clerical/ManageGeneralTrans.aspx" runat="server" visible=true>General Transactions</a></li>
                        </ul>          
                    </li>    
                      <li><a id="A64" href="~/Logout.aspx" runat="server">Sign Out</a> </li>                           
	                    	                    
                    </ul>
                    
	       </div>
	   </td>
	   </tr>   
	   </asp:PlaceHolder>

	   
	   <!--- Employee Menu -->	   
	   <asp:PlaceHolder ID="EmployeeMenu" runat="server" Visible=false>
	   <tr bgcolor=#3C4042>
	    <td colspan="3" valign="top">
        
                 <div id="nav">
                    <ul>
                    <li><a href="#">My Profile</a>
                         <ul>
	                        <li><a href="~/Common/EmployeeProfile.aspx" runat="server">View Profile</a></li>
	                        <li><a href="~/Common/UpdateEmployeeProfile.aspx" runat="server">Update Profile</a></li>
	                        <li><a href="~/Common/ManageEContacts.aspx" runat="server">Add Emergency Contacts</a></li>
	                        <li><a href="~/Common/ManageDependents.aspx" runat="server">Add Dependents</a></li>
	                        
	                     </ul>
	                 </li>
                    <li><a href="#">Leave Request</a>
                          <ul>
	                        <li><a href="~/Common/LeaveRequest.aspx" runat="server">Leave Request</a></li>
	                        <li><a href="~/Common/ViewHolidays.aspx" runat="server">Company Holidays</a></li>
	                     </ul>                  
                    </li>
                    <li><a id="A3"  href="~/Common/ManageRequests.aspx"  runat="server">Other Requests</a></li>
                    <li><a href="#">My Pay</a> 
                    <ul>
                        <li><a id="A2"  href="~/Common/ViewPaySlip.aspx"  runat="server">View Monthly Pay Slip</a></li>
                        <li><a id="A32"  href="~/Common/ViewEOSBenefit.aspx"  runat="server">View EOS Benefit Statement</a></li>                   
                    </ul>                   
                    <li><a href="#">Directory</a>
                          <ul>
	                        <li><a href="~/Common/EmployeeDirectory.aspx"  runat="server">Employee Directory</a></li>
	                        <li><a href="~/Common/EmployeePhoneBook.aspx"  runat="server">Employee Phone Directory</a></li>
	                        <li><a href="~/Common/LocationDirectory.aspx" runat="server">Company Location Info</a></li>	                        
	                     </ul>                    
                     </li>
                    <li><a href="~/Common/EmployeeResources.aspx" runat="server">Employee Resources</a></li>
                    <li><a href="#">My Career</a> 
                        <ul>
                            <li><a href="~/Common/EmployeeSkills.aspx" runat="server">Competencies</a></li>
	                        <li><a href="~/Common/EmployeeCertifications.aspx" runat="server">Certifications</a></li>
	                        <li><a href="~/Common/EmployeeEducation.aspx" runat="server">Education</a></li>
	                        <li><a href="~/Common/EmployeeLanguages.aspx" runat="server">Languages</a></li>
	                        <li><a href="~/Common/EmployeeMemberships.aspx" runat="server">Memberships</a></li>
	                        <li><a href="~/Common/EmployeeTraining.aspx" runat="server">Training</a></li>
	                        <li><a href="~/Common/EmployeeWorkExp.aspx" runat="server">Work Experience</a></li>
	                        
                        </ul>
                    </li>
                    <li><a href="~/Common/ChangePassword.aspx" runat="server">Change Password</a> </li>
                    <li><a href="~/Logout.aspx" runat="server">Sign Out</a>                            
                  </ul>
                    
	       </div>
	   </td>
	   </tr>   
	   </asp:PlaceHolder>
   <!--- Supervisor Menu -->	   
	   <asp:PlaceHolder ID="SupervisorMenu" runat="server" Visible=false>
	   <tr bgcolor=#3C4042>
	    <td colspan="3" valign="top">
        
                 <div id="nav">
                  <ul>
                    <li><a href="#">My Profile</a>
                         <ul>
	                        <li><a href="~/Common/EmployeeProfile.aspx" runat="server">View Profile</a></li>
	                        <li><a href="~/Common/UpdateEmployeeProfile.aspx" runat="server">Update Profile</a></li>
	                        <li><a href="~/Common/ManageEContacts.aspx" runat="server">Add Emergency Contacts</a></li>
	                        <li><a href="~/Common/ManageDependents.aspx" runat="server" >Add Dependents</a></li>
	                        
	                     </ul>
	                 </li>
                    <li><a href="#">Leave Request</a>
                          <ul>
	                        <li><a href="~/Common/LeaveRequest.aspx" runat="server">My Leave Request</a></li>
	                        <li><a id="A68" href="~/Supervisor/SubOrdinatesLeaveList.aspx" runat="server">My Subordinates Leave Register</a></li>
	                        <li><a href="~/Common/ViewHolidays.aspx" runat="server">Company Holidays</a></li>
	                     </ul>
                    </li>
                    <li><a href="#">Requests Inbox</a>
                          <ul>
                            <li><a id="A6" href="~/Supervisor/PendingLeaveRequests.aspx" runat="server">Employee Leave Requests</a></li>
	                        <li><a id="A10" href="~/Common/ManageRequests.aspx" runat="server">General Requests</a></li>
	                     </ul>
                    </li>
                    
                    <li><a href="#">My Pay</a> 
                    <ul>
                        <li><a id="A5"  href="~/Common/ViewPaySlip.aspx"  runat="server">View Monthly Pay Slip</a></li>
                        <li><a id="A37"  href="~/Common/ViewEOSBenefit.aspx"  runat="server">View EOS Benefit Statement</a></li>                   
                    </ul>                   
                    <li><a href="#">Directory</a>
                          <ul>
	                        <li><a href="~/Common/EmployeeDirectory.aspx"  runat="server">Employee Directory</a></li>
	                        <li><a href="~/Common/EmployeePhoneBook.aspx"  runat="server">Employee Phone Directory</a></li>
	                        <li><a href="~/Common/LocationDirectory.aspx" runat="server">Company Location Directory</a></li>	                        
	                     </ul>                    
                     </li>
                    <li><a href="~/Common/EmployeeResources.aspx" runat="server">Employee Resources</a></li>
                    <li><a href="#">My Career</a> 
                        <ul>
                            <li><a href="~/Common/EmployeeSkills.aspx" runat="server">Competencies</a></li>
	                        <li><a href="~/Common/EmployeeCertifications.aspx" runat="server">Certifications</a></li>
	                        <li><a href="~/Common/EmployeeEducation.aspx" runat="server">Education</a></li>
	                        <li><a href="~/Common/EmployeeLanguages.aspx" runat="server">Languages</a></li>
	                        <li><a href="~/Common/EmployeeMemberships.aspx" runat="server">Memberships</a></li>
   	                        <li><a href="~/Common/EmployeeTraining.aspx" runat="server">Training</a></li>
	                        <li><a href="~/Common/EmployeeWorkExp.aspx" runat="server">Work Experience</a></li>

                        </ul>
                    </li>

                    <li><a href="~/Common/ChangePassword.aspx" runat="server">Change Password</a> </li>
                    <li><a href="~/Logout.aspx" runat="server">Sign Out</a>                            
                  </ul>
                   
	       </div>
	   </td>
	   </tr>   
	   </asp:PlaceHolder>
	    
	   </table>
	   
		   <!-- Main Content Area -->
		<table width="100%" height="86%" cellspacing="0" cellpadding="0" border ="0" bgcolor=#ffffff>
		<tr vAlign="top" height="100%">
				
		<td vAlign="top"  width="5%"  height="460px" bgcolor=#3C4042>
			<div id="RightMenu"></div>
		</td>	
		<td vAlign="top"  width="90%" height="460px">   
		     <div><master:contentplaceholder id="formData"  runat="server" /></div>
		    
		</td>
		 <td vAlign="top"  width="5%" height="460px" bgcolor=#3C4042>
		   <asp:PlaceHolder ID="MainLeftMenu" runat="server" Visible="false">
			<div id="LeftMenu">
			
			</div>
			</asp:PlaceHolder>
		</td>	
        </tr>
        </table>
        
		
		
		<!-- Page Footer menu -->  
		<table width="100%" cellspacing="0" cellpadding="0" border="0">	
		<tr bgcolor=#3C4042><td colspan="4" align="center" class=SubTitle>
		   <p style="text-align:center;color:White;">ARK HRMS Rel Version 2.1 Copyright © 2014 Shift2Net Solutions.All Rights Reserved.</p>
     	 </td>
		</tr>
			
		</table>
		</FORM> 
	</BODY>
</HTML>

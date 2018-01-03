<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
<%@ Control Language="c#" AutoEventWireup="true" Inherits="SchoolNet.Template" CodeFile="Template.ascx.cs" %>
<!DOCTYPE html> 
<HTML>
  <HEAD runat="server"> 
		<title>
			<master:contentplaceholder id="pageTitle" runat="server">Enterprise HRMS </master:contentplaceholder>
		</title>

        <link rel="stylesheet" href="~/CSS/folder-tree-static.css" type="text/css">
	    <link rel="stylesheet" href="~/CSS/context-menu.css" type="text/css">
        <link rel="stylesheet" type="text/css" href="~/CSS/NewUIStyles.css"/>
        <script language="javascript" src='<%= this.ResolveClientUrl("~/_scripts/folder-tree-static.js")%>' type="text/javascript"></script>
        <script language="javascript" src='<%= this.ResolveClientUrl("~/_scripts/context-menu.js")%>' type="text/javascript"></script>
        <script language="javascript" src='<%= this.ResolveClientUrl("~/FusionCharts/FusionCharts.js")%>' type="text/javascript"></script>

		<meta http-equiv="X-UA-Compatible" content="IE=edge" >
  		<meta content="Microsoft FrontPage 5.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<meta name="description"  content="HRMS" />
        				
		<!--<link rel="stylesheet" type="text/css" href="~/CSS/CommonStyles.css" id="CommonCss" />-->
		<link rel="stylesheet" media="all" href="~/CSS/stylesheet.css" />
				
		<!--  Includes for Jquery date control -->
		
	    <link type="text/css" href="~/CSS/smoothness/jquery-ui.css" rel="stylesheet" />
        <link type="text/css" href="~/CSS/smoothness/jquery-ui-timepicker-addon.css" rel="stylesheet" />
	
    	<style type="text/css">.ui-datepicker { font-size: 11px; margin-left:10px}</style>
        <script language="javascript" src='<%= this.ResolveClientUrl("~/_scripts/jquery-1.11.1.min.js") %>' type="text/javascript"></script>
        <script language="javascript" src='<%= this.ResolveClientUrl("~/_scripts/jquery-ui.min.js") %>' type="text/javascript"></script> 
	    <script language="javascript" src='<%= this.ResolveClientUrl("~/_scripts/PrintPage.js") %>' type="text/javascript"></script>
        <script language="javascript" src='<%= this.ResolveClientUrl("~/_scripts/jquery-ui-timepicker-addon.js") %>' type="text/javascript"></script>
               
        <SCRIPT type="text/javascript">
            $(function () {

                $('#Tab8_FileName').bind('change', function () {

                    //this.files[0].size gets the size of your file.
                    if (this.files[0].size / 1024 / 1024 > 4) {
                        alert('File size can not exceed more than 4 MB. Please check the file size.');
                        $('#Doc_Upload').attr("disabled", "true");
                        return true; //causes the client side script to run.
                    }
                    else {
                        //alert('File size can is less than 4 MB. Please check the file size.'); 
                        $('#Doc_Upload').removeAttr('disabled');
                        return true; //causes the client side script to run.
                    }
                });


                var dateToday = new Date();


                /*       T&A Scripts     */
                $("#Tab1_ShiftInTime").timepicker({ timeFormat: "HH:mm:ss" });
                $("#Tab1_ShiftOutTime").timepicker({ timeFormat: "HH:mm:ss" });
                $("#Tab1_PunchInTime").timepicker({ timeFormat: "HH:mm:ss" });
                $("#Tab1_PunchOutTime").timepicker({ timeFormat: "HH:mm:ss" });
                $("#Tab1_PunchingDate").datepicker({ dateFormat: "dd/mm/yy" });
                $("#Tab1_PunchingDate").datepicker();


                var minViewDate = new Date(dateToday.getFullYear(), dateToday.getMonth() - 3, 1);
                var maxViewDate = new Date(dateToday.getFullYear(), dateToday.getMonth() + 3, 1);
                //  $("#Attendance_Month").datepicker().datepicker("setDate", dateToday);
                $("#Attendance_Month").datepicker({
                    dateFormat: 'yy-mm',
                    changeMonth: true,
                    changeYear: true,
                    showButtonPanel: true,
                    minDate: minViewDate,
                    maxDate: maxViewDate,
                    onClose: function (dateText, inst) {
                        var month = $("#ui-datepicker-div .ui-datepicker-month :selected").val();
                        var year = $("#ui-datepicker-div .ui-datepicker-year :selected").val();
                        $(this).val($.datepicker.formatDate('yy-mm', new Date(year, month, 1)));
                    }
                });
                //.datepicker("setDate", dateToday);


                $("#Tab1_DateCompleted").datepicker({ dateFormat: "dd/mm/yy" });
                $("#Tab1_DateCompleted").datepicker();
                $("#Tab1_DateCompleted").datepicker({ beforeShowDay: $.datepicker.noWeekends });
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
                $("#Tab1_Date").datepicker({ beforeShowDay: $.datepicker.noWeekends });



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



                $(".monthPicker").datepicker({
                    dateFormat: 'mm-yy',
                    changeMonth: true,
                    changeYear: true,
                    showButtonPanel: true,
                    minDate: dateToday,
                    onClose: function (dateText, inst) {
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
                    onClose: function (dateText, inst) {
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
                    onClose: function (dateText, inst) {
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
                    onClose: function (dateText, inst) {
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
				<tr bgcolor="#061226">
					<td style="vertical-align:middle" width="30%" ><div><span class='product'>Enterprise HRM Solution</span></div>
                    <!--&nbsp;&nbsp;&nbsp;&nbsp;<IMG height="65" src="~/images/Arklogo.jpg" runat="server" alt= "Product Logo" width="200" style="vertical-align:bottom;">-->
                    </td>
                    <td style="vertical-align:middle" width="35%">
                   <!-- <center><IMG id="IMG1" height="51" src="~/images/aon_Logo1.gif" runat="server" alt= "Customer Logo" width="96" style="vertical-align:bottom;"></center>-->
                    </td>					
					<td style="vertical-align:middle" width="30%" align="right">
                        <p style="text-align: right;margin: 10px 5px 5px 5px;"><asp:Label ID="UserName"  Visible=true Runat=server /></p>
              <a id="A69" href="~/Common/EmployeeProfile.aspx" runat="server">  
              <IMG id="IMG2" src="~/images/user.png" runat="server" runat=server title="View Profile" alt= "View Profile" height="25" width="25" style="vertical-align:bottom;"></a>
              <a id="A70" href="~/Common/ChangePassword.aspx" runat="server">
              <IMG id="IMG4" src="~/images/key.png" runat="server" alt= "Change Password" title= "Change Password" height="25" width="25" style="vertical-align:bottom;padding-bottom:2px"></a>
              <a id="A71" href="~/Logout.aspx" runat="server">
              <IMG id="IMG3" src="~/images/exit.png" runat="server" alt= "Sign Out" title= "Sign Out" height="25" width="25" style="vertical-align:bottom;padding-bottom:2px"></a>
                     </td>
					<td style="vertical-align:middle" width="5%">&nbsp;</td>
					
				</tr>
					 			
	        </table>  
		
	         
	   <!-- Main Menu Navigation -->
	   <!-- Pure CSS3 Multi Level Drop Down Navigation Menu by Bloggermint.com -->
	   
		   <!-- Main Content Area -->
		<table width="100%" height="100%" cellspacing="0" cellpadding="0" border ="0">
		<tr vAlign="top" height="100%">
				
		<td vAlign="top"  width="18%"  height="100%">
        <%--Tree View Menu--%>
	   <!-- Main Menu Navigation -->

			<div id="RightMenu">
            <div id="menu_content">
            <p id="menu_title">Main Menu Navigation</p>
                         
       <!--- HR Admin Menu -->       
           	<asp:PlaceHolder ID="AdminMenu" runat="server" Visible=false>
                    <div id="menu_scroll">
	    <ul id="menu_tree" class="menu_tree">
        <li class="dir_pink.png"><a id="A73" href="~/admin/Dashboard.aspx" runat="server">Dashboard</a></li>
        <li><a id="A74" href="javascript:void(0);" runat="server">Employee Management</a>
	        <ul>
	            <li class="dir_pink.png"><a id="A75" href="~/admin/ManageEmployee.aspx" runat="server">Manage Employees</a></li>	 
	            <li class="dir_pink.png"><a id="A76" href="~/admin/AddEmployee.aspx" runat="server">Add Employee</a></li>
	            <li class="dir_pink.png"><a id="A77" href="~/admin/DeactivateEmployee.aspx" runat="server">Deactivate Employee</a></li>
	            <li class="dir_pink.png"><a id="A78" href="~/admin/ReactivateEmployee.aspx" runat="server">Reactivate Employee</a></li>
	        </ul>
        </li>
        <li><a id="A87" href="javascript:void(0);" runat="server">Leave Management</a>
            <ul>
                <li class="dir_pink.png"><a id="A88" href="~/admin/LeaveList.aspx" runat="server">Employees Leave List</a></li>
	            <li class="dir_pink.png"><a id="A89" href="~/admin/ManageLeave.aspx" runat="server">Manage Employee Leave</a></li>
	            <li class="dir_pink.png"><a id="A90" href="~/admin/ManageLeaveEntitlement.aspx" runat="server">Assign Leave Entitlement</a></li>          	                        
	        </ul>
        </li>
        <li><a id="A5" href="javascript:void(0);" runat="server">Time & Attendance</a>
            <ul>
                <li class="dir_pink.png"><a id="A6" href="~/admin/ManageEmpTA.aspx" runat="server">Employee Attendance</a></li>
	        </ul>
        </li>
        <li><a id="A97" href="javascript:void(0);" runat="server">Benefits Management</a>
            <ul>
                    <li class="dir_pink.png"><a id="A98"  href="~/Admin/ManageBenefit.aspx" runat="server">Manage Employee Benefits</a></li>
                    <li class="dir_pink.png"><a id="A99"  href="~/Payroll/ManageEOS.aspx" runat="server" visible=true>End of Service Process</a></li>
            </ul>                                          
        </li>
         
        <li><a id="A107" href="javascript:void(0);"  runat="server">Transactions</a>
            <ul>
                    <li class="dir_pink.png"><a id="A109"  href="~/Clerical/ManageGeneralTrans.aspx" runat="server" visible=true>General Transactions</a></li>
                    <li class="dir_pink.png"><a id="A110"  href="~/Common/ManageRequests.aspx"  runat="server">Requests Management</a></li>     
           
            </ul>          
        </li>
              
                    
        <li><a id="A111" href="javascript:void(0);" runat="server">HR Administration</a>
	        <ul>
	        <li><a href="javascript:void(0);">Employee</a>
                <ul>
                    <li class="dir_pink.png"><a id="A112" href="~/admin/Division.aspx" runat="server">Business Unit</a></li>
                    <li class="dir_pink.png"><a id="A113" href="~/admin/Department.aspx" runat="server">Department</a></li>
                    <li class="dir_pink.png"><a id="A114" href="~/admin/Designation.aspx" runat="server">Designation</a></li>                                
                    <li class="dir_pink.png"><a id="A115" href="~/admin/EmpCategory.aspx" runat="server">Employee Category</a></li>
                    <li class="dir_pink.png"><a id="A116" href="~/admin/EmployeeStatus.aspx" runat="server">Employment Status</a></li>
                    <li class="dir_pink.png"><a id="A117" href="~/admin/Education.aspx" runat="server">Education</a></li>
                    <li class="dir_pink.png"><a id="A118" href="~/admin/Bank.aspx" runat="server">Bank</a></li>                              
                                
                    </ul>    
	        </li>
	        <li><a href="javascript:void(0);">Leave</a>
                <ul>
                    <li class="dir_pink.png"><a id="A119" href="~/admin/LeaveType.aspx" runat="server">Define Leave Type</a></li>
                    <li class="dir_pink.png"><a id="A120" href="~/admin/LeavePeriod.aspx" runat="server">Define Leave Period</a></li>
                    <li class="dir_pink.png"><a id="A121" href="~/admin/WorkWeek.aspx" runat="server">Define Work Week</a></li>
                    <li class="dir_pink.png"><a id="A122" href="~/admin/Holidays.aspx" runat="server">Define Holidays</a></li>
                                
                </ul>   
	        </li>
            <li><a href="javascript:void(0);">Time & Attendance</a>
                <ul>
                    <li class="dir_pink.png"><a id="A2" href="~/admin/TAConfig.aspx" runat="server">General Configuration</a></li>
                    <li class="dir_pink.png"><a id="A4" href="~/admin/TAShiftMaster.aspx" runat="server">Define Shift Level</a></li>
                </ul>   
	        </li>
	        <li><a href="javascript:void(0);">Benefit</a>
                <ul>
                    <li class="dir_pink.png"><a id="A123" href="~/admin/PayComponents.aspx" runat="server">Payable Components</a></li>
                    <li class="dir_pink.png"><a href="~/admin/Deductions.aspx" runat="server">Deduction Components</a></li>
                    <li class="dir_pink.png"><a href="~/admin/Incentives.aspx" runat="server">Incentive Components</a></li> 
                    <li class="dir_pink.png"><a href="~/admin/NonPayrollBenefits.aspx" runat="server">NonPayroll Benefits</a></li>                                                                
                    <li class="dir_pink.png"><a href="~/admin/GratuityRule.aspx" runat="server">Define EOS Gratuity</a></li>
                </ul>                                 
                </li>
                         
            <li><a href="javascript:void(0);">Employee Resources</a>
                <ul>
                    <li class="dir_pink.png"><a href="~/admin/ManageEmpResources.aspx" runat="server">Employee Resources</a></li>
                               
                </ul>   
	        </li>
	        <li class="dir_pink.png"><a href="~/admin/UserAccounts.aspx" runat="server">Manage User Accounts</a></li>
            </ul>

            </li>
            <li class="dir_pink.png"><a id="A1" href="~/Common/Reports.aspx" runat="server">Custom Reports</a></li>
        </ul>
    <div style="padding-left:3px;">
	<a class='menu_all' href="javascript:void(0);" onclick="expandAll('menu_tree');return false">Expand all</a>
	<a class='menu_all' href="javascript:void(0);" onclick="collapseAll('menu_tree');return false">Collapse all</a>
    </div>
    </div>

            </asp:PlaceHolder>
    
       <!-- Payroll Admin Menu -->
<asp:PlaceHolder ID="PayrollMenu" runat="server" Visible=false>
<div id="menu_scroll">    
    <ul id="menu_tree" class="menu_tree">                 
            <li class="dir_pink.png"><a id="A126" href="~/Payroll/payrollDashboard.aspx" runat="server">Dashboard</a></li>
                            
            <li>
            <a id="A127" href="#" runat="server">Prepare</a>
                <ul>
                <li class="dir_pink.png"><a id="A128"  href="~/Payroll/ManageDeductions.aspx" runat="server">Manage Reoccuring Deductions</a></li>
                <li class="dir_pink.png"><a id="A129"  href="~/Clerical/EnterDailyFnTrans.aspx" runat="server">Manage Adhoc Payroll Transactions</a></li>                                                       
                <li class="dir_pink.png"><a id="A130"  href="~/Payroll/ManageEOS.aspx" runat="server">End of Service List</a></li>                                                                                       
            </ul>
            </li>  
            <li>
            <a id="A131" href="#" runat="server">Process</a>
                <ul>
                <li class="dir_pink.png"><a id="A132"   href="~/Payroll/ProcessMonthlyPayroll.aspx" runat="server">Process Monthly Payroll (Batch)</a></li> 
                <li class="dir_pink.png"><a id="A133"   href="~/Payroll/ProcessMonthlyEOSPayroll.aspx" runat="server">Process End of Service (Batch)</a></li> 
            </ul>
            </li>  
                                                  
            <li>
            <a id="A134" href="#" runat="server">Preview</a>
                <ul>
                <li class="dir_pink.png"><a id="A135"  href="~/Payroll/ManagePayroll.aspx" runat="server">Review/Reconcile Employee Payroll</a></li>
                <li class="dir_pink.png"><a id="A136"  href="~/Payroll/ManageEOS.aspx" runat="server">Review/Reconcile End of Service</a></li>  
                <li class="dir_pink.png"><a id="A137"  href="~/Payroll/PreviewMonthlyPayroll.aspx" runat="server">Preview Monthly Payroll</a></li>                                                                                                                                                                                                                     
            </ul>
            </li>  
            <li>
            <a id="A138" href="#" runat="server">Post</a>
                <ul>
                <li class="dir_pink.png"><a id="A139"  href="~/Payroll/RunMonthlyPayroll.aspx" runat="server">Finalize Monthly Payroll</a></li>
                <li class="dir_pink.png"><a id="A140"  href="~/Payroll/MonthlyWPSPayroll.aspx" runat="server">Extract Monthly WPS</a></li>                                
            </ul>
            </li>  
            <li class="dir_pink.png"><a id="A142"  href="~/Payroll/ViewPayrollHistory.aspx" runat="server" visible=true>Payroll History</a></li>  
            <li class="dir_pink.png"><a id="A3" href="~/Common/Reports.aspx" runat="server">Custom Reports</a></li>
                        
    </ul>
    <div style="padding-left:3px;">
    <a href="#" onclick="expandAll('menu_tree');return false">Expand all</a>
	<a href="#" onclick="collapseAll('menu_tree');return false">Collapse all</a>
    </div>  
    </div>
</asp:PlaceHolder>

	<!--- Employee Menu -->	 
<asp:PlaceHolder ID="EmployeeMenu" runat="server" Visible=false>
    <div id="menu_scroll">
	<ul id="menu_tree" class="menu_tree">
                    <li><a href="#">My Profile</a>
                         <ul>
	                        <li class="dir_pink.png"><a id="A72" href="~/Common/EmployeeProfile.aspx" runat="server">View Profile</a></li>
	                        <li class="dir_pink.png"><a id="A151" href="~/Common/UpdateEmployeeProfile.aspx" runat="server">Update Profile</a></li>
	                        <li class="dir_pink.png"><a id="A152" href="~/Common/ManageEContacts.aspx" runat="server">Add Emergency Contacts</a></li>
	                        <li class="dir_pink.png"><a id="A153" href="~/Common/ManageDependents.aspx" runat="server">Add Dependents</a></li>
	                     </ul>
	                 </li>
                    <li><a href="#">Leave Request</a>
                          <ul>
	                        <li class="dir_pink.png"><a id="A154" href="~/Common/LeaveRequest.aspx" runat="server">Leave Request</a></li>
	                        <li class="dir_pink.png"><a id="A155" href="~/Common/ViewHolidays.aspx" runat="server">Company Holidays</a></li>
	                     </ul>                  
                    </li>
                    <li><a href="#">Time & Attendance</a>
                          <ul>
	                        <li class="dir_pink.png"><a id="A7" href="~/Common/ViewAttendance.aspx" runat="server">View My attendance</a></li>
	                        <li class="dir_pink.png"><a id="A8" href="~/Common/ManualAttendance.aspx" runat="server">Enter Manual Attendance</a></li>
	                     </ul>                  
                    </li>
                    <li class="dir_pink.png"><a id="A156"  href="~/Common/ManageRequests.aspx"  runat="server">Other Requests</a></li>
                    <li><a href="#">My Pay</a> 
                    <ul>
                        <li class="dir_pink.png"><a id="A157"  href="~/Common/ViewPaySlip.aspx"  runat="server">View Monthly Pay Slip</a></li>
                        <li class="dir_pink.png"><a id="A158"  href="~/Common/ViewEOSBenefit.aspx"  runat="server">View EOS Benefit Statement</a></li>                   
                    </ul>                   
                    <li><a href="#">Directory</a>
                          <ul>
	                        <li class="dir_pink.png"><a id="A159" href="~/Common/EmployeeDirectory.aspx"  runat="server">Employee Directory</a></li>
	                        <li class="dir_pink.png"><a id="A160" href="~/Common/EmployeePhoneBook.aspx"  runat="server">Employee Phone Directory</a></li>
	                        <li class="dir_pink.png"><a id="A161" href="~/Common/LocationDirectory.aspx" runat="server">Company Location Info</a></li>	                        
	                     </ul>                    
                     </li>
                    <li class="dir_pink.png"><a id="A162" href="~/Common/EmployeeResources.aspx" runat="server">Employee Resources</a></li>
                    <li><a href="#">My Career</a> 
                        <ul>
                            <li class="dir_pink.png"><a id="A163" href="~/Common/EmployeeSkills.aspx" runat="server">Competencies</a></li>
	                        <li class="dir_pink.png"><a id="A164" href="~/Common/EmployeeCertifications.aspx" runat="server">Certifications</a></li>
	                        <li class="dir_pink.png"><a id="A165" href="~/Common/EmployeeEducation.aspx" runat="server">Education</a></li>
	                        <li class="dir_pink.png"><a id="A166" href="~/Common/EmployeeLanguages.aspx" runat="server">Languages</a></li>
	                        <li class="dir_pink.png"><a id="A167" href="~/Common/EmployeeMemberships.aspx" runat="server">Memberships</a></li>
	                        <li class="dir_pink.png"><a id="A168" href="~/Common/EmployeeTraining.aspx" runat="server">Training</a></li>
	                        <li class="dir_pink.png"><a id="A169" href="~/Common/EmployeeWorkExp.aspx" runat="server">Work Experience</a></li>
                        </ul>
                    </li>                           
                  </ul>
                  <div style="padding-left:3px;">
	<a href="#" onclick="expandAll('menu_tree');return false">Expand all</a>
	<a href="#" onclick="collapseAll('menu_tree');return false">Collapse all</a>
    </div>
    </div>
</asp:PlaceHolder>

	<!--- Data Entry Menu -->	 
<asp:PlaceHolder ID="EntryClerkMenu" runat="server" Visible=false>
    <div id="menu_scroll">
	<ul id="menu_tree" class="menu_tree">
        <li><a id="A108" href="#"  runat="server">Manage Transactions</a>
        <ul>
                <li class="dir_pink.png"><a id="A124"  href="~/Clerical/EnterDailyFnTrans.aspx" runat="server">Finance Adhoc Transactions</a></li>
                <li class="dir_pink.png"><a id="A125"  href="~/Clerical/ManageGeneralTrans.aspx" runat="server">General Transactions</a></li>

        </ul>          
        </li>                 	                    
    </ul>
    <div style="padding-left:3px;">
	<a href="#" onclick="expandAll('menu_tree');return false">Expand all</a>
	<a href="#" onclick="collapseAll('menu_tree');return false">Collapse all</a>
    </div>
    </div>
</asp:PlaceHolder>

	<!--- Supervisor Menu -->	 
<asp:PlaceHolder ID="SupervisorMenu" runat="server" Visible=false>
    <div id="menu_scroll">
	<ul id="menu_tree" class="menu_tree">
        <li><a href="#">My Profile</a>
                <ul>
	            <li class="dir_pink.png"><a id="A170" href="~/Common/EmployeeProfile.aspx" runat="server">View Profile</a></li>
	            <li class="dir_pink.png"><a id="A171" href="~/Common/UpdateEmployeeProfile.aspx" runat="server">Update Profile</a></li>
	            <li class="dir_pink.png"><a id="A172" href="~/Common/ManageEContacts.aspx" runat="server">Add Emergency Contacts</a></li>
	            <li class="dir_pink.png"><a id="A173" href="~/Common/ManageDependents.aspx" runat="server" >Add Dependents</a></li>
	                        
	            </ul>
	        </li>
        <li><a href="#">Leave Request</a>
                <ul>
	            <li class="dir_pink.png"><a id="A174" href="~/Common/LeaveRequest.aspx" runat="server">My Leave Request</a></li>
	            <li class="dir_pink.png"><a id="A175" href="~/Supervisor/SubOrdinatesLeaveList.aspx" runat="server">My Subordinates Leave Register</a></li>
	            <li class="dir_pink.png"><a id="A176" href="~/Common/ViewHolidays.aspx" runat="server">Company Holidays</a></li>
	            </ul>
        </li>
        <li><a href="#">Time & Attendance</a>
                <ul>
	            <li class="dir_pink.png"><a id="A9" href="~/Common/ViewAttendance.aspx" runat="server">View My attendance</a></li>
	            <li class="dir_pink.png"><a id="A10" href="~/Common/ManualAttendance.aspx" runat="server">Enter Manual Attendance</a></li>
	            </ul>                  
        </li>
        <li><a href="#">Requests Inbox</a>
                <ul>
                <li class="dir_pink.png"><a id="A177" href="~/Supervisor/PendingLeaveRequests.aspx" runat="server">Employee Leave Requests</a></li>
                <li class="dir_pink.png"><a id="A11" href="~/Supervisor/AttendanceRequests.aspx" runat="server">Attendance Requests</a></li>
	            <li class="dir_pink.png"><a id="A178" href="~/Common/ManageRequests.aspx" runat="server">General Requests</a></li>
	            </ul>
        </li>
        
        <li><a href="#">My Pay</a> 
        <ul>
            <li class="dir_pink.png"><a id="A179"  href="~/Common/ViewPaySlip.aspx"  runat="server">View Monthly Pay Slip</a></li>
            <li class="dir_pink.png"><a id="A180"  href="~/Common/ViewEOSBenefit.aspx"  runat="server">View EOS Benefit Statement</a></li>                   
        </ul>                   
        <li><a href="#">Directory</a>
                <ul>
	            <li class="dir_pink.png"><a id="A181" href="~/Common/EmployeeDirectory.aspx"  runat="server">Employee Directory</a></li>
	            <li class="dir_pink.png"><a id="A182" href="~/Common/EmployeePhoneBook.aspx"  runat="server">Employee Phone Directory</a></li>
	            <li class="dir_pink.png"><a id="A183" href="~/Common/LocationDirectory.aspx" runat="server">Company Location Directory</a></li>	                        
	            </ul>                    
            </li>
        <li class="dir_pink.png"><a id="A184" href="~/Common/EmployeeResources.aspx" runat="server">Employee Resources</a></li>
        <li><a href="#">My Career</a> 
            <ul>
                <li class="dir_pink.png"><a id="A185" href="~/Common/EmployeeSkills.aspx" runat="server">Competencies</a></li>
	            <li class="dir_pink.png"><a id="A186" href="~/Common/EmployeeCertifications.aspx" runat="server">Certifications</a></li>
	            <li class="dir_pink.png"><a id="A187" href="~/Common/EmployeeEducation.aspx" runat="server">Education</a></li>
	            <li class="dir_pink.png"><a id="A188" href="~/Common/EmployeeLanguages.aspx" runat="server">Languages</a></li>
	            <li class="dir_pink.png"><a id="A189" href="~/Common/EmployeeMemberships.aspx" runat="server">Memberships</a></li>
   	            <li class="dir_pink.png"><a id="A190" href="~/Common/EmployeeTraining.aspx" runat="server">Training</a></li>
	            <li class="dir_pink.png"><a id="A191" href="~/Common/EmployeeWorkExp.aspx" runat="server">Work Experience</a></li>

            </ul>
        </li>                           
        </ul>
    <div style="padding-left:3px;">
	<a href="#" onclick="expandAll('menu_tree');return false">Expand all</a>
	<a href="#" onclick="collapseAll('menu_tree');return false">Collapse all</a>
    </div>
    </div>
</asp:PlaceHolder>
                </div>
       </div>
		</td>	

		<td vAlign="top"  width="82%" height="100%">   
		    <div id="tool_outer">
                <div id="tool_content">
                    <p id="tool_title">Welcome to Enterprise HRM Solutions</p>
                    <!--<div style="margin-top:3px;float:left;"></div>-->
            <div style="float:left;width:100%;min-height:500px;"><master:contentplaceholder id="formData"  runat="server" /></div>
                </div>
		    </div>
		</td>
<%--		 <td vAlign="top"  width="5%" height="460px" bgcolor=#E1EBF1>
		   <asp:PlaceHolder ID="MainLeftMenu" runat="server" Visible="false">
			<div id="LeftMenu">
			
			</div>
			</asp:PlaceHolder>
		</td>--%>	
        </tr>
        </table>
      
		
		<!-- Page Footer menu -->  
		<table width="100%" cellspacing="0" cellpadding="0" border="0">	
		<tr>
        <td>&nbsp;</td>
        <td align="center" class=SubTitle>
		   <p style="text-align:center;color:#0A3151;margin:20px 0 12px;">Enterprise HRM Solutions Rel Version 2.2 Copyright © 2015 Shift2Net Solutions Inc. All Rights Reserved.</p>
     	</td>
		</tr>
			
		</table>
       	</FORM> 
	</BODY>
<script type="text/javascript" language="JavaScript">
    function myJS(myVar) {
        window.alert(myVar);
    }     
</script>
</HTML>

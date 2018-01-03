using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Globalization;
using System.Web.Security;
using System.Web.UI;
using System.Net.Mail;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using PresentationManager.Web.UI.MasterPages;

namespace SchoolNet
{
    public partial class ManageEmpTA : SchoolNetBase
    {
        public int EmpId;
        protected void Page_Load(object sender, EventArgs e)
        {
            EmpId = Int32.Parse(Page.User.Identity.Name.ToString());
            if (!Page.IsPostBack)
            {
                
                LoadEmpStatusLookup(this.empStatusDDList);
                LoadDesignationLookup(this.jobTitleDDList);
                LoadDivisionLookupByEmpId(businessUnitDDList, Int32.Parse(Page.User.Identity.Name.ToString()));
                LoadEntityLocationLookupByEmpId_DivisionID(DivisionLocationList, Int32.Parse(Page.User.Identity.Name.ToString()), Int32.Parse(businessUnitDDList.SelectedValue));

            }
            if (Int32.Parse(DivisionLocationList.SelectedValue) == -1)
            {
                LoadEntityLocationLookupByEmpId_DivisionID(DivisionLocationList, Int32.Parse(Page.User.Identity.Name.ToString()), Int32.Parse(businessUnitDDList.SelectedValue));
            }

           // LoadCurrentEntitlement();
            LoadDataList();

            if (this.keyField.Text.ToString() != "")
            {
                LoadShiftAssignments();
                LoadLeaveRequestList();
                LoadPendingLeaveRequestList();
            }

        }
        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
            base.OnInit(e);
            this.EnableViewState = true;
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {

            Grid.PageIndexChanged += new DataGridPageChangedEventHandler(this.Grid_PageIndexChanged);
            Grid.SortCommand += new DataGridSortCommandEventHandler(Grid_SortCommand);
            EGrid.PageIndexChanged +=new DataGridPageChangedEventHandler(EGrid_PageIndexChanged);
            Search.Click += new ImageClickEventHandler(Search_Click);
            Reset.Click += new ImageClickEventHandler(Reset_Click);
            AssignShift_Save.Click += new EventHandler(AssignShift_Save_Click);
            AssignShift_Cancel.Click += new EventHandler(AssignShift_Cancel_Click);
            Attendance_Go.Click += new ImageClickEventHandler(View_Attendance_Click);
            tab1.Click += new EventHandler(tab1_Click);
            tab2.Click += new EventHandler(tab2_Click);
            tab3.Click +=new EventHandler(tab3_Click);
            
        }
        #endregion
        #region Load LoadDataList
        private void LoadDataList()
        {
            try{
            DataSet _DataList = null;
            if (ViewState["myDataSet"] == null)   // No such value in view state, take appropriate action.
            {

                _DataList = DatabaseManager.Data.DBAccessManager.RetrieveEmployeeList_Search(Int32.Parse(Page.User.Identity.Name.ToString()), empName.Text.ToString(), emp_ID.Text.ToString(), mgrName.Text.ToString(), Int32.Parse(empStatusDDList.SelectedValue), Int32.Parse(jobTitleDDList.SelectedValue), Int32.Parse(businessUnitDDList.SelectedValue), Int32.Parse(DivisionLocationList.SelectedValue));

                if (_DataList.Tables[0].Rows.Count > 0)
                {
                    this.Grid.DataSource = _DataList;
                    this.Grid.DataBind();
                    emptyRow.Text = "";
                    emptyRow.Visible = false;
                    SetViewState(_DataList);

                }
                else
                {
                    this.Grid.DataSource = null;
                    this.Grid.DataBind();
                    emptyRow.Visible = true;
                    emptyRow.CssClass = "errorMessage";
                    emptyRow.Text = "There are no matching records found.";
                }
            }
            else  // If it is avaiable in the viewstate bind it from there.
            {
                _DataList = GetViewState();
                this.Grid.DataSource = _DataList;
                this.Grid.DataBind();

            }
            }
            catch (Exception exception)
            {
                 Grid.CurrentPageIndex = 0;
                 Grid.DataBind();
            }



        }
     #endregion
        #region LoadShiftAssignments()
        private void LoadShiftAssignments()
        {
            DataSet _DataList = null;
            Tab1_EmptyRow.Visible = false;
            _DataList = DatabaseManager.Data.DBAccessManager.RetrieveShiftAssignments(Int32.Parse(keyField.Text.ToString()));

            if (_DataList.Tables[0].Rows.Count > 0)
            {
                this.EGrid.DataSource = _DataList;
                this.EGrid.DataBind();
            }
            else
            {
                this.EGrid.DataSource = null;
                this.EGrid.DataBind();
                Tab1_EmptyRow.Visible = true;
                Tab1_EmptyRow.CssClass = "errorMessage";
                Tab1_EmptyRow.Text = "There are no shift assignment records set for this year.Please setup shift assignments for this leave year.";
            }
        }
        #endregion

        #region LoadLeaveRequestList();
        private void LoadLeaveRequestList()
        {
        /*    DataSet _DataList = null;
            Tab2_EmptyRow.Visible = false;
            Int32 RequestType = (int)Constants.LeaveRequestType.Processed; // Returns approved, closed, cancelled,rejected requests
            _DataList = DatabaseManager.Data.DBAccessManager.RetrieveLeaveRequestsByLeavePeriod(Int32.Parse(keyField.Text.ToString()), Int32.Parse(Tab2_LeavePeriodList.SelectedValue), RequestType); 

            if (_DataList.Tables[0].Rows.Count > 0)
            {
                emptyRow.Visible = false;
                this.LGrid.DataSource = _DataList;
                this.LGrid.DataBind();

            }
            else
            {
                this.LGrid.DataSource = null;
                this.LGrid.DataBind();
                Tab2_EmptyRow.Visible = true;
                Tab2_EmptyRow.CssClass = "errorMessage";
                Tab2_EmptyRow.Text = "There are no matching records found.";

            }   */
        }
        #endregion

        #region LoadPendingLeaveRequestList();
        private void LoadPendingLeaveRequestList()
        {
      /*      DataSet _DataList = null;
            Tab3_EmptyRow.Visible = false;
            Int32 RequestType = (int)Constants.LeaveRequestType.Pending; // Returns only submitted,pending approval
            _DataList = DatabaseManager.Data.DBAccessManager.RetrieveLeaveRequestsByLeavePeriod(Int32.Parse(keyField.Text.ToString()), Int32.Parse(Tab2_LeavePeriodList.SelectedValue), RequestType); 

            if (_DataList.Tables[0].Rows.Count > 0)
            {
                Tab3_EmptyRow.Visible = false;
                this.ALGrid.DataSource = _DataList;
                this.ALGrid.DataBind();

            }
            else
            {
                this.ALGrid.DataSource = null;
                this.ALGrid.DataBind();
                Tab3_EmptyRow.Visible = true;
                Tab3_EmptyRow.CssClass = "errorMessage";
                Tab3_EmptyRow.Text = "There are no pending leave request found.";

            }   */
        }
        #endregion

        #region Tab2_Cancel_Click
        protected void Tab2_Cancel_Click(object sender, EventArgs e)
        {

            try
            {
                if (Page.IsValid == true)
                {
                    if (Tab2_keyField.Text.ToString()== "0")
                    {
                        Tab2_Message2.Visible = true;
                        Tab2_Message2.Text = "Please select the leave request to cancel.";
                        Tab2_Message2.CssClass = "errorMessage";
                        return;
                    }
                    DataSet _DataList = null;
                    _DataList = DatabaseManager.Data.DBAccessManager.Cancel_ApprovedLeaveRequest(Convert.ToInt32(Tab2_keyField.Text), Convert.ToInt32(keyField.Text), Tab2_ApproverComments.Text.ToString(), EmpId);
                    if (_DataList.Tables[0].Rows.Count > 0)
                    {
                        String Result, LineManagerName, LineManagerEmail, EmpName, EmpEmail, LeaveType, LeaveStartDate, LeaveEndDate, StatusName;
                        DataRow _DataRow = _DataList.Tables[0].Rows[0];
                        Result = _DataRow["Result"].ToString();
                        if (Result == "")
                        {
                            EmpName = _DataRow["EmpName"].ToString();
                            EmpEmail = _DataRow["EmpEmail"].ToString();
                            LeaveStartDate = _DataRow["LeaveDate"].ToString();
                            LeaveEndDate = _DataRow["LeaveEndDate"].ToString();
                            LeaveType = _DataRow["LeaveType"].ToString();
                            StatusName = _DataRow["StatusName"].ToString();

                            if (StatusName != "")
                            {
                                if (EmpEmail != "") // Notify via Email if Email was used as a user Name                                           
                                {
                                    LeaveRequestCancel_Notification(EmpName, EmpEmail, LeaveStartDate, LeaveEndDate, LeaveType, StatusName);

                                }
                                Tab2_Message2.Visible = true;
                                Tab2_Message2.Text = "This request has been successfully cancelled and employee has been notified via email.";
                                Tab2_Message2.CssClass = "errorMessage";
                                ResetFields();
                            }
                        }
                        else
                        {
                            Tab2_Message2.Visible = true;
                            Tab2_Message2.Text = Result;
                            Tab2_Message2.CssClass = "errorMessage";

                        }
                    }
                }
                else
                {
                    Tab2_Message2.Visible = true;
                    Tab2_Message2.Text = "Error:Could not save the information. Please check the inputs";
                    Tab2_Message2.CssClass = "errorMessage";
                }
                LoadPendingLeaveRequestList();// Refresh the grid

            }
            catch (Exception exception)
            {
                Tab2_Message.Visible = true;
                Tab2_Message.Text = ErrorLogging.LogError(exception, "Unknown Exception Occured. Please contact support.");
                Tab2_Message.CssClass = "errorMessage";
            }
        }
        #endregion


        #region View_Attendance_Click
        protected void View_Attendance_Click(object sender, EventArgs e)
        {
            if (Page.IsValid == true)
            {
                //  ViewMonthlyAttendance.Visible = true;
                LoadEmpMonthlyAttendance(Int32.Parse(keyField.Text), Attendance_Month.Text);
            }
        }
        #endregion

        protected void LoadEmpMonthlyAttendance(Int32 EmpId, String MonthYear)
        {
            try
            {
                message.Visible = false;
                message.Text = "";
                DataSet _DataList = null;
                _DataList = DatabaseManager.Data.DBAccessManager.RetrieveEmpMonthlyAttendance(EmpId, MonthYear);
                if (_DataList.Tables[0].Rows.Count > 0)
                {
                    this.AttendanceGrid.DataSource = _DataList;
                    this.AttendanceGrid.DataBind();
                }
                else
                {
                    emptyRow.Visible = true;
                    emptyRow.Text = "There are no records found.";
                    emptyRow.CssClass = "errorMessage";
                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "Unknown Exception Occured.Please contact Support.");
                this.message.Visible = true;
                this.message.CssClass = "errorMessage";
            }
        }


        private void LeaveRequestCancel_Notification(String EmpName, String EmpEmail, String LeaveStartDate, String LeaveEndDate, String LeaveType, String StatusName)
        {

            string HRSystemLink = ConfigurationManager.AppSettings["HRSystemURL"].ToString();
            string FromAddressDisplayName = ConfigurationManager.AppSettings["FromEmailDisplayName"].ToString();

            string subject = "Ark HRMS Alerting Service:Leave Request Cancellation Alert for " + EmpName;

            string bodycontent = "<html><body leftmargin=10 style=\"font-family: Arial;font-size:11\">" +
                                 "<P><br> Hello " + EmpName + "," +
                                 "<br><br>As per your request, Your HR administrator has cancelled your previously approved leave request details as given below." +
                                 "<br><br>Now,You should delete this cancelled request in order to file another request." +
                                 "<br><br> To view the status update on this request or file a new request, please go to <a href id=a1 runat=server href=" + HRSystemLink + ">" + FromAddressDisplayName + "</a>" +
                                 "<br><br><u><b>Leave Request Details</b></u>" +
                                 "<br><br>Leave Start Date :" + DateTime.Parse(LeaveStartDate.ToString()).ToString(@"dd/MM/yyyy") +
                                 "<br>Leave End Date :" + DateTime.Parse(LeaveEndDate.ToString()).ToString(@"dd/MM/yyyy") +
                                 "<br>Leave Type :" + LeaveType.ToString() +
                                 "<br>Statuse :" + StatusName.ToString() +
                                 "<br><br>If you have not made this request or made in error, Please contact your Local HR Administrator!." +
                                 "<br><br><br><font-size:14>THIS IS AN AUTOMATED,UNMONITORED EMAIL.PLEASE DO NOT REPLY OR FORWARD TO THIS EMAIL ADDRESS." +
                                 "</P></body></HTML>";

            try
            {
                string fromEmail = ConfigurationManager.AppSettings["FromEmail"].ToString();
                MailMessage message = new MailMessage();
                message.IsBodyHtml = true;
                message.From = new MailAddress(fromEmail, FromAddressDisplayName);
                message.Subject = subject;
                message.Body = bodycontent;

                if (EmpEmail.Trim() != "")
                {
                    message.To.Add(EmpEmail.Trim());
                }           
                SmtpClient smtp = new SmtpClient();
                smtp.Send(message);

            }
            catch (Exception exception)
            {
                this.Tab2_Message2.Visible = true;
                this.Tab2_Message2.Text = ErrorLogging.LogError(exception, "There was an error in notifying leave request for cancellation.");
                this.Tab2_Message2.CssClass = "errorMessage";

            }

        }

        #region Reset_Click
        protected void Reset_Click(object sender, EventArgs e)
        {
            empName.Text = "";
            emp_ID.Text = "";
            mgrName.Text = "";
            empStatusDDList.SelectedIndex = -1;
            jobTitleDDList.SelectedIndex = -1;
            businessUnitDDList.SelectedIndex = -1;
            DivisionLocationList.SelectedIndex = -1;

        }
        #endregion
        #region Tab2_Reset_Click
        protected void Tab2_Reset_Click(object sender, EventArgs e)
        {
            ResetFields();
            Tab2_Message2.Text = "";
            Tab2_Message2.Visible = false;
        }
        #endregion
       
        private void ResetFields()
        {
            Tab2_keyField.Text = "0";
            Tab2_LeavePeriodList.SelectedIndex = -1;
            Tab2_Message.Visible = false;
            Tab2_EmptyRow.Visible = false;
            Attendance_Month.Text = "0";
            Tab1_keyField.Text = "0";
            Tab1_StartDate.Text = "";
            Tab1_EndDate.Text = "";
            Tab1_Message.Visible = false;
            Tab1_ShiftTypeList.SelectedIndex = -1;
            Tab2_ApproverComments.Text = "";
        }

        private void TabSettings()
        {
            message.Visible = false;
            Tab1_Pane.Visible = false;
            Tab2_Pane.Visible = false;
            Tab3_Pane.Visible = false;
     
        }
        protected void tab1_Click(object sender, EventArgs e)
        {
            TabSettings();
            Tab1_Pane.Visible = true;
            
        }
        protected void tab2_Click(object sender, EventArgs e)
        {
            TabSettings();
            Tab2_Pane.Visible = true;
        }
        protected void tab3_Click(object sender, EventArgs e)
        {
            TabSettings();
            Tab3_Pane.Visible = true;

       
        }
        protected void tab4_Click(object sender, EventArgs e)
        {
            TabSettings();
     //       LoadEContactList();
//            Tab4_Pane.Visible = true;
  //          ECmessage.Text = "";
            // ResetEContactFields();

        }


        protected void AssignShift_Save_Click(object sender, EventArgs e)
        {

            try
            {
                if (Page.IsValid == true)
                {
                    if ( Tab1_keyField.Text.ToString()== "" ) {Tab1_keyField.Text ="0";}
                    String Result = DatabaseManager.Data.DBAccessManager.
                        AddUpdateEmpShiftAssigment(Convert.ToInt32(Tab1_keyField.Text), Int32.Parse(keyField.Text.ToString()), 
                        Int32.Parse(Tab1_ShiftTypeList.SelectedValue), ConvertDMY_MDY(Tab1_StartDate), ConvertDMY_MDY(Tab1_EndDate), EmpId);
                    this.Tab1_Message.Visible = true;
                    this.Tab1_Message.CssClass = "errorMessage";
                    if (Result == "")
                    {
                        this.Tab1_Message.Text = "Successfully saved.";
                        ResetTab1();
                    }
                    else
                    {
                        this.Tab1_Message.Text = Result;
                      
                    }                   
                }
              
            }
            catch (Exception exception)
            {
                Tab1_Message.Visible = true;
                Tab1_Message.Text = ErrorLogging.LogError(exception,"Unknown Exception Occured. Please contact support.");
                Tab1_Message.CssClass = "errorMessage";
            }
            LoadShiftAssignments();
        }
        protected void AssignShift_Cancel_Click(object sender, EventArgs e)
        {
            ResetTab1();

        }
 
        private void ResetTab1()
        {
            Tab1_keyField.Text = "";
            Tab1_ShiftTypeList.SelectedIndex = -1;
            Tab1_StartDate.Text = "";
            Tab1_EndDate.Text = "";
            Tab1_Message.Visible = false;

        }
        private void DeleteShiftAssignment(Int32 EntitlementID)
        {
            try
            {
                String result = DatabaseManager.Data.DBAccessManager.DeleteShiftAssignment(EntitlementID, Int32.Parse(keyField.Text.ToString()));

                if (result != "")
                {
                    Tab1_Message.Text = "Error:Could not delete the record. Please check the data";
                    Tab1_Message.CssClass = "errorMessage";
                }
            }
            catch (Exception exception)
            {
                Tab1_Message.Text = ErrorLogging.LogError(exception, "Unknown Exception Occured.Please contact Support.");
                Tab1_Message.CssClass = "errorMessage";
            }
            EGrid.CurrentPageIndex = 0;
            LoadShiftAssignments();
            ResetTab1();

        }
        private void DeleteLeaveRequest(Int32 LeaveRequestID)
        {
            try
            {
                String result = DatabaseManager.Data.DBAccessManager.DeleteLeaveRequest(LeaveRequestID, Int32.Parse(keyField.Text.ToString()));

                if (result != "")
                {
                    Tab2_Message.Visible = true;
                    Tab2_Message.Text = result;
                    Tab2_Message.CssClass = "errorMessage";

                }
            }
            catch (Exception exception)
            {
                Tab2_Message.Visible = true;
                Tab2_Message.Text = ErrorLogging.LogError(exception, "Unknown Exception Occured.Please contact Support.");
                Tab2_Message.CssClass = "errorMessage";

            }
            LGrid.CurrentPageIndex = 0;
            LoadLeaveRequestList();

        }
        protected void Search_Click(object sender, EventArgs e)
        {

            SetViewState(null);
            LoadDataList();


        }

        //This is invoked when the grid column is Clicked for Sorting, 
        //Clicking again will Toggle Descending/Ascending through the Sort Expression
        protected void Grid_SortCommand(object sender, DataGridSortCommandEventArgs e)
        {
            DataSet myDataSet = GetViewState();
            DataTable myDataTable = myDataSet.Tables[0];
            GridViewSortExpression = e.SortExpression;
            //Gets the Pageindex of the GridView.
            int iPageIndex = Grid.CurrentPageIndex;
            DataView _dataView = SortDataTable(myDataTable, false);
            Grid.DataSource = _dataView;
            Grid.DataBind();
            Grid.CurrentPageIndex = iPageIndex;
            // Rebind the sorted data into ViewState
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            dt = _dataView.ToTable();
            ds.Merge(dt);
            SetViewState(ds);
        }
                

        protected void Grid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            DataSet myDataSet = GetViewState();
            DataTable myDataTable = myDataSet.Tables[0];
            DataView _dataView = SortDataTable(myDataTable, true);
            Grid.DataSource = _dataView;
            Grid.CurrentPageIndex = e.NewPageIndex;
            Grid.DataBind();
            // Rebind the sorted data into ViewState
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            dt = _dataView.ToTable();
            ds.Merge(dt);
            SetViewState(ds);

            
           // Grid.CurrentPageIndex = e.NewPageIndex;
           // LoadDataList(); 
        }
        protected void Grid_EditCommand(object source, DataGridCommandEventArgs e)
        {

            this.keyField.Text = Grid.DataKeys[e.Item.ItemIndex].ToString();
            Grid.EditItemIndex = e.Item.ItemIndex;
            this.EmpSearchBox.Visible = false;
            this.searchDataArea.Visible = false;
            this.EditArea.Visible = true;
            this.Tab1_Pane.Visible = true;
            LoadKeyEmployeeInformation(Int32.Parse(this.keyField.Text));
            LoadShiftAssignments();
            LoadShiftListByEmpID(Tab1_ShiftTypeList, Int32.Parse(keyField.Text.ToString()));

        }

        protected void LoadKeyEmployeeInformation(Int32 EmpId)
        {
            DataSet _DataList = null;
            _DataList = DatabaseManager.Data.DBAccessManager.RetrieveKeyEmpInfo(EmpId);
            if (_DataList.Tables.Count > 0)
            {
                DataRow _DataRow = _DataList.Tables[0].Rows[0];
                lblEmployeeName.Text = _DataRow["F_Name"].ToString() + " " + _DataRow["Mid_Initial"].ToString() + " " + _DataRow["L_Name"].ToString();
                lblJobTitle.Text = _DataRow["Designation"].ToString();
                lblJobLocation.Text = _DataRow["Work_City"].ToString() + "/" + _DataRow["CountryName"].ToString();
                lblWorkPhone.Text = _DataRow["Work_Phone"].ToString() + "(W)";
                lblMobile.Text = _DataRow["Mobile_Phone"].ToString() + "(M)";
                lblEmailAddress.Text = _DataRow["Work_Email"].ToString();
                //lblSuperVisorName.Text = _DataRow["LineManager"].ToString();
                lblSuperVisorName.Text = _DataRow["SupervisorName"].ToString();
                lblSuperVisor_Phone.Text = _DataRow["Supervisor_Phone"].ToString();
                lblSuperVisor_EmailAddress.Text = _DataRow["Supervisor_Email"].ToString();
                lblDivision.Text = _DataRow["DivisionName"].ToString();
                lblDivisionLocation.Text = _DataRow["DivisionLocationName"].ToString();
                lblSuperVisor_JobLocation.Text = _DataRow["Supervisor_WorkLocation"].ToString();
                lblSuperVisor_JobTitle.Text = _DataRow["Supervisor_Designation"].ToString();
                lblSuperVisor_Division.Text = _DataRow["Supervisor_Division"].ToString();
                lblSuperVisor_DivisionLocation.Text = _DataRow["Supervisor_BULocation"].ToString();


                if (_DataRow["Photo_Path"].ToString() != "")
                {
                    this.profile.ImageUrl = Page.ResolveUrl("~\\PhotoProfiles\\" + _DataRow["Photo_Path"].ToString());

                }
                else
                {
                    this.profile.ImageUrl = Page.ResolveUrl("~\\PhotoProfiles\\" + "d_Photo.jpg");
                }

            }


        }

        protected void Grid_CancelCommand(object source, DataGridCommandEventArgs e)
        {
            Grid.EditItemIndex = -1;
           // LoadDataList();
        }
        protected void Grid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
      
        }
        protected void Grid_UpdateCommand(object source, DataGridCommandEventArgs e)
        {
   
        }
        protected void EGrid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            EGrid.CurrentPageIndex = e.NewPageIndex;
            LoadShiftAssignments();
        }
        protected void EGrid_EditCommand(object source, DataGridCommandEventArgs e)
        {
            this.Tab1_keyField.Text = EGrid.DataKeys[e.Item.ItemIndex].ToString();
            LoadShiftListByEmpID(Tab1_ShiftTypeList, Int32.Parse(keyField.Text.ToString()));  
            EGrid.EditItemIndex = -1;           
        
            DataSet _DataList = null;
            _DataList = DatabaseManager.Data.DBAccessManager.RetrieveShiftAssignmentInfo(Int32.Parse(Tab1_keyField.Text.ToString()));
            if (_DataList.Tables.Count > 0)
            {
                if (_DataList.Tables[0].Rows.Count > 0) // Leave Entitlement Information.
                {
                    DataRow _DataRow = _DataList.Tables[0].Rows[0];
                    if (_DataRow["ShiftID"].ToString() != "")
                    {
                        Tab1_ShiftTypeList.SelectedValue = _DataRow["ShiftID"].ToString();
                    }

                    Tab1_StartDate.Text = _DataRow["ShiftStartDate"].ToString();
                    Tab1_EndDate.Text = _DataRow["ShiftEndDate"].ToString();
                }
            }

        }
        protected void EGrid_CancelCommand(object source, DataGridCommandEventArgs e)
        {
            EGrid.EditItemIndex = -1;
            // LoadDataList();
        }
        protected void EGrid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            int EmpShiftID = (int)EGrid.DataKeys[(int)e.Item.ItemIndex];
            EGrid.EditItemIndex = -1;
            DeleteShiftAssignment(EmpShiftID);
            ResetFields();
       
        }
        protected void EGrid_UpdateCommand(object source, DataGridCommandEventArgs e)
        {

        }

        protected void LGrid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            LGrid.CurrentPageIndex = e.NewPageIndex;
            LoadLeaveRequestList();
        }
       
        protected void ALGrid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            AttendanceGrid.CurrentPageIndex = e.NewPageIndex;
            LoadLeaveRequestList();
        }
        
         protected void LGrid_EditCommand(object source, DataGridCommandEventArgs e)
        {
        /*    Tab2_keyField.Text = LGrid.DataKeys[e.Item.ItemIndex].ToString();
            String Status = EmptyString(e.Item.Cells[7].Text);
            if (Status == "Approved")
            {
                Tab2_EmpName.Text = EmptyString(e.Item.Cells[0].Text);
                Tab2_StartDate.Text = EmptyString(e.Item.Cells[1].Text);
                Tab2_EndDate.Text = EmptyString(e.Item.Cells[2].Text);
                if (EmptyString(e.Item.Cells[3].Text) != "")
                {
                    Tab2_LeaveTypeList.SelectedValue = Tab3_LeaveTypeList.Items.FindByText(e.Item.Cells[3].Text).Value;
                }

                if (EmptyString(e.Item.Cells[4].Text) == "Paid") { Tab2_Rb1_PayType1.Checked = true; } else { Tab2_Rb1_PayType1.Checked = false; }
                if (EmptyString(e.Item.Cells[4].Text) == "Unpaid") { Tab2_Rb1_PayType2.Checked = true; } else { Tab2_Rb1_PayType2.Checked = false; }

                Tab2_Comments.Text = EmptyString(e.Item.Cells[6].Text);
                Tab2_ApprRB1.Checked = true;
                Tab2_ApprRB2.Checked = false;
                Tab2_ApprRB1.Enabled = false;
                Tab2_ApprRB2.Enabled = false;


            }
            else
            {
                TableCell delete = (TableCell)e.Item.Controls[8];
                delete.Enabled = false;
                this.Tab2_Message2.Text = "This can not be deleted at this stage.";
                this.Tab2_Message2.Visible = true;
                this.Tab2_Message2.CssClass = "errorMessage";

            }
         */ 
        }
     
    }
}
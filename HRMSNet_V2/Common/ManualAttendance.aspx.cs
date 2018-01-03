using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
//using System.Web.Mail;
using System.Net.Mail;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using PresentationManager.Web.UI.MasterPages;

namespace SchoolNet
{
    public partial class ManualAttendance : SchoolNetBase
    {
        public int EmpId;

        protected void Page_Load(object sender, EventArgs e)
        {
            EmpId = Int32.Parse(Page.User.Identity.Name.ToString());
            if (!Page.IsPostBack)
            {
                LoadMAReasonTypeLookup(Tab1_ReasonTypeList);
            }
            LoadMAPunchRequests();
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
            ManualPunch_Save.Click += new EventHandler(ManualPunch_Save_Click);
            Reset.Click += new EventHandler(Reset_Click);

        }
        #endregion
        #region LoadMAPunchRequests();
        private void LoadMAPunchRequests()
        {
             DataSet _DataList = null;
            _DataList = DatabaseManager.Data.DBAccessManager.RetrieveMAPunchRequests(EmpId);

            if (_DataList.Tables[0].Rows.Count > 0)
            {
               this.Grid.DataSource = _DataList;
               this.Grid.DataBind();            
            }
            else
            {
                this.Grid.DataSource = null;
                this.Grid.DataBind(); 
            }

        }
        #endregion

        #region ManualPunch_Save_Click
        protected void ManualPunch_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid == true)  // Change requestStatusType to be dynamic, currently 1=submitted.
                {
                    Hmessage.Visible = true;
                    Hmessage.CssClass = "errorMessage";

                    if (Tab1_keyField.Text.ToString() == "") { Tab1_keyField.Text = "0"; }

                    DataSet _DataList = null;
                    _DataList = DatabaseManager.Data.DBAccessManager.AddUpdateMAPunchRequest(Convert.ToInt32(Tab1_keyField.Text), EmpId,
                        ConvertDMY_MDY(Tab1_PunchingDate), Tab1_PunchInTime.Text, Tab1_PunchOutTime.Text, Int32.Parse(Tab1_ReasonTypeList.SelectedValue), 
                        Tab1_Comments.Text);
                    if (_DataList.Tables[0].Rows.Count > 0)
                    {
                        String Result, HRAdminName,HRAdminEmail,LineManagerName, LineManagerEmail, DeptHeadName, DeptHeadEmail, EmpName, EmpEmail, LeaveTypeName;
                        DataRow _DataRow = _DataList.Tables[0].Rows[0];
                        Result = _DataRow["Result"].ToString();

                        if (Result == "")
                        {
                            LineManagerName = _DataRow["LineManagerName"].ToString();
                            LineManagerEmail = _DataRow["LineManagerEmail"].ToString();
                            HRAdminName = _DataRow["HRAdminName"].ToString();
                            HRAdminEmail = _DataRow["HRAdminEmail"].ToString();
                            DeptHeadName = _DataRow["DeptHeadName"].ToString();
                            DeptHeadEmail = _DataRow["DeptHeadEmail"].ToString();
                            EmpName = _DataRow["EmpName"].ToString();
                            EmpEmail = _DataRow["EmpEmail"].ToString();
                            LeaveTypeName = _DataRow["LeaveTypeName"].ToString();
                            String PunchingDate = ConvertDMY_MDY(Tab1_PunchingDate);
                            String PunchInTime = Tab1_PunchInTime.Text.ToString();
                            String PunchOutTime = Tab1_PunchOutTime.Text.ToString();                    
                            
                            if ((LineManagerEmail != "") || (DeptHeadEmail != "") || (HRAdminEmail !="")) // Notify via Email if Email was used as a user Name                                           
                            {
                            //    NotifyApproversViaEmail(EmpName, EmpEmail, LeaveStartDate, LeaveEndDate, LeaveTypeName, LineManagerName, LineManagerEmail, DeptHeadName, DeptHeadEmail,HRAdminName,HRAdminEmail);

                            }
                            ResetFields();

                        }
                        else
                        {
                            this.Hmessage.Text = Result;
                            this.Hmessage.CssClass = "errorMessage";

                        }
                    }
                }
                else
                {
                    this.Hmessage.Text = "Error:Could not save the information. Please check the inputs";
                    this.Hmessage.CssClass = "errorMessage";
                }
                LoadMAPunchRequests();// Refresh the grid

            }
            catch (Exception exception)
            {
                this.Hmessage.Visible = true;
                this.Hmessage.Text = ErrorLogging.LogError(exception, "Unknown Exception Occured.Please contact Support.");
                this.Hmessage.CssClass = "errorMessage";
            }
        }
        #endregion

        private void NotifyApproversViaEmail(String EmpName, String EmpEmail, String LeaveStartDate, String LeaveEndDate, String LeaveType, String LineManagerName, String LineManagerEmail, String DeptHeadName, String DeptHeadEmail,String HRAdminName,String HRAdminEmail)
        {

            string HRSystemLink = ConfigurationManager.AppSettings["HRSystemURL"].ToString();
            string FromAddressDisplayName = ConfigurationManager.AppSettings["FromEmailDisplayName"].ToString();

            string subject = "Ark HRMS Alerting Service:Leave Request from " + EmpName + " Awaiting Approval";

            string bodycontent = "<html><body leftmargin=10 style=\"font-family: Arial;font-size:11\">" +
                                 "<P><br> Hello "+LineManagerName +","+
                                 "<br><br> You have received leave request from " + EmpName + " for approval."+
                                 "<br><br> To approve or reject this leave request, Please click 'Requests Inbox' after login into <a href id=a1 runat=server href="+HRSystemLink+">"+FromAddressDisplayName+ "</a>" +
                                 "<br><br><u><b>Leave Request Details</b></u>"+
                                 "<br><br>Leave Start Date :"+ DateTime.Parse(LeaveStartDate.ToString()).ToString(@"dd/MM/yyyy")+
                                 "<br>Leave End Date :"+ DateTime.Parse(LeaveEndDate.ToString()).ToString(@"dd/MM/yyyy")+
                                 "<br>Leave Type :"+ LeaveType.ToString()+
                                 "<br><br><br><font-size:14>THIS IS AN AUTOMATED,UNMONITORED EMAIL.PLEASE DO NOT REPLY OR FORWARD TO THIS EMAIL ADDRESS."+
                                 "</P></body></HTML>";

            
               try
               {
                   string fromEmail = ConfigurationManager.AppSettings["FromEmail"].ToString();
                   MailMessage message = new MailMessage();
                   message.IsBodyHtml = true;
                   message.From = new MailAddress(fromEmail, FromAddressDisplayName);

                   if (LineManagerEmail.Trim() != "")
                   {
                       message.To.Add(LineManagerEmail.Trim());
                   }                                   

                   message.Subject = subject;
                   message.Body = bodycontent;

                   // Add a carbon copy recipient.
                   if (DeptHeadEmail.Trim() != "")
                   {
                       message.CC.Add(DeptHeadEmail.Trim());
                   }

                   if (HRAdminEmail.Trim() != "")
                   {
                       message.CC.Add(HRAdminEmail.Trim());
                   }
                   if (EmpEmail.Trim() != "")
                   {
                       MailAddress copy = new MailAddress(EmpEmail);
                       message.CC.Add(copy);
                   }
                   SmtpClient smtp = new SmtpClient();
                   smtp.Send(message);

               }
               catch (Exception exception)
               {
                   this.Hmessage.Visible = true;
                   this.Hmessage.Text = ErrorLogging.LogError(exception,"There was an error in notifying leave request for approval.");
                   this.Hmessage.CssClass = "errorMessage";
               }
        }


        #region Reset_Click
        protected void Reset_Click(object sender, EventArgs e)
        {
            ResetFields();
            Hmessage.Visible = false;
            emptyRow.Visible = false;
        }
         #endregion
        private void ResetFields()
        {
            Tab1_keyField.Text = "0";
            Tab1_PunchingDate.Text = "";
            Tab1_PunchInTime.Text = "";
            Tab1_PunchOutTime.Text = "";
            Tab1_Comments.Text = "";
            Tab1_ReasonTypeList.SelectedIndex = -1;
            Hmessage.Visible = false;
            emptyRow.Visible = false;
            Tab1_Request_Log.InnerHtml = "";
        }
        private void DeleteMAPunchRequest(Int32 MAPunchID)
        {
            try
            {
                String result = DatabaseManager.Data.DBAccessManager.DeleteMAPunchRequest(MAPunchID, EmpId);

                if (result == "")
                {
                    this.Hmessage.Text = "Successfully deleted.";
                    this.Hmessage.CssClass = "errorMessage";
                }
                else
                {
                    this.Hmessage.Text = "Error:Could not delete the leave request. Please check the inputs";
                    this.Hmessage.CssClass = "errorMessage";

                }
            }
            catch (Exception exception)
            {
                this.Hmessage.Text = ErrorLogging.LogError(exception, "Unknown Exception Occured.Please contact Support.");
                this.Hmessage.CssClass = "errorMessage";

            }
            Grid.CurrentPageIndex = 0;
            LoadMAPunchRequests();
            ResetFields();

        }

        protected void Grid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            Grid.CurrentPageIndex = e.NewPageIndex;
            LoadMAPunchRequests();
        }
        protected void Grid_EditCommand(object source, DataGridCommandEventArgs e)
        {
            this.Hmessage.Text = "";
            this.Hmessage.Visible = false;
            this.Tab1_keyField.Text = Grid.DataKeys[e.Item.ItemIndex].ToString();
           // Disable rows if the status is other than 'submitted'
            String Status = EmptyString(e.Item.Cells[5].Text);
            if ((Status == "Submitted") || (Status == "Rejected"))
            {
                Tab1_PunchingDate.Text = EmptyString(e.Item.Cells[0].Text);
                Tab1_PunchInTime.Text = EmptyString(e.Item.Cells[1].Text);
                Tab1_PunchOutTime.Text = EmptyString(e.Item.Cells[2].Text);
                if (EmptyString(e.Item.Cells[3].Text) != "")
                {
                    Tab1_ReasonTypeList.SelectedValue = Tab1_ReasonTypeList.Items.FindByText(e.Item.Cells[3].Text).Value;
                }
                Tab1_Comments.Text = "";
                Tab1_Request_Log.InnerHtml = EmptyString(e.Item.Cells[4].Text).ToString();
            }
            else
            {
                TableCell edit = (TableCell)e.Item.Controls[7];
                edit.Enabled = false;
                this.Hmessage.Text = "This can not be edited at this stage.";
                this.Hmessage.Visible = true;
                this.Hmessage.CssClass = "errorMessage";
            }
        }

        protected void Grid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            int MAPunchID = (int)Grid.DataKeys[(int)e.Item.ItemIndex];
            String Status = EmptyString(e.Item.Cells[5].Text);
            if ((Status == "Submitted") || (Status == "Rejected") || (Status == "Cancelled"))
            { 
                DeleteMAPunchRequest(MAPunchID); 
            }
            else
            {
               TableCell delete = (TableCell)e.Item.Controls[7];
               delete.Enabled = false;
               this.Hmessage.Text = "This can not be edited/deleted at this stage.";
               this.Hmessage.Visible = true;
               this.Hmessage.CssClass = "errorMessage";

            }
            
        }

    }
}
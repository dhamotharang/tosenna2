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
    public partial class PendingLeaveRequests : SchoolNetBase
    {
        public int EmpId;
        protected void Page_Load(object sender, EventArgs e)
        {
            EmpId = Int32.Parse(Page.User.Identity.Name.ToString());
            if (!Page.IsPostBack)
            {
                LoadLeaveTypeLookup(Tab3_LeaveTypeList);
            }
            
            LoadPendingLeaveRequestList();

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

            ALGrid.PageIndexChanged += new DataGridPageChangedEventHandler(ALGrid_PageIndexChanged);
            Tab3_Approve.Click += new EventHandler(Tab3_Approve_Click);
            Tab3_Reset.Click +=new EventHandler(Tab3_Reset_Click);

        }
        #endregion
  
        #region LoadPendingLeaveRequestList();
        private void LoadPendingLeaveRequestList()
        {
            DataSet _DataList = null;
            _DataList = DatabaseManager.Data.DBAccessManager.RetrieveLeaveRequests_Approval(EmpId);

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
            }
        }
        #endregion

        #region Tab3_Approve_Click
        protected void Tab3_Approve_Click(object sender, EventArgs e)
        {

            try
            {
                if (Page.IsValid == true)
                {
                    Int32 Approval = 0; Int32 LeavePayType = 1;
                    Int32 HR_Approval_Id = 0;
                    if (Tab3_keyField.Text.ToString() == "") { Tab3_keyField.Text = "0"; }
                    if (Tab3_ApprRB1.Checked) { Approval = 1; }
                    if (Tab3_ApprRB2.Checked) { Approval = 0; }

                    if (Tab3_Rb1_PayType1.Checked) { LeavePayType = 1; }
                    if (Tab3_Rb1_PayType2.Checked) { LeavePayType = 0; }

                    DataSet _DataList = null;
                    _DataList = DatabaseManager.Data.DBAccessManager.Appprove_LeaveRequest(Convert.ToInt32(Tab3_keyField.Text),-1, Tab3_ApproverComments.Text.ToString(), LeavePayType, Approval, EmpId);
                    if (_DataList.Tables[0].Rows.Count > 0)
                    {
                        String Result, LineManagerName, LineManagerEmail, EmpName, EmpEmail, LeaveType, LeaveStartDate, LeaveEndDate, StatusName;
                        DataRow _DataRow = _DataList.Tables[0].Rows[0];
                        Result = _DataRow["Result"].ToString();
                        if (Result == "")
                        {
                            LineManagerName = _DataRow["ApproverName"].ToString();
                            LineManagerEmail = _DataRow["ApproverEmail"].ToString();
                            EmpName = _DataRow["EmpName"].ToString();
                            EmpEmail = _DataRow["EmpEmail"].ToString();
                            LeaveStartDate = _DataRow["LeaveDate"].ToString();
                            LeaveEndDate = _DataRow["LeaveEndDate"].ToString();
                            LeaveType = _DataRow["LeaveType"].ToString();
                            StatusName = _DataRow["StatusName"].ToString();


                            if ((LineManagerEmail != "") && (EmpEmail != "")) // Notify via Email if Email was used as a user Name                                           
                            {
                                LeaveRequestApproval_Notification(EmpName, EmpEmail, LeaveStartDate, LeaveEndDate, LeaveType, StatusName, LineManagerName, LineManagerEmail);

                            }

                            ResetFields();

                        }
                        else
                        {
                            Tab3_Message.Visible = true;
                            Tab3_Message.Text = Result;
                            Tab3_Message.CssClass = "errorMessage";

                        }
                    }
                }
                else
                {
                    Tab3_Message.Visible = true;
                    Tab3_Message.Text = "Error:Could not save the information. Please check the inputs";
                    Tab3_Message.CssClass = "errorMessage";
                }
                LoadPendingLeaveRequestList();// Refresh the grid

            }
            catch (Exception exception)
            {
                Tab3_Message.Visible = true;
                Tab3_Message.Text = ErrorLogging.LogError(exception,"Unknown Exception Occured. Please contact support.");
                Tab3_Message.CssClass = "errorMessage";
            }
        }
        #endregion

        private void LeaveRequestApproval_Notification(String EmpName, String EmpEmail, String LeaveStartDate, String LeaveEndDate, String LeaveType, String StatusName, String LineManagerName, String LineManagerEmail)
        {

            string HRSystemLink = ConfigurationManager.AppSettings["HRSystemURL"].ToString();
            string FromAddressDisplayName = ConfigurationManager.AppSettings["FromEmailDisplayName"].ToString();

            string subject = "Ark HRMS Alerting Service:Leave Request Approval Status for " + EmpName;

            string bodycontent = "<html><body leftmargin=10 style=\"font-family: Arial;font-size:11\">" +
                                 "<P><br> Hello " + EmpName + "," +
                                 "<br><br> Your Leave request as given below has been <b><u>"+StatusName+"</u></b> by " + LineManagerName +
                                 "<br><br> To view the status update on your leave request, please login into <a href id=a1 runat=server href=" + HRSystemLink + ">" + FromAddressDisplayName + "</a>" +
                                 "<br><br><u><b>Leave Request Details</b></u>" +
                                 "<br><br>Leave Start Date :" + DateTime.Parse(LeaveStartDate.ToString()).ToString(@"dd/MM/yyyy") +
                                 "<br>Leave End Date :" + DateTime.Parse(LeaveEndDate.ToString()).ToString(@"dd/MM/yyyy") +
                                 "<br>Leave Type :" + LeaveType.ToString() +
                                 "<br><br><br><font-size:14>THIS IS AN AUTOMATED,UNMONITORED EMAIL.PLEASE DO NOT REPLY OR FORWARD TO THIS EMAIL ADDRESS." +
                                 "</P></body></HTML>";           
            try
            {
                string fromEmail = ConfigurationManager.AppSettings["FromEmail"].ToString();
                MailMessage message = new MailMessage();
                message.IsBodyHtml = true;
                message.From = new MailAddress(fromEmail, FromAddressDisplayName);
                if (EmpEmail.Trim() != "")
                {
                    message.To.Add(EmpEmail.Trim());
                }

                message.Subject = subject;
                message.Body = bodycontent;
                // Add a carbon copy recipient.
                if (LineManagerEmail.Trim() != "")
                {
                    MailAddress copy = new MailAddress(LineManagerEmail);
                    message.CC.Add(copy);
                }
                SmtpClient smtp = new SmtpClient();
                smtp.Send(message);

            }
            catch (Exception ex)
            {
                this.Tab3_Message.Visible = true;
                this.Tab3_Message.Text =ErrorLogging.LogError(ex, "There was an error in notifying leave request for approval.");
                this.Tab3_Message.CssClass = "errorMessage";
                return;

            }

        }



        #region Tab3_Reset_Click
        protected void Tab3_Reset_Click(object sender, EventArgs e)
        {
            ResetFields();
        }
        #endregion

        private void ResetFields()
        {
            Tab3_Comments.Text = "";
            Tab3_StartDate.Text = "";
            Tab3_EndDate.Text = "";
            Tab3_keyField.Text = "";
            Tab3_Message.Text = "";
            Tab3_LeaveTypeList.SelectedIndex = -1;
            Tab3_EmpName.Text = "";
            Tab3_Message.Visible = false;
            Tab3_EmptyRow.Visible = false;
            Tab3_ApproverComments.Text = "";
            Tab3_ApprRB1.Checked = true;
            Tab3_ApprRB2.Checked = false;
        }








       protected void ALGrid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            ALGrid.CurrentPageIndex = e.NewPageIndex;
            LoadPendingLeaveRequestList();
        }
        protected void ALGrid_EditCommand(object source, DataGridCommandEventArgs e)
        {

            Tab3_keyField.Text = ALGrid.DataKeys[e.Item.ItemIndex].ToString();
            Tab3_EmpName.Text = EmptyString(e.Item.Cells[0].Text);
            Tab3_StartDate.Text = EmptyString(e.Item.Cells[1].Text);
            Tab3_EndDate.Text = EmptyString(e.Item.Cells[2].Text);
            if (EmptyString(e.Item.Cells[4].Text) != "")
            {
                Tab3_LeaveTypeList.SelectedValue = Tab3_LeaveTypeList.Items.FindByText(e.Item.Cells[4].Text).Value;
            }

            if (EmptyString(e.Item.Cells[5].Text) == "Paid") { Tab3_Rb1_PayType1.Checked = true; } else { Tab3_Rb1_PayType1.Checked = false; }
            if (EmptyString(e.Item.Cells[5].Text) == "Unpaid") { Tab3_Rb1_PayType2.Checked = true; } else { Tab3_Rb1_PayType2.Checked = false; }

            Tab3_Comments.Text = EmptyString(e.Item.Cells[6].Text);
            Tab3_ApproverComments.Text = EmptyString(e.Item.Cells[7].Text);

        }



    }
}
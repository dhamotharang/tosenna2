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
    public partial class ReactivateEmployee : SchoolNetBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadBasicEmployeeInformation();

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
            Reactivate_Employee.Click += new EventHandler(Reactivate_Employee_Click);
            Cancel.Click += new EventHandler(Cancel_Click);

        }
        #endregion

        private void LoadBasicEmployeeInformation()
        {
            if (Tab1_EmployeeID.Text != "")
            {
                DataSet _DataList = null;
                _DataList = DatabaseManager.Data.DBAccessManager.RetrieveKeyEmpInformation(Tab1_EmployeeID.Text.ToString());
                if (_DataList.Tables[0].Rows.Count > 0)
                {
                    DataRow _DataRow = _DataList.Tables[0].Rows[0];
                    Tab1_EmployeeName.Text = _DataRow["EmployeeName"].ToString();
                    Tab1_EmpStatusName.Text = _DataRow["EmpStatusName"].ToString();
                    Tab1_HireDateLbl.Text = _DataRow["HireDate"].ToString();
                }
                else
                {
                    this.message.CssClass = "errorMessage";
                    this.message.Visible = true;
                    this.message.Text = "The selected employee ID does not exist in the system";
                }
            }
        }


        protected void Reactivate_Employee_Click(object sender, EventArgs e)
        {
            try
            {
                this.message.CssClass = "errorMessage";
                this.message.Visible = true;
                if (Page.IsValid == true)
                {
                    DataSet _DataList = null;
                    _DataList = DatabaseManager.Data.DBAccessManager.ReactivateEmployee(Tab1_EmployeeID.Text.ToString(), Int32.Parse(Page.User.Identity.Name.ToString()));
                    if (_DataList.Tables[0].Rows.Count > 0)
                    {
                        String Result, EmployeeName, EmpEmail, Password;
                        DataRow _DataRow = _DataList.Tables[0].Rows[0];
                        Result = _DataRow["Result"].ToString();


                        if (Result == "")
                        {
                            EmployeeName = _DataRow["EmployeeName"].ToString();
                            EmpEmail = _DataRow["EmpEmail"].ToString();
                            Password = SchoolNetBase.DecodeFrom64(_DataRow["EmpPwd"].ToString());
                            if (EmpEmail != "")
                            {
                                EmployeePasswordResetNotification(EmployeeName, EmpEmail, Password);
                            }

                            this.message.Text = "Employee Profile has been successfully reactivated from HRM system.";
                            ResetFields();

                        }
                        else
                        {
                            this.message.Text = Result;
                        }
                    }
                }
                else
                {
                    this.message.Text = "Error:Could not save the information. Please check the inputs";
                }

            }
            catch (Exception exception)
            {
                this.message.Visible = true;
                this.message.Text = ErrorLogging.LogError(exception, "Unknown Exception Occured. Please contact support.");
                this.message.CssClass = "errorMessage";
            }
        }


        private void EmployeePasswordResetNotification(string employeeName,string uName,string Password)
        {
            string HRSystemLink = ConfigurationManager.AppSettings["HRSystemURL"].ToString();
            string FromAddressDisplayName = ConfigurationManager.AppSettings["FromEmailDisplayName"].ToString();

            string subject = "Ark HRMS Alerting Service:Password Reset Notification " + employeeName;

            string bodycontent = "<html><body leftmargin=10 style=\"font-family: Arial;font-size:11\">" +
                                 "<P><br> Hello " + employeeName + "," +
                                "<br><br>You have received this email  because your HRM system login password has been reset as below due to the reactivation of your employee profile in the system by your HR administrator." +
                                "<br>In case you have any questions about this notification, Please contact your HR administrator" +
                                "<br><br>Your UserName/Email Address : " + uName +
                                "<br>Password : " + Password +
                                "<br><br>You may want to change your password once logged in and note down your login credentials for future access." +
                                "<br><br><br><font-size:14>THIS IS AN AUTOMATED,UNMONITORED EMAIL.PLEASE DO NOT REPLY OR FORWARD TO THIS EMAIL ADDRESS." +
                                "</P></body></HTML>";           
            try
            {
                string fromEmail = ConfigurationManager.AppSettings["FromEmail"].ToString();
                MailMessage message = new MailMessage();
                message.IsBodyHtml = true;
                message.From = new MailAddress(fromEmail, FromAddressDisplayName);

                if (uName.Trim() != "")
                {
                    message.To.Add(uName.Trim());
                }

                message.Subject = subject;
                message.Body = bodycontent;

                SmtpClient smtp = new SmtpClient();
                smtp.Send(message);
                this.message.Visible = true;
                this.message.Text = "Your login credentials have been sent to your work email account on our system.";
                this.message.CssClass = "errorMessage";

            }
            catch (Exception exception)
            {
                this.message.Visible = true;
                this.message.Text = ErrorLogging.LogError(exception, "There was an error in sending email notification.");
                this.message.CssClass = "errorMessage";

            }
        }


        protected void Cancel_Click(object sender, EventArgs e)
        {
            ResetFields();
            message.Text = "";
            message.Visible = false;
        }

        private void ResetFields()
        {
            Tab1_EmployeeID.Text = "";
            Tab1_EmployeeName.Text = "";
            Tab1_EmpStatusName.Text = "";
            Tab1_HireDateLbl.Text = "";
        }

    }
}

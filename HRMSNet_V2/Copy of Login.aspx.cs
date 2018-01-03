using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net.Mail;
using PresentationManager.Web.UI.MasterPages;
using DatabaseManager.Data;

namespace SchoolNet
{
    public partial class Login : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies[".ARKAUTH"] != null)
                {
                    RedirectBasedonRole();
                }          
      
            }
            
            
            if (ChangePassword.Visible)
            {
                Login_Pane.Visible = false;
                Account_Signup.Visible = false;
                Tab3_Pane.Visible = false;
                this.HyperLink1.Visible = false;
                ChangePassword.Visible = true;
            }
            else
            {
                Login_Pane.Visible = true;
                Account_Signup.Visible = false;
                Tab3_Pane.Visible = false;
                this.HyperLink1.Visible = false;
            }

            if (Request.QueryString["id"] != null)
            {
                if (Request.QueryString["Id"].ToString() == "1")
                {
                    Login_Pane.Visible = false;
                    Account_Signup.Visible = true;
                    Tab3_Pane.Visible = false;
                    ChangePassword.Visible = false;
                    this.HyperLink1.Visible = true;


                }
                if (Request.QueryString["ID"].ToString() == "2")
                {
                    Login_Pane.Visible = false;
                    Account_Signup.Visible = false;
                    Tab3_Pane.Visible = true;
                    this.HyperLink1.Visible = true;
                    ChangePassword.Visible = false;
                }
            }

        }

        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
            //base.OnInit(e);
            this.EnableViewState = true;


        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {

            this.LoginMe.Click += new System.EventHandler(this.MemberLogin);

            this.SignMeUp.Click += new EventHandler(SignMeUp_Click);
            this.Tab3_Submit.Click += new EventHandler(Tab3_Submit_Click);
            Change_Password.Click  +=new EventHandler(Change_Password_Click);
            Cancel.Click += new EventHandler(Cancel_Click);


        }
        #endregion

        private void Change_Password_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (Tab1_password.Text.ToString() != Tab1_NewPassword.Text.ToString())
                {
                        String Result = DatabaseManager.Data.DBAccessManager.UserChangePassword(Tab1_keyField.Text.ToString().Trim(), SchoolNetBase.EncodePasswordToBase64(Tab1_password.Text.ToString()), SchoolNetBase.EncodePasswordToBase64(Tab1_NewPassword.Text.ToString()));
                        this.errorMessage.Visible = true;
                        if (Result == "")
                        {
                            Login_Pane.Visible = true;
                            ChangePassword.Visible = false;
                            this.errorMessage.Text = "";

                        }
                        else
                        {
                            this.errorMessage.Text = Result;
                            this.errorMessage.CssClass = "errorMessage";
                        }
                        
              }
            }
            catch (Exception exception)
            {

                this.errorMessage.Visible = true;
                this.errorMessage.Text = ErrorLogging.LogError(exception, "Unknown Exception Occured.Please contact Support.");
                this.errorMessage.CssClass = "errorMessage";
            }


        }
        private void SignMeUp_Click(object sender, System.EventArgs e)
        {

            try
            {
                if (Page.IsValid == true)
                {
                    String AddedBy = "Employee"; // Used to determine the RoleTypeID
                    Int32 RoleTypeID = 0;
                    Int32 DivisionID = 0;
                    Int32 LocationID = 0;
                    Int32 AccountStatus = 1; // Enabled by Default
                    string result = DBAccessManager.AccountSignUp(this.Signup_EmployeeID.Text.ToString().Trim(), Signup_UserName.Text.ToString().Trim(),SchoolNetBase.EncodePasswordToBase64(Signup_Password.Text.ToString().Trim()), RoleTypeID, DivisionID, LocationID, AccountStatus, AddedBy);

                    if (result == "")
                    {
                        this.errorMessage.Visible = true;
                        this.Signup_EmployeeID.Text = "";
                        this.Signup_UserName.Text = "";
                        this.Signup_Password.Text = "";
                        this.errorMessage.Text = "Thank you for sign up.Your account has been created. Please click the login link below to sign in.";
                        this.errorMessage.CssClass = "errorMessage";

                    }

                    else
                    {
                        this.errorMessage.Visible = true;
                        this.EmailAddress.Text = "";
                        this.Login_Password.Text = "";
                        this.errorMessage.Text = result;
                        this.errorMessage.CssClass = "errorMessage";
                    }
                }
            }
            catch (Exception exception)
            {
                this.errorMessage.Visible = true;
                this.EmailAddress.Text = "";
                this.Login_Password.Text = "";
                this.errorMessage.Text = ErrorLogging.LogError(exception, "Unknown Exception Occured.Please contact Support.");
                this.errorMessage.CssClass = "errorMessage";
            }

        }

        private void Cancel_Click(object sender, System.EventArgs e)
        {
            Signup_UserName.Text = "";
            Signup_EmployeeID.Text = "";
            errorMessage.Text = "";
            errorMessage.Visible = false;

        }
        private void MemberLogin(object sender, System.EventArgs e)
        {
            try
            {
                if (Page.IsValid == true)
                {
                    DataSet _DataList = null;
                    String userName = string.Empty;
                    String roleName = string.Empty;
                    String userEmail = string.Empty;
                    String MemberName = string.Empty;
                    String PasswordExpiry = string.Empty;
                    _DataList = DBAccessManager.ValidateLogin(this.EmailAddress.Text.ToString().Trim(), SchoolNetBase.EncodePasswordToBase64(this.Login_Password.Text.ToString().Trim()));
                    if (_DataList.Tables.Count > 0)
                    {
                        if (_DataList.Tables[0].Rows.Count > 0) // Member Login Information
                        {
                            DataRow _DataRow = _DataList.Tables[0].Rows[0];
                            userName = _DataRow["EmpId"].ToString();
                            roleName = _DataRow["RoleName"].ToString();
                            userEmail = _DataRow["Work_Email"].ToString();
                            MemberName = _DataRow["MemberName"].ToString();
                            PasswordExpiry = _DataRow["PasswordExpiry"].ToString();

                        }
                        // If the password has expired, redirect to change password screen
                        if (PasswordExpiry != "")
                        {
                            Tab1_keyField.Text = EmailAddress.Text.ToString().Trim();
                            Login_Pane.Visible = false;
                            ChangePassword.Visible = true;
                            errorMessage.Text = "";

                        }
                        else
                        {

                            DateTime expiryDate = DateTime.Now.AddMinutes(60);// Default
                            bool isPersistent = false;
                            if (login_RememberMe.Checked)
                            {
                                //clear any other tickets that are already in the response
                                Response.Cookies.Clear();
                                //set the new expiry date - to thirty days from now
                                expiryDate = DateTime.Now.AddDays(30);
                                //create a new forms auth ticket
                                isPersistent = true;

                            }
                            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, userName, DateTime.Now, expiryDate, isPersistent, roleName);
                            //encrypt the ticket
                            String encryptedTicket = FormsAuthentication.Encrypt(ticket);
                            //create a new authentication cookie - and set its expiration date
                            HttpCookie authenticationCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                            authenticationCookie.Expires = ticket.Expiration;
                            //add the cookie to the response.
                            Response.Cookies.Add(authenticationCookie);
                            Session["MemberName"] = MemberName;
                            Session["MemberEmail"] = userEmail;
                            String redirectUrl = "";
                            if (roleName == "HR Administrator")
                            {
                                redirectUrl = FormsAuthentication.GetRedirectUrl(userName, false);
                            }
                            if (roleName == "Payroll Administrator")
                            {
                                redirectUrl = Page.ResolveUrl("~/Payroll/PayrollDashboard.aspx");
                            }
                            if (roleName == "Supervisor" || roleName == "Employee")
                            {
                                redirectUrl = Page.ResolveUrl("~/Common/EmployeeProfile.aspx");
                            }
                            if (roleName == "Data Entry Clerk")
                            {
                                redirectUrl = Page.ResolveUrl("~/Clerical/EnterDailyFNTrans.aspx");
                            }
                            if (redirectUrl.Equals(String.Empty))
                                redirectUrl = Page.ResolveUrl("~/Common/EmployeeProfile.aspx");
                            Page.Response.Redirect(redirectUrl);
                        }
                    }
                    else
                    {
                        this.errorMessage.Visible = true;
                        this.EmailAddress.Text = "";
                        this.Login_Password.Text = "";
                        this.errorMessage.Text = "Invalid Email Id or Password. Please check your credentials.";
                        this.errorMessage.CssClass = "errorMessage";
                    }
                }
            }
            catch (Exception exception)
            {
                this.errorMessage.Visible = true;
                this.EmailAddress.Text = "";
                this.Login_Password.Text = "";
                this.errorMessage.Text = ErrorLogging.LogError(exception, "Unknown Exception Occured.Please contact Support.");
                this.errorMessage.CssClass = "errorMessage";
            }

        }

        private void RedirectBasedonRole()
        {
            try
            {
                HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);

                string cookiePath = ticket.CookiePath;
                DateTime expiration = ticket.Expiration;
                bool expired = ticket.Expired;
                bool isPersistent = ticket.IsPersistent;
                DateTime issueDate = ticket.IssueDate;
                string roleName = ticket.UserData;
                string userName = ticket.Name;
                //string version = ticket.Version;
                if (expired == false)
                {
                    String redirectUrl = "";
                    if (roleName == "HR Administrator") {redirectUrl = FormsAuthentication.GetRedirectUrl(userName, false);}
                    if (roleName == "Payroll Administrator")
                    {
                        redirectUrl = Page.ResolveUrl("~/Payroll/ManagePayroll.aspx");
                    }
                    if (roleName == "Supervisor" || roleName == "Employee")
                    {
                        redirectUrl = Page.ResolveUrl("~/Common/EmployeeProfile.aspx");
                    }

                    if (redirectUrl.Equals(String.Empty))
                        redirectUrl = Page.ResolveUrl("~/Common/EmployeeProfile.aspx");
                    Page.Response.Redirect(redirectUrl);
                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }

        }
        private void Tab3_Submit_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid == true)
                {
                    DataSet _DataList = null;
                    _DataList = DatabaseManager.Data.DBAccessManager.RetrievePassword(this.Tab3_Emailaddress.Text.ToString().Trim());
                    if (_DataList.Tables.Count > 0)
                    {
                        if (_DataList.Tables[0].Rows.Count > 0) // Member Login Information
                        {
                            DataRow _DataRow = _DataList.Tables[0].Rows[0];
                            string userName = _DataRow["userName"].ToString();
                            string emailAddress = _DataRow["Work_Email"].ToString();
                            string password = SchoolNetBase.DecodeFrom64(_DataRow["Password"].ToString());
                            string employeeName = _DataRow["EmployeeName"].ToString();
                            SendPasswordRetrieveMail(employeeName,userName, emailAddress, password);

                        }
                        else
                        {
                            this.errorMessage.Visible = true;
                            this.errorMessage.Text = "Sorry, We could not find your email address.Please check your email address again.";
                            this.errorMessage.CssClass = "errorMessage";
                            //  this.Reset_Click(sender,e);
                        }
                    }
                    else
                    {
                        this.errorMessage.Visible = true;
                        this.errorMessage.Text = "Sorry, We could not find your email address.Please check your email address again.";
                        this.errorMessage.CssClass = "errorMessage";
                        //  this.Reset_Click(sender,e);
                    }
                }
            }
            catch (Exception exception)
            {
                this.errorMessage.Visible = true;
                this.errorMessage.Text = ErrorLogging.LogError(exception, "Unknown Exception Occured.Please contact Support.");
                this.errorMessage.CssClass = "errorMessage";
            }

        }

        private void SendPasswordRetrieveMail(string employeeName,string uName, string Employee_EmailAddress, string Password)
        {
            string HRSystemLink = ConfigurationManager.AppSettings["HRSystemURL"].ToString();
            string FromAddressDisplayName = ConfigurationManager.AppSettings["FromEmailDisplayName"].ToString();

            string subject = "Ark HRMS Alerting Service:Password Retrieval Request from " + employeeName;

            string bodycontent = "<html><body leftmargin=10 style=\"font-family: Arial;font-size:11\">" +
                                 "<P><br> Hello " + employeeName + "," +
                                "<br><br>You have received this email  because  you have requested to retrieve your forgotten password from AON HRMS System" +
                                "<br>In case you have not made this request, Please contact your HR administrator" +
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

                if (Employee_EmailAddress.Trim() != "")
                {
                    message.To.Add(Employee_EmailAddress.Trim());
                }

                message.Subject = subject;
                message.Body = bodycontent;

                SmtpClient smtp = new SmtpClient();
                smtp.Send(message);
                this.errorMessage.Visible = true;
                this.errorMessage.Text = "Your login credentials have been sent to your work email account on our system.";
                this.errorMessage.CssClass = "errorMessage";

            }
            catch (Exception exception)
            {
                this.errorMessage.Visible = true;
                this.errorMessage.Text = ErrorLogging.LogError(exception, "There was an error in sending email notification.");
                this.errorMessage.CssClass = "errorMessage";

            }
        }

    }
}


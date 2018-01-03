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
    public partial class AddEmployee : SchoolNetBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            { 
                LoadEmpStatusLookupByType(Tab1_EmpStatus, (int)Constants.EmpStatusType.Onboarding);
                LoadDesignationLookup(Tab1_Designation);
              //  LoadDepartmentLookup(Tab1_Department);
                LoadDivisionLookupByEmpId(Tab1_Division, Int32.Parse(Page.User.Identity.Name.ToString()));
                //LoadEntityLocationLookupByEmpId(Tab1_Location, Int32.Parse(Page.User.Identity.Name.ToString()));
                LoadEntityLocationLookupByEmpId_DivisionID(Tab1_Location, Int32.Parse(Page.User.Identity.Name.ToString()), Int32.Parse(Tab1_Division.SelectedValue));
                LoadGenderType(Tab1_GenderType);
                LoadMaritalStatus(Tab1_MaritalStatus);
                LoadEmpCategoryLookup(Tab1_EmpCategory);
                LoadSalutationType(Tab1_SaluationType);
                LoadEducationList(Tab1_Education);
                LoadSupervisorsListLookupByDivisionID(Tab1_Supervisor, Int32.Parse(Tab1_Division.SelectedValue));
                LoadDepartmentLookupByDivisionId(Tab1_Department, Int32.Parse(Tab1_Division.SelectedValue));
                LoadCountryList(Tab1_WCountryDDList);
                LoadCountryList(Tab1_CountryDDList);
                LoadRoleTypeLookup(Tab1_AccessLevel);
                
            }
            else
            {
                //LoadEntityLocationLookup(Tab1_Location, Int32.Parse(Tab1_Division.SelectedValue));
                if (Int32.Parse(Tab1_Location.SelectedValue) == -1)
                {
                    LoadEntityLocationLookupByEmpId_DivisionID(Tab1_Location, Int32.Parse(Page.User.Identity.Name.ToString()), Int32.Parse(Tab1_Division.SelectedValue));
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
            base.OnInit(e);
            this.EnableViewState = true;
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Save_Employee.Click +=new EventHandler(Save_Employee_Click);
            Cancel.Click +=new EventHandler(Cancel_Click);
            Tab1_Division.SelectedIndexChanged += new EventHandler(Tab1_Division_SelectedIndexChanged);
        }
        #endregion

        protected void Tab1_Division_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadEntityLocationLookupByEmpId_DivisionID(Tab1_Location, Int32.Parse(Page.User.Identity.Name.ToString()), Int32.Parse(Tab1_Division.SelectedValue));
            LoadSupervisorsListLookupByDivisionID(Tab1_Supervisor, Int32.Parse(Tab1_Division.SelectedValue));
            LoadDepartmentLookupByDivisionId(Tab1_Department, Int32.Parse(Tab1_Division.SelectedValue));

        }


        protected void Save_Employee_Click(object sender, EventArgs e)
        {
            Int32 AccountStatus; Int32 PhotoProfile; String PhotoPath; String FilePath;
            try
            {
                if (Page.IsValid == true)
                {
                                        
                    if (RadioButton1.Checked) {AccountStatus= 1;}
                    else{AccountStatus= 0;}

                    if (Tab1_ProfilePhoto.PostedFile != null && Tab1_ProfilePhoto.PostedFile.FileName !="") // Checked Photo is uploaded.
                    {
                            HttpPostedFile myFile = Tab1_ProfilePhoto.PostedFile;
                            String Ext = System.IO.Path.GetExtension(myFile.FileName);
                            FilePath = Server.MapPath(Page.ResolveUrl("~\\PhotoProfiles\\" + Tab1_FName.Text.ToString() + "_" + Tab1_LName.Text.ToString() + Ext));
                            myFile.SaveAs(FilePath);
                            PhotoPath = Tab1_FName.Text.ToString() + "_" + Tab1_LName.Text.ToString() + Ext;
                            PhotoProfile = 1;
                        
                    }
                    else
                    {
                            PhotoPath = "";
                            PhotoProfile = 0;

                    }
                    if (Tab1_Probation.Text == "") { Tab1_Probation.Text = "0"; }

                    String Result = DatabaseManager.Data.DBAccessManager.AddNewEmployee(Int32.Parse(Tab1_SaluationType.SelectedValue), Tab1_FName.Text.ToString(), Tab1_MidName.Text.ToString(), Tab1_LName.Text.ToString(), ConvertDMY_MDY(Tab1_DOB), Int32.Parse(Tab1_GenderType.SelectedValue), Int32.Parse(Tab1_MaritalStatus.SelectedValue), ConvertDMY_MDY(Tab1_HireDate), Tab1_EmployeeID.Text.ToString(), Int32.Parse(Tab1_EmpCategory.SelectedValue), Int32.Parse(Tab1_EmpStatus.SelectedValue), Int32.Parse(Tab1_Designation.SelectedValue), Int32.Parse(Tab1_Department.SelectedValue), Int32.Parse(Tab1_Division.SelectedValue), Int32.Parse(Tab1_Education.SelectedValue), PhotoProfile, PhotoPath, Tab1_UserName.Text.ToString(), EncodePasswordToBase64(Tab1_password.Text.ToString()), Int32.Parse(Tab1_Location.SelectedValue), Int32.Parse(Tab1_Probation.Text.ToString()),Tab1_PSEmployeeID.Text.ToString(), Tab1_HAddress1.Text.ToString(), Tab1_HAddress2.Text.ToString(), Tab1_HCity.Text.ToString(), Tab1_HState.Text.ToString(), Int32.Parse(Tab1_CountryDDList.SelectedValue), Tab1_WAddress1.Text.ToString(), Tab1_WAddress2.Text.ToString(), Tab1_WCity.Text.ToString(), Tab1_WState.Text.ToString(), Int32.Parse(Tab1_WCountryDDList.SelectedValue),Tab1_HPhone.Text.ToString(), Tab1_Mobile.Text.ToString(), Tab1_WPhone.Text.ToString(), Tab1_WorkEmail.Text.ToString(),Int32.Parse(Tab1_Supervisor.SelectedValue),Int32.Parse(Tab1_AccessLevel.SelectedValue),Int32.Parse(Page.User.Identity.Name.ToString()), AccountStatus);
                    this.message.Visible = true;
                    this.message.CssClass = "errorMessage";
                    if (Result == "")
                    {
                    
                        String Emp_FullName = Tab1_FName.Text.ToString() +' '+Tab1_MidName.Text.ToString()+ ' '+ Tab1_LName.Text.ToString();
                        String EmpEmail  = Tab1_WorkEmail.Text.ToString();
                        String UserName = Tab1_UserName.Text.ToString();
                        String Password = Tab1_password.Text.ToString();
                        if (CheckEmail(EmpEmail))  // Notify via Email if Email was used as a user Name
                        {
                            NotifyEmployee_PortaLoginViaEmail(Emp_FullName, EmpEmail,UserName, Password);

                        }
                        this.message.Text = "Successfully saved.";
                        ResetFields();

                    }
                    else
                    {
                        this.message.Text = Result;

                       // System.IO.File.Delete(FilePath);
                    }
                }
                else
                {
                    this.message.Text = "Error:Could not save the information. Please check the inputs";
                    this.message.CssClass = "errorMessage";
                   

                }

            }
            catch (Exception exception)
            {
                this.message.Visible = true;
                this.message.Text = ErrorLogging.LogError(exception,"Unknown Exception Occured. Please contact support.");
                this.message.CssClass = "errorMessage";
            }
        }


        private void NotifyEmployee_PortaLoginViaEmail(string EmpName, string Employee_EmailAddress,string userName, string Password)
        {
            string HRSystemLink = ConfigurationManager.AppSettings["HRSystemURL"].ToString();
            string FromAddressDisplayName = ConfigurationManager.AppSettings["FromEmailDisplayName"].ToString();

            string subject = "Ark HRMS Alerting Service:AON HRM System Login Credentials";

            string bodycontent = "<html><body leftmargin=10 style=\"font-family: Arial;font-size:11\">" +
                                 "<P><br> Hello " + EmpName + "," +
                                "<br><br>You have received this email because HR Administrator has created login credentials for you to access AON HR System." +
                                "<br> You can click  <a href id=a1 runat=server href="+HRSystemLink+">"+FromAddressDisplayName+ "</a> link in order to login." +
                                "<br>If you have not made this request, Please contact your HR administrator" +
                                "<br><br>Your UserName/Email Address : " + userName +
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
                this.message.Visible = true;
                this.message.Text = "Employee login credentials have been sent to employee's work email account on our system.";
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
            Tab1_FName.Text = "";
            Tab1_MidName.Text = "";
            Tab1_LName.Text = "";
            Tab1_GenderType.SelectedIndex = -1;
            Tab1_HireDate.Text = "";
            Tab1_DOB.Text = "";
            Tab1_UserName.Text = "";
            Tab1_EmployeeID.Text = "";
            Tab1_EmpStatus.SelectedIndex = -1;
            Tab1_EmpCategory.SelectedIndex = -1;
            Tab1_Division.SelectedIndex = -1;
            Tab1_Designation.SelectedIndex = -1;
            Tab1_Department.SelectedIndex = -1;
            Tab1_Education.SelectedIndex = -1;
            Tab1_MaritalStatus.SelectedIndex = -1;
            Tab1_Location.SelectedIndex = -1;           
            Tab1_Probation.Text = "";
            Tab1_AccessLevel.SelectedIndex = -1;
            Tab1_WorkEmail.Text = "";
            Tab1_WPhone.Text = "";
            Tab1_HPhone.Text = "";
            Tab1_WState.Text = "";
            Tab1_WCountryDDList.SelectedIndex = -1;
            Tab1_WCity.Text = "";
            Tab1_WAddress1.Text = "";
            Tab1_WAddress2.Text = "";
            Tab1_HAddress1.Text = "";
            Tab1_HAddress2.Text = "";
            Tab1_HCity.Text = "";
            Tab1_HState.Text = "";
            Tab1_CountryDDList.SelectedIndex = -1;
            Tab1_PSEmployeeID.Text = "";
            Tab1_Supervisor.SelectedIndex = -1;
            Tab1_Mobile.Text = "";
        }

    }
}

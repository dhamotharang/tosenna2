using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Globalization;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using PresentationManager.Web.UI.MasterPages;

namespace SchoolNet
{
    public partial class ChangePassword_HR : SchoolNetBase
    {
        public int EmpId;

        protected void Page_Load(object sender, EventArgs e)
        {
            EmpId = Int32.Parse(Page.User.Identity.Name.ToString());
            if (!Page.IsPostBack)
            {
                LoadPrivilegedUsersList(Tab1_PrivilegedLoginList, EmpId);
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
            Change_Password.Click += new EventHandler(Change_Password_Click);
            Cancel.Click += new EventHandler(Cancel_Click);
            Tab1_PrivilegedLoginList.SelectedIndexChanged += new EventHandler(Tab1_PrivilegedLoginList_SelectedIndexChanged);
        }
        #endregion

        protected void Tab1_PrivilegedLoginList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.message.Text = "";
            this.message.Visible = false;
            LoadMappedUserInformation(Int32.Parse(Tab1_PrivilegedLoginList.SelectedValue));

        }

        private void LoadMappedUserInformation(Int32 selectedUser_empID)
        {
            try
            {
                DataSet _DataList = null;
                _DataList = DatabaseManager.Data.DBAccessManager.RetrieveMappedUserInfo(selectedUser_empID);
                if (_DataList.Tables[0].Rows.Count > 0) // General Employee/Job details Information
                {
                    DataRow _employeeDataRow = _DataList.Tables[0].Rows[0];
                    Tab1_ContactEmail.Text = _employeeDataRow["Work_Email"].ToString();
                }

            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }
        }
        protected void Change_Password_Click(object sender, EventArgs e)
        {
            try
            {
                this.message.CssClass = "errorMessage";
                this.message.Visible = true;
                if (Page.IsValid == true)
                {
                    if (Tab1_ConfirmNewPassword.Text.ToString() == Tab1_NewPassword.Text.ToString())
                    {

                        if (Page.IsValid == true)
                        {
                            keyField.Text = EmpId.ToString();
                            String Result = DatabaseManager.Data.DBAccessManager.ChangePassword_PrivilegedUsers(Int32.Parse(Tab1_PrivilegedLoginList.SelectedValue),Tab1_ContactEmail.Text, EncodePasswordToBase64(Tab1_NewPassword.Text.ToString()),EmpId);
                            
                            if (Result == "")
                            {
                                this.message.Text = "Successfully saved.";
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
                        this.message.Visible = true;
                        this.message.Text = "New Password and Confirm New Password does not match. Please check again.";
                        this.message.CssClass = "errorMessage";
                    }
                }
            }
            catch (Exception exception)
            {
                this.message.Visible = true;
                this.message.Text = ErrorLogging.LogError(exception, "Unknown Exception Occured.Please contact Support.");
                this.message.CssClass = "errorMessage";
            }
        }

        private void ResetFields()
        {
            Tab1_PrivilegedLoginList.SelectedIndex = -1;
            Tab1_ContactEmail.Text = "";
            Tab1_NewPassword.Text = "";
            Tab1_ConfirmNewPassword.Text = "";
   
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Tab1_PrivilegedLoginList.SelectedIndex = -1;
            Tab1_ContactEmail.Text = "";
            Tab1_NewPassword.Text = "";
            Tab1_ConfirmNewPassword.Text = "";
            message.Text = "";
            message.Visible = false;
        }

    }
}

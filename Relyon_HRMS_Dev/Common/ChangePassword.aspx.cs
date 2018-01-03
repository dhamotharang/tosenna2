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
    public partial class ChangePassword : SchoolNetBase
    {
        public int EmpId;       

        protected void Page_Load(object sender, EventArgs e)
        {
            EmpId = Int32.Parse(Page.User.Identity.Name.ToString());
            if (!Page.IsPostBack)
            {
   
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
            Change_Password.Click +=new EventHandler(Change_Password_Click);                
            Cancel.Click += new EventHandler(Cancel_Click);
        }
        #endregion

        protected void Change_Password_Click(object sender, EventArgs e)
        {
           try
            {
                if (Page.IsValid == true)
                {
                    if (Tab1_password.Text.ToString() != Tab1_NewPassword.Text.ToString())
                    {

                        if (Page.IsValid == true)
                        {
                            keyField.Text = EmpId.ToString();
                            String Result = DatabaseManager.Data.DBAccessManager.ChangePassword(Int32.Parse(this.keyField.Text.ToString()), EncodePasswordToBase64(Tab1_password.Text.ToString()), EncodePasswordToBase64(Tab1_NewPassword.Text.ToString()));
                            this.message.Visible = true;
                            if (Result == "")
                            {
                                this.message.Text = "Successfully saved.";
                            }

                            else
                            {
                                this.message.Text = Result;
                                this.message.CssClass = "errorMessage";
                            }
                        }
                    }
                    else
                    {
                        this.message.Visible = true;
                        this.message.Text = "New Password can not be same as your current password.Please check the input.";
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
       
     
        protected void Cancel_Click(object sender, EventArgs e)
        {
            Tab1_password.Text = "";
            Tab1_NewPassword.Text = "";
            Tab1_ConfirmNewPassword.Text = "";
            message.Text = "";
            message.Visible = false;
        }

    }
}

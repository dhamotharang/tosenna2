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
    public partial class DeactivateEmployee : SchoolNetBase
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
            Deactivate_Employee.Click += new EventHandler(Deactivate_Employee_Click);
            Cancel.Click += new EventHandler(Cancel_Click);
      
        }
        #endregion

        private  void LoadBasicEmployeeInformation()
        {
          if (Tab1_EmployeeID.Text != "")
          {
            DataSet _DataList = null;
            _DataList = DatabaseManager.Data.DBAccessManager.RetrieveKeyEmpInformation(Tab1_EmployeeID.Text.ToString());
            if (_DataList.Tables.Count > 0)
            {
                DataRow _DataRow = _DataList.Tables[0].Rows[0];
                Tab1_EmployeeName.Text = _DataRow["EmployeeName"].ToString();
                Tab1_EmpStatusName.Text = _DataRow["EmpStatusName"].ToString();
                Tab1_HireDateLbl.Text = _DataRow["HireDate"].ToString();
            }
          }
        }


        protected void Deactivate_Employee_Click(object sender, EventArgs e)
        {
            try
            {
                this.message.CssClass = "errorMessage";
                if (Page.IsValid == true)
                {
                    String Result = DatabaseManager.Data.DBAccessManager.DeactivateEmployee(Tab1_EmployeeID.Text.ToString(),  Int32.Parse(Page.User.Identity.Name.ToString()));
                    this.message.Visible = true;
                    if (Result == "")
                    {
                      this.message.Text = "Employee Profile has been deactivated from HRM system successfully.";
                      ResetFields();

                    }
                    else
                    {
                        this.message.Text = Result;
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

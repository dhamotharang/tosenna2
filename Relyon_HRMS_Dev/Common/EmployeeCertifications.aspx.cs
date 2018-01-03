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
using PresentationManager.Web.UI.MasterPages;

namespace SchoolNet
{
    public partial class EmployeeCertifications : SchoolNetBase
    {
        public int EmpId;

        protected void Page_Load(object sender, EventArgs e)
        {
            EmpId = Int32.Parse(Page.User.Identity.Name.ToString());

            if (!Page.IsPostBack)
            {
                LoadCertificationType(Tab1_CertTypeList);

            }
           
            LoadEmployeeCertList();
            if (Tab1_CertTypeList.Enabled != true) { Tab1_CertTypeList.Enabled = true; }
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
            EmpCert_Save.Click +=new EventHandler(EmpCert_Save_Click);
            Reset.Click += new EventHandler(Reset_Click);

        }
        #endregion
        #region LoadEmployeeCertList();
        private void LoadEmployeeCertList()
        {
            DataSet _DataList = null;
            _DataList = DatabaseManager.Data.DBAccessManager.RetrieveEmployeeCertifications(EmpId);

            if (_DataList.Tables[0].Rows.Count > 0)
            {
                emptyRow.Visible = false;
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

        #region EmpCert_Save_Click
        protected void EmpCert_Save_Click(object sender, EventArgs e)
        {
          
            try
            {
                if (Page.IsValid == true)  // Change requestStatusType to be dynamic, currently 1=submitted.
                {
                    if (Tab1_keyField.Text.ToString() == "") { Tab1_keyField.Text = "0"; }


                    String Result = DatabaseManager.Data.DBAccessManager.AddUpdateEmployeeCertifications(Convert.ToInt32(Tab1_keyField.Text), EmpId, Int32.Parse(Tab1_CertTypeList.SelectedValue), Tab1_Description.Text.ToString(), Tab1_CertNumber.Text.ToString(), ConvertDMY_MDY(Tab1_IssuedDate), ConvertDMY_MDY(Tab1_ExpiryDate));
                    this.Hmessage.Visible = true;
                    Hmessage.CssClass = "errorMessage";
                    if (Result == "")
                    {
                        //  this.Hmessage.Text = "Successfully saved.";
                        ResetFields();

                    }
                }
                else
                {
                    this.Hmessage.Text = "Error:Could not save the information. Please check the inputs";
                    this.Hmessage.CssClass = "errorMessage";
                }
                LoadEmployeeCertList();// Refresh the grid

            }
            catch (Exception exception)
            {
                this.Hmessage.Visible = true;
                this.Hmessage.Text = ErrorLogging.LogError(exception, "Unknown Exception Occured.Please contact Support.");
                this.Hmessage.CssClass = "errorMessage";
            }
                  

        }
        #endregion
        #region Reset_Click
        protected void Reset_Click(object sender, EventArgs e)
        {
            ResetFields();
        }
        #endregion
        private void ResetFields()
        {
            Tab1_keyField.Text = "0";
            Tab1_ExpiryDate.Text = "";
            Tab1_IssuedDate.Text = "";
            Tab1_Description.Text = "";
            Tab1_CertNumber.Text = "";
            Tab1_CertTypeList.SelectedIndex = -1;
            Hmessage.Visible = false;
            emptyRow.Visible = false;
        }
        private void DeleteEmployeeCertification(Int32 RowId, Int32 EmpId)
        {
            try
            {
                String result = DatabaseManager.Data.DBAccessManager.DeleteEmployeeCertification(RowId, EmpId);

                if (result != "")
                {
                    this.Hmessage.Text = "Error:Could not delete the certification. Please check the inputs";
                    this.Hmessage.CssClass = "errorMessage";

                }
            }
            catch (Exception exception)
            {
                this.Hmessage.Text = ErrorLogging.LogError(exception, "Unknown Exception Occured.Please contact Support.");
                this.Hmessage.CssClass = "errorMessage";
            }
            Grid.CurrentPageIndex = 0;
            LoadEmployeeCertList();

        }

        protected void Grid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            Grid.CurrentPageIndex = e.NewPageIndex;
            LoadEmployeeCertList();
        }
        protected void Grid_EditCommand(object source, DataGridCommandEventArgs e)
        {
            this.Tab1_keyField.Text = Grid.DataKeys[e.Item.ItemIndex].ToString();
            Grid.EditItemIndex = -1;
            LoadCertificationType(Tab1_CertTypeList);
            DataSet _DataList = null;
            _DataList = DatabaseManager.Data.DBAccessManager.RetrieveEmpCertificationInfo(Int32.Parse(Tab1_keyField.Text.ToString()));

            if (_DataList.Tables.Count > 0)
            {
                if (_DataList.Tables[0].Rows.Count > 0) // Leave Request Information.
                {
                    DataRow _DataRow = _DataList.Tables[0].Rows[0];
                    Tab1_CertNumber.Text = _DataRow["Certification_Number"].ToString();
                    Tab1_Description.Text = _DataRow["Cert_Desc"].ToString();
                    Tab1_ExpiryDate.Text = _DataRow["ExpiryDate"].ToString();
                    Tab1_IssuedDate.Text = _DataRow["IssueDate"].ToString();             

                    if (_DataRow["CertificationID"].ToString() != "")
                    {
                        Tab1_CertTypeList.SelectedValue = _DataRow["CertificationID"].ToString();
                        Tab1_CertTypeList.Enabled = false;
                    }

                }

            }
        }

        protected void Grid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            int Emp_CertID = (int)Grid.DataKeys[(int)e.Item.ItemIndex];
            Grid.EditItemIndex = -1;
            DeleteEmployeeCertification(Emp_CertID, EmpId);
        }

    }
}
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
    public partial class ManageDependents : SchoolNetBase
    {
        public int EmpId;
        protected void Page_Load(object sender, EventArgs e)
        {

            EmpId = Int32.Parse(Page.User.Identity.Name.ToString());
            this.keyField.Text = EmpId.ToString();

            if (!Page.IsPostBack)
            {
                LoadRelationshipType(Tab3_RelationshipDDList);
                LoadGenderType(Tab3_GenderType);
                LoadCountryList(Tab3_PassportCountryDDList);
                LoadVisaType(Tab3_VisaType);
                LoadCountryList(Tab3_VisaIssueCountryID);
            }

            if (this.keyField.Text.ToString() != "")
            {
              
                LoadDependentsList();
              
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

            DPGrid.PageIndexChanged += new DataGridPageChangedEventHandler(this.DPGrid_PageIndexChanged);
            DP_Save.Click += new EventHandler(DP_Save_Click);
            DP_Cancel.Click +=new EventHandler(DP_Cancel_Click);
        }
        #endregion

        #region  LoadDependentsList
        private void LoadDependentsList()
        {
            DataTable _empDependentDataTable = null;
            try
            {
                DataSet _DataList = null;
                _DataList = DatabaseManager.Data.DBAccessManager.RetrieveEmployeeInfo(Int32.Parse(this.keyField.Text.ToString()));
                if (_DataList.Tables[1].Rows.Count > 0)  // Employee Dependent Information.
                {
                     _empDependentDataTable = _DataList.Tables[1];
                    this.DPGrid.DataSource = _empDependentDataTable;
                    this.DPGrid.DataBind();
                }
                else
                {
                    this.DPGrid.DataSource = null;
                    this.DPGrid.DataBind();
                }
            }
            catch (Exception exception)
            {
                if (DPGrid.CurrentPageIndex >= DPGrid.PageCount)
                {
                    DPGrid.CurrentPageIndex -= 1;
                    this.DPGrid.DataSource = _empDependentDataTable;
                    this.DPGrid.DataBind();

                }
                else
                {
                    ErrorLogging.LogError(exception, " ");
                }

            }

        }
        #endregion

        protected void DP_Save_Click(object sender, EventArgs e)
        {

            try
            {
                if (Page.IsValid == true)
                {
                    String Result = DatabaseManager.Data.DBAccessManager.Update_Emp_DependentInfo(Int32.Parse(keyField.Text.ToString()), Tab3_Name.Text.ToString(), Int32.Parse(Tab3_RelationshipDDList.SelectedValue), ConvertDMY_MDY(Tab3_DOB), Int32.Parse(Tab3_GenderType.SelectedValue), Tab3_PassportNo.Text.ToString(), Int32.Parse(Tab3_PassportCountryDDList.SelectedValue), ConvertDMY_MDY(Tab3_PassportIssueDate), ConvertDMY_MDY(Tab3_PassportExpiryDate), Tab3_VisaNumber.Text.ToString(), Int32.Parse(Tab3_VisaType.SelectedValue), ConvertDMY_MDY(Tab3_VisaIssueDate), ConvertDMY_MDY(Tab3_VisaExpiryDate), Int32.Parse(Tab3_VisaIssueCountryID.SelectedValue));

                    this.DPmessage.Visible = true;
                    this.DPmessage.CssClass = "errorMessage";
                    if (Result == "")
                    {
                        ResetDPFields();
                    }
                    else
                    {
                        this.DPmessage.Text = Result;
                        this.DPmessage.CssClass = "errorMessage";
                    }
                }
                this.LoadDependentsList(); // Refresh the grid after save

            }
            catch (Exception exception)
            {
                this.DPmessage.Visible = true;
                this.DPmessage.Text = ErrorLogging.LogError(exception, "Unknown Exception Occured.Please contact Support.");
                this.DPmessage.CssClass = "errorMessage";
            }
        }
        protected void DP_Cancel_Click(object sender, EventArgs e)
        {
            ResetDPFields();
           
        }

        private void ResetDPFields()
        {
            Tab3_Name.Text = "";
            Tab3_RelationshipDDList.SelectedIndex = -1;
            Tab3_DOB.Text = "";
            Tab3_GenderType.SelectedIndex = -1;
            Tab3_PassportNo.Text = "";
            Tab3_PassportCountryDDList.SelectedIndex = -1;
            Tab3_PassportIssueDate.Text = "";
            Tab3_PassportExpiryDate.Text = "";
            Tab3_VisaNumber.Text = "";
            Tab3_VisaType.SelectedIndex = -1;
            Tab3_VisaIssueDate.Text = "";
            Tab3_VisaExpiryDate.Text = "";
            Tab3_VisaIssueCountryID.SelectedIndex = -1;
            this.DPmessage.Text = "";
        }

        private void DeleteDependent(Int32 DependentID)
        {
            try
            {
                String result = DatabaseManager.Data.DBAccessManager.DeleteEmployeeDependent(Int32.Parse(keyField.Text.ToString()), DependentID);

                if (result != "")
                {
                    this.DPmessage.Text = "Error:Could not delete the dependent. Please check the data";
                    this.DPmessage.CssClass = "errorMessage";

                }
            }
            catch (Exception exception)
            {
                this.DPmessage.Text = ErrorLogging.LogError(exception, "Unknown Exception Occured.Please contact Support.");
                this.DPmessage.CssClass = "errorMessage";

            }
            DPGrid.CurrentPageIndex = 0;
            LoadDependentsList();

        }

        protected void DPGrid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            DPGrid.CurrentPageIndex = e.NewPageIndex;
            LoadDependentsList();

        }
        protected void DPGrid_EditCommand(object source, DataGridCommandEventArgs e)
        {

            keyField.Text = DPGrid.DataKeys[e.Item.ItemIndex].ToString();
            DPGrid.EditItemIndex = -1;
            try
            {
                DataSet _DataList = null;
                _DataList = DatabaseManager.Data.DBAccessManager.RetrieveEmpDependentInfo(Int32.Parse(keyField.Text.ToString()));

                if (_DataList.Tables.Count > 0)
                {
                    if (_DataList.Tables[0].Rows.Count > 0) // Leave Request Information.
                    {
                        DataRow _DataRow = _DataList.Tables[0].Rows[0];
                        Tab3_Name.Text = _DataRow["FullName"].ToString();
                        Tab3_DOB.Text = _DataRow["DOB"].ToString();
                        Tab3_PassportExpiryDate.Text = _DataRow["PP_ExpiryDate"].ToString();
                        Tab3_PassportIssueDate.Text = _DataRow["PP_IssueDate"].ToString();
                        Tab3_PassportNo.Text = _DataRow["PassportNumber"].ToString();
                        Tab3_VisaExpiryDate.Text = _DataRow["Visa_ExpiryDate"].ToString();
                        Tab3_VisaIssueDate.Text = _DataRow["Visa_IssueDate"].ToString();
                        Tab3_VisaNumber.Text = _DataRow["Visa_Number"].ToString();


                        if (_DataRow["GenderTypeID"].ToString() != "")
                        {
                            Tab3_GenderType.SelectedValue = _DataRow["GenderTypeID"].ToString();

                        }
                        if (_DataRow["PP_IssueCountryID"].ToString() != "")
                        {
                            Tab3_PassportCountryDDList.SelectedValue = _DataRow["PP_IssueCountryID"].ToString();

                        }

                        if (_DataRow["RelationshipID"].ToString() != "")
                        {
                            Tab3_RelationshipDDList.SelectedValue = _DataRow["RelationshipID"].ToString();

                        }

                        if (_DataRow["Visa_TypeID"].ToString() != "")
                        {
                            Tab3_VisaType.SelectedValue = _DataRow["Visa_TypeID"].ToString();

                        }
                        if (_DataRow["Visa_IssueCountryID"].ToString() != "")
                        {
                            Tab3_VisaIssueCountryID.SelectedValue = _DataRow["Visa_IssueCountryID"].ToString();

                        }
                    }
                }

            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }

       }
        protected void DPGrid_CancelCommand(object source, DataGridCommandEventArgs e)
        {

        }
        protected void DPGrid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            int dependentID = (int)DPGrid.DataKeys[(int)e.Item.ItemIndex];
            DPGrid.EditItemIndex = -1;
            DeleteDependent(dependentID);

        }
        protected void DPGrid_UpdateCommand(object source, DataGridCommandEventArgs e)
        {

        }

    }
}
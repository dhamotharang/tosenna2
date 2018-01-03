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
    public partial class EmployeeEducation : SchoolNetBase
    {
        public int EmpId;

        protected void Page_Load(object sender, EventArgs e)
        {
            EmpId = Int32.Parse(Page.User.Identity.Name.ToString());

            if (!Page.IsPostBack)
            {
                LoadEducationList(Tab1_EducationList);


            }

            LoadEmployeeEduList();
            if (Tab1_EducationList.Enabled != true) { Tab1_EducationList.Enabled = true; }
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
            EmpEdu_Save.Click += new EventHandler(EmpEdu_Save_Click);
            Reset.Click += new EventHandler(Reset_Click);

        }
        #endregion
        #region LoadEmployeeEduList();
        private void LoadEmployeeEduList()
        {
            try
            {
                DataSet _DataList = null;
                _DataList = DatabaseManager.Data.DBAccessManager.RetrieveEmployeeEducation(EmpId);

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
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }

        }
        #endregion

        #region EmpEdu_Save_Click
        protected void EmpEdu_Save_Click(object sender, EventArgs e)
        {

            try
            {
                if (Page.IsValid == true)  
                {
                    if (Tab1_keyField.Text.ToString() == "") { Tab1_keyField.Text = "0"; }

                    Int32 didGraduate =0;
                    if (Tab1_keyField.Text.ToString() == "") { Tab1_keyField.Text = "0"; }
                    if (Tab1_Graduated.Checked) { didGraduate = 1; } else { didGraduate = 0; }
                    if (Tab1_GPA.Text.ToString() == "") { Tab1_GPA.Text = "0"; }


                    String Result = DatabaseManager.Data.DBAccessManager.AddUpdateEmployeeEducation(Convert.ToInt32(Tab1_keyField.Text), EmpId, Int32.Parse(Tab1_EducationList.SelectedValue), Tab1_SchoolName.Text.ToString(), ConvertDMY_MDY(Tab1_DateDegCompleted), didGraduate, decimal.Parse(Tab1_GPA.Text.ToString()));
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
                LoadEmployeeEduList();// Refresh the grid

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
            Tab1_GPA.Text = "";
            Tab1_SchoolName.Text = "";
            Tab1_Graduated.Checked = false;
            Tab1_EducationList.SelectedIndex = -1;
            Tab1_DateDegCompleted.Text = "";
            Hmessage.Visible = false;
            emptyRow.Visible = false;
        }
        private void DeleteEmployeeEducation(Int32 RowId, Int32 EmpId)
        {
            try
            {
                String result = DatabaseManager.Data.DBAccessManager.DeleteEmployeeEducation(RowId, EmpId);

                if (result != "")
                {
                    this.Hmessage.Text = "Error:Could not delete the education. Please check the inputs";
                    this.Hmessage.CssClass = "errorMessage";

                }
            }
            catch (Exception exception)
            {
                this.Hmessage.Text = ErrorLogging.LogError(exception, "Unknown Exception Occured.Please contact Support.");
                this.Hmessage.CssClass = "errorMessage";

            }

            Grid.CurrentPageIndex = 0;
            LoadEmployeeEduList();

        }

        protected void Grid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            Grid.CurrentPageIndex = e.NewPageIndex;
            LoadEmployeeEduList();
        }
        protected void Grid_EditCommand(object source, DataGridCommandEventArgs e)
        {
            this.Tab1_keyField.Text = Grid.DataKeys[e.Item.ItemIndex].ToString();
            Grid.EditItemIndex = -1;
            LoadEducationList(Tab1_EducationList);
            
            DataSet _DataList = null;
            _DataList = DatabaseManager.Data.DBAccessManager.RetrieveEmpEducationInfo(Int32.Parse(Tab1_keyField.Text.ToString()));

            if (_DataList.Tables.Count > 0)
            {
                if (_DataList.Tables[0].Rows.Count > 0) // Leave Request Information.
                {
                    DataRow _DataRow = _DataList.Tables[0].Rows[0];
                    Tab1_DateDegCompleted.Text = _DataRow["Date_DegreeReceived"].ToString();
                    Tab1_SchoolName.Text = _DataRow["School_Name"].ToString();
                    Tab1_GPA.Text = _DataRow["GradeAverage"].ToString();
                    if (_DataRow["Graduated"].ToString() == "1")
                    { Tab1_Graduated.Checked = true; }
                    else
                    { Tab1_Graduated.Checked = false; }      

                    if (_DataRow["EducationID"].ToString() != "")
                    {
                        Tab1_EducationList.SelectedValue = _DataRow["EducationID"].ToString();
                        Tab1_EducationList.Enabled = false;
                    }

                }

            }
        }

        protected void Grid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            int Emp_EduID = (int)Grid.DataKeys[(int)e.Item.ItemIndex];
            Grid.EditItemIndex = -1;
            DeleteEmployeeEducation(Emp_EduID, EmpId);
        }

    }
}
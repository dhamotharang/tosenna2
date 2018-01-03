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
    public partial class EmployeeSkills : SchoolNetBase
    {
        public int EmpId;

        protected void Page_Load(object sender, EventArgs e)
        {
            EmpId = Int32.Parse(Page.User.Identity.Name.ToString());
            if (!Page.IsPostBack)
            {
                LoadSkillLevelType(Tab1_SkillLevelList);
                LoadSkillCategoryType(Tab1_SkillCategoryList);
                LoadSkillsList(Tab1_SkillsList, Int32.Parse(Tab1_SkillCategoryList.SelectedValue));
                
            }
            else
            {
                LoadSkillsList(Tab1_SkillsList, Int32.Parse(Tab1_SkillCategoryList.SelectedValue));
            }
            LoadEmployeeSkillsList();
            if (Tab1_SkillCategoryList.Enabled != true) { Tab1_SkillCategoryList.Enabled = true; }
            if (Tab1_SkillsList.Enabled != true) { Tab1_SkillsList.Enabled = true; }
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
            EmpSkill_Save.Click +=new EventHandler(EmpSkill_Save_Click);
            Reset.Click += new EventHandler(Reset_Click);

        }
        #endregion
        #region LoadEmployeeSkillsList();
        private void LoadEmployeeSkillsList()
        {
            DataSet _DataList = null;
            _DataList = DatabaseManager.Data.DBAccessManager.RetrieveEmployeeSkills(EmpId);

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
                //emptyRow.Visible = true;
                //emptyRow.Text = "There are no leave requests found.";
                //emptyRow.CssClass = "errorMessage";
            }


        }
        #endregion

        #region EmpSkill_Save_Click
        protected void EmpSkill_Save_Click(object sender, EventArgs e)
        {

            try
            {
                if (Page.IsValid == true)  // Change requestStatusType to be dynamic, currently 1=submitted.
                {
                    if (Tab1_keyField.Text.ToString() == "") { Tab1_keyField.Text = "0"; }


                    String Result = DatabaseManager.Data.DBAccessManager.AddUpdateEmployeeSkills(Convert.ToInt32(Tab1_keyField.Text), EmpId, Int32.Parse(Tab1_SkillsList.SelectedValue), Tab1_SkillDesc.Text.ToString(), Int32.Parse(Tab1_SkillLevelList.SelectedValue), ConvertDMY_MDY(Tab1_LastAssessed), Tab1_Note.Text.ToString());
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
                LoadEmployeeSkillsList();// Refresh the grid

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
            Tab1_Note.Text = "";
            Tab1_SkillDesc.Text = "";
            Tab1_SkillCategoryList.SelectedIndex = -1;
            Tab1_SkillLevelList.SelectedIndex = -1;
            LoadSkillsList(Tab1_SkillsList, Int32.Parse(Tab1_SkillCategoryList.SelectedValue));
            Tab1_SkillsList.SelectedIndex = -1;
            Tab1_LastAssessed.Text = "";          
            Hmessage.Visible = false;
            emptyRow.Visible = false;
        }
        private void DeleteEmployeeSkill(Int32 RowId, Int32 EmpId)
        {
            try
            {
                String result = DatabaseManager.Data.DBAccessManager.DeleteEmployeeSkill(RowId, EmpId);

                if (result != "")
                {
                    this.Hmessage.Text = "Error:Could not delete the skill. Please check the inputs";
                    this.Hmessage.CssClass = "errorMessage";

                }
            }
            catch (Exception exception)
            {
                this.Hmessage.Text = ErrorLogging.LogError(exception, "Unknown Exception Occured.Please contact Support.");
                this.Hmessage.CssClass = "errorMessage";

            }
            Grid.CurrentPageIndex = 0;
            LoadEmployeeSkillsList();
           
        }

        protected void Grid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            Grid.CurrentPageIndex = e.NewPageIndex;
            LoadEmployeeSkillsList();
        }
        protected void Grid_EditCommand(object source, DataGridCommandEventArgs e)
        {
            this.Tab1_keyField.Text = Grid.DataKeys[e.Item.ItemIndex].ToString();
            Grid.EditItemIndex = -1;
            LoadSkillLevelType(Tab1_SkillLevelList);
            LoadSkillCategoryType(Tab1_SkillCategoryList);
          //  LoadSkillsList(Tab1_SkillsList, Int32.Parse(Tab1_SkillCategoryList.SelectedValue));

            // Leave Request Information.
            DataSet _DataList = null;
            _DataList = DatabaseManager.Data.DBAccessManager.RetrieveEmpSkillInfo(Int32.Parse(Tab1_keyField.Text.ToString()));

            if (_DataList.Tables.Count > 0)
            {
                if (_DataList.Tables[0].Rows.Count > 0) // Leave Request Information.
                {
                    DataRow _DataRow = _DataList.Tables[0].Rows[0];
                    Tab1_Note.Text =  _DataRow["Note"].ToString();
                    Tab1_SkillDesc.Text = _DataRow["Skill_Desc"].ToString();
                    Tab1_LastAssessed.Text = _DataRow["Last_Assessed"].ToString();

                    if (_DataRow["SkillLevel_Id"].ToString() != "")
                    {
                        Tab1_SkillLevelList.SelectedValue = _DataRow["SkillLevel_Id"].ToString();
                    }
                    if (_DataRow["SkillCategoryID"].ToString() != "")
                    {
                        Tab1_SkillCategoryList.SelectedValue = _DataRow["SkillCategoryID"].ToString();
                        LoadSkillsList(Tab1_SkillsList, Int32.Parse(Tab1_SkillCategoryList.SelectedValue));
                        Tab1_SkillCategoryList.Enabled = false;
                        Tab1_SkillsList.Enabled = false;
                    }

                }

            } 
        }

        protected void Grid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
              int Emp_SkillID = (int)Grid.DataKeys[(int)e.Item.ItemIndex];
              Grid.EditItemIndex = -1;
              DeleteEmployeeSkill(Emp_SkillID,EmpId);
        }

    }
}
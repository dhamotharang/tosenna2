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
    public partial class EmployeeLanguages : SchoolNetBase
    {
        public int EmpId;

        protected void Page_Load(object sender, EventArgs e)
        {
            EmpId = Int32.Parse(Page.User.Identity.Name.ToString());

            if (!Page.IsPostBack)
            {
                LoadSkillLevelType(Tab1_ReadLevel);
                LoadSkillLevelType(Tab1_SpeakLevel);
                LoadSkillLevelType(Tab1_WriteLevel);
                LoadLanguages(Tab1_Languagelist);
            }

            LoadEmployeeLanguagesList();
            if (Tab1_Languagelist.Enabled != true) { Tab1_Languagelist.Enabled = true; }
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
            EmpLang_Save.Click += new EventHandler(EmpLang_Save_Click);
            Reset.Click += new EventHandler(Reset_Click);

        }
        #endregion
        #region LoadEmployeeLanguagesList();
        private void LoadEmployeeLanguagesList()
        {
            try
            {
                DataSet _DataList = null;
                _DataList = DatabaseManager.Data.DBAccessManager.RetrieveEmployeeLanguages(EmpId);

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

        #region EmpLang_Save_Click
        protected void EmpLang_Save_Click(object sender, EventArgs e)
        {

            try
            {
                if (Page.IsValid == true)  // Change requestStatusType to be dynamic, currently 1=submitted.
                {
                    if (Tab1_keyField.Text.ToString() == "") { Tab1_keyField.Text = "0"; }

                    String Result = DatabaseManager.Data.DBAccessManager.AddUpdateEmployeeLanguages(Convert.ToInt32(Tab1_keyField.Text), EmpId, Int32.Parse(Tab1_Languagelist.SelectedValue), Int32.Parse(Tab1_SpeakLevel.SelectedValue), Int32.Parse(Tab1_ReadLevel.SelectedValue), Int32.Parse(Tab1_WriteLevel.SelectedValue), ConvertDMY_MDY(Tab1_LastAssessed));

                    this.Hmessage.Visible = true;
                    Hmessage.CssClass = "errorMessage";
                    if (Result == "")
                    {
                        ResetFields();
                    }
                    else
                    {
                        this.Hmessage.Text = Result;
                        this.Hmessage.CssClass = "errorMessage";
                    }
                }
                LoadEmployeeLanguagesList();// Refresh the grid

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
            Tab1_LastAssessed.Text = "";
            Tab1_ReadLevel.SelectedIndex = -1;
            Tab1_SpeakLevel.SelectedIndex = -1;
            Tab1_WriteLevel.SelectedIndex = -1;
            Tab1_Languagelist.SelectedIndex = -1;
            Hmessage.Visible = false;
            emptyRow.Visible = false;
        }
        private void DeleteEmployeeLanguage(Int32 RowId, Int32 EmpId)
        {
            try
            {
                String result = DatabaseManager.Data.DBAccessManager.DeleteEmployeeLanguage(RowId, EmpId);

                if (result != "")
                {
                    this.Hmessage.Text = "Error:Could not delete the language. Please check the inputs";
                    this.Hmessage.CssClass = "errorMessage";

                }
                else
                {
                    this.Hmessage.Text = result;
                    this.Hmessage.CssClass = "errorMessage";
                }
            }
            catch (Exception exception)
            {
                this.Hmessage.Text = ErrorLogging.LogError(exception, "Unknown Exception Occured.Please contact Support.");
                this.Hmessage.CssClass = "errorMessage";

            }
            Grid.CurrentPageIndex = 0;
            LoadEmployeeLanguagesList();

        }

        protected void Grid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            Grid.CurrentPageIndex = e.NewPageIndex;
            LoadEmployeeLanguagesList();
        }
        protected void Grid_EditCommand(object source, DataGridCommandEventArgs e)
        {
            try
            {
                this.Tab1_keyField.Text = Grid.DataKeys[e.Item.ItemIndex].ToString();
                Grid.EditItemIndex = -1;
                LoadSkillLevelType(Tab1_ReadLevel);
                LoadSkillLevelType(Tab1_SpeakLevel);
                LoadSkillLevelType(Tab1_WriteLevel);
                LoadLanguages(Tab1_Languagelist);

                DataSet _DataList = null;
                _DataList = DatabaseManager.Data.DBAccessManager.RetrieveEmpLanguageInfo(Int32.Parse(Tab1_keyField.Text.ToString()));

                if (_DataList.Tables.Count > 0)
                {
                    if (_DataList.Tables[0].Rows.Count > 0) // Leave Request Information.
                    {
                        DataRow _DataRow = _DataList.Tables[0].Rows[0];
                        Tab1_LastAssessed.Text = _DataRow["Last_Assessed"].ToString();
                        if (_DataRow["LanguageID"].ToString() != "")
                        {
                            Tab1_Languagelist.SelectedValue = _DataRow["LanguageID"].ToString();
                            Tab1_Languagelist.Enabled = false;
                        }

                        if (_DataRow["ReadLevelID"].ToString() != "")
                        {
                            Tab1_ReadLevel.SelectedValue = _DataRow["ReadLevelID"].ToString();
                        }
                        if (_DataRow["SpeakLevelID"].ToString() != "")
                        {
                            Tab1_SpeakLevel.SelectedValue = _DataRow["SpeakLevelID"].ToString();
                        }
                        if (_DataRow["WriteLevelID"].ToString() != "")
                        {
                            Tab1_WriteLevel.SelectedValue = _DataRow["WriteLevelID"].ToString();
                        }

                    }

                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }
        }

        protected void Grid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            int Emp_LangID = (int)Grid.DataKeys[(int)e.Item.ItemIndex];
            Grid.EditItemIndex = -1;
            DeleteEmployeeLanguage(Emp_LangID, EmpId);
        }

    }
}
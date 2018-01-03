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
    public partial class EmployeeMemberships : SchoolNetBase
    {
        public int EmpId;

        protected void Page_Load(object sender, EventArgs e)
        {
            EmpId = Int32.Parse(Page.User.Identity.Name.ToString());

            if (!Page.IsPostBack)
            {
            }

            LoadEmployeeMembershipList();

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
            EmpMem_Save.Click += new EventHandler(EmpMem_Save_Click);
            Reset.Click += new EventHandler(Reset_Click);

        }
        #endregion
        #region LoadEmployeeMembershipList();
        private void LoadEmployeeMembershipList()
        {
            DataSet _DataList = null;
            _DataList = DatabaseManager.Data.DBAccessManager.RetrieveEmployeeMemberships(EmpId);

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

        #region EmpMem_Save_Click
        protected void EmpMem_Save_Click(object sender, EventArgs e)
        {

            try
            {
                if (Page.IsValid == true)  // Change requestStatusType to be dynamic, currently 1=submitted.
                {
                    if (Tab1_keyField.Text.ToString() == "") { Tab1_keyField.Text = "0"; }

                    String Result = DatabaseManager.Data.DBAccessManager.AddUpdateEmployeeMemberships(Convert.ToInt32(Tab1_keyField.Text), EmpId, Tab1_Membership.Text.ToString(), Tab1_Affilation.Text.ToString(), ConvertDMY_MDY(Tab1_DateJoined));

                    this.Hmessage.Visible = true;
                    Hmessage.CssClass = "errorMessage";
                    if (Result == "")
                    {
                        ResetFields();
                    }
                }
                else
                {
                    this.Hmessage.Text = "Error:Could not save the information. Please check the inputs";
                    this.Hmessage.CssClass = "errorMessage";
                }
                LoadEmployeeMembershipList();// Refresh the grid

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
            Tab1_DateJoined.Text = "";
            Tab1_Affilation.Text = "";
            Tab1_Membership.Text = "";
            Tab1_keyField.Text = "0";
            Hmessage.Visible = false;
            emptyRow.Visible = false;
        }
        private void DeleteEmployeeMembership(Int32 RowId, Int32 EmpId)
        {
            try
            {
                String result = DatabaseManager.Data.DBAccessManager.DeleteEmployeeMembership(RowId, EmpId);

                if (result != "")
                {
                    this.Hmessage.Text = "Error:Could not delete the Membership. Please check the inputs";
                    this.Hmessage.CssClass = "errorMessage";

                }
            }
            catch (Exception exception)
            {
                this.Hmessage.Text = ErrorLogging.LogError(exception, "Unknown Exception Occured.Please contact Support.");
                this.Hmessage.CssClass = "errorMessage";

            }
            Grid.CurrentPageIndex = 0;
            LoadEmployeeMembershipList();

        }

        protected void Grid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            Grid.CurrentPageIndex = e.NewPageIndex;
            LoadEmployeeMembershipList();
        }
        protected void Grid_EditCommand(object source, DataGridCommandEventArgs e)
        {
            this.Tab1_keyField.Text = Grid.DataKeys[e.Item.ItemIndex].ToString();
            Grid.EditItemIndex = -1;

            DataSet _DataList = null;
            _DataList = DatabaseManager.Data.DBAccessManager.RetrieveEmpMembershipInfo(Int32.Parse(Tab1_keyField.Text.ToString()));

            if (_DataList.Tables.Count > 0)
            {
                if (_DataList.Tables[0].Rows.Count > 0) // Leave Request Information.
                {
                    DataRow _DataRow = _DataList.Tables[0].Rows[0];
                    Tab1_Membership.Text = _DataRow["MembershipName"].ToString();
                    Tab1_Affilation.Text = _DataRow["Affiliation"].ToString();
                    Tab1_DateJoined.Text = _DataRow["Date_Joined"].ToString();
                }

            }
        }

        protected void Grid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            int Emp_MemID = (int)Grid.DataKeys[(int)e.Item.ItemIndex];
            Grid.EditItemIndex = -1;
            DeleteEmployeeMembership(Emp_MemID, EmpId);
        }

    }
}
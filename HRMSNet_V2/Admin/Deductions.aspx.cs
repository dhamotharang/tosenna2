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
    public partial class Deductions : SchoolNetBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadPayFrequencyType(Tab1_PayFrequencyList);
            }
            LoadPayComponentsList();
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
            PayComp_Save.Click += new EventHandler(PayComp_Save_Click);
            Reset.Click += new EventHandler(Reset_Click);

        }
        #endregion
        #region LoadPayComponentsList
        private void LoadPayComponentsList()
        {
            DataSet _DataList = null;
            _DataList = DatabaseManager.Data.DBAccessManager.RetrievePayComponentList((int)Constants.PayComponentType.Deduction);

            if (_DataList.Tables[0].Rows.Count > 0)
            {
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

        #region PayComp_Save_Click
        protected void PayComp_Save_Click(object sender, EventArgs e)
        {

            try
            {
                if (Page.IsValid == true)
                {
                    Int32 Status = 0;
                    if (Radio1.Checked) { Status = 1; }
                    if (Tab1_KeyField.Text.ToString() == "") { Tab1_KeyField.Text = "0"; }
                    String Result = DatabaseManager.Data.DBAccessManager.AddUpdatePayComponents(Convert.ToInt32(Tab1_KeyField.Text), Tab1_ComponentName.Text.ToString(), Tab1_ShortName.Text.ToString(), Int32.Parse(Tab1_PayFrequencyList.SelectedValue), (int)Constants.PayComponentType.Deduction, Status, Tab1_AccountCode.Text.ToString(), Tab1_Description.Text.ToString(), Int32.Parse(Page.User.Identity.Name.ToString()));
                    this.LTmessage.Visible = true;
                    LTmessage.CssClass = "errorMessage";
                    if (Result == "")
                    {
                        ResetFields();

                    }
                    else
                    {
                        this.LTmessage.Text = Result;
                    }

                }
                else
                {
                    this.LTmessage.Text = "Error Occured.Please check the input data and try again.";
                    this.LTmessage.CssClass = "errorMessage";
                }
                LoadPayComponentsList();// Refresh the grid

            }
            catch (Exception exception)
            {
                this.LTmessage.Visible = true;
                this.LTmessage.Text = ErrorLogging.LogError(exception,"Unknown Exception Occured.Please contact support.");
                this.LTmessage.CssClass = "errorMessage";
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
            Tab1_KeyField.Text = "0";
            Tab1_ComponentName.Text = "";
            Tab1_ShortName.Text = "";
            Tab1_PayFrequencyList.SelectedIndex = 1;
            Tab1_AccountCode.Text = "";
            Tab1_Description.Text = "";
            LTmessage.Visible = false;
            LTmessage.Text = "";
            Tab1_ShortName.Enabled = true;
        }
        private void DeletePayComponent(Int32 PayComponentID)
        {
            try
            {
                String result = DatabaseManager.Data.DBAccessManager.DeletePayComponent(PayComponentID,(int)Constants.PayComponentType.Deduction, Int32.Parse(Page.User.Identity.Name.ToString()));

                this.LTmessage.Visible = true;
                LTmessage.CssClass = "errorMessage";
                if (result == "") { this.LTmessage.Text = "Successfully deleted."; }
                else { this.LTmessage.Text = result; }
            }
            catch (Exception exception)
            {
                this.LTmessage.Visible = true;
                this.LTmessage.Text = ErrorLogging.LogError(exception,"Unknown Exception Occured.Please contact support.");
                this.LTmessage.CssClass = "errorMessage";

            }
            Grid.CurrentPageIndex = 0;
            LoadPayComponentsList(); // Refresh the grid after deletion.

        }

        protected void Grid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            Grid.CurrentPageIndex = e.NewPageIndex;
            LoadPayComponentsList();
        }
        protected void Grid_EditCommand(object source, DataGridCommandEventArgs e)
        {
            this.Tab1_KeyField.Text = Grid.DataKeys[e.Item.ItemIndex].ToString();
            Tab1_ComponentName.Text = EmptyString(e.Item.Cells[0].Text);
            Tab1_ShortName.Text = EmptyString(e.Item.Cells[1].Text);
            Tab1_ShortName.Enabled = false;
            if (EmptyString(e.Item.Cells[2].Text) != "")
            {
                Tab1_PayFrequencyList.SelectedValue = Tab1_PayFrequencyList.Items.FindByText(e.Item.Cells[2].Text).Value;
            }
            Tab1_AccountCode.Text = EmptyString(e.Item.Cells[3].Text);
            Tab1_Description.Text = EmptyString(e.Item.Cells[4].Text);

            if (EmptyString(e.Item.Cells[5].Text) == "Active") { Radio1.Checked = true; } else { Radio2.Checked = true; }

        }

        protected void Grid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            int PayComponentID = (int)Grid.DataKeys[(int)e.Item.ItemIndex];
            Grid.EditItemIndex = -1;
            DeletePayComponent(PayComponentID);
        }

    }
}
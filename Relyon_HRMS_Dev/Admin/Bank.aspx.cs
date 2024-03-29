using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using DatabaseManager.Data;
using PresentationManager.Web.UI.MasterPages;

namespace SchoolNet

{
    /// <summary>
    /// Summary description for WebForm1.
    /// </summary>
    public partial class Bank : SchoolNetBase
    {

        protected void Page_Load(object sender, System.EventArgs e)
        {
           LoadDataList();
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
           Save.Click += new EventHandler(Save_Click);
           Reset.Click += new EventHandler(Reset_Click);
     
        }
        #endregion
        #region Load LoadDataList
        private void LoadDataList()
        {
            DataSet _DataList = null;
            _DataList = DatabaseManager.Data.DBAccessManager.RetrieveBankList();
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
        protected void Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid == true)
                {
                    Int32 Status = 0;
                    if (Radio1.Checked) { Status = 1; }
                    if (Tab1_KeyField.Text.ToString() == "") { Tab1_KeyField.Text = "0"; }
                    String Result = DatabaseManager.Data.DBAccessManager.AddUpdateBankInformation(Int32.Parse(Page.User.Identity.Name.ToString()), Int32.Parse(Tab1_KeyField.Text), BankName.Text,BankBranch.Text,BankCode.Text,RoutingCode.Text,SwfitCode.Text, Status);
                    this.Tab1_Message.Visible = true;
                    this.Tab1_Message.CssClass = "errorMessage";
                    if (Result == "")
                    {
                        ResetFields();
                    }
                }
                else
                {
                    this.Tab1_Message.Text = "Error:Could not save the information. Please check the inputs";
                    this.Tab1_Message.CssClass = "errorMessage";
                }

            }
            catch (Exception exception)
            {
                this.Tab1_Message.Visible = true;
                this.Tab1_Message.Text = ErrorLogging.LogError(exception,"Unknown Exception Occured. Please contact support.");
                this.Tab1_Message.CssClass = "errorMessage";
            }
            LoadDataList(); // Refresh the Grid after Save.



        }

        protected void Reset_Click(object sender, EventArgs e)
        {
            ResetFields();
        }
        private void ResetFields()
        {
            BankName.Text = "";
            BankBranch.Text = "";
            BankCode.Text = "";
            RoutingCode.Text = "";
            SwfitCode.Text = "";
            Tab1_KeyField.Text = "";
            Tab1_Message.Text = "";
            Tab1_Message.Visible = false;
        }
        protected void Grid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            Grid.CurrentPageIndex = e.NewPageIndex;
            LoadDataList();
        }
        protected void Grid_EditCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                Tab1_KeyField.Text = Grid.DataKeys[e.Item.ItemIndex].ToString();
                BankName.Text = EmptyString(e.Item.Cells[0].Text);
                BankBranch.Text = EmptyString(e.Item.Cells[1].Text);
                BankCode.Text = EmptyString(e.Item.Cells[2].Text);
                RoutingCode.Text = EmptyString(e.Item.Cells[3].Text);
                SwfitCode.Text = EmptyString(e.Item.Cells[4].Text);
                if (EmptyString(e.Item.Cells[5].Text) == "Active") { Radio1.Checked = true; } else { Radio2.Checked = true; }

            }
            LoadDataList();
        }
        protected void Grid_CancelCommand(object source, DataGridCommandEventArgs e)
        {
            Grid.EditItemIndex = -1;
            LoadDataList();
        }
        protected void Grid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
          
        }
        protected void Grid_UpdateCommand(object source, DataGridCommandEventArgs e)
        {
        }
    }
}


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

    public partial class WorkWeek : SchoolNetBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadCountryList(Tab1_CountryList);
                LoadBusinessWeekTypeList(Tab1_BusinessweekTypeList);  
                
            }
            LoadWorkWeekList();
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
            Reset.Click += new EventHandler(Reset_Click);
            WorkWeek_Save.Click +=new EventHandler(WorkWeek_Save_Click);

        }
        #endregion

        #region LoadWorkWeekList();
        private void LoadWorkWeekList()
        {
            DataSet _DataList = null;
            _DataList = DatabaseManager.Data.DBAccessManager.RetrieveCurrentWorkWeek();
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


        #region WorkWeek_Save_Click
        protected void WorkWeek_Save_Click(object sender, EventArgs e)
        {

            try
            {
                if (Page.IsValid == true)
                {
                    if (Tab1_keyField.Text.ToString() == "") { Tab1_keyField.Text = "0"; }

                    String Result = DatabaseManager.Data.DBAccessManager.AddUpdateWorkWeek(Int32.Parse(Tab1_CountryList.SelectedValue), Int32.Parse(Tab1_BusinessweekTypeList.SelectedValue), Int32.Parse(Page.User.Identity.Name.ToString()));

                    this.message.Visible = true;
                    message.CssClass = "errorMessage";
                    if (Result == "")
                    {
                      //  this.Hmessage.Text = "Successfully saved.";
                        ResetFields();

                    }
                    else
                    {
                        this.message.Text = Result;
                        this.message.CssClass = "errorMessage";
                    }
                }
                else
                {
                    this.message.Text = "Error:Could not save the information. Please check the inputs";
                    this.message.CssClass = "errorMessage";
                }
                LoadWorkWeekList();// Refresh the grid

            }
            catch (Exception exception)
            {
                this.message.Visible = true;
                this.message.Text = "Unknown Exception Occured. Please contact support.";
                this.message.CssClass = "errorMessage";
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
            Tab1_CountryList.SelectedIndex = -1;
            Tab1_BusinessweekTypeList.SelectedIndex = -1;
            this.message.Text = "";
        }
        private void DeleteWorkWeek(Int32 CountryID)
        {
            String result = DatabaseManager.Data.DBAccessManager.DeleteWorkWeek(CountryID,Int32.Parse(Page.User.Identity.Name.ToString()));

            if (result == "")
            {
                this.message.Text = "Successfully deleted.";
                this.message.CssClass = "errorMessage";

            }
            
            else
            {
                this.message.Text = result;
                this.message.CssClass = "errorMessage";

            }
            Grid.CurrentPageIndex = 0;
            LoadWorkWeekList();

        }

        protected void Grid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            Grid.CurrentPageIndex = e.NewPageIndex;
            LoadWorkWeekList();
        }
        protected void Grid_EditCommand(object source, DataGridCommandEventArgs e)
        {
            this.Tab1_keyField.Text = Grid.DataKeys[e.Item.ItemIndex].ToString();
            if (EmptyString(e.Item.Cells[0].Text) != "")
            {
                Tab1_CountryList.SelectedValue = Tab1_CountryList.Items.FindByText(e.Item.Cells[0].Text).Value;
            }

            if (EmptyString(e.Item.Cells[1].Text) != "")
            {
                Tab1_BusinessweekTypeList.SelectedValue = Tab1_BusinessweekTypeList.Items.FindByText(e.Item.Cells[1].Text).Value;
            }

        }

        protected void Grid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            int countryID = (int)Grid.DataKeys[(int)e.Item.ItemIndex];
            DeleteWorkWeek(countryID);
        }

    }
}
 
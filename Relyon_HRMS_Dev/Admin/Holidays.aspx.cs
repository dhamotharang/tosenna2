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
    public partial class Holidays : SchoolNetBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!Page.IsPostBack)
            {
                LoadCountryListByEmpId(Tab1_CountryList, Int32.Parse(Page.User.Identity.Name.ToString()));
            }
            LoadHolidaysList();
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
            Holiday_Save.Click   += new EventHandler(Holiday_Save_Click);  
            Reset.Click +=new EventHandler(Reset_Click);

        }
        #endregion
        #region LoadHolidaysList();
        private void LoadHolidaysList()
        {
            DataSet _DataList = null;
            _DataList = DatabaseManager.Data.DBAccessManager.RetrieveHolidayList(Int32.Parse(Page.User.Identity.Name.ToString()));

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

        #region Holiday_Save_Click
        protected void Holiday_Save_Click(object sender, EventArgs e)
        {

            try
            {
                if (Page.IsValid == true)
                {
                    Int32 RepeatsAnnually = 0;
                    if (Tab1_keyField.Text.ToString() == "") { Tab1_keyField.Text = "0"; }
                    
                    String Result = DatabaseManager.Data.DBAccessManager.AddUpdateHoliday(Convert.ToInt32(Tab1_keyField.Text), Tab1_Name.Text.ToString(), ConvertDMY_MDY(Tab1_Date), RepeatsAnnually, Int32.Parse(Tab1_CountryList.SelectedValue));
                    this.Hmessage.Visible = true;
                    Hmessage.CssClass = "errorMessage";
                    if (Result == "")
                    {
                      //  this.Hmessage.Text = "Successfully saved.";
                        ResetFields();

                    }
                    else
                    {
                        this.Hmessage.Text = Result;
                        this.Hmessage.CssClass = "errorMessage";
                    }
                }
                else
                {
                    this.Hmessage.Text = "Error:Could not save the information. Please check the inputs";
                    this.Hmessage.CssClass = "errorMessage";
                }
                LoadHolidaysList();// Refresh the grid

            }
            catch (Exception exception)
            {
                this.Hmessage.Visible = true;
                this.Hmessage.Text = ErrorLogging.LogError(exception,"Unknown Exception Occured. Please contact support.");
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
            Tab1_Name.Text = "";
            Tab1_Date.Text = "";
            Tab1_CountryList.SelectedIndex = -1;
            this.Hmessage.Text = "";
        }
        private void DeleteHoliday(Int32 HolidayID)
        {
            try
            {
                String result = DatabaseManager.Data.DBAccessManager.DeleteHoliday(HolidayID);

                if (result == "")
                {
                    this.Hmessage.Text = "Successfully deleted.";
                    this.Hmessage.CssClass = "errorMessage";

                }

                else
                {
                    this.Hmessage.Text = "Error:Could not delete the holiday. Please check the inputs";
                    this.Hmessage.CssClass = "errorMessage";

                }
            }
            catch (Exception exception)
            {
                this.Hmessage.Visible = true;
                this.Hmessage.Text = ErrorLogging.LogError(exception, "Unknown Exception Occured. Please contact support.");
                this.Hmessage.CssClass = "errorMessage";
            }

            Grid.CurrentPageIndex = 0;
            LoadHolidaysList();

        }

        protected void Grid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            Grid.CurrentPageIndex = e.NewPageIndex;
            LoadHolidaysList();
        }
        protected void Grid_EditCommand(object source, DataGridCommandEventArgs e)
        {
            this.Tab1_keyField.Text = Grid.DataKeys[e.Item.ItemIndex].ToString();
            Grid.EditItemIndex = -1;
            LoadCountryListByEmpId(Tab1_CountryList, Int32.Parse(Page.User.Identity.Name.ToString()));
            // Leave Type Information.
            try
            {
                DataSet _DataList = null;
                _DataList = DatabaseManager.Data.DBAccessManager.RetrieveHolidayInfo(Int32.Parse(Tab1_keyField.Text.ToString()));
                if (_DataList.Tables.Count > 0)
                {
                    if (_DataList.Tables[0].Rows.Count > 0) // Leave Type Information.
                    {
                        DataRow _DataRow = _DataList.Tables[0].Rows[0];
                        Tab1_Name.Text = _DataRow["HolidayName"].ToString();
                        Tab1_Date.Text = _DataRow["Holiday_Date"].ToString();

                        if (_DataRow["CountryID"].ToString() != "")
                        {
                            Tab1_CountryList.SelectedValue = _DataRow["CountryID"].ToString();
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
            int HolidayID = (int)Grid.DataKeys[(int)e.Item.ItemIndex];
            Grid.EditItemIndex = -1;
            DeleteHoliday(HolidayID);
        }

    }
}
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

    public partial class LeavePeriod : SchoolNetBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                getCurrentLeavePeriod();
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

            LeaveWeek_Save.Click += new EventHandler(LeaveWeek_Save_Click);
           

        }
        #endregion
        private void getCurrentLeavePeriod()
        {
            DataSet _DataList = null;
            _DataList = DatabaseManager.Data.DBAccessManager.RetrieveCurrentLeavePeriod();

            if (_DataList.Tables[0].Rows.Count > 0)
            {
                DataRow _DataRow = _DataList.Tables[0].Rows[0];
                Tab1_LeavePeriodName.Text = _DataRow["LeavePeriodName"].ToString();
                Tab1_StartDate.Text = _DataRow["Start_Date"].ToString();
                Tab1_EndDate.Text = _DataRow["End_Date"].ToString();
                Tab1_LeavePeriod.Text = Tab1_StartDate.Text + " to " + Tab1_EndDate.Text;
            }
        }
      

        #region LeaveWeek_Save_Click
        protected void LeaveWeek_Save_Click(object sender, EventArgs e)
        {

            try
            {
                if (Page.IsValid == true)
                {
                    String Result = DatabaseManager.Data.DBAccessManager.AddUpdateLeavePeriod(Tab1_LeavePeriodName.Text.ToString(), ConvertDMY_MDY(Tab1_StartDate), ConvertDMY_MDY(Tab1_EndDate));
                    this.message.Visible = true;
                    message.CssClass = "errorMessage";
                    if (Result == "")
                    {
                        this.message.Text = "Successfully saved.";
                        Tab1_LeavePeriod.Text = Tab1_StartDate.Text.ToString() + " to " + Tab1_EndDate.Text.ToString();

                    }
                }
                else
                {
                    this.message.Text = "Error:Could not save the information. Please check the inputs";
                    this.message.CssClass = "errorMessage";
                }
                

            }
            catch (Exception exception)
            {
                this.message.Visible = true;
                this.message.Text = ErrorLogging.LogError(exception,"Unknown Exception Occured. Please contact support.");
                this.message.CssClass = "errorMessage";
            }
            getCurrentLeavePeriod();
        }
           #endregion

       
    }
}
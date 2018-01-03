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
using System.IO;


namespace SchoolNet
{
    public partial class ViewAttendance : SchoolNetBase
    {
        protected System.Web.UI.HtmlControls.HtmlInputButton printbtn;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
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

            Attendance_Go.Click += new ImageClickEventHandler(Payroll_Go_Click);
        }
        #endregion

        protected void Payroll_Go_Click(object sender, EventArgs e)
        {
            if (Page.IsValid == true)
            {
                ViewMonthlyAttendance.Visible = true;
                LoadEmpMonthlyAttendance(Int32.Parse(Page.User.Identity.Name.ToString()), Attendance_Month.Text);
            }
        }


        protected void LoadEmpMonthlyAttendance(Int32 EmpId, String MonthYear)
        {
            try
            {
                message.Visible = false;
                message.Text = "";
                DataSet _DataList = null;
                _DataList = DatabaseManager.Data.DBAccessManager.RetrieveEmpMonthlyAttendance(EmpId, MonthYear);
                if (_DataList.Tables[0].Rows.Count > 0)
                {
                    this.AttendanceGrid.DataSource = _DataList;
                    this.AttendanceGrid.DataBind();
                }
                else
                {
                    emptyRow.Visible = true;
                    emptyRow.Text = "There are no records found.";
                    emptyRow.CssClass = "errorMessage";
                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "Unknown Exception Occured.Please contact Support.");
                this.message.Visible = true;
                this.message.CssClass = "errorMessage";
            }    
        }

        protected void Grid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            AttendanceGrid.CurrentPageIndex = e.NewPageIndex;
            LoadEmpMonthlyAttendance(Int32.Parse(Page.User.Identity.Name.ToString()), Attendance_Month.Text);
        }
    } 
   
}
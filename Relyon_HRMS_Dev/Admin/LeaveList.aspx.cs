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

namespace SchoolNet
{
    public partial class LeaveList : SchoolNetBase
    {
        public int EmpId;
        protected void Page_Load(object sender, EventArgs e)
        {
            EmpId = Int32.Parse(Page.User.Identity.Name.ToString());
            if (!Page.IsPostBack)
            {
                LoadDepartmentLookup(departmentDDList);
                LoadDesignationLookup(this.jobTitleDDList);
                LoadDivisionLookupByEmpId(businessUnitDDList, Int32.Parse(Page.User.Identity.Name.ToString()));
                LoadEntityLocationLookupByEmpId_DivisionID(DivisionLocationList, Int32.Parse(Page.User.Identity.Name.ToString()), Int32.Parse(businessUnitDDList.SelectedValue));

            }
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
            businessUnitDDList.SelectedIndexChanged += new EventHandler(businessUnitDDList_SelectedIndexChanged);
            Search.Click += new EventHandler(Search_Click);
            Reset.Click += new EventHandler(Reset_Click);
            Export.Click += new EventHandler(Export_Click);

        }
        #endregion
        protected void businessUnitDDList_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadEntityLocationLookupByEmpId_DivisionID(DivisionLocationList, Int32.Parse(Page.User.Identity.Name.ToString()), Int32.Parse(businessUnitDDList.SelectedValue));

        }
        #region Load LoadDataList
        private void LoadDataList()
        {
            Int32 LeavePeriod = 1; // Default is Today
            if (Tab1_Rb1.Checked) { LeavePeriod = 1; } // Today
            if (Tab1_Rb2.Checked) { LeavePeriod = 2; } // This Week
            if (Tab1_Rb3.Checked) { LeavePeriod = 3; } // This Month
            if (Tab1_Rb4.Checked) { LeavePeriod = 4; } // This Year
            DataSet _DataList = null;
            _DataList = DatabaseManager.Data.DBAccessManager.RetrieveEmployeeLeaveList(LeavePeriod, Int32.Parse(departmentDDList.SelectedValue), Int32.Parse(jobTitleDDList.SelectedValue), Int32.Parse(businessUnitDDList.SelectedValue), Int32.Parse(DivisionLocationList.SelectedValue));

            if (_DataList.Tables[0].Rows.Count > 0)
            {
                DataTable _leaveListDataTable = _DataList.Tables[0];
                this.Grid.DataSource = _leaveListDataTable;
                this.Grid.DataBind();
                emptyRow.Visible = false;
                message.Visible = false;
                Export.Visible = true;

            }
            else
            {
                this.Grid.DataSource = null;
                this.Grid.DataBind();
                emptyRow.Visible = true;
                emptyRow.CssClass = "errorMessage";
                emptyRow.Text = "There are no leave records found.";
                Export.Visible = false;

            }


        }
        #endregion
        protected void Export_Click(object sender, EventArgs e)
        {
            Int32 LeavePeriod = 1; // Default is Today
            if (Tab1_Rb1.Checked) { LeavePeriod = 1; } // Today
            if (Tab1_Rb2.Checked) { LeavePeriod = 2; } // This Week
            if (Tab1_Rb3.Checked) { LeavePeriod = 3; } // This Month
            if (Tab1_Rb4.Checked) { LeavePeriod = 4; } // This Year
            DataSet _DataList = null;
            _DataList = DatabaseManager.Data.DBAccessManager.RetrieveEmployeeLeaveList(LeavePeriod, Int32.Parse(departmentDDList.SelectedValue), Int32.Parse(jobTitleDDList.SelectedValue), Int32.Parse(businessUnitDDList.SelectedValue),Int32.Parse(DivisionLocationList.SelectedValue));

            if (_DataList.Tables[0].Rows.Count > 0)
            {
                DataTable _dataTable = _DataList.Tables[0];
                ExportToExcel(_dataTable);
            }



        }

        public void ExportToExcel(DataTable dt)
        {
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();

            Response.Buffer = true;
            Response.ContentType = "application/vnd.ms-excel";
            Response.Write("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0 Transitional//EN\">");
            Response.AddHeader("content-disposition", "attachment;filename=EmployeeLeaveMaster.xls");
            // Response.ContentEncoding = Encoding.UTF8;
            Response.Charset = "";
            EnableViewState = false;
            String Option = "";
            if (Tab1_Rb1.Checked) { Option = "Today"; } // Today
            if (Tab1_Rb2.Checked) { Option = "Current Week"; } // This Week
            if (Tab1_Rb3.Checked) { Option = "Current Month"; } // This Month
            if (Tab1_Rb4.Checked) { Option = "Current Year"; } // This Year

            String ReportTitle = "<B>Employee Leave Report for " + Option + " :" + businessUnitDDList.SelectedItem.ToString() + " As of " + DateTime.Now.ToString(@"dd/MM/yyyy");
            //Set Fonts
            Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
            Response.Write("<BR><BR><BR>");

            //Sets the table border, cell spacing, border color, font of the text, background,
            //foreground, font height
            Response.Write("<Table border='1' bgColor='#ffffff' borderColor='#000000' cellSpacing='0' cellPadding='0' style='font-size:10.0pt; font-family:Calibri; background:white;'> <TR>");
            //Write the header
            Response.Write("<TR font style='font-size:13.0pt; font-family:Calibri;'><TD align='left' Colspan=" + dt.Columns.Count + ">");
            Response.Write(ReportTitle);
            Response.Write("</TD></TR><TR>");

            // Check not to increase number of records more than 65k according to excel,03
            if (Int32.Parse(dt.Rows.Count.ToString()) <= 65536)
            {
                // Get DataTable Column's Header
                foreach (DataColumn column in dt.Columns)
                {
                    //Write in new column
                    Response.Write("<Td>");

                    //Get column headers  and make it as bold in excel columns
                    Response.Write("<B>");
                    Response.Write(column);
                    Response.Write("</B>");
                    Response.Write("</Td>");
                }

                Response.Write("</TR>");

                // Get DataTable Column's Row
                foreach (DataRow row in dt.Rows)
                {
                    //Write in new row
                    Response.Write("<TR>");

                    for (int i = 0; i <= dt.Columns.Count - 1; i++)
                    {
                        Response.Write("<Td>");
                        Response.Write(row[i].ToString());
                        Response.Write("</Td>");
                    }

                    Response.Write("</TR>");
                }
            }

            Response.Write("</Table>");
            Response.Write("</font>");

            Response.Flush();
            Response.End();
        }


        #region Reset_Click
        protected void Reset_Click(object sender, EventArgs e)
        {
            ResetFields();
        }
        #endregion

        private void ResetFields()
        {

            Tab1_Rb1.Checked = true;
            Tab1_Rb2.Checked = false;
            Tab1_Rb3.Checked = false;
            Tab1_Rb4.Checked = false;
            departmentDDList.SelectedIndex = -1;
            jobTitleDDList.SelectedIndex = -1;
            businessUnitDDList.SelectedIndex = -1;
            emptyRow.Visible = false;
            emptyRow.Text = "";
            message.Text = "";
            message.Visible = false;

        }

        protected void Search_Click(object sender, EventArgs e)
        {
            if (Page.IsValid == true)
            {

                LoadDataList();
            }
        }
        
        protected void Grid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            Grid.CurrentPageIndex = e.NewPageIndex;
            LoadDataList();
        }
        protected void Grid_EditCommand(object source, DataGridCommandEventArgs e)
        {

          //  this.keyField.Text = Grid.DataKeys[e.Item.ItemIndex].ToString();
          //  Grid.EditItemIndex = e.Item.ItemIndex;

        }


        protected void Grid_CancelCommand(object source, DataGridCommandEventArgs e)
        {
            Grid.EditItemIndex = -1;
            // LoadDataList();
        }
        protected void Grid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {

        }
        protected void Grid_UpdateCommand(object source, DataGridCommandEventArgs e)
        {

        }
     }
}
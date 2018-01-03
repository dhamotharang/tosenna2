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
using skmControls2.GoogleChart;
using System.Collections.Generic;
using InfoSoftGlobal; 

namespace SchoolNet
{
    public partial class PayrollDashBoard : SchoolNetBase
    {
        public int EmpId;

        /* 3D fushion Charts*/
        string GraphWidth = "650";
        string GraphHeight = "370";
        string PieWidth = "450";
        string PieHeight = "370";
        string PieXML = "";
        string[] color = new string[12]; 

        protected void Page_Load(object sender, EventArgs e)
        {
            EmpId = Int32.Parse(Page.User.Identity.Name.ToString());
            if (!Page.IsPostBack)
            {
                LoadDivisionLookupByEmpId(businessUnitDDList, Int32.Parse(Page.User.Identity.Name.ToString()));
                LoadEntityLocationLookupByEmpId_DivisionID(DivisionLocationList, Int32.Parse(Page.User.Identity.Name.ToString()), Int32.Parse(businessUnitDDList.SelectedValue));

            }
            LoadDataList();
            ConfigureColors();
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
            Search.Click += new ImageClickEventHandler(Search_Click);
            businessUnitDDList.SelectedIndexChanged += new EventHandler(businessUnitDDList_SelectedIndexChanged);
            Grid1.PageIndexChanged += new DataGridPageChangedEventHandler(this.Grid1_PageIndexChanged);
        }
        #endregion

        protected void Search_Click(object sender, EventArgs e)
        {
            LoadDataList();

        }
        protected void businessUnitDDList_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadEntityLocationLookupByEmpId_DivisionID(DivisionLocationList, Int32.Parse(Page.User.Identity.Name.ToString()), Int32.Parse(businessUnitDDList.SelectedValue));

        }
        #region Load LoadDataList
        private void LoadDataList()
        {
            try
            {
                DataSet _DataList = null;
                _DataList = DatabaseManager.Data.DBAccessManager.RetrievePayrollDashBoardDataByEmpID(Int32.Parse(Page.User.Identity.Name.ToString()), Int32.Parse(businessUnitDDList.SelectedValue), Int32.Parse(DivisionLocationList.SelectedValue));

                if (_DataList.Tables.Count > 0)
                {
                    if (_DataList.Tables[0].Rows.Count > 0) // Employee Divisional PieChart
                    {
                        PieXML = "";
                        DataTable _DataTable = _DataList.Tables[0];
                        PieXML = CreatePieGraph1(_DataTable, "Employee Count Breakdown By Business Unit/Dept", "", "Count", "Division/Dept");
                        FCLiteral2.Text = FusionCharts.RenderChartHTML("../FusionCharts/FCF_Pie3D.swf", "", PieXML, "DivisionDeptChart", PieWidth, PieHeight, false);

                    }
                    else
                    {
                        FCLiteral2.Visible = false;
                    }
                    if (_DataList.Tables[1].Rows.Count > 0) // Employee Location PieChart
                    {
                        PieXML = "";
                        DataTable _DataTable = _DataList.Tables[1];
                        PieXML = CreatePieGraph1(_DataTable, "Employee Count Breakdown By Country", "", "Country", "Count");
                        FCLiteral3.Text = FusionCharts.RenderChartHTML("../FusionCharts/FCF_Pie3D.swf", "", PieXML, "CountryChart", PieWidth, PieHeight, false);
                    }
                    else
                    {
                        FCLiteral3.Visible = false;
                    }
                    

                    if (_DataList.Tables[2].Rows.Count > 0) // Current Month Payroll data/Status
                    {
                        DataTable _DataTable = _DataList.Tables[2];
                        Grid1.DataSource = _DataTable;
                        Grid1.DataBind();
                    }
                    else
                    {
                        Grid1.DataSource = null;
                        Grid1.DataBind();
                    }

                    if (_DataList.Tables[3].Rows.Count > 0) // Historical data for payroll
                    {
                        DataTable _DataTable = _DataList.Tables[3];
                        Grid2.DataSource = _DataTable;
                        Grid2.DataBind();
                    }
                    else
                    {
                        Grid2.DataSource = null;
                        Grid2.DataBind();
                    }

                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "Unknown Exception Occured. Please contact support.");

            }

        }
        #endregion




        protected void Grid1_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            Grid1.CurrentPageIndex = e.NewPageIndex;
            LoadDataList();
        }

        protected void Grid2_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            Grid2.CurrentPageIndex = e.NewPageIndex;
            LoadDataList();
        }
       /* protected void Division_EmpListChart(DataTable dt)
        {
            String _dataValue = null;
            String _dataLabel = null;
            EmpListChart1.Items.Clear();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow _DataRow in dt.Rows) // Loop over the rows.
                {
                    _dataValue = _DataRow["Employee Count"].ToString();
                    _dataLabel = _DataRow["Name"].ToString() + '(' + _dataValue + ')';
                    EmpListChart1.Items.Add(new DataPoint(_dataValue, _dataLabel));

                }
            }

        }

        protected void Location_EmpListChart(DataTable dt)
        {
            String _dataValue = null;
            String _dataLabel = null;
            EmpListChart2.Items.Clear();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow _DataRow in dt.Rows) // Loop over the rows.
                {
                    _dataValue = _DataRow["Employee Count"].ToString();
                    _dataLabel = _DataRow["Name"].ToString() + '(' + _dataValue + ')';
                    EmpListChart2.Items.Add(new DataPoint(_dataValue, _dataLabel));

                }
            }

        }*/
        protected void Grid1_ItemDataBound(object sender, DataGridItemEventArgs e)
        {

            if ((e.Item.ItemType.ToString() != "Header") && (e.Item.ItemType.ToString() != "Footer"))
            {
                if (e.Item.Cells[6].Text.ToString() == "Not Started")
                {
                   // e.Item.Cells[6].BackColor = System.Drawing.Color.Red;
                    e.Item.Cells[6].ForeColor = System.Drawing.Color.Red;
                    e.Item.Cells[6].Font.Bold = true;
                }
                if (e.Item.Cells[6].Text.ToString() == "Pending")
                {
                    e.Item.Cells[6].ForeColor = System.Drawing.Color.Brown;
                   // e.Item.Cells[6].ForeColor = System.Drawing.Color.Black;
                    e.Item.Cells[6].Font.Bold = true;
                }

                if (e.Item.Cells[6].Text.ToString() == "Processed")
                {
                   // e.Item.Cells[6].BackColor = System.Drawing.Color.Green;
                    e.Item.Cells[6].ForeColor = System.Drawing.Color.Green;
                    e.Item.Cells[6].Font.Bold = true;
                }


            }

        }

        protected void Grid2_ItemDataBound(object sender, DataGridItemEventArgs e)
        {

            if ((e.Item.ItemType.ToString() != "Header") && (e.Item.ItemType.ToString() != "Footer"))
            {
                if (e.Item.Cells[4].Text.ToString() == "Not Started")
                {
                  //  e.Item.Cells[4].BackColor = System.Drawing.Color.Red;
                    e.Item.Cells[4].ForeColor = System.Drawing.Color.Red;
                    e.Item.Cells[4].Font.Bold = true;
                }
                if (e.Item.Cells[4].Text.ToString() == "Pending")
                {
                  //  e.Item.Cells[4].BackColor = System.Drawing.Color.Yellow;
                    e.Item.Cells[4].ForeColor = System.Drawing.Color.Brown;
                    e.Item.Cells[4].Font.Bold = true;
                }

                if (e.Item.Cells[4].Text.ToString() == "Processed")
                {
                  //  e.Item.Cells[4].BackColor = System.Drawing.Color.Green;
                    e.Item.Cells[4].ForeColor = System.Drawing.Color.Green;
                    e.Item.Cells[4].Font.Bold = true;
                }


            }

        }

        protected void ConfigureColors()
        {
            color[0] = "AFD8F8";
            color[1] = "F6BD0F";
            color[2] = "8BBA00";
            color[3] = "FF8E46";
            color[4] = "008E8E";
            color[5] = "D64646";
            color[6] = "8E468E";
            color[7] = "588526";
            color[8] = "B3AA00";
            color[9] = "008ED6";
            color[10] = "9D080D";
            color[11] = "A186BE";
        }
        private string CreatePieGraph1(DataTable dt, string strCaption, string strSubCaption, string xAxis, string yAxis)
        {

            string strXML = null;
            strXML = @"<graph caption='" + strCaption + @"' subCaption='" + strSubCaption + @"' decimalPrecision='0'
                          pieSliceDepth='30' formatNumberScale='0'
                          xAxisName='" + xAxis + @"' yAxisName='" + yAxis + @"' rotateNames='1'>";
            int i = 0;
            foreach (DataRow DR in dt.Rows)
            {
                strXML += "<set name='" + DR[0].ToString() + "' value='" + DR[1].ToString() + "' color='" + color[i] + @"'  link=&quot;JavaScript:myJS('" + DR[0].ToString() + ", " + DR[1].ToString() + "'); &quot;/>";
                i++;
            }

            strXML += "</graph>";
            return strXML;
        }   

    }
}
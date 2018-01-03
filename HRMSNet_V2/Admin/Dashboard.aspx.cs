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
    public partial class Dashboard : SchoolNetBase
    {
        public int EmpId;
        /* 3D fushion Charts*/
        string GraphWidth = "550";
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
            LoadPayrollDataList();
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
            Grid2.PageIndexChanged += new DataGridPageChangedEventHandler(this.Grid2_PageIndexChanged);
            Grid3.PageIndexChanged += new DataGridPageChangedEventHandler(this.Grid3_PageIndexChanged);
            Grid4.PageIndexChanged += new DataGridPageChangedEventHandler(this.Grid4_PageIndexChanged);
            Grid5.PageIndexChanged += new DataGridPageChangedEventHandler(this.Grid5_PageIndexChanged);
            Grid6.PageIndexChanged += new DataGridPageChangedEventHandler(this.Grid6_PageIndexChanged);
            Grid7.PageIndexChanged += new DataGridPageChangedEventHandler(this.Grid7_PageIndexChanged);
            Grid8.PageIndexChanged += new DataGridPageChangedEventHandler(this.Grid8_PageIndexChanged);
            Grid9.PageIndexChanged += new DataGridPageChangedEventHandler(this.Grid9_PageIndexChanged);
            Grid10.PageIndexChanged += new DataGridPageChangedEventHandler(this.Grid10_PageIndexChanged);
        }
        #endregion

        protected void Search_Click(object sender, EventArgs e)
        {
            LoadDataList();
            LoadPayrollDataList();

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
                _DataList = DatabaseManager.Data.DBAccessManager.RetrieveDashBoardDataByEmpID(Int32.Parse(Page.User.Identity.Name.ToString()), Int32.Parse(businessUnitDDList.SelectedValue), Int32.Parse(DivisionLocationList.SelectedValue));

                if (_DataList.Tables.Count > 0)
                {
                    if (_DataList.Tables[0].Rows.Count > 0) // Employee Divisional PieChart
                    {
                        PieXML = "";
                        DataTable _DataTable = _DataList.Tables[0];
                        PieXML = CreatePieGraph1(_DataTable, "Employee Count Breakdown By Business Unit/Dept", "", "Count", "Division/Dept");
                        FCLiteral1.Text = FusionCharts.RenderChartHTML("../FusionCharts/FCF_Pie3D.swf", "", PieXML, "DivisionDeptChart", PieWidth, PieHeight, false);

                    }
                    else
                    {
                        FCLiteral1.Visible = false;
                    }
                    if (_DataList.Tables[1].Rows.Count > 0) // Employee Location PieChart
                    {
                        PieXML = "";
                        DataTable _DataTable = _DataList.Tables[1];
                        PieXML = CreatePieGraph1(_DataTable, "Employee Count Breakdown By Country", "", "Country", "Count");
                        FCLiteral2.Text = FusionCharts.RenderChartHTML("../FusionCharts/FCF_Pie3D.swf", "", PieXML, "CountryChart", PieWidth, PieHeight, false);
                    
                    }
                    else
                    {
                        FCLiteral2.Visible = false;
                    }
                    if (_DataList.Tables[2].Rows.Count > 0) // Employee Age Profile PieChart
                    {
                        DataTable _DataTable = _DataList.Tables[2];
                        CreateBarGraph1(_DataTable);
                    }
                    else
                    {
                        FCLiteral3.Visible = false;
                    }
                    if (_DataList.Tables[3].Rows.Count > 0) // Employee Service Profile PieChart
                    {
                        PieXML = "";
                        DataTable _DataTable = _DataList.Tables[3];
                        PieXML = CreatePieGraph1(_DataTable, "Employee Service Year Profile", "", "Count", "Division/Dept");
                        FCLiteral4.Text = FusionCharts.RenderChartHTML("../FusionCharts/FCF_Pie3D.swf", "", PieXML, "ServiceChart", PieWidth, PieHeight, false);

                    }
                    else
                    {
                        FCLiteral4.Visible = false;
                    }
                    
                    if (_DataList.Tables[4].Rows.Count > 0) // Expiring Labor Cards in the next 6 months.
                    {
                        DataTable _DataTable = _DataList.Tables[4];
                        Grid3.DataSource = _DataTable;
                        Grid3.DataBind();
                    }
                    else
                    {
                        Grid3.DataSource = null;
                        Grid3.DataBind();
                    }

                    if (_DataList.Tables[5].Rows.Count > 0) // Expiring Visa in the next 6 months.
                    {
                        DataTable _DataTable = _DataList.Tables[5];
                        Grid4.DataSource = _DataTable;
                        Grid4.DataBind();
                    }
                    else
                    {
                        Grid4.DataSource = null;
                        Grid4.DataBind();
                    }


                    if (_DataList.Tables[6].Rows.Count > 0) // Expiring Passports in the next 6 months.
                    {
                        DataTable _DataTable = _DataList.Tables[6];
                        Grid5.DataSource = _DataTable;
                        Grid5.DataBind();
                    }
                    else
                    {
                        Grid5.DataSource = null;
                        Grid5.DataBind();
                    }

                    if (_DataList.Tables[7].Rows.Count > 0) // Pending Leave in the current week.
                    {
                        DataTable _DataTable = _DataList.Tables[7];
                        Grid1.DataSource = _DataTable;
                        Grid1.DataBind();
                    }
                    else
                    {
                        Grid1.DataSource = null;
                        Grid1.DataBind();
                    }


                    if (_DataList.Tables[8].Rows.Count > 0) // Upcoming Holidays
                    {
                        DataTable _DataTable = _DataList.Tables[8];
                        Grid2.DataSource = _DataTable;
                        Grid2.DataBind();
                    }
                    else
                    {
                        Grid2.DataSource = null;
                        Grid2.DataBind();
                    }

                    if (_DataList.Tables[10].Rows.Count > 0) // Upcoming Probation endings
                    {
                        DataTable _DataTable = _DataList.Tables[10];
                        Grid7.DataSource = _DataTable;
                        Grid7.DataBind();
                    }
                    else
                    {
                        Grid7.DataSource = null;
                        Grid7.DataBind();
                    }
                    if (_DataList.Tables[11].Rows.Count > 0) // Business Visa Expiry
                    {
                        DataTable _DataTable = _DataList.Tables[11];
                        Grid10.DataSource = _DataTable;
                        Grid10.DataBind();
                    }
                    else
                    {
                        Grid10.DataSource = null;
                        Grid10.DataBind();
                    }

                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "Unknown Exception Occured. Please contact support.");
                
            }

        }
        #endregion

        #region  LoadPayrollDataList
        private void LoadPayrollDataList()
        {
            try
            {
                DataSet _DataList = null;
                _DataList = DatabaseManager.Data.DBAccessManager.RetrievePayrollDashBoardDataByEmpID(Int32.Parse(Page.User.Identity.Name.ToString()), Int32.Parse(businessUnitDDList.SelectedValue), Int32.Parse(DivisionLocationList.SelectedValue));

                if (_DataList.Tables.Count > 0)
                {
                   if (_DataList.Tables[2].Rows.Count > 0) // Current Month Payroll data/Status
                    {
                        DataTable _DataTable = _DataList.Tables[2];
                        Grid8.DataSource = _DataTable;
                        Grid8.DataBind();
                    }
                    else
                    {
                        Grid8.DataSource = null;
                        Grid8.DataBind();
                    }

                    if (_DataList.Tables[3].Rows.Count > 0) // Historical data for payroll
                    {
                        DataTable _DataTable = _DataList.Tables[3];
                        Grid9.DataSource = _DataTable;
                        Grid9.DataBind();
                    }
                    else
                    {
                        Grid9.DataSource = null;
                        Grid9.DataBind();
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
        protected void Grid3_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            Grid3.CurrentPageIndex = e.NewPageIndex;
            LoadDataList();

        }

        protected void Grid4_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            Grid4.CurrentPageIndex = e.NewPageIndex;
            LoadDataList();
        }

        protected void Grid5_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            Grid5.CurrentPageIndex = e.NewPageIndex;
            LoadDataList();

        }
        protected void Grid6_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            Grid6.CurrentPageIndex = e.NewPageIndex;
            LoadDataList();

        }
        protected void Grid7_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            Grid7.CurrentPageIndex = e.NewPageIndex;
            LoadDataList();

        }
        protected void Grid8_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            Grid8.CurrentPageIndex = e.NewPageIndex;
            LoadPayrollDataList();
        }

        protected void Grid9_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            Grid9.CurrentPageIndex = e.NewPageIndex;
            LoadPayrollDataList();
        }
        protected void Grid10_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            Grid10.CurrentPageIndex = e.NewPageIndex;
            LoadDataList();
        }
        protected void Grid8_ItemDataBound(object sender, DataGridItemEventArgs e)
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
                    // e.Item.Cells[6].BackColor = System.Drawing.Color.Yellow;
                    e.Item.Cells[6].ForeColor = System.Drawing.Color.Brown;
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

        protected void Grid9_ItemDataBound(object sender, DataGridItemEventArgs e)
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
 /* Old Dashboard Charts */
        /*
        protected void Division_EmpListChart(DataTable dt)
        {
            String  _dataValue   = null;
            String  _dataLabel   = null;
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
            String  _dataValue   = null;
            String  _dataLabel   = null;
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
            
        }
        protected void AgeProfile_EmpListChart(DataTable dt)
        {
            String _dataValue = null;
            String _dataLabel = null;
            EmpListChart3.Items.Clear();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow _DataRow in dt.Rows) // Loop over the rows.
                {
                    _dataValue = _DataRow["Employee Count"].ToString();
                    _dataLabel = _DataRow["Age_Range"].ToString() + '(' + _dataValue + ')';
                    EmpListChart3.Items.Add(new DataPoint(_dataValue, _dataLabel));

                }
            }

        }
        protected void ServiceProfile_EmpListChart(DataTable dt)
        {
            String _dataValue = null;
            String _dataLabel = null;
            EmpListChart4.Items.Clear();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow _DataRow in dt.Rows) // Loop over the rows.
                {
                    _dataValue = _DataRow["Employee Count"].ToString();
                    _dataLabel = _DataRow["Service_Range"].ToString() + '(' + _dataValue + ')';
                    EmpListChart4.Items.Add(new DataPoint(_dataValue, _dataLabel));

                }
            }

        }*/
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
        private void CreateBarGraph1(DataTable dt)
        {
            try
            {
                string xmlData, categories, age, closed, cancel;
                //Initialize <chart> element
                xmlData = @"<graph caption='Employee Age Profile Chart' formatNumberScale='-1' decimalPrecision='0' rotateValues='1' placeValuesInside='1' >";

                //Initialize <categories> element - necessary to generate a multi-series chart
                categories = "<categories>";

                //Initiate <dataset> elements
                age = "<dataset seriesName='Age Range' color='#8BBA00'>";
                /*closed = "<dataset seriesName='Closed Complaints' color='#A186BE'>";
                cancel = "<dataset seriesName='Cancelled & Rejected Complaints' color='#9D080D'>"; */

                //Iterate through the data 
                int i = 0;
                foreach (DataRow DR in dt.Rows)
                {
                    //Append <category name='...' /> to strCategories
                    categories += "<category name='" + DR[0].ToString() + "' />";
                    //Add <set value='...' /> to both the datasets
                    age += "<set value='" + DR[1].ToString() + "' />";
                    /*closed += "<set value='" + DR["Closed"].ToString() + "' />";
                    cancel += "<set value='" + DR["TotalCancelled"].ToString() + "' />";*/
                    i++;
                }

                //Close <categories> element
                categories += "</categories>";

                //Close <dataset> elements
                age += "</dataset>";
               /* closed += "</dataset>";
                cancel += "</dataset>"; */

                //Assemble the entire XML now
                xmlData += categories + age + "</graph>";

                //Create the chart - MS Column 3D Chart with data contained in xmlData
                //  return FusionCharts.RenderChart("../../FusionCharts/MSColumn3D.swf", "", xmlData, "productSales", "600", "300", false, false);

                FCLiteral3.Text = FusionCharts.RenderChart(
                    "../FusionCharts/FCF_MSColumn3D.swf", // Path to chart's SWF
                    "",                              // Leave blank when using Data String method
                    xmlData,                          // xmlStr contains the chart data
                    "EmployeeAgeChart",                      // Unique chart ID
                    GraphWidth, GraphHeight,                   // Width & Height of chart
                    false, false
                    );
            }
            catch (Exception ex)
            { }

        }

    }
}
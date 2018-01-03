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

namespace SchoolNet
{
    public partial class Dashboard : SchoolNetBase
    {
        public int EmpId;
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
            Search.Click += new EventHandler(Search_Click);
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
                    if (_DataList.Tables[0].Rows.Count > 0) // Employee Divisional Chart
                    {
                        DataTable _DataTable = _DataList.Tables[0];
                        Division_EmpListChart(_DataTable);
                    }
                    else
                    {
                        EmpListChart1.Items.Clear();
                    }

                    if (_DataList.Tables[1].Rows.Count > 0) // Employee Location  Chart
                    {
                        DataTable _DataTable = _DataList.Tables[1];
                        Location_EmpListChart(_DataTable);
                    }
                    else
                    {
                        EmpListChart2.Items.Clear();
                    }

                    if (_DataList.Tables[2].Rows.Count > 0) // Employee Age Profile  Chart
                    {
                        DataTable _DataTable = _DataList.Tables[2];
                        AgeProfile_EmpListChart(_DataTable);
                    }
                    else
                    {
                        EmpListChart3.Items.Clear();
                    }

                    if (_DataList.Tables[3].Rows.Count > 0) // Employee Service Profile  Chart
                    {
                        DataTable _DataTable = _DataList.Tables[3];
                        ServiceProfile_EmpListChart(_DataTable);
                    }
                    else
                    {
                        EmpListChart4.Items.Clear();
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
                    e.Item.Cells[6].ForeColor = System.Drawing.Color.Black;
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
                if (e.Item.Cells[3].Text.ToString() == "Not Started")
                {
                    //  e.Item.Cells[3].BackColor = System.Drawing.Color.Red;
                    e.Item.Cells[3].ForeColor = System.Drawing.Color.Red;
                    e.Item.Cells[3].Font.Bold = true;
                }
                if (e.Item.Cells[3].Text.ToString() == "Pending")
                {
                    //  e.Item.Cells[3].BackColor = System.Drawing.Color.Yellow;
                    e.Item.Cells[3].ForeColor = System.Drawing.Color.Yellow;
                    e.Item.Cells[3].Font.Bold = true;
                }

                if (e.Item.Cells[3].Text.ToString() == "Processed")
                {
                    //  e.Item.Cells[3].BackColor = System.Drawing.Color.Green;
                    e.Item.Cells[3].ForeColor = System.Drawing.Color.Green;
                    e.Item.Cells[3].Font.Bold = true;
                }


            }

        }
 
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

        }
              
    }
}
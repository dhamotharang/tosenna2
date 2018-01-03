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
    public partial class ViewPayrollHistory : SchoolNetBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadEmpStatusLookupByType(this.empStatusDDList, (int)Constants.EmpStatusType.Benefit);
                LoadDesignationLookup(this.jobTitleDDList);
                LoadDivisionLookupByEmpId(businessUnitDDList, Int32.Parse(Page.User.Identity.Name.ToString()));
                LoadEntityLocationLookupByEmpId_DivisionID(DivisionLocationList, Int32.Parse(Page.User.Identity.Name.ToString()), Int32.Parse(businessUnitDDList.SelectedValue));

            }
            if (Int32.Parse(DivisionLocationList.SelectedValue) == -1)
            {
                LoadEntityLocationLookupByEmpId_DivisionID(DivisionLocationList, Int32.Parse(Page.User.Identity.Name.ToString()), Int32.Parse(businessUnitDDList.SelectedValue));
            }
            LoadDataList();
            if ((this.keyField.Text.ToString() != "") && (Payroll_Date.Text != ""))
            {
                LoadEmployeeMonthlyPayrollInfo(Int32.Parse(this.keyField.Text), Payroll_Date.Text);

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

            Grid.PageIndexChanged += new DataGridPageChangedEventHandler(this.Grid_PageIndexChanged);
            Grid.SortCommand += new DataGridSortCommandEventHandler(Grid_SortCommand);
            //  Tab1Grid.PageIndexChanged += new DataGridPageChangedEventHandler(Tab1Grid_PageIndexChanged);
            Search.Click += new EventHandler(Search_Click);
            Reset.Click += new EventHandler(Reset_Click);
            Payroll_Go.Click += new EventHandler(Payroll_Go_Click);

        }
        #endregion
        #region Load LoadDataList
        private void LoadDataList()
        {
            DataSet _DataList = null;
            //hack:Filter other status types when default search turns specifically when the index = -1.
            Int32 EmpStatusID = -1;
            if (Int32.Parse(empStatusDDList.SelectedValue) == -1)
            {
                EmpStatusID = -4; // Return only ^Benefit = 4    
            }
            else
            {
                EmpStatusID = Int32.Parse(empStatusDDList.SelectedValue);
            }
            if (ViewState["myDataSet"] == null)   // No such value in view state, take appropriate action.
            {

                _DataList = DatabaseManager.Data.DBAccessManager.RetrieveEmployeeList_Search(Int32.Parse(Page.User.Identity.Name.ToString()), empName.Text.ToString(), empID.Text.ToString(), mgrName.Text.ToString(), EmpStatusID, Int32.Parse(jobTitleDDList.SelectedValue), Int32.Parse(businessUnitDDList.SelectedValue), Int32.Parse(DivisionLocationList.SelectedValue));

                if (_DataList.Tables[0].Rows.Count > 0)
                {
                    this.Grid.DataSource = _DataList;
                    this.Grid.DataBind();
                    emptyRow.Text = "";
                    emptyRow.Visible = false;
                    SetViewState(_DataList);

                }
                else
                {
                    this.Grid.DataSource = null;
                    this.Grid.DataBind();
                    emptyRow.Visible = true;
                    emptyRow.CssClass = "errorMessage";
                    emptyRow.Text = "There are no matching records found.";
                }
            }
            else  // If it is avaiable in the viewstate bind it from there.
            {
                _DataList = GetViewState();
                this.Grid.DataSource = _DataList;
                this.Grid.DataBind();

            }


        }
        #endregion


        protected void LoadEmployeeMonthlyPayrollInfo(Int32 EmpId, String MonthYear)
        {

            try
            {
                DataSet _DataList = null;
                _DataList = DatabaseManager.Data.DBAccessManager.RetrieveEmployeeMonthlyPayrollHistoryInfo(EmpId, MonthYear);

                if (_DataList.Tables.Count > 0)
                {
                    this.message.Text = "";
                    if (_DataList.Tables[0].Rows.Count > 0) // Standard Pay Components.
                    {
                        Tab1Grid.DataSource = _DataList.Tables[0];
                        Tab1Grid.DataBind();
                    }
                    else
                    {
                        Tab1Grid.DataSource = null;
                        Tab1Grid.DataBind();
                    }

                    if (_DataList.Tables[1].Rows.Count > 0) // Leave/Bank Information
                    {
                        DataRow _DataRow = _DataList.Tables[1].Rows[0];
                        Tab1_CurrenyLabel1.Text = "(All Figures in " + _DataRow["CurrencyCode"].ToString() + ")";
                        Tab1_NoOfDaysPayCycle.Text = _DataRow["TotalDays_PayCycle"].ToString();
                        Tab1_NofUnpaidDays.Text = _DataRow["TotalDays_Unpaid"].ToString();
                        Tab1_NetPayDays.Text = _DataRow["NetPayDays"].ToString();
                        Tab1_NetPay.Text = _DataRow["NetPay"].ToString();
                        if (_DataRow["BankAccount"].ToString() != "")
                        {
                            Tab1_EmployeeBankAccount.Text = _DataRow["BankAccount"].ToString();
                        }
                        if (_DataRow["BankId"].ToString() != "")
                        {
                            Tab1_BankName.SelectedValue = _DataRow["BankId"].ToString();
                        }
                        if (_DataRow["PayrollNote"].ToString() != "")
                        {
                            Tab1_Note.Text = _DataRow["PayrollNote"].ToString();
                        }
                        LoadPayrollStatusTypeLookup(Tab1_PayrollStatusType, (int)Constants.PayrollStatusType.Preview);

                        if (_DataRow["PayrollStatusTypeID"].ToString() == "3") // Processed. Change this later.
                        {
                            LoadPayrollStatusTypeLookup(Tab1_PayrollStatusType, (int)Constants.PayrollStatusType.Processed);

                        }

                        if (_DataRow["PayrollStatusTypeID"].ToString() != "")
                        {
                            Tab1_PayrollStatusType.SelectedValue = _DataRow["PayrollStatusTypeID"].ToString();
                        }
                        if (_DataRow["EOSPayout"].ToString() == "1")
                        { Tab1_EOSCheckBox.Checked = true; }
                        else
                        { Tab1_EOSCheckBox.Checked = false; }

                        // Enable payroll download link
                        WPSDownloadLink.Visible = true;
                        WPSDownloadLink.Text = "Click here to view this pay slip";
                        WPSDownloadLink.CssClass = "validationtxt";
                     //   Page.ClientScript.RegisterStartupScript(this.GetType(), "windowopen", @"<script>function openWindow(link){window.open (link,'mywindow','status=1,toolbar=1');return false; }</script>", true);
                      //  WPSDownloadLink.NavigateUrl = "javascript:openWindow('http://localhost:64739/HRMSNet/Payroll/ViewPayStub.aspx?empId='" + EmpId + "'&PayMonthYear='" + MonthYear + ")";
                        WPSDownloadLink.NavigateUrl = "~/Payroll/ViewPayStub.aspx?empId=" + EmpId + "&PayMonthYear=" + MonthYear;
                        WPSDownloadLink.Target = "_blank";
                        



                    }

                }
                else
                {
                    this.message.Visible = true;
                    WPSDownloadLink.Visible = false;
                    this.message.Text = "No Processed payroll data available for this Pay Period.";
                    this.message.CssClass = "errorMessage";
                    return;

                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }

        }

        protected void LoadKeyEmployeeInformation(Int32 EmpId)
        {
            DataSet _DataList = null;
            _DataList = DatabaseManager.Data.DBAccessManager.RetrieveKeyEmpInfo(EmpId);
            if (_DataList.Tables[0].Rows.Count > 0)
            {
                DataRow _DataRow = _DataList.Tables[0].Rows[0];
                lblEmployeeName.Text = _DataRow["F_Name"].ToString() + " " + _DataRow["Mid_Initial"].ToString() + " " + _DataRow["L_Name"].ToString();
                lblJobTitle.Text = _DataRow["Designation"].ToString();
                lblJobLocation.Text = _DataRow["Work_City"].ToString() + "/" + _DataRow["CountryName"].ToString();
                lblWorkPhone.Text = _DataRow["Work_Phone"].ToString() + "(W)";
                lblMobile.Text = _DataRow["Mobile_Phone"].ToString() + "(M)";
                lblEmailAddress.Text = _DataRow["Work_Email"].ToString();
                //lblSuperVisorName.Text = _DataRow["LineManager"].ToString();
                lblSuperVisorName.Text = _DataRow["SupervisorName"].ToString();
                lblSuperVisor_Phone.Text = _DataRow["Supervisor_Phone"].ToString();
                lblSuperVisor_EmailAddress.Text = _DataRow["Supervisor_Email"].ToString();
                lblDivision.Text = _DataRow["DivisionName"].ToString();
                lblDivisionLocation.Text = _DataRow["DivisionLocationName"].ToString();
                lblSuperVisor_JobLocation.Text = _DataRow["Supervisor_WorkLocation"].ToString();
                lblSuperVisor_JobTitle.Text = _DataRow["Supervisor_Designation"].ToString();
                lblSuperVisor_Division.Text = _DataRow["Supervisor_Division"].ToString();
                lblSuperVisor_DivisionLocation.Text = _DataRow["Supervisor_BULocation"].ToString();



                if (_DataRow["Photo_Path"].ToString() != "")
                {
                    this.profile.ImageUrl = Page.ResolveUrl("~\\PhotoProfiles\\" + _DataRow["Photo_Path"].ToString());

                }
                else
                {
                    this.profile.ImageUrl = Page.ResolveUrl("~\\PhotoProfiles\\" + "d_Photo.jpg");
                }

            }


        }


        protected void Payroll_Go_Click(object sender, EventArgs e)
        {
            if (Page.IsValid == true)
            {

                Paycomponents.Visible = true;
                LoadEmployeeMonthlyPayrollInfo(Int32.Parse(this.keyField.Text), Payroll_Date.Text);

            }


        }


        protected void Search_Click(object sender, EventArgs e)
        {
            SetViewState(null);
            LoadDataList();
        }

        #region Reset_Click
        protected void Reset_Click(object sender, EventArgs e)
        {
            empName.Text = "";
            empID.Text = "";
            mgrName.Text = "";
            empStatusDDList.SelectedIndex = -1;
            jobTitleDDList.SelectedIndex = -1;
            businessUnitDDList.SelectedIndex = -1;
            DivisionLocationList.SelectedIndex = -1;

        }
        #endregion

     
        //This is invoked when the grid column is Clicked for Sorting, 
        //Clicking again will Toggle Descending/Ascending through the Sort Expression
        protected void Grid_SortCommand(object sender, DataGridSortCommandEventArgs e)
        {
            DataSet myDataSet = GetViewState();
            DataTable myDataTable = myDataSet.Tables[0];
            GridViewSortExpression = e.SortExpression;
            //Gets the Pageindex of the GridView.
            int iPageIndex = Grid.CurrentPageIndex;
            DataView _dataView = SortDataTable(myDataTable, false);
            Grid.DataSource = _dataView;
            Grid.DataBind();
            Grid.CurrentPageIndex = iPageIndex;
            // Rebind the sorted data into ViewState
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            dt = _dataView.ToTable();
            ds.Merge(dt);
            SetViewState(ds);
        }

        protected void Grid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            DataSet myDataSet = GetViewState();
            DataTable myDataTable = myDataSet.Tables[0];
            DataView _dataView = SortDataTable(myDataTable, true);
            Grid.DataSource = _dataView;
            Grid.CurrentPageIndex = e.NewPageIndex;
            Grid.DataBind();
            // Rebind the sorted data into ViewState
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            dt = _dataView.ToTable();
            ds.Merge(dt);
            SetViewState(ds);

            //            Grid.CurrentPageIndex = e.NewPageIndex;
            //            LoadDataList();
        }
        protected void Grid_EditCommand(object source, DataGridCommandEventArgs e)
        {

            this.keyField.Text = Grid.DataKeys[e.Item.ItemIndex].ToString();
            Grid.EditItemIndex = e.Item.ItemIndex;
            this.EmpSearchBox.Visible = false;
            this.EditArea.Visible = true;
            this.Tab1_Pane.Visible = true;
            //LoadEmployeeBenefits(Int32.Parse(this.keyField.Text));
            LoadBankingListLookup(Tab1_BankName);
            LoadPayrollStatusTypeLookup(Tab1_PayrollStatusType, (int)Constants.PayrollStatusType.Preview);
            LoadKeyEmployeeInformation(Int32.Parse(this.keyField.Text));
        }


    }
}

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
    public partial class ManageDeductions : SchoolNetBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadEmpStatusLookupByType(this.empStatusDDList, (int)Constants.EmpStatusType.Benefit);
                LoadDesignationLookup(this.jobTitleDDList);
                LoadDivisionLookupByEmpId(businessUnitDDList, Int32.Parse(Page.User.Identity.Name.ToString()));
                LoadEntityLocationLookupByEmpId_DivisionID(DivisionLocationList, Int32.Parse(Page.User.Identity.Name.ToString()), Int32.Parse(businessUnitDDList.SelectedValue));
                RetrievePayComponentListByCompTypeID(Tab2_PayComponentList, (int)Constants.PayComponentType.Deduction, (int)Constants.PayFrequencyType.Standard);

            }
            if (Int32.Parse(DivisionLocationList.SelectedValue) == -1)
            {
                LoadEntityLocationLookupByEmpId_DivisionID(DivisionLocationList, Int32.Parse(Page.User.Identity.Name.ToString()), Int32.Parse(businessUnitDDList.SelectedValue));
            }
            LoadDataList();
            if (this.keyField.Text.ToString() != "")
            {
                LoadBenefitDeductionList();
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
            Tab2Grid.PageIndexChanged += new DataGridPageChangedEventHandler(Tab2Grid_PageIndexChanged);
            Search.Click += new EventHandler(Search_Click);
            Reset.Click += new EventHandler(Reset_Click);
            Tab2_Save.Click += new EventHandler(Tab2_Save_Click);
            Tab2_Reset.Click += new EventHandler(Tab2_Reset_Click);
            tab2.Click += new EventHandler(tab2_Click);
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
        #region LoadBenefitDeductionList()
        private void LoadBenefitDeductionList()
        {
            try
            {
                DataSet _DataList = null;
                _DataList = DatabaseManager.Data.DBAccessManager.RetrieveEmployeeBenefitInfo(Int32.Parse(keyField.Text.ToString()));
                if (_DataList.Tables.Count > 0)
                {
                    if (_DataList.Tables[1].Rows.Count > 0) // Deductions Information
                    {
                        DataTable _DeductionTable = _DataList.Tables[1];
                        this.Tab2Grid.DataSource = _DeductionTable;
                        this.Tab2Grid.DataBind();
                    }
                    else
                    {
                        this.Tab2Grid.DataSource = null;
                        this.Tab2Grid.DataBind();
                    }

                 }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }

        }
        #endregion

      
        private void DeleteEmployeeDeductionComponent(Int32 PayComponentID)
        {
            try
            {
                String result = DatabaseManager.Data.DBAccessManager.DeleteEmployeeDeductions(Int32.Parse(keyField.Text.ToString()), Int32.Parse(Tab2_keyField.Text), PayComponentID, Int32.Parse(Page.User.Identity.Name.ToString()));

                this.Tab2_Message.Visible = true;
                Tab2_Message.CssClass = "errorMessage";
                if (result == "") { this.Tab2_Message.Text = "Successfully deleted."; }
                else { this.Tab2_Message.Text = result; }
            }
            catch (Exception exception)
            {
                this.Tab2_Message.Visible = true;
                this.Tab2_Message.Text = ErrorLogging.LogError(exception, "Unknown Exception Occured.Please contact support.");
                this.Tab2_Message.CssClass = "errorMessage";

            }
            //Grid.CurrentPageIndex = 0;
            ResetTab2(); // Clear values after deleting.
            LoadBenefitDeductionList(); // Refresh the grid after deletion.

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
                lblJobLocation.Text = _DataRow["Work_City"].ToString() + "  " + _DataRow["CountryName"].ToString();
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
                EOSPayout.Text = _DataRow["EOSPayout"].ToString();
                // Do this if EOS Payout is processed.

                if (EmptyString(EOSPayout.Text) == "Processed")  // EOS Status, may change this later with enum string.
                {
         
                    Tab2_Save.Enabled = false;
                    Tab2_Reset.Enabled = false;
                }

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


        #region Tab2_Save_Click
        protected void Tab2_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid == true)
                {
                    if (Tab2_keyField.Text.ToString() == "") { Tab2_keyField.Text = "0"; }
                    String Result = DatabaseManager.Data.DBAccessManager.AddUpdateEmployeeDeductions(Convert.ToInt32(keyField.Text), Int32.Parse(Tab2_keyField.Text), Int32.Parse(Tab2_PayComponentList.SelectedValue), Decimal.Parse(NumericCheck_EmptyString(Tab2_Amount.Text)), Int32.Parse(NumericCheck_EmptyString(Tab2_RepaymentPeriod.Text)), Tab2_RepaymentStartDate.Text, Int32.Parse(Page.User.Identity.Name.ToString()));
                    this.Tab2_Message.Visible = true;
                    this.Tab2_Message.CssClass = "errorMessage";
                    if (Result == "")
                    {
                        this.Tab2_Message.Text = "Successfully saved.";
                        ResetTab2();

                    }
                    else
                    {
                        this.Tab2_Message.Text = Result;
                    }
                }
                else
                {
                    this.Tab2_Message.Text = "Error:Could not save the information. Please check the inputs and submit again";
                    this.Tab2_Message.CssClass = "errorMessage";

                }

            }
            catch (Exception exception)
            {
                this.Tab2_Message.Visible = true;
                this.Tab2_Message.Text = ErrorLogging.LogError(exception, "Unknown Exception Occured. Please contact support.");
                this.Tab2_Message.CssClass = "errorMessage";
            }

            LoadBenefitDeductionList();

        }
        #endregion
        #region Reset_Click
        protected void Tab2_Reset_Click(object sender, EventArgs e)
        {
            ResetTab2();
            Tab2_Message.Text = "";
            Tab2_Message.Visible = false;

        }
        #endregion
        private void ResetTab2()
        {
            Tab2_Amount.Text = "";
            Tab2_MonthlyDedAmount.Text = "";
            Tab2_PayComponentList.SelectedIndex = -1;
            Tab2_RepaymentPeriod.Text = "";
            Tab2_RepaymentStartDate.Text = "";
            Tab2_keyField.Text = "";

        }
        private void TabSettings()
        {
            message.Visible = false;
            //Tab2_Pane.Visible = false;
        }
       
        protected void tab2_Click(object sender, EventArgs e)
        {
            TabSettings();
            Tab2_Pane.Visible = true;
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

            // Grid.CurrentPageIndex = e.NewPageIndex;
            // LoadDataList(); 
        }
        protected void Grid_EditCommand(object source, DataGridCommandEventArgs e)
        {

            this.keyField.Text = Grid.DataKeys[e.Item.ItemIndex].ToString(); // Employee ID
            Grid.EditItemIndex = e.Item.ItemIndex;
            this.EmpSearchBox.Visible = false;
            this.EditArea.Visible = true;
            this.Tab2_Pane.Visible = true;
            LoadBenefitDeductionList();
            LoadKeyEmployeeInformation(Int32.Parse(this.keyField.Text));
        }

       
        protected void Tab2Grid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            Tab2Grid.CurrentPageIndex = e.NewPageIndex;
            LoadDataList();
        }
        protected void Tab2Grid_EditCommand(object source, DataGridCommandEventArgs e)
        {

            Tab2_keyField.Text = Tab2Grid.DataKeys[e.Item.ItemIndex].ToString();
            this.EmpSearchBox.Visible = false;
            this.EditArea.Visible = true;
            this.Tab2_Pane.Visible = true;

            Int32 MonthsPaid = Int32.Parse(e.Item.Cells[8].Text);
            if (MonthsPaid > 0)
            {
                TableCell edit = (TableCell)e.Item.Controls[10];
                edit.Enabled = false;
                this.Tab2_Message.Text = "Loan/Advance payment terms can not be edited or modified at this stage as repayment payment has already started.";
                this.Tab2_Message.Visible = true;
                this.Tab2_Message.CssClass = "errorMessage";
                return;
            }
            else
            {
                this.Tab2_Message.Text = "";

            }

            if (EmptyString(e.Item.Cells[1].Text) != "")
            {
                try
                {
                    Tab2_PayComponentList.SelectedValue = Tab2_PayComponentList.Items.FindByText(e.Item.Cells[1].Text).Value;
                }
                catch (Exception exception)
                {
                    ErrorLogging.LogError(exception, "");
                }
            }
            Tab2_Amount.Text = EmptyString(e.Item.Cells[2].Text);
            Tab2_RepaymentPeriod.Text = EmptyString(e.Item.Cells[3].Text);
            Tab2_RepaymentStartDate.Text = EmptyString(e.Item.Cells[4].Text);

            if (EmptyString(e.Item.Cells[7].Text) == "Paid Off")
            {
                TableCell edit = (TableCell)e.Item.Controls[10];
                edit.Enabled = false;
                this.Tab2_Message.Text = "This can not be edited/deleted at this stage this component has been paid off.";
                this.Tab2_Message.Visible = true;
                this.Tab2_Message.CssClass = "errorMessage";
            }


            if (EmptyString(EOSPayout.Text) == "Processed")  // EOS Status, may change this later with enum string.
            {
                TableCell edit = (TableCell)e.Item.Controls[10];
                edit.Enabled = false;
                this.Tab2_Message.Text = "This can not be edited/deleted at this stage as End of Service(EOS) Settlement already processed for this employee.";
                this.Tab2_Message.Visible = true;
                this.Tab2_Message.CssClass = "errorMessage";

            }


        }
        protected void Tab2Grid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            Tab2_keyField.Text = Tab2Grid.DataKeys[e.Item.ItemIndex].ToString();
            int PayComponentID = Int32.Parse(e.Item.Cells[0].Text);

            if (EmptyString(e.Item.Cells[7].Text) == "Paid Off")
            {
                TableCell edit = (TableCell)e.Item.Controls[9];
                edit.Enabled = false;
                this.Tab2_Message.Text = "This can not be edited/deleted at this stage this component has been paid off.";
                this.Tab2_Message.Visible = true;
                this.Tab2_Message.CssClass = "errorMessage";
            }

            if (EmptyString(EOSPayout.Text) == "Processed")  // EOS Status, may change this later with enum string.
            {
                TableCell delete = (TableCell)e.Item.Controls[9];
                delete.Enabled = false;
                this.Tab2_Message.Text = "This can not be edited/deleted at this stage as End of Service(EOS) Settlement already processed for this employee.";
                this.Tab2_Message.Visible = true;
                this.Tab2_Message.CssClass = "errorMessage";

            }
            else
            {
                DeleteEmployeeDeductionComponent(PayComponentID);
            }
        }


    }
}
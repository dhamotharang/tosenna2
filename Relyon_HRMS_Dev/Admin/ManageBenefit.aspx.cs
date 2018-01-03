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
    public partial class ManageBenefit : SchoolNetBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadEmpStatusLookupByType(this.empStatusDDList, (int)Constants.EmpStatusType.Benefit);
                LoadDesignationLookup(this.jobTitleDDList);
                LoadDivisionLookupByEmpId(businessUnitDDList, Int32.Parse(Page.User.Identity.Name.ToString()));
                LoadEntityLocationLookupByEmpId_DivisionID(DivisionLocationList, Int32.Parse(Page.User.Identity.Name.ToString()), Int32.Parse(businessUnitDDList.SelectedValue));
                LoadBankingListLookup(Tab4_BankName);
                RetrievePayComponentListByCompTypeID(Tab1_PayComponentList, (int)Constants.PayComponentType.Benefit,(int)Constants.PayFrequencyType.Standard);
                RetrievePayComponentListByCompTypeID(Tab2_PayComponentList, (int)Constants.PayComponentType.Incentives, (int)Constants.PayFrequencyType.Adhoc);
                RetrievePayComponentListByCompTypeID(Tab3_PayComponentList, (int)Constants.PayComponentType.NPBenefits, (int)Constants.PayFrequencyType.Adhoc);               

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
            Search.Click += new EventHandler(Search_Click);
            Reset.Click += new EventHandler(Reset_Click);
            Bank_Save.Click += new EventHandler(Bank_Save_Click);            
            Tab1_Save.Click += new EventHandler(Tab1_Save_Click);
            Tab2_Save.Click += new EventHandler(Tab2_Save_Click);
            Tab3_Save.Click += new EventHandler(Tab3_Save_Click);
            Tab1_Reset.Click += new EventHandler(Tab1_Reset_Click);
            Tab2_Reset.Click += new EventHandler(Tab2_Reset_Click);
            Tab3_Reset.Click += new EventHandler(Tab3_Reset_Click);
            tab1.Click += new EventHandler(tab1_Click);
            tab2.Click += new EventHandler(tab2_Click);
            tab3.Click += new EventHandler(tab3_Click);
            tab4.Click += new EventHandler(tab4_Click);

        }
        #endregion
        #region Load LoadDataList
        private void LoadDataList()
        {
            try{
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
            catch (Exception exception)
            {
         //       Grid.CurrentPageIndex = 0;
                Grid.DataBind();
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
                    if (_DataList.Tables[0].Rows.Count > 0) // Benefit Information
                    {
                        DataTable _BenefitTable = _DataList.Tables[0];
                        this.Tab1Grid.DataSource = _BenefitTable;
                        this.Tab1Grid.DataBind();

                    }
                    else
                    {
                        this.Tab1Grid.DataSource = null;
                        this.Tab1Grid.DataBind();
                    }

       
                    if (_DataList.Tables[2].Rows.Count > 0) // Bank Information
                    {
                        DataRow _DataRow = _DataList.Tables[2].Rows[0];
                        if (Tab4_EmployeeBankAccount.Text == "")
                        {
                            Tab4_EmployeeBankAccount.Text = _DataRow["BankAccount"].ToString();
                        }
                        if (_DataRow["BankID"].ToString() != "")
                        {
                            if (Tab4_BankName.SelectedValue == "-1") // do this binding only for the first time.
                            {
                                Tab4_BankName.SelectedValue = _DataRow["BankID"].ToString();
                            }
                        }
                    }
                    if (_DataList.Tables[3].Rows.Count > 0) // Incentives Information
                    {
                        DataTable _IncentivesTable = _DataList.Tables[3];
                        this.Tab2Grid.DataSource = _IncentivesTable;
                        this.Tab2Grid.DataBind();
                    }
                    else
                    {
                        this.Tab2Grid.DataSource = null;
                        this.Tab2Grid.DataBind();
                    }
                    if (_DataList.Tables[4].Rows.Count > 0) // NonPayroll Benefit Information
                    {
                        DataTable _NPBenefitsTable = _DataList.Tables[4];
                        this.Tab3Grid.DataSource = _NPBenefitsTable;
                        this.Tab3Grid.DataBind();
                    }
                    else
                    {
                        this.Tab3Grid.DataSource = null;
                        this.Tab3Grid.DataBind();
                    }
                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }

        }
       #endregion

        private void DeleteEmployeeBenefitComponent(Int32 PayComponentID)
        {
            try
            {
                String result = DatabaseManager.Data.DBAccessManager.DeleteEmployeeBenefit(Int32.Parse(keyField.Text.ToString()),PayComponentID,Int32.Parse(Page.User.Identity.Name.ToString()));

                this.Tab1_Message.Visible = true;
                Tab1_Message.CssClass = "errorMessage";
                if (result == "") { this.Tab1_Message.Text = "Successfully deleted."; }
                else { this.Tab1_Message.Text = result; }
            }
            catch (Exception exception)
            {
                this.Tab1_Message.Visible = true;
                this.Tab1_Message.Text = ErrorLogging.LogError(exception,"Unknown Exception Occured.Please contact support.");
                this.Tab1_Message.CssClass = "errorMessage";

            }
            //Grid.CurrentPageIndex = 0;
            ResetTab1(); // Clear values after deleting.
            LoadBenefitDeductionList(); // Refresh the grid after deletion.

        }
        private void DeleteEmployeeIncentiveComponent(Int32 PayComponentID)
        {
            try
            {
                String result = DatabaseManager.Data.DBAccessManager.DeleteEmployeeIncentive(Int32.Parse(keyField.Text.ToString()), PayComponentID, Int32.Parse(Page.User.Identity.Name.ToString()));

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
        private void DeleteEmployeeNonPayrollBenefitComponent(Int32 PayComponentID)
        {
            try
            {
                String result = DatabaseManager.Data.DBAccessManager.DeleteEmployeeNonPayrollBenefit(Int32.Parse(keyField.Text.ToString()), PayComponentID, Int32.Parse(Page.User.Identity.Name.ToString()));

                this.Tab3_Message.Visible = true;
                Tab3_Message.CssClass = "errorMessage";
                if (result == "") { this.Tab3_Message.Text = "Successfully deleted."; }
                else { this.Tab3_Message.Text = result; }
            }
            catch (Exception exception)
            {
                this.Tab3_Message.Visible = true;
                this.Tab3_Message.Text = ErrorLogging.LogError(exception, "Unknown Exception Occured.Please contact support.");
                this.Tab3_Message.CssClass = "errorMessage";

            }
            //Grid.CurrentPageIndex = 0;
            ResetTab3(); // Clear values after deleting.
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
                lblWorkPhone.Text = _DataRow["Work_Phone"].ToString()+ "(W)";
                lblMobile.Text = _DataRow["Mobile_Phone"].ToString()+ "(M)";
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
                    Tab1_Save.Enabled = false;
                    Tab1_Reset.Enabled = false;
                    Tab2_Save.Enabled = false;
                    Tab3_Save.Enabled = false;
                    Bank_Save.Enabled = false;

                }

                if (_DataRow["Photo_Path"].ToString() != "")
                {
                    this.profile.ImageUrl = Page.ResolveUrl("~\\PhotoProfiles\\" + _DataRow["Photo_Path"].ToString());

                }
                else
                {
                    this.profile.ImageUrl = Page.ResolveUrl("~\\PhotoProfiles\\" + "d_Photo.jpg");            }

              }
        }
        
        protected void Bank_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid == true)
                {
                    String Result = DatabaseManager.Data.DBAccessManager.AddUpdateEmployeeBankInformation(Int32.Parse(NumericCheck_EmptyString(keyField.Text.ToString())), Tab4_EmployeeBankAccount.Text, Int32.Parse(Tab4_BankName.SelectedValue), Int32.Parse(Page.User.Identity.Name.ToString()));

                    this.Tab4_Message.Visible = true;
                    this.Tab4_Message.CssClass = "errorMessage";
                    if (Result == "")
                    {
                        this.Tab4_Message.Text = "Successfully saved.";
                        //ResetTab3();
                    }
                    else
                    {
                        this.Tab4_Message.Text = Result;
                    }
                }
                else
                {
                    this.Tab4_Message.Text = "Error:Could not save the information. Please check the inputs";
                    this.Tab4_Message.CssClass = "errorMessage";

                }


            }
            catch (Exception exception)
            {
                this.Tab4_Message.Visible = true;
                this.Tab4_Message.Text = ErrorLogging.LogError(exception,"Unknown Exception Occured. Please contact support.");
                this.Tab4_Message.CssClass = "errorMessage";
            }
            LoadBenefitDeductionList();
        }
        
     
        #region Tab1_Save_Click
        protected void Tab1_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid == true)
                {
                    Int32 ChangeType = 0;
                    if (Tab1_keyField.Text.ToString() == "") { Tab1_keyField.Text = "0"; }
                    if (Tab1_ApprRB1.Checked) { ChangeType = 0; } // Correction
                    if (Tab1_ApprRB2.Checked) { ChangeType = 1; } // Salary Revision.

                    String Result = DatabaseManager.Data.DBAccessManager.AddUpdateEmployeeBenefit(Convert.ToInt32(keyField.Text), Int32.Parse(Tab1_PayComponentList.SelectedValue), Decimal.Parse(NumericCheck_EmptyString(Tab1_Amount.Text)), ChangeType, ConvertDMY_MDY(Tab1_Date), Int32.Parse(Page.User.Identity.Name.ToString()));
                    this.Tab1_Message.Visible = true;
                    this.Tab1_Message.CssClass = "errorMessage";
                    if (Result == "")
                    {
                        this.Tab1_Message.Text = "Successfully saved.";
                        ResetTab1();
                        LoadBenefitDeductionList();

                    }
                    else
                    {
                        this.Tab1_Message.Text = Result;
                    }
                }
                else
                {
                    this.Tab1_Message.Text = "Error:Could not save the information. Please check the inputs and submit again";
                    this.Tab1_Message.CssClass = "errorMessage";

                }

            }
            catch (Exception exception)
            {
                this.Tab1_Message.Visible = true;
                this.Tab1_Message.Text = ErrorLogging.LogError(exception,"Unknown Exception Occured. Please contact support.");
                this.Tab1_Message.CssClass = "errorMessage";
            }
           
        }
        #endregion

        #region Tab2_Save_Click
        protected void Tab2_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid == true)
                {
                    Int32 ChangeType = 0;
                    if (Tab2_keyField.Text.ToString() == "") { Tab2_keyField.Text = "0"; }
                    if (Tab2_ApprRB1.Checked) { ChangeType = 0; } // Correction
                    if (Tab2_ApprRB2.Checked) { ChangeType = 1; } // Salary Revision.

                    String Result = DatabaseManager.Data.DBAccessManager.AddUpdateEmployeeIncentive(Convert.ToInt32(keyField.Text), Int32.Parse(Tab2_PayComponentList.SelectedValue), Decimal.Parse(NumericCheck_EmptyString(Tab2_Amount.Text)), ChangeType, Int32.Parse(Page.User.Identity.Name.ToString()));
                    this.Tab2_Message.Visible = true;
                    this.Tab2_Message.CssClass = "errorMessage";
                    if (Result == "")
                    {  this.Tab2_Message.Text = "Successfully saved."; }
                    else { this.Tab2_Message.Text = Result; }
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
            ResetTab2();
            LoadBenefitDeductionList();
        }
        #endregion

        #region Tab3_Save_Click
        protected void Tab3_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid == true)
                {
                    Int32 ChangeType = 0;
                    if (Tab3_keyField.Text.ToString() == "") { Tab3_keyField.Text = "0"; }
                    if (Tab3_ApprRB1.Checked) { ChangeType = 0; } // Correction
                    if (Tab3_ApprRB2.Checked) { ChangeType = 1; } // Salary Revision.

                    String Result = DatabaseManager.Data.DBAccessManager.AddUpdateEmployeeNonPayrollBenefit(Convert.ToInt32(keyField.Text), Int32.Parse(Tab3_PayComponentList.SelectedValue), Decimal.Parse(NumericCheck_EmptyString(Tab3_Amount.Text)), ChangeType, Int32.Parse(Page.User.Identity.Name.ToString()));
                    this.Tab3_Message.Visible = true;
                    this.Tab3_Message.CssClass = "errorMessage";
                    if (Result == "")
                    { this.Tab3_Message.Text = "Successfully saved."; }
                    else { this.Tab3_Message.Text = Result; }
                }
                else
                {
                    this.Tab3_Message.Text = "Error:Could not save the information. Please check the inputs and submit again";
                    this.Tab3_Message.CssClass = "errorMessage";
                }
            }
            catch (Exception exception)
            {
                this.Tab3_Message.Visible = true;
                this.Tab3_Message.Text = ErrorLogging.LogError(exception, "Unknown Exception Occured. Please contact support.");
                this.Tab3_Message.CssClass = "errorMessage";
            }
            ResetTab3();
            LoadBenefitDeductionList();
        }
        #endregion



        #region Tab1_Reset_Click
        protected void Tab1_Reset_Click(object sender, EventArgs e)
        {
            ResetTab1();
            Tab1_Message.Text = "";
            Tab1_Message.Visible = false;
        }
        #endregion
        private void ResetTab1()
        {
            Tab1_PayComponentList.SelectedIndex = -1;
            Tab1_Amount.Text = "";
            Tab1_ApprRB1.Visible = false;
            Tab1_ApprRB2.Visible = false;
            Tab1_keyField.Text = "";
            Tab1_ApprRB1.Checked = true;
            Tab1_ApprRB2.Checked = false;
            Tab1_Date.Text = "";
        }
        #region Tab2_Reset_Click
        protected void Tab2_Reset_Click(object sender, EventArgs e)
        {
            ResetTab2();
            Tab2_Message.Text = "";
            Tab2_Message.Visible = false;
        }
        #endregion
        private void ResetTab2()
        {
            Tab2_PayComponentList.SelectedIndex = -1;
            Tab2_Amount.Text = "";
            Tab2_ApprRB1.Visible = false;
            Tab2_ApprRB2.Visible = false;
            Tab2_keyField.Text = "";
            Tab2_ApprRB1.Checked = true;
            Tab2_ApprRB2.Checked = false;
        }
        #region Tab3_Reset_Click
        protected void Tab3_Reset_Click(object sender, EventArgs e)
        {
            ResetTab3();
            Tab3_Message.Text = "";
            Tab3_Message.Visible = false;
        }
        #endregion
        private void ResetTab3()
        {
            Tab3_PayComponentList.SelectedIndex = -1;
            Tab3_Amount.Text = "";
            Tab3_ApprRB1.Visible = false;
            Tab3_ApprRB2.Visible = false;
            Tab3_keyField.Text = "";
            Tab3_ApprRB1.Checked = true;
            Tab3_ApprRB2.Checked = false;
        }
        private void ResetTab4()
        {
            Tab4_BankName.SelectedIndex = -1;
            Tab4_EmployeeBankAccount.Text = "";
            Tab4_Message.Text = "";
            Tab4_Message.Visible = false;
            Tab4_keyField.Text = "";
        }

        private void TabSettings()
        {
            message.Visible = false;
            Tab1_Pane.Visible = false;
            Tab2_Pane.Visible = false;
            Tab3_Pane.Visible = false;
            Tab4_Pane.Visible = false;

        }
        protected void tab1_Click(object sender, EventArgs e)
        {
            TabSettings();
            Tab1_Pane.Visible = true;

        }
        protected void tab2_Click(object sender, EventArgs e)
        {
            TabSettings();
            Tab2_Pane.Visible = true;

        }
        protected void tab3_Click(object sender, EventArgs e)
        {
            TabSettings();
            Tab3_Pane.Visible = true;

        }
        protected void tab4_Click(object sender, EventArgs e)
        {
            TabSettings();
            Tab4_Pane.Visible = true;
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
            this.Tab1_Pane.Visible = true;            
            LoadBenefitDeductionList();
            LoadKeyEmployeeInformation(Int32.Parse(this.keyField.Text));
        }
      
        protected void Tab1Grid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            Tab1Grid.CurrentPageIndex = e.NewPageIndex;
            LoadDataList();
        }
        protected void Tab1Grid_EditCommand(object source, DataGridCommandEventArgs e)
        {

            Tab1_keyField.Text = Tab1Grid.DataKeys[e.Item.ItemIndex].ToString();
            this.EmpSearchBox.Visible = false;
            this.EditArea.Visible = true;
            this.Tab1_Pane.Visible = true;
            if (EmptyString(e.Item.Cells[0].Text) != "")
            {
                try
                {
                    Tab1_PayComponentList.SelectedValue = Tab1_PayComponentList.Items.FindByText(e.Item.Cells[0].Text).Value;
                }
                catch (Exception exception)
                {
                    ErrorLogging.LogError(exception, "");
                }

             }
            Tab1_Amount.Text = EmptyString(e.Item.Cells[1].Text);
            Tab1_ApprRB1.Visible = true;
            Tab1_ApprRB2.Visible = true;


            if (EmptyString(EOSPayout.Text) == "Processed")  // EOS Status, may change this later with enum string.
            {
                TableCell edit = (TableCell)e.Item.Controls[4];
                edit.Enabled = false;
                this.Tab1_Message.Text = "This can not be edited/deleted at this stage as End of Service(EOS) Settlement already processed for this employee.";
                this.Tab1_Message.Visible = true;
                this.Tab1_Message.CssClass = "errorMessage";

            }

                    
        }
        protected void Tab1Grid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
                int PaycomponentID = (int)Tab1Grid.DataKeys[(int)e.Item.ItemIndex];
                if (EmptyString(EOSPayout.Text) == "Processed")  // EOS Status, may change this later with enum string.
                {
                    TableCell edit = (TableCell)e.Item.Controls[4];
                    edit.Enabled = false;
                    this.Tab1_Message.Text = "This can not be edited/deleted at this stage as End of Service(EOS) Settlement already processed for this employee.";
                    this.Tab1_Message.Visible = true;
                    this.Tab1_Message.CssClass = "errorMessage";

                }
                else
                {
                    DeleteEmployeeBenefitComponent(PaycomponentID);
                }
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
            if (EmptyString(e.Item.Cells[0].Text) != "")
            {
                try
                {
                    Tab2_PayComponentList.SelectedValue = Tab2_PayComponentList.Items.FindByText(e.Item.Cells[0].Text).Value;
                }
                catch (Exception exception)
                {
                    ErrorLogging.LogError(exception, "");
                }

            }
            Tab2_Amount.Text = EmptyString(e.Item.Cells[1].Text);
            Tab2_ApprRB1.Visible = true;
            Tab2_ApprRB2.Visible = true;
        }

        protected void Tab2Grid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            int PaycomponentID = (int)Tab2Grid.DataKeys[(int)e.Item.ItemIndex];
            DeleteEmployeeIncentiveComponent(PaycomponentID);

        }
        protected void Tab3Grid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            Tab2Grid.CurrentPageIndex = e.NewPageIndex;
            LoadDataList();
        }
        protected void Tab3Grid_EditCommand(object source, DataGridCommandEventArgs e)
        {
            Tab3_keyField.Text = Tab3Grid.DataKeys[e.Item.ItemIndex].ToString();
            this.EmpSearchBox.Visible = false;
            this.EditArea.Visible = true;
            this.Tab3_Pane.Visible = true;
            if (EmptyString(e.Item.Cells[0].Text) != "")
            {
                try
                {
                    Tab3_PayComponentList.SelectedValue = Tab3_PayComponentList.Items.FindByText(e.Item.Cells[0].Text).Value;
                }
                catch (Exception exception)
                {
                    ErrorLogging.LogError(exception, "");
                }

            }
            Tab3_Amount.Text = EmptyString(e.Item.Cells[1].Text);
            Tab3_ApprRB1.Visible = true;
            Tab3_ApprRB2.Visible = true;
        }

        protected void Tab3Grid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            int PaycomponentID = (int)Tab3Grid.DataKeys[(int)e.Item.ItemIndex];
            DeleteEmployeeNonPayrollBenefitComponent(PaycomponentID);

        }


    }
}
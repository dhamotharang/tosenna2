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
    public partial class EmployeeProfile : SchoolNetBase
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
                       
            
          
           // if (!Page.IsPostBack)
           // {
                LoadEmployeeProfile();
             //   LoadEmpStatusLookup(this.empStatusDDList);
             //   LoadDesignationLookup(this.jobTitleDDList);
             //   LoadDivisionLookup(this.businessUnitDDList);
           // }

            if (this.keyField.Text.ToString() != "")
            {
                LoadEContactList();
                LoadDependentsList();
                LoadEmployeePositionList();
                LoadCurrentEntitlement();
                LoadCurrentCompensation();
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

            ECGrid.PageIndexChanged += new DataGridPageChangedEventHandler(ECGrid_PageIndexChanged);
            DPGrid.PageIndexChanged +=new DataGridPageChangedEventHandler(DPGrid_PageIndexChanged);
            EPGrid.PageIndexChanged += new DataGridPageChangedEventHandler(EPGrid_PageIndexChanged);
            EGrid.PageIndexChanged += new DataGridPageChangedEventHandler(EGrid_PageIndexChanged);
            PayGrid.PageIndexChanged += new DataGridPageChangedEventHandler(PayGrid_PageIndexChanged);
            tab1.Click += new EventHandler(tab1_Click);
            tab2.Click += new EventHandler(tab2_Click);
            tab3.Click += new EventHandler(tab3_Click);
            tab4.Click += new EventHandler(tab4_Click);
            tab5.Click += new EventHandler(tab5_Click);
            tab6.Click += new EventHandler(tab6_Click);
            tab7.Click += new EventHandler(tab7_Click);
            tab8.Click += new EventHandler(tab8_Click);           
        }
        #endregion
        private void LockAllControls()
        {

          // if (this.Master != null)
                foreach (Control myControl in this.FindControl("Form").Controls)
                {
                    if (myControl.GetType().Name == "TextBox" )//|| myControl.GetType().Name == "RadioButton" || myControl.GetType().Name == "Dropdownlist" || myControl.GetType().Name == "Checkbox")
                    {
                        TextBox myTextBox = (TextBox)myControl;
                        myTextBox.ReadOnly = true;
                       
                    }
                }
        }
        private void TabSettings()
        {
            message.Visible = false;
            GeneralInfoTab.Visible = false;
            ContactInfoTab.Visible = false;
            DependentTab.Visible = false;
            EmergencyContactTab.Visible = false;
            JobDetailsTab.Visible = false;
            CompensationTab.Visible = false;
            OtherBenefitsTab.Visible = false;
            ManagementChainTab.Visible = false;

        }
        protected void tab1_Click(object sender, EventArgs e)
        {
            TabSettings();
            GeneralInfoTab.Visible = true;

        }
        protected void tab2_Click(object sender, EventArgs e)
        {
            TabSettings();
            ContactInfoTab.Visible = true;
        }
        protected void tab3_Click(object sender, EventArgs e)
        {
            TabSettings();
            LoadDependentsList();
            DependentTab.Visible = true;          
            //  ResetDPFields();
        }
        protected void tab4_Click(object sender, EventArgs e)
        {
            TabSettings();
            LoadEContactList();
            EmergencyContactTab.Visible = true;           
            // ResetEContactFields();

        }
        protected void tab5_Click(object sender, EventArgs e)
        {
            TabSettings();
            JobDetailsTab.Visible = true;

        }
        protected void tab6_Click(object sender, EventArgs e)
        {
            TabSettings();
            CompensationTab.Visible = true;
            LoadBenefitDeductionList();
            LoadCurrentCompensation();
        }
        protected void tab7_Click(object sender, EventArgs e)
        {
            TabSettings();
            OtherBenefitsTab.Visible = true;
            LoadCurrentEntitlement();
        }
        protected void tab8_Click(object sender, EventArgs e)
        {
            TabSettings();
            LoadRootLevelMembers();
            ManagementChainTab.Visible = true;
        }

        #region  LoadDependentsList
        private void LoadDependentsList()
        {
            try
            {
                DataSet _DataList = null;
                _DataList = DatabaseManager.Data.DBAccessManager.RetrieveEmployeeInfo(Int32.Parse(this.keyField.Text.ToString()));
                if (_DataList.Tables[1].Rows.Count > 0)  // Employee Dependent Information.
                {
                    DataTable _empDependentDataTable = _DataList.Tables[1];
                    this.DPGrid.DataSource = _empDependentDataTable;
                    this.DPGrid.DataBind();
                    emptyRow2.Visible = false;
                    emptyRow2.Text = "";

                }
                else
                {
                    this.DPGrid.DataSource = null;
                    this.DPGrid.DataBind();
                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, " "); 
            }
        }
        #endregion
        #region LoadEContactList
        private void LoadEContactList()
        {
            try
            {
                DataSet _DataList = null;
                _DataList = DatabaseManager.Data.DBAccessManager.RetrieveEmployeeInfo(Int32.Parse(this.keyField.Text.ToString()));
                if (_DataList.Tables[2].Rows.Count > 0)  // Employee Emergency Contacts Information.
                {
                    DataTable _empECDataTable = _DataList.Tables[2];
                    this.ECGrid.DataSource = _empECDataTable;
                    this.ECGrid.DataBind();
                    emptyRow1.Visible = false;
                    emptyRow1.Text = "";

                }
                else
                {
                    this.ECGrid.DataSource = null;
                    this.ECGrid.DataBind();
                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, " "); 
            }
        }
        #endregion 
        #region LoadEmployeePositionList
        private void LoadEmployeePositionList()
        {
            try
            {
                DataSet _DataList = null;
                _DataList = DatabaseManager.Data.DBAccessManager.RetrieveEmployeeInfo(Int32.Parse(this.keyField.Text.ToString()));
                if (_DataList.Tables[4].Rows.Count > 0)  // Employee Emergency Contacts Information.
                {
                    DataTable _DataTable = _DataList.Tables[4];
                    this.EPGrid.DataSource = _DataTable;
                    this.EPGrid.DataBind();
                }
                else
                {
                    this.EPGrid.DataSource = null;
                    this.EPGrid.DataBind();
                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, " ");
            }
        }
         #endregion

        #region LoadCurrentEntitlement()
        private void LoadCurrentEntitlement()
        {
            try
            {
                DataSet _DataList = null;
                _DataList = DatabaseManager.Data.DBAccessManager.RetrieveLeaveEntitlements(Int32.Parse(keyField.Text.ToString()));

                if (_DataList.Tables[0].Rows.Count > 0)
                {
                    this.EGrid.DataSource = _DataList;
                    this.EGrid.DataBind();
                }
                else
                {
                    this.EGrid.DataSource = null;
                    this.EGrid.DataBind();
                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, " ");
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
                        this.BTGrid.DataSource = _BenefitTable;
                        this.BTGrid.DataBind();

                    }
                    else
                    {
                        this.BTGrid.DataSource = null;
                        this.BTGrid.DataBind();
                    }
                    if (_DataList.Tables[1].Rows.Count > 0) // Deductions Information
                    {
                        DataTable _DeductionTable = _DataList.Tables[1];
                        this.DedGrid.DataSource = _DeductionTable;
                        this.DedGrid.DataBind();
                    }
                    else
                    {
                        this.DedGrid.DataSource = null;
                        this.DedGrid.DataBind();
                    }
                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }

        }
        #endregion


        #region LoadCurrentCompensation()
        private void LoadCurrentCompensation()
        {
            try
            {
                DataSet _DataList = null;
                _DataList = DatabaseManager.Data.DBAccessManager.RetrieveEmployeeCompensation_CurrentYr(Int32.Parse(keyField.Text.ToString()));
                if (_DataList.Tables.Count > 0)
                {
                    if (_DataList.Tables[0].Rows.Count > 0) // Table 0: Payroll Summary Info
                    {
                        DataRow _DataRow = _DataList.Tables[0].Rows[0];
                        Tab6_EarningsYTD.Text = FormatTwoDecimals(_DataRow["YTDEarnings"].ToString());
                        Tab6_LOPDeductYTD.Text =FormatTwoDecimals(_DataRow["YTDLOPDeductions"].ToString());
                        Tab6_OtherLOPDeductYTD.Text = FormatTwoDecimals(_DataRow["YTDOtherDeductions"].ToString());
                        Tab6_NetEarningsYTD.Text = FormatTwoDecimals(_DataRow["NetPay"].ToString());
                        if (_DataRow["EOSPayout"].ToString() == "1")
                        { Tab6_EOSCheckBox1.Checked = true; }
                        else
                        { Tab6_EOSCheckBox1.Checked = false; }
                        Tab6_lblCurrencyName.Text = "(All Figures in " + _DataRow["CurrencyCode"].ToString() + ')';
                  
                    }
                    if (_DataList.Tables[1].Rows.Count > 0) // Table 1: Monthly Payroll data
                    {
                        this.PayGrid.DataSource = _DataList.Tables[1];
                        this.PayGrid.DataBind();
                    }
                    else
                    {
                        this.PayGrid.DataSource = null;
                        this.PayGrid.DataBind();
                    }

                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, " ");
            }
        }
        #endregion


        #region LoadRootLevelMembers();
        private void LoadRootLevelMembers()
        {
            try
            {
                MyOrgTree.Nodes.Clear();
                DataSet _DataList = null;
                _DataList = DatabaseManager.Data.DBAccessManager.RetrieveMyOrgRootMember(Int32.Parse(this.keyField.Text.ToString()));

                if (_DataList.Tables[0].Rows.Count > 0)
                {
                    DataRow _DataRow = _DataList.Tables[0].Rows[0];
                    if (_DataRow["LineManagerID"] == DBNull.Value)
                    {
                        TreeNode treeRoot = new TreeNode();
                        treeRoot.Text = _DataRow["FullName"].ToString();
                        treeRoot.Value = _DataRow["EmpID"].ToString();
                        treeRoot.ImageUrl = "~/Images/oInboxF.gif";
                        treeRoot.ExpandAll();
                        MyOrgTree.Nodes.Add(treeRoot);

                        foreach (TreeNode childnode in GetChildNode(Convert.ToInt32(_DataRow["EmpId"])))
                        {
                            treeRoot.ChildNodes.Add(childnode);
                        }
                    }

                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }
        }
        #endregion

        private TreeNodeCollection GetChildNode(Int32 parentid)
        {
            TreeNodeCollection childtreenodes = new TreeNodeCollection();

            DataView dataView1 = null;
            DataSet _DataList = null;
            _DataList = DatabaseManager.Data.DBAccessManager.RetrieveMyOrgRootMember(Int32.Parse(this.keyField.Text.ToString()));
            DataTable dt = _DataList.Tables[0];
            dataView1 = new DataView(dt);
            String strFilter = "LineManagerID" + "=" + parentid.ToString() + "";
            dataView1.RowFilter = strFilter;

            if (dataView1.Count > 0)
            {
                foreach (DataRow dataRow in dataView1.ToTable().Rows)
                {
                    TreeNode childNode = new TreeNode();
                    childNode.Text = dataRow["FullName"].ToString();
                    childNode.Value = dataRow["EmpId"].ToString();
                    childNode.ImageUrl = "~/Images/Folder.gif";
                    childNode.ExpandAll();

                    foreach (TreeNode cnode in GetChildNode
            (Convert.ToInt32(dataRow["EmpId"])))
                    {
                        childNode.ChildNodes.Add(cnode);
                    }
                    childtreenodes.Add(childNode);
                }
            }
            return childtreenodes;
        }

        private void ClearNodes(TreeNodeCollection tnc)
        {
            foreach (TreeNode n in tnc)
            {
                n.Selected = false;
                ClearNodes(n.ChildNodes);
            }
        }

       
        protected void ECGrid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            ECGrid.CurrentPageIndex = e.NewPageIndex;
            LoadEContactList();


        }
      
        protected void DPGrid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            DPGrid.CurrentPageIndex = e.NewPageIndex;
            LoadDependentsList();

        }
        protected void EPGrid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            EPGrid.CurrentPageIndex = e.NewPageIndex;
            LoadEmployeePositionList();
        }
        protected void EGrid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            EGrid.CurrentPageIndex = e.NewPageIndex;
            LoadCurrentEntitlement();
        }
        protected void PayGrid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            PayGrid.CurrentPageIndex = e.NewPageIndex;
            LoadCurrentCompensation();
        }
        private void LoadEmployeeProfile()
        {
            if (Page.User.Identity.Name.ToString() != null)
            {
                this.keyField.Text = Page.User.Identity.Name.ToString();
                this.EditArea.Visible = true;
                this.GeneralInfoTab.Visible = true;
                // Load dropdown Controls.
                LoadVisaType(this.Tab1_VisaType);
                LoadCountryList(this.Tab1_PassportCountryDDList);
                LoadCountryList(this.Tab1_VisaCountryDDList);
                LoadCountryList(Tab1_LaborCardCountryDDList);
                LoadCountryList(this.Tab2_CountryDDList);
                LoadCountryList(this.Tab2_WCountryDDList);
             
                try
                {
                    // Gather Employee Information.
                    DataSet _DataList = null;
                    _DataList = DatabaseManager.Data.DBAccessManager.RetrieveEmployeeInfo(Int32.Parse(this.keyField.Text.ToString()));
                    if (_DataList.Tables.Count > 0)
                    {
                        if (_DataList.Tables[0].Rows.Count > 0) // General Employee/Job details Information
                        {
                            DataRow _employeeDataRow = _DataList.Tables[0].Rows[0];
                            Tab1_FName.Text = _employeeDataRow["F_Name"].ToString();
                            Tab1_MidName.Text = _employeeDataRow["Mid_Initial"].ToString();
                            Tab1_LName.Text = _employeeDataRow["L_Name"].ToString();
                            lblEmployeeName.Text = Tab1_FName.Text + " " + Tab1_MidName.Text + " " + Tab1_LName.Text;
                            lblDivision.Text = _employeeDataRow["DivisionName"].ToString();
                            lblDivisionLocation.Text = _employeeDataRow["DivisionLocationName"].ToString();
                            LoadGenderType(this.Tab1_GenderType);
                            Tab1_GenderType.SelectedValue = _employeeDataRow["GenderID"].ToString();
                            Tab1_DOB.Text = _employeeDataRow["DOB"].ToString();
                            LoadMaritalStatus(this.Tab1_MaritalStatus);
                            Tab1_MaritalStatus.SelectedValue = _employeeDataRow["MaritalStatus_ID"].ToString();
                            LoadEducationList(this.Tab1_Education);
                            if (_employeeDataRow["EducationID"].ToString() != "")
                            {
                                Tab1_Education.SelectedValue = _employeeDataRow["EducationID"].ToString();
                            }
                            Tab1_Citizenship.Text = _employeeDataRow["Citizenship"].ToString();

                            if (_employeeDataRow["Photo_Path"].ToString() != "")
                            {
                                this.profile.ImageUrl = Page.ResolveUrl("~\\PhotoProfiles\\" + _employeeDataRow["Photo_Path"].ToString());

                            }
                            else
                            {
                                this.profile.ImageUrl = Page.ResolveUrl("~\\PhotoProfiles\\" + "d_Photo.jpg");
                            }
                            Tab1_Age.Text = _employeeDataRow["Age"].ToString();
                            lblSuperVisorName.Text = _employeeDataRow["SupervisorName"].ToString();
                            lblSuperVisor_Phone.Text = _employeeDataRow["Supervisor_Phone"].ToString();
                            lblSuperVisor_EmailAddress.Text = _employeeDataRow["Supervisor_Email"].ToString();
                            lblSuperVisor_JobLocation.Text = _employeeDataRow["Supervisor_WorkLocation"].ToString();
                            lblSuperVisor_JobTitle.Text = _employeeDataRow["Supervisor_Designation"].ToString();
                            lblSuperVisor_Division.Text = _employeeDataRow["Supervisor_Division"].ToString();
                            lblSuperVisor_DivisionLocation.Text = _employeeDataRow["Supervisor_BULocation"].ToString();
                            // Job Details Tab Information.

                            LoadEmpStatusLookup(Tab5_EmpStatusDDList);
                            LoadDesignationLookup(Tab5_DesignationDDList);
                            LoadDivisionLookup(Tab5_DivisonDDList);
                            this.LoadEmpCategoryLookup(Tab5_EmpCategoryDDList);
                            this.LoadDepartmentLookup(Tab5_DepartmentDDList);
                            LoadSupervisorsListLookup(Tab5_SupervisorDDList);


                            Tab5_EmpID.Text = _employeeDataRow["Employee_ID"].ToString();
                            if (_employeeDataRow["DesignationID"].ToString() != "")
                            {
                                Tab5_DesignationDDList.SelectedValue = _employeeDataRow["DesignationID"].ToString();
                                lblJobTitle.Text = Tab5_DesignationDDList.SelectedItem.ToString();
                            }
                            if (_employeeDataRow["EmployeeStatusID"].ToString() != "")
                            {
                                Tab5_EmpStatusDDList.SelectedValue = _employeeDataRow["EmployeeStatusID"].ToString();
                            }
                            if (_employeeDataRow["EmployeeCategoryID"].ToString() != "")
                            {
                                Tab5_EmpCategoryDDList.SelectedValue = _employeeDataRow["EmployeeCategoryID"].ToString();
                            }

                            if (_employeeDataRow["DepartmentID"].ToString() != "")
                            {
                                Tab5_DepartmentDDList.SelectedValue = _employeeDataRow["DepartmentID"].ToString();
                            }
                            if (_employeeDataRow["DivisionID"].ToString() != "")
                            {
                                Tab5_DivisonDDList.SelectedValue = _employeeDataRow["DivisionID"].ToString();
                            }
                            Tab5_HireDate.Text = _employeeDataRow["HireDate"].ToString();
                            Tab5_OriginalHDate.Text = _employeeDataRow["OriginalHireDate"].ToString();
                            Tab5_ResignedDate.Text = _employeeDataRow["Date_Resigned"].ToString();
                            Tab5_DateLeft.Text = _employeeDataRow["Date_Left"].ToString();
                            Tab5_TotalServiceYears.Text = _employeeDataRow["TotalYears_Service"].ToString();
                            Tab5_ProbabtionYears.Text = _employeeDataRow["Probation_Period"].ToString();
                            Tab5_ProbationEndDate.Text = _employeeDataRow["Probation_EndDate"].ToString();
                            if (_employeeDataRow["Probation_Completed"].ToString() == "1")
                            {
                                Tab5_ProbationCompletedCheckBox.Checked = true;
                                Tab5_ProbationCompletedCheckBox.Enabled = false;
                                Tab5_ProbationEndDate.Enabled = false;
                                Tab5_ProbabtionYears.Enabled = false;
                            }
                            else
                            { Tab5_ProbationCompletedCheckBox.Checked = false; }


                            if (_employeeDataRow["SupervisoryRole"].ToString() == "1")
                            { Tab5_SupervisoryCheckBox.Checked = true; }
                            else
                            { Tab5_SupervisoryCheckBox.Checked = false; }

                            if (_employeeDataRow["LineManagerID"].ToString() != "")
                            {
                                Tab5_SupervisorDDList.SelectedValue = _employeeDataRow["LineManagerID"].ToString();
                            }


                            // Immigration Information

                            if (_employeeDataRow["Visa_TypeID"].ToString() != "")
                            {
                                Tab1_VisaType.SelectedValue = _employeeDataRow["Visa_TypeID"].ToString();
                            }

                            if (_employeeDataRow["PP_IssueCountryID"].ToString() != "")
                            {
                                Tab1_PassportCountryDDList.SelectedValue = _employeeDataRow["PP_IssueCountryID"].ToString();
                            }

                            if (_employeeDataRow["Visa_IssueCountryID"].ToString() != "")
                            {
                                Tab1_VisaCountryDDList.SelectedValue = _employeeDataRow["Visa_IssueCountryID"].ToString();
                            }
                            Tab1_PassportNo.Text = _employeeDataRow["PassportNumber"].ToString();
                            Tab1_VisaNumber.Text = _employeeDataRow["Visa_Number"].ToString();
                            Tab1_VisaExpiryDate.Text = _employeeDataRow["Visa_ExpiryDate"].ToString();
                            Tab1_VisaIssueDate.Text = _employeeDataRow["Visa_IssueDate"].ToString();
                            Tab1_PassportIssueDate.Text = _employeeDataRow["PP_IssueDate"].ToString();
                            Tab1_PassportExpiryDate.Text = _employeeDataRow["PP_ExpiryDate"].ToString();
                            Tab1_LaborCardNo.Text = _employeeDataRow["LaborCardNumber"].ToString();
                            Tab1_LaborCardIssueDate.Text = _employeeDataRow["LaborCardIssueDate"].ToString();
                            Tab1_LaborCardExpiryDate.Text = _employeeDataRow["LaborCardExpiryDate"].ToString();
                            if (_employeeDataRow["LaborCardIssueCountryID"].ToString() != "")
                            {
                                Tab1_LaborCardCountryDDList.SelectedValue = _employeeDataRow["LaborCardIssueCountryID"].ToString();
                            }

                            // Employee Contact Information.

                            Tab2_HAddress1.Text = _employeeDataRow["Home_Addr1"].ToString();
                            Tab2_HAddress2.Text = _employeeDataRow["Home_Addr2"].ToString();
                            Tab2_WAddress1.Text = _employeeDataRow["Work_Addr1"].ToString();
                            Tab2_WAddress2.Text = _employeeDataRow["Work_Addr2"].ToString();
                            Tab2_HCity.Text = _employeeDataRow["City"].ToString();
                            Tab2_HState.Text = _employeeDataRow["Home_State"].ToString();
                            if (_employeeDataRow["Home_CountryID"].ToString() != "")
                            {
                                Tab2_CountryDDList.SelectedValue = _employeeDataRow["Home_CountryID"].ToString();
                            }
                            if (_employeeDataRow["Work_CountryID"].ToString() != "")
                            {
                                Tab2_WCountryDDList.SelectedValue = _employeeDataRow["Work_CountryID"].ToString();
                            }
                            Tab2_WCity.Text = _employeeDataRow["Work_City"].ToString();
                            Tab5_City.Text = _employeeDataRow["Work_City"].ToString();
                            Tab2_WState.Text = _employeeDataRow["Work_State"].ToString();
                            lblJobLocation.Text = Tab5_City.Text + '/' + Tab5_CountryName.Text;
                            Tab2_HPhone.Text = _employeeDataRow["Home_Phone"].ToString();
                            Tab2_Mobile.Text = _employeeDataRow["Mobile_Phone"].ToString();
                            Tab2_WPhone.Text = _employeeDataRow["Work_Phone"].ToString();
                            Tab2_WorkEmail.Text = _employeeDataRow["Work_Email"].ToString();
                            lblWorkPhone.Text = _employeeDataRow["Work_Phone"].ToString();
                            lblMobile.Text = _employeeDataRow["Mobile_Phone"].ToString();
                            lblEmailAddress.Text = _employeeDataRow["Work_Email"].ToString();
                        }


                        if (_DataList.Tables[1].Rows.Count > 0)  // Employee Dependent Information.
                        {
                            DataRow _empDependentDataRow = _DataList.Tables[1].Rows[0];
                            DataTable _empDependentDataTable = _DataList.Tables[1];

                            if (_DataList.Tables[3].Rows.Count > 0)
                            {
                                this.DPGrid.DataSource = _empDependentDataTable;
                                this.DPGrid.DataBind();
                            }
                            else
                            {
                                emptyRow2.Visible = true;
                                emptyRow2.Text = "No Dependents Information Available.";
                                emptyRow2.CssClass = "errorMessage";
                            }

                        }
                        else
                        {
                            emptyRow2.Visible = true;
                            emptyRow2.Text = "No Dependents Information Available.";
                            emptyRow2.CssClass = "errorMessage";
                        }

                        if (_DataList.Tables[2].Rows.Count > 0)  // Employee Emergency contact Information.
                        {
                            DataRow _empECDataRow = _DataList.Tables[2].Rows[0];
                            DataTable _empECDataTable = _DataList.Tables[2];

                            if (_DataList.Tables[4].Rows.Count > 0)
                            {
                                this.ECGrid.DataSource = _empECDataTable;
                                this.ECGrid.DataBind();


                            }
                            else
                            {
                                emptyRow1.Visible = true;
                                emptyRow1.Text = "No Emergency Contacts Available.";
                                emptyRow1.CssClass = "errorMessage";
                            }

                        }
                        else
                        {
                            emptyRow1.Visible = true;
                            emptyRow1.Text = "No Emergency Contacts Available.";
                            emptyRow1.CssClass = "errorMessage";
                        }

                    }
                }
                catch (Exception exception)
                {
                    ErrorLogging.LogError(exception, "");
                }
            }
        }

    }
}
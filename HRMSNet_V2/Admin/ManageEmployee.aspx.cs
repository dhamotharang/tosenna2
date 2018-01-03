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
    public partial class ManageEmployee : SchoolNetBase
    {
       // protected HtmlInputFile Tab8_FileName;
       
        protected void Page_Load(object sender, EventArgs e)
        {
           
 
            if (!Page.IsPostBack)
            {
                LoadEmpStatusLookup(this.empStatusDDList);
                LoadDesignationLookup(this.jobTitleDDList);
                LoadDivisionLookupByEmpId(businessUnitDDList, Int32.Parse(Page.User.Identity.Name.ToString()));
                LoadEntityLocationLookupByEmpId_DivisionID(DivisionLocationList, Int32.Parse(Page.User.Identity.Name.ToString()), Int32.Parse(businessUnitDDList.SelectedValue));

            }
            else
            {
              //    LoadEntityLocationLookupByDivisionID(Tab5_DivisionLocationDDList, Int32.Parse(Tab5_DivisonDDList.SelectedValue));
              //    LoadSupervisorsListLookupByDivisionID(Tab5_SupervisorDDList, Int32.Parse(Tab5_DivisonDDList.SelectedValue));
            }
            if (Int32.Parse(DivisionLocationList.SelectedValue) == -1)
            {
                LoadEntityLocationLookupByEmpId_DivisionID(DivisionLocationList, Int32.Parse(Page.User.Identity.Name.ToString()), Int32.Parse(businessUnitDDList.SelectedValue));
            }
         //   if (Int32.Parse(Tab5_DivisionLocationDDList.SelectedValue) == -1)
         //   {
                
           // }

            LoadDataList();
            if (this.keyField.Text.ToString() != "")
            {
                LoadEContactList();
                LoadDependentsList();
                LoadEmployeeDocs();
                LoadEmployeePositionList();
                LoadEmployeeTransferList();
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

            Grid.PageIndexChanged += new DataGridPageChangedEventHandler(this.Grid_PageIndexChanged);
            Grid.SortCommand +=new DataGridSortCommandEventHandler(Grid_SortCommand);
            ECGrid.PageIndexChanged += new DataGridPageChangedEventHandler(ECGrid_PageIndexChanged);
            DOCGrid.PageIndexChanged +=new DataGridPageChangedEventHandler(DOCGrid_PageIndexChanged);
            EPGrid.PageIndexChanged +=new DataGridPageChangedEventHandler(EPGrid_PageIndexChanged);
            ETGrid.PageIndexChanged += new DataGridPageChangedEventHandler(ETGrid_PageIndexChanged);            
            PayGrid.PageIndexChanged += new DataGridPageChangedEventHandler(PayGrid_PageIndexChanged);
            Tab5_DivisonDDList.SelectedIndexChanged +=new EventHandler(Tab5_DivisonDDList_SelectedIndexChanged);
            Search.Click += new ImageClickEventHandler(Search_Click);
            Reset.Click += new ImageClickEventHandler(Reset_Click);
            tab1.Click += new EventHandler(tab1_Click);
            tab2.Click += new EventHandler(tab2_Click); 
            tab3.Click += new EventHandler(tab3_Click);
            tab4.Click += new EventHandler(tab4_Click);
            tab5.Click += new EventHandler(tab5_Click);
            tab6.Click += new EventHandler(tab6_Click);
            tab7.Click += new EventHandler(tab7_Click);
            tab8.Click += new EventHandler(tab8_Click);   
            Personal_Save.Click +=new EventHandler(Personal_Save_Click);
            Contact_Save.Click +=new EventHandler(Contact_Save_Click);
            DP_Save.Click +=new EventHandler(DP_Save_Click);
            DP_Cancel.Click +=new EventHandler(DP_Cancel_Click);
            EC_Save.Click +=new EventHandler(EC_Save_Click);
            EC_Cancel.Click +=new EventHandler(EC_Cancel_Click);
            Job_Save.Click +=new EventHandler(Job_Save_Click);
            Doc_Upload.Click +=new EventHandler(Doc_Upload_Click);
            Export.Click += new ImageClickEventHandler(Export_Click);
            Tab1_Back.Click += new EventHandler(Tab_Back_Click);
            Tab2_Back.Click += new EventHandler(Tab_Back_Click);
            Tab3_Back.Click += new EventHandler(Tab_Back_Click);
            Tab4_Back.Click += new EventHandler(Tab_Back_Click);
            Tab5_Back.Click += new EventHandler(Tab_Back_Click);
            Tab6_Back.Click += new EventHandler(Tab_Back_Click);
            Tab7_Back.Click += new EventHandler(Tab_Back_Click);
            Tab8_Back.Click += new EventHandler(Tab_Back_Click);
        }
        #endregion
        protected void Tab5_DivisonDDList_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadEntityLocationLookupByDivisionID(Tab5_DivisionLocationDDList, Int32.Parse(Tab5_DivisonDDList.SelectedValue));
            LoadSupervisorsListLookupByDivisionID(Tab5_SupervisorDDList, Int32.Parse(Tab5_DivisonDDList.SelectedValue));
            LoadDepartmentLookupByDivisionId(Tab5_DepartmentDDList, Int32.Parse(Tab5_DivisonDDList.SelectedValue));
        }

         protected void Tab_Back_Click(object sender, EventArgs e)
        {
            TabSettings();
            this.keyField.Text = "";
            Grid.EditItemIndex = -1;
            this.EmpSearchBox.Visible = true;
            this.searchDataArea.Visible = true;
            this.EditArea.Visible = false;


        }

        #region Load LoadDataList
        private void LoadDataList()
        {
            try
            {
                DataSet _DataList = null;
                if (ViewState["myDataSet"] == null)   // No such value in view state, take appropriate action.
                {
                    _DataList = DatabaseManager.Data.DBAccessManager.RetrieveEmployeeList_Search(Int32.Parse(Page.User.Identity.Name.ToString()), empName.Text.ToString(), empID.Text.ToString(), mgrName.Text.ToString(), Int32.Parse(empStatusDDList.SelectedValue), Int32.Parse(jobTitleDDList.SelectedValue), Int32.Parse(businessUnitDDList.SelectedValue), Int32.Parse(DivisionLocationList.SelectedValue));
                    if (_DataList.Tables[0].Rows.Count > 0)
                    {
                        this.Grid.DataSource = _DataList;
                        this.Grid.DataBind();
                        emptyRow.Text = "";
                        emptyRow.Visible = false;
                        Export.Visible = true;
                        SetViewState(_DataList);

                    }
                    else
                    {
                        this.Grid.DataSource = null;
                        this.Grid.DataBind();
                        emptyRow.Visible = true;
                        emptyRow.CssClass = "errorMessage";
                        emptyRow.Text = "There are no matching records found.";
                        Export.Visible = false;
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
                 Grid.CurrentPageIndex = 0;
                 Grid.DataBind();
            }


        }
        #endregion
        protected void Export_Click(object sender, EventArgs e)
        {
             DataSet _DataList = null;
            _DataList = DatabaseManager.Data.DBAccessManager.RetrieveEmployeeList_Search(Int32.Parse(Page.User.Identity.Name.ToString()),empName.Text.ToString(), empID.Text.ToString(), mgrName.Text.ToString(),Int32.Parse(empStatusDDList.SelectedValue),Int32.Parse(jobTitleDDList.SelectedValue),Int32.Parse(businessUnitDDList.SelectedValue),Int32.Parse(DivisionLocationList.SelectedValue));

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
            Response.AddHeader("content-disposition", "attachment;filename=EmployeeMaster.xls");
           // Response.ContentEncoding = Encoding.UTF8;
            Response.Charset = "";
            EnableViewState = false;
            String ReportTitle = "<B>Employee Master Data Report for : " + businessUnitDDList.SelectedItem.ToString() + " As of " + DateTime.Now.ToString(@"dd/MM/yyyy"); 

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

        private void TabSettings()
        {
            message.Visible = false;
            GeneralInfoTab.Visible = false;
            ContactInfoTab.Visible = false;
            DependentTab.Visible = false;
            EmergencyContactTab.Visible = false;
            JobDetailsTab.Visible = false;
            ManagementChainTab.Visible = false;
            EmployeeDocumentsTab.Visible = false;
            CompensationTab.Visible = false;
            
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
            DPmessage.Text = "";
            DPmessage.Visible = false;
            //  ResetDPFields();
        }
        protected void tab4_Click(object sender, EventArgs e)
        {
            TabSettings();
            LoadEContactList();
            EmergencyContactTab.Visible = true;
            ECmessage.Text = "";
            ECmessage.Visible = false;
  
        }
        protected void tab5_Click(object sender, EventArgs e)
        {
            TabSettings();
            LoadEmployeePositionList();
            LoadEmployeeTransferList();
            JobDetailsTab.Visible = true;

        }
        protected void tab6_Click(object sender, EventArgs e)
        {
            TabSettings();
            LoadRootLevelMembers();
            ManagementChainTab.Visible = true;
        }
        protected void tab7_Click(object sender, EventArgs e)
        {
            TabSettings();
            LoadEmployeeDocs();
            EmployeeDocumentsTab.Visible = true;
            docmessage.Text = "";
            docmessage.Visible = false;
        }
        protected void tab8_Click(object sender, EventArgs e)
        {
            TabSettings();
            CompensationTab.Visible = true;
            LoadCurrentCompensation();
        }


        #region  LoadDependentsList
        private void LoadDependentsList()
        {
            DataTable _empDependentDataTable = null;
            try
            {                
                DataSet _DataList = null;
                _DataList = DatabaseManager.Data.DBAccessManager.RetrieveEmployeeInfo(Int32.Parse(this.keyField.Text.ToString()));
                if (_DataList.Tables[1].Rows.Count > 0)  // Employee Dependent Information.
                {
                     _empDependentDataTable = _DataList.Tables[1];
                    this.DPGrid.DataSource = _empDependentDataTable;
                    this.DPGrid.DataBind();
                    DPmessage.Text = "";
                    DPmessage.Visible = false;
                    emptyRow2.Text = "";
                    emptyRow2.Visible = false;

                }
                else
                {
                  
                    this.DPGrid.DataSource = null;
                    this.DPGrid.DataBind();
                }
            }
            catch (Exception exception)
            {
                if (DPGrid.CurrentPageIndex >= DPGrid.PageCount)
                {
                    DPGrid.CurrentPageIndex -= 1;
                    this.DPGrid.DataSource = _empDependentDataTable;
                    this.DPGrid.DataBind();

                }
                else
                {
                    ErrorLogging.LogError(exception, " ");
                }
            }
         }
        #endregion
        #region LoadEContactList
        private void LoadEContactList()
        {
            DataTable _empECDataTable = null;
            try
            {
                DataSet _DataList = null;
                _DataList = DatabaseManager.Data.DBAccessManager.RetrieveEmployeeInfo(Int32.Parse(this.keyField.Text.ToString()));
                if (_DataList.Tables[2].Rows.Count > 0)  // Employee Emergency Contacts Information.
                {
                   
                    _empECDataTable = _DataList.Tables[2];
                    this.ECGrid.DataSource = _empECDataTable;
                    this.ECGrid.DataBind();
                    ECmessage.Text = "";
                    ECmessage.Visible = false;
                    emptyRow1.Text = "";
                    emptyRow1.Visible = false;

                }
                else
                {
                    this.ECGrid.DataSource = null;
                    this.ECGrid.DataBind();
                }
            }
            catch (Exception exception)
            {
                if (ECGrid.CurrentPageIndex >= ECGrid.PageCount)
                {
                    ECGrid.CurrentPageIndex -= 1; 
                    this.ECGrid.DataSource = _empECDataTable;
                    this.ECGrid.DataBind();
                    
                }
                else
                {
                    ErrorLogging.LogError(exception, " ");
                }
            }
        }
        #endregion
        #region  LoadEmployeeDocs
        private void LoadEmployeeDocs()
        {
            DataTable _empDocDataTable = null;
            try
            {
                DataSet _DataList = null;                
                _DataList = DatabaseManager.Data.DBAccessManager.RetrieveEmployeeInfo(Int32.Parse(this.keyField.Text.ToString()));
                if (_DataList.Tables[3].Rows.Count > 0)  // Employee Document Information.
                {
                    _empDocDataTable = _DataList.Tables[3];
                    this.DOCGrid.DataSource = _empDocDataTable;
                    this.DOCGrid.DataBind();
                    docmessage.Text = "";
                    docmessage.Visible = false;
                    emptyRow3.Text = "";
                    emptyRow3.Visible = false;
                }
                else
                {
                    this.DOCGrid.DataSource = null;
                    this.DOCGrid.DataBind();
                }
            }
            catch (Exception exception)
            {
                if (DOCGrid.CurrentPageIndex >= DOCGrid.PageCount)
                {
                    DOCGrid.CurrentPageIndex -= 1;
                    DOCGrid.DataSource = _empDocDataTable;
                    DOCGrid.DataBind();
                }
                else
                {
                    ErrorLogging.LogError(exception, " ");
                }
            }
        }
       #endregion
        #region LoadEmployeePositionList
        private void LoadEmployeePositionList()
        {
            DataTable _DataTable = null;
            try
            {
                DataSet _DataList = null;
                _DataList = DatabaseManager.Data.DBAccessManager.RetrieveEmployeeInfo(Int32.Parse(this.keyField.Text.ToString()));
                if (_DataList.Tables[4].Rows.Count > 0)  // Employee Emergency Contacts Information.
                {
                     _DataTable = _DataList.Tables[4];
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
                if (EPGrid.CurrentPageIndex >= EPGrid.PageCount)
                {
                    EPGrid.CurrentPageIndex -= 1;
                    EPGrid.DataSource = _DataTable;
                    EPGrid.DataBind();
                }
                else
                {
                    ErrorLogging.LogError(exception, " ");
                }
            }
        }
       #endregion

        #region LoadEmployeeTransferList
        private void LoadEmployeeTransferList()
        {
            DataTable _DataTable = null;
            try
            {
                DataSet _DataList = null;
                _DataList = DatabaseManager.Data.DBAccessManager.RetrieveEmployeeInfo(Int32.Parse(this.keyField.Text.ToString()));
                if (_DataList.Tables[5].Rows.Count > 0)  // Employee Transfer List.
                {
                    _DataTable = _DataList.Tables[5];
                    this.ETGrid.DataSource = _DataTable;
                    this.ETGrid.DataBind();
                }
                else
                {
                    this.ETGrid.DataSource = null;
                    this.ETGrid.DataBind();
                }
            }
            catch (Exception exception)
            {
                if (ETGrid.CurrentPageIndex >= ETGrid.PageCount)
                {
                    ETGrid.CurrentPageIndex -= 1;
                    ETGrid.DataSource = _DataTable;
                    ETGrid.DataBind();
                }
                else
                {
                    ErrorLogging.LogError(exception, " ");
                }
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
                        Tab8_EarningsYTD.Text = FormatTwoDecimals(_DataRow["YTDEarnings"].ToString());
                        Tab8_LOPDeductYTD.Text = FormatTwoDecimals(_DataRow["YTDLOPDeductions"].ToString());
                        Tab8_OtherLOPDeductYTD.Text = FormatTwoDecimals(_DataRow["YTDOtherDeductions"].ToString());
                        Tab8_NetEarningsYTD.Text = FormatTwoDecimals(_DataRow["NetPay"].ToString());
                        if (_DataRow["EOSPayout"].ToString() == "1")
                        { Tab8_EOSCheckBox1.Checked = true; }
                        else
                        { Tab8_EOSCheckBox1.Checked = false; }
                        Tab8_lblCurrencyName.Text = "(All Figures in " + _DataRow["CurrencyCode"].ToString() + ')';

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

    
        protected void Personal_Save_Click(object sender, EventArgs e)
        {
           
         try
			{
                if (Page.IsValid == true)
                {


                    String Result = DatabaseManager.Data.DBAccessManager.Update_Emp_GeneralInfo(Int32.Parse(keyField.Text.ToString()), Tab1_FName.Text.ToString(), Tab1_MidName.Text.ToString(), Tab1_LName.Text.ToString(), ConvertDMY_MDY(Tab1_DOB), this.Tab1_Citizenship.Text.ToString(), this.Tab1_VisaNumber.Text.ToString(), ConvertDMY_MDY(Tab1_VisaIssueDate), ConvertDMY_MDY(Tab1_VisaExpiryDate), Tab1_PassportNo.Text.ToString(), ConvertDMY_MDY(Tab1_PassportExpiryDate), ConvertDMY_MDY(Tab1_PassportIssueDate), Int32.Parse(Tab1_GenderType.SelectedValue), Int32.Parse(Tab1_MaritalStatus.SelectedValue), Int32.Parse(Tab1_Education.SelectedValue), Int32.Parse(Tab1_VisaType.SelectedValue), Int32.Parse(Tab1_PassportCountryDDList.SelectedValue), Int32.Parse(Tab1_VisaCountryDDList.SelectedValue), Tab1_LaborCardNo.Text.ToString(), ConvertDMY_MDY(Tab1_LaborCardIssueDate), ConvertDMY_MDY(Tab1_LaborCardExpiryDate), Int32.Parse(Tab1_LaborCardCountryDDList.SelectedValue), this.Tab1_BVisaNumber.Text.ToString(), ConvertDMY_MDY(Tab1_BVisaIssueDate), ConvertDMY_MDY(Tab1_BVisaExpiryDate),Int32.Parse(Tab1_BVisaCountryDDList.SelectedValue),Tab1_PersonID.Text.ToString(),Int32.Parse(Page.User.Identity.Name.ToString()));

                    this.message.Visible = true;
                    this.message.CssClass = "errorMessage";
                    if (Result == "")
                    {
                        this.message.Text = "Successfully saved.";

                    }
                    else
                    {
                        this.message.Text = Result;
                        this.message.CssClass = "errorMessage";

                    }
                }			
			}
			catch(Exception exception)
			{
				this.message.Visible = true;
				this.message.Text    = ErrorLogging.LogError(exception,"Unknown Exception Occured. Please contact support.");
				this.message.CssClass="errorMessage";
			}
            //LoadEmployeePositionList();
            LoadEmployeeInformation(Int32.Parse(this.keyField.Text));
	    }
        protected void Contact_Save_Click(object sender, EventArgs e)
        {

            try
            {
                if (Page.IsValid == true)
                {
                    String Result = DatabaseManager.Data.DBAccessManager.Update_Emp_ContactInfo(Int32.Parse(keyField.Text.ToString()), Tab2_HAddress1.Text.ToString(), Tab2_HAddress2.Text.ToString(), Tab2_HCity.Text.ToString(), Tab2_HState.Text.ToString(), Int32.Parse(Tab2_CountryDDList.SelectedValue), Tab2_WAddress1.Text.ToString(), Tab2_WAddress2.Text.ToString(), Tab2_WCity.Text.ToString(), Tab2_WState.Text.ToString(), Int32.Parse(Tab2_WCountryDDList.SelectedValue), Tab2_HPhone.Text.ToString(), Tab2_Mobile.Text.ToString(), Tab2_WPhone.Text.ToString(), Tab2_WorkEmail.Text.ToString(), 0, 0, 0, "");

                    this.message.Visible = true;
                    this.message.CssClass = "errorMessage";
                    if (Result == "")
                    {
                        this.message.Text = "Successfully saved.";
                    }
                    else
                    {
                        this.message.Text = Result;
                        this.message.CssClass = "errorMessage";
                    }
                }

            }
            catch (Exception exception)
            {
                this.message.Visible = true;
                this.message.Text = ErrorLogging.LogError(exception,"Unknown Exception Occured. Please contact support.");
                this.message.CssClass = "errorMessage";
            }
            LoadEmployeeInformation(Int32.Parse(this.keyField.Text));
        }
        protected void DP_Save_Click(object sender, EventArgs e)
        {

            try
            {
                if (Page.IsValid == true)
                {
                    String Result = DatabaseManager.Data.DBAccessManager.Update_Emp_DependentInfo(Int32.Parse(keyField.Text.ToString()), Tab3_Name.Text.ToString(), Int32.Parse(Tab3_RelationshipDDList.SelectedValue), ConvertDMY_MDY(Tab3_DOB), Int32.Parse(Tab3_GenderType.SelectedValue), Tab3_PassportNo.Text.ToString(), Int32.Parse(Tab3_PassportCountryDDList.SelectedValue), ConvertDMY_MDY(Tab3_PassportIssueDate), ConvertDMY_MDY(Tab3_PassportExpiryDate), Tab3_VisaNumber.Text.ToString(), Int32.Parse(Tab3_VisaType.SelectedValue), ConvertDMY_MDY(Tab3_VisaIssueDate), ConvertDMY_MDY(Tab3_VisaExpiryDate), Int32.Parse(Tab3_VisaIssueCountryID.SelectedValue));

                    this.DPmessage.Visible = true;
                    this.DPmessage.CssClass = "errorMessage";
                    if (Result == "")
                    {
                        this.DPmessage.Text = "Successfully saved.";
                        ResetDPFields();
                    }
                    else
                    {
                        this.DPmessage.Text = Result;
                        this.DPmessage.CssClass = "errorMessage";
                    }
                }
                this.LoadDependentsList(); // Refresh the grid after save

            }
            catch (Exception exception)
            {
                this.DPmessage.Visible = true;
                this.DPmessage.Text = ErrorLogging.LogError(exception,"Unknown Exception Occured. Please contact support.");
                this.DPmessage.CssClass = "errorMessage";
            }
        }

        protected void DP_Cancel_Click(object sender, EventArgs e)
        {
            Tab3_DOB.Text = "";
            Tab3_GenderType.SelectedIndex = -1;
            Tab3_Name.Text = "";
            Tab3_PassportCountryDDList.SelectedIndex = -1;
            Tab3_PassportExpiryDate.Text = "";
            Tab3_PassportIssueDate.Text = "";
            Tab3_PassportNo.Text = "";
            Tab3_RelationshipDDList.SelectedIndex = -1;
            Tab3_VisaExpiryDate.Text = "";
            Tab3_VisaIssueDate.Text = "";
            Tab3_VisaNumber.Text = "";
            Tab3_VisaType.SelectedIndex = -1;
            Tab3_VisaIssueCountryID.SelectedIndex = -1;
            DPmessage.Text = "";
        }


        protected void EC_Cancel_Click(object sender, EventArgs e)
        {
            Tab4_ContactPrioirtyDDList.SelectedIndex = -1;
            Tab4_EmailAddress.Text = "";
            Tab4_HomePhone.Text = "";
            Tab4_MobilePhone.Text = "";
            Tab4_Name.Text = "";
            Tab4_RelationshipDDList.SelectedIndex = -1;
            Tab4_WorkPhone.Text = "";
            ECmessage.Text = "";
        }
        protected void EC_Save_Click(object sender, EventArgs e)
        {

            try
            {
                if (Page.IsValid == true)
                {
                    String Result = DatabaseManager.Data.DBAccessManager.Update_Emp_EContactInfo(Int32.Parse(keyField.Text.ToString()), Tab4_Name.Text.ToString(), Int32.Parse(Tab4_RelationshipDDList.SelectedValue), Int32.Parse(Tab4_ContactPrioirtyDDList.SelectedValue), Tab4_HomePhone.Text.ToString(), Tab4_MobilePhone.Text.ToString(), Tab4_WorkPhone.Text.ToString(), Tab4_EmailAddress.Text.ToString());

                    this.ECmessage.Visible = true;
                    this.ECmessage.CssClass = "errorMessage";
                    if (Result == "")
                    {
                        this.ECmessage.Text = "Successfully saved.";
                        ResetEContactFields();
                    }
                    else
                    {
                        this.ECmessage.Text = Result;
                        this.ECmessage.CssClass = "errorMessage";
                    }
                }
                LoadEContactList(); // Refresh the Grid after Save.

            }
            catch (Exception exception)
            {
                this.ECmessage.Visible = true;
                this.ECmessage.Text = ErrorLogging.LogError(exception,"Unknown Exception Occured. Please contact support.");
                this.ECmessage.CssClass = "errorMessage";
            }
        }
        protected void Job_Save_Click(object sender, EventArgs e)
        {

            try
            {
                if (Page.IsValid == true)
                {
                    Int32 SuperVisoryRole = 0;
                    Int32 ProbationCompleted = 0;
                    if (Tab5_SupervisoryCheckBox.Checked) { SuperVisoryRole = 1; }
                    if (Tab5_ProbationCompletedCheckBox.Checked) { ProbationCompleted = 1; }

                    if (Tab5_ProbabtionYears.Text == "") { Tab5_ProbabtionYears.Text = "0"; }

                    String Result = DatabaseManager.Data.DBAccessManager.Update_Emp_JobInfo(Int32.Parse(keyField.Text.ToString()), Tab5_EmpID.Text.ToString(), Int32.Parse(Tab5_DesignationDDList.SelectedValue), Int32.Parse(Tab5_EmpCategoryDDList.SelectedValue), Int32.Parse(Tab5_EmpStatusDDList.SelectedValue), Int32.Parse(Tab5_DepartmentDDList.SelectedValue), Int32.Parse(Tab5_DivisonDDList.SelectedValue), ConvertDMY_MDY(Tab5_HireDate), ConvertDMY_MDY(Tab5_CRPositionEndDate), ConvertDMY_MDY(Tab5_NewPositionStartDate), ConvertDMY_MDY(Tab5_ResignedDate), ConvertDMY_MDY(Tab5_DateLeft), double.Parse(Tab5_ProbabtionYears.Text.ToString()), Int32.Parse(Tab5_SupervisorDDList.SelectedValue), SuperVisoryRole, Int32.Parse(Tab5_DivisionLocationDDList.SelectedValue), ConvertDMY_MDY(Tab5_ProbationEndDate), ProbationCompleted, Tab5_PSEmpID.Text.ToString(), Int32.Parse(Page.User.Identity.Name.ToString()));

                    this.message.Visible = true;
                    this.message.CssClass = "errorMessage";
                    if (Result == "")
                    {
                        this.message.Text = "Successfully saved.";
                        this.Tab5_CRPositionEndDate.Text = "";
                        this.Tab5_NewPositionStartDate.Text = "";
                    }
                    else
                    {
                        this.message.Text = Result;
                        this.message.CssClass = "errorMessage";
                    }
                }
                
                LoadEmployeeInformation(Int32.Parse(keyField.Text.ToString()));
            }
            catch (Exception exception)
            {
                this.message.Visible = true;
                this.message.Text = ErrorLogging.LogError(exception,"Unknown Exception Occured. Please contact support.");
                this.message.CssClass = "errorMessage";
            }
            LoadEmployeePositionList();
        }


        protected void Doc_Upload_Click(object sender, EventArgs e)
        {
            if (Page.IsValid == true)
            {
                if (Tab8_FileName.PostedFile != null && Tab8_FileName.PostedFile.FileName != "")
                    try
                    {
                        HttpPostedFile myFile = Tab8_FileName.PostedFile;
                        String Ext = System.IO.Path.GetExtension(myFile.FileName);
                        

                        String FilePath = Server.MapPath(Page.ResolveUrl("~\\Documents\\" + Int32.Parse(keyField.Text.ToString()) + "_" + Tab8_DocumentName.Text.ToString() + Ext));

                        this.docmessage.Visible = true;
                        this.docmessage.CssClass = "errorMessage";
                        myFile.SaveAs(FilePath);
                        String ActualFileName = Int32.Parse(keyField.Text.ToString()) + "_" + Tab8_DocumentName.Text.ToString() + Ext;

                        String Result = DatabaseManager.Data.DBAccessManager.Update_Emp_Documents(Int32.Parse(keyField.Text.ToString()), Int32.Parse(Tab8_DocumentType.SelectedValue), ActualFileName, FilePath, Tab8_Comments.Text.ToString());

                        if (Result == "")
                        {
                            this.docmessage.Text = "Successfully saved.";
                            this.docmessage.CssClass = "errorMessage";
                            ResetDOCFields();
                            
                        }

                        else
                        {
                            this.docmessage.Text = Result;
                            this.docmessage.CssClass = "errorMessage";

                        }

                    }
                    catch (Exception exception)
                    {
                        this.docmessage.Text = ErrorLogging.LogError(exception, "Unknown Exception Occured.Please contact Support.");
                        this.docmessage.CssClass = "errorMessage";
                    }
                else
                {
                    this.docmessage.Text = "You have not specified a file.";
                }
            }
            LoadEmployeeDocs();  
        }

        private void ResetDPFields()
        {
            Tab3_Name.Text = "";
            Tab3_RelationshipDDList.SelectedIndex = -1;
            Tab3_DOB.Text = "";
            Tab3_GenderType.SelectedIndex = -1;
            Tab3_PassportNo.Text = "";
            Tab3_PassportCountryDDList.SelectedIndex = -1;
            Tab3_PassportIssueDate.Text = "";
            Tab3_PassportExpiryDate.Text = "";
            Tab3_VisaNumber.Text = "";
            Tab3_VisaType.SelectedIndex = -1;
            Tab3_VisaIssueDate.Text = "";
            Tab3_VisaExpiryDate.Text = "";
            Tab3_VisaIssueCountryID.SelectedIndex = -1;
        }
        private void ResetEContactFields()
        {
            Tab4_Name.Text = "";
            Tab4_RelationshipDDList.SelectedIndex = -1;
            Tab4_ContactPrioirtyDDList.SelectedIndex = -1;
            Tab4_HomePhone.Text = "";
            Tab4_MobilePhone.Text = "";
            Tab4_WorkPhone.Text = "";
            Tab4_EmailAddress.Text = "";
        }
        private void ResetDOCFields()
        {
            Tab8_DocumentName.Text = "";
            Tab8_DocumentType.SelectedIndex = -1;
            Tab8_Comments.Text = "";
        }
        private void DeleteEmployeeDocument(Int32 DocumentID)
        {
            String document = DatabaseManager.Data.DBAccessManager.DeleteEmployeeDocument(Int32.Parse(keyField.Text.ToString()), DocumentID);

            if (document != "")
            {
                try
                {
                    System.IO.File.Delete(document);
                }
                catch (Exception exception)
                {
                    this.docmessage.Text = ErrorLogging.LogError(exception,"Error Occured:Could not delete the file.");
                    this.docmessage.CssClass = "errorMessage";
                }
            }

            else
            {
                this.docmessage.Text = document;
                this.docmessage.CssClass = "errorMessage";

            }
            DOCGrid.CurrentPageIndex = 0;
            ResetDOCFields();
            LoadEmployeeDocs();


        }

        private void DeleteEContact(Int32 EContactID)
        {
            try
            {
                String result = DatabaseManager.Data.DBAccessManager.DeleteEmployeeEContact(Int32.Parse(keyField.Text.ToString()), EContactID);

                if (result != "")
                {
                    this.ECmessage.Text = result;
                    this.ECmessage.CssClass = "errorMessage";

                }
                
            }
            catch (Exception exception)
            {

                this.ECmessage.Text = ErrorLogging.LogError(exception,"Error Occured:Could not delete the contact. Please check the data");
                this.ECmessage.CssClass = "errorMessage";

            }
            ECGrid.CurrentPageIndex = 0;
            LoadEContactList();
            ResetEContactFields();

        }
        private void DeleteDependent(Int32 DependentID)
        {
            try
            {
                String result = DatabaseManager.Data.DBAccessManager.DeleteEmployeeDependent(Int32.Parse(keyField.Text.ToString()), DependentID);

                if (result != "")
                {
                    this.DPmessage.Text = result;
                    this.DPmessage.CssClass = "errorMessage";

                }
               
            }
            catch (Exception exception)
            {
                this.DPmessage.Text = ErrorLogging.LogError(exception, "Unknown Exception Occured.Please contact Support.");
                this.DPmessage.CssClass = "errorMessage";

            }
            DPGrid.CurrentPageIndex = 0;
            LoadDependentsList();
            ResetDPFields();

        }

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


       

        protected void Search_Click(object sender, EventArgs e)
        {
            SetViewState(null);
            LoadDataList();       

        }
        protected void PayGrid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            PayGrid.CurrentPageIndex = e.NewPageIndex;
            LoadCurrentCompensation();
        }
        protected void EPGrid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            EPGrid.CurrentPageIndex = e.NewPageIndex;
            LoadEmployeePositionList();

        }
        protected void ETGrid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            ETGrid.CurrentPageIndex = e.NewPageIndex;
            LoadEmployeeTransferList();


        }
       
        protected void ECGrid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            ECGrid.CurrentPageIndex = e.NewPageIndex;
            LoadEContactList();

           
        }
        protected void ECGrid_EditCommand(object source, DataGridCommandEventArgs e)
        {
            Tab4_Name.Text = EmptyString(e.Item.Cells[0].Text);
            if (EmptyString(e.Item.Cells[1].Text) != "")
            {
                Tab4_RelationshipDDList.SelectedValue = Tab4_RelationshipDDList.Items.FindByText(e.Item.Cells[1].Text).Value;
            }
            if (EmptyString(e.Item.Cells[2].Text) != "")
            {
                Tab4_ContactPrioirtyDDList.SelectedValue = Tab4_ContactPrioirtyDDList.Items.FindByText(e.Item.Cells[2].Text).Value;
            }
            Tab4_HomePhone.Text = EmptyString(e.Item.Cells[3].Text);
            Tab4_MobilePhone.Text = EmptyString(e.Item.Cells[4].Text);
            Tab4_WorkPhone.Text = EmptyString(e.Item.Cells[5].Text);
            Tab4_EmailAddress.Text = EmptyString(e.Item.Cells[6].Text);
            ECGrid.EditItemIndex = -1;
        }
        protected void ECGrid_CancelCommand(object source, DataGridCommandEventArgs e)
        {
            //ECGrid.EditItemIndex = -1;
            
        }
        protected void ECGrid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            int EContactID = (int)ECGrid.DataKeys[(int)e.Item.ItemIndex];
            ECGrid.EditItemIndex = -1;
            DeleteEContact(EContactID);

        }
        protected void ECGrid_UpdateCommand(object source, DataGridCommandEventArgs e)
        {
        
        }
        protected void DPGrid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
             DPGrid.CurrentPageIndex = e.NewPageIndex;
             LoadDependentsList();

        }
        protected void DPGrid_EditCommand(object source, DataGridCommandEventArgs e)
        {
            Tab3_Name.Text = EmptyString(e.Item.Cells[0].Text);
            if (EmptyString(e.Item.Cells[1].Text) != "")
            {
                Tab3_RelationshipDDList.SelectedValue = Tab3_RelationshipDDList.Items.FindByText(EmptyString(e.Item.Cells[1].Text)).Value;
            }
            Tab3_DOB.Text = EmptyString(e.Item.Cells[2].Text);
            if (EmptyString(e.Item.Cells[3].Text) != "")
            {
                Tab3_GenderType.SelectedValue = Tab3_GenderType.Items.FindByText(EmptyString(e.Item.Cells[3].Text)).Value;
            }
            Tab3_PassportNo.Text = EmptyString(e.Item.Cells[4].Text);
            if (EmptyString(e.Item.Cells[5].Text) != "")
            {
                Tab3_PassportCountryDDList.SelectedValue = Tab3_PassportCountryDDList.Items.FindByText(EmptyString(e.Item.Cells[5].Text)).Value;
            }
            Tab3_PassportIssueDate.Text = EmptyString(e.Item.Cells[6].Text);
            Tab3_PassportExpiryDate.Text = EmptyString(e.Item.Cells[7].Text);
            Tab3_VisaNumber.Text = EmptyString(e.Item.Cells[8].Text);
            Tab3_VisaIssueDate.Text = EmptyString(e.Item.Cells[10].Text);
            Tab3_VisaExpiryDate.Text = EmptyString(e.Item.Cells[11].Text);
            if (EmptyString(e.Item.Cells[12].Text) != "")
            {
                Tab3_VisaIssueCountryID.SelectedValue = Tab3_VisaIssueCountryID.Items.FindByValue(EmptyString(e.Item.Cells[12].Text)).Value;
            }
            if (EmptyString(e.Item.Cells[9].Text) != "")
            {
                Tab3_VisaType.SelectedValue = Tab3_VisaType.Items.FindByValue(EmptyString(e.Item.Cells[9].Text)).Value;
            }

         

            DPGrid.EditItemIndex = -1;
        }
        protected void DPGrid_CancelCommand(object source, DataGridCommandEventArgs e)
        {
            //ECGrid.EditItemIndex = -1;

        }
        protected void DPGrid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            int dependentID = (int)DPGrid.DataKeys[(int)e.Item.ItemIndex];
            DPGrid.EditItemIndex = -1;
            DeleteDependent(dependentID);
            
        }
        protected void DPGrid_UpdateCommand(object source, DataGridCommandEventArgs e)
        {

        }
        protected void DOCGrid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            DOCGrid.CurrentPageIndex = e.NewPageIndex;
            LoadEmployeeDocs();

        }
        protected void DOCGrid_EditCommand(object source, DataGridCommandEventArgs e)
        {
        }
        protected void DOCGrid_CancelCommand(object source, DataGridCommandEventArgs e)
        {
            //ECGrid.EditItemIndex = -1;

        }
        protected void DOCGrid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            int documentID = (int)DOCGrid.DataKeys[(int)e.Item.ItemIndex];            
            DeleteEmployeeDocument(documentID);
            DOCGrid.EditItemIndex = -1;
            //Response.Redirect(Request.Url.AbsoluteUri);

        }
        protected void DOCGrid_UpdateCommand(object source, DataGridCommandEventArgs e)
        {

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

          //  Grid.CurrentPageIndex = e.NewPageIndex;
         //   LoadDataList();
        }
        protected void Grid_EditCommand(object source, DataGridCommandEventArgs e)
        {

            this.keyField.Text = Grid.DataKeys[e.Item.ItemIndex].ToString();
           // Grid.EditItemIndex = e.Item.ItemIndex;
            this.EmpSearchBox.Visible = false;
            this.searchDataArea.Visible = false;
            this.EditArea.Visible = true;
            this.GeneralInfoTab.Visible = true;
            LoadEmployeeInformation(Int32.Parse(this.keyField.Text));
        }
        private void LoadEmployeeInformation(Int32 EmpId)
        {
       
           // Load dropdown Controls.
            LoadVisaType(this.Tab1_VisaType);
            LoadVisaType(this.Tab3_VisaType);
            LoadCountryList(this.Tab1_PassportCountryDDList);
            LoadCountryList(this.Tab1_VisaCountryDDList);
            LoadCountryList(Tab1_BVisaCountryDDList);
            LoadCountryList(this.Tab2_CountryDDList);
            LoadCountryList(this.Tab2_WCountryDDList);
            LoadCountryList(this.Tab3_PassportCountryDDList);
            LoadCountryList(Tab1_LaborCardCountryDDList);
            LoadCountryList(Tab3_VisaIssueCountryID);            
            LoadGenderType(this.Tab3_GenderType);
            LoadRelationshipType(this.Tab3_RelationshipDDList);
            LoadRelationshipType(this.Tab4_RelationshipDDList);
            ContactPriorityType(this.Tab4_ContactPrioirtyDDList);
            LoadDocumentType(Tab8_DocumentType);
            LoadEducationList(Tab1_Education);

            
           // Gather Employee Information.
            try
            {
             DataSet _DataList = null;
             _DataList = DatabaseManager.Data.DBAccessManager.RetrieveEmployeeInfo(EmpId);
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
                
                  if (_employeeDataRow["EducationId"].ToString() != "") 
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
                      this.profile.ImageUrl = Page.ResolveUrl("~\\PhotoProfiles\\" +"d_Photo.jpg");
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
                 // LoadDivisionLookup(Tab5_DivisonDDList);
                 LoadDivisionLookupByEmpId(Tab5_DivisonDDList, Int32.Parse(Page.User.Identity.Name.ToString()));
                 LoadEntityLocationLookupByEmpId_DivisionID(Tab5_DivisionLocationDDList, Int32.Parse(Page.User.Identity.Name.ToString()), Int32.Parse(Tab5_DivisonDDList.SelectedValue));

                  this.LoadEmpCategoryLookup(Tab5_EmpCategoryDDList);
                  
                  //LoadSupervisorsListLookup(Tab5_SupervisorDDList);

                  Tab5_EmpID.Text = _employeeDataRow["Employee_ID"].ToString();
                  Tab5_PSEmpID.Text = _employeeDataRow["PS_EmpId"].ToString();
                  Tab1_PersonID.Text = _employeeDataRow["WPS_PersonID"].ToString();

                  if (_employeeDataRow["DesignationID"].ToString() != "")
                  {
                      Tab5_DesignationDDList.SelectedValue = _employeeDataRow["DesignationID"].ToString();
                      lblJobTitle.Text = Tab5_DesignationDDList.SelectedItem.ToString();
                  }
                  if (_employeeDataRow["EmployeeStatusID"].ToString() != "")
                  {
                      Tab5_EmpStatusDDList.SelectedValue = _employeeDataRow["EmployeeStatusID"].ToString();
                  }
                  if ((Tab5_EmpStatusDDList.SelectedItem.ToString() == "Resigned" || Tab5_EmpStatusDDList.SelectedItem.ToString() == "Terminated") && (_employeeDataRow["Date_Left"].ToString() != ""))
                  {
                      Job_Save.Enabled = false;
                      JobTab_message.Visible = true;
                      JobTab_message.CssClass = "errorMessage";
                      JobTab_message.Text = "No Changes to the Job Information is allowed due to the current employment status of the employee";
                  }
                  else
                  {
                      Job_Save.Enabled = true;
                      JobTab_message.Visible = false;
                      JobTab_message.Text = "";
                  }
                  if (_employeeDataRow["EmployeeCategoryID"].ToString() != "")
                  {
                      Tab5_EmpCategoryDDList.SelectedValue = _employeeDataRow["EmployeeCategoryID"].ToString();
                  }

                 
                  if (_employeeDataRow["DivisionID"].ToString() != "")
                  {
                      Tab5_DivisonDDList.SelectedValue = _employeeDataRow["DivisionID"].ToString();
                      LoadEntityLocationLookupByDivisionID(Tab5_DivisionLocationDDList, Int32.Parse(Tab5_DivisonDDList.SelectedValue));
                      LoadSupervisorsListLookupByDivisionID(Tab5_SupervisorDDList, Int32.Parse(Tab5_DivisonDDList.SelectedValue));
                      //LoadDepartmentLookup(Tab5_DepartmentDDList);
                      LoadDepartmentLookupByDivisionId(Tab5_DepartmentDDList, Int32.Parse(Tab5_DivisonDDList.SelectedValue));
                  }
                  if (_employeeDataRow["DivisionLocationID"].ToString() != "")
                  {
                      Tab5_DivisionLocationDDList.SelectedValue = _employeeDataRow["DivisionLocationID"].ToString();
                  }
                  if (_employeeDataRow["DepartmentID"].ToString() != "")
                  {
                      Tab5_DepartmentDDList.SelectedValue = _employeeDataRow["DepartmentID"].ToString();
                  }

                  Tab5_HireDate.Text = _employeeDataRow["HireDate"].ToString();
                  Tab5_OriginalHireDate.Text = _employeeDataRow["OriginalHireDate"].ToString();
                  Tab5_ResignedDate.Text = _employeeDataRow["Date_Resigned"].ToString();
                  Tab5_DateLeft.Text = _employeeDataRow["Date_Left"].ToString();
                  Tab5_TotalServiceYears.Text = _employeeDataRow["TotalYears_Service"].ToString();
                  Tab5_ProbabtionYears.Text = _employeeDataRow["Probation_Period"].ToString();
                  Tab5_YearsinCurrentPosition.Text = _employeeDataRow["Years_CurrentPosition"].ToString();
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
                      try
                      {
                          Tab5_SupervisorDDList.Items.FindByValue(_employeeDataRow["LineManagerID"].ToString().Trim()).Selected = true;
                      }
                      catch
                      {
                          Tab5_SupervisorDDList.SelectedValue = "-1";
                      }
                      //Tab5_SupervisorDDList.SelectedValue = _employeeDataRow["LineManagerID"].ToString();
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
                 //Business Visa
                  Tab1_BVisaNumber.Text = _employeeDataRow["BVisa_Number"].ToString();
                  Tab1_BVisaExpiryDate.Text = _employeeDataRow["BVisa_ExpiryDate"].ToString();
                  Tab1_BVisaIssueDate.Text = _employeeDataRow["BVisa_IssueDate"].ToString();
                  if (_employeeDataRow["BVisa_IssueCountryID"].ToString() != "")
                  {
                      Tab1_BVisaCountryDDList.SelectedValue = _employeeDataRow["BVisa_IssueCountryID"].ToString();
                  }                    
                 // Employee Contact Information.
                  Tab2_HAddress1.Text = _employeeDataRow["Home_Addr1"].ToString();
                  Tab2_HAddress2.Text = _employeeDataRow["Home_Addr2"].ToString();
                  Tab2_WAddress1.Text = _employeeDataRow["Work_Addr1"].ToString();
                  Tab2_WAddress2.Text = _employeeDataRow["Work_Addr2"].ToString();
                  Tab2_HCity.Text     = _employeeDataRow["City"].ToString();
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
                  Tab5_CountryName.Text = _employeeDataRow["CountryName"].ToString();
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
                  DataRow _empDependentDataRow = _DataList.Tables[3].Rows[0];
                  DataTable _empDependentDataTable = _DataList.Tables[3];

                  if (_DataList.Tables[3].Rows.Count > 0)
                  {
                      this.DPGrid.DataSource = _empDependentDataTable;
                      this.DPGrid.DataBind();
                  }
                  else
                  {
                      emptyRow2.Visible = true;
                      emptyRow2.Text = "There are no dependents information found.";
                      emptyRow2.CssClass = "errorMessage";
                  }
                             
              }
              else
              {
                  emptyRow2.Visible = true;
                  emptyRow2.Text = "There are no dependents information found.";
                  emptyRow2.CssClass = "errorMessage";
              }

              if (_DataList.Tables[2].Rows.Count > 0)  // Employee Emergency contact Information.
              {
                  DataRow _empECDataRow = _DataList.Tables[4].Rows[0];
                  DataTable _empECDataTable = _DataList.Tables[4];

                  if (_DataList.Tables[4].Rows.Count > 0)
                  {
                      this.ECGrid.DataSource = _empECDataTable;
                      this.ECGrid.DataBind();

                      if (_empECDataRow["Contact_Priority"].ToString() != "")
                      {
                          Tab4_ContactPrioirtyDDList.SelectedValue = _empECDataRow["Contact_Priority"].ToString();
                      }
                      if (_empECDataRow["RelationshipId"].ToString() != "")
                      {
                          Tab4_RelationshipDDList.SelectedValue = _empECDataRow["RelationshipId"].ToString();
                      }
                  }
                  else
                  {
                      emptyRow1.Visible = true;
                      emptyRow1.Text = "There are no records found.";
                      emptyRow1.CssClass = "errorMessage";
                  }

              }
              else
              {
                  emptyRow1.Visible = true;
                  emptyRow1.Text = "There are no records found.";
                  emptyRow1.CssClass = "errorMessage";
              }


              if (_DataList.Tables[3].Rows.Count > 0)  // Employee Documents Information.
              {
                  DataRow _empDOCDataRow = _DataList.Tables[7].Rows[0];
                  DataTable _empDOCDataTable = _DataList.Tables[7];

                  if (_DataList.Tables[7].Rows.Count > 0)
                  {
                      this.DOCGrid.DataSource = _empDOCDataTable;
                      this.DOCGrid.DataBind();
             
                  }
                  else
                  {
                      emptyRow3.Visible = true;
                      emptyRow3.Text = "There are no documents found.";
                      emptyRow3.CssClass = "errorMessage";
                  }

              }
              else
              {
                  emptyRow3.Visible = true;
                  emptyRow3.Text = "There are no documents found.";
                  emptyRow3.CssClass = "errorMessage";
              }

            }
        }
     catch(Exception exception)
     {
        ErrorLogging.LogError(exception, "");
     }
           
        }
        protected void Grid_CancelCommand(object source, DataGridCommandEventArgs e)
        {
            Grid.EditItemIndex = -1;
            LoadDataList();
        }
        protected void Grid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
          
        }
       

    

    }
}
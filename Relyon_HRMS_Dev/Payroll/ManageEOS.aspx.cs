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
    public partial class ManageEOS : SchoolNetBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)

            {
            //    LoadEmpStatusLookupByType(this.empStatusDDList, (int)Constants.EmpStatusType.PostEmployment);
             //   LoadDesignationLookup(this.jobTitleDDList);
             //   LoadDivisionLookupByEmpId(businessUnitDDList, Int32.Parse(Page.User.Identity.Name.ToString()));
             //   LoadEntityLocationLookupByEmpId_DivisionID(DivisionLocationList, Int32.Parse(Page.User.Identity.Name.ToString()), Int32.Parse(businessUnitDDList.SelectedValue));

            }
          //  if (Int32.Parse(DivisionLocationList.SelectedValue) == -1)
           // {
            //    LoadEntityLocationLookupByEmpId_DivisionID(DivisionLocationList, Int32.Parse(Page.User.Identity.Name.ToString()), Int32.Parse(businessUnitDDList.SelectedValue));
           // }
            LoadDataList();
            if ((this.keyField.Text.ToString() != "") && (Payroll_Date.Text != ""))
            {
                LoadEmployeeEOSPayrollInfo(Int32.Parse(this.keyField.Text), Payroll_Date.Text);
                
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
            Payroll_Save.Click += new EventHandler(Payroll_Save_Click);
            Payroll_Go.Click += new EventHandler(Payroll_Go_Click);
            Tab_Back.Click += new EventHandler(Tab_Back_Click);
            Payroll_StartOver.Click += new EventHandler(Payroll_StartOver_Click);
        }
        #endregion
        #region Load LoadDataList
        private void LoadDataList()
        {
            DataSet _DataList = null;
            //hack:Filter other status types when default search turns specifically when the index = -1.
            Int32 EmpStatusID = -3;//Resigned and Terminated.
            
            _DataList = DatabaseManager.Data.DBAccessManager.RetrieveEmployeeEOSList(Int32.Parse(Page.User.Identity.Name.ToString()));

            if (_DataList.Tables[0].Rows.Count > 0)
            {
                this.Grid.DataSource = _DataList;
                this.Grid.DataBind();
                emptyRow.Text = "";
                emptyRow.Visible = false;

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
        #endregion

        protected void Payroll_Go_Click(object sender, EventArgs e)
        {
            if (Page.IsValid == true)
            {

                Paycomponents.Visible = true;
                LoadEmployeeEOSPayrollInfo(Int32.Parse(this.keyField.Text), Payroll_Date.Text);

            }

        }
        protected void Tab_Back_Click(object sender, EventArgs e)
        {
            //TabSettings();
            this.keyField.Text = "";
            Grid.EditItemIndex = -1;
            this.EmpSearchBox.Visible = true;
            this.Tab1_Pane.Visible = false;
            this.EditArea.Visible = false;
            message.Text = "";
        }

        protected void Payroll_StartOver_Click(object sender, EventArgs e)
        {
            try
            {
                String result = DatabaseManager.Data.DBAccessManager.DeleteEmployeeMonthlyPayrollInfo(Int32.Parse(this.keyField.Text), Payroll_Date.Text, Int32.Parse(Page.User.Identity.Name.ToString()));
                this.message.Visible = true;
                message.CssClass = "errorMessage";
                if (result == "")
                {
                    LoadEmployeeEOSPayrollInfo(Int32.Parse(this.keyField.Text), Payroll_Date.Text);
                    this.message.Text = "Successfully started over again.";
                }
                else { this.message.Text = result; }
            }
            catch (Exception exception)
            {
                this.message.Visible = true;
                this.message.Text = ErrorLogging.LogError(exception, "Unknown Exception Occured.Please contact support.");
                this.message.CssClass = "errorMessage";

            }

        }

        protected void LoadEmployeeEOSPayrollInfo(Int32 EmpId, String MonthYear)
        {
            DataSet _DataList = null;
            _DataList = DatabaseManager.Data.DBAccessManager.RetrieveEmployeeEOSPayrollInfo(EmpId, MonthYear,Int32.Parse(Page.User.Identity.Name.ToString()));
            if (_DataList.Tables.Count > 0)
            {
                if (_DataList.Tables[0].Rows.Count > 0) // Standard Pay Components.
                {
                    Tab1Grid.DataSource = _DataList.Tables[0];
                    Tab1Grid.DataBind();
                }
                else
                {
                    Tab1Grid.DataSource = null;
                    Tab1Grid.DataBind();
                    this.message.Visible = true;
                    this.message.Text = "Standard Benefit Components(Allowances/Ded) are not setup for this employee.Please setup benefit records via Manage Benefit Screen before payroll process";
                    this.message.CssClass = "errorMessage";
                    Payroll_Save.Enabled = false;
                    return;
                }
                if (_DataList.Tables[1].Rows.Count > 0) // Adhoc Pay Components
                {
                    Tab2Grid.DataSource = _DataList.Tables[1];
                    Tab2Grid.DataBind();
                }
                else
                {
                    Tab2Grid.DataSource = null;
                    Tab2Grid.DataBind();
                }

                if (_DataList.Tables[2].Rows.Count > 0)  // Leave/Bank Information
                {
                    DataRow _DataRow = _DataList.Tables[2].Rows[0];
                    Tab1_GratuityAmount.Text = FormatTwoDecimals(_DataRow["Gratuity_Amt"].ToString());
                    Tab1_DateJoined.Text = _DataRow["HireDate"].ToString();
                    Tab1_DateLeft.Text = _DataRow["Date_Left"].ToString();
                    Tab1_TotalServiceYears.Text = FormatTwoDecimals(_DataRow["Years_Service"].ToString());
                    Tab1_NoOfDaysPayCycle.Text = _DataRow["TotalDays_PayCycle"].ToString();
                    Tab1_NofUnpaidDays.Text = _DataRow["TotalDays_Unpaid"].ToString();
                    Tab1_NetPayDays.Text = _DataRow["NetPayDays"].ToString();
                    Tab1_UnusedVacDays.Text = _DataRow["UnusedVacDays"].ToString();
                    payperiod.Visible = true;
                    Tab1_PayStartDate.Text = _DataRow["PayStartDate"].ToString();
                    Tab1_PayEndDate.Text = _DataRow["PayEndDate"].ToString();

                  //  if (_DataRow["GratuityRuleID"].ToString() != "")
                   // {
                    //    Tab1_GratuityRulesList.SelectedValue = _DataRow["GratuityRuleID"].ToString();
                   // }
                    Tab1_CurrenyLabel1.Text = "(All Figures in " + _DataRow["Currencycode"].ToString() + ")";
                    Tab1_EmployeeBankAccount.Text = _DataRow["BankAccount"].ToString();
                    if (_DataRow["BankId"].ToString() != "")
                    {
                        Tab1_BankName.SelectedValue = _DataRow["BankId"].ToString();
                    }
                    if (Tab1_Note.Text == "")
                    {
                        Tab1_Note.Text = _DataRow["PayrollNote"].ToString();
                    }
                                       
                    LoadPayrollStatusTypeLookup(Tab1_PayrollStatusType, (int)Constants.PayrollStatusType.Preview);
                    if (Int32.Parse(_DataRow["PayrollStatusTypeID"].ToString()) == (int)Constants.PayrollStatusType.Processed) // Allow to view pay slip
                    {
                        LoadPayrollStatusTypeLookup(Tab1_PayrollStatusType, (int)Constants.PayrollStatusType.Processed);
                        Payroll_Save.Enabled = false;
                        Payroll_StartOver.Enabled = false;

                        // Enable payroll download link
                        WPSDownloadLink.Visible = true;
                        WPSDownloadLink.Text = "Click here to view this pay slip";
                        WPSDownloadLink.CssClass = "validationtxt";
                        WPSDownloadLink.NavigateUrl = "~/Payroll/ViewPayStub.aspx?empId=" + EmpId + "&PayMonthYear=" + MonthYear;
                        WPSDownloadLink.Target = "_blank";
                    }
                    else
                    {
                        Payroll_Save.Enabled = true;
                        Payroll_StartOver.Enabled = true;
                        WPSDownloadLink.Visible = false;

                    }
                    if (Int32.Parse(_DataRow["PayrollStatusTypeID"].ToString()) == (int)Constants.PayrollStatusType.Pending) // Allow Preview
                    {
                        // Enable payroll download link
                        WPSDownloadLink.Visible = true;
                        WPSDownloadLink.Text = "Click here to preview this pay slip";
                        WPSDownloadLink.CssClass = "validationtxt";
                        WPSDownloadLink.NavigateUrl = "~/Payroll/ViewPayStub.aspx?empId=" + EmpId + "&PayMonthYear=" + MonthYear;
                        WPSDownloadLink.Target = "_blank";
                    }

                    if (Int32.Parse(_DataRow["PayrollStatusTypeID"].ToString()) == (int)Constants.PayrollStatusType.New) // New. Hide the link
                    {
                        WPSDownloadLink.Visible = false;
                    }

                    if (_DataRow["PayrollStatusTypeID"].ToString() != "")
                    {
                        Tab1_PayrollStatusType.SelectedValue = _DataRow["PayrollStatusTypeID"].ToString();
                    }
                    Tab1_NetPay.Text = _DataRow["NetPay"].ToString();
                    if (_DataRow["EOSPayout"].ToString() == "1")
                    { Tab1_EOSCheckBox.Checked = true; }
                    else
                    { Tab1_EOSCheckBox.Checked = false; }

                }
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
                    Payroll_Save.Enabled = false;

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

       

        protected void Payroll_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid == true)
                {
                    String Result = DatabaseManager.Data.DBAccessManager.AddUpdateEmployee_EOSPayroll(Int32.Parse(NumericCheck_EmptyString(keyField.Text.ToString())), Payroll_Date.Text, Int32.Parse(NumericCheck_EmptyString(Tab1_NoOfDaysPayCycle.Text)), Decimal.Parse(NumericCheck_EmptyString(Tab1_NofUnpaidDays.Text)), Decimal.Parse(NumericCheck_EmptyString(Tab1_NetPayDays.Text)), Tab1_EmployeeBankAccount.Text, Int32.Parse(Tab1_BankName.SelectedValue), Tab1_Note.Text, Int32.Parse(Tab1_PayrollStatusType.SelectedValue), Int32.Parse(Page.User.Identity.Name.ToString()));

                    this.message.Visible = true;
                    this.message.CssClass = "errorMessage";
                    if (Result == "")
                    {
                        this.message.Text = "Successfully saved.";
                        Tab1_PayrollStatusType.SelectedValue = Tab1_PayrollStatusType.Items.FindByText("Pending").Value;                     

                    }
                    else
                    {
                        this.message.Text = Result;
                    }
                }
                else
                {
                    this.message.Text = "Error:Could not save the information. Please check the inputs";
                    this.message.CssClass = "errorMessage";

                }


            }
            catch (Exception exception)
            {
                this.message.Visible = true;
                this.message.Text = ErrorLogging.LogError(exception,"Unknown Exception Occured. Please contact support.");
                this.message.CssClass = "errorMessage";
            }
            LoadEmployeeEOSPayrollInfo(Int32.Parse(this.keyField.Text), Payroll_Date.Text);
        }
        #region Reset_Click
        protected void Payroll_Reset_Click(object sender, EventArgs e)
        {



        }
        #endregion

      
        protected void Grid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            Grid.CurrentPageIndex = e.NewPageIndex;
            LoadDataList();
        }
        protected void Grid_EditCommand(object source, DataGridCommandEventArgs e)
        {

            this.keyField.Text = Grid.DataKeys[e.Item.ItemIndex].ToString();
            Grid.EditItemIndex = e.Item.ItemIndex;
            this.EmpSearchBox.Visible = false;
            this.EditArea.Visible = true;
            this.Tab1_Pane.Visible = true;
            LoadBankingListLookup(Tab1_BankName);
            LoadPayrollStatusTypeLookup(Tab1_PayrollStatusType,(int)Constants.PayrollStatusType.Preview);
            LoadKeyEmployeeInformation(Int32.Parse(this.keyField.Text));

             // Do this if the EOS is processed.
            if (EmptyString(e.Item.Cells[6].Text) == "Processed")  // EOS Status, may change this later with enum string.
            { 
              Payroll_Date.Text = EmptyString(e.Item.Cells[8].Text);
              Payroll_Date.Enabled = false;
              Payroll_Go.Enabled = false;
              Paycomponents.Visible = true;
              LoadEmployeeEOSPayrollInfo(Int32.Parse(this.keyField.Text), Payroll_Date.Text);
            }
            Grid.EditItemIndex = -1;
        }
        protected void Tab2Grid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            Tab2Grid.CurrentPageIndex = e.NewPageIndex;
            // LoadDataList();
        }
     }
}
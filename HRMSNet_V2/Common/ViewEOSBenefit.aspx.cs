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
using System.IO;


namespace SchoolNet
{
    public partial class ViewEOSBenefit : SchoolNetBase
    {
        protected System.Web.UI.HtmlControls.HtmlInputButton printbtn;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                // LoadEmployeePayrollInfo(Int32.Parse(Page.User.Identity.Name.ToString()), Payroll_Date.Text);
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

            Payroll_Go.Click += new ImageClickEventHandler(Payroll_Go_Click);
        }
        #endregion

        protected void Payroll_Go_Click(object sender, EventArgs e)
        {
            if (Page.IsValid == true)
            {
                PayStubViewPaycomponents.Visible = true;
                LoadEmployeeEOSBenefitInformation(Int32.Parse(Page.User.Identity.Name.ToString()), Payroll_Date.Text);
            }


        }


        protected void LoadEmployeeEOSBenefitInformation(Int32 EmpId, String MonthYear)
        {
            message.Visible = false;
            message.Text = "";
            DataSet _DataList = null;
            _DataList = DatabaseManager.Data.DBAccessManager.RetrieveEmployeeEOSBenefitInfo(EmpId, MonthYear);
            if (_DataList.Tables.Count > 0)
            {
                if (_DataList.Tables[0].Rows.Count > 0) // EOS Benefit
                {
                    DataRow _dataRow = _DataList.Tables[0].Rows[0];
                    Tab1_EmployeeName.Text = _dataRow["EmployeeName"].ToString();
                    Tab1_EmployeeID.Text = _dataRow["EmployeeID"].ToString();
                    Tab1_DOJ.Text = _dataRow["HireDate"].ToString();
                    Tab1_DateLeft.Text = _dataRow["DateLeft"].ToString();
                    Tab1_BaseSalary.Text = _dataRow["BaseSalary"].ToString();
                    Tab1_MonthlyAllowance.Text = _dataRow["MonthlyAllowance"].ToString();
                    Tab1_MonthlySalary.Text = _dataRow["TotalMonthlySalary"].ToString();
                    Tab1_MonthlyEarnings.Text = _dataRow["TotalEarnings"].ToString();
                    Tab1_ServiceYear.Text = _dataRow["ServiceYears"].ToString();
                    Tab1_ExgratiaPayment.Text = _dataRow["ExgratiaAmount"].ToString();
                    Tab1_GratuityAmount.Text = _dataRow["GratuityAmount"].ToString();
                    Tab1_ALeaveAdjPayment.Text = _dataRow["ALAdjPayment"].ToString();
                    Tab1_TotalEOSBenefit.Text = _dataRow["TotalEOSBenefit"].ToString();
                    Tab1_StandardDeductions.Text = _dataRow["StandardDeduction"].ToString();
                    Tab1_AdvanceRecoveryAmount.Text = _dataRow["AdvanceRecovery"].ToString();
                    Tab1_LOPDeductions.Text = _dataRow["LOPDeduction"].ToString();
                    Tab1_AdhocDeductions.Text = _dataRow["AdhocDeduction"].ToString();
                    Tab1_TotalDeductions.Text = _dataRow["TotalDeductions"].ToString();
                    Tab1_TotalNetPay.Text = _dataRow["NetEOSPayable"].ToString();
                    lblcurrencycode.Text = "(All Figures in " + _dataRow["CurrencyCode"].ToString() + ")";
                }
                else
                {
                    PayStubViewPaycomponents.Visible = false;
                    printbutton.Visible = false;
                    message.Visible = true;
                    message.Text = "No EOS Benefit data is available currently for the selected Month/Year.Please check with your HR Administrator.";
                    message.CssClass = "errorMessage";

                }

            } 
        } 

    } 
   
}
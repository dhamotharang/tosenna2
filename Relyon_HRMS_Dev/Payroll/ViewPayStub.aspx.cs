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
    public partial class ViewPayStub: SchoolNetBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Int32 EmpId  = Int32.Parse(Request.QueryString["empId"].ToString());
                String Payroll_MonthYear = Request.QueryString["PayMonthYear"].ToString();
                PayStubViewPaycomponents.Visible = true;
                LoadEmployeePayrollInfo(EmpId, Payroll_MonthYear);
                printbutton.Visible = true;
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
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

        }
        #endregion

            
        protected void LoadEmployeePayrollInfo(Int32 EmpId, String MonthYear)
        {
            message.Visible = false;
            message.Text = "";
            DataSet _DataList = null;
            _DataList = DatabaseManager.Data.DBAccessManager.RetrieveEmployeePaySlipInfo(EmpId, MonthYear);
            if (_DataList.Tables.Count > 0)
            {
                if (_DataList.Tables[0].Rows.Count > 0) // Standard Pay Components.
                {
                    DataRow _dataRow = _DataList.Tables[0].Rows[0];
                    lblCompanyName.Text = _dataRow["DivisionName"].ToString();
                    lblDivisionName.Text = _dataRow["Location"].ToString();
               //   lblPaySlipPeriod.Text = "Pay Slip for the period between " + _dataRow["PayStartDate"].ToString() + '-' + _dataRow["PayEnddate"].ToString();
                    lblPaySlipPeriod.Text = "Pay slip for " + _dataRow["PayMonthYear"].ToString();
                    lblCurrencyName.Text = "(All Figures in " + _dataRow["CurrencyCode"].ToString() + ')';
                    lblEmployeeName.Text = _dataRow["EmployeeName"].ToString();
                    lblDesignation.Text = _dataRow["Designation"].ToString();
                    lblEmployeeNo.Text = _dataRow["Employee_ID"].ToString();
                    lblDepartmentName.Text = _dataRow["deptName"].ToString();
                    lblLocationName.Text = _dataRow["Location"].ToString();
                    lblPayCycleDays.Text = _dataRow["TotalDays_PayCycle"].ToString();
                    lblLOPDays.Text = _dataRow["TotalDays_Unpaid"].ToString();
                    lblBankAccount.Text = _dataRow["BankAccount"].ToString();
                    lblBankName.Text = _dataRow["BankName"].ToString();
                    lblTotalEarnings.Text = _dataRow["TotalEarnings"].ToString();
                    lblTotalDeductions.Text = _dataRow["Total_Deductions"].ToString();
                    lblNetPay.Text = _dataRow["NetPay"].ToString();
                    lblPayrollNote.Text = _dataRow["PayrollNote"].ToString();
                    if (_dataRow["EOSPayout"].ToString() == "1")
                    {
                        lblPayrollNote.Text = lblPayrollNote.Text + ' ' + "End of Service-Final Pay Slip.";
                    }
                    //lblPayrollGeneratedDate.Text = DateTime.Now.ToString(@"d/M/yyyy hh:mm:ss tt");
                }
                else
                {
                    message.Visible = true;
                    message.Text = "No Payroll data is available for the selected Month/Year.Please check with your Payroll Administrator.";
                    message.CssClass = "errorMessage";

                }
                if (_DataList.Tables[1].Rows.Count >= 0) // Earnings Component
                {
                    DataTable dt = _DataList.Tables[1];
                    HtmlTableRow htr = new HtmlTableRow();  // Header Row
                    HtmlTableCell htd = new HtmlTableCell();
                    htd.ColSpan = 2;
                    htd.InnerText = "Entitlements";
                    htd.Attributes.Add("Class", "mainheadtxt4");
                    htd.Align = "left";
                    htr.Cells.Add(htd);
                    htr.BgColor = "lightgray";
                    BenefitTableContent.Rows.Add(htr);
                    //Add Empty Row for spacing
                    htr = new HtmlTableRow();  // empty row 1
                    htd = new HtmlTableCell();
                    htd.ColSpan = 2;
                    htd.InnerText = "";
                    htr.Cells.Add(htd);
                    BenefitTableContent.Rows.Add(htr);



                    // Get DataTable Column's Row
                    foreach (DataRow dataRow in dt.Rows)
                    {
                        HtmlTableRow tr = new HtmlTableRow();
                        for (int i = 0; i <= dt.Columns.Count - 1; i++)
                        {
                            HtmlTableCell td = new HtmlTableCell();
                            if (i == 0) // First Column- Label
                            {
                                td.InnerText = dataRow[i].ToString();
                                td.Attributes.Add("Class", "mainheadtxt");
                            }
                            if (i == 1) // Second Column- Value
                            {
                                td.InnerText = dataRow[i].ToString();
                                td.Attributes.Add("Class", "mainheadtxt");
                                td.Align = "right";
                            }
                            tr.Cells.Add(td);
                        }
                        BenefitTableContent.Rows.Add(tr);
                    }

                }


                if (_DataList.Tables[2].Rows.Count >= 0)  // Deduction Component
                {
                    DataTable dt = _DataList.Tables[2];
                    HtmlTableRow htr = new HtmlTableRow();  // Header Row
                    HtmlTableCell htd = new HtmlTableCell();
                    htd.ColSpan = 2;
                    htd.InnerText = "Deductions";
                    htd.Attributes.Add("Class", "mainheadtxt4");
                    htd.Align = "left";
                    htr.Cells.Add(htd);
                    htr.BgColor = "lightgray";
                    DeductionTableContent.Rows.Add(htr);
                    //Add Empty Row for spacing
                    htr = new HtmlTableRow();  // empty row 1
                    htd = new HtmlTableCell();
                    htd.ColSpan = 2;
                    htd.InnerText = " ";
                    htr.Cells.Add(htd);
                    DeductionTableContent.Rows.Add(htr);             

                    // Get DataTable Column's Row
                    foreach (DataRow dataRow in dt.Rows)
                    {
                        HtmlTableRow tr = new HtmlTableRow();
                        for (int i = 0; i <= dt.Columns.Count - 1; i++)
                        {
                            HtmlTableCell td = new HtmlTableCell();
                            if (i == 0) // First Column- Label
                            {
                                td.InnerText = dataRow[i].ToString();
                                td.Attributes.Add("Class", "mainheadtxt");
                            }
                            if (i == 1) // Second Column- Value
                            {
                                td.InnerText = dataRow[i].ToString();
                                td.Attributes.Add("Class", "mainheadtxt");
                                td.Align = "right";
                            }
                            tr.Cells.Add(td);
                        }
                        DeductionTableContent.Rows.Add(tr);
                    }


                }
            }
        }


    }
}
using System;
using System.Data;
using System.Text;
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
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using iTextSharp.tool.xml;
using iTextSharp.tool.xml.parser;
using iTextSharp.tool.xml.pipeline;




namespace SchoolNet
{
    public partial class ViewPaySlip : SchoolNetBase
    {
        protected System.Web.UI.HtmlControls.HtmlInputButton printbtn;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
               // LoadEmployeePayrollInfo(Int32.Parse(Page.User.Identity.Name.ToString()), Payroll_Date.Text);
            }
           // LoadEmployeePayrollInfo(Int32.Parse(Page.User.Identity.Name.ToString()), Payroll_Date.Text);
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

            Payroll_Go.Click += new EventHandler(Payroll_Go_Click);
            //PayStub_Print.Click +=new EventHandler(PayStub_Print_Click);
            SavePDF.Click += new EventHandler(SavePDF_Click);
            


        }
        #endregion
       
      /* Used for saving as PDF. This is not complete due to htmlparser error. */
      
        protected void SavePDF_Click(object sender, EventArgs e)
        {
            try
            {
                string HRSystemLink = ConfigurationManager.AppSettings["HRSystemURL"].ToString();
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=payslip.pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                LoadEmployeePayrollInfo(Int32.Parse(Page.User.Identity.Name.ToString()), Payroll_Date.Text);
                PayStubViewPaycomponents.RenderControl(hw);
                StringBuilder sb = new StringBuilder();
                /* html to parse */
             //  sb.Append("<html><head><title>AON ME HR System-Payroll</title>");
             //   sb.Append("<link rel=stylesheet type=text/css href=\"http://localhost:56141/HRMSNet_Dev/CSS/CommonStyles.css \" />");
             //  sb.Append("<link rel=stylesheet type=text/css href=\""+HRSystemLink+"/CSS/CommonStyles.css media=all\" />");
                sb.Append("<html><body><table>");
                sb.Append(sw.ToString());
                sb.Append("</table></body></html>");
                StringReader sr = new StringReader(sb.ToString());
                Document pdfDoc = new Document(PageSize.A4, 7f, 7f, 7f, 0f);
               // pdfDoc.HtmlStyleClass = "mainheadtxt4";
                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfDoc.Open();
                htmlparser.Parse(sr);
                pdfDoc.Close();
                Response.Write(pdfDoc);
                Response.End();


            }
            catch (Exception exception)
            {
                this.message.Visible = true;
                this.message.Text = ErrorLogging.LogError(exception, "Unknown Exception Occured. Please contact support.");
                this.message.CssClass = "errorMessage";
            }
    
        }
     
        protected void PayStub_Print_Click(object sender, EventArgs e)
        {
            {
               // PayStub_Print.Attributes.Add("Onclick", "getPrint('PrintArea');");

             //   Session["ctrl"] = PayStubViewPaycomponents;
             //   ClientScript.RegisterStartupScript(this.GetType(), "onclick", "getPrint('PrintArea');");

            }

        }
        protected void Payroll_Go_Click(object sender, EventArgs e)
        {
            if (Page.IsValid == true)
            {
                PayStubViewPaycomponents.Visible = true;
                printbutton.Visible = true;
                SavePDF.Visible = true;
                LoadEmployeePayrollInfo(Int32.Parse(Page.User.Identity.Name.ToString()), Payroll_Date.Text);
                
            }


        }


        protected void LoadEmployeePayrollInfo(Int32 EmpId, String MonthYear)
        {
            message.Visible = false;
            CustomerLogo.Visible = false;
            message.Text = "";
            DataSet _DataList = null;
            _DataList = DatabaseManager.Data.DBAccessManager.RetrieveEmployeePaySlipInfo(EmpId, MonthYear);
            if (_DataList.Tables.Count > 1)
            {
                if (_DataList.Tables[0].Rows.Count > 0) // Standard Pay Components.
                {
                    DataRow _dataRow = _DataList.Tables[0].Rows[0];


                    if (_dataRow["PayrollStatusTypeID"].ToString() != "3") // Do not show if the payroll is pending.
                    {
                        PayStubViewPaycomponents.Visible = false;
                        printbutton.Visible = false;
                        message.Visible = true;
                        message.Text = "No Payroll data is available for the selected Month/Year.Please check with your Payroll Administrator.";
                        message.CssClass = "errorMessage";
                        return;
                    }
                    CustomerLogo.Visible = true;
                    CustomerLogo.ImageUrl = _dataRow["CompanyLogoImgName"].ToString();
                        //UrlDecode("~/Images/" + _dataRow["CompanyLogoImgName"].ToString());
                        //"~/Images/" + _dataRow["CompanyLogoImgName"].ToString();
                    //lblCompanyName.Text = _dataRow["CompanyName"].ToString();
                    lblCompanyName.Text = _dataRow["DivisionName"].ToString(); 
                    lblDivisionName.Text = _dataRow["Location"].ToString();
                    lblPaySlipPeriod.Text = "Pay Slip for " + _dataRow["PayMonthYear"].ToString();
                    lblCurrencyName.Text = "(All Figures in " + _dataRow["CurrencyCode"].ToString() +')';
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
                    lblPayrollGeneratedDate.Text = DateTime.Now.ToString(@"d/M/yyyy hh:mm:ss tt");
                }
                else
                {
                    PayStubViewPaycomponents.Visible = false;
                    printbutton.Visible = false;
                    CustomerLogo.Visible = false;
                    message.Visible = true;
                    message.Text = "No Payroll data is available for the selected Month/Year.Please check with your Payroll Administrator.";
                    message.CssClass = "errorMessage";

                }
                if (_DataList.Tables[1].Rows.Count > 0) // Earnings Component
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


                if (_DataList.Tables[2].Rows.Count > 0)  // Deduction Component
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
                        tr.VAlign = "top";
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
            else
            {
                PayStubViewPaycomponents.Visible = false;
                printbutton.Visible = false;
                message.Visible = true;
                message.Text = "No Payroll data is available for the selected Month/Year.Please check with your Payroll Administrator.";
                message.CssClass = "errorMessage";
                SavePDF.Visible = false;
                CustomerLogo.Visible = false;
                return;
            }
        }


        protected void Payroll_Preview_Click(object sender, EventArgs e)
        {



        } 

    }
}
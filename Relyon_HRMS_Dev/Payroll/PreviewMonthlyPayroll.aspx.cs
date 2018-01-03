using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using PresentationManager.Web.UI.MasterPages;
using ReportClass;

namespace SchoolNet
{
    public partial class PreviewMonthlyPayroll : SchoolNetBase 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadDivisionLookupByEmpId(businessUnitDDList, Int32.Parse(Page.User.Identity.Name.ToString()));
                LoadEntityLocationLookupByEmpId_DivisionID(DivisionLocationList, Int32.Parse(Page.User.Identity.Name.ToString()), Int32.Parse(businessUnitDDList.SelectedValue));

            }
            if (Int32.Parse(DivisionLocationList.SelectedValue) == -1)
            {
                LoadEntityLocationLookupByEmpId_DivisionID(DivisionLocationList, Int32.Parse(Page.User.Identity.Name.ToString()), Int32.Parse(businessUnitDDList.SelectedValue));
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
            Preview.Click += new EventHandler(Preview_Click);
        }
        #endregion
        protected void Preview_Click(object sender, EventArgs e)
        {
            if (Page.IsValid == true)
            {
                PreviewEmployeeMonthlyPayroll(Payroll_Date.Text, Int32.Parse(businessUnitDDList.SelectedValue), Int32.Parse(DivisionLocationList.SelectedValue), Int32.Parse(Page.User.Identity.Name.ToString()));
            }

        }

        protected void PreviewEmployeeMonthlyPayroll(String Pay_MonthYear, Int32 DivisionID, Int32 DivisionLocationID, Int32 RequestingEmpId)
        {
            try
            {
                DataSet _DataList = null;
                _DataList = DatabaseManager.Data.DBAccessManager.RetrieveEmployeeMonthlyPayroll_Preview(Pay_MonthYear, DivisionID, DivisionLocationID, RequestingEmpId);

                if (_DataList.Tables.Count > 0)
                {
                    if (_DataList.Tables[0].Rows.Count > 0)
                    {
                        this.message.Visible = false;
                        this.message.Text = "";
                        DataTable _dataTable = _DataList.Tables[0];
                        ExportToExcel(_dataTable);

                    }
                    else
                    {
                        this.message.Visible = true;
                        this.message.Text = "No matching data found!.";
                        this.message.CssClass = "errorMessage";
                    }
                }
                else
                {
                    this.message.Visible = true;
                    this.message.Text = "No Pending Payroll data exists to process";
                    this.message.CssClass = "errorMessage";

                }
            }
            catch (Exception exception)
            {
               // ErrorLogging.LogError(exception, "");
                this.message.Visible = true;
                this.message.Text = ErrorLogging.LogError(exception, "Unknown Exception Occured.Please contact Support.");
                this.message.CssClass = "errorMessage";

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
            Response.AddHeader("content-disposition", "attachment;filename=MonthlyPayrollPreview.xls");
           // Response.ContentEncoding = Encoding.UTF8;
            Response.Charset = "";
            EnableViewState = false;
            String ReportTitle = "<B>Monthly Payroll Preview Report for " + Payroll_Date.Text + ", " + businessUnitDDList.SelectedItem.ToString() + "/ " + DivisionLocationList.SelectedItem.ToString() + " As of " + DateTime.Now.ToString(@"dd/MM/yyyy") + "</b>"; 
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
    }
}
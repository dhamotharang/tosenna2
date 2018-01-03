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

namespace SchoolNet
{
    public partial class ProcessMonthlyPayroll : SchoolNetBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                UserAlert();
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
            Submit.Click += new EventHandler(Submit_Click);
        }
        #endregion
        protected void Submit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid == true)
            {
                RunEmployeeMonthlyPayroll(Payroll_Date.Text, Int32.Parse(businessUnitDDList.SelectedValue), Int32.Parse(DivisionLocationList.SelectedValue), Int32.Parse(Page.User.Identity.Name.ToString()));
            }
        }
        private void UserAlert()
        {
            string message = "ATTENTION! \\r\\n Please note that if there are any end of service (EOS) employees during the current payroll month, First you must request Local HR admin to update the end of service employee status (Resigned or Terminated) along with date of resigned and date of leaving via Jobs Tab under Employee Management Module before any payroll process. After that, you have to choose either Option 1 or Option 2 as below.\\r\\n\\r\\nOption 1: Do NOT Process EOS via System.\\r\\n In this case, just go to Deactivate Employee Profile via Employee Management Module by supplying Employee ID and click Deactivate button.\\r\\n\\r\\nThe Option 2:Process EOS along with Monthly Payroll.\\r\\n In this case, Local HR admin needs to make sure that  employee status, date resigned and date of leaving is updated and then process EOS(batch).";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
       //     sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("');");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }
        protected void RunEmployeeMonthlyPayroll(String Pay_MonthYear, Int32 DivisionID, Int32 DivisionLocationID, Int32 RequestingEmpId)
        {
            try
            {
                DataSet _DataList = null;
                _DataList = DatabaseManager.Data.DBAccessManager.RetrieveEmployeeProcessedMonthlyPayroll(Pay_MonthYear, DivisionID, DivisionLocationID, RequestingEmpId);
                if (_DataList.Tables.Count > 0)
                {
                    if (_DataList.Tables[0].Rows.Count > 0)
                    {
                        DataTable _dataTable = _DataList.Tables[0];
                        ExportToExcel(_dataTable);
                    }
                    else
                    {
                        this.message.Visible = true;
                        this.message.Text = "No Payroll Data available for the selected pay period. Either it is unavailable or already processed for the selected pay period.";
                        this.message.CssClass = "errorMessage";
                    }
                }
                else
                {
                    this.message.Visible = true;
                    this.message.Text = "No Payroll Data available for the selected pay period.Either it is unavailable or already processed for the selected pay period.";
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
            Response.AddHeader("content-disposition", "attachment;filename=ProcessedMonthlyPayroll.xls");
            // Response.ContentEncoding = Encoding.UTF8;
            Response.Charset = "";
            EnableViewState = false;
            String ReportTitle = "<B>Processed Monthly Payroll  Report for " + Payroll_Date.Text + ", " + businessUnitDDList.SelectedItem.ToString() + "/ " + DivisionLocationList.SelectedItem.ToString() + " As of " + DateTime.Now.ToString(@"dd/MM/yyyy") + "</b>"; 
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
                      //  if ((dt.Columns[i].ToString() == "Employee Name") || (dt.Columns[i].ToString() == "Employee ID"))
                      //  { Response.Write(row[i].ToString()); }
                       // else { Response.Write("&nbsp;" + row[i].ToString()); }
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

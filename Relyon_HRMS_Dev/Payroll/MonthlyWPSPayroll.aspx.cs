using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.IO;
using System.Text;
using context = System.Web.HttpContext;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using PresentationManager.Web.UI.MasterPages;

namespace SchoolNet
{
    public partial class MonthlyWPSPayroll : SchoolNetBase
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
            Submit.Click += new EventHandler(Submit_Click);
        }
        #endregion
        protected void Submit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid == true)
            {
                RunEmployeeWPSMonthlyPayroll(Payroll_Date.Text, Int32.Parse(businessUnitDDList.SelectedValue), Int32.Parse(DivisionLocationList.SelectedValue), Int32.Parse(Page.User.Identity.Name.ToString()));
            }
        }

        protected void RunEmployeeWPSMonthlyPayroll(String Pay_MonthYear, Int32 DivisionID, Int32 DivisionLocationID, Int32 RequestingEmpId)
        {
            try
            {
                DataSet _DataList = null;
                string FileName = "";
                _DataList = DatabaseManager.Data.DBAccessManager.RetrieveFinalizedMonthlyWPSPayroll(Pay_MonthYear, DivisionID, DivisionLocationID, RequestingEmpId);
                  if (_DataList.Tables[0].Rows.Count > 0) // WPS FileName.
                    {
                         FileName = _DataList.Tables[0].Rows[0]["FileName"].ToString();

                    }
                    if (_DataList.Tables[1].Rows.Count > 0) // WPS Data
                    {
                        DataTable _dataTable = _DataList.Tables[1];
                        CreateCsvFile(_dataTable, FileName);
                       // ExportToExcel(_dataTable);
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

       public void CreateCsvFile(DataTable dt, String FileName)
        {

            try
            {
                string path = context.Current.Server.MapPath("~/WPS/");
                // check if directory exists
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                path = path + FileName + ".sif";
                // check if file exist
                if (!File.Exists(path))
                {
                    File.Create(path).Dispose();
                }
                // log the error now
                using (StreamWriter writer = File.AppendText(path))
                {

                    

                    // Get DataTable Column's Row
                    foreach (DataRow row in dt.Rows)
                    {
                        StringBuilder sb = new StringBuilder();

                        for (int i = 0; i <= dt.Columns.Count - 1; i++)
                        {
                            if (sb.Length > 0) { sb.Append(","); }
                            sb.Append(row[i].ToString());
                        }

                        // write output to file
                         writer.WriteLine(sb.ToString());
                    }
                    
                    writer.Flush();
                    writer.Close();
                }
                WPSDownloadLink.Visible = true;
                WPSDownloadLink.Text = "Click here to download WPS Extract File";
                WPSDownloadLink.CssClass="mainheadtxt";
                WPSDownloadLink.NavigateUrl = "~/WPS/" + FileName + ".sif";


            }
            catch(Exception exception)
            {
                ErrorLogging.LogError(exception, "");
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
            Response.AddHeader("content-disposition", "attachment;filename=MonthlyWPSPayroll.xls");
            // Response.ContentEncoding = Encoding.UTF8;
            Response.Charset = "";
            EnableViewState = false;

            //Set Fonts
            Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
            Response.Write("<BR><BR><BR>");

            //Sets the table border, cell spacing, border color, font of the text, background,
            //foreground, font height
            Response.Write("<Table border='1' bgColor='#ffffff' borderColor='#000000' cellSpacing='0' cellPadding='0' style='font-size:10.0pt; font-family:Calibri; background:white;'> <TR>");

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

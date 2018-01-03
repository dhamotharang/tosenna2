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
    public partial class EmployeeServiceYearsReport : SchoolNetBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadDivisionLookupByEmpId(businessUnitDDList, Int32.Parse(Page.User.Identity.Name.ToString()));
                LoadEntityLocationLookupByEmpId_DivisionID(DivisionLocationList, Int32.Parse(Page.User.Identity.Name.ToString()), Int32.Parse(businessUnitDDList.SelectedValue));

            }
            this.message.Visible = false;
            this.message.Text = "";

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
            Export.Click += new EventHandler(Export_Click);
            businessUnitDDList.SelectedIndexChanged += new EventHandler(businessUnitDDList_SelectedIndexChanged);
        }
        #endregion
        protected void Export_Click(object sender, EventArgs e)
        {
            if (Page.IsValid == true)
            {
                this.message.Visible = false;
                this.message.Text = "";
                GetServiceYearsData();
            }

        }
        protected void businessUnitDDList_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadEntityLocationLookupByEmpId_DivisionID(DivisionLocationList, Int32.Parse(Page.User.Identity.Name.ToString()), Int32.Parse(businessUnitDDList.SelectedValue));

        }

        protected void GetServiceYearsData()
        {
            try
            {
                Int32 ServiceYears = 5; // Default is 5 years
                if (Tab1_Rb1.Checked) { ServiceYears = 5; } // 5 years
                if (Tab1_Rb2.Checked) { ServiceYears = 10; } // 10 years
                if (Tab1_Rb3.Checked) { ServiceYears = 15; } // 15 years
                if (Tab1_Rb4.Checked) { ServiceYears = 20; } // 20 years
                if (Tab1_Rb5.Checked) { ServiceYears = 25; } // 25 years

                DataSet _DataList = null;
                _DataList = DatabaseManager.Data.DBAccessManager.RetrieveServiceYearData(Int32.Parse(businessUnitDDList.SelectedValue), Int32.Parse(DivisionLocationList.SelectedValue), ServiceYears, Int32.Parse(Page.User.Identity.Name.ToString()));

                if (_DataList.Tables[0].Rows.Count > 0)
                {
                    DataTable _dataTable = _DataList.Tables[0];
                    ExportToExcel(_dataTable);
                    this.message.Visible = false;
                    this.message.Text = "";

                }
                else
                {
                    this.message.Visible = true;
                    this.message.Text = "No matching data found!.";
                    this.message.CssClass = "errorMessage";
                }
            }
            catch (Exception exception)
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
            Response.AddHeader("content-disposition", "attachment;filename=EmployeeServiceYearsReport.xls");
            // Response.ContentEncoding = Encoding.UTF8;
            Response.Charset = "";
            EnableViewState = false;
            String ServiceYears = ""; // Default is 5 years
            if (Tab1_Rb1.Checked) { ServiceYears = "5 Years"; } // 5 years
            if (Tab1_Rb2.Checked) { ServiceYears = "10 Years"; } // 10 years
            if (Tab1_Rb3.Checked) { ServiceYears = "15 Years"; } // 15 years
            if (Tab1_Rb4.Checked) { ServiceYears = "20 Years"; } // 20 years
            if (Tab1_Rb5.Checked) { ServiceYears = "25 Years"; } // 25 years

            String ReportTitle = "<B>Employee Service Years Report : " + ServiceYears + " As of " + DateTime.Now.ToString(@"dd/MM/yyyy");

            //Set Fonts
            Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
            Response.Write("<BR><BR><BR>");

            //Sets the table border, cell spacing, border color, font of the text, background,
            //foreground, font height

            Response.Write("<Table border='1' bgColor='#ffffff' borderColor='#000000' cellSpacing='0' cellPadding='0' style='font-size:10.0pt; font-family:Calibri; background:white;'>");
            //Write the header
            Response.Write("<TR font style='font-size:13.0pt; font-family:Calibri;'><TD align='center' Colspan=" + dt.Columns.Count + ">");
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
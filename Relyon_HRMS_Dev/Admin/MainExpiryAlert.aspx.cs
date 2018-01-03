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
    public partial class MainExpiryAlert : SchoolNetBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadExpiryAlertDataType(ExpiryAlertDataTypeList);
                LoadDivisionLookupByEmpId(businessUnitDDList, Int32.Parse(Page.User.Identity.Name.ToString()));
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
                GetExpiryAlertData();
            }

        }
        protected void businessUnitDDList_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadEntityLocationLookupByEmpId_DivisionID(DivisionLocationList, Int32.Parse(Page.User.Identity.Name.ToString()), Int32.Parse(businessUnitDDList.SelectedValue));

        }

        protected void GetExpiryAlertData()
        {
            try
            {
                Int32 AlertPeriod = 30; // Default is 30 days
                if (Tab1_Rb1.Checked) { AlertPeriod = 30; } // 30 days
                if (Tab1_Rb2.Checked) { AlertPeriod = 60; } // 60 days
                if (Tab1_Rb3.Checked) { AlertPeriod = 90; } // 90 days
                if (Tab1_Rb4.Checked) { AlertPeriod = 120; } // 120 days

                DataSet _DataList = null;
                _DataList = DatabaseManager.Data.DBAccessManager.RetrieveAlertData(Int32.Parse(ExpiryAlertDataTypeList.SelectedValue), Int32.Parse(businessUnitDDList.SelectedValue), Int32.Parse(DivisionLocationList.SelectedValue), AlertPeriod, Int32.Parse(Page.User.Identity.Name.ToString()));

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
            Response.AddHeader("content-disposition", "attachment;filename=MainEmployeeDataExpiryAlert.xls");
            // Response.ContentEncoding = Encoding.UTF8;
            Response.Charset = "";
            EnableViewState = false;
            String alertPeriod = "";
            if (Tab1_Rb1.Checked) { alertPeriod = "30 days"; } // 30 days
            if (Tab1_Rb2.Checked) { alertPeriod = "60 days"; } // 60 days
            if (Tab1_Rb3.Checked) { alertPeriod = "90 days"; } // 90 days
            if (Tab1_Rb4.Checked) { alertPeriod = "120 days"; } // 120 days

            String ReportTitle = "<B>" + ExpiryAlertDataTypeList.SelectedItem.ToString() + " " + "Expiry Alert in the next " + alertPeriod + " for " + businessUnitDDList.SelectedItem.ToString() + " As of " + DateTime.Now.ToString(@"dd/MM/yyyy"); 

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
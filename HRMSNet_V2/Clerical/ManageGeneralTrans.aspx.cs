using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
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
    public partial class ManageGeneralTrans : SchoolNetBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadEmployeeListLookupByEmpId(Tab1_EmployeeList, Int32.Parse(Page.User.Identity.Name.ToString()));
                LoadImportDataType(Tab1_ImportDataTypeList);
                LoadVisaType(this.Tab1_VisaType);
                LoadCountryList(this.Tab1_CountryList);
                //  LoadDailyFNTransactionsList();
            }
           // LoadDailyFNTransactionsList();


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

            Tab2Grid.PageIndexChanged += new DataGridPageChangedEventHandler(Tab2Grid_PageIndexChanged);
            Tab1_ImportDataTypeList.SelectedIndexChanged += new EventHandler(Tab1_ImportDataTypeList_SelectedIndexChanged);
            Tab1_Reset.Click += new EventHandler(Tab1_Reset_Click);
            Tab1_Save.Click += new EventHandler(Tab1_Save_Click);
            Tab2_Reset.Click += new EventHandler(Tab2_Reset_Click);
            tab1.Click += new EventHandler(tab1_Click);
            tab2.Click += new EventHandler(tab2_Click);
            Import.Click += new EventHandler(Import_Click);
            Export1.Click += new EventHandler(Export1_Click);

        }
        #endregion
        protected void Tab1_ImportDataTypeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Tab1_ImportDataTypeList.SelectedValue == "3") // Visa
            { Tab1_VisaType.Visible = true; }   else   { Tab1_VisaType.Visible = false; }

        }
     


        protected void Export1_Click(object sender, EventArgs e)
        {
            DataSet _DataList = null;
            _DataList = DatabaseManager.Data.DBAccessManager.RetrieveImportedErrorData(Int32.Parse(Page.User.Identity.Name.ToString()), StringEnum.stringValueOf(Constants.ImportType.LaborVisaPP));
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
            Response.AddHeader("content-disposition", "attachment;filename=GeneralTransactions.xls");
            // Response.ContentEncoding = Encoding.UTF8;
            Response.Charset = "";
            EnableViewState = false;
            String ReportTitle = "<B>General Transactions Import As of " + DateTime.Now.ToString(@"dd/MM/yyyy") + "</b>";
            //Set Fonts
            Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
            Response.Write("<BR><BR><BR>");

            //Sets the table border, cell spacing, border color, font of the text, background,
            //foreground, font height
            Response.Write("<Table border='1' bgColor='#ffffff' borderColor='#000000' cellSpacing='0' cellPadding='0' style='font-size:10.0pt; font-family:Calibri; background:white;'> <TR>");
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


        #region LoadErrorDataList()
        private void LoadErrorDataList()
        {
            try
            {
                DataSet _DataList = null;
                _DataList = DatabaseManager.Data.DBAccessManager.RetrieveImportedErrorData(Int32.Parse(Page.User.Identity.Name.ToString()), StringEnum.stringValueOf(Constants.ImportType.LaborVisaPP));
                if (_DataList.Tables.Count > 0)
                {
                    if (_DataList.Tables[0].Rows.Count > 0) 
                    {
                        DataTable _dataTable = _DataList.Tables[0];
                        this.Tab2Grid.DataSource = _dataTable;
                        this.Tab2Grid.DataBind();
                        Export1.Visible = true;
                    }
                    else
                    {
                        this.Tab2Grid.DataSource = null;
                        this.Tab2Grid.DataBind();
                        Export1.Visible = false;
                    }

                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }

        }
        #endregion


        #region Reset_Click
        protected void Tab2_Reset_Click(object sender, EventArgs e)
        {
            Tab2_Message.Text = "";
            Tab2_Message.Visible = false;
            Export1.Visible = false;


        }
        #endregion
        #region Tab1_Save_Click
        protected void Tab1_Save_Click(object sender, EventArgs e)
        {
           try
            {
                if (Page.IsValid == true)
                {
                    if (Tab1_keyField.Text.ToString() == "") { Tab1_keyField.Text = "0"; }
                    String Result = DatabaseManager.Data.DBAccessManager.AddUpdateGenTransactions(Int32.Parse(Tab1_EmployeeList.SelectedValue), Int32.Parse(Tab1_ImportDataTypeList.SelectedValue), Tab1_InstrumentNo.Text, ConvertDMY_MDY(Tab1_VisaIssueDate), ConvertDMY_MDY(Tab1_VisaExpiryDate), Int32.Parse(Tab1_CountryList.SelectedValue), Int32.Parse(Tab1_VisaType.SelectedValue), Int32.Parse(Page.User.Identity.Name.ToString()));
                    this.Tab1_Message.Visible = true;
                    this.Tab1_Message.CssClass = "errorMessage";
                    if (Result == "")
                    {
                        this.Tab1_Message.Text = "Successfully saved.";
                        ClearTab2();

                    }
                    else
                    {
                        this.Tab1_Message.Text = Result;
                    }
                }
                else
                {
                    this.Tab1_Message.Text = "Error:Could not save the information. Please check the inputs and submit again";
                    this.Tab1_Message.CssClass = "errorMessage";

                }

            }
            catch (Exception exception)
            {
                this.Tab1_Message.Visible = true;
                this.Tab1_Message.Text = ErrorLogging.LogError(exception, "Unknown Exception Occured. Please contact support.");
                this.Tab1_Message.CssClass = "errorMessage";
            }
            
        }
        #endregion
        #region Reset_Click
        protected void Tab1_Reset_Click(object sender, EventArgs e)
        {
            ClearTab2();
            Tab1_Message.Text = "";
            Tab1_Message.Visible = false;
        }
        #endregion

        private void ClearTab2()
        {
            Tab1_VisaIssueDate.Text = "";
            Tab1_InstrumentNo.Text = "";
            Tab1_ImportDataTypeList.SelectedIndex = -1;
            Tab1_EmployeeList.SelectedIndex = -1;
            Tab1_CountryList.SelectedIndex = -1;
            Tab1_VisaType.SelectedIndex = -1;
            Tab1_VisaExpiryDate.Text = "";
            Tab1_keyField.Text = "";
        }
        private void TabSettings()
        {
            message.Visible = false;
            Tab1_Pane.Visible = false;
            Tab2_Pane.Visible = false;

        }
        protected void tab1_Click(object sender, EventArgs e)
        {
            TabSettings();
            Tab1_Pane.Visible = true;

        }
        protected void tab2_Click(object sender, EventArgs e)
        {
            TabSettings();
            Tab2_Pane.Visible = true;
            Export1.Visible = false;
            TemplateDownloadLink.Visible = true;
            TemplateDownloadLink.Text = "Click here to download the import template for this transaction.";
            TemplateDownloadLink.CssClass = "mainheadtxt";
            TemplateDownloadLink.NavigateUrl = "~/Template/LaborVisaPassportTemplate.xlsx";


        }
        protected void Import_Click(object sender, EventArgs e)
        {
            try
            {
            if ((fileuploadExcel.FileName != ""))
            {
                string extension = System.IO.Path.GetExtension(fileuploadExcel.PostedFile.FileName);
                string excelConnectionString;
                SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings.Get("ConnectionInfo"));
                string connStr = System.Configuration.ConfigurationSettings.AppSettings.Get("ConnectionInfo");

                string path = fileuploadExcel.PostedFile.FileName;
                string tableName = StringEnum.stringValueOf(Constants.ImportTableName.LaborVisaPP);
                //Create connection string to Excel work book
                if (extension == ".xls")
                {
                    excelConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path +
                                                          ";Extended Properties=Excel 8.0";
                }
                else
                {
                    excelConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path +
                                                         ";Extended Properties=Excel 12.0 Xml";
                }

                //Create Connection to Excel work book
                OleDbConnection excelConnection = new OleDbConnection(excelConnectionString);
                //Create OleDbCommand to fetch data from Excel             
                connection.Open();
                SqlCommand comm = new SqlCommand("delete from " + tableName, connection);
                comm.ExecuteNonQuery();
                SqlCommand identityChange = connection.CreateCommand();
                identityChange.CommandText = "SET IDENTITY_INSERT " + tableName + " OFF";
                OleDbCommand cmd = new OleDbCommand("Select * from [Sheet1$]", excelConnection);
                excelConnection.Open();
                OleDbDataReader dReader;
                dReader = cmd.ExecuteReader();
                identityChange.ExecuteNonQuery();
                SqlBulkCopy sqlBulk = new SqlBulkCopy(connStr);
                //Give your Destination table name
                sqlBulk.DestinationTableName = tableName;
                sqlBulk.WriteToServer(dReader);
                excelConnection.Close();
                connection.Close();
                // Validate the data in the staging table and return all bad data.

                Tab2_Message.CssClass = "errorMessage";
                Tab2_Message.Visible = true;
                DataSet _DataList = null;
                _DataList = DatabaseManager.Data.DBAccessManager.ValidateImportedTransactions(Int32.Parse(Page.User.Identity.Name.ToString()),StringEnum.stringValueOf(Constants.ImportType.LaborVisaPP));
                if (_DataList.Tables.Count > 0)
                {
                    if (_DataList.Tables[0].Rows.Count > 0) // Bad Data exists
                    {
                        DataTable _dataTable = _DataList.Tables[0];
                        this.Tab2Grid.DataSource = _dataTable;
                        this.Tab2Grid.DataBind();
                        Export1.Visible = true;
                        Tab2_Message.Text = "The following data was not imported due to validation error. Please fix them and re-import.";
                    }
                    else
                    {
                        this.Tab2Grid.DataSource = null;
                        this.Tab2Grid.DataBind();
                        Export1.Visible = false;
                        Tab2_Message.Text = "All data has been successfully imported into the system";
                    }
                }
            }
            else
            {
                Tab2_Message.CssClass = "errorMessage";
                Tab2_Message.Text = "Please select the excel (.xls) file to import.";
            }
        }
         catch (Exception exception)
            {
                this.Tab2_Message.Visible = true;
                this.Tab2_Message.Text = ErrorLogging.LogError(exception, "Unknown Exception Occured. Please check the data in the import file.");
                this.Tab2_Message.CssClass = "errorMessage";
            }

        }




        protected void Tab2Grid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            Tab2Grid.CurrentPageIndex = e.NewPageIndex;
            LoadErrorDataList();
        }


    }
}


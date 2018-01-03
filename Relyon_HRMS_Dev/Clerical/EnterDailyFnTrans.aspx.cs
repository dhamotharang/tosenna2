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
    public partial class EnterDailyFnTrans : SchoolNetBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            
            if (!Page.IsPostBack)
            {
                UserAlert();
                LoadEmployeeListLookupByEmpId(Tab2_EmployeeList, Int32.Parse(Page.User.Identity.Name.ToString()));
                LoadPayComponentTypeLookup(Tab2_PayComponentTypeList);
                RetrievePayComponentListByCompTypeID(Tab2_PayComponentList, (int)Constants.PayComponentType.Deduction, (int)Constants.PayFrequencyType.Adhoc);
              //  LoadDailyFNTransactionsList();
             
            }
            LoadDailyFNTransactionsList();

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
            Tab1Grid.PageIndexChanged += new DataGridPageChangedEventHandler(Tab1Grid_PageIndexChanged);
            Tab2_PayComponentTypeList.SelectedIndexChanged += new EventHandler(Tab2_PayComponentTypeList_SelectedIndexChanged);
            Tab1_Reset.Click += new EventHandler(Tab1_Reset_Click);
            Tab2_Save.Click += new EventHandler(Tab2_Save_Click);
            Tab2_Reset.Click += new EventHandler(Tab2_Reset_Click);
            tab1.Click += new EventHandler(tab1_Click);
            tab2.Click += new EventHandler(tab2_Click);
            Export.Click += new EventHandler(Export_Click);
            Import.Click += new EventHandler(Import_Click);
            Export1.Click += new EventHandler(Export1_Click);

        }
        #endregion

        protected void Tab2_PayComponentTypeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            RetrievePayComponentListByCompTypeID(Tab2_PayComponentList, Int32.Parse(Tab2_PayComponentTypeList.SelectedValue), (int)Constants.PayFrequencyType.Adhoc);
        }
        protected void Export_Click(object sender, EventArgs e)
        {
            DataSet _DataList = null;
            _DataList = DatabaseManager.Data.DBAccessManager.RetrieveDailyFNTransactionsList(Int32.Parse(Page.User.Identity.Name.ToString()));            
            if (_DataList.Tables[0].Rows.Count > 0)
            {
                DataTable _dataTable = _DataList.Tables[0];
                ExportToExcel(_dataTable);
            }

        }

        private void UserAlert()
        {
            string message = "ATTENTION! Please note that the transactions entered in this page is valid only for current pay period and they will disappear after monthly payroll is processed.This functionality is meant for entering only non-standard/non-recoccuring transactions.Advance or Loan Type of reoccuring transactions SHOULD NOT BE entered in this screen.";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }

        protected void Export1_Click(object sender, EventArgs e)
        {
            DataSet _DataList = null;
            _DataList = DatabaseManager.Data.DBAccessManager.RetrieveImportedErrorData(Int32.Parse(Page.User.Identity.Name.ToString()),StringEnum.stringValueOf(Constants.ImportType.Finance_01));
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
            Response.AddHeader("content-disposition", "attachment;filename=MonthPayrollFinTrans.xls");
            // Response.ContentEncoding = Encoding.UTF8;
            Response.Charset = "";
            EnableViewState = false;
            String ReportTitle = "<B>Daily Adhoc/Non-Reoccuring Financial Entries for Current Month Payroll Process As of " + DateTime.Now.ToString(@"dd/MM/yyyy") + "</b>";
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

        #region LoadDailyFNTransactionsList()
        private void LoadDailyFNTransactionsList()
        {
            try
            {
                DataSet _DataList = null;
                _DataList = DatabaseManager.Data.DBAccessManager.RetrieveDailyFNTransactionsList(Int32.Parse(Page.User.Identity.Name.ToString()));
                if (_DataList.Tables.Count > 0)
                {
                    if (_DataList.Tables[0].Rows.Count > 0) // Deductions Information
                    {
                        DataTable _DeductionTable = _DataList.Tables[0];
                        this.Tab2Grid.DataSource = _DeductionTable;
                        this.Tab2Grid.DataBind();
                        Export.Visible = true;
                    }
                    else
                    {
                        this.Tab2Grid.DataSource = null;
                        this.Tab2Grid.DataBind();
                        Export.Visible = false;
                    }

                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }

        }
        #endregion

        #region LoadErrorDataList()
        private void LoadErrorDataList()
        {
            try
            {
                DataSet _DataList = null;
                _DataList = DatabaseManager.Data.DBAccessManager.RetrieveImportedErrorData(Int32.Parse(Page.User.Identity.Name.ToString()), StringEnum.stringValueOf(Constants.ImportType.Finance_01));
                if (_DataList.Tables.Count > 0)
                {
                    if (_DataList.Tables[0].Rows.Count > 0) // Deductions Information
                    {
                        DataTable _DeductionTable = _DataList.Tables[0];
                        this.Tab1Grid.DataSource = _DeductionTable;
                        this.Tab1Grid.DataBind();
                        Export1.Visible = true;
                    }
                    else
                    {
                        this.Tab1Grid.DataSource = null;
                        this.Tab1Grid.DataBind();
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

        private void DeleteEmployeeDeductionComponent(Int32 Empid,Int32 PayComponentID)
        {
            try
            {
                String result = DatabaseManager.Data.DBAccessManager.DeleteEmployeeDailyFNTEntry(Empid,PayComponentID, Int32.Parse(Page.User.Identity.Name.ToString()));

                this.Tab2_Message.Visible = true;
                Tab2_Message.CssClass = "errorMessage";
                if (result == "") { this.Tab2_Message.Text = "Successfully deleted."; }
                else { this.Tab2_Message.Text = result; }
            }
            catch (Exception exception)
            {
                this.Tab2_Message.Visible = true;
                this.Tab2_Message.Text = ErrorLogging.LogError(exception, "Unknown Exception Occured.Please contact support.");
                this.Tab2_Message.CssClass = "errorMessage";

            }
            Tab2Grid.CurrentPageIndex = 0;
            LoadDailyFNTransactionsList(); // Refresh the grid after deletion.

        }

        #region Reset_Click
        protected void Tab1_Reset_Click(object sender, EventArgs e)
        {
            Tab1_Message.Text = "";
            Tab1_Message.Visible = false;
            Export1.Visible = false;


        }
        #endregion
        #region Tab2_Save_Click
        protected void Tab2_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid == true)
                {
                    if (Tab2_keyField.Text.ToString() == "") { Tab2_keyField.Text = "0"; }
                    String Result = DatabaseManager.Data.DBAccessManager.AddUpdateDailyFNTransactions(Int32.Parse(Tab2_EmployeeList.SelectedValue),Int32.Parse(Tab2_PayComponentList.SelectedValue),Decimal.Parse(NumericCheck_EmptyString(Tab2_Amount.Text)),Int32.Parse(Page.User.Identity.Name.ToString()));
                        
                    this.Tab2_Message.Visible = true;
                    this.Tab2_Message.CssClass = "errorMessage";
                    if (Result == "")
                    {
                        this.Tab2_Message.Text = "Successfully saved.";
                        ClearTab2();

                    }
                    else
                    {
                        this.Tab2_Message.Text = Result;
                    }
                }
                else
                {
                    this.Tab2_Message.Text = "Error:Could not save the information. Please check the inputs and submit again";
                    this.Tab2_Message.CssClass = "errorMessage";

                }

            }
            catch (Exception exception)
            {
                this.Tab2_Message.Visible = true;
                this.Tab2_Message.Text = ErrorLogging.LogError(exception, "Unknown Exception Occured. Please contact support.");
                this.Tab2_Message.CssClass = "errorMessage";
            }
            LoadDailyFNTransactionsList();

        }
        #endregion
        #region Reset_Click
        protected void Tab2_Reset_Click(object sender, EventArgs e)
        {
            ClearTab2();
            Tab2_Message.Text = "";
            Tab2_Message.Visible = false;
        }
        #endregion

        private void ClearTab2()
        {
            Tab2_Amount.Text = "";
            Tab2_PayComponentList.SelectedIndex = -1;
            Tab2_EmployeeList.SelectedIndex = -1;
            Tab2_PayComponentTypeList.SelectedIndex = -1;
         //   Tab2_keyField.Text = "";
         //   Tab2_EmpId.Text = "";

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
            LoadDailyFNTransactionsList();
           
        }
        protected void tab2_Click(object sender, EventArgs e)
        {
            TabSettings();
            Tab2_Pane.Visible = true;
            Export1.Visible = false;
            TemplateDownloadLink.Visible = true;
            TemplateDownloadLink.Text = "Click here to download the import template for this transaction.";
            TemplateDownloadLink.CssClass = "mainheadtxt";
            TemplateDownloadLink.NavigateUrl = "~/Template/AdhocTxn_ImportTemplate.xls";


        }
        protected void Import_Click(object sender, EventArgs e)
        {
            try
            {
                Tab1_Message.CssClass = "errorMessage";
                Tab1_Message.Visible = true;
                string extension = System.IO.Path.GetExtension(fileuploadExcel.PostedFile.FileName);
                if (fileuploadExcel.FileName != "" )//&& extension == ".xls")
                {
                    
                    string excelConnectionString;
                    SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings.Get("ConnectionInfo"));
                    string connStr = System.Configuration.ConfigurationSettings.AppSettings.Get("ConnectionInfo");

                   // string path = fileuploadExcel.PostedFile.FileName;

                    string path = Server.MapPath(Page.ResolveUrl("~\\App_Data\\") + fileuploadExcel.FileName);
                    fileuploadExcel.SaveAs(path);
                   // string a = fileuploadExcel.PostedFile.FileName;
                    

                    string tableName = StringEnum.stringValueOf(Constants.ImportTableName.FinanceTransaction);
                    //Create connection string to Excel work book
                    if (extension == ".xls")
                    {
                        excelConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path +
                                                              ";Extended Properties=Excel 8.0";
                    }
                    else if (extension == ".csv")
                    {
                        excelConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path +
                                                              ";Extended Properties=text;FMT=Delimited()";
                    }
                    else
                    {
                        excelConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path +
                                                             ";Extended Properties=Excel 12.0";
                    }

                    //Create Connection to Excel work book
                    OleDbConnection excelConnection = new OleDbConnection(excelConnectionString);
                    //Create OleDbCommand to fetch data from Excel             
                    connection.Open();
                    SqlCommand comm = new SqlCommand("delete from " + tableName, connection);
                    comm.ExecuteNonQuery();
                    SqlCommand identityChange = connection.CreateCommand();
                    identityChange.CommandText = "SET IDENTITY_INSERT " + tableName + " ON";
                    OleDbCommand cmd = new OleDbCommand("Select RowID,PSEmployeeID,ComponentCode,Amount from [Sheet1$] where RowID > 0", excelConnection);
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

                
                    DataSet _DataList = null;
                    _DataList = DatabaseManager.Data.DBAccessManager.ValidateImportedFinanceTransactions(Int32.Parse(Page.User.Identity.Name.ToString()));
                    if (_DataList.Tables.Count > 0)
                    {
                        if (_DataList.Tables[0].Rows.Count > 0) // Bad Data exists
                        {
                            DataTable _DeductionTable = _DataList.Tables[0];
                            this.Tab1Grid.DataSource = _DeductionTable;
                            this.Tab1Grid.DataBind();
                            Export1.Visible = true;
                            Tab1_Message.Text = "The following data was not imported due to validation error. Please fix them and re-import.";
                        }
                        else
                        {
                            this.Tab1Grid.DataSource = null;
                            this.Tab1Grid.DataBind();
                            Export1.Visible = false;
                            Tab1_Message.Text = "All data has been successfully imported into the system";
                        }
                    }
                }
                else
                {
                    Tab1_Message.CssClass = "errorMessage";
                    Tab1_Message.Text = "Please select the excel(.xlsx) file to import.You should save the file as 'Excel Workbook' for the import process to work.";
                }
            }
            catch (Exception exception)
            {
                this.Tab1_Message.Visible = true;
                this.Tab1_Message.Text = ErrorLogging.LogError(exception, "Unknown Exception Occured. Please check the data in the import file.");
                this.Tab1_Message.CssClass = "errorMessage";
            }
        }
            

     

        protected void Tab1Grid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            Tab1Grid.CurrentPageIndex = e.NewPageIndex;
            LoadErrorDataList();
        }
        protected void Tab2Grid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            Tab2Grid.CurrentPageIndex = e.NewPageIndex;
            LoadDailyFNTransactionsList();
        }
        protected void Tab2Grid_EditCommand(object source, DataGridCommandEventArgs e)
        {

            Tab2_keyField.Text = Tab2Grid.DataKeys[e.Item.ItemIndex].ToString();
            this.EditArea.Visible = true;
            this.Tab2_Pane.Visible = true;
            if (EmptyString(e.Item.Cells[0].Text) != "")
            {
                try
                {
                    Tab2_PayComponentTypeList.SelectedValue = Tab2_PayComponentTypeList.Items.FindByValue(e.Item.Cells[0].Text).Value;
                    RetrievePayComponentListByCompTypeID(Tab2_PayComponentList, Int32.Parse(Tab2_PayComponentTypeList.SelectedValue), (int)Constants.PayFrequencyType.Adhoc);
                }
                catch (Exception exception)
                {
                    ErrorLogging.LogError(exception, "");
                }
            }
            if (EmptyString(e.Item.Cells[1].Text) != "")
            {
                try
                {
                    Tab2_PayComponentList.SelectedValue = Tab2_PayComponentList.Items.FindByValue(e.Item.Cells[1].Text).Value;
                }
                catch (Exception exception)
                {
                    ErrorLogging.LogError(exception, "");
                }
            }
            if (EmptyString(e.Item.Cells[2].Text) != "")
            {
                try
                {
                    Tab2_EmployeeList.SelectedValue = Tab2_EmployeeList.Items.FindByValue(e.Item.Cells[2].Text).Value;
                }
                catch (Exception exception)
                {
                    ErrorLogging.LogError(exception, "");
                }
            }

            Tab2_Amount.Text = EmptyString(e.Item.Cells[6].Text);
            TabSettings();
            Tab1_Pane.Visible = true;

        }
        protected void Tab2Grid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            Tab2_keyField.Text = Tab2Grid.DataKeys[e.Item.ItemIndex].ToString();
            int PayComponentID = Int32.Parse(e.Item.Cells[1].Text);
            int Empid = Int32.Parse(e.Item.Cells[2].Text);
            DeleteEmployeeDeductionComponent(Empid,PayComponentID);

        }


    }
}

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
using System.Net.Mail;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using PresentationManager.Web.UI.MasterPages;

namespace SchoolNet
{
    public partial class ManageRequests : SchoolNetBase
    {
        public int EmpId;

        protected void Page_Load(object sender, EventArgs e)
        {
            EmpId = Int32.Parse(Page.User.Identity.Name.ToString());

           if (!Page.IsPostBack)
           {
                LoadRequestTypeLookup(Tab1_RequestType,EmpId);
                LoadRequestImplTypeLookup(Tab1_RequestImplType, EmpId);
                LoadRequestStatusTypeLookup(Tab1_RequestStatusType);
                LoadNewHiresList(Tab1_NewHiresList, EmpId, (int)Constants.EmpStatusType.PreEmployment);
           }
           if ((Tab1_RequestType.SelectedItem.ToString() == StringEnum.stringValueOf(Constants.RequestType.Onboarding)) || (Tab1_RequestType.SelectedItem.ToString() == StringEnum.stringValueOf(Constants.RequestType.Personal))) // Onboarding Request/Personal Action Request
            {
                    EmployeeSelection.Visible = true;
            }
          
           else 
            {
                EmployeeSelection.Visible = false;
            }
            LoadEmployeeRequests();
            
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

            Grid.PageIndexChanged += new DataGridPageChangedEventHandler(this.Grid_PageIndexChanged);
            Tab1_RequestType.SelectedIndexChanged += new EventHandler(Tab1_RequestType_SelectedIndexChanged);
            Send_Request.Click += new EventHandler(Send_Request_Click);
            Cancel.Click += new EventHandler(Cancel_Click);

        }
        #endregion
        protected void Tab1_RequestType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Tab1_RequestType.SelectedItem.ToString() == StringEnum.stringValueOf(Constants.RequestType.Onboarding)) // Onboarding Request
            { 
                LoadNewHiresList(Tab1_NewHiresList, EmpId, (int)Constants.EmpStatusType.PreEmployment); 
            }
            else if (Tab1_RequestType.SelectedItem.ToString() == StringEnum.stringValueOf(Constants.RequestType.Personal)) // Personal Action Request
            {
               LoadNewHiresList(Tab1_NewHiresList, EmpId, (int)Constants.EmpStatusType.Payroll);
            } 

        }
        #region LoadEmployeeRequests();
        private void LoadEmployeeRequests()
        {
            DataSet _DataList = null;
           _DataList = DatabaseManager.Data.DBAccessManager.RetrieveEmployeeRequests(EmpId);

            if (_DataList.Tables[0].Rows.Count > 0)
            {
                emptyRow.Visible = false;
                this.Grid.DataSource = _DataList;
                this.Grid.DataBind();

            }
            else
            {
                this.Grid.DataSource = null;
                this.Grid.DataBind();
            }
            

        }
        #endregion

        #region Send_Request_Click
        protected void Send_Request_Click(object sender, EventArgs e)
        {

            try
            {
                if (Page.IsValid == true)  // Change requestStatusType to be dynamic, currently 1=submitted.
                {
                    
                    String RequestImplTypeID = GetSelectedItems(Tab1_RequestImplType);
                    DataSet _DataList = null;
                    _DataList = DatabaseManager.Data.DBAccessManager.AddUpdateEmployeeRequest(Convert.ToInt32(NumericCheck_EmptyString(Tab1_keyField.Text)), EmpId, Int32.Parse(Tab1_RequestType.SelectedValue), RequestImplTypeID, Int32.Parse(Tab1_RequestStatusType.SelectedValue), Int32.Parse(Tab1_NewHiresList.SelectedValue), Tab1_Note.Text);
                    this.Hmessage.Visible = true;
                    Hmessage.CssClass = "errorMessage";
                    if (_DataList.Tables[0].Rows.Count > 0)
                    {
                        String Result, HRAdminName, HRAdminEmail, LineManagerName, LineManagerEmail, DeptHeadName, DeptHeadEmail, EmpName, EmpEmail, ITHeadName, ITHeadEmail, FinanceHeadName, FinanceHeadEmail;
                        String StatusName,NewHireName, NewHireDate, NewHireDivision, NewHireLocation, NewHireDept,RequestTypeName;

                        DataRow _DataRow = _DataList.Tables[0].Rows[0];
                        Result = _DataRow["Result"].ToString();

                        if (Result == "")
                        {

                            HRAdminName = _DataRow["HRAdminName"].ToString();
                            HRAdminEmail = _DataRow["HRAdminEmail"].ToString();
                            LineManagerName = _DataRow["LineManagerName"].ToString();
                            LineManagerEmail = _DataRow["LineManagerEmail"].ToString();
                            DeptHeadName = _DataRow["DeptHeadName"].ToString();
                            DeptHeadEmail = _DataRow["DeptHeadEmail"].ToString();
                            EmpName = _DataRow["EmpName"].ToString();
                            EmpEmail = _DataRow["EmpEmail"].ToString();
                            ITHeadName = _DataRow["ITHeadName"].ToString();
                            ITHeadEmail = _DataRow["ITHeadEmail"].ToString();
                            FinanceHeadName = _DataRow["FinanceHeadName"].ToString();
                            FinanceHeadEmail = _DataRow["FinanceHeadEmail"].ToString();
                            NewHireName = _DataRow["NewHireName"].ToString();
                            NewHireDate = _DataRow["NewHireHireDate"].ToString();
                            NewHireDivision = _DataRow["NewHireDivision"].ToString();
                            NewHireDept = _DataRow["NewHireDeptName"].ToString();
                            NewHireLocation = _DataRow["NewHireLocation"].ToString();
                            RequestTypeName = _DataRow["RequestTypeName"].ToString();
                            StatusName = _DataRow["StatusName"].ToString();
                            EmailNotification_Requests(HRAdminName, HRAdminEmail, LineManagerName, LineManagerEmail, FinanceHeadName, FinanceHeadEmail, DeptHeadName, DeptHeadEmail, ITHeadName, ITHeadEmail, EmpName, EmpEmail, RequestTypeName, NewHireName, NewHireDate, NewHireDivision, NewHireDept, NewHireLocation, Tab1_Note.Text, StatusName);
                            // For Resignation request approval, email has to be sent to HR with explanation. Make email routine come with custom body content.
                      //      if ((Tab1_RequestType.SelectedItem.ToString() == "Resignation Request") && (Tab1_RequestStatusType.SelectedItem.ToString() == "Approved"))
                      //      {
                      //          EmailNotification_Requests(HRAdminName, HRAdminEmail, LineManagerName, LineManagerEmail, FinanceHeadName, FinanceHeadEmail, DeptHeadName, DeptHeadEmail, ITHeadName, ITHeadEmail, EmpName, EmpEmail, RequestTypeName, NewHireName, NewHireDate, NewHireDivision, NewHireDept, NewHireLocation, Tab1_Note.Text);

                       //     }
                            ResetFields();

                        }
                        else
                        {
                            this.Hmessage.Text = Result;
                            this.Hmessage.CssClass = "errorMessage";

                        }
                    }
                }
              }
            catch (Exception exception)
            {
                this.Hmessage.Visible = true;
                this.Hmessage.Text = ErrorLogging.LogError(exception, "Unknown Exception Occured.Please contact Support.");
                this.Hmessage.CssClass = "errorMessage";
            }
            LoadEmployeeRequests();// Refresh the grid
        }
        #endregion

        #region Cancel_Click
        protected void Cancel_Click(object sender, EventArgs e)
        {
            ResetFields();
        }
        #endregion
        private void ResetFields()
        {
            Tab1_Note.Text = "";
            Tab1_RequestImplType.SelectedIndex = -1;
            Tab1_RequestType.SelectedIndex = -1;
            Tab1_NewHiresList.SelectedIndex = -1;
            this.Send_Request.Enabled = true;
            this.Cancel.Enabled = true;
            this.Tab1_RequestType.Enabled = true;
            this.Tab1_RequestImplType.Enabled = true;
            this.Tab1_NewHiresList.Enabled = true;
            this.TemplateDownloadLink.Visible = false;
            TemplateDownloadLink.Text = "";
            TemplateDownloadLink.NavigateUrl = "";
            Hmessage.Visible = false;
            emptyRow.Visible = false;
            Tab1_keyField.Text = "";
        }
        private void EmailNotification_Requests(String HRAdminName, String HRAdminEmail, String LineManagerName,String LineManagerEmail,String FinanceHeadName, String FinanceHeadEmail,String DeptHeadName, String DeptHeadEmail, String ITHeadName, String ITHeadEmail,String EmpName, String EmpEmail, String RequestTypeName, String NewHireName, String NewHireDate, String NewHireDivision, String NewHireDept, String NewHireLocation, String Note, String StatusName)
        {

            string HRSystemLink = ConfigurationManager.AppSettings["HRSystemURL"].ToString();
            string FromAddressDisplayName = ConfigurationManager.AppSettings["FromEmailDisplayName"].ToString();

            string subject = "Ark HRMS Alerting Service: ";
            string bodycontent ="";
          

             // Set the subject
             if (NewHireName != "")
             {
                 subject = subject+" "+RequestTypeName + " - " + NewHireName + '(' + NewHireDivision + "->" + NewHireLocation + "->" + NewHireDept + ')';
             }
             else
             {
                 subject = subject + " " + RequestTypeName;
             }
              Note = Note.Replace("\r\n", "<br>"); // needed to translate the page break.

              bodycontent = "<html><body leftmargin=10 style=\"font-family: Arial;font-size:11\">" +
                                 "<P><br><br> You have received an action alert regarding the request given below." +
                                 "<br><br> Please note that you have received this email alert because you are listed as one of the action owners or approvers for this request. To view and act on the request, please go to <a href id=a1 runat=server href=" + HRSystemLink + ">" + FromAddressDisplayName + "</a>" +
                                 "<br><br><u><b>Request Details</b></u>" +
                                 "<br><br><b>Request Type:</b>" + subject +
                                 "<br><b>Request Status:</b> " + StatusName +
                                 "<br><b>Request Details:</b><br>" + Note +
                                 "<br><br>In case you have received this in error, please contact your HR Administrator." +
                                 "<br><br><br><font-size:14>THIS IS AN AUTOMATED,UNMONITORED EMAIL.PLEASE DO NOT REPLY OR FORWARD TO THIS EMAIL ADDRESS." +
                                 "</P></body></HTML>";           

            try
            {
                string fromEmail = ConfigurationManager.AppSettings["FromEmail"].ToString();
                MailMessage message = new MailMessage();
                message.IsBodyHtml = true;
                message.Subject = subject;
                message.From = new MailAddress(fromEmail, FromAddressDisplayName);
               
                if (LineManagerEmail.Trim() != "")
                {
                    message.To.Add(LineManagerEmail.Trim());
                }
                if (DeptHeadEmail.Trim() != "")
                {
                    message.To.Add(DeptHeadEmail.Trim());
                }
                if (HRAdminEmail.Trim() != "")
                {
                    message.To.Add(HRAdminEmail.Trim());
                }
                if (FinanceHeadEmail.Trim() != "")
                {
                    message.To.Add(FinanceHeadEmail.Trim());
                }

                if (ITHeadEmail.Trim() != "")
                {
                    message.To.Add(ITHeadEmail.Trim());
                }
               

                message.Body = bodycontent;
                // Add a carbon copy recipient.
               
                if (EmpEmail.Trim() != "")
                {
                    MailAddress copy = new MailAddress(EmpEmail);
                    message.CC.Add(copy);
                } 
               // SmtpMail.SmtpServer = "relay-hosting.secureserver.net";
                SmtpClient smtp = new SmtpClient();
                smtp.Send(message);

            }
            catch (Exception exception)
            {
                this.Hmessage.Visible = true;
                this.Hmessage.Text = ErrorLogging.LogError(exception,"There was an error in notifying your request.");
                this.Hmessage.CssClass = "errorMessage";

            }

        }

        private void DeleteEmployeeRequest(Int32 RequestID, Int32 EmpId)
        {
            try
            {
                String result = DatabaseManager.Data.DBAccessManager.DeleteEmployeeRequest(RequestID, EmpId);
                this.Hmessage.Visible = true;
                if (result != "")
                {
                    this.Hmessage.Text = result;
                    this.Hmessage.CssClass = "errorMessage";

                }
            }
            catch (Exception exception)
            {
                this.Hmessage.Text = ErrorLogging.LogError(exception, "Unknown Exception Occured.Please contact Support.");
                this.Hmessage.CssClass = "errorMessage";

            }
            Grid.CurrentPageIndex = 0;
            LoadEmployeeRequests();

        }
        private void GenerateSalaryCertificate()
        {
            DataSet _DataList = null;
            String FileName = "";
            _DataList = DatabaseManager.Data.DBAccessManager.RetrieveSalaryCertificateData(Int32.Parse(this.Tab1_keyField.Text), Int32.Parse(Page.User.Identity.Name.ToString()));
            if (_DataList.Tables.Count > 1)
            {
                if (_DataList.Tables[0].Rows.Count > 0) // SalaryCertificate FileName.
                {
                     FileName = _DataList.Tables[0].Rows[0]["FileName"].ToString();

                }
                if (_DataList.Tables[1].Rows.Count > 0) // Certificate Data
                {
                    DataTable _dataTable = _DataList.Tables[1];
                    CreateWordFile(_dataTable, FileName);
                }
            }
            else if (_DataList.Tables.Count == 1) // In case Salary Certificate already exists, just enable the link.
            {
                FileName = _DataList.Tables[0].Rows[0]["FileName"].ToString();
                TemplateDownloadLink.Visible = true;
                TemplateDownloadLink.Text = "Click here to download Salary Certificate";
                TemplateDownloadLink.CssClass = "mainheadtxt";
                TemplateDownloadLink.NavigateUrl = "~/Requests/" + FileName;
            }
         }

        public void CreateWordFile(DataTable dt, String FileName)
        {

            try
            {
                string path = context.Current.Server.MapPath("~/Requests/");

                // check if directory exists
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                path = path + FileName;                
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
                TemplateDownloadLink.Visible = true;
                TemplateDownloadLink.Text = "Click here to download Salary Certificate";
                TemplateDownloadLink.CssClass = "mainheadtxt";
                TemplateDownloadLink.NavigateUrl = "~/Requests/" + FileName;


            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }

        }

        public void ExportToWord(DataTable dt)
        {
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();

            Response.Buffer = true;
            Response.ContentType = "application/vnd.ms-excel";
            Response.Write("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0 Transitional//EN\">");
            Response.AddHeader("content-disposition", "attachment;filename=EmployeeSalaryCertificate.xls");
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


        protected void Grid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            Grid.CurrentPageIndex = e.NewPageIndex;
            LoadEmployeeRequests();
        }
        protected void Grid_ItemCommand(object sender, DataGridCommandEventArgs e)
        {
         
        }
        protected void Grid_EditCommand(object source, DataGridCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edit")
                {
                    this.Hmessage.Text = "";
                    this.Hmessage.Visible = false;
                    this.Tab1_keyField.Text = Grid.DataKeys[e.Item.ItemIndex].ToString();
                    Grid.EditItemIndex = -1;
                    if (EmptyString(e.Item.Cells[0].Text) != "")
                    {

                        Tab1_RequestType.SelectedValue = Tab1_RequestType.Items.FindByText(e.Item.Cells[0].Text).Value;
                    }
                   

                    if ((EmptyString(e.Item.Cells[0].Text) == StringEnum.stringValueOf(Constants.RequestType.Onboarding)) || (EmptyString(e.Item.Cells[0].Text) == StringEnum.stringValueOf(Constants.RequestType.Personal)))
                    {
                        EmployeeSelection.Visible = true;

                        if (EmptyString(e.Item.Cells[0].Text) == StringEnum.stringValueOf(Constants.RequestType.Onboarding)) // Onboarding Request
                        {
                            LoadNewHiresList(Tab1_NewHiresList, EmpId, (int)Constants.EmpStatusType.PreEmployment);
                        }
                        else if (EmptyString(e.Item.Cells[0].Text) == StringEnum.stringValueOf(Constants.RequestType.Personal)) // Personal Action Request
                        {
                            LoadNewHiresList(Tab1_NewHiresList, EmpId, (int)Constants.EmpStatusType.Payroll);
                        } 
                                                
                        Tab1_NewHiresList.SelectedValue = Tab1_NewHiresList.Items.FindByValue(e.Item.Cells[5].Text).Value;

                    }
                    if (EmptyString(e.Item.Cells[7].Text) != "")
                    {
                        string Implementors = EmptyString(e.Item.Cells[7].Text);
                        string[] ImplTypes = Implementors.Split(';');
                        foreach (string word in ImplTypes)
                        {
                            Tab1_RequestImplType.Items.FindByText(word).Selected = true;
                        }

                    }
                    Tab1_Note.Text = EmptyString(e.Item.Cells[4].Text);
                    if (EmptyString(e.Item.Cells[6].Text) != "")
                    {
                        Tab1_RequestStatusType.Visible = true;
                        Tab1_RequestStatusType.SelectedValue = Tab1_RequestStatusType.Items.FindByText(e.Item.Cells[6].Text).Value;
                    }

                    // Generate Salary Certificate
                    if ((EmptyString(e.Item.Cells[0].Text) == StringEnum.stringValueOf(Constants.RequestType.SalCertificate)))
                    {
                        GenerateSalaryCertificate();
                    }
                    if ((EmptyString(e.Item.Cells[6].Text) != StringEnum.stringValueOf(Constants.RequestStatusType.Submitted)) && (EmptyString(e.Item.Cells[6].Text) != StringEnum.stringValueOf(Constants.RequestStatusType.PendingApproval)))
                    {
                        this.Hmessage.Visible = true;
                        this.Hmessage.CssClass = "errorMessage";
                        if (Page.User.IsInRole("HR Administrator") && (EmptyString(e.Item.Cells[6].Text) != StringEnum.stringValueOf(Constants.RequestStatusType.Closed)))
                        {
                            this.Hmessage.Text = "This request can be only closed at this stage.";
                            this.Send_Request.Enabled = true;
                            this.Cancel.Enabled = true;
                            this.Tab1_RequestType.Enabled = false;
                            this.Tab1_RequestImplType.Enabled = false;
                            this.Tab1_NewHiresList.Enabled = false;

                        }
                        else
                        {
                            this.Hmessage.Text = "This request can be only viewed at this stage.";
                            this.Send_Request.Enabled = false;
                            this.Cancel.Enabled = true;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.Hmessage.Visible = true;
                this.Hmessage.Text = ErrorLogging.LogError(exception, "Unknown Exception Occured.Please contact Support.");
                this.Hmessage.CssClass = "errorMessage";
            }

        }

        protected void Grid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            int requestID = (int)Grid.DataKeys[(int)e.Item.ItemIndex];
            Grid.EditItemIndex = -1;
            if (EmptyString(e.Item.Cells[6].Text) == StringEnum.stringValueOf(Constants.RequestStatusType.Submitted))
            {
                DeleteEmployeeRequest(requestID, EmpId);
            }
            else
            {
                this.Hmessage.Visible = true;
                this.Hmessage.Text = "This request can not deleted at this stage.";
                this.Hmessage.CssClass = "errorMessage";

            }
        }

    }
}
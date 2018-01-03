using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Globalization;
using System.Web.Security;
using System.Web.UI;
using System.Net.Mail;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using PresentationManager.Web.UI.MasterPages;
using DatabaseManager.Data;

namespace SchoolNet
{
    public partial class UserAccounts : SchoolNetBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                LoadRoleTypeLookup(Tab1_RoleTypeList);
               // LoadDivisionLookup2(Tab1_DivisionListList);
                LoadDivisionLookupByEmpId(Tab1_DivisionListList, Int32.Parse(Page.User.Identity.Name.ToString()));
                LoadEntityLocationLookupByEmpId_DivisionID(Tab1_DivisionLocationList, Int32.Parse(Page.User.Identity.Name.ToString()), Int32.Parse(Tab1_DivisionListList.SelectedValue));
               // LoadEntityLocationLookup(Tab1_DivisionLocationList, Int32.Parse(Tab1_DivisionListList.SelectedValue));

                LoadRoleTypeLookup(Tab2_RoleTypeList);
               // LoadDivisionLookup2(Tab2_DivisionListList);
                LoadDivisionLookupByEmpId(Tab2_DivisionListList, Int32.Parse(Page.User.Identity.Name.ToString()));

               // LoadEntityLocationLookup(Tab2_DivisionLocationList, Int32.Parse(Tab2_DivisionListList.SelectedValue));
                LoadEntityLocationLookupByEmpId_DivisionID(Tab2_DivisionLocationList, Int32.Parse(Page.User.Identity.Name.ToString()), Int32.Parse(Tab2_DivisionListList.SelectedValue));

            }
            else
            {
               if ((Int32.Parse(Tab1_RoleTypeList.SelectedValue) == 1) && (AddAccount.Visible == true))

                {
                    Tab1_DivisionListList.Visible = true;
                    Tab1_DivisionLocationList.Visible = true;
                    if (Int32.Parse(Tab1_DivisionLocationList.SelectedValue) == -1)
                    {
                        LoadEntityLocationLookup(Tab1_DivisionLocationList, Int32.Parse(Tab1_DivisionListList.SelectedValue));
                    }

                }
                else
                {
                    Tab1_DivisionListList.Visible = false;
                    Tab1_DivisionLocationList.Visible = false;
                }

                if ((Int32.Parse(Tab2_RoleTypeList.SelectedValue) == 1) && (EditAccount.Visible == true))
                {
                    Tab2_DivisionListList.Visible = true;
                    Tab2_DivisionLocationList.Visible = true;
                    if (Int32.Parse(Tab2_DivisionLocationList.SelectedValue) == -1)
                    {
                        LoadEntityLocationLookup(Tab2_DivisionLocationList, Int32.Parse(Tab2_DivisionListList.SelectedValue));
                    }                  

                }
                else
                {
                    Tab2_DivisionListList.Visible = false;
                    Tab2_DivisionLocationList.Visible = false;
                }




            }            

            LoadPortalUserAccounts();
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
            Grid.SortCommand += new DataGridSortCommandEventHandler(Grid_SortCommand);
            PortalAcct_Save.Click += new EventHandler(PortalAcct_Save_Click);
            PortalEdit_Save.Click += new EventHandler(PortalEdit_Save_Click);
            Reset.Click += new EventHandler(Reset_Click);
            Edit_Reset.Click +=new EventHandler(Edit_Reset_Click);
        }
        #endregion

        protected void PortalAcct_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid == true)
                {
                    String AddedBy = Page.User.IsInRole("HR Administrator").ToString();
                    Int32 AccountStatus = 1;
                    if (Tab1_RadioButton1.Checked = true) { AccountStatus = 1; } else { AccountStatus = 0; }

                    string result = DBAccessManager.AccountSignUp(Tab1_EmployeeID.Text.ToString(), Tab1_UserName.Text.ToString().Trim(), EncodePasswordToBase64(Tab1_password.Text.ToString().Trim()), Int32.Parse(Tab1_RoleTypeList.SelectedValue), Int32.Parse(Tab1_DivisionListList.SelectedValue), Int32.Parse(Tab1_DivisionLocationList.SelectedValue), AccountStatus, AddedBy);

                    if (result == "")
                    {
                        ResetFields();
                        String Emp_FullName = "";
                        String UserName = Tab1_UserName.Text.ToString();
                        String Password = DecodeFrom64(Tab1_password.Text.ToString());
                        if (CheckEmail(UserName))  // Notify via Email if Email was used as a user Name
                        {
                            NotifyEmployee_PortaLoginViaEmail(Emp_FullName,UserName,Password);

                        }
                        this.Hmessage.Visible = true;
                        this.Hmessage.Text = "Account has been created successfully";
                        this.Hmessage.CssClass = "errorMessage";
                    }
                    else
                    {
                        this.Hmessage.Visible = true;
                        this.Hmessage.Text = result;
                        this.Hmessage.CssClass = "errorMessage";
                    }
                }
            }
            catch (Exception exception)
            {
                this.Hmessage.Visible = true;
                this.Hmessage.Text = ErrorLogging.LogError(exception, "Unknown Exception Occured.Please contact Support.");
                this.Hmessage.CssClass = "errorMessage";
            }
            ViewState["myDataSet"] = null;
            LoadPortalUserAccounts();
        }

        protected void PortalEdit_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid == true)
                {
                    String AddedBy = Page.User.Identity.Name.ToString();// Page.User.IsInRole("HR Administrator").ToString();
                    Int32 AccountStatus = 1;
                    if (Tab2_RadioButton1.Checked == true) { AccountStatus = 1; } else { AccountStatus = 0; }
                    String Password = "Edit"; // do not update password while editing-handled in SP.

                    string result = DBAccessManager.AccountSignUp(Tab2_EmployeeID.Text.ToString(), Tab2_UserName.Text.ToString().Trim(), Password, Int32.Parse(Tab2_RoleTypeList.SelectedValue),Int32.Parse(Tab2_DivisionListList.SelectedValue),Int32.Parse(Tab2_DivisionLocationList.SelectedValue), AccountStatus, AddedBy);

                    if (result == "")
                    {
                        ResetFields();
                        this.EditAccount.Visible = false;
                        this.AddAccount.Visible = true;
                    }
                    else
                    {
                        this.Editmessage.Visible = true;
                        this.Editmessage.Text = result;
                        this.Editmessage.CssClass = "errorMessage";
                    }
                }
            }
            catch (Exception exception)
            {
                this.Hmessage.Visible = true;
                this.Hmessage.Text = ErrorLogging.LogError(exception, "Unknown Exception Occured.Please contact Support.");
                this.Hmessage.CssClass = "errorMessage";
            }
            ViewState["myDataSet"] = null;
            LoadPortalUserAccounts();
            
        }


        #region LoadPortalUserAccounts()
        private void LoadPortalUserAccounts()
        {
            DataSet _DataList = null;
            if (ViewState["myDataSet"] == null)   // No such value in view state, take appropriate action.
            {
                Int32 FetchFlag = 2; // Retruns all users for portal management.
                _DataList = DatabaseManager.Data.DBAccessManager.RetrieveNewlyAddedUserAccounts(FetchFlag, Int32.Parse(Page.User.Identity.Name.ToString()));

                if (_DataList.Tables[0].Rows.Count > 0)
                {
                    this.Grid.DataSource = _DataList;
                    this.Grid.DataBind();
                    SetViewState(_DataList);
                }
                else
                {
                    this.Grid.DataSource = null;
                    this.Grid.DataBind();
                }
            }
            else  // If it is avaiable in the viewstate bind it from there.
            {
                _DataList = GetViewState();
                 this.Grid.DataSource = _DataList;
                 this.Grid.DataBind();

            }
        }
        #endregion

        private void NotifyEmployee_PortaLoginViaEmail(string uName, string Employee_EmailAddress, string Password)
        {
            string HRSystemLink = ConfigurationManager.AppSettings["HRSystemURL"].ToString();
            string FromAddressDisplayName = ConfigurationManager.AppSettings["FromEmailDisplayName"].ToString();

            string subject = "Ark HRMS Alerting Service:AON HRM System Login Credentials";

            string bodycontent = "<html><body leftmargin=10 style=\"font-family: Arial;font-size:11\">" +
                                "<P><br> Hello " + uName + "," +
                               "<br><br>You have received this email because HR Administrator has created login credentials for you to access AON HR System." +
                               "<br> You can click  <a href id=a1 runat=server href=" + HRSystemLink + ">" + FromAddressDisplayName + "</a> link in order to login." +
                               "<br>If you have not made this request, Please contact your HR administrator" +
                               "<br><br>Your UserName/Email Address : " + Employee_EmailAddress +
                               "<br><br>Password : " + Password +
                               "<br>You may want to change your password once logged in and note down your login credentials for future access." +
                               "<br><br><br><font-size:14>THIS IS AN AUTOMATED,UNMONITORED EMAIL.PLEASE DO NOT REPLY OR FORWARD TO THIS EMAIL ADDRESS." +
                               "</P></body></HTML>";            

            try
            {
                string fromEmail = ConfigurationManager.AppSettings["FromEmail"].ToString();
                MailMessage message = new MailMessage();
                message.IsBodyHtml = true;
                message.From = new MailAddress(fromEmail, FromAddressDisplayName);

                if (Employee_EmailAddress.Trim() != "")
                {
                    message.To.Add(Employee_EmailAddress.Trim());
                }

                message.Subject = subject;
                message.Body = bodycontent;

                SmtpClient smtp = new SmtpClient();
                smtp.Send(message);
                this.Hmessage.Visible = true;
                this.Hmessage.Text = "Employee login credentials have been sent to employee's work email account on our system.";
                this.Hmessage.CssClass = "errorMessage";

            }
            catch (Exception exception)
            {
                this.Hmessage.Visible = true;
                this.Hmessage.Text = ErrorLogging.LogError(exception, "There was an error in sending email notification.");
                this.Hmessage.CssClass = "errorMessage";

            }

        }


        private void ResetFields()
        {

            this.Tab1_EmployeeID.Text = "";
            this.Tab1_password.Text = "";
            this.Tab1_ConfirmPassword.Text = "";
            this.Tab1_UserName.Text = "";
            Tab1_RadioButton1.Checked = true;
            Tab1_RadioButton2.Checked = false;
            Tab1_DivisionListList.Visible = false;
            Tab1_DivisionLocationList.Visible = false;
            Tab2_keyField.Text = "";
            Tab1_keyField.Text = "";
          
        }

        protected void Reset_Click(object sender, EventArgs e)
        {
            ResetFields();
            this.Hmessage.Text = "";
            this.Hmessage.Visible = false;
        }
        protected void Edit_Reset_Click(object sender, EventArgs e)
        {
            this.Tab2_EmployeeID.Text = "";
            this.Tab2_UserName.Text = "";
            Tab2_RadioButton1.Checked = true;
            Tab2_RadioButton2.Checked = false;
            this.Editmessage.Text = "";
            this.Editmessage.Visible = false;
            Tab2_DivisionListList.Visible = false;
            Tab2_DivisionLocationList.Visible = false;
        }

        //This is invoked when the grid column is Clicked for Sorting, 
        //Clicking again will Toggle Descending/Ascending through the Sort Expression
        protected void Grid_SortCommand(object sender, DataGridSortCommandEventArgs e)
        {
            DataSet myDataSet = GetViewState();
            DataTable myDataTable = myDataSet.Tables[0];
            GridViewSortExpression = e.SortExpression;

            //Gets the Pageindex of the GridView.
            int iPageIndex = Grid.CurrentPageIndex;
            DataView _dataView = SortDataTable(myDataTable, false);
            Grid.DataSource = _dataView;
            Grid.DataBind();
            Grid.CurrentPageIndex = iPageIndex;
            // Rebind the sorted data into ViewState
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            dt = _dataView.ToTable();
            ds.Merge(dt);
            SetViewState(ds);
        }

        protected void Grid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            DataSet myDataSet = GetViewState();
            DataTable myDataTable = myDataSet.Tables[0];
            DataView _dataView = SortDataTable(myDataTable, true);
            Grid.DataSource = _dataView;
            Grid.CurrentPageIndex = e.NewPageIndex;
            Grid.DataBind();
            // Rebind the sorted data into ViewState
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            dt = _dataView.ToTable();
            ds.Merge(dt);
            SetViewState(ds);

            
            //Grid.CurrentPageIndex = e.NewPageIndex;
            //LoadPortalUserAccounts();
        }
        protected void Grid_EditCommand(object source, DataGridCommandEventArgs e)
        {
            this.EditAccount.Visible = true;
            this.AddAccount.Visible = false;
            this.Tab1_keyField.Text = Grid.DataKeys[e.Item.ItemIndex].ToString();
            Tab2_EmployeeID.Text = EmptyString(e.Item.Cells[0].Text);
            Tab2_UserName.Text = EmptyString(e.Item.Cells[2].Text);
            LoadRoleTypeLookup(Tab2_RoleTypeList);
            if (EmptyString(e.Item.Cells[3].Text) != "")
            {
                Tab2_RoleTypeList.SelectedValue = Tab2_RoleTypeList.Items.FindByText(e.Item.Cells[3].Text).Value;
            }

            if (EmptyString(e.Item.Cells[6].Text) == "Active") { Tab2_RadioButton1.Checked = true; }
            else { Tab2_RadioButton2.Checked = true; }

            if (Int32.Parse(Tab2_RoleTypeList.SelectedValue) == 1)
            {
                Tab2_DivisionListList.Visible = true;
                Tab2_DivisionLocationList.Visible = true;
            }
            else
            {
                Tab2_DivisionListList.Visible = false;
                Tab2_DivisionLocationList.Visible = false;

            }

            Grid.EditItemIndex = -1;
            
        }

        protected void Grid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            int Emp_Id = (int)Grid.DataKeys[(int)e.Item.ItemIndex];
            Grid.EditItemIndex = -1;
            DeleteUserAccount(Emp_Id);
        }
        private void DeleteUserAccount(Int32 Emp_Id)
        {
            try
            {
                String result = DatabaseManager.Data.DBAccessManager.DeleteUserAccount(Emp_Id);

                if (result != "")
                {
                    this.Hmessage.Text = "Error:Could not delete the user account. Please check the data";
                    this.Hmessage.CssClass = "errorMessage";

                }
            }
            catch (Exception exception)
            {
                this.Hmessage.Text = ErrorLogging.LogError(exception, "Unknown Exception Occured.Please contact Support.");
                this.Hmessage.CssClass = "errorMessage";

            }


            Grid.CurrentPageIndex = 0;
            LoadPortalUserAccounts();

        }


    }
}


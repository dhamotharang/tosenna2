using System;
using System.Data;
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
    public partial class ManageEContacts : SchoolNetBase
    {
        public int EmpId;

        protected void Page_Load(object sender, EventArgs e)
        {

            EmpId = Int32.Parse(Page.User.Identity.Name.ToString());
            this.keyField.Text = EmpId.ToString();


            if (!Page.IsPostBack)
            {
                LoadRelationshipType(Tab4_RelationshipDDList);
                ContactPriorityType(Tab4_ContactPrioirtyDDList);
            }
            if (this.keyField.Text.ToString() != "")
            {
                LoadEContactList();
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

            ECGrid.PageIndexChanged += new DataGridPageChangedEventHandler(ECGrid_PageIndexChanged);
            EC_Save.Click += new EventHandler(EC_Save_Click);
            EC_Cancel.Click +=new EventHandler(EC_Cancel_Click);
        }
        #endregion

        #region LoadEContactList
        private void LoadEContactList()
        {
            DataTable _empECDataTable = null;
            try
            {

                DataSet _DataList = null;
                _DataList = DatabaseManager.Data.DBAccessManager.RetrieveEmployeeInfo(Int32.Parse(this.keyField.Text.ToString()));
                if (_DataList.Tables[2].Rows.Count > 0)  // Employee Emergency Contacts Information.
                {
                     _empECDataTable = _DataList.Tables[2];
                    this.ECGrid.DataSource = _empECDataTable;
                    this.ECGrid.DataBind();
                }
                else
                {
                    this.ECGrid.DataSource = null;
                    this.ECGrid.DataBind();
                }
            }
            catch (Exception exception)
            {
                if (ECGrid.CurrentPageIndex >= ECGrid.PageCount)
                {
                    ECGrid.CurrentPageIndex -= 1;
                    this.ECGrid.DataSource = _empECDataTable;
                    this.ECGrid.DataBind();

                }
                else
                {
                    ErrorLogging.LogError(exception, " ");
                }
            }
        }
        #endregion


        protected void EC_Save_Click(object sender, EventArgs e)
        {

            try
            {
                if (Page.IsValid == true)
                {
                    String Result = DatabaseManager.Data.DBAccessManager.Update_Emp_EContactInfo(Int32.Parse(keyField.Text.ToString()), Tab4_Name.Text.ToString(), Int32.Parse(Tab4_RelationshipDDList.SelectedValue), Int32.Parse(Tab4_ContactPrioirtyDDList.SelectedValue), Tab4_HomePhone.Text.ToString(), Tab4_MobilePhone.Text.ToString(), Tab4_WorkPhone.Text.ToString(), Tab4_EmailAddress.Text.ToString());

                    this.ECmessage.Visible = true;
                    this.ECmessage.CssClass = "errorMessage";
                    if (Result == "")
                    {
                        ResetEContactFields();
                    }
                    else
                    {
                        this.ECmessage.Text = Result;
                        this.ECmessage.CssClass = "errorMessage";
                    }
                }
                LoadEContactList(); // Refresh the Grid after Save.

            }
            catch (Exception exception)
            {
                this.ECmessage.Visible = true;
                this.ECmessage.Text = ErrorLogging.LogError(exception, "Unknown Exception Occured.Please contact Support.");
                this.ECmessage.CssClass = "errorMessage";
            }
        }
        protected void EC_Cancel_Click (object sender, EventArgs e)
        {
            ResetEContactFields();
            this.ECmessage.Text="";
           
        }



        private void ResetEContactFields()
        {
            Tab4_Name.Text = "";
            Tab4_RelationshipDDList.SelectedIndex = -1;
            Tab4_ContactPrioirtyDDList.SelectedIndex = -1;
            Tab4_HomePhone.Text = "";
            Tab4_MobilePhone.Text = "";
            Tab4_WorkPhone.Text = "";
            Tab4_EmailAddress.Text = "";
            
            
        }

        private void DeleteEContact(Int32 EContactID)
        {
            try
            {
                String result = DatabaseManager.Data.DBAccessManager.DeleteEmployeeEContact(Int32.Parse(keyField.Text.ToString()), EContactID);

                if (result != "")
                {
                    this.ECmessage.Text = "Error:Could not delete the contact. Please check the data";
                    this.ECmessage.CssClass = "errorMessage";

                }
            }
            catch (Exception exception)
            {
                this.ECmessage.Text = ErrorLogging.LogError(exception, "Unknown Exception Occured.Please contact Support.");
                this.ECmessage.CssClass = "errorMessage";

            }
            ECGrid.CurrentPageIndex = 0;
            LoadEContactList();
            ResetEContactFields();

        }
        protected void ECGrid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            ECGrid.CurrentPageIndex = e.NewPageIndex;
            LoadEContactList();


        }
        protected void ECGrid_EditCommand(object source, DataGridCommandEventArgs e)
        {
            Tab4_Name.Text = EmptyString(e.Item.Cells[0].Text);
            if (EmptyString(e.Item.Cells[1].Text) != "")
            {
                try
                {
                    Tab4_RelationshipDDList.SelectedValue = Tab4_RelationshipDDList.Items.FindByText(e.Item.Cells[1].Text).Value;
                }
                catch(Exception exception)
                {
                    Tab4_RelationshipDDList.SelectedValue = "-1";
                    ErrorLogging.LogError(exception, "");
                }
            }
            if (EmptyString(e.Item.Cells[2].Text) != "")
            {
                try
                {
                    Tab4_ContactPrioirtyDDList.SelectedValue = Tab4_ContactPrioirtyDDList.Items.FindByText(e.Item.Cells[2].Text).Value;
                }
                catch (Exception exception)
                {
                    Tab4_ContactPrioirtyDDList.SelectedValue = "-1";
                    ErrorLogging.LogError(exception, "");
                }
            }
            Tab4_HomePhone.Text = EmptyString(e.Item.Cells[3].Text);
            Tab4_MobilePhone.Text = EmptyString(e.Item.Cells[4].Text);
            Tab4_WorkPhone.Text = EmptyString(e.Item.Cells[5].Text);
            Tab4_EmailAddress.Text = EmptyString(e.Item.Cells[6].Text);
            ECGrid.EditItemIndex = -1;
        }
        protected void ECGrid_CancelCommand(object source, DataGridCommandEventArgs e)
        {

        }
        protected void ECGrid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            int EContactID = (int)ECGrid.DataKeys[(int)e.Item.ItemIndex];
            ECGrid.EditItemIndex = -1;
            DeleteEContact(EContactID);

        }
        protected void ECGrid_UpdateCommand(object source, DataGridCommandEventArgs e)
        {

        }

    }
}
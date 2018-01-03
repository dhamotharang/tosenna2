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
    public partial class TAConfig : SchoolNetBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               // LoadCountryList(Tab1_CountryList);
                LoadDivisionLookupByEmpId(Tab1_businessUnitDDList, Int32.Parse(Page.User.Identity.Name.ToString()));
                LoadEntityLocationLookupByEmpId_DivisionID(Tab1_DivisionLocationList, Int32.Parse(Page.User.Identity.Name.ToString()), Int32.Parse(Tab1_businessUnitDDList.SelectedValue));

            }
            if (Int32.Parse(Tab1_DivisionLocationList.SelectedValue) == -1)
            {
                LoadEntityLocationLookupByEmpId_DivisionID(Tab1_DivisionLocationList, Int32.Parse(Page.User.Identity.Name.ToString()), Int32.Parse(Tab1_businessUnitDDList.SelectedValue));
            }
            LoadTAConfigList();
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
            TAConfig_Save.Click += new EventHandler(TAConfig_Save_Click);
            TAConfig_Reset.Click += new EventHandler(TAConfig_Reset_Click);
            Tab1_businessUnitDDList.SelectedIndexChanged += new EventHandler(Tab1_businessUnitDDList_SelectedIndexChanged);
        
        }
        #endregion
        protected void Tab1_businessUnitDDList_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadEntityLocationLookupByDivisionID(Tab1_DivisionLocationList, Int32.Parse(Tab1_businessUnitDDList.SelectedValue));
        }

        #region LoadTAConfigList
        private void LoadTAConfigList()
        {
            DataSet _DataList = null;
            _DataList = DatabaseManager.Data.DBAccessManager.RetrieveTAConfigList(Int32.Parse(Page.User.Identity.Name.ToString()));

            if (_DataList.Tables[0].Rows.Count > 0)
            {
                this.Grid.DataSource = _DataList;
                this.Grid.DataBind();

            }
            else
            {
                this.Grid.DataSource = null;
                this.Grid.DataBind();
                emptyRow.Visible = true;
                emptyRow.Text = "There are no records found.";
                emptyRow.CssClass = "errorMessage";
            }
        }
        #endregion


        #region TAConfig_Save_Click
        protected void TAConfig_Save_Click(object sender, EventArgs e)
        {
           
            try
            {
                if (Page.IsValid == true)
                {
                   // Int32 PayType, EnableAccrual, DedAccrual, CarryFWD, DedSPeriod, AllowNegative, PartialDay, AllowESS;
                    Boolean EmpEA, EmpDA, SupEA, LunchAllowed, OTAllowed;
                    if ( Tab1_keyField.Text.ToString()== "" ) {Tab1_keyField.Text ="0";}
                    if (Tab1_EmpEditAccess1.Checked) { EmpEA = true; } else { EmpEA = false; }
                    if (Tab1_EmpDelAccess1.Checked) { EmpDA = true; } else { EmpDA = false; }
                    if (Tab1_SupervisorAccess1.Checked) { SupEA = true; } else { SupEA = false; }
                    if (Tab1_LunchAllowed1.Checked) { LunchAllowed = true; } else { LunchAllowed = false; }
                    if (Tab1_OTAllowed1.Checked) { OTAllowed = true; } else { OTAllowed = false; }
                    if (Tab1_MaxOTMinsAllowed.Text.ToString() == "") { Tab1_MaxOTMinsAllowed.Text = "0"; }
                    String Result = DatabaseManager.Data.DBAccessManager.AddUpdateTAConfig(Int32.Parse(Page.User.Identity.Name.ToString()), Int32.Parse(Tab1_businessUnitDDList.SelectedValue), Int32.Parse(Tab1_DivisionLocationList.SelectedValue), EmpEA, EmpDA, SupEA, LunchAllowed, OTAllowed, Int32.Parse(Tab1_MaxOTMinsAllowed.Text));
                    this.LTmessage.Visible = true;
                    LTmessage.CssClass = "errorMessage";
                    if (Result == "")
                    {
                        ResetFields();
                    }
                    else
                    {
                        this.LTmessage.Text = Result;
                    }
                    
                }
                else
                {
                    this.LTmessage.Text = "Error Occured.Please check the input data and try again.";
                    this.LTmessage.CssClass = "errorMessage";
                }
                LoadTAConfigList();
            }
            catch (Exception exception)
            {
                this.LTmessage.Visible = true;
                this.LTmessage.Text = ErrorLogging.LogError(exception,"Unknown Exception Occured.Please contact support.");
                this.LTmessage.CssClass = "errorMessage";
            }
        }
        #endregion
        #region TAConfig_Reset_Click
        protected void TAConfig_Reset_Click(object sender, EventArgs e)
        {
            ResetFields();
        }
        #endregion
        private void ResetFields()
        {
            Tab1_keyField.Text = "0";
            Tab1_businessUnitDDList.SelectedIndex = -1;
            Tab1_DivisionLocationList.SelectedIndex = -1;
            Tab1_EmpEditAccess1.Checked = true;
            Tab1_EmpEditAccess2.Checked = false;
            Tab1_EmpDelAccess1.Checked = true;
            Tab1_EmpDelAccess2.Checked = false;
            Tab1_SupervisorAccess1.Checked = true;
            Tab1_SupervisorAccess2.Checked = false;
            Tab1_LunchAllowed1.Checked = true;
            Tab1_LunchAllowed2.Checked = false;
            Tab1_OTAllowed1.Checked = true;
            Tab1_OTAllowed2.Checked = false;
            Tab1_MaxOTMinsAllowed.Text = "";
            LTmessage.Visible = false;
            LTmessage.Text = "";
            emptyRow.Text = "";
            emptyRow.Visible = false;
        }
        private void DeleteLeaveType(Int32 LeaveTypeID)
        {
            try
            {
                String result = DatabaseManager.Data.DBAccessManager.DeleteLeaveType(LeaveTypeID);

                this.LTmessage.Visible = true;
                LTmessage.CssClass = "errorMessage";
                if (result == "") { this.LTmessage.Text = "Successfully deleted."; }
                else { this.LTmessage.Text = result; }
            }
            catch (Exception exception)
            {
                this.LTmessage.Visible = true;
                this.LTmessage.Text = ErrorLogging.LogError(exception,"Unknown Exception Occured.Please contact support.");
                this.LTmessage.CssClass = "errorMessage";

            }
            Grid.CurrentPageIndex = 0;
            LoadTAConfigList();

        }

        protected void Grid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            Grid.CurrentPageIndex = e.NewPageIndex;
            LoadTAConfigList();            
        }
       protected void Grid_EditCommand(object source, DataGridCommandEventArgs e)
        {
            LoadDivisionLookupByEmpId(Tab1_businessUnitDDList, Int32.Parse(Page.User.Identity.Name.ToString()));

            this.Tab1_keyField.Text = Grid.DataKeys[e.Item.ItemIndex].ToString();
          /*  if (EmptyString(Tab1_keyField.Text) != "")
            {
                Tab1_LeaveTypeDDList.SelectedValue = Tab1_LeaveTypeDDList.Items.FindByValue(Tab1_keyField.Text).Value;
            }   */

//            Grid.EditItemIndex = -1;
                 if (EmptyString(e.Item.Cells[1].Text) != "")
                 {
                     Tab1_businessUnitDDList.SelectedValue = Tab1_businessUnitDDList.Items.FindByValue(e.Item.Cells[1].Text).Value;
                 }

                 if (EmptyString(e.Item.Cells[3].Text) != "")
                 {
                     LoadEntityLocationLookupByEmpId_DivisionID(Tab1_DivisionLocationList, Int32.Parse(Page.User.Identity.Name.ToString()), Int32.Parse(Tab1_businessUnitDDList.SelectedValue));
                     Tab1_DivisionLocationList.SelectedValue = Tab1_DivisionLocationList.Items.FindByValue(e.Item.Cells[3].Text).Value;
                 }

                 //Tab1_Name.Text = EmptyString(e.Item.Cells[4].Text);
                 if (EmptyString(e.Item.Cells[4].Text) == "Yes") { Tab1_EmpEditAccess1.Checked = true; } else { Tab1_EmpEditAccess1.Checked = false; }
                 if (EmptyString(e.Item.Cells[4].Text) == "No") { Tab1_EmpEditAccess2.Checked = true; } else { Tab1_EmpEditAccess2.Checked = false; }
                 if (EmptyString(e.Item.Cells[5].Text) == "Yes") { Tab1_EmpDelAccess1.Checked = true; } else { Tab1_EmpDelAccess1.Checked = false; }
                 if (EmptyString(e.Item.Cells[5].Text) == "No") { Tab1_EmpDelAccess2.Checked = true; } else { Tab1_EmpDelAccess2.Checked = false; }
                 if (EmptyString(e.Item.Cells[6].Text) == "Yes") { Tab1_SupervisorAccess1.Checked = true; } else { Tab1_SupervisorAccess1.Checked = false; }
                 if (EmptyString(e.Item.Cells[6].Text) == "No") { Tab1_SupervisorAccess2.Checked = true; } else { Tab1_SupervisorAccess2.Checked = false; }
                 if (EmptyString(e.Item.Cells[7].Text) == "Yes") { Tab1_LunchAllowed1.Checked = true; } else { Tab1_LunchAllowed1.Checked = false; }
                 if (EmptyString(e.Item.Cells[7].Text) == "No") { Tab1_LunchAllowed2.Checked = true; } else { Tab1_LunchAllowed2.Checked = false; }
                 if (EmptyString(e.Item.Cells[8].Text) == "Yes") { Tab1_OTAllowed1.Checked = true; } else { Tab1_OTAllowed1.Checked = false; }
                 if (EmptyString(e.Item.Cells[8].Text) == "No") { Tab1_OTAllowed2.Checked = true; } else { Tab1_OTAllowed2.Checked = false; }

                 Tab1_MaxOTMinsAllowed.Text = EmptyString(e.Item.Cells[9].Text);     
        }
    
        protected void Grid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            int LeaveTypeID = (int)Grid.DataKeys[(int)e.Item.ItemIndex];
            Grid.EditItemIndex = -1;
            DeleteLeaveType(LeaveTypeID);
        }
        
    }
}
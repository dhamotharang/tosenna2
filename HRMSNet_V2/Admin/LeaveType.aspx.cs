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
    public partial class LeaveType : SchoolNetBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               // LoadCountryList(Tab1_CountryList);
                LoadLeaveTypeLookup(Tab1_LeaveTypeDDList);
                LoadDivisionLookupByEmpId(Tab1_businessUnitDDList, Int32.Parse(Page.User.Identity.Name.ToString()));
                LoadEntityLocationLookupByEmpId_DivisionID(Tab1_DivisionLocationList, Int32.Parse(Page.User.Identity.Name.ToString()), Int32.Parse(Tab1_businessUnitDDList.SelectedValue));

            }
            if (Int32.Parse(Tab1_DivisionLocationList.SelectedValue) == -1)
            {
                LoadEntityLocationLookupByEmpId_DivisionID(Tab1_DivisionLocationList, Int32.Parse(Page.User.Identity.Name.ToString()), Int32.Parse(Tab1_businessUnitDDList.SelectedValue));
            }
           LoadLeaveTypeList();
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
            LeaveType_Save.Click +=new EventHandler(LeaveType_Save_Click);
            Reset.Click += new EventHandler(Reset_Click);
            Tab1_businessUnitDDList.SelectedIndexChanged += new EventHandler(Tab1_businessUnitDDList_SelectedIndexChanged);
        
        }
        #endregion
        protected void Tab1_businessUnitDDList_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadEntityLocationLookupByDivisionID(Tab1_DivisionLocationList, Int32.Parse(Tab1_businessUnitDDList.SelectedValue));
        }

        #region LoadLeaveTypeList
        private void LoadLeaveTypeList()
        {
            DataSet _DataList = null;
            _DataList = DatabaseManager.Data.DBAccessManager.RetrieveLeaveTypeList(Int32.Parse(Page.User.Identity.Name.ToString()));

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

        #region LeaveType_Save_Click
        protected void LeaveType_Save_Click(object sender, EventArgs e)
        {
           
            try
            {
                if (Page.IsValid == true)
                {
                    Int32 PayType, EnableAccrual, DedAccrual, CarryFWD, DedSPeriod, AllowNegative, PartialDay, AllowESS;
                    
                     AllowNegative = 0; // default.
                     DedSPeriod = 0;
                     CarryFWD = 0;
                    if (Tab1_Rb1_PayType1.Checked) {PayType= 1;} else{PayType= 0;}
                    if ( Tab1_keyField.Text.ToString()== "" ) {Tab1_keyField.Text ="0";}
                    if (Tab1_MaxFullPayDays.Text.ToString() == "") { Tab1_MaxFullPayDays.Text = "0"; }
                    if (Tab1_MaxPartialPayDays.Text.ToString() == "") { Tab1_MaxPartialPayDays.Text = "0"; }
                    if (Tab1_PartialPayPercentage.Text.ToString() == "") { Tab1_PartialPayPercentage.Text = "0"; }
                    if (Tab1_MaxDaysAllowed.Text.ToString() == "") { Tab1_MaxDaysAllowed.Text = "0"; }

                    String Result = DatabaseManager.Data.DBAccessManager.AddUpdateLeaveType(Int32.Parse(Page.User.Identity.Name.ToString()), Convert.ToInt32(Tab1_LeaveTypeDDList.SelectedValue), Int32.Parse(Tab1_businessUnitDDList.SelectedValue), Int32.Parse(Tab1_DivisionLocationList.SelectedValue),PayType, CarryFWD, DedSPeriod, AllowNegative, Convert.ToInt32(Tab1_MaxFullPayDays.Text), Convert.ToInt32(Tab1_MaxPartialPayDays.Text), Decimal.Parse(Tab1_PartialPayPercentage.Text), Int32.Parse(Tab1_MaxDaysAllowed.Text));
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
                LoadLeaveTypeList();// Refresh the grid

            }
            catch (Exception exception)
            {
                this.LTmessage.Visible = true;
                this.LTmessage.Text = ErrorLogging.LogError(exception,"Unknown Exception Occured.Please contact support.");
                this.LTmessage.CssClass = "errorMessage";
            }
        }
        #endregion
        #region Reset_Click
        protected void Reset_Click(object sender, EventArgs e)
        {
            ResetFields();
        }
        #endregion
        private void ResetFields()
        {
            Tab1_keyField.Text = "0";
            Tab1_Rb1_PayType1.Checked = true;
            Tab1_Rb1_PayType2.Checked = false;
            Tab1_MaxFullPayDays.Text = "";
            Tab1_MaxPartialPayDays.Text = "";
            Tab1_PartialPayPercentage.Text = "";
            Tab1_businessUnitDDList.SelectedIndex = -1;
            Tab1_DivisionLocationList.SelectedIndex = -1;
            Tab1_LeaveTypeDDList.SelectedIndex = -1;
            Tab1_MaxDaysAllowed.Text = "";
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
            LoadLeaveTypeList(); // Refresh the grid after deletion.

        }

        protected void Grid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            Grid.CurrentPageIndex = e.NewPageIndex;
            LoadLeaveTypeList();
        }
        protected void Grid_EditCommand(object source, DataGridCommandEventArgs e)
        {
            LoadDivisionLookupByEmpId(Tab1_businessUnitDDList, Int32.Parse(Page.User.Identity.Name.ToString()));
            LoadLeaveTypeLookup(Tab1_LeaveTypeDDList);

            this.Tab1_keyField.Text = Grid.DataKeys[e.Item.ItemIndex].ToString();
            if (EmptyString(Tab1_keyField.Text) != "")
            {
                Tab1_LeaveTypeDDList.SelectedValue = Tab1_LeaveTypeDDList.Items.FindByValue(Tab1_keyField.Text).Value;
            }

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
            if (EmptyString(e.Item.Cells[5].Text) == "Paid"){ Tab1_Rb1_PayType1.Checked = true; } else {Tab1_Rb1_PayType1.Checked = false; }
            if (EmptyString(e.Item.Cells[5].Text) == "Unpaid") { Tab1_Rb1_PayType2.Checked = true; } else { Tab1_Rb1_PayType2.Checked = false; }
            
            Tab1_MaxFullPayDays.Text = EmptyString(e.Item.Cells[6].Text);
            Tab1_MaxPartialPayDays.Text = EmptyString(e.Item.Cells[7].Text);
            Tab1_PartialPayPercentage.Text = EmptyString(e.Item.Cells[8].Text);

            Tab1_MaxDaysAllowed.Text = EmptyString(e.Item.Cells[9].Text);
         }
        
        protected void Grid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            int LeaveTypeID = (int)Grid.DataKeys[(int)e.Item.ItemIndex];
            Grid.EditItemIndex = -1;
            DeleteLeaveType(LeaveTypeID);
        }
        
    }
}
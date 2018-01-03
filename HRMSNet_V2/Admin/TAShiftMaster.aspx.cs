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
    public partial class TAShiftMaster : SchoolNetBase
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
            LoadTAShiftMaster();
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

        #region LoadTAShiftMaster
        private void LoadTAShiftMaster()
        {
            DataSet _DataList = null;
            _DataList = DatabaseManager.Data.DBAccessManager.RetrieveTAShiftMaster(Int32.Parse(Page.User.Identity.Name.ToString()));
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
             //       Int32 LunchMins = 0, BreakMins = 0, DedAccrual, CarryFWD, DedSPeriod, AllowNegative, PartialDay, AllowESS;
                    Boolean LateAllowed, EarlyAllowed,EndsNextDay, LunchAllowed, BreakAllowed, OTAllowed, IsDefault;
                    if (Tab1_keyField.Text.ToString() == "") { Tab1_keyField.Text = "0"; }
                    if (Tab1_LateAllowed1.Checked) { LateAllowed = true; } else { LateAllowed = false; }
                    if (Tab1_EarlyAllowed1.Checked) { EarlyAllowed = true; } else { EarlyAllowed = false; }
                    if (Tab1_LateAllowed1.Checked) { LunchAllowed = true; } else { LunchAllowed = false; }
                    if (Tab1_EarlyAllowed1.Checked) { BreakAllowed = true; } else { BreakAllowed = false; }
                    if (Tab1_OTAllowed1.Checked) { OTAllowed = true; } else { OTAllowed = false; }
                    if (Tab1_EndsNextDay1.Checked) { EndsNextDay = true; } else { EndsNextDay = false; }
                    if (Tab1_IsDefault1.Checked) { IsDefault = true; } else { IsDefault = false; }
                    if (Tab1_FixedLunchMins.Text.ToString() == "") { Tab1_FixedLunchMins.Text = "0"; }
                    if (Tab1_FixedBreakMins.Text.ToString() == "") { Tab1_FixedBreakMins.Text = "0"; }
                    if (Tab1_FixedFullDayMins.Text.ToString() == "") { Tab1_FixedFullDayMins.Text = "0"; }
                    if (Tab1_FixedHalfDayMins.Text.ToString() == "") { Tab1_FixedHalfDayMins.Text = "0"; }
                    if (Tab1_OTOffset.Text.ToString() == "") { Tab1_OTOffset.Text = "0"; }
                    if (Tab1_GracePeriod.Text.ToString() == "") { Tab1_GracePeriod.Text = "0"; }
                    String Result = DatabaseManager.Data.DBAccessManager.AddUpdateTAShiftMaster(Int32.Parse(Page.User.Identity.Name.ToString()), Int32.Parse(Tab1_keyField.Text), Int32.Parse(Tab1_businessUnitDDList.SelectedValue), Int32.Parse(Tab1_DivisionLocationList.SelectedValue),
                        ShiftName.Text.ToString(), ShiftCode.Text.ToString(), Tab1_ShiftInTime.Text.ToString(), Tab1_ShiftOutTime.Text.ToString(), LateAllowed, EarlyAllowed, EndsNextDay,
                        LunchAllowed, Convert.ToInt32(Tab1_FixedLunchMins.Text), BreakAllowed, Convert.ToInt32(Tab1_FixedBreakMins.Text), Convert.ToInt32(Tab1_FixedFullDayMins.Text), Convert.ToInt32(Tab1_FixedHalfDayMins.Text), OTAllowed, Convert.ToInt32(Tab1_GracePeriod.Text), Convert.ToInt32(Tab1_OTOffset.Text), IsDefault);
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
                LoadTAShiftMaster();// Refresh the grid

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
            Tab1_businessUnitDDList.SelectedIndex = -1;
            Tab1_DivisionLocationList.SelectedIndex = -1;
            ShiftName.Text = "";
            ShiftCode.Text = "";
            Tab1_ShiftInTime.Text = "";
            Tab1_ShiftOutTime.Text = "";
            Tab1_LateAllowed1.Checked = true;
            Tab1_LateAllowed2.Checked = false;
            Tab1_EarlyAllowed1.Checked = true;
            Tab1_EarlyAllowed2.Checked = false;
            Tab1_EndsNextDay1.Checked = true;
            Tab1_EndsNextDay2.Checked = false;
            Tab1_LunchAllowed1.Checked = true;
            Tab1_LunchAllowed2.Checked = false;
            Tab1_FixedLunchMins.Text = "";
            Tab1_BreakAllowed1.Checked = true;
            Tab1_BreakAllowed2.Checked = false;
            Tab1_FixedBreakMins.Text = "";
            Tab1_FixedFullDayMins.Text = "";
            Tab1_FixedHalfDayMins.Text = "";
            Tab1_OTAllowed1.Checked = true;
            Tab1_OTAllowed2.Checked = false;
            Tab1_OTOffset.Text = "";
            Tab1_GracePeriod.Text = "";
            Tab1_IsDefault1.Checked = true;
            Tab1_IsDefault2.Checked = false;
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
            LoadTAShiftMaster(); // Refresh the grid after deletion.

        }

        protected void Grid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            Grid.CurrentPageIndex = e.NewPageIndex;
            LoadTAShiftMaster();
        }
        protected void Grid_EditCommand(object source, DataGridCommandEventArgs e)
        {
            LoadDivisionLookupByEmpId(Tab1_businessUnitDDList, Int32.Parse(Page.User.Identity.Name.ToString()));

            this.Tab1_keyField.Text = Grid.DataKeys[e.Item.ItemIndex].ToString();

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

            ShiftName.Text = EmptyString(e.Item.Cells[4].Text);
            ShiftCode.Text = EmptyString(e.Item.Cells[5].Text);
            Tab1_ShiftInTime.Text = EmptyString(e.Item.Cells[6].Text);
            Tab1_ShiftOutTime.Text = EmptyString(e.Item.Cells[7].Text);

            if (EmptyString(e.Item.Cells[8].Text) == "Yes") { Tab1_LateAllowed1.Checked = true; } else { Tab1_LateAllowed1.Checked = false; }
            if (EmptyString(e.Item.Cells[8].Text) == "No") { Tab1_LateAllowed2.Checked = true; } else { Tab1_LateAllowed2.Checked = false; }
            if (EmptyString(e.Item.Cells[9].Text) == "Yes") { Tab1_EarlyAllowed1.Checked = true; } else { Tab1_EarlyAllowed1.Checked = false; }
            if (EmptyString(e.Item.Cells[9].Text) == "No") { Tab1_EarlyAllowed2.Checked = true; } else { Tab1_EarlyAllowed2.Checked = false; }
            if (EmptyString(e.Item.Cells[10].Text) == "Yes") { Tab1_EndsNextDay1.Checked = true; } else { Tab1_EndsNextDay1.Checked = false; }
            if (EmptyString(e.Item.Cells[10].Text) == "No") { Tab1_EndsNextDay2.Checked = true; } else { Tab1_EndsNextDay2.Checked = false; }
            if (EmptyString(e.Item.Cells[11].Text) == "Yes") { Tab1_LunchAllowed1.Checked = true; } else { Tab1_LunchAllowed1.Checked = false; }
            if (EmptyString(e.Item.Cells[11].Text) == "No") { Tab1_LunchAllowed2.Checked = true; } else { Tab1_LunchAllowed2.Checked = false; }
            if (EmptyString(e.Item.Cells[12].Text) == "Yes") { Tab1_BreakAllowed1.Checked = true; } else { Tab1_BreakAllowed1.Checked = false; }
            if (EmptyString(e.Item.Cells[12].Text) == "No") { Tab1_BreakAllowed2.Checked = true; } else { Tab1_BreakAllowed2.Checked = false; }

            Tab1_FixedLunchMins.Text = EmptyString(e.Item.Cells[13].Text);
            Tab1_FixedBreakMins.Text = EmptyString(e.Item.Cells[14].Text);
            Tab1_FixedFullDayMins.Text = EmptyString(e.Item.Cells[15].Text);
            Tab1_FixedHalfDayMins.Text = EmptyString(e.Item.Cells[16].Text);

            if (EmptyString(e.Item.Cells[17].Text) == "Yes") { Tab1_OTAllowed1.Checked = true; } else { Tab1_OTAllowed1.Checked = false; }
            if (EmptyString(e.Item.Cells[17].Text) == "No") { Tab1_OTAllowed2.Checked = true; } else { Tab1_OTAllowed2.Checked = false; }

            Tab1_OTOffset.Text = EmptyString(e.Item.Cells[18].Text);
            Tab1_GracePeriod.Text = EmptyString(e.Item.Cells[19].Text);

            if (EmptyString(e.Item.Cells[20].Text) == "Yes") { Tab1_IsDefault1.Checked = true; } else { Tab1_IsDefault1.Checked = false; }
            if (EmptyString(e.Item.Cells[20].Text) == "No") { Tab1_IsDefault2.Checked = true; } else { Tab1_IsDefault2.Checked = false; }

         }
        
        protected void Grid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            int LeaveTypeID = (int)Grid.DataKeys[(int)e.Item.ItemIndex];
            Grid.EditItemIndex = -1;
            DeleteLeaveType(LeaveTypeID);
        }
        
    }
}
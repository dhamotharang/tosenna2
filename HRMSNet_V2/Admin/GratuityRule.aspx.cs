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
    public partial class GratuityRule: SchoolNetBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadGratuityTypeList(Tab1_GratuityTypeDDList);
                LoadDivisionLookupByEmpId(Tab1_businessUnitDDList, Int32.Parse(Page.User.Identity.Name.ToString()));
                LoadEntityLocationLookupByEmpId_DivisionID(Tab1_DivisionLocationList, Int32.Parse(Page.User.Identity.Name.ToString()), Int32.Parse(Tab1_businessUnitDDList.SelectedValue));

                Tab1_GratuityTypeDDList.Enabled = false;
                Tab1_businessUnitDDList.Enabled = false;
                Tab1_DivisionLocationList.Enabled = false;
                Tab1_GratuityExpression.Enabled = false;

            }
            if (Int32.Parse(Tab1_DivisionLocationList.SelectedValue) == -1)
            {
                LoadEntityLocationLookupByEmpId_DivisionID(Tab1_DivisionLocationList, Int32.Parse(Page.User.Identity.Name.ToString()), Int32.Parse(Tab1_businessUnitDDList.SelectedValue));
            }

            LoadEOSGratuityRuleList();
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
            EOS_Save.Click += new EventHandler(EOS_Save_Click);
            Reset.Click += new EventHandler(Reset_Click);
            Tab1_businessUnitDDList.SelectedIndexChanged += new EventHandler(Tab1_businessUnitDDList_SelectedIndexChanged);

        }
        #endregion

        protected void Tab1_businessUnitDDList_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadEntityLocationLookupByDivisionID(Tab1_DivisionLocationList, Int32.Parse(Tab1_businessUnitDDList.SelectedValue));
        }

        #region LoadEOSGratuityRuleList
        private void LoadEOSGratuityRuleList()
        {
            DataSet _DataList = null;
            _DataList = DatabaseManager.Data.DBAccessManager.RetrieveEOSGratuityList(Int32.Parse(Page.User.Identity.Name.ToString())); 

            if (_DataList.Tables[0].Rows.Count > 0)
            {
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

        #region EOS_Save_Click
        protected void EOS_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid == true)
                {
                    Int32 Status = 0;
                    if (Tab1_KeyField.Text.ToString() == "") { Tab1_KeyField.Text = "0"; }
                    if (Tab1_Param1Days.Text.ToString() == "") { Tab1_Param1Days.Text ="0";}
                    if (Tab1_Param1Percentage.Text.ToString() == "") { Tab1_Param1Percentage.Text ="0";}
                    if (Tab1_Param2Days.Text.ToString() == "") { Tab1_Param2Days.Text="0";}
                    if (Tab1_Param2Percentage.Text.ToString() =="") {Tab1_Param2Percentage.Text ="0";}
                    if (Tab1_WageConstraint.Text.ToString() == "") { Tab1_WageConstraint.Text = "0"; }

                    String Result = DatabaseManager.Data.DBAccessManager.AddUpdateGratuityRules(Convert.ToInt32(Tab1_KeyField.Text),Int32.Parse(Tab1_businessUnitDDList.SelectedValue),Int32.Parse(Tab1_DivisionLocationList.SelectedValue),Int32.Parse(Tab1_GratuityTypeDDList.SelectedValue),Int32.Parse(Tab1_Param1Days.Text),Decimal.Parse(Tab1_Param1Percentage.Text),Int32.Parse(Tab1_Param2Days.Text),Decimal.Parse(Tab1_Param2Percentage.Text),Int32.Parse(Tab1_WageConstraint.Text),Int32.Parse(Page.User.Identity.Name.ToString()));
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
                LoadEOSGratuityRuleList();// Refresh the grid

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
            Tab1_KeyField.Text = "0";
           // Tab1_GratuityRuleName.Text = "";
            Tab1_GratuityExpression.Text = "";
            Tab1_businessUnitDDList.SelectedIndex = 0;
            Tab1_DivisionLocationList.SelectedIndex = 0;
            Tab1_GratuityTypeDDList.SelectedIndex = 0;
            Tab1_Param1Days.Text = "";
            Tab1_Param1Percentage.Text = "";
            Tab1_Param2Days.Text = "";
            Tab1_Param2Percentage.Text = "";
            Tab1_WageConstraint.Text = "";
            LTmessage.Visible = false;
            LTmessage.Text = "";
        }
        private void DeleteGratuityRule(Int32 GratuityRuleID)
        {
            try
            {
                String result = DatabaseManager.Data.DBAccessManager.DeleteGratuityRule(GratuityRuleID, Int32.Parse(Page.User.Identity.Name.ToString()));

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
            LoadEOSGratuityRuleList(); // Refresh the grid after deletion.

        }

        protected void Grid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            Grid.CurrentPageIndex = e.NewPageIndex;
            LoadEOSGratuityRuleList();
        }
        protected void Grid_EditCommand(object source, DataGridCommandEventArgs e)
        {
            LoadDivisionLookupByEmpId(Tab1_businessUnitDDList, Int32.Parse(Page.User.Identity.Name.ToString()));
            LoadGratuityTypeList(Tab1_GratuityTypeDDList);

            this.Tab1_KeyField.Text = Grid.DataKeys[e.Item.ItemIndex].ToString();
            if (EmptyString(e.Item.Cells[1].Text) != "")
            {
                Tab1_businessUnitDDList.SelectedValue = Tab1_businessUnitDDList.Items.FindByValue(EmptyString(e.Item.Cells[1].Text)).Value;
            }
            if (EmptyString(e.Item.Cells[3].Text) != "")
            {
                LoadEntityLocationLookupByEmpId_DivisionID(Tab1_DivisionLocationList, Int32.Parse(Page.User.Identity.Name.ToString()), Int32.Parse(Tab1_businessUnitDDList.SelectedValue));
                Tab1_DivisionLocationList.SelectedValue = Tab1_DivisionLocationList.Items.FindByValue(EmptyString(e.Item.Cells[3].Text)).Value;
            }

            if (EmptyString(e.Item.Cells[4].Text) != "")
            {
                Tab1_GratuityTypeDDList.SelectedValue = Tab1_GratuityTypeDDList.Items.FindByValue(EmptyString(e.Item.Cells[4].Text)).Value;
            }
            Tab1_GratuityExpression.Text = EmptyString(e.Item.Cells[6].Text);
            Tab1_Param1Days.Text = EmptyString(e.Item.Cells[7].Text);
            Tab1_Param1Percentage.Text = EmptyString(e.Item.Cells[8].Text);
            Tab1_Param2Days.Text = EmptyString(e.Item.Cells[9].Text);
            Tab1_Param2Percentage.Text = EmptyString(e.Item.Cells[10].Text);
            Tab1_WageConstraint.Text = EmptyString(e.Item.Cells[11].Text);
            
            Tab1_GratuityTypeDDList.Enabled = false;
            Tab1_businessUnitDDList.Enabled = false;
            Tab1_DivisionLocationList.Enabled = false;
            Tab1_GratuityExpression.Enabled = false;

                     

        }

        protected void Grid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            int GratuityRuleID = (int)Grid.DataKeys[(int)e.Item.ItemIndex];
            Grid.EditItemIndex = -1;
            DeleteGratuityRule(GratuityRuleID);
        }

    }
}
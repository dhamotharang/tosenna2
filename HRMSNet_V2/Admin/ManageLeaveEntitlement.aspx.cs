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
    public partial class ManageLeaveEntitlement : SchoolNetBase
    {
        public int EmpId;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            EmpId = Int32.Parse(Page.User.Identity.Name.ToString());
            if (!Page.IsPostBack)
            {
                LoadLeaveTypeLookup(Tab1_LeaveTypeList);
                LoadLeavePeriodLookup(Tab1_LeavePeriodList);
                LoadDesignationLookup(Tab1_JobTitleDDList);
                LoadDivisionLookupByEmpId(Tab1_BusinessUnitDDList, Int32.Parse(Page.User.Identity.Name.ToString()));
                LoadEntityLocationLookupByEmpId_DivisionID(Tab1_DivisionLocationList, Int32.Parse(Page.User.Identity.Name.ToString()), Int32.Parse(Tab1_BusinessUnitDDList.SelectedValue));

            }
            if (Int32.Parse(Tab1_DivisionLocationList.SelectedValue) == -1)
            {
                LoadEntityLocationLookupByEmpId_DivisionID(Tab1_DivisionLocationList, Int32.Parse(Page.User.Identity.Name.ToString()), Int32.Parse(Tab1_BusinessUnitDDList.SelectedValue));
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
            Entitlement_Save.Click += new EventHandler(Entitlement_Save_Click);
            Entitlement_Cancel.Click += new EventHandler(Entitlement_Cancel_Click);

        }
        #endregion

        protected void Entitlement_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid == true)
                {
                    Int32 LineMgr_Approval = 1;
                    
                    if (Tab1_Entitlement.Text.ToString() == "") { Tab1_Entitlement.Text = "0"; }

                    String Result = DatabaseManager.Data.DBAccessManager.AddUpdateEntitlement(EmpId, Int32.Parse(Tab1_LeaveTypeList.SelectedValue), Int32.Parse(Tab1_LeavePeriodList.SelectedValue), Convert.ToInt32(Tab1_Entitlement.Text), Tab1_EmpName.Text, Int32.Parse(Tab1_JobTitleDDList.SelectedValue), Int32.Parse(Tab1_BusinessUnitDDList.SelectedValue), Int32.Parse(Tab1_DivisionLocationList.SelectedValue), LineMgr_Approval);
                    Tab1_Message.Visible = true;
                    Tab1_Message.CssClass = "errorMessage";
                    if (Result == "")
                    {
                        Tab1_Message.Text = "Successfully saved.";

                    }
                    else
                    {
                        Tab1_Message.Text = Result;
                    }                    
                }

            }
            catch (Exception exception)
            {
                Tab1_Message.Visible = true;
                Tab1_Message.Text = ErrorLogging.LogError(exception, "Unknown Exception Occured.Please contact Support.");
                Tab1_Message.CssClass = "errorMessage";
            }

        }
        protected void Entitlement_Cancel_Click(object sender, EventArgs e)
        {
            Tab1_Entitlement.Text = "";
            Tab1_EmpName.Text = "";
            Tab1_JobTitleDDList.SelectedIndex = -1;
            Tab1_Message.Text = "";
            Tab1_Message.Visible = false;
        }

    }
}
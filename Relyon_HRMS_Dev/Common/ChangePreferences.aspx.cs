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
    public partial class ChangePreferences : SchoolNetBase
    {
        public int EmpId;

        protected void Page_Load(object sender, EventArgs e)
        {
            EmpId = Int32.Parse(Page.User.Identity.Name.ToString());
            if (!Page.IsPostBack)
            {
                LoadMyCurrentPreferences(EmpId);
                if (Session["MemberEmail"] != null)
                {
                    Tab1_EmailAddress.Text = Session["MemberEmail"].ToString();
                    
                }
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
            Save_Preference.Click += new EventHandler(Save_Preference_Click);
        }
        #endregion

        protected void Save_Preference_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid == true)
                {
                    keyField.Text = EmpId.ToString(); // Hardcoded value
                    Int32 Alerting = 0;
                    if (Tab1_ApprCheckBox1.Checked) { Alerting = 1; }
                    if (Tab1_PersistDays.Text.ToString() == "") { Tab1_PersistDays.Text = "0"; }

                    String Result = DatabaseManager.Data.DBAccessManager.SavePreferences(Int32.Parse(this.keyField.Text.ToString()), Alerting, Tab1_EmailAddress.Text.ToString(), Tab1_EmergencyPhone.Text.ToString(), Int32.Parse(Tab1_PersistDays.Text.ToString()));
                    this.message.Visible = true;
                    if (Result == "")
                    {
                        this.message.Text = "Successfully saved.";
                        this.message.CssClass = "errorMessage";
                    }

                }
                else
                {
                    this.message.Text = "Error:Could not save the information. Please check the inputs";
                    this.message.CssClass = "errorMessage";
                }

            }
            catch (Exception exception)
            {
                this.message.Visible = true;
                this.message.Text = ErrorLogging.LogError(exception, "Unknown Exception Occured.Please contact Support.");
                this.message.CssClass = "errorMessage";
            }
        }

       
        private void LoadMyCurrentPreferences(Int32 EmpId)
        {

            DataSet _DataList = null;
            _DataList = DatabaseManager.Data.DBAccessManager.RetrieveEmpPreferenceInfo(EmpId);

            if (_DataList.Tables.Count > 0)
            {
                if (_DataList.Tables[0].Rows.Count > 0)
                {
                    DataRow _DataRow = _DataList.Tables[0].Rows[0];
                    Tab1_EmailAddress.Text = _DataRow["Alerting_EmailAddr"].ToString();
                    Tab1_EmergencyPhone.Text = _DataRow["Alerting_Phone"].ToString();
                    Tab1_PersistDays.Text = _DataRow["PersistDays_CompTasks"].ToString();
                    if (_DataRow["Alerting_Enabled"].ToString() == "1")
                    { Tab1_ApprCheckBox1.Checked = true; }
                    else
                    { Tab1_ApprCheckBox1.Checked = false; }


                }

            }
        }
    }
}

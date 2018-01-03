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

    public partial class EmployeeResources : SchoolNetBase
    {
        public int EmpId;
        protected void Page_Load(object sender, EventArgs e)
        {
            EmpId = Int32.Parse(Page.User.Identity.Name.ToString());
            LoadDocuments(EmpId);
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

            DOCGrid.PageIndexChanged += new DataGridPageChangedEventHandler(DOCGrid_PageIndexChanged);
        }
        #endregion
        protected void DOCGrid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            DOCGrid.CurrentPageIndex = e.NewPageIndex;
            LoadDocuments(EmpId);

        }
        #region  LoadDocuments
        private void LoadDocuments(Int32 EmpId)
        {
            DataSet _DataList = null;
            _DataList = DatabaseManager.Data.DBAccessManager.RetrieveDocumentListByRole(EmpId);
            if (_DataList.Tables[0].Rows.Count > 0)  // Document Information.
            {
                DataTable _DocDataTable = _DataList.Tables[0];
                this.DOCGrid.DataSource = _DocDataTable;
                this.DOCGrid.DataBind();
            }
            else
            {
                this.DOCGrid.DataSource = null;
                this.DOCGrid.DataBind();
            }
        }
        #endregion

    }
}

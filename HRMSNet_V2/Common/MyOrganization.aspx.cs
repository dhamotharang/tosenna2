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
    public partial class MyOrganization : SchoolNetBase
    {
        public int EmpId;

        protected void Page_Load(object sender, EventArgs e)
        {
            EmpId = Int32.Parse(Page.User.Identity.Name.ToString());

            if (!Page.IsPostBack)
            {
                LoadRootLevelMembers();
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


        }
        #endregion


        #region LoadRootLevelMembers();
        private void LoadRootLevelMembers()
        {
            DataSet _DataList = null;
            _DataList = DatabaseManager.Data.DBAccessManager.RetrieveMyOrgRootMember(EmpId);

            if (_DataList.Tables[0].Rows.Count > 0)
            {
                DataRow _DataRow = _DataList.Tables[0].Rows[0];
                if (_DataRow["LineManagerID"] == DBNull.Value)
                    {
                        TreeNode treeRoot = new TreeNode();
                        treeRoot.Text = _DataRow["FullName"].ToString();
                        treeRoot.Value = _DataRow["EmpID"].ToString();
                        treeRoot.ImageUrl = "~/Images/Folder.gif";
                        treeRoot.ExpandAll();
                        MyOrgTree.Nodes.Add(treeRoot);    

                     foreach (TreeNode childnode in GetChildNode(Convert.ToInt32(_DataRow["EmpId"])))
                        {
                            treeRoot.ChildNodes.Add(childnode);
                        }
                    }
           
            }
        }
        #endregion

        private TreeNodeCollection GetChildNode(Int32 parentid)
        {
            TreeNodeCollection childtreenodes = new TreeNodeCollection();

            DataView dataView1 = null;
            DataSet _DataList = null;
            _DataList = DatabaseManager.Data.DBAccessManager.RetrieveMyOrgRootMember(EmpId);
            DataTable dt = _DataList.Tables[0];
            dataView1 = new DataView(dt);
            String strFilter = "LineManagerID" + "=" + parentid.ToString() + "";
            dataView1.RowFilter = strFilter;

            if (dataView1.Count > 0)
            {
                foreach (DataRow dataRow in dataView1.ToTable().Rows)
                {
                    TreeNode childNode = new TreeNode();
                    childNode.Text = dataRow["FullName"].ToString();
                    childNode.Value = dataRow["EmpId"].ToString();
                    childNode.ImageUrl = "~/Images/oInboxF.gif";
                    childNode.ExpandAll();

                    foreach (TreeNode cnode in GetChildNode
			(Convert.ToInt32(dataRow["EmpId"])))
                    {
                        childNode.ChildNodes.Add(cnode);
                    }
                    childtreenodes.Add(childNode);
                }
            }
            return childtreenodes;
        }               


    }
}
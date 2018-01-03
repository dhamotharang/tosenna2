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
    public partial class LineManager : SchoolNetBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadDataList();
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

        }
        #endregion
        #region Load LoadDataList
        private void LoadDataList()
        {
            DataSet _DataList = null;
            _DataList = DatabaseManager.Data.DBAccessManager.RetrieveLineManagerList();

            if (_DataList.Tables[0].Rows.Count > 0)
            {
                this.Grid.DataSource = _DataList;
                this.Grid.DataBind();
            }
            else
            {
                emptyRow.Visible = true;
              emptyRow.Text="There are no records found.";
            }
           

        }
        #endregion
        /*
        protected override void search_Click(object sender,EventArgs e)
        {
            DataGrid empList = null;
            empList = EventManager.Data.DBAccessManager.RetrieveEmpList2
                this.empName.Text, this.empID.Text, this.mgrName.Text, this.empStatusDDList.SelectedItem.ToString(),
                this.jobTitleDDList.SelectedItem.ToString(), this.businessUnitDDList.SelectedItem.ToString());

            Grid.DataSource = empList;
            Grid.DataBind();

         

        } 
         */

        protected void Reset_Click(object sender, EventArgs e)
        {

        }
        protected void Grid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            Grid.CurrentPageIndex = e.NewPageIndex;
            LoadDataList();
        }
        protected void Grid_EditCommand(object source, DataGridCommandEventArgs e)
        {
            Grid.EditItemIndex = e.Item.ItemIndex;
            LoadDataList();
        }
        protected void Grid_CancelCommand(object source, DataGridCommandEventArgs e)
        {
            Grid.EditItemIndex = -1;
            LoadDataList();
        }
        protected void Grid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            /*   con = new SqlConnection(ConfigurationManager.AppSettings["connect"]);
               cmd.Connection = con;
               int EmpId = (int)Grid.DataKeys[(int)e.Item.ItemIndex];
               cmd.CommandText = "Delete from Employee where EmpId=" + EmpId;
               cmd.Connection.Open();
               cmd.ExecuteNonQuery();
               cmd.Connection.Close();
               Grid.EditItemIndex = -1;
               BindData();
               LoadEmpList() */
        }
        protected void Grid_UpdateCommand(object source, DataGridCommandEventArgs e)
        {
            /* con = new SqlConnection(ConfigurationManager.AppSettings["connect"]);
             cmd.Parameters.Add("@EmpId", SqlDbType.Int).Value = ((TextBox)e.Item.Cells[0].Controls[0]).Text;
             cmd.Parameters.Add("@F_Name", SqlDbType.Char).Value = ((TextBox)e.Item.Cells[1].Controls[0]).Text;
             cmd.Parameters.Add("@L_Name", SqlDbType.Char).Value = ((TextBox)e.Item.Cells[2].Controls[0]).Text;
             cmd.Parameters.Add("@City", SqlDbType.Char).Value = ((TextBox)e.Item.Cells[3].Controls[0]).Text;
             cmd.Parameters.Add("@EmailId", SqlDbType.Char).Value = ((TextBox)e.Item.Cells[4].Controls[0]).Text;
             cmd.Parameters.Add("@EmpJoining", SqlDbType.DateTime).Value = DateTime.Now.ToString();
             cmd.CommandText = "Update Employee set F_Name=@F_Name,L_Name=@L_Name,City=@City,EmailId=@EmailId,EmpJoining=@EmpJoining where EmpId=@EmpId";
             cmd.Connection = con;
             cmd.Connection.Open();
             cmd.ExecuteNonQuery();
             cmd.Connection.Close();
             Grid.EditItemIndex = -1;
             BindData(); */
        }

    }
}
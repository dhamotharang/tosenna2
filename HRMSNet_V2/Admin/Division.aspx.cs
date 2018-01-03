using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using DatabaseManager.Data;
using PresentationManager.Web.UI.MasterPages;

namespace SchoolNet
{
    /// <summary>
    /// Summary description for WebForm1.
    /// </summary>
    public partial class Division : SchoolNetBase
    {

        protected void Page_Load(object sender, System.EventArgs e)
        {
            // Put user code to initialize the page here
            if (!Page.IsPostBack)
            {
                LoadSupervisorsListLookup(SupervisorDDList);
                LoadCompanyRegionList(RegionDDList);
            }
            LoadDataList();
            if (this.Tab1_KeyField.Text.ToString() != "")
            {
                LoadDivisionLocationList(Int32.Parse(Tab1_KeyField.Text));
            }
             if ((this.Tab1_KeyField.Text.ToString() != "" ) && (Tab2_KeyField.Text.ToString() !=""))
            {
                LoadDivisionLocationDeptList(Int32.Parse(Tab1_KeyField.Text),Int32.Parse(Tab2_KeyField.Text));
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

            Grid.PageIndexChanged += new DataGridPageChangedEventHandler(this.Grid_PageIndexChanged);
            LGrid.PageIndexChanged +=new DataGridPageChangedEventHandler(LGrid_PageIndexChanged);
            DGrid.PageIndexChanged  +=new DataGridPageChangedEventHandler(DGrid_PageIndexChanged);
            Tab1_Save.Click +=new EventHandler(Tab1_Save_Click);
            Tab1_Reset.Click +=new EventHandler(Tab1_Reset_Click);
            Tab2_Save.Click +=new EventHandler(Tab2_Save_Click);
            Tab2_Reset.Click +=new EventHandler(Tab2_Reset_Click);
            Tab2_Back.Click +=new EventHandler(Tab2_Back_Click);
            Tab3_Save.Click +=new EventHandler(Tab3_Save_Click);
            Tab3_Reset.Click +=new EventHandler(Tab3_Reset_Click);
            Tab3_Back.Click +=new EventHandler(Tab3_Back_Click);
                
        }
        #endregion
        #region Load LoadDataList
        private void LoadDataList()
        {
            DataSet _DataList = null;
            _DataList = DatabaseManager.Data.DBAccessManager.RetrieveDivisionList(Int32.Parse(Page.User.Identity.Name.ToString()));
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

        #region  LoadDivisionLocationList
        private void LoadDivisionLocationList(Int32 DivisionID)
        {
            DataSet _DataList = null;
            _DataList = DatabaseManager.Data.DBAccessManager.RetrieveDivisionLocationListByDivisionID(DivisionID);
            if (_DataList.Tables[0].Rows.Count > 0)
            {
                this.LGrid.DataSource = _DataList;
                this.LGrid.DataBind();
            }
            else
            {
                this.LGrid.DataSource = null;
                this.LGrid.DataBind();
            }

        }
        #endregion

        #region  LoadDivisionLocationDeptList
        private void LoadDivisionLocationDeptList(Int32 DivisionID, Int32 LocationID)
        {
            DataSet _DataList = null;
            _DataList = DatabaseManager.Data.DBAccessManager.RetrieveDivisionLocationDeptList(DivisionID, LocationID);
            if (_DataList.Tables[0].Rows.Count > 0)
            {
                this.DGrid.DataSource = _DataList;
                this.DGrid.DataBind();
            }
            else
            {
                this.DGrid.DataSource = null;
                this.DGrid.DataBind();
            }

        }
        #endregion



        protected void Tab1_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid == true)
                {
                    Int32 Status = 0;
                    if (Radio1.Checked) { Status = 1; }
                    if (Tab1_KeyField.Text.ToString() == "") { Tab1_KeyField.Text = "0"; }

                    String Result = DatabaseManager.Data.DBAccessManager.AddUpdateDivision(Int32.Parse(Page.User.Identity.Name.ToString()), Int32.Parse(Tab1_KeyField.Text), DivisionName.Text.ToString(), Int32.Parse(SupervisorDDList.SelectedValue), GLCode.Text, Status, Int32.Parse(RegionDDList.SelectedValue));

                    this.Tab1_Message.Visible = true;
                    this.Tab1_Message.CssClass = "errorMessage";
                    if (Result == "")
                    {
                        ResetFields();
                    }
                    else
                    {
                        this.Tab1_Message.Text = Result;
                    }
                }
                else
                {
                    this.Tab1_Message.Text = "Error:Could not save the information. Please check the inputs";
                    this.Tab1_Message.CssClass = "errorMessage";

                }
                this.LoadDataList(); // Refresh the grid after save

            }
            catch (Exception exception)
            {
                this.Tab1_Message.Visible = true;
                this.Tab1_Message.Text = ErrorLogging.LogError(exception,"Unknown Exception Occured. Please contact support.");
                this.Tab1_Message.CssClass = "errorMessage";
            }

        }


        private void DeleteDivision(Int32 DivisionID)
        {
            try
            {
                String result = DatabaseManager.Data.DBAccessManager.DeleteBusinessDivision(Int32.Parse(Page.User.Identity.Name.ToString()), DivisionID);

                if (result != "")
                {
                    this.Tab1_Message.Text = result;
                    this.Tab1_Message.Visible = true;
                    this.Tab1_Message.CssClass = "errorMessage";

                }
            }
            catch (Exception exception)
            {
                this.Tab1_Message.Visible = true;
                this.Tab1_Message.Text = ErrorLogging.LogError(exception, "Unknown Exception Occured. Please contact support.");
                this.Tab1_Message.CssClass = "errorMessage";
            }

            Grid.CurrentPageIndex = 0;
            this.LoadDataList(); 

        }

        private void DeleteDivisionLocation(Int32 DivisionID, Int32 LocationID)
        {
            try
            {
                String result = DatabaseManager.Data.DBAccessManager.DeleteDivisionLocation(Int32.Parse(Page.User.Identity.Name.ToString()), DivisionID, LocationID);

                if (result != "")
                {
                    this.Tab2_Message.Text = result;
                    this.Tab2_Message.Visible = true;
                    this.Tab2_Message.CssClass = "errorMessage";

                }
            }
            catch (Exception exception)
            {
                this.Tab2_Message.Visible = true;
                this.Tab2_Message.Text = ErrorLogging.LogError(exception, "Unknown Exception Occured. Please contact support.");
                this.Tab2_Message.CssClass = "errorMessage";
            }

            LGrid.CurrentPageIndex = 0;
            LoadDivisionLocationList(DivisionID);

        }

        private void ResetFields()
        {
            DivisionName.Text = "";
            SupervisorDDList.SelectedIndex = -1;
            RegionDDList.SelectedIndex = -1;
            GLCode.Text = "";
            Tab1_KeyField.Text = "";
            Tab1_Message.Text = "";
            Tab1_Message.Visible = false;

        }
        private void ResetTab2()
        {
            Tab2_SuperVisorList.SelectedIndex = -1;
            Tab2_CountryList.SelectedIndex = -1;
            Tab2_GLCode.Text = "";
            Tab2_Message.Text = "";
            Tab2_Message.Visible = false;
            Tab2_KeyField.Text = "";
            Tab2_EmployerID.Text = "";
            Tab2_EmployerRef.Text = "";
            Tab2_EmployerRoutingCode.Text = "";
            Tab2_CountryList.Enabled = true;

        }
        private void ResetTab3()
        {
            Tab3_SuperVisorList.SelectedIndex = -1;
            Tab3_GLCode.Text = "";
            Tab3_Message.Text = "";
            Tab3_Message.Visible = false;
            Tab3_DepartmentList.Enabled = true;

        }

        protected void Tab1_Reset_Click(object sender, EventArgs e)
        {
            ResetFields();
        }
        protected void Tab2_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid == true)
                {
                    if (Tab2_EmployerRoutingCode.Text == "") { Tab2_EmployerRoutingCode.Text = "0"; }
                    if (Tab2_EmployerID.Text == "") { Tab2_EmployerID.Text = "0"; }
                    if (Tab2_KeyField.Text.ToString() == "") { Tab2_KeyField.Text = "0"; }
                    String Result = DatabaseManager.Data.DBAccessManager.AddUpdateDivisionLocation(Int32.Parse(Page.User.Identity.Name.ToString()), Int32.Parse(Tab2_DivisionID.Text), Int32.Parse(Tab2_KeyField.Text),Int32.Parse(Tab2_CountryList.SelectedValue),Int32.Parse(Tab2_SuperVisorList.SelectedValue), Tab2_EmployerID.Text.ToString(), Tab2_EmployerRef.Text, Int32.Parse(Tab2_EmployerRoutingCode.Text), Tab2_GLCode.Text);
                    this.Tab2_Message.Visible = true;
                    this.Tab2_Message.CssClass = "errorMessage";
                    if (Result == "")
                    {
                        ResetTab2();
                    }
                    else
                    {
                        this.Tab2_Message.Text = Result;
                    }
                }
                else
                {
                    this.Tab2_Message.Text = "Error:Could not save the information. Please check the inputs";
                    this.Tab2_Message.CssClass = "errorMessage";
                }              

            }
            catch (Exception exception)
            {
                this.Tab2_Message.Visible = true;
                this.Tab2_Message.Text = ErrorLogging.LogError(exception,"Unknown Exception Occured. Please contact support.");
                this.Tab2_Message.CssClass = "errorMessage";
            }
            this.LoadDivisionLocationList(Int32.Parse(Tab2_DivisionID.Text)); // Refresh the grid after save
        }
        protected void Tab2_Reset_Click(object sender, EventArgs e)
        {
            ResetTab2();
        }

        protected void Tab2_Back_Click(object sender, EventArgs e)
        {
            ManageCRUD.Visible = true;
            ManagelocationDept.Visible = false;
            Managelocation.Visible = false;
        }
        protected void Tab3_Save_Click(object sender, EventArgs e)
        {

            try
            {
                if (Page.IsValid == true)
                {
                    String Result = DatabaseManager.Data.DBAccessManager.AddUpdateDivisionLocationDept(Int32.Parse(Page.User.Identity.Name.ToString()), Int32.Parse(Tab3_DivisionID.Text), Int32.Parse(Tab3_LocationID.Text), Int32.Parse(Tab3_DepartmentList.SelectedValue), Int32.Parse(Tab3_SuperVisorList.SelectedValue), Tab3_GLCode.Text);

                    this.Tab3_Message.Visible = true;
                    this.Tab3_Message.CssClass = "errorMessage";
                    if (Result == "")
                    {
                        ResetTab3();
                    }
                }
                else
                {
                    this.Tab3_Message.Text = "Error:Could not save the information. Please check the inputs";
                    this.Tab3_Message.CssClass = "errorMessage";

                }


            }
            catch (Exception exception)
            {
                this.Tab3_Message.Visible = true;
                this.Tab3_Message.Text = ErrorLogging.LogError(exception,"Unknown Exception Occured. Please contact support.");
                this.Tab3_Message.CssClass = "errorMessage";
            }
            this.LoadDivisionLocationDeptList(Int32.Parse(Tab3_DivisionID.Text),Int32.Parse(Tab3_LocationID.Text)); // Refresh the grid after save


        }
        protected void Tab3_Reset_Click(object sender, EventArgs e)
        {
            ResetTab3();
        }

        protected void Tab3_Back_Click(object sender, EventArgs e)
        {
            ManageCRUD.Visible = false;
            ManagelocationDept.Visible = false;
            Managelocation.Visible = true;

        }
        protected void Grid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            Grid.CurrentPageIndex = e.NewPageIndex;
            LoadDataList();
        }
        protected void Grid_EditCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                Tab1_KeyField.Text = Grid.DataKeys[e.Item.ItemIndex].ToString();
                //Grid.EditItemIndex = e.Item.ItemIndex;
                LoadSupervisorsListLookupByDivisionID(SupervisorDDList, Int32.Parse(Tab1_KeyField.Text));
                DivisionName.Text = EmptyString(e.Item.Cells[0].Text);
                if (EmptyString(e.Item.Cells[1].Text.Trim()) != "")
                {
                    try
                    {
                        RegionDDList.SelectedValue = RegionDDList.Items.FindByText(e.Item.Cells[1].Text.Trim()).Value;

                    }
                    catch(Exception exception)
                    {
                        RegionDDList.SelectedValue = "-1";
                        ErrorLogging.LogError(exception, "");
                    }
                }

                if (EmptyString(e.Item.Cells[2].Text.Trim()) != "")
                {
                    try
                    {
                        SupervisorDDList.SelectedValue = SupervisorDDList.Items.FindByText(e.Item.Cells[2].Text.Trim()).Value;
                       
                    }
                    catch(Exception exception)
                    {
                        SupervisorDDList.SelectedValue = "-1";
                        ErrorLogging.LogError(exception, "");
                    }
                }
                GLCode.Text = EmptyString(e.Item.Cells[3].Text);
                if (EmptyString(e.Item.Cells[4].Text) == "Active") { Radio1.Checked = true; } else { Radio2.Checked = true; }

                
            }
            

        }
        protected void Grid_ItemCommand(object sender, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                ManageCRUD.Visible = false;
                ManagelocationDept.Visible = false;
                Managelocation.Visible = true;
                Tab1_KeyField.Text = Grid.DataKeys[e.Item.ItemIndex].ToString();
                Tab2_DivisionID.Text   = Grid.DataKeys[e.Item.ItemIndex].ToString();
                Tab2_DivisionName.Text = EmptyString(e.Item.Cells[0].Text);
               // LoadEntityLocationLookup(Tab2_CountryList, -1);
                LoadCountryList(Tab2_CountryList);
                LoadSupervisorsListLookupByDivisionID(Tab2_SuperVisorList, Int32.Parse(Tab2_DivisionID.Text));
                LoadDivisionLocationList(Int32.Parse(Tab2_DivisionID.Text));
                  Grid.EditItemIndex = -1;
            }
          

        }
     
       protected void Grid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            int divisionID = (int)Grid.DataKeys[(int)e.Item.ItemIndex];
            Grid.EditItemIndex = -1;
            DeleteDivision(divisionID);
        }
        protected void LGrid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            LGrid.CurrentPageIndex = e.NewPageIndex;
            //LoadDataList();
        }
        protected void LGrid_EditCommand(object source, DataGridCommandEventArgs e)
        {
            Tab2_KeyField.Text = LGrid.DataKeys[e.Item.ItemIndex].ToString(); // LocationID 
            DivisionName.Text = EmptyString(e.Item.Cells[0].Text);
            Int32 DivisionID = Int32.Parse(EmptyString(e.Item.Cells[1].Text));
            LoadSupervisorsListLookupByDivisionID(SupervisorDDList,DivisionID);            
            if (EmptyString(e.Item.Cells[8].Text.Trim()) != "")
            {        

                try
                {
                    Tab2_CountryList.SelectedValue = Tab2_CountryList.Items.FindByValue(e.Item.Cells[8].Text.Trim()).Value;
                   
                }
                catch(Exception exception)
                {
                    Tab2_CountryList.SelectedValue = "-1";
                    ErrorLogging.LogError(exception, "");
                }
            }
            if (EmptyString(e.Item.Cells[3].Text.Trim()) != "")
            {
                try
                {
                    Tab2_SuperVisorList.SelectedValue = Tab2_SuperVisorList.Items.FindByText(e.Item.Cells[3].Text.Trim()).Value;
                }
                catch(Exception exception)
                {
                    Tab2_SuperVisorList.SelectedValue = "-1";
                    ErrorLogging.LogError(exception, "");
                }
            }
            Tab2_EmployerID.Text = EmptyString(e.Item.Cells[4].Text);
            Tab2_EmployerRef.Text = EmptyString(e.Item.Cells[5].Text);
            Tab2_EmployerRoutingCode.Text = EmptyString(e.Item.Cells[6].Text);
            Tab2_GLCode.Text = EmptyString(e.Item.Cells[7].Text);
            Tab2_CountryList.Enabled = false;
            LGrid.EditItemIndex = -1;
        }

        protected void LGrid_ItemCommand(object sender, DataGridCommandEventArgs e)
        {
           if (e.CommandName == "Select")
            {
                ManageCRUD.Visible = false;
                ManagelocationDept.Visible = true;
                Managelocation.Visible = false;
                Tab2_KeyField.Text = LGrid.DataKeys[e.Item.ItemIndex].ToString();// LocationID
                Tab3_LocationID.Text = LGrid.DataKeys[e.Item.ItemIndex].ToString();
                Tab3_DivisionName.Text = EmptyString(e.Item.Cells[0].Text);
                Tab3_DivisionID.Text = EmptyString(e.Item.Cells[1].Text);
                LoadEntityLocationLookup(Tab3_CountryList, Int32.Parse(Tab3_DivisionID.Text));
                try
                    {
                        Tab3_CountryList.SelectedValue = Tab3_CountryList.Items.FindByValue(Tab3_LocationID.Text).Value;
                    }
                    catch(Exception exception)
                    {
                        Tab3_CountryList.SelectedValue = "-1";
                        ErrorLogging.LogError(exception, "");
                    }
                LoadDepartmentLookup(Tab3_DepartmentList);
                LoadSupervisorsListLookupByDivisionID(Tab3_SuperVisorList, Int32.Parse(Tab3_DivisionID.Text));
                LoadDivisionLocationDeptList(Int32.Parse(Tab2_DivisionID.Text),Int32.Parse(Tab2_KeyField.Text));
            }
            LGrid.EditItemIndex = -1;

        }

        protected void LGrid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            int LocationID = (int)LGrid.DataKeys[(int)e.Item.ItemIndex];
            LGrid.EditItemIndex = -1;
           // DeleteDivisionLocation(Int32.Parse(Tab2_DivisionID.Text), LocationID);

        }
        protected void DGrid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            DGrid.CurrentPageIndex = e.NewPageIndex;
            //LoadDataList();
        }
        protected void DGrid_EditCommand(object source, DataGridCommandEventArgs e)
        {
          //  Tab3_KeyField.Text = DGrid.DataKeys[e.Item.ItemIndex].ToString();
            Tab3_DivisionName.Text = EmptyString(e.Item.Cells[0].Text);
            Tab3_DivisionID.Text = EmptyString(e.Item.Cells[1].Text);
            Tab3_LocationID.Text = EmptyString(e.Item.Cells[3].Text);
            if (EmptyString(e.Item.Cells[2].Text.Trim()) != "")
            {


                try
                {
                    Tab3_CountryList.SelectedValue = Tab3_CountryList.Items.FindByText(e.Item.Cells[2].Text.Trim()).Value;

                }
                catch (Exception exception)
                {
                    Tab3_CountryList.SelectedValue = "-1";
                    ErrorLogging.LogError(exception, "");
                }
            }
            try
               {
                  Tab3_DepartmentList.SelectedValue = Tab3_DepartmentList.Items.FindByText(e.Item.Cells[4].Text).Value;
                }
            catch(Exception exception)
              {
                 Tab3_DepartmentList.SelectedValue = "-1";
                 ErrorLogging.LogError(exception, "");
                }
             try
                {
                    Tab3_SuperVisorList.SelectedValue = Tab3_SuperVisorList.Items.FindByText(e.Item.Cells[5].Text).Value;
                }
                catch (Exception exception)
                {
                    Tab3_SuperVisorList.SelectedValue = "-1";
                    ErrorLogging.LogError(exception, "");
                }
            Tab3_GLCode.Text = EmptyString(e.Item.Cells[6].Text);
            DGrid.EditItemIndex = -1;
            Tab3_DepartmentList.Enabled = false;

        }

        protected void DGrid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            int divisionID = (int)DGrid.DataKeys[(int)e.Item.ItemIndex];
            DGrid.EditItemIndex = -1;
            // DeleteDivision(divisionID);
        }
        protected void Grid_CancelCommand(object source, DataGridCommandEventArgs e)
        {
            Grid.EditItemIndex = -1;
            LoadDataList();
        }
        protected void Grid_UpdateCommand(object source, DataGridCommandEventArgs e)
        {
           
        }
    }
}

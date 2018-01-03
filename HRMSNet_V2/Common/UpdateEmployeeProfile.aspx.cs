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
    public partial class UpdateEmployeeProfile : SchoolNetBase
    {
        public int EmpId;
        protected void Page_Load(object sender, EventArgs e)
        {
            EmpId = Int32.Parse(Page.User.Identity.Name.ToString());
            if (!Page.IsPostBack)
            {
                //LoadGenderType(Tab1_GenderType);
                LoadMaritalStatus(Tab1_MaritalStatus);
                LoadSalutationType(Tab1_SaluationType);
                LoadEducationList(Tab1_Education);
                LoadCountryList(Tab1_CountryDDList);
                LoadCountryList(Tab1_WCountryDDList);
                LoadKeyEmployeeInformation(EmpId);
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
            Save_Employee.Click += new EventHandler(Save_Employee_Click);

        }
        #endregion

        protected void LoadKeyEmployeeInformation(Int32 EmpId)
        {
            DataSet _DataList = null;
            _DataList = DatabaseManager.Data.DBAccessManager.RetrieveKeyEmpInfo(EmpId);
            if (_DataList.Tables.Count > 0)
            {
                DataRow _DataRow = _DataList.Tables[0].Rows[0];
                Tab1_FName.Text = _DataRow["F_Name"].ToString();
                Tab1_MidName.Text = _DataRow["Mid_Initial"].ToString();
                Tab1_LName.Text = _DataRow["L_Name"].ToString();
                Tab1_KeyField.Text = _DataRow["EmpId"].ToString();
               
                //if (_DataRow["GenderID"].ToString() != "")
               // {
                //    Tab1_GenderType.SelectedValue = _DataRow["GenderID"].ToString();
               // }
                if (_DataRow["EducationID"].ToString() != "")
                {
                    Tab1_Education.SelectedValue = _DataRow["EducationID"].ToString();
                }
                if (_DataRow["MaritalStatus_ID"].ToString() != "")
                {
                    Tab1_MaritalStatus.SelectedValue = _DataRow["MaritalStatus_ID"].ToString();
                }
                Tab1_HAddress1.Text = _DataRow["Home_addr1"].ToString();
                Tab1_HAddress2.Text = _DataRow["Home_addr2"].ToString();
                Tab1_HCity.Text = _DataRow["City"].ToString();
                Tab1_HState.Text = _DataRow["Home_State"].ToString();
                if (_DataRow["Home_CountryID"].ToString() != "")
                {
                    Tab1_CountryDDList.SelectedValue = _DataRow["Home_CountryID"].ToString();
                }
                Tab1_WAddress1.Text = _DataRow["Work_Addr1"].ToString();
                Tab1_WAddress2.Text = _DataRow["Work_Addr2"].ToString();
                Tab1_WCity.Text = _DataRow["WORK_CITY"].ToString();
                Tab1_WState.Text = _DataRow["WORK_STATE"].ToString();
                if (_DataRow["Work_CountryID"].ToString() != "")
                {
                    Tab1_WCountryDDList.SelectedValue = _DataRow["Work_CountryID"].ToString();
                }
                Tab1_HPhone.Text = _DataRow["Home_Phone"].ToString();
                Tab1_WPhone.Text = _DataRow["WORK_PHONE"].ToString();
                Tab1_Mobile.Text = _DataRow["MOBILE_PHONE"].ToString();
                Tab1_WorkEmail.Text = _DataRow["WORK_EMAIL"].ToString();

                        
            }


        }
        protected void Save_Employee_Click(object sender, EventArgs e)
        {
            Int32 PhotoProfile; String PhotoPath; String FilePath;
            try
            {
                if (Page.IsValid == true)
                {

                    if (Tab1_ProfilePhoto.PostedFile != null && Tab1_ProfilePhoto.PostedFile.FileName != "") // Checked Photo is uploaded.
                    {
                        HttpPostedFile myFile = Tab1_ProfilePhoto.PostedFile;
                        String Ext = System.IO.Path.GetExtension(myFile.FileName);
                        FilePath = Server.MapPath(Page.ResolveUrl("~\\PhotoProfiles\\" + Tab1_FName.Text.ToString() + "_" + Tab1_LName.Text.ToString() + Ext));
                        myFile.SaveAs(FilePath);
                        PhotoPath = Tab1_FName.Text.ToString() + "_" + Tab1_LName.Text.ToString() + Ext;
                        PhotoProfile = 1;

                    }
                    else
                    {
                        PhotoPath = "";
                        PhotoProfile = 0;

                    }

                    String Result = DatabaseManager.Data.DBAccessManager.Update_Emp_ContactInfo(Int32.Parse(Tab1_KeyField.Text.ToString()), Tab1_HAddress1.Text.ToString(), Tab1_HAddress2.Text.ToString(), Tab1_HCity.Text.ToString(), Tab1_HState.Text.ToString(), Int32.Parse(Tab1_CountryDDList.SelectedValue), Tab1_WAddress1.Text.ToString(), Tab1_WAddress2.Text.ToString(), Tab1_WCity.Text.ToString(), Tab1_WState.Text.ToString(), Int32.Parse(Tab1_WCountryDDList.SelectedValue), Tab1_HPhone.Text.ToString(), Tab1_Mobile.Text.ToString(), Tab1_WPhone.Text.ToString(), Tab1_WorkEmail.Text.ToString(), Int32.Parse(Tab1_MaritalStatus.SelectedValue), Int32.Parse(Tab1_Education.SelectedValue), PhotoProfile, PhotoPath);

                    this.message.Visible = true;
                    if (Result == "")
                    {
                        this.message.Text = "Successfully saved.";
                        this.message.CssClass = "errorMessage";
                    }
                    else
                    {
                        //System.IO.File.Delete(FilePath);
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
        
    }
}

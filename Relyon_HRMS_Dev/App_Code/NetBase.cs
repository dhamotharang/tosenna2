using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Collections;
using System.Globalization;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using DatabaseManager.Data;
using PresentationManager.Web.UI.MasterPages;

namespace SchoolNet
{
	/// <summary>
	/// Summary description for SchoolNetBase
	/// </summary>
	public class SchoolNetBase : PresentationManager.Web.UI.MasterPages.MasterPage
	{
		
      //  protected	HtmlGenericControl		masterCss;
       // protected System.Web.UI.WebControls.DataGrid DivGrid;

        protected System.Web.UI.WebControls.Label UserName;
        protected System.Web.UI.WebControls.PlaceHolder EmployeeMenu;
        protected System.Web.UI.WebControls.PlaceHolder AdminMenu;
        protected System.Web.UI.WebControls.PlaceHolder SupervisorMenu;
        protected System.Web.UI.WebControls.PlaceHolder PayrollMenu;
        protected System.Web.UI.WebControls.PlaceHolder EntryClerkMenu;
			
		public Int32 CurrentPage
		{
			get
			{
				object obj = this.ViewState["_CurrentPage"];
				if (obj  == null )
				{
					return 0;
				}
				else
				{
					return (int) obj;
				}
			}
			set
			{
				this.ViewState["_CurrentPage"] = value;
			}

		}

		#region OnInit
		protected override void OnInit(EventArgs e)
		{
			this.Response.Expires = -1;
			this.Response.ExpiresAbsolute = DateTime.Now.AddDays(-1f);
			this.Response.AddHeader("Pragma", "no-cache");
			this.Response.CacheControl = "no-cache";
			base.OnInit(e);

			for(Int32 i = 0; i < this.Validators.Count; i++)
			{
				((System.Web.UI.WebControls.BaseValidator)this.Validators[i]).EnableClientScript = false;
			}

			this.LoadData();
           
		
		}
		#endregion


		#region OnPreRender
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender (e);
			//this.masterCss.Attributes["href"] = "DefaultTheme.css"; //default

		}
		#endregion

		
		#region LoadData
		/// <summary>
		/// To retrieve data from database 
		/// </summary>
		protected  void LoadData()
		{

             if (Page.User.Identity.Name.ToString() != null && Page.User.Identity.Name.ToString() != "")
            {
                if (Session["MemberName"] == null)
                {
                    DataSet _DataList = null;
                    _DataList = DBAccessManager.GetSessionInfo(Int32.Parse(Page.User.Identity.Name.ToString()));
                    if (_DataList.Tables.Count > 0)
                    {
                        DataRow _DataRow = _DataList.Tables[0].Rows[0];
                        Session["MemberEmail"] = _DataRow["Work_Email"].ToString();
                        Session["MemberName"] = _DataRow["MemberName"].ToString();
                    }

                }

                 if (Page.User.IsInRole("Employee"))
                 {
                    
                     this.AdminMenu.Visible = false;                     
                     this.SupervisorMenu.Visible = false;
                     this.PayrollMenu.Visible = false;
                     this.EmployeeMenu.Visible = true;

                 }
                 if (Page.User.IsInRole("HR Administrator"))
                 {
                     this.AdminMenu.Visible = true;
                     this.EmployeeMenu.Visible = false;
                     this.SupervisorMenu.Visible = false;
                     this.PayrollMenu.Visible = false;
                 }
                 if (Page.User.IsInRole("Supervisor"))
                 {
                     this.AdminMenu.Visible = false;
                     this.EmployeeMenu.Visible = false;
                     this.SupervisorMenu.Visible = true;
                     this.PayrollMenu.Visible = false;
                 }
                 if (Page.User.IsInRole("Payroll Administrator"))
                 {
                     this.AdminMenu.Visible = false;
                     this.EmployeeMenu.Visible = false;
                     this.SupervisorMenu.Visible = false;
                     this.PayrollMenu.Visible = true;
                 }
                 if (Page.User.IsInRole("Data Entry Clerk"))
                 {
                     this.AdminMenu.Visible = false;
                     this.EmployeeMenu.Visible = false;
                     this.SupervisorMenu.Visible = false;
                     this.PayrollMenu.Visible = false;
                     this.EntryClerkMenu.Visible = true;
                 }
                 this.UserName.Text = "Welcome " + "  " + Session["MemberName"].ToString();
                 this.UserName.CssClass = "mainheadtxt4";
          }
           else
          {
              this.UserName.Visible = false;
              this.UserName.Text = "";
          }
			
		}
		#endregion
        #region LoadLanguages()
        protected void LoadLanguages(DropDownList eLang)
        {
            try
            {

                DatabaseManager.Data.NamedCollection[] LangList = DatabaseManager.Data.DBAccessManager.RetrieveLanguagesLookup();


                if (eLang == null)
                    return;

                if (LangList != null)
                {
                    DatabaseManager.Data.NamedCollection List_tmp = null;
                    eLang.Items.Clear();
                    eLang.Items.Add(new ListItem("Select Language", "-1"));
                    for (Int32 i = 0; i < LangList.Length; i++)
                    {
                        List_tmp = LangList[i];

                        eLang.Items.Add(new ListItem(List_tmp.Name, List_tmp.Id.ToString(CultureInfo.InvariantCulture)));
                    }

                    eLang.SelectedIndex = -1;
                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }
        }
        #endregion

        #region LoadSkillLevelType()
        protected void LoadSkillLevelType(DropDownList eSkillCatType)
        {
            try
            {

                DatabaseManager.Data.NamedCollection[] SkillCatList = DatabaseManager.Data.DBAccessManager.RetrieveSkillLevelLookup();


                if (eSkillCatType == null)
                    return;

                if (SkillCatList != null)
                {
                    DatabaseManager.Data.NamedCollection List_tmp = null;
                    eSkillCatType.Items.Clear();
                    eSkillCatType.Items.Add(new ListItem("Select Skill Level", "-1"));
                    for (Int32 i = 0; i < SkillCatList.Length; i++)
                    {
                        List_tmp = SkillCatList[i];

                        eSkillCatType.Items.Add(new ListItem(List_tmp.Name, List_tmp.Id.ToString(CultureInfo.InvariantCulture)));
                    }

                    eSkillCatType.SelectedIndex = -1;
                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }

        }
       #endregion

        #region LoadSkillCategoryType()
        protected void LoadSkillCategoryType(DropDownList eSkillCatType)
        {
            try
            {

                DatabaseManager.Data.NamedCollection[] SkillCatList = DatabaseManager.Data.DBAccessManager.RetrieveSkillCategoryLookup();


                if (eSkillCatType == null)
                    return;

                if (SkillCatList != null)
                {
                    DatabaseManager.Data.NamedCollection List_tmp = null;
                    eSkillCatType.Items.Clear();
                    for (Int32 i = 0; i < SkillCatList.Length; i++)
                    {
                        List_tmp = SkillCatList[i];

                        eSkillCatType.Items.Add(new ListItem(List_tmp.Name, List_tmp.Id.ToString(CultureInfo.InvariantCulture)));
                    }

                    eSkillCatType.SelectedIndex = -1;
                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }

        }
        #endregion

        #region LoadSkillsList()
        protected void LoadSkillsList(DropDownList eSkill,Int32 skillCatID)
        {
            try
            {
                DatabaseManager.Data.NamedCollection[] SkillList = DatabaseManager.Data.DBAccessManager.RetrieveSkillsLookup(skillCatID);


                if (eSkill == null)
                    return;

                if (SkillList != null)
                {
                    DatabaseManager.Data.NamedCollection List_tmp = null;
                    eSkill.Items.Clear();
                    for (Int32 i = 0; i < SkillList.Length; i++)
                    {
                        List_tmp = SkillList[i];

                        eSkill.Items.Add(new ListItem(List_tmp.Name, List_tmp.Id.ToString(CultureInfo.InvariantCulture)));
                    }

                    eSkill.SelectedIndex = -1;
                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }

        }
        #endregion

 
        #region LoadTrainingType()
        protected void LoadTrainingType(DropDownList eTrainingType)
        {
            try
            {
                DatabaseManager.Data.NamedCollection[] TrainingTypeList = DatabaseManager.Data.DBAccessManager.RetrieveTrainingTypeLookup();


                if (eTrainingType == null)
                    return;

                if (TrainingTypeList != null)
                {
                    DatabaseManager.Data.NamedCollection List_tmp = null;
                    eTrainingType.Items.Clear();
                    eTrainingType.Items.Add(new ListItem("Select Training Type", "-1"));
                    for (Int32 i = 0; i < TrainingTypeList.Length; i++)
                    {
                        List_tmp = TrainingTypeList[i];

                        eTrainingType.Items.Add(new ListItem(List_tmp.Name, List_tmp.Id.ToString(CultureInfo.InvariantCulture)));
                    }

                    eTrainingType.SelectedIndex = -1;
                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }

        }
        #endregion

        #region LoadCertificationType()
        protected void LoadCertificationType(DropDownList eCertType)
        {
            try
            {
                DatabaseManager.Data.NamedCollection[] CertList = DatabaseManager.Data.DBAccessManager.RetrieveCertificationTypeLookup();


                if (eCertType == null)
                    return;

                if (CertList != null)
                {
                    DatabaseManager.Data.NamedCollection List_tmp = null;
                    eCertType.Items.Clear();
                    // eSalutation.Items.Add(new ListItem("Select Employee Category", "-1"));
                    for (Int32 i = 0; i < CertList.Length; i++)
                    {
                        List_tmp = CertList[i];

                        eCertType.Items.Add(new ListItem(List_tmp.Name, List_tmp.Id.ToString(CultureInfo.InvariantCulture)));
                    }

                    eCertType.SelectedIndex = -1;
                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }

        }
        #endregion

        #region LoadRoleTypeLookup()
        protected void LoadRoleTypeLookup(DropDownList eRoleType)
        {
            try
            {
                DatabaseManager.Data.NamedCollection[] RoleList = DatabaseManager.Data.DBAccessManager.RetrieveRoleTypeLookup();


                if (eRoleType == null)
                    return;

                if (RoleList != null)
                {
                    DatabaseManager.Data.NamedCollection List_tmp = null;
                    eRoleType.Items.Clear();
                    // eSalutation.Items.Add(new ListItem("Select Employee Category", "-1"));
                    for (Int32 i = 0; i < RoleList.Length; i++)
                    {
                        List_tmp = RoleList[i];

                        eRoleType.Items.Add(new ListItem(List_tmp.Name, List_tmp.Id.ToString(CultureInfo.InvariantCulture)));
                    }

                    eRoleType.SelectedIndex = -1;
                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }

        }
       #endregion

        #region LoadLeavePeriodLookup()
        protected void LoadLeavePeriodLookup(DropDownList eLeavePeriod)
        {
            try
            {

                DatabaseManager.Data.NamedCollection[] LeavePeriodList = DatabaseManager.Data.DBAccessManager.RetrieveLeavePeriodLookup();


                if (eLeavePeriod == null)
                    return;

                if (LeavePeriodList != null)
                {
                    DatabaseManager.Data.NamedCollection List_tmp = null;
                    eLeavePeriod.Items.Clear();
                    // eSalutation.Items.Add(new ListItem("Select Employee Category", "-1"));
                    for (Int32 i = 0; i < LeavePeriodList.Length; i++)
                    {
                        List_tmp = LeavePeriodList[i];

                        eLeavePeriod.Items.Add(new ListItem(List_tmp.Name, List_tmp.Id.ToString(CultureInfo.InvariantCulture)));
                    }

                    eLeavePeriod.SelectedIndex = -1;
                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }

        }
        #endregion
        #region LoadLeaveTypeLookup()
        protected void LoadLeaveTypeLookup(DropDownList eLeaveType)
        {
            try
            {
                DatabaseManager.Data.NamedCollection[] LeaveTypeList = DatabaseManager.Data.DBAccessManager.RetrieveLeaveTypeLookup();


                if (eLeaveType == null)
                    return;

                if (LeaveTypeList != null)
                {
                    DatabaseManager.Data.NamedCollection List_tmp = null;
                    eLeaveType.Items.Clear();
                    // eSalutation.Items.Add(new ListItem("Select Employee Category", "-1"));
                    for (Int32 i = 0; i < LeaveTypeList.Length; i++)
                    {
                        List_tmp = LeaveTypeList[i];

                        eLeaveType.Items.Add(new ListItem(List_tmp.Name, List_tmp.Id.ToString(CultureInfo.InvariantCulture)));
                    }

                    eLeaveType.SelectedIndex = -1;
                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }

        }
        #endregion
        #region LoadRequestStatusTypeLookup()
        protected void LoadRequestStatusTypeLookup(DropDownList eStatusType)
        {
            try
            {
                DatabaseManager.Data.NamedCollection[] StatusTypeList = DatabaseManager.Data.DBAccessManager.RetrieveRequestStatusTypeLookup();


                if (eStatusType == null)
                    return;

                if (StatusTypeList != null)
                {
                    DatabaseManager.Data.NamedCollection List_tmp = null;
                    eStatusType.Items.Clear();
                    // eSalutation.Items.Add(new ListItem("Select Employee Category", "-1"));
                    for (Int32 i = 0; i < StatusTypeList.Length; i++)
                    {
                        List_tmp = StatusTypeList[i];

                        eStatusType.Items.Add(new ListItem(List_tmp.Name, List_tmp.Id.ToString(CultureInfo.InvariantCulture)));
                    }

                    eStatusType.SelectedIndex = -1;
                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }

        }
        #endregion

        #region LoadDayTypeLookup()
        protected void LoadDayTypeLookup(DropDownList eDayType)
        {
            try
            {
                DatabaseManager.Data.NamedCollection[] DayTypeList = DatabaseManager.Data.DBAccessManager.RetrieveDayTypeLookup();


                if (eDayType == null)
                    return;

                if (DayTypeList != null)
                {
                    DatabaseManager.Data.NamedCollection List_tmp = null;
                    eDayType.Items.Clear();
                    // eSalutation.Items.Add(new ListItem("Select Employee Category", "-1"));
                    for (Int32 i = 0; i < DayTypeList.Length; i++)
                    {
                        List_tmp = DayTypeList[i];

                        eDayType.Items.Add(new ListItem(List_tmp.Name, List_tmp.Id.ToString(CultureInfo.InvariantCulture)));
                    }

                    eDayType.SelectedIndex = -1;
                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }

        }
        #endregion

        #region LoadSalutationType()
        protected void LoadSalutationType(DropDownList eSalutation)
        {
            try
            {
                DatabaseManager.Data.NamedCollection[] SalutationList = DatabaseManager.Data.DBAccessManager.RetrieveSalutationType();


                if (eSalutation == null)
                    return;

                if (SalutationList != null)
                {
                    DatabaseManager.Data.NamedCollection List_tmp = null;
                    eSalutation.Items.Clear();
                    // eSalutation.Items.Add(new ListItem("Select Employee Category", "-1"));
                    for (Int32 i = 0; i < SalutationList.Length; i++)
                    {
                        List_tmp = SalutationList[i];

                        eSalutation.Items.Add(new ListItem(List_tmp.Name, List_tmp.Id.ToString(CultureInfo.InvariantCulture)));
                    }

                    eSalutation.SelectedIndex = -1;
                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }

        }
        #endregion
        #region LoadEducationList()
        protected void LoadEducationList(DropDownList eEducation)
        {
            try
            {
                DatabaseManager.Data.NamedCollection[] EducationList = DatabaseManager.Data.DBAccessManager.RetrieveEducationLookup();


                if (eEducation == null)
                    return;

                if (EducationList != null)
                {
                    DatabaseManager.Data.NamedCollection List_tmp = null;
                    eEducation.Items.Clear();
                    eEducation.Items.Add(new ListItem("Select Education", "-1"));
                    for (Int32 i = 0; i < EducationList.Length; i++)
                    {
                        List_tmp = EducationList[i];

                        eEducation.Items.Add(new ListItem(List_tmp.Name, List_tmp.Id.ToString(CultureInfo.InvariantCulture)));
                    }

                    eEducation.SelectedIndex = -1;
                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }

        }
        #endregion
        #region LoadEmpCategoryLookup()
        protected void LoadEmpCategoryLookup(DropDownList eCategory)
        {

            try
            {
                DatabaseManager.Data.NamedCollection[] EmpCatList = DatabaseManager.Data.DBAccessManager.RetrieveEmpCategoryLookup();


                if (eCategory == null)
                    return;

                if (EmpCatList != null)
                {
                    DatabaseManager.Data.NamedCollection List_tmp = null;
                    eCategory.Items.Clear();
                    eCategory.Items.Add(new ListItem("Select Employee Category", "-1"));
                    for (Int32 i = 0; i < EmpCatList.Length; i++)
                    {
                        List_tmp = EmpCatList[i];

                        eCategory.Items.Add(new ListItem(List_tmp.Name, List_tmp.Id.ToString(CultureInfo.InvariantCulture)));
                    }

                    eCategory.SelectedIndex = -1;
                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }

        }
        #endregion

        #region LoadDepartmentLookup()
        protected void LoadDepartmentLookup(DropDownList eDept)
        {
            try
            {
                DatabaseManager.Data.NamedCollection[] DeptList = DatabaseManager.Data.DBAccessManager.RetrieveDepartmentLookup();


                if (eDept == null)
                    return;

                if (DeptList != null)
                {
                    DatabaseManager.Data.NamedCollection List_tmp = null;
                    eDept.Items.Clear();
                    eDept.Items.Add(new ListItem("Select Department", "-1"));
                    for (Int32 i = 0; i < DeptList.Length; i++)
                    {
                        List_tmp = DeptList[i];

                        eDept.Items.Add(new ListItem(List_tmp.Name, List_tmp.Id.ToString(CultureInfo.InvariantCulture)));
                    }

                    eDept.SelectedIndex = -1;
                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }

        }
        #endregion

        #region LoadGenderType()
        protected void LoadGenderType(DropDownList eGenderType)
        {
            try
            {
                DatabaseManager.Data.NamedCollection[] GenderTypeList = DatabaseManager.Data.DBAccessManager.RetrieveGenderType();


                if (eGenderType == null)
                    return;

                if (GenderTypeList != null)
                {
                    DatabaseManager.Data.NamedCollection List_tmp = null;
                    eGenderType.Items.Clear();
                    eGenderType.Items.Add(new ListItem("Select Gender Type", "-1"));
                    for (Int32 i = 0; i < GenderTypeList.Length; i++)
                    {
                        List_tmp = GenderTypeList[i];

                        eGenderType.Items.Add(new ListItem(List_tmp.Name, List_tmp.Id.ToString(CultureInfo.InvariantCulture)));
                    }

                    eGenderType.SelectedIndex = -1;
                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }

        }
        #endregion
        #region ContactPriorityType()
        protected void ContactPriorityType(DropDownList eContactType)
        {
            try
            {
                DatabaseManager.Data.NamedCollection[] ContactPriorityTypeList = DatabaseManager.Data.DBAccessManager.RetrieveContactPriorityType();


                if (eContactType == null)
                    return;

                if (ContactPriorityTypeList != null)
                {
                    DatabaseManager.Data.NamedCollection List_tmp = null;
                    eContactType.Items.Clear();
                    eContactType.Items.Add(new ListItem("Select Contact Priority", "-1"));
                    for (Int32 i = 0; i < ContactPriorityTypeList.Length; i++)
                    {
                        List_tmp = ContactPriorityTypeList[i];

                        eContactType.Items.Add(new ListItem(List_tmp.Name, List_tmp.Id.ToString(CultureInfo.InvariantCulture)));
                    }

                    eContactType.SelectedIndex = -1;
                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }

        }
        #endregion

        #region LoadRelationShipType()
        protected void LoadRelationshipType(DropDownList eRelationship)
        {
            try
            {
                DatabaseManager.Data.NamedCollection[] RelationShipTypeList = DatabaseManager.Data.DBAccessManager.RetrieveRelationShipType();

                if (eRelationship == null)
                    return;

                if (RelationShipTypeList != null)
                {
                    DatabaseManager.Data.NamedCollection List_tmp = null;
                    eRelationship.Items.Clear();
                    eRelationship.Items.Add(new ListItem("Select Relationship Type", "-1"));
                    for (Int32 i = 0; i < RelationShipTypeList.Length; i++)
                    {
                        List_tmp = RelationShipTypeList[i];

                        eRelationship.Items.Add(new ListItem(List_tmp.Name, List_tmp.Id.ToString(CultureInfo.InvariantCulture)));
                    }

                    eRelationship.SelectedIndex = -1;
                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }

        }
        #endregion

        #region LoadMaritalStatus()
        protected void LoadMaritalStatus(DropDownList eMaritalStatus)
        {
            try
            {
                DatabaseManager.Data.NamedCollection[] MaritalStatusList = DatabaseManager.Data.DBAccessManager.RetrieveMaritalStatusList();


                if (eMaritalStatus == null)
                    return;

                if (MaritalStatusList != null)
                {
                    DatabaseManager.Data.NamedCollection List_tmp = null;
                    eMaritalStatus.Items.Clear();
                    eMaritalStatus.Items.Add(new ListItem("Select Marital Status", "-1"));
                    for (Int32 i = 0; i < MaritalStatusList.Length; i++)
                    {
                        List_tmp = MaritalStatusList[i];

                        eMaritalStatus.Items.Add(new ListItem(List_tmp.Name, List_tmp.Id.ToString(CultureInfo.InvariantCulture)));
                    }

                    eMaritalStatus.SelectedIndex = -1;
                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }

        }
        #endregion

        #region LoadEthnicity()
        protected void LoadEthnicity(DropDownList eEthnicity)
        {
            try
            {
                DatabaseManager.Data.NamedCollection[] EthnicityList = DatabaseManager.Data.DBAccessManager.RetrieveEthnicityList();


                if (eEthnicity == null)
                    return;

                if (EthnicityList != null)
                {
                    DatabaseManager.Data.NamedCollection List_tmp = null;
                    eEthnicity.Items.Clear();
                    eEthnicity.Items.Add(new ListItem("Select Ethnicity", "-1"));
                    for (Int32 i = 0; i < EthnicityList.Length; i++)
                    {
                        List_tmp = EthnicityList[i];

                        eEthnicity.Items.Add(new ListItem(List_tmp.Name, List_tmp.Id.ToString(CultureInfo.InvariantCulture)));
                    }

                    eEthnicity.SelectedIndex = -1;
                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }

        }
        #endregion
        #region LoadExpiryAlertDataType()
        protected void LoadExpiryAlertDataType(DropDownList eAlertType)
        {
            try
            {
                DatabaseManager.Data.NamedCollection[] eAlertTypeList = DatabaseManager.Data.DBAccessManager.RetrieveAlertExpiryDataType();
                if (eAlertType == null) return;
                if (eAlertTypeList != null)
                {
                    DatabaseManager.Data.NamedCollection List_tmp = null;
                    eAlertType.Items.Clear();
                    eAlertType.Items.Add(new ListItem("Select Data Type", "-1"));
                    for (Int32 i = 0; i < eAlertTypeList.Length; i++)
                    {
                        List_tmp = eAlertTypeList[i];

                        eAlertType.Items.Add(new ListItem(List_tmp.Name, List_tmp.Id.ToString(CultureInfo.InvariantCulture)));
                    }

                    eAlertType.SelectedIndex = -1;
                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }

        }
        #endregion
        #region LoadMissingDataType()
        protected void LoadMissingDataType(DropDownList eAlertType)
        {
            try
            {
                DatabaseManager.Data.NamedCollection[] eAlertTypeList = DatabaseManager.Data.DBAccessManager.RetrieveMissingDataType();
                if (eAlertType == null) return;
                if (eAlertTypeList != null)
                {
                    DatabaseManager.Data.NamedCollection List_tmp = null;
                    eAlertType.Items.Clear();
                    eAlertType.Items.Add(new ListItem("Select Data Type", "-1"));
                    for (Int32 i = 0; i < eAlertTypeList.Length; i++)
                    {
                        List_tmp = eAlertTypeList[i];

                        eAlertType.Items.Add(new ListItem(List_tmp.Name, List_tmp.Id.ToString(CultureInfo.InvariantCulture)));
                    }

                    eAlertType.SelectedIndex = -1;
                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }

        }
        #endregion


        #region LoadImportDataType()
        protected void LoadImportDataType(DropDownList eImportType)
        {
            try
            {
                DatabaseManager.Data.NamedCollection[] eImportTypeList = DatabaseManager.Data.DBAccessManager.RetrieveImportDataType();
                if (eImportType == null)  return;
                if (eImportTypeList != null)
                {
                    DatabaseManager.Data.NamedCollection List_tmp = null;
                    eImportType.Items.Clear();
                    eImportType.Items.Add(new ListItem("Select Data Type", "-1"));
                    for (Int32 i = 0; i < eImportTypeList.Length; i++)
                    {
                        List_tmp = eImportTypeList[i];

                        eImportType.Items.Add(new ListItem(List_tmp.Name, List_tmp.Id.ToString(CultureInfo.InvariantCulture)));
                    }

                    eImportType.SelectedIndex = -1;
                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }

        }
        #endregion


        #region LoadVisaType()
        protected void LoadVisaType(DropDownList eVisaType)
        {
            try
            {
                DatabaseManager.Data.NamedCollection[] VisatTypeList = DatabaseManager.Data.DBAccessManager.RetrieveVisaType();


                if (eVisaType == null)
                    return;

                if (VisatTypeList != null)
                {
                    DatabaseManager.Data.NamedCollection List_tmp = null;
                    eVisaType.Items.Clear();
                    eVisaType.Items.Add(new ListItem("Select Visa Type", "-1"));
                    for (Int32 i = 0; i < VisatTypeList.Length; i++)
                    {
                        List_tmp = VisatTypeList[i];

                        eVisaType.Items.Add(new ListItem(List_tmp.Name, List_tmp.Id.ToString(CultureInfo.InvariantCulture)));
                    }

                    eVisaType.SelectedIndex = -1;
                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }

        }
        #endregion

        #region LoadCountryList()
        protected void LoadCountryList(DropDownList eCountry)
        {
            try
            {
                DatabaseManager.Data.NamedCollection[] CountryList = DatabaseManager.Data.DBAccessManager.RetrieveCountryList();


                if (eCountry == null)
                    return;

                if (CountryList != null)
                {
                    DatabaseManager.Data.NamedCollection List_tmp = null;
                    eCountry.Items.Clear();
                    eCountry.Items.Add(new ListItem("Select Country", "-1"));
                    for (Int32 i = 0; i < CountryList.Length; i++)
                    {
                        List_tmp = CountryList[i];

                        eCountry.Items.Add(new ListItem(List_tmp.Name, List_tmp.Id.ToString(CultureInfo.InvariantCulture)));
                    }

                    eCountry.SelectedIndex = -1;
                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }

        }
        #endregion

        #region LoadCountryListByEmpId()
        protected void LoadCountryListByEmpId(DropDownList eCountry, Int32 EmpId)
        {
            try
            {
                DatabaseManager.Data.NamedCollection[] CountryList = DatabaseManager.Data.DBAccessManager.RetrieveCountryListByEmpID(EmpId);


                if (eCountry == null)
                    return;

                if (CountryList != null)
                {
                    DatabaseManager.Data.NamedCollection List_tmp = null;
                    eCountry.Items.Clear();
                    eCountry.Items.Add(new ListItem("Select Country", "-1"));
                    for (Int32 i = 0; i < CountryList.Length; i++)
                    {
                        List_tmp = CountryList[i];

                        eCountry.Items.Add(new ListItem(List_tmp.Name, List_tmp.Id.ToString(CultureInfo.InvariantCulture)));
                    }

                    eCountry.SelectedIndex = -1;
                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }

        }
        #endregion


        #region LoadEmpStatusLookup()
        protected void LoadEmpStatusLookup(DropDownList eStatusList)
        {
            try
            {
                DatabaseManager.Data.NamedCollection[] EmpStatusList = DatabaseManager.Data.DBAccessManager.RetrieveEmpStatusLookup((int)Constants.EmpStatusType.AllEmpStatus);


                if (eStatusList == null)
                    return;

                if (EmpStatusList != null)
                {
                    DatabaseManager.Data.NamedCollection List_tmp = null;
                    eStatusList.Items.Clear();
                    eStatusList.Items.Add(new ListItem("Select Employee Status", "-1"));
                    for (Int32 i = 0; i < EmpStatusList.Length; i++)
                    {
                        List_tmp = EmpStatusList[i];

                        eStatusList.Items.Add(new ListItem(List_tmp.Name, List_tmp.Id.ToString(CultureInfo.InvariantCulture)));
                    }

                    eStatusList.SelectedIndex = -1;
                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }

        }
        #endregion
        #region LoadEmpStatusLookupByType()
        protected void LoadEmpStatusLookupByType(DropDownList eStatusList, Int32 Type )
        {
            try
            {

                DatabaseManager.Data.NamedCollection[] EmpStatusList = DatabaseManager.Data.DBAccessManager.RetrieveEmpStatusLookup(Type);


                if (eStatusList == null)
                    return;

                if (EmpStatusList != null)
                {
                    DatabaseManager.Data.NamedCollection List_tmp = null;
                    eStatusList.Items.Clear();
                    eStatusList.Items.Add(new ListItem("Select Employee Status", "-1"));
                    for (Int32 i = 0; i < EmpStatusList.Length; i++)
                    {
                        List_tmp = EmpStatusList[i];

                        eStatusList.Items.Add(new ListItem(List_tmp.Name, List_tmp.Id.ToString(CultureInfo.InvariantCulture)));
                    }

                    eStatusList.SelectedIndex = -1;
                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }

        }
        #endregion

        #region LoadDivisionLookup()
        protected void LoadDivisionLookup(DropDownList buList)
        {
            try
            {
                DatabaseManager.Data.NamedCollection[] DivisionList = DatabaseManager.Data.DBAccessManager.RetrieveDivisionLookup();


                if (buList == null)
                    return;

                if (DivisionList != null)
                {
                    DatabaseManager.Data.NamedCollection List_tmp = null;
                    buList.Items.Clear();
                    buList.Items.Add(new ListItem("Select Business Unit", "-1"));
                    for (Int32 i = 0; i < DivisionList.Length; i++)
                    {
                        List_tmp = DivisionList[i];

                        buList.Items.Add(new ListItem(List_tmp.Name, List_tmp.Id.ToString(CultureInfo.InvariantCulture)));
                    }

                    buList.SelectedIndex = -1;
                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }

        }
        #endregion
        #region LoadDivisionLookup2()
        protected void LoadDivisionLookup2(DropDownList buList)
        {
            try
            {
                DatabaseManager.Data.NamedCollection[] DivisionList = DatabaseManager.Data.DBAccessManager.RetrieveDivisionLookup();


                if (buList == null)
                    return;

                if (DivisionList != null)
                {
                    DatabaseManager.Data.NamedCollection List_tmp = null;
                    buList.Items.Clear();
                    buList.Items.Add(new ListItem("All Business Units", "-1"));
                    for (Int32 i = 0; i < DivisionList.Length; i++)
                    {
                        List_tmp = DivisionList[i];

                        buList.Items.Add(new ListItem(List_tmp.Name, List_tmp.Id.ToString(CultureInfo.InvariantCulture)));
                    }

                    buList.SelectedIndex = -1;
                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }

        }
        #endregion

        #region LoadDivisionLookupByEmpId()
        protected void LoadDivisionLookupByEmpId(DropDownList buList, Int32 EmpId)
        {
            try
            {
                DatabaseManager.Data.NamedCollection[] DivisionList = DatabaseManager.Data.DBAccessManager.RetrieveDivisionLookupByEmpId(EmpId);
                if (buList == null)
                    return;

                if (DivisionList != null)
                {
                    DatabaseManager.Data.NamedCollection List_tmp = null;
                    buList.Items.Clear();
                    if (DivisionList.Length > 1)
                    {
                        buList.Items.Add(new ListItem("All Business Units", "-1"));
                    }
                    for (Int32 i = 0; i < DivisionList.Length; i++)
                    {
                        List_tmp = DivisionList[i];

                        buList.Items.Add(new ListItem(List_tmp.Name, List_tmp.Id.ToString(CultureInfo.InvariantCulture)));
                    }

                    buList.SelectedIndex = -1;
                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }

        }
        #endregion   

        #region LoadDepartmentLookupByDivisionId()
        protected void LoadDepartmentLookupByDivisionId(DropDownList buList, Int32 DivisionID)
        {
            try
            {
                DatabaseManager.Data.NamedCollection[] DivisionList = DatabaseManager.Data.DBAccessManager.RetrieveDepartmentLookupByDivisionID(DivisionID);
                if (buList == null)
                    return;

                if (DivisionList != null)
                {
                    DatabaseManager.Data.NamedCollection List_tmp = null;
                    buList.Items.Clear();
                    if (DivisionList.Length > 1)
                    {
                        buList.Items.Add(new ListItem("Select Department", "-1"));
                    }
                    for (Int32 i = 0; i < DivisionList.Length; i++)
                    {
                        List_tmp = DivisionList[i];

                        buList.Items.Add(new ListItem(List_tmp.Name, List_tmp.Id.ToString(CultureInfo.InvariantCulture)));
                    }

                    buList.SelectedIndex = -1;
                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }

        }
        #endregion   


        #region LoadDesignationLookup()
        protected void LoadDesignationLookup(DropDownList jobTitleList)
        {
            try
            {
                DatabaseManager.Data.NamedCollection[] DesignationList = DatabaseManager.Data.DBAccessManager.RetrieveDesignationLookup();


                if (jobTitleList == null)
                    return;

                if (DesignationList != null)
                {
                    DatabaseManager.Data.NamedCollection List_tmp = null;
                    jobTitleList.Items.Clear();
                    jobTitleList.Items.Add(new ListItem("Select Job Title", "-1"));
                    for (Int32 i = 0; i < DesignationList.Length; i++)
                    {
                        List_tmp = DesignationList[i];

                        jobTitleList.Items.Add(new ListItem(List_tmp.Name, List_tmp.Id.ToString(CultureInfo.InvariantCulture)));
                    }

                    jobTitleList.SelectedIndex = -1;
                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }

        }
        #endregion
        #region LoadDocumentType()
        protected void LoadDocumentType(DropDownList eDocType)
        {
            try
            {
                DatabaseManager.Data.NamedCollection[] DocTypeList = DatabaseManager.Data.DBAccessManager.RetrieveDocumentType();


                if (eDocType == null)
                    return;

                if (DocTypeList != null)
                {
                    DatabaseManager.Data.NamedCollection List_tmp = null;
                    eDocType.Items.Clear();
                    eDocType.Items.Add(new ListItem("Select Document Type", "-1"));
                    for (Int32 i = 0; i < DocTypeList.Length; i++)
                    {
                        List_tmp = DocTypeList[i];

                        eDocType.Items.Add(new ListItem(List_tmp.Name, List_tmp.Id.ToString(CultureInfo.InvariantCulture)));
                    }

                    eDocType.SelectedIndex = -1;
                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }

        }
       #endregion
       
        #region LoadPayType()
        protected void LoadPayType(DropDownList ePayType)
        {
            try
            {
                DatabaseManager.Data.NamedCollection[] PayTypeList = DatabaseManager.Data.DBAccessManager.RetrievePayType();


                if (ePayType == null)
                    return;

                if (PayTypeList != null)
                {
                    DatabaseManager.Data.NamedCollection List_tmp = null;
                    ePayType.Items.Clear();
                    ePayType.Items.Add(new ListItem("Select Pay Type", "-1"));
                    for (Int32 i = 0; i < PayTypeList.Length; i++)
                    {
                        List_tmp = PayTypeList[i];

                        ePayType.Items.Add(new ListItem(List_tmp.Name, List_tmp.Id.ToString(CultureInfo.InvariantCulture)));
                    }

                    ePayType.SelectedIndex = -1;
                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }

        }
        #endregion
        #region LoadPayPlanType()
        protected void LoadPayPlanType(DropDownList ePayPlanType)
        {
            try
            {
                DatabaseManager.Data.NamedCollection[] PayPlanTypeList = DatabaseManager.Data.DBAccessManager.RetrievePayPlanType();


                if (ePayPlanType == null)
                    return;

                if (PayPlanTypeList != null)
                {
                    DatabaseManager.Data.NamedCollection List_tmp = null;
                    ePayPlanType.Items.Clear();
                    ePayPlanType.Items.Add(new ListItem("Select Pay Plan", "-1"));
                    for (Int32 i = 0; i < PayPlanTypeList.Length; i++)
                    {
                        List_tmp = PayPlanTypeList[i];

                        ePayPlanType.Items.Add(new ListItem(List_tmp.Name, List_tmp.Id.ToString(CultureInfo.InvariantCulture)));
                    }

                    ePayPlanType.SelectedIndex = -1;
                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }

        }
        #endregion
        #region LoadPayFrequencyType()
        protected void LoadPayFrequencyType(DropDownList ePayFreqType)
        {
            try
            {
                DatabaseManager.Data.NamedCollection[] PayFreqTypeList = DatabaseManager.Data.DBAccessManager.RetrievePayFrequencyType();


                if (ePayFreqType == null)
                    return;

                if (PayFreqTypeList != null)
                {
                    DatabaseManager.Data.NamedCollection List_tmp = null;
                    ePayFreqType.Items.Clear();
                    ePayFreqType.Items.Add(new ListItem("Select Pay Frequency", "-1"));
                    for (Int32 i = 0; i < PayFreqTypeList.Length; i++)
                    {
                        List_tmp = PayFreqTypeList[i];

                        ePayFreqType.Items.Add(new ListItem(List_tmp.Name, List_tmp.Id.ToString(CultureInfo.InvariantCulture)));
                    }

                    ePayFreqType.SelectedIndex = 1; //default Monthly option
                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }

        }
       #endregion
       #region LoadCalcMethodType()
        protected void LoadCalcMethodType(DropDownList eCalcMethodType)
        {
            try
            {
                DatabaseManager.Data.NamedCollection[] CalcMethodTypeList = DatabaseManager.Data.DBAccessManager.RetrieveCalcMethodType();


                if (eCalcMethodType == null)
                    return;

                if (CalcMethodTypeList != null)
                {
                    DatabaseManager.Data.NamedCollection List_tmp = null;
                    eCalcMethodType.Items.Clear();
                    eCalcMethodType.Items.Add(new ListItem("Select Calc Method", "-1"));
                    for (Int32 i = 0; i < CalcMethodTypeList.Length; i++)
                    {
                        List_tmp = CalcMethodTypeList[i];

                        eCalcMethodType.Items.Add(new ListItem(List_tmp.Name, List_tmp.Id.ToString(CultureInfo.InvariantCulture)));
                    }

                    eCalcMethodType.SelectedIndex = -1;
                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }

        }
        #endregion 
        #region LoadSupervisorsListLookup()
        protected void LoadSupervisorsListLookup(DropDownList eDrop)
        {
            try
            {
                DatabaseManager.Data.NamedCollection[] ValueList = DatabaseManager.Data.DBAccessManager.RetrieveSuperVisorsListLookup();


                if (eDrop == null)
                    return;

                if (ValueList != null)
                {
                    DatabaseManager.Data.NamedCollection List_tmp = null;
                    eDrop.Items.Clear();
                    eDrop.Items.Add(new ListItem("Select Supervisor", "-1"));
                    for (Int32 i = 0; i < ValueList.Length; i++)
                    {
                        List_tmp = ValueList[i];

                        eDrop.Items.Add(new ListItem(List_tmp.Name, List_tmp.Id.ToString(CultureInfo.InvariantCulture)));
                    }

                    eDrop.SelectedIndex = -1;
                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }

        }
       #endregion 

        #region LoadSupervisorsListLookupByDivisionID()
        protected void LoadSupervisorsListLookupByDivisionID(DropDownList eDrop, Int32 DivisionID)
        {
            try
            {
                DatabaseManager.Data.NamedCollection[] ValueList = DatabaseManager.Data.DBAccessManager.RetrieveSuperVisorsListLookupByDivisionID(DivisionID);


                if (eDrop == null)
                    return;

                if (ValueList != null)
                {
                    DatabaseManager.Data.NamedCollection List_tmp = null;
                    eDrop.Items.Clear();
                    eDrop.Items.Add(new ListItem("Select Supervisor", "-1"));
                    for (Int32 i = 0; i < ValueList.Length; i++)
                    {
                        List_tmp = ValueList[i];

                        eDrop.Items.Add(new ListItem(List_tmp.Name, List_tmp.Id.ToString(CultureInfo.InvariantCulture)));
                    }

                    eDrop.SelectedIndex = -1;
                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }

        }
        #endregion 

        #region LoadEntityLocationLookup()
        protected void LoadEntityLocationLookup(DropDownList eDrop, Int32 DivisionID)
        {
            try
            {
                DatabaseManager.Data.NamedCollection[] ValueList = DatabaseManager.Data.DBAccessManager.RetrieveEntityLocationLookup(DivisionID);


                if (eDrop == null)
                    return;

                if (ValueList != null)
                {
                    DatabaseManager.Data.NamedCollection List_tmp = null;
                    eDrop.Items.Clear();
                    eDrop.Items.Add(new ListItem("All", "-1"));
                    for (Int32 i = 0; i < ValueList.Length; i++)
                    {
                        List_tmp = ValueList[i];

                        eDrop.Items.Add(new ListItem(List_tmp.Name, List_tmp.Id.ToString(CultureInfo.InvariantCulture)));
                    }

                    eDrop.SelectedIndex = -1;
                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }

        }
        #endregion 

        #region LoadEntityLocationLookupByEmpId()
        protected void LoadEntityLocationLookupByEmpId(DropDownList eDrop, Int32 EmpId)
        {
            try
            {
                DatabaseManager.Data.NamedCollection[] ValueList = DatabaseManager.Data.DBAccessManager.RetrieveDivisionLocationLookupByEmpId(EmpId);


                if (eDrop == null)
                    return;

                if (ValueList != null)
                {
                    DatabaseManager.Data.NamedCollection List_tmp = null;
                    eDrop.Items.Clear();
                    eDrop.Items.Add(new ListItem("All", "-1"));
                    for (Int32 i = 0; i < ValueList.Length; i++)
                    {
                        List_tmp = ValueList[i];

                        eDrop.Items.Add(new ListItem(List_tmp.Name, List_tmp.Id.ToString(CultureInfo.InvariantCulture)));
                    }

                    eDrop.SelectedIndex = -1;
                }
            }
        
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }

        }
        #endregion 

        #region LoadEntityLocationLookupByEmpId_DivisionID()
        protected void LoadEntityLocationLookupByEmpId_DivisionID(DropDownList eDrop, Int32 EmpId, Int32 DivisionID)
        {
            try
            {
                DatabaseManager.Data.NamedCollection[] ValueList = DatabaseManager.Data.DBAccessManager.RetrieveDivisonLocationLookupByEmpId_DivisionID(EmpId, DivisionID);


                if (eDrop == null)
                    return;

                if (ValueList != null)
                {
                    DatabaseManager.Data.NamedCollection List_tmp = null;
                    eDrop.Items.Clear();
                   // if (ValueList.Length > 1)
                    //{
                        eDrop.Items.Add(new ListItem("Select Location", "-1"));
                    //}
                    for (Int32 i = 0; i < ValueList.Length; i++)
                    {
                        List_tmp = ValueList[i];

                        eDrop.Items.Add(new ListItem(List_tmp.Name, List_tmp.Id.ToString(CultureInfo.InvariantCulture)));
                    }

                    eDrop.SelectedIndex = -1;
                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }

        }
        #endregion 

        #region LoadOfficeLocationLookupByDivisionID_LocationID()
        protected void LoadOfficeLocationLookupByDivisionID_LocationID(DropDownList eDrop, Int32 DivisionID, Int32 LocationID)
        {
            try
            {
                DatabaseManager.Data.NamedCollection[] ValueList = DatabaseManager.Data.DBAccessManager.RetrieveOfficeLocationLookupByDivisionID_LocationID(DivisionID,LocationID);
                if (eDrop == null)return;
                if (ValueList != null)
                {
                    DatabaseManager.Data.NamedCollection List_tmp = null;
                    eDrop.Items.Clear();
                    // if (ValueList.Length > 1)
                    //{
                    eDrop.Items.Add(new ListItem("All", "-1"));
                    //}
                    for (Int32 i = 0; i < ValueList.Length; i++)
                    {
                        List_tmp = ValueList[i];

                        eDrop.Items.Add(new ListItem(List_tmp.Name, List_tmp.Id.ToString(CultureInfo.InvariantCulture)));
                    }

                    eDrop.SelectedIndex = -1;
                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }

        }
        #endregion 

        
        #region LoadEntityLocationLookupByEmpId_DivisionID()
        protected void LoadEntityLocationLookupByDivisionID(DropDownList eDrop, Int32 DivisionID)
        {
            try
            {
                DatabaseManager.Data.NamedCollection[] ValueList = DatabaseManager.Data.DBAccessManager.RetrieveDivisonLocationLookupByDivisionID(DivisionID);


                if (eDrop == null)
                    return;

                if (ValueList != null)
                {
                    DatabaseManager.Data.NamedCollection List_tmp = null;
                    eDrop.Items.Clear();
                    eDrop.Items.Add(new ListItem("Select Location", "-1"));
                    for (Int32 i = 0; i < ValueList.Length; i++)
                    {
                        List_tmp = ValueList[i];

                        eDrop.Items.Add(new ListItem(List_tmp.Name, List_tmp.Id.ToString(CultureInfo.InvariantCulture)));
                    }

                    eDrop.SelectedIndex = -1;
                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }

        }
        #endregion 
        #region LoadEmployeeListLookupByEmpId()
        protected void LoadEmployeeListLookupByEmpId(DropDownList eDrop, Int32 EmpID)
        {
            try
            {
                DatabaseManager.Data.NamedCollection[] ValueList = DatabaseManager.Data.DBAccessManager.RetrieveEmployeeListLookupByEmpId(EmpID);


                if (eDrop == null)
                    return;

                if (ValueList != null)
                {
                    DatabaseManager.Data.NamedCollection List_tmp = null;
                    eDrop.Items.Clear();
                    eDrop.Items.Add(new ListItem("Select Employee", "-1"));
                    for (Int32 i = 0; i < ValueList.Length; i++)
                    {
                        List_tmp = ValueList[i];

                        eDrop.Items.Add(new ListItem(List_tmp.Name, List_tmp.Id.ToString(CultureInfo.InvariantCulture)));
                    }

                    eDrop.SelectedIndex = -1;
                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }

        }
       #endregion 

        #region RetrieveBankingListLookup()
        protected void LoadBankingListLookup(DropDownList eDrop)
        {
            try
            {
                DatabaseManager.Data.NamedCollection[] ValueList = DatabaseManager.Data.DBAccessManager.RetrieveBankingListLookup();


                if (eDrop == null)
                    return;

                if (ValueList != null)
                {
                    DatabaseManager.Data.NamedCollection List_tmp = null;
                    eDrop.Items.Clear();
                    eDrop.Items.Add(new ListItem("Select Bank Name", "-1"));
                    for (Int32 i = 0; i < ValueList.Length; i++)
                    {
                        List_tmp = ValueList[i];

                        eDrop.Items.Add(new ListItem(List_tmp.Name, List_tmp.Id.ToString(CultureInfo.InvariantCulture)));
                    }

                    eDrop.SelectedIndex = -1;
                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }

        }
        #endregion 

        #region LoadPayComponentTypeLookup()
        protected void LoadPayComponentTypeLookup(DropDownList eDrop)
        {
            try
            {
                DatabaseManager.Data.NamedCollection[] ValueList = DatabaseManager.Data.DBAccessManager.RetrievePayComponentTypeLookup();


                if (eDrop == null)
                    return;

                if (ValueList != null)
                {
                    DatabaseManager.Data.NamedCollection List_tmp = null;
                    eDrop.Items.Clear();
                    eDrop.Items.Add(new ListItem("Select Pay Component Type", "-1"));
                    for (Int32 i = 0; i < ValueList.Length; i++)
                    {
                        List_tmp = ValueList[i];

                        eDrop.Items.Add(new ListItem(List_tmp.Name, List_tmp.Id.ToString(CultureInfo.InvariantCulture)));
                    }

                    eDrop.SelectedIndex = -1;
                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }

        }
        #endregion 

        #region RetrievePayComponentListByCompTypeID()
        protected void RetrievePayComponentListByCompTypeID(DropDownList eDrop, Int32 PayComponentTypeID, Int32 PayFrequencyTypeID)
        {
            try
            {
                DatabaseManager.Data.NamedCollection[] ValueList = DatabaseManager.Data.DBAccessManager.RetrievePayComponentListByCompTypeID(PayComponentTypeID, PayFrequencyTypeID);
                if (eDrop == null)
                    return;

                if (ValueList != null)
                {
                    DatabaseManager.Data.NamedCollection List_tmp = null;
                    eDrop.Items.Clear();
                    eDrop.Items.Add(new ListItem("Select Pay Component Name", "-1"));
                    for (Int32 i = 0; i < ValueList.Length; i++)
                    {
                        List_tmp = ValueList[i];

                        eDrop.Items.Add(new ListItem(List_tmp.Name, List_tmp.Id.ToString(CultureInfo.InvariantCulture)));
                    }

                    eDrop.SelectedIndex = -1;
                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }

        }
        #endregion 
        

        #region RetrievePayrollStatusLookup()
        protected void LoadPayrollStatusTypeLookup(DropDownList eDrop,Int32 PayrollStageID)
        {
            try
            {
                DatabaseManager.Data.NamedCollection[] ValueList = DatabaseManager.Data.DBAccessManager.RetrievePayrollStatusLookup(PayrollStageID);


                if (eDrop == null)
                    return;

                if (ValueList != null)
                {
                    DatabaseManager.Data.NamedCollection List_tmp = null;
                    eDrop.Items.Clear();
                    //eDrop.Items.Add(new ListItem("Select Payroll Status", "-1"));
                    for (Int32 i = 0; i < ValueList.Length; i++)
                    {
                        List_tmp = ValueList[i];

                        eDrop.Items.Add(new ListItem(List_tmp.Name, List_tmp.Id.ToString(CultureInfo.InvariantCulture)));
                    }

                    eDrop.SelectedIndex = -1;
                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }

        }
        #endregion 

        #region LoadRequestTypeLookup()
        protected void LoadRequestTypeLookup(DropDownList eDrop, Int32 EmpId)
        {
            try
            {
                DatabaseManager.Data.NamedCollection[] ValueList = DatabaseManager.Data.DBAccessManager.RetrieveRequestTypeLookup(EmpId);


                if (eDrop == null)
                    return;

                if (ValueList != null)
                {
                    DatabaseManager.Data.NamedCollection List_tmp = null;
                    eDrop.Items.Clear();
                    eDrop.Items.Add(new ListItem("Select Request Type", "-1"));
                    for (Int32 i = 0; i < ValueList.Length; i++)
                    {
                        List_tmp = ValueList[i];

                        eDrop.Items.Add(new ListItem(List_tmp.Name, List_tmp.Id.ToString(CultureInfo.InvariantCulture)));
                    }

                    eDrop.SelectedIndex = -1;
                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }

        }
        #endregion 
        #region LoadNewHiresList()
        protected void LoadNewHiresList(DropDownList eDrop, Int32 RequestingEmpId,Int32 EmpStatusType)
        {
            try
            {
                DatabaseManager.Data.NamedCollection[] ValueList = DatabaseManager.Data.DBAccessManager.RetrieveNewHiresListLookup(RequestingEmpId, EmpStatusType);

                if (eDrop == null)
                    return;

                if (ValueList != null)
                {
                    DatabaseManager.Data.NamedCollection List_tmp = null;
                    eDrop.Items.Clear();
                    eDrop.Items.Add(new ListItem("Select the employee", "-1"));
                    for (Int32 i = 0; i < ValueList.Length; i++)
                    {
                        List_tmp = ValueList[i];

                        eDrop.Items.Add(new ListItem(List_tmp.Name, List_tmp.Id.ToString(CultureInfo.InvariantCulture)));
                    }

                    eDrop.SelectedIndex = -1;
                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }

        }
        #endregion 

        #region LoadGratuityTypeList()
        protected void LoadGratuityTypeList(DropDownList eDrop)
        {
            try
            {
                DatabaseManager.Data.NamedCollection[] ValueList = DatabaseManager.Data.DBAccessManager.RetrieveGratuityTypeLookup();

                if (eDrop == null)
                    return;

                if (ValueList != null)
                {
                    DatabaseManager.Data.NamedCollection List_tmp = null;
                    eDrop.Items.Clear();
                    eDrop.Items.Add(new ListItem("Select Gratuity Type", "-1"));
                    for (Int32 i = 0; i < ValueList.Length; i++)
                    {
                        List_tmp = ValueList[i];

                        eDrop.Items.Add(new ListItem(List_tmp.Name, List_tmp.Id.ToString(CultureInfo.InvariantCulture)));
                    }

                    eDrop.SelectedIndex = -1;
                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }

        }
        #endregion 
        
        #region LoadCompanyRegionList()
        protected void LoadCompanyRegionList(DropDownList eDrop)
        {

            try
            {
                DatabaseManager.Data.NamedCollection[] ValueList = DatabaseManager.Data.DBAccessManager.RetrieveCompanyRegionLookup();

                if (eDrop == null)
                    return;

                if (ValueList != null)
                {
                    DatabaseManager.Data.NamedCollection List_tmp = null;
                    eDrop.Items.Clear();
                    eDrop.Items.Add(new ListItem("Select Region", "-1"));
                    for (Int32 i = 0; i < ValueList.Length; i++)
                    {
                        List_tmp = ValueList[i];

                        eDrop.Items.Add(new ListItem(List_tmp.Name, List_tmp.Id.ToString(CultureInfo.InvariantCulture)));
                    }

                    eDrop.SelectedIndex = -1;
                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }

        }
        #endregion 
        #region LoadPrivilegedUsersList()
        protected void LoadPrivilegedUsersList(DropDownList eDrop, Int32 RequestorID)
        {

            try
            {
                DatabaseManager.Data.NamedCollection[] ValueList = DatabaseManager.Data.DBAccessManager.RetrievePrivilegedUsersLookupByEmpId(RequestorID);

                if (eDrop == null)
                    return;

                if (ValueList != null)
                {
                    DatabaseManager.Data.NamedCollection List_tmp = null;
                    eDrop.Items.Clear();
                    eDrop.Items.Add(new ListItem("Select User Name", "-1"));
                    for (Int32 i = 0; i < ValueList.Length; i++)
                    {
                        List_tmp = ValueList[i];

                        eDrop.Items.Add(new ListItem(List_tmp.Name, List_tmp.Id.ToString(CultureInfo.InvariantCulture)));
                    }

                    eDrop.SelectedIndex = -1;
                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }

        }
        #endregion 
        #region LoadSubOrdinatesList()
        protected void LoadSubOrdinatesList(DropDownList eDrop, Int32 RequestorID)
        {

            try
            {
                DatabaseManager.Data.NamedCollection[] ValueList = DatabaseManager.Data.DBAccessManager.RetrieveSubOrdinatesListByEmpId(RequestorID);

                if (eDrop == null)
                    return;

                if (ValueList != null)
                {
                    DatabaseManager.Data.NamedCollection List_tmp = null;
                    eDrop.Items.Clear();
                    eDrop.Items.Add(new ListItem("All SubOrdinates", "-1"));
                    for (Int32 i = 0; i < ValueList.Length; i++)
                    {
                        List_tmp = ValueList[i];

                        eDrop.Items.Add(new ListItem(List_tmp.Name, List_tmp.Id.ToString(CultureInfo.InvariantCulture)));
                    }

                    eDrop.SelectedIndex = -1;
                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }

        }
        #endregion 
        #region LoadWorkCityList()
        protected void LoadWorkCityList(DropDownList eDrop)
        {

            try
            {
                DatabaseManager.Data.NamedCollection[] ValueList = DatabaseManager.Data.DBAccessManager.RetrieveWorkCityList();

                if (eDrop == null)
                    return;

                if (ValueList != null)
                {
                    DatabaseManager.Data.NamedCollection List_tmp = null;
                    eDrop.Items.Clear();
                    eDrop.Items.Add(new ListItem("Select a location", "-1"));
                    for (Int32 i = 0; i < ValueList.Length; i++)
                    {
                        List_tmp = ValueList[i];

                        eDrop.Items.Add(new ListItem(List_tmp.Name, List_tmp.Id.ToString(CultureInfo.InvariantCulture)));
                    }

                    eDrop.SelectedIndex = -1;
                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }

        }
        #endregion 



        #region LoadBusinessWeekTypeList()
        protected void LoadBusinessWeekTypeList(DropDownList eDrop)
        {
            try
            {
                DatabaseManager.Data.NamedCollection[] ValueList = DatabaseManager.Data.DBAccessManager.RetrieveBusinessWeekTypeLookup();

                if (eDrop == null)
                    return;

                if (ValueList != null)
                {
                    DatabaseManager.Data.NamedCollection List_tmp = null;
                    eDrop.Items.Clear();
                    eDrop.Items.Add(new ListItem("Select Business Week", "-1"));
                    for (Int32 i = 0; i < ValueList.Length; i++)
                    {
                        List_tmp = ValueList[i];

                        eDrop.Items.Add(new ListItem(List_tmp.Name, List_tmp.Id.ToString(CultureInfo.InvariantCulture)));
                    }

                    eDrop.SelectedIndex = -1;
                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }

        }
        #endregion 

        #region LoadRequestImplTypeLookup()
        protected void LoadRequestImplTypeLookup(ListBox eListBox, Int32 RequestingEmpId)
        {
            try
            {
                DataSet _DataList = null;
                _DataList = DatabaseManager.Data.DBAccessManager.RetrieveRequestImplTypes(RequestingEmpId);
                eListBox.Items.Clear();


                if (_DataList.Tables.Count > 0)
                {
                    if (_DataList.Tables[0].Rows.Count > 0) // Leave Request Information.
                    {
                        eListBox.DataSource = _DataList;
                        eListBox.DataTextField = "RequestImplTypeName";
                        eListBox.DataValueField = "RequestImplTypeID";
                        eListBox.DataBind();
                    }
                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError(exception, "");
            }

        }
       #endregion 

       protected string GetSelectedItems(ListBox lbx)
       {
           string selectedValues = ""; 
           foreach (ListItem listItem in lbx.Items)
           {
            if (listItem.Selected)
            {
                if (selectedValues != "")
                { selectedValues = selectedValues + ';' + listItem.Text; }
                else
                { selectedValues = listItem.Text; }
            }
           }
           return selectedValues;
       }

        protected String  ConvertDMY_MDY(TextBox dateTextBox)
        {
            if (dateTextBox.Text.ToString() != "")
            {
                return DateTime.Parse(dateTextBox.Text.ToString(), CultureInfo.GetCultureInfo("en-GB")).ToString();
            }
            else { return dateTextBox.Text.ToString(); }

        }

        protected String EmptyString(String TableCellText)
        {
            if (TableCellText == "&nbsp;")
            {
                return TableCellText = "";
            }
            else { return TableCellText.Trim(); }
        }
        protected String NumericCheck_EmptyString(String TableCellText)
        {
            if (TableCellText == "")
            {
                return TableCellText = "0";
            }
            else { return TableCellText.Trim(); }
        }

        protected String FormatTwoDecimals(String TableCellText)
        {
            if (TableCellText != "")
            {
                String result = decimal.Round(decimal.Parse(TableCellText), 2).ToString();
                return result;
            }
            else { return TableCellText.Trim(); }
        }
        protected bool CheckEmail(string EmailAddress)
        {

            string ValidationExpression = "^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$";
            //string strPattern = "^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (System.Text.RegularExpressions.Regex.IsMatch(EmailAddress, ValidationExpression))
            { return true; }
            else { return false; }
        }

        //this function Convert to Encode your Password 
        public static string EncodePasswordToBase64(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        } //this function Convert to Decode your Password

        //this function Convert to Decord your Password
        public static string DecodeFrom64(string encodedData)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encodedData);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new String(decoded_char);
            return result;
        }

        //Gets or Sets the GridView SortDirection Property
        public string GridViewSortDirection
        {
            get
            {
                return ViewState["SortDirection"] as string ?? "ASC";
            }
            set
            {
                ViewState["SortDirection"] = value;
            }
        }
        //Gets or Sets the GridView SortExpression Property
        public string GridViewSortExpression
        {
            get
            {
                return ViewState["SortExpression"] as string ?? string.Empty;
            }
            set
            {
                ViewState["SortExpression"] = value;
            }
        }

        //Toggles between the Direction of the Sorting
        public string GetSortDirection()
        {
            switch (GridViewSortDirection)
            {
                case "ASC":
                    GridViewSortDirection = "DESC";
                    break;
                case "DESC":
                    GridViewSortDirection = "ASC";
                    break;
            }
            return GridViewSortDirection;
        }

        //Sorts the ResultSet based on the SortExpression and the Selected Column.
        protected DataView SortDataTable(DataTable myDataTable, bool isPageIndexChanging)
        {
            if (myDataTable != null)
            {
                DataView myDataView = new DataView(myDataTable);
                if (GridViewSortExpression != string.Empty)
                {
                    if (isPageIndexChanging)
                    {
                        myDataView.Sort = string.Format("{0} {1}",
                        GridViewSortExpression, GridViewSortDirection);
                    }
                    else
                    {
                        myDataView.Sort = string.Format("{0} {1}",
                        GridViewSortExpression, GetSortDirection());
                    }
                }
                return myDataView;
            }
            else
            {

                return new DataView();
            }
        }

        public DataSet GetViewState()
        {
            //Gets the ViewState
            return (DataSet)ViewState["myDataSet"];
        }

        public void SetViewState(DataSet myDataSet)
        {
            //Sets the ViewState
            ViewState["myDataSet"] = myDataSet;
        }
	}
}

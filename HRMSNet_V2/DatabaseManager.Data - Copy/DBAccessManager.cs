using System;
using System.Data;
using System.Data.SqlClient;

namespace DatabaseManager.Data
{
	/// <summary>
	/// Summary description for DBAccessManager.
	/// </summary>
	

		public sealed class DBAccessManager
		{
			#region Constructor
			private DBAccessManager()
			{
			}
			#endregion

			// See Sample Below to return the data in dataTable.

			#region RetrieveStateWiseCityList
			public static NamedCollection[] RetrieveStateWiseCityList(int StateID)
			{
			
				SqlParameter[] parameters = new SqlParameter[1];

				parameters[0] = new SqlParameter("@StateID", SqlDbType.Int);
				parameters[0].Value = StateID;
				return RetrieveCollection("spGetStateWiseCityList", parameters);
			

			}
			#endregion
            // End of Sample.    
			#region RetrieveStateList
			public static NamedCollection[] RetrieveStateList()
			{
			
				return RetrieveCollection("spGetStateList", null);

			}
			#endregion
            #region RetrieveCurrencyListLookup
            public static NamedCollection[] RetrieveCurrencyListLookup()
            {

                return RetrieveCollection("spGetCurrencyListLookUp", null);

            }
           #endregion

            #region RetrievePayComponentTypeLookup
            public static NamedCollection[] RetrievePayComponentTypeLookup()
            {

                return RetrieveCollection("spGetPayComponentTypeLookup", null);

            }
            #endregion
            #region RetrieveBusinessWeekTypeLookup
            public static NamedCollection[] RetrieveBusinessWeekTypeLookup()
            {

                return RetrieveCollection("spGetBusinessweekTypeLookup", null);

            }
              #endregion

            #region RetrievePayComponentListByCompTypeID
            public static NamedCollection[] RetrievePayComponentListByCompTypeID(Int32 PayComponentTypeID,Int32 PayFrequencyType)
            {
                SqlParameter[] parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@PayComponentTypeID", SqlDbType.Int);
                parameters[0].Value = PayComponentTypeID;
                parameters[1] = new SqlParameter("@PayFrequencyTypeID", SqlDbType.Int);
                parameters[1].Value = PayFrequencyType;

                return RetrieveCollection("spGetPayComponentLookup", parameters);

            }
            #endregion

            #region RetrievePracticeTypeLookup
            public static NamedCollection[] RetrievePracticeTypeLookup()
            {

                return RetrieveCollection("spGetPracticeLookup", null);

            }
            #endregion
            #region RetrieveJobBandLevelLookup
            public static NamedCollection[] RetrieveJobBandLevelLookup()
            {

                return RetrieveCollection("spGetJobBandLevelLookup", null);

            }
            #endregion

            #region RetrieveCompanyRegionList
            public static NamedCollection[] RetrieveCompanyRegionLookup()
            {

                return RetrieveCollection("spGetCompanyRegionLookup", null);

            }
            #endregion


            #region RetrieveSuperVisorsList
            public static NamedCollection[] RetrieveSuperVisorsListLookup()
            {

                return RetrieveCollection("spGetSupervisorsListLookup", null);

            }
            #endregion
            #region RetrieveSubOrdinatesLookupByMgrID
            public static NamedCollection[] RetrieveSubOrdinatesLookupByMgrID(Int32 ManagerID)
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@ManagerID", SqlDbType.Int);
                parameters[0].Value = ManagerID;
                return RetrieveCollection("spGetSubOrdinatesListLookupByMgrID", parameters);

            }
            #endregion


            #region RetrieveDepartmentLookupByDivisionID
            public static NamedCollection[] RetrieveDepartmentLookupByDivisionID(Int32 DivisionID)
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@DivisionID", SqlDbType.Int);
                parameters[0].Value = DivisionID;
                return RetrieveCollection("spGetDepartmentListLookupByDivisionID", parameters);

            }
            #endregion

            #region RetrieveEOSCalcTypeLookup
            public static NamedCollection[] RetrieveEOSCalcTypeLookup()
            {

                return RetrieveCollection("spGetEOSCalcTypeLookup", null);

            }
           #endregion

            #region RetrieveBankingList
            public static NamedCollection[] RetrieveBankingListLookup()
            {

                return RetrieveCollection("spGetBankingListLookup", null);

            }
            #endregion
            #region RetrievePayrollStatusLookup
            public static NamedCollection[] RetrievePayrollStatusLookup(Int32 PayrollStageID)
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@PayrollStageID", SqlDbType.Int);
                parameters[0].Value = PayrollStageID;
                return RetrieveCollection("spGetPayrollStatusLookup", parameters);

            }
            #endregion

            #region RetrieveSuperVisorsListLookupByDivisionID
            public static NamedCollection[] RetrieveSuperVisorsListLookupByDivisionID(Int32 DivisionID)
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@DivisionID", SqlDbType.Int);
                parameters[0].Value = DivisionID;
                return RetrieveCollection("spGetSupervisorsListLookupByDivisionID", parameters);

            }
            #endregion
     

            #region RetrieveCertificationTypeLookup
            public static NamedCollection[] RetrieveCertificationTypeLookup()
            {

                return RetrieveCollection("spGetCertificationTypeLookup", null);

            }
            #endregion
            #region RetrieveTrainingTypeLookup
            public static NamedCollection[] RetrieveTrainingTypeLookup()
            {

                return RetrieveCollection("spGetTrainingTypeLookup", null);

            }
            #endregion

            #region RetrieveSkillLevelLookup
            public static NamedCollection[] RetrieveSkillLevelLookup()
            {

                return RetrieveCollection("spGetSkillLevelLookup", null);

            }
           #endregion

           #region RetrieveSkillCategoryLookup
            public static NamedCollection[] RetrieveSkillCategoryLookup()
            {

                return RetrieveCollection("spGetSkillCategoryLookup", null);

            }
            #endregion

            #region RetrieveLanguagesLookup
            public static NamedCollection[] RetrieveLanguagesLookup()
            {

                return RetrieveCollection("spGetLanguagesLookup", null);

            }
            #endregion
            #region RetrieveRoleTypeLookup
            public static NamedCollection[] RetrieveRoleTypeLookup()
            {

                return RetrieveCollection("spGetRoleTypeLookup", null);

            }
            #endregion
            #region RetrieveGratuityTypeLookup
            public static NamedCollection[] RetrieveGratuityTypeLookup()
            {

                return RetrieveCollection("spGetGratuityTypeLookup", null);

            }
             #endregion
            #region RetrieveRequestStatusTypeLookup
            public static NamedCollection[] RetrieveRequestStatusTypeLookup()
            {

                return RetrieveCollection("spRequestStatusTypeLookup", null);

            }
            #endregion
            #region RetrieveLeavePeriodLookup
            public static NamedCollection[] RetrieveLeavePeriodLookup()
            {

                return RetrieveCollection("spGetLeavePeriodLookup", null);

            }
          #endregion
            #region RetrieveLeaveTypeLookup
            public static NamedCollection[] RetrieveLeaveTypeLookup()
            {

                return RetrieveCollection("spGetLeaveTypeLookup", null);

            }
            #endregion
            #region RetrieveEducationLookup
            public static NamedCollection[] RetrieveEducationLookup()
            {

                return RetrieveCollection("spGetEducationLookup", null);

            }
            #endregion
            #region RetrieveDayTypeLookup
            public static NamedCollection[] RetrieveDayTypeLookup()
            {

                return RetrieveCollection("spGetDayTypeLookup", null);

            }
            #endregion
            #region RetrieveProjectStatusType
            public static NamedCollection[] RetrieveProjectStatusType()
            {

                return RetrieveCollection("spGetProjectStatusTypeLookup", null);

            }
           #endregion
            #region RetrieveSalutationType
            public static NamedCollection[] RetrieveSalutationType()
            {

                return RetrieveCollection("spGetSalutationType", null);

            }
            #endregion
            #region RetrievePayFrequencyType
            public static NamedCollection[] RetrievePayFrequencyType()
            {

                return RetrieveCollection("spGetPayFrequencyLookup", null);

            }
            #endregion
            #region RetrieveDocumentType
            public static NamedCollection[] RetrieveDocumentType()
            {

                return RetrieveCollection("spGetDocumentTypeLookup", null);

            }
          #endregion
            #region RetrievePayPlanType
            public static NamedCollection[] RetrievePayPlanType()
            {

                return RetrieveCollection("spGetPayPlanLookup", null);

            }
           #endregion
            #region RetrievePayType
            public static NamedCollection[] RetrievePayType()
            {

                return RetrieveCollection("spGetPayTypeLookup", null);

            }
           #endregion
            #region RetrieveCalcMethodType
            public static NamedCollection[] RetrieveCalcMethodType()
            {

                return RetrieveCollection("spGetCalcMethodLookup", null);

            }
           #endregion
            #region RetrieveContactPriorityType
            public static NamedCollection[] RetrieveContactPriorityType()
            {

                return RetrieveCollection("spGetContactPriorityTypes", null);

            }
           #endregion
            #region RetrieveGenderType
            public static NamedCollection[] RetrieveGenderType()
            {

                return RetrieveCollection("spGetGenderType", null);

            }
            #endregion
            #region RetrieveRelationShipType
            public static NamedCollection[] RetrieveRelationShipType()
            {

                return RetrieveCollection("spGetRelationshipType", null);

            }
            #endregion
            #region RetrieveMaritalStatusList
            public static NamedCollection[] RetrieveMaritalStatusList()
            {

                return RetrieveCollection("spGetMaritalStatusList", null);

            }
            #endregion
            #region RetrieveEthnicityList
            public static NamedCollection[] RetrieveEthnicityList()
            {

                return RetrieveCollection("spGetEthnicityList", null);

            }
            #endregion
            #region RetrieveVisaType
            public static NamedCollection[] RetrieveVisaType()
            {

                return RetrieveCollection("spGetVisaType", null);

            }
            #endregion
            #region RetrieveImportDataType
            public static NamedCollection[] RetrieveImportDataType()
            {

                return RetrieveCollection("spGetImportDataType", null);

            }
            #endregion
            #region RetrieveAlertExpiryDataType
            public static NamedCollection[] RetrieveAlertExpiryDataType()
            {

                return RetrieveCollection("spGetExpiryAlertDataType", null);

            }
            #endregion
            #region RetrieveMissingDataType
            public static NamedCollection[] RetrieveMissingDataType()
            {

                return RetrieveCollection("spGetMissingDataType", null);

            }
            #endregion


            #region RetrieveCountryList
            public static NamedCollection[] RetrieveCountryList()
            {

                return RetrieveCollection("spGetCountryList", null);

            }
           #endregion
            #region RetrieveProjectRolesLookUp
            public static NamedCollection[] RetrieveProjectRolesLookUp()
            {

                return RetrieveCollection("spGetRolesLookup", null);

            }
            #endregion
            #region RetrieveCountryListByEmpID
            public static NamedCollection[] RetrieveCountryListByEmpID(Int32 EmpId)
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[0].Value = EmpId;
                return RetrieveCollection("spGetCountryListByEmpID", parameters);

            }
           #endregion

            #region RetrieveProjectEmployeeLookup
            public static NamedCollection[] RetrieveProjectEmployeeLookup(Int32 ProjectID)
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@ProjectID", SqlDbType.Int);
                parameters[0].Value = ProjectID;
                return RetrieveCollection("[spGetProjectEmployeeLookUp]", parameters);

            }
            #endregion

            #region RetrieveEmpStatusLookup
            public static NamedCollection[] RetrieveEmpStatusLookup(Int32 empStatusType)
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@EmpStatusType", SqlDbType.Int);
                parameters[0].Value = empStatusType;

                return RetrieveCollection("[spGetEmpStatusLookup]", parameters);

            }
            #endregion
            #region RetrieveSkillsLookup
            public static NamedCollection[] RetrieveSkillsLookup(Int32 skillCatgID)
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@skillCatgID", SqlDbType.Int);
                parameters[0].Value = skillCatgID;
                return RetrieveCollection("[spGetSkillsLookup]", parameters);

            }
           #endregion
            #region RetrieveNewHiresListLookup
            public static NamedCollection[] RetrieveNewHiresListLookup(Int32 RequestorEmpId, Int32 EmpStatusTypeID)
            {
                SqlParameter[] parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@RequestorEmpId", SqlDbType.Int);
                parameters[0].Value = RequestorEmpId;
                parameters[1] = new SqlParameter("@EmpStatusTypeID", SqlDbType.Int);
                parameters[1].Value = EmpStatusTypeID;

                return RetrieveCollection("[spGetNewHiresListLookup]", parameters);

            }
            #endregion

            #region RetrieveRequestTypeLookup
            public static NamedCollection[] RetrieveRequestTypeLookup(Int32 EmpId)
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[0].Value = EmpId;
                return RetrieveCollection("[spGetRequestTypeLookup]", parameters);

            }
           #endregion
           #region RetrieveRequestImplTypes
            public static DataSet RetrieveRequestImplTypes(Int32 RequestingEmpId)
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[0].Value = RequestingEmpId;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetRequestImplTypes", parameters);
                return dataSet;

            }
          #endregion
          #region RetrieveEmployeeListLBX
            public static DataSet RetrieveEmployeeListLBX(Int32 RequestorID,Int32 ProjectID, Int32 AssignType)
            {
                SqlParameter[] parameters = new SqlParameter[3];
                parameters[0] = new SqlParameter("@RequestorID", SqlDbType.Int);
                parameters[0].Value = RequestorID;
                parameters[1] = new SqlParameter("@ProjectID", SqlDbType.Int);
                parameters[1].Value = ProjectID;
                parameters[2] = new SqlParameter("@AssignType", SqlDbType.Int);
                parameters[2].Value = AssignType;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetEmployeesLBX", parameters);
                return dataSet;

            }
           #endregion

            #region RetrieveDivisionLookupByEmpId
            public static NamedCollection[] RetrieveEmployeeListLookupByEmpId(Int32 EmpId)
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@RequestorEmpID", SqlDbType.Int);
                parameters[0].Value = EmpId;
                return RetrieveCollection("[spGetEmployeeListLookupByDivisionID]", parameters);

            }
            #endregion

           #region RetrieveEntityLocationLookup
            public static NamedCollection[] RetrieveEntityLocationLookup(Int32 DivisionID)
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@DivisionID", SqlDbType.Int);
                parameters[0].Value = DivisionID;
                return RetrieveCollection("[spGetEntityLocationLookup]", parameters);

            }
           #endregion

            #region RetrieveDivisionLookup
            public static NamedCollection[] RetrieveDivisionLookup()
            {

                return RetrieveCollection("[spGetDivisonLookup]", null);

            }
            #endregion

            #region RetrieveDivisionLookupByEmpId
            public static NamedCollection[] RetrieveDivisionLookupByEmpId(Int32 EmpId)
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[0].Value = EmpId;
                return RetrieveCollection("[spGetDivisonLookupByEmpId]", parameters);

            }
            #endregion
            #region RetrieveDivisionLocationLookupByEmpId
            public static NamedCollection[] RetrieveDivisionLocationLookupByEmpId(Int32 EmpId)
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[0].Value = EmpId;
                return RetrieveCollection("[spGetDivisonLocationLookupByEmpId]", parameters);

            }
           #endregion
            #region RetrieveDivisonLocationLookupByEmpId_DivisionID
            public static NamedCollection[] RetrieveDivisonLocationLookupByEmpId_DivisionID(Int32 EmpId,Int32 DivisionID)
            {
                SqlParameter[] parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[0].Value = EmpId;
                parameters[1] = new SqlParameter("@DivisionID", SqlDbType.Int);
                parameters[1].Value = DivisionID;
                return RetrieveCollection("[spGetDivisonLocationLookupByEmpId_DivisionID]", parameters);

            }
            #endregion
            #region RetrieveDivisonLocationLookupByDivisionID
            public static NamedCollection[] RetrieveDivisonLocationLookupByDivisionID(Int32 DivisionID)
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@DivisionID", SqlDbType.Int);
                parameters[0].Value = DivisionID;
                return RetrieveCollection("[spGetDivisonLocationLookupByDivisionID]", parameters);

            }
            #endregion

            #region RetrieveSubOrdinatesListByEmpId
            public static NamedCollection[] RetrieveSubOrdinatesListByEmpId(Int32 EmpId)
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@EmpID", SqlDbType.Int);
                parameters[0].Value = EmpId;
                return RetrieveCollection("[spGetSubOrdinatesLookupByEmpId]", parameters);

            }
            #endregion
            #region RetrieveWorkCityList
            public static NamedCollection[] RetrieveWorkCityList()
            {
                return RetrieveCollection("[spGetOfficeLocationLookup]", null);

            }
            #endregion

            #region RetrievePayComponentList
            public static DataSet RetrievePayComponentList(Int32 PayComponentTypeID)
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@PayComponentTypeID", SqlDbType.Int);
                parameters[0].Value = PayComponentTypeID;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetPayComponentList", parameters);
                return dataSet;

            }
            #endregion

            #region RetrieveDesignationLookup
            public static NamedCollection[] RetrieveDesignationLookup()
            {

                return RetrieveCollection("[spGetDesignationLookup]", null);

            }
            #endregion
            #region RetrieveCustomerLookup
            public static NamedCollection[] RetrieveCustomerLookup()
            {

                return RetrieveCollection("[spGetCustomerLookup]", null);

            }
            #endregion
            #region RetrieveProjectLookup
            public static NamedCollection[] RetrieveProjectLookup(Int32 CustomerID)
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@CustomerID", SqlDbType.Int);
                parameters[0].Value = CustomerID;
                return RetrieveCollection("[spGetProjectLookUpByCustomerID]", parameters);
            }
            #endregion

            #region RetrieveProjectLookupByEmpId
            public static NamedCollection[] RetrieveProjectLookupByEmpId(Int32 EmpId)
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[0].Value = EmpId;
                return RetrieveCollection("[spGetProjectLookUpByEmpId]", parameters);
            }
            #endregion

            #region RetrieveProjectActivityLookup
            public static NamedCollection[] RetrieveProjectActivityLookup(Int32 ProjectID)
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@ProjectID", SqlDbType.Int);
                parameters[0].Value = ProjectID;
                return RetrieveCollection("[spGetProjectActivityLookUpByProjectID]", parameters);
            }
            #endregion

            #region RetrieveProjectActivityLookupByEmpID
            public static NamedCollection[] RetrieveProjectActivityLookupByEmpID(Int32 ProjectID,Int32 EmpID)
            {
                SqlParameter[] parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@ProjectID", SqlDbType.Int);
                parameters[0].Value = ProjectID;
                parameters[1] = new SqlParameter("@EmpID", SqlDbType.Int);
                parameters[1].Value = EmpID;
                return RetrieveCollection("[spGetProjectActivityLookUpByProjectID_EmpID]", parameters);
            }
            #endregion

            #region RetrieveDivisionList
            public static DataSet RetrieveDivisionList(Int32 EmpId)
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[0].Value = EmpId;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetDivisionList", parameters);
                return dataSet;

            }
            #endregion
            #region RetrieveDivisionLocationListByDivisionID
            public static DataSet  RetrieveDivisionLocationListByDivisionID(Int32 DivisionID)
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@DivisionID", SqlDbType.Int);
                parameters[0].Value = DivisionID;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetDivisionLocationList", parameters);
                return dataSet;
            }
             #endregion

            #region RetrieveDivisionLocationDeptList
            public static DataSet RetrieveDivisionLocationDeptList(Int32 DivisionID, Int32 LocationID)
            {
                SqlParameter[] parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@DivisionID", SqlDbType.Int);
                parameters[0].Value = DivisionID;

                parameters[1] = new SqlParameter("@LocationID", SqlDbType.Int);
                parameters[1].Value = LocationID;

                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetDivisionLocationDeptList", parameters);
                return dataSet;
            }
             #endregion
            #region RetrieveEOSGratuityList
            public static DataSet RetrieveEOSGratuityList(Int32 EmpId)
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[0].Value = EmpId;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetGratuityRulesList", parameters);
                return dataSet;
            }
            #endregion



            #region RetrieveBankList
            public static DataSet RetrieveBankList()
            {
                SqlParameter[] parameters = new SqlParameter[0];
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetBankList", parameters);
                return dataSet;

            }
            #endregion
            #region RetrieveCustomerList
            public static DataSet RetrieveCustomerList()
            {
                SqlParameter[] parameters = new SqlParameter[0];
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetCustomerList", parameters);
                return dataSet;

            }
            #endregion
            #region RetrieveProjectList
            public static DataSet RetrieveProjectList(Int32 CustomerID)
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@CustomerID", SqlDbType.Int);
                parameters[0].Value = CustomerID;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("[spGetCustomerProjectList]", parameters);
                return dataSet;

            }
            #endregion
            #region RetrieveProjectActivityList
            public static DataSet RetrieveProjectActivityList(Int32 CustomerID, Int32 ProjectID)
            {
                SqlParameter[] parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@CustomerID", SqlDbType.Int);
                parameters[0].Value = CustomerID;
                parameters[1] = new SqlParameter("@ProjectID", SqlDbType.Int);
                parameters[1].Value = ProjectID;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetProjectActivityList", parameters);
                return dataSet;

            }
            #endregion
            #region RetrieveProjectActivityListByProjectID
            public static DataSet RetrieveProjectActivityListByProjectID(Int32 ProjectID)
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@ProjectID", SqlDbType.Int);
                parameters[0].Value = ProjectID;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetProjectActivityListByProjectID", parameters);
                return dataSet;

            }
            #endregion
            #region RetrieveProjectEmployeeRoleByProjectID
            public static DataSet RetrieveProjectEmployeeRoleByProjectID(Int32 ProjectID)
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@ProjectID", SqlDbType.Int);
                parameters[0].Value = ProjectID;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetProjectEmployeeRoleListByProjectID", parameters);
                return dataSet;

            }
            #endregion

            #region RetrieveDepartment
            public static DataSet RetrieveDepartment()
            {
                SqlParameter[] parameters = new SqlParameter[0];
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetDepartmentList", parameters);
                return dataSet;

            }
           #endregion
           #region RetrieveRoles
            public static DataSet RetrieveRoles()
            {
                SqlParameter[] parameters = new SqlParameter[0];
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetRolesList", parameters);
                return dataSet;

            }
            #endregion

            #region RetrieveActivityList
            public static DataSet RetrieveActivityList()
            {
                SqlParameter[] parameters = new SqlParameter[0];
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetActivityList", parameters);
                return dataSet;

            }
           #endregion
            #region RetrieveActivityLookup
            public static DataSet RetrieveActivityLookup()
            {
                SqlParameter[] parameters = new SqlParameter[0];
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetActivityListLookUp", parameters);
                return dataSet;

            }
           #endregion

            #region RetrieveDepartmentLookup
            public static NamedCollection[] RetrieveDepartmentLookup()
            {
                return RetrieveCollection("[spGetDepartmentListLookup]", null);

            }
           #endregion
            #region RetrieveEmpCategoryLookup
            public static NamedCollection[] RetrieveEmpCategoryLookup()
            {
                return RetrieveCollection("[spGetEmpCategoryLookup]", null); 

            }
           #endregion
            #region RetrieveDesignationList
            public static DataSet RetrieveDesignationList()
            {
                SqlParameter[] parameters = new SqlParameter[0];
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetDesignationList", parameters);
                return dataSet;

            }
            #endregion
            #region RetrieveEducationList
            public static DataSet RetrieveEducationList()
            {
                SqlParameter[] parameters = new SqlParameter[0];
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetEducation", parameters);
                return dataSet;

            }
            #endregion
            #region RetrieveEmployeeCategoryList
            public static DataSet RetrieveEmployeeCategoryList()
            {
                SqlParameter[] parameters = new SqlParameter[0];
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetEmployeeCategory", parameters);
                return dataSet;

            }
            #endregion
            #region RetrieveEmployeeStatusList
            public static DataSet RetrieveEmployeeStatusList()
            {
                SqlParameter[] parameters = new SqlParameter[0];
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetEmployeeStatus", parameters);
                return dataSet;

            }
            #endregion
            #region RetrieveInsuranceList
            public static DataSet RetrieveInsuranceList()
            {
                SqlParameter[] parameters = new SqlParameter[0];
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetInsuranceList", parameters);
                return dataSet;

            }
            #endregion
            #region RetrieveLineManagerList
            public static DataSet RetrieveLineManagerList()
            {
                SqlParameter[] parameters = new SqlParameter[0];
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetLineManagerStatus", parameters);
                return dataSet;

            }
            #endregion 
            #region RetrieveSkillsList
            public static DataSet RetrieveSkillsList()
            {
                SqlParameter[] parameters = new SqlParameter[0];
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetSkills", parameters);
                return dataSet;

            }
            #endregion        
            #region RetrieveVisaSponsorList
            public static DataSet RetrieveVisaSponsorList()
            {
                SqlParameter[] parameters = new SqlParameter[0];
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetVisaSponsors", parameters);
                return dataSet;

            }
           #endregion 
            
            #region RetrieveEmployeeEOSList
            public static DataSet RetrieveEmployeeEOSList(Int32 RequestorEmpID)
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@RequestorID", SqlDbType.Int);
                parameters[0].Value = RequestorEmpID;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetEmployeeEOSList", parameters);
                return dataSet;

            }
           #endregion 

            #region RetrieveEmployeeProfile_Search
            public static DataSet RetrieveEmployeeProfile_Search(Int32 RequestorEmpID, String EmpName, String Employee_ID, String MgrName,Int32 DesignationID, Int32 DivisionID, Int32 LocationID)
            {
                SqlParameter[] parameters = new SqlParameter[7];
                parameters[0] = new SqlParameter("@EmpName", SqlDbType.VarChar, 50);
                parameters[0].Value = EmpName;
                parameters[1] = new SqlParameter("@Employee_ID", SqlDbType.VarChar, 25);
                parameters[1].Value = Employee_ID;
                parameters[2] = new SqlParameter("@MgrName", SqlDbType.VarChar, 30);
                parameters[2].Value = MgrName;
                parameters[3] = new SqlParameter("@DesignationID", SqlDbType.Int);
                parameters[3].Value = DesignationID;
                parameters[4] = new SqlParameter("@DivisionID", SqlDbType.Int);
                parameters[4].Value = DivisionID;
                parameters[5] = new SqlParameter("@LocationID", SqlDbType.Int);
                parameters[5].Value = LocationID;
                parameters[6] = new SqlParameter("@RequestorEmpID", SqlDbType.Int);
                parameters[6].Value = RequestorEmpID;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetEmployeeProfile_Search", parameters);
                return dataSet;

            }
            #endregion  

           #region RetrieveEmployeeList_Search
            public static DataSet RetrieveEmployeeList_Search(Int32 RequestorEmpID,String EmpName, String Employee_ID, String MgrName, Int32 EmpStatusID, Int32 DesignationID, Int32 DivisionID, Int32 LocationID)
            {
                SqlParameter[] parameters = new SqlParameter[8];
                parameters[0] = new SqlParameter("@EmpName", SqlDbType.VarChar, 50);
                parameters[0].Value = EmpName;
                parameters[1] = new SqlParameter("@Employee_ID", SqlDbType.VarChar, 25);
                parameters[1].Value = Employee_ID;
                parameters[2] = new SqlParameter("@MgrName", SqlDbType.VarChar, 30);
                parameters[2].Value = MgrName;
                parameters[3] = new SqlParameter("@EmpStatusID", SqlDbType.Int);
                parameters[3].Value = EmpStatusID;
                parameters[4] = new SqlParameter("@DesignationID", SqlDbType.Int);
                parameters[4].Value = DesignationID;
                parameters[5] = new SqlParameter("@DivisionID", SqlDbType.Int);
                parameters[5].Value = DivisionID;
                parameters[6] = new SqlParameter("@LocationID", SqlDbType.Int);
                parameters[6].Value = LocationID;
                parameters[7] = new SqlParameter("@RequestorEmpID", SqlDbType.Int);
                parameters[7].Value = RequestorEmpID;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetEmployeeList_Search", parameters);
                return dataSet;

            }
           #endregion  
            #region RetrieveEmployeeList_PayrollSearch
            public static DataSet RetrieveEmployeeList_PayrollSearch(Int32 RequestorEmpID, String EmpName, String Employee_ID, String MgrName, Int32 EmpStatusID, Int32 DesignationID, Int32 DivisionID, Int32 LocationID)
            {
                SqlParameter[] parameters = new SqlParameter[8];
                parameters[0] = new SqlParameter("@EmpName", SqlDbType.VarChar, 50);
                parameters[0].Value = EmpName;
                parameters[1] = new SqlParameter("@Employee_ID", SqlDbType.VarChar, 25);
                parameters[1].Value = Employee_ID;
                parameters[2] = new SqlParameter("@MgrName", SqlDbType.VarChar, 30);
                parameters[2].Value = MgrName;
                parameters[3] = new SqlParameter("@EmpStatusID", SqlDbType.Int);
                parameters[3].Value = EmpStatusID;
                parameters[4] = new SqlParameter("@DesignationID", SqlDbType.Int);
                parameters[4].Value = DesignationID;
                parameters[5] = new SqlParameter("@DivisionID", SqlDbType.Int);
                parameters[5].Value = DivisionID;
                parameters[6] = new SqlParameter("@LocationID", SqlDbType.Int);
                parameters[6].Value = LocationID;
                parameters[7] = new SqlParameter("@RequestorEmpID", SqlDbType.Int);
                parameters[7].Value = RequestorEmpID;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetEmployeeList_SearchPayroll", parameters);
                return dataSet;

            }
           #endregion  

           #region RetrieveEmployeeList_GeneralSearch
            public static DataSet RetrieveEmployeeList_GeneralSearch(Int32 RequestorEmpID, String EmpName, String Employee_ID, String MgrName, Int32 EmpStatusID, Int32 DesignationID, Int32 DivisionID, Int32 LocationID)
            {
                SqlParameter[] parameters = new SqlParameter[8];
                parameters[0] = new SqlParameter("@EmpName", SqlDbType.VarChar, 50);
                parameters[0].Value = EmpName;
                parameters[1] = new SqlParameter("@Employee_ID", SqlDbType.VarChar, 25);
                parameters[1].Value = Employee_ID;
                parameters[2] = new SqlParameter("@MgrName", SqlDbType.VarChar, 30);
                parameters[2].Value = MgrName;
                parameters[3] = new SqlParameter("@EmpStatusID", SqlDbType.Int);
                parameters[3].Value = EmpStatusID;
                parameters[4] = new SqlParameter("@DesignationID", SqlDbType.Int);
                parameters[4].Value = DesignationID;
                parameters[5] = new SqlParameter("@DivisionID", SqlDbType.Int);
                parameters[5].Value = DivisionID;
                parameters[6] = new SqlParameter("@LocationID", SqlDbType.Int);
                parameters[6].Value = LocationID;
                parameters[7] = new SqlParameter("@RequestorEmpID", SqlDbType.Int);
                parameters[7].Value = RequestorEmpID;


                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetEmployeeList_GeneralSearch", parameters);
                return dataSet;

            }
       #endregion  
            #region RetrieveEmployeeList
            public static DataSet RetrieveEmployeeList()
            {
                SqlParameter[] parameters = new SqlParameter[0];
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetEmployeeList", parameters);
                return dataSet;

            }
            #endregion  

            #region RetrieveDocumentList
            public static DataSet RetrieveDocumentList()
            {
                SqlParameter[] parameters = new SqlParameter[0];
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetDocumentList", parameters);
                return dataSet;

            }
            #endregion
            #region RetrieveDocumentListByRole
            public static DataSet RetrieveDocumentListByRole(Int32 EmpId)
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[0].Value = EmpId;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetDocumentListByRole", parameters);
                return dataSet;

            }
            #endregion 
            #region RetrieveLeaveTypeList
            public static DataSet RetrieveLeaveTypeList(Int32 EmpId)
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[0].Value = EmpId;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetLeaveType", parameters);
                return dataSet;

            }
            #endregion 
            #region RetrieveLeaveEntitlements
            public static DataSet RetrieveLeaveEntitlements(Int32 EmpId)
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[0].Value = EmpId;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("[spGetLeaveEntitlements]", parameters);
                return dataSet;
            }
            #endregion  
 
            #region RetrieveLeaveRequests
            public static DataSet RetrieveLeaveRequests(Int32 EmpId)
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[0].Value = EmpId;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("[spGetLeaveRequests]", parameters);
                return dataSet;    
            }
            #endregion  
            #region RetrieveLeaveRequestsByLeavePeriod
            public static DataSet RetrieveLeaveRequestsByLeavePeriod(Int32 EmpId, Int32 LeavePeriodId, Int32 RequestType)
            {
                SqlParameter[] parameters = new SqlParameter[3];
                parameters[0] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[0].Value = EmpId;
                parameters[1] = new SqlParameter("@LeavePeriodId", SqlDbType.Int);
                parameters[1].Value = LeavePeriodId;
                parameters[2] = new SqlParameter("@RequestType", SqlDbType.Int);
                parameters[2].Value = RequestType;


                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("[spGetLeaveRequestsByLeavePeriod]", parameters);
                return dataSet;    
            }
            #endregion  


            #region RetrieveLeaveRequests_Approval
            public static DataSet RetrieveLeaveRequests_Approval(Int32 EmpId)
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[0].Value = EmpId;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("[spGetLeaveRequests_Approval]", parameters);
                return dataSet;    
            }
            #endregion  


            #region RetrieveCurrentLeavePeriod
            public static DataSet RetrieveCurrentLeavePeriod()
            {
                SqlParameter[] parameters = new SqlParameter[0];
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetCurrentLeavePeriod", parameters);
                return dataSet;

            }
           #endregion
            #region RetrieveCurrentWorkWeek
            public static DataSet RetrieveCurrentWorkWeek()
            {
                SqlParameter[] parameters = new SqlParameter[0];
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetWorkWeek", parameters);
                return dataSet;

            }
            #endregion

            #region RetrieveHolidayList
            public static DataSet RetrieveHolidayList(Int32 RequestingEmpId)
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@RequestingEmpId", SqlDbType.Int);
                parameters[0].Value = RequestingEmpId;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetHolidays", parameters);
                return dataSet;

            } 
            #endregion

            #region RetrieveCompanyLocationList
            public static DataSet RetrieveCompanyLocationList()
            {
                SqlParameter[] parameters = new SqlParameter[0];
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetCompanyLocations", parameters);
                return dataSet;

            }
            #endregion

            #region RetrieveLeaveInfo
            public static DataSet RetrieveLeaveInfo(Int32 LeaveRequestID)
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@LeaveRequestID", SqlDbType.Int);
                parameters[0].Value = LeaveRequestID;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetLeaveRequestInfo", parameters);
                return dataSet;

            }
            #endregion    

            #region RetrieveLeaveEntitlementInfo
            public static DataSet RetrieveLeaveEntitlementInfo(Int32 EntitlementID)
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@EntitlementID", SqlDbType.Int);
                parameters[0].Value = EntitlementID;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetLeaveEntitlementInfo", parameters);
                return dataSet;

            }
            #endregion    
            #region RetrieveEmployeeSkills
            public static DataSet RetrieveEmployeeSkills(Int32 EmpId)
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[0].Value = EmpId;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetEmployeeSkills", parameters);
                return dataSet;

            }
           #endregion    

            #region RetrieveEmployeeCertifications
            public static DataSet RetrieveEmployeeCertifications(Int32 EmpId)
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[0].Value = EmpId;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetEmployeeCertifications", parameters);
                return dataSet;

            }
            #endregion
            #region RetrieveEmployeeEducation
            public static DataSet RetrieveEmployeeEducation(Int32 EmpId)
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[0].Value = EmpId;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetEmployeeEducation", parameters);
                return dataSet;

            }
            #endregion

            #region RetrieveEmployeeExperience
            public static DataSet RetrieveEmployeeExperience(Int32 EmpId)
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[0].Value = EmpId;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetEmployeeExperience", parameters);
                return dataSet;

            }
            #endregion

            #region RetrieveEmployeeLanguages
            public static DataSet RetrieveEmployeeLanguages(Int32 EmpId)
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[0].Value = EmpId;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetEmployeeLanguages", parameters);
                return dataSet;

            }
            #endregion
            #region RetrieveEmployeeMemberships
            public static DataSet RetrieveEmployeeMemberships(Int32 EmpId)
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[0].Value = EmpId;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetEmployeeMemberships", parameters);
                return dataSet;

            }
           #endregion

            #region RetrieveEmployeeTrainings
            public static DataSet RetrieveEmployeeTrainings(Int32 EmpId)
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[0].Value = EmpId;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetEmployeeTrainings", parameters);
                return dataSet;

            }
           #endregion

            #region RetrieveEmployeeLeaveList
            public static DataSet RetrieveEmployeeLeaveList(Int32 LeavePeriod, Int32 DepartmentID, Int32 DesignationID, Int32 DivisionID,Int32 LocationID)
            {
                SqlParameter[] parameters = new SqlParameter[5];
                parameters[0] = new SqlParameter("@LeavePeriod", SqlDbType.Int);
                parameters[0].Value = LeavePeriod;
                parameters[1] = new SqlParameter("@DepartmentID", SqlDbType.Int);
                parameters[1].Value = DepartmentID;
                parameters[2] = new SqlParameter("@DesignationID", SqlDbType.Int);
                parameters[2].Value = DesignationID;
                parameters[3] = new SqlParameter("@DivisionID", SqlDbType.Int);
                parameters[3].Value = DivisionID;
                parameters[4] = new SqlParameter("@LocationID", SqlDbType.Int);
                parameters[4].Value = LocationID;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetEmployeeLeaveList", parameters);
                return dataSet;

            }
           #endregion
            #region RetrieveSubordinatesLeaveList
            public static DataSet RetrieveSubordinatesLeaveList(Int32 SupervisoryEmpID, Int32 LeavePeriod, Int32 SelectedEmpId, String LocationName)
            {
                SqlParameter[] parameters = new SqlParameter[4];            
                parameters[0] = new SqlParameter("@SupervisoryEmpID", SqlDbType.Int);
                parameters[0].Value = SupervisoryEmpID;
                parameters[1] = new SqlParameter("@LeavePeriod", SqlDbType.Int);
                parameters[1].Value = LeavePeriod;
                parameters[2] = new SqlParameter("@SelectedEmpId", SqlDbType.Int);
                parameters[2].Value = SelectedEmpId;
                parameters[3] = new SqlParameter("@LocationName", SqlDbType.VarChar,100);
                parameters[3].Value = LocationName;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetSubordinatesLeaveList", parameters);
                return dataSet;

            }
            #endregion
            #region RetrieveEmployeeListByDept
            public static DataSet RetrieveEmployeeListByDept()
            {
                SqlParameter[] parameters = new SqlParameter[0];
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetEmployeeListByDept", parameters);
                return dataSet;

            }
            #endregion

            #region RetrieveDashBoardDataByEmpID
            public static DataSet RetrieveDashBoardDataByEmpID(Int32 RequestorID,Int32 DivisionID, Int32 DivisionLocationID)
            {
                SqlParameter[] parameters = new SqlParameter[3];

                parameters[0] = new SqlParameter("@Requestor_ID", SqlDbType.Int);
                parameters[0].Value = RequestorID;
                parameters[1] = new SqlParameter("@DivisionID", SqlDbType.Int);
                parameters[1].Value = DivisionID;
                parameters[2] = new SqlParameter("@LocationID", SqlDbType.Int);
                parameters[2].Value = DivisionLocationID;                
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetDashBoardDataByEmpID", parameters);
                return dataSet;

            }
            #endregion
            #region RetrieveTMDashBoardData
            public static DataSet RetrieveTMDashBoardData(Int32 RequestorID, Int32 DivisionID, Int32 DivisionLocationID,String startDate,String endDate)
            {
                SqlParameter[] parameters = new SqlParameter[5];

                parameters[0] = new SqlParameter("@Requestor_ID", SqlDbType.Int);
                parameters[0].Value = RequestorID;
                parameters[1] = new SqlParameter("@DivisionID", SqlDbType.Int);
                parameters[1].Value = DivisionID;
                parameters[2] = new SqlParameter("@LocationID", SqlDbType.Int);
                parameters[2].Value = DivisionLocationID;
                parameters[3] = new SqlParameter("@StartDate", SqlDbType.VarChar,25);
                parameters[3].Value = startDate;
                parameters[4] = new SqlParameter("@EndDate", SqlDbType.VarChar,25);
                parameters[4].Value = endDate;                
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetTMDashBoardData", parameters);
                return dataSet;

            }
         #endregion

         #region RetrieveTMDashBoardData_Employee
            public static DataSet RetrieveTMDashBoardData_Employee(Int32 RequestorID, String startDate, String endDate)
            {
                SqlParameter[] parameters = new SqlParameter[5];

                parameters[0] = new SqlParameter("@Requestor_ID", SqlDbType.Int);
                parameters[0].Value = RequestorID;
                parameters[1] = new SqlParameter("@StartDate", SqlDbType.VarChar, 25);
                parameters[1].Value = startDate;
                parameters[2] = new SqlParameter("@EndDate", SqlDbType.VarChar, 25);
                parameters[2].Value = endDate;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetTMDashBoardData_Employee", parameters);
                return dataSet;

            }
         #endregion


            #region RetrieveLeaveListByDept
            public static DataSet RetrieveLeaveListByDept()
            {
                SqlParameter[] parameters = new SqlParameter[0];
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetLeaveListByDept", parameters);
                return dataSet;

            }
            #endregion

            #region RetrieveNewlyAddedUserAccounts
            public static DataSet RetrieveNewlyAddedUserAccounts(Int32 FetchFlag, Int32 Requestor_ID)
            {
                SqlParameter[] parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@FetchFlag", SqlDbType.Int);
                parameters[0].Value = FetchFlag;
                parameters[1] = new SqlParameter("@Requestor_ID", SqlDbType.Int);
                parameters[1].Value = Requestor_ID;

                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetUserAccounts", parameters);
                return dataSet;

            }
           #endregion

            #region RetrieveEmployeeRequests
            public static DataSet RetrieveEmployeeRequests(Int32 Requesting_EmpID)
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@Requesting_EmpID", SqlDbType.Int);
                parameters[0].Value = Requesting_EmpID;

                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetEmployeeRequests", parameters);
                return dataSet;

            }
            #endregion
            #region RetrieveUpcomingHolidays
            public static DataSet RetrieveUpcomingHolidays()
            {
                SqlParameter[] parameters = new SqlParameter[0];
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetUpcomingHolidays", parameters);
                return dataSet;

            }
            #endregion
            #region RetrieveEmployeeUtilizationInfo
            public static DataSet RetrieveEmployeeUtilizationInfo(Int32 EmpId)
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[0].Value = EmpId;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetEmployeeUtilizationInfo", parameters);
                return dataSet;

            }
            #endregion    
            
            #region RetrieveEmployeeInfo
            public static DataSet RetrieveEmployeeInfo(Int32 EmpId)
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[0].Value = EmpId;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetEmployeeInfo", parameters);
                return dataSet;

            }
            #endregion  
            #region RetrieveEmployeeProfileInfo
            public static DataSet RetrieveEmployeeProfileInfo(Int32 EmpId)
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[0].Value = EmpId;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetEmployeeProfileInfo", parameters);
                return dataSet;

            }
            #endregion    
  
            #region RetrieveKeyEmpInfo
            public static DataSet RetrieveKeyEmpInfo(Int32 EmpId)
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[0].Value = EmpId;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetKeyEmployeeInfo", parameters);
                return dataSet;

            }
            #endregion 
            #region RetrieveHolidays_Week
            public static DataSet RetrieveHolidays_Week(Int32 EmpID, String StartDate, String EndDate)
            {
                SqlParameter[] parameters = new SqlParameter[3];
                parameters[0] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[0].Value = EmpID;
                parameters[1] = new SqlParameter("@StartDate", SqlDbType.VarChar,25);
                parameters[1].Value = StartDate;
                parameters[2] = new SqlParameter("@EndDate", SqlDbType.VarChar, 25);
                parameters[2].Value = EndDate;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetHolidays_WithinWeek", parameters);
                return dataSet;

            }
           #endregion 
           #region RetrieveEmployeeMissedTimeEntryRequests
            public static DataSet RetrieveEmployeeMissedTimeEntryRequests(Int32 EmpID)
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[0].Value = EmpID;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetMissedTSEntryRequests", parameters);
                return dataSet;

            }
            #endregion 
            #region RetrieveEmployeeMissedTimeEntryRequests_Approval
            public static DataSet RetrieveEmployeeMissedTimeEntryRequests_Approval(Int32 LineManagerEmpID)
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@LineManagerEmpID", SqlDbType.Int);
                parameters[0].Value = LineManagerEmpID;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetMissedTSEntryRequests_Approval", parameters);
                return dataSet;

            }
         #endregion 
            
          #region Appprove_MissedTimeEntryRequest
            public static DataSet Appprove_MissedTimeEntryRequest(Int32 LineManagerEmpID,Int32 RequestID,Int32 ApprovalStatusID,String Comment)
           {
                SqlParameter[] parameters = new SqlParameter[4];
                parameters[0] = new SqlParameter("@LineManagerEmpID", SqlDbType.Int);
                parameters[0].Value = LineManagerEmpID;
                parameters[1] = new SqlParameter("@RequestID", SqlDbType.Int);
                parameters[1].Value = RequestID;
                parameters[2] = new SqlParameter("@ApprovalStatusID", SqlDbType.Int);
                parameters[2].Value = ApprovalStatusID;
                parameters[3] = new SqlParameter("@Comment", SqlDbType.VarChar, 150);
                parameters[3].Value = Comment;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("Approve_MissedTimeEntryRequest", parameters);
                return dataSet;

            }
         #endregion 
          #region RetrieveMissedTimeEntryRequestApproval
           public static DataSet RetrieveMissedTimeEntryRequestApproval(Int32 EmpID, String StartDate, String EndDate)
            {
                SqlParameter[] parameters = new SqlParameter[3];
                parameters[0] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[0].Value = EmpID;
                parameters[1] = new SqlParameter("@StartDate", SqlDbType.VarChar, 25);
                parameters[1].Value = StartDate;
                parameters[2] = new SqlParameter("@EndDate", SqlDbType.VarChar, 25);
                parameters[2].Value = EndDate;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetMissedEntryRequestApproval", parameters);
                return dataSet;

            }
            #endregion 
            #region RequestApprovalMissedTimeEntry
            public static DataSet RequestApprovalMissedTimeEntry(Int32 EmpID, String StartDate, String EndDate)
            {
                SqlParameter[] parameters = new SqlParameter[3];
                parameters[0] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[0].Value = EmpID;
                parameters[1] = new SqlParameter("@StartDate", SqlDbType.VarChar, 25);
                parameters[1].Value = StartDate;
                parameters[2] = new SqlParameter("@EndDate", SqlDbType.VarChar, 25);
                parameters[2].Value = EndDate;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spRequestApproval_MissedEntry", parameters);
                return dataSet;

            }
            #endregion 

       
            #region RetrieveEmployeeTimeSheetList
            public static DataSet RetrieveEmployeeTimeSheetList(Int32 EmpId, Int32 RequestType)
            {
                SqlParameter[] parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[0].Value = EmpId;
                parameters[1] = new SqlParameter("@RequestType", SqlDbType.Int);
                parameters[1].Value = RequestType;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetEmployeeTimeSheets", parameters);
                return dataSet;

            }
            #endregion 
            #region RetrievePendingTimeSheetList
            public static DataSet RetrievePendingTimeSheetList(Int32 EmpId)
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@RequestorID", SqlDbType.Int);
                parameters[0].Value = EmpId;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetEmployeeTimeSheets_Approval", parameters);
                return dataSet;

            }
           #endregion             
            #region RetrieveEmployeeTimeSheetInfo
            public static DataSet RetrieveEmployeeTimeSheetInfo(Int32 EmpId, Int32 TimeSheetID)
            {
                SqlParameter[] parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[0].Value = EmpId;
                parameters[1] = new SqlParameter("@TimeSheetID", SqlDbType.Int);
                parameters[1].Value = TimeSheetID;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetEmployeeTimeSheetDetail", parameters);
                return dataSet;

            }
            #endregion 
            
            #region RetrieveEmployeeBenefitInfo
            public static DataSet RetrieveEmployeeBenefitInfo(Int32 EmpId)
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[0].Value = EmpId;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetEmployeeBenefitDeductionInfo", parameters);
                return dataSet;

            }
            #endregion 

            #region RetrieveDailyFNTransactionsList
            public static DataSet RetrieveDailyFNTransactionsList(Int32 EntryClerk_EmpId)
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@EntryClerk_EmpId", SqlDbType.Int);
                parameters[0].Value = EntryClerk_EmpId;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetPrePayrollFinancialTransList", parameters);
                return dataSet;

            }
            #endregion 

            #region RetrieveImportedErrorData
            public static DataSet RetrieveImportedErrorData(Int32 Edit_EmpID , String ImportTransaction)
            {
                SqlParameter[] parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@Edit_EmpID", SqlDbType.Int);
                parameters[0].Value = Edit_EmpID;
                parameters[1] = new SqlParameter("@ImportTransaction", SqlDbType.VarChar,50);
                parameters[1].Value = ImportTransaction;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetImportedErrorData", parameters);
                return dataSet;

            }
          #endregion 
            
          #region RetrieveSalaryCertificateData
          public static DataSet RetrieveSalaryCertificateData(Int32 RequestID, Int32 Edit_EmpId)
           {
                SqlParameter[] parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@RequestID", SqlDbType.Int);
                parameters[0].Value = RequestID;
                parameters[1] = new SqlParameter("@Edit_EmpId", SqlDbType.Int);
                parameters[1].Value = Edit_EmpId;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetEmployee_SalaryCertInfo", parameters);
                return dataSet;

            }
           #endregion 


            
            #region RetrieveEmployeePaySlipInfo
            public static DataSet RetrieveEmployeePaySlipInfo(Int32 EmpId, String MonthYear)
            {
                SqlParameter[] parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[0].Value = EmpId;
                parameters[1] = new SqlParameter("@Pay_MonthYear", SqlDbType.VarChar, 30);
                parameters[1].Value = MonthYear;

                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetEmployee_PayStubInfo", parameters);
                return dataSet;

            }
            #endregion 
            #region RetrieveEmployeeCompensation_CurrentYr
            public static DataSet RetrieveEmployeeCompensation_CurrentYr(Int32 EmpId)
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[0].Value = EmpId;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetEmployeeCompensation_CurrentYr", parameters);
                return dataSet;

            }
           #endregion 

            #region DeleteEmployeeMonthlyPayrollInfo
            public static String DeleteEmployeeMonthlyPayrollInfo(Int32 EmpId, String MonthYear, Int32 EditEmpId)
            {
                SqlParameter[] parameters = new SqlParameter[3];
                parameters[0] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[0].Value = EmpId;
                parameters[1] = new SqlParameter("@Pay_MonthYear", SqlDbType.VarChar, 30);
                parameters[1].Value = MonthYear;
                parameters[2] = new SqlParameter("@Last_UpdatedEmpId", SqlDbType.VarChar, 30);
                parameters[2].Value = EditEmpId;

                return BaseDataAccessor.ExecuteWithResult("spDeleteEmployee_Payroll", parameters);

            }
            #endregion 

            #region RetrieveEmployeeMonthlyPayrollInfo
            public static DataSet RetrieveEmployeeMonthlyPayrollInfo(Int32 EmpId, String MonthYear, Int32 EditEmpId)
            {
                SqlParameter[] parameters = new SqlParameter[3];
                parameters[0] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[0].Value = EmpId;
                parameters[1] = new SqlParameter("@Pay_MonthYear", SqlDbType.VarChar, 30);
                parameters[1].Value = MonthYear;
                parameters[2] = new SqlParameter("@Last_UpdatedEmpId", SqlDbType.VarChar, 30);
                parameters[2].Value = EditEmpId;

                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetEmployee_MonthlyPayroll", parameters);
                return dataSet;

            }
            #endregion 
            #region RetrieveEmployeeMonthlyPayrollHistoryInfo
            public static DataSet RetrieveEmployeeMonthlyPayrollHistoryInfo(Int32 EmpId, String MonthYear)
            {
                SqlParameter[] parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[0].Value = EmpId;
                parameters[1] = new SqlParameter("@Pay_MonthYear", SqlDbType.VarChar, 30);
                parameters[1].Value = MonthYear;

                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetEmployee_MonthlyPayrollHistory", parameters);
                return dataSet;

            }
          #endregion 
            
            #region RetrieveEmployeeEOSPayrollInfo
            public static DataSet RetrieveEmployeeEOSPayrollInfo(Int32 EmpId, String MonthYear, Int32 EditEmpId)
            {
                SqlParameter[] parameters = new SqlParameter[3];
                parameters[0] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[0].Value = EmpId;
                parameters[1] = new SqlParameter("@Pay_MonthYear", SqlDbType.VarChar, 30);
                parameters[1].Value = MonthYear;
                parameters[2] = new SqlParameter("@Last_UpdatedEmpId", SqlDbType.VarChar, 30);
                parameters[2].Value = EditEmpId;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetEmployee_EOSPayroll", parameters);
                return dataSet;

            }
            #endregion 



            #region RetrieveEmployeeMonthlyPayroll_Preview
            public static DataSet RetrieveEmployeeMonthlyPayroll_Preview(String Pay_MonthYear,Int32 DivisionID,Int32 DivisionLocationID,Int32 RequestingEmpId)
            {
                SqlParameter[] parameters = new SqlParameter[4];
                parameters[0] = new SqlParameter("@Pay_MonthYear", SqlDbType.VarChar, 30);
                parameters[0].Value = Pay_MonthYear;
                parameters[1] = new SqlParameter("@DivisionID", SqlDbType.Int);
                parameters[1].Value = DivisionID;
                parameters[2] = new SqlParameter("@DivisionLocationID", SqlDbType.Int);
                parameters[2].Value = DivisionLocationID;
                parameters[3] = new SqlParameter("@RequestingEmpId", SqlDbType.Int);
                parameters[3].Value = RequestingEmpId;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetEmployee_MonthlyPayrollPreview", parameters);
                return dataSet;
            }
            #endregion 

            #region RetrieveEmployeeMonthlyUnPaidLeaveReport
            public static DataSet RetrieveEmployeeMonthlyUnPaidLeaveReport(String Pay_MonthYear, Int32 DivisionID, Int32 DivisionLocationID, Int32 RequestingEmpId)
            {
                SqlParameter[] parameters = new SqlParameter[4];
                parameters[0] = new SqlParameter("@Pay_MonthYear", SqlDbType.VarChar, 30);
                parameters[0].Value = Pay_MonthYear;
                parameters[1] = new SqlParameter("@DivisionID", SqlDbType.Int);
                parameters[1].Value = DivisionID;
                parameters[2] = new SqlParameter("@LocationID", SqlDbType.Int);
                parameters[2].Value = DivisionLocationID;
                parameters[3] = new SqlParameter("@Requestor_EmpId", SqlDbType.Int);
                parameters[3].Value = RequestingEmpId;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spRptMonthlyUnPaidLeave", parameters);
                return dataSet;
            }
            #endregion 

            #region RetrieveEmployeeMonthlyStandardDeductions
            public static DataSet RetrieveEmployeeMonthlyStandardDeductions(Int32 DivisionID, Int32 DivisionLocationID)
            {
                SqlParameter[] parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@DivisionID", SqlDbType.Int);
                parameters[0].Value = DivisionID;
                parameters[1] = new SqlParameter("@DivisionLocationID", SqlDbType.Int);
                parameters[1].Value = DivisionLocationID;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spRptGetEmployee_MonthlyStandardDeductions", parameters);
                return dataSet;
            }
            #endregion 


            #region RetrieveEmployeeMonthlyPayrollSummary
            public static DataSet RetrieveEmployeeMonthlyPayrollSummary(String Pay_MonthYear, Int32 DivisionID, Int32 DivisionLocationID, Int32 ProcessState, Int32 RequestingEmpId)
            {
                SqlParameter[] parameters = new SqlParameter[5];
                parameters[0] = new SqlParameter("@Pay_MonthYear", SqlDbType.VarChar, 30);
                parameters[0].Value = Pay_MonthYear;
                parameters[1] = new SqlParameter("@DivisionID", SqlDbType.Int);
                parameters[1].Value = DivisionID;
                parameters[2] = new SqlParameter("@DivisionLocationID", SqlDbType.Int);
                parameters[2].Value = DivisionLocationID;
                parameters[3] = new SqlParameter("@ProcessState", SqlDbType.Int);
                parameters[3].Value = ProcessState;
                parameters[4] = new SqlParameter("@RequestingEmpId", SqlDbType.Int);
                parameters[4].Value = RequestingEmpId;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetEmployee_MonthlyPayrollSummary", parameters);
                return dataSet;
            }
            #endregion 
            #region RetrieveProjectedEmployeeMonthlyPayrollSummary
            public static DataSet RetrieveProjectedEmployeeMonthlyPayrollSummary(String Pay_MonthYear, Int32 DivisionID, Int32 DivisionLocationID, Int32 RequestingEmpId)
            {
                SqlParameter[] parameters = new SqlParameter[4];
                parameters[0] = new SqlParameter("@Pay_MonthYear", SqlDbType.VarChar, 30);
                parameters[0].Value = Pay_MonthYear;
                parameters[1] = new SqlParameter("@DivisionID", SqlDbType.Int);
                parameters[1].Value = DivisionID;
                parameters[2] = new SqlParameter("@DivisionLocationID", SqlDbType.Int);
                parameters[2].Value = DivisionLocationID;
                parameters[3] = new SqlParameter("@Last_UpdatedEmpId", SqlDbType.Int);
                parameters[3].Value = RequestingEmpId;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spRptProjectedPayrollFund", parameters);
                return dataSet;
            }
            #endregion 

            #region RetrieveEmployeeMainData
            public static DataSet RetrieveEmployeeMainData(Int32 DivisionID, Int32 DivisionLocationID, Int32 RequestingEmpId)
            {
                SqlParameter[] parameters = new SqlParameter[3];
                parameters[0] = new SqlParameter("@DivisionID", SqlDbType.Int);
                parameters[0].Value = DivisionID;
                parameters[1] = new SqlParameter("@LocationID", SqlDbType.Int);
                parameters[1].Value = DivisionLocationID;
                parameters[2] = new SqlParameter("@RequestingEmpId", SqlDbType.Int);
                parameters[2].Value = RequestingEmpId;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spRptMainEmployeeData", parameters);
                return dataSet;
            }
            #endregion 
            #region RetrieveNewHiresReport
            public static DataSet RetrieveNewHiresReport(Int32 DivisionID, Int32 DivisionLocationID, Int32 RequestingEmpId)
            {
                SqlParameter[] parameters = new SqlParameter[3];
                parameters[0] = new SqlParameter("@DivisionID", SqlDbType.Int);
                parameters[0].Value = DivisionID;
                parameters[1] = new SqlParameter("@LocationID", SqlDbType.Int);
                parameters[1].Value = DivisionLocationID;
                parameters[2] = new SqlParameter("@RequestingEmpId", SqlDbType.Int);
                parameters[2].Value = RequestingEmpId;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spRptCurrentYear_NewJoiners", parameters);
                return dataSet;
            }
           #endregion 
            #region RetrieveEmployeeAttritionReport
            public static DataSet RetrieveEmployeeAttritionReport(Int32 DivisionID, Int32 DivisionLocationID, Int32 RequestingEmpId)
            {
                SqlParameter[] parameters = new SqlParameter[3];
                parameters[0] = new SqlParameter("@DivisionID", SqlDbType.Int);
                parameters[0].Value = DivisionID;
                parameters[1] = new SqlParameter("@LocationID", SqlDbType.Int);
                parameters[1].Value = DivisionLocationID;
                parameters[2] = new SqlParameter("@RequestingEmpId", SqlDbType.Int);
                parameters[2].Value = RequestingEmpId;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spRptCurrentYear_Leavers", parameters);
                return dataSet;
            }
          #endregion 


            #region RetrieveCustomerMonthlyForecastTimeSheetData
            public static DataSet RetrieveCustomerMonthlyForecastTimeSheetData(Int32 DivisionID, Int32 DivisionLocationID, String ReportMonthYear)
            {
                SqlParameter[] parameters = new SqlParameter[3];
                parameters[0] = new SqlParameter("@DivisionID", SqlDbType.Int);
                parameters[0].Value = DivisionID;
                parameters[1] = new SqlParameter("@LocationID", SqlDbType.Int);
                parameters[1].Value = DivisionLocationID;
                parameters[2] = new SqlParameter("@ReportMonthYear", SqlDbType.VarChar, 20);
                parameters[2].Value = ReportMonthYear;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spRptCustomerUtilization_MonthlyForecast", parameters);
                return dataSet;
            }
            #endregion 
            
            #region RetrieveProjectMonthlyForecastTimeSheetData
            public static DataSet RetrieveProjectMonthlyForecastTimeSheetData(Int32 DivisionID, Int32 DivisionLocationID, String ReportMonthYear)
            {
                SqlParameter[] parameters = new SqlParameter[3];
                parameters[0] = new SqlParameter("@DivisionID", SqlDbType.Int);
                parameters[0].Value = DivisionID;
                parameters[1] = new SqlParameter("@LocationID", SqlDbType.Int);
                parameters[1].Value = DivisionLocationID;
                parameters[2] = new SqlParameter("@ReportMonthYear", SqlDbType.VarChar, 20);
                parameters[2].Value = ReportMonthYear;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spRptProjectUtilzation_MonthlyForecast", parameters);
                return dataSet;
            }
            #endregion 

            #region RetrieveEmployeeMonthlyForecastTimeSheetData
            public static DataSet RetrieveEmployeeMonthlyForecastTimeSheetData(Int32 DivisionID, Int32 DivisionLocationID, String ReportMonthYear)
            {
                SqlParameter[] parameters = new SqlParameter[3];
                parameters[0] = new SqlParameter("@DivisionID", SqlDbType.Int);
                parameters[0].Value = DivisionID;
                parameters[1] = new SqlParameter("@LocationID", SqlDbType.Int);
                parameters[1].Value = DivisionLocationID;
                parameters[2] = new SqlParameter("@ReportMonthYear", SqlDbType.VarChar, 20);
                parameters[2].Value = ReportMonthYear;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spRptEmployeeUtilization_MonthlyForecast", parameters);
                return dataSet;
            }
            #endregion 



            #region RetrieveEmployeeTimeSheetData
            public static DataSet RetrieveEmployeeTimeSheetData(Int32 DivisionID, Int32 DivisionLocationID, String StartDate, String EndDate,Int32 RequestingEmpId)
            {
                SqlParameter[] parameters = new SqlParameter[5];
                parameters[0] = new SqlParameter("@DivisionID", SqlDbType.Int);
                parameters[0].Value = DivisionID;
                parameters[1] = new SqlParameter("@LocationID", SqlDbType.Int);
                parameters[1].Value = DivisionLocationID;
                parameters[2] = new SqlParameter("@StartDate", SqlDbType.VarChar,25);
                parameters[2].Value = StartDate;
                parameters[3] = new SqlParameter("@EndDate", SqlDbType.VarChar,25);
                parameters[3].Value = EndDate;
                parameters[4] = new SqlParameter("@RequestingEmpId", SqlDbType.Int);
                parameters[4].Value = RequestingEmpId;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spRptEmployeeUtilization", parameters);
                return dataSet;
            }
            #endregion 
            #region RetrieveMissingEmployeeTimeSheetData
            public static DataSet RetrieveMissingEmployeeTimeSheetData(Int32 DivisionID, Int32 DivisionLocationID, String StartDate, String EndDate, Int32 RequestingEmpId)
            {
                SqlParameter[] parameters = new SqlParameter[5];
                parameters[0] = new SqlParameter("@DivisionID", SqlDbType.Int);
                parameters[0].Value = DivisionID;
                parameters[1] = new SqlParameter("@LocationID", SqlDbType.Int);
                parameters[1].Value = DivisionLocationID;
                parameters[2] = new SqlParameter("@StartDate", SqlDbType.VarChar, 25);
                parameters[2].Value = StartDate;
                parameters[3] = new SqlParameter("@EndDate", SqlDbType.VarChar, 25);
                parameters[3].Value = EndDate;
                parameters[4] = new SqlParameter("@RequestingEmpId", SqlDbType.Int);
                parameters[4].Value = RequestingEmpId;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spRptMissingEmployeeTimeSheets", parameters);
                return dataSet;
            }
            #endregion 

            #region RetrieveCustomerTimeSheetData
            public static DataSet RetrieveCustomerTimeSheetData(Int32 DivisionID, Int32 DivisionLocationID, String StartDate, String EndDate, Int32 RequestingEmpId)
            {
                SqlParameter[] parameters = new SqlParameter[5];
                parameters[0] = new SqlParameter("@DivisionID", SqlDbType.Int);
                parameters[0].Value = DivisionID;
                parameters[1] = new SqlParameter("@LocationID", SqlDbType.Int);
                parameters[1].Value = DivisionLocationID;
                parameters[2] = new SqlParameter("@StartDate", SqlDbType.VarChar, 25);
                parameters[2].Value = StartDate;
                parameters[3] = new SqlParameter("@EndDate", SqlDbType.VarChar, 25);
                parameters[3].Value = EndDate;
                parameters[4] = new SqlParameter("@RequestingEmpId", SqlDbType.Int);
                parameters[4].Value = RequestingEmpId;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spRptCustomerUtilization", parameters);
                return dataSet;
            }
            #endregion 

            #region RetrieveProjectTimeSheetData
            public static DataSet RetrieveProjectTimeSheetData(Int32 DivisionID, Int32 DivisionLocationID, String StartDate, String EndDate, Int32 RequestingEmpId)
            {
                SqlParameter[] parameters = new SqlParameter[5];
                parameters[0] = new SqlParameter("@DivisionID", SqlDbType.Int);
                parameters[0].Value = DivisionID;
                parameters[1] = new SqlParameter("@LocationID", SqlDbType.Int);
                parameters[1].Value = DivisionLocationID;
                parameters[2] = new SqlParameter("@StartDate", SqlDbType.VarChar, 25);
                parameters[2].Value = StartDate;
                parameters[3] = new SqlParameter("@EndDate", SqlDbType.VarChar, 25);
                parameters[3].Value = EndDate;
                parameters[4] = new SqlParameter("@RequestingEmpId", SqlDbType.Int);
                parameters[4].Value = RequestingEmpId;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spRptProjectUtilization", parameters);
                return dataSet;
            }
            #endregion 
            #region RetrieveProjectTimeSheetDetailedData
            public static DataSet RetrieveProjectTimeSheetDetailedData(Int32 ProjectID, Int32 RequestingEmpId)
            {
                SqlParameter[] parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@ProjectID", SqlDbType.Int);
                parameters[0].Value = ProjectID;
                parameters[1] = new SqlParameter("@RequestingEmpId", SqlDbType.Int);
                parameters[1].Value = RequestingEmpId;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spRptProjectWiseTimeSheetDetail", parameters);
                return dataSet;
            }
            #endregion 

            #region RetrieveCustomerTimeSheetDetailedData
            public static DataSet RetrieveCustomerTimeSheetDetailedData(Int32 CustomerID, Int32 RequestingEmpId)
            {
                SqlParameter[] parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@CustomerID", SqlDbType.Int);
                parameters[0].Value = CustomerID;
                parameters[1] = new SqlParameter("@RequestingEmpId", SqlDbType.Int);
                parameters[1].Value = RequestingEmpId;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spRptCustomerWiseTimeSheetDetail", parameters);
                return dataSet;
            }
            #endregion 
            #region RetrieveEmployeeTimeSheetDetailedData
            public static DataSet RetrieveEmployeeTimeSheetDetailedData(Int32 DivisionID, Int32 LocationId,Int32 RequestingEmpId)
            {
                SqlParameter[] parameters = new SqlParameter[3];
                parameters[0] = new SqlParameter("@DivisionID", SqlDbType.Int);
                parameters[0].Value = DivisionID;
                parameters[1] = new SqlParameter("@LocationId", SqlDbType.Int);
                parameters[1].Value = LocationId;
                parameters[2] = new SqlParameter("@RequestingEmpId", SqlDbType.Int);
                parameters[2].Value = RequestingEmpId;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spRptEmployeeWiseTimeSheetDetail", parameters);
                return dataSet;
            }
            #endregion 

            #region RetrieveEmployeeAllocationReportData
            public static DataSet RetrieveEmployeeAllocationReportData(Int32 DivisionID, Int32 LocationId, Int32 RequestingEmpId)
            {
                SqlParameter[] parameters = new SqlParameter[3];
                parameters[0] = new SqlParameter("@DivisionID", SqlDbType.Int);
                parameters[0].Value = DivisionID;
                parameters[1] = new SqlParameter("@LocationId", SqlDbType.Int);
                parameters[1].Value = LocationId;
                parameters[2] = new SqlParameter("@RequestingEmpId", SqlDbType.Int);
                parameters[2].Value = RequestingEmpId;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spRptEmployeeUtlizationVsAllocation", parameters);
                return dataSet;
            }
            #endregion 
            #region RetrieveProjectUtilizationSummary
            public static DataSet RetrieveProjectUtilizationSummary(Int32 DivisionID, Int32 DivisionLocationID)
            {
                SqlParameter[] parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@DivisionID", SqlDbType.Int);
                parameters[0].Value = DivisionID;
                parameters[1] = new SqlParameter("@LocationID", SqlDbType.Int);
                parameters[1].Value = DivisionLocationID;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spRptProjectUtilizationSummary", parameters);
                return dataSet;
            }
            #endregion 
            #region RetrieveProjectModuleUtilizationSummary
            public static DataSet RetrieveProjectModuleUtilizationSummary(Int32 DivisionID, Int32 DivisionLocationID)
            {
                SqlParameter[] parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@DivisionID", SqlDbType.Int);
                parameters[0].Value = DivisionID;
                parameters[1] = new SqlParameter("@LocationID", SqlDbType.Int);
                parameters[1].Value = DivisionLocationID;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spRptProjectModuleUtilizationSummary", parameters);
                return dataSet;
            }
            #endregion 

            #region RetrieveEmployeeMonthlyProjectUtlization
            public static DataSet RetrieveEmployeesMonthlyProjectUtlization(Int32 DivisionID, Int32 DivisionLocationID, String MonthYear)
            {
                SqlParameter[] parameters = new SqlParameter[3];
                parameters[0] = new SqlParameter("@DivisionID", SqlDbType.Int);
                parameters[0].Value = DivisionID;
                parameters[1] = new SqlParameter("@LocationID", SqlDbType.Int);
                parameters[1].Value = DivisionLocationID;
                parameters[2] = new SqlParameter("@MonthYear", SqlDbType.VarChar, 20);
                parameters[2].Value = MonthYear;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spRptEmployeeMonthlyUtilizationSummary", parameters);
                return dataSet;
            }
            #endregion 
            #region RetrieveEmployeesYearlyProjectUtlization
            public static DataSet RetrieveEmployeesYearlyProjectUtlization(Int32 DivisionID, Int32 DivisionLocationID, String Year)
            {
                SqlParameter[] parameters = new SqlParameter[3];
                parameters[0] = new SqlParameter("@DivisionID", SqlDbType.Int);
                parameters[0].Value = DivisionID;
                parameters[1] = new SqlParameter("@LocationID", SqlDbType.Int);
                parameters[1].Value = DivisionLocationID;
                parameters[2] = new SqlParameter("@Report_Year", SqlDbType.VarChar, 20);
                parameters[2].Value = Year;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spRptEmployeeYearlyUtilizationSummary", parameters);
                return dataSet;
            }
            #endregion 


            #region RetrieveAlertData
            public static DataSet RetrieveAlertData(Int32 AlertDataTypeID, Int32 DivisionID, Int32 DivisionLocationID, Int32 AlertingPeriod,Int32 RequestingEmpId)
            {
                SqlParameter[] parameters = new SqlParameter[5];
                parameters[0] = new SqlParameter("@ExpiryDataType", SqlDbType.Int);
                parameters[0].Value = AlertDataTypeID;
                parameters[1] = new SqlParameter("@DivisionID", SqlDbType.Int);
                parameters[1].Value = DivisionID;
                parameters[2] = new SqlParameter("@LocationID", SqlDbType.Int);
                parameters[2].Value = DivisionLocationID;
                parameters[3] = new SqlParameter("@ExpiryNoticeDays", SqlDbType.Int);
                parameters[3].Value = AlertingPeriod;
                parameters[4] = new SqlParameter("@RequestingEmpId", SqlDbType.Int);
                parameters[4].Value = RequestingEmpId;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spRptExpiryAlertList", parameters);
                return dataSet;
            }
            #endregion 
            #region RetrieveMissingData
            public static DataSet RetrieveMissingData(Int32 MissingDataTypeID, Int32 DivisionID, Int32 DivisionLocationID, Int32 RequestingEmpId)
            {
                SqlParameter[] parameters = new SqlParameter[4];
                parameters[0] = new SqlParameter("@MissingDataType", SqlDbType.Int);
                parameters[0].Value = MissingDataTypeID;
                parameters[1] = new SqlParameter("@DivisionID", SqlDbType.Int);
                parameters[1].Value = DivisionID;
                parameters[2] = new SqlParameter("@LocationID", SqlDbType.Int);
                parameters[2].Value = DivisionLocationID;
                parameters[3] = new SqlParameter("@Requestor_EmpId", SqlDbType.Int);
                parameters[3].Value = RequestingEmpId;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spRptMissingDataAlertList", parameters);
                return dataSet;
            }
            #endregion 
            #region RetrieveLeaveData
            public static DataSet RetrieveLeaveData(Int32 LeaveTypeID, Int32 DivisionID, Int32 DivisionLocationID, Int32 RequestingEmpId)
            {
                SqlParameter[] parameters = new SqlParameter[4];
                parameters[0] = new SqlParameter("@LeaveTypeID", SqlDbType.Int);
                parameters[0].Value = LeaveTypeID;
                parameters[1] = new SqlParameter("@DivisionID", SqlDbType.Int);
                parameters[1].Value = DivisionID;
                parameters[2] = new SqlParameter("@LocationID", SqlDbType.Int);
                parameters[2].Value = DivisionLocationID;
                parameters[3] = new SqlParameter("@Requestor_EmpId", SqlDbType.Int);
                parameters[3].Value = RequestingEmpId;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spRptCurrentPeriodLeaveRequests", parameters);
                return dataSet;
            }
            #endregion 

            #region RetrieveLeaveBalanceData
            public static DataSet RetrieveLeaveBalanceData(Int32 LeaveTypeID, Int32 DivisionID, Int32 DivisionLocationID, Int32 RequestingEmpId)
            {
                SqlParameter[] parameters = new SqlParameter[4];
                parameters[0] = new SqlParameter("@LeaveTypeID", SqlDbType.Int);
                parameters[0].Value = LeaveTypeID;
                parameters[1] = new SqlParameter("@DivisionID", SqlDbType.Int);
                parameters[1].Value = DivisionID;
                parameters[2] = new SqlParameter("@LocationID", SqlDbType.Int);
                parameters[2].Value = DivisionLocationID;
                parameters[3] = new SqlParameter("@Requestor_EmpId", SqlDbType.Int);
                parameters[3].Value = RequestingEmpId;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spRptAnnualLeaveBalance", parameters);
                return dataSet;
            }
            #endregion 
            #region RetrieveBenefitData
            public static DataSet RetrieveBenefitData(Int32 DivisionID, Int32 DivisionLocationID, Int32 RequestingEmpId)
            {
                SqlParameter[] parameters = new SqlParameter[3];
                parameters[0] = new SqlParameter("@DivisionID", SqlDbType.Int);
                parameters[0].Value = DivisionID;
                parameters[1] = new SqlParameter("@LocationID", SqlDbType.Int);
                parameters[1].Value = DivisionLocationID;
                parameters[2] = new SqlParameter("@Requestor_EmpId", SqlDbType.Int);
                parameters[2].Value = RequestingEmpId;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spRptGetBenefitData", parameters);
                return dataSet;
            }
            #endregion 

            #region RetrieveServiceYearData
            public static DataSet RetrieveServiceYearData(Int32 DivisionID, Int32 DivisionLocationID, Int32 ServiceYears, Int32 RequestingEmpId)
            {
                SqlParameter[] parameters = new SqlParameter[4];
                parameters[0] = new SqlParameter("@DivisionID", SqlDbType.Int);
                parameters[0].Value = DivisionID;
                parameters[1] = new SqlParameter("@LocationID", SqlDbType.Int);
                parameters[1].Value = DivisionLocationID;
                parameters[2] = new SqlParameter("@ServiceYears", SqlDbType.Int);
                parameters[2].Value = ServiceYears;
                parameters[3] = new SqlParameter("@Requestor_EmpId", SqlDbType.Int);
                parameters[3].Value = RequestingEmpId;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spRptGetServiceYearsReport", parameters);
                return dataSet;
            }
            #endregion 


            #region RetrieveEmployeeYTDPayrollSummary
            public static DataSet RetrieveEmployeeYTDPayrollSummary(String Pay_Year, Int32 DivisionID, Int32 DivisionLocationID, Int32 ProcessState, Int32 RequestingEmpId)
            {
                SqlParameter[] parameters = new SqlParameter[5];
                parameters[0] = new SqlParameter("@Pay_Year", SqlDbType.VarChar, 15);
                parameters[0].Value = Pay_Year;
                parameters[1] = new SqlParameter("@DivisionID", SqlDbType.Int);
                parameters[1].Value = DivisionID;
                parameters[2] = new SqlParameter("@DivisionLocationID", SqlDbType.Int);
                parameters[2].Value = DivisionLocationID;
                parameters[3] = new SqlParameter("@ProcessState", SqlDbType.Int);
                parameters[3].Value = ProcessState;
                parameters[4] = new SqlParameter("@RequestingEmpId", SqlDbType.Int);
                parameters[4].Value = RequestingEmpId;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetEmployee_YTDPayrollSummary", parameters);
                return dataSet;
            }
            #endregion 

            #region RetrieveEmployeeFinalizedMonthlyPayroll
            public static DataSet RetrieveEmployeeFinalizedMonthlyPayroll(String Pay_MonthYear, Int32 DivisionID, Int32 DivisionLocationID, Int32 RequestingEmpId)
            {
                SqlParameter[] parameters = new SqlParameter[4];
                parameters[0] = new SqlParameter("@Pay_MonthYear", SqlDbType.VarChar, 30);
                parameters[0].Value = Pay_MonthYear;
                parameters[1] = new SqlParameter("@DivisionID", SqlDbType.Int);
                parameters[1].Value = DivisionID;
                parameters[2] = new SqlParameter("@DivisionLocationID", SqlDbType.Int);
                parameters[2].Value = DivisionLocationID;
                parameters[3] = new SqlParameter("@RequestingEmpId", SqlDbType.Int);
                parameters[3].Value = RequestingEmpId;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetEmployee_FinalizeMonthlyPayroll", parameters);
                return dataSet;
            }
            #endregion 

            #region RetrieveEmployeeProcessedMonthlyPayroll
            public static DataSet RetrieveEmployeeProcessedMonthlyPayroll(String Pay_MonthYear, Int32 DivisionID, Int32 DivisionLocationID, Int32 RequestingEmpId)
            {
                SqlParameter[] parameters = new SqlParameter[4];
                parameters[0] = new SqlParameter("@Pay_MonthYear", SqlDbType.VarChar, 30);
                parameters[0].Value = Pay_MonthYear;
                parameters[1] = new SqlParameter("@DivisionID", SqlDbType.Int);
                parameters[1].Value = DivisionID;
                parameters[2] = new SqlParameter("@LocationID", SqlDbType.Int);
                parameters[2].Value = DivisionLocationID;
                parameters[3] = new SqlParameter("@Last_UpdatedEmpId", SqlDbType.Int);
                parameters[3].Value = RequestingEmpId;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetEmployee_BulkProcessMonthlyPayroll", parameters);
                return dataSet;
            }
            #endregion 

            #region RetrieveEmployeeProcessedMonthlyEOSPayroll
            public static DataSet RetrieveEmployeeProcessedMonthlyEOSPayroll(String Pay_MonthYear, Int32 DivisionID, Int32 DivisionLocationID, Int32 RequestingEmpId)
            {
                SqlParameter[] parameters = new SqlParameter[4];
                parameters[0] = new SqlParameter("@Pay_MonthYear", SqlDbType.VarChar, 30);
                parameters[0].Value = Pay_MonthYear;
                parameters[1] = new SqlParameter("@DivisionID", SqlDbType.Int);
                parameters[1].Value = DivisionID;
                parameters[2] = new SqlParameter("@LocationID", SqlDbType.Int);
                parameters[2].Value = DivisionLocationID;
                parameters[3] = new SqlParameter("@Last_UpdatedEmpId", SqlDbType.Int);
                parameters[3].Value = RequestingEmpId;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetEmployee_BulkProcessMonthly_EOSPayroll", parameters);
                return dataSet;
            }
            #endregion 

            #region RetrieveFinalizedMonthlyWPSPayroll
            public static DataSet RetrieveFinalizedMonthlyWPSPayroll(String Pay_MonthYear, Int32 DivisionID, Int32 DivisionLocationID, Int32 RequestingEmpId)
            {
                SqlParameter[] parameters = new SqlParameter[4];
                parameters[0] = new SqlParameter("@Pay_MonthYear", SqlDbType.VarChar, 30);
                parameters[0].Value = Pay_MonthYear;
                parameters[1] = new SqlParameter("@DivisionID", SqlDbType.Int);
                parameters[1].Value = DivisionID;
                parameters[2] = new SqlParameter("@DivisionLocationID", SqlDbType.Int);
                parameters[2].Value = DivisionLocationID;
                parameters[3] = new SqlParameter("@RequestingEmpId", SqlDbType.Int);
                parameters[3].Value = RequestingEmpId;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetEmployee_FinalizeMonthlyWPSPayroll", parameters);
                return dataSet;
            }
            #endregion 
            #region RetrieveLeaveTypeInfo
            public static DataSet RetrieveLeaveTypeInfo(Int32 LeaveTypeID)
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@LeaveTypeID", SqlDbType.Int);
                parameters[0].Value = LeaveTypeID;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetLeaveTypeInfo", parameters);
                return dataSet;

            }
           #endregion    

            #region RetrieveHolidayInfo
            public static DataSet RetrieveHolidayInfo(Int32 HolidayID)
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@HolidayID", SqlDbType.Int);
                parameters[0].Value = HolidayID;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetHolidayInfo", parameters);
                return dataSet;

            }
            #endregion    

            
            #region RetrieveEmpSkillInfo
            public static DataSet RetrieveEmpSkillInfo(Int32 Emp_SkillID)
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@Emp_SkillID", SqlDbType.Int);
                parameters[0].Value = Emp_SkillID;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetEmpSkillInfo", parameters);
                return dataSet;

            }
            #endregion    
            
            #region RetrieveEmpCertificationInfo
            public static DataSet RetrieveEmpCertificationInfo(Int32 Emp_CertId)
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@Emp_CertId", SqlDbType.Int);
                parameters[0].Value = Emp_CertId;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetEmpCertificationInfo", parameters);
                return dataSet;

            }
            #endregion    

            #region RetrieveEmpEducationInfo
            public static DataSet RetrieveEmpEducationInfo(Int32 Emp_EduId)
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@Emp_EduId", SqlDbType.Int);
                parameters[0].Value = Emp_EduId;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetEmpEducationInfo", parameters);
                return dataSet;

            }
            #endregion    
            
            #region RetrieveEmpExperienceInfo
            public static DataSet RetrieveEmpExperienceInfo(Int32 Emp_WorkExpID)
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@Emp_WorkExpID", SqlDbType.Int);
                parameters[0].Value = Emp_WorkExpID;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetEmpExperienceInfo", parameters);
                return dataSet;

            }
            #endregion    

            #region RetrieveEmpLanguageInfo
            public static DataSet RetrieveEmpLanguageInfo(Int32 Emp_LangID)
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@Emp_LangID", SqlDbType.Int);
                parameters[0].Value = Emp_LangID;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetEmpLanguageInfo", parameters);
                return dataSet;

            }
            #endregion    

            #region RetrieveEmpMembershipInfo
            public static DataSet RetrieveEmpMembershipInfo(Int32 Emp_MemID)
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@Emp_MemID", SqlDbType.Int);
                parameters[0].Value = Emp_MemID;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetEmpMembershipInfo", parameters);
                return dataSet;

            }
            #endregion    
            
            #region RetrieveEmpTrainingInfo
            public static DataSet RetrieveEmpTrainingInfo(Int32 Emp_TrainingID)
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@Emp_TrainingID", SqlDbType.Int);
                parameters[0].Value = Emp_TrainingID;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetEmpTrainingInfo", parameters);
                return dataSet;

            }
            #endregion    
            
            #region RetrieveEmpPreferenceInfo
            public static DataSet RetrieveEmpPreferenceInfo(Int32 EmpID)
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@EmpID", SqlDbType.Int);
                parameters[0].Value = EmpID;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetEmpPreferenceInfo", parameters);
                return dataSet;

            }
            #endregion    

            #region RetrieveEmpDependentInfo
            public static DataSet RetrieveEmpDependentInfo(Int32 Emp_DPId)
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@Emp_DPId", SqlDbType.Int);
                parameters[0].Value = Emp_DPId;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetEmpDependentInfo", parameters);
                return dataSet;

            }
            #endregion    


            /*
			#region RetrieveEmpList
            public static DataSet RetrieveEmpList()
			{
                SqlParameter[] parameters = new SqlParameter[0];
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spEmpList", parameters);
                return dataSet; 

			}
			#endregion
            #region RetriveEmpList
            public static DataSet RetrieveEmpList2(string empName, string empID, string mgrName,string empStatusID,string jobTitleID, string bUnitID)
            {
                SqlParameter[] parameters = new SqlParameter[6];

                parameters[0] = new SqlParameter("@empName", SqlDbType.
                    (50));
                parameters[0].Value = empName;
                parameters[1] = new SqlParameter("@empId", SqlDbType.Int);
                parameters[1].Value = empId;
                parameters[2] = new SqlParameter("@mgrName", SqlDbType.NVarChar(50));
                parameters[2].Value = mgrName;
                parameters[3] = new SqlParameter("@empStatusID", SqlDbType.Int);
                parameters[3].Value = empStatusID;
                parameters[4] = new SqlParameter("@jobTitleID", SqlDbType.Int);
                parameters[4].Value = jobTitleID;
                parameters[5] = new SqlParameter("@bUnitID", SqlDbType.Int);
                parameters[5].Value = bUnitID;

                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spSearchEmpList", parameters);

                return dataSet;

            }
            #endregion
            */
			#region RetrieveEventList
			public static NamedCollection[] RetrieveEventList()
			{
			
				return RetrieveCollection("spGetEventList", null);

			}
			#endregion

			#region RetrieveCatgeoryList
			public static NamedCollection[] RetrieveCategoryList()
			{
			
				return RetrieveCollection("spGetCategoryList", null);

			}
			#endregion


			#region RetrieveRegistrantTypes
			public static NamedCollection[] RetrieveRegistrantTypes()
			{
			
				return RetrieveCollection("spGetRegistrantTypes", null);

			}
			#endregion


		

		
			// End of sample.


         //   See the sample method to just execute but no need to return data back.
			#region DeletePolicy
			public static void DeletePolicy(Int32 PolicyID,String UserID)
			{
			
				SqlParameter[] parameters = new SqlParameter[2];

				parameters[0] = new SqlParameter("@PolicyID", SqlDbType.Int);
				parameters[0].Value = PolicyID;
				parameters[1] = new SqlParameter("@UserID", SqlDbType.VarChar,20);
				parameters[1].Value = UserID;

				BaseDataAccessor.Execute("spDeletePolicy",parameters);
			}
			#endregion
            // End of Sample.



            #region AddUpdatePayComponents
            public static String AddUpdatePayComponents(Int32 PayComponentID, String PayComponentName, String ShortName, Int32 PayFrequencyID, Int32 PayComponentTypeID,Int32 Status, Int32 EditEmpID)
            {
                SqlParameter[] parameters = new SqlParameter[7];

                parameters[0] = new SqlParameter("@PayComponentID", SqlDbType.Int);
                parameters[0].Value = PayComponentID;
                parameters[1] = new SqlParameter("@PayComponentName", SqlDbType.VarChar,50);
                parameters[1].Value = PayComponentName;
                parameters[2] = new SqlParameter("@ShortName", SqlDbType.VarChar, 25);
                parameters[2].Value = ShortName;
                parameters[3] = new SqlParameter("@PayFrequencyID", SqlDbType.Int);
                parameters[3].Value = PayFrequencyID;
                parameters[4] = new SqlParameter("@PayComponentTypeID", SqlDbType.Int);
                parameters[4].Value = PayComponentTypeID;
                parameters[5] = new SqlParameter("@Status", SqlDbType.Int);
                parameters[5].Value = Status;
                parameters[6] = new SqlParameter("@EditEmpId", SqlDbType.Int);
                parameters[6].Value = EditEmpID;

                return BaseDataAccessor.ExecuteWithResult("spAddUpdatePayComponents", parameters);
            }
            #endregion
            #region AddUpdateCustomerInformation
            public static String AddUpdateCustomerInformation(Int32 RequestorID, Int32 CustomerID, String CustomerName, String CustomerDescription, String Cust_Addr1, String Cust_Addr2,String Cust_City, String Cust_State, Int32 CountryID, String ContactPerson, String CustomerPhone, String CustomerFax, String CustomerEmail)
            {
                SqlParameter[] parameters = new SqlParameter[13];

                parameters[0] = new SqlParameter("@RequestorID", SqlDbType.Int);
                parameters[0].Value = RequestorID;
                parameters[1] = new SqlParameter("@CustomerID", SqlDbType.Int);
                parameters[1].Value = CustomerID;
                parameters[2] = new SqlParameter("@CustomerName", SqlDbType.VarChar, 100);
                parameters[2].Value = CustomerName;
                parameters[3] = new SqlParameter("@CustomerDescription", SqlDbType.VarChar, 250);
                parameters[3].Value = CustomerDescription;
                parameters[4] = new SqlParameter("@Cust_Addr1", SqlDbType.VarChar, 100);
                parameters[4].Value = Cust_Addr1;
                parameters[5] = new SqlParameter("@Cust_Addr2", SqlDbType.VarChar, 100);
                parameters[5].Value = Cust_Addr2;
                parameters[6] = new SqlParameter("@Cust_City", SqlDbType.VarChar, 50);
                parameters[6].Value = Cust_City;
                parameters[7] = new SqlParameter("@Cust_State", SqlDbType.VarChar, 100);
                parameters[7].Value = Cust_State;
                parameters[8] = new SqlParameter("@CountryID", SqlDbType.Int);
                parameters[8].Value = CountryID;
                parameters[9] = new SqlParameter("@ContactPerson", SqlDbType.VarChar, 100);
                parameters[9].Value = ContactPerson;
                parameters[10] = new SqlParameter("@CustomerPhone", SqlDbType.VarChar, 50);
                parameters[10].Value = CustomerPhone;
                parameters[11] = new SqlParameter("@CustomerFax", SqlDbType.VarChar, 50);
                parameters[11].Value = CustomerFax;
                parameters[12] = new SqlParameter("@CustomerEmail", SqlDbType.VarChar, 100);
                parameters[12].Value = CustomerEmail;
                return BaseDataAccessor.ExecuteWithResult("spAddUpdateCustomerInformation", parameters);
            }
            #endregion
            #region AddUpdateCustomerProjectInfo
            public static String AddUpdateCustomerProjectInfo(Int32 RequestorID, Int32 CustomerID, Int32 ProjectID, String ProjectName, String ProjectCode, String ProjectDescription, Int32 ProjectManagerID, String ProjectStartDate, String ProjectEndDate, Double ContractValue, Int32 ProjectCurrencyID, Int32 ProjectStatusID)
            {
                SqlParameter[] parameters = new SqlParameter[12];

                parameters[0] = new SqlParameter("@RequestorID", SqlDbType.Int);
                parameters[0].Value = RequestorID;
                parameters[1] = new SqlParameter("@CustomerID", SqlDbType.Int);
                parameters[1].Value = CustomerID;
                parameters[2] = new SqlParameter("@ProjectID", SqlDbType.Int);
                parameters[2].Value = ProjectID;
                parameters[3] = new SqlParameter("@ProjectName", SqlDbType.VarChar, 100);
                parameters[3].Value = ProjectName;
                parameters[4] = new SqlParameter("@ProjectDescription", SqlDbType.VarChar, 250);
                parameters[4].Value = ProjectDescription;
                parameters[5] = new SqlParameter("@ProjectManagerID", SqlDbType.Int);
                parameters[5].Value = ProjectManagerID;
                parameters[6] = new SqlParameter("@ProjectStartDate", SqlDbType.VarChar, 30);
                parameters[6].Value = ProjectStartDate;
                parameters[7] = new SqlParameter("@ProjectEndDate", SqlDbType.VarChar, 30);
                parameters[7].Value = ProjectEndDate;
                parameters[8] = new SqlParameter("@ContractValue", SqlDbType.Money);
                parameters[8].Value = ContractValue;
                parameters[9] = new SqlParameter("@ProjectCurrencyID", SqlDbType.Int);
                parameters[9].Value = ProjectCurrencyID;
                parameters[10] = new SqlParameter("@ProjectStatusID", SqlDbType.Int);
                parameters[10].Value = ProjectStatusID;
                parameters[11] = new SqlParameter("@ProjectCode", SqlDbType.VarChar,10);
                parameters[11].Value = ProjectCode;

                return BaseDataAccessor.ExecuteWithResult("spAddUpdateCustomerProjectInfo", parameters);
            }
            #endregion

            #region AddUpdateEmployeeUtilization
            public static String AddUpdateEmployeeUtilization(Int32 EmpId, Int32 UtilYear, Decimal M01_Util, Decimal M02_Util, Decimal M03_Util, Decimal M04_Util, Decimal M05_Util, Decimal M06_Util, Decimal M07_Util, Decimal M08_Util, Decimal M09_Util, Decimal M10_Util, Decimal M11_Util, Decimal M12_Util,Int32 RequestorID)
            {
                SqlParameter[] parameters = new SqlParameter[15];

                parameters[0] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[0].Value = EmpId;
                parameters[1] = new SqlParameter("@UtilYear", SqlDbType.Int);
                parameters[1].Value = UtilYear;
                parameters[2] = new SqlParameter("@M01_Util", SqlDbType.Decimal);
                parameters[2].Value = M01_Util;
                parameters[3] = new SqlParameter("@M02_Util", SqlDbType.Decimal);
                parameters[3].Value = M02_Util;
                parameters[4] = new SqlParameter("@M03_Util", SqlDbType.Decimal);
                parameters[4].Value = M03_Util;
                parameters[5] = new SqlParameter("@M04_Util", SqlDbType.Decimal);
                parameters[5].Value = M04_Util;
                parameters[6] = new SqlParameter("@M05_Util", SqlDbType.Decimal);
                parameters[6].Value = M05_Util;
                parameters[7] = new SqlParameter("@M06_Util", SqlDbType.Decimal);
                parameters[7].Value = M06_Util;
                parameters[8] = new SqlParameter("@M07_Util", SqlDbType.Decimal);
                parameters[8].Value = M07_Util;
                parameters[9] = new SqlParameter("@M08_Util", SqlDbType.Decimal);
                parameters[9].Value = M08_Util;
                parameters[10] = new SqlParameter("@M09_Util", SqlDbType.Decimal);
                parameters[10].Value = M09_Util;
                parameters[11] = new SqlParameter("@M10_Util", SqlDbType.Decimal);
                parameters[11].Value = M10_Util;
                parameters[12] = new SqlParameter("@M11_Util", SqlDbType.Decimal);
                parameters[12].Value = M11_Util;
                parameters[13] = new SqlParameter("@M12_Util", SqlDbType.Decimal);
                parameters[13].Value = M12_Util;
                parameters[14] = new SqlParameter("@RequestorID", SqlDbType.Int);
                parameters[14].Value = RequestorID;
                return BaseDataAccessor.ExecuteWithResult("spAddUpdate_EmployeeUtilization", parameters);
            }
            #endregion
            #region AddUpdateEmployeeUtilization_Bulk
            public static String AddUpdateEmployeeUtilization_Bulk(Int32 RequestorID, Int32 UtilYear, Decimal M01_Util, Decimal M02_Util, Decimal M03_Util, Decimal M04_Util, Decimal M05_Util, Decimal M06_Util, Decimal M07_Util, Decimal M08_Util, Decimal M09_Util, Decimal M10_Util, Decimal M11_Util, Decimal M12_Util,Int32 JobBandID,Int32 DesignationID, Int32 PracticeID, Int32 DivisionID, Int32 LocationID)
            {
                SqlParameter[] parameters = new SqlParameter[19];
                parameters[0] = new SqlParameter("@RequestorID", SqlDbType.Int);
                parameters[0].Value = RequestorID;
                parameters[1] = new SqlParameter("@UtilYear", SqlDbType.Int);
                parameters[1].Value = UtilYear;
                parameters[2] = new SqlParameter("@M01_Util", SqlDbType.Decimal);
                parameters[2].Value = M01_Util;
                parameters[3] = new SqlParameter("@M02_Util", SqlDbType.Decimal);
                parameters[3].Value = M02_Util;
                parameters[4] = new SqlParameter("@M03_Util", SqlDbType.Decimal);
                parameters[4].Value = M03_Util;
                parameters[5] = new SqlParameter("@M04_Util", SqlDbType.Decimal);
                parameters[5].Value = M04_Util;
                parameters[6] = new SqlParameter("@M05_Util", SqlDbType.Decimal);
                parameters[6].Value = M05_Util;
                parameters[7] = new SqlParameter("@M06_Util", SqlDbType.Decimal);
                parameters[7].Value = M06_Util;
                parameters[8] = new SqlParameter("@M07_Util", SqlDbType.Decimal);
                parameters[8].Value = M07_Util;
                parameters[9] = new SqlParameter("@M08_Util", SqlDbType.Decimal);
                parameters[9].Value = M08_Util;
                parameters[10] = new SqlParameter("@M09_Util", SqlDbType.Decimal);
                parameters[10].Value = M09_Util;
                parameters[11] = new SqlParameter("@M10_Util", SqlDbType.Decimal);
                parameters[11].Value = M10_Util;
                parameters[12] = new SqlParameter("@M11_Util", SqlDbType.Decimal);
                parameters[12].Value = M11_Util;
                parameters[13] = new SqlParameter("@M12_Util", SqlDbType.Decimal);
                parameters[13].Value = M12_Util;
                parameters[14] = new SqlParameter("@JobBandID", SqlDbType.Int);
                parameters[14].Value = JobBandID;
                parameters[15] = new SqlParameter("@DesignationID", SqlDbType.Int);
                parameters[15].Value = DesignationID;
                parameters[16] = new SqlParameter("@PracticeID", SqlDbType.Int);
                parameters[16].Value = PracticeID;
                parameters[17] = new SqlParameter("@DivisionID", SqlDbType.Int);
                parameters[17].Value = DivisionID;
                parameters[18] = new SqlParameter("@LocationID", SqlDbType.Int);
                parameters[18].Value = LocationID;
                return BaseDataAccessor.ExecuteWithResult("spAddUpdateEmployeeUtilization_Bulk", parameters);
            }
            #endregion

            #region AddUpdateEmployeeUtilization_Bulk
            public static String AddUpdateEmployeeBillingRate_Bulk(Int32 RequestorID, Decimal BillingRate, Int32 JobBandID, Int32 DesignationID, Int32 PracticeID, Int32 DivisionID, Int32 LocationID)
            {
                SqlParameter[] parameters = new SqlParameter[19];
                parameters[0] = new SqlParameter("@RequestorID", SqlDbType.Int);
                parameters[0].Value = RequestorID;
                parameters[1] = new SqlParameter("@BillingRate", SqlDbType.Decimal);
                parameters[1].Value = BillingRate;
                parameters[2] = new SqlParameter("@JobBandID", SqlDbType.Int);
                parameters[2].Value = JobBandID;
                parameters[3] = new SqlParameter("@DesignationID", SqlDbType.Int);
                parameters[3].Value = DesignationID;
                parameters[4] = new SqlParameter("@PracticeID", SqlDbType.Int);
                parameters[4].Value = PracticeID;
                parameters[5] = new SqlParameter("@DivisionID", SqlDbType.Int);
                parameters[5].Value = DivisionID;
                parameters[6] = new SqlParameter("@LocationID", SqlDbType.Int);
                parameters[6].Value = LocationID;
                return BaseDataAccessor.ExecuteWithResult("spAddUpdateEmployeeUtilization_Bulk", parameters);
            }
            #endregion


            #region AddUpdateProjectEmployeeAssignment
            public static String AddUpdateProjectEmployeeAssignment(Int32 RequestorID, Int32 ProjectID, String SelectedEmpIds, Int32 AssignTypeID)
            {
                SqlParameter[] parameters = new SqlParameter[4];

                parameters[0] = new SqlParameter("@RequestorID", SqlDbType.Int);
                parameters[0].Value = RequestorID;
                parameters[1] = new SqlParameter("@ProjectID", SqlDbType.Int);
                parameters[1].Value = ProjectID;
                parameters[2] = new SqlParameter("@SelectedEmpIds", SqlDbType.VarChar,250);
                parameters[2].Value = SelectedEmpIds;
                parameters[3] = new SqlParameter("@AssignTypeID", SqlDbType.Int);
                parameters[3].Value = AssignTypeID;
                return BaseDataAccessor.ExecuteWithResult("AddUpdateProjectEmployeeAssignment", parameters);
            }
            #endregion

            #region RetrieveProjectRoleBillingRateByRoleID
            public static String RetrieveProjectRoleBillingRateByRoleID(Int32 RoleID)
            {
                SqlParameter[] parameters = new SqlParameter[1];

                parameters[0] = new SqlParameter("@RoleID", SqlDbType.Int);
                parameters[0].Value = RoleID;
                return BaseDataAccessor.ExecuteWithResult("spGetBillingRateByRoleID", parameters);
            }
            #endregion

            #region GetProjectActivityType
            public static String GetProjectActivityType(Int32 ProjectID, Int32 ProjectActivityID)
            {
                SqlParameter[] parameters = new SqlParameter[2];

                parameters[0] = new SqlParameter("@ProjectID", SqlDbType.Int);
                parameters[0].Value = ProjectID;
                parameters[1] = new SqlParameter("@ProjectActivityID", SqlDbType.Int);
                parameters[1].Value = ProjectActivityID;

                return BaseDataAccessor.ExecuteWithResult("spGetProjectActivityType", parameters);
            }
            #endregion


            #region AddUpdateEmployeeProjectRole
            public static String AddUpdateEmployeeProjectRole(Int32 RequestorID, Int32 ProjectID, Int32 EmpId, Int32 ActivityID, Int32 Allocatedhrs)
            {
                SqlParameter[] parameters = new SqlParameter[5];

                parameters[0] = new SqlParameter("@RequestorID", SqlDbType.Int);
                parameters[0].Value = RequestorID;
                parameters[1] = new SqlParameter("@ProjectID", SqlDbType.Int);
                parameters[1].Value = ProjectID;
                parameters[2] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[2].Value = EmpId;
                parameters[3] = new SqlParameter("@ActivityID", SqlDbType.Int);
                parameters[3].Value = ActivityID;
                parameters[4] = new SqlParameter("@Allocatedhrs", SqlDbType.Money);
                parameters[4].Value = Allocatedhrs;
                return BaseDataAccessor.ExecuteWithResult("AddUpdateEmployeeProjectRole", parameters);
            }
            #endregion


            #region AddUpdateProjectActivityInfo
            public static String AddUpdateProjectActivityInfo(Int32 RequestorID, Int32 ProjectID, Int32 ActivityID, String ActivityName, Int32 Billable, Int32 Active, Double ContractValue)
            {
                SqlParameter[] parameters = new SqlParameter[7];

                parameters[0] = new SqlParameter("@RequestorID", SqlDbType.Int);
                parameters[0].Value = RequestorID;
                parameters[1] = new SqlParameter("@ProjectID", SqlDbType.Int);
                parameters[1].Value = ProjectID;
                parameters[2] = new SqlParameter("@ActivityID", SqlDbType.Int);
                parameters[2].Value = ActivityID;
                parameters[3] = new SqlParameter("@ActivityName", SqlDbType.VarChar, 100);
                parameters[3].Value = ActivityName;
                parameters[4] = new SqlParameter("@Billable", SqlDbType.Int);
                parameters[4].Value = Billable;
                parameters[5] = new SqlParameter("@Active", SqlDbType.Int);
                parameters[5].Value = Active;
                parameters[6] = new SqlParameter("@ModuleValue", SqlDbType.Money);
                parameters[6].Value = ContractValue;

                return BaseDataAccessor.ExecuteWithResult("AddUpdateProjectActivityInfo", parameters);
            }
            #endregion
            #region AddUpdateEmployeeTimeSheet
            public static DataSet AddUpdateEmployeeTimeSheet(Int32 EmpID, Int32 TimeSheetID, String WeekStartDate, String WeekEndDate, String Comment, Int32 R1_ProjectID, Int32 R1_ActivityID, Decimal R1_Day1_Hrs, Decimal R1_Day2_Hrs, Decimal R1_Day3_Hrs, Decimal R1_Day4_Hrs, Decimal R1_Day5_Hrs, Decimal R1_Day6_Hrs, Decimal R1_Day7_Hrs, Int32 R2_ProjectID, Int32 R2_ActivityID, Decimal R2_Day1_Hrs, Decimal R2_Day2_Hrs, Decimal R2_Day3_Hrs, Decimal R2_Day4_Hrs, Decimal R2_Day5_Hrs, Decimal R2_Day6_Hrs, Decimal R2_Day7_Hrs, Int32 R3_ProjectID, Int32 R3_ActivityID, Decimal R3_Day1_Hrs, Decimal R3_Day2_Hrs, Decimal R3_Day3_Hrs, Decimal R3_Day4_Hrs, Decimal R3_Day5_Hrs, Decimal R3_Day6_Hrs, Decimal R3_Day7_Hrs, Int32 R4_ProjectID, Int32 R4_ActivityID, Decimal R4_Day1_Hrs, Decimal R4_Day2_Hrs, Decimal R4_Day3_Hrs, Decimal R4_Day4_Hrs, Decimal R4_Day5_Hrs, Decimal R4_Day6_Hrs, Decimal R4_Day7_Hrs, Int32 R5_ProjectID, Int32 R5_ActivityID, Decimal R5_Day1_Hrs, Decimal R5_Day2_Hrs, Decimal R5_Day3_Hrs, Decimal R5_Day4_Hrs, Decimal R5_Day5_Hrs, Decimal R5_Day6_Hrs, Decimal R5_Day7_Hrs, Int32 R6_ProjectID, Int32 R6_ActivityID, Decimal R6_Day1_Hrs, Decimal R6_Day2_Hrs, Decimal R6_Day3_Hrs, Decimal R6_Day4_Hrs, Decimal R6_Day5_Hrs, Decimal R6_Day6_Hrs, Decimal R6_Day7_Hrs, Int32 R7_ProjectID, Int32 R7_ActivityID, Decimal R7_Day1_Hrs, Decimal R7_Day2_Hrs, Decimal R7_Day3_Hrs, Decimal R7_Day4_Hrs, Decimal R7_Day5_Hrs, Decimal R7_Day6_Hrs, Decimal R7_Day7_Hrs, Int32 R8_ProjectID, Int32 R8_ActivityID, Decimal R8_Day1_Hrs, Decimal R8_Day2_Hrs, Decimal R8_Day3_Hrs, Decimal R8_Day4_Hrs, Decimal R8_Day5_Hrs, Decimal R8_Day6_Hrs, Decimal R8_Day7_Hrs, Int32 StatusTypeId)             
            {
                SqlParameter[] parameters = new SqlParameter[78];

                parameters[0] = new SqlParameter("@EmpID", SqlDbType.Int);
                parameters[0].Value = EmpID;
                parameters[1] = new SqlParameter("@TimeSheetID", SqlDbType.Int);
                parameters[1].Value = TimeSheetID;
                parameters[2] = new SqlParameter("@WeekStartDate", SqlDbType.VarChar, 30);
                parameters[2].Value = WeekStartDate;
                parameters[3] = new SqlParameter("@WeekEndDate", SqlDbType.VarChar, 30);
                parameters[3].Value = WeekEndDate;
                parameters[4] = new SqlParameter("@Comment", SqlDbType.VarChar, 250);
                parameters[4].Value = Comment;
                parameters[5] = new SqlParameter("@R1_ProjectID", SqlDbType.Int);
                parameters[5].Value = R1_ProjectID;
                parameters[6] = new SqlParameter("@R1_ActivityID", SqlDbType.Int);
                parameters[6].Value = R1_ActivityID;
                parameters[7] = new SqlParameter("@R1_Day1_Hrs", SqlDbType.Decimal);
                parameters[7].Value = R1_Day1_Hrs;
                parameters[8] = new SqlParameter("@R1_Day2_Hrs", SqlDbType.Decimal);
                parameters[8].Value = R1_Day2_Hrs;
                parameters[9] = new SqlParameter("@R1_Day3_Hrs", SqlDbType.Decimal);
                parameters[9].Value = R1_Day3_Hrs;
                parameters[10] = new SqlParameter("@R1_Day4_Hrs", SqlDbType.Decimal);
                parameters[10].Value = R1_Day4_Hrs;
                parameters[11] = new SqlParameter("@R1_Day5_Hrs", SqlDbType.Decimal);
                parameters[11].Value = R1_Day5_Hrs;
                parameters[12] = new SqlParameter("@R1_Day6_Hrs", SqlDbType.Decimal);
                parameters[12].Value = R1_Day6_Hrs;
                parameters[13] = new SqlParameter("@R1_Day7_Hrs", SqlDbType.Decimal);
                parameters[13].Value = R1_Day7_Hrs;
                parameters[14] = new SqlParameter("@R2_ProjectID", SqlDbType.Int);
                parameters[14].Value = R2_ProjectID;
                parameters[15] = new SqlParameter("@R2_ActivityID", SqlDbType.Int);
                parameters[15].Value = R2_ActivityID;
                parameters[16] = new SqlParameter("@R2_Day1_Hrs", SqlDbType.Decimal);
                parameters[16].Value = R2_Day1_Hrs;
                parameters[17] = new SqlParameter("@R2_Day2_Hrs", SqlDbType.Decimal);
                parameters[17].Value = R2_Day2_Hrs;
                parameters[18] = new SqlParameter("@R2_Day3_Hrs", SqlDbType.Decimal);
                parameters[18].Value = R2_Day3_Hrs;
                parameters[19] = new SqlParameter("@R2_Day4_Hrs", SqlDbType.Decimal);
                parameters[19].Value = R2_Day4_Hrs;
                parameters[20] = new SqlParameter("@R2_Day5_Hrs", SqlDbType.Decimal);
                parameters[20].Value = R2_Day5_Hrs;
                parameters[21] = new SqlParameter("@R2_Day6_Hrs", SqlDbType.Decimal);
                parameters[21].Value = R2_Day6_Hrs;
                parameters[22] = new SqlParameter("@R2_Day7_Hrs", SqlDbType.Decimal);
                parameters[22].Value = R2_Day7_Hrs;
                parameters[23] = new SqlParameter("@R3_ProjectID", SqlDbType.Int);
                parameters[23].Value = R3_ProjectID;
                parameters[24] = new SqlParameter("@R3_ActivityID", SqlDbType.Int);
                parameters[24].Value = R3_ActivityID;
                parameters[25] = new SqlParameter("@R3_Day1_Hrs", SqlDbType.Decimal);
                parameters[25].Value = R3_Day1_Hrs;
                parameters[26] = new SqlParameter("@R3_Day2_Hrs", SqlDbType.Decimal);
                parameters[26].Value = R3_Day2_Hrs;
                parameters[27] = new SqlParameter("@R3_Day3_Hrs", SqlDbType.Decimal);
                parameters[27].Value = R3_Day3_Hrs;
                parameters[28] = new SqlParameter("@R3_Day4_Hrs", SqlDbType.Decimal);
                parameters[28].Value = R3_Day4_Hrs;
                parameters[29] = new SqlParameter("@R3_Day5_Hrs", SqlDbType.Decimal);
                parameters[29].Value = R3_Day5_Hrs;
                parameters[30] = new SqlParameter("@R3_Day6_Hrs", SqlDbType.Decimal);
                parameters[30].Value = R3_Day6_Hrs;
                parameters[31] = new SqlParameter("@R3_Day7_Hrs", SqlDbType.Decimal);
                parameters[31].Value = R3_Day7_Hrs;
                parameters[32] = new SqlParameter("@R4_ProjectID", SqlDbType.Int);
                parameters[32].Value = R4_ProjectID;
                parameters[33] = new SqlParameter("@R4_ActivityID", SqlDbType.Int);
                parameters[33].Value = R4_ActivityID;
                parameters[34] = new SqlParameter("@R4_Day1_Hrs", SqlDbType.Decimal);
                parameters[34].Value = R4_Day1_Hrs;
                parameters[35] = new SqlParameter("@R4_Day2_Hrs", SqlDbType.Decimal);
                parameters[35].Value = R4_Day2_Hrs;
                parameters[36] = new SqlParameter("@R4_Day3_Hrs", SqlDbType.Decimal);
                parameters[36].Value = R4_Day3_Hrs;
                parameters[37] = new SqlParameter("@R4_Day4_Hrs", SqlDbType.Decimal);
                parameters[37].Value = R4_Day4_Hrs;
                parameters[38] = new SqlParameter("@R4_Day5_Hrs", SqlDbType.Decimal);
                parameters[38].Value = R4_Day5_Hrs;
                parameters[39] = new SqlParameter("@R4_Day6_Hrs", SqlDbType.Decimal);
                parameters[39].Value = R4_Day6_Hrs;
                parameters[40] = new SqlParameter("@R4_Day7_Hrs", SqlDbType.Decimal);
                parameters[40].Value = R4_Day7_Hrs;
                parameters[41] = new SqlParameter("@R5_ProjectID", SqlDbType.Int);
                parameters[41].Value = R5_ProjectID;
                parameters[42] = new SqlParameter("@R5_ActivityID", SqlDbType.Int);
                parameters[42].Value = R5_ActivityID;
                parameters[43] = new SqlParameter("@R5_Day1_Hrs", SqlDbType.Decimal);
                parameters[43].Value = R5_Day1_Hrs;
                parameters[44] = new SqlParameter("@R5_Day2_Hrs", SqlDbType.Decimal);
                parameters[44].Value = R5_Day2_Hrs;
                parameters[45] = new SqlParameter("@R5_Day3_Hrs", SqlDbType.Decimal);
                parameters[45].Value = R5_Day3_Hrs;
                parameters[46] = new SqlParameter("@R5_Day4_Hrs", SqlDbType.Decimal);
                parameters[46].Value = R5_Day4_Hrs;
                parameters[47] = new SqlParameter("@R5_Day5_Hrs", SqlDbType.Decimal);
                parameters[47].Value = R5_Day5_Hrs;
                parameters[48] = new SqlParameter("@R5_Day6_Hrs", SqlDbType.Decimal);
                parameters[48].Value = R5_Day6_Hrs;
                parameters[49] = new SqlParameter("@R5_Day7_Hrs", SqlDbType.Decimal);
                parameters[49].Value = R5_Day7_Hrs;
                parameters[50] = new SqlParameter("@R6_ProjectID", SqlDbType.Int);
                parameters[50].Value = R6_ProjectID;
                parameters[51] = new SqlParameter("@R6_ActivityID", SqlDbType.Int);
                parameters[51].Value = R6_ActivityID;
                parameters[52] = new SqlParameter("@R6_Day1_Hrs", SqlDbType.Decimal);
                parameters[52].Value = R6_Day1_Hrs;
                parameters[53] = new SqlParameter("@R6_Day2_Hrs", SqlDbType.Decimal);
                parameters[53].Value = R6_Day2_Hrs;
                parameters[54] = new SqlParameter("@R6_Day3_Hrs", SqlDbType.Decimal);
                parameters[54].Value = R6_Day3_Hrs;
                parameters[55] = new SqlParameter("@R6_Day4_Hrs", SqlDbType.Decimal);
                parameters[55].Value = R6_Day4_Hrs;
                parameters[56] = new SqlParameter("@R6_Day5_Hrs", SqlDbType.Decimal);
                parameters[56].Value = R6_Day5_Hrs;
                parameters[57] = new SqlParameter("@R6_Day6_Hrs", SqlDbType.Decimal);
                parameters[57].Value = R6_Day6_Hrs;
                parameters[58] = new SqlParameter("@R6_Day7_Hrs", SqlDbType.Decimal);
                parameters[58].Value = R6_Day7_Hrs;
                parameters[59] = new SqlParameter("@R7_ProjectID", SqlDbType.Int);
                parameters[59].Value = R7_ProjectID;
                parameters[60] = new SqlParameter("@R7_ActivityID", SqlDbType.Int);
                parameters[60].Value = R7_ActivityID;
                parameters[61] = new SqlParameter("@R7_Day1_Hrs", SqlDbType.Decimal);
                parameters[61].Value = R7_Day1_Hrs;
                parameters[62] = new SqlParameter("@R7_Day2_Hrs", SqlDbType.Decimal);
                parameters[62].Value = R7_Day2_Hrs;
                parameters[63] = new SqlParameter("@R7_Day3_Hrs", SqlDbType.Decimal);
                parameters[63].Value = R7_Day3_Hrs;
                parameters[64] = new SqlParameter("@R7_Day4_Hrs", SqlDbType.Decimal);
                parameters[64].Value = R7_Day4_Hrs;
                parameters[65] = new SqlParameter("@R7_Day5_Hrs", SqlDbType.Decimal);
                parameters[65].Value = R7_Day5_Hrs;
                parameters[66] = new SqlParameter("@R7_Day6_Hrs", SqlDbType.Decimal);
                parameters[66].Value = R7_Day6_Hrs;
                parameters[67] = new SqlParameter("@R7_Day7_Hrs", SqlDbType.Decimal);
                parameters[67].Value = R7_Day7_Hrs;
                parameters[68] = new SqlParameter("@R8_ProjectID", SqlDbType.Int);
                parameters[68].Value = R8_ProjectID;
                parameters[69] = new SqlParameter("@R8_ActivityID", SqlDbType.Int);
                parameters[69].Value = R8_ActivityID;
                parameters[70] = new SqlParameter("@R8_Day1_Hrs", SqlDbType.Decimal);
                parameters[70].Value = R8_Day1_Hrs;
                parameters[71] = new SqlParameter("@R8_Day2_Hrs", SqlDbType.Decimal);
                parameters[71].Value = R8_Day2_Hrs;
                parameters[72] = new SqlParameter("@R8_Day3_Hrs", SqlDbType.Decimal);
                parameters[72].Value = R8_Day3_Hrs;
                parameters[73] = new SqlParameter("@R8_Day4_Hrs", SqlDbType.Decimal);
                parameters[73].Value = R8_Day4_Hrs;
                parameters[74] = new SqlParameter("@R8_Day5_Hrs", SqlDbType.Decimal);
                parameters[74].Value = R8_Day5_Hrs;
                parameters[75] = new SqlParameter("@R8_Day6_Hrs", SqlDbType.Decimal);
                parameters[75].Value = R8_Day6_Hrs;
                parameters[76] = new SqlParameter("@R8_Day7_Hrs", SqlDbType.Decimal);
                parameters[76].Value = R8_Day7_Hrs;
                parameters[77] = new SqlParameter("@StatusTypeId", SqlDbType.Int);
                parameters[77].Value = StatusTypeId;

                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spAddUpdateEmployeeTimeSheet", parameters);
                return dataSet;
            }
            #endregion


            #region AddUpdateEmployementStatus
            public static String AddUpdateEmployementStatus(Int32 RequestorID, Int32 EmpStatusID, String EmpStatusName, Int32 Status)
            {
                SqlParameter[] parameters = new SqlParameter[4];

                parameters[0] = new SqlParameter("@RequestorID", SqlDbType.Int);
                parameters[0].Value = RequestorID;

                parameters[1] = new SqlParameter("@EmpStatusID", SqlDbType.Int);
                parameters[1].Value = EmpStatusID;

                parameters[2] = new SqlParameter("@EmpStatusName", SqlDbType.VarChar, 50);
                parameters[2].Value = EmpStatusName;

                parameters[3] = new SqlParameter("@Status", SqlDbType.Int);
                parameters[3].Value = Status;

                return BaseDataAccessor.ExecuteWithResult("spAddUpdateEmployementStatus", parameters);
            }
            #endregion

            #region AddUpdateEmployeeCategory
            public static String AddUpdateEmployeeCategory(Int32 RequestorID, Int32 EmpCategoryID, String EmpCategoryName,Int32 Status)
            {
                SqlParameter[] parameters = new SqlParameter[4];

                parameters[0] = new SqlParameter("@RequestorID", SqlDbType.Int);
                parameters[0].Value = RequestorID;

                parameters[1] = new SqlParameter("@EmpCategoryID", SqlDbType.Int);
                parameters[1].Value = EmpCategoryID;

                parameters[2] = new SqlParameter("@EmpCategoryName", SqlDbType.VarChar, 50);
                parameters[2].Value = EmpCategoryName;

                parameters[3] = new SqlParameter("@Status", SqlDbType.Int);
                parameters[3].Value = Status;

                return BaseDataAccessor.ExecuteWithResult("spAddUpdateEmployeeCategory", parameters);
            }
            #endregion

            #region AddUpdateBankInformation
            public static String AddUpdateBankInformation(Int32 RequestorID, Int32 BankID, String BankName, String BankBranch, String BankCode, String RoutingCode, String SwiftCode,Int32 Status)
            {
                SqlParameter[] parameters = new SqlParameter[8];

                parameters[0] = new SqlParameter("@RequestorID", SqlDbType.Int);
                parameters[0].Value = RequestorID;

                parameters[1] = new SqlParameter("@BankID", SqlDbType.Int);
                parameters[1].Value = BankID;

                parameters[2] = new SqlParameter("@BankName", SqlDbType.VarChar, 100);
                parameters[2].Value = BankName;

                parameters[3] = new SqlParameter("@BankBranch", SqlDbType.VarChar, 50);
                parameters[3].Value = BankBranch;

                parameters[4] = new SqlParameter("@BankCode", SqlDbType.VarChar, 10);
                parameters[4].Value = BankCode;

                parameters[5] = new SqlParameter("@RoutingCode", SqlDbType.VarChar, 50);
                parameters[5].Value = RoutingCode;

                parameters[6] = new SqlParameter("@SwiftCode", SqlDbType.VarChar, 50);
                parameters[6].Value = SwiftCode;

                parameters[7] = new SqlParameter("@Status", SqlDbType.Int);
                parameters[7].Value = Status;

                return BaseDataAccessor.ExecuteWithResult("spAddUpdateBankInformation", parameters);
            }
            #endregion

            #region AddUpdateEmployeeRequest
            public static DataSet AddUpdateEmployeeRequest(Int32 RequestID, Int32 RequestingEmpId, Int32 RequestTypeID, String RequestImplTypes, Int32 RequestStatusTypeID, Int32 NewHireID, String RequestNote)
            {
                SqlParameter[] parameters = new SqlParameter[7];

                parameters[0] = new SqlParameter("@RequestID", SqlDbType.Int);
                parameters[0].Value = RequestID;

                parameters[1] = new SqlParameter("@RequestingEmpId", SqlDbType.Int);
                parameters[1].Value = RequestingEmpId;

                parameters[2] = new SqlParameter("@RequestTypeID", SqlDbType.Int);
                parameters[2].Value = RequestTypeID;

                parameters[3] = new SqlParameter("@RequestImplTypes", SqlDbType.VarChar, 250);
                parameters[3].Value = RequestImplTypes;

                parameters[4] = new SqlParameter("@RequestStatusTypeID", SqlDbType.Int);
                parameters[4].Value = RequestStatusTypeID;

                parameters[5] = new SqlParameter("@NewHireID", SqlDbType.Int);
                parameters[5].Value = NewHireID;

                parameters[6] = new SqlParameter("@RequestNote", SqlDbType.VarChar, 2000);
                parameters[6].Value = RequestNote;

                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spAddUpdateRequests", parameters);
                return dataSet;
            }
            #endregion


            #region AddUpdateEducation
            public static String AddUpdateEducation(Int32 RequestorID, Int32 EducationID, String EducationDesc, String ShortCode, Int32 Status)
            {
                SqlParameter[] parameters = new SqlParameter[6];

                parameters[0] = new SqlParameter("@RequestorID", SqlDbType.Int);
                parameters[0].Value = RequestorID;

                parameters[1] = new SqlParameter("@EducationID", SqlDbType.Int);
                parameters[1].Value = EducationID;

                parameters[2] = new SqlParameter("@EducationDesc", SqlDbType.VarChar, 50);
                parameters[2].Value = EducationDesc;

                parameters[3] = new SqlParameter("@ShortCode", SqlDbType.VarChar, 10);
                parameters[3].Value = ShortCode;

                parameters[4] = new SqlParameter("@Status", SqlDbType.Int);
                parameters[4].Value = Status;

                return BaseDataAccessor.ExecuteWithResult("spAddUpdateEducation", parameters);
            }
            #endregion

            #region AddUpdateDesignation
            public static String AddUpdateDesignation(Int32 RequestorID, Int32 DesigID, String Designation, String VisaDesignation, String Remark, Int32 Status)
            {
                SqlParameter[] parameters = new SqlParameter[6];

                parameters[0] = new SqlParameter("@RequestorID", SqlDbType.Int);
                parameters[0].Value = RequestorID;

                parameters[1] = new SqlParameter("@DesignID", SqlDbType.Int);
                parameters[1].Value = DesigID;

                parameters[2] = new SqlParameter("@Designation", SqlDbType.VarChar, 50);
                parameters[2].Value = Designation;

                parameters[3] = new SqlParameter("@VisaDesignation", SqlDbType.VarChar, 50);
                parameters[3].Value = VisaDesignation;

                parameters[4] = new SqlParameter("@Remark", SqlDbType.VarChar, 150);
                parameters[4].Value = Remark;

                parameters[5] = new SqlParameter("@Status", SqlDbType.Int);
                parameters[5].Value = Status;

                return BaseDataAccessor.ExecuteWithResult("spAddUpdateDesignation", parameters);
            }
            #endregion

            #region AddUpdateDepartment
            public static String AddUpdateDepartment(Int32 RequestorID, Int32 DepartmentID,String DepartmentName, String DeptPrefix, String GLCode, Int32 Status)
            {
                SqlParameter[] parameters = new SqlParameter[6];

                parameters[0] = new SqlParameter("@RequestorID", SqlDbType.Int);
                parameters[0].Value = RequestorID;

                parameters[1] = new SqlParameter("@DepartmentID", SqlDbType.Int);
                parameters[1].Value = DepartmentID;

                parameters[2] = new SqlParameter("@DepartmentName", SqlDbType.VarChar, 50);
                parameters[2].Value = DepartmentName;

                parameters[3] = new SqlParameter("@DeptPrefix", SqlDbType.VarChar, 10);
                parameters[3].Value = DeptPrefix;

                parameters[4] = new SqlParameter("@GLCode", SqlDbType.VarChar, 50);
                parameters[4].Value = GLCode;

                parameters[5] = new SqlParameter("@Status", SqlDbType.Int);
                parameters[5].Value = Status;

                return BaseDataAccessor.ExecuteWithResult("spAddUpdateDepartment", parameters);
            }
            #endregion

            #region AddUpdateRole
            public static String AddUpdateRole(Int32 RequestorID, Int32 RoleID, String RoleName, decimal BillingRate)
            {
                SqlParameter[] parameters = new SqlParameter[4];

                parameters[0] = new SqlParameter("@RequestorID", SqlDbType.Int);
                parameters[0].Value = RequestorID;

                parameters[1] = new SqlParameter("@RoleID", SqlDbType.Int);
                parameters[1].Value = RoleID;

                parameters[2] = new SqlParameter("@RoleName", SqlDbType.VarChar, 100);
                parameters[2].Value = RoleName;

                parameters[3] = new SqlParameter("@BillingRate", SqlDbType.Decimal);
                parameters[3].Value = BillingRate;           

                return BaseDataAccessor.ExecuteWithResult("spAddUpdateRole", parameters);
            }
           #endregion

            #region AddUpdateActivity
            public static String AddUpdateActivity(Int32 RequestorID, Int32 ActivityID, String ActivityName)
            {
                SqlParameter[] parameters = new SqlParameter[3];

                parameters[0] = new SqlParameter("@RequestorID", SqlDbType.Int);
                parameters[0].Value = RequestorID;

                parameters[1] = new SqlParameter("@ActivityID", SqlDbType.Int);
                parameters[1].Value = ActivityID;

                parameters[2] = new SqlParameter("@ActivityName", SqlDbType.VarChar, 100);
                parameters[2].Value = ActivityName;

                return BaseDataAccessor.ExecuteWithResult("spAddUpdateActivity", parameters);
            }
            #endregion

            #region AddUpdateDivision
            public static String AddUpdateDivision(Int32 RequestorID, Int32 DivisionID,String DivisionName, Int32 DivisionHeadId, String GLCode, Int32 Status,Int32 RegionID)
            {
                SqlParameter[] parameters = new SqlParameter[7];

                parameters[0] = new SqlParameter("@RequestorID", SqlDbType.Int);
                parameters[0].Value = RequestorID;

                parameters[1] = new SqlParameter("@DivisionID", SqlDbType.Int);
                parameters[1].Value = DivisionID;

                parameters[2] = new SqlParameter("@DivisionName", SqlDbType.VarChar, 50);
                parameters[2].Value = DivisionName;

                parameters[3] = new SqlParameter("@DivisionHeadId", SqlDbType.Int);
                parameters[3].Value = DivisionHeadId;

                parameters[4] = new SqlParameter("@GLCode", SqlDbType.VarChar, 50);
                parameters[4].Value = GLCode;

                parameters[5] = new SqlParameter("@Status", SqlDbType.Int);
                parameters[5].Value = Status;

                parameters[6] = new SqlParameter("@RegionID", SqlDbType.Int);
                parameters[6].Value = RegionID;
                
                return BaseDataAccessor.ExecuteWithResult("spAddUpdateDivision", parameters);
            }
            #endregion
            #region AddUpdateDivisionLocation
            public static String AddUpdateDivisionLocation(Int32 RequestorID, Int32 DivisionID, Int32 DivisionLocationID, Int32 CountryID,Int32 DivisionHeadId, String Employer_UniqueID, String Employer_RefNumber,Int32 Bank_RoutingCode, String GLCode)
            {
                SqlParameter[] parameters = new SqlParameter[9];

                parameters[0] = new SqlParameter("@RequestorID", SqlDbType.Int);
                parameters[0].Value = RequestorID;

                parameters[1] = new SqlParameter("@DivisionID", SqlDbType.Int);
                parameters[1].Value = DivisionID;

                parameters[2] = new SqlParameter("@DivisionLocationID", SqlDbType.Int);
                parameters[2].Value = DivisionLocationID;

                parameters[3] = new SqlParameter("@CountryID", SqlDbType.Int);
                parameters[3].Value = CountryID;

                parameters[4] = new SqlParameter("@DivisionHeadID", SqlDbType.Int);
                parameters[4].Value = DivisionHeadId;

                parameters[5] = new SqlParameter("@Employer_UniqueID", SqlDbType.VarChar,25);
                parameters[5].Value = Employer_UniqueID;

                parameters[6] = new SqlParameter("@Employer_RefNumber", SqlDbType.VarChar,50);
                parameters[6].Value = Employer_RefNumber;

                parameters[7] = new SqlParameter("@Bank_RoutingCode", SqlDbType.Int);
                parameters[7].Value = Bank_RoutingCode;

                parameters[8] = new SqlParameter("@GLCode", SqlDbType.VarChar, 50);
                parameters[8].Value = GLCode;

                return BaseDataAccessor.ExecuteWithResult("spAddUpdateDivisionLocation", parameters);
            }
          #endregion
            #region AddUpdateDivisionLocationDept
            public static String AddUpdateDivisionLocationDept(Int32 RequestorID, Int32 DivisionID, Int32 DivisionLocationID, Int32 DeptID,Int32 LocationDeptHeadID, String GLCode)
            {
                SqlParameter[] parameters = new SqlParameter[6];

                parameters[0] = new SqlParameter("@RequestorID", SqlDbType.Int);
                parameters[0].Value = RequestorID;

                parameters[1] = new SqlParameter("@DivisionID", SqlDbType.Int);
                parameters[1].Value = DivisionID;

                parameters[2] = new SqlParameter("@DivisionLocationID", SqlDbType.Int);
                parameters[2].Value = DivisionLocationID;

                parameters[3] = new SqlParameter("@DeptID", SqlDbType.Int);
                parameters[3].Value = DeptID;

                parameters[4] = new SqlParameter("@LocationDeptHeadID", SqlDbType.Int);
                parameters[4].Value = LocationDeptHeadID;

                parameters[5] = new SqlParameter("@GLCode", SqlDbType.VarChar, 50);
                parameters[5].Value = GLCode;

                return BaseDataAccessor.ExecuteWithResult("spAddUpdateDivisionLocationDept", parameters);
            }
            #endregion

            #region AddNewEmployee
            public static String AddNewEmployee(Int32 SalutationTypeID, String FName, String MidName, String LName, String DOB, Int32 GenderTypeID, Int32 MaritalStatusID, String HireDate, String EmployeeID, Int32 EmpCategory, Int32 EmpStatusID, Int32 DesignationID, Int32 DepartmentID, Int32 DivisionID, Int32 EducationID, Int32 PhotoProfile, String PhotoPath, String UserName, String Password, Int32 LocationID, Int32 Probation, String PSEmployeeID, String Home_Addr1, String Home_Addr2, String City, String Home_State, Int32 Home_CountryID, String Work_Addr1, String Work_Addr2, String Work_City, String Work_State, Int32 Work_CountryID, String Home_Phone, String Mobile_Phone, String Work_Phone, String Work_Email, Int32 SupervisorID, Int32 AccessLevelID, Int32 AddedBy_ID, Int32 AccountStatus)
            {

                SqlParameter[] parameters = new SqlParameter[40];

                parameters[0] = new SqlParameter("@SalutationTypeID", SqlDbType.Int);
                parameters[0].Value = SalutationTypeID;

                parameters[1] = new SqlParameter("@FName", SqlDbType.VarChar, 50);
                parameters[1].Value = FName;

                parameters[2] = new SqlParameter("@MidName", SqlDbType.VarChar, 30);
                parameters[2].Value = MidName;

                parameters[3] = new SqlParameter("@LName", SqlDbType.VarChar, 50);
                parameters[3].Value = LName;

                parameters[4] = new SqlParameter("@DOB", SqlDbType.VarChar, 30);
                parameters[4].Value = DOB;

                parameters[5] = new SqlParameter("@GenderTypeID", SqlDbType.Int);
                parameters[5].Value = GenderTypeID;

                parameters[6] = new SqlParameter("@MaritalStatusID", SqlDbType.Int);
                parameters[6].Value = MaritalStatusID;

                parameters[7] = new SqlParameter("@HireDate", SqlDbType.VarChar, 30);
                parameters[7].Value = HireDate;

                parameters[8] = new SqlParameter("@EmployeeID", SqlDbType.VarChar, 30);
                parameters[8].Value = EmployeeID;

                parameters[9] = new SqlParameter("@EmpCategory", SqlDbType.Int);
                parameters[9].Value = EmpCategory;

                parameters[10] = new SqlParameter("@EmpStatusID", SqlDbType.Int);
                parameters[10].Value = EmpStatusID;

                parameters[11] = new SqlParameter("@DesignationID", SqlDbType.Int);
                parameters[11].Value = DesignationID;

                parameters[12] = new SqlParameter("@DepartmentID", SqlDbType.Int);
                parameters[12].Value = DepartmentID;

                parameters[13] = new SqlParameter("@DivisionID", SqlDbType.Int);
                parameters[13].Value = DivisionID;

                parameters[14] = new SqlParameter("@EducationID", SqlDbType.Int);
                parameters[14].Value = EducationID;

                parameters[15] = new SqlParameter("@PhotoProfile", SqlDbType.Int);
                parameters[15].Value = PhotoProfile;

                parameters[16] = new SqlParameter("@PhotoPath", SqlDbType.VarChar,100);
                parameters[16].Value = PhotoPath;

                parameters[17] = new SqlParameter("@UserName", SqlDbType.VarChar,50);
                parameters[17].Value = UserName;

                parameters[18] = new SqlParameter("@Password", SqlDbType.VarChar,50);
                parameters[18].Value = Password;

                parameters[19] = new SqlParameter("@LocationID", SqlDbType.Int);
                parameters[19].Value = LocationID;

                parameters[20] = new SqlParameter("@Probation", SqlDbType.Int);
                parameters[20].Value = Probation;

                parameters[21] = new SqlParameter("@PSEmployeeID", SqlDbType.VarChar,30);
                parameters[21].Value = PSEmployeeID;

                parameters[22] = new SqlParameter("@Home_Addr1", SqlDbType.VarChar, 50);
                parameters[22].Value = Home_Addr1;

                parameters[23] = new SqlParameter("@Home_Addr2", SqlDbType.VarChar, 50);
                parameters[23].Value = Home_Addr2;

                parameters[24] = new SqlParameter("@City", SqlDbType.VarChar, 50);
                parameters[24].Value = City;

                parameters[25] = new SqlParameter("@State", SqlDbType.VarChar, 50);
                parameters[25].Value = Home_State;

                parameters[26] = new SqlParameter("@Home_CountryID", SqlDbType.Int);
                parameters[26].Value = Home_CountryID;

                parameters[27] = new SqlParameter("@Work_Addr1", SqlDbType.VarChar, 50);
                parameters[27].Value = Work_Addr1;

                parameters[28] = new SqlParameter("@Work_Addr2", SqlDbType.VarChar, 50);
                parameters[28].Value = Work_Addr2;

                parameters[29] = new SqlParameter("@Work_City", SqlDbType.VarChar, 50);
                parameters[29].Value = Work_City;

                parameters[30] = new SqlParameter("@Work_State", SqlDbType.VarChar, 50);
                parameters[30].Value = Work_State;

                parameters[31] = new SqlParameter("@Work_CountryID", SqlDbType.Int);
                parameters[31].Value = Work_CountryID;

                parameters[32] = new SqlParameter("@Home_Phone", SqlDbType.VarChar, 20);
                parameters[32].Value = Home_Phone;

                parameters[33] = new SqlParameter("@Mobile_Phone", SqlDbType.VarChar, 20);
                parameters[33].Value = Mobile_Phone;

                parameters[34] = new SqlParameter("@Work_Phone", SqlDbType.VarChar, 20);
                parameters[34].Value = Work_Phone;

                parameters[35] = new SqlParameter("@Work_Email", SqlDbType.VarChar, 50);
                parameters[35].Value = Work_Email;

                parameters[36] = new SqlParameter("@SupervisorID", SqlDbType.Int);
                parameters[36].Value = SupervisorID;

                parameters[37] = new SqlParameter("@AccessLevelID", SqlDbType.Int);
                parameters[37].Value = AccessLevelID;

                parameters[38] = new SqlParameter("@AddedBy_ID", SqlDbType.Int);
                parameters[38].Value = AddedBy_ID;

                parameters[39] = new SqlParameter("@AccountStatus", SqlDbType.Int);
                parameters[39].Value = AccountStatus;

                return BaseDataAccessor.ExecuteWithResult("spAddEmployee", parameters);
            }
            #endregion

            #region AddUpdateEmployeeProfile
            public static String AddUpdateEmployeeProfile(Int32 EmpId, Int32 SalutationTypeID, String FName, String MidName, String LName, String DOB, Int32 GenderTypeID, String EmployeeID, Int32 DesignationID, Int32 BandLevelID, Int32 DepartmentID, Int32 DivisionID, Int32 LocationID, Int32 PracticeID, Int32 SupervisorID, Int32 SupervisoryRole, Decimal BillingRate, String UserName, String Password, Int32 AccessLevelID, String WorkPhone, String WorkEmailAddress, Int32 AddedBy_ID)
            {

                SqlParameter[] parameters = new SqlParameter[23];

                parameters[0] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[0].Value = EmpId;

                parameters[1] = new SqlParameter("@SalutationTypeID", SqlDbType.Int);
                parameters[1].Value = SalutationTypeID;

                parameters[2] = new SqlParameter("@FName", SqlDbType.VarChar, 50);
                parameters[2].Value = FName;

                parameters[3] = new SqlParameter("@MidName", SqlDbType.VarChar, 30);
                parameters[3].Value = MidName;

                parameters[4] = new SqlParameter("@LName", SqlDbType.VarChar, 50);
                parameters[4].Value = LName;

                parameters[5] = new SqlParameter("@DOB", SqlDbType.VarChar, 30);
                parameters[5].Value = DOB;

                parameters[6] = new SqlParameter("@GenderTypeID", SqlDbType.Int);
                parameters[6].Value = GenderTypeID;
              
                parameters[7] = new SqlParameter("@EmployeeID", SqlDbType.VarChar, 30);
                parameters[7].Value = EmployeeID;

                parameters[8] = new SqlParameter("@DesignationID", SqlDbType.Int);
                parameters[8].Value = DesignationID;

                parameters[9] = new SqlParameter("@DepartmentID", SqlDbType.Int);
                parameters[9].Value = DepartmentID;

                parameters[10] = new SqlParameter("@DivisionID", SqlDbType.Int);
                parameters[10].Value = DivisionID;

                parameters[11] = new SqlParameter("@LocationID", SqlDbType.Int);
                parameters[11].Value = LocationID;

                parameters[12] = new SqlParameter("@PracticeID", SqlDbType.Int);
                parameters[12].Value = PracticeID;

                parameters[13] = new SqlParameter("@SupervisorID", SqlDbType.Int);
                parameters[13].Value = SupervisorID;

                parameters[14] = new SqlParameter("@SupervisoryRole", SqlDbType.Int);
                parameters[14].Value = SupervisoryRole;

                parameters[15] = new SqlParameter("@BandLevelID", SqlDbType.Int);
                parameters[15].Value = BandLevelID;

                parameters[16] = new SqlParameter("@BillingRate", SqlDbType.Decimal);
                parameters[16].Value = BillingRate;

                parameters[17] = new SqlParameter("@UserName", SqlDbType.VarChar, 50);
                parameters[17].Value = UserName;

                parameters[18] = new SqlParameter("@Password", SqlDbType.VarChar, 50);
                parameters[18].Value = Password;

                parameters[19] = new SqlParameter("@AccessLevelID", SqlDbType.Int);
                parameters[19].Value = AccessLevelID;

                parameters[20] = new SqlParameter("@WorkPhone", SqlDbType.VarChar,50);
                parameters[20].Value = WorkPhone;

                parameters[21] = new SqlParameter("@WorkEmailAddress", SqlDbType.VarChar,100);
                parameters[21].Value = WorkEmailAddress;

                parameters[22] = new SqlParameter("@AddedBy_ID", SqlDbType.Int);
                parameters[22].Value = AddedBy_ID;              

                return BaseDataAccessor.ExecuteWithResult("spAddUpdateEmployeeProfile", parameters);
            }
            #endregion

            #region AddUpdateLeaveRequest
            public static DataSet AddUpdateLeaveRequest(Int32 LeaveRequestID, Int32 EmpId, String Leave_StartDate, String Leave_EndDate, Int32 LeaveTypeId, String Comments)
            {
                SqlParameter[] parameters = new SqlParameter[6];

                parameters[0] = new SqlParameter("@LeaveRequestID", SqlDbType.Int);
                parameters[0].Value = LeaveRequestID;
                parameters[1] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[1].Value = EmpId;
                parameters[2] = new SqlParameter("@Leave_StartDate", SqlDbType.VarChar, 25);
                parameters[2].Value = Leave_StartDate;
                parameters[3] = new SqlParameter("@Leave_EndDate", SqlDbType.VarChar, 25);
                parameters[3].Value = Leave_EndDate;
                parameters[4] = new SqlParameter("@LeaveTypeID", SqlDbType.Int);
                parameters[4].Value = LeaveTypeId;
                parameters[5] = new SqlParameter("@Comments", SqlDbType.VarChar, 100);
                parameters[5].Value = Comments;                              
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spAddUpdate_LeaveRequest", parameters);
                return dataSet;
            }
           #endregion
            #region AddUpdateEntitlement
            public static String AddUpdateEntitlement(Int32 EmpId, Int32 LeaveTypeId, Int32 LeavePeriodID, Int32 EntitlementDays, String EmpName,Int32 DesignationID, Int32 DivisionID, Int32 DivisionLocationID, Int32 LineMgr_Approval)
            {
                SqlParameter[] parameters = new SqlParameter[9];

                parameters[0] = new SqlParameter("@RequestingEmpId", SqlDbType.Int);
                parameters[0].Value = EmpId;

                parameters[1] = new SqlParameter("@LeaveTypeId", SqlDbType.Int);
                parameters[1].Value = LeaveTypeId;

                parameters[2] = new SqlParameter("@LeavePeriodID", SqlDbType.Int);
                parameters[2].Value = LeavePeriodID;

                parameters[3] = new SqlParameter("@Entitlement", SqlDbType.Int);
                parameters[3].Value = EntitlementDays;

                parameters[4] = new SqlParameter("@EmpName", SqlDbType.VarChar,50);
                parameters[4].Value = EmpName;

                parameters[5] = new SqlParameter("@DesignationID", SqlDbType.Int);
                parameters[5].Value = DesignationID;

                parameters[6] = new SqlParameter("@DivisionID", SqlDbType.Int);
                parameters[6].Value = DivisionID;

                parameters[7] = new SqlParameter("@DivisionLocationID", SqlDbType.Int);
                parameters[7].Value = DivisionLocationID;

                parameters[8] = new SqlParameter("@LineMgr_Approval", SqlDbType.Int);
                parameters[8].Value = LineMgr_Approval;

                return BaseDataAccessor.ExecuteWithResult("spAddUpdate_Entitlement", parameters);
            }
            #endregion

            #region AddUpdateLeaveEntitlement
            public static String AddUpdateLeaveEntitlement(Int32 EmpId, Int32 EntitlementId, Int32 LeaveTypeId, Int32 LeavePeriodID, Int32 EntitlementDays, Int32 LineMgr_Approval, Int32 DeptHead_Approval, Int32 RequestingEmpID)
            {
                SqlParameter[] parameters = new SqlParameter[8];

                parameters[0] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[0].Value = EmpId;

                parameters[1] = new SqlParameter("@EntitlementId", SqlDbType.Int);
                parameters[1].Value = EntitlementId;

                parameters[2] = new SqlParameter("@LeaveTypeId", SqlDbType.Int);
                parameters[2].Value = LeaveTypeId;

                parameters[3] = new SqlParameter("@LeavePeriodID", SqlDbType.Int);
                parameters[3].Value = LeavePeriodID;

                parameters[4] = new SqlParameter("@Entitlement", SqlDbType.Int);
                parameters[4].Value = EntitlementDays;

                parameters[5] = new SqlParameter("@LineMgr_Approval", SqlDbType.Int);
                parameters[5].Value = LineMgr_Approval;

                parameters[6] = new SqlParameter("@DeptHead_Approval", SqlDbType.Int);
                parameters[6].Value = DeptHead_Approval;

                parameters[7] = new SqlParameter("@RequestingEmpID", SqlDbType.Int);
                parameters[7].Value = RequestingEmpID;
                
                return BaseDataAccessor.ExecuteWithResult("spAddUpdate_LeaveEntitlement", parameters);
            }
           #endregion
            #region Appprove_LeaveRequest
            public static DataSet Appprove_LeaveRequest(Int32 LeaveRequestID, Int32 EmpId, String Approver_Comments,Int32 LeavePayType, Int32 Approval, Int32 Approver_ID)
            {
                SqlParameter[] parameters = new SqlParameter[6];

                parameters[0] = new SqlParameter("@LeaveRequestID", SqlDbType.Int);
                parameters[0].Value = LeaveRequestID;

                parameters[1] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[1].Value = EmpId;

                parameters[2] = new SqlParameter("@Approver_Comments", SqlDbType.VarChar, 100);
                parameters[2].Value = Approver_Comments;

                parameters[3] = new SqlParameter("@LeavePayType", SqlDbType.Int);
                parameters[3].Value = LeavePayType;

                parameters[4] = new SqlParameter("@Approval", SqlDbType.Int);
                parameters[4].Value = Approval;

                parameters[5] = new SqlParameter("@Approver_ID", SqlDbType.Int);
                parameters[5].Value = Approver_ID;

                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spApprove_LeaveRequest", parameters);
                return dataSet;
                
            }
         #endregion
            #region Appprove_TimeSheet
            public static DataSet Appprove_TimeSheet(Int32 ApproverID, Int32 TimeSheetID, String Approver_Comments, Int32 Approval)
            {
                SqlParameter[] parameters = new SqlParameter[4];

                parameters[0] = new SqlParameter("@ApproverID", SqlDbType.Int);
                parameters[0].Value = ApproverID;
                parameters[1] = new SqlParameter("@TimeSheetID", SqlDbType.Int);
                parameters[1].Value = TimeSheetID;
                parameters[2] = new SqlParameter("@Approver_Comments", SqlDbType.VarChar, 250);
                parameters[2].Value = Approver_Comments;
                parameters[3] = new SqlParameter("@Approval", SqlDbType.Int);
                parameters[3].Value = Approval;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spApprove_TimeSheet", parameters);
                return dataSet;

            }
            #endregion


            #region AddUpdateEmployeeSkills
            public static String AddUpdateEmployeeSkills(Int32 Emp_SkillID, Int32 EmpId,Int32 Skill_ID, String Skill_Desc, Int32 SkillLevel_ID, String Last_Assessed, String Note)
            {
                SqlParameter[] parameters = new SqlParameter[7];

                parameters[0] = new SqlParameter("@Emp_SkillID", SqlDbType.Int);
                parameters[0].Value = Emp_SkillID;

                parameters[1] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[1].Value = EmpId;

                parameters[2] = new SqlParameter("@Skill_ID", SqlDbType.Int);
                parameters[2].Value = Skill_ID;

                parameters[3] = new SqlParameter("@Skill_Desc", SqlDbType.VarChar, 100);
                parameters[3].Value = Skill_Desc;

                parameters[4] = new SqlParameter("@SkillLevel_ID", SqlDbType.Int);
                parameters[4].Value = SkillLevel_ID;

                parameters[5] = new SqlParameter("@Last_Assessed", SqlDbType.VarChar,25);
                parameters[5].Value = Last_Assessed;

                parameters[6] = new SqlParameter("@Note", SqlDbType.VarChar, 100);
                parameters[6].Value = Note;

                return BaseDataAccessor.ExecuteWithResult("spAddUpdate_EmployeeSkills", parameters);
            }
            #endregion

            #region AddUpdateEmployeeEducation
            public static String AddUpdateEmployeeEducation(Int32 Employee_EduId, Int32 EmpId, Int32 EducationID, String School_Name, String Date_DegreeReceived,Int32 Graduated, decimal GradeAverage)
            {
                SqlParameter[] parameters = new SqlParameter[7];

                parameters[0] = new SqlParameter("@Employee_EduId ", SqlDbType.Int);
                parameters[0].Value = Employee_EduId;

                parameters[1] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[1].Value = EmpId;

                parameters[2] = new SqlParameter("@EducationID", SqlDbType.Int);
                parameters[2].Value = EducationID;

                parameters[3] = new SqlParameter("@School_Name", SqlDbType.VarChar, 150);
                parameters[3].Value = School_Name;

                parameters[4] = new SqlParameter("@Date_DegreeReceived", SqlDbType.VarChar,25);
                parameters[4].Value = Date_DegreeReceived;

                parameters[5] = new SqlParameter("@Graduated", SqlDbType.Int);
                parameters[5].Value = Graduated;

                parameters[6] = new SqlParameter("@GradeAverage", SqlDbType.Decimal);
                parameters[6].Value = GradeAverage;

                return BaseDataAccessor.ExecuteWithResult("spAddUpdate_EmpEducation", parameters);
            }
            #endregion

            #region AddUpdateEmployeeCertifications
            public static String AddUpdateEmployeeCertifications(Int32 Employee_CertId, Int32 EmpId, Int32 CertificationID, String Cert_desc,String Certification_Number, String IssueDate, String ExpiryDate)
            {
                SqlParameter[] parameters = new SqlParameter[7];

                parameters[0] = new SqlParameter("@Employee_CertId", SqlDbType.Int);
                parameters[0].Value = Employee_CertId;

                parameters[1] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[1].Value = EmpId;

                parameters[2] = new SqlParameter("@CertificationID", SqlDbType.Int);
                parameters[2].Value = CertificationID;

                parameters[3] = new SqlParameter("@Cert_Desc", SqlDbType.VarChar, 100);
                parameters[3].Value = Cert_desc;

                parameters[4] = new SqlParameter("@Certification_Number", SqlDbType.VarChar, 50);
                parameters[4].Value = Certification_Number;
                                
                parameters[5] = new SqlParameter("@IssueDate", SqlDbType.VarChar, 25);
                parameters[5].Value = IssueDate;

                parameters[6] = new SqlParameter("@ExpiryDate", SqlDbType.VarChar,25);
                parameters[6].Value = ExpiryDate;

                return BaseDataAccessor.ExecuteWithResult("spAddUpdate_EmpCertifications", parameters);
            }
            #endregion

            #region AddUpdateEmployeeLanguages
            public static String AddUpdateEmployeeLanguages(Int32 Employee_LangId, Int32 EmpId, Int32 LanguageID, Int32 SpeakLevelID,Int32 ReadLevelID, Int32 WriteLevelID,  String Last_Assessed)
            {
                SqlParameter[] parameters = new SqlParameter[7];

                parameters[0] = new SqlParameter("@Employee_LangId", SqlDbType.Int);
                parameters[0].Value = Employee_LangId;

                parameters[1] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[1].Value = EmpId;

                parameters[2] = new SqlParameter("@LanguageID", SqlDbType.Int);
                parameters[2].Value = LanguageID;

                parameters[3] = new SqlParameter("@SpeakLevelID", SqlDbType.Int);
                parameters[3].Value = SpeakLevelID;

                parameters[4] = new SqlParameter("@ReadLevelID", SqlDbType.Int);
                parameters[4].Value = ReadLevelID;

                parameters[5] = new SqlParameter("@WriteLevelID", SqlDbType.Int);
                parameters[5].Value = WriteLevelID;

                parameters[6] = new SqlParameter("@Last_Assessed", SqlDbType.VarChar, 25);
                parameters[6].Value = Last_Assessed;

                return BaseDataAccessor.ExecuteWithResult("spAddUpdate_EmpLanguages", parameters);
            }
            #endregion

            #region AddUpdateEmployeeMemberships
            public static String AddUpdateEmployeeMemberships(Int32 Employee_MemId, Int32 EmpId, String MembershipName, String Affiliation,String Date_Joined)
            {
                SqlParameter[] parameters = new SqlParameter[5];

                parameters[0] = new SqlParameter("@Employee_MemId", SqlDbType.Int);
                parameters[0].Value = Employee_MemId;

                parameters[1] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[1].Value = EmpId;

                parameters[2] = new SqlParameter("@MembershipName", SqlDbType.VarChar, 150);
                parameters[2].Value = MembershipName;

                parameters[3] = new SqlParameter("@Affiliation", SqlDbType.VarChar, 150);
                parameters[3].Value = Affiliation;

                parameters[4] = new SqlParameter("@Date_Joined", SqlDbType.VarChar, 25);
                parameters[4].Value = Date_Joined;

                return BaseDataAccessor.ExecuteWithResult("spAddUpdate_EmpMembership", parameters);
            }
            #endregion

           #region AddUpdateEmployeeTraining
            public static String AddUpdateEmployeeTraining(Int32 Employee_TrainingID, Int32 EmpId, String TrainingName, Int32 TrainingTypeID, String Training_Desc, String Date_Completed, Int32 Training_Duration)
            {
                SqlParameter[] parameters = new SqlParameter[7];

                parameters[0] = new SqlParameter("@Employee_TrainingID", SqlDbType.Int);
                parameters[0].Value = Employee_TrainingID;

                parameters[1] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[1].Value = EmpId;

                parameters[2] = new SqlParameter("@TrainingName", SqlDbType.VarChar, 100);
                parameters[2].Value = TrainingName;

                parameters[3] = new SqlParameter("@TrainingTypeID", SqlDbType.Int);
                parameters[3].Value = TrainingTypeID;

                parameters[4] = new SqlParameter("@Training_Desc", SqlDbType.VarChar, 200);
                parameters[4].Value = Training_Desc;

                parameters[5] = new SqlParameter("@Date_Completed", SqlDbType.VarChar, 25);
                parameters[5].Value = Date_Completed;

                parameters[6] = new SqlParameter("@Training_Duration", SqlDbType.Int);
                parameters[6].Value = Training_Duration;

                return BaseDataAccessor.ExecuteWithResult("spAddUpdate_EmpTraining", parameters);
            }
            #endregion

            #region AddUpdateEmployeeWorkExperience
            public static String AddUpdateEmployeeWorkExperience(Int32 Employee_WorkExpId, Int32 EmpId, String WorkExperience, Int32 ExperienceLevelID, String Note)
            {
                SqlParameter[] parameters = new SqlParameter[5];

                parameters[0] = new SqlParameter("@Employee_WorkExpId", SqlDbType.Int);
                parameters[0].Value = Employee_WorkExpId;

                parameters[1] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[1].Value = EmpId;

                parameters[2] = new SqlParameter("@WorkExperience", SqlDbType.VarChar, 100);
                parameters[2].Value = WorkExperience;

                parameters[3] = new SqlParameter("@ExperienceLevelID", SqlDbType.Int);
                parameters[3].Value = ExperienceLevelID;

                parameters[4] = new SqlParameter("@Note", SqlDbType.VarChar, 100);
                parameters[4].Value = Note;

                return BaseDataAccessor.ExecuteWithResult("spAddUpdate_EmpWorkExperience", parameters);
            }
            #endregion

            
            #region AddUpdateLeavePeriod
            public static String AddUpdateLeavePeriod(String LeavePeriodName, String Start_Date, String End_Date)
            {  
                SqlParameter[] parameters = new SqlParameter[3];

                parameters[0] = new SqlParameter("@LeavePeriodName", SqlDbType.VarChar,50);
                parameters[0].Value = LeavePeriodName;

                parameters[1] = new SqlParameter("@Start_Date", SqlDbType.VarChar, 25);
                parameters[1].Value = Start_Date;

                parameters[2] = new SqlParameter("@End_Date", SqlDbType.VarChar,25);
                parameters[2].Value = End_Date;

                return BaseDataAccessor.ExecuteWithResult("spAddUpdate_LeavePeriod", parameters);
            }
           #endregion
            #region AddUpdateHoliday
            public static String AddUpdateHoliday(Int32 HolidayId,String HolidayName, String Holiday_Date, Int32 RepeatsAnnually,  Int32 CountryId)
            {
                SqlParameter[] parameters = new SqlParameter[5];

                parameters[0] = new SqlParameter("@HolidayId", SqlDbType.Int);
                parameters[0].Value = HolidayId;

                parameters[1] = new SqlParameter("@HolidayName", SqlDbType.VarChar, 50);
                parameters[1].Value = HolidayName;

                parameters[2] = new SqlParameter("@Holiday_Date", SqlDbType.VarChar, 25);
                parameters[2].Value = Holiday_Date;

                parameters[3] = new SqlParameter("@RepeatsAnnually", SqlDbType.Int);
                parameters[3].Value = RepeatsAnnually;

                parameters[4] = new SqlParameter("@CountryId", SqlDbType.Int);
                parameters[4].Value = CountryId;

                return BaseDataAccessor.ExecuteWithResult("spAddUpdate_Holidays", parameters);
            }
           #endregion

           #region AddUpdateWorkWeek
            public static String AddUpdateWorkWeek(Int32 CountryID, Int32 WorkWeekID,Int32 EditEmpID)
            {
                SqlParameter[] parameters = new SqlParameter[3];

                parameters[0] = new SqlParameter("@CountryID", SqlDbType.Int);
                parameters[0].Value = CountryID;
                parameters[1] = new SqlParameter("@WorkWeekID", SqlDbType.Int);
                parameters[1].Value = WorkWeekID;
                parameters[2] = new SqlParameter("@EditEmpID", SqlDbType.Int);
                parameters[2].Value = EditEmpID;

                return BaseDataAccessor.ExecuteWithResult("spAddUpdate_WorkWeek", parameters);
            }
         #endregion
            #region AddUpdateLeaveType
            public static String AddUpdateLeaveType(Int32 RequestorID, Int32 LeaveTypeID, Int32 DivisionID,Int32 LocationID, Int32 LeavePayType, Int32 Enable_Carry_FWD, Int32 DeductFromServicePeriod, Int32 Allow_Negative, Int32 MaxFullPayDays, Int32 MaxPartialPayDays, Decimal PartialPayPercentage,Int32 MaxDaysAllowed)
            {  
                SqlParameter[] parameters = new SqlParameter[12];

                parameters[0] = new SqlParameter("@RequestorID", SqlDbType.Int);
                parameters[0].Value = RequestorID;

                parameters[1] = new SqlParameter("@LeaveTypeID", SqlDbType.Int);
                parameters[1].Value = LeaveTypeID;

                parameters[2] = new SqlParameter("@DivisionID", SqlDbType.Int);
                parameters[2].Value = DivisionID;

                parameters[3] = new SqlParameter("@LocationID", SqlDbType.Int);
                parameters[3].Value = LocationID;

                parameters[4] = new SqlParameter("@LeavePayType", SqlDbType.Int);
                parameters[4].Value = LeavePayType;

                parameters[5] = new SqlParameter("@Enable_Carry_FWD", SqlDbType.Int);
                parameters[5].Value = Enable_Carry_FWD;

                parameters[6] = new SqlParameter("@DeductFromServicePeriod", SqlDbType.Int);
                parameters[6].Value = DeductFromServicePeriod;

                parameters[7] = new SqlParameter("@Allow_Negative", SqlDbType.Int);
                parameters[7].Value = Allow_Negative;

                parameters[8] = new SqlParameter("@MaxFullPayDays", SqlDbType.Int);
                parameters[8].Value = MaxFullPayDays;

                parameters[9] = new SqlParameter("@MaxPartialPayDays", SqlDbType.Int);
                parameters[9].Value = MaxPartialPayDays;

                parameters[10] = new SqlParameter("@PartialPayPercentage", SqlDbType.Decimal);
                parameters[10].Value = PartialPayPercentage;

                parameters[11] = new SqlParameter("@MaxDaysAllowed", SqlDbType.Decimal);
                parameters[11].Value = MaxDaysAllowed;

                return BaseDataAccessor.ExecuteWithResult("spAddUpdate_LeaveType", parameters);
            }
           #endregion
            #region Update_Emp_GeneralInfo
            public static String Update_Emp_GeneralInfo(Int32 EmpId, String FName, String MidName, String LName, String DOB, String Citizenship, String VisaNumber, String VisaIssueDate, String VisaExpiryDate, String PassportNo, String PassportExpDate, String PassportIssueDate,Int32 GenderTypeID, Int32 MaritalStatusID, Int32 EducationID, Int32 VisaTypeID, Int32 PPCountryID, Int32 VisaCountryID, String LaborCardNo, String LaborCardIssueDate, String LaborCardExpiryDate,Int32 LaborCardIssueCountryID,String BVisaNumber, String BVisaIssueDate, String BVisaExpiryDate,Int32 BVisaCountryID, String WPS_PersonID,Int32 AddedBy_ID)
            {

                SqlParameter[] parameters = new SqlParameter[28];

                parameters[0] = new SqlParameter("@EmpID", SqlDbType.Int);
                parameters[0].Value = EmpId;

                parameters[1] = new SqlParameter("@FName", SqlDbType.VarChar, 30);
                parameters[1].Value = FName;

                parameters[2] = new SqlParameter("@MidName", SqlDbType.VarChar, 30);
                parameters[2].Value = MidName;

                parameters[3] = new SqlParameter("@LName", SqlDbType.VarChar, 30);
                parameters[3].Value = LName;

                parameters[4] = new SqlParameter("@DOB", SqlDbType.VarChar, 30);
                parameters[4].Value = DOB;

                parameters[5] = new SqlParameter("@CitizenShip", SqlDbType.VarChar, 30);
                parameters[5].Value = Citizenship;

                parameters[6] = new SqlParameter("@VisaNumber", SqlDbType.VarChar, 30);
                parameters[6].Value = VisaNumber;

                parameters[7] = new SqlParameter("@VisaIssueDate", SqlDbType.VarChar, 30);
                parameters[7].Value = VisaIssueDate;

                parameters[8] = new SqlParameter("@VisaExpiryDate", SqlDbType.VarChar, 30);
                parameters[8].Value = VisaExpiryDate;

                parameters[9] = new SqlParameter("@PassportNo", SqlDbType.VarChar, 30);
                parameters[9].Value = PassportNo;

                parameters[10] = new SqlParameter("@PassportExpDate", SqlDbType.VarChar, 30);
                parameters[10].Value = PassportExpDate;

                parameters[11] = new SqlParameter("@PassportIssueDate", SqlDbType.VarChar, 30);
                parameters[11].Value = PassportIssueDate;

                parameters[12] = new SqlParameter("@GenderTypeID", SqlDbType.Int);
                parameters[12].Value = GenderTypeID;

                parameters[13] = new SqlParameter("@MaritalStatusID", SqlDbType.Int);
                parameters[13].Value = MaritalStatusID;

                parameters[14] = new SqlParameter("@EducationID", SqlDbType.Int);
                parameters[14].Value = EducationID;

                parameters[15] = new SqlParameter("@VisaTypeID", SqlDbType.Int);
                parameters[15].Value = VisaTypeID;

                parameters[16] = new SqlParameter("@PPCountryID", SqlDbType.Int);
                parameters[16].Value = PPCountryID;

                parameters[17] = new SqlParameter("@VisaCountryID", SqlDbType.Int);
                parameters[17].Value = VisaCountryID;

                parameters[18] = new SqlParameter("@LaborCardNo", SqlDbType.VarChar, 30);
                parameters[18].Value = LaborCardNo;

                parameters[19] = new SqlParameter("@LaborCardIssueDate", SqlDbType.VarChar, 30);
                parameters[19].Value = LaborCardIssueDate;

                parameters[20] = new SqlParameter("@LaborCardExpiryDate", SqlDbType.VarChar, 30);
                parameters[20].Value = LaborCardExpiryDate;

                parameters[21] = new SqlParameter("@LaborCardIssueCountryID", SqlDbType.Int);
                parameters[21].Value = LaborCardIssueCountryID;

                parameters[22] = new SqlParameter("@BVisaNumber", SqlDbType.VarChar, 30);
                parameters[22].Value = BVisaNumber;

                parameters[23] = new SqlParameter("@BVisaIssueDate", SqlDbType.VarChar, 30);
                parameters[23].Value = BVisaIssueDate;

                parameters[24] = new SqlParameter("@BVisaExpiryDate", SqlDbType.VarChar, 30);
                parameters[24].Value = BVisaExpiryDate;
                parameters[25] = new SqlParameter("@BVisaCountryID", SqlDbType.Int);
                parameters[25].Value = BVisaCountryID;

                parameters[26] = new SqlParameter("@WPS_PersonID", SqlDbType.VarChar,25);
                parameters[26].Value = WPS_PersonID;

                parameters[27] = new SqlParameter("@AddedBy_ID", SqlDbType.Int);
                parameters[27].Value = AddedBy_ID;

                return BaseDataAccessor.ExecuteWithResult("spUpdateEmployee_Personal", parameters);
            }
            #endregion
            #region Update_Emp_ContactInfo
            public static String Update_Emp_ContactInfo(Int32 EmpId, String Home_Addr1, String Home_Addr2, String City, String Home_State, Int32 Home_CountryID, String Work_Addr1, String Work_Addr2, String Work_City, String Work_State, Int32 Work_CountryID, String Home_Phone, String Mobile_Phone, String Work_Phone, String Work_Email, Int32 MaritalStatusID, Int32 EducationId, Int32 PhotoProfile, String PhotoPath)
            {

                SqlParameter[] parameters = new SqlParameter[19];

                parameters[0] = new SqlParameter("@EmpID", SqlDbType.Int);
                parameters[0].Value = EmpId;

                parameters[1] = new SqlParameter("@Home_Addr1", SqlDbType.VarChar, 50);
                parameters[1].Value = Home_Addr1;

                parameters[2] = new SqlParameter("@Home_Addr2", SqlDbType.VarChar, 50);
                parameters[2].Value = Home_Addr2;

                parameters[3] = new SqlParameter("@City", SqlDbType.VarChar,50);
                parameters[3].Value = City;

                parameters[4] = new SqlParameter("@State", SqlDbType.VarChar, 50);
                parameters[4].Value = Home_State;

                parameters[5] = new SqlParameter("@Home_CountryID", SqlDbType.Int);
                parameters[5].Value = Home_CountryID;

                parameters[6] = new SqlParameter("@Work_Addr1", SqlDbType.VarChar, 50);
                parameters[6].Value = Work_Addr1;

                parameters[7] = new SqlParameter("@Work_Addr2", SqlDbType.VarChar, 50);
                parameters[7].Value = Work_Addr2;

                parameters[8] = new SqlParameter("@Work_City", SqlDbType.VarChar, 50);
                parameters[8].Value = Work_City;

                parameters[9] = new SqlParameter("@Work_State", SqlDbType.VarChar, 50);
                parameters[9].Value = Work_State;

                parameters[10] = new SqlParameter("@Work_CountryID", SqlDbType.Int);
                parameters[10].Value = Work_CountryID;

                parameters[11] = new SqlParameter("@Home_Phone", SqlDbType.VarChar, 20);
                parameters[11].Value = Home_Phone;

                parameters[12] = new SqlParameter("@Mobile_Phone", SqlDbType.VarChar, 20);
                parameters[12].Value = Mobile_Phone;

                parameters[13] = new SqlParameter("@Work_Phone", SqlDbType.VarChar,20);
                parameters[13].Value = Work_Phone;

                parameters[14] = new SqlParameter("@Work_Email", SqlDbType.VarChar, 50);
                parameters[14].Value = Work_Email;

                parameters[15] = new SqlParameter("@MaritalStatusID", SqlDbType.Int);
                parameters[15].Value = MaritalStatusID;

                parameters[16] = new SqlParameter("@EducationId", SqlDbType.Int);
                parameters[16].Value = EducationId;

                parameters[17] = new SqlParameter("@PhotoProfile", SqlDbType.Int);
                parameters[17].Value = PhotoProfile;

                parameters[18] = new SqlParameter("@PhotoPath", SqlDbType.VarChar, 100);
                parameters[18].Value = PhotoPath;

               return BaseDataAccessor.ExecuteWithResult("spUpdateEmployee_Contact", parameters);
            }
            #endregion
            #region Update_Emp_DependentInfo
            public static String Update_Emp_DependentInfo(Int32 EmpId, String Name, Int32 RelationshipID, String DOB, Int32 GenderTypeID, String PassportNo, Int32 PPCountryID, String PassportIssueDate, String PassportExpDate, String VisaNumber, Int32 VisaTypeID, String VisaIssueDate, String VisaExpiryDate, Int32 Visa_IssueCountryID)
            {

                SqlParameter[] parameters = new SqlParameter[14];

                parameters[0] = new SqlParameter("@EmpID", SqlDbType.Int);
                parameters[0].Value = EmpId;

                parameters[1] = new SqlParameter("@FullName", SqlDbType.VarChar, 50);
                parameters[1].Value = Name;

                parameters[2] = new SqlParameter("@RelationshipId", SqlDbType.Int);
                parameters[2].Value = RelationshipID;

                parameters[3] = new SqlParameter("@DOB", SqlDbType.VarChar, 30);
                parameters[3].Value = DOB;

                parameters[4] = new SqlParameter("@GenderTypeID", SqlDbType.Int);
                parameters[4].Value = GenderTypeID;

                parameters[5] = new SqlParameter("@PassportNo", SqlDbType.VarChar, 30);
                parameters[5].Value = PassportNo;

                parameters[6] = new SqlParameter("@PPCountryID", SqlDbType.Int);
                parameters[6].Value = PPCountryID;

                parameters[7] = new SqlParameter("@PassportExpDate", SqlDbType.VarChar, 30);
                parameters[7].Value = PassportExpDate;

                parameters[8] = new SqlParameter("@PassportIssueDate", SqlDbType.VarChar, 30);
                parameters[8].Value = PassportIssueDate;

                parameters[9] = new SqlParameter("@VisaNumber", SqlDbType.VarChar, 30);
                parameters[9].Value = VisaNumber;

                parameters[10] = new SqlParameter("@VisaTypeID", SqlDbType.Int);
                parameters[10].Value = VisaTypeID;

                parameters[11] = new SqlParameter("@VisaIssueDate", SqlDbType.VarChar, 30);
                parameters[11].Value = VisaIssueDate;

                parameters[12] = new SqlParameter("@VisaExpiryDate", SqlDbType.VarChar, 30);
                parameters[12].Value = VisaExpiryDate;

                parameters[13] = new SqlParameter("@Visa_IssueCountryID", SqlDbType.Int);
                parameters[13].Value = Visa_IssueCountryID;

                return BaseDataAccessor.ExecuteWithResult("spUpdateEmployee_Dependent", parameters);
            }
            #endregion
            #region Update_Emp_EContactInfo
            public static String Update_Emp_EContactInfo(Int32 EmpId, String Name, Int32 RelationshipID,Int32 Contact_Priority, String HomePhone, String Mobile, String WorkPhone, String EmailAddr)
            {

                SqlParameter[] parameters = new SqlParameter[8];

                parameters[0] = new SqlParameter("@EmpID", SqlDbType.Int);
                parameters[0].Value = EmpId;

                parameters[1] = new SqlParameter("@ContactName", SqlDbType.VarChar, 50);
                parameters[1].Value = Name;

                parameters[2] = new SqlParameter("@RelationshipId", SqlDbType.Int);
                parameters[2].Value = RelationshipID;

                parameters[3] = new SqlParameter("@Contact_Priority", SqlDbType.Int);
                parameters[3].Value = Contact_Priority;

                parameters[4] = new SqlParameter("@HomePhone", SqlDbType.VarChar, 20);
                parameters[4].Value = HomePhone;

                parameters[5] = new SqlParameter("@Mobile", SqlDbType.VarChar,20);
                parameters[5].Value = Mobile;

                parameters[6] = new SqlParameter("@WorkPhone", SqlDbType.VarChar, 20);
                parameters[6].Value = WorkPhone;

                parameters[7] = new SqlParameter("@EmailAddr", SqlDbType.VarChar,100);
                parameters[7].Value = EmailAddr;

                return BaseDataAccessor.ExecuteWithResult("spUpdateEmployee_EContact", parameters);
            }
          #endregion
            #region Update_Emp_JobInfo
            public static String Update_Emp_JobInfo(Int32 EmpId, String Employee_ID, Int32 DesignationID, Int32 EmployeeCategoryID, Int32 EmployeeStatusID, Int32 DepartmentID, Int32 DivisionID, String HireDate, String CR_PositionEndDate, String New_PositionStartDate, String ResignedDate, String DateLeft, double ProbationYears, Int32 LineManagerID, Int32 SupervisoryRole, Int32 DivisionLocationID, String ProbationEndDate, Int32 ProbationCompleted, String PSEmployee_ID,Int32 LastUpdated_EmpID)
            {

                SqlParameter[] parameters = new SqlParameter[20];

                parameters[0] = new SqlParameter("@EmpID", SqlDbType.Int);
                parameters[0].Value = EmpId;

                parameters[1] = new SqlParameter("@Employee_ID", SqlDbType.VarChar, 25);
                parameters[1].Value = Employee_ID;

                parameters[2] = new SqlParameter("@DesignationID", SqlDbType.Int);
                parameters[2].Value = DesignationID;

                parameters[3] = new SqlParameter("@EmployeeCategoryID", SqlDbType.Int);
                parameters[3].Value = EmployeeCategoryID;

                parameters[4] = new SqlParameter("@EmployeeStatusID", SqlDbType.Int);
                parameters[4].Value = EmployeeStatusID;

                parameters[5] = new SqlParameter("@DepartmentID", SqlDbType.Int);
                parameters[5].Value = DepartmentID;

                parameters[6] = new SqlParameter("@DivisionID", SqlDbType.Int);
                parameters[6].Value = DivisionID;

                parameters[7] = new SqlParameter("@HireDate", SqlDbType.VarChar, 25);
                parameters[7].Value = HireDate;

                parameters[8] = new SqlParameter("@CR_PositionEndDate", SqlDbType.VarChar, 25);
                parameters[8].Value = CR_PositionEndDate;

                parameters[9] = new SqlParameter("@New_PositionStartDate", SqlDbType.VarChar, 25);
                parameters[9].Value = New_PositionStartDate;

                parameters[10] = new SqlParameter("@ResignedDate", SqlDbType.VarChar, 25);
                parameters[10].Value = ResignedDate;

                parameters[11] = new SqlParameter("@DateLeft", SqlDbType.VarChar, 25);
                parameters[11].Value = DateLeft;

                parameters[12] = new SqlParameter("@ProbationYears", SqlDbType.Decimal);
                parameters[12].Value = ProbationYears;

                parameters[13] = new SqlParameter("@LineManagerID", SqlDbType.Int);
                parameters[13].Value = LineManagerID;

                parameters[14] = new SqlParameter("@SupervisoryRole", SqlDbType.Int);
                parameters[14].Value = SupervisoryRole;

                parameters[15] = new SqlParameter("@DivisionLocationID", SqlDbType.Int);
                parameters[15].Value = DivisionLocationID;

                parameters[16] = new SqlParameter("@ProbationEndDate", SqlDbType.VarChar,25);
                parameters[16].Value = ProbationEndDate;

                parameters[17] = new SqlParameter("@ProbationCompleted", SqlDbType.Int);
                parameters[17].Value = ProbationCompleted;

                parameters[18] = new SqlParameter("PSEmployee_ID", SqlDbType.VarChar, 25);
                parameters[18].Value = PSEmployee_ID;

                parameters[19] = new SqlParameter("@LastUpdated_EmpID", SqlDbType.Int);
                parameters[19].Value = LastUpdated_EmpID;

                return BaseDataAccessor.ExecuteWithResult("spUpdateEmployee_Job", parameters);
            }
           #endregion
            #region Update_Emp_Compensation
            public static String Update_Emp_Compensation(Int32 EmpId, Int32 PayTypeId, String PayGrade, Double TotalPay, Double TotalAllowance, Int32 PayFRequencyID, Int32 PayPlanID, Int32 OTEligible, Int32 CalcMethodId)
            {

                SqlParameter[] parameters = new SqlParameter[9];

                parameters[0] = new SqlParameter("@EmpID", SqlDbType.Int);
                parameters[0].Value = EmpId;

                parameters[1] = new SqlParameter("@PayTypeID", SqlDbType.Int);
                parameters[1].Value = PayTypeId;

                parameters[2] = new SqlParameter("@PayGrade", SqlDbType.VarChar,50);
                parameters[2].Value = PayGrade;

                parameters[3] = new SqlParameter("@TotalPay", SqlDbType.Decimal);
                parameters[3].Value = TotalPay;

                parameters[4] = new SqlParameter("@TotalAllowance", SqlDbType.Decimal);
                parameters[4].Value = TotalAllowance;

                parameters[5] = new SqlParameter("@PayFRequencyID", SqlDbType.Int);
                parameters[5].Value = PayFRequencyID;

                parameters[6] = new SqlParameter("@PayPlanID", SqlDbType.Int);
                parameters[6].Value = PayPlanID;

                parameters[7] = new SqlParameter("@OTEligible", SqlDbType.Int);
                parameters[7].Value = OTEligible;

                parameters[8] = new SqlParameter("@CalcMethodId", SqlDbType.Int);
                parameters[8].Value = CalcMethodId;

                return BaseDataAccessor.ExecuteWithResult("spUpdateEmployee_Pay", parameters);
            }
            #endregion

            #region AddUpdateEmployeeBenefit
            public static String AddUpdateEmployeeBenefit(Int32 EmpId, Int32 PayComponentID, Decimal Amount, Int32 ChangeType,Int32 EditEmpId)
            {

                SqlParameter[] parameters = new SqlParameter[5];
                parameters[0] = new SqlParameter("@EmpID", SqlDbType.Int);
                parameters[0].Value = EmpId;
                parameters[1] = new SqlParameter("@PayComponentID", SqlDbType.Int);
                parameters[1].Value = PayComponentID;
                parameters[2] = new SqlParameter("@Amount", SqlDbType.Money);
                parameters[2].Value = Amount;
                parameters[3] = new SqlParameter("@ChangeType", SqlDbType.Int);
                parameters[3].Value = ChangeType;
                parameters[4] = new SqlParameter("@EditEmpId", SqlDbType.Int);
                parameters[4].Value = EditEmpId;
                return BaseDataAccessor.ExecuteWithResult("spAddUpdateEmployee_Benefit", parameters);
            }
          #endregion

            #region AddUpdateAdocEmployeeMonthlyPayComponents
            public static String AddUpdateAdocEmployeeMonthlyPayComponents(Int32 EmpId, Int32 PayComponentID, Decimal Amount, String Reason, String Pay_MonthYear, Int32 EditEmpId)
            {

                SqlParameter[] parameters = new SqlParameter[6];
                parameters[0] = new SqlParameter("@EmpID", SqlDbType.Int);
                parameters[0].Value = EmpId;
                parameters[1] = new SqlParameter("@PayComponentID", SqlDbType.Int);
                parameters[1].Value = PayComponentID;
                parameters[2] = new SqlParameter("@Amount", SqlDbType.Money);
                parameters[2].Value = Amount;
                parameters[3] = new SqlParameter("@Reason", SqlDbType.VarChar, 100);
                parameters[3].Value = Reason;
                parameters[4] = new SqlParameter("@Pay_MonthYear", SqlDbType.VarChar, 30);
                parameters[4].Value = Pay_MonthYear;                
                parameters[5] = new SqlParameter("@EditEmpId", SqlDbType.Int);
                parameters[5].Value = EditEmpId;
                return BaseDataAccessor.ExecuteWithResult("spAddUpdateEmployee_MonthlyAdhocBenefit", parameters);
            }
            #endregion


           #region AddUpdateGratuityRules
            public static String AddUpdateGratuityRules(Int32 GratuityRuleID, Int32 DivisionID, Int32 LocationID, Int32 GratuityTypeID,Int32 Param1_Days, Decimal Param1_Percentage,Int32 Param2_Days,Decimal Param2_Percentage,Int32 MaximumYRConstraint,Int32 RequestorID)
            {

                SqlParameter[] parameters = new SqlParameter[10];
                parameters[0] = new SqlParameter("@GratuityRuleID", SqlDbType.Int);
                parameters[0].Value = GratuityRuleID;
                parameters[1] = new SqlParameter("@DivisionID", SqlDbType.Int);
                parameters[1].Value = DivisionID;
                parameters[2] = new SqlParameter("@LocationID", SqlDbType.Int);
                parameters[2].Value = LocationID;
                parameters[3] = new SqlParameter("@GratuityTypeID", SqlDbType.Int);
                parameters[3].Value = GratuityTypeID;
                parameters[4] = new SqlParameter("@Param1_Days", SqlDbType.Int);
                parameters[4].Value = Param1_Days;
                parameters[5] = new SqlParameter("@Param1_Percentage", SqlDbType.Decimal);
                parameters[5].Value = Param1_Percentage;
                parameters[6] = new SqlParameter("@Param2_Days", SqlDbType.Int);
                parameters[6].Value = Param2_Days;
                parameters[7] = new SqlParameter("@Param2_Percentage", SqlDbType.Int);
                parameters[7].Value = Param2_Percentage;
                parameters[8] = new SqlParameter("@MaxYRConstraint", SqlDbType.Int);
                parameters[8].Value = MaximumYRConstraint;
                parameters[9] = new SqlParameter("@RequestorID", SqlDbType.Int);
                parameters[9].Value = RequestorID;
                return BaseDataAccessor.ExecuteWithResult("spAddUpdateGratuityRules", parameters);
            }
          #endregion


          #region AddUpdateEmployeeDeductions
            public static String AddUpdateEmployeeDeductions(Int32 EmpId, Int32 DeductionID, Int32 PayComponentID, Decimal Amount, Int32 RepaymentMonths, String RepaymentStartDate, Int32 EditEmpId)
            {

                SqlParameter[] parameters = new SqlParameter[7];
                parameters[0] = new SqlParameter("@EmpID", SqlDbType.Int);
                parameters[0].Value = EmpId;
                parameters[1] = new SqlParameter("@DeductionID", SqlDbType.Int);
                parameters[1].Value = DeductionID;
                parameters[2] = new SqlParameter("@PayComponentID", SqlDbType.Int);
                parameters[2].Value = PayComponentID;
                parameters[3] = new SqlParameter("@Advance_DedAmount", SqlDbType.Money);
                parameters[3].Value = Amount;
                parameters[4] = new SqlParameter("@RepaymentMonths", SqlDbType.Int);
                parameters[4].Value = RepaymentMonths;
                parameters[5] = new SqlParameter("@Repayment_StartMonthYear", SqlDbType.VarChar, 20);
                parameters[5].Value = RepaymentStartDate;
                parameters[6] = new SqlParameter("@EditEmpId", SqlDbType.Int);
                parameters[6].Value = EditEmpId;
                return BaseDataAccessor.ExecuteWithResult("spAddUpdateEmployee_Deductions", parameters);
            }
          #endregion

            #region AddUpdateDailyFNTransactions
            public static String AddUpdateDailyFNTransactions(Int32 EmpID,Int32 PayComponentID,Decimal Amount,Int32 EditEmpId)
            {

                SqlParameter[] parameters = new SqlParameter[4];
                parameters[0] = new SqlParameter("@EmpID", SqlDbType.Int);
                parameters[0].Value = EmpID;
                parameters[1] = new SqlParameter("@PayComponentID", SqlDbType.Int);
                parameters[1].Value = PayComponentID;
                parameters[2] = new SqlParameter("@Amount", SqlDbType.Money);
                parameters[2].Value = Amount;
                parameters[3] = new SqlParameter("@EditEmpId", SqlDbType.Int);
                parameters[3].Value = EditEmpId;
                return BaseDataAccessor.ExecuteWithResult("spAddUpdateDailyFNTransactions", parameters);
            }
            #endregion
            #region AddUpdateGenTransactions
            public static String AddUpdateGenTransactions(Int32 EmpID, Int32 DataTypeID, String InstrumentNo, String IssueDate, String ExpiryDate,Int32 CountryID, Int32 VisaTypeID, Int32 EditEmpId)
            {

                SqlParameter[] parameters = new SqlParameter[8];
                parameters[0] = new SqlParameter("@EmpID", SqlDbType.Int);
                parameters[0].Value = EmpID;
                parameters[1] = new SqlParameter("@DataTypeID", SqlDbType.Int);
                parameters[1].Value = DataTypeID;
                parameters[2] = new SqlParameter("@InstrumentNo", SqlDbType.VarChar,50);
                parameters[2].Value = InstrumentNo;
                parameters[3] = new SqlParameter("@Issue_Date", SqlDbType.VarChar,30);
                parameters[3].Value = IssueDate;
                parameters[4] = new SqlParameter("@Expiry_Date", SqlDbType.VarChar, 30);
                parameters[4].Value = ExpiryDate;
                parameters[5] = new SqlParameter("@CountryID", SqlDbType.Int);
                parameters[5].Value = CountryID;
                parameters[6] = new SqlParameter("@VisaTypeID", SqlDbType.Int);
                parameters[6].Value = VisaTypeID;
                parameters[7] = new SqlParameter("@EditEmpId", SqlDbType.Int);
                parameters[7].Value = EditEmpId;
                return BaseDataAccessor.ExecuteWithResult("spAddUpdateGeneralTransactions", parameters);
            }
            #endregion

            #region ValidateImportedFinanceTransactions
            public static  DataSet ValidateImportedFinanceTransactions(Int32 EditEmpId)
            {

                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@EditEmpId", SqlDbType.Int);
                parameters[0].Value = EditEmpId;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spValidateImportedFinanceTrans", parameters);
                return dataSet;                
            }
            #endregion
            #region ValidateImportedTransactions
            public static DataSet ValidateImportedTransactions(Int32 EditEmpId, String TransactionType)
            {

                SqlParameter[] parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@EditEmpId", SqlDbType.Int);
                parameters[0].Value = EditEmpId;

                parameters[1] = new SqlParameter("@TransactionType", SqlDbType.VarChar, 50);
                parameters[1].Value = TransactionType;
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spValidateImportedTransactions", parameters);
                return dataSet;
            }
           #endregion


            #region AddUpdateEmployeeBankInformation
            public static String AddUpdateEmployeeBankInformation(Int32 EmpId, String BankAccountNumber,Int32 BankId, Int32 EditEmpId)
            {

                SqlParameter[] parameters = new SqlParameter[7];
                parameters[0] = new SqlParameter("@EmpID", SqlDbType.Int);
                parameters[0].Value = EmpId;
                parameters[1] = new SqlParameter("@BankAccount", SqlDbType.VarChar,30);
                parameters[1].Value = BankAccountNumber;
                parameters[2] = new SqlParameter("@BankId", SqlDbType.Int);
                parameters[2].Value = BankId;
                parameters[3] = new SqlParameter("@EditEmpId", SqlDbType.Int);
                parameters[3].Value = EditEmpId;
                return BaseDataAccessor.ExecuteWithResult("spAddUpdateEmployee_BankInfo", parameters);
            }
          #endregion


            #region AddUpdateEmployee_MonthlyPayroll
            public static String AddUpdateEmployee_MonthlyPayroll(Int32 EmpId, String Pay_MonthYear, Int32 TotalDays_PayCycle, Decimal TotalDays_Unpaid, Decimal NetPayDays, String BankAccount, Int32 BankID, String PayrollNote, Int32 PayrollStatusTypeID, Int32 Last_UpdatedEmpId)
            {

                SqlParameter[] parameters = new SqlParameter[10];

                parameters[0] = new SqlParameter("@EmpID", SqlDbType.Int);
                parameters[0].Value = EmpId;
                parameters[1] = new SqlParameter("@Pay_MonthYear", SqlDbType.VarChar,20);
                parameters[1].Value = Pay_MonthYear;
                parameters[2] = new SqlParameter("@TotalDays_PayCycle", SqlDbType.Int);
                parameters[2].Value = TotalDays_PayCycle;
                parameters[3] = new SqlParameter("@TotalDays_Unpaid", SqlDbType.Decimal);
                parameters[3].Value = TotalDays_Unpaid;
                parameters[4] = new SqlParameter("@NetPayDays", SqlDbType.Decimal);
                parameters[4].Value = NetPayDays;
                parameters[5] = new SqlParameter("@BankAccount", SqlDbType.VarChar, 30);
                parameters[5].Value = BankAccount;
                parameters[6] = new SqlParameter("@BankID", SqlDbType.Int);
                parameters[6].Value = BankID;
                parameters[7] = new SqlParameter("@PayrollNote", SqlDbType.VarChar,500);
                parameters[7].Value = PayrollNote;
                parameters[8] = new SqlParameter("@PayrollStatusTypeID", SqlDbType.Int);
                parameters[8].Value = PayrollStatusTypeID;
                parameters[9] = new SqlParameter("@Last_UpdatedEmpId", SqlDbType.Int);
                parameters[9].Value = @Last_UpdatedEmpId;

                return BaseDataAccessor.ExecuteWithResult("spAddUpdateEmployee_Payroll", parameters);
            }
            #endregion

            #region AddUpdateEmployee_EOSPayroll
            public static String AddUpdateEmployee_EOSPayroll(Int32 EmpId, String Pay_MonthYear, Int32 TotalDays_PayCycle, Decimal TotalDays_Unpaid, Decimal NetPayDays, String BankAccount, Int32 BankID, String PayrollNote, Int32 PayrollStatusTypeID, Int32 Last_UpdatedEmpId)
            {

                SqlParameter[] parameters = new SqlParameter[10];

                parameters[0] = new SqlParameter("@EmpID", SqlDbType.Int);
                parameters[0].Value = EmpId;
                parameters[1] = new SqlParameter("@Pay_MonthYear", SqlDbType.VarChar, 20);
                parameters[1].Value = Pay_MonthYear;
                parameters[2] = new SqlParameter("@TotalDays_PayCycle", SqlDbType.Int);
                parameters[2].Value = TotalDays_PayCycle;
                parameters[3] = new SqlParameter("@TotalDays_Unpaid", SqlDbType.Decimal);
                parameters[3].Value = TotalDays_Unpaid;
                parameters[4] = new SqlParameter("@NetPayDays", SqlDbType.Decimal);
                parameters[4].Value = NetPayDays;
                parameters[5] = new SqlParameter("@BankAccount", SqlDbType.VarChar, 30);
                parameters[5].Value = BankAccount;
                parameters[6] = new SqlParameter("@BankID", SqlDbType.Int);
                parameters[6].Value = BankID;
                parameters[7] = new SqlParameter("@PayrollNote", SqlDbType.VarChar, 500);
                parameters[7].Value = PayrollNote;
                parameters[8] = new SqlParameter("@PayrollStatusTypeID", SqlDbType.Int);
                parameters[8].Value = PayrollStatusTypeID;
                parameters[9] = new SqlParameter("@Last_UpdatedEmpId", SqlDbType.Int);
                parameters[9].Value = @Last_UpdatedEmpId;

                return BaseDataAccessor.ExecuteWithResult("spAddUpdateEmployee_EOSPayroll", parameters);
            }
            #endregion

            #region Update_Emp_Documents
            public static String Update_Emp_Documents(Int32 EmpId, Int32 DocumentTypeID, String DocumentName, String Document_Location, String Doc_Comments)
            {

                SqlParameter[] parameters = new SqlParameter[5];

                parameters[0] = new SqlParameter("@EmpID", SqlDbType.Int);
                parameters[0].Value = EmpId;

                parameters[1] = new SqlParameter("@DocumentTypeID", SqlDbType.Int);
                parameters[1].Value = DocumentTypeID;

                parameters[2] = new SqlParameter("@DocumentName", SqlDbType.VarChar, 100);
                parameters[2].Value = DocumentName;

                parameters[3] = new SqlParameter("@Document_Location", SqlDbType.VarChar, 100);
                parameters[3].Value = Document_Location;

                parameters[4] = new SqlParameter("@Doc_Comments", SqlDbType.VarChar,200);
                parameters[4].Value = Doc_Comments;                    

                return BaseDataAccessor.ExecuteWithResult("spUpdateEmployee_Document", parameters);
            }
            #endregion
            #region UpdateDocuments
            public static String UpdateDocuments(Int32 EmpId, Int32 DocumentTypeID, Int32 DocumentVisibilityID, String DocumentName, String Document_Location, String Doc_Comments)
            {

                SqlParameter[] parameters = new SqlParameter[6];

                parameters[0] = new SqlParameter("@EmpID", SqlDbType.Int);
                parameters[0].Value = EmpId;

                parameters[1] = new SqlParameter("@DocumentTypeID", SqlDbType.Int);
                parameters[1].Value = DocumentTypeID;

                parameters[2] = new SqlParameter("@DocumentVisibilityID", SqlDbType.Int);
                parameters[2].Value = DocumentVisibilityID;

                parameters[3] = new SqlParameter("@DocumentName", SqlDbType.VarChar, 100);
                parameters[3].Value = DocumentName;

                parameters[4] = new SqlParameter("@Document_Location", SqlDbType.VarChar, 100);
                parameters[4].Value = Document_Location;

                parameters[5] = new SqlParameter("@Doc_Comments", SqlDbType.VarChar, 200);
                parameters[5].Value = Doc_Comments;

                return BaseDataAccessor.ExecuteWithResult("spUpdate_Document", parameters);
            }
           #endregion
            #region DeleteEmployeeDocument
            public static String DeleteEmployeeDocument(Int32 EmpId, Int32 DocumentId)
            {

                SqlParameter[] parameters = new SqlParameter[2];

                parameters[0] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[0].Value = EmpId;
                parameters[1] = new SqlParameter("@DocumentId", SqlDbType.Int);
                parameters[1].Value = DocumentId;

               return  BaseDataAccessor.ExecuteWithResult("spDeleteEmployee_Document", parameters);
            }
            #endregion
            #region DeleteEmployeeSkill
            public static String DeleteEmployeeSkill(Int32 Emp_SkillId,Int32 EmpId )
            {

                SqlParameter[] parameters = new SqlParameter[2];

                parameters[0] = new SqlParameter("@Emp_SkillID", SqlDbType.Int);
                parameters[0].Value = Emp_SkillId;

                parameters[1] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[1].Value = EmpId;

                return BaseDataAccessor.ExecuteWithResult("spDeleteEmployee_Skill", parameters);
            }
           #endregion
            #region DeleteEmployeeCertification
            public static String DeleteEmployeeCertification(Int32 Emp_CertId, Int32 EmpId)
            {

                SqlParameter[] parameters = new SqlParameter[2];

                parameters[0] = new SqlParameter("@Emp_CertId", SqlDbType.Int);
                parameters[0].Value = Emp_CertId;

                parameters[1] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[1].Value = EmpId;

                return BaseDataAccessor.ExecuteWithResult("spDeleteEmployee_Certification", parameters);
            }
            #endregion
            #region DeleteEmployeeEducation
            public static String DeleteEmployeeEducation(Int32 Emp_EduId, Int32 EmpId)
            {

                SqlParameter[] parameters = new SqlParameter[2];

                parameters[0] = new SqlParameter("@Emp_EduId", SqlDbType.Int);
                parameters[0].Value = Emp_EduId;

                parameters[1] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[1].Value = EmpId;

                return BaseDataAccessor.ExecuteWithResult("spDeleteEmployee_Education", parameters);
            }
            #endregion
            #region DeleteEmployeeExperience
            public static String DeleteEmployeeExperience(Int32 Emp_WorkExpID, Int32 EmpId)
            {

                SqlParameter[] parameters = new SqlParameter[2];

                parameters[0] = new SqlParameter("@Emp_WorkExpID", SqlDbType.Int);
                parameters[0].Value = Emp_WorkExpID;

                parameters[1] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[1].Value = EmpId;

                return BaseDataAccessor.ExecuteWithResult("spDeleteEmployee_WorkExperience", parameters);
            }
            #endregion

            #region DeleteEmployeeLanguage
            public static String DeleteEmployeeLanguage(Int32 Emp_LangID, Int32 EmpId)
            {

                SqlParameter[] parameters = new SqlParameter[2];

                parameters[0] = new SqlParameter("@Emp_LangID", SqlDbType.Int);
                parameters[0].Value = Emp_LangID;

                parameters[1] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[1].Value = EmpId;

                return BaseDataAccessor.ExecuteWithResult("spDeleteEmployee_Language", parameters);
            }
            #endregion

            #region DeleteGratuityRule
            public static String DeleteGratuityRule(Int32 GratuityRuleID, Int32 EmpId)
            {

                SqlParameter[] parameters = new SqlParameter[2];

                parameters[0] = new SqlParameter("@GratuityRuleID", SqlDbType.Int);
                parameters[0].Value = GratuityRuleID;

                parameters[1] = new SqlParameter("@EditEmpID", SqlDbType.Int);
                parameters[1].Value = EmpId;

                return BaseDataAccessor.ExecuteWithResult("spDeleteGratuityRule", parameters);
            }
            #endregion

            #region DeletePayComponent
            public static String DeletePayComponent(Int32 PayComponentID,Int32 PayComponentTypeID, Int32 EmpId)
            {

                SqlParameter[] parameters = new SqlParameter[3];

                parameters[0] = new SqlParameter("@PayComponentID", SqlDbType.Int);
                parameters[0].Value = PayComponentID;
                parameters[1] = new SqlParameter("@PayComponentTypeID", SqlDbType.Int);
                parameters[1].Value = PayComponentTypeID;
                parameters[2] = new SqlParameter("@EditEmpID", SqlDbType.Int);
                parameters[2].Value = EmpId;

                return BaseDataAccessor.ExecuteWithResult("spDeletePayComponent", parameters);
            }
            #endregion
            #region DeleteEmployeeRequest
            public static String DeleteEmployeeRequest(Int32 RequestID, Int32 EmpId)
            {

                SqlParameter[] parameters = new SqlParameter[2];

                parameters[0] = new SqlParameter("@RequestID", SqlDbType.Int);
                parameters[0].Value = RequestID;

                parameters[1] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[1].Value = EmpId;

                return BaseDataAccessor.ExecuteWithResult("spDeleteEmployeeRequest", parameters);
            }
            #endregion

            #region DeleteEmployeeMembership
            public static String DeleteEmployeeMembership(Int32 Emp_MemID, Int32 EmpId)
            {

                SqlParameter[] parameters = new SqlParameter[2];

                parameters[0] = new SqlParameter("@Emp_MemID", SqlDbType.Int);
                parameters[0].Value = Emp_MemID;

                parameters[1] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[1].Value = EmpId;

                return BaseDataAccessor.ExecuteWithResult("spDeleteEmployee_Membership", parameters);
            }
            #endregion
            #region DeleteEmployeeTraining
            public static String DeleteEmployeeTraining(Int32 Emp_TrainingID, Int32 EmpId)
            {

                SqlParameter[] parameters = new SqlParameter[2];

                parameters[0] = new SqlParameter("@Emp_TrainingID", SqlDbType.Int);
                parameters[0].Value = Emp_TrainingID;

                parameters[1] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[1].Value = EmpId;

                return BaseDataAccessor.ExecuteWithResult("spDeleteEmployee_Training", parameters);
            }
            #endregion

            #region DeleteBusinessDivision
            public static String DeleteBusinessDivision(Int32 RequestorID,Int32 DivisionID)
            {

                SqlParameter[] parameters = new SqlParameter[2];

                parameters[0] = new SqlParameter("@RequestorID", SqlDbType.Int);
                parameters[0].Value = RequestorID;

                parameters[1] = new SqlParameter("@DivisionID", SqlDbType.Int);
                parameters[1].Value = DivisionID;

                return BaseDataAccessor.ExecuteWithResult("spDeleteBusinessDivision", parameters);
            }
            #endregion
            #region DeleteDivisionLocation
            public static String DeleteDivisionLocation(Int32 RequestorID,Int32 DivisionID, Int32 LocationID)
            {

                SqlParameter[] parameters = new SqlParameter[3];
                parameters[0] = new SqlParameter("@RequestorID", SqlDbType.Int);
                parameters[0].Value = RequestorID;

                parameters[1] = new SqlParameter("@DivisionID", SqlDbType.Int);
                parameters[1].Value = DivisionID;

                parameters[2] = new SqlParameter("@LocationID", SqlDbType.Int);
                parameters[2].Value = LocationID;

                return BaseDataAccessor.ExecuteWithResult("spDeleteDivisionLocation", parameters);
            }
          #endregion

            #region DeleteEmployeeBenefit
            public static String DeleteEmployeeBenefit(Int32 EmpId, Int32 PayComponentID, Int32 EditEmpID)
            {

                SqlParameter[] parameters = new SqlParameter[3];
                parameters[0] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[0].Value = EmpId;

                parameters[1] = new SqlParameter("@PayComponentID", SqlDbType.Int);
                parameters[1].Value = PayComponentID;

                parameters[2] = new SqlParameter("@EditEmpID", SqlDbType.Int);
                parameters[2].Value = EditEmpID;

                return BaseDataAccessor.ExecuteWithResult("spDeleteEmployeeBenefit", parameters);
            }
            #endregion

            #region DeleteEmployeeDeductions
            public static String DeleteEmployeeDeductions(Int32 EmpId, Int32 DeductionID, Int32 PayComponentID, Int32 EditEmpID)
            {

                SqlParameter[] parameters = new SqlParameter[4];
                parameters[0] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[0].Value = EmpId;

                parameters[1] = new SqlParameter("@DeductionID", SqlDbType.Int);
                parameters[1].Value = DeductionID;

                parameters[2] = new SqlParameter("@PayComponentID", SqlDbType.Int);
                parameters[2].Value = PayComponentID;

                parameters[3] = new SqlParameter("@EditEmpID", SqlDbType.Int);
                parameters[3].Value = EditEmpID;

                return BaseDataAccessor.ExecuteWithResult("spDeleteEmployeeDeductions", parameters);
            }
            #endregion
            #region DeleteEmployeeAdhocPayComponent
            public static String DeleteEmployeeAdhocPayComponent(Int32 EmpId, Int32 PayComponentID, String Payroll_MonthYear, Int32 EditEmpID)
            {

                SqlParameter[] parameters = new SqlParameter[4];
                parameters[0] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[0].Value = EmpId;
                parameters[1] = new SqlParameter("@PayComponentID", SqlDbType.Int);
                parameters[1].Value = PayComponentID;
                parameters[2] = new SqlParameter("@Payroll_MonthYear", SqlDbType.VarChar,30);
                parameters[2].Value = Payroll_MonthYear;
                parameters[3] = new SqlParameter("@EditEmpID", SqlDbType.Int);
                parameters[3].Value = EditEmpID;

                return BaseDataAccessor.ExecuteWithResult("spDeleteEmployeeAdhocComponents", parameters);
            }
            #endregion
            #region DeleteEmployeeDailyFNTEntry
            public static String DeleteEmployeeDailyFNTEntry(Int32 EmpId, Int32 PayComponentID,Int32 EditEmpID)
            {

                SqlParameter[] parameters = new SqlParameter[3];
                parameters[0] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[0].Value = EmpId;
                parameters[1] = new SqlParameter("@PayComponentID", SqlDbType.Int);
                parameters[1].Value = PayComponentID;
                parameters[2] = new SqlParameter("@EditEmpID", SqlDbType.Int);
                parameters[2].Value = EditEmpID;

                return BaseDataAccessor.ExecuteWithResult("spDeleteDailyFNTEntry", parameters);
            }
            #endregion


            #region DeleteWorkWeek
            public static String DeleteWorkWeek(Int32 CountryId, Int32 EditEmpID)
            {

                SqlParameter[] parameters = new SqlParameter[2];

                parameters[0] = new SqlParameter("@CountryId", SqlDbType.Int);
                parameters[0].Value = CountryId;
                parameters[1] = new SqlParameter("@EditEmpID", SqlDbType.Int);
                parameters[1].Value = EditEmpID;

                return BaseDataAccessor.ExecuteWithResult("spDeleteWorkWeek", parameters);
            }
          #endregion

            #region DeleteDocument
            public static String DeleteDocument(Int32 DocumentId)
            {

                SqlParameter[] parameters = new SqlParameter[1];

                parameters[0] = new SqlParameter("@DocumentId", SqlDbType.Int);
                parameters[0].Value = DocumentId;
                return BaseDataAccessor.ExecuteWithResult("spDeleteDocument", parameters);
            }
           #endregion

            #region DeleteEmployeeEContact
            public static String DeleteEmployeeEContact(Int32 EmpId, Int32 EContactID)
            {

                SqlParameter[] parameters = new SqlParameter[2];

                parameters[0] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[0].Value = EmpId;
                parameters[1] = new SqlParameter("@EContactID", SqlDbType.Int);
                parameters[1].Value = EContactID;

                return BaseDataAccessor.ExecuteWithResult("spDeleteEmployee_EContact", parameters);
            }
           #endregion
            #region DeleteEmployeeEContact
           public static String DeleteEmployeeDependent(Int32 EmpId, Int32 DependentID)
            {

                SqlParameter[] parameters = new SqlParameter[2];

                parameters[0] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[0].Value = EmpId;
                parameters[1] = new SqlParameter("@DependentID", SqlDbType.Int);
                parameters[1].Value = DependentID;

                return BaseDataAccessor.ExecuteWithResult("spDeleteEmployee_Dependent", parameters);
            }
                       #endregion
            #region DeleteLeaveType
            public static String DeleteLeaveType(Int32 LeaveTypeID)
            {

                SqlParameter[] parameters = new SqlParameter[1];

                parameters[0] = new SqlParameter("@LeaveTypeID", SqlDbType.Int);
                parameters[0].Value = LeaveTypeID;

                return BaseDataAccessor.ExecuteWithResult("spDeleteLeaveType", parameters);
            }
            #endregion
            #region DeleteHoliday
            public static String DeleteHoliday(Int32 HolidayID)
            {

                SqlParameter[] parameters = new SqlParameter[1];

                parameters[0] = new SqlParameter("@HolidayID", SqlDbType.Int);
                parameters[0].Value = HolidayID;

                return BaseDataAccessor.ExecuteWithResult("spDeleteHoliday", parameters);
            }
           #endregion

            #region DeleteUserAccount
            public static String DeleteUserAccount(Int32 EmpId)
            {

                SqlParameter[] parameters = new SqlParameter[1];

                parameters[0] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[0].Value = EmpId;

                return BaseDataAccessor.ExecuteWithResult("spDeleteUserAccount", parameters);
            }
           #endregion


            #region DeleteLeaveRequest
            public static String DeleteLeaveRequest(Int32 LeaveRequestId, Int32 EmpId)
            {

                SqlParameter[] parameters = new SqlParameter[2];

                parameters[0] = new SqlParameter("@LeaveRequestId", SqlDbType.Int);
                parameters[0].Value = LeaveRequestId;

                parameters[1] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[1].Value = EmpId;

                return BaseDataAccessor.ExecuteWithResult("spDeleteLeaveRequest", parameters);
            }
            #endregion
            #region DeleteLeaveRequest
            public static String DeleteLeaveEntitlement(Int32 EntitlementID, Int32 EmpId)
            {

                SqlParameter[] parameters = new SqlParameter[2];

                parameters[0] = new SqlParameter("@EntitlementID", SqlDbType.Int);
                parameters[0].Value = EntitlementID;

                parameters[1] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[1].Value = EmpId;

                return BaseDataAccessor.ExecuteWithResult("spDeleteLeaveEntitlement", parameters);
            }
         #endregion
         #region DeleteCustomer
            public static String DeleteCustomer(Int32 CustomerID,Int32 RequestorID)
            {

                SqlParameter[] parameters = new SqlParameter[2];

                parameters[0] = new SqlParameter("@CustomerID", SqlDbType.Int);
                parameters[0].Value = CustomerID;

                parameters[1] = new SqlParameter("@RequestorID", SqlDbType.Int);
                parameters[1].Value = RequestorID;

                return BaseDataAccessor.ExecuteWithResult("spDeleteCustomer", parameters);
            }
           #endregion
            #region DeleteEmployeeTimeSheet
            public static String DeleteEmployeeTimeSheet(Int32 TimeSheetID, Int32 RequestorID)
            {

                SqlParameter[] parameters = new SqlParameter[2];

                parameters[0] = new SqlParameter("@TimeSheetID", SqlDbType.Int);
                parameters[0].Value = TimeSheetID;

                parameters[1] = new SqlParameter("@RequestorID", SqlDbType.Int);
                parameters[1].Value = RequestorID;

                return BaseDataAccessor.ExecuteWithResult("spDeleteEmployeeTimeSheet", parameters);
            }
            #endregion

            #region DeleteCustomerProject
            public static String DeleteCustomerProject(Int32 ProjectID, Int32 RequestorID)
            {

                SqlParameter[] parameters = new SqlParameter[2];

                parameters[0] = new SqlParameter("@ProjectID", SqlDbType.Int);
                parameters[0].Value = ProjectID;

                parameters[1] = new SqlParameter("@RequestorID", SqlDbType.Int);
                parameters[1].Value = RequestorID;

                return BaseDataAccessor.ExecuteWithResult("spDeleteCustomerProject", parameters);
            }
            #endregion
            #region DeleteCustomerProjectActivity
            public static String DeleteCustomerProjectActivity(Int32 ProjectID,Int32 ActivityID, Int32 RequestorID)
            {

                SqlParameter[] parameters = new SqlParameter[3];

                parameters[0] = new SqlParameter("@ProjectID", SqlDbType.Int);
                parameters[0].Value = ProjectID;

                parameters[1] = new SqlParameter("@ActivityID", SqlDbType.Int);
                parameters[1].Value = ActivityID;

                parameters[2] = new SqlParameter("@RequestorID", SqlDbType.Int);
                parameters[2].Value = RequestorID;

                return BaseDataAccessor.ExecuteWithResult("spDeleteCustomerProjectActivity", parameters);
            }
            #endregion


			#region Add/Update Members
			public static String AddNewMembers(String Name,String EmailAddress,String Password,String CompanyName,Int32 MemberTypeID,Boolean TermsAndCondCheck)
			{
			
				SqlParameter[] parameters = new SqlParameter[7];

				parameters[0] = new SqlParameter("@MemberName", SqlDbType.VarChar,30);
				parameters[0].Value = Name;

				parameters[1] = new SqlParameter("@EmailAddress", SqlDbType.VarChar,50);
				parameters[1].Value = EmailAddress;

				parameters[2] = new SqlParameter("@Password", SqlDbType.VarChar,30);
				parameters[2].Value = Password;

				parameters[3] = new SqlParameter("@CompanyName", SqlDbType.VarChar,50);
				parameters[3].Value = CompanyName;

				parameters[4] = new SqlParameter("@MemberTypeID", SqlDbType.Int);
				parameters[4].Value = MemberTypeID;

				parameters[5] = new SqlParameter("@TermsAndCondCheck", SqlDbType.Bit);
				parameters[5].Value = TermsAndCondCheck;

				return BaseDataAccessor.ExecuteWithResult("spAddMember",parameters);
			}
			#endregion

			#region Post Ad Details
			public static String PostAdInfo(String BusinessName,Int32 CategoryID,String Address1, String Address2, String City, String State, String ZipCode, Int32 CityID, String AdTitle, String AdDescription,String BusinessPhone,String BusinessEmail, String ContactPerson,String WebPage,Boolean TermsAndCondCheck,String MemberEmail)
			{
			
				SqlParameter[] parameters = new SqlParameter[17];
			
				parameters[0] = new SqlParameter("@BusinessName", SqlDbType.VarChar,50);
				parameters[0].Value = BusinessName;

				parameters[1] = new SqlParameter("@CategoryID", SqlDbType.Int);
				parameters[1].Value = CategoryID;

				parameters[2] = new SqlParameter("@Address1", SqlDbType.VarChar,50);
				parameters[2].Value = Address1;

				parameters[3] = new SqlParameter("@Address2", SqlDbType.VarChar,50);
				parameters[3].Value = Address2;

				parameters[4] = new SqlParameter("@City", SqlDbType.VarChar,50);
				parameters[4].Value = City;

				parameters[5] = new SqlParameter("@State", SqlDbType.VarChar,50);
				parameters[5].Value = State;

				parameters[6] = new SqlParameter("@ZipCode", SqlDbType.VarChar,50);
				parameters[6].Value = ZipCode;

				parameters[7] = new SqlParameter("@CityID", SqlDbType.Int);
				parameters[7].Value = CityID;

				parameters[8] = new SqlParameter("@AdTitle", SqlDbType.VarChar,100);
				parameters[8].Value = AdTitle;

				parameters[9] = new SqlParameter("@AdDescription", SqlDbType.VarChar,500);
				parameters[9].Value = AdDescription;

				parameters[10] = new SqlParameter("@BusinessPhone", SqlDbType.VarChar,20);
				parameters[10].Value = BusinessPhone;

				parameters[11] = new SqlParameter("@BusinesEmail", SqlDbType.VarChar,50);
				parameters[11].Value = BusinessEmail;

				parameters[12] = new SqlParameter("@ContactPerson", SqlDbType.VarChar,50);
				parameters[12].Value = ContactPerson;

				parameters[13] = new SqlParameter("@WebPage", SqlDbType.VarChar,50);
				parameters[13].Value = WebPage;

				parameters[14] = new SqlParameter("@TermsAndCondCheck", SqlDbType.Bit);
				parameters[14].Value = TermsAndCondCheck;

				parameters[15] = new SqlParameter("@MemberEmail", SqlDbType.VarChar,50);
				parameters[15].Value = MemberEmail;


				return BaseDataAccessor.ExecuteWithResult("spPostAd",parameters);
			}
			#endregion

			#region SendFeedBack
			public static String SendFeedBack(String FeedBackType,String UserName,String EmailAddress,String ContactPhone, String Message)
			{
			
				SqlParameter[] parameters = new SqlParameter[5];

				parameters[0] = new SqlParameter("@FeedBackType", SqlDbType.VarChar,50);
				parameters[0].Value = FeedBackType;

				parameters[1] = new SqlParameter("@UserName", SqlDbType.VarChar,30);
				parameters[1].Value = UserName;

				parameters[2] = new SqlParameter("@EmailAddress", SqlDbType.VarChar,50);
				parameters[2].Value = EmailAddress;

				parameters[3] = new SqlParameter("@ContactPhone", SqlDbType.VarChar,30);
				parameters[3].Value = ContactPhone;

				parameters[4] = new SqlParameter("@Message", SqlDbType.VarChar,500);
				parameters[4].Value = Message;


				return BaseDataAccessor.ExecuteWithResult("spSaveFeedBack",parameters);
			}
			#endregion

            #region AccountSignUp
            public static String AccountSignUp(String EmployeeID, String EmailAddress, String Password, Int32 RoleTypeID, Int32 DivisionID, Int32 LocationID,Int32 AccountStatus,String AddedBy)
			{
			
				SqlParameter[] parameters = new SqlParameter[8];

                parameters[0] = new SqlParameter("@EmployeeID", SqlDbType.VarChar, 20);
                parameters[0].Value = EmployeeID;
				parameters[1] = new SqlParameter("@EmailAddress", SqlDbType.VarChar,50);
				parameters[1].Value = EmailAddress;
				parameters[2] = new SqlParameter("@Password", SqlDbType.VarChar,50);
				parameters[2].Value = Password;
                parameters[3] = new SqlParameter("@RoleTypeID", SqlDbType.Int);
                parameters[3].Value = RoleTypeID;
                parameters[4] = new SqlParameter("@DivisionID", SqlDbType.Int);
                parameters[4].Value = DivisionID;
                parameters[5] = new SqlParameter("@LocationID", SqlDbType.Int);
                parameters[5].Value = LocationID;
                parameters[6] = new SqlParameter("@AccountStatus", SqlDbType.Int);
                parameters[6].Value = AccountStatus;
                parameters[7] = new SqlParameter("@AddedBy", SqlDbType.VarChar, 20);
                parameters[7].Value = AddedBy;

                return BaseDataAccessor.ExecuteWithResult("spAddMember", parameters);
			}
			#endregion

            #region ValidateLogin
            public static DataSet ValidateLogin(String EmailAddress, String Password)
            {

                SqlParameter[] parameters = new SqlParameter[3];

                parameters[0] = new SqlParameter("@EmailAddress", SqlDbType.VarChar, 50);
                parameters[0].Value = EmailAddress;

                parameters[1] = new SqlParameter("@Password", SqlDbType.VarChar, 50);
                parameters[1].Value = Password;

                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spLoginMember", parameters);
                return dataSet;
            }
            #endregion
            #region GetSessionInfo
            public static DataSet GetSessionInfo(Int32 EmpId)                
            {

                SqlParameter[] parameters = new SqlParameter[1];

                parameters[0] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[0].Value = EmpId;

                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetSessionInfo", parameters);
                return dataSet;
            }
           #endregion


            #region RetrieveMyOrgRootMember
            public static DataSet RetrieveMyOrgRootMember(Int32 EmpId)                
            {

                SqlParameter[] parameters = new SqlParameter[1];

                parameters[0] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[0].Value = EmpId;                
                
                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spGetMyOrgRootMember", parameters);
                return dataSet;
            }
           #endregion
    

            #region RetrievePassword
            public static DataSet RetrievePassword(String EmailAddress)
            {

                SqlParameter[] parameters = new SqlParameter[1];

                parameters[0] = new SqlParameter("@EmailAddress", SqlDbType.VarChar, 50);
                parameters[0].Value = EmailAddress;

                DataSet dataSet = BaseDataAccessor.ExecuteDataSet("spRetrievePassword", parameters);

                return dataSet; 

            }
            #endregion
            #region ChangePassword
            public static String ChangePassword(Int32 EmpId,String OldPassword, String NewPassword)
            {

                SqlParameter[] parameters = new SqlParameter[3];

                parameters[0] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[0].Value = EmpId;

                parameters[1] = new SqlParameter("@OldPassword", SqlDbType.VarChar,50);
                parameters[1].Value = OldPassword;

                parameters[2] = new SqlParameter("@NewPassword", SqlDbType.VarChar, 50);
                parameters[2].Value = NewPassword;

                return BaseDataAccessor.ExecuteWithResult("spChangePassword", parameters);

            }
           #endregion

            #region UserChangePassword
            public static String UserChangePassword(String UserName,String OldPassword, String NewPassword)
            {

                SqlParameter[] parameters = new SqlParameter[3];

                parameters[0] = new SqlParameter("@UserName", SqlDbType.VarChar,50);
                parameters[0].Value = UserName;

                parameters[1] = new SqlParameter("@OldPassword", SqlDbType.VarChar,50);
                parameters[1].Value = OldPassword;

                parameters[2] = new SqlParameter("@NewPassword", SqlDbType.VarChar, 50);
                parameters[2].Value = NewPassword;

                return BaseDataAccessor.ExecuteWithResult("spUserChangePassword", parameters);

            }
           #endregion

            #region SavePreferences
            public static String SavePreferences(Int32 EmpId, Int32 Alerting, String Email_Addr, String Emergency_Phone, Int32 PersistDays)
            {

                SqlParameter[] parameters = new SqlParameter[5];

                parameters[0] = new SqlParameter("@EmpId", SqlDbType.Int);
                parameters[0].Value = EmpId;

                parameters[1] = new SqlParameter("@Alerting", SqlDbType.Int);
                parameters[1].Value = Alerting;

                parameters[2] = new SqlParameter("@Email_Addr", SqlDbType.VarChar, 50);
                parameters[2].Value = Email_Addr;

                parameters[3] = new SqlParameter("@Emergency_Phone", SqlDbType.VarChar, 20);
                parameters[3].Value = Emergency_Phone;

                parameters[4] = new SqlParameter("@PersistDays", SqlDbType.Int);
                parameters[4].Value = PersistDays;

                return BaseDataAccessor.ExecuteWithResult("spSavePreferences", parameters);

            }
          #endregion
		


			#region RetrieveServiceProviderList
			public static DataSet RetrieveServiceProviderList(String CityName, int CategoryID)
			{
			
				SqlParameter[] parameters = new SqlParameter[2];

				parameters[0] = new SqlParameter("@CategoryID", SqlDbType.Int);
				parameters[0].Value = CategoryID;

				parameters[1] = new SqlParameter("@CityName", SqlDbType.VarChar,50);
				parameters[1].Value = CityName;

				DataSet		dataSet = BaseDataAccessor.ExecuteDataSet("spGetServiceProviders", parameters);

				DataSet	result = null;

				if(dataSet.Tables.Count > 0)
				{
					if (dataSet.Tables.Count > 0)
					{
						result =  dataSet ;//dataSet.Tables[0];
					}
				}

				return result;

			}
			#endregion
			// End of Sample.

			#region RetrieveAllServiceProviderList for a selected Event
            public static DataSet RetrieveAllServiceProviderList_Event(int EventID)
			{
			
				SqlParameter[] parameters = new SqlParameter[1];

				parameters[0] = new SqlParameter("@EventID", SqlDbType.Int);
				parameters[0].Value = EventID;

				DataSet		dataSet = BaseDataAccessor.ExecuteDataSet("spGetAllServiceProvidersUsingEventID", parameters);

				DataSet	result = null;

				if(dataSet.Tables.Count > 0)
				{
					if (dataSet.Tables.Count > 0)
					{
						result = dataSet;// dataSet.Tables[0];
					}
				}

				return result;

			}
			#endregion

			#region RetrieveAllServiceProviderList for a selected Category
			public static DataSet RetrieveAllServiceProviderList_Category(int CategoryID)
			{
			
				SqlParameter[] parameters = new SqlParameter[1];

				parameters[0] = new SqlParameter("@CategoryID", SqlDbType.Int);
				parameters[0].Value = CategoryID;

				DataSet		dataSet = BaseDataAccessor.ExecuteDataSet("spGetServiceProvidersUsingCatgeoryID", parameters);

				DataSet	result = null;

				if(dataSet.Tables.Count > 0)
				{
					if (dataSet.Tables.Count > 0)
					{
						result = dataSet; //dataSet.Tables[0];
					}
				}

				return result;

			}
			#endregion

			#region RetrieveCollection
			public static NamedCollection[] RetrieveCollection(String sproc, SqlParameter[] parameters)
			{
				NamedCollection[] result = null;
				DataSet		dataSet = BaseDataAccessor.ExecuteDataSet(sproc, parameters);
				DataTable	table = null;
				DataRow		row = null;

				if(dataSet.Tables.Count > 0)
				{
					table = dataSet.Tables[0];
					result = new NamedCollection[table.Rows.Count];
				
					for(Int32 i = 0; i < table.Rows.Count; i++)
					{
						row = table.Rows[i];
						result[i] = new NamedCollection((String)row["TypeID"], (String)row["TypeName"]);
					}
				}

				return result;
			}
			#endregion


		}
	}








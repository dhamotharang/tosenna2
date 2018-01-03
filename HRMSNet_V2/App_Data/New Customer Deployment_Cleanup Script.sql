
--1. Step 1: Clean up if any existing data from main employee transaction tables
Delete from Employee_Benefit
Delete from dbo.Employee_AdhocMonthlyPayComponents;
Delete from dbo.Employee_BenefitHistory
Delete from dbo.Employee_Certifications
Delete from dbo.Employee_Contact
Delete from dbo.Employee_Deductions;
Delete from dbo.Employee_dependent
Delete from dbo.Employee_Documents
Delete from dbo.Employee_EContact
Delete from dbo.Employee_Documents
Delete from dbo.Employee_Education
Delete from dbo.Employee_EOSPayroll
Delete from dbo.Employee_Immigration
Delete from dbo.Employee_Incentives
Delete from dbo.Employee_IncentivesHistory
Delete from dbo.Employee_Languages
Delete from dbo.Employee_Leave
Delete from dbo.Employee_Membership
Delete from dbo.Employee_MonthlyPayComponents
Delete from Employee_MonthlyPayrollSummary
Delete from dbo.Employee_NonPayrollBenefits
Delete from dbo.Employee_NonPayrollBenefitsHistory
Delete from dbo.Employee_Pay
Delete from dbo.Employee_Position
Delete from dbo.Employee_Preference
DElete from dbo.Employee_Skills
Delete from dbo.Employee_Training
Delete from dbo.Employee_TransferHistory
DElete from dbo.Employee_WorkExperience
Delete from dbo.LeaveRequest
Delete from dbo.PasswordHistory
Delete from Employee

--2. Insert Key Master Data.
 
--2.1 Setup Company Name.
    Delete from dbo.CompanyRegion
    INSERT INTO dbo].[Company]
           ([CompanyID]
           ,[CompanyName]
           ,[ParentOrgID]
           ,[GLCode]
           ,[BuildingNo_Name]
           ,[StreetName]
           ,[City]
           ,[State]
           ,[CountryID]
           ,[PostalCode]
           ,[Location_PhoneNo]
           ,[Location_Fax]
           ,[Location_EmailAddr]
           ,[Location_Contact]
           ,[CompanyLogoImgName]
           ,[CompanyCaption]
           ,[Bank_RoutingCode]
           ,[Employer_UniqueID]
           ,[Employer_RefNumber])
     VALUES
           (1
           ,'New Client Company Name'
           ,Null
           ,Null,>
           ,'Build No:123'
           ,'123 Sample Street Name'
           ,'CityName'
           ,'State/TerritoryName'
           ,<CountryID, int,>
           ,<PostalCode, nvarchar(50),>
           ,<Location_PhoneNo, nvarchar(30),>
           ,<Location_Fax, nvarchar(30),>
           ,<Location_EmailAddr, nvarchar(50),>
           ,<Location_Contact, nvarchar(50),>
           ,<CompanyLogoImgName, nvarchar(50),>
           ,<CompanyCaption, nvarchar(50),>
           ,<Bank_RoutingCode, nvarchar(9),>
           ,<Employer_UniqueID, nvarchar(13),>
           ,<Employer_RefNumber, nvarchar(35),>)
       GO
       
--2.3 Add Regions for Company. You can add one or more regions for each company.     
	  Declare @CompanyID int
	  Select @CompanyID = CompanyID from Company 
	  Insert into CompanyRegion (1,'Middle East Region', @CompanyID)
	  
--2.4 Add Company Business Division. You can add one or more business divisions for a company 
	  Declare @RegionID int
	  Select @RegionID = RegionID from CompanyRegion Where CompanyID=@CompanyID  
	  
	  Insert into Division Values (1, 'Business Division Name',@RegionID,@CompanyID, NULL, NULL,1)
	  
--2.5 Add Country Master List. By default country table has all countries list. Keep the required countries at the top of the list.
      Insert into Country values (1,'United States','USA','$')
      
--2.6 Add company locations. Add one or more locations as needed.
     Insert into Location values (1,'City Name','State Name',@CountryID)
--2.7 Now Map locations to each business unit added in Step 2.4. The last column defines unique HR employee id scheme for each business unit location
      Insert into DivisionLocationMap values (DivisionID, LocationID, NULL,NULL,NULL,NULL,NULL, 'EMP-XX000-0000')
      
--2.8 Department Master. Add all departments needed in this master table.
         
      Insert INTO Department
--2.9 Designation Master. Add all required designations in this master table.      
	  Insert INTO Designation
--2.10 Fill up Education master table.
	 Insert into  dbo.Education 
	 
--3. Standard LookUp Table.This is standard across all customers. do not change /delete anything these tables
--3.1 Employee Category Table
 Insert into dbo.EmployeeCategory with the following values
	EmpCategoryID	EmpCategoryName	Status
	1				Permanent		1
	2				Temporary		1
	3				Probation		1
	4				Part Time		1
	5				Others			1
	
--3.2 Employee Status Table
 Insert into dbo.EmployeeStatus with the following values
 EmpStatusID	EmpStatusName	Status
	1			Employed		1
	2			Resigned		1
	3			Terminated		1
	4			On Leave		1
	5			Offer Sent		1
	6			Offer Accepted	1
	7			Deactivated		0
	
--3.3 GenderType Table
  Insert into dbo.GenderType with the following values
  GenderTypeID	GenderName
	1			Male
	2			Female
--3.4 Marital Status Type
  Insert into dbo.MaritalStatus with the following values
  MaritalStatusID	MaritalStatusName
	1				Married
	2				Single
	3				Others
--3.5 Visibility Type
 Insert into VisibiltyType with the following values 	
	RowId	VisibilityLevel
	1		HR Administrators
	2		Supervisor
	3		Employees	
--3.6 Access Roles Type
  Insert into UserRoles with following values
  RoleId	RoleName
	1		HR Administrator
	2		Supervisor
	3		Employee
	4		Payroll Administrator
	5		Data Entry Clerk	
	
--3.7 StatusType
Insert into StatusType with following values
StatusTypeID	StatusName
1				Entered
2				Submitted
3				Pending Approval
4				Approved
5				Rejected
6				Cancelled
7				Closed
--3.8  SalutationType
SalutationID	Salutation
1				Mr.
2				Ms.
3				Mrs.

--3.9 Master Leave Type
Insert into MasterLeaveType with the following values. Separate script available to add new type and associated changes.
LeaveTypeID	LeaveTypeName
1			Annual Leave
2			Bereavement Leave
3			Hajji Leave
4			Maternity Leave
5			Paternity Leave
6			Sick Leave
7			LOA-Unpaid Leave
8			Marriage Leave
9			Study Leave
10			On Training
--3.10 select * from dbo.GratuityType
Insert into GratuityType wih the following values
GratuityTypeId	GratuityName
1				Resignation
2				Termination
3				Visa Completion
--3.11  Pay_frequency

RowId	PayFrequency
1		Standard/Monthly
2		Non Standard/Adhoc
--3.12 PaycomponentType with customer specific account code for each component

PayComponentTypeID		PayComponentTypeName	AccountCode	AccountDescription	Active
1						Basic & Allowance		682151					NULL		1
2						Deduction				680000					NULL		1
3						Incentives				690000					NULL		1
4						Benefits				640000					NULL	NULL
5						Basic Salary			681100					NULL	NULL
6						EOS Benefit				691100					NULL	NULL
7						Advance Payment			651100					NULL	NULL
8						Allowance	661100		NULL					NULL
--3.13 PayrollstatusType

PayrollStatusID	PayrollStatusName
1				New
2				Pending
3				Processed

--4. Customer specific Master Data. Fill up the follwoing customer specific data
1. Bank
2. DocumentType
3. dbo.EOSGratuityRule
4.dbo.MissingDataType
5. PayComponent
6. RequestStatusType
7. dbo.RequestImplType
8. dbo.SkillCategory
9. dbo.SkillLevel
10.dbo.Skills
11. dbo.TrainingType

--5. Insert Superadmin accountbefore you add employees.
    
 --Create SuperAdmin Account with <Division,Location, DeptID>  values <1,1,1>/ HR administrator Privilege
 
Declare @EmpID int

Select @EmpID = MAX(EmpID) from Employee;

Insert into Employee (EmpId,F_Name,L_Name,GenderID,Employee_ID,DOB,HireDate,MaritalStatus_ID,DivisionID,DepartmentID,DivisionLocationID,DesignationID,EmployeeCategoryID,EmployeeStatusID,EducationID)
values (ISNULL(@EmpID,0)+1,'RegionalHR','Administrator',1,'AONDIFC00000','1900-01-01','1900-01-01',1,1,1,1,1,5,1,1)

-- Admin@123(Encrytpted) : YWRtaW5AMTIz
Insert into UserAccounts values (ISNULL(@EmpID,0)+1,'RegionalHR_Admin@Arkhrms.com','YWRtaW5AMTIz',1,1,GETDATE(),null,GETDATE())

-- Add Rights to  Business Units and Locations.

INSERT INTO HRAdmin_ACL VALUES (ISNULL(@EmpID,0)+1,1,1) -- AON DIFC/UAE
INSERT INTO HRAdmin_ACL VALUES (ISNULL(@EmpID,0)+1,2,1) -- AON ARS/UAE
INSERT INTO HRAdmin_ACL VALUES (ISNULL(@EmpID,0)+1,3,4) -- AON KSA/KSA
INSERT INTO HRAdmin_ACL VALUES (ISNULL(@EmpID,0)+1,4,2) -- AON ARS/BH
INSERT INTO HRAdmin_ACL VALUES (ISNULL(@EmpID,0)+1,5,5) -- AON QAT/UAE
INSERT INTO HRAdmin_ACL VALUES (ISNULL(@EmpID,0)+1,6,1) -- AON BF/UAE
INSERT INTO HRAdmin_ACL VALUES (ISNULL(@EmpID,0)+1,7,7) -- AON Corp/Other

--6. Now Login into system as superadmin created in step 5 and add all employees/define other pending things.
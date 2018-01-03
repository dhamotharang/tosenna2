Select * from Company

--Parent Organization:Company
Update Company
  set CompanyName = 'AON Corporation',
      CountryID = 1,
      BuildingNo_Name = '6th Floor, Al Reem Tower',
      StreetName = 'Al Maktoum Street',
      City = 'Dubai',
      State='Dubai',
      Location_PhoneNo ='971 4 202 6222',
      Bank_RoutingCode = '123456789',
      Employer_UniqueID='1000000000567',
      PostalCode = null
Where CompanyID = 1 

-- Sub Organizations.
-- 1. AON Middle East LLC
INSERT INTO [HRIS].[dbo].[Company]
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
           (2,'AON Middle East LLC',1,null,'6th Floor, Al Reem Tower','Al Maktoum Street','Dubai','Dubai',1,null,'971 4 202 6222','971 4 228 1325',null,null,null,null,'123456789','1000000000568',null)
GO
-- 2. AON Saudi Arabia
INSERT INTO [HRIS].[dbo].[Company]
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
           (3,'AON Saudi Arabia',1,null,'2nd Floor Al-Khereiji Bldg','605 Salah-Udeen Ayoubi St','Sulaimania,Riyadh','Riyadh Province',3,'11565','966 1 477 2317','966 1 478 4304',null,null,null,null,'123456789','1000000000569',null)
GO

--AON RE MiddleEast W.L.L
INSERT INTO [HRIS].[dbo].[Company]
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
           (4,'AON Re Middle East W.L.L',1,null,'Impact House ,Office 41, 4th Floor,Building No 662','Road 2811','Al Seef District 428','Kingdom of Bahrain',2,null,'973 1 722 6066','973 1 722 5299',null,null,null,null,'123456789','1000000000570',null)
GO

-- AON Qatar LLC

INSERT INTO [HRIS].[dbo].[Company]
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
           (5,'AON Qatar LLC',1,null,'2nd Floor, Office 1, Tatweer Tower','West Bay, PO Box 16456','Doha','Qatar',4,null,'974 4 408 3444','974 4 421 3111',null,null,null,null,'123456789','1000000000571',null)
GO

-- AON Benfield Middle East LLC
INSERT INTO [HRIS].[dbo].[Company]
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
           (6,'AON Benfield Middle East LLC',1,null,'DIFC,Currency House, Tower 2, Level 5','PO Box 506746','Dubai','UAE',1,null,'971 4 389 6300','971 4 323 0708',null,null,null,null,'123456789','1000000000572',null)
GO

-- AON DIFC
INSERT INTO [HRIS].[dbo].[Company]
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
           (7,'AON (DIFC) Gulf Limited',1,null,'DIFC,Currency House, Tower 2, Level 5','PO Box 506746','Dubai','UAE',1,null,'971 4 389 6300','971 4 389 1690',null,null,null,null,'123456789','1000000000573',null)
GO

-- Insert Countries

INSERT INTO Country VALUES (1, 'United Arab Emirates','UAE','AED')
INSERT INTO Country VALUES (2, 'Bahrain','BHR','BHD')
INSERT INTO Country VALUES (3, 'Saudi Arabia','KSA','SAR')
INSERT INTO Country VALUES (4, 'Qatar','QAT','QAR')
INSERT INTO Country VALUES (5, 'Oman','OMN','OMR')
INSERT INTO Country VALUES (6, 'Kuwait','KWT','KWD')
INSERT INTO Country VALUES (99, 'Other','','AED')


-- Insert Locations

Insert into Location values (1, 'Dubai',null,1)
Insert into Location values (2, 'Manama',null,2)
Insert into Location values (3, 'Muscat',null,5)
Insert into Location values (4, 'Riyadh',null,3)
Insert into Location values (5, 'Doha',null,4)
Insert into Location values (6, 'Kuwait City',null,6)
Insert into Location values (7, 'Other',null,7) -- Used for non-MEA supervisors

-- Insert 1 Division

INSERT INTO [HRIS].[dbo].[Division]
           ([DivisionID]
           ,[DivisionName]
           ,[RegionID]
           ,[CompanyID]
           ,[DivisionHeadID]
           ,[GLCode]
           ,[Active])
     VALUES (1, 'AON (DIFC) Gulf Limited',1,7,NULL,NULL,1)
-- Add Dummy Division to allow supervisors come from Non MEA regions.All NON MEA supervisors will be added here.
Insert into Division values (7,'AON Corporate',1,1,NULL,NULL,1) -- AON Corporate/UAE


     
-- Create Division Location Mapping
Insert into DivisionLocationMap (DivisionID,LocationID) values (1,1) -- AON DIFC/UAE
Insert into DivisionLocationMap (DivisionID,LocationID) values (2,1) -- AON ARS/UAE
Insert into DivisionLocationMap (DivisionID,LocationID) values (3,4) -- AON KSA/KSA
Insert into DivisionLocationMap (DivisionID,LocationID) values (4,2) -- AON ARS/BH
Insert into DivisionLocationMap (DivisionID,LocationID) values (5,5) -- AON QAR/QAR
Insert into DivisionLocationMap (DivisionID,LocationID) values (6,1) -- AON BF/UAE
-- Add Dummy Division to allow supervisors come from Non MEA regions.All NON MEA supervisors will be added here.
Insert into DivisionLocationMap (DivisionID,LocationID) values (7,7) -- AON Corp/Others
     
-- Insert 1 department

INSERT INTO [HRIS].[dbo].[Department]
           ([DeptID]
           ,[DeptName]
           ,[DeptPrefix]
           ,[GLCode]
           ,[DeptHead_Id]
           ,[Status])
     VALUES (1,'Human Resource','HR',null,null,1)

     
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


  
          
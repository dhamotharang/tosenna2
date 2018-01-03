using System;
using System.Reflection;
using System.ComponentModel;

namespace SchoolNet
{
    /// <summary>
    /// Summary description for Constants.
    /// </summary>
    public sealed class Constants
    {

        public Constants()
        {
        }
       

        #region Enumeration: EmpStatusType
        public enum EmpStatusType
        {
            AllEmpStatus  = 1,		// All Employment Statuses
            PreEmployment = 2, 		// Returns only offer sent(5)/offer accepted(6)
            PostEmployment = 3,		// Returns only Resigned(2)/Terminated(3)
            Benefit        = 4,     // Returns only Employed(1)/On Leave(4)/Resigned(2)/Terminated(3)
            Onboarding   = 5,        // Adding Employee <Employed, Offer Sent, Offer Accepted>
            Payroll      = 6         //Returns only Employed(1)/On leave(4)
        }
        #endregion

        #region Enumeration: PayComponentType
        public enum PayComponentType
        {
            Benefit = 1,		// Allwoance Components
            Deduction = 2, 		// Deduction Components
            Incentives=3,       // Incentives Components
            NPBenefits=4,       // Non Payroll Benefits
            All = 9             // Returns both deduction and allowances 
        }
        #endregion
        #region Enumeration: PayFrequencyType
        public enum PayFrequencyType
        {
            Standard = 1,		// Standard Components
            Adhoc = 2, 		// Adhoc Components
            All=3           // Both Standard/Adhoc Components 
        }
        #endregion
        #region Enumeration: PayrollStatusType
        public enum PayrollStatusType
        {
            New = 1,            // Payroll Status: New  
            Pending = 2, 		// Payroll Status: Pending
            Processed = 3, 		// Payroll Status: Processed
            Preview = 4,		// New and Pending Statuses
            All = 5             // new, pending and processed.
        }
        #endregion
        #region Enumeration: LeaveRequestType
        public enum LeaveRequestType
        {
            Processed = 1,        // approved, closed, cancelled,rejected requests
            Pending   = 2,		  // Submitted, Pending Approval
            All = 3               // All Statuses <approved, submitted, pending approval, rejected, closed, cancelled.
        }
        #endregion

        public enum RequestType
        {
            [DescriptionAttribute("New Hire Onboarding Request")] Onboarding = 1,
            [DescriptionAttribute("Employee Salary Certificate Request")] SalCertificate = 2,
            [DescriptionAttribute("Resignation Request")] Resignation = 3,
            [DescriptionAttribute("Personal Action Request")] Personal = 4          
        }
        public enum RequestStatusType
        {
            [DescriptionAttribute("Submitted")] Submitted = 1,
            [DescriptionAttribute("Pending Approval")] PendingApproval = 2,
            [DescriptionAttribute("Approved")] Approved = 3,
            [DescriptionAttribute("Cancelled")] Cancelled = 4,
            [DescriptionAttribute("Rejected")] Rejected = 5,
            [DescriptionAttribute("Closed")]  Closed = 6
        }
        public enum ImportType
        {
            [DescriptionAttribute("Finance_01")]
            Finance_01 = 1,
            [DescriptionAttribute("LaborVisaPP")]
            LaborVisaPP = 2,
        }
        public enum ImportTableName
        {
            [DescriptionAttribute("FinanceTrans_TmpTable")]
            FinanceTransaction = 1,
            [DescriptionAttribute("LaborVisaPP_StagingTable")]
            LaborVisaPP = 2, 
        }
        #region Enumeration: PayrollReportState
        public enum PayrollReportState
        {
            Projected = 1,        // Projected
            Processed = 2,		  // Processed

        }
        #endregion

        #region Enumeration: MissingDataType
        public enum MissingDataType
        {
            LaborCard = 1,       
            Passport = 2,
		    WorkAddress=3,
            HomeAddress=4,
            EContact=5,
            LMAssignment=6,
            ALEntitlement=7,
            ALApproval=8,
            BenefitData=9
        }
        #endregion
        #region Enumeration: ExpiryAlertDataType
        public enum ExpiryAlertDataType
        {
            LaborCard = 1,
            Passport = 2,
            Visa = 3,
            Probation = 4
        }
        #endregion
        #region Enumeration: LeaveTypeID
        public enum LeaveTypeID
        {
            AnnualLeave = 1,
            BereavementLeave=2,
            HajjiLeave=3,
            MaternityLeave=4,
            PaternityLeave=5,
            SickLeave=6,
            LOAUnpaidLeave=7
        }
       #endregion


        public static string SERVER = "relay-hosting.secureserver.net";
        
    }
}



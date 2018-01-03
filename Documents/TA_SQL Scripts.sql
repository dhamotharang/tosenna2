USE [HRIS_Prod]
GO

/****** Object:  Table [dbo].[TA_Attendance]    Script Date: 01/01/2016 20:44:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TA_Attendance](
	[ID] [int] NOT NULL,
	[EmpID] [int] NOT NULL,
	[ShiftId] [numeric](18, 0) NULL,
	[Date] [datetime] NULL,
	[InTime] [nvarchar](50) NULL,
	[OutTime] [nvarchar](50) NULL,
	[Late] [nvarchar](50) NULL,
	[Early] [nvarchar](50) NULL,
	[OT] [nvarchar](50) NULL,
	[TotalHrs] [nvarchar](50) NULL,
	[Status] [nvarchar](50) NULL,
	[Type] [nvarchar](50) NULL,
	[Day] [float] NULL,
	[OutNextDay] [varchar](50) NULL,
	[LunchMin] [varchar](50) NULL,
	[LateStatus] [varchar](10) NULL,
	[LunchIn] [nvarchar](50) NULL,
	[LunchOut] [nvarchar](50) NULL,
	[BreakIn] [nvarchar](50) NULL,
	[BreakOut] [nvarchar](50) NULL,
	[LeaveDay] [float] NULL,
	[AttendanceType] [int] NULL,
 CONSTRAINT [PK_TA_Attendance] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[EmpID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO



USE [HRIS_Prod]
GO

/****** Object:  Table [dbo].[TA_Configuration]    Script Date: 01/01/2016 20:44:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TA_Configuration](
	[TAConfig_ID] [int] NOT NULL,
	[DivisionID] [int] NOT NULL,
	[LocationID] [int] NOT NULL,
	[Emp_EditAllowed] [int] NULL,
	[Emp_DelAllowed] [int] NULL,
	[Sup_EditDelAllowed] [int] NULL,
	[DevicePunch_Frequency] [int] NULL,
	[PunchInterval_ToleranceMin] [int] NULL,
	[OT_Allowed] [int] NULL,
	[Lunch_Allowed] [int] NULL,
	[MaxOT_Allowed] [int] NULL,
	[NoPunch_Action] [int] NULL,
	[MissingPunch_Action] [int] NULL,
 CONSTRAINT [PK_TA_Configuration] PRIMARY KEY CLUSTERED 
(
	[TAConfig_ID] ASC,
	[DivisionID] ASC,
	[LocationID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


USE [HRIS_Prod]
GO

/****** Object:  Table [dbo].[TA_EmployeeShiftSchedule]    Script Date: 01/01/2016 20:44:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TA_EmployeeShiftSchedule](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EmpID] [int] NOT NULL,
	[ShiftID] [int] NOT NULL,
	[IsCurrent] [int] NOT NULL,
	[DateUpdated] [date] NOT NULL,
	[UpdatedUserID] [int] NOT NULL,
 CONSTRAINT [PK_TA_EmployeeShiftSchedule] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[EmpID] ASC,
	[ShiftID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


USE [HRIS_Prod]
GO

/****** Object:  Table [dbo].[TA_MissingActionType]    Script Date: 01/01/2016 20:45:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TA_MissingActionType](
	[MissingActionTypeID] [int] NOT NULL,
	[ActionTypeName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TA_MissingActionType] PRIMARY KEY CLUSTERED 
(
	[MissingActionTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


USE [HRIS_Prod]
GO

/****** Object:  Table [dbo].[TA_MissingAttendance]    Script Date: 01/01/2016 20:45:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TA_MissingAttendance](
	[ID] [int] NOT NULL,
	[EmpID] [int] NOT NULL,
	[WorkDate] [date] NOT NULL,
	[MissingActionTypeID] [int] NULL,
	[Ref_LeaveID] [int] NULL,
	[DateUpdated] [datetime] NOT NULL,
	[UpdatedEmpID] [int] NOT NULL,
 CONSTRAINT [PK_TA_MissingAttendance] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[EmpID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


USE [HRIS_Prod]
GO

/****** Object:  Table [dbo].[TA_Shift]    Script Date: 01/01/2016 20:45:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TA_Shift](
	[ShiftID] [int] NOT NULL,
	[DivisionID] [int] NULL,
	[LocationID] [int] NULL,
	[ShiftName] [nvarchar](50) NOT NULL,
	[ShiftShortName] [nvarchar](10) NULL,
	[InTime] [nvarchar](50) NULL,
	[OutTime] [nvarchar](50) NULL,
	[LateAllowed] [nvarchar](50) NULL,
	[EarlyAllowed] [nvarchar](50) NULL,
	[EndsNextDay] [int] NULL,
	[LunchIn] [nvarchar](50) NULL,
	[LunchOut] [nvarchar](50) NULL,
	[LunchAllowed] [int] NULL,
	[BreakAllowed] [int] NULL,
	[BreakIn] [nvarchar](50) NULL,
	[BreakOut] [nvarchar](50) NULL,
	[LunchMinsFixed] [int] NULL,
	[FullDayMinutes] [int] NULL,
	[HalfDayMinutes] [int] NULL,
	[OTAllowed] [int] NULL,
	[GracePeriod] [int] NULL,
	[MaxOTHrs] [int] NULL,
 CONSTRAINT [PK_TA_Shift] PRIMARY KEY CLUSTERED 
(
	[ShiftID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


USE [HRIS_Prod]
GO

/****** Object:  Table [dbo].[TA_UploadedAttendanceControl]    Script Date: 01/01/2016 20:46:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TA_UploadedAttendanceControl](
	[ID] [int] NOT NULL,
	[DateUploaded] [datetime] NOT NULL,
	[UploadedEmpID] [int] NOT NULL,
	[TotalRecords] [int] NOT NULL,
	[File_Path] [nvarchar](250) NULL,
 CONSTRAINT [PK_TA_UploadedAttendanceControl] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO




Insert into ta_missingactionType values (1, 'Leave/LOA/Sick')
Insert into ta_missingactionType values (2, 'Work Remotely')
Insert into ta_missingactionType values (3, 'Vacation')
Insert into ta_missingactionType values (4, 'Travel')
Insert into ta_missingactionType values (5, 'Other')
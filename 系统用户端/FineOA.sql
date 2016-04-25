USE [master]
GO
/****** Object:  Database [FineOA]    Script Date: 2014/1/16 10:44:50 ******/
CREATE DATABASE [FineOA]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FineOA', FILENAME = N'D:\FineOA.mdf' , SIZE = 4160KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'FineOA_log', FILENAME = N'D:\FineOA_log.ldf' , SIZE = 1040KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [FineOA] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FineOA].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FineOA] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FineOA] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FineOA] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FineOA] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FineOA] SET ARITHABORT OFF 
GO
ALTER DATABASE [FineOA] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FineOA] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [FineOA] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FineOA] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FineOA] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FineOA] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FineOA] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FineOA] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FineOA] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FineOA] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FineOA] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FineOA] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FineOA] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FineOA] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FineOA] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FineOA] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FineOA] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [FineOA] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FineOA] SET RECOVERY FULL 
GO
ALTER DATABASE [FineOA] SET  MULTI_USER 
GO
ALTER DATABASE [FineOA] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FineOA] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FineOA] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FineOA] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'FineOA', N'ON'
GO
USE [FineOA]
GO
/****** Object:  StoredProcedure [dbo].[GetBillId]    Script Date: 2014/1/16 10:44:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetBillId] (@BillName varchar(50),@ItemId int output) as
	select @ItemId=FMaxId from t_BillId
		where FBillName= @BillName
	if @ItemId >0
	  begin
		begin transaction
		Update t_BillId set FMaxId=FMaxId+1 where FBillName= @BillName
		if @@error=0
		  begin
			commit
			select @ItemId=@ItemId + 1
			end
		else
			begin
			rollback
			select @ItemId=-1
			end
	  end
	else
	   begin
		begin transaction
	    Insert Into t_BillId(FBillName,FMaxId)
		values(@BillName,1000)
		if @@error=0
		   begin
		      commit
		      select @ItemId=1000
		   end
		else
		  begin
			rollback
			select @ItemId=-1
		  end	
	   end
	return @ItemId

GO
/****** Object:  StoredProcedure [dbo].[GetBillNo]    Script Date: 2014/1/16 10:44:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROC [dbo].[GetBillNo]
@BillType int,
@IsSave int,
@BillNo varchar(50) output
AS /*author:YELIANG date:2012-11-27 description:自动编号*/
declare @Format varchar(255),@CC varchar(255),@Date datetime,@Len int,@CurId int
set @Date=GETDATE()
select @Format=fformat,@CurId=isnull(FCurId+1,1),@Len=FLen from t_BillNo where FItemId= @BillType
if(@Format='yyyy-mm+流水') set @CC=SUBSTRING(CONVERT(varchar(12),@Date,23),1,7)
else if(@Format='yyyy-mm-dd+流水') set @CC=CONVERT(varchar(12),@Date,112)
else if(@Format='yyyymm+流水') set @CC=SUBSTRING(CONVERT(varchar(12),@Date,112),1,6)
else if(@Format='yyyymmdd+流水') set @CC=CONVERT(varchar(12),@Date,112 )
else if(@Format='流水') set @CC=''
while(len(@CC)+len(@CurId)<@Len)
begin
   set @CC=@CC+'0'
end
select @BillNo = isnull(FPreLetter,'')+@CC+convert(varchar(20),isnull(FCurId+1,1)) + isnull(FSufLetter,'') from t_BillNo where FItemId= @BillType
begin tran
  if @IsSave=1 update t_BillNo set FCurId=FCurId+1 where FItemId=@BillType
  if @@error=0 commit
  else
  begin
    rollback
    select @BillNo=''
end
select @BillNo
return

GO
/****** Object:  Table [dbo].[t_BillId]    Script Date: 2014/1/16 10:44:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_BillId](
	[FBillName] [nvarchar](128) NOT NULL,
	[FMaxId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.t_BillId] PRIMARY KEY CLUSTERED 
(
	[FBillName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[t_BillNo]    Script Date: 2014/1/16 10:44:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_BillNo](
	[FItemId] [int] NOT NULL,
	[FBillName] [nvarchar](max) NULL,
	[FTableName] [nvarchar](max) NULL,
	[FPreLetter] [nvarchar](max) NULL,
	[FCurId] [int] NOT NULL,
	[FSufLetter] [nvarchar](max) NULL,
	[FFormat] [nvarchar](max) NULL,
	[FLen] [int] NOT NULL,
	[FTranType] [int] NOT NULL,
 CONSTRAINT [PK_dbo.t_BillNo] PRIMARY KEY CLUSTERED 
(
	[FItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[t_Config]    Script Date: 2014/1/16 10:44:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Config](
	[FItemId] [int] IDENTITY(1,1) NOT NULL,
	[FConfigKey] [nvarchar](50) NOT NULL,
	[FConfigValue] [nvarchar](4000) NOT NULL,
	[FDescription] [nvarchar](500) NULL,
 CONSTRAINT [PK_dbo.t_Config] PRIMARY KEY CLUSTERED 
(
	[FItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[t_Department]    Script Date: 2014/1/16 10:44:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Department](
	[FItemId] [int] IDENTITY(1,1) NOT NULL,
	[FParentId] [int] NULL,
	[FNumber] [nvarchar](50) NULL,
	[FName] [nvarchar](50) NOT NULL,
	[FDescription] [nvarchar](500) NULL,
 CONSTRAINT [PK_dbo.t_Department] PRIMARY KEY CLUSTERED 
(
	[FItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[t_Log]    Script Date: 2014/1/16 10:44:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Log](
	[FItemId] [int] IDENTITY(1,1) NOT NULL,
	[FLevel] [nvarchar](20) NULL,
	[FLogger] [nvarchar](200) NULL,
	[FMessage] [nvarchar](4000) NULL,
	[FException] [nvarchar](4000) NULL,
	[FLogTime] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.t_Log] PRIMARY KEY CLUSTERED 
(
	[FItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[t_Menu]    Script Date: 2014/1/16 10:44:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Menu](
	[FItemId] [int] IDENTITY(1,1) NOT NULL,
	[FName] [nvarchar](50) NOT NULL,
	[FImageUrl] [nvarchar](200) NULL,
	[FNavigateUrl] [nvarchar](200) NULL,
	[FDescription] [nvarchar](500) NULL,
	[FSortIndex] [int] NOT NULL,
	[FParentId] [int] NULL,
	[FViewPowerId] [int] NULL,
 CONSTRAINT [PK_dbo.t_Menu] PRIMARY KEY CLUSTERED 
(
	[FItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[t_Online]    Script Date: 2014/1/16 10:44:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Online](
	[FItemId] [int] IDENTITY(1,1) NOT NULL,
	[FIPAdddress] [nvarchar](50) NULL,
	[FLoginTime] [datetime] NOT NULL,
	[FUpdateTime] [datetime] NULL,
	[FUserId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.t_Online] PRIMARY KEY CLUSTERED 
(
	[FItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[t_Power]    Script Date: 2014/1/16 10:44:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Power](
	[FPowerId] [int] IDENTITY(1,1) NOT NULL,
	[FName] [nvarchar](50) NOT NULL,
	[FGroupName] [nvarchar](50) NULL,
	[FTitle] [nvarchar](200) NULL,
	[FDescription] [nvarchar](500) NULL,
 CONSTRAINT [PK_dbo.t_Power] PRIMARY KEY CLUSTERED 
(
	[FPowerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[t_Role]    Script Date: 2014/1/16 10:44:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Role](
	[FRoleId] [int] IDENTITY(1,1) NOT NULL,
	[FRoleName] [nvarchar](50) NOT NULL,
	[FDescription] [nvarchar](500) NULL,
 CONSTRAINT [PK_dbo.t_Role] PRIMARY KEY CLUSTERED 
(
	[FRoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[t_RolePower]    Script Date: 2014/1/16 10:44:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_RolePower](
	[FRoleId] [int] NOT NULL,
	[FPowerId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.t_RolePower] PRIMARY KEY CLUSTERED 
(
	[FRoleId] ASC,
	[FPowerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[t_RoleUser]    Script Date: 2014/1/16 10:44:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_RoleUser](
	[FRoleId] [int] NOT NULL,
	[FUserId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.t_RoleUser] PRIMARY KEY CLUSTERED 
(
	[FRoleId] ASC,
	[FUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[t_SubMessage]    Script Date: 2014/1/16 10:44:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_SubMessage](
	[FItemId] [int] NOT NULL,
	[FParentId] [int] NOT NULL,
	[FName] [nvarchar](50) NOT NULL,
	[FType] [int] NOT NULL,
	[FDetail] [bit] NOT NULL,
	[FDescription] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.t_SubMessage] PRIMARY KEY CLUSTERED 
(
	[FItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[t_User]    Script Date: 2014/1/16 10:44:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_User](
	[FUserId] [int] IDENTITY(1,1) NOT NULL,
	[FUserName] [nvarchar](50) NOT NULL,
	[FEmail] [nvarchar](100) NOT NULL,
	[FPassword] [nvarchar](50) NOT NULL,
	[FEnabled] [bit] NOT NULL,
	[FGender] [nvarchar](10) NULL,
	[FChineseName] [nvarchar](100) NULL,
	[FEnglishName] [nvarchar](100) NULL,
	[FPhoto] [nvarchar](200) NULL,
	[FQQ] [nvarchar](50) NULL,
	[FCompanyEmail] [nvarchar](100) NULL,
	[FOfficePhone] [nvarchar](50) NULL,
	[FOfficePhoneExt] [nvarchar](50) NULL,
	[FHomePhone] [nvarchar](50) NULL,
	[FCellPhone] [nvarchar](50) NULL,
	[FAddress] [nvarchar](500) NULL,
	[FDescription] [nvarchar](500) NULL,
	[FIdentityCard] [nvarchar](50) NULL,
	[FBirthday] [datetime] NULL,
	[FTakeOfficeTime] [datetime] NULL,
	[FLastLoginTime] [datetime] NULL,
	[FBuildDate] [datetime] NULL,
	[FDepartmentId] [int] NULL,
 CONSTRAINT [PK_dbo.t_User] PRIMARY KEY CLUSTERED 
(
	[FUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[t_Config] ON 

GO
INSERT [dbo].[t_Config] ([FItemId], [FConfigKey], [FConfigValue], [FDescription]) VALUES (1, N'Title', N'FineOA协同工作管理平台', N'网站的标题')
GO
INSERT [dbo].[t_Config] ([FItemId], [FConfigKey], [FConfigValue], [FDescription]) VALUES (2, N'PageSize', N'20', N'表格每页显示的个数')
GO
INSERT [dbo].[t_Config] ([FItemId], [FConfigKey], [FConfigValue], [FDescription]) VALUES (3, N'MenuType', N'tree', N'左侧菜单样式')
GO
INSERT [dbo].[t_Config] ([FItemId], [FConfigKey], [FConfigValue], [FDescription]) VALUES (4, N'Theme', N'blue', N'网站主题')
GO
INSERT [dbo].[t_Config] ([FItemId], [FConfigKey], [FConfigValue], [FDescription]) VALUES (5, N'HelpList', N'[{"Text":"万年历","Icon":"Calendar","ID":"wannianli","URL":"~/admin/help/wannianli.htm"},{"Text":"科学计算器","Icon":"Calculator","ID":"jisuanqi","URL":"~/admin/help/jisuanqi.htm"},{"Text":"系统帮助","Icon":"Help","ID":"help","URL":"~/admin/help/help.htm"}]', N'帮助下拉列表的JSON字符串')
GO
SET IDENTITY_INSERT [dbo].[t_Config] OFF
GO
SET IDENTITY_INSERT [dbo].[t_Department] ON 

GO
INSERT [dbo].[t_Department] ([FItemId], [FParentId], [FNumber], [FName], [FDescription]) VALUES (1, NULL, NULL, N'研发部', N'顶级部门')
GO
INSERT [dbo].[t_Department] ([FItemId], [FParentId], [FNumber], [FName], [FDescription]) VALUES (2, 1, NULL, N'开发部', N'二级部门')
GO
INSERT [dbo].[t_Department] ([FItemId], [FParentId], [FNumber], [FName], [FDescription]) VALUES (3, 1, NULL, N'测试部', N'二级部门')
GO
INSERT [dbo].[t_Department] ([FItemId], [FParentId], [FNumber], [FName], [FDescription]) VALUES (4, NULL, NULL, N'销售部', N'顶级部门')
GO
INSERT [dbo].[t_Department] ([FItemId], [FParentId], [FNumber], [FName], [FDescription]) VALUES (5, 4, NULL, N'直销部', N'二级部门')
GO
INSERT [dbo].[t_Department] ([FItemId], [FParentId], [FNumber], [FName], [FDescription]) VALUES (6, 4, NULL, N'渠道部', N'二级部门')
GO
INSERT [dbo].[t_Department] ([FItemId], [FParentId], [FNumber], [FName], [FDescription]) VALUES (7, NULL, NULL, N'客服部', N'顶级部门')
GO
INSERT [dbo].[t_Department] ([FItemId], [FParentId], [FNumber], [FName], [FDescription]) VALUES (8, 7, NULL, N'实施部', N'二级部门')
GO
INSERT [dbo].[t_Department] ([FItemId], [FParentId], [FNumber], [FName], [FDescription]) VALUES (9, 7, NULL, N'售后服务部', N'二级部门')
GO
INSERT [dbo].[t_Department] ([FItemId], [FParentId], [FNumber], [FName], [FDescription]) VALUES (10, 7, NULL, N'大客户服务部', N'二级部门')
GO
INSERT [dbo].[t_Department] ([FItemId], [FParentId], [FNumber], [FName], [FDescription]) VALUES (11, NULL, NULL, N'行政部', N'顶级部门')
GO
INSERT [dbo].[t_Department] ([FItemId], [FParentId], [FNumber], [FName], [FDescription]) VALUES (12, 11, NULL, N'人事部', N'二级部门')
GO
INSERT [dbo].[t_Department] ([FItemId], [FParentId], [FNumber], [FName], [FDescription]) VALUES (13, 11, NULL, N'后勤部', N'二级部门')
GO
INSERT [dbo].[t_Department] ([FItemId], [FParentId], [FNumber], [FName], [FDescription]) VALUES (14, 11, NULL, N'运输部', N'二级部门')
GO
INSERT [dbo].[t_Department] ([FItemId], [FParentId], [FNumber], [FName], [FDescription]) VALUES (15, 14, NULL, N'省内运输部', N'三级部门')
GO
INSERT [dbo].[t_Department] ([FItemId], [FParentId], [FNumber], [FName], [FDescription]) VALUES (16, 14, NULL, N'国内运输部', N'三级部门')
GO
INSERT [dbo].[t_Department] ([FItemId], [FParentId], [FNumber], [FName], [FDescription]) VALUES (17, 14, NULL, N'国际运输部', N'三级部门')
GO
INSERT [dbo].[t_Department] ([FItemId], [FParentId], [FNumber], [FName], [FDescription]) VALUES (18, NULL, NULL, N'财务部', N'顶级部门')
GO
SET IDENTITY_INSERT [dbo].[t_Department] OFF
GO
SET IDENTITY_INSERT [dbo].[t_Log] ON 

GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1, N'Info', NULL, N'登录失败：用户“admin”密码错误', NULL, CAST(0x0000A2AF015C5D18 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (2, N'Info', NULL, N'登录失败：用户“admin”密码错误', NULL, CAST(0x0000A2AF015CA5B2 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (3, N'Info', NULL, N'登录失败：用户“admin”密码错误', NULL, CAST(0x0000A2AF015CE22C AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (4, N'Info', NULL, N'登录失败：用户“admin”密码错误', NULL, CAST(0x0000A2AF015D1F2A AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (5, N'Info', NULL, N'登录失败：用户“admin”密码错误', NULL, CAST(0x0000A2AF015D3355 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (6, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2AF015D81C1 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (7, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2AF015FD9FE AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (8, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2AF016032A0 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (9, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2AF01606D5B AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (10, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2AF0164F81B AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (11, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2AF01651DD9 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (12, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2AF01657781 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (13, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2AF0165C003 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (14, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2AF0165D9B8 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (15, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2AF016627DF AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (16, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2AF01667894 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (17, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2AF0166EAB7 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (18, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2AF0167111B AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (19, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2AF016870CD AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (20, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2AF0168AD54 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (21, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2AF016990E3 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (22, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2AF016A037C AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (23, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2AF016AAC19 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (24, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2AF016ACA0C AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (25, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2AF016AFE73 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (26, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2AF016C1322 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (27, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2AF01728DA7 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (28, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2AF0172E644 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (29, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2AF017377F0 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (30, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2AF0173F065 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (31, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2AF01741185 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (32, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2AF01743392 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (33, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2AF0174D50F AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (34, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2AF01751E14 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (35, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000C23E1B AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (36, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000C29E36 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (37, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000C2AEB3 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (38, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000C32051 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (39, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000C336F0 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (40, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000C37C8F AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (41, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000C3A554 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (42, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000C3C4D3 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (43, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000C4131A AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (44, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000C44E3B AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (45, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000C4D3CB AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (46, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000C578E9 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (47, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000C5D100 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (48, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000C6DC1E AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (49, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000C7C210 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (50, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000C80BFC AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (51, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000C82F59 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (52, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000C8D4BD AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (53, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000C93DE0 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (54, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000C94E90 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (55, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000C96DCC AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (56, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000CDA7C9 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (57, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000CDD91C AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (58, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000CDFB95 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (59, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000CF0545 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (60, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000D6ABBB AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (61, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000D76F43 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (62, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000D7CF9F AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (63, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000D7D2F4 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (64, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000D7D992 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (65, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000D8195C AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (66, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000D82CB9 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (67, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000D83EE4 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (68, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000D887F8 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1035, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000DCD052 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1036, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000DCDF54 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1037, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000DD1C92 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1038, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000DD4D34 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1039, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000DD5F7B AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1040, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000DD71A3 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1041, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000DD84C4 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1042, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000DDA08E AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1043, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000DDAFE6 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1044, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000DDBBF6 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1045, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000DDC77C AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1046, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000DE2560 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1047, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000DE5223 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1048, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000DE8D52 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1049, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000DEFE15 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1050, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000DF3027 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1051, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000DF838B AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1052, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000DFB46D AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1053, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000E04DCA AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1054, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000E0DECC AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1055, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000E0F981 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1056, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000E1A591 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1057, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000E22D13 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1058, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000E24210 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1059, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000E2A2DC AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1060, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000E2BF6D AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1061, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000E30B1B AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1062, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000E32EC4 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1063, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000E3542C AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1064, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000E3C407 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1065, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000E3F222 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1066, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000E40AAF AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1067, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000E48EFA AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1068, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000E4BB58 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1069, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000E57C1B AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1070, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000E5A5C4 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1071, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000E66AD8 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1072, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000E697AD AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1073, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000E6C0EC AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1074, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000E6DF2A AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1075, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000E707F4 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1076, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000E71D23 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1077, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000E8CA4E AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1078, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000E8F1B0 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1079, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000EB4EB1 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1080, N'Info', NULL, N'登录成功：用户“user0”', NULL, CAST(0x0000A2B000EB8A23 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1081, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000ECCC8D AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1082, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000ECFF68 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1083, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000ED9A42 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1084, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000EE0B77 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1085, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000EE3B64 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1086, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000EEA544 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1087, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000EED27D AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1088, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000EF0B41 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1089, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000F08703 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1090, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000F0B9E9 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1091, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000F13C77 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1092, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000F1D4DA AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1093, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000F33E7F AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1094, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000F38850 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1095, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000F3DE15 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1096, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000F46295 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1097, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000F4A8E6 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1098, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000F549E4 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1099, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000FB27DB AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1100, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000FB900D AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1101, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000FBB45C AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1102, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000FBFCAA AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1103, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B000FC991F AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1104, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B0013D5F7F AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1105, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B0013DDE66 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1106, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B0013FD08B AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1107, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B00140A23D AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1108, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B00140CFFF AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1109, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B00140F2C0 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1110, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B00144A7A8 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1111, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B001454C0B AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1112, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B00145928B AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1113, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B0014674DF AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1114, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B00146F090 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1115, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B00147DFF5 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1116, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B001480E3C AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1117, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B101483B2F AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1118, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B1014C6D8C AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1119, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B1014CC47C AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1120, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B1014CDAEC AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1121, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B1014CF656 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1122, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B10154DEA9 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1123, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B1015681B9 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1124, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B10157C666 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1125, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B10158C57F AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1126, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B10158F0C2 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1127, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B1015A5772 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1128, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B1015B0D33 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1129, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B1015B802B AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1130, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B1015BA752 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1131, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B1015BE9B5 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1132, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B1015C4CDB AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1133, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B1015CA54C AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1134, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B1015CF114 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1135, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B1015D7611 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1136, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B1015DD20D AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1137, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B1015E2983 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1138, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B101620018 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1139, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B101622847 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1140, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B10163245F AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1141, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B101634170 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1142, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B1016366CD AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1143, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B101645FBB AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1144, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B10164CA8B AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1145, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B1016685B8 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1146, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B10166E52D AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1147, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B10166FE38 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1148, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B1016721F0 AS DateTime))
GO
INSERT [dbo].[t_Log] ([FItemId], [FLevel], [FLogger], [FMessage], [FException], [FLogTime]) VALUES (1149, N'Info', NULL, N'登录成功：用户“admin”', NULL, CAST(0x0000A2B101679C77 AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[t_Log] OFF
GO
SET IDENTITY_INSERT [dbo].[t_Menu] ON 

GO
INSERT [dbo].[t_Menu] ([FItemId], [FName], [FImageUrl], [FNavigateUrl], [FDescription], [FSortIndex], [FParentId], [FViewPowerId]) VALUES (1, N'系统管理', NULL, NULL, N'顶级菜单', 1, NULL, NULL)
GO
INSERT [dbo].[t_Menu] ([FItemId], [FName], [FImageUrl], [FNavigateUrl], [FDescription], [FSortIndex], [FParentId], [FViewPowerId]) VALUES (2, N'用户管理', N'~/icon/tag_blue.png', N'~/admin/TUser.aspx', N'二级菜单', 10, 1, 1)
GO
INSERT [dbo].[t_Menu] ([FItemId], [FName], [FImageUrl], [FNavigateUrl], [FDescription], [FSortIndex], [FParentId], [FViewPowerId]) VALUES (3, N'职称管理', N'~/icon/tag_blue.png', N'~/admin/title.aspx', N'二级菜单', 20, 1, 22)
GO
INSERT [dbo].[t_Menu] ([FItemId], [FName], [FImageUrl], [FNavigateUrl], [FDescription], [FSortIndex], [FParentId], [FViewPowerId]) VALUES (4, N'职称用户管理', N'~/icon/tag_blue.png', N'~/admin/title_user.aspx', N'二级菜单', 30, 1, 26)
GO
INSERT [dbo].[t_Menu] ([FItemId], [FName], [FImageUrl], [FNavigateUrl], [FDescription], [FSortIndex], [FParentId], [FViewPowerId]) VALUES (5, N'部门管理', N'~/icon/tag_blue.png', N'~/admin/dept.aspx', N'二级菜单', 40, 1, 29)
GO
INSERT [dbo].[t_Menu] ([FItemId], [FName], [FImageUrl], [FNavigateUrl], [FDescription], [FSortIndex], [FParentId], [FViewPowerId]) VALUES (6, N'部门用户管理', N'~/icon/tag_blue.png', N'~/admin/dept_user.aspx', N'二级菜单', 50, 1, 33)
GO
INSERT [dbo].[t_Menu] ([FItemId], [FName], [FImageUrl], [FNavigateUrl], [FDescription], [FSortIndex], [FParentId], [FViewPowerId]) VALUES (7, N'角色管理', N'~/icon/tag_blue.png', N'~/admin/role.aspx', N'二级菜单', 60, 1, 6)
GO
INSERT [dbo].[t_Menu] ([FItemId], [FName], [FImageUrl], [FNavigateUrl], [FDescription], [FSortIndex], [FParentId], [FViewPowerId]) VALUES (8, N'角色用户管理', N'~/icon/tag_blue.png', N'~/admin/role_user.aspx', N'二级菜单', 70, 1, 10)
GO
INSERT [dbo].[t_Menu] ([FItemId], [FName], [FImageUrl], [FNavigateUrl], [FDescription], [FSortIndex], [FParentId], [FViewPowerId]) VALUES (9, N'权限管理', N'~/icon/tag_blue.png', N'~/admin/power.aspx', N'二级菜单', 80, 1, 36)
GO
INSERT [dbo].[t_Menu] ([FItemId], [FName], [FImageUrl], [FNavigateUrl], [FDescription], [FSortIndex], [FParentId], [FViewPowerId]) VALUES (10, N'角色权限管理', N'~/icon/tag_blue.png', N'~/admin/role_power.aspx', N'二级菜单', 90, 1, 40)
GO
INSERT [dbo].[t_Menu] ([FItemId], [FName], [FImageUrl], [FNavigateUrl], [FDescription], [FSortIndex], [FParentId], [FViewPowerId]) VALUES (11, N'菜单管理', N'~/icon/tag_blue.png', N'~/admin/menu.aspx', N'二级菜单', 100, 1, 16)
GO
INSERT [dbo].[t_Menu] ([FItemId], [FName], [FImageUrl], [FNavigateUrl], [FDescription], [FSortIndex], [FParentId], [FViewPowerId]) VALUES (12, N'在线统计', N'~/icon/tag_blue.png', N'~/admin/online.aspx', N'二级菜单', 110, 1, 13)
GO
INSERT [dbo].[t_Menu] ([FItemId], [FName], [FImageUrl], [FNavigateUrl], [FDescription], [FSortIndex], [FParentId], [FViewPowerId]) VALUES (13, N'系统配置', N'~/icon/tag_blue.png', N'~/admin/config.aspx', N'二级菜单', 120, 1, 14)
GO
INSERT [dbo].[t_Menu] ([FItemId], [FName], [FImageUrl], [FNavigateUrl], [FDescription], [FSortIndex], [FParentId], [FViewPowerId]) VALUES (14, N'用户设置', N'~/icon/tag_blue.png', N'~/admin/profile.aspx', N'二级菜单', 130, 1, NULL)
GO
SET IDENTITY_INSERT [dbo].[t_Menu] OFF
GO
SET IDENTITY_INSERT [dbo].[t_Online] ON 

GO
INSERT [dbo].[t_Online] ([FItemId], [FIPAdddress], [FLoginTime], [FUpdateTime], [FUserId]) VALUES (1, N'::1', CAST(0x0000A2B101634179 AS DateTime), CAST(0x0000A2B101634179 AS DateTime), 206)
GO
SET IDENTITY_INSERT [dbo].[t_Online] OFF
GO
SET IDENTITY_INSERT [dbo].[t_Power] ON 

GO
INSERT [dbo].[t_Power] ([FPowerId], [FName], [FGroupName], [FTitle], [FDescription]) VALUES (1, N'CoreUserView', N'CoreUser', N'浏览用户列表', NULL)
GO
INSERT [dbo].[t_Power] ([FPowerId], [FName], [FGroupName], [FTitle], [FDescription]) VALUES (2, N'CoreUserNew', N'CoreUser', N'新增用户', NULL)
GO
INSERT [dbo].[t_Power] ([FPowerId], [FName], [FGroupName], [FTitle], [FDescription]) VALUES (3, N'CoreUserEdit', N'CoreUser', N'编辑用户', NULL)
GO
INSERT [dbo].[t_Power] ([FPowerId], [FName], [FGroupName], [FTitle], [FDescription]) VALUES (4, N'CoreUserDelete', N'CoreUser', N'删除用户', NULL)
GO
INSERT [dbo].[t_Power] ([FPowerId], [FName], [FGroupName], [FTitle], [FDescription]) VALUES (5, N'CoreUserChangePassword', N'CoreUser', N'修改用户登陆密码', NULL)
GO
INSERT [dbo].[t_Power] ([FPowerId], [FName], [FGroupName], [FTitle], [FDescription]) VALUES (6, N'CoreRoleView', N'CoreRole', N'浏览角色列表', NULL)
GO
INSERT [dbo].[t_Power] ([FPowerId], [FName], [FGroupName], [FTitle], [FDescription]) VALUES (7, N'CoreRoleNew', N'CoreRole', N'新增角色', NULL)
GO
INSERT [dbo].[t_Power] ([FPowerId], [FName], [FGroupName], [FTitle], [FDescription]) VALUES (8, N'CoreRoleEdit', N'CoreRole', N'编辑角色', NULL)
GO
INSERT [dbo].[t_Power] ([FPowerId], [FName], [FGroupName], [FTitle], [FDescription]) VALUES (9, N'CoreRoleDelete', N'CoreRole', N'删除角色', NULL)
GO
INSERT [dbo].[t_Power] ([FPowerId], [FName], [FGroupName], [FTitle], [FDescription]) VALUES (10, N'CoreRoleUserView', N'CoreRoleUser', N'浏览角色用户列表', NULL)
GO
INSERT [dbo].[t_Power] ([FPowerId], [FName], [FGroupName], [FTitle], [FDescription]) VALUES (11, N'CoreRoleUserNew', N'CoreRoleUser', N'向角色添加用户', NULL)
GO
INSERT [dbo].[t_Power] ([FPowerId], [FName], [FGroupName], [FTitle], [FDescription]) VALUES (12, N'CoreRoleUserDelete', N'CoreRoleUser', N'从角色中删除用户', NULL)
GO
INSERT [dbo].[t_Power] ([FPowerId], [FName], [FGroupName], [FTitle], [FDescription]) VALUES (13, N'CoreOnlineView', N'CoreOnline', N'浏览在线用户列表', NULL)
GO
INSERT [dbo].[t_Power] ([FPowerId], [FName], [FGroupName], [FTitle], [FDescription]) VALUES (14, N'CoreConfigView', N'CoreConfig', N'浏览全局配置参数', NULL)
GO
INSERT [dbo].[t_Power] ([FPowerId], [FName], [FGroupName], [FTitle], [FDescription]) VALUES (15, N'CoreConfigEdit', N'CoreConfig', N'修改全局配置参数', NULL)
GO
INSERT [dbo].[t_Power] ([FPowerId], [FName], [FGroupName], [FTitle], [FDescription]) VALUES (16, N'CoreMenuView', N'CoreMenu', N'浏览菜单列表', NULL)
GO
INSERT [dbo].[t_Power] ([FPowerId], [FName], [FGroupName], [FTitle], [FDescription]) VALUES (17, N'CoreMenuNew', N'CoreMenu', N'新增菜单', NULL)
GO
INSERT [dbo].[t_Power] ([FPowerId], [FName], [FGroupName], [FTitle], [FDescription]) VALUES (18, N'CoreMenuEdit', N'CoreMenu', N'编辑菜单', NULL)
GO
INSERT [dbo].[t_Power] ([FPowerId], [FName], [FGroupName], [FTitle], [FDescription]) VALUES (19, N'CoreMenuDelete', N'CoreMenu', N'删除菜单', NULL)
GO
INSERT [dbo].[t_Power] ([FPowerId], [FName], [FGroupName], [FTitle], [FDescription]) VALUES (20, N'CoreLogView', N'CoreLog', N'浏览日志列表', NULL)
GO
INSERT [dbo].[t_Power] ([FPowerId], [FName], [FGroupName], [FTitle], [FDescription]) VALUES (21, N'CoreLogDelete', N'CoreLog', N'删除日志', NULL)
GO
INSERT [dbo].[t_Power] ([FPowerId], [FName], [FGroupName], [FTitle], [FDescription]) VALUES (22, N'CoreTitleView', N'CoreTitle', N'浏览职务列表', NULL)
GO
INSERT [dbo].[t_Power] ([FPowerId], [FName], [FGroupName], [FTitle], [FDescription]) VALUES (23, N'CoreTitleNew', N'CoreTitle', N'新增职务', NULL)
GO
INSERT [dbo].[t_Power] ([FPowerId], [FName], [FGroupName], [FTitle], [FDescription]) VALUES (24, N'CoreTitleEdit', N'CoreTitle', N'编辑职务', NULL)
GO
INSERT [dbo].[t_Power] ([FPowerId], [FName], [FGroupName], [FTitle], [FDescription]) VALUES (25, N'CoreTitleDelete', N'CoreTitle', N'删除职务', NULL)
GO
INSERT [dbo].[t_Power] ([FPowerId], [FName], [FGroupName], [FTitle], [FDescription]) VALUES (26, N'CoreTitleUserView', N'CoreTitleUser', N'浏览职务用户列表', NULL)
GO
INSERT [dbo].[t_Power] ([FPowerId], [FName], [FGroupName], [FTitle], [FDescription]) VALUES (27, N'CoreTitleUserNew', N'CoreTitleUser', N'向职务添加用户', NULL)
GO
INSERT [dbo].[t_Power] ([FPowerId], [FName], [FGroupName], [FTitle], [FDescription]) VALUES (28, N'CoreTitleUserDelete', N'CoreTitleUser', N'从职务中删除用户', NULL)
GO
INSERT [dbo].[t_Power] ([FPowerId], [FName], [FGroupName], [FTitle], [FDescription]) VALUES (29, N'CoreDeptView', N'CoreDept', N'浏览部门列表', NULL)
GO
INSERT [dbo].[t_Power] ([FPowerId], [FName], [FGroupName], [FTitle], [FDescription]) VALUES (30, N'CoreDeptNew', N'CoreDept', N'新增部门', NULL)
GO
INSERT [dbo].[t_Power] ([FPowerId], [FName], [FGroupName], [FTitle], [FDescription]) VALUES (31, N'CoreDeptEdit', N'CoreDept', N'编辑部门', NULL)
GO
INSERT [dbo].[t_Power] ([FPowerId], [FName], [FGroupName], [FTitle], [FDescription]) VALUES (32, N'CoreDeptDelete', N'CoreDept', N'删除部门', NULL)
GO
INSERT [dbo].[t_Power] ([FPowerId], [FName], [FGroupName], [FTitle], [FDescription]) VALUES (33, N'CoreDeptUserView', N'CoreDeptUser', N'浏览部门用户列表', NULL)
GO
INSERT [dbo].[t_Power] ([FPowerId], [FName], [FGroupName], [FTitle], [FDescription]) VALUES (34, N'CoreDeptUserNew', N'CoreDeptUser', N'向部门添加用户', NULL)
GO
INSERT [dbo].[t_Power] ([FPowerId], [FName], [FGroupName], [FTitle], [FDescription]) VALUES (35, N'CoreDeptUserDelete', N'CoreDeptUser', N'从部门中删除用户', NULL)
GO
INSERT [dbo].[t_Power] ([FPowerId], [FName], [FGroupName], [FTitle], [FDescription]) VALUES (36, N'CorePowerView', N'CorePower', N'浏览权限列表', NULL)
GO
INSERT [dbo].[t_Power] ([FPowerId], [FName], [FGroupName], [FTitle], [FDescription]) VALUES (37, N'CorePowerNew', N'CorePower', N'新增权限', NULL)
GO
INSERT [dbo].[t_Power] ([FPowerId], [FName], [FGroupName], [FTitle], [FDescription]) VALUES (38, N'CorePowerEdit', N'CorePower', N'编辑权限', NULL)
GO
INSERT [dbo].[t_Power] ([FPowerId], [FName], [FGroupName], [FTitle], [FDescription]) VALUES (39, N'CorePowerDelete', N'CorePower', N'删除权限', NULL)
GO
INSERT [dbo].[t_Power] ([FPowerId], [FName], [FGroupName], [FTitle], [FDescription]) VALUES (40, N'CoreRolePowerView', N'CoreRolePower', N'浏览角色权限列表', NULL)
GO
INSERT [dbo].[t_Power] ([FPowerId], [FName], [FGroupName], [FTitle], [FDescription]) VALUES (41, N'CoreRolePowerEdit', N'CoreRolePower', N'编辑角色权限', NULL)
GO
SET IDENTITY_INSERT [dbo].[t_Power] OFF
GO
SET IDENTITY_INSERT [dbo].[t_Role] ON 

GO
INSERT [dbo].[t_Role] ([FRoleId], [FRoleName], [FDescription]) VALUES (1, N'系统管理员', N'')
GO
INSERT [dbo].[t_Role] ([FRoleId], [FRoleName], [FDescription]) VALUES (2, N'部门管理员', N'')
GO
INSERT [dbo].[t_Role] ([FRoleId], [FRoleName], [FDescription]) VALUES (3, N'项目经理', N'')
GO
INSERT [dbo].[t_Role] ([FRoleId], [FRoleName], [FDescription]) VALUES (4, N'开发经理', N'')
GO
INSERT [dbo].[t_Role] ([FRoleId], [FRoleName], [FDescription]) VALUES (5, N'开发人员', N'')
GO
INSERT [dbo].[t_Role] ([FRoleId], [FRoleName], [FDescription]) VALUES (6, N'后勤人员', N'')
GO
INSERT [dbo].[t_Role] ([FRoleId], [FRoleName], [FDescription]) VALUES (7, N'外包人员', N'')
GO
SET IDENTITY_INSERT [dbo].[t_Role] OFF
GO
SET IDENTITY_INSERT [dbo].[t_User] ON 

GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (1, N'user0', N'user0@qq.com', N'yVsVXBkgdfs6RYArh/Rz3Bs8WnTjgF05', 1, N'男', N'童光喜', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB04 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (2, N'user2', N'user2@foxmail.com', N'v0FDiwziiqTR8OrVf4Rv1cl7eyUKp021', 1, N'男', N'方原柏', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB04 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (3, N'user4', N'user4@126.com', N'zUpxIqdOFxg/Cpmcp0f30xgSwgSXv6e4', 1, N'女', N'祝春亚', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB04 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (4, N'user6', N'user6@gmail.com', N'VDMJXlGmO0ABqXUU12QfEgHmp6A4u0Gx', 1, N'男', N'涂辉', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB04 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (5, N'user8', N'user8@qq.com', N'KnpyKZhwEkw+9u5SBZsX88DwizW61o70', 1, N'男', N'舒兆国', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB04 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (6, N'user10', N'user10@126.com', N'Il4iNCuPc6C8J00op/gAfFzdeFlvH918', 1, N'男', N'熊忠文', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB04 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (7, N'user12', N'user12@gmail.com', N'mNfwk0SNnxdGA/QeBwvSi6TEBkJQuWDG', 1, N'男', N'徐吉琳', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB04 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (8, N'user14', N'user14@foxmail.com', N'iIVfAhxT7yz+93iuWKqqFJD7mTCE1OWh', 1, N'男', N'方金海', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB04 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (9, N'user16', N'user16@126.com', N'lv/8sM9nufA8fxPBO26tnW4x49syAD3p', 1, N'男', N'包卫峰', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB04 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (10, N'user18', N'user18@126.com', N'O4tn8cB5b3Ot7VRXDUohoItfq1LAekNg', 1, N'女', N'靖小燕', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB04 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (11, N'user20', N'user20@163.com', N'LcK9LNCz06b7YJS5PASpFPHAGFEIW2r7', 1, N'男', N'杨习斌', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB04 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (12, N'user22', N'user22@126.com', N'unX06nCer7DOgcpyFcOEx++1PmHMPBTE', 1, N'男', N'徐长旺', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB04 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (13, N'user24', N'user24@126.com', N'p3qUKtAcN57BOEFnnBuqcTDrF/URsgQG', 1, N'男', N'聂建雄', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB04 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (14, N'user26', N'user26@outlook.com', N'2gA9Bvff7zATY0g4gdzR+fcbWji3VZ0m', 1, N'男', N'周敦友', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB04 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (15, N'user28', N'user28@163.com', N'OaJ0MQOVUYylh3ddFVKNcsiTrCTbWsIk', 1, N'男', N'陈友庭', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB04 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (16, N'user30', N'user30@126.com', N'gTTe0YytkHZy8CwHHZb1/gDmLCEdjUlS', 1, N'女', N'陆静芳', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB04 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (17, N'user32', N'user32@126.com', N'210BYcEX7xI01hGMz0VGQ75siv3js+US', 1, N'男', N'袁国柱', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB04 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (18, N'user34', N'user34@qq.com', N'AZzJGlPd/+H9QRwLcVZY8cJli9kLmCcv', 1, N'女', N'骆新桂', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB04 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (19, N'user36', N'user36@163.com', N'+w8kTbTh+MxXSllVrJb11YTUZ+OtD7+Y', 1, N'男', N'许治国', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB04 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (20, N'user38', N'user38@gmail.com', N'4l7cd0zbTISDbZyten1Wnmwfj55oJ4og', 1, N'男', N'马先加', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB04 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (21, N'user40', N'user40@qq.com', N'Acq7Dxmam9A3yJ6jBzBLBP5hG3oGpkcU', 1, N'男', N'赵恢川', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB04 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (22, N'user42', N'user42@foxmail.com', N'1p1NSkeMbcEPPw/wpBJqCBAyF9jId4DH', 1, N'男', N'柯常胜', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB04 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (23, N'user44', N'user44@qq.com', N'C40PD4vbNNi5uCZ7aXDhxzOunqECCQL4', 1, N'男', N'黄国鹏', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB04 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (24, N'user46', N'user46@gmail.com', N'i4shzgaR1/0mS7mBVTWpE+kO5q+h5odc', 1, N'男', N'柯尊北', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB04 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (25, N'user48', N'user48@163.com', N'NYK6niv4oMYHpBdFMaN6bkkIt9c0rwwh', 1, N'男', N'刘海云', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB04 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (26, N'user50', N'user50@qq.com', N'uL+wGM5AdPSYgf+UFLKPp/hX9SwLZ02Q', 1, N'男', N'罗清波', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB04 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (27, N'user52', N'user52@gmail.com', N'tYjw+Au8M8RCxeFeaQ+516FjYn1x4S4d', 1, N'男', N'张业权', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB04 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (28, N'user54', N'user54@foxmail.com', N'HCXDb+cWQfzM/jmgdcj0lW9dIJ8ENxch', 1, N'女', N'丁溯鋆', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB04 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (29, N'user56', N'user56@163.com', N'MzjucvexqRRggZX4hQ9Vc+3aWbPJsgyx', 1, N'男', N'吴俊', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB04 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (30, N'user58', N'user58@outlook.com', N'xEh7j2c8gaC2cfx2juoTx+0/yas7QuAH', 1, N'男', N'郑江', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB04 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (31, N'user60', N'user60@gmail.com', N'hr0pfti2TGoxIeONuMX6UU4msWfcU2Az', 1, N'男', N'李亚华', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB04 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (32, N'user62', N'user62@163.com', N'lz9rGHXKlaVGruAWRlZ42ZKK0T190jH5', 1, N'男', N'石光富', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB04 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (33, N'user64', N'user64@126.com', N'9oe3I8jbnj+XXoKOKa7WjI5si2GqT5Ok', 1, N'男', N'谭志洪', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB04 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (34, N'user66', N'user66@qq.com', N'51vfCIOTubNG787SHQJiSJ4T7sCrXzEk', 1, N'男', N'胡中生', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB04 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (35, N'user68', N'user68@gmail.com', N'3oIdhqF52yuD+8WLBtXO6+eX8Y4n2eGz', 1, N'男', N'董龙剑', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB04 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (36, N'user70', N'user70@outlook.com', N'ld1fmV7ShH7ZjC8riwJcRPkNoMXpGkK9', 1, N'男', N'陈红', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB04 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (37, N'user72', N'user72@outlook.com', N'dRPQgrraUfA78uVx0N8PYoDlZ/uM0p1v', 1, N'男', N'汪海平', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB04 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (38, N'user74', N'user74@outlook.com', N'JH/dFVbPsfeG+RQ+PHlz/OILxYdMLGb9', 1, N'男', N'彭道洲', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB04 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (39, N'user76', N'user76@outlook.com', N'3J91PwcW9+9+U0UoNj8buolVdEAg+pzq', 1, N'女', N'尹莉君', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB04 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (40, N'user78', N'user78@163.com', N'Ex7RPN9Ejay9OlwzCHxJaRAUUeSD4h39', 1, N'男', N'占耀玲', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB04 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (41, N'user80', N'user80@163.com', N'2NZ4AHNgFuUHu8T7KiIpY3ynfXz88hBe', 1, N'男', N'付杰', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB04 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (42, N'user82', N'user82@qq.com', N'RsikNwgyhR6brmiF+YWENseU4eGVtvxA', 1, N'男', N'王红艳', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB04 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (43, N'user84', N'user84@qq.com', N'tDorPX80PMjoESbQV8M0d4TVwHAmL4XP', 1, N'男', N'邝兴', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB04 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (44, N'user86', N'user86@gmail.com', N'EYSKp8B3613DYX1iJoB2zJFQ2atZhBGs', 1, N'男', N'饶玮', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB04 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (45, N'user88', N'user88@gmail.com', N'UAW4ZkzABT+VK7IDKkEQFin9XWS7/EuA', 1, N'男', N'王方胜', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB04 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (46, N'user90', N'user90@163.com', N'Du2zP4syM2D/TrBOQ2cv1b+icD4jr0J/', 1, N'男', N'陈劲松', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB04 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (47, N'user92', N'user92@outlook.com', N'5XL5YxSFUCoBMW0aTRYEBoSNv1VUqoOP', 1, N'男', N'邓庆华', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB04 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (48, N'user94', N'user94@foxmail.com', N'K8MnxKaVaglrvIcGA7N01KdL7Unsg/Tp', 1, N'男', N'王石林', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB04 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (49, N'user96', N'user96@163.com', N'mEDcVSJJgzMT0/E1lejNcmLnU6jTGQQz', 1, N'男', N'胡俊明', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB04 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (50, N'user98', N'user98@163.com', N'iibxUiVTreryqoDmwb5q+KHTDK3avOPN', 1, N'男', N'索相龙', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB04 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (51, N'user100', N'user100@163.com', N'SkGBKbpAvXsT5byb4w2L5xkIaCQHw7xD', 1, N'男', N'陈海军', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB04 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (52, N'user102', N'user102@foxmail.com', N'jY/h/0HPBII2HqRMpR0YNxImkxm6aZGp', 1, N'男', N'吴文涛', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB04 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (53, N'user104', N'user104@gmail.com', N'G8FqBDIgiOa5CsNVY4qjL0aZsILeBtyU', 1, N'女', N'熊望梅', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (54, N'user106', N'user106@126.com', N'TnxY8keoZqdDhvEXw92mo+Gq35Ader5J', 1, N'女', N'段丽华', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (55, N'user108', N'user108@outlook.com', N'JFUgWVCAGQotOChFlVC0FluUKObO12jr', 1, N'女', N'胡莎莎', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (56, N'user110', N'user110@qq.com', N'7o3GV5fRiZA8UG2lj8MXU1xoNyEJDDgN', 1, N'男', N'徐友安', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (57, N'user112', N'user112@outlook.com', N'+kpW6Dq7xaRpTf7o+zMFDYHKkvbZIhyG', 1, N'男', N'肖诗涛', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (58, N'user114', N'user114@163.com', N'sqEL3IlnFV+vhks3y+6heb85l1TwR8o5', 1, N'男', N'王闯', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (59, N'user116', N'user116@outlook.com', N'edrUC53Ge+mMdD6LnHDejsd4UHqPbycJ', 1, N'男', N'余兴龙', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (60, N'user118', N'user118@foxmail.com', N'GmfdT4I812MQkyeZxGEGfrL+IomOmX/y', 1, N'男', N'芦荫杰', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (61, N'user120', N'user120@gmail.com', N'duLHbOyV+7oBNatKbVtHcHzTyhpwHV1E', 1, N'男', N'丁金富', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (62, N'user122', N'user122@163.com', N'J+uOYhUU3knvUXYbV6qy+NS1b88sJ8yt', 1, N'男', N'谭军令', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (63, N'user124', N'user124@126.com', N'6P1fT1Nc+af7EaySxB40aB6clx8HppEs', 1, N'女', N'鄢旭燕', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (64, N'user126', N'user126@outlook.com', N'0DTVarxfUJ8L4WAhTSkPYYMFii2jAdtp', 1, N'男', N'田坤', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (65, N'user128', N'user128@gmail.com', N'/hDcsx40qu+PofpEyTRdu0sO6eNSWGrF', 1, N'男', N'夏德胜', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (66, N'user130', N'user130@qq.com', N'9sANQBHpvJnxmp6CPrYaiza3GhBcOAFd', 1, N'男', N'喻显发', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (67, N'user132', N'user132@qq.com', N'E3nI3SWetEdTUG/wMoKD+FPb7baRTTjF', 1, N'男', N'马兴宝', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (68, N'user134', N'user134@126.com', N'uYdOX9lmghp/TZj1GxFecnY41FWqhX8W', 1, N'男', N'孙学涛', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (69, N'user136', N'user136@163.com', N'2+DicTKJisbD1OdomfQhI1KyIiSC0jhI', 1, N'男', N'陶云成', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (70, N'user138', N'user138@outlook.com', N'cg1mYjvyJVXOEVnDkIAqmcfKGES+P95J', 1, N'男', N'马远健', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (71, N'user140', N'user140@outlook.com', N'iwI/7bbih1tm1OdRsezp9d3OhGlJddJ0', 1, N'男', N'田华', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (72, N'user142', N'user142@foxmail.com', N'y4NjuDZvmN4nCEnc5zDjKgOLZzGMfGAE', 1, N'男', N'聂子森', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (73, N'user144', N'user144@163.com', N'1+eWe49p3FtPt5boB20zmlk++aQf0uLP', 1, N'男', N'郑永军', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (74, N'user146', N'user146@qq.com', N'DYlrIsnNFhk7tglnicPBxwUUFhvwY9n3', 1, N'男', N'余昌平', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (75, N'user148', N'user148@foxmail.com', N'pHVcXwY+OR6CsM1Xwfk3x8oxO+2qDjlm', 1, N'男', N'陶俊华', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (76, N'user150', N'user150@foxmail.com', N'5BmY2/PuvldrU1APaifzhl6PePOobVHe', 1, N'男', N'李小林', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (77, N'user152', N'user152@foxmail.com', N'WSuTU3zUHn/+Xubh2yrSdnS44w5LJhQq', 1, N'男', N'李荣宝', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (78, N'user154', N'user154@foxmail.com', N'rb+omNucetpducxR349R651MsT7h/98V', 1, N'男', N'梅盈凯', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (79, N'user156', N'user156@foxmail.com', N'wgJoeLlWecDl7sxkrCy/dGWJXzkhLJZ/', 1, N'男', N'张元群', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (80, N'user158', N'user158@foxmail.com', N'FRkqNPEAhHq6EJdZcJmMuK1NKy4u6/nt', 1, N'男', N'郝新华', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (81, N'user160', N'user160@163.com', N'GEoupwcgKU8VVVQiZtLrMtD7JT2/C4e/', 1, N'男', N'刘红涛', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (82, N'user162', N'user162@163.com', N'xa9CGoaRges27hSG571kCkoD9Lpe8EhS', 1, N'男', N'向志强', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (83, N'user164', N'user164@126.com', N'v9Lwd0fxE8nCzPFnKGpXgtNTCJETxuKn', 1, N'男', N'伍小峰', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (84, N'user166', N'user166@qq.com', N'nSA6MDy29EgBmwPRHxdxVlIc8xkMi9bF', 1, N'男', N'胡勇民', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (85, N'user168', N'user168@163.com', N'I+c3YUhS5plJ3Jf5gVRNJnPbu6YiV6qf', 1, N'男', N'黄定祥', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (86, N'user170', N'user170@163.com', N'7Bfyzz8R1i1Cl6TUrNC2KuIe/WoibU+N', 1, N'女', N'高红香', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (87, N'user172', N'user172@qq.com', N'vsat80eJRgFJJ4J2Hl6kPoBP174eTSHq', 1, N'男', N'刘军', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (88, N'user174', N'user174@qq.com', N'LIZWgOg+whhA9e2akgYSqTYdRltxfdK4', 1, N'男', N'叶松', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (89, N'user176', N'user176@gmail.com', N'0x19chyEdXHxIIvk8xlK5bnj2JgeyPmb', 1, N'男', N'易俊林', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (90, N'user178', N'user178@qq.com', N'Dl+50PXaArC3vd8NsxIMy4G+IYs352ej', 1, N'男', N'张威', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (91, N'user180', N'user180@foxmail.com', N'BM5DfJ+/cfGkOzQz/R9X7tg2uQprngBd', 1, N'男', N'刘卫华', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (92, N'user182', N'user182@gmail.com', N'81hJUfTENDH5IhKUkwOVhBJdQO+VeDIi', 1, N'男', N'李浩', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (93, N'user184', N'user184@foxmail.com', N'4Zn9fNfJ8eaL9A5GXqlIa5Xjl5wuWw3f', 1, N'男', N'李寿庚', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (94, N'user186', N'user186@outlook.com', N'h21ZFuHtxq3RYZNg7opqQ2wfQeXSzTaQ', 1, N'男', N'涂洋', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (95, N'user188', N'user188@qq.com', N'pL9hnwczWddu4XO8iEvsyJQXLUBQHoyZ', 1, N'男', N'曹晶', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (96, N'user190', N'user190@foxmail.com', N'y4LO1zBGTD8QN9y/Z253XWEk25Dh3iOC', 1, N'男', N'陈辉', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (97, N'user192', N'user192@126.com', N'karhgqRY3a8DaUN6hQBU1QdzwS42GbU9', 1, N'女', N'彭博', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (98, N'user194', N'user194@gmail.com', N'q/OcHnYJnO/IIzTvx7gm+7MKG7wp3rlO', 1, N'男', N'严雪冰', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (99, N'user196', N'user196@qq.com', N'B9gapWMha3pGgF6alab04uIiGEnphOlC', 1, N'男', N'刘青', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (100, N'user198', N'user198@gmail.com', N'1hykOhTdDXo1SWkDZY2sG3QkLMEM6yiG', 1, N'女', N'印媛', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (101, N'user200', N'user200@163.com', N'rAhC0Plet1NmtC5FMGx+bIT3P8uevyu7', 1, N'男', N'吴道雄', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (102, N'user202', N'user202@qq.com', N'65zUSJesGvnbZT4igRGHRqufA8ILxTDX', 1, N'男', N'邓旻', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (103, N'user204', N'user204@163.com', N'Sbs1JfWH9Ug+2345oBDngDLC+2sYVtqj', 1, N'男', N'陈骏', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (104, N'user206', N'user206@126.com', N'wbf3iDOCVQpYIc24rYGZ+KkN3YqisUS5', 1, N'男', N'崔波', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (105, N'user208', N'user208@126.com', N'TbCXKFNjkLMQtjqz4DD2MlZoPnPwvsd/', 1, N'男', N'韩静颐', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (106, N'user210', N'user210@126.com', N'W0DqxqT6HId/3l/EwYXLVnpii9n2Imlf', 1, N'男', N'严安勇', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (107, N'user212', N'user212@126.com', N'2rnN0zgfUrumvNdOEw35tnlPecRX0Eo/', 1, N'男', N'刘攀', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (108, N'user214', N'user214@gmail.com', N'JT93OUwQ+cTmkWYqslRcGfsQZqkvVX+k', 1, N'女', N'刘艳', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (109, N'user216', N'user216@outlook.com', N'Faod+KGqEeQ4YxkkDm3fpZ+TV8SFKNn0', 1, N'女', N'孙昕', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (110, N'user218', N'user218@outlook.com', N'Vz4r5hBrsxbmaFRrKp0Df1QwYylG5r2G', 1, N'女', N'郑新', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (111, N'user220', N'user220@qq.com', N'LHDrHywk9uRdVoe4ObT8XLUZ//BhxCrx', 1, N'女', N'徐睿', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (112, N'user222', N'user222@foxmail.com', N'qf1JWbicb4p3H2+a0Ih2v0P3NYq2IR/h', 1, N'女', N'李月杰', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (113, N'user224', N'user224@126.com', N'j4bujJgwrdGGzEXXc5+UPQaNxUBKjqqm', 1, N'男', N'吕焱鑫', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (114, N'user226', N'user226@foxmail.com', N'tCJEAiilk5k4EIFCtBGhQ5dkThe4j6JF', 1, N'女', N'刘沈', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (115, N'user228', N'user228@126.com', N'tY6Vv7WY17WmKOQXrmsXEQO7HKd4LWYp', 1, N'男', N'朱绍军', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (116, N'user230', N'user230@foxmail.com', N'xgyI8jVK3FhZIo6JZZxpOvmhsaBe2KMI', 1, N'女', N'马茜', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (117, N'user232', N'user232@foxmail.com', N'UKIQYLkyuYvlHS3PZS8o5N7DswQXIL04', 1, N'女', N'唐蕾', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (118, N'user234', N'user234@126.com', N'xZl3/c09w9/ap8ReTkKrF9PY4wELePAZ', 1, N'女', N'刘姣', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (119, N'user236', N'user236@163.com', N'HO2cS7ONk1DFbSrd64GB7PEaYNbIHhng', 1, N'女', N'于芳', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (120, N'user238', N'user238@foxmail.com', N'Fux44RCfZpbbnmg69z9kuK3tjfP/O4kz', 1, N'男', N'吴健', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (121, N'user240', N'user240@foxmail.com', N'QQLuhW50UrdH7lvJon3vYMh0rnNYhz8+', 1, N'女', N'张丹梅', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (122, N'user242', N'user242@qq.com', N'51ImBdk8HdADfyH0uoRsv0/2FKQIaxkf', 1, N'女', N'王燕', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (123, N'user244', N'user244@gmail.com', N'FoNLSKIA0ZcSmllQ/wMb62DxWZvoWlbB', 1, N'女', N'贾兆梅', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (124, N'user246', N'user246@163.com', N'Y1Dkx8xUV0X7Sw3FWWO5F8mNPSjFC1Xk', 1, N'男', N'程柏漠', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (125, N'user248', N'user248@foxmail.com', N'qSIpIMsohf83bJHDbIOdTyoeIIc+VK0E', 1, N'男', N'程辉', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (126, N'user250', N'user250@163.com', N'mi+iz2DBTNLW1yfbpp/5ZVXgkAA7+X3O', 1, N'女', N'任明慧', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (127, N'user252', N'user252@foxmail.com', N'mcULekE10BEb5wjBbL94XzubkSQX0oLD', 1, N'女', N'焦莹', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (128, N'user254', N'user254@126.com', N'ZH/kvcApdQXjPVjlixvuFgN4sNfvj+7w', 1, N'女', N'马淑娟', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (129, N'user256', N'user256@foxmail.com', N'5m5oYRfcjSDRAPSfNlCfQUor7s7iEWxL', 1, N'男', N'徐涛', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (130, N'user258', N'user258@foxmail.com', N'YgPHaoTs5wVx/2wka2RHcDDK/UnX7pqA', 1, N'男', N'孙庆国', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (131, N'user260', N'user260@163.com', N'K6OglxJpkTz2kCQVPNNxQvRZyMrr/7I7', 1, N'男', N'刘胜', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (132, N'user262', N'user262@outlook.com', N'umI1Tkut3pzco7pGenpx1Ynuo3Gb6jyq', 1, N'女', N'傅广凤', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (133, N'user264', N'user264@foxmail.com', N'2qsmaqc3yXTXdYnHzcNwOwx4Z+cPP925', 1, N'男', N'袁弘', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (134, N'user266', N'user266@outlook.com', N'MpfaLOm2uBK4HlyRVEeTI99+npb41Oq9', 1, N'男', N'高令旭', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (135, N'user268', N'user268@163.com', N'ZtszXKn8Rrsz+TAAQyp0OPChqOcVo3oU', 1, N'男', N'栾树权', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (136, N'user270', N'user270@gmail.com', N'0u6p1cFdXwbS2ndPlDXni5rAkTciNt7D', 1, N'女', N'申霞', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (137, N'user272', N'user272@qq.com', N'32FkPyOBHSZOv0kQrxEs+VD3jEhCyTuO', 1, N'女', N'韩文萍', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (138, N'user274', N'user274@foxmail.com', N'9nlgneniYVHHy4pJjv6sDKt+sUKLRuXl', 1, N'女', N'隋艳', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (139, N'user276', N'user276@163.com', N'pEM+osGjdT4NNSToGVoX3ddfQ6AvJ7yl', 1, N'男', N'邢海洲', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (140, N'user278', N'user278@outlook.com', N'L46Asy08UEcoqoPL4jXCYjiQZUDROoso', 1, N'女', N'王宁', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (141, N'user280', N'user280@outlook.com', N'wW5pLIvGIZmYGNCa2eCiiVSI+cku1z7u', 1, N'女', N'陈晶', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (142, N'user282', N'user282@foxmail.com', N'mJCGcsUI3cjdIzZ4fwkt9cejx0gNNQ3s', 1, N'女', N'吕翠', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (143, N'user284', N'user284@163.com', N'Vr03sH2r5ZSXwdLKOpt0FFNxYHbZE9qu', 1, N'女', N'刘少敏', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (144, N'user286', N'user286@126.com', N'ZbuKp2dQXZMlTKZJnNCLiR7SkJQTGCLb', 1, N'女', N'刘少君', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (145, N'user288', N'user288@foxmail.com', N'MRcoKF5LNxgR/7sacdfRPpLOjd8piZsR', 1, N'男', N'孔鹏', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (146, N'user290', N'user290@foxmail.com', N'2ZUumHqP1DffH2MCixq+LXm2gbHapPiG', 1, N'女', N'张冰', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (147, N'user292', N'user292@outlook.com', N'fycbpNyH0J4sizET1909oETb72utU033', 1, N'女', N'王芳', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (148, N'user294', N'user294@foxmail.com', N'wbYYyfEFKhaKKF8CkuzcHGvH4nXUuDt/', 1, N'男', N'万世忠', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (149, N'user296', N'user296@gmail.com', N'OyIRZP16CgRAulAyA+hWnAnkPBz4twR2', 1, N'女', N'徐凡', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (150, N'user298', N'user298@gmail.com', N'32RYzZ2nLwpIhAlq8mdJPeynxNZPu/I/', 1, N'女', N'张玉梅', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (151, N'user300', N'user300@qq.com', N'/aixeD1jG4p8LuDRC71I1l8AJHBEcjxt', 1, N'女', N'何莉', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (152, N'user302', N'user302@foxmail.com', N'V33qL33iveeMZ7QtJCmI2i3gRUINjzHi', 1, N'女', N'时会云', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (153, N'user304', N'user304@outlook.com', N'AcAXmahm82cR8dpZ66xmLgx4ICi3Ntyk', 1, N'女', N'王玉杰', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (154, N'user306', N'user306@qq.com', N'zm3BYMX39M72Yi5If1HZvb33twCbjn2p', 1, N'女', N'谭素英', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (155, N'user308', N'user308@gmail.com', N'x5kSMr5lqL7ryNzc64h29kvnRwjE/4jg', 1, N'女', N'李艳红', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (156, N'user310', N'user310@163.com', N'62lOlTr2LEERM3xXQpxZW5FU1WzgiFwp', 1, N'女', N'刘素莉', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (157, N'user312', N'user312@outlook.com', N'05YRTdryA0BzAyuEViaQd2lc7PTdFIKA', 1, N'男', N'王旭海', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (158, N'user314', N'user314@qq.com', N'/ZiRwVrPwezeAnrEv6SD9GpilmJrkVzh', 1, N'女', N'安丽梅', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (159, N'user316', N'user316@outlook.com', N'0B1LP5Gnzx1/vA/45VNCJiihcsgXYQfK', 1, N'女', N'姚露', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (160, N'user318', N'user318@qq.com', N'RS3OG1ZQw7dV6QSQdf/sXC1EwTr1dpro', 1, N'女', N'贾颖', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (161, N'user320', N'user320@126.com', N'raT2UGitExJl9voloBA8GKQTv19nP0jl', 1, N'女', N'曹微', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (162, N'user322', N'user322@foxmail.com', N'VjLdR4FuE4bFxpnthKutwA7C2e2t8O9z', 1, N'男', N'黄经华', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (163, N'user324', N'user324@163.com', N'Mko6lqc2L+PdVd16+mi23ISVfrOLVgBM', 1, N'女', N'陈玉华', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (164, N'user326', N'user326@outlook.com', N'6C5n9b8dqtiRuRfbiuSpvShGB2cZp9GP', 1, N'女', N'姜媛', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (165, N'user328', N'user328@163.com', N'LK4CzXKS1IIx1GnpJwEbJK1Qq5gwfdxx', 1, N'女', N'魏立平', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (166, N'user330', N'user330@163.com', N'/ob82b6cPnbe3Kb8BV8OD6WucibbEaC0', 1, N'女', N'张萍', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (167, N'user332', N'user332@qq.com', N'iycn1RBtH08Fgc3ZuMHbLNTFxYLbXm+Y', 1, N'男', N'来辉', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (168, N'user334', N'user334@foxmail.com', N'qPuL0rNP4cg63efbDER9tSWN95Wqg5wJ', 1, N'女', N'陈秀玫', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (169, N'user336', N'user336@163.com', N'd17hgorPa0QkyrMOG4ewIjk4ZxcJ7SHg', 1, N'男', N'石岩', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (170, N'user338', N'user338@gmail.com', N'eKYi4iSxjB65m7aMOykX9eju2QL9i28q', 1, N'男', N'王洪捍', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (171, N'user340', N'user340@foxmail.com', N'pQvxeaDSUNQlvpkwGZ8iRAqgZ1MEJVuc', 1, N'男', N'张树军', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (172, N'user342', N'user342@foxmail.com', N'n0xYYV3utrJuzYpGEIE63VAZG68FLhui', 1, N'女', N'李亚琴', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (173, N'user344', N'user344@qq.com', N'u93lwIDsZVrDpIvdP3XkWEIB6eaJpCQd', 1, N'女', N'王凤', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (174, N'user346', N'user346@126.com', N'Djc1zU7y4/jyFIkaOsasjD7YpafwhcnY', 1, N'女', N'王珊华', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (175, N'user348', N'user348@gmail.com', N'gDvPeJOVCbxL88MU9/hJ+kAbHogLBwle', 1, N'女', N'杨丹丹', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (176, N'user350', N'user350@qq.com', N'kl2kymtglsqfpCXUR+o5RTjjf7r6dRZH', 1, N'女', N'教黎明', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (177, N'user352', N'user352@outlook.com', N'ihIk0gCxQfJ6Qhdr7j61Aw2KZPOAVWyN', 1, N'女', N'修晶', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (178, N'user354', N'user354@outlook.com', N'H2zerYzncfj8RRooJfco7nBgL1/tLlZ9', 1, N'女', N'丁晓霞', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (179, N'user356', N'user356@163.com', N'br3hnUHoRC9Nm5IIMiHlHqwxSxSjLTYg', 1, N'女', N'张丽', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (180, N'user358', N'user358@foxmail.com', N'BeJ0jBdtd65/fDP3neQqlTPQ078/5Il8', 1, N'女', N'郭素兰', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (181, N'user360', N'user360@outlook.com', N'4CBcLYIQlIzWVJ5u23G9gyMZQ9yUBC7f', 1, N'女', N'徐艳丽', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (182, N'user362', N'user362@qq.com', N'fWFiMtBUi+h8709B5sAxIcBQeBVcOYKA', 1, N'女', N'任子英', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (183, N'user364', N'user364@163.com', N'nyqopHw922Xza/HXpq4PriYY87Sj/6g8', 1, N'女', N'胡雁', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (184, N'user366', N'user366@126.com', N'wZrx2aDNEco4Kaau9tgpT2LlugiKicQv', 1, N'女', N'彭洪亮', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (185, N'user368', N'user368@outlook.com', N'Kmv5Wp0BX1LyszscwKmqONuC68J3CHij', 1, N'女', N'高玉珍', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (186, N'user370', N'user370@163.com', N'TBnokVjKhWzNV71pqu1Bipw0pveTHfxG', 1, N'女', N'王玉姝', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (187, N'user372', N'user372@foxmail.com', N'LcwWHcHE6H3xH/hAQMAbYpouldv8zE0N', 1, N'男', N'郑伟', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (188, N'user374', N'user374@outlook.com', N'bwSfGrZGFrmKes4k2cR/DzeM10Jv4qDg', 1, N'女', N'姜春玲', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (189, N'user376', N'user376@126.com', N'CIzmqaIot0oiyFW6Bm7VzDEI+2VxdG1d', 1, N'女', N'张伟', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (190, N'user378', N'user378@qq.com', N'GKc+Y21BfF2Rzfx7WKil5Opip9vDbD3T', 1, N'女', N'王颖', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (191, N'user380', N'user380@163.com', N'JdOR4EDr3MyDRZ8KS9Z4jrVqnmHWJatn', 1, N'女', N'金萍', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (192, N'user382', N'user382@foxmail.com', N'SrjrS0d085WTrOUyw5e3o2T6ZxmxG2ff', 1, N'男', N'孙望', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (193, N'user384', N'user384@gmail.com', N'm2X4ciRHwAHn/7XfQcbhr4Ev+2No1pp2', 1, N'男', N'闫宝东', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (194, N'user386', N'user386@gmail.com', N'ind6X5cP/81t/mpMFLnOrJ3fWYQBcB53', 1, N'男', N'周相永', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (195, N'user388', N'user388@gmail.com', N'MkItrp/X/ERak6b1P0zDf57Vv0owgr7z', 1, N'女', N'杨美娜', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (196, N'user390', N'user390@outlook.com', N'kvlVF9HWpNZeZT7ut1EF6nPlVQQ6JSEx', 1, N'女', N'欧立新', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (197, N'user392', N'user392@163.com', N'+p9TJ/xRNwgWUix1mvxcLIBto09xS+U0', 1, N'女', N'刘宝霞', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (198, N'user394', N'user394@126.com', N'oyxYdXoxjcnmm5AWVMvSXw9JFCedYWnZ', 1, N'女', N'刘艳杰', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (199, N'user396', N'user396@gmail.com', N'3+13TWTpdpFPsim5BGn/aGDZkeoZLgNp', 1, N'女', N'宋艳平', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (200, N'user398', N'user398@126.com', N'dNb+bAWv9cXAwG4Wn/Bx2VJXSlSn/z+i', 1, N'男', N'李克', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (201, N'user400', N'user400@foxmail.com', N'9qY3IbykaW+2iGW+iznvYjjAbu8IuWW/', 1, N'女', N'梁翠', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB05 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (202, N'user402', N'user402@outlook.com', N'NsHq31TL/IsZb3BrJZsikdNPxMWbVLlA', 1, N'女', N'宗宏伟', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB06 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (203, N'user404', N'user404@126.com', N'3vUJ0MypN3+mg2pqgmuPsd1Otg2JOrUL', 1, N'女', N'刘国伟', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB06 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (204, N'user406', N'user406@foxmail.com', N'L21RPwTnzUGI6/HwaZN837n3foJ/COIJ', 1, N'女', N'敖志敏', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB06 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (205, N'user408', N'user408@163.com', N'EHF+yd1F3u2BcZN9SuMBfBMx9fxZ6XiS', 1, N'女', N'尹玲', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB06 AS DateTime), NULL)
GO
INSERT [dbo].[t_User] ([FUserId], [FUserName], [FEmail], [FPassword], [FEnabled], [FGender], [FChineseName], [FEnglishName], [FPhoto], [FQQ], [FCompanyEmail], [FOfficePhone], [FOfficePhoneExt], [FHomePhone], [FCellPhone], [FAddress], [FDescription], [FIdentityCard], [FBirthday], [FTakeOfficeTime], [FLastLoginTime], [FBuildDate], [FDepartmentId]) VALUES (206, N'admin', N'admin@examples.com', N'mhVy2NDe8Ud4JQgWIGX9/DbhFg5q9sNE', 1, N'男', N'超级管理员', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A2AE011BFB06 AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[t_User] OFF
GO
/****** Object:  Index [IX_FParentId]    Script Date: 2014/1/16 10:44:51 ******/
CREATE NONCLUSTERED INDEX [IX_FParentId] ON [dbo].[t_Department]
(
	[FParentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FParentId]    Script Date: 2014/1/16 10:44:51 ******/
CREATE NONCLUSTERED INDEX [IX_FParentId] ON [dbo].[t_Menu]
(
	[FParentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FViewPowerId]    Script Date: 2014/1/16 10:44:51 ******/
CREATE NONCLUSTERED INDEX [IX_FViewPowerId] ON [dbo].[t_Menu]
(
	[FViewPowerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FUserId]    Script Date: 2014/1/16 10:44:51 ******/
CREATE NONCLUSTERED INDEX [IX_FUserId] ON [dbo].[t_Online]
(
	[FUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FPowerId]    Script Date: 2014/1/16 10:44:51 ******/
CREATE NONCLUSTERED INDEX [IX_FPowerId] ON [dbo].[t_RolePower]
(
	[FPowerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FRoleId]    Script Date: 2014/1/16 10:44:51 ******/
CREATE NONCLUSTERED INDEX [IX_FRoleId] ON [dbo].[t_RolePower]
(
	[FRoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FRoleId]    Script Date: 2014/1/16 10:44:51 ******/
CREATE NONCLUSTERED INDEX [IX_FRoleId] ON [dbo].[t_RoleUser]
(
	[FRoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FUserId]    Script Date: 2014/1/16 10:44:51 ******/
CREATE NONCLUSTERED INDEX [IX_FUserId] ON [dbo].[t_RoleUser]
(
	[FUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FDepartmentId]    Script Date: 2014/1/16 10:44:51 ******/
CREATE NONCLUSTERED INDEX [IX_FDepartmentId] ON [dbo].[t_User]
(
	[FDepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[t_Department]  WITH CHECK ADD  CONSTRAINT [FK_dbo.t_Department_dbo.t_Department_FParentId] FOREIGN KEY([FParentId])
REFERENCES [dbo].[t_Department] ([FItemId])
GO
ALTER TABLE [dbo].[t_Department] CHECK CONSTRAINT [FK_dbo.t_Department_dbo.t_Department_FParentId]
GO
ALTER TABLE [dbo].[t_Menu]  WITH CHECK ADD  CONSTRAINT [FK_dbo.t_Menu_dbo.t_Menu_FParentId] FOREIGN KEY([FParentId])
REFERENCES [dbo].[t_Menu] ([FItemId])
GO
ALTER TABLE [dbo].[t_Menu] CHECK CONSTRAINT [FK_dbo.t_Menu_dbo.t_Menu_FParentId]
GO
ALTER TABLE [dbo].[t_Menu]  WITH CHECK ADD  CONSTRAINT [FK_dbo.t_Menu_dbo.t_Power_FViewPowerId] FOREIGN KEY([FViewPowerId])
REFERENCES [dbo].[t_Power] ([FPowerId])
GO
ALTER TABLE [dbo].[t_Menu] CHECK CONSTRAINT [FK_dbo.t_Menu_dbo.t_Power_FViewPowerId]
GO
ALTER TABLE [dbo].[t_Online]  WITH CHECK ADD  CONSTRAINT [FK_dbo.t_Online_dbo.t_User_FUserId] FOREIGN KEY([FUserId])
REFERENCES [dbo].[t_User] ([FUserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[t_Online] CHECK CONSTRAINT [FK_dbo.t_Online_dbo.t_User_FUserId]
GO
ALTER TABLE [dbo].[t_RolePower]  WITH CHECK ADD  CONSTRAINT [FK_dbo.t_RolePower_dbo.t_Power_FPowerId] FOREIGN KEY([FPowerId])
REFERENCES [dbo].[t_Power] ([FPowerId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[t_RolePower] CHECK CONSTRAINT [FK_dbo.t_RolePower_dbo.t_Power_FPowerId]
GO
ALTER TABLE [dbo].[t_RolePower]  WITH CHECK ADD  CONSTRAINT [FK_dbo.t_RolePower_dbo.t_Role_FRoleId] FOREIGN KEY([FRoleId])
REFERENCES [dbo].[t_Role] ([FRoleId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[t_RolePower] CHECK CONSTRAINT [FK_dbo.t_RolePower_dbo.t_Role_FRoleId]
GO
ALTER TABLE [dbo].[t_RoleUser]  WITH CHECK ADD  CONSTRAINT [FK_dbo.t_RoleUser_dbo.t_Role_FRoleId] FOREIGN KEY([FRoleId])
REFERENCES [dbo].[t_Role] ([FRoleId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[t_RoleUser] CHECK CONSTRAINT [FK_dbo.t_RoleUser_dbo.t_Role_FRoleId]
GO
ALTER TABLE [dbo].[t_RoleUser]  WITH CHECK ADD  CONSTRAINT [FK_dbo.t_RoleUser_dbo.t_User_FUserId] FOREIGN KEY([FUserId])
REFERENCES [dbo].[t_User] ([FUserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[t_RoleUser] CHECK CONSTRAINT [FK_dbo.t_RoleUser_dbo.t_User_FUserId]
GO
ALTER TABLE [dbo].[t_User]  WITH CHECK ADD  CONSTRAINT [FK_dbo.t_User_dbo.t_Department_FDepartmentId] FOREIGN KEY([FDepartmentId])
REFERENCES [dbo].[t_Department] ([FItemId])
GO
ALTER TABLE [dbo].[t_User] CHECK CONSTRAINT [FK_dbo.t_User_dbo.t_Department_FDepartmentId]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'表单名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_BillId', @level2type=N'COLUMN',@level2name=N'FBillName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'当前最大ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_BillId', @level2type=N'COLUMN',@level2name=N'FMaxId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'表单ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_BillNo', @level2type=N'COLUMN',@level2name=N'FItemId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'表名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_BillNo', @level2type=N'COLUMN',@level2name=N'FBillName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单据名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_BillNo', @level2type=N'COLUMN',@level2name=N'FTableName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'前缀' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_BillNo', @level2type=N'COLUMN',@level2name=N'FPreLetter'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'当前表单ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_BillNo', @level2type=N'COLUMN',@level2name=N'FCurId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'后缀' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_BillNo', @level2type=N'COLUMN',@level2name=N'FSufLetter'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编码格式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_BillNo', @level2type=N'COLUMN',@level2name=N'FFormat'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编码长度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_BillNo', @level2type=N'COLUMN',@level2name=N'FLen'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单据类型ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_BillNo', @level2type=N'COLUMN',@level2name=N'FTranType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'表ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Config', @level2type=N'COLUMN',@level2name=N'FItemId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'配置类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Config', @level2type=N'COLUMN',@level2name=N'FConfigKey'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'配置内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Config', @level2type=N'COLUMN',@level2name=N'FConfigValue'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Config', @level2type=N'COLUMN',@level2name=N'FDescription'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'表单ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Department', @level2type=N'COLUMN',@level2name=N'FItemId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上级ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Department', @level2type=N'COLUMN',@level2name=N'FParentId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部门编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Department', @level2type=N'COLUMN',@level2name=N'FNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部门名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Department', @level2type=N'COLUMN',@level2name=N'FName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Department', @level2type=N'COLUMN',@level2name=N'FDescription'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'表单ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Log', @level2type=N'COLUMN',@level2name=N'FItemId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Role', @level2type=N'COLUMN',@level2name=N'FRoleId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Role', @level2type=N'COLUMN',@level2name=N'FRoleName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Role', @level2type=N'COLUMN',@level2name=N'FDescription'
GO
USE [master]
GO
ALTER DATABASE [FineOA] SET  READ_WRITE 
GO

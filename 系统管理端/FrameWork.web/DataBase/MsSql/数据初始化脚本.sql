﻿--应用数据Start
SET IDENTITY_INSERT [sys_Applications] ON
insert sys_Applications(ApplicationID,A_AppName,A_AppDescription,A_AppUrl) values(	1	,	N'系统模块'	,	N'管理员专用系统'	,	'http://www.baidu.com'	)
SET IDENTITY_INSERT [sys_Applications] OFF
--应用数据End
---系统模块初始化Start
SET IDENTITY_INSERT [sys_Module] ON
insert sys_module(ModuleID,M_ApplicationID,M_ParentID,M_PageCode,M_CName,M_Directory,M_OrderLevel,M_IsSystem,M_Close) values(	1	,	1	,	0	,	'S00'	,	N'后台管理'	,	NULL	,	'0000'	,	1	,	0	)
insert sys_module(ModuleID,M_ApplicationID,M_ParentID,M_PageCode,M_CName,M_Directory,M_OrderLevel,M_IsSystem,M_Close) values(	2	,	1	,	1	,	'S00M00'	,	N'应用列表管理'	,	N'Module/FrameWork/SystemApp/AppManager/list.aspx'	,	'0001'	,	1	,	0	)
insert sys_module(ModuleID,M_ApplicationID,M_ParentID,M_PageCode,M_CName,M_Directory,M_OrderLevel,M_IsSystem,M_Close) values(	4	,	1	,	1	,	'S00M01'	,	N'部门资料管理'	,	N'Module/FrameWork/SystemApp/GroupManager/Frame.aspx'	,	'0003'	,	1	,	0	)
insert sys_module(ModuleID,M_ApplicationID,M_ParentID,M_PageCode,M_CName,M_Directory,M_OrderLevel,M_IsSystem,M_Close) values(	5	,	1	,	1	,	'S00M02'	,	N'角色资料管理'	,	N'Module/FrameWork/SystemApp/RoleManager/RoleList.aspx'	,	'0004'	,	1	,	0	)
insert sys_module(ModuleID,M_ApplicationID,M_ParentID,M_PageCode,M_CName,M_Directory,M_OrderLevel,M_IsSystem,M_Close) values(	6	,	1	,	1	,	'S00M03'	,	N'用户资料管理'	,	N'Module/FrameWork/SystemApp/UserManager/default.aspx'	,	'0005'	,	1	,	0	)
insert sys_module(ModuleID,M_ApplicationID,M_ParentID,M_PageCode,M_CName,M_Directory,M_OrderLevel,M_IsSystem,M_Close) values(	7	,	1	,	1	,	'S00M04'	,	N'系统字典设定'	,	N'Module/FrameWork/SystemApp/FieldManager/default.aspx'	,	'0006'	,	1	,	0	)
insert sys_module(ModuleID,M_ApplicationID,M_ParentID,M_PageCode,M_CName,M_Directory,M_OrderLevel,M_IsSystem,M_Close) values(	8	,	1	,	1	,	'S00M05'	,	N'事件日志管理'	,	N'Module/FrameWork/SystemApp/EventManager/default.aspx'	,	'0007'	,	1	,	0	)
insert sys_module(ModuleID,M_ApplicationID,M_ParentID,M_PageCode,M_CName,M_Directory,M_OrderLevel,M_IsSystem,M_Close) values(	9	,	1	,	1	,	'S00M06'	,	N'在线用户列表'	,	N'Module/FrameWork/SystemApp/OnlineUserManager/default.aspx'	,	'0008'	,	1	,	0	)
insert sys_module(ModuleID,M_ApplicationID,M_ParentID,M_PageCode,M_CName,M_Directory,M_OrderLevel,M_IsSystem,M_Close) values(	26	,	1	,	1	,	'S00M07'	,	N'应用模块管理'	,	N'Module/FrameWork/SystemApp/ModuleManager/list.aspx'	,	'0002'	,	1	,	0	)
insert sys_module(ModuleID,M_ApplicationID,M_ParentID,M_PageCode,M_CName,M_Directory,M_OrderLevel,M_IsSystem,M_Close) values(	27	,	1	,	0	,	'S01'	,	N'系统维护'	,	N''	,	'0100'	,	1	,	0	)
insert sys_module(ModuleID,M_ApplicationID,M_ParentID,M_PageCode,M_CName,M_Directory,M_OrderLevel,M_IsSystem,M_Close) values(	28	,	1	,	27	,	'S01M00'	,	N'系统运行状态'	,	N'Module/FrameWork/SystemMaintenance/SystemState/default.aspx'	,	'0101'	,	1	,	0	)
insert sys_module(ModuleID,M_ApplicationID,M_ParentID,M_PageCode,M_CName,M_Directory,M_OrderLevel,M_IsSystem,M_Close) values(	29	,	1	,	27	,	'S01M01'	,	N'系统异常日志'	,	N'Module/FrameWork/SystemMaintenance/SystemErrorLog/default.aspx'	,	'0102'	,	1	,	0	)
insert sys_module(ModuleID,M_ApplicationID,M_ParentID,M_PageCode,M_CName,M_Directory,M_OrderLevel,M_IsSystem,M_Close) values(	30	,	1	,	27	,	'S01M02'	,	N'系统环境配置'	,	N'Module/FrameWork/SystemMaintenance/SystemConfig/default.aspx'	,	'0103'	,	1	,	0	)
SET IDENTITY_INSERT [sys_Module] OFF
---系统模块初始化End
--系统管理员增加 Start---
SET IDENTITY_INSERT [sys_User] ON
insert sys_User(UserID,U_LoginName,U_Password,U_CName,U_EName,U_GroupID,U_Email,U_Type,U_Status,U_Licence,U_Mac,U_Remark,U_IDCard,U_Sex,U_BirthDay,U_MobileNo,U_UserNO,U_WorkStartDate,U_WorkEndDate,U_CompanyMail,U_Title,U_Extension,U_HomeTel,U_PhotoUrl,U_DateTime,U_LastIP,U_LastDateTime,U_ExtendField) values(	1	,	N'admin'	,	'21232F297A57A5A743894A0E4A801FC3'	,	N'管理员'	,	''	,	0	,	''	,	0	,	0	,	''	,	''	,	N''	,	''	,	0	,	'2007-06-23 00:00:00.000'	,	''	,	''	,	'2007-06-23 00:00:00.000'	,	'2007-06-23 15:32:19.263'	,	''	,	17	,	''	,	''	,	N''	,	'2007-06-23 15:32:19.263'	,	''	,	'2007-06-23 15:32:19.263'	,'1,10')
SET IDENTITY_INSERT [sys_User] OFF
--系统管理员增加 End--
--应用字段Start
SET IDENTITY_INSERT [sys_Field] ON
insert sys_Field(FieldID,F_Key,F_CName,F_Remark) values(	2	,	'Title'	,	N'职称'	,	N'用户职称列表'	)
SET IDENTITY_INSERT [sys_Field] OFF
SET IDENTITY_INSERT [sys_FieldValue] ON
insert sys_FieldValue(ValueID,V_F_Key,V_Text,V_ShowOrder) values(	5	,	'title'	,	N'普通员工'	,	5	)
insert sys_FieldValue(ValueID,V_F_Key,V_Text,V_ShowOrder) values(	16	,	'Title'	,	N'职业员工'	,	3	)
insert sys_FieldValue(ValueID,V_F_Key,V_Text,V_ShowOrder) values(	17	,	'Title'	,	N'高级程序员'	,	2	)
insert sys_FieldValue(ValueID,V_F_Key,V_Text,V_ShowOrder) values(	18	,	'Title'	,	N'试用期员工'	,	4	)
insert sys_FieldValue(ValueID,V_F_Key,V_Text,V_ShowOrder) values(	19	,	'Title'	,	N'经理员工'	,	1	)
SET IDENTITY_INSERT [sys_FieldValue] OFF
--应用字段End

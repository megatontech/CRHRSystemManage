CREATE DATABASE MyOffice
GO
USE MyOffice
GO
---------------------状态---------可扩展性，设置用户是否被屏蔽的状态------------------------------
CREATE TABLE UserState
(
 Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,--ID
 UserStateName Varchar(50) NOT NULL--1：正常状态；0：被屏蔽
)
INSERT INTO UserState(UserStateName)VALUES('被屏蔽')
INSERT INTO UserState(UserStateName)VALUES('正常状态')
--SELECT * FROM UserState
GO
--------------------------------存放角色基本信息------------------------------
CREATE TABLE RoleInfo
(
 RoleId INT IDENTITY(1,1) PRIMARY KEY NOT NULL,--角色id 
 RoleName Varchar(50) NOT NULL,--1：角色名称
 RoleDesc Varchar(50) --角色描述
)
INSERT INTO RoleInfo(RoleName,RoleDesc)VALUES('未审批用户','还没有使用该系统的权限。')
INSERT INTO RoleInfo(RoleName,RoleDesc)VALUES('普通用户','一般用户')
INSERT INTO RoleInfo(RoleName,RoleDesc)VALUES('系统管理员','拥有本系统最高管理权限')
INSERT INTO RoleInfo(RoleName,RoleDesc)VALUES('公司老总','拥有最高的检查权')
INSERT INTO RoleInfo(RoleName,RoleDesc)VALUES('部门经理','管辖本部门相关工作')
INSERT INTO RoleInfo(RoleName,RoleDesc)VALUES('临时角色','测试几个项目')
--SELECT * FROM RoleInfo
GO
---------------------------------机构信息表------------------------------
CREATE TABLE BranchInfo
(
 Id  INT IDENTITY(1,1) PRIMARY KEY NOT NULL,---机构id
 BranchName Varchar(50) NOT NULL,--机构名称
 BranchShortName Varchar(50) NOT NULL--机构简称
)
INSERT INTO BranchInfo (BranchName,BranchShortName)VALUES('华北电力科学研究院','华电')
INSERT INTO BranchInfo (BranchName,BranchShortName)VALUES('中国科学院声学研究所','中科声研究所')
INSERT INTO BranchInfo (BranchName,BranchShortName)VALUES('北大青鸟集团','青鸟')
INSERT INTO BranchInfo (BranchName,BranchShortName)VALUES('大唐国际盘山发电有限公司','盘电')
--SELECT * FROM BranchInfo
GO
-------------------------------部门信息表------------------------------
CREATE TABLE DepartInfo
(
 Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,--部门id
 DepartName Varchar(50) NOT NULL ,--部门名称
 PrincipalUserId INT NOT NULL ,--部门负责人
 ConnectTelNo	varchar(20) ,--联系电话
 ConnectMobileTelNo char(11) ,--移动电话
 Faxes	varchar(20) ,--传真
 BranchId INT NOT NULL FOREIGN KEY (BranchId) REFERENCES BranchInfo(Id)--所属机构
)
INSERT INTO DepartInfo(DepartName,PrincipalUserId,ConnectTelNo,ConnectMobileTelNo,Faxes,BranchId)
VALUES('销售部',1,'62768866','13910255752','62768866',1)
INSERT INTO DepartInfo(DepartName,PrincipalUserId,ConnectTelNo,ConnectMobileTelNo,Faxes,BranchId)
VALUES('研发部',1,'62768866','13520319928','62768866',2)
INSERT INTO DepartInfo(DepartName,PrincipalUserId,ConnectTelNo,ConnectMobileTelNo,Faxes,BranchId)
VALUES('财务部',8,'62768866','13520319928','62768866',3)
INSERT INTO DepartInfo(DepartName,PrincipalUserId,ConnectTelNo,ConnectMobileTelNo,Faxes,BranchId)
VALUES('发电部',9,'62768866','13920319928','62768866',4)
INSERT INTO DepartInfo(DepartName,PrincipalUserId,ConnectTelNo,ConnectMobileTelNo,Faxes,BranchId)
VALUES('综合部',2,'83258011','13910255752','82353695',3)
INSERT INTO DepartInfo(DepartName,PrincipalUserId,ConnectTelNo,ConnectMobileTelNo,Faxes,BranchId)
VALUES('培训部',1,'62768866','13910255752','62768866',3)
--SELECT * FROM DepartInfo
GO
--------------------------------存放用户基本信息------------------------------
CREATE TABLE UserInfo
(
 Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,--用户唯一标识
 LoginId Varchar(50) NOT NULL,--用户Id
 UserName Varchar(50) NOT NULL,--真实姓名
 PassWord Varchar(50) NOT NULL,--密码
 DepartId INT NOT NULL FOREIGN KEY (DepartId) REFERENCES DepartInfo(Id),--表DepartInfoe的外键，对应DepartId 字段(所在部门)
 Gender	INT NOT NULL,--性别
 RoleId	INT NOT NULL FOREIGN KEY (RoleId) REFERENCES RoleInfo(RoleId),--表RoleInfo的外键，对应RoleId 字段(用户角色)
 UserStateId INT NOT NULL FOREIGN KEY (UserStateId) REFERENCES UserState(Id)--表UserState的外键，对应UserStateId 字段(用户状态)
)
INSERT INTO UserInfo(LoginId,UserName,PassWord,DepartId,Gender,RoleId,UserStateId)
VALUES('admin','系统管理员','123',2,1,3,1)
INSERT INTO UserInfo(LoginId,UserName,PassWord,DepartId,Gender,RoleId,UserStateId)
VALUES('jiyaoqin','姬耀钦','123',4,1,2,1)
INSERT INTO UserInfo(LoginId,UserName,PassWord,DepartId,Gender,RoleId,UserStateId)
VALUES('leibeibei','李贝贝','666',1,0,2,1)
INSERT INTO UserInfo(LoginId,UserName,PassWord,DepartId,Gender,RoleId,UserStateId)
VALUES('liuguangping','刘广平','123',5,1,2,1)
INSERT INTO UserInfo(LoginId,UserName,PassWord,DepartId,Gender,RoleId,UserStateId)
VALUES('qijingxue','齐静雪','123',1,0,1,1)
INSERT INTO UserInfo(LoginId,UserName,PassWord,DepartId,Gender,RoleId,UserStateId)
VALUES('wangchao','王超','123',6,1,2,1)
INSERT INTO UserInfo(LoginId,UserName,PassWord,DepartId,Gender,RoleId,UserStateId)
VALUES('wuliping','武丽平','666',2,0,2,1)
INSERT INTO UserInfo(LoginId,UserName,PassWord,DepartId,Gender,RoleId,UserStateId)
VALUES('yangjiali','杨嘉丽','666',1,0,2,1)
INSERT INTO UserInfo(LoginId,UserName,PassWord,DepartId,Gender,RoleId,UserStateId)
VALUES('yuanbin','袁斌','123',4,1,2,1)
--SELECT * FROM UserInfo
GO
-------------------------------------存放菜单功能基本信息-------------------------------------------
CREATE TABLE SysFun
(
NodeId	INT  PRIMARY KEY NOT NULL,---菜单节点id
DisplayName Varchar(50) NOT NULL,---菜单名称
NodeURL	Varchar(50),---菜单连接地址
DisplayOrder INT NOT NULL,----菜单显示顺序
ParentNodeId INT NOT NULL---父节点id
)
INSERT INTO SysFun(NodeId,DisplayName,DisplayOrder,ParentNodeId)
VALUES(101,'人事管理',1,0)
INSERT INTO SysFun(NodeId,DisplayName,DisplayOrder,ParentNodeId)
VALUES(102,'日程管理',2,0)
INSERT INTO SysFun(NodeId,DisplayName,DisplayOrder,ParentNodeId)
VALUES(103,'文档管理',3,0)
INSERT INTO SysFun(NodeId,DisplayName,DisplayOrder,ParentNodeId)
VALUES(104,'消息传递',4,0)
INSERT INTO SysFun(NodeId,DisplayName,DisplayOrder,ParentNodeId)
VALUES(105,'系统管理',5,0)
INSERT INTO SysFun(NodeId,DisplayName,DisplayOrder,ParentNodeId)
VALUES(106,'考勤管理',6,0)
INSERT INTO SysFun(NodeId,DisplayName,NodeURL,DisplayOrder,ParentNodeId)
VALUES(101001,'机构信息','PersonManage/BranchManage.aspx',1,101)
INSERT INTO SysFun(NodeId,DisplayName,NodeURL,DisplayOrder,ParentNodeId)
VALUES(101002,'部门信息','PersonManage/DepartManage.aspx',2,101)
INSERT INTO SysFun(NodeId,DisplayName,NodeURL,DisplayOrder,ParentNodeId)
VALUES(101003,'员工管理','PersonManage/UserManage.aspx',3,101)
INSERT INTO SysFun(NodeId,DisplayName,NodeURL,DisplayOrder,ParentNodeId)
VALUES(102001,'我的日程','ScheduleManage/PersonSchedule/PersonSchedule.aspx',4,102)
INSERT INTO SysFun(NodeId,DisplayName,NodeURL,DisplayOrder,ParentNodeId)
VALUES(102002,'部门日程','ScheduleManage/DepartSchedule/DepartSchedule.aspx',5,102)
INSERT INTO SysFun(NodeId,DisplayName,NodeURL,DisplayOrder,ParentNodeId)
VALUES(102003,'我的便签','ScheduleManage/PersonNote/PersonNote.aspx',6,102)
INSERT INTO SysFun(NodeId,DisplayName,NodeURL,DisplayOrder,ParentNodeId)
VALUES(103001,'文档管理','File/FileManage/FileManage.aspx',7,103)
INSERT INTO SysFun(NodeId,DisplayName,NodeURL,DisplayOrder,ParentNodeId)
VALUES(103002,'回收站','File/RecycleBin.aspx',8,103)
INSERT INTO SysFun(NodeId,DisplayName,NodeURL,DisplayOrder,ParentNodeId)
VALUES(103003,'文件搜索','File/FileSearch.aspx',9,103)
INSERT INTO SysFun(NodeId,DisplayName,NodeURL,DisplayOrder,ParentNodeId)
VALUES(104001,'消息管理','Message/MessageManage/MessageManage.aspx',10,104)
INSERT INTO SysFun(NodeId,DisplayName,NodeURL,DisplayOrder,ParentNodeId)
VALUES(104002,'信箱','Message/MailBox/MailBox.aspx',11,104)
INSERT INTO SysFun(NodeId,DisplayName,NodeURL,DisplayOrder,ParentNodeId)
VALUES(105001,'角色管理','SysManage/RoleManage/RoleManage.aspx',12,105)
INSERT INTO SysFun(NodeId,DisplayName,NodeURL,DisplayOrder,ParentNodeId)
VALUES(105002,'登录日志','SysManage/LoginLog.aspx',13,105)
INSERT INTO SysFun(NodeId,DisplayName,NodeURL,DisplayOrder,ParentNodeId)
VALUES(105003,'操作日志','SysManage/OperateLog.aspx',14,105)
INSERT INTO SysFun(NodeId,DisplayName,NodeURL,DisplayOrder,ParentNodeId)
VALUES(105004,'菜单排序','SysManage/MenuAdjust.aspx',15,105)
INSERT INTO SysFun(NodeId,DisplayName,NodeURL,DisplayOrder,ParentNodeId)
VALUES(106001,'员工签到、签退','ManualSign/ManualSign.aspx',16,106)
INSERT INTO SysFun(NodeId,DisplayName,NodeURL,DisplayOrder,ParentNodeId)
VALUES(106002,'考勤历史查询','ManualSign/ManualSignSearch.aspx',17,106)
INSERT INTO SysFun(NodeId,DisplayName,NodeURL,DisplayOrder,ParentNodeId)
VALUES(106003,'考勤统计','ManualSign/SignStatistic.aspxx',18,106)
---SELECT * FROM SysFun
GO
---------------------------------------存放所有角色权限--------------------------------------------
CREATE TABLE RoleRight
(
 Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
 RoleId	INT NOT NULL FOREIGN KEY (RoleId) REFERENCES RoleInfo(RoleId),--表RoleInfo的外键，对应RoleId(角色id)
 NodeId	INT NOT NULL FOREIGN KEY (NodeId) REFERENCES SysFun(NodeId)--表SysFun的外键，对应NodeId(菜单节点id)
)
INSERT INTO RoleRight(RoleId,NodeId)VALUES(2,101)
INSERT INTO RoleRight(RoleId,NodeId)VALUES(2,101001)
INSERT INTO RoleRight(RoleId,NodeId)VALUES(2,101002)
INSERT INTO RoleRight(RoleId,NodeId)VALUES(2,101003)
INSERT INTO RoleRight(RoleId,NodeId)VALUES(2,102)
INSERT INTO RoleRight(RoleId,NodeId)VALUES(2,102001)
INSERT INTO RoleRight(RoleId,NodeId)VALUES(2,102002)
INSERT INTO RoleRight(RoleId,NodeId)VALUES(2,102003)
INSERT INTO RoleRight(RoleId,NodeId)VALUES(2,103)
INSERT INTO RoleRight(RoleId,NodeId)VALUES(2,103001)
INSERT INTO RoleRight(RoleId,NodeId)VALUES(2,103002)
INSERT INTO RoleRight(RoleId,NodeId)VALUES(2,103003)
INSERT INTO RoleRight(RoleId,NodeId)VALUES(2,104)
INSERT INTO RoleRight(RoleId,NodeId)VALUES(2,104001)
INSERT INTO RoleRight(RoleId,NodeId)VALUES(2,105)
INSERT INTO RoleRight(RoleId,NodeId)VALUES(2,105001)
INSERT INTO RoleRight(RoleId,NodeId)VALUES(2,105002)
INSERT INTO RoleRight(RoleId,NodeId)VALUES(2,105003)
INSERT INTO RoleRight(RoleId,NodeId)VALUES(2,105004)
INSERT INTO RoleRight(RoleId,NodeId)VALUES(2,106)
INSERT INTO RoleRight(RoleId,NodeId)VALUES(2,106001)
INSERT INTO RoleRight(RoleId,NodeId)VALUES(2,106002)
INSERT INTO RoleRight(RoleId,NodeId)VALUES(2,106003)
INSERT INTO RoleRight(RoleId,NodeId)VALUES(1,102)
INSERT INTO RoleRight(RoleId,NodeId)VALUES(1,102001)
INSERT INTO RoleRight(RoleId,NodeId)VALUES(1,102002)
INSERT INTO RoleRight(RoleId,NodeId)VALUES(1,102003)
INSERT INTO RoleRight(RoleId,NodeId)VALUES(1,103)
INSERT INTO RoleRight(RoleId,NodeId)VALUES(1,103001)
INSERT INTO RoleRight(RoleId,NodeId)VALUES(1,103002)
INSERT INTO RoleRight(RoleId,NodeId)VALUES(1,103003)
INSERT INTO RoleRight(RoleId,NodeId)VALUES(1,104)
INSERT INTO RoleRight(RoleId,NodeId)VALUES(1,104001)
INSERT INTO RoleRight(RoleId,NodeId)VALUES(1,104002)
INSERT INTO RoleRight(RoleId,NodeId)VALUES(1,106)
INSERT INTO RoleRight(RoleId,NodeId)VALUES(1,106001)
--SELECT * FROM RoleRight

GO
----------------------------------------文件类型表-----------------------------------------
CREATE TABLE FileTypeInfo
(
 Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,--文件类型id
 FileTypeName	Varchar(50) NOT NULL,--文件类型名
 FileTypeImage	Varchar(50) NOT NULL,--文件类型对应的图标
 FileTypeSuffix	Varchar(50)--文件类型后缀
)
INSERT INTO FileTypeInfo(FileTypeName,FileTypeImage,FileTypeSuffix)
VALUES('文件夹','../../images/file/folder.gif','0')
INSERT INTO FileTypeInfo(FileTypeName,FileTypeImage,FileTypeSuffix)
VALUES('其他文件','../../images/file/other.gif','noname')
INSERT INTO FileTypeInfo(FileTypeName,FileTypeImage,FileTypeSuffix)
VALUES('Word文档','../../images/file/word.gif','doc')
INSERT INTO FileTypeInfo(FileTypeName,FileTypeImage,FileTypeSuffix)
VALUES('Excel文档','../../images/file/excel.gif','xls')
INSERT INTO FileTypeInfo(FileTypeName,FileTypeImage,FileTypeSuffix)
VALUES('PowerPoint演示文档','../../images/file/ppt.gif','ppt')
INSERT INTO FileTypeInfo(FileTypeName,FileTypeImage,FileTypeSuffix)
VALUES('Access文档','../../images/file/access.gif','mdb')
INSERT INTO FileTypeInfo(FileTypeName,FileTypeImage,FileTypeSuffix)
VALUES('超文本文档','../../images/file/html.gif','htm')
INSERT INTO FileTypeInfo(FileTypeName,FileTypeImage,FileTypeSuffix)
VALUES('图片文档','../../images/file/bmp.gif','gif')
INSERT INTO FileTypeInfo(FileTypeName,FileTypeImage,FileTypeSuffix)
VALUES('压缩文档','../../images/file/zip.gif','rar')
INSERT INTO FileTypeInfo(FileTypeName,FileTypeImage,FileTypeSuffix)
VALUES('文本文档','../../images/file/note1.gif','txt')
INSERT INTO FileTypeInfo(FileTypeName,FileTypeImage,FileTypeSuffix)
VALUES('多媒体文档','../../images/file/media.gif','avi')
INSERT INTO FileTypeInfo(FileTypeName,FileTypeImage,FileTypeSuffix)
VALUES('Acrobat文档','../../images/file/pdf.gif','pdf')
INSERT INTO FileTypeInfo(FileTypeName,FileTypeImage,FileTypeSuffix)
VALUES('可执行文件','../../images/file/exe.gif','exe')
--SELECT * FROM FileTypeInfo
GO
---------------------------------------文件信息表-----------------------------------------------
CREATE TABLE FileInfo
(
 Id	INT IDENTITY(1,1) PRIMARY KEY NOT NULL,--文件Id
 FileName Varchar(50) NOT NULL,--文件名称
 FileTypeId int NOT NULL FOREIGN KEY (FileTypeId) REFERENCES FileTypeInfo(Id),--FileTypeInfo表的外键，对应FileTypeId字段(文件类型)
 Remark	Varchar(50),--备注
 FileOwnerId int NOT NULL FOREIGN KEY (FileOwnerId) REFERENCES UserInfo(Id),--表UserInfo外键，对应UserId字段(创建者)
 CreateDate DateTime NOT NULL,--创建日期
 ParentId INT NOT NULL,--父节点Id
 FilePath Varchar(200) NOT NULL,--文件路径
 IfDelete BIT NOT NULL--是否已删除。1：已删除、2：未删除
)
INSERT INTO FileInfo(FileName,FileTypeId,Remark,FileOwnerId,CreateDate,ParentId,FilePath,IfDelete)
VALUES('公共文挡',1,'对整个系统的整体说明',1,'2007-12-12 11:00:00',0,'c:\\公共文挡',0)
INSERT INTO FileInfo(FileName,FileTypeId,Remark,FileOwnerId,CreateDate,ParentId,FilePath,IfDelete)
VALUES('管理制度',1,'公司的整个管理规范',2,'2007-12-16 12:00:00',0,'c:\\管理制度',0)
INSERT INTO FileInfo(FileName,FileTypeId,Remark,FileOwnerId,CreateDate,ParentId,FilePath,IfDelete)
VALUES('部门文档',1,'各部门的文件分类',1,'2007-12-16 9:00:00',0,'c:\\部门文档',0)
INSERT INTO FileInfo(FileName,FileTypeId,Remark,FileOwnerId,CreateDate,ParentId,FilePath,IfDelete)
VALUES('研发部',1,'研发部相关资料',8,'2007-12-16 19:00:00',4,'c:\\部门文档\研发部',0)
INSERT INTO FileInfo(FileName,FileTypeId,Remark,FileOwnerId,CreateDate,ParentId,FilePath,IfDelete)
VALUES('部门员工介绍',1,'介绍所有研发部员工的基本信息。',1,'2007-12-21 11:06:01',5,'c:\\部门文档\研发部\部门员工介绍',0)
INSERT INTO FileInfo(FileName,FileTypeId,Remark,FileOwnerId,CreateDate,ParentId,FilePath,IfDelete)
VALUES('所有项目',1,'所有可用的项目汇总。',1,'2007-12-21 11:06:38',5,'c:\\部门文档\研发部\所有项目',0)
INSERT INTO FileInfo(FileName,FileTypeId,Remark,FileOwnerId,CreateDate,ParentId,FilePath,IfDelete)
VALUES('ACCP员工基本资料',3,'若要查看详细，请联系管理员。',1,'2007-12-21 11:07:40',19,'c:\\部门文档\研发部\部门员工介绍\ACCP员工基本资料',0)
INSERT INTO FileInfo(FileName,FileTypeId,Remark,FileOwnerId,CreateDate,ParentId,FilePath,IfDelete)
VALUES('MyOffice',1,'bishexiangmu',1,'2007-12-22 11:19:34',20,'c:\\部门文档\研发部\所有项目\MyOffice',1)
INSERT INTO FileInfo(FileName,FileTypeId,Remark,FileOwnerId,CreateDate,ParentId,FilePath,IfDelete)
VALUES('游戏点卡销售系统',1,'毕业设计项目',1,'2007-12-22 11:19:57',20,'c:\\部门文档\研发部\所有项目\游戏点卡销售系统',0)
INSERT INTO FileInfo(FileName,FileTypeId,Remark,FileOwnerId,CreateDate,ParentId,FilePath,IfDelete)
VALUES('MyOffice说明文档',3,'说明文档',1,'2007-12-22 11:28:49',31,'c:\\部门文档\研发部\所有项目\MyOffice\MyOffice说明文档',0)
INSERT INTO FileInfo(FileName,FileTypeId,Remark,FileOwnerId,CreateDate,ParentId,FilePath,IfDelete)
VALUES('游戏点卡销售系统说明书',3,'说明书',1,'2007-12-22 11:29:18',32,'c:\\部门文档\研发部\所有项目\游戏点卡销售系统\游戏点卡销售系统说明书',0)
INSERT INTO FileInfo(FileName,FileTypeId,Remark,FileOwnerId,CreateDate,ParentId,FilePath,IfDelete)
VALUES('Java项目',1,'Java毕业设计项目',1,'2007-12-22 11:33:35',20,'c:\\部门文档\研发部\所有项目\Java项目',0)
INSERT INTO FileInfo(FileName,FileTypeId,Remark,FileOwnerId,CreateDate,ParentId,FilePath,IfDelete)
VALUES('ACCP5.0产品发布',1,'所有即将发布的产品',1,'2007-12-31 22:30:34',5,'c:\\部门文档\研发部\ACCP5.0产品发布',0)
--SELECT * FROM FileInfo
GO
------------------------------------附件文件表-------------------------------------------------------
CREATE TABLE AccessoryFile
(
 Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,--文件附件Id
 FileId	INT NOT NULL FOREIGN KEY (FileId) REFERENCES FileInfo(Id),--表FileInfo的外键，对应FileId 字段 (文件Id)
 AccessoryName	Varchar(50) NOT NULL,--附件名称
 AccessorySize	INT NOT NULL,--附件大小
 AccessoryTypeId INT NOT NULL FOREIGN KEY (AccessoryTypeId) REFERENCES FileTypeInfo(Id),--(FileTypeInfo表的外键，对应FileTypeId字段)附件类型
 CreateDate	DateTime NOT NULL,--创建日期
 AccessoryPath	Varchar(200) NOT NULL--附件路径
)
INSERT INTO AccessoryFile(FileId,AccessoryName,AccessorySize,AccessoryTypeId,CreateDate,AccessoryPath)
VALUES(10,'MyOffice项目说明',24064,3,'2007-12-22 11:28:49','c:\\部门文档\研发部\所有项目\MyOffice\MyOffice说明文档\MyOffice项目说明.doc')
--SELECT * FROM AccessoryFile
GO
------------------------------考勤信息表--------------------------------------------------------------
CREATE TABLE ManualSign
(
 Id	INT IDENTITY(1,1) PRIMARY KEY NOT NULL,--签卡Id
 UserId	INT NOT NULL FOREIGN KEY (UserId) REFERENCES UserInfo(Id),--表UserInfo中UserId的外键(用户id)
 SignTime DateTime NOT NULL,--签卡时间
 SignDesc Varchar(200) NOT NULL,--签卡备注
 SignTag INT NOT NULL--签卡标记
)
INSERT INTO ManualSign(UserId,SignTime,SignDesc,SignTag)VALUES(2,'2007-12-6 7:36:14','测试一下',1)
INSERT INTO ManualSign(UserId,SignTime,SignDesc,SignTag)VALUES(2,'2007-12-6 10:36:29','测试一下',0)
INSERT INTO ManualSign(UserId,SignTime,SignDesc,SignTag)VALUES(8,'2007-12-6 8:56:22','上午报到',1)
INSERT INTO ManualSign(UserId,SignTime,SignDesc,SignTag)VALUES(4,'2007-12-6 8:03:20','签到测试.',1)
INSERT INTO ManualSign(UserId,SignTime,SignDesc,SignTag)VALUES(4,'2007-12-6 17:03:34','签退测试.',0)
INSERT INTO ManualSign(UserId,SignTime,SignDesc,SignTag)VALUES(6,'2007-12-6 17:40:00','我是博望老总。',1)
INSERT INTO ManualSign(UserId,SignTime,SignDesc,SignTag)VALUES(6,'2007-12-6 17:40:58','今天员工可以提前回家。',0)
INSERT INTO ManualSign(UserId,SignTime,SignDesc,SignTag)VALUES(1,'2007-12-7 9:40:58','haha',1)
INSERT INTO ManualSign(UserId,SignTime,SignDesc,SignTag)VALUES(1,'2007-12-7 15:30:58','heihei',0)
INSERT INTO ManualSign(UserId,SignTime,SignDesc,SignTag)VALUES(8,'2007-12-7 8:20:58','haha',1)
INSERT INTO ManualSign(UserId,SignTime,SignDesc,SignTag)VALUES(8,'2007-12-7 15:40:58','heihei',0)
INSERT INTO ManualSign(UserId,SignTime,SignDesc,SignTag)VALUES(1,'2008-1-16 8:52:19','管理员测试一下。',1)
INSERT INTO ManualSign(UserId,SignTime,SignDesc,SignTag)VALUES(1,'2008-1-16 9:06:43','管理员身份测试签退操作。',0)
--SELECT * FROM ManualSign
------------------------------------------上下班时间表--------------------------------------------------
GO
CREATE TABLE WorkTime
(
 Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,--工作时间ID
 OnDutyTime DateTime NOT NULL,--上班时间
 OffDutyTime DateTime NOT NULL --下班时间
)
INSERT INTO WorkTime(OnDutyTime,OffDutyTime)VALUES('8:30:00','17:30:00')
--SELECT * FROM WorkTime
GO
-----------------------------------消息类型表--------------------------------------------------
CREATE TABLE MessageType
(
 Id	INT IDENTITY(1,1) PRIMARY KEY NOT NULL,--消息类型Id
 MessageTypeName Varchar(50) NOT NULL,--消息类型名称
 MessageDesc Varchar(50)--消息类型描述
)
INSERT INTO MessageType(MessageTypeName)VALUES('一般消息')
INSERT INTO MessageType(MessageTypeName,MessageDesc)VALUES('紧急消息','非常重要的消息，需要立刻阅读')
--SELECT * FROM MessageType
GO
--------------------------------------消息表-----------------------------------------------------
CREATE TABLE Message
(
 Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,--	消息Id
 Title	Varchar(100) NOT NULL,--消息标题
 Content Varchar(5000) NOT NULL,--	消息内容
 MessageTypeId	INT NOT NULL FOREIGN KEY (MessageTypeId) REFERENCES MessageType(Id),--表MessageType中MessageTypeId的外键（消息类型）
 BeginTime DateTime NOT NULL,--	开始有效时间
 EndTime DateTime NOT NULL,--	有效结束时间
 FromUserId INT NOT NULL FOREIGN KEY (FromUserId) REFERENCES UserInfo(Id),--表UserInfo中UserId的外键(发送者)
 IfPublish BIT NOT NULL,--是否已发布(1已发布0未发布)
 RecordTime DateTime NOT NULL--	发送时间
)
INSERT INTO Message(Title,Content,MessageTypeId,BeginTime,EndTime,FromUserId,IfPublish,RecordTime)
VALUES('关于记者证考试日程安排','请所有远程中心的老师抓紧到中蓝多功能厅召开临时会议。',
2,'2008-1-6 13:30:00','2008-12-16 17:30:00',1,1,'2007-12-12 13:19:42')
INSERT INTO Message(Title,Content,MessageTypeId,BeginTime,EndTime,FromUserId,IfPublish,RecordTime)
VALUES('关于公司年会合唱名单','请每个部门准备一个节目，部门人员参加数>60%，以戏剧为主。',
1,'2008-1-6 1:00:00','2008-12-18 12:00:59',8,1,'2007-12-13 9:21:08')
--SELECT * FROM Message
--------------------------------------------消息发送对象-----------------------------------------------
GO
CREATE TABLE MessageToUser
(
 Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,--序号Id
 MessageId INT NOT NULL FOREIGN KEY (MessageId) REFERENCES Message(Id),--Message表外键，对应MessageId字段(消息Id)
 ToUserId INT NOT NULL FOREIGN KEY (ToUserId) REFERENCES UserInfo(Id),--UserInfo表外键，对应UserId字段(发送对象Id)
 IfRead	BIT NOT NULL--(是否已读。1：已读、0：未读)
)
INSERT INTO MessageToUser(MessageId,ToUserId,IfRead)VALUES(1,8,1)
--SELECT * FROM MessageToUser
----------------------------------会议类型表----------------------------------------------------
GO
CREATE TABLE MeetingInfo
(
 Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,--会议类型Id
 MeetingName	Varchar(50) NOT NULL--会议类型名称
)
INSERT INTO MeetingInfo(MeetingName)VALUES('公司年会')
INSERT INTO MeetingInfo(MeetingName)VALUES('机构会议')
INSERT INTO MeetingInfo(MeetingName)VALUES('部门会议')
INSERT INTO MeetingInfo(MeetingName)VALUES('小组会议')
INSERT INTO MeetingInfo(MeetingName)VALUES('外部合作会议')
--SELECT * FROM MeetingInfo
-----------------------------------日程表---------------------------------------------------------
GO
CREATE TABLE Schedule
(
 Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,--日程Id
 Title	Varchar(50) NOT NULL,--日程标题
 Address Varchar(500) NOT NULL,--会议地址
 MeetingId INT NOT NULL FOREIGN KEY (MeetingId) REFERENCES MeetingInfo(Id),--MeetingInfo表外键，对应MeetingId字段(会议类型)
 BeginTime DateTime NOT NULL,--日程开始时间
 EndTime DateTime NOT NULL,--日程结束时间
 SchContent varchar(500) NOT NULL,--日程内容
 CreateUserId INT NOT NULL FOREIGN KEY (CreateUserId) REFERENCES UserInfo(Id),--UserInfo表外键，对应UserId字段(创建者)
 CreateTime DateTime NOT NULL,--创建时间
 IfPrivate BIT NOT NULL--是否私有(1私有)
)
INSERT INTO Schedule(Title,Address,MeetingId,BeginTime,EndTime,SchContent,CreateUserId,CreateTime,IfPrivate)
VALUES('今天下午要开一个部门月度工作总结会。','B03会议室',3,'2007-12-5 9:26:39'
,'2007-12-5 18:26:49','对12月份工作进行总结，安排下一个月的工作任务。',1,'2007-12-5 11:10:00',1)
--SELECT * FROM Schedule
---------------------------------------------------预约人表-----------------------------
GO
CREATE TABLE PreContract
(
 Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,--预约序号Id
 ScheduleId INT NOT NULL FOREIGN KEY (ScheduleId) REFERENCES Schedule(Id),--表Schedule外键，对应ScheduleId字段(日程Id)
 UserId	INT NOT NULL FOREIGN KEY (UserId) REFERENCES UserInfo(Id)--表UserInfo外键，对应UserId字段(预约人)
)
INSERT INTO PreContract(ScheduleId,UserId)VALUES(1,7)
--SELECT * FROM PreContract
---------------------------------------------------个人便签表----------------------------------
GO 
CREATE TABLE MyNote
(
 Id	INT IDENTITY(1,1) PRIMARY KEY NOT NULL,--便签id
 NoteTitle Varchar(50) NOT NULL,--便签标题
 NoteContent Varchar(500),--便签内容
 CreateTime datetime NOT NULL,--创建时间
 CreateUserId INT NOT NULL FOREIGN KEY (CreateUserId) REFERENCES UserInfo(Id)--UserInfo表外键，对应UserId字段(创建者)
)
INSERT INTO MyNote(NoteTitle,NoteContent,CreateTime,CreateUserId)
VALUES('个人工作','记录个人今天主要工作','2008-1-11 10:24:56',1)
--SELECT * FROM MyNote
--------------------------------------------------登录日志表-----------------------------------------
GO
CREATE TABLE LoginLog
(
 Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,--登录日志id
 UserId	INT NOT NULL FOREIGN KEY (UserId) REFERENCES UserInfo(Id),--UserInfo表外键，对应UserId字段(登录者)
 LoginTime DateTime NOT NULL,--登录时间
 IfSuccess bit NOT NULL,--登录是否成功。1：成功、0失败。
 LoginUserIp varchar(100) NOT NULL,--登录用户IP
 LoginDesc varchar(100)--登录备注 
)
INSERT INTO LoginLog(UserId,LoginTime,IfSuccess,LoginUserIp,LoginDesc)
VALUES(1,'2007-12-28 22:57:46',1,'192.168.2.90','用户登录成功')
INSERT INTO LoginLog(UserId,LoginTime,IfSuccess,LoginUserIp,LoginDesc)
VALUES(8,'2007-12-28 23:02:52',0,'192.168.2.90','用户登录失败，用户名或密码不正确。')
INSERT INTO LoginLog(UserId,LoginTime,IfSuccess,LoginUserIp,LoginDesc)
VALUES(1,'2008-1-16 10:49:42',1,'127.0.0.1','用户登录成功')
--SELECT * FROM LoginLog
---------------------------------------------------操作日志表------------------------------------------
GO
CREATE TABLE OperateLog
(
 Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,--操作日志ID
 UserId	INT NOT NULL FOREIGN KEY (UserId) REFERENCES UserInfo(Id),--UserInfo表外键，对应UserId字段(操作者)
 OperateName Varchar(50) NOT NULL,--操作名称
 OperateDesc Varchar(200) NOT NULL,--操作描述
 OperateTime DateTime NOT NULL,--操作时间
)
INSERT INTO OperateLog(UserId,OperateName,OperateDesc,OperateTime)
VALUES(1,'修改','修改用户','2008-1-11 16:49:44')
--SELECT * FROM OperateLog
GO
--------------------------在这加约束是因为UserInfo的一个外键是DepartInfo的Id（有先后顺序）
ALTER TABLE DepartInfo ADD CONSTRAINT FK_PrincipalUser  
     FOREIGN KEY (PrincipalUserId) REFERENCES UserInfo(Id)
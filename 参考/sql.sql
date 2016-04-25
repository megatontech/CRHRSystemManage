CREATE DATABASE MyOffice
GO
USE MyOffice
GO
---------------------״̬---------����չ�ԣ������û��Ƿ����ε�״̬------------------------------
CREATE TABLE UserState
(
 Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,--ID
 UserStateName Varchar(50) NOT NULL--1������״̬��0��������
)
INSERT INTO UserState(UserStateName)VALUES('������')
INSERT INTO UserState(UserStateName)VALUES('����״̬')
--SELECT * FROM UserState
GO
--------------------------------��Ž�ɫ������Ϣ------------------------------
CREATE TABLE RoleInfo
(
 RoleId INT IDENTITY(1,1) PRIMARY KEY NOT NULL,--��ɫid 
 RoleName Varchar(50) NOT NULL,--1����ɫ����
 RoleDesc Varchar(50) --��ɫ����
)
INSERT INTO RoleInfo(RoleName,RoleDesc)VALUES('δ�����û�','��û��ʹ�ø�ϵͳ��Ȩ�ޡ�')
INSERT INTO RoleInfo(RoleName,RoleDesc)VALUES('��ͨ�û�','һ���û�')
INSERT INTO RoleInfo(RoleName,RoleDesc)VALUES('ϵͳ����Ա','ӵ�б�ϵͳ��߹���Ȩ��')
INSERT INTO RoleInfo(RoleName,RoleDesc)VALUES('��˾����','ӵ����ߵļ��Ȩ')
INSERT INTO RoleInfo(RoleName,RoleDesc)VALUES('���ž���','��Ͻ��������ع���')
INSERT INTO RoleInfo(RoleName,RoleDesc)VALUES('��ʱ��ɫ','���Լ�����Ŀ')
--SELECT * FROM RoleInfo
GO
---------------------------------������Ϣ��------------------------------
CREATE TABLE BranchInfo
(
 Id  INT IDENTITY(1,1) PRIMARY KEY NOT NULL,---����id
 BranchName Varchar(50) NOT NULL,--��������
 BranchShortName Varchar(50) NOT NULL--�������
)
INSERT INTO BranchInfo (BranchName,BranchShortName)VALUES('����������ѧ�о�Ժ','����')
INSERT INTO BranchInfo (BranchName,BranchShortName)VALUES('�й���ѧԺ��ѧ�о���','�п����о���')
INSERT INTO BranchInfo (BranchName,BranchShortName)VALUES('����������','����')
INSERT INTO BranchInfo (BranchName,BranchShortName)VALUES('���ƹ�����ɽ�������޹�˾','�̵�')
--SELECT * FROM BranchInfo
GO
-------------------------------������Ϣ��------------------------------
CREATE TABLE DepartInfo
(
 Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,--����id
 DepartName Varchar(50) NOT NULL ,--��������
 PrincipalUserId INT NOT NULL ,--���Ÿ�����
 ConnectTelNo	varchar(20) ,--��ϵ�绰
 ConnectMobileTelNo char(11) ,--�ƶ��绰
 Faxes	varchar(20) ,--����
 BranchId INT NOT NULL FOREIGN KEY (BranchId) REFERENCES BranchInfo(Id)--��������
)
INSERT INTO DepartInfo(DepartName,PrincipalUserId,ConnectTelNo,ConnectMobileTelNo,Faxes,BranchId)
VALUES('���۲�',1,'62768866','13910255752','62768866',1)
INSERT INTO DepartInfo(DepartName,PrincipalUserId,ConnectTelNo,ConnectMobileTelNo,Faxes,BranchId)
VALUES('�з���',1,'62768866','13520319928','62768866',2)
INSERT INTO DepartInfo(DepartName,PrincipalUserId,ConnectTelNo,ConnectMobileTelNo,Faxes,BranchId)
VALUES('����',8,'62768866','13520319928','62768866',3)
INSERT INTO DepartInfo(DepartName,PrincipalUserId,ConnectTelNo,ConnectMobileTelNo,Faxes,BranchId)
VALUES('���粿',9,'62768866','13920319928','62768866',4)
INSERT INTO DepartInfo(DepartName,PrincipalUserId,ConnectTelNo,ConnectMobileTelNo,Faxes,BranchId)
VALUES('�ۺϲ�',2,'83258011','13910255752','82353695',3)
INSERT INTO DepartInfo(DepartName,PrincipalUserId,ConnectTelNo,ConnectMobileTelNo,Faxes,BranchId)
VALUES('��ѵ��',1,'62768866','13910255752','62768866',3)
--SELECT * FROM DepartInfo
GO
--------------------------------����û�������Ϣ------------------------------
CREATE TABLE UserInfo
(
 Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,--�û�Ψһ��ʶ
 LoginId Varchar(50) NOT NULL,--�û�Id
 UserName Varchar(50) NOT NULL,--��ʵ����
 PassWord Varchar(50) NOT NULL,--����
 DepartId INT NOT NULL FOREIGN KEY (DepartId) REFERENCES DepartInfo(Id),--��DepartInfoe���������ӦDepartId �ֶ�(���ڲ���)
 Gender	INT NOT NULL,--�Ա�
 RoleId	INT NOT NULL FOREIGN KEY (RoleId) REFERENCES RoleInfo(RoleId),--��RoleInfo���������ӦRoleId �ֶ�(�û���ɫ)
 UserStateId INT NOT NULL FOREIGN KEY (UserStateId) REFERENCES UserState(Id)--��UserState���������ӦUserStateId �ֶ�(�û�״̬)
)
INSERT INTO UserInfo(LoginId,UserName,PassWord,DepartId,Gender,RoleId,UserStateId)
VALUES('admin','ϵͳ����Ա','123',2,1,3,1)
INSERT INTO UserInfo(LoginId,UserName,PassWord,DepartId,Gender,RoleId,UserStateId)
VALUES('jiyaoqin','��ҫ��','123',4,1,2,1)
INSERT INTO UserInfo(LoginId,UserName,PassWord,DepartId,Gender,RoleId,UserStateId)
VALUES('leibeibei','���','666',1,0,2,1)
INSERT INTO UserInfo(LoginId,UserName,PassWord,DepartId,Gender,RoleId,UserStateId)
VALUES('liuguangping','����ƽ','123',5,1,2,1)
INSERT INTO UserInfo(LoginId,UserName,PassWord,DepartId,Gender,RoleId,UserStateId)
VALUES('qijingxue','�뾲ѩ','123',1,0,1,1)
INSERT INTO UserInfo(LoginId,UserName,PassWord,DepartId,Gender,RoleId,UserStateId)
VALUES('wangchao','����','123',6,1,2,1)
INSERT INTO UserInfo(LoginId,UserName,PassWord,DepartId,Gender,RoleId,UserStateId)
VALUES('wuliping','����ƽ','666',2,0,2,1)
INSERT INTO UserInfo(LoginId,UserName,PassWord,DepartId,Gender,RoleId,UserStateId)
VALUES('yangjiali','�����','666',1,0,2,1)
INSERT INTO UserInfo(LoginId,UserName,PassWord,DepartId,Gender,RoleId,UserStateId)
VALUES('yuanbin','Ԭ��','123',4,1,2,1)
--SELECT * FROM UserInfo
GO
-------------------------------------��Ų˵����ܻ�����Ϣ-------------------------------------------
CREATE TABLE SysFun
(
NodeId	INT  PRIMARY KEY NOT NULL,---�˵��ڵ�id
DisplayName Varchar(50) NOT NULL,---�˵�����
NodeURL	Varchar(50),---�˵����ӵ�ַ
DisplayOrder INT NOT NULL,----�˵���ʾ˳��
ParentNodeId INT NOT NULL---���ڵ�id
)
INSERT INTO SysFun(NodeId,DisplayName,DisplayOrder,ParentNodeId)
VALUES(101,'���¹���',1,0)
INSERT INTO SysFun(NodeId,DisplayName,DisplayOrder,ParentNodeId)
VALUES(102,'�ճ̹���',2,0)
INSERT INTO SysFun(NodeId,DisplayName,DisplayOrder,ParentNodeId)
VALUES(103,'�ĵ�����',3,0)
INSERT INTO SysFun(NodeId,DisplayName,DisplayOrder,ParentNodeId)
VALUES(104,'��Ϣ����',4,0)
INSERT INTO SysFun(NodeId,DisplayName,DisplayOrder,ParentNodeId)
VALUES(105,'ϵͳ����',5,0)
INSERT INTO SysFun(NodeId,DisplayName,DisplayOrder,ParentNodeId)
VALUES(106,'���ڹ���',6,0)
INSERT INTO SysFun(NodeId,DisplayName,NodeURL,DisplayOrder,ParentNodeId)
VALUES(101001,'������Ϣ','PersonManage/BranchManage.aspx',1,101)
INSERT INTO SysFun(NodeId,DisplayName,NodeURL,DisplayOrder,ParentNodeId)
VALUES(101002,'������Ϣ','PersonManage/DepartManage.aspx',2,101)
INSERT INTO SysFun(NodeId,DisplayName,NodeURL,DisplayOrder,ParentNodeId)
VALUES(101003,'Ա������','PersonManage/UserManage.aspx',3,101)
INSERT INTO SysFun(NodeId,DisplayName,NodeURL,DisplayOrder,ParentNodeId)
VALUES(102001,'�ҵ��ճ�','ScheduleManage/PersonSchedule/PersonSchedule.aspx',4,102)
INSERT INTO SysFun(NodeId,DisplayName,NodeURL,DisplayOrder,ParentNodeId)
VALUES(102002,'�����ճ�','ScheduleManage/DepartSchedule/DepartSchedule.aspx',5,102)
INSERT INTO SysFun(NodeId,DisplayName,NodeURL,DisplayOrder,ParentNodeId)
VALUES(102003,'�ҵı�ǩ','ScheduleManage/PersonNote/PersonNote.aspx',6,102)
INSERT INTO SysFun(NodeId,DisplayName,NodeURL,DisplayOrder,ParentNodeId)
VALUES(103001,'�ĵ�����','File/FileManage/FileManage.aspx',7,103)
INSERT INTO SysFun(NodeId,DisplayName,NodeURL,DisplayOrder,ParentNodeId)
VALUES(103002,'����վ','File/RecycleBin.aspx',8,103)
INSERT INTO SysFun(NodeId,DisplayName,NodeURL,DisplayOrder,ParentNodeId)
VALUES(103003,'�ļ�����','File/FileSearch.aspx',9,103)
INSERT INTO SysFun(NodeId,DisplayName,NodeURL,DisplayOrder,ParentNodeId)
VALUES(104001,'��Ϣ����','Message/MessageManage/MessageManage.aspx',10,104)
INSERT INTO SysFun(NodeId,DisplayName,NodeURL,DisplayOrder,ParentNodeId)
VALUES(104002,'����','Message/MailBox/MailBox.aspx',11,104)
INSERT INTO SysFun(NodeId,DisplayName,NodeURL,DisplayOrder,ParentNodeId)
VALUES(105001,'��ɫ����','SysManage/RoleManage/RoleManage.aspx',12,105)
INSERT INTO SysFun(NodeId,DisplayName,NodeURL,DisplayOrder,ParentNodeId)
VALUES(105002,'��¼��־','SysManage/LoginLog.aspx',13,105)
INSERT INTO SysFun(NodeId,DisplayName,NodeURL,DisplayOrder,ParentNodeId)
VALUES(105003,'������־','SysManage/OperateLog.aspx',14,105)
INSERT INTO SysFun(NodeId,DisplayName,NodeURL,DisplayOrder,ParentNodeId)
VALUES(105004,'�˵�����','SysManage/MenuAdjust.aspx',15,105)
INSERT INTO SysFun(NodeId,DisplayName,NodeURL,DisplayOrder,ParentNodeId)
VALUES(106001,'Ա��ǩ����ǩ��','ManualSign/ManualSign.aspx',16,106)
INSERT INTO SysFun(NodeId,DisplayName,NodeURL,DisplayOrder,ParentNodeId)
VALUES(106002,'������ʷ��ѯ','ManualSign/ManualSignSearch.aspx',17,106)
INSERT INTO SysFun(NodeId,DisplayName,NodeURL,DisplayOrder,ParentNodeId)
VALUES(106003,'����ͳ��','ManualSign/SignStatistic.aspxx',18,106)
---SELECT * FROM SysFun
GO
---------------------------------------������н�ɫȨ��--------------------------------------------
CREATE TABLE RoleRight
(
 Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
 RoleId	INT NOT NULL FOREIGN KEY (RoleId) REFERENCES RoleInfo(RoleId),--��RoleInfo���������ӦRoleId(��ɫid)
 NodeId	INT NOT NULL FOREIGN KEY (NodeId) REFERENCES SysFun(NodeId)--��SysFun���������ӦNodeId(�˵��ڵ�id)
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
----------------------------------------�ļ����ͱ�-----------------------------------------
CREATE TABLE FileTypeInfo
(
 Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,--�ļ�����id
 FileTypeName	Varchar(50) NOT NULL,--�ļ�������
 FileTypeImage	Varchar(50) NOT NULL,--�ļ����Ͷ�Ӧ��ͼ��
 FileTypeSuffix	Varchar(50)--�ļ����ͺ�׺
)
INSERT INTO FileTypeInfo(FileTypeName,FileTypeImage,FileTypeSuffix)
VALUES('�ļ���','../../images/file/folder.gif','0')
INSERT INTO FileTypeInfo(FileTypeName,FileTypeImage,FileTypeSuffix)
VALUES('�����ļ�','../../images/file/other.gif','noname')
INSERT INTO FileTypeInfo(FileTypeName,FileTypeImage,FileTypeSuffix)
VALUES('Word�ĵ�','../../images/file/word.gif','doc')
INSERT INTO FileTypeInfo(FileTypeName,FileTypeImage,FileTypeSuffix)
VALUES('Excel�ĵ�','../../images/file/excel.gif','xls')
INSERT INTO FileTypeInfo(FileTypeName,FileTypeImage,FileTypeSuffix)
VALUES('PowerPoint��ʾ�ĵ�','../../images/file/ppt.gif','ppt')
INSERT INTO FileTypeInfo(FileTypeName,FileTypeImage,FileTypeSuffix)
VALUES('Access�ĵ�','../../images/file/access.gif','mdb')
INSERT INTO FileTypeInfo(FileTypeName,FileTypeImage,FileTypeSuffix)
VALUES('���ı��ĵ�','../../images/file/html.gif','htm')
INSERT INTO FileTypeInfo(FileTypeName,FileTypeImage,FileTypeSuffix)
VALUES('ͼƬ�ĵ�','../../images/file/bmp.gif','gif')
INSERT INTO FileTypeInfo(FileTypeName,FileTypeImage,FileTypeSuffix)
VALUES('ѹ���ĵ�','../../images/file/zip.gif','rar')
INSERT INTO FileTypeInfo(FileTypeName,FileTypeImage,FileTypeSuffix)
VALUES('�ı��ĵ�','../../images/file/note1.gif','txt')
INSERT INTO FileTypeInfo(FileTypeName,FileTypeImage,FileTypeSuffix)
VALUES('��ý���ĵ�','../../images/file/media.gif','avi')
INSERT INTO FileTypeInfo(FileTypeName,FileTypeImage,FileTypeSuffix)
VALUES('Acrobat�ĵ�','../../images/file/pdf.gif','pdf')
INSERT INTO FileTypeInfo(FileTypeName,FileTypeImage,FileTypeSuffix)
VALUES('��ִ���ļ�','../../images/file/exe.gif','exe')
--SELECT * FROM FileTypeInfo
GO
---------------------------------------�ļ���Ϣ��-----------------------------------------------
CREATE TABLE FileInfo
(
 Id	INT IDENTITY(1,1) PRIMARY KEY NOT NULL,--�ļ�Id
 FileName Varchar(50) NOT NULL,--�ļ�����
 FileTypeId int NOT NULL FOREIGN KEY (FileTypeId) REFERENCES FileTypeInfo(Id),--FileTypeInfo����������ӦFileTypeId�ֶ�(�ļ�����)
 Remark	Varchar(50),--��ע
 FileOwnerId int NOT NULL FOREIGN KEY (FileOwnerId) REFERENCES UserInfo(Id),--��UserInfo�������ӦUserId�ֶ�(������)
 CreateDate DateTime NOT NULL,--��������
 ParentId INT NOT NULL,--���ڵ�Id
 FilePath Varchar(200) NOT NULL,--�ļ�·��
 IfDelete BIT NOT NULL--�Ƿ���ɾ����1����ɾ����2��δɾ��
)
INSERT INTO FileInfo(FileName,FileTypeId,Remark,FileOwnerId,CreateDate,ParentId,FilePath,IfDelete)
VALUES('�����ĵ�',1,'������ϵͳ������˵��',1,'2007-12-12 11:00:00',0,'c:\\�����ĵ�',0)
INSERT INTO FileInfo(FileName,FileTypeId,Remark,FileOwnerId,CreateDate,ParentId,FilePath,IfDelete)
VALUES('�����ƶ�',1,'��˾����������淶',2,'2007-12-16 12:00:00',0,'c:\\�����ƶ�',0)
INSERT INTO FileInfo(FileName,FileTypeId,Remark,FileOwnerId,CreateDate,ParentId,FilePath,IfDelete)
VALUES('�����ĵ�',1,'�����ŵ��ļ�����',1,'2007-12-16 9:00:00',0,'c:\\�����ĵ�',0)
INSERT INTO FileInfo(FileName,FileTypeId,Remark,FileOwnerId,CreateDate,ParentId,FilePath,IfDelete)
VALUES('�з���',1,'�з����������',8,'2007-12-16 19:00:00',4,'c:\\�����ĵ�\�з���',0)
INSERT INTO FileInfo(FileName,FileTypeId,Remark,FileOwnerId,CreateDate,ParentId,FilePath,IfDelete)
VALUES('����Ա������',1,'���������з���Ա���Ļ�����Ϣ��',1,'2007-12-21 11:06:01',5,'c:\\�����ĵ�\�з���\����Ա������',0)
INSERT INTO FileInfo(FileName,FileTypeId,Remark,FileOwnerId,CreateDate,ParentId,FilePath,IfDelete)
VALUES('������Ŀ',1,'���п��õ���Ŀ���ܡ�',1,'2007-12-21 11:06:38',5,'c:\\�����ĵ�\�з���\������Ŀ',0)
INSERT INTO FileInfo(FileName,FileTypeId,Remark,FileOwnerId,CreateDate,ParentId,FilePath,IfDelete)
VALUES('ACCPԱ����������',3,'��Ҫ�鿴��ϸ������ϵ����Ա��',1,'2007-12-21 11:07:40',19,'c:\\�����ĵ�\�з���\����Ա������\ACCPԱ����������',0)
INSERT INTO FileInfo(FileName,FileTypeId,Remark,FileOwnerId,CreateDate,ParentId,FilePath,IfDelete)
VALUES('MyOffice',1,'bishexiangmu',1,'2007-12-22 11:19:34',20,'c:\\�����ĵ�\�з���\������Ŀ\MyOffice',1)
INSERT INTO FileInfo(FileName,FileTypeId,Remark,FileOwnerId,CreateDate,ParentId,FilePath,IfDelete)
VALUES('��Ϸ�㿨����ϵͳ',1,'��ҵ�����Ŀ',1,'2007-12-22 11:19:57',20,'c:\\�����ĵ�\�з���\������Ŀ\��Ϸ�㿨����ϵͳ',0)
INSERT INTO FileInfo(FileName,FileTypeId,Remark,FileOwnerId,CreateDate,ParentId,FilePath,IfDelete)
VALUES('MyOffice˵���ĵ�',3,'˵���ĵ�',1,'2007-12-22 11:28:49',31,'c:\\�����ĵ�\�з���\������Ŀ\MyOffice\MyOffice˵���ĵ�',0)
INSERT INTO FileInfo(FileName,FileTypeId,Remark,FileOwnerId,CreateDate,ParentId,FilePath,IfDelete)
VALUES('��Ϸ�㿨����ϵͳ˵����',3,'˵����',1,'2007-12-22 11:29:18',32,'c:\\�����ĵ�\�з���\������Ŀ\��Ϸ�㿨����ϵͳ\��Ϸ�㿨����ϵͳ˵����',0)
INSERT INTO FileInfo(FileName,FileTypeId,Remark,FileOwnerId,CreateDate,ParentId,FilePath,IfDelete)
VALUES('Java��Ŀ',1,'Java��ҵ�����Ŀ',1,'2007-12-22 11:33:35',20,'c:\\�����ĵ�\�з���\������Ŀ\Java��Ŀ',0)
INSERT INTO FileInfo(FileName,FileTypeId,Remark,FileOwnerId,CreateDate,ParentId,FilePath,IfDelete)
VALUES('ACCP5.0��Ʒ����',1,'���м��������Ĳ�Ʒ',1,'2007-12-31 22:30:34',5,'c:\\�����ĵ�\�з���\ACCP5.0��Ʒ����',0)
--SELECT * FROM FileInfo
GO
------------------------------------�����ļ���-------------------------------------------------------
CREATE TABLE AccessoryFile
(
 Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,--�ļ�����Id
 FileId	INT NOT NULL FOREIGN KEY (FileId) REFERENCES FileInfo(Id),--��FileInfo���������ӦFileId �ֶ� (�ļ�Id)
 AccessoryName	Varchar(50) NOT NULL,--��������
 AccessorySize	INT NOT NULL,--������С
 AccessoryTypeId INT NOT NULL FOREIGN KEY (AccessoryTypeId) REFERENCES FileTypeInfo(Id),--(FileTypeInfo����������ӦFileTypeId�ֶ�)��������
 CreateDate	DateTime NOT NULL,--��������
 AccessoryPath	Varchar(200) NOT NULL--����·��
)
INSERT INTO AccessoryFile(FileId,AccessoryName,AccessorySize,AccessoryTypeId,CreateDate,AccessoryPath)
VALUES(10,'MyOffice��Ŀ˵��',24064,3,'2007-12-22 11:28:49','c:\\�����ĵ�\�з���\������Ŀ\MyOffice\MyOffice˵���ĵ�\MyOffice��Ŀ˵��.doc')
--SELECT * FROM AccessoryFile
GO
------------------------------������Ϣ��--------------------------------------------------------------
CREATE TABLE ManualSign
(
 Id	INT IDENTITY(1,1) PRIMARY KEY NOT NULL,--ǩ��Id
 UserId	INT NOT NULL FOREIGN KEY (UserId) REFERENCES UserInfo(Id),--��UserInfo��UserId�����(�û�id)
 SignTime DateTime NOT NULL,--ǩ��ʱ��
 SignDesc Varchar(200) NOT NULL,--ǩ����ע
 SignTag INT NOT NULL--ǩ�����
)
INSERT INTO ManualSign(UserId,SignTime,SignDesc,SignTag)VALUES(2,'2007-12-6 7:36:14','����һ��',1)
INSERT INTO ManualSign(UserId,SignTime,SignDesc,SignTag)VALUES(2,'2007-12-6 10:36:29','����һ��',0)
INSERT INTO ManualSign(UserId,SignTime,SignDesc,SignTag)VALUES(8,'2007-12-6 8:56:22','���籨��',1)
INSERT INTO ManualSign(UserId,SignTime,SignDesc,SignTag)VALUES(4,'2007-12-6 8:03:20','ǩ������.',1)
INSERT INTO ManualSign(UserId,SignTime,SignDesc,SignTag)VALUES(4,'2007-12-6 17:03:34','ǩ�˲���.',0)
INSERT INTO ManualSign(UserId,SignTime,SignDesc,SignTag)VALUES(6,'2007-12-6 17:40:00','���ǲ������ܡ�',1)
INSERT INTO ManualSign(UserId,SignTime,SignDesc,SignTag)VALUES(6,'2007-12-6 17:40:58','����Ա��������ǰ�ؼҡ�',0)
INSERT INTO ManualSign(UserId,SignTime,SignDesc,SignTag)VALUES(1,'2007-12-7 9:40:58','haha',1)
INSERT INTO ManualSign(UserId,SignTime,SignDesc,SignTag)VALUES(1,'2007-12-7 15:30:58','heihei',0)
INSERT INTO ManualSign(UserId,SignTime,SignDesc,SignTag)VALUES(8,'2007-12-7 8:20:58','haha',1)
INSERT INTO ManualSign(UserId,SignTime,SignDesc,SignTag)VALUES(8,'2007-12-7 15:40:58','heihei',0)
INSERT INTO ManualSign(UserId,SignTime,SignDesc,SignTag)VALUES(1,'2008-1-16 8:52:19','����Ա����һ�¡�',1)
INSERT INTO ManualSign(UserId,SignTime,SignDesc,SignTag)VALUES(1,'2008-1-16 9:06:43','����Ա��ݲ���ǩ�˲�����',0)
--SELECT * FROM ManualSign
------------------------------------------���°�ʱ���--------------------------------------------------
GO
CREATE TABLE WorkTime
(
 Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,--����ʱ��ID
 OnDutyTime DateTime NOT NULL,--�ϰ�ʱ��
 OffDutyTime DateTime NOT NULL --�°�ʱ��
)
INSERT INTO WorkTime(OnDutyTime,OffDutyTime)VALUES('8:30:00','17:30:00')
--SELECT * FROM WorkTime
GO
-----------------------------------��Ϣ���ͱ�--------------------------------------------------
CREATE TABLE MessageType
(
 Id	INT IDENTITY(1,1) PRIMARY KEY NOT NULL,--��Ϣ����Id
 MessageTypeName Varchar(50) NOT NULL,--��Ϣ��������
 MessageDesc Varchar(50)--��Ϣ��������
)
INSERT INTO MessageType(MessageTypeName)VALUES('һ����Ϣ')
INSERT INTO MessageType(MessageTypeName,MessageDesc)VALUES('������Ϣ','�ǳ���Ҫ����Ϣ����Ҫ�����Ķ�')
--SELECT * FROM MessageType
GO
--------------------------------------��Ϣ��-----------------------------------------------------
CREATE TABLE Message
(
 Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,--	��ϢId
 Title	Varchar(100) NOT NULL,--��Ϣ����
 Content Varchar(5000) NOT NULL,--	��Ϣ����
 MessageTypeId	INT NOT NULL FOREIGN KEY (MessageTypeId) REFERENCES MessageType(Id),--��MessageType��MessageTypeId���������Ϣ���ͣ�
 BeginTime DateTime NOT NULL,--	��ʼ��Чʱ��
 EndTime DateTime NOT NULL,--	��Ч����ʱ��
 FromUserId INT NOT NULL FOREIGN KEY (FromUserId) REFERENCES UserInfo(Id),--��UserInfo��UserId�����(������)
 IfPublish BIT NOT NULL,--�Ƿ��ѷ���(1�ѷ���0δ����)
 RecordTime DateTime NOT NULL--	����ʱ��
)
INSERT INTO Message(Title,Content,MessageTypeId,BeginTime,EndTime,FromUserId,IfPublish,RecordTime)
VALUES('���ڼ���֤�����ճ̰���','������Զ�����ĵ���ʦץ���������๦�����ٿ���ʱ���顣',
2,'2008-1-6 13:30:00','2008-12-16 17:30:00',1,1,'2007-12-12 13:19:42')
INSERT INTO Message(Title,Content,MessageTypeId,BeginTime,EndTime,FromUserId,IfPublish,RecordTime)
VALUES('���ڹ�˾���ϳ�����','��ÿ������׼��һ����Ŀ��������Ա�μ���>60%����Ϸ��Ϊ����',
1,'2008-1-6 1:00:00','2008-12-18 12:00:59',8,1,'2007-12-13 9:21:08')
--SELECT * FROM Message
--------------------------------------------��Ϣ���Ͷ���-----------------------------------------------
GO
CREATE TABLE MessageToUser
(
 Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,--���Id
 MessageId INT NOT NULL FOREIGN KEY (MessageId) REFERENCES Message(Id),--Message���������ӦMessageId�ֶ�(��ϢId)
 ToUserId INT NOT NULL FOREIGN KEY (ToUserId) REFERENCES UserInfo(Id),--UserInfo���������ӦUserId�ֶ�(���Ͷ���Id)
 IfRead	BIT NOT NULL--(�Ƿ��Ѷ���1���Ѷ���0��δ��)
)
INSERT INTO MessageToUser(MessageId,ToUserId,IfRead)VALUES(1,8,1)
--SELECT * FROM MessageToUser
----------------------------------�������ͱ�----------------------------------------------------
GO
CREATE TABLE MeetingInfo
(
 Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,--��������Id
 MeetingName	Varchar(50) NOT NULL--������������
)
INSERT INTO MeetingInfo(MeetingName)VALUES('��˾���')
INSERT INTO MeetingInfo(MeetingName)VALUES('��������')
INSERT INTO MeetingInfo(MeetingName)VALUES('���Ż���')
INSERT INTO MeetingInfo(MeetingName)VALUES('С�����')
INSERT INTO MeetingInfo(MeetingName)VALUES('�ⲿ��������')
--SELECT * FROM MeetingInfo
-----------------------------------�ճ̱�---------------------------------------------------------
GO
CREATE TABLE Schedule
(
 Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,--�ճ�Id
 Title	Varchar(50) NOT NULL,--�ճ̱���
 Address Varchar(500) NOT NULL,--�����ַ
 MeetingId INT NOT NULL FOREIGN KEY (MeetingId) REFERENCES MeetingInfo(Id),--MeetingInfo���������ӦMeetingId�ֶ�(��������)
 BeginTime DateTime NOT NULL,--�ճ̿�ʼʱ��
 EndTime DateTime NOT NULL,--�ճ̽���ʱ��
 SchContent varchar(500) NOT NULL,--�ճ�����
 CreateUserId INT NOT NULL FOREIGN KEY (CreateUserId) REFERENCES UserInfo(Id),--UserInfo���������ӦUserId�ֶ�(������)
 CreateTime DateTime NOT NULL,--����ʱ��
 IfPrivate BIT NOT NULL--�Ƿ�˽��(1˽��)
)
INSERT INTO Schedule(Title,Address,MeetingId,BeginTime,EndTime,SchContent,CreateUserId,CreateTime,IfPrivate)
VALUES('��������Ҫ��һ�������¶ȹ����ܽ�ᡣ','B03������',3,'2007-12-5 9:26:39'
,'2007-12-5 18:26:49','��12�·ݹ��������ܽᣬ������һ���µĹ�������',1,'2007-12-5 11:10:00',1)
--SELECT * FROM Schedule
---------------------------------------------------ԤԼ�˱�-----------------------------
GO
CREATE TABLE PreContract
(
 Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,--ԤԼ���Id
 ScheduleId INT NOT NULL FOREIGN KEY (ScheduleId) REFERENCES Schedule(Id),--��Schedule�������ӦScheduleId�ֶ�(�ճ�Id)
 UserId	INT NOT NULL FOREIGN KEY (UserId) REFERENCES UserInfo(Id)--��UserInfo�������ӦUserId�ֶ�(ԤԼ��)
)
INSERT INTO PreContract(ScheduleId,UserId)VALUES(1,7)
--SELECT * FROM PreContract
---------------------------------------------------���˱�ǩ��----------------------------------
GO 
CREATE TABLE MyNote
(
 Id	INT IDENTITY(1,1) PRIMARY KEY NOT NULL,--��ǩid
 NoteTitle Varchar(50) NOT NULL,--��ǩ����
 NoteContent Varchar(500),--��ǩ����
 CreateTime datetime NOT NULL,--����ʱ��
 CreateUserId INT NOT NULL FOREIGN KEY (CreateUserId) REFERENCES UserInfo(Id)--UserInfo���������ӦUserId�ֶ�(������)
)
INSERT INTO MyNote(NoteTitle,NoteContent,CreateTime,CreateUserId)
VALUES('���˹���','��¼���˽�����Ҫ����','2008-1-11 10:24:56',1)
--SELECT * FROM MyNote
--------------------------------------------------��¼��־��-----------------------------------------
GO
CREATE TABLE LoginLog
(
 Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,--��¼��־id
 UserId	INT NOT NULL FOREIGN KEY (UserId) REFERENCES UserInfo(Id),--UserInfo���������ӦUserId�ֶ�(��¼��)
 LoginTime DateTime NOT NULL,--��¼ʱ��
 IfSuccess bit NOT NULL,--��¼�Ƿ�ɹ���1���ɹ���0ʧ�ܡ�
 LoginUserIp varchar(100) NOT NULL,--��¼�û�IP
 LoginDesc varchar(100)--��¼��ע 
)
INSERT INTO LoginLog(UserId,LoginTime,IfSuccess,LoginUserIp,LoginDesc)
VALUES(1,'2007-12-28 22:57:46',1,'192.168.2.90','�û���¼�ɹ�')
INSERT INTO LoginLog(UserId,LoginTime,IfSuccess,LoginUserIp,LoginDesc)
VALUES(8,'2007-12-28 23:02:52',0,'192.168.2.90','�û���¼ʧ�ܣ��û��������벻��ȷ��')
INSERT INTO LoginLog(UserId,LoginTime,IfSuccess,LoginUserIp,LoginDesc)
VALUES(1,'2008-1-16 10:49:42',1,'127.0.0.1','�û���¼�ɹ�')
--SELECT * FROM LoginLog
---------------------------------------------------������־��------------------------------------------
GO
CREATE TABLE OperateLog
(
 Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,--������־ID
 UserId	INT NOT NULL FOREIGN KEY (UserId) REFERENCES UserInfo(Id),--UserInfo���������ӦUserId�ֶ�(������)
 OperateName Varchar(50) NOT NULL,--��������
 OperateDesc Varchar(200) NOT NULL,--��������
 OperateTime DateTime NOT NULL,--����ʱ��
)
INSERT INTO OperateLog(UserId,OperateName,OperateDesc,OperateTime)
VALUES(1,'�޸�','�޸��û�','2008-1-11 16:49:44')
--SELECT * FROM OperateLog
GO
--------------------------�����Լ������ΪUserInfo��һ�������DepartInfo��Id�����Ⱥ�˳��
ALTER TABLE DepartInfo ADD CONSTRAINT FK_PrincipalUser  
     FOREIGN KEY (PrincipalUserId) REFERENCES UserInfo(Id)
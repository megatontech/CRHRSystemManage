/************************************************************************************
 *      Copyright (C) 2008 supesoft.com,All Rights Reserved						    *
 *      File:																		*
 *				sys_OnlineTable.cs                               		        	*
 *      Description:																*
 *				 在线人员实体类           	           							    *
 *      Author:																		*
 *				Lzppcc														        *
 *				Lzppcc@hotmail.com													*
 *				http://www.supesoft.com												*
 *      Finish DateTime:															*
 *				2007年8月6日														*
 *      History:																	*
 ***********************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameWork.Components
{
    /// <summary>
    /// 在线人员实体类
    /// </summary>
    public class sys_OnlineTable
    {

        #region "Private Variables"
        private string _DB_Option_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除 
        private int _OnlineID = 0;  // 在线ID号
        private int _O_UserID = 0;  // 用户ID号
        private string _O_SessionID; //浏览器唯一号
        private string _O_CName;  // 用户名
        private string _O_IP; //客户端IP地址
        private DateTime _O_LoginTime; // 登陆时间
        private DateTime _O_LastTime; // 最后登陆时间
        private int _O_IsAdmin = 0;  // 是否为管理员1:是0:否
        private int _O_State = 0;  // 当前状态1:正常 0:被踢下线
        private string _O_LookUrl; //访问Url地址
        private int _O_ApplicationID = 0;  // 所属应用程序ID与sys_Applicatio
        private string _O_A_AppName;  // 所属应用名称
        #endregion

        #region "Public Variables"
        /// <summary>
        /// 操作方法 Insert:增加 Update:修改 Delete:删除 
        /// </summary>
        public string DB_Option_Action_
        {
            set { this._DB_Option_Action_ = value; }
            get { return this._DB_Option_Action_; }
        }

        /// <summary>
        /// 在线ID号
        /// </summary>
        public int OnlineID
        {
            set { this._OnlineID = value; }
            get { return this._OnlineID; }
        }

        /// <summary>
        /// 用户ID号
        /// </summary>
        public int O_UserID
        {
            set { this._O_UserID = value; }
            get { return this._O_UserID; }
        }

        /// <summary>
        /// 浏览器唯一号
        /// </summary>
        public string O_SessionID
        {
            set { this._O_SessionID = value; }
            get { return this._O_SessionID; }
        }

        /// <summary>
        /// 用户名
        /// </summary>
        public string O_CName
        {
            set { this._O_CName = value; }
            get { return this._O_CName; }
        }

        /// <summary>
        /// 客户端IP地址
        /// </summary>
        public string O_IP
        {
            set { this._O_IP = value; }
            get { return this._O_IP; }
        }

        /// <summary>
        /// 登陆时间
        /// </summary>
        public DateTime O_LoginTime
        {
            set { this._O_LoginTime = value; }
            get { return this._O_LoginTime; }
        }

        /// <summary>
        /// 最后登陆时间
        /// </summary>
        public DateTime O_LastTime
        {
            set { this._O_LastTime = value; }
            get { return this._O_LastTime; }
        }

        /// <summary>
        /// 是否为管理员1:是0:否
        /// </summary>
        public int O_IsAdmin
        {
            set { this._O_IsAdmin = value; }
            get { return this._O_IsAdmin; }
        }

        /// <summary>
        /// 当前状态1:正常 0:被踢下线
        /// </summary>
        public int O_State
        {
            set { this._O_State = value; }
            get { return this._O_State; }
        }

        /// <summary>
        /// 访问Url地址
        /// </summary>
        public string O_LookUrl
        {
            set { this._O_LookUrl = value; }
            get { return this._O_LookUrl; }
        }

        /// <summary>
        /// 所属应用程序ID与sys_Applicatio
        /// </summary>
        public int O_ApplicationID
        {
            set { this._O_ApplicationID = value; }
            get { return this._O_ApplicationID; }
        }

        /// <summary>
        /// 所属应用名称
        /// </summary>
        public string O_A_AppName
        {
            set { this._O_A_AppName = value; }
            get { return this._O_A_AppName; }
        }

        #endregion
	
	
    }
}

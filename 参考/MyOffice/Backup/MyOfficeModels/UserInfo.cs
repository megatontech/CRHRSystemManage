using System;
using System.Collections.Generic;
using System.Text;

namespace MyOffice.Models
{
    //用户信息类
    [Serializable]
    public class UserInfo
    {
        private int id;//用户唯一标识
        private string loginId;//登录ID
        private string userName;//用户真实姓名
        private string password;//登录密码
        private DepartInfo depart;//部门,表DepartInfo的外键
        private int gender;//性别
        private RoleInfo role;//用户角色,表RoleInfo的外键
        private UserState userState;//用户状态,表UserState的外键

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string LoginId
        {
            get { return loginId; }
            set { loginId = value; }
        }
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public DepartInfo Depart
        {
            get { return depart; }
            set { depart = value; }
        }
        public int Gender
        {
            get { return gender; }
            set { gender = value; }
        }
        public RoleInfo Role
        {
            get { return role; }
            set { role = value; }
        }
        public UserState UserState
        {
            get { return userState; }
            set { userState = value; }
        }
    }
}

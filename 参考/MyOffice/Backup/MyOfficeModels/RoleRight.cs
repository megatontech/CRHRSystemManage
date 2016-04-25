using System;
using System.Collections.Generic;
using System.Text;

namespace MyOffice.Models
{
    //角色权限类
    [Serializable]
    public class RoleRight 
    {
        private int id;//角色权限
        private RoleInfo role;//角色基本信息,表RoleInfo的外键
        private SysFun node;//菜单节点,表SysFun的外键

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public RoleInfo Role
        {
            get { return role; }
            set { role = value; }
        }
        public SysFun Node
        {
            get { return node; }
            set { node = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace MyOffice.Models
{
    /// <summary>
    /// 用户角色
    /// </summary>
    [Serializable]
   public class RoleInfo
    {
        private int id;//角色id 
        private string roleName;//角色名称
        private string roleDesc;//角色描述

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string RoleName
        {
            get { return roleName; }
            set { roleName = value; }
        }
        public string RoleDesc
        {
            get { return roleDesc; }
            set { roleDesc = value; }
        }
    }
}

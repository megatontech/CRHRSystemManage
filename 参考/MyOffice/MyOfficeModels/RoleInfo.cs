using System;
using System.Collections.Generic;
using System.Text;

namespace MyOffice.Models
{
    /// <summary>
    /// �û���ɫ
    /// </summary>
    [Serializable]
   public class RoleInfo
    {
        private int id;//��ɫid 
        private string roleName;//��ɫ����
        private string roleDesc;//��ɫ����

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

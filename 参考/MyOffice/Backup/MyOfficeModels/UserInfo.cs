using System;
using System.Collections.Generic;
using System.Text;

namespace MyOffice.Models
{
    //�û���Ϣ��
    [Serializable]
    public class UserInfo
    {
        private int id;//�û�Ψһ��ʶ
        private string loginId;//��¼ID
        private string userName;//�û���ʵ����
        private string password;//��¼����
        private DepartInfo depart;//����,��DepartInfo�����
        private int gender;//�Ա�
        private RoleInfo role;//�û���ɫ,��RoleInfo�����
        private UserState userState;//�û�״̬,��UserState�����

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

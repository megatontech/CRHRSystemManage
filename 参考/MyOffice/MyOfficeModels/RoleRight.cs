using System;
using System.Collections.Generic;
using System.Text;

namespace MyOffice.Models
{
    //��ɫȨ����
    [Serializable]
    public class RoleRight 
    {
        private int id;//��ɫȨ��
        private RoleInfo role;//��ɫ������Ϣ,��RoleInfo�����
        private SysFun node;//�˵��ڵ�,��SysFun�����

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

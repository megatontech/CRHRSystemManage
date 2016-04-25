using System;
using System.Collections.Generic;
using System.Text;

namespace MyOffice.Models
{
    /// <summary>
    /// ��־
    /// </summary>
    [Serializable]
    public class OperateLog
    {
        private int id;//������־Id
        private UserInfo user;//������
        private string operateName;//��������
        private string operateDesc;//��������
        private DateTime operateTime;//����ʱ��

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public UserInfo User
        {
            get { return user; }
            set { user = value; }
        }
        public string OperateName
        {
            get { return operateName; }
            set { operateName = value; }
        }
        public string OperateDesc
        {
            get { return operateDesc; }
            set { operateDesc = value; }
        }
        public DateTime OperateTime
        {
            get { return operateTime; }
            set { operateTime = value; }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace MyOffice.Models
{
    [Serializable()]
    public class LoginLog//��¼��־
    {
        private int id; //PK��¼��־id
        private UserInfo user; //FK��¼��
        private DateTime loginTime;//��¼ʱ��
        private int ifSuccess;//��¼�Ƿ�ɹ���1���ɹ���0ʧ�ܡ�
        private string loginUserIp = String.Empty;//��¼�û�IP
        private string loginDesc = String.Empty;//��¼��ע

        public LoginLog() { }

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public UserInfo User
        {
            get { return this.user; }
            set { this.user = value; }
        }

        public DateTime LoginTime
        {
            get { return this.loginTime; }
            set { this.loginTime = value; }
        }

        public int IfSuccess
        {
            get { return this.ifSuccess; }
            set { this.ifSuccess = value; }
        }

        public string LoginUserIp
        {
            get { return this.loginUserIp; }
            set { this.loginUserIp = value; }
        }

        public string LoginDesc
        {
            get { return this.loginDesc; }
            set { this.loginDesc = value; }
        }
    }
}
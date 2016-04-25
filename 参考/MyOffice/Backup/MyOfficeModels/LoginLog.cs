using System;
using System.Collections.Generic;
using System.Text;

namespace MyOffice.Models
{
    [Serializable()]
    public class LoginLog//登录日志
    {
        private int id; //PK登录日志id
        private UserInfo user; //FK登录者
        private DateTime loginTime;//登录时间
        private int ifSuccess;//登录是否成功。1：成功、0失败。
        private string loginUserIp = String.Empty;//登录用户IP
        private string loginDesc = String.Empty;//登录备注

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
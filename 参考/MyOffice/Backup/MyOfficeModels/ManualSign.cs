using System;
using System.Collections.Generic;
using System.Text;

namespace MyOffice.Models
{
    [Serializable()]
    public class ManualSign//考勤信息
    {
        private int id; //PK签卡Id
        private UserInfo user; //FK用户id
        private DateTime signTime;//签卡时间
        private string signDesc = String.Empty;//签卡备注
        private int signTag;//签卡标记

        public ManualSign() { }

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

        public DateTime SignTime
        {
            get { return this.signTime; }
            set { this.signTime = value; }
        }

        public string SignDesc
        {
            get { return this.signDesc; }
            set { this.signDesc = value; }
        }

        public int SignTag
        {
            get { return this.signTag; }
            set { this.signTag = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace MyOffice.Models
{
    /// <summary>
    /// 日志
    /// </summary>
    [Serializable]
    public class OperateLog
    {
        private int id;//操作日志Id
        private UserInfo user;//操作者
        private string operateName;//操作名称
        private string operateDesc;//操作描述
        private DateTime operateTime;//操作时间

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

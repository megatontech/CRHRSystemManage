using System;
using System.Collections.Generic;
using System.Text;

namespace MyOffice.Models
{
    /// <summary>
    /// 预约
    /// </summary>
    [Serializable]
   public class PreContract
    {
        private int id;//预约序号Id
        private Schedule schedule;//日程Id
        private UserInfo user;//预约人

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public Schedule Schedule
        {
            get { return schedule; }
            set { schedule = value; }
        }
        public UserInfo User
        {
            get { return user; }
            set { user = value; }
        }
    }
}

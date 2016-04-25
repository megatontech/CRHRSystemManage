using System;
using System.Collections.Generic;
using System.Text;

namespace MyOffice.Models
{
    //工作时间类
    [Serializable]
    public class WorkTime
    {
        private int id;//工作时间ID
        private string onDutyTime;//上班时间
        private string offDutyTime;//下班时间

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string OnDutyTime
        {
            get { return onDutyTime; }
            set { onDutyTime = value; }
        }
        public string OffDutyTime
        {
            get { return offDutyTime; }
            set { offDutyTime = value; }
        }
    }
}

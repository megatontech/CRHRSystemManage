using System;
using System.Collections.Generic;
using System.Text;

namespace MyOffice.Models
{
    [Serializable()]
    public class MeetingInfo//会议类型
    {
        private int id; //PK会议类型Id
        private string meetingName = String.Empty;//会议类型名称

        public MeetingInfo() { }

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public string MeetingName
        {
            get { return this.meetingName; }
            set { this.meetingName = value; }
        }
    }
}

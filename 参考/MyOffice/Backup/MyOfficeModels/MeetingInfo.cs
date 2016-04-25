using System;
using System.Collections.Generic;
using System.Text;

namespace MyOffice.Models
{
    [Serializable()]
    public class MeetingInfo//��������
    {
        private int id; //PK��������Id
        private string meetingName = String.Empty;//������������

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

using System;
using System.Collections.Generic;
using System.Text;

namespace MyOffice.Models
{
    //日程类
    [Serializable]
    public class Schedule 
    {
        private int id;//日程Id
        private string title;//日程标题
        private string address;//会议地址
        private MeetingInfo meeting;//会议类型,MeetingInfo表外键
        private DateTime beginTime;//开始时间
        private DateTime endTime;//结束时间
        private string schContent;//日程内容
        private UserInfo createUserId;//创建者,UserInfo表的外键
        private DateTime createTime;//创建时间
        private int ifPrivate;//是否私有--------------------------------------------------******

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public MeetingInfo Meeting
        {
            get { return meeting; }
            set { meeting = value; }
        }
        public DateTime BeginTime
        {
            get { return beginTime; }
            set { beginTime = value; }
        }
        public DateTime EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }
        public string SchContent
        {
            get { return schContent; }
            set { schContent = value; }
        }
        public UserInfo CreateUserId
        {
            get { return createUserId; }
            set { createUserId = value; }
        }
        public DateTime CreateTime
        {
            get { return createTime; }
            set { createTime = value; }
        }
        public int IfPrivate
        {
            get { return ifPrivate; }
            set { ifPrivate = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace MyOffice.Models
{
    [Serializable()]
    public class Message//消息
    {
        private int id; //PK消息Id
        private string title = String.Empty;//消息标题
        private string messageContent = String.Empty;//消息内容
        private MessageType messageType; //FK消息类型
        private DateTime beginTime;//开始有效时间
        private DateTime endTime;//有效结束时间
        private UserInfo fromUser;//发送者
        private int ifPublish;//是否已发布
        private DateTime recordTime;//发送时间
        private int isDelete;//是否已删除


        public Message() { }

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public UserInfo FromUser
        {
            get { return this.fromUser; }
            set { this.fromUser = value; }
        }

        public MessageType MessageType
        {
            get { return this.messageType; }
            set { this.messageType = value; }
        }

        public string Title
        {
            get { return this.title; }
            set { this.title = value; }
        }

        public string MessageContent
        {
            get { return this.messageContent; }
            set { this.messageContent = value; }
        }

        public DateTime BeginTime
        {
            get { return this.beginTime; }
            set { this.beginTime = value; }
        }

        public DateTime EndTime
        {
            get { return this.endTime; }
            set { this.endTime = value; }
        }

        public int IfPublish
        {
            get { return this.ifPublish; }
            set { this.ifPublish = value; }
        }

        public DateTime RecordTime
        {
            get { return this.recordTime; }
            set { this.recordTime = value; }
        }

        public int IsDelete
        {
            get { return isDelete; }
            set { isDelete = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace MyOffice.Models
{
    [Serializable()]
    public class MessageToUser//消息发送对象(数据库有问题)
    {
        private int id; //PK序号Id
        private Message message; //FK消息Id
        private UserInfo toUser;//FK发送对象Id(*)
        private int ifRead;//是否已读。1：已读、0：未读
        private int isDelete;//是否删除
        public MessageToUser() { }

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public Message Message
        {
            get { return this.message; }
            set { this.message = value; }
        }

        public UserInfo ToUser
        {
            get { return this.toUser; }
            set { this.toUser = value; }
        }

        public int IfRead
        {
            get { return this.ifRead; }
            set { this.ifRead = value; }
        }
        public int IsDelete
        {
            get { return isDelete; }
            set { isDelete = value; }
        }
    }
}

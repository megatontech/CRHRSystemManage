using System;
using System.Collections.Generic;
using System.Text;

namespace MyOffice.Models
{
    [Serializable()]
    public class MessageToUser//��Ϣ���Ͷ���(���ݿ�������)
    {
        private int id; //PK���Id
        private Message message; //FK��ϢId
        private UserInfo toUser;//FK���Ͷ���Id(*)
        private int ifRead;//�Ƿ��Ѷ���1���Ѷ���0��δ��
        private int isDelete;//�Ƿ�ɾ��
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

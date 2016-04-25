using System;
using System.Collections.Generic;
using System.Text;

namespace MyOffice.Models
{
    [Serializable()]
    public class Message//��Ϣ
    {
        private int id; //PK��ϢId
        private string title = String.Empty;//��Ϣ����
        private string messageContent = String.Empty;//��Ϣ����
        private MessageType messageType; //FK��Ϣ����
        private DateTime beginTime;//��ʼ��Чʱ��
        private DateTime endTime;//��Ч����ʱ��
        private UserInfo fromUser;//������
        private int ifPublish;//�Ƿ��ѷ���
        private DateTime recordTime;//����ʱ��
        private int isDelete;//�Ƿ���ɾ��


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

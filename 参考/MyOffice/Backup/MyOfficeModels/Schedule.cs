using System;
using System.Collections.Generic;
using System.Text;

namespace MyOffice.Models
{
    //�ճ���
    [Serializable]
    public class Schedule 
    {
        private int id;//�ճ�Id
        private string title;//�ճ̱���
        private string address;//�����ַ
        private MeetingInfo meeting;//��������,MeetingInfo�����
        private DateTime beginTime;//��ʼʱ��
        private DateTime endTime;//����ʱ��
        private string schContent;//�ճ�����
        private UserInfo createUserId;//������,UserInfo������
        private DateTime createTime;//����ʱ��
        private int ifPrivate;//�Ƿ�˽��--------------------------------------------------******

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

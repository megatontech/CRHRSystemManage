using System;
using System.Collections.Generic;
using System.Text;

namespace MyOffice.Models
{
    [Serializable()]
    public class ManualSign//������Ϣ
    {
        private int id; //PKǩ��Id
        private UserInfo user; //FK�û�id
        private DateTime signTime;//ǩ��ʱ��
        private string signDesc = String.Empty;//ǩ����ע
        private int signTag;//ǩ�����

        public ManualSign() { }

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public UserInfo User
        {
            get { return this.user; }
            set { this.user = value; }
        }

        public DateTime SignTime
        {
            get { return this.signTime; }
            set { this.signTime = value; }
        }

        public string SignDesc
        {
            get { return this.signDesc; }
            set { this.signDesc = value; }
        }

        public int SignTag
        {
            get { return this.signTag; }
            set { this.signTag = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace MyOffice.Models
{
    /// <summary>
    /// ��Ϣ����
    /// </summary>
   [Serializable]
   public class MessageType
    {
        private int id;//��Ϣ����Id
        private string messageTypeName;//��Ϣ��������
        private string messageDesc;//��Ϣ��������


        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string MessageTypeName
        {
            get { return messageTypeName; }
            set { messageTypeName = value; }
        }
        public string MessageDesc
        {
            get { return messageDesc; }
            set { messageDesc = value; }
        }
    }
}

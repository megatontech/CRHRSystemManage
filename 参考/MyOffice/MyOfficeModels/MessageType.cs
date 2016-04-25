using System;
using System.Collections.Generic;
using System.Text;

namespace MyOffice.Models
{
    /// <summary>
    /// 消息类型
    /// </summary>
   [Serializable]
   public class MessageType
    {
        private int id;//消息类型Id
        private string messageTypeName;//消息类型名称
        private string messageDesc;//消息类型描述


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

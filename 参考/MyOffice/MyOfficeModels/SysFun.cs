using System;
using System.Collections.Generic;
using System.Text;

namespace MyOffice.Models
{
    //�˵��ڵ���
    [Serializable]
    public class SysFun 
    {
        private int nodeId;//�˵��ڵ�id
        private string displayName;//�˵�����
        private string nodeURL;//�˵����ӵ�ַ
        private int displayOrder;//�˵���ʾ˳��
        private int parentNodeId;//���ڵ�id


        public int NodeId
        {
            get { return nodeId; }
            set { nodeId = value; }
        }
        public string DisplayName
        {
            get { return displayName; }
            set { displayName = value; }
        }
        public string NodeURL
        {
            get { return nodeURL; }
            set { nodeURL = value; }
        }
        public int DisplayOrder
        {
            get { return displayOrder; }
            set { displayOrder = value; }
        }
        public int ParentNodeId
        {
            get { return parentNodeId; }
            set { parentNodeId = value; }
        }


    }
}

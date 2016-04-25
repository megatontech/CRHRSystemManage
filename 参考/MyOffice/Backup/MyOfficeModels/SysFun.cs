using System;
using System.Collections.Generic;
using System.Text;

namespace MyOffice.Models
{
    //菜单节点类
    [Serializable]
    public class SysFun 
    {
        private int nodeId;//菜单节点id
        private string displayName;//菜单名称
        private string nodeURL;//菜单连接地址
        private int displayOrder;//菜单显示顺序
        private int parentNodeId;//父节点id


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

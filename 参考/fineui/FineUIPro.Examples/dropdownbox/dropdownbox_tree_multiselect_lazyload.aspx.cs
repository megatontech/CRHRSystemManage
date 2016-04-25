using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace FineUIPro.Examples.dropdownbox
{
    public partial class dropdownbox_tree_multiselect_lazyload : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }


        protected void btnGetSelection_Click(object sender, EventArgs e)
        {
            if (DropDownBox1.Value != null)
            {
                labResult.Text = String.Format("下拉框文本：{0}（值：{1}）", DropDownBox1.Text, String.Join(",", DropDownBox1.Values));
            }
            else
            {
                labResult.Text = "下拉框为空";
            }
        }



        protected void Tree1_NodeLazyLoad(object sender, TreeNodeEventArgs e)
        {
            DynamicAppendNode(e.Node);
        }

        private void DynamicAppendNode(TreeNode parentNode)
        {
            parentNode.Expanded = true;

            TreeNode node = null;
            switch (parentNode.NodeID)
            {
                case "zhumadian":
                    node = new TreeNode();
                    node.Text = "遂平县（此节点延迟加载）";
                    node.Leaf = false;
                    node.NodeID = "suiping";
                    parentNode.Nodes.Add(node);

                    node = new TreeNode();
                    node.Text = "西平县";
                    node.Leaf = true;
                    node.NodeID = "xiping";
                    parentNode.Nodes.Add(node);
                    break;
                case "suiping":
                    node = new TreeNode();
                    node.Text = "槐树乡（此节点延迟加载）";
                    node.Leaf = false;
                    node.NodeID = "huaishu";
                    parentNode.Nodes.Add(node);

                    node = new TreeNode();
                    node.Text = "嵖岈山乡";
                    node.Leaf = true;
                    node.NodeID = "chayashan";
                    parentNode.Nodes.Add(node);
                    break;
                case "huaishu":
                    node = new TreeNode();
                    node.Text = "陈庄村";
                    node.Leaf = true;
                    node.NodeID = "chenzhuang";
                    parentNode.Nodes.Add(node);

                    node = new TreeNode();
                    node.Text = "王老庄";
                    node.Leaf = true;
                    node.NodeID = "wanglaozhuang";
                    parentNode.Nodes.Add(node);
                    break;
            }
        }


    }
}

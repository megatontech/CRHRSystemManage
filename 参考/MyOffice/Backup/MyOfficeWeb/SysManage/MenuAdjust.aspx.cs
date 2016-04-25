using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MyOffice.BLL;
using MyOffice.Models;
using System.Collections.Generic;
public partial class SysManage_MenuAdjust : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["user"] != null)
            {   
                DisplayUserMenu();
            }
        }
    }
    public void DisplayUserMenu()
    {
        //得到用户信息
        UserInfo user = (UserInfo)Session["user"];
        this.TVSysFunUpdate.Nodes.Clear();
        //得到系统菜单表中所有的第一级菜单
        IList<SysFun> parentSysFun = SysFunManager.GetAllParentNodeInfoByUserId(user);
        foreach (SysFun sfParent in parentSysFun)
        {
            //得到第一层节点的Id
            string nodeId = sfParent.NodeId.ToString();
            //得到第一层节点的显示名称
            string displayName = sfParent.DisplayName;
            //根据节点信息创建一层节点
            TreeNode fatherNode = CreateTreeNode(displayName, nodeId, "~/images/menuclose.gif");
            CreateChildTree(nodeId, user, fatherNode);
            this.TVSysFunUpdate.Nodes.Add(fatherNode);           
            //展开上次选择的节点
           
           
        }
        //选中的子菜单其父节点打开
        if (hidNodeId.Value.ToString() != "" && hidNodeId.Value.ToString().Length>3)
        {
            foreach (TreeNode treeNode in this.TVSysFunUpdate.Nodes)
            {
               
                if (hidNodeId.Value.ToString().IndexOf(treeNode.Value.ToString())==0)
                { treeNode.Expand(); }
            }
        }
    }
    private TreeNode CreateTreeNode(string strText, string strId, string strImage)
    {
        TreeNode newNode = new TreeNode();
        newNode.Text = strText;
        newNode.Value = strId;
        newNode.ImageUrl = strImage;
        return newNode;
    }
    //创建第二级节点
    public void CreateChildTree(string nodeId, UserInfo user, TreeNode fatherNode)
    {
        //在三层下实现获得父级节点为nodeId的所有子节点
        IList<SysFun> childSysFun = SysFunManager.GetSysFunByParentNodeIdAndUserId(user, int.Parse(nodeId));
        foreach (SysFun sfChild in childSysFun)
        {
            //得到第二层节点Id
            string childNodeId = sfChild.NodeId.ToString();
            //得到第二层节点的显示名称
            string childDisplayName = sfChild.DisplayName;

            //根据节点信息，创建第二层节点
            TreeNode childNode = CreateTreeNode(childDisplayName, childNodeId,  "~/images/CloseTree.gif");
            //将子节点加入到父节点中
            AddTree(fatherNode, childNode);
        }
    }
    //将子节点加入到父节点中
    private void AddTree(TreeNode fatherNode, TreeNode childNode)
    {
        fatherNode.ChildNodes.Add(childNode);
    }
    // 上移
    protected void BtnUp_Click(object sender, EventArgs e)
    {
        //得到当前选中的节点
        int nodeId = int.Parse(hidNodeId.Value.ToString());
        SysFun node = SysFunManager.GetSysFunById(nodeId);

        //得到当前选中节点的前一个节点
        SysFun upNode = SysFunManager.GetUpNodeByCurrentNodeId(node.DisplayOrder, node.ParentNodeId);


        //验证：如果已经是最上面的一个节点，则不能进行上移操作
        if (upNode == null)
        {
            this.LblMessage.Text = "操作菜单项已经置顶";
            this.LblMessage.Visible = true;
            return;
        }
        this.LblMessage.Visible = false;

        //执行移动操作：修改displayOrder,交换选中节点和该节点的上一个节点的DisplayOrder
        bool b=SysFunManager.ModifySysFunOrderByNodeId(node.NodeId, upNode.DisplayOrder);
        bool b1=SysFunManager.ModifySysFunOrderByNodeId(upNode.NodeId, node.DisplayOrder);
        if (b && b1)
        {
            //重新绑定树
            DisplayUserMenu();
            ///////////////添加操作日志	
            UserInfo user = (UserInfo)Session["user"];
            OperateLog log = new OperateLog();
            log.User = user;
            log.OperateName = "上调整";
            log.OperateDesc = "菜单排序";
            bool b2 = OperateLogManager.AddOperateLog(log);
        }
    }
    //下移
    protected void BtnDown_Click(object sender, EventArgs e)
    {
        //得到当前选中的节点
        int nodeId = int.Parse(hidNodeId.Value.ToString());
        SysFun node = SysFunManager.GetSysFunById(nodeId);

        //得到当前选中节点的下一个节点
        SysFun downNode = SysFunManager.GetDownNodeByCurrentNodeId(node.DisplayOrder, node.ParentNodeId);

        //验证：如果已经是最下面的一个节点，则不能进行下移操作
        if (downNode == null)
        {
            this.LblMessage.Text = "操作菜单项已经置底";
            this.LblMessage.Visible = true;
            return;
        }
        this.LblMessage.Visible = false;

        //执行移动操作：修改displayOrder,交换选中节点和该节点的下一个节点的DisplayOrder
        bool b=SysFunManager.ModifySysFunOrderByNodeId(node.NodeId, downNode.DisplayOrder);
        bool b1=SysFunManager.ModifySysFunOrderByNodeId(downNode.NodeId, node.DisplayOrder);

        if (b && b1)
        {
            //重新绑定树
            DisplayUserMenu();
            ///////////////添加操作日志	
            UserInfo user = (UserInfo)Session["user"];
            OperateLog log = new OperateLog();
            log.User = user;
            log.OperateName = "下调整";
            log.OperateDesc = "菜单排序";
            bool b2 = OperateLogManager.AddOperateLog(log);
        }
    }
    protected void TVSysFunUpdate_SelectedNodeChanged(object sender, EventArgs e)
    {
        //得到当前选中的节点ＩＤ
        int nodeId = int.Parse(TVSysFunUpdate.SelectedNode.Value);
        //赋值到隐藏域中
        hidNodeId.Value = nodeId.ToString();  
    }
   
}

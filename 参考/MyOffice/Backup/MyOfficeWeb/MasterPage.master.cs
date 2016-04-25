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
public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) 
        {
             if (Session["user"] != null)
             {
                 //得到用户信息
                 UserInfo user = (UserInfo)Session["user"];
                 this.LblUserName.Text = user.LoginId;
                 this.LblRoleName.Text = user.Role.RoleName;
                 this.LblDepartName.Text = user.Depart.DepartName;
                 this.LblBranchName.Text = user.Depart.Branch.BranchShortName;
                 //显示日期
                 this.LblTimeNow.Text = DateTime.Now.ToShortDateString()+ " " + DateTime.Now.ToString("dddd", new System.Globalization.CultureInfo("zh-cn"));
                 DisplayUserMenu(user);
             }
        }
    }
    public void DisplayUserMenu(UserInfo user) 
    {  
        this.TVSysFun.Nodes.Clear();
        //得到系统菜单表中所有的第一级菜单
        IList<SysFun> parentSysFun = SysFunManager.GetAllParentNodeInfoByUserId(user);
        foreach (SysFun sfParent in parentSysFun) 
        {
            //得到第一层节点的Id
            string nodeId = sfParent.NodeId.ToString();
            //得到第一层节点的显示名称
            string displayName = sfParent.DisplayName;
            //根据节点信息创建一层节点
            TreeNode fatherNode = CreateTreeNode(displayName, nodeId, "", "~/images/menuclose.gif");
            CreateChildTree(nodeId, user, fatherNode);
            this.TVSysFun.Nodes.Add(fatherNode);
            //选中的子菜单其父节点打开
            
        }

        if (Request.QueryString["NodeId"] != null )
        {
            string NodeId = Request.QueryString["NodeId"];
            //选中的子菜单其父节点打开
            if (NodeId != "" && NodeId.Length > 3)
            {
                foreach (TreeNode treeNode in this.TVSysFun.Nodes)
                {

                    if (NodeId.IndexOf(treeNode.Value.ToString()) == 0)
                    { treeNode.Expand(); }
                }
            }
        }
       
    }
    private TreeNode CreateTreeNode(string strText,string strId,string strUrl,string strImage)
    {
        TreeNode newNode = new TreeNode();
        newNode.Text = strText;
        newNode.Value = strId;
        if (strId != "")
        {
            newNode.NavigateUrl = strUrl + "?NodeId=" + strId;
        }
        else 
        {
            newNode.NavigateUrl = strUrl;
        }
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
            //将路径转换为客户端可用的URL
            string nodeURL = ResolveUrl(sfChild.NodeURL.ToString().Trim());

            //根据节点信息，创建第二层节点
            TreeNode childNode = CreateTreeNode(childDisplayName, childNodeId, nodeURL, "~/images/CloseTree.gif");
            //将子节点加入到父节点中
            AddTree(fatherNode, childNode);
        }
    }
    //将子节点加入到父节点中
    private void AddTree(TreeNode fatherNode, TreeNode childNode) 
    {
        fatherNode.ChildNodes.Add(childNode);
    }
   
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        if (Session["user"] != null)
        {
            //得到用户信息
            UserInfo user = (UserInfo)Session["user"];
            int MessageCount = MessageToUserManager.GetMessageCountByUser(user);
            this.LblMessageCount.Text = MessageCount.ToString();
            if (MessageCount > 0)
            { 
                imgbtnMessage.Visible = true; 
            }
            else
            { 
                imgbtnMessage.Visible = false; 
            }
        }
    }
    //修改密码
    protected void imgbtnUpdatePass_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["user"] != null)
        {
            Response.Redirect("~/ModifyPassword.aspx");
        }
    }
    //重新登陆
    protected void imgbtnRelogin_Click(object sender, ImageClickEventArgs e)
    {
        Session["user"] = null;
        Response.Redirect("~/index.aspx");
    }

    protected void imgbtnHome_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["user"] != null)
        {
            UserInfo userInfo = (UserInfo)Session["user"];
            if (userInfo.Role.RoleName == "系统管理员")
            {
                Response.Redirect("~/ScheduleManage/PersonNote/PersonNote.aspx");
            }
            else
            {
                Response.Redirect("~/ManualSign/ManualSign.aspx");
            }
        }
    }
    protected void imgbtnHideTitle_Click(object sender, ImageClickEventArgs e)
    {
        if (divMessage.Visible == false)
        {
            divMessage.Visible = true;
        }
        else 
        {
            divMessage.Visible = false;
        }
    }
}

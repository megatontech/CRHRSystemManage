using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MyOffice.BLL;
using MyOffice.Models;


public partial class PersonManage_DepartInfoManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if(!IsPostBack)
        {
            ViewState["DepartName"] = "";
            ViewState["BranchId"] = "";
            Inite();
            UserTree();
        }
    }
    public string DepartName
    {
        get { return Convert.ToString(ViewState["DepartName"]); }
        set { ViewState["DepartName"] = value; }
    }
    public int BranchId
    {
        get { return Convert.ToInt32(ViewState["BranchId"]); }
        set { ViewState["BranchId"] = value; }
    }
    public void Inite() 
    {
        if (Request.QueryString["departid"] != null)
        {
            int departid = int.Parse(Request.QueryString["departid"].ToString());
            DepartInfo depart = new DepartInfo();
            depart = DepartInfoManager.GetDepartById(departid);
            this.txtDepartName.Text = depart.DepartName.ToString();
            ViewState["DepartName"] = depart.DepartName.ToString();
            this.txtUser.Text = depart.User.UserName.ToString();
            this.txtConnectTelNo.Text = depart.ConnectTelNo.ToString();
            this.txtconnectMobileTelNo.Text = depart.ConnectMobileTelNo.ToString();
            this.txtfaxes.Text = depart.Faxes.ToString();
            this.ddlBranch.DataSource = BranchInfoManger.GetBranchInfo();
            this.ddlBranch.DataBind();
            this.ddlBranch.SelectedValue = depart.Branch.Id.ToString();
            ViewState["BranchId"] = depart.Branch.Id.ToString();
        }
        else
        {
            this.ddlBranch.DataSource = BranchInfoManger.GetBranchInfo();
            this.ddlBranch.DataBind();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        UserInfo user = new UserInfo();
        BranchInfo branch = new BranchInfo();
        DepartInfo depart = new DepartInfo();
        branch.Id = int.Parse(this.ddlBranch.SelectedValue.ToString());
        depart.ConnectMobileTelNo = this.txtconnectMobileTelNo.Text.Trim();
        depart.ConnectTelNo = this.txtConnectTelNo.Text.Trim();
        depart.Faxes = this.txtfaxes.Text.Trim();
        depart.DepartName = this.txtDepartName.Text.Trim();
        depart.Branch = branch;
        if (this.txtUser.Text.Trim() == "")
        {
            user = (UserInfo)Session["user"];
        }
        else
        {
            user.Id = UserInfoManager.GetUserByUserName(this.txtUser.Text.Trim());
        }
        depart.User = user;
        if (Request.QueryString["departid"] != null )
        {
            depart.Id = int.Parse(Request.QueryString["departid"]);
            if (DepartInfoManager.CheckDepart(depart) && DepartName == depart.DepartName && BranchId == depart.Branch.Id)
            {
                bool boo = DepartInfoManager.ModifyDepartById(depart);
                if (boo) 
                {
                    Response.Redirect("DepartManage.aspx");
                }
            }
            else 
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "str", "<script>alert('已有该部门')</script>", false);
            }
        }
        else 
        {
            if (DepartInfoManager.CheckDepart(depart))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "str", "<script>alert('已有该部门')</script>", false);
            }
            else 
            {
                bool b = DepartInfoManager.AddDepart(depart);
                if (b)
                {
                    Response.Redirect("DepartManage.aspx");
                }
            }
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("DepartManage.aspx");
    }
    //得到预约人[机构，部门和员工]
    public void UserTree()
    {
        IList<BranchInfo> list = BranchInfoManger.GetBranchInfo();
        if (list.Count > 0)
        {
            foreach (BranchInfo branchInfo in list)
            {
                TreeNode nodeTemp = new TreeNode();
                nodeTemp.ImageUrl = "~/images/menuclose.gif";
                nodeTemp.Text = branchInfo.BranchName;
                nodeTemp.Value = branchInfo.Id.ToString();
                
                //根据机构ID得到部门信息
                IList<DepartInfo> departList = DepartInfoManager.GetDepartInfoByBranchId(int.Parse(nodeTemp.Value));
                foreach (DepartInfo depart in departList)
                {
                    TreeNode child = new TreeNode();
                    child.ImageUrl = "~/images/CloseTree.gif";
                    child.Text = depart.DepartName;
                    child.Value = depart.Id.ToString();
                    //把部门添加到机构中
                    nodeTemp.ChildNodes.Add(child);
                    //根据部门ID得到员工信息
                    IList<UserInfo> userList = UserInfoManager.GetUserInfoByDepartId(int.Parse(child.Value));
                    foreach (UserInfo user in userList)
                    {   
                        TreeNode node = new TreeNode();
                        node.ImageUrl = "~/images/person.gif";
                        node.Text = user.UserName;
                        node.Value = user.Id.ToString();

                        //把员工添加到相应部门中
                        child.ChildNodes.Add(node);
                    }
                }
                //把机构添加到TreeView中显示..
                
                TreeView1.Nodes.Add(nodeTemp);
                TreeView1.ExpandAll();
            }
        }
    }
   
    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        TreeNode curNode = this.TreeView1.SelectedNode;  //得到当前的节点
        TreeNode fatherNode = (TreeNode)curNode.Parent;  //得到父节点
        int i = curNode.Depth;       
        if (i > 1)
        {
            int id = int.Parse(this.TreeView1.SelectedValue.ToString());
            Session["usid"] = id;
            UserInfo us = UserInfoManager.GetUserInfoById(id);
            this.txtUser.Text = us.UserName;
            //this.divTree.Visible = false;
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "str", "<script>alert('您选择的不是用户')</script>", false);           
           
        }
    }

    protected void TreeView1_TreeNodeExpanded(object sender, TreeNodeEventArgs e)
    {

    }
}

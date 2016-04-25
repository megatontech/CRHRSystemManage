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

public partial class SysManage_RoleManage_ListUsersByRole : System.Web.UI.Page
{

    private const int ENABLE = 2;//状态为“正常”的编号
    private const int UNENABLE = 1;//状态为“无效”的编号
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Inite();////加载GridView         
            LoadRole();

        }
    }
    ////加载GridView
    public void Inite()
    {

        PagedDataSource pdsList = new PagedDataSource();
        IList<UserInfo> list = null;
        if (this.chkBranch.Checked || this.chkDepart.Checked || this.chkUserName.Checked || this.chkRole.Checked)
        {
            string userName = "";
            int departId = 0;
            int branchId = 0;
            int roleId = 0;
            if (this.chkUserName.Checked)
            {
                userName = this.txtUserName.Text.Trim();//姓名
            }
            if (ddlDeparts.SelectedValue != "" && this.chkDepart.Checked)
            {
                departId = int.Parse(ddlDeparts.SelectedValue);//部门
            }
            if (ddlBranchs.SelectedValue != "" && this.chkBranch.Checked)
            {
                branchId = int.Parse(ddlBranchs.SelectedValue);//机构
            }
            if (this.ddlRoles.SelectedValue != "" && this.chkRole.Checked)
            {
                roleId = int.Parse(this.ddlRoles.SelectedValue);//角色
            }
            list = UserInfoManager.GetUserInfoBySelectedConditions(userName, departId, branchId, roleId);//通过条件查询用户信息
        }
        else
        {
            list = UserInfoManager.GetUserInfos();//查询所有用户信息
        }
        pdsList.DataSource = list;
        int count = 0;
        if (list.Count % 5 == 0)
        {
            count = list.Count / 5;
        }
        else
        {
            count = list.Count / 5 + 1;
        }
        pdsList.AllowPaging = true;//数据源允许分页
        pdsList.PageSize = this.anpPager.PageSize;//取控件的分页大小       
        if (this.anpPager.CurrentPageIndex > count)
            this.anpPager.CurrentPageIndex = 1;
        else
            pdsList.CurrentPageIndex = this.anpPager.CurrentPageIndex - 1;//显示当前页
        //设置控件
        this.anpPager.RecordCount = list.Count;//记录总数
        this.anpPager.PageSize = 5;
        this.gvUser.DataSource = pdsList;
        this.gvUser.DataBind();

    }
   
   
    //添加角色
    protected void LoadRole()
    {
        IList<RoleInfo> roles = RoleInfoManager.GetRoleInfoAll();
        ddlUserRoles.Items.Clear();
        ddlRoles.Items.Clear();

        ddlUserRoles.Items.Add(new ListItem("==请选择==", "0"));
        foreach (RoleInfo role in roles)
        {
            ListItem li = new ListItem();
            li.Value = role.Id.ToString();
            li.Text = role.RoleName;
            ddlUserRoles.Items.Add(li);
        }
        ddlRoles.Items.Add(new ListItem("==请选择==", "0"));
        foreach (RoleInfo role in roles)
        {
            ListItem li = new ListItem();
            li.Value = role.Id.ToString();
            li.Text = role.RoleName;
            ddlRoles.Items.Add(li);
        }
    }
    public void ControlEnabled()
    {
        if (this.chkBranch.Checked)
            this.ddlBranchs.Enabled = true;
        else
            this.ddlBranchs.Enabled = false;
        if (this.chkDepart.Checked)
            this.ddlDeparts.Enabled = true;
        else
            this.ddlDeparts.Enabled = false;
        if (this.chkUserName.Checked)
            this.txtUserName.Enabled = true;
        else
            this.txtUserName.Enabled = false;
        if (this.chkRole.Checked)
            this.ddlRoles.Enabled = true;
        else
            this.ddlRoles.Enabled = false;
        foreach (GridViewRow gvr in this.gvUser.Rows)
        {
            CheckBox cb = gvr.FindControl("chkOne") as CheckBox;
            if (cb.Checked == true)
            {
                this.btnOk.Enabled = true;
                this.btnEnable.Enabled = true;
                this.btnEnenable.Enabled = true;
            }
        }
    }
    
    //通过条件查询用户信息
    protected void imgbtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        Inite();//刷新GridView
        ControlEnabled();
    }
    //分页
    protected void anpPager_PageChanged(object sender, EventArgs e)
    {
        Inite();//刷新GridView
    }
    //修改状态
    protected void gvUser_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //取得用户状态的当前值
        LinkButton link = this.gvUser.Rows[e.RowIndex].FindControl("linkbtnUserState") as LinkButton;
        int stateid = int.Parse(link.CommandArgument);//绑定的是用户的状态ＩＤ
        int userId = int.Parse(this.gvUser.DataKeys[e.RowIndex].Value.ToString());
        if (stateid == 1)
        {
            stateid = 2;
        }
        else
        {
            stateid = 1;
        }
        bool b = UserInfoManager.DeleteUserById(userId, stateid);//调用修改状态的方法
        Inite();//刷新GridView
        e.Cancel = true;
    }
    protected void gvUser_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#6dc7fc'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");
        }
    }
    //屏蔽
    protected void btnEnenable_Click(object sender, EventArgs e)
    {
        GetUserId(UNENABLE);
    }
    //正常
    protected void btnEnable_Click(object sender, EventArgs e)
    {
        GetUserId(ENABLE);
    }
    /// <summary>
    /// 更改状态的方法
    /// </summary>
    /// <param name="StateId">状态编号</param>
    public void GetUserId(int StateId)
    {
        bool b = false;
        string sb = String.Empty;
        foreach (GridViewRow gvr in this.gvUser.Rows)
        {
            CheckBox cb = gvr.FindControl("chkOne") as CheckBox;
            if (cb.Checked == true)
            {
                sb += this.gvUser.DataKeys[gvr.RowIndex].Value.ToString() + ",";//得到选中复选框用户的编号
            }
        }
        if (sb.Length > 0)//如果有复选框被选中就修改
        {
            sb = sb.Substring(0, sb.Length - 1);
            b = UserInfoManager.ModifyUserInfoStates(StateId, sb);//调用修改状态的方法
            if (b) 
            {
                Inite();//刷新GridView
            }
        }      

    }
    //为用户分陪角色
    protected void btnOk_Click(object sender, EventArgs e)
    {
        if (this.ddlUserRoles.SelectedValue != "")
        {
            string sb = String.Empty;
            bool b = false;
            foreach (GridViewRow gvr in this.gvUser.Rows)
            {
                CheckBox cb = gvr.FindControl("chkOne") as CheckBox;//得到选中复选框
                if (cb.Checked == true)
                {
                    sb += this.gvUser.DataKeys[gvr.RowIndex].Value.ToString() + ",";//累加所有的UserID以，连接
                }
            }
            int roleId = int.Parse(this.ddlUserRoles.SelectedValue);//得到角编号
            if (sb.Length > 0)
            {
                sb = sb.Substring(0, sb.Length - 1);
                b = UserInfoManager.ModifyRoleIdByUserId(sb, roleId); //调用修改角色的方法      
                if (b)
                {
                    Inite();//刷新GridView
                }
            }
        }
    }
}

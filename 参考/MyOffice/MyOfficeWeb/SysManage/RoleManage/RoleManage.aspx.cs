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
public partial class SysManage_RoleManage_RoleManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) 
        {
            SetPager();//加载角色信息
            ViewState["RoleId"] = 1;
            ViewState["RoleName"] = "";
        }
    }
    //分页显示
    public void SetPager()
    {        
        PagedDataSource pdsList = new PagedDataSource();
        IList<RoleInfo> list = RoleInfoManager.GetRoleInfoAll(); //得到所有角色信息    
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
        this.GVRoleInfoAll.DataSource = pdsList;
        this.GVRoleInfoAll.DataBind();
      
    }
   //添加角色信息
    protected void BtnAddRole_Click(object sender, EventArgs e)
    {
        RoleInfo roleInfo = new RoleInfo();
        roleInfo.RoleName = this.TxtRoleName.Text.Trim();
        roleInfo.RoleDesc = Server.HtmlEncode(this.TxtRoleDesc.Text.Trim());
        if (RoleNameValidator(roleInfo, "添加"))
        {
            if (RoleInfoManager.AddRoleInfo(roleInfo))//添加角色
            {
                SetPager();////重新加载角色信息
                this.TxtRoleName.Text = "";
                this.TxtRoleDesc.Text = "";
                ///////////////添加操作日志
                UserInfo user = (UserInfo)Session["user"];
                OperateLog log = new OperateLog();
                log.User = user;
                log.OperateName = "添加";
                log.OperateDesc = "添加角色";
                bool b1 = OperateLogManager.AddOperateLog(log);
            }
        }
    }
    //验证角色名称
    public bool RoleNameValidator(RoleInfo roleInfo,string btnName) 
    {
        //以空格为分隔符，将分隔后的字符串放进数组中
        string[] str = roleInfo.RoleName.Split(' ');
        string roleName = "";
        //将数组中的字符转换为字符串
        for (int i = 0; i < str.Length; i++)
        {
            roleName += str[i];
        }
        //将去除空格后的字符串转换成大写
        roleInfo.RoleName = roleName.ToUpper();
        IList<RoleInfo> list = RoleInfoManager.GetRoleInfoAll(); //得到所有角色信息    
          //已存在时设result
        int result = 0;
        //将每个类别信息取出后去除空格，并转换为大写
        foreach (RoleInfo role in list)
        {
            string temp = role.RoleName.Trim().TrimStart();
            string[] tempArry = temp.Split(' ');
            string tempstr = "";
            for (int j = 0; j < tempArry.Length; j++)
            {
                tempstr += tempArry[j];
            }
            string strName = tempstr.ToUpper();
            //如果页面中的值与数据库中有类别值相等，则结束循环
            if (strName == roleInfo.RoleName)
            {
                result++;
            }
        }
        //调用判断该类别是否存在的方法
        if (result > 0 && btnName == "修改" && RoleName != roleInfo.RoleName)
        {
            //弹出提示
            ScriptManager.RegisterStartupScript(this, this.GetType(), "str", "<script>alert('该角色名称已存在')</script>", false);
            this.TxtRoleName.Text = "";//清空
            return false;
        }
        if (result > 0 && btnName == "添加") 
        {
            //弹出提示
            ScriptManager.RegisterStartupScript(this, this.GetType(), "str", "<script>alert('该角色名称已存在')</script>", false);
            this.TxtRoleName.Text = "";//清空
            return false;
        }
        foreach (char chr in roleInfo.RoleName)
        {
            if (!char.IsLetterOrDigit(chr) && char.IsSymbol(chr))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "str", "<script>alert(\"无效字符！！\")</script>", false);
                return false;
            }
        }
        return true;
       
    }
   //修改角色信息
    protected void BtnUpdateRole_Click(object sender, EventArgs e)
    {
        RoleInfo roleInfo = new RoleInfo();
        roleInfo.Id = RoleId;
        roleInfo.RoleName = this.TxtRoleName.Text.Trim();
        roleInfo.RoleDesc = Server.HtmlEncode(this.TxtRoleDesc.Text.Trim());
        if (RoleNameValidator(roleInfo, "修改"))
        {
            if (RoleInfoManager.UpdateRoleInfo(roleInfo))//修改角色
            {
                SetPager();//重新加载角色信息
                this.TxtRoleName.Text = "";
                this.TxtRoleDesc.Text = "";
                this.BtnAddRole.Enabled = true;
                this.BtnUpdateRole.Enabled = false;
                ///////////////添加操作日志
                UserInfo user = (UserInfo)Session["user"];
                OperateLog log = new OperateLog();
                log.User = user;
                log.OperateName = "修改";
                log.OperateDesc = "修改角色";
                bool b1 = OperateLogManager.AddOperateLog(log);
            }
        }
    }
    //分页
    protected void anpPager_PageChanged(object sender, EventArgs e)
    {
        SetPager();
    }
    public string RoleName
    {
        get { return Convert.ToString(ViewState["RoleName"]); }
        set { ViewState["RoleName"] = value; }
    }
    public int RoleId
    {
        get { return Convert.ToInt32(ViewState["RoleId"]); }
        set { ViewState["RoleId"] = value; }
    }
    protected void GVRoleInfoAll_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (Session["user"] != null)
        {
            ImageButton imageButton = (ImageButton)e.CommandSource;
            int roleId = int.Parse(imageButton.CommandArgument);
            //修改
            if (imageButton.ID.Equals("IBUpdate"))
            {
                RoleInfo roleInfo = RoleInfoManager.GetRoleInfoById(roleId);
                this.TxtRoleName.Text = roleInfo.RoleName;
                this.TxtRoleDesc.Text = roleInfo.RoleDesc;
                ViewState["RoleName"] = roleInfo.RoleName;
                RoleId = roleInfo.Id;
                this.BtnAddRole.Enabled = false;
                this.BtnUpdateRole.Enabled = true;
            }
            //分配权限
            if (imageButton.ID.Equals("IBRoleRight"))
            {
                Response.Redirect("DistributeRole.aspx?RoleId=" + roleId);
            }
            UserInfo user = (UserInfo)Session["user"];
            //删除
            if (imageButton.ID.Equals("IBDelete"))
            {
                if (roleId == 1)
                {
                    //不删除无角色用户            
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "str", "<script>alert('该角色为所有无角色用户准备，请务删除！')</script>", false);
                }

                //下面不能删除自己的
                else if (roleId == user.Role.Id)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "str", "<script>alert('不能删除自己的！')</script>", false);
                    this.TxtRoleName.Text = "";
                    this.TxtRoleDesc.Text = "";
                    this.BtnAddRole.Enabled = true;
                    this.BtnUpdateRole.Enabled = false;
                }
                else if (UserInfoManager.GetUserIdByRoleId(roleId))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "str", "<script>alert('该角色有用户，请务删除！')</script>", false);
                }
                else //删除角色
                {
                    if (RoleRightManager.GetRoleRightByRoleId(roleId).Count > 0) 
                    {
                        RoleRightManager.DeleteRoleRightByRoleId(roleId);
                    }
                    bool b = RoleInfoManager.DeleteRoleInfoById(roleId);
                    if (b)
                    {
                        SetPager();
                        ///////////////添加操作日志                     
                        OperateLog log = new OperateLog();
                        log.User = user;
                        log.OperateName = "删除";
                        log.OperateDesc = "删除角色";
                        bool b1 = OperateLogManager.AddOperateLog(log);
                    }
                }
            }
        }
    }
    //光棒
    protected void GVRoleInfoAll_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#6dc7fc'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");
        }
    }
    //取消
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        this.TxtRoleName.Text = "";
        this.TxtRoleDesc.Text = "";
        this.BtnAddRole.Enabled = true;
        this.BtnUpdateRole.Enabled = false;
    }
}

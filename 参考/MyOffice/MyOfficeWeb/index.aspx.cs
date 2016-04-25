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
public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //www.codepub.com
    }

    protected void IBLogin_Click(object sender, ImageClickEventArgs e)
    {
        UserInfo userInfo = new UserInfo();
        userInfo.LoginId = this.TxtUserId.Text.Trim();
        userInfo.Password = this.TxtPassword.Text.Trim();
        int userId = UserInfoManager.GetUserIdByUserLoginId(userInfo);
        if (userId > 0)
        {

            bool b = UserInfoManager.Login(ref userInfo);
            if (b)
            {
                Session["user"] = userInfo;
                LoginLog log = new LoginLog();
                log.IfSuccess = 1;
                log.LoginDesc="用户登录成功";
                log.User = userInfo;
                bool b1 = LoginLogManager.AddLoginLog(log);//添加登录日志
                if (b1)
                {
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
            else 
            {
                UserInfo user = new UserInfo();
                user.Id = userId;
                LoginLog log = new LoginLog();
                log.IfSuccess = 0;
                log.LoginDesc = "用户登录失败，用户名或密码不正确。";
                log.User = user;
                bool b1 = LoginLogManager.AddLoginLog(log);//添加登录日志
                Session["user"] = null;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "str", "<script>alert(\"密码错误！！\")</script>");
            }
        }
        else 
        {
            Session["user"] = null;
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "str", "<script>alert(\"不存在该用户！！\")</script>");
        }
    }
}

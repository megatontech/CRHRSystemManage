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
public partial class ModifyPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    //修改密码
    protected void btnOk_Click(object sender, EventArgs e)
    {
        if (Session["user"] != null)
        {
            UserInfo user = (UserInfo)Session["user"];
            user.Password = this.txtOkPwd.Text.Trim();
            bool b = UserInfoManager.ModifyPassword(user);
            if (b) 
            {
                OperateLog log = new OperateLog();
                log.User = user;
                log.OperateName = "修改";
                log.OperateDesc = "修改密码";
                bool b1=OperateLogManager.AddOperateLog(log);
               ScriptManager.RegisterStartupScript(this,this.GetType(), "str", "<script>alert('修改成功')</script>", false);
            }
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {

    }
}

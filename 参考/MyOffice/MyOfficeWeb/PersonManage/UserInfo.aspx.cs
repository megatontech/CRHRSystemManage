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
using MyOffice.Models;
using MyOffice.BLL;
using System.IO;

public partial class PersonManage_UserInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            int uid=int.Parse(Request.QueryString["uid"].ToString());
            Inite(uid);
        }
    }
    /// <summary>
    /// 初始页面
    /// </summary>"~/images/Users/" + this.txtLoginId.Text + ".jpg";
    /// <param name="uid"></param>
    public void Inite(int uid) 
    {
        UserInfo user = UserInfoManager.GetUserInfoById(uid);
        this.lalLoginId.Text = user.LoginId.ToString();
        this.lblDepart.Text = user.Depart.DepartName.ToString();
        string path = Server.MapPath(@"~/images/Users/" + user.LoginId.ToString() + ".jpg");
        string url = null;
        bool bb = File.Exists(path);
        if (bb)
        {
            url = @"~/images/Users/" + user.LoginId.ToString() + ".jpg";
        }
        else
        {
            url = "~/images/Users/noperson.jpg";
        }
        this.imgFace.ImageUrl = url;
        string gender = "";
        if (user.Gender.ToString() == "1")
        {
            gender = "男";
        }
        else
        {
            gender = "女";
        }
        this.lblGender.Text = gender;
        this.lblUserName.Text = user.UserName.ToString();
        this.lblUserRole.Text = user.Role.RoleName.ToString();
        this.lblUserState.Text = user.UserState.UserStateName.ToString();
    }
    /// <summary>
    /// 返回用户管理页面
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("UserManage.aspx");
    }
}

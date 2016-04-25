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

public partial class Message_MailBox_MailBox : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetMessage();
        }
    }
    public void GetMessage()
    {
        int userId = 1;
        string loginId = "admin";
        string roleName = "系统管理员";      
        if (Session["User"] != null)
        {
            UserInfo user = (UserInfo)Session["User"];//获得登录用户
            userId = user.Id;
            loginId = user.LoginId;
            roleName = user.Role.RoleName;//登录用户的角色   
        }
        this.lblReceiveFiles.Text = MessageToUserManager.GetReceiveMessageCountByUserId(userId).ToString(); //收件箱文件个数
        this.lblUnReadReceiveFiles.Text = MessageToUserManager.GetUnReadReceiveMessageCountByUserId(userId).ToString();//收件箱未读邮件

        this.lblSendFiles.Text = MessageManager.GetSendMessageCountByUserId(userId).ToString();//已发送文件个数
        this.lblDraftFiles.Text = MessageManager.GetDraftFilesMessageCountByUserId(userId).ToString();//草稿箱
        this.lblDeletedFiles.Text = MessageManager.GetDeleteFilesMessageByUserId(userId).Count.ToString();
    }
    protected void imgbtnReceiveFiles_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("ReceiveMail.aspx");//收件箱
    }
    protected void imgbtnSendFile_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("SendMail.aspx");//消息发送页面
    }
    protected void imgbtnDraftFiles_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("DraftMail.aspx");//草稿箱
    }
    protected void imgbtnDeletedFile_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("DeletedFiles.aspx");//已删除
    }
}

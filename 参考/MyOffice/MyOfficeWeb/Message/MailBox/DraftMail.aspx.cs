﻿using System;
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

public partial class Message_MailBox_DraftMail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            UserInfo user = new UserInfo();
            if (Session["User"] != null)
            {
                user = (UserInfo)Session["User"];
                DisplayDraftMailInfo(user.Id);//显示个人消息基本信息
            }
        }

    }
    /// <summary>
    /// 根据人员编号查询未发布的消息
    /// </summary>
    /// <param name="userId">人员编号</param>
    protected void DisplayDraftMailInfo(int userId)
    {
        List<Message> list = MessageManager.GetDraftFilesMessageByUserId(userId);
        if (list.Count > 0)
        {
            this.btnSelectAll.Disabled = false;
            this.btnDelete.Disabled = false;
            this.btnPublish.Disabled = false;

        }
        else
        {
            this.btnSelectAll.Disabled = true;
            this.btnDelete.Disabled = true;
            this.btnPublish.Disabled = true;
        }
        this.gvUnPublishMail.DataSource = list;
        this.gvUnPublishMail.DataBind();

    }
    #region 格式设置
    //设置文本格式
    public string GetCut(object obj)
    {
        string str = obj as string;
        if (str.Length > 7)
        {
            return str.Substring(0, 7) + "...";
        }
        return str;
    }
    //设置时间格式
    public string GetDate(object obj)
    {
        DateTime str = (DateTime)obj;
        return str.ToLongDateString();
    }
    #endregion
    protected void btnReturn_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("MailBox.aspx");
    }
    //发布
    protected void btnPublish_ServerClick(object sender, EventArgs e)
    {
        UserInfo user = (UserInfo)Session["User"];

        bool result = false;
        foreach (GridViewRow gvr in gvUnPublishMail.Rows)
        {
            CheckBox chkSelect = (CheckBox)gvr.FindControl("chkSelect");
            //如果选中了则发布
            if (chkSelect.Enabled == true && chkSelect.Checked == true)
            {
                string messageId = gvUnPublishMail.DataKeys[gvr.RowIndex].Value.ToString();

                result = MessageManager.ModifyMessageIsPublishById(int.Parse(messageId), 1);//1,true;0,False
            }
        }
        //如果发布成功，则重新绑定个人消息
        if (!result)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "str", "<script>alert('发布失败！！')</script>", false);

        }

        DisplayDraftMailInfo(user.Id);
     
    }
    //删除
    protected void btnDelete_ServerClick(object sender, EventArgs e)
    {

        UserInfo user = (UserInfo)Session["User"];

        bool result = false;
        foreach (GridViewRow gvr in gvUnPublishMail.Rows)
        {
            CheckBox chkSelect = (CheckBox)gvr.FindControl("chkSelect");
            //如果选中了则删除
            if (chkSelect.Enabled == true && chkSelect.Checked == true)
            {
                string messageId = gvUnPublishMail.DataKeys[gvr.RowIndex].Value.ToString();
                //if (MessageToUserManager.GetMessageToUserByMessageId(int.Parse(messageId)).Count > 0)//如果有发送对象就删除对象的消息
                //{
                //    MessageToUserManager.DelectMessageToUserByMessageId(int.Parse(messageId));
                //} 
                result = MessageManager.ModifyMessageIsDeleteById(int.Parse(messageId),1);
            }
        }
        //如果删除成功，则重新绑定个人消息
        if (!result)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "str", "<script>alert('删除失败！！')</script>", false);
            
        }

        DisplayDraftMailInfo(user.Id);
    }
    protected void gvUnPublishMail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        #region 绑定GridView基本项
        if (e.Row.RowType == DataControlRowType.DataRow)//判断行类型
        {
            UserInfo user = (UserInfo)Session["User"];

            int messageId = int.Parse(gvUnPublishMail.DataKeys[e.Row.RowIndex].Value.ToString());
            Message message = MessageManager.GetMessageById(messageId);//根据消息Id获得消息基本信息

            HyperLink hlReceiveUsers = (HyperLink)e.Row.FindControl("hlReceiveUsers");//实例化HyperLink用以显示发送对象
            List<MessageToUser> listMessage = MessageToUserManager.GetMessageToUserByMessageId(messageId);//得到消息发布对象
            if (listMessage.Count > 0)
            {
                IList<UserInfo> listUser = UserInfoManager.GetUserInfoAll();//所有人用户信息
                if (listUser.Count - listMessage.Count != 1)
                {

                    foreach (MessageToUser messages in listMessage)
                    {
                        hlReceiveUsers.Text += messages.ToUser.UserName + " ";//得到消息发布对象
                    }
                }
                else
                {
                    hlReceiveUsers.Text = "所有人";
                }

                if (message.MessageType.Id == 1)
                {
                    e.Row.Cells[4].Text = "***一般***";
                }
                else
                {
                    e.Row.Cells[4].Text = "<font color=red>" + "***紧急***" + "</font>";
                }
            }
            //光棒效果
            e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#00a3ff'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");
            HyperLink hlMessageContent = (HyperLink)e.Row.FindControl("hlMessageContent");
            hlMessageContent.NavigateUrl = "~/Message/MessageManage/MessageAdd.aspx?Id=" + messageId;
            if (hlReceiveUsers.Text.Length > 7)
            {
                hlReceiveUsers.Text = hlReceiveUsers.Text.Substring(0, 7) + "...";
            }
        }
        #endregion
    }
}

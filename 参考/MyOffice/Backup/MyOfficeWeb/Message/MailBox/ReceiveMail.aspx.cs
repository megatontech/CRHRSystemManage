using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MyOffice.BLL;
using MyOffice.Models;

public partial class Message_MailBox_ReceiveMail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            UserInfo user = new UserInfo();
            if (Session["User"] != null)
            {
                user = (UserInfo)Session["User"];
                DisplayReceiveMessageInfo(user.Id);//显示个人消息基本信息
            }           
        }
    }

    protected void DisplayReceiveMessageInfo(int userId)
    {
        List<MessageToUser> messages = MessageToUserManager.GetMessageToUserByUserInfoId(userId);
        if (messages.Count > 0)
        {
            btnSelectAll.Disabled = false;
            btnDelete.Disabled = false;
           
        }
        else
        {
            btnSelectAll.Disabled = true;
            btnDelete.Disabled = true;           
        }
        gvPersonMessageInfo.DataSource = messages;
        gvPersonMessageInfo.DataBind();
    }

    protected void btnReturn_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("MailBox.aspx");
    }
    protected void btnDelete_ServerClick(object sender, EventArgs e)
    {
        UserInfo user = (UserInfo)Session["User"];
        bool result = false;
        foreach (GridViewRow gvr in gvPersonMessageInfo.Rows)
        {
            CheckBox chkSelect = (CheckBox)gvr.FindControl("chkSelect");
            //如果选中了则删除
            if (chkSelect.Enabled == true && chkSelect.Checked == true)
            {
                string Id = gvPersonMessageInfo.DataKeys[gvr.RowIndex].Value.ToString();
                result = MessageToUserManager.DelectMessageToUserById(int.Parse(Id));
            }
        }
        //如果删除成功，则重新绑定个人消息
        if (!result)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "str", "<script>alert('删除失败！！')</script>", false);
        }       
        DisplayReceiveMessageInfo(user.Id);
    }
    protected void gvPersonMessageInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        #region 绑定GridView基本项
        if (e.Row.RowType == DataControlRowType.DataRow)//判断行类型
        {
            UserInfo user = (UserInfo)Session["User"];

            int Id = int.Parse(gvPersonMessageInfo.DataKeys[e.Row.RowIndex].Value.ToString());
            int messageId = MessageToUserManager.GetMessageToUserById(Id).Message.Id;
            Message message = MessageManager.GetMessageById(messageId);

            if (message.MessageType.Id == 1)
            {
                e.Row.Cells[5].Text = "***一般***";
            }
            else
            {
                e.Row.Cells[5].Text = "<font color=red>" + "***紧急***" + "</font>";
            }

            CheckBox chkSelect = (CheckBox)e.Row.FindControl("chkSelect");


            Image imgMessage = (Image)e.Row.FindControl("imgMessage");

            List<MessageToUser> messageToUsers = MessageToUserManager.GetMessageToUserByMessageId(messageId);
            foreach (MessageToUser messageToUser in messageToUsers)
            {
                if (messageToUser.ToUser.Id == user.Id)
                {
                    int count = Convert.ToInt32(messageToUser.IfRead);//查看是否用户已经读信息
                    if (count == 0)
                    {
                        imgMessage.ImageUrl = "~/images/new.gif";
                    }
                    else
                    {
                        imgMessage.ImageUrl = "~/images/old.gif";
                    }
                }
            }
            HyperLink hlMessageContent = (HyperLink)e.Row.FindControl("hlMessageContent");
            hlMessageContent.NavigateUrl = "javascript:ScanMessageDetail('" + Id + "')";

            //光棒效果
            e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#00a3ff'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");
        }
        #endregion
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
}

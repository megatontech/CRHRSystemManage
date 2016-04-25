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
public partial class Message_MessageManage_MessageContent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
           
            string messageId = Request.Params["messageid"].ToString();       
           
            List<MessageToUser> listMessage = MessageToUserManager.GetMessageToUserByMessageId(int.Parse(messageId));//得到消息发布对象

            IList<UserInfo> listUser = UserInfoManager.GetUserInfoAll();//所有人用户信息

            if (listUser.Count - listMessage.Count != 1)
            {
                foreach (MessageToUser toUser in listMessage)
                {
                    this.lblToUserName.Text += toUser.ToUser.UserName + "  ";
                    this.txtMessageContent.Value = toUser.Message.MessageContent;
                    this.lblTitle.Text = toUser.Message.Title;
                }
            }
            else
            {
                this.lblToUserName.Text = "所有人";
                foreach (MessageToUser toUser in listMessage)
                {
                   
                    this.txtMessageContent.Value = toUser.Message.MessageContent;
                    this.lblTitle.Text = toUser.Message.Title;

                }
            }
        }
    }
}

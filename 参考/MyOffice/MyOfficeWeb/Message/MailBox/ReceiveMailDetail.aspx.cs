using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MyOffice.BLL;
using MyOffice.Models;

public partial class Message_MailBox_ReceiveMailDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.Params["Id"] != null)
            {
                int Id = int.Parse(Request.Params["Id"].ToString());//获得当前消息Id
                GetMessage(Id);
            }
            else
            {
                //GetMessage(6);

            }
        }
    }
    public void GetMessage(int id)
    {
        MessageToUser messageToUser = MessageToUserManager.GetMessageToUserById(id);
        lblTitle.Text = messageToUser.Message.Title;
        lblType.Text = "**" + messageToUser.Message.MessageType.MessageTypeName + "**";
        txtContent.Value = messageToUser.Message.MessageContent;
        lblFromUser.Text = messageToUser.Message.FromUser.UserName;
        lblSendTime.Text = messageToUser.Message.RecordTime.ToString();

        messageToUser.IfRead = 1;
       
        MessageToUserManager.ModifyMessageToUserIfReadById(messageToUser.Id,messageToUser.IfRead);
       
    }
}

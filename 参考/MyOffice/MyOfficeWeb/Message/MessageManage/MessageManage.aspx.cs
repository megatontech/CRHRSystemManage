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
using System.Drawing;
public partial class Message_MessageManage_MessageManage : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["StartDate"] = "2008-01-01";
            ViewState["EndDate"] = DateTime.Now.ToShortDateString();
            BindGridView(StartDate, EndDate);
        }
    }
    public DateTime StartDate
    {
        get { return Convert.ToDateTime(ViewState["StartDate"]); }
        set { ViewState["StartDate"] = value; }
    }
    public DateTime EndDate
    {
        get { return Convert.ToDateTime(ViewState["EndDate"]); }
        set { ViewState["EndDate"] = value; }
    }
    //查询一部分时间内的订单
    protected void imgbtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        StartDate = Convert.ToDateTime(this.txtBeginTime.Text);//得到开始时间
        EndDate = Convert.ToDateTime(this.txtEndTime.Text);//得到结束时间
        BindGridView(StartDate, EndDate);
    }
    /// <summary>
    /// 数据连接类
    /// </summary>
    public void BindGridView(DateTime beginTime, DateTime endTime)
    {
        int userId = 0;
        if (Session["User"] != null)
        {
            UserInfo user = (UserInfo)Session["User"];//获得登录用户
            userId = user.Id;
        }
        PagedDataSource pdsList = new PagedDataSource();
        List<Message> list = null;
       
        list = MessageManager.GetMessageByDateTimeAndUserId(beginTime, endTime, userId);
        if (list.Count > 0)
        {
           
            pdsList.DataSource = list;
            pdsList.AllowPaging = true;//数据源允许分页
            pdsList.PageSize = this.anpPager.PageSize;//取控件的分页大小
            pdsList.CurrentPageIndex = this.anpPager.CurrentPageIndex - 1;//显示当前页
            //设置控件
            this.anpPager.RecordCount = list.Count;//记录总数
            this.anpPager.PageSize = 10;
            this.gvMessage.DataSource = pdsList;
            this.gvMessage.DataBind();
            this.lblMessage.Visible = false;
        }
        else 
        {
            this.lblMessage.Visible = true;
        }
    }

    //光棒效果
    protected void gvMessage_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //光棒效果
        if (e.Row.RowType == DataControlRowType.DataRow)//判断行类型
        {
            e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#00a3ff'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");

            e.Row.Cells[9].Attributes.Add("onclick", "return confirm('确定要删除吗？');");

            string messageId = gvMessage.DataKeys[e.Row.RowIndex].Value.ToString();//得到消息id
            List<MessageToUser> listMessage = MessageToUserManager.GetMessageToUserByMessageId(int.Parse(messageId));//得到消息发布对象

            if (listMessage.Count > 0)
            {
                IList<UserInfo> listUser = UserInfoManager.GetUserInfoAll();//所有人用户信息


                if (listUser.Count - listMessage.Count != 1)
                {
                    foreach (MessageToUser messages in listMessage)
                    {
                        e.Row.Cells[4].Text += messages.ToUser.UserName + " ";//得到消息发布对象
                    }
                }
                else
                {
                    e.Row.Cells[4].Text = "所有人";
                }

                HyperLink hlUserName = (HyperLink)e.Row.FindControl("hlUserName");//判断发送对象是不是所有人(0)

                HyperLink hlMessageContent = (HyperLink)e.Row.FindControl("hlMessageContent");              
                hlMessageContent.NavigateUrl = "javascript:ScanMessageDetail('" + messageId + "')";

                Message message = MessageManager.GetMessageById(int.Parse(messageId));
                int ispublish = message.IfPublish;
                Button btnIsPublish = (Button)e.Row.FindControl("btnIsPublish");//发布按钮是否可用

                ImageButton imgbtnUpdate = (ImageButton)e.Row.FindControl("imgbtnUpdate");//实例化image按钮控件

                ImageButton imgbtnDelete = (ImageButton)e.Row.FindControl("imgbtnDelete");//实例化image按钮控件
             
                if (ispublish == 1)
                {
                    btnIsPublish.Enabled = false;                   
                    imgbtnUpdate.Enabled = false;
                    imgbtnDelete.Enabled = false;
                    imgbtnUpdate.BackColor = Color.Gray;
                    imgbtnDelete.BackColor = Color.Gray;
                   
                }
                else
                {
                    btnIsPublish.Enabled = true;
                   
                }
            }
            else 
            {
                e.Row.Cells[4].Text = "对象已删除";
            }
        }
        if (e.Row.Cells[4].Text.Length > 7)
        {
            e.Row.Cells[4].Text= e.Row.Cells[4].Text.Substring(0, 7) + "...";
        }
        
    }
    //设置分页控件
    protected void anpPager_PageChanged(object sender, EventArgs e)
    {
        BindGridView(StartDate, EndDate);
    }    
    protected void gvMessage_RowCommand(object sender, GridViewCommandEventArgs e)
    {        
        if (e.CommandName == "messageModify")//修改该行的消息,将消息传到修改页面
        {
            ImageButton imagebtn = (ImageButton)e.CommandSource;
            int messageId = int.Parse(imagebtn.CommandArgument);//得到当前点击行的ID
            //string Id = e.CommandArgument.ToString();//根据关联参数得到部门id值
            Response.Redirect("MessageAdd.aspx?Id=" + messageId + "");
        }
        else if (e.CommandName == "messageDelete")//删除该行的消息
        {
            ImageButton imagebtn = (ImageButton)e.CommandSource;
            int messageId = int.Parse(imagebtn.CommandArgument);//得到当前点击行的ID
            //int Id = int.Parse(e.CommandArgument.ToString());//根据关联参数得到消息id值
            #region 原版删除方式
            //if (MessageManager.GetMessageById(messageId).IfPublish == 0)//删除没有发布的消息
            //{
            //    if (MessageToUserManager.GetMessageToUserByMessageId(messageId).Count>0)//如果有发送对象就删除对象的消息
            //    {
            //        MessageToUserManager.DelectMessageToUserByMessageId(messageId);
            //    }           
            //    bool bl = MessageManager.DelectMessageById(messageId);//再删除选定的消息
            //    if (bl)
            //    {

            //        ScriptManager.RegisterStartupScript(this, this.GetType(), "str", "<script>alert('删除信息成功')</script>", false);
            //        //添加操作日志
            //        UserInfo user = (UserInfo)Session["user"];
            //        OperateLog operateLog = new OperateLog();
            //        operateLog.User = user;
            //        operateLog.OperateName = "删除";
            //        operateLog.OperateDesc = "删除消息";
            //        operateLog.OperateTime = DateTime.Now;
            //        bool b2 = OperateLogManager.AddOperateLog(operateLog);
            //    }
            //    else
            //    {
            //        ScriptManager.RegisterStartupScript(this, this.GetType(), "str", "<script>alert('删除失败！！')</script>", false);
            //    }
               
            //}
            //else //发布后的修改为已删除状态
            //{
            //    bool b = MessageManager.ModifyMessageIsDeleteById(messageId,1);
            //    if (b) 
            //    {
            //        //添加操作日志
            //        UserInfo user = (UserInfo)Session["user"];
            //        OperateLog operateLog = new OperateLog();
            //        operateLog.User = user;
            //        operateLog.OperateName = "删除";                
            //        operateLog.OperateDesc = "删除消息";
            //        operateLog.OperateTime = DateTime.Now;
            //        bool b1=OperateLogManager.AddOperateLog(operateLog);
            //    }
            //}
           #endregion
            bool b = MessageManager.ModifyMessageIsDeleteById(messageId, 1);//只是将这条消息的是否删除的状态改为“是”而已
            if (b)
            {
                //添加操作日志
                UserInfo user = (UserInfo)Session["user"];
                OperateLog operateLog = new OperateLog();
                operateLog.User = user;
                operateLog.OperateName = "删除";
                operateLog.OperateDesc = "删除消息";
                operateLog.OperateTime = DateTime.Now;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "str", "<script>alert('删除信息成功')</script>", false);
                bool b1 = OperateLogManager.AddOperateLog(operateLog);
            }
            BindGridView(StartDate, EndDate);
        }
        else if (e.CommandName == "publish")//发布该行的消息,需要选择发布的对象(1,所有人)
        {
            Button imagebtn = (Button)e.CommandSource;
            int messageId = int.Parse(imagebtn.CommandArgument);//得到当前点击行的ID
            UpdateMessage(messageId);//发布该行的消息
           
        }        
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
    /// <summary>
    /// 发布消息
    /// </summary>
    /// <param name="messageId">消息ID</param>
    public void UpdateMessage(int messageId)
    {
        bool b = MessageManager.ModifyMessageIsPublishById(messageId, 1);//1,true;0,False
        if (b)//若发布成功则重新显示消息信息
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "str", "<script>alert('发布信息成功！！')</script>", false);
            //添加操作日志
            UserInfo user = (UserInfo)Session["user"];
            OperateLog operateLog = new OperateLog();
            operateLog.User = user;
            operateLog.OperateName = "发布";           
            operateLog.OperateDesc = "发布消息";
            operateLog.OperateTime = DateTime.Now;
            bool b1 = OperateLogManager.AddOperateLog(operateLog);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "str", "<script>alert('发布信息失败！！')</script>", false);
        }
        BindGridView(StartDate, EndDate);
    }
}

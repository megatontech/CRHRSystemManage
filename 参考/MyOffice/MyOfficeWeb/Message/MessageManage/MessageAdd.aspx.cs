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
using System.Collections.Generic;
using MyOffice.BLL;
using MyOffice.Models;

public partial class Message_MessageManage_MessageAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //if(Session["user"] != null)
            LoadBranch();//加载机构下拉菜单
            LoadDepart(int.Parse(this.ddlBranchs.SelectedValue));//根据选定的机构ID加载部门下拉菜单
            if (Request.QueryString["Id"] != null)
            {
                SelectMessageById(int.Parse(Request.QueryString["Id"].ToString()));
                this.rdolstToUser.Enabled = false;               
            }
        }
    }
    #region 发布消息时弹出pnlMessage
    /// <summary>
    /// 查询机构信息
    /// </summary>
    protected void LoadBranch()
    {
        IList<BranchInfo> branchs = BranchInfoManger.GetBranchInfo();
        ddlBranchs.Items.Clear();
        ddlBranchs.Items.Add(new ListItem("==请选择==", "0"));
        foreach (BranchInfo branch in branchs)
        {
            ListItem li = new ListItem();
            li.Value = branch.Id.ToString();
            li.Text = branch.BranchName;
            ddlBranchs.Items.Add(li);
        }
    }
    /// <summary>
    /// 查询部门信息
    /// </summary>
    /// <param name="branchId"></param>
    protected void LoadDepart(int branchId)
    {
        IList<DepartInfo> departs = DepartInfoManager.GetDepartInfoByBranchId(branchId);
        ddlDeparts.Items.Clear();
        ddlDeparts.Items.Add(new ListItem("==请选择==", "0"));
        foreach (DepartInfo depart in departs)
        {
            ListItem li = new ListItem();
            li.Value = depart.Id.ToString();
            li.Text = depart.DepartName;
            ddlDeparts.Items.Add(li);
        }
    }
    /// <summary>
    /// 复选框选定
    /// </summary>
    public void ControlEnabled()
    {
        if (this.chkBranch.Checked)
            this.ddlBranchs.Enabled = true;
        else
            this.ddlBranchs.Enabled = false;

        if (this.chkDepart.Checked)
            this.ddlDeparts.Enabled = true;
        else
            this.ddlDeparts.Enabled = false;

        if (this.chkUserName.Checked)
            this.txtName.Enabled = true;
        else
            this.txtName.Enabled = false;
    }
    //根据选定的机构ID加载部门下拉菜单
    protected void ddlBranchs_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadDepart(int.Parse(this.ddlBranchs.SelectedValue));//根据选定的机构ID加载部门下拉菜单
        ControlEnabled();//复选框选定
    }
    #endregion
    //保存信息
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["Id"] == null)
        {

            AddMessage(0);
        }
        else
        {
            UpdateMessage(0);
        }
    }
    /// <summary>
    /// 添加新消息
    /// </summary>
    public void AddMessage(int ifPublish)
    {
        if (DateTime.Parse(txtBeginTime.Text) > DateTime.Now)
        {
            Message message = new Message();
            message.Title = txtTitle.Text.ToString();
            message.MessageContent = txtMessageContent.Text.ToString();
            message.BeginTime = DateTime.Parse(txtBeginTime.Text);
            message.EndTime = DateTime.Parse(txtEndTime.Text);
            message.IfPublish = ifPublish;
            message.RecordTime = DateTime.Parse(DateTime.Now.ToString());
            message.IsDelete = 0;

            MessageType mt = new MessageType();
            mt.Id = int.Parse(this.ddlMessageTypeName.SelectedValue);
            message.MessageType = mt;

            UserInfo user = new UserInfo();
            if (Session["user"] == null)
            {
                user.Id = 1;
            }
            else
            {
                user = (UserInfo)Session["user"];//获得登录用户 
            }
            message.FromUser = user;

            int MId = MessageManager.AddMessage(message);//添加新消息
            if (MId > 0)
            {
                if (rdolstToUser.SelectedValue == "0") //0表示所有人
                {

                    #region 添加公共消息
                    bool result = false;
                    MessageToUser messageToUser = new MessageToUser();

                    Message messageId = new Message();
                    messageId.Id = MId;
                    messageToUser.Message = messageId;
                    messageToUser.IfRead = 0; //默认为未读
                    IList<UserInfo> list = UserInfoManager.GetUserInfoAll();//所有人用户信息
                    foreach (UserInfo u in list)
                    {
                        if (u.Id != user.Id)
                        {
                            messageToUser.ToUser = u;
                            result = MessageToUserManager.AddMessageToUser(messageToUser);
                        }
                    }
                    if (result)
                    {
                        Response.Redirect("MessageManage.aspx");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "str", "<script>alert('添加失败！！')</script>", false);

                    }

                    # endregion
                }
                else
                {
                    #region 添加特定消息

                    bool result = false;
                    //循环为每一个发送对象插入记录
                    foreach (ListItem li in chkblstUserName.Items)
                    {
                        if (li.Selected)
                        {
                            if (li.Value != message.FromUser.Id.ToString())//不能发送给自己
                            {
                                MessageToUser messageToUser = new MessageToUser();
                                Message messageId = new Message();
                                messageId.Id = MId;
                                messageToUser.Message = messageId;
                                UserInfo userInfo = new UserInfo();
                                userInfo.Id = int.Parse(li.Value);
                                messageToUser.ToUser = userInfo;

                                messageToUser.IfRead = 0; //默认为未读
                                messageToUser.IsDelete = 0;
                                result = MessageToUserManager.AddMessageToUser(messageToUser);
                            }
                        }
                    }
                    if (result)
                    {
                        Response.Redirect("MessageManage.aspx");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "str", "<script>alert('添加失败！！')</script>", false);
                    }

                    #endregion
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "str", "<script>alert('添加失败！！')</script>", false);

            }
        }
        else 
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "str", "<script>alert('开始时间已过时，没意义！！')</script>", false);
        }
    }
    /// <summary>
    /// 修改消息
    /// </summary>
    public void UpdateMessage(int ifPublish)
    {
        Message message = new Message();
        message.Id = int.Parse( Request.QueryString["Id"]);
        message.Title = txtTitle.Text.ToString();
        message.MessageContent = txtMessageContent.Text.ToString();
        message.BeginTime = DateTime.Parse(txtBeginTime.Text);
        message.EndTime = DateTime.Parse(txtEndTime.Text);
        message.IfPublish = ifPublish;
        message.RecordTime = DateTime.Parse(DateTime.Now.ToShortDateString());
        message.IsDelete = 0;
        MessageType mt = new MessageType();
        mt.Id = int.Parse(this.ddlMessageTypeName.SelectedValue);
        message.MessageType = mt;
        UserInfo user = (UserInfo)Session["user"];//获得登录用户
        message.FromUser = user;

        bool b = MessageManager.ModifyMessageById(message);
        if (b) 
        {
            Response.Redirect("MessageManage.aspx");
        }
       
    }
    /// <summary>
    /// 根据ID查询消息
    /// </summary>
    /// <param name="Id">编号</param>
    public void SelectMessageById(int id)
    {
        Message message = new Message();
        message = MessageManager.GetMessageById(id);
        this.txtTitle.Text = message.Title;
        txtMessageContent.Text = message.MessageContent;
        txtBeginTime.Text = message.BeginTime.ToString();
        txtEndTime.Text = message.EndTime.ToString();
        this.ddlMessageTypeName.SelectedValue = message.MessageType.Id.ToString();
    }
    //返回
    protected void btnEnd_Click(object sender, EventArgs e)
    {
        Response.Redirect("MessageManage.aspx");
    }
    protected void rdolstToUser_SelectedIndexChanged(object sender, EventArgs e)
    {
        #region 不同情况选择查询条件
        if (rdolstToUser.SelectedValue == "0")
        {
            pnlMessage_1.Visible = false;
            pnlUserName.Visible = false;
        }
        else
        {
            pnlMessage_1.Visible = true;
        }        
        #endregion
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        #region 将按机构,部门,姓名查询到的姓名添加到复选框
        chkblstUserName.Items.Clear();
        pnlMessage_1.Visible = false;
        pnlUserName.Visible = true;
        string userName = "";
        int departId = 0;
        int branchId = 0;
        userName = this.txtName.Text.Trim();//姓名
        if (ddlDeparts.SelectedValue != "0")
        {
            departId = int.Parse(ddlDeparts.SelectedValue);//部门
        }
        if (ddlBranchs.SelectedValue != "0")
        {
            branchId = int.Parse(ddlBranchs.SelectedValue);//机构
        }
        List<UserInfo> users = UserInfoManager.GetUserInfoByUserNameAndDepartIdAndBranchId(userName,departId,branchId);
        chkblstUserName.Items.Clear();
        foreach (UserInfo user in users)
        {
            ListItem li = new ListItem();
            li.Value = user.Id.ToString();
            li.Text = user.UserName;
            chkblstUserName.Items.Add(li);//将姓名添加到复选框
        }
        int i=chkblstUserName.Items.Count;
        #endregion
    }
    //直接发布
    protected void btnPublish_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["Id"] == null)
        {

            AddMessage(1);
        }
        else
        {
            UpdateMessage(1);
        }
    }
}

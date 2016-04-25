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

public partial class ScheduleManage_PersonSchedule_SaveMySchedule : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetUserandTime();//得到创建者和创建时间     
            TreeViewInfo(); //员工的详细信息     
            if (Request.QueryString["userid"] == null)
            {
                this.btnDeletePreContract.Enabled = false;
            }
            this.btnDelete.Enabled = false;  //删除控件是不可用的
            GetScheduleInfoAll();//从PersonSchedule.aspx中传值到SaveMySchedule.aspx页面中看是否有值
        }
    }

    //添加日程
    protected void btnadd_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            //如果添加日程时小于当天的时间就不可以添加日程
            //判断一下添加日程的时间是否小于当天的时间
            if (DateTime.Parse(txtBeginTime.Text) >= DateTime.Now)
            {
                Schedule schedule = new Schedule(); //日程信息
                schedule.Title = this.txtTitle.Text.Trim();//标题
                schedule.Address = this.txtAddress.Text.Trim();//地址
                schedule.BeginTime = DateTime.Parse(this.txtBeginTime.Text.Trim());//开始时间
                schedule.EndTime = DateTime.Parse(this.txtEndTime.Text.Trim());//结束时间
                MeetingInfo meetingInfo = new MeetingInfo(); //会议信息
                meetingInfo.Id = int.Parse(this.ddlMeeting.SelectedValue.ToString());//会议名称

                schedule.Meeting = meetingInfo;
                schedule.SchContent = this.txtContent.Text.Trim();//内容
                schedule.CreateUserId = (UserInfo)Session["user"];
                schedule.CreateTime = DateTime.Now;
                if (this.ckbIfPirvate.Checked)  //判断复选框是否被选中
                {
                    schedule.IfPrivate = 1; //公开
                }
                else
                {
                    schedule.IfPrivate = 0; //隐藏
                }

                if (Request.QueryString["scheduleId"] != null)
                {
                    schedule.Id = int.Parse(Request.QueryString["scheduleId"]);


                    ScheduleManager.ModifySchedule(schedule);  //修改日程       
                    PreContract pre = new PreContract();
                    pre.Schedule = schedule;
                    //根据日程ID查询预约信息
                    IList<PreContract> list = PreContractManager.GetPreContractByScheduleID(int.Parse(Request.QueryString["scheduleId"]));
                    ArrayList userIds = new ArrayList();
                    //循环将节点添加到ArrayList中
                    foreach (PreContract preContract in list)
                    {
                        userIds.Add(preContract.User.Id.ToString());
                    }
                    foreach (ListItem item in lstbPreContract.Items)  //预约人表
                    {
                        if (!userIds.Contains(item.Value))
                        {
                            UserInfo userInfo = new UserInfo();
                            userInfo.Id = int.Parse(item.Value);
                            pre.User = userInfo;
                            bool result = PreContractManager.AddPreContract(pre);
                        }
                    }
                    ArrayList userIdsByListItem = new ArrayList();
                    foreach (ListItem item in lstbPreContract.Items)  //预约人表
                    {
                        userIdsByListItem.Add(item.Value);
                    }
                    foreach (string Id in userIds)  //预约人表
                    {
                        if (!userIdsByListItem.Contains(Id))
                        {
                            UserInfo userInfo = new UserInfo();
                            userInfo.Id = int.Parse(Id);
                            pre.User = userInfo;
                            bool b = PreContractManager.DeletePreContractByIdAndUserId(pre); //删除预约人
                        }
                    }

                    Response.Redirect("PersonSchedule.aspx"); //重定向到日历显示日程的界面
                }
                else
                {
                    this.btnDelete.Enabled = false;
                    bool b = ScheduleManager.GetScheduleByPreContract(schedule.BeginTime, schedule.EndTime, ((UserInfo)Session["user"]).Id);
                    if (b)
                    {
                        schedule.Id = ScheduleManager.AddSchedule(schedule);  //添加日程
                        if (schedule.Id > 0)
                        {
                            foreach (ListItem item in lstbPreContract.Items)  //预约人表
                            {
                                UserInfo userInfo = new UserInfo();
                                userInfo.Id = int.Parse(item.Value);
                                PreContract pre = new PreContract();
                                pre.Schedule = schedule;
                                pre.User = userInfo;
                                bool result = PreContractManager.AddPreContract(pre); //添加预约人
                                if (result)
                                {
                                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "str", "<script>alert(\"预约人添加成功！！\")</script>");
                                }
                                else
                                {
                                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "str", "<script>alert(\"预约人添加失败！！\")</script>");
                                }
                            }
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "消息", "<script>alert('++++添加成功++++！');location='PersonSchedule.aspx'</script>", false);
                            Response.Redirect("~/ScheduleManage/PersonSchedule/PersonSchedule.aspx");
                        }
                        else
                        {
                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "str", "<script>alert(\"添加失败！！\")</script>");
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "消息", "<script>alert('您已经有预约了~~')</script>", false);
                    }
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "消息", "<script>alert('时间已经过时了，无法编辑！');location='PersonSchedule.aspx'</script>", false);
            }
        }

    }
    //展开节点
    //protected void imgbtnPreContract_Click(object sender, ImageClickEventArgs e)
    //{
    //    this.divPrecontract.Visible = true;
    //}

    //得到创建者和创建时间
    public void GetUserandTime()
    {
        if (Session["user"] != null)
        {
            //显示创建人和创建时间
            UserInfo userInfo = (UserInfo)Session["user"];
            string name = userInfo.UserName;
            this.lblName.Text = name;
            string time = DateTime.Now.ToString();
            this.lblTime.Text = time;
        }
    }

    //TreeView 员工的详细信息
    public void TreeViewInfo()
    {
        //得到预约人[机构，部门和员工]
        IList<BranchInfo> list = BranchInfoManger.GetBranchInfo();
        if (list.Count > 0)
        {
            foreach (BranchInfo branchInfo in list)
            {
                TreeNode nodeTemp = new TreeNode();
                nodeTemp.ImageUrl = "~/images/menuclose.gif";
                nodeTemp.Text = branchInfo.BranchName;
                nodeTemp.Value = branchInfo.Id.ToString();

                //根据机构ID得到部门信息
                IList<DepartInfo> departList = DepartInfoManager.GetDepartInfoByBranchId(int.Parse(nodeTemp.Value));
                foreach (DepartInfo depart in departList)
                {
                    TreeNode child = new TreeNode();
                    child.ImageUrl = "~/images/CloseTree.gif";
                    child.Text = depart.DepartName;
                    child.Value = depart.Id.ToString();

                    //把部门添加到机构中
                    nodeTemp.ChildNodes.Add(child);

                    //根据部门ID得到员工信息
                    IList<UserInfo> userList = UserInfoManager.GetUserInfoByDepartId(int.Parse(child.Value));
                    foreach (UserInfo user in userList)
                    {
                        TreeNode node = new TreeNode();
                        node.ImageUrl = "~/images/person.gif";
                        node.Text = user.UserName;
                        node.Value = user.Id.ToString();

                        //把员工添加到相应部门中
                        child.ChildNodes.Add(node);
                    }
                }
                //把机构添加到TreeView中显示..
                trvPreContract.Nodes.Add(nodeTemp);
                trvPreContract.ExpandAll();
            }
        }
    }

    //显示树的点击事件
    protected void trvPreContract_SelectedNodeChanged(object sender, EventArgs e)
    {
        TreeNode node = trvPreContract.SelectedNode;

        string userName = node.Text;
        UserInfo user = new UserInfo();
        int userId = UserInfoManager.GetUserByUserName(userName);  //根据用户名查找用户 和选中的节点比较
        if (((UserInfo)Session["user"]).Id == userId)
        {
            //如果添加的预约人事自己就给出提示信息
            ScriptManager.RegisterStartupScript(this, this.GetType(), "消息", "<script>alert('您不能和自己预约！')</script>", false);  //
        }
        else
        {
            if (userId == int.Parse(node.Value))   //如果查找到该用户和节点相等就添加到里面
            {
                this.btnDeletePreContract.Enabled = true;
                string noteText = node.Parent.Text + "--" + node.Text;//得到部门和员工
                string Id = node.Value;

                foreach (ListItem item in lstbPreContract.Items)
                {
                    if (item.Text.Equals(noteText))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "消息", "<script>alert('该用户已经预约了~~')</script>", false);
                        return;
                    }
                }
                ListItem listItem = new ListItem();
                listItem.Text = noteText;
                listItem.Value = Id;
                this.lstbPreContract.Items.Add(listItem);
                //this.divPrecontract.Visible = false;
            }
            else
            {
                //提示
                ScriptManager.RegisterStartupScript(this, this.GetType(), "消息", "<script>alert('您选择的不是员工，请重新选折')</script>", false);
            }
        }
    }

    //删除选定的预约人
    int index;
    protected void btnDeletePreContract_Click(object sender, EventArgs e)
    {
        this.lstbPreContract.Items.RemoveAt(index);
    }
    protected void lstbPreContract_SelectedIndexChanged(object sender, EventArgs e)
    {
        index = this.lstbPreContract.SelectedIndex;
    }

    //传值过来看是否有值
    public void GetScheduleInfoAll()
    {
        if (Request.QueryString["scheduleId"] != null)
        {
            int scheduleId = int.Parse(Request.QueryString["scheduleId"]);
            UserInfo user = (UserInfo)Session["user"];
            bool b = PreContractManager.GetPreContractByUserandSchedule(user.Id, scheduleId);//根据创建人Id和日程Id的预约人信息
            if (b) //如果是查看被预约的信息，则相应的控件都是不可用的[无法对其进行编辑]
            {
                this.txtTitle.Enabled = false;
                this.txtAddress.Enabled = false;
                this.ddlMeeting.Enabled = false;
                this.txtBeginTime.Enabled = false;
                this.txtEndTime.Enabled = false;
                this.txtContent.Enabled = false;
                this.lstbPreContract.Enabled = false;
                //this.imgbtnPreContract.Enabled = false;
                this.btnDeletePreContract.Enabled = false;
                this.btnadd.Enabled = false;
                this.btnDelete.Enabled = false;
                this.ckbIfPirvate.Enabled = false;
                //根据日程Id查询日程
                Schedule schedule = ScheduleManager.GetScheduleById(scheduleId);
                this.lblName.Text = schedule.CreateUserId.UserName;
            }
            else
            {
                this.btnDelete.Enabled = true;
            }

            //根据日程Id得到预约人
            IList<PreContract> list = PreContractManager.GetPreContractByScheduleID(scheduleId);
            foreach (PreContract preContract in list)
            {
                ListItem li = new ListItem();
                string aa = preContract.User.Depart.DepartName + "--" + preContract.User.UserName; //循环将部门和预约人添加到ListBox控件中
                li.Text = aa;
                li.Value = preContract.User.Id.ToString();
                this.lstbPreContract.Items.Add(li);

                txtTitle.Text = preContract.Schedule.Title;
                txtAddress.Text = preContract.Schedule.Address;
                txtBeginTime.Text = preContract.Schedule.BeginTime.ToString();
                txtEndTime.Text = preContract.Schedule.EndTime.ToString();
                ddlMeeting.SelectedValue = preContract.Schedule.Meeting.Id.ToString();
                txtContent.Text = preContract.Schedule.SchContent;
                lblTime.Text = preContract.Schedule.CreateTime.ToString();

                //判断该日程是否公开
                if (preContract.Schedule.IfPrivate == 1)
                {
                    this.ckbIfPirvate.Checked = true;
                }
                else
                {
                    this.ckbIfPirvate.Checked = false;
                }
            }
        }
    }

    //删除我的日程的方法
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        if (DateTime.Parse(txtBeginTime.Text) >= DateTime.Now) //小于当天的时间就不可以添加日程
        {
            int scheduleId = int.Parse(Request.QueryString["scheduleId"]);
            bool b = ScheduleManager.DeleteScheduleById(scheduleId);
            if (b)
            {
                Response.Redirect("PersonSchedule.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "消息", "<script>alert('删除失败。。。')</script>", false);
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "消息", "<script>alert('时间已经过时了，无法删除！');location='PersonSchedule.aspx'</script>", false);
        }
    }
    //退出【返回到上一页】
    protected void btnExit_Click(object sender, EventArgs e)
    {

        Response.Redirect("PersonSchedule.aspx");
    }
}

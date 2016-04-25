using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MyOffice.Models;
using MyOffice.DAL;
using MyOffice.BLL;


//http://www.51aspx.com/
public partial class ScheduleManage_DepartSchedule_DepartSchedule : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.txtDate.Text = DateTime.Now.ToShortDateString();
            LoadBranch();
        }
    }

    //根据不同的条件搜索部门日程信息
    protected void imgbtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        this.lblDateTime.Text = this.txtDate.Text;
        int branchId = int.Parse(this.ddlBranch.SelectedValue.ToString());
        int departId = int.Parse(this.ddlDepart.SelectedValue.ToString());
        string UserName = this.txtName.Text.Trim();
        DateTime date = Convert.ToDateTime(this.txtDate.Text);
        DateTime startWeek = date.AddDays(1 - Convert.ToInt32(date.DayOfWeek.ToString("d")) - 1);  //本周周一
        DateTime endWeek = startWeek.AddDays(6);  //本周周日
        DateTime startDate = Convert.ToDateTime(startWeek.ToShortDateString());
        DateTime endDate = Convert.ToDateTime(endWeek.ToShortDateString()).AddDays(1);

        IList<Schedule> list = ScheduleManager.GetScheduleBySelectedConditions(startDate, endDate, UserName, departId, branchId);

        if (list.Count > 0)
        {
            this.gvdepart.DataSource = list;
            this.gvdepart.DataBind();
            All(); //显示合并在一起的日程
            this.lblMessage.Visible = false;
        }
        else
        {
            lblMessage.Text = "暂无日程信息";
        }

    }

    /// <summary>
    /// 绑定显示农历时间和日历小图标
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void cldTime_DayRender(object sender, DayRenderEventArgs e)
    {
        UserInfo user = (UserInfo)Session["CurrentUser"];
        //自定义显示内容
        CalendarDay calDay = ((DayRenderEventArgs)e).Day;
        HyperLink lnkDate = new HyperLink();
        lnkDate.ImageUrl = "~/images/add_Schedule.gif";
        lnkDate.ToolTip = "新增个人日程";
        //获取表示呈现在控件中的单元格
        TableCell tc = ((DayRenderEventArgs)e).Cell;
        //农历转换对象
        CNDate dt = new CNDate(calDay.Date);
    }
    //获得机构名称
    protected void LoadBranch()
    {
        IList<BranchInfo> branchs = BranchInfoManger.GetBranchInfo(); //查询机构名称的方法
        ddlBranch.Items.Clear();
        ddlBranch.Items.Add(new ListItem("==请选择==", "0"));
        foreach (BranchInfo branch in branchs)
        {
            ListItem li = new ListItem();
            li.Value = branch.Id.ToString();
            li.Text = branch.BranchName;
            ddlBranch.Items.Add(li);
        }
    }
    //部门下拉框的信息
    protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.ddlDepart.Enabled = true;
        this.ddlDepart.Items.Clear(); //清空下拉列表框的值
        int branchId = int.Parse(this.ddlBranch.SelectedValue.ToString());
        this.ddlDepart.DataSourceID = null;
        IList<DepartInfo> Departlist = DepartInfoManager.GetDepartInfoByBranchId(branchId);//根据机构ID查询部门
        ddlDepart.Items.Clear();
        ddlDepart.Items.Add(new ListItem("==请选择==", "0"));
        foreach (DepartInfo depart in Departlist) //循环得到部门的信息
        {
            ListItem listItem = new ListItem();
            listItem.Value = depart.Id.ToString();
            listItem.Text = depart.DepartName;
            this.ddlDepart.Items.Add(listItem);
        }
        this.ddlDepart.DataBind();
    }
    protected void gvdepart_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        string selectDay = txtDate.Text + " 00:00:00";//得到选择的日期
        DateTime selectTime = DateTime.Parse(selectDay);
        int intWeek = 1 - Convert.ToInt32(selectTime.DayOfWeek) - 1;
        string strWeek = selectTime.AddDays(intWeek).ToShortDateString();//一周中各天所对应的日期
        DateTime weekDay = DateTime.Parse(strWeek + " 00:00:00");
        DateTime weekDay1 = DateTime.Parse(strWeek + " 00:00:00");
        if (e.Row.RowType == DataControlRowType.Header)//判断行类型是不是标头
        {
            //循环显示一周中各天所对应的日期
            for (int i = 1; i <= 7; i++)
            {


                if (weekDay.Month.ToString() == selectTime.Month.ToString())
                {
                    Label lblWeek = (Label)e.Row.FindControl("Label" + i + "");//实例化标题控件
                    lblWeek.Text = weekDay.Day.ToString();
                }
                weekDay = weekDay.AddDays(1);
            }
        }

        if (e.Row.RowType == DataControlRowType.DataRow)//判断行类型是不是数据行
        {
            int id = int.Parse(gvdepart.DataKeys[e.Row.RowIndex].Value.ToString());
            Schedule s = ScheduleManager.GetScheduleById(id); //根据ID查询日程
            Label lblUserName = e.Row.Cells[0].FindControl("lblUserName") as Label;
            lblUserName.Text = s.CreateUserId.UserName;
            //循环显示一周中各天所对应的日程内容
            for (int i = 1; i <= 7; i++)
            {
                int scheduleId = ScheduleManager.GetScheduleId(s.CreateUserId.Id, weekDay1);//根据用户Id和日期获得日程Id
                if (scheduleId != 0)
                {
                    Schedule schedule = ScheduleManager.GetScheduleById(scheduleId);  //根据日程Id获得日程信息              
                    HyperLink hl = (HyperLink)e.Row.Cells[0].FindControl("HyperLink" + i + "");//实例化内容控件
                    //指定HyperLink控件的文本属性
                    if (schedule.Title.Length > 3)
                    {
                        string str = schedule.Title.Substring(0, 3);
                        string date = schedule.CreateTime.ToShortTimeString();
                        hl.Text = "◎" + schedule.CreateTime.ToShortTimeString() + " " + schedule.Title.Substring(0, 3) + "...";
                    }
                    else
                    {
                        hl.Text = "◎" + schedule.CreateTime.ToShortTimeString() + " " + schedule.Title;
                    }
                    //指定HyperLink控件的超连接属性
                    hl.NavigateUrl = "../PersonSchedule/SaveMySchedule.aspx?userid=" + s.CreateUserId.Id + "&today=" + weekDay1 + "&scheduleId=" + scheduleId;
                }
                weekDay1 = weekDay1.AddDays(1);
            }
        }
    }
    //合并用户名相同的项
    public void All()
    {
        int x = 0;
        for (int i = x; i < gvdepart.Rows.Count - 1; i++)
        {
            gvdepart.Rows[i].Cells[0].RowSpan = 1;
            for (int j = i; j < gvdepart.Rows.Count; j++)
            {
                string a = (gvdepart.Rows[i].Cells[0].FindControl("lblUserName") as Label).Text;
                string b = (gvdepart.Rows[j].Cells[0].FindControl("lblUserName") as Label).Text;
                if (a == b)
                {
                    if (j != i)
                    {
                        gvdepart.Rows[i].Cells[0].RowSpan++;
                        gvdepart.Rows[j].Cells[0].Visible = false;
                    }
                    x++;
                }
                else
                {
                    break;
                }
            }
        }
    }
}















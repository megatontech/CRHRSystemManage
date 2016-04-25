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


public partial class ScheduleManage_PersonSchedule_PersonSchedule : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void calSchedule_DayRender(object sender, DayRenderEventArgs e)
    {
        UserInfo user = (UserInfo)Session["User"];
        //自定义显示内容
        CalendarDay calDay = ((DayRenderEventArgs)e).Day;
        //获取表示呈现在控件中的单元格
        TableCell tc = ((DayRenderEventArgs)e).Cell;
        //农历转换对象
        CNDate dt = new CNDate(calDay.Date);
        if (calDay.IsOtherMonth)
        {
            tc.Controls.Clear();
        }
        else
        {
            //显示日历控件的方法
            IList<Schedule> list = ScheduleManager.GetScheduleByUserIdandDate(user.Id, calDay.Date); //根据用户和时间查询日程的信息
            IList<PreContract> listPre = PreContractManager.GetPreContractByUserIdandDate(user.Id, calDay.Date);//根据用户和时间查询预约的信息
            HyperLink aHyperLink = new HyperLink();
            aHyperLink.ImageUrl = "~/images/add_Schedule.gif";
            aHyperLink.ToolTip = "新增个人日程";   //提示
            aHyperLink.NavigateUrl = "~/ScheduleManage/PersonSchedule/SaveMySchedule.aspx"; //路径
            tc.Controls.Add(new LiteralControl("&nbsp;" + "&nbsp;" + "&nbsp;"));
            tc.Controls.Add(aHyperLink);
            tc.Controls.Add(new LiteralControl("<br>" + dt.GetLunarHolDay())); //得日期
            if (list.Count > 0 || listPre.Count > 0)  //如果日程的集合和预约人的集合都存在则显示相应的信息
            {
                Schedule schedule = new Schedule();
                PreContract pre = new PreContract();
                if (list.Count > 0 && listPre.Count <= 0)
                {
                    schedule = list[0] as Schedule;
                    if (list.Count > 1)
                    {
                        ShowSchedule(user.Id, schedule.Id, schedule.BeginTime.ToShortTimeString(), schedule.Title, calDay.Date, tc);
                        showScheduleAll(user.Id, calDay.Date, tc);
                    }
                    else
                    {
                        ShowSchedule(user.Id, schedule.Id, schedule.BeginTime.ToShortTimeString(), schedule.Title, calDay.Date, tc);
                    }
                }
                else if (listPre.Count > 0 && list.Count <= 0)
                {
                    pre = listPre[0] as PreContract;
                    if (list.Count > 1)  //如果当天有多条的日程信息就显示到日历控件上
                    {
                        ShowSchedule(user.Id, pre.Schedule.Id, pre.Schedule.BeginTime.ToShortTimeString(), "被预约信息", calDay.Date, tc);
                        showScheduleAll(user.Id, calDay.Date, tc);
                    }
                    else
                    {
                        ShowSchedule(user.Id, pre.Schedule.Id, pre.Schedule.BeginTime.ToShortTimeString(), "被预约信息", calDay.Date, tc);
                    }
                }
                else
                {
                    schedule = list[0] as Schedule;
                    pre = listPre[0] as PreContract;
                    if (list.Count > 1 || listPre.Count > 1)  //如果当天有多条的日程信息就显示到日历控件上
                    {
                        ShowSchedule(user.Id, schedule.Id, schedule.BeginTime.ToShortTimeString(), schedule.Title, calDay.Date, tc);
                        ShowSchedule(user.Id, pre.Schedule.Id, pre.Schedule.BeginTime.ToShortTimeString(), "被预约信息", calDay.Date, tc);
                        showScheduleAll(user.Id, calDay.Date, tc);
                    }
                    else
                    {
                        ShowSchedule(user.Id, schedule.Id, schedule.BeginTime.ToShortTimeString(), schedule.Title, calDay.Date, tc);
                        ShowSchedule(user.Id, pre.Schedule.Id, pre.Schedule.BeginTime.ToShortTimeString(), "被预约信息", calDay.Date, tc);
                    }


                }
            }
        }
    }
    //根据用户Id，日程ID，开始时间和标题等条件在日历控件中显示日程 [日历控件]
    public void ShowSchedule(int userId, int scheduleId, string beginTime, string title, DateTime date, TableCell tc)
    {
        HtmlAnchor ha = new HtmlAnchor();
        ha.HRef = "~/ScheduleManage/PersonSchedule/SaveMySchedule.aspx?userid=" + userId + "&scheduleId=" + scheduleId + "&today=" + date.ToShortDateString();
        if (title.Length > 3)
        {
            ha.InnerText = "◎" + beginTime + " " + title.Substring(0, 3) + "...";
        }
        else
        {
            ha.InnerText = "◎" + beginTime + " " + title;
        }
        tc.Controls.Add(new LiteralControl("&nbsp;" + "&nbsp;" + "&nbsp;"));
        tc.Controls.Add(new LiteralControl("<br>"));
        tc.Controls.Add(ha);

    }

    //在日历控件中显示当天的其他日程
    public void showScheduleAll(int userId, DateTime date, TableCell tc)
    {
        //显示当天的其他日程信息
        HyperLink lnk = new HyperLink();
        lnk.ToolTip = "查看更多";
        lnk.ImageUrl = "~/images/more.gif";
        lnk.Text = "查看更多信息";
        lnk.ForeColor = System.Drawing.Color.Blue;
        lnk.NavigateUrl = "ScheduleAll.aspx?userId=" + userId + "&date=" + date.ToShortDateString();
        tc.Controls.Add(new LiteralControl("<br>"));
        tc.Controls.Add(lnk);
        tc.Controls.Add(new LiteralControl("<br>"));
    }
}

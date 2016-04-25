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
using System.Data.Sql;
using System.Data.SqlClient;
using MyOffice.DAL;
using MyOffice.Models;
using MyOffice.BLL;

public partial class ScheduleManage_PersonSchedule_ScheduleAll : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ShowPreContract(); //显示被预约的所有日程的信息
        }
    }

    //截取字符串的方法
    public string GetCut(object obj)
    {
        string str = obj.ToString();
        if (str.Length > 10)
        {
            return str.Substring(0, 10) + "...";
        }
        else
        {
            return str;
        }
    }

    //光棒效果  
    protected void gvSchedule_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#FFCCFF'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");
        }
    }
    //光棒效果  
    protected void gvPreSchedule_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#FFCCFF'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");
        }
    }

    //显示被预约日程信息
    public void ShowPreContract()
    {
        int userId = ((UserInfo)Session["user"]).Id;
        DateTime datetime = DateTime.Parse(Request.QueryString["date"]);

        this.gvPreSchedule.DataSourceID = null;
        IList<PreContract> list = PreContractManager.SelectPrecontract(userId, datetime);
        if (list.Count > 0)
        {
            this.gvPreSchedule.DataSource = list;
            this.gvPreSchedule.DataBind();
        }
        else
        {
            this.lblPreContract.Visible = false; //隐藏该控件
            this.panHr.Visible = false;
        }
    }
}

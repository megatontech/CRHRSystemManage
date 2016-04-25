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
public partial class SysManage_LoginLog : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            SetPager();//加载登录日志所有信息
        }
    }
    //分页显示
    public void SetPager()
    {
        string min = this.txtStartDate.Text.Trim();
        string max = this.txtEndDate.Text.Trim();
        if (min == null || min == "" || max == null || max == "")
        {
            min = "1970-1-1";      
            max = DateTime.Now.ToShortDateString();
        } 
        PagedDataSource pdsList = new PagedDataSource();
        IList<LoginLog> list = LoginLogManager.GetLoginLogByTime(DateTime.Parse(min), DateTime.Parse(max).AddDays(1)); //得到所有登录日志所有信息
        pdsList.DataSource = list;
        int count = 0;
        if (list.Count % 5 == 0)
        {
            count = list.Count / 5;
        }
        else
        {
            count = list.Count / 5 + 1;
        }
        pdsList.AllowPaging = true;//数据源允许分页
        pdsList.PageSize = this.anpPager.PageSize;//取控件的分页大小
        if (this.anpPager.CurrentPageIndex > count)
            this.anpPager.CurrentPageIndex = 1;
        else
        pdsList.CurrentPageIndex = this.anpPager.CurrentPageIndex - 1;//显示当前页
        //设置控件
        this.anpPager.RecordCount = list.Count;//记录总数
        this.anpPager.PageSize = 5;
        this.GVLoginLogAll.DataSource = pdsList;
        this.GVLoginLogAll.DataBind();
    }
    protected string GetIfSuccess(int ifSuccess)
    {
        string IfSuccess = "";
        if (ifSuccess == 1)
        { IfSuccess = "是"; }
        if (ifSuccess == 0)
        { IfSuccess = "否"; }
        return IfSuccess;
    }
    protected void anpPager_PageChanged(object sender, EventArgs e)
    {
        SetPager();//加载登录日志所有信息
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        SetPager();//加载登录日志所有信息
    }
    //光棒
    protected void GVLoginLogAll_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#6dc7fc'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");
        }
    }
    //删除选中的登录日志
    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow gvr in this.GVLoginLogAll.Rows)
        {
            CheckBox cb = gvr.FindControl("chkOne") as CheckBox;
            if (cb.Checked == true)
            {
                int id= int.Parse(this.GVLoginLogAll.DataKeys[gvr.RowIndex].Value.ToString());//得到选中复选框的编号
                bool b = LoginLogManager.DeleteLoginLogById(id);
            }
        }
        SetPager();
    }
}

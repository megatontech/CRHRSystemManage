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
using System.Text.RegularExpressions;
using System.IO;
public partial class ManualSign_SignStatistic : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadBranch();//加载机构下拉菜单
            ViewState["StartDate"] = "2008-01-01";
            ViewState["EndDate"] = DateTime.Now.ToShortDateString();
            LoadDepart(int.Parse(ddlBranchs.SelectedValue));//根据选定的机构Id加载部门下拉菜单
           
            SetPager();

        }
    }
    public DateTime StartDate
    {
        get { return Convert.ToDateTime(ViewState["StartDate"]); }
        set { ViewState["StartDate"] = value; }
    }
    public DateTime EndDate
    {
        get { return Convert.ToDateTime(ViewState["EndDate"]).AddDays(1); }
        set { ViewState["EndDate"] = value; }
    }
    //分页显示
    public void SetPager()
    {

        int branchId = 0;
        int departId = 0;
        branchId = int.Parse(this.ddlBranchs.SelectedValue);
        departId = int.Parse(this.ddlDeparts.SelectedValue);
        PagedDataSource pdsList = new PagedDataSource();
        IList<UserInfo> list = null;
        list = UserInfoManager.GetUserInfoByBranchIdAndDepartId(branchId, departId); //得到满足条件的考勤所有信息

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
        this.gvSignInfoStatistic.DataSource = pdsList;
        this.gvSignInfoStatistic.DataBind();

    }
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
    protected void ddlBranchs_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadDepart(int.Parse(ddlBranchs.SelectedValue));//根据选定的机构Id加载部门下拉菜单
    }
    protected void btnStatistic_Click(object sender, EventArgs e)
    {
        string min = this.txtStartDate.Text.Trim();
        string max = DateTime.Now.ToShortDateString();
        if (min == null || min == "" || max == null || max == "")
        {
            min = "1970-01-01";
            max = DateTime.Now.ToShortDateString();
        }
        ViewState["StartDate"] = min;
        ViewState["EndDate"] = max;
        SetPager();
        this.btnLoad.Enabled = true;
    }
    protected void anpPager_PageChanged(object sender, EventArgs e)
    {
        SetPager();
    }
    public string GetAttendances(object obj)
    {
        return ManualSignManager.GetUserAttendances(int.Parse(obj.ToString()), StartDate, EndDate);
    }
    public int GetArriveLates(object obj)
    {
        return ManualSignManager.GetUserArriveLates(int.Parse(obj.ToString()), StartDate, EndDate);
    }
    public int GetLeaveEarlys(object obj)
    {
        return ManualSignManager.GetUserLeaveEarlys(int.Parse(obj.ToString()), StartDate, EndDate);
    }
    public int GetAbsences(object obj)
    {
        return ManualSignManager.GetUserAbsences(int.Parse(obj.ToString()), StartDate, EndDate);
    }
    protected void btnLoad_Click(object sender, EventArgs e)
    {
        UserInfo user = (UserInfo)Session["user"];
        this.lblReportUser.Text = user.UserName;
        this.lblReportTime.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
        this.divReportUser.Visible = true;
        //
        StringWriter sw = new StringWriter();
        sw.WriteLine("姓名,出勤率（%）,迟到次数,迟到次数,早退次数,所属部门,所属机构");
       
        for (int i = 0; i < gvSignInfoStatistic.Rows.Count; i++)
        {
            string name = (gvSignInfoStatistic.Rows[i].Cells[0].Controls[1] as Label).Text;
            string attendances = (gvSignInfoStatistic.Rows[i].Cells[1].Controls[1] as Label).Text;
            string ArriveLates = (gvSignInfoStatistic.Rows[i].Cells[2].Controls[1] as Label).Text;
            string LeaveEarlys = (gvSignInfoStatistic.Rows[i].Cells[3].Controls[1] as Label).Text;
            string Absences = (gvSignInfoStatistic.Rows[i].Cells[4].Controls[1] as Label).Text;
            string DepartName = (gvSignInfoStatistic.Rows[i].Cells[5].Controls[1] as Label).Text;
            string BranchName = (gvSignInfoStatistic.Rows[i].Cells[6].Controls[1] as Label).Text;

            sw.WriteLine(name + "," + attendances + "," + ArriveLates + "," + LeaveEarlys + "," + Absences + "," + DepartName + "," + BranchName);
        }
        sw.Close();
        Response.AddHeader("Content-Disposition", "attachment;   filename=test.csv");
        Response.ContentType = "application/ms-excel";
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
        Response.Write(sw);
        Response.End();

       
    }
}

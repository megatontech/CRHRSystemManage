using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Drawing;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MyOffice.BLL;
using MyOffice.Models;
using System.Collections.Generic;
using System.Text.RegularExpressions;
public partial class ManualSign_ManualSignSearch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadBranch();//加载机构下拉菜单
            LoadDepart(int.Parse(ddlBranchs.SelectedValue));//根据选定的机构Id加载部门下拉菜单
            SetPager();
           
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
        int branchId = 0;
        int departId = 0;
        string userName = "";
        if (this.chkBranch.Checked) 
        {
            branchId = int.Parse(this.ddlBranchs.SelectedValue);
        }
        if (this.chkDepart.Checked) 
        {
            departId = int.Parse(this.ddlDeparts.SelectedValue);
        }
        if (this.chkUserName.Checked) 
        {
            userName = this.txtUserName.Text.Trim();
        }
        PagedDataSource pdsList = new PagedDataSource();
        IList<ManualSign> list=null;
        if (this.chkBranch.Checked || this.chkDepart.Checked || this.chkUserName.Checked) 
        {
            list = ManualSignManager.GetManualSignsBySelectedConditions(DateTime.Parse(min), DateTime.Parse(max).AddDays(1),userName,departId,branchId); //得到满足条件的考勤所有信息
        }
        else
        {
            list = ManualSignManager.GetAllManualSignBySignTime(DateTime.Parse(min), DateTime.Parse(max).AddDays(1));  //得到所有考勤所有信息
        }
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
        this.gvUserSignInfo.DataSource = pdsList;
        this.gvUserSignInfo.DataBind();
        Unite(this.gvUserSignInfo);
    }


    //合并单元格
    protected void Unite(GridView gv)
    {
        int i;
        string LastType1;
        int LastCell;
        if (gv.Rows.Count > 0)
        {
            for (int j = 0; j < 6; j++)
            {
                if (j != 1 && j != 2 && j != 3)
                {
                    LastType1 = gv.Rows[0].Cells[j].Text;
                    gv.Rows[0].Cells[j].RowSpan = 1;
                    LastCell = 0;

                    for (i = 1; i < gv.Rows.Count; i++)
                    {
                        if (gv.Rows[i].Cells[j].Text == LastType1)
                        {
                            gv.Rows[i].Cells[j].Visible = false;
                            gv.Rows[LastCell].Cells[j].RowSpan++;
                        }
                        else
                        {
                            LastType1 = gv.Rows[i].Cells[j].Text;
                            LastCell = i;
                            gv.Rows[i].Cells[j].RowSpan = 1;
                        }
                    }
                }
            }
        }
    }

    /// <summary>
    /// 截断签到备注
    /// </summary>
    public string GetCut(object obj)
    {
        string temp = Server.HtmlDecode(obj as string);
        //参数说明：要处理的字符串，符合条件的表达式[汉字]，
        //替换的字符[内容随意写但是要两个字符，因为一个中文对应两个字符，不区分大小写]
        if (Regex.Replace(temp, "[\u4e00-\u9fa5]", "zz", RegexOptions.IgnoreCase).Length <= 20)
        {
            return temp;
        }
        for (int i = temp.Length; i >= 0; i--)
        {
            temp = temp.Substring(0, i);
            if (Regex.Replace(temp, "[\u4e00-\u9fa5]", "zz", RegexOptions.IgnoreCase).Length <= 20 - 3)
            {
                return temp + "...";
            }
        }
        return "...";
    }
    public string GetSignTag(object obj) 
    {
        int signTag = Convert.ToInt32( obj);
        if (signTag == 0)
        {
            return "签退";
        }
        else 
        {
            return "签到";
        }
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
    //分页显示
    protected void anpPager_PageChanged(object sender, EventArgs e)
    {
        SetPager();
        ControlEnabled();
    }
    //搜索
    protected void imgbtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        SetPager();
        ControlEnabled();
    }
    protected void ddlBranchs_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadDepart(int.Parse(ddlBranchs.SelectedValue));//根据选定的机构Id加载部门下拉菜单
        ControlEnabled();
    }
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
            this.txtUserName.Enabled = true;
        else
            this.txtUserName.Enabled = false;
    }
   
    protected void chkDepart_CheckedChanged(object sender, EventArgs e)
    {
        if (this.chkDepart.Checked && !this.chkBranch.Checked)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "str", "<script>alert('请选择机构')</script>", false);
        }
        ControlEnabled();
    }
}

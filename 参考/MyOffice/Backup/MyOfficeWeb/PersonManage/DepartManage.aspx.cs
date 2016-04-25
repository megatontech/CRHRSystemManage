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
using MyOffice.BLL;
using MyOffice.Models;

public partial class PersonManage_DepartManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["BranchId"] = 0;
            SetPager(0);
            LoadBranch();
        }
    }
    protected void LoadBranch()
    {
        IList<BranchInfo> branchs = BranchInfoManger.GetBranchInfo();
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
    public void SetPager(int branchid)
    {
        PagedDataSource pdsList = new PagedDataSource();
        IList<DepartInfo> list = new List<DepartInfo>();
        if (branchid == 0)
        {
             list = DepartInfoManager.GetAllDepart();
        }
        else
        {
            list = DepartInfoManager.GetDepartInfoByBranchId(branchid);
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
        this.GridView1.DataSource = pdsList;
        this.GridView1.DataBind();
    }
    protected void anpPager_PageChanged(object sender, EventArgs e)
    {
        SetPager(int.Parse(ViewState["BranchId"].ToString()));
    }
    protected void imgbtnModify_Click(object sender, ImageClickEventArgs e)
    {
        
            ImageButton btnUpdate = sender as ImageButton;
            string id = btnUpdate.CommandArgument.ToString();
            Response.Redirect("DepartInfoManage.aspx?departid="+id);
    }
    protected void btnAddDepart_Click(object sender, EventArgs e)
    {
        Response.Redirect("DepartInfoManage.aspx");
    }
    protected void imgbtnDelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btnDelete = sender as ImageButton;
        string id = btnDelete.CommandArgument.ToString();
        int departid = int.Parse(id);
        bool b = MyOffice.BLL.DepartInfoManager.DeleteDepartCheck(departid);
        if (!b)
        {
            bool u = MyOffice.BLL.DepartInfoManager.DeleteDepartById(departid);
            if (u)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "str", "<script>alert('删除成功')</script>", false);      
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "str", "<script>alert('删除失败')</script>", false);       
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "str", "<script>alert('该部门还包含用户,不能删除！')</script>", false);          
        }
        SetPager(int.Parse(ViewState["BranchId"].ToString()));
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#6dc7fc'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");
        }
    }
    protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["BranchId"] = int.Parse(this.ddlBranch.SelectedValue.ToString());
        SetPager(int.Parse(this.ddlBranch.SelectedValue.ToString()));
    }
}

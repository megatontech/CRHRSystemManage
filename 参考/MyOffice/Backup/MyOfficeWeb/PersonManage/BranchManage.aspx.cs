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


public partial class PersonManage_BranchManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SetPager();
            Inited();
            ViewState["BranchName"] = "";
        }
    }
    public string BranchName
    {
        get { return Convert.ToString(ViewState["BranchName"]); }
        set { ViewState["BranchName"] = value; }
    }
    protected void Inited()
    {
        this.btnSave.Enabled = false;
    }
    public void SetPager() 
    {
        PagedDataSource pdsList = new PagedDataSource();
        IList<BranchInfo> list = BranchInfoManger.GetBranchInfo();
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
        SetPager();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        BranchInfo branchinfo = new BranchInfo();
        branchinfo.BranchName = this.txtBranchName.Text.Trim();
        branchinfo.BranchShortName = this.txtBranchShortName.Text.Trim();
        bool bl=false;
        bl=BranchInfoManger.CheckBranch(branchinfo);
        if (!bl)
        {
            bool b = BranchInfoManger.AddBranch(branchinfo);
            if (b)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "str", "<script>alert('添加成功')</script>", false);               
                SetPager();
                this.txtBranchName.Text = "";
                this.txtBranchShortName.Text = "";
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "str", "<script>alert('添加失败')</script>", false);
            }
        }
        else 
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "str", "<script>alert('已有该机构')</script>", false);
        }
    }
    protected void imgbtnModify_Click(object sender, ImageClickEventArgs e)
    {
        
            ImageButton btnUpdate = sender as ImageButton;
            int id = int.Parse(btnUpdate.CommandArgument.ToString());
          
            BranchInfo b = new BranchInfo();
            b = BranchInfoManger.GetBranchById(id);
            Session["BranchId"] = id.ToString();
            this.txtBranchName.Text = b.BranchName.ToString();
            this.txtBranchShortName.Text = b.BranchShortName.ToString();
            ViewState["BranchName"] = b.BranchName.ToString();
            this.btnAdd.Enabled = false;
            this.btnSave.Enabled = true;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        BranchInfo branchinfo = new BranchInfo();
        branchinfo.Id = int.Parse(Session["BranchId"].ToString());
        branchinfo.BranchName = this.txtBranchName.Text.Trim();
        bool bol = false;
        branchinfo.BranchShortName = this.txtBranchShortName.Text.Trim();
         bool bl=false;
        bl=BranchInfoManger.CheckBranch(branchinfo);
        if (bl && BranchName == this.txtBranchName.Text.Trim())
        {
            bol = BranchInfoManger.ModifyBranchById(branchinfo);
            if (bol)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "str", "<script>alert('保存成功')</script>", false);
               
                this.btnAdd.Enabled = true;
                this.btnSave.Enabled = false;
                SetPager();
                this.txtBranchName.Text = "";
                this.txtBranchShortName.Text = "";
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "str", "<script>alert('保存失败')</script>", false);
               
            }
        } 
        else 
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "str", "<script>alert('已有该机构')</script>", false);
           
        }
    }
    /// <summary>
    /// 删除机构
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btnDelete = sender as ImageButton;
        int branchid = int.Parse(btnDelete.CommandArgument.ToString());
        bool b = MyOffice.BLL.BranchInfoManger.DeleteBranchCheck(branchid);
        if (!b)
        {
            bool de = MyOffice.BLL.BranchInfoManger.DeleteBranchById(branchid);
            if (de)
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
            ScriptManager.RegisterStartupScript(this, this.GetType(), "str", "<script>alert('该机构还包含部门,不能删除！')</script>", false);  
        }
        SetPager();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#6dc7fc'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");
        }
    }
}

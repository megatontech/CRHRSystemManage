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

public partial class PersonManage_UserManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["DepartId"] = 0;
            Inite();          
        }
    }   
    public void Inite()
    {
        int branchId = 0;
        int departId = 0;
        PagedDataSource pdsList = new PagedDataSource();
        IList<UserInfo> list = new List<UserInfo>();

         if (this.ddlBranchs.SelectedValue == "") 
        {
            list = UserInfoManager.GetAllUserInfo();
        }
        else 
        {
            branchId =int.Parse(this.ddlBranchs.SelectedValue);
            if (this.ddlDepart.SelectedValue != "") 
            {
                departId = int.Parse(this.ddlDepart.SelectedValue);
            }

            list = UserInfoManager.GetUserInfoByBranchIdAndDepartId(branchId,departId);
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
        this.gvUser.DataSource = pdsList;
        this.gvUser.DataBind();
    }
    protected void ImagBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        Inite();
    }
    protected void imgbtnModify_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btnUpDate = sender as ImageButton;
        string id = btnUpDate.CommandArgument.ToString();
        Response.Redirect("UserInfoManage.aspx?uid=" + int.Parse(id));
    }
    protected void imgbtnDelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btnDelete = sender as ImageButton;
        string id = btnDelete.CommandArgument.ToString();
        int uid = int.Parse(id);
        if (Session["user"] != null)
        {
            UserInfo user = (UserInfo)Session["user"];
            if (user.Id != uid)
            {
                bool b = UserInfoManager.DeleteUserById(uid,1);
                if (b)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "str", "<script>alert('删除成功')</script>", false);
                    Inite();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "str", "<script>alert('删除失败')</script>", false);

                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "str", "<script>alert('不能删除自己的')</script>", false);
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("UserInfoManage.aspx");
    }
    protected void anpPager_PageChanged(object sender, EventArgs e)
    {
        Inite();
    }
    protected void gvUser_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#6dc7fc'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");
        }
    }
}

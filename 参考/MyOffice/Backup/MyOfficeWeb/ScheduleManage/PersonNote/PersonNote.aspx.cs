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


public partial class ScheduleManage_MyNote : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["user"] != null)
            {
                Bind(((UserInfo)Session["user"]).Id);
            }
           
        }
    }
    //绑定数据源的方法
    public void Bind(int createUserId)
    {
        dtlMyNote.DataSourceID = null;
        IList<MyNote> list = MyNoteManager.GetMyNoteByCreateUserId(createUserId);//根据创建人查看便签的方法
        if (list.Count > 0)
        {
            dtlMyNote.DataSource = list;
            dtlMyNote.DataBind();
        }
        else
        {
            lblMessage.Visible = true;
        }
    }

    //截取字符串的方法
    public string GetCut(object obj)
    {
        string str = obj.ToString();
        if (str.Length > 12)
        {
            return str.Substring(0, 12) + "...";
        }
        else
        {
            return str;
        }
    }
    //添加便签的方法
    protected void lnkbtntitle_Command(object sender, CommandEventArgs e)
    {
        int id =Convert.ToInt32(e.CommandArgument.ToString());

        Response.Redirect("AddMyNote.aspx?Id="+id);
    }
}

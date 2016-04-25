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

public partial class ScheduleManage_AddMyNote : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["user"] != null)
            {
                //显示创建人和创建时间
                UserInfo userInfo = (UserInfo)Session["user"];
                string name = userInfo.UserName;
                this.lblCreateUser.Text = name;
                string time = DateTime.Now.ToString();
                this.lblDataTime.Text = time;
            }
            if (Request.QueryString["Id"] != null)
            {
                MyNote mynote = MyNoteManager.GetMyNoteById(int.Parse(Request.QueryString["Id"]));
                //取出控件名
                txtNoteTitle.Text = mynote.NoteTitle;
                txtNoteContent.Text = mynote.NoteContent;
                mynote.CreateTime = DateTime.Now;
                mynote.CreateUser = (UserInfo)Session["user"];
                this.btnDelete.Enabled = true;
            }
        }
    }
    //保存按钮
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            //修改便签
            MyNote mynote = new MyNote();
            mynote.NoteTitle = txtNoteTitle.Text.Trim();
            mynote.NoteContent = txtNoteContent.Text.Trim();
            mynote.CreateTime = DateTime.Now;
            mynote.CreateUser = (UserInfo)Session["user"];

            if (Request.QueryString["Id"] != null)
            {
                mynote.Id=int.Parse(Request.QueryString["Id"]);
                bool b=MyNoteManager.ModifyMyNote(mynote);
                if (b)
                {
                    Response.Redirect("PersonNote.aspx"); //显示便签
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "str", "<script>alert(\"失败！！\")</script>");
                }
            }
            else
            {
                //+++++++++++添加便签的方法+++++++++++++++             
                bool b = MyNoteManager.AddMyNote(mynote); 
                if (b)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "str", "<script>alert(\"保存成功！！\")</script>");
                    this.btnDelete.Enabled = true;
                    Response.Redirect("PersonNote.aspx"); //添加成功后，转到便签页
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "str", "<script>alert(\"保存失败！！\")</script>");
                }
            }
        }
    }
    //删除当前便签
    protected void btnDelete_Click(object sender, EventArgs e)
    { 
        int id=int.Parse(Request.QueryString["Id"]);
        bool b = MyNoteManager.DeleteMyNotebyId(id);//根据Id删除便签的方法
        if (b)
        {
            Response.Redirect("PersonNote.aspx");//删除成功后，转到便签页
        }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(),"str","<script>alert(\"删除失败！\")</script>");
        }
    }
}

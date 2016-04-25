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

public partial class File_ManageFolder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindPage();
        }
    }
    /// <summary>
    /// 初始化页面信息
    /// </summary>
    private void BindPage()
    {
        if (Request.QueryString["fileId"] != null)//修改文件夹
        {
            int fileId = int.Parse(Request.QueryString["fileId"]);
            FileInfo fileInfo = FileInfoManager.GetFileByFileId(fileId);

            txtFileName.Text = fileInfo.FileName;//文件夹名字
            lblAddress.Text = fileInfo.FilePath.Replace("c:\\", "自动办公系统");//文件夹地址
            txtRemark.Text = fileInfo.Remark;//备注
            lblCreateDate.Text = fileInfo.CreateDate.ToShortDateString();//创建时间
            lblFileOwner.Text = fileInfo.FileOwner.UserName;//所有者
        }
        if (Request.QueryString["fileAddress"] != null)//新增文件夹
        {
            lblAddress.Text = Request.QueryString["fileAddress"];//文件夹地址
            if (Session["user"] != null)
            {
                UserInfo userInfo = (UserInfo)Session["user"];
                lblFileOwner.Text = userInfo.UserName;//所有者
            }
        }
    }
    /// <summary>
    /// 添加文件夹
    /// </summary>
    private void AddFile()
    {
        FileInfo fileInfo = new FileInfo();

        fileInfo.FileName = txtFileName.Text.Trim();

        FileTypeInfo fileType = new FileTypeInfo();
        fileType.Id = 1;//类型是文件夹
        fileInfo.FileTyPe = fileType;

        fileInfo.Remark = txtRemark.Text.Trim();

        UserInfo fileOwner = Session["user"] as UserInfo;
        fileInfo.FileOwner = fileOwner;


        fileInfo.ParentId = FileInfoManager.GetFileIdByAddress(Request.QueryString["fileAddress"].Replace("自动办公系统", "c:\\"));

        string path = lblAddress.Text.Replace("自动办公系统", "c:\\") + "\\" + txtFileName.Text;
        fileInfo.FilePath = path;
        fileInfo.IfDelete = 0;

        int id = FileInfoManager.GetFileIdByAddress(path);//根据文件位置查询文件id
        if (id > 0)
        {
            Page.RegisterStartupScript("ss", "<script>alert('此文件夹已经存在!!!')</script>");
        }
        else
        {
            int fid = FileInfoManager.AddFileInfo(fileInfo);//添加文件夹

            ManageAllFile manageFile = new ManageAllFile();
            manageFile.CreateDirectory(path);//在目录下创建文件

            if (fid > 0)
                ScriptManager.RegisterStartupScript(this, this.GetType(), "str", "<script>document.getElementById('ss').click();</script>", false);
            else
                Page.RegisterStartupScript("ss", "<script>alert('添加失败,请重新再试!!!')</script>");
        }
    }
    /// <summary>
    /// 修改文件夹
    /// </summary>
    private void ModifyFile()
    {
        FileInfo fileInfo = new FileInfo();
        int fileId = int.Parse(Request.QueryString["fileId"]);

        fileInfo.Id = fileId;//文件夹id
        fileInfo.FileName = txtFileName.Text.Trim();//文件夹名称
        
        string path = "";//路径
        path = lblAddress.Text.Replace("自动办公系统", "c:\\");
        path = path.Substring(0, path.LastIndexOf('\\') + 1);//去掉最后一个 \ 后面的内容 
        path = path + txtFileName.Text.Trim(); //再加上文件夹名称（新的路径）
        fileInfo.FilePath = path;

        FileTypeInfo fileType = new FileTypeInfo();//文件夹类型
        fileType.Id = 1;
        fileInfo.FileTyPe = fileType;
        
        fileInfo.Remark = txtRemark.Text.Trim();//备注

        //磁盘上，重命名文件
        ManageAllFile manageFile = new ManageAllFile();
        manageFile.ReNameDirectory(lblAddress.Text.Replace("自动办公系统", "c:\\"), path);

        bool b = FileInfoManager.ModifyFile(fileInfo);//修改文件夹


        if (b)
            ScriptManager.RegisterStartupScript(this, this.GetType(), "str", "<script>document.getElementById('ss').click();</script>", false);
        else
            Page.RegisterStartupScript("ss", "<script>alert('修改失败,请重新再试!!!')</script>");
    }
    protected void ibtnSave_Click(object sender, ImageClickEventArgs e)
    {
        if (Request.QueryString["fileId"] != null)//修改文件夹
        {
            ModifyFile();
        }
        if (Request.QueryString["fileAddress"] != null)//新增文件夹
        {
            AddFile();
        }
    }

    protected void ibtnExit_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("FileManage.aspx");
    }
}

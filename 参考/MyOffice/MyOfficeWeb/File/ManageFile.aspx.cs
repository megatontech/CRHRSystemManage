using System;
using System.Data;
using System.IO;
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

public partial class File_ManageFile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindRadioList();// 绑定类型图标
            if (Request.QueryString["fileId"] != null)//修改文件
            {
                int fileId = int.Parse(Request.QueryString["fileId"]);
                MyOffice.Models.FileInfo fileInfo = FileInfoManager.GetFileByFileId(fileId);

                lblFileName.Text = fileInfo.FileName;//文件夹名字

                string path = fileInfo.FilePath;
                path = path.Replace("c:\\", "自动办公系统");
                lblAddress.Text = path;//文件夹地址

                txtRemark.Text = fileInfo.Remark;//备注
                lblCreateDate.Text = fileInfo.CreateDate.ToShortDateString();//创建时间
                lblFileOwner.Text = fileInfo.FileOwner.UserName;//所有者
                radFileType.SelectedValue = fileInfo.FileTyPe.Id.ToString();//文件类型图标

                BindAccessoryFile(fileId);//文件附件
            }
            if (Request.QueryString["fileAddress"] != null)//新增文件
            {
                lblAddress.Text = Request.QueryString["fileAddress"];//文件夹地址
                if (Session["user"] != null)
                {
                    UserInfo userInfo = (UserInfo)Session["user"];
                    lblFileOwner.Text = userInfo.UserName;//所有者
                }
            }

        }
    }

    /// <summary>
    /// 绑定类型图标
    /// </summary>
    private void BindRadioList()
    {
        IList<FileTypeInfo> list = FileTypeInfoManager.GetAllFileType();
        foreach (FileTypeInfo fileType in list)
        {
            //设置属性
            ListItem item = new ListItem();
            item.Attributes.Add("id", fileType.FileTypeSuffix);
            item.Text = "&nbsp;<Img src='" + fileType.FileTypeImage + "'></Img>&nbsp;" + fileType.FileTypeName;
            item.Value = fileType.Id.ToString();

            radFileType.Items.Add(item);
        }
        radFileType.Enabled = false;//让用户不能使用
    }
    /// <summary>
    /// 绑定文件附件
    /// </summary>
    /// <param name="fileId">文件的id</param>
    private void BindAccessoryFile(int fileId)
    {
        gvAccessoryFile.DataSource = AccessoryFileManager.GetAccessoryFileByFileId(fileId);
        gvAccessoryFile.DataBind();
    }

    /// <summary>
    /// 添加文件
    /// </summary>
    /// <returns>添加的文件的id</returns>
    private int AddFile()
    {
        if (fileUpload.FileName.Trim().Length > 0)
        {
            string[] getFile = fupFile.FileName.Trim().Split('.');
            string fileName = getFile[0];//得到文件名称部分
            string suffix = "";//得到文件后缀部分
            if (getFile.Length == 1)
                suffix = "noname";
            else
                suffix = getFile[1].ToString();

            //--------------------------
            MyOffice.Models.FileInfo fileInfo = new MyOffice.Models.FileInfo();
            //文件名
            fileInfo.FileName = fileName;
            //文件类型
            fileInfo.FileTyPe = FileTypeInfoManager.GetFileTypeInfoByFileTypeSuffix(suffix);
            //文件备注
            fileInfo.Remark = txtRemark.Text.Trim();
            //创建者
            UserInfo fileOwner = Session["user"] as UserInfo;
            fileInfo.FileOwner = fileOwner;
            //文件的父级节点
            fileInfo.ParentId = FileInfoManager.GetFileIdByAddress(Request.QueryString["fileAddress"].Replace("自动办公系统", "c:\\"));
            //文件路径
            string path = "";
            if (suffix == "noname")
                path = lblAddress.Text.Replace("自动办公系统", "c:\\") + "\\" + fileName;
            else
                path = lblAddress.Text.Replace("自动办公系统", "c:\\") + "\\" + fileName + "." + suffix;
            fileInfo.FilePath = path;
            //是否删除
            fileInfo.IfDelete = 0;

            int id = FileInfoManager.GetFileIdByAddress(path);//根据文件位置查询文件id
            int fid = 0;
            if (id > 0)
            {
                Page.RegisterStartupScript("ss", "<script>alert('文件已经存在,上传失败!!!')</script>");
            }
            else
            {
                fid = FileInfoManager.AddFileInfo(fileInfo);//添加文件到数据库
                if (fid <= 0)
                {
                    Page.RegisterStartupScript("ss", "<script>alert('添加失败,请重新再试!!!')</script>");
                }
                //上传到服务器
                fupFile.PostedFile.SaveAs(path);
            }

            return fid;
        }
        return 0;
    }
    /// <summary>
    /// 修改文件
    /// </summary>
    /// <returns>修改的文件的id</returns>
    private int ModifyFile()
    {
        string fileName = "";//文件名称
        string suffix = "";//文件后缀

        string[] getFile = fupFile.FileName.Trim().Split('.');
        if (getFile[0] != "")
        {
            fileName = getFile[0];
            if (getFile.Length == 1)
                suffix = "noname";
            else
                suffix = getFile[1].ToString();
        }
        else
        {
            fileName = lblFileName.Text.Trim();
            suffix = FileTypeInfoManager.GetFileTypeSuffixByTypeId(int.Parse(radFileType.SelectedValue));
        }

        //-----------------
        MyOffice.Models.FileInfo fileInfo = new MyOffice.Models.FileInfo();
        int fileId = int.Parse(Request.QueryString["fileId"]);
        //文件id
        fileInfo.Id = fileId;
        //文件名称
        fileInfo.FileName = fileName;
        //路径
        string path = "";
        path = lblAddress.Text.Replace("自动办公系统", "c:\\");
        path = path.Substring(0, path.LastIndexOf('\\') + 1);//去掉最后一个 \ 后面的内容 
        path = path + fileName; //再加上文件名称
        if (suffix != "noname")
            path = path + "." + suffix;
        fileInfo.FilePath = path;//（新的路径）
        //文件类型
        fileInfo.FileTyPe = FileTypeInfoManager.GetFileTypeInfoByFileTypeSuffix(suffix);
        //备注
        fileInfo.Remark = txtRemark.Text.Trim();

        int id = FileInfoManager.GetFileIdByAddress(path);//根据文件位置查询文件id
        if (id > 0)
        {
            Page.RegisterStartupScript("ss", "<script>alert('文件已经存在,修改失败!!!')</script>");
            return 0;
        }
        else
        {
            if (fupFile.FileName.Trim().Length > 0)
            {
                //先把以前的文件删除
                string address = FileInfoManager.GetAddressByFileId(fileId);
                ManageAllFile manage = new ManageAllFile();
                manage.DeleteFile(address);
                //再把文件上传到服务器
                fupFile.PostedFile.SaveAs(path);
            }

            FileInfoManager.ModifyFile(fileInfo);//修改文件
            
            return fileId;
        }
    }
    /// <summary>
    /// 添加附件
    /// </summary>
    /// <param name="fileId"></param>
    private void AddAccessoryFile(int fid)
    {
        if (fileUpload.FileName.Trim().Length > 0)
        {
            //附件
            string[] getFileType = fileUpload.FileName.Trim().Split('.');
            string accessoryName = getFileType[0];//得到文件名称部分
            string suffix = getFileType[1].ToString();//得到文件后缀部分
            int fileSize = fileUpload.PostedFile.ContentLength;


            FileTypeInfo fileType = FileTypeInfoManager.GetFileTypeInfoByFileTypeSuffix(suffix);//根据文件后缀得到文件类型

            AccessoryFileInfo accessoryFileInfo = new AccessoryFileInfo();//文件附件
            MyOffice.Models.FileInfo fileInfo = new MyOffice.Models.FileInfo();
            fileInfo.Id = fid;
            accessoryFileInfo.File = fileInfo;//文件附件所对应的文件

            accessoryFileInfo.AccessoryName = accessoryName;//附件名字


            accessoryFileInfo.AccessoryType = fileType;//附件类型
            accessoryFileInfo.AccessorySize = fileSize;//附件大小

            string accessoryPath = "";//附件位置
            string address = "";//下载到服务器的地方
            if (Request.QueryString["fileAddress"] != null)//新增文件
            {
                address = Request.QueryString["fileAddress"].Replace("自动办公系统", "c:\\");
                accessoryPath = address + "\\" + fileUpload.FileName;
            }
            if (Request.QueryString["fileId"] != null)//修改文件
            {
                accessoryPath = FileInfoManager.GetAddressByFileId(int.Parse(Request.QueryString["fileId"]));
                address = accessoryPath.Substring(0, accessoryPath.LastIndexOf('\\'));//把 \ 后面的部分去掉
                accessoryPath = address + "\\" + fileUpload.FileName;
            }
            accessoryFileInfo.AccessoryPath = accessoryPath;//附件的位置

            //添加附件
            int accessoryId = AccessoryFileManager.AddAccessoryFile(accessoryFileInfo);

            //把附件上传到服务器
            fileUpload.PostedFile.SaveAs(accessoryPath);

        }
    }


    //保存
    protected void ibtnSave_Click(object sender, ImageClickEventArgs e)
    {
        int fid = 0;
        if (Request.QueryString["fileAddress"] != null)//新增文件
        {
            fid = AddFile();
        }
        if (Request.QueryString["fileId"] != null)//修改文件
        {
            fid = ModifyFile();
        }

        if (fid != 0)
        {
            AddAccessoryFile(fid);//添加附件
        }
        ScriptManager.RegisterStartupScript(this, this.GetType(), "str", "<script>alert('操作已成功！');parent.location='FileManage.aspx';</script>", false);
    }
    //退出
    protected void ibtnExit_Click(object sender, ImageClickEventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "str", "<script>parent.location='FileManage.aspx';</script>", false);
    }


    //文件附件的删除
    protected void gvAccessoryFile_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int accessoryId = (int)gvAccessoryFile.DataKeys[e.RowIndex].Value;
        AccessoryFileManager.DeleteAccessoryFileById(accessoryId);
        if (Request.QueryString["fileId"] != null)
        {
            int fileId = int.Parse(Request.QueryString["fileId"]);
            BindAccessoryFile(fileId);//文件附件
        }
    }

    protected void gvAccessoryFile_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //添加光棒
            e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#FFFF99'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");
        }
    }
}

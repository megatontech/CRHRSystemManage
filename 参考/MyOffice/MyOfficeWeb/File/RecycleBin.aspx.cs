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
using MyOffice.BLL;

public partial class File_RecycleBin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindRecycleBin();
        }
    }

    /// <summary>
    /// 绑定回收站
    /// </summary>
    private void BindRecycleBin()
    {
        UserInfo user = Session["user"] as UserInfo;
        gvFilesInfo.DataSource = FileInfoManager.GetAllIsDeleteFile(user.Id);
        gvFilesInfo.DataBind();
    }
    /// <summary>
    /// 删除文件
    /// </summary>
    /// <param name="fileId">文件id</param>
    private void DeleteFile(int fileId)
    {
        FileInfoManager.DeleteFileById(fileId);
        IList<FileInfo> list = FileInfoManager.GetFileByParentId(fileId);
        foreach (FileInfo fileInfo in list)
        {
            DeleteFile(fileInfo.Id);
        }
    }


    protected void gvFilesInfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandArgument != null)
        {
            int fileId = int.Parse(e.CommandArgument.ToString());
            if (e.CommandName == "UpCancel")//还原
            {
                FileInfoManager.ModifyIfDeleteById(fileId, 0);//修改 IfDelete 为0
            }
            if (e.CommandName == "Del")//删除
            {

                //删除磁盘内容
                ManageAllFile manageFile = new ManageAllFile();
                //如果是文件夹，就删除文件夹
                //否则就是删除文件
                if (FileInfoManager.GetFileTypeNameByFileId(fileId) == "文件夹")
                    manageFile.DeleteDirectory(FileInfoManager.GetAddressByFileId(fileId));
                else
                    manageFile.DeleteFile(FileInfoManager.GetAddressByFileId(fileId));


                DeleteFile(fileId);//删除

            }
            BindRecycleBin();
        }
    }
    protected void gvFilesInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#FFFF99'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");
        }
    }

    /// <summary>
    /// 格式化路径
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public string GetPath(object path)
    {
        string obj = path as string;
        return obj.Replace("c:\\", "自动办公系统");
    }
    protected void lbtnClear_Click(object sender, EventArgs e)
    {
        FileInfoManager.ClearRecycleBin();//清空回收站
        BindRecycleBin();
    }
}

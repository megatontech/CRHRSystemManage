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

public partial class File_FileSearch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void gvFilesInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#FFFF99'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");
        }
    }
    protected void imgbtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        string fileName = txtFileName.Text.Trim();
        string accesoryFile = txtAccessoryFile.Text.Trim();
        string createUser = txtCreateUser.Text.Trim();
        string startDate = txtStartDate.Text.Trim();
        string endDate = txtEndDate.Text.Trim();

        IList<FileInfo> list = FileInfoManager.GetFileInfoBySearch(fileName, accesoryFile, createUser, startDate, endDate);
        if (list.Count > 0)//如果搜索有内容
        {
            gvFilesInfo.DataSource = list;
            gvFilesInfo.DataBind();
            pnlFileDetail.Visible = false;

            lblMessage.Text = "";
        }
        else//如果搜索为空
        {
            lblMessage.Text = "没找到任何信息...";
        }
    }
    protected void gvFilesInfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Detail")
        {
            gvFilesInfo.DataSource = null;
            gvFilesInfo.DataBind();
            pnlFileDetail.Visible = true;

            BindDetail(int.Parse(e.CommandArgument.ToString()));
        }
    }

    /// <summary>
    /// 绑定详细信息
    /// </summary>
    /// <param name="fileId">文件id</param>
    private void BindDetail(int fileId)
    {
        FileInfo fileInfo = FileInfoManager.GetFileByFileId(fileId);
        if (fileInfo.FileName != null)
        {
            lblFileName.Text = fileInfo.FileName;
            lblFilePath.Text = fileInfo.FilePath.Replace("c:\\", "自动办公系统");
            txtRemark.Text = fileInfo.Remark;
            lblCreateDate.Text = fileInfo.CreateDate.ToShortDateString();
            lblFileOwner.Text = fileInfo.FileOwner.UserName;
        }

        gvAccessoryFileInfo.DataSource = AccessoryFileManager.GetAccessoryFileByFileId(fileId);
        gvAccessoryFileInfo.DataBind();
    }
    protected void gvAccessoryFileInfo_RowDataBound(object sender, GridViewRowEventArgs e)
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
}

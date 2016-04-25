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

//5*1*a*s*p*x
public partial class File_FileMain : System.Web.UI.Page
{
    private DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int fileId = 4;//默认部门文档
            if (Request.QueryString["fileId"] != null)
            {
                fileId = int.Parse(Request.QueryString["fileId"]);
                
            }
            BindPage(fileId);

            dt = FileInfoManager.GetAllFileForTreeView();
            FillTreeView(0, null);
        }

        //如果地址框为空，上一级按钮不能使用
        string address = txtAddress.Text.Trim();
        if (address == "")
        {
            btnUp.Enabled = false;
        }
    }

    /// <summary>
    /// 初始化页面信息
    /// </summary>
    /// <param name="fileId">文件id</param>
    private void BindPage(int fileId)
    {
        gvFiles.DataSource = FileInfoManager.GetFileByParentId(fileId);//初始化GridView
        gvFiles.DataBind();

        string path = FileInfoManager.GetAddressByFileId(fileId);
        path = path.Replace("c:\\", "自动办公系统");
        txtAddress.Text = path;//初始化地址

    }
    /// <summary>
    /// 根据地址绑定GridView
    /// </summary>
    /// <param name="address">地址</param>
    private void BindGridViewByAddress(string address)
    {
        if (address != "")
        {
            //如果地址后面有一个 \ ，就把它去掉
            if (address.Substring(address.Length - 1) == "\\")
                address = address.Substring(0, address.Length - 1);
            int fileId = FileInfoManager.GetFileIdByAddress(address);//根据地址查询文件的id
            BindPage(fileId);
        }
    }

    protected void gvFiles_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //添加光棒
            e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#FFFF99'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");
        }

    }
    //转到
    protected void ibtnGoTo_Click(object sender, ImageClickEventArgs e)
    {
        string address = txtAddress.Text.Trim();
        address = address.Replace("自动办公系统", "c:\\");

        //根据文件路径查询文件id
        int id = FileInfoManager.GetFileIdByAddress(address);
        if (id > 0)
        {
            BindGridViewByAddress(address);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "str", "<script>alert('未能找到 \"" + address + "\"。请确认路径正确！')</script>", false);
        }
    }
    //返回上一级
    protected void btnUp_Click(object sender, ImageClickEventArgs e)
    {
        string address = txtAddress.Text.Trim();
        address = address.Replace("自动办公系统", "c:\\");
        if (address != "")
        {
            string[] ad = address.Split('\\');//根据 \ 截取字符串
            string newAddress = "";//上一级的地址

            //去掉 \ 后面的内容，就是上一级的地址
            for (int i = 0; i < ad.Length - 1; i++)
            {
                newAddress = newAddress + ad[i] + "\\";
            }

            //截取后，倒数第二个，如果是空的，那么就是没有上一级
            //"c:\\部门文档"
            string fileName = ad[ad.Length - 2];

            if (fileName != "")//如果有上一级
            {
                BindGridViewByAddress(newAddress);
            }
            else
            {
                //如果没有就不能在点击上一级按钮
                btnUp.Enabled = false;
            }
        }
    }
    protected void gvFiles_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string fileId = e.CommandArgument.ToString();

        if (e.CommandName == "Attribute")//查看属性
        {
            string fileName = FileInfoManager.GetFileTypeNameByFileId(int.Parse(fileId));//根据文件id查询类型
            if (fileName == "文件夹")
                Response.Redirect("ManageFolder.aspx?fileId=" + fileId);
            else
                Response.Redirect("ManageFile.aspx?fileId=" + fileId);
        }
        if (e.CommandName == "Move")//移动
        {
            ViewState["FileId"] = fileId;
        }
        if (e.CommandName == "Dele")//删除
        {
            FileInfoManager.ModifyIfDeleteById(int.Parse(fileId), 1);//修改IfDelete为１

            ScriptManager.RegisterStartupScript(this, this.GetType(), "str", "<script>document.getElementById('ss').click();</script>", false);
        }
    }
    //绑定名称的URL和察看属性按钮是否可用
    protected void gvFiles_DataBound(object sender, EventArgs e)
    {
        string address = txtAddress.Text.Trim();//得到地址
        foreach (GridViewRow gvr in gvFiles.Rows)
        {
            LinkButton lbtnFileName = gvr.FindControl("lbtnFileName") as LinkButton;//名称
            Image imgFileType = gvr.FindControl("imgFileType") as Image;//类型图片
            ImageButton ibtnAttribute = gvr.FindControl("ibtnAttribute") as ImageButton;//查看属性按钮
            string imageUrl = imgFileType.ImageUrl;//类型图片的ImageUrl
            string fileId = gvFiles.DataKeys[gvr.RowIndex].Value.ToString();//文件id

            //如果是文件夹,绑定CommandArgument
            if (imageUrl == "../images/file/folder.gif")
            {
                lbtnFileName.CommandArgument = fileId;
            }
            else
                lbtnFileName.PostBackUrl = "~/File/ManageFile.aspx?fileId=" + fileId;
        }
    }
    protected void lbtnFileName_Click(object sender, EventArgs e)
    {
        LinkButton lbtnFileName = sender as LinkButton;
        if (lbtnFileName.CommandArgument != null)
            Response.Redirect("~/File/FileMain.aspx?fileId=" + lbtnFileName.CommandArgument);

        //ScriptManager.RegisterStartupScript(this, this.GetType(), "str", "<script>alert('" + sender.ToString() + "')</script>", false);
    }
    protected void btnNewFolder_Click(object sender, ImageClickEventArgs e)
    {
        if (txtAddress.Text.Trim() != "")
        {
            //新增文件夹，把文件地址传过去
            Response.Redirect("ManageFolder.aspx?fileAddress=" + txtAddress.Text.Trim());
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "str", "<script>alert('请选择一个您要新增文件夹的位置!')</script>", false);
        }
    }
    protected void btnNewFile_Click(object sender, ImageClickEventArgs e)
    {
        if (txtAddress.Text.Trim() != "")
        {
            //新增文件，把文件地址传过去
            Response.Redirect("ManageFile.aspx?fileAddress=" + txtAddress.Text.Trim());
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "str", "<script>alert('请选择一个您要新增文件的位置!')</script>", false);
        }
    }
    //绑定树形菜单
    public void FillTreeView(int nodeId, TreeNode node)
    {
        DataView dv = new DataView(dt);
        dv.RowFilter = "ParentId=" + nodeId;

        foreach (DataRowView dr in dv)
        {
            TreeNode nodeTemp = new TreeNode();
            nodeTemp.Text = dr["FileName"].ToString();
            nodeTemp.Value = dr["Id"].ToString();
            nodeTemp.ImageUrl = "../images/file/folder.gif";
            nodeTemp.ToolTip = dr["FileName"].ToString();

            if (nodeId == 0)
            {
                tvFile.Nodes.Add(nodeTemp);
            }
            else
            {
                node.ChildNodes.Add(nodeTemp);
            }

            FillTreeView(int.Parse(nodeTemp.Value), nodeTemp);
        }
    }
    //移动
    protected void tvFile_SelectedNodeChanged(object sender, EventArgs e)
    {
        int idTo = int.Parse(tvFile.SelectedValue);//移动到的文件夹的id
        string pathTo = FileInfoManager.GetFilePathByFileId(idTo);//移动到的文件路径
        int idFrom = int.Parse(ViewState["FileId"].ToString());//要移动的文件的id
        string pathFrom = FileInfoManager.GetFilePathByFileId(idFrom);//要移动的文件路径

        bool b = FileInfoManager.ModifyParentId(idFrom, idTo);//修改父级id
        if (b)
        {
            ModifyPath(pathFrom, pathTo);//修改路径

            string[] pa = pathFrom.Split('\\');
            string p = pa[pa.Length - 1];
            string path = pathTo + "\\" + p;

            string type = FileInfoManager.GetFileTypeNameByFileId(idFrom);//根据id查询文件类型
            ManageAllFile manage = new ManageAllFile();
            if (type == "文件夹")
                manage.ReNameDirectory(pathFrom, path);
            else
                manage.ReNameFile(pathFrom, path);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "str", "<script>parent.location='FileManage.aspx';</script>", false);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "str", "<script>alert('移动失败，请重新再试!')</script>", false);
        }

    }

    /// <summary>
    /// 修改路径
    /// </summary>
    /// <param name="pathFrom">要移动的文件路径</param>
    /// <param name="pathTo">移动到的文件路径</param>
    private void ModifyPath(string pathFrom,string pathTo)
    {
        //c:\\部门文档\研发部\所有项目\Java项目\ddd.txt  | pathFrom
        //c:\\部门文档\研发部\部门员工介绍               | pathTo
        string[] pa = pathFrom.Split('\\');
        string p = pa[pa.Length - 1];

        string path = pathTo + "\\" + p;
        int id = FileInfoManager.GetFileIdByAddress(pathFrom);
        FileInfoManager.ModifyFilePath(id, path);//修改文件路径

        IList<FileInfo> list = FileInfoManager.GetFileByParentId(id);//查询修改的文件的子文件（夹）
        foreach (FileInfo fileInfo in list)
        {
            ModifyPath(fileInfo.FilePath, pathTo + "\\" + p);
        }
    }
}

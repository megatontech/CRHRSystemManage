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
using System.Web.Caching;
using MyOffice.BLL;
using MyOffice.Models;

public partial class File_FileTree : System.Web.UI.Page
{
    private DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dt = FileInfoManager.GetAllFileForTreeView();
            FillTreeView(0, null);
            
        }
    }

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
            nodeTemp.NavigateUrl = "FileMain.aspx?fileId=" + dr["Id"].ToString();
            nodeTemp.Target = "mainFrame";

            if (nodeId == 0)
            {
                tvFile.Nodes[0].ChildNodes.Add(nodeTemp);
            }
            else
            {
                node.ChildNodes.Add(nodeTemp);
            }

            FillTreeView(int.Parse(nodeTemp.Value), nodeTemp);
        }
    }
}

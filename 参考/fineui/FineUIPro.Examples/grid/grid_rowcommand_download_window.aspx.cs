using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

namespace FineUIPro.Examples.grid
{
    public partial class grid_rowcommand_download_window : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        #region LoadData

        private void LoadData()
        {
            BindGrid();
        }

        private void BindGrid()
        {
            DataTable table = GetDataTable();

            Grid1.DataSource = table;
            Grid1.DataBind();

        }

        #endregion

        #region Events

        protected void Button1_Click(object sender, EventArgs e)
        {
            labResult.Text = HowManyRowsAreSelected(Grid1);
        }

        protected void Grid1_RowCommand(object sender, FineUIPro.GridCommandEventArgs e)
        {
            object[] keys = Grid1.DataKeys[e.RowIndex];
            string result = String.Format("你点击了第 {0} 行，第 {1} 列，行命令是 {2}", e.RowIndex + 1, e.ColumnIndex + 1, e.CommandName) +
                       "<br>" +
                       String.Format("当前行数据 - 编号：{0}，姓名：{1}", keys[0], keys[1]);

            if (e.CommandName == "Action1")
            {
                // AJAX回发
                labResult.Text = result;
            }
            else if (e.CommandName == "Action2")
            {
                // 下载文件页面不会触发 iframeload 事件，所以无法得知IFrame已经加载完毕 或者 文件是否已经下载
                // 这里只能简单使用定时
                // http://stackoverflow.com/questions/17184970/iframe-onload-wont-fire-when-dumping-a-file
                string downloadUrl = String.Format("~/grid/download.ashx?id={0}&name={1}&rowIndex={2}", keys[0], HttpUtility.UrlEncode(keys[1].ToString()), e.RowIndex + 1);

                //PageContext.RegisterStartupScript(winDownload.GetShowReference(downloadUrl) + String.Format("window.setTimeout(function(){{{0}}}, 1000)", winDownload.GetHideReference()));

                PageContext.RegisterStartupScript(String.Format("window.location.href='{0}';", ResolveUrl(downloadUrl)));
            }
        }

        #endregion
    }
}

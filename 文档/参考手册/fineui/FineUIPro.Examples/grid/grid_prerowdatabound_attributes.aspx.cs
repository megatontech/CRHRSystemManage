using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

namespace FineUIPro.Examples.grid
{
    public partial class grid_prerowdatabound_attributes : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();

            }
        }

        #region BindGrid

        private void BindGrid()
        {
            DataTable table = GetDataTable();

            Grid1.DataSource = table;
            Grid1.DataBind();
        }

        #endregion

        #region Events

        /// <summary>
        /// 这个事件会在渲染每一行前调用，因此改变了列的属性，那么渲染每一行时此列的属性都发生了变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Grid1_PreRowDataBound(object sender, FineUIPro.GridPreRowEventArgs e)
        {
            // 如果绑定到 DataTable，那么这里的 DataItem 就是 DataRowView
            DataRowView row = e.DataItem as DataRowView;
            int entranceYear = Convert.ToInt32(row["EntranceYear"]);

            BoundField bfEntranceYear = Grid1.FindColumn("bfEntranceYear") as BoundField;


            if (entranceYear < 2004)
            {
                bfEntranceYear.Attributes["data-year"] = "year1";
            }
            else if (entranceYear >= 2004 && entranceYear < 2007)
            {
                bfEntranceYear.Attributes["data-year"] = "year2";
            }
            else if (entranceYear >= 2007)
            {
                bfEntranceYear.Attributes["data-year"] = "year3";
            }


        }


        protected void Grid1_RowCommand(object sender, FineUIPro.GridCommandEventArgs e)
        {
            if (e.CommandName == "Action1" || e.CommandName == "Action2")
            {
                labResult.Text = String.Format("你点击了第 {0} 行，第 {1} 列，行命令是 {2}", e.RowIndex + 1, e.ColumnIndex + 1, e.CommandName);
            }
        }

        #endregion

    }
}

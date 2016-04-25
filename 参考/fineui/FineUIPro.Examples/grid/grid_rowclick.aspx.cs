﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;

namespace FineUIPro.Examples.grid
{
    public partial class grid_rowclick : PageBase
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
            DataTable table = GetDataTable();

            Grid1.DataSource = table;
            Grid1.DataBind();
        }

        #endregion

        #region Events


        protected void Grid1_RowClick(object sender, FineUIPro.GridRowClickEventArgs e)
        {
            Notify(String.Format("你点击了第 {0} 行（单击），第 {1} 列", e.RowIndex + 1, Grid1.SelectedCell[1]));
        }

        #endregion


    }
}

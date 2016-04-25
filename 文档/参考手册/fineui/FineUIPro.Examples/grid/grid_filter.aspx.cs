using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;
using Newtonsoft.Json.Linq;

namespace FineUIPro.Examples.grid
{
    public partial class grid_filter : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FilterDataRowItem = FilterDataRowItemImplement;

            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        #region BindGrid

        private void BindGrid()
        {
            DataTable table = GetFilteredTable(Grid1.FilteredData);

            Grid1.DataSource = table;
            Grid1.DataBind();

        }


        #endregion

        #region Events

        protected void Grid1_FilterChange(object sender, EventArgs e)
        {
            BindGrid();

            labResult.Text = String.Format("过滤参数：<pre>{0}</pre>", Grid1.FilteredData.ToString());
        }

        #endregion

        #region FilterDataRowItem

        private bool FilterDataRowItemImplement(object sourceObj, string fillteredOperator, object fillteredObj, string column)
        {
            bool valid = false;

            if (column == "Name")
            {
                string sourceValue = sourceObj.ToString();
                string fillteredValue = fillteredObj.ToString();

                if (sourceValue.Contains(fillteredValue))
                {
                    valid = true;
                }
            }

            return valid;
        } 

        #endregion

    }
}

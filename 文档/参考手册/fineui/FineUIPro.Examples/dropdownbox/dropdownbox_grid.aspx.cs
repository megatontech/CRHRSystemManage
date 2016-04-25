using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace FineUIPro.Examples.dropdownbox
{
    public partial class dropdownbox_grid : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        private void BindGrid()
        {
            DataTable table = GetDataTable();

            Grid1.DataSource = table;
            Grid1.DataBind();

        }



        protected void btnGetSelection_Click(object sender, EventArgs e)
        {
            if (DropDownBox1.Value != null)
            {
                labResult.Text = String.Format("下拉框文本：{0}（值：{1}）", DropDownBox1.Text, String.Join(",", DropDownBox1.Values));
            }
            else
            {
                labResult.Text = "下拉框为空";
            }
        }

       

    }
}

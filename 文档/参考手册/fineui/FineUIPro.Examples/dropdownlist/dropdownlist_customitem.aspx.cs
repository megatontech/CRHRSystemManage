using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace FineUIPro.Examples.dropdownlist
{
    public partial class dropdownlist_customitem : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDataTableToDropDownList();
            }
        }

        #region BindDataTableToDropDownList

        private void BindDataTableToDropDownList()
        {
            DropDownList1.DataTextField = "Name";
            DropDownList1.DataValueField = "Id";
            DropDownList1.DataSource = GetDataTable();
            DropDownList1.DataBind();
        }

        #endregion

        #region Events

        protected void DropDownList1_ItemDataBound(object sender, ListItemEventArgs e)
        {
            DataRowView row = e.DataItem as DataRowView;

            e.Item.Display = String.Format("<div class=\"item-name\">{0}</div><div class=\"item-desc\">{1}</div>", row["Name"], row["Desc"]);
        }

        protected void btnGetSelection_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedItem != null)
            {
                labResult.Text = String.Format("选中项：{0}（值：{1}）", DropDownList1.SelectedItem.Text, DropDownList1.SelectedValue);
            }
            else
            {
                labResult.Text = "无选中项";
            }
        }

        #endregion



    }
}

using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace FineUIPro.Examples.dropdownlist
{
    public partial class dropdownlist_itemicon : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ResolveDropDownListItems();
            }
        }

        private void ResolveDropDownListItems()
        {
            foreach (ListItem item in DropDownList1.Items)
            {
                item.Display = String.Format("<img src=\"{0}\">&nbsp;", ResolveUrl("~/res/icon/flag_" + item.Value + ".png")) + item.Text;
            }
        }

        protected void btnSelectItem6_Click(object sender, EventArgs e)
        {
            DropDownList1.SelectedValue = "au";
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



    }
}

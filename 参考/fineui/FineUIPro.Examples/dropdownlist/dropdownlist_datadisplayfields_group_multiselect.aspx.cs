using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace FineUIPro.Examples.dropdownlist
{
    public partial class dropdownlist_datadisplayfields_group_multiselect : PageBase
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
            DropDownList1.DataGroupField = "Major";
            DropDownList1.DataDisplayFields = new string[] { "Name", "Desc"};
            DropDownList1.DataDisplayFormatString = "<div class=\"item-name\">{0}</div><div class=\"item-desc\">{1}</div>";
            DropDownList1.DataTextField = "Name";
            DropDownList1.DataValueField = "Id";
            DropDownList1.DataSource = GetDataTable();
            DropDownList1.DataBind();
        }

        #endregion

        #region Events


        protected void btnGetSelection_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedItem != null)
            {
                List<string> texts = new List<string>();
                List<string> values = new List<string>();
                foreach (ListItem item in DropDownList1.SelectedItemArray)
                {
                    texts.Add(item.Text);
                    values.Add(item.Value);
                }

                labResult.Text = String.Format("选中项文本：{0}<br/>选中项值：{1}",
                    String.Join("&nbsp;&nbsp;", texts.ToArray()),
                    String.Join("&nbsp;&nbsp;", values.ToArray()));
            }
            else
            {
                labResult.Text = "无选中项";
            }
        }

        #endregion



    }
}

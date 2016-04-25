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
    public partial class grid_editor_cell_selectfromwindow_iframe : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                btnClose.OnClientClick = ActiveWindow.GetHideReference();


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

        // 根据行ID来获取行数据
        private DataRow FindRowByID(int rowID)
        {
            DataTable table = GetDataTable();
            foreach (DataRow row in table.Rows)
            {
                if (Convert.ToInt32(row["Id"]) == rowID)
                {
                    return row;
                }
            }
            return null;
        }

        #endregion

        #region Events

        private void SelectGridRow()
        {
            object[] keys = Grid1.DataKeys[Grid1.SelectedRowIndex];
            DataRow dataRow = FindRowByID(Convert.ToInt32(keys[0]));

            JObject dataObj = new JObject();
            dataObj.Add("EditingRowIndex", Request.QueryString["EditingRowIndex"]);
            dataObj.Add("Name", dataRow["Name"].ToString());
            dataObj.Add("Gender", dataRow["Gender"].ToString());
            dataObj.Add("EntranceYear", dataRow["EntranceYear"].ToString());
            dataObj.Add("EntranceDate", dataRow["EntranceDate"].ToString());
            dataObj.Add("AtSchool", Convert.ToBoolean(dataRow["AtSchool"]));
            dataObj.Add("Major", dataRow["Major"].ToString());

            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference(dataObj.ToString(Newtonsoft.Json.Formatting.None)));
        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            SelectGridRow();
        }

        protected void Grid1_RowDoubleClick(object sender, GridRowClickEventArgs e)
        {
            SelectGridRow();
        }

        
        #endregion

    }
}

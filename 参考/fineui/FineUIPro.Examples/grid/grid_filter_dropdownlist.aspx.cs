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
    public partial class grid_filter_dropdownlist : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FilterDataRowItem = FilterDataRowItemImplement;

            if (!IsPostBack)
            {
                BindGrid();

                InitFilterGroupList();
            }
        }

        private void InitFilterGroupList()
        {
            for (int i = 1; i <= 5; i++)
            {
                ListItem item = new ListItem();
                item.Value = i.ToString();
                item.Text = String.Format("分组{0}", i);
                item.Display = String.Format("<img src=\"{0}\">&nbsp;{1}", ResolveUrl("~/res/images/16/" + i.ToString() + ".png"), item.Text);

                groupList.Items.Add(item);
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

        #region FilterDataRowItemImplement

        private bool FilterDataRowItemImplement(object sourceObj, string fillteredOperator, object fillteredObj, string column)
        {
            bool valid = false;

            if (column == "Name")
            {
                string sourceValue = sourceObj.ToString();
                string fillteredValue = fillteredObj.ToString();
                if (fillteredOperator == "equal")
                {
                    if (sourceValue == fillteredValue)
                    {
                        valid = true;
                    }
                }
                else if (fillteredOperator == "contain")
                {
                    if (sourceValue.Contains(fillteredValue))
                    {
                        valid = true;
                    }
                }
                else if (fillteredOperator == "start")
                {
                    if (sourceValue.StartsWith(fillteredValue))
                    {
                        valid = true;
                    }
                }
                else if (fillteredOperator == "end")
                {
                    if (sourceValue.EndsWith(fillteredValue))
                    {
                        valid = true;
                    }
                }
            }
            else if (column == "EntranceYear")
            {
                int sourceValue = Convert.ToInt32(sourceObj);
                int fillteredValue = Convert.ToInt32(fillteredObj);

                if (fillteredOperator == "greater")
                {
                    if (sourceValue > fillteredValue)
                    {
                        valid = true;
                    }
                }
                else if (fillteredOperator == "less")
                {
                    if (sourceValue < fillteredValue)
                    {
                        valid = true;
                    }
                }
                else if (fillteredOperator == "equal")
                {
                    if (sourceValue == fillteredValue)
                    {
                        valid = true;
                    }
                }

            }
            else if (column == "LogTime")
            {
                DateTime sourceValue = Convert.ToDateTime(sourceObj);
                DateTime fillteredValue = Convert.ToDateTime(fillteredObj);

                if (fillteredOperator == "greater")
                {
                    if (sourceValue > fillteredValue)
                    {
                        valid = true;
                    }
                }
                else if (fillteredOperator == "less")
                {
                    if (sourceValue < fillteredValue)
                    {
                        valid = true;
                    }
                }
                else if (fillteredOperator == "equal")
                {
                    if (sourceValue == fillteredValue)
                    {
                        valid = true;
                    }
                }

            }
            else if (column == "Major" || column == "Group")
            {
                string sourceValue = sourceObj.ToString();
                JArray fillteredValue = JArray.Parse(fillteredObj.ToString());

                foreach (string filltereditem in fillteredValue)
                {
                    if (filltereditem == sourceValue)
                    {
                        valid = true;
                        break;
                    }
                }
            }
            else if (column == "AtSchool")
            {
                bool sourceValue = Convert.ToBoolean(sourceObj);
                bool fillteredValue = Convert.ToBoolean(fillteredObj);

                if (sourceValue == fillteredValue)
                {
                    valid = true;
                }
            }
            else if (column == "Gender")
            {
                int sourceValue = Convert.ToInt32(sourceObj);
                int fillteredValue = Convert.ToInt32(fillteredObj);

                if (sourceValue == fillteredValue)
                {
                    valid = true;
                }
            }
            

            return valid;
        }

        #endregion

    }
}

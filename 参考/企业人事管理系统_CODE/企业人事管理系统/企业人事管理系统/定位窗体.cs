using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 企业人事管理系统
{
    public partial class 定位窗体 : Form
    {
        #region[构造窗体]
        public 定位窗体(TextBox 编号1, TextBox 姓名1, TextBox 部门1, TextBox 职位1)
        {
            编号2 = 编号1;
            姓名2 = 姓名1;
            部门2 = 部门1;
            职位2 = 职位1;
            InitializeComponent();
        }
        #endregion

        #region[公共变量]
        SQL_Link Sql_Linker = new SQL_Link();
        DataTable DT = new DataTable();
        TextBox 编号2;
        TextBox 姓名2;
        TextBox 部门2;
        TextBox 职位2;
        #endregion

        #region[事件] [Form_Load]
        private void 定位窗体_Load(object sender, EventArgs e)
        {
            Sql_Linker.SQL_Bind("select 编号,姓名,部门,职位 from Person_Info", MDI主窗口.Send_Data_2, DT, dataGridView1);
            DataSet DS = Sql_Linker.SQL_Select("select 部门名称 from Basic_Bm", MDI主窗口.Send_Data_2);
            部门.Items.Add("全体员工");
            foreach (DataRow DR in DS.Tables[0].Rows)
            {
                部门.Items.Add(DR.ItemArray[0].ToString());
            }
            部门.Text = "全体员工";
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.ColumnHeader);
        }
        #endregion

        #region[事件] [姓名定位更改]
        private void 姓名_TextChanged(object sender, EventArgs e)
        {
            if (姓名.Text.Trim() != "")
            {
                DataTable DDT = new DataTable();
                DDT.Columns.Add("编号");
                DDT.Columns.Add("姓名");
                DDT.Columns.Add("部门");
                DDT.Columns.Add("职位");
                foreach (DataRow DR in DT.Select("姓名 like '%" + 姓名.Text.Trim() + "%'"))
                {
                    DDT.Rows.Add(DR.ItemArray);
                }
                dataGridView1.DataSource = DDT;
            }
            else
                dataGridView1.DataSource = DT;
        }
        #endregion

        #region[事件] [全部员工按钮]
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DT;
        }
        #endregion

        #region[事件] [下拉列表选取]
        private void 部门_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (部门.Text != "全体员工")
            {
                DataTable DDT = new DataTable();
                DDT.Columns.Add("编号");
                DDT.Columns.Add("姓名");
                DDT.Columns.Add("部门");
                DDT.Columns.Add("职位");
                foreach (DataRow DR in DT.Select("部门 ='" + 部门.Text.Trim() + "'"))
                {
                    DDT.Rows.Add(DR.ItemArray);
                }
                dataGridView1.DataSource = DDT;
            }
            else
                dataGridView1.DataSource = DT;
        }
        #endregion

        #region[事件] [确定按钮]
        private void 确定_Click(object sender, EventArgs e)
        {
            this.Hide();
            编号2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            姓名2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            部门2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            职位2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            this.Dispose();
            this.Close();
        }
        #endregion

        #region[事件] [双击单元格]
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Hide();
            编号2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            姓名2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            部门2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            职位2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            this.Dispose();
            this.Close();
        }
        #endregion


    }
}
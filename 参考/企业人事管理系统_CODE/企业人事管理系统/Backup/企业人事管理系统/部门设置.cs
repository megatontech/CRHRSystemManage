using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 企业人事管理系统
{
    public partial class 部门设置 : Form
    {
        #region[公共变量]
        public string[] BM_String = new string[6];
        DataTable SDT = new DataTable();
        SQL_Link Link = new SQL_Link();
        Public_Fun PF = new Public_Fun();
        public static bool UP_SQL = false;
        #endregion

        #region[窗体设计器]
        public 部门设置()
        {
            InitializeComponent();
        }
        #endregion

        #region[事件] [FormLoad]
        private void 部门设置_Load(object sender, EventArgs e)
        {
            PF.Fun_Tree(treeView1, MDI主窗口.Send_Data_2);
            Link.SQL_Bind("select * from Basic_Bm", MDI主窗口.Send_Data_2, SDT, dataGridView1);
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.ColumnHeader);
        }
        #endregion

        #region[事件] [展开所有节点]
        private void 展开所有节点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeView1.ExpandAll();
        }
        #endregion

        #region[事件] [折叠所有节点]
        private void 折叠所有节点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeView1.CollapseAll();
        }
        #endregion

        #region[事件] [添加部门]
        private void button1_Click_1(object sender, EventArgs e)
        {
            Control CT = (Control)sender;
            部门信息编辑 form = new 部门信息编辑(CT.Text, "0");
            form.ShowDialog();
        }
        #endregion

        #region[事件] [添加子部门]
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Control CT = (Control)sender;
                部门信息编辑 form = new 部门信息编辑(CT.Text, treeView1.SelectedNode.Text);
                form.ShowDialog();
            }
            catch 
            {
                MessageBox.Show("未选取部门");
            }
        }
        #endregion
        
        #region[事件] [窗体激活]
        private void 部门设置_Activated(object sender, EventArgs e)
        {
            if (UP_SQL == true)
            {
                treeView1.Nodes.Clear();
                PF.Tree_Node_P = false;
                PF.Fun_Tree(treeView1, MDI主窗口.Send_Data_2);
                Link.SQL_Bind("select * from Basic_Bm", MDI主窗口.Send_Data_2, SDT, dataGridView1);
                dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.ColumnHeader);
                UP_SQL = false;
            }
        }
        #endregion

        #region[事件] [编辑按钮]
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Control CT = (Control)sender;
                部门信息编辑 form = new 部门信息编辑(CT.Text, treeView1.SelectedNode.Text);
                form.ShowDialog();
            }
            catch
            {
                MessageBox.Show("未选取部门");
            }
        }
        #endregion

        #region[事件] [删除按钮]
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("您确定要删除" + treeView1.SelectedNode.Text + "及其所有下属部门?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    string Update_String = "delete from Basic_Bm where 部门名称='" + treeView1.SelectedNode.Text + "' or 上级部门='" + treeView1.SelectedNode.Text + "'";
                    Link.SQL_Update(Update_String, MDI主窗口.Send_Data_2);
                    treeView1.Nodes.Clear();
                    PF.Tree_Node_P = false;
                    PF.Fun_Tree(treeView1, MDI主窗口.Send_Data_2);
                    Link.SQL_Bind("select * from Basic_Bm", MDI主窗口.Send_Data_2, SDT, dataGridView1);
                    dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.ColumnHeader);
                    UP_SQL = false;
                }
            }
            catch 
            {
                MessageBox.Show("未选取部门");
            }
        }
        #endregion
    }
}
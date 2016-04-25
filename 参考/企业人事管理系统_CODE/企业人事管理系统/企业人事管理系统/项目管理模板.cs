using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Net.Sockets;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace 企业人事管理系统
{
    public partial class 项目管理模板 : Form
    {
        public 项目管理模板()
        {
            InitializeComponent();
        }

        #region[公共变量]
        static SQL_Link SQL_Linker = new SQL_Link();
        Public_Fun PF = new Public_Fun();
        SqlConnection Link_Conn;
        public static SqlDataAdapter SDA_0 = new SqlDataAdapter();
        public static DataTable SDT_0 = new DataTable();
        string Table_Name;
        string Date_Column_Name;
        string Select_String;
        bool Add_Info_Control = false;//是否动态添加了编辑框控件

        #region[查询变量]
        DataTable DT;
        bool First_AND_OR = false;
        string LS_Select_String;
        bool IF_ADD_ITEMS = false;
        #endregion

        #endregion

        #region[公共函数]
        #region[函数] [TreeView选取]
        public void TreeView_Select(string Table_Name, string Date_Column_Name)
        {
            SDT_0 = new DataTable();
            Select_String = @"select Person_Info.姓名,Person_Info.部门,Person_Info.职位,"+Table_Name+@".*
from "+Table_Name+@" ,(select 姓名,部门,职位,编号 from Person_Info) Person_Info
where "+Table_Name+@".编号 = Person_Info.编号";
            if (treeView1.SelectedNode.Text == "全体人员")
            {
                if (checkBox2.Checked == true)
                {
                    Select_String += @" and substring(convert(varchar(10), " + Date_Column_Name + ", 120),1,8) like (substring(convert(varchar(10), getdate(), 120),1,8))  ";
                }
                else { }
            }
            else
            {
                if (checkBox2.Checked == false)
                {
                    Select_String += " and ( 部门 = '" + treeView1.SelectedNode.Text + "'";
                    if (checkBox1.Checked == true)
                    {
                        foreach (TreeNode TN in treeView1.SelectedNode.Nodes)
                        {
                            Select_String += " or 部门 ='" + TN.Text + "'";
                            Child_BM_Worker(TN);
                        }
                    }
                    else { }
                    Select_String += ")";
                }
                else
                {
                    Select_String += @" and substring(convert(varchar(10), " + Date_Column_Name + ", 120),1,8) like (substring(convert(varchar(10), getdate(), 120),1,8)) " + " and ( 部门 = '" + treeView1.SelectedNode.Text + "' ";
                    if (checkBox1.Checked == true)
                    {
                        foreach (TreeNode TN in treeView1.SelectedNode.Nodes)
                        {
                            Select_String += " or 部门 ='" + TN.Text + "'";
                            Child_BM_Worker(TN);
                        }
                    }
                    else { }
                    Select_String += ")";
                }
            }
            SDA_0 = SQL_Linker.SQL_Bind(Select_String, Link_Conn, SDT_0, dataGridView1);
            dataGridView1.Focus();
            dataGridView1.Columns["标识"].Visible = false;
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.ColumnHeader);
        }
        #endregion

        #region[函数] [显示下级部门员工]
        public void Child_BM_Worker(TreeNode TN)
        {
            foreach (TreeNode TN_1 in TN.Nodes)
            {
                Select_String += " or " + '"' + "部门" + '"' + "='" + TN_1.Text + "'";
                Child_BM_Worker(TN_1);
            }
        }
        #endregion

        #region[查询函数]
        public void Select_Fun()
        {
            SDA_0 = SQL_Linker.SQL_Bind(MDI主窗口.Select_Together_String, MDI主窗口.Send_Data_2, SDT_0, dataGridView1);
        }
        #endregion

        #region[查询窗体公共函数]

        #region[函数] [判断条件]
        public string Auto_IF_String(string IF_String)
        {
            if (IF_String == "包含")
                return " like ";
            else if (IF_String == "等于")
                return " = ";
            else if (IF_String == "大于")
                return " > ";
            else if (IF_String == "大于等于")
                return " >= ";
            else if (IF_String == "小于")
                return " < ";
            else if (IF_String == "小于等于")
                return " <= ";
            else
                return " <> ";
        }
        #endregion

        #region[函数] [值+后缀,根据条件判断后缀]
        public string Auto_Word(string IF_String)
        {
            if (IF_String == " like ")
                return @" '%" + 值.Text.Trim() + @"%'";
            else
                return " '" + 值.Text.Trim() + "'";
        }
        #endregion

        #region[函数] [动态加载编辑框]
        public void D_Info_Load()
        {
            if (Add_Info_Control == false)
            {
                int j = 0;
                DataTable D_DT = SQL_Linker.SQL_Select("select * from " + Table_Name, MDI主窗口.Send_Data_2).Tables[0];
                foreach (DataColumn DC in D_DT.Columns)
                {
                    if (DC.ColumnName.Trim() != "编号" && DC.ColumnName.Trim() != "标识")
                    {
                        Label L = new Label();
                        L.Text = DC.ColumnName;
                        L.Size = new Size(53, 12);
                        L.AutoEllipsis = true;
                        L.Location = new Point(((j % 2) * 210 + 26), j / 2 * 30);
                        panel3.Controls.Add(L);
                        j++;

                        TextBox TB = new TextBox();
                        TB.Location = new Point((((j - 1) % 2) * 210 + 85), (j - 1) / 2 * 30);
                        编号.Enabled = true;
                        button2.Enabled = true;
                        if (groupBox4.Text.Trim() == "修改")
                        {
                        //    if (DGR == null)
                        //        DGR = dataGridView1.CurrentRow;
                            编号.Enabled = false;
                            button2.Enabled = false;
                            编号.Text = dataGridView1.CurrentRow.Cells[dataGridView1.Columns["编号"].Index].Value.ToString();
                            姓名.Text = dataGridView1.CurrentRow.Cells[dataGridView1.Columns["姓名"].Index].Value.ToString();
                            部门.Text = dataGridView1.CurrentRow.Cells[dataGridView1.Columns["部门"].Index].Value.ToString();
                            职位.Text = dataGridView1.CurrentRow.Cells[dataGridView1.Columns["职位"].Index].Value.ToString();
                            TB.Text = dataGridView1.CurrentRow.Cells[dataGridView1.Columns[L.Text].Index].Value.ToString();
                            TB.TextChanged += new EventHandler(MY_TextChanged);
                        }
                        TB.Name = L.Text;
                        TB.Size = new Size(100, 21);
                        panel3.Controls.Add(TB);
                    }
                }
                Add_Info_Control = true;
            }
        }
        #endregion

        #region[函数] [自动判断编辑框操作]
        public void Auto_Edit_Sql()
        {
            string Edit_Sql_String = "";
            foreach (Control CT in panel3.Controls)
            {
                if (CT is TextBox)
                {
                    if (groupBox4.Text.Trim() == "新增")
                        Edit_Sql_String += " , '" + CT.Text.Trim() + "'";
                    else
                    {
                        if (Edit_Sql_String == "")
                            Edit_Sql_String = "[" + CT.Name + "]='" + CT.Text + "'";
                        else
                            Edit_Sql_String += ",[" + CT.Name + "]='" + CT.Text + "'";
                    }
                }
            }
            if (groupBox4.Text.Trim() == "新增")
            {
                SQL_Linker.SQL_Update("insert into " + Table_Name + " values ('" + 编号.Text.Trim() + "'" + Edit_Sql_String + ")", MDI主窗口.Send_Data_2);
                TreeView_Select(Table_Name, Date_Column_Name);
            }
            else if (groupBox4.Text.Trim() == "修改")
            {
                SQL_Linker.SQL_Update("update " + Table_Name + " set " + Edit_Sql_String + " where [标识]=" + dataGridView1.CurrentRow.Cells[dataGridView1.Columns["标识"].Index].Value.ToString(), MDI主窗口.Send_Data_2);
                TreeView_Select(Table_Name, Date_Column_Name);
            }
        }
        #endregion
        #endregion

        #region[函数] [自动判断窗体对应的数据库表]
        public void Auto_Return_Table_Name()
        {
            if (this.Text == "培训管理")
            {
                Table_Name = "Person_Pxjl";
                Date_Column_Name = "开始时间";
            }
            else if (this.Text == "奖惩管理")
            {
                Table_Name = "Person_Jcjl";
                Date_Column_Name = "奖惩日期";
            }
            else if (this.Text == "调薪管理")
            {
                Table_Name = "Person_Txjl";
                Date_Column_Name = "调薪日期";
            }
            else if (this.Text == "考评管理")
            {
                Table_Name = "Person_Kpjl";
                Date_Column_Name = "考评日期";
            }
            else
            {
                Table_Name = "Person_Htjl";
                Date_Column_Name = "结束时间";
            }
        }
        #endregion
        #endregion

        #region[事件] [Form_Load]
        private void 项目管理模板_Load(object sender, EventArgs e)
        {
            Link_Conn = MDI主窗口.Send_Data_2;
            PF.Fun_Tree(treeView1, Link_Conn);
            groupBox2.Text = this.Text;
            Auto_Return_Table_Name();
        }
        #endregion

        #region[事件] [TreeView选取]
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeView_Select(Table_Name, Date_Column_Name);
        }
        #endregion

        #region[事件] [RadioButton选取]
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //TreeView_Select();
        }
        #endregion

        #region[事件] [CheckBox选取]
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            TreeView_Select(Table_Name, Date_Column_Name);
        }
        #endregion

        #region[事件] [查询按钮]
        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            groupBox3.Visible = true;
            groupBox3.Dock = DockStyle.Left;
            groupBox4.Dock = DockStyle.Fill;
            groupBox4.BringToFront();
            listView1.Clear();
            #region[加载查询]
            if (IF_ADD_ITEMS == false)
            {
                DT = SQL_Linker.SQL_Select(@"select Person_Info.姓名,Person_Info.部门,Person_Info.职位," + Table_Name + @".*
from " + Table_Name + @" ,(select 姓名,部门,职位,编号 from Person_Info) Person_Info
where " + Table_Name + @".编号 = Person_Info.编号", MDI主窗口.Send_Data_2).Tables[0];
                LS_Select_String = @"select Person_Info.姓名,Person_Info.部门,Person_Info.职位," + Table_Name + @".*
from " + Table_Name + @" ,(select 姓名,部门,职位,编号 from Person_Info) Person_Info
where " + Table_Name + @".编号 = Person_Info.编号";
                foreach (DataColumn DC in DT.Columns)
                {
                    if (DC.ColumnName != "照片" && DC.ColumnName != "标识")
                        字段名.Items.Add(DC.ColumnName);
                    if (字段名.Text == "")
                        字段名.Text = DC.ColumnName;
                }
                条件.Text = "包含";
                IF_ADD_ITEMS = true;
            }
            #endregion
        }
        #endregion

        #region[事件] [模板关闭事件]
        private void 项目管理模板_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Text == "培训管理")
                MDI主窗口.培训管理 = false;
            else if (this.Text == "奖惩管理")
                MDI主窗口.奖惩管理 = false;
            else if (this.Text == "调薪管理")
                MDI主窗口.调薪管理 = false;
            else if (this.Text == "考评管理")
                MDI主窗口.考评管理 = false;
            else
                MDI主窗口.合同管理 = false;
        }
        #endregion

        #region[事件] [查询窗体添加按钮]
        private void 添加按钮_Click(object sender, EventArgs e)
        {
            if (LS_Select_String == null)
            {
                LS_Select_String = @"select Person_Info.姓名,Person_Info.部门,Person_Info.职位," + Table_Name + @".*
from " + Table_Name + @" ,(select 姓名,部门,职位,编号 from Person_Info) Person_Info
where " + Table_Name + @".编号 = Person_Info.编号";
            }
            if (值.Text.Trim() != "")
            {
                string ZD;
                if (字段名.Text.Trim() == "编号")
                    ZD = "Person_Info.编号";
                else
                    ZD = 字段名.Text;
                if (First_AND_OR == false)
                {
                    First_AND_OR = true;
                    LS_Select_String += " and ( " + ZD + Auto_IF_String(条件.Text) + Auto_Word(Auto_IF_String(条件.Text));
                    listView1.Items.Add(字段名.Text + " " + 条件.Text + " " + 值.Text.Trim());
                }
                else
                {
                    if (和.Checked == true)
                    {
                        listView1.Items.Add("并且");
                        LS_Select_String += " and " + ZD + Auto_IF_String(条件.Text) + Auto_Word(Auto_IF_String(条件.Text));
                    }
                    else
                    {
                        listView1.Items.Add("或者");
                        LS_Select_String += " or " + ZD + Auto_IF_String(条件.Text) + Auto_Word(Auto_IF_String(条件.Text));
                    }
                    listView1.Items.Add(字段名.Text + " " + 条件.Text + " " + 值.Text.Trim());
                }
            }
            else { }
        }
        #endregion

        #region[事件] [清空按钮]
        private void 清空_Click(object sender, EventArgs e)
        {
            MDI主窗口.Select_Together_String = null;
            listView1.Clear();
            LS_Select_String = null;
            First_AND_OR = false;
        }
        #endregion

        #region[事件] [确定按钮]
        private void 确定按钮_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count != 0)
            {
                LS_Select_String += " )";
                MDI主窗口.Select_Together_String = LS_Select_String;
                Select_Fun();
                MDI主窗口.Select_Together_String = null;
                groupBox3.Visible = false;
                groupBox4.Dock = DockStyle.Left;
                First_AND_OR = false;
                LS_Select_String = null;
                if (groupBox4.Visible == false)
                    panel2.Visible = false;
            }
        }
        #endregion

        #region[事件] [取消按钮]
        private void 取消按钮_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = false;
            groupBox4.Dock = DockStyle.Left;
            First_AND_OR = false;
            LS_Select_String = null;
            if (groupBox4.Visible == false)
                panel2.Visible = false;
        }
        #endregion

        #region[事件] [部门节点右键菜单]
        private void 全部展开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeView1.ExpandAll();
        }

        private void 全部折叠ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeView1.CollapseAll();
        }
        #endregion

        #region[事件] [新增按钮]
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            groupBox4.Text = ((ToolStripButton)sender).Text;
            groupBox4.Visible = true;
            groupBox4.Dock = DockStyle.Left;
            groupBox3.Dock = DockStyle.Fill; 
            groupBox3.BringToFront();
            #region[动态加载编辑框]
            D_Info_Load();
            #endregion
        }
        #endregion

        #region[事件] [编辑框取消按钮]
        private void 编辑_取消_Click(object sender, EventArgs e)
        {
            groupBox4.Visible = false;
            groupBox3.Dock = DockStyle.Left;
            if (groupBox3.Visible == false)
                panel2.Visible = false;
            编号.Text = null;
            姓名.Text = null;
            部门.Text = null;
            职位.Text = null;
        }
        #endregion

        #region[事件] [编辑框定位按钮]
        private void button2_Click(object sender, EventArgs e)
        {
            定位窗体 DW_Form = new 定位窗体(编号,姓名,部门,职位);
            DW_Form.ShowDialog();
        }
        #endregion

        #region[事件] [编辑框确定按钮]
        private void 编辑_确定_Click(object sender, EventArgs e)
        {
            Auto_Edit_Sql();
        }
        #endregion

        #region[事件] [编辑框控件自定义事件]
        public void MY_TextChanged(object sender, EventArgs e) 
        {
            Control Control_Name = (Control)sender;
            try
            {
                dataGridView1.CurrentRow.Cells[dataGridView1.Columns[Control_Name.Name].Index].Value = Control_Name.Text;
            }
            catch { }
        }
        #endregion

        #region[事件] [CurrentCell更改]
        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            if (groupBox4.Visible == true && groupBox4.Text.Trim() == "修改")
            {
                foreach (Control CT in panel3.Controls)
                {
                    if (CT is TextBox)
                    {
                        CT.Text = dataGridView1.CurrentRow.Cells[CT.Name].Value.ToString();
                    }
                }
                foreach (Control CT in groupBox4.Controls)
                {
                    if (CT is TextBox)
                    {
                        CT.Text = dataGridView1.CurrentRow.Cells[CT.Name].Value.ToString();
                    }
                }
            }
        }
        #endregion

        #region[事件] [删除按钮]
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            SQL_Linker.SQL_Update("delete from " + Table_Name + " where [标识]=" + dataGridView1.CurrentRow.Cells[dataGridView1.Columns["标识"].Index].Value.ToString(), MDI主窗口.Send_Data_2);
            TreeView_Select(Table_Name, Date_Column_Name);
        }
        #endregion


    }
}
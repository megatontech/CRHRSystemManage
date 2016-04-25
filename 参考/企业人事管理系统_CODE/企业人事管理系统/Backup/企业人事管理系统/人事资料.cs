using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace 企业人事管理系统
{
    public partial class 人事资料 : Form
    {
        #region[公共变量]
        static SQL_Link SQL_Linker = new SQL_Link();
        Public_Fun PF = new Public_Fun();
        SqlConnection Link_Conn;
        #region[变量] [数据映射窗体载入]
        SqlDataAdapter SDA = new SqlDataAdapter();//数据映射工作经历
        public static SqlDataAdapter SDA_0 = new SqlDataAdapter();//数据映射人事资料
        SqlDataAdapter SDA_1 = new SqlDataAdapter();//数据映射社会关系
        SqlDataAdapter SDA_2 = new SqlDataAdapter();//数据映射培训记录
        SqlDataAdapter SDA_3 = new SqlDataAdapter();//数据映射奖惩记录
        SqlDataAdapter SDA_4 = new SqlDataAdapter();//数据映射考评记录
        SqlDataAdapter SDA_5 = new SqlDataAdapter();//数据映射调薪记录
        SqlDataAdapter SDA_6 = new SqlDataAdapter();//数据映射出差记录
        SqlDataAdapter SDA_7 = new SqlDataAdapter();//数据映射合同记录
        DataTable SDT = new DataTable();//数据映射工作经历      
        public static DataTable SDT_0 = new DataTable();//数据映射人事资料
        DataTable SDT_1 = new DataTable();//数据映射社会关系
        DataTable SDT_2 = new DataTable();//数据映射培训记录
        DataTable SDT_3 = new DataTable();//数据映射奖惩记录
        DataTable SDT_4 = new DataTable();//数据映射考评记录
        DataTable SDT_5 = new DataTable();//数据映射调薪记录
        DataTable SDT_6 = new DataTable();//数据映射出差记录
        DataTable SDT_7 = new DataTable();//数据映射合同记录
        #endregion  
        DataSet DS_3;
        SqlDataAdapter Adapter;//图片的
        bool Add_Contrls = false;
        bool Image_ERRO = false;//是否已经显示过图片错误提示
        string Path = Application.StartupPath;
        object Cell_Value;
        string Select_String;//TreeView的下级部门员工显示
        bool CMB_Load = false;//动态人事资料是否已经加载下来列表
        #endregion

        #region [人事资料窗体][参数传递构造函数]
        public 人事资料()
        {
            InitializeComponent();
        }
        #endregion

        #region [事件] [FormLoad]
        private void 人事资料_Load(object sender, EventArgs e)
        {
            Link_Conn = MDI主窗口.Send_Data_2;
            PF.Fun_Tree(treeView1, Link_Conn);
            Bm_ComBox_Load();
            Image_SQL();
            //if (!MDI主窗口.User_P_Update)
                toolStripButton8.Enabled = false;
        }
        #endregion

        #region[公共函数]
        
        #region [函数] [ComboxLoad]
        public void Bm_ComBox_Load() 
        {
            部门.DataSource = PF.DS.Tables[0].DefaultView;
            部门.DisplayMember = "部门名称";
            部门.ValueMember = "部门名称";
            职位.DataSource = SQL_Linker.SQL_Select("select * from Basic_Zw", Link_Conn).Tables[0].DefaultView;
            职位.DisplayMember = "职位类别";
            职位.ValueMember = "职位类别";
            离职类别.DataSource = SQL_Linker.SQL_Select("select * from Basic_Lz", Link_Conn).Tables[0].DefaultView;
            离职类别.DisplayMember = "离职类别";
            离职类别.ValueMember = "离职类别";
        }
        #endregion

        #region[函数] [显示下级部门员工]
        public void Child_BM_Worker(TreeNode TN_2) 
        {
            foreach (TreeNode TN_3 in TN_2.Nodes) 
            {
                Select_String += " or " + '"' + "部门" + '"' + "='" + TN_3.Text + "'";
                if (radioButton1.Checked == true)
                {
                    Select_String += "and " + '"' + "在职情况" + '"' + "='在职'";
                }
                if (radioButton2.Checked == true)
                {
                    Select_String += "and " + '"' + "在职情况" + '"' + "='离职'";
                }
                Child_BM_Worker(TN_3);
            }
        }
        #endregion

        #region[函数] [TreeView选取]
        public void TreeView_Select() 
        {
            if (treeView1.SelectedNode.Text == "全体人员")
            {
                #region[判断] [在职情况]
                if (radioButton1.Checked == true)
                {
                    SDA_0 = SQL_Linker.SQL_Bind("select * from Person_Info" + " where " + '"' + "在职情况" + '"' + "='在职'", Link_Conn, SDT_0, dataGridView1);
                    groupBox14.Visible = false;
                }
                if (radioButton2.Checked == true)
                {
                    SDA_0 = SQL_Linker.SQL_Bind("select * from Person_Info" + " where " + '"' + "在职情况" + '"' + "='离职'", Link_Conn, SDT_0, dataGridView1);
                    groupBox14.Visible = true;
                }
                #endregion
            }
            else
            {
                Select_String = "select * from Person_Info where " + '"' + "部门 " + '"' + "= '" + treeView1.SelectedNode.Text + "'";
                #region[判断] [在职情况]
                if (radioButton1.Checked == true)
                {
                    Select_String += "and " + '"' + "在职情况" + '"' + "='在职'";
                    groupBox14.Visible = false;
                }
                if (radioButton2.Checked == true)
                {
                    Select_String += "and " + '"' + "在职情况" + '"' + "='离职'";
                    groupBox14.Visible = true;
                }
                #endregion
                if (checkBox1.Checked == true)
                {
                    foreach (TreeNode TN in treeView1.SelectedNode.Nodes)
                    {
                        Select_String += " or " + '"' + "部门" + '"' + "='" + TN.Text + "'";
                        #region[判断] [在职情况]
                        if (radioButton1.Checked == true)
                        {
                            Select_String += "and " + '"' + "在职情况" + '"' + "='在职'";
                            groupBox14.Visible = false;
                        }
                        if (radioButton2.Checked == true)
                        {
                            Select_String += "and " + '"' + "在职情况" + '"' + "='离职'";
                            groupBox14.Visible = true;
                        }
                        #endregion
                        Child_BM_Worker(TN);
                    }
                }
                SDA_0 = SQL_Linker.SQL_Bind(Select_String, Link_Conn, SDT_0, dataGridView1);
            }
            tabControl1.SelectTab(0);
            dataGridView1.Focus();
            dataGridView1.Columns["照片"].Visible = false;
            dataGridView1.Columns["离职日期"].Visible = false;
            dataGridView1.Columns["离职类别"].Visible = false;
            dataGridView1.Columns["离职原因"].Visible = false;
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.ColumnHeader);
            if (dataGridView1.Columns.Count >= 1) dataGridView1.Columns["姓名"].Frozen = true;
        }
        #endregion

        #region[函数] [自动选择加载选定选项卡对应函数]
        public void Auto_Select_Tab(string Select_Tab_Text)
        {
            if (tabControl1.SelectedTab.Text == "基本资料")
            {
                Show_Image();
                D_Person_Info_Load();
                Refresh_D_Person_Info();
            }
            if (tabControl1.SelectedTab.Text == "经历及社会关系")
            {
                Person_History();
                Person_GX();
            }
            else if (tabControl1.SelectedTab.Text == "培训记录")
            {
                Person_Education();
            }
            else if (tabControl1.SelectedTab.Text == "奖惩记录") 
            {
                Person_JC();
            }
            else if (tabControl1.SelectedTab.Text == "考评记录") 
            {
                Person_KP();
            }
            else if (tabControl1.SelectedTab.Text == "调薪记录") 
            {
                Person_TX();
            }
            else if (tabControl1.SelectedTab.Text == "出差记录") 
            {
                Person_CC();
            }
            else if (tabControl1.SelectedTab.Text == "合同记录") 
            {
                Person_HT();
            }

        }
        #endregion
        #endregion

        #region [事件] [展开按钮]
        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "展开>>>")
            {
                splitContainer2.Panel2.Hide();
                splitContainer2.SplitterDistance = this.Width;
                button2.Text = "<<<折叠";
            }
            else 
            {
                splitContainer2.Panel2.Show();
                splitContainer2.SplitterDistance = 185;
                button2.Text = "展开>>>";
            }
        }
        #endregion

        #region[事件] [禁止修改单元格]
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentCell.Value = Cell_Value;
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            Cell_Value = dataGridView1.CurrentCell.Value;
        }
        #endregion

        #region[事件] [TreeView选取]
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeView_Select();
        }
        #endregion

        #region[事件] [CheckBox选取]
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            TreeView_Select();
        }
        #endregion

        #region[事件] [RBtn属性更改]
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            TreeView_Select();
        }
        #endregion

        #region[事件] [是否显示复职]
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
                toolStripButton8.Text = "员工复职";
            else
                toolStripButton8.Text = "员工离职";
        }
        #endregion

        #region[事件] [DtGV统计人数]
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            groupBox2.Text = "人事数据 [共" + dataGridView1.Rows.Count.ToString() + "人]";
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

        #region[事件] [CurtCell更改]
        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                姓名.Text = dataGridView1.CurrentRow.Cells[dataGridView1.Columns["姓名"].Index].Value.ToString();
                编号.Text = dataGridView1.CurrentRow.Cells[dataGridView1.Columns["编号"].Index].Value.ToString();
                身份证号.Text = dataGridView1.CurrentRow.Cells[dataGridView1.Columns["身份证号"].Index].Value.ToString();
                部门.Text = dataGridView1.CurrentRow.Cells[dataGridView1.Columns["部门"].Index].Value.ToString();
                职位.Text = dataGridView1.CurrentRow.Cells[dataGridView1.Columns["职位"].Index].Value.ToString();
                年龄.Text = dataGridView1.CurrentRow.Cells[dataGridView1.Columns["年龄"].Index].Value.ToString();
                工作时间.Text = dataGridView1.CurrentRow.Cells[dataGridView1.Columns["工作时间"].Index].Value.ToString();
                离职类别.Text = dataGridView1.CurrentRow.Cells[dataGridView1.Columns["离职类别"].Index].Value.ToString();
                离职原因.Text = dataGridView1.CurrentRow.Cells[dataGridView1.Columns["离职原因"].Index].Value.ToString();
                PF.Person_Index_Info_Load(dataGridView1, 离职日期);
                PF.Person_Index_Info_Load(dataGridView1, 出生日期);
                PF.Person_Index_Info_Load(dataGridView1, 到职日期);
                PF.Person_Index_Info_Load(dataGridView1, 转正日期);
                if (dataGridView1.CurrentRow.Cells[dataGridView1.Columns["性别"].Index].Value.ToString() == "男")
                    男.Checked = true;
                else if (dataGridView1.CurrentRow.Cells[dataGridView1.Columns["性别"].Index].Value.ToString() == "女")
                    女.Checked = true;
                else { }

                //dataGridView1.CurrentRow.Selected = true;
            }
            catch { }
            Auto_Select_Tab(tabControl1.SelectedTab.Text);

        }
        #endregion

        #region[事件] [更改照片按钮]
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells[1].Value.ToString() != "")
            {
                openFileDialog1.ShowDialog();
            }
            else
            {
                MessageBox.Show("员工编号尚未填写!");
            }
        }
        #endregion

        #region[函数] [显图片SQL参数]
        public void Image_SQL() 
        {
            Adapter = new SqlDataAdapter("select * from Person_Info", Link_Conn);
            SqlCommandBuilder Builder = new SqlCommandBuilder(Adapter);
            Adapter.UpdateCommand = Builder.GetUpdateCommand();
            DS_3 = new DataSet();
            Adapter.Fill(DS_3, "Person_Info");
        }
        #endregion

        #region[函数] [显示图片]
        private void Show_Image()
        {
            try
            {
                byte[] bytes = (byte[])DS_3.Tables[0].Select("编号=" + dataGridView1.CurrentRow.Cells[1].Value.ToString())[0][DS_3.Tables[0].Columns.IndexOf("照片")];
                MemoryStream memStream = new MemoryStream(bytes);
                try
                {
                    Bitmap myImage = new Bitmap(memStream);
                    this.pictureBox1.BackgroundImage = myImage;
                }
                catch { }
            }
            catch
            {
                try
                {
                    this.pictureBox1.BackgroundImage = new Bitmap(Path + ".//Image//001.jpg");
                }
                catch
                {
                    if (Image_ERRO == false)
                    {
                        Image_ERRO = true;
                        MessageBox.Show(null, "系统图象文件被删除,请拷贝任意图象到系统目录(如果不存在此目录,则请您重新创建): " + Path + @"\Image\ 下,并命名图象文件为001.jpg,或者您选择重装本软件!本系统下次启动前将无法正常显示系统默认照片!", "系统文件错误", MessageBoxButtons.OK);
                    }
                }
            }
        }
        #endregion

        #region[函数] [保存图片]
        public void Save_Image() 
        {
            Adapter.Update(DS_3, "Person_Info");
        }
        #endregion

        #region[事件] [Open文件对话框确认]
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                Bitmap BMP = new Bitmap(openFileDialog1.FileName);
                pictureBox1.BackgroundImage = BMP;
                if (openFileDialog1.OpenFile() != null)
                {
                    Stream myStream = openFileDialog1.OpenFile();
                    int length = (int)myStream.Length;
                    byte[] bytes = new byte[length];
                    myStream.Read(bytes, 0, length);
                    myStream.Close();
                    DS_3.Tables[0].Select("编号=" + dataGridView1.CurrentRow.Cells[1].Value.ToString())[0][DS_3.Tables[0].Columns.IndexOf("照片")] = bytes;
                    Show_Image();
                    Save_Image();
                }
            }
            catch 
            {
                MessageBox.Show(openFileDialog1.FileName + " 文件有误，请检查此文件是否为合法的图象文件!");
            }
        }
        #endregion

        #region[事件] [图片右键菜单集合]
        private void 居中ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImageLayout = ImageLayout.Center;
        }

        private void 平铺ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImageLayout = ImageLayout.Tile;
        }

        private void 拉伸ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void 放大ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
        }

        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }
        #endregion

        #region[事件] [Save文件对话框确认]
        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            pictureBox1.BackgroundImage.Save(saveFileDialog1.FileName);
        }
        #endregion

        #region[事件] [恢复系统默认图片]
        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells[1].Value.ToString() != "")
            {
                DialogResult result = MessageBox.Show("您确定更换照片为系统默认照片?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    DS_3.Tables[0].Select("编号=" + dataGridView1.CurrentRow.Cells[1].Value.ToString())[0][DS_3.Tables[0].Columns.IndexOf("照片")] = null;
                    Save_Image();
                    Show_Image();
                }
                else
                    return;
            }
            else
            {
                MessageBox.Show("员工编号尚未填写!");
            }
        }
        #endregion

        #region[函数] [动态加载人事资料]
        public void D_Person_Info_Load()
        {
            try
            {
                if (Add_Contrls == false)
                {
                    int j = 0;
                    for (int i = dataGridView1.Columns["卡号"].Index; i < DS_3.Tables[0].Columns.Count; i++)
                    {
                        Label l = new Label();
                        l.Location = new Point(((j % 2) * 220 + 20), j / 2 * 24);
                        l.Text = DS_3.Tables[0].Columns[i].ColumnName;
                        l.Size = new Size(59, 12);
                        panel2.Controls.Add(l);
                        Add_Contrls = true;
                        j++;
                        if (int.Parse(SQL_Linker.SQL_Select("select   count(*)   from   sysobjects   where   xtype   =   'U'   and   name   =   '_" + l.Text + "'", Link_Conn).Tables[0].Rows[0][0].ToString()) != 0)
                        {
                            ComboBox CMB = new ComboBox();
                            CMB.Location = new Point((((j - 1) % 2) * 225 + 85), (j - 1) / 2 * 24);
                            CMB.Text = dataGridView1.CurrentRow.Cells[i].Value.ToString();
                            CMB.MaxDropDownItems = 100;
                            CMB.SelectionChangeCommitted += new EventHandler(姓名_TextChanged);
                            CMB.TextChanged += new EventHandler(姓名_TextChanged);
                            CMB.Size = new Size(138, 21);
                            DataSet DS_4 = SQL_Linker.SQL_Select("select * from [_" + l.Text + "]", Link_Conn);
                            DataTable DTT = DS_4.Tables[0];
                            if (CMB_Load == false)
                            {
                                foreach (DataRow DR in DTT.Rows)
                                {
                                    CMB.Items.Add(DR.ItemArray[0]);
                                }
                            }
                            CMB.Enabled = false;
                            CMB.Name = l.Text;
                            panel2.Controls.Add(CMB);
                        }
                        else
                        {
                            TextBox TB = new TextBox();
                            TB.Location = new Point((((j - 1) % 2) * 225 + 85), (j - 1) / 2 * 24);
                            TB.Text = dataGridView1.CurrentRow.Cells[i].Value.ToString();
                            TB.Name = l.Text;
                            TB.TextChanged += new EventHandler(姓名_TextChanged);
                            TB.Size = new Size(138, 21);
                            TB.Enabled = false;
                            panel2.Controls.Add(TB);
                        }
                    }
                    CMB_Load = true;
                }
            }
            catch { }
        }
        #endregion

        #region[函数] [更新人事动态资料]
        public void Refresh_D_Person_Info()
        {
            if (Add_Contrls == true)
            {
                foreach (Control P_Control in panel2.Controls) 
                {
                    if (P_Control is Label) { }
                    else
                    {
                        try
                        {
                            P_Control.Text = dataGridView1.CurrentRow.Cells[dataGridView1.Columns[P_Control.Name].Index].Value.ToString();
                        }
                        catch { }
                    }
                }
            }
        }
        #endregion

        #region[事件] [人事资料查询按钮]
        private void button1_Click(object sender, EventArgs e)
        {
            查询窗体 Form = new 查询窗体("Person_Info");
            Form.ShowDialog();
        }
        #endregion
        
        #region[函数] [加载工作经历数据]
        public void Person_History()
        {
            try
            {
                SDA = SQL_Linker.SQL_Bind("select * from Person_Gzjl where 编号=" + dataGridView1.CurrentRow.Cells[1].Value.ToString(), Link_Conn, SDT, dataGridView2);
                dataGridView2.Columns["编号"].Visible = false;
                dataGridView2.Columns["标识"].Visible = false;
            }
            catch
            {
                SDT.Rows.Clear();
                dataGridView2.DataSource = SDT;
            }
        }
        #endregion

        #region[函数] [加载社会关系数据]
        public void Person_GX() 
        {
            try
            {
                SDA_1 = SQL_Linker.SQL_Bind("select * from Person_Shgx where 编号=" + dataGridView1.CurrentRow.Cells[1].Value.ToString(), Link_Conn, SDT_1, dataGridView3);
                dataGridView3.Columns["编号"].Visible = false;
                dataGridView3.Columns["标识"].Visible = false;
            }
            catch 
            {
                SDT_1.Rows.Clear();
                dataGridView2.DataSource = SDT_1;
            }
        }
        #endregion

        #region[事件] [工作经历编辑按钮]
        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            dataGridView2.ReadOnly = false;
            //if (MDI主窗口.User_P_Delete)
                toolStripButton11.Enabled = true;
            toolStripButton14.Enabled = true;
            toolStripButton15.Enabled = true;
            //if (MDI主窗口.User_P_Update)
                toolStripButton18.Enabled = true;
        }
        #endregion

        #region[事件] [工作经历删除按钮]
        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView2.Rows.Remove(dataGridView2.CurrentRow);
            }
            catch { }
        }
        #endregion

        #region[事件] [工作经历添加按钮]
        private void toolStripButton18_Click(object sender, EventArgs e)
        {
            SDT.Rows.Add(null, dataGridView1.CurrentRow.Cells[1].Value);
            dataGridView2.DataSource = SDT;
        }
        #endregion

        #region[事件] [鼠标经过变换焦点]
        private void toolStripButton14_MouseEnter(object sender, EventArgs e)
        {
            button2.Select();
        }
        #endregion

        #region[事件] [工作经历保存按钮]
        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            try
            {
                SQL_Linker.SQL_Save(SDA, SDT, Link_Conn);
                Person_History();
                dataGridView2.ReadOnly = true;
                toolStripButton11.Enabled = false;
                toolStripButton14.Enabled = false;
                toolStripButton15.Enabled = false;
                toolStripButton18.Enabled = false;
            }
            catch (Exception err)
            {
                MessageBox.Show(null, err.ToString(), "保存失败", MessageBoxButtons.OK);
            }
        }
        #endregion

        #region[事件] [工作经历取消按钮]
        private void toolStripButton15_Click(object sender, EventArgs e)
        {
            Person_History();
            dataGridView2.ReadOnly = true;
            toolStripButton11.Enabled = false;
            toolStripButton14.Enabled = false;
            toolStripButton15.Enabled = false;
            toolStripButton18.Enabled = false;
        }
        #endregion

        #region[事件] [社会关系编辑按钮]
        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            dataGridView3.ReadOnly = false;
            //if (MDI主窗口.User_P_Update)
                toolStripButton13.Enabled = true;
            //if (MDI主窗口.User_P_Delete)
                toolStripButton16.Enabled = true;
            toolStripButton17.Enabled = true;
            toolStripButton19.Enabled = true;
        }
        #endregion

        #region[事件] [社会关系添加按钮]
        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            SDT_1.Rows.Add(null, dataGridView1.CurrentRow.Cells[1].Value);
            dataGridView3.DataSource = SDT_1;
        }
        #endregion

        #region[事件] [社会关系删除按钮]
        private void toolStripButton16_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView3.Rows.Remove(dataGridView3.CurrentRow);
            }
            catch { }
        }
        #endregion

        #region[事件] [社会关系保存按钮]
        private void toolStripButton17_Click(object sender, EventArgs e)
        {
            try
            {
                SQL_Linker.SQL_Save(SDA_1, SDT_1, Link_Conn);
                Person_GX();
                dataGridView3.ReadOnly = true;
                toolStripButton13.Enabled = false;
                toolStripButton16.Enabled = false;
                toolStripButton17.Enabled = false;
                toolStripButton19.Enabled = false;
            }
            catch (Exception err)
            {
                MessageBox.Show(null, err.ToString(), "保存失败", MessageBoxButtons.OK);
            }
        }
        #endregion

        #region[事件] [社会关系取消按钮]
        private void toolStripButton19_Click(object sender, EventArgs e)
        {
            Person_GX();
            dataGridView3.ReadOnly = true;
            toolStripButton13.Enabled = false;
            toolStripButton16.Enabled = false;
            toolStripButton17.Enabled = false;
            toolStripButton19.Enabled = false;
        }
        #endregion

        #region[事件] [选择TabCrl选项卡]
        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            Auto_Select_Tab(tabControl1.SelectedTab.Text);
        }
        #endregion

        #region[函数] [加载培训记录数据]
        public void Person_Education() 
        {
            try
            {
                SDA_2 = SQL_Linker.SQL_Bind("select * from Person_Pxjl where 编号=" + dataGridView1.CurrentRow.Cells[1].Value.ToString(), Link_Conn, SDT_2, dataGridView4);
                dataGridView4.Columns["编号"].Visible = false;
                dataGridView4.Columns["标识"].Visible = false;
            }
            catch 
            {
                SDT_2.Rows.Clear();
                dataGridView2.DataSource = SDT_2;
            }
        }
        #endregion

        #region[事件] [DatError事件处理]
        private void dataGridView2_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("输入的数据格式有误!请检查数据格式", "数据格式转换错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        #endregion

        #region[事件] [培训记录编辑按钮]
        private void toolStripButton20_Click(object sender, EventArgs e)
        {
            dataGridView4.ReadOnly = false;
            //if (MDI主窗口.User_P_Update)
                toolStripButton21.Enabled = true;
            //if (MDI主窗口.User_P_Delete)
                toolStripButton22.Enabled = true;
            toolStripButton23.Enabled = true;
            toolStripButton24.Enabled = true;
        }
        #endregion

        #region[事件] [培训记录添加按钮]
        private void toolStripButton21_Click(object sender, EventArgs e)
        {
            SDT_2.Rows.Add(null, dataGridView1.CurrentRow.Cells[1].Value);
            dataGridView4.DataSource = SDT_2;
        }
        #endregion

        #region[事件] [培训记录删除按钮]
        private void toolStripButton22_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView4.Rows.Remove(dataGridView4.CurrentRow);
            }
            catch { }
        }
        #endregion

        #region[事件] [培训记录保存按钮]
        private void toolStripButton23_Click(object sender, EventArgs e)
        {
            try
            {
                SQL_Linker.SQL_Save(SDA_2, SDT_2, Link_Conn);
                Person_Education();
                dataGridView4.ReadOnly = true;
                toolStripButton21.Enabled = false;
                toolStripButton22.Enabled = false;
                toolStripButton23.Enabled = false;
                toolStripButton24.Enabled = false;
            }
            catch (Exception err)
            {
                MessageBox.Show(null, err.ToString(), "保存失败", MessageBoxButtons.OK);
            }
        }
        #endregion

        #region[事件] [培训记录取消按钮]
        private void toolStripButton24_Click(object sender, EventArgs e)
        {
            Person_Education();
            dataGridView4.ReadOnly = true;
            toolStripButton21.Enabled = false;
            toolStripButton22.Enabled = false;
            toolStripButton23.Enabled = false;
            toolStripButton24.Enabled = false;
        }
        #endregion

        #region[函数] [加载奖惩记录数据]
        public void Person_JC() 
        {
            try
            {
                SDA_3 = SQL_Linker.SQL_Bind("select * from Person_Jcjl where 编号=" + dataGridView1.CurrentRow.Cells[1].Value.ToString(), Link_Conn, SDT_3, dataGridView5);
                dataGridView5.Columns["编号"].Visible = false;
                dataGridView5.Columns["标识"].Visible = false;
            }
            catch 
            {
                SDT_3.Rows.Clear();
                dataGridView2.DataSource = SDT_3;
            }
        }
        #endregion

        #region[事件] [奖惩记录编辑按钮]
        private void toolStripButton25_Click(object sender, EventArgs e)
        {
            dataGridView5.ReadOnly = false;
            //if (MDI主窗口.User_P_Update)
                toolStripButton26.Enabled = true;
            //if (MDI主窗口.User_P_Delete)
                toolStripButton27.Enabled = true;
            toolStripButton28.Enabled = true;
            toolStripButton29.Enabled = true;
        }
        #endregion

        #region[事件] [奖惩记录添加按钮]
        private void toolStripButton26_Click(object sender, EventArgs e)
        {
            SDT_3.Rows.Add(null, dataGridView1.CurrentRow.Cells[1].Value);
            dataGridView5.DataSource = SDT_3;
        }
        #endregion

        #region[事件] [奖惩记录删除按钮]
        private void toolStripButton27_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView5.Rows.Remove(dataGridView5.CurrentRow);
            }
            catch { }
        }
        #endregion

        #region[事件] [奖惩记录保存按钮]
        private void toolStripButton28_Click(object sender, EventArgs e)
        {
            try
            {
                SQL_Linker.SQL_Save(SDA_3, SDT_3, Link_Conn);
                Person_JC();
                dataGridView5.ReadOnly = true;
                toolStripButton26.Enabled = false;
                toolStripButton27.Enabled = false;
                toolStripButton28.Enabled = false;
                toolStripButton29.Enabled = false;
            }
            catch (Exception err)
            {
                MessageBox.Show(null, err.ToString(), "保存失败", MessageBoxButtons.OK);
            }
        }
        #endregion

        #region[事件] [奖惩记录取消按钮]
        private void toolStripButton29_Click(object sender, EventArgs e)
        {
            Person_JC();
            dataGridView5.ReadOnly = true;
            toolStripButton26.Enabled = false;
            toolStripButton27.Enabled = false;
            toolStripButton28.Enabled = false;
            toolStripButton29.Enabled = false;
        }
        #endregion

        #region[函数] [加载考评记录数据]
        public void Person_KP() 
        {
            try
            {
                SDA_4 = SQL_Linker.SQL_Bind("select * from Person_Kpjl where 编号=" + dataGridView1.CurrentRow.Cells[1].Value.ToString(), Link_Conn, SDT_4, dataGridView6);
                dataGridView6.Columns["编号"].Visible = false;
                dataGridView6.Columns["标识"].Visible = false;
            }
            catch 
            {
                SDT_4.Rows.Clear();
                dataGridView2.DataSource = SDT_4;
            }
        }
        #endregion

        #region[事件] [考评记录编辑按钮]
        private void toolStripButton30_Click(object sender, EventArgs e)
        {
            dataGridView6.ReadOnly = false;
            //if (MDI主窗口.User_P_Update)
                toolStripButton31.Enabled = true;
            //if (MDI主窗口.User_P_Delete)
                toolStripButton32.Enabled = true;
            toolStripButton33.Enabled = true;
            toolStripButton34.Enabled = true;
        }
        #endregion

        #region[事件] [考评记录添加按钮]
        private void toolStripButton31_Click(object sender, EventArgs e)
        {
            SDT_4.Rows.Add(null, dataGridView1.CurrentRow.Cells[1].Value);
            dataGridView6.DataSource = SDT_4;
        }
        #endregion

        #region[事件] [考评记录删除按钮]
        private void toolStripButton32_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView6.Rows.Remove(dataGridView6.CurrentRow);
            }
            catch { }
        }
        #endregion

        #region[事件] [考评记录保存按钮]
        private void toolStripButton33_Click(object sender, EventArgs e)
        {
            try
            {
                SQL_Linker.SQL_Save(SDA_4, SDT_4, Link_Conn);
                Person_KP();
                dataGridView6.ReadOnly = true;
                toolStripButton31.Enabled = false;
                toolStripButton32.Enabled = false;
                toolStripButton33.Enabled = false;
                toolStripButton34.Enabled = false;
            }
            catch (Exception err)
            {
                MessageBox.Show(null, err.ToString(), "保存失败", MessageBoxButtons.OK);
            }
        }
        #endregion

        #region[事件] [考评记录取消按钮]
        private void toolStripButton34_Click(object sender, EventArgs e)
        {
            Person_KP();
            dataGridView6.ReadOnly = true;
            toolStripButton31.Enabled = false;
            toolStripButton32.Enabled = false;
            toolStripButton33.Enabled = false;
            toolStripButton34.Enabled = false;
        }
        #endregion

        #region[函数] [加载调薪记录数据]
        public void Person_TX() 
        {
            try
            {
                SDA_5 = SQL_Linker.SQL_Bind("select * from Person_Txjl where 编号=" + dataGridView1.CurrentRow.Cells[1].Value.ToString(), Link_Conn, SDT_5, dataGridView7);
                dataGridView7.Columns["编号"].Visible = false;
                dataGridView7.Columns["标识"].Visible = false;
            }
            catch 
            {
                SDT_5.Rows.Clear();
                dataGridView2.DataSource = SDT_5;
            }
        }
        #endregion

        #region[事件] [调薪记录编辑按钮]
        private void toolStripButton35_Click(object sender, EventArgs e)
        {
            dataGridView7.ReadOnly = false;
            //if (MDI主窗口.User_P_Update)
                toolStripButton36.Enabled = true;
            //if (MDI主窗口.User_P_Delete)
                toolStripButton37.Enabled = true;
            toolStripButton38.Enabled = true;
            toolStripButton39.Enabled = true;
        }
        #endregion

        #region[事件] [调薪记录添加按钮]
        private void toolStripButton36_Click(object sender, EventArgs e)
        {
            SDT_5.Rows.Add(null, dataGridView1.CurrentRow.Cells[1].Value);
            dataGridView7.DataSource = SDT_5;
        }
        #endregion

        #region[事件] [调薪记录删除按钮]
        private void toolStripButton37_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView7.Rows.Remove(dataGridView7.CurrentRow);
            }
            catch { }
        }
        #endregion

        #region[事件] [调薪记录保存按钮]
        private void toolStripButton38_Click(object sender, EventArgs e)
        {
            try
            {
                SQL_Linker.SQL_Save(SDA_5, SDT_5, Link_Conn);
                Person_TX();
                dataGridView7.ReadOnly = true;
                toolStripButton36.Enabled = false;
                toolStripButton37.Enabled = false;
                toolStripButton38.Enabled = false;
                toolStripButton39.Enabled = false;
            }
            catch (Exception err)
            {
                MessageBox.Show(null, err.ToString(), "保存失败", MessageBoxButtons.OK);
            }
        }
        #endregion

        #region[事件] [调薪记录取消按钮]
        private void toolStripButton39_Click(object sender, EventArgs e)
        {
            Person_TX();
            dataGridView7.ReadOnly = true;
            toolStripButton36.Enabled = false;
            toolStripButton37.Enabled = false;
            toolStripButton38.Enabled = false;
            toolStripButton39.Enabled = false;
        }
        #endregion

        #region[函数] [加载出差记录数据]
        public void Person_CC() 
        {
            try
            {
                SDA_6 = SQL_Linker.SQL_Bind("select * from Person_Ccjl where 编号=" + dataGridView1.CurrentRow.Cells[1].Value.ToString(), Link_Conn, SDT_6, dataGridView8);
                dataGridView8.Columns["编号"].Visible = false;
                dataGridView8.Columns["标识"].Visible = false;
            }
            catch 
            {
                SDT_6.Rows.Clear();
                dataGridView2.DataSource = SDT_6;
            }
        }
        #endregion

        #region[事件] [出差记录编辑按钮]
        private void toolStripButton40_Click(object sender, EventArgs e)
        {
            dataGridView8.ReadOnly = false;
            //if (MDI主窗口.User_P_Update)
                toolStripButton41.Enabled = true;
            //if (MDI主窗口.User_P_Delete)
                toolStripButton42.Enabled = true;
            toolStripButton43.Enabled = true;
            toolStripButton44.Enabled = true;
        }
        #endregion

        #region[事件] [出差记录添加按钮]
        private void toolStripButton41_Click(object sender, EventArgs e)
        {
            SDT_6.Rows.Add(null, dataGridView1.CurrentRow.Cells[1].Value);
            dataGridView8.DataSource = SDT_6;
        }
        #endregion

        #region[事件] [出差记录删除按钮]
        private void toolStripButton42_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView8.Rows.Remove(dataGridView8.CurrentRow);
            }
            catch { }
        }
        #endregion

        #region[事件] [出差记录保存按钮]
        private void toolStripButton43_Click(object sender, EventArgs e)
        {
            try
            {
                SQL_Linker.SQL_Save(SDA_6, SDT_6, Link_Conn);
                Person_CC();
                dataGridView8.ReadOnly = true;
                toolStripButton41.Enabled = false;
                toolStripButton42.Enabled = false;
                toolStripButton43.Enabled = false;
                toolStripButton44.Enabled = false;
            }
            catch (Exception err)
            {
                MessageBox.Show(null, err.ToString(), "保存失败", MessageBoxButtons.OK);
            }
        }
        #endregion

        #region[事件] [出差记录取消按钮]
        private void toolStripButton44_Click(object sender, EventArgs e)
        {
            Person_CC();
            dataGridView8.ReadOnly = true;
            toolStripButton41.Enabled = false;
            toolStripButton42.Enabled = false;
            toolStripButton43.Enabled = false;
            toolStripButton44.Enabled = false;
        }
        #endregion

        #region[函数] [加载合同记录数据]
        public void Person_HT() 
        {
            try
            {
                SDA_7 = SQL_Linker.SQL_Bind("select * from Person_Htjl where 编号=" + dataGridView1.CurrentRow.Cells[1].Value.ToString(), Link_Conn, SDT_7, dataGridView9);
                dataGridView9.Columns["编号"].Visible = false;
                dataGridView9.Columns["标识"].Visible = false;
            }
            catch 
            {
                SDT_7.Rows.Clear();
                dataGridView2.DataSource = SDT_7 ;
            }
        }
        #endregion

        #region[事件] [合同记录编辑按钮]
        private void toolStripButton45_Click(object sender, EventArgs e)
        {
            dataGridView9.ReadOnly = false;
            //if (MDI主窗口.User_P_Update)
                toolStripButton46.Enabled = true;
            //if (MDI主窗口.User_P_Delete)
                toolStripButton47.Enabled = true;
            toolStripButton48.Enabled = true;
            toolStripButton49.Enabled = true;
        }
        #endregion

        #region[事件] [合同记录添加按钮]
        private void toolStripButton46_Click(object sender, EventArgs e)
        {
            SDT_7.Rows.Add(null, dataGridView1.CurrentRow.Cells[1].Value);
            dataGridView9.DataSource = SDT_7;
        }
        #endregion

        #region[事件] [合同记录删除按钮]
        private void toolStripButton47_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView9.Rows.Remove(dataGridView9.CurrentRow);
            }
            catch { }
        }
        #endregion

        #region[事件] [合同记录保存按钮]
        private void toolStripButton48_Click(object sender, EventArgs e)
        {
            try
            {
                SQL_Linker.SQL_Save(SDA_7, SDT_7, Link_Conn);
                Person_HT();
                dataGridView9.ReadOnly = true;
                toolStripButton46.Enabled = false;
                toolStripButton47.Enabled = false;
                toolStripButton48.Enabled = false;
                toolStripButton49.Enabled = false;
            }
            catch (Exception err)
            {
                MessageBox.Show(null,err.ToString(),"保存失败",MessageBoxButtons.OK);
            }
        }
        #endregion

        #region[事件] [合同记录取消按钮]
        private void toolStripButton49_Click(object sender, EventArgs e)
        {
            Person_HT();
            dataGridView9.ReadOnly = true;
            toolStripButton46.Enabled = false;
            toolStripButton47.Enabled = false;
            toolStripButton48.Enabled = false;
            toolStripButton49.Enabled = false;
        }
        #endregion

        #region[事件] [人事资料编辑按钮]
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            //if (MDI主窗口.User_P_Update)
                toolStripButton1.Enabled = true;
            //if (MDI主窗口.User_P_Delete)
                toolStripButton2.Enabled = true;
            toolStripButton3.Enabled = false;
            toolStripButton4.Enabled = true;
            toolStripButton5.Enabled = true;
            //if (MDI主窗口.User_P_Update)
            //{
                foreach (Control T_Control in groupBox3.Controls)
                {
                    T_Control.Enabled = true;
                }
                foreach (Control T_Control in panel2.Controls)
                {
                    T_Control.Enabled = true;
                }
                foreach (Control T_Control in groupBox14.Controls)
                {
                    T_Control.Enabled = true;
                }
                dataGridView1.Focus();
            //}
        }
        #endregion

        #region[事件] [人事资料添加按钮]
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            toolStripButton4.Enabled = true;
            toolStripButton5.Enabled = true;
            foreach (Control T_Control in groupBox3.Controls)
            {
                T_Control.Enabled = true;
            }
            foreach (Control T_Control in panel2.Controls)
            {
                T_Control.Enabled = true;
            }
            foreach (Control T_Control in groupBox14.Controls)
            {
                T_Control.Enabled = true;
            }
            dataGridView1.Focus();

            SDT_0.Rows.Add();
            dataGridView1.DataSource = SDT_0;
            dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[0].Selected = true;
            部门.Text = null;
            男.Checked = false;
            女.Checked = false;
            //if (!MDI主窗口.User_P_Update)
            //{
                //dataGridView1.Enabled = false;
            //}
        }
        #endregion

        #region[函数] [人事资料Text绑定DGView]
        public void Text_TO_DGV(Control Control_Name)
        {
            try
            {                
                dataGridView1.CurrentRow.Cells[dataGridView1.Columns[Control_Name.Name].Index].Value = Control_Name.Text;
            }
            catch { }
        }
        #endregion

        #region[事件] [姓名TextChanged事件]
        private void 姓名_TextChanged(object sender, EventArgs e)
        {
            Text_TO_DGV((Control)sender);
        }
        #endregion

        #region[事件] [性别CheckedChange事件]
        private void 男_CheckedChanged(object sender, EventArgs e)
        {
            if (男.Checked == true)
            {
                dataGridView1.CurrentRow.Cells[dataGridView1.Columns["性别"].Index].Value = "男";
            }
            else if (女.Checked == true)
            {
                dataGridView1.CurrentRow.Cells[dataGridView1.Columns["性别"].Index].Value = "女";
            }
            else { }
        }
        #endregion

        #region[事件] [出生日期Validated事件]
        private void 出生日期_Validated(object sender, EventArgs e)
        {
            DateTime RS;
            if (DateTime.TryParse(出生日期.Text, out RS))
            {
                dataGridView1.CurrentRow.Cells[dataGridView1.Columns["出生日期"].Index].Value = RS;
                TimeSpan TS = DateTime.Now - RS;
                int D_Num = TS.Days / 365;
                年龄.Text = D_Num.ToString();
            }
        }
        #endregion

        #region[事件] [到职日期Validated事件]
        private void 到职日期_Validated(object sender, EventArgs e)
        {
            DateTime RS;
            if (DateTime.TryParse(到职日期.Text, out RS))
            {
                dataGridView1.CurrentRow.Cells[dataGridView1.Columns["到职日期"].Index].Value = RS;
                TimeSpan TS = DateTime.Now - RS;
                int D_Num = TS.Days / 30;
                工作时间.Text = D_Num.ToString();
            }
        }
        #endregion

        #region[事件] [转正日期Validated事件]
        private void 转正日期_Validated(object sender, EventArgs e)
        {
            DateTime RS;
            if (DateTime.TryParse(转正日期.Text, out RS))
            {
                dataGridView1.CurrentRow.Cells[dataGridView1.Columns["转正日期"].Index].Value = RS;
            }
        }
        #endregion

        #region[事件] [离职日期Validated事件]
        private void 离职日期_Validated(object sender, EventArgs e)
        {
            DateTime RS;
            if (DateTime.TryParse(离职日期.Text, out RS))
            {
                dataGridView1.CurrentRow.Cells[dataGridView1.Columns["离职日期"].Index].Value = RS;
            }
        }
        #endregion

        #region[事件] [人事资料删除按钮]
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
            }
            catch { }
        }
        #endregion

        #region[事件] [人事资料保存按钮]
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (姓名.Text != "")
            {
                if (编号.Text != "")
                {
                    if (部门.Text != "")
                    {
                        try
                        {
                            dataGridView1.Enabled = true;
                            dataGridView1.Focus();
                            SQL_Linker.SQL_Save(SDA_0, SDT_0, Link_Conn);
                            TreeView_Select();
                            toolStripButton1.Enabled = false;
                            toolStripButton2.Enabled = false;
                            toolStripButton3.Enabled = true;
                            toolStripButton4.Enabled = false;
                            toolStripButton5.Enabled = false;
                            foreach (Control T_Control in groupBox3.Controls)
                            {
                                if (T_Control is Label) { }
                                else
                                {
                                    T_Control.Enabled = false;
                                }
                            }
                            foreach (Control T_Control in panel2.Controls)
                            {
                                if (T_Control is Label) { }
                                else
                                {
                                    T_Control.Enabled = false;
                                }
                            }
                            foreach (Control T_Control in groupBox14.Controls)
                            {
                                if (T_Control is Label) { }
                                else
                                {
                                    T_Control.Enabled = false;
                                }
                            }
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show(null, err.ToString(), "保存失败", MessageBoxButtons.OK);
                        }
                    }
                    else 
                    {
                        MessageBox.Show("部门不能为空");
                    }
                }
                else
                {
                    MessageBox.Show("编号不能为空");
                }
            }
            else 
            {
                MessageBox.Show("姓名不能为空");
            }
        }
        #endregion

        #region[事件] [人事资料取消按钮]
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            dataGridView1.Enabled = true;
            TreeView_Select();
            toolStripButton1.Enabled = false;
            toolStripButton2.Enabled = false;
            toolStripButton3.Enabled = true;
            toolStripButton4.Enabled = false;
            toolStripButton5.Enabled = false;
            foreach (Control T_Control in groupBox3.Controls)
            {
                if (T_Control is Label) { }
                else
                {
                    T_Control.Enabled = false;
                }
            }
            foreach (Control T_Control in panel2.Controls)
            {
                if (T_Control is Label) { }
                else
                {
                    T_Control.Enabled = false;
                }
            }
            foreach (Control T_Control in groupBox14.Controls)
            {
                if (T_Control is Label) { }
                else
                {
                    T_Control.Enabled = false;
                }
            }
        }
        #endregion

        #region[事件] [人事资料员工离职]
        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                if (姓名.Text != "")
                {
                    if (编号.Text != "")
                    {
                        if (部门.Text != "")
                        {
                            try
                            {
                                if (toolStripButton8.Text == "员工离职")
                                {
                                    DialogResult result = MessageBox.Show(姓名.Text + "离职,您确定执行此操作?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                                    if (result == DialogResult.OK)
                                    {
                                        SQL_Linker.SQL_Update("Update Person_Info set 在职情况= '离职' where 编号= '" + 编号.Text + "'", Link_Conn);
                                        TreeView_Select();
                                    }
                                    else
                                    {
                                        return;
                                    }
                                }
                                else
                                {
                                    DialogResult result = MessageBox.Show(姓名.Text + "复职,您确定执行此操作?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                                    if (result == DialogResult.OK)
                                    {
                                        SQL_Linker.SQL_Update("Update Person_Info set 在职情况= '在职' where 编号= '" + 编号.Text + "'", Link_Conn);
                                        TreeView_Select();
                                    }
                                    else
                                    {
                                        return;
                                    }
                                }
                            }
                            catch (Exception err)
                            {
                                MessageBox.Show(null, err.ToString(), "保存失败", MessageBoxButtons.OK);
                            }
                        }
                        else
                        {
                            MessageBox.Show("部门不能为空");
                        }
                    }
                    else
                    {
                        MessageBox.Show("编号不能为空");
                    }
                }
                else
                {
                    MessageBox.Show("姓名不能为空");
                }
            }
            else
            {
                MessageBox.Show("未选择员工");
            }
        }
        #endregion

        #region[事件] [人事资料退出按钮]
        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion        

        #region[事件] [人事资料窗体关闭]
        private void 人事资料_FormClosing(object sender, FormClosingEventArgs e)
        {
            MDI主窗口.form = null;
        }
        #endregion

        #region[函数] [静态]
        public static void Select_Fun() 
        {
            人事资料 Form = new 人事资料();
            SDA_0 = SQL_Linker.SQL_Bind(MDI主窗口.Select_Together_String, MDI主窗口.Send_Data_2, SDT_0, Form.dataGridView1);
        }
        #endregion
    }
}
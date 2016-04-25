using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Threading;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace 企业人事管理系统
{
    public partial class MDI主窗口 : Form
    {
        #region [公共变量]
        public static string Send_Data;
        public string Send_Data_1;
        public static SqlConnection Send_Data_2;
        Secret Sc = new Secret();
        SQL_Link SQL_Linker = new SQL_Link();
        public static 人事资料 form;
        public static bool 培训管理 = false;
        public static bool 奖惩管理 = false;
        public static bool 调薪管理 = false;
        public static bool 考评管理 = false;
        public static bool 合同管理 = false;
        public static string 自定义字段_Table;
        public static string Select_Together_String;//查询窗体返回的拼接字符串
        public static bool Re_Load_ZDY_Form = false;//是否刷新自定义字段窗体
        #endregion

        #region[MDI窗口] [构造传参]
        public MDI主窗口(string User_Name, bool User_Power, SqlConnection Data_2)
        {
            if (User_Name != null && Data_2 != null)
            {
                Send_Data = User_Name;
                if (User_Power)
                    Send_Data_1 = "系统管理员";
                else
                    Send_Data_1 = "普通用户";
                Send_Data_2 = Data_2;
                InitializeComponent();
            }
        }
        #endregion

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        #region [事件] [FormLoad]
        private void MDI主窗口_Load(object sender, EventArgs e)
        {
            #region [事件] [获取系统名称]
            string[] Read_Data = File.ReadAllLines(".//System_Information//System_Information.ini");
            try
            {
                if (Read_Data[0].ToString() != "" && Read_Data[1] != "")
                {
                    this.Text = "[" + Sc.Fun_UnSecret(Read_Data[0].ToString()) + "] " + Sc.Fun_UnSecret(Read_Data[1].ToString());
                }
                else
                {
                    this.Text = "[嘉源] 人事管理系统";
                }
            }
            catch 
            {
                this.Text = "[嘉源] 人事管理系统";
            }
            User_Name_Lable.Text = Send_Data;
            User_Power_Lable.Text = Send_Data_1;
            #endregion

            系统背景 form1 = new 系统背景();
            form1.MdiParent = this;
            form1.WindowState = FormWindowState.Maximized;
            form1.Show();
        }
        #endregion

        #region [事件] [窗口按钮]
        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)//窗口层叠
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void tileVerticalToolStripMenuItem_Click(object sender, EventArgs e)//窗口垂直平铺
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void tileHorizontalToolStripMenuItem_Click_1(object sender, EventArgs e)//窗口水平平铺
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void 总在最上ToolStripMenuItem_Click(object sender, EventArgs e)//总在最上
        {
            if (this.TopMost == false) this.TopMost = true;
            else this.TopMost = false;

        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)//关闭所有子窗口
        {
            foreach (Form Form_Child in this.MdiChildren) 
            {
                Form_Child.Close();
            }
        }
        #endregion

        #region [事件] [关闭子窗体]
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.ActiveMdiChild.Close();
        }
        #endregion

        #region[事件] [还原子窗体]
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.ActiveMdiChild.WindowState = FormWindowState.Normal;
        }
        #endregion

        #region[事件] [防窗体皮肤出现空缺]
        private void MDI主窗口_Activated(object sender, EventArgs e)
        {
            this.Refresh();
        }
        #endregion

        #region[事件] [人事资料按钮]
        private void 人事资料NToolStripButton_Click_1(object sender, EventArgs e)
        {
            if (form == null)
            {
                form = new 人事资料();
                form.MdiParent = this;
                form.WindowState = FormWindowState.Maximized;
                form.Show();
            }
        }
        #endregion

        #region[事件] [公司资料按钮]
        private void 公司资料ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            公司资料设置 form = new 公司资料设置(Send_Data_2);
            form.ShowDialog();
        }
        #endregion

        #region[事件] [部门设置按钮]
        private void 部门设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            部门设置 form = new 部门设置();
            form.ShowDialog();
        }
        #endregion

        #region[事件] [培训管理]
        private void 培训管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (培训管理 == false) 
            {
                培训管理 = true;
                项目管理模板 MB_Form = new 项目管理模板();
                MB_Form.Text = "培训管理";
                MB_Form.Name = "培训管理";
                MB_Form.MdiParent = this;
                MB_Form.WindowState = FormWindowState.Maximized;
                MB_Form.Show();
            }
        }
        #endregion

        #region[事件] [奖惩管理]
        private void 奖惩管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (奖惩管理 == false)
            {
                奖惩管理 = true;
                项目管理模板 MB_Form = new 项目管理模板();
                MB_Form.Text = "奖惩管理";
                MB_Form.Name = "奖惩管理";
                MB_Form.MdiParent = this;
                MB_Form.WindowState = FormWindowState.Maximized;
                MB_Form.Show();
            }
        }
        #endregion

        #region[事件] [调薪管理]
        private void 调薪管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (调薪管理 == false)
            {
                调薪管理 = true;
                项目管理模板 MB_Form = new 项目管理模板();
                MB_Form.Text = "调薪管理";
                MB_Form.Name = "调薪管理";
                MB_Form.MdiParent = this;
                MB_Form.WindowState = FormWindowState.Maximized;
                MB_Form.Show();
            }
        }
        #endregion

        #region[事件] [考评管理]
        private void 考评管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (考评管理 == false)
            {
                考评管理 = true;
                项目管理模板 MB_Form = new 项目管理模板();
                MB_Form.Text = "考评管理";
                MB_Form.Name = "考评管理";
                MB_Form.MdiParent = this;
                MB_Form.WindowState = FormWindowState.Maximized;
                MB_Form.Show();
            }
        }
        #endregion

        #region[事件] [合同管理]
        private void 合同管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (合同管理 == false)
            {
                合同管理 = true;
                项目管理模板 MB_Form = new 项目管理模板();
                MB_Form.Text = "合同管理";
                MB_Form.Name = "合同管理";
                MB_Form.MdiParent = this;
                MB_Form.WindowState = FormWindowState.Maximized;
                MB_Form.Show();
            }
        }
        #endregion

        #region[事件] [显示工具栏]
        private void toolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (toolStrip.Visible == false)
                toolStrip.Show();
            else
                toolStrip.Hide();
        }
        #endregion

        #region[事件] [显示状态栏]
        private void statusBarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (statusStrip.Visible == false)
                statusStrip.Show();
            else
                statusStrip.Hide();
        }
        #endregion

        #region[事件] [系统锁定]
        private void 系统锁定OToolStripButton_Click(object sender, EventArgs e)
        {
            锁定窗体 S_Form = new 锁定窗体();
            S_Form.ShowDialog();
        }
        #endregion

        #region[事件] [单击自定义字段]
        private void 人事资料ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem CT = (ToolStripMenuItem)sender;
            MDI主窗口.自定义字段_Table = CT.Text;
            自定义字段 Z_Form = new 自定义字段();
            Z_Form.ShowDialog();
        }
        #endregion

        #region[事件] [更高密码]
        private void 更改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            更改密码 G_Form = new 更改密码(Send_Data);
            G_Form.ShowDialog();
        }
        #endregion

        #region[事件] [更换皮肤]
        private void 自定义CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }
        #endregion

        #region[事件] [对话框确定按钮]
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            using (FileStream FS = File.Create(Application.StartupPath + "//skin/skin.ini"))
            {
                FS.Close();
            }
            using (StreamWriter Write_String = File.CreateText(Application.StartupPath + "//skin/skin.ini"))
            {
                Write_String.Write(Sc.Fun_Secret(openFileDialog1.FileName));
                Write_String.Close();
            }
            MessageBox.Show("下次系统启动,将自动更新为您的设置");
        }
        #endregion

        #region[事件] [数据初始化]
        private void 数据初始化ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("此操作完毕后会初始化数据库,完成后将关闭系统,请您保存未完成的工作,您确定现在进行数据初始化?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                try
                {
                    this.Refresh();
                    SQL_Linker.RestoreDB(@"\Restart.bak");
                }
                catch
                {
                    MessageBox.Show("您可能未安装MS-SQL SERVER,COM对象无法正常加载,请尝试在服务器端手动初始化");
                }
            }
        }
        #endregion

        #region[事件] [软件注册]
        private void 索引IToolStripMenuItem_Click(object sender, EventArgs e)
        {
            购买注册码 G_Form = new 购买注册码();
            G_Form.ShowDialog();
        }
        #endregion

        #region[事件] [使用说明]
        private void 内容CToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region[事件] [数据备份到本地]
        private void 备份到本地ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Refresh();
            try
            {
                SQL_Linker.SQL_BackUp("l");
            }
            catch
            {
                MessageBox.Show("您可能未安装MS-SQL SERVER,COM对象无法正常加载,请尝试在服务器端手动备份");
            }
        }
        #endregion

        #region[事件] [数据备份到服务器]
        private void 备份到服务器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Refresh();
            try
            {
                SQL_Linker.SQL_BackUp("s");
            }
            catch
            {
                MessageBox.Show("您可能未安装MS-SQL SERVER,COM对象无法正常加载,请尝试在服务器端手动备份");
            }
        }
        #endregion

        #region[事件] [从本地数据恢复]
        private void 从本地恢复ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("此操作完毕后会关闭系统,请您保存未完成的工作,您确定现在进行数据恢复?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                try
                {
                    this.Refresh();
                    SQL_Linker.RestoreDB("l");
                }
                catch
                {
                    MessageBox.Show("您可能未安装MS-SQL SERVER,COM对象无法正常加载,请尝试在服务器端手动恢复");
                }
            }
        }
        #endregion

        #region[事件] [从服务器数据恢复]
        private void 从服务器恢复ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("此操作完毕后会关闭系统,请您保存未完成的工作,您确定现在进行数据恢复?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                try
                {
                    this.Refresh();
                    SQL_Linker.RestoreDB("s");
                }
                catch
                {
                    MessageBox.Show("您可能未安装MS-SQL SERVER,COM对象无法正常加载,请尝试在服务器端手动恢复");
                }
            }
        }
        #endregion

        private void Exit_toolStripButton_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

    }
}

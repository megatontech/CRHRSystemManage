using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 企业人事管理系统
{
    public partial class 锁定窗体 : Form
    {
        public 锁定窗体()
        {
            InitializeComponent();
        }
        SQL_Link SQL_Linker = new SQL_Link();
        DataSet DS;
        private void 锁定窗体_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void 锁定窗体_Load(object sender, EventArgs e)
        {
            user_name.Text = MDI主窗口.Send_Data;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DS = SQL_Linker.SQL_Select("select * from System_Admin where User_Name ='" + user_name.Text + "'  and Password='" + Password.Text.Replace("'", "") + "'", MDI主窗口.Send_Data_2);
            if (DS != null && DS.Tables[0].Rows.Count != 0)
            {
                this.Dispose();
            }
            else
                label3.Text = "密码不正确";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("你的工作是否已经及时保存?\r\n你确定要退出系统?\r\n[点击确定退出]", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                Application.ExitThread();
            }
        }

        private void Password_TextChanged(object sender, EventArgs e)
        {
            if (label3.Text != "") 
            {
                label3.Text = null;
            }
        }

    }
}
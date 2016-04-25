using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 企业人事管理系统
{
    public partial class 更改密码 : Form
    {
        string User_Name;
        public 更改密码(string User_Info)
        {
            User_Name = User_Info;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SQL_Link SQL_Linker = new SQL_Link();
            DataSet DS = SQL_Linker.SQL_Select("select * from System_Admin where User_Name='" + User_Name + "'", MDI主窗口.Send_Data_2);
            if (Old_Password.Text == DS.Tables[0].Rows[0][1].ToString())
            {
                if (New_Password.Text.Trim().Length >= 3)
                {
                    if (New_Password.Text == Sure_New_Password.Text)
                    {
                        SQL_Linker.SQL_Update("update System_Admin set Password='" + New_Password.Text + "' where User_Name='" + User_Name + "'", MDI主窗口.Send_Data_2);
                        MessageBox.Show("密码修改成功");
                        this.Close();
                    }
                    else
                        MessageBox.Show("两次输入密码请确保相同");
                }
                else
                    MessageBox.Show("密码至少为3位");
            }
            else
                label3.Text = "密码错误";
        }

        private void Old_Password_TextChanged(object sender, EventArgs e)
        {
            label3.Text = null;
        }
    }
}
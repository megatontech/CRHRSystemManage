using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace 企业人事管理系统
{
    public partial class Form_Join : Form
    {
        public Form_Join()
        {
            InitializeComponent();
        }

        #region [公共变量]
        SqlConnection Linker;
        DataSet DS;
        #endregion

        #region [公共函数]

        #region [函数] [文件验证]
        public void If_File(string file_path, string folder_path)
        {
            if (File.Exists(file_path) == false)
            {
                try
                {
                    Directory.CreateDirectory(folder_path);
                }
                catch { }
                File.CreateText(file_path);
            }
        }
        #endregion

        #region [函数] [下拉列表读取]
        public void CombBox_Load(string File_path,ComboBox CombBox_List) 
        {
            try
            {
                if (File.ReadAllText(File_path, Encoding.UTF8) != "") //[判断] [用户信息文件内容不为空]
                {
                    try
                    {
                        string[] Temp_String = File.ReadAllLines(File_path, Encoding.UTF8);
                        for (int i = 0; i < Temp_String.Length; i++)
                        {
                            CombBox_List.Items.Add(Temp_String[i]);
                        }
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.ToString());
                    }
                }
            }
            catch
            {

            }
        }
        #endregion

        #region [函数] [公司设置数据记录]
        public void Record_Information(string System_File_Path, string SQLSERVER_File_path, string Record_Data_001, string Record_Data_002, string Record_Data_003, string Record_Data_004, string Record_SQL_Data)
        {
            using (StreamWriter Write_String = File.AppendText(SQLSERVER_File_path))
            {
                bool Record_SQL_Data_OK = true;
                for (int i = 0; i < sqlserver_name_comboBox.Items.Count; i++)
                {
                    if (Record_SQL_Data == sqlserver_name_comboBox.Items[i].ToString()) Record_SQL_Data_OK = false;
                }
                if (Record_SQL_Data_OK == true)
                {
                    Write_String.WriteLine(Record_SQL_Data);
                    MessageBox.Show(null, "记录成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            File.WriteAllText(System_File_Path, Record_Data_001 + "\r\n" + Record_Data_002 + "\r\n" + Record_SQL_Data + "\r\n" + Record_Data_003 + "\r\n" + Record_Data_004 + "\r\n", Encoding.UTF8);
        }
        #endregion

        #region [函数] [通用数据记录]
        public void Record_Data(string File_Path, string Record_Data, ComboBox Control_Name) 
        {
            using (StreamWriter Write_String = File.AppendText(File_Path))
            {
                bool Record_Data_OK = true;
                for (int i = 0; i < Control_Name.Items.Count; i++)
                {
                    if (Record_Data == Control_Name.Items[i].ToString()) Record_Data_OK = false;
                }
                if (Record_Data_OK == true) Write_String.WriteLine(Record_Data);
            }
        }
        #endregion

        #region [函数] [读取记录]
        public void Read_Data(string File_Path, int Data_Num, Control Control_name)
        {
            string[] Temp_Data = File.ReadAllLines(File_Path);
            Control_name.Text = Temp_Data[Data_Num];
        }
        #endregion

        #endregion

        #region [事件] [FormLoad]
        private void Form_Join_Load(object sender, EventArgs e)
        {
            If_File(".//Record_User_Info//User_Info.ini", ".//Record_User_Info");
            If_File(".//System_Information//System_Information.ini", ".//System_Information");
            If_File(".//System_Information//SQLSERVER_Information.ini", ".//System_Information");
            CombBox_Load(".//Record_User_Info//User_Info.ini", user_name_comboBox);
            CombBox_Load(".//System_Information//SQLSERVER_Information.ini", sqlserver_name_comboBox);
            Read_Data(".//System_Information//System_Information.ini", 0, company_name_textBox);
            Read_Data(".//System_Information//System_Information.ini", 1, system_name_textBox);
            Read_Data(".//System_Information//System_Information.ini", 2, sqlserver_name_comboBox);
            Read_Data(".//System_Information//System_Information.ini", 3, sql_user_textBox);
            Read_Data(".//System_Information//System_Information.ini", 4, sql_password_textBox);
        }
        #endregion

        #region [事件] [公司设置]
        private void set_system_button_Click(object sender, EventArgs e)
        {
            if (set_system_button.Text == "公司设置↓")
            {
                set_system_button.Text = "公司设置↑";
                this.Height = 455;
                this.CenterToScreen();
            }
            else
            {
                set_system_button.Text = "公司设置↓";
                this.Height = 222;
                this.CenterToScreen();
            }
        }
        #endregion

        #region [事件] [登陆]
        private void Join_button_Click(object sender, EventArgs e)
        {
            SQL_Link SQL_Linker = new SQL_Link();
            Linker = SQL_Linker.Link_SQL(sqlserver_name_comboBox.Text, "嘉源人事管理系统", sql_user_textBox.Text, sql_password_textBox.Text);
            DS = SQL_Linker.SQL_Select("Select * From System_Admin Where User_Name = '" + user_name_comboBox.Text + "' And Password = '" + password_textBox.Text + "'");
            if (DS != null && DS.Tables[0].Rows.Count != 0)
            {
                if (DS.Tables[0].Rows[0].ItemArray[0].ToString() == user_name_comboBox.Text && DS.Tables[0].Rows[0].ItemArray[1].ToString() == password_textBox.Text)
                {
                    Record_Data(".//Record_User_Info//User_Info.ini", user_name_comboBox.Text, user_name_comboBox);
                    MessageBox.Show(null, "成功登陆到嘉源V1.1人事管理系统", "登陆成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(null, "请检查用户名和密码输入是否正确,请注意字母的大小写", "登陆失败", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
            else
            {
                MessageBox.Show(null, "请检查用户名和密码输入是否正确,请注意字母的大小写", "登陆失败", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }
        #endregion

        #region [事件] [保存公司设置]
        private void reord_button_Click(object sender, EventArgs e)
        {
            Record_Information(".//System_Information//System_Information.ini", ".//System_Information//SQLSERVER_Information.ini", company_name_textBox.Text, system_name_textBox.Text, sql_user_textBox.Text, sql_password_textBox.Text, sqlserver_name_comboBox.Text);
            Read_Data(".//System_Information//System_Information.ini", 0, company_name_textBox);
            Read_Data(".//System_Information//System_Information.ini", 1, system_name_textBox);
            company_name_textBox.Enabled = false;
            system_name_textBox.Enabled = false;
            sqlserver_name_comboBox.Enabled = false;
            sql_user_textBox.Enabled = false;
            sql_password_textBox.Enabled = false;
            update_button.Text = "重新设置";
        }
        #endregion

        #region [事件] [单击SQL服务器下拉列表]
        private void sqlserver_name_comboBox_MouseDown(object sender, MouseEventArgs e)
        {
            sqlserver_name_comboBox.Items.Clear();
            CombBox_Load(".//System_Information//SQLSERVER_Information.ini", sqlserver_name_comboBox);
        }
        #endregion

        #region [事件] [重新设置公司信息]
        private void update_button_Click(object sender, EventArgs e)
        {
            if (update_button.Text == "重新设置")
            {
                update_button.Text = "取消设置";
                company_name_textBox.Enabled = true;
                system_name_textBox.Enabled = true;
                sqlserver_name_comboBox.Enabled = true;
                sql_user_textBox.Enabled = true;
                sql_password_textBox.Enabled = true;
            }
            else 
            {
                update_button.Text = "重新设置";
                company_name_textBox.Enabled = false;
                system_name_textBox.Enabled = false;
                sqlserver_name_comboBox.Enabled = false;
                sql_user_textBox.Enabled = false;
                sql_password_textBox.Enabled = false;
            }
        }
        #endregion

        #region [事件] [单击用户名下拉列表]
        private void user_name_comboBox_MouseDown(object sender, MouseEventArgs e)
        {
            user_name_comboBox.Items.Clear();
            CombBox_Load(".//Record_User_Info//User_Info.ini", user_name_comboBox);
        }
        #endregion

        #region [事件] [取消按钮]
        private void cancel_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
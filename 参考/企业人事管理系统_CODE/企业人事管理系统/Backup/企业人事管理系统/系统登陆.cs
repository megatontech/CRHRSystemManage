using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
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
        Secret Sc = new Secret();
        SQL_Link SQL_Linker = new SQL_Link();
        delegate void Logo_Delegate();
        bool Accessful_Join = false;
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
                using (FileStream FS = File.Create(file_path)) 
                {
                    FS.Close();
                }
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
                            CombBox_List.Items.Add(Sc.Fun_UnSecret(Temp_String[i]));
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
                    Write_String.WriteLine(Sc.Fun_Secret(Record_SQL_Data));
                    MessageBox.Show(null, "记录成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                Write_String.Close();
            }
            File.WriteAllText(System_File_Path, Sc.Fun_Secret(Record_Data_001) + "\r\n" + Sc.Fun_Secret(Record_Data_002) + "\r\n" + Sc.Fun_Secret(Record_SQL_Data) + "\r\n" + Sc.Fun_Secret(Record_Data_003) + "\r\n" + Sc.Fun_Secret(Record_Data_004) + "\r\n", Encoding.UTF8);
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
                if (Record_Data_OK == true) Write_String.WriteLine(Sc.Fun_Secret(Record_Data));
                Write_String.Close();
            }
        }
        #endregion

        #region[函数] [皮肤ini文件数据读取]
        public void Read_Data_For_Skin()
        {
            try
            {
                string[] Temp_Data = File.ReadAllLines(".//skin//skin.ini", Encoding.UTF8);
                if (Temp_Data.Length > 0)
                {
                    skinEngine1.SkinFile = Sc.Fun_UnSecret(Temp_Data[0]);
                }
                else
                    skinEngine1.SkinFile = ".//skin//skin.ssk";
            }
            catch { }
        }
        #endregion

        #region [函数] [读取记录]
        public void Read_Data(string File_Path, int Data_Num, Control Control_name)
        {
            try
            {
                string[] Temp_Data = File.ReadAllLines(File_Path);
                if (Temp_Data.Length > Data_Num)
                {
                    Control_name.Text = Sc.Fun_UnSecret(Temp_Data[Data_Num]);
                }
            }
            catch { }
        }
        #endregion

        #endregion

        #region [事件] [FormLoad]
        private void Form_Join_Load(object sender, EventArgs e)
        {
            If_File(".//Record_User_Info//User_Info.ini", ".//Record_User_Info");
            If_File(".//System_Information//System_Information.ini", ".//System_Information");
            If_File(".//System_Information//SQLSERVER_Information.ini", ".//System_Information");
            If_File(".//skin//skin.ini", ".//skin");
            CombBox_Load(".//Record_User_Info//User_Info.ini", user_name_comboBox);
            CombBox_Load(".//System_Information//SQLSERVER_Information.ini", sqlserver_name_comboBox);
            Read_Data(".//System_Information//System_Information.ini", 0, company_name_textBox);
            Read_Data(".//System_Information//System_Information.ini", 1, system_name_textBox);
            Read_Data(".//System_Information//System_Information.ini", 2, sqlserver_name_comboBox);
            Read_Data(".//System_Information//System_Information.ini", 3, sql_user_textBox);
            Read_Data(".//System_Information//System_Information.ini", 4, sql_password_textBox);
            Read_Data_For_Skin();
            CheckForIllegalCrossThreadCalls = false;//解决跨线程调用
            //Reg_SQLDMO();
        }
        #endregion

        #region [事件] [公司设置]
        private void set_system_button_Click(object sender, EventArgs e)
        {
            if (set_system_button.Text == "公司设置↓")
            {
                set_system_button.Text = "公司设置↑";
                this.Height = 455;
                if (groupBox2.Visible == false)
                    groupBox2.Visible = true;
                this.CenterToScreen();
            }
            else
            {
                set_system_button.Text = "公司设置↓";
                this.Height = 240;
                groupBox2.Hide();
                this.CenterToScreen();
            }
        }
        #endregion
        
        #region [事件] [登陆按钮]
        private void Join_button_Click(object sender, EventArgs e)
        {
            Accessful_Join = false;
            if (user_name_comboBox.Text.Trim() == "")
            {
                MessageBox.Show(null, "用户名不能为空", "登陆失败", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }               
            if (sqlserver_name_comboBox.Text == "" || sqlserver_name_comboBox.Text == null || sqlserver_name_comboBox.Enabled == true)
            {
                MessageBox.Show(null, "登陆前请先进行公司设置并[保存]", "登陆失败", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            } 
            //if (checkBox1.Checked == false)
            //    Linker = SQL_Linker.Link_SQL(sqlserver_name_comboBox.Text, "嘉源人事管理系统", sql_user_textBox.Text, sql_password_textBox.Text);
            //else
            //    Linker = SQL_Linker.Link_SQL(sqlserver_name_comboBox.Text, "嘉源人事管理系统", null, null);
            //DS = SQL_Linker.SQL_Select("Select * From System_Admin Where User_Name = '" + user_name_comboBox.Text.Replace("'", "") + "' And Password = '" + password_textBox.Text.Replace("'", "") + "'", null);
            
            //MDI主窗口 MDI_Show = new MDI主窗口(user_name_comboBox.Text, (bool)DS.Tables[0].Rows[0][2], Linker);
            //this.Hide();
            //MDI_Show.ShowDialog();
            //Application.Exit();
            Thread LT = new Thread(new ThreadStart(p));
            LT.Start();

            #region 无线程调用
            //bool Accessful_Join = false;
            //if (sqlserver_name_comboBox.Text == "" || sqlserver_name_comboBox.Text == null || sqlserver_name_comboBox.Enabled == true)
            //{
            //    MessageBox.Show(null, "登陆前请先进行公司设置并[保存]", "登陆失败", MessageBoxButtons.OK, MessageBoxIcon.Question);
            //    return;
            //}

            //Thread TH = new Thread(new ThreadStart(SQL_Linker.Wait_Form));
            //TH.Start();
            //Linker = SQL_Linker.Link_SQL(sqlserver_name_comboBox.Text, "嘉源人事管理系统", sql_user_textBox.Text, sql_password_textBox.Text);
            //DS = SQL_Linker.SQL_Select("Select * From System_Admin Where User_Name = '" + user_name_comboBox.Text.Replace("'", "") + "' And Password = '" + password_textBox.Text.Replace("'", "") + "'", null);
            //if (DS != null)
            //{
            //    try
            //    {
            //        if (DS.Tables[0].Rows[0].ItemArray[0].ToString() == user_name_comboBox.Text && DS.Tables[0].Rows[0].ItemArray[1].ToString() == password_textBox.Text)
            //        {
            //            Record_Data(".//Record_User_Info//User_Info.ini", user_name_comboBox.Text, user_name_comboBox);
            //            Accessful_Join = true;
            //        }
            //        else
            //        {
            //            TH.Abort();
            //            MessageBox.Show(null, "请检查用户名和密码输入是否正确,请注意字母的大小写", "登陆失败", MessageBoxButtons.OK, MessageBoxIcon.Question);
            //        }
            //    }
            //    catch
            //    {
            //        TH.Abort();
            //        MessageBox.Show(null, "请检查用户名密码以及数据库连接参数是否正确无误", "登陆失败", MessageBoxButtons.OK, MessageBoxIcon.Question);
            //    }
            //}
            //else
            //{
            //    TH.Abort();
            //    MessageBox.Show(null, "请检查用户名和密码输入是否正确,请注意字母的大小写", "登陆失败", MessageBoxButtons.OK, MessageBoxIcon.Question);
            //}
            //try
            //{
            //    TH.Abort();
            //}
            //catch { };

            //if (Accessful_Join == true)
            //{
            //    MDI主窗口 MDI_Show = new MDI主窗口(user_name_comboBox.Text, (bool)DS.Tables[0].Rows[0][2], Linker);
            //    this.Hide();
            //    MDI_Show.ShowDialog();
            //    Application.Exit();
            //}
            #endregion
        }
        #endregion

        #region [事件] [取消按钮]
        private void cancel_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region [事件] [保存公司设置]
        private void reord_button_Click(object sender, EventArgs e)
        {
            if (sqlserver_name_comboBox.Text.Trim() != "")
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
            else 
            {
                MessageBox.Show(null, "数据库名不能为空", "保存设置失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
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
        private void user_name_comboBox_DropDown(object sender, EventArgs e)
        {
            user_name_comboBox.Items.Clear();
            CombBox_Load(".//Record_User_Info//User_Info.ini", user_name_comboBox);
        }
        #endregion

        #region [事件] [单击SQL 服务器下拉列表]
        private void sqlserver_name_comboBox_DropDown(object sender, EventArgs e)
        {
            sqlserver_name_comboBox.Items.Clear();
            CombBox_Load(".//System_Information//SQLSERVER_Information.ini", sqlserver_name_comboBox);
        }
        #endregion

        #region[事件] [购买注册码]
        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            购买注册码 G_Form = new 购买注册码();
            G_Form.ShowDialog();
        }
        #endregion

        #region [函数] [登陆函数]
        public void Logo_Fun()
        {
            Thread TH = new Thread(new ThreadStart(SQL_Linker.Wait_Form));
            TH.Start();
            if (checkBox1.Checked == false)
                Linker = SQL_Linker.Link_SQL(sqlserver_name_comboBox.Text, "嘉源人事管理系统", sql_user_textBox.Text, sql_password_textBox.Text);
            else
                Linker = SQL_Linker.Link_SQL(sqlserver_name_comboBox.Text, "嘉源人事管理系统", null, null);
            DS = SQL_Linker.SQL_Select("Select * From System_Admin Where User_Name = '" + user_name_comboBox.Text.Replace("'", "") + "' And Password = '" + password_textBox.Text.Replace("'", "") + "'", null);
            if (DS != null)
            {
                try
                {
                    if (DS.Tables[0].Rows[0].ItemArray[0].ToString() == user_name_comboBox.Text && DS.Tables[0].Rows[0].ItemArray[1].ToString() == password_textBox.Text)
                    {
                        TH.Abort();
                        Record_Data(".//Record_User_Info//User_Info.ini", user_name_comboBox.Text, user_name_comboBox);
                        Accessful_Join = true;
                        Logo_Delegate Logo = new Logo_Delegate(s);
                        this.Invoke(Logo, null);
                        return;
                    }
                    else
                    {
                        TH.Abort();
                        Logo_Delegate Message_Box = new Logo_Delegate(m);
                        Message_Box();
                        return;
                    }
                }
                catch (Exception err)
                {
                    TH.Abort();
                    if (Accessful_Join == false)
                        notifyIcon1.ShowBalloonTip(1500, "登陆失败", "数据库连接失败,请检查您的[公司设置]并确定数据库服务器已经开启!", ToolTipIcon.Info);
                    else
                    {
                        try
                        {
                            int num = err.ToString().IndexOf("。");
                            notifyIcon1.ShowBalloonTip(1500, "系统错误", err.ToString().Substring(0, num), ToolTipIcon.Info);
                        }
                        catch
                        {
                            notifyIcon1.ShowBalloonTip(1500, "系统错误", err.ToString(), ToolTipIcon.Info);
                        }
                    }
                    return;
                }
            }
            else
            {
                TH.Abort();
                Logo_Delegate Message_Box = new Logo_Delegate(m);
                Message_Box();
                return;
            }
        }
        #endregion

        #region 利用子线程判断登陆结果
        public void p()
        {
            Logo_Delegate Logo = new Logo_Delegate(Logo_Fun);
            //this.Invoke(Logo, null);//给予UI主线程调用委托
            Logo();//子线程调用委托
        }
        #endregion

        #region 利用主线程显示MDI界面
        public void s()
        {
            if (Accessful_Join == true)
            {
                MDI主窗口 MDI_Show = new MDI主窗口(user_name_comboBox.Text, (bool)DS.Tables[0].Rows[0][2], Linker);
                this.Hide();
                MDI_Show.ShowDialog();
                Application.Exit();
            }
        }
        #endregion

        #region 利用子线程显示对话框,缺点:无皮肤
        public void m()
        {
            notifyIcon1.ShowBalloonTip(1500, "登陆失败", "请检查用户名和密码输入是否正确,请注意字母的大小写", ToolTipIcon.Info);
            return;
            //MessageBox.Show(null, "请检查用户名和密码输入是否正确,请注意字母的大小写", "登陆失败", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
        #endregion

        #region[事件] [退出系统]
        private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }
        #endregion

        #region[函数] [注册SQLDMO]
        public void Reg_SQLDMO() 
        {
            if (!File.Exists(Application.StartupPath + @"\DMO.ini"))
            {
                try
                {
                    Process p = new Process();
                    p.StartInfo.FileName = "CMD.exe";
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.RedirectStandardInput = true;
                    p.StartInfo.RedirectStandardOutput = true;
                    p.StartInfo.RedirectStandardError = true;
                    p.StartInfo.CreateNoWindow = true;
                    p.Start();
                    p.StandardInput.WriteLine("regsvr32 " + '"' + Application.StartupPath + @"\SQLDMO\SQLDMO.dll" + '"');
                    //p.WaitForExit();
                    File.CreateText(Application.StartupPath + @"\DMO.ini");
                }
                catch { }
            }
        }
        #endregion

        #region[事件] [Windows验证模式]
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                sqlserver_name_comboBox.Enabled = true;
                notifyIcon1.ShowBalloonTip(1500, "已切换到Windows身份验证模式", "您只需输入服务器名称,无需输入[数据库设置]中的用户名和密码", ToolTipIcon.Info);
            }
            if (checkBox1.Checked == false && sql_user_textBox.Enabled == false) 
            {
                sqlserver_name_comboBox.Enabled = false;
            }
        }
        #endregion


    }

}
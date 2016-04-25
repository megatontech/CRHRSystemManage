using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 企业人事管理系统
{
    public partial class 字段编辑 : Form
    {
        string G_Name = "";
        DataGridViewRow DR = null;
        SQL_Link SQL_Linker = new SQL_Link();
        delegate void R();
        bool D_Name_Change = false;//编辑模式的时候`判断是否已经修改过字段名
        bool D_Def_Change = false;//修改字段默认值

        public 字段编辑(string Button_Name, DataGridViewRow DGR)
        {
            G_Name = Button_Name;
            DR = DGR;
            InitializeComponent();
        }

        private void 字段编辑_Load(object sender, EventArgs e)
        {
            groupBox1.Text = G_Name;
            if (G_Name == "修改")
            {
                try
                {
                    Data_Type.Enabled = false;
                    Data_Length.Enabled = false;
                    if (DR.Cells[1].Value.ToString() == "decimal")
                        Small_Num.Enabled = true;
                    Data_Name.Text = DR.Cells[0].Value.ToString();
                    if (DR.Cells[1].Value.ToString() == "varchar")
                        Data_Type.Text = "字符";
                    if (DR.Cells[1].Value.ToString() == "int" || DR.Cells[1].Value.ToString() == "decimal")
                        Data_Type.Text = "数字";
                    if (DR.Cells[1].Value.ToString() == "datetime")
                        Data_Type.Text = "日期";
                    Data_Length.Value = (int)DR.Cells[2].Value;
                    Small_Num.Value = (int)DR.Cells[3].Value;
                    Data_Dealful_Value.Text = DR.Cells[4].Value.ToString().Replace("'", "").Replace("(", "").Replace(")", "").Trim();
                    Data_List.Text = DR.Cells[5].Value.ToString();
                }
                catch { }
            }
            else
            {
                Data_Type.Enabled = true;
                Data_Length.Enabled = true;
            }
        }

        #region[函数] [保存修改函数]
        public void Auto_Save_Update()
        {
            #region 排除条件
            if (Data_Name.Text.Trim() == "") 
            {
                MessageBox.Show("字段名不能为空");
                return;
            } 
            if (Data_Type.Text.Trim() == "") 
            {
                MessageBox.Show("字段类型不能为空");
                return;
            }
            try
            {
                if (Data_Name.Text.Trim() != DR.Cells[0].Value.ToString().Trim() && int.Parse(SQL_Linker.SQL_Select(@"select count(*) from sysobjects where id = object_id('_" + Data_Name.Text.Trim() + "')", MDI主窗口.Send_Data_2).Tables[0].Rows[0][0].ToString()) > 0)
                {
                    MessageBox.Show("字段名称有冲突,请更换一个试试");//是否有相同名称的表
                    return;
                }
            }
            catch { }
            if (G_Name == "增加" || D_Name_Change == true)
            {
                if (SQL_Linker.SQL_Select(@"SELECT  a.name N'字段名' FROM syscolumns a 
INNER JOIN sysobjects d on a.id=d.id AND d.xtype='U' AND d.name<>'dtproperties' and  a.name='" + Data_Name.Text.Trim() + @"'
WHERE d.name = '" + MDI主窗口.自定义字段_Table + "'", MDI主窗口.Send_Data_2).Tables[0].Rows.Count != 0)
                {
                    MessageBox.Show("已经存在同名的字段名,请更换一个试试");
                    return;
                }
            }
            #endregion

            string SQL_String = "";

            #region 数据增加
            if (G_Name == "增加")
            {
                string Send_Data_Type = "";
                string Send_Data_S_Num = "";
                if (Data_Type.Text == "字符")
                    Send_Data_Type = "varchar";
                if (Data_Type.Text == "数字")
                {
                    if (Small_Num.Value.ToString().Trim() != "0")
                        Send_Data_Type = "decimal";
                    else
                        Send_Data_Type = "int";
                }
                if (Small_Num.Value.ToString().Trim() != "0")
                    Send_Data_S_Num = "," + Small_Num.Value.ToString().Trim();
                if (Data_Type.Text == "日期")
                    Send_Data_Type = "datetime";
                if (Send_Data_Type == "int" || Send_Data_Type == "datetime")
                    SQL_String = @"ALTER table " + MDI主窗口.自定义字段_Table + " add [" + Data_Name.Text.Trim() + "] " + Send_Data_Type;//添加列  
                else
                    SQL_String = @"ALTER table " + MDI主窗口.自定义字段_Table + " add [" + Data_Name.Text.Trim() + "] " + Send_Data_Type + "(" + Data_Length.Value.ToString() + Send_Data_S_Num + ") ";//添加列   
                if (Data_Dealful_Value.Text.Trim() != "")
                {
                    SQL_String += " default ('" + Data_Dealful_Value.Text.Trim() + "')";
                }
                if (checkBox1.Checked == false)
                {
                    SQL_String += " not null";
                }
                SQL_Linker.SQL_Update(SQL_String, MDI主窗口.Send_Data_2);
                if (Data_List.Text.Replace(",", "").Trim() != "")//添加字段值列表
                {
                    string Creat_SQL_String = "create table [_" + Data_Name.Text.Trim() + "] ([" + Data_Name.Text.Trim() + "] " + Send_Data_Type + "(" + Data_Length.Value.ToString() + Send_Data_S_Num + "))";
                    string[] D_List = Data_List.Text.Split(',');
                    foreach (string T_S in D_List)
                    {
                        Creat_SQL_String += "\r\n insert into [_" + Data_Name.Text.Trim() + "] values('" + T_S + "')";
                    }
                    SQL_Linker.SQL_Update(Creat_SQL_String, MDI主窗口.Send_Data_2);
                }
                MDI主窗口.Re_Load_ZDY_Form = true;
                this.Close();
            }
            #endregion

            #region 数据修改
            if (G_Name == "修改")
            {
                string Send_Data_Name = DR.Cells[0].Value.ToString().Trim();
                string Send_Data_Type = DR.Cells[1].Value.ToString();
                string Send_Data_S_Num = DR.Cells[3].Value.ToString().Trim();
                if (D_Name_Change == true)
                {
                    SQL_String = @"EXEC   sp_rename   '" + MDI主窗口.自定义字段_Table + "." + Send_Data_Name + "',   '" + Data_Name.Text.Trim() + @"',   'COLUMN'  EXEC sp_rename  '_" + Send_Data_Name + "', '_" + Data_Name.Text.Trim() + "'";
                    SQL_Linker.SQL_Update(SQL_String, MDI主窗口.Send_Data_2);
                }
                if (D_Def_Change == true)
                {
                    string temp_s = DR.Cells[4].Value.ToString().Replace("'", "").Replace("(", "").Replace(")", "").Trim();
                    if (temp_s != "")//是否有约束
                    {
                        SQL_Linker.SQL_Update(@"declare @csname varchar(100) set @csname='' select @csname=[name]  from sysobjects t where id=(select cdefault from syscolumns where id=object_id(N'" + MDI主窗口.自定义字段_Table + @"') and name='" + Data_Name.Text.Trim() + "') exec('alter table " + MDI主窗口.自定义字段_Table + " drop constraint '+@csname)", MDI主窗口.Send_Data_2);
                    }
                    if (Data_Dealful_Value.Text.Trim() != "")
                        SQL_Linker.SQL_Update(@"alter table " + MDI主窗口.自定义字段_Table + @" add constraint  [C_" + Data_Name.Text.Trim() + "]  default  '" + Data_Dealful_Value.Text.Trim() + "'  for [" + Data_Name.Text.Trim() + "]", MDI主窗口.Send_Data_2);
                }
                if (Data_List.Text.Replace(",", "").Trim() != "")
                {
                    if (DR.Cells[5].Value.ToString().Trim() != "")
                    {
                        SQL_Linker.SQL_Update("drop table  _" + Data_Name.Text.Trim(), MDI主窗口.Send_Data_2);
                    }
                    if (Send_Data_S_Num != "0")
                        Send_Data_S_Num = "," + Send_Data_S_Num;
                    else
                        Send_Data_S_Num = "";
                    string Creat_SQL_String = "";
                    if (Send_Data_Type == "int" || Send_Data_Type == "datetime")
                        Creat_SQL_String = "create table [_" + Data_Name.Text.Trim() + "] ([" + Data_Name.Text.Trim() + "] " + Send_Data_Type + ")";
                    else
                        Creat_SQL_String = "create table [_" + Data_Name.Text.Trim() + "] ([" + Data_Name.Text.Trim() + "] " + Send_Data_Type + "(" + Data_Length.Value.ToString() + Send_Data_S_Num + "))";
                    string[] D_List = Data_List.Text.Split(',');
                    foreach (string T_S in D_List)
                    {
                        Creat_SQL_String += "\r\n insert into [_" + Data_Name.Text.Trim() + "] values('" + T_S + "')";
                    }
                    SQL_Linker.SQL_Update(Creat_SQL_String, MDI主窗口.Send_Data_2);

                }
                else
                {
                    if (DR.Cells[5].Value.ToString().Trim() != "")
                    {
                        SQL_Linker.SQL_Update("drop table _" + Data_Name.Text.Trim(), MDI主窗口.Send_Data_2);
                    }
                }
                if (Small_Num.Value.ToString() != DR.Cells[3].Value.ToString().Trim())
                {
                    SQL_Linker.SQL_Update("ALTER table " + MDI主窗口.自定义字段_Table + " alter column [" + Data_Name.Text.Trim() + "] " + Send_Data_Type + "(" + Data_Length.Value.ToString() + "," + Small_Num.Value.ToString() + ") ", MDI主窗口.Send_Data_2);
                    SQL_Linker.SQL_Update("ALTER table _" + Data_Name.Text.Trim() + " alter column [" + Data_Name.Text.Trim() + "] " + Send_Data_Type + "(" + Data_Length.Value.ToString() + "," + Small_Num.Value.ToString() + ") ", MDI主窗口.Send_Data_2);
                }
                MDI主窗口.Re_Load_ZDY_Form = true;
                this.Close();
            }
            #endregion

        }
        #endregion

        #region[事件] [保存按钮]
        private void button1_Click(object sender, EventArgs e)
        {
            Auto_Save_Update();
        }
        #endregion

        #region[事件] [默认值text更改]
        private void Data_Dealful_Value_TextChanged(object sender, EventArgs e)
        {
            if (Data_Dealful_Value.Text.Trim() != "" && checkBox1.Checked == true)
            {
                checkBox1.Checked = false;
            }
            if (Data_Dealful_Value.Text.Trim() == "") 
            {
                checkBox1.Checked = true;
            }
            if (G_Name == "修改" && Data_Dealful_Value.Text.Trim() != DR.Cells[4].Value.ToString().Replace("'", "").Replace("(", "").Replace(")", "").Trim())
            {
                D_Def_Change = true;
            }
        }
        #endregion

        #region[事件] [字段名更改]
        private void Data_Name_TextChanged(object sender, EventArgs e)
        {
            if (G_Name == "修改" && Data_Name.Text.Trim() != DR.Cells[0].Value.ToString().Trim() && Data_Name.Text.Trim() != "")
            {
                D_Name_Change = true;
            }
        }
        #endregion

        #region[事件] [选择字段类型]
        private void Data_Type_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Data_Type.Text.Trim() == "数字")
                Small_Num.Enabled = true;
            else
            {
                Small_Num.Value = 0;
                Small_Num.Enabled = false;
            }
        }
        #endregion

        #region[事件] [小数位更改]
        private void Small_Num_ValueChanged(object sender, EventArgs e)
        {
            if (Small_Num.Value.ToString().Trim() != "0")
                Data_Length.Maximum = 38;
            else
                Data_Length.Maximum = 255;
        }
        #endregion
    }
}
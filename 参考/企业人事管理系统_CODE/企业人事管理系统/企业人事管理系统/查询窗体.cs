using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 企业人事管理系统
{
    public partial class 查询窗体 : Form
    {

        #region[公共变量]
        string Select_Table_Name;
        SQL_Link SQL_Linker = new SQL_Link();
        DataTable DT;
        bool First_AND_OR = false;
        string LS_Select_String;
        #endregion

        #region[窗体构造函数]
        public 查询窗体(string Table_Name)
        {
            Select_Table_Name = Table_Name;
            InitializeComponent();
        }
        #endregion

        #region[公共函数]
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
        #endregion

        #region[事件] [Form_Load]
        private void 查询窗体_Load(object sender, EventArgs e)
        {
            DT = SQL_Linker.SQL_Select("select * from " + Select_Table_Name, MDI主窗口.Send_Data_2).Tables[0];
            LS_Select_String = "select * from " + Select_Table_Name + " where ";
            foreach (DataColumn DC in DT.Columns)
            {
                if (DC.ColumnName != "照片" && DC.ColumnName != "标识")
                    字段名.Items.Add(DC.ColumnName);
                if (字段名.Text == "")
                    字段名.Text = DC.ColumnName;
            }
            条件.Text = "包含";
        }
        #endregion

        #region[事件] [查询窗体添加按钮]
        private void 添加按钮_Click(object sender, EventArgs e)
        {
            if (值.Text.Trim() != "")
            {
                if (First_AND_OR == false)
                {
                    First_AND_OR = true;
                    LS_Select_String += 字段名.Text + Auto_IF_String(条件.Text) + Auto_Word(Auto_IF_String(条件.Text));
                    listView1.Items.Add(字段名.Text + " " + 条件.Text + " " + 值.Text.Trim());
                }
                else
                {
                    if (和.Checked == true)
                    {
                        listView1.Items.Add("和");
                        LS_Select_String += " and " + 字段名.Text + Auto_IF_String(条件.Text) + Auto_Word(Auto_IF_String(条件.Text));
                    }
                    else
                    {
                        listView1.Items.Add("或");
                        LS_Select_String += " or " + 字段名.Text + Auto_IF_String(条件.Text) + Auto_Word(Auto_IF_String(条件.Text));
                    }
                    listView1.Items.Add(字段名.Text + " " + 条件.Text + " " + 值.Text.Trim());
                }
                MDI主窗口.Select_Together_String = LS_Select_String;
            }
            else { }
        }
        #endregion

        #region[事件] [清空按钮]
        private void 清空_Click(object sender, EventArgs e)
        {
            MDI主窗口.Select_Together_String = null;
            listView1.Clear();
            First_AND_OR = false;
        }
        #endregion

        #region[事件] [确定按钮]
        private void 确定按钮_Click(object sender, EventArgs e)
        {
            if (值.Text.Trim() != "")
            {
                人事资料.Select_Fun();
                this.Close();
            }
        }
        #endregion

        #region[事件] [取消按钮]
        private void 取消按钮_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
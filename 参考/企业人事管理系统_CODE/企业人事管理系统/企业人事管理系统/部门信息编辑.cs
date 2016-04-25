using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace 企业人事管理系统
{
    public partial class 部门信息编辑 : Form
    {
        SQL_Link Link = new SQL_Link();
        Public_Fun PF = new Public_Fun();
        string Auto_BM;
        string Node_Name;

        public 部门信息编辑(string Button_Info,string Node_Info)
        {
            Auto_BM = Button_Info;
            Node_Name = Node_Info;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Update_String = "";
            if (Auto_BM == "编辑(&E)") 
            {
                Update_String = "update Basic_Bm set 部门名称='" + textBox1.Text.Trim() + "',部门经理='" + textBox2.Text + "',联系电话='" + textBox3.Text + "',负责人='" + textBox4.Text + "',备注='" + textBox5.Text + "',上级部门='" + textBox6.Text + "' where 部门名称='" + Node_Name + "'";
            }
            else
            {
                if (textBox1.Text != null && textBox1.Text.Trim() != "")
                {
                    DataSet DS = Link.SQL_Select("select * from Basic_Bm where " + '"' + "部门名称" + '"' + " ='" + textBox1.Text + "'", MDI主窗口.Send_Data_2);
                    if (DS.Tables[0].Rows.Count == 0)
                    {
                        部门设置 form = new 部门设置();
                        form.BM_String[0] = textBox1.Text.Trim();
                        form.BM_String[1] = textBox2.Text.Trim();
                        form.BM_String[2] = textBox3.Text.Trim();
                        form.BM_String[3] = textBox4.Text.Trim();
                        form.BM_String[4] = textBox5.Text.Trim();
                        Update_String = "insert into Basic_Bm values('" + form.BM_String[0] + "' ,'" + Node_Name + "'";
                        for (int i = 1; i < 5; i++)
                        {
                            Update_String += ",'" + form.BM_String[i] + "'";
                        }
                        Update_String += ")";
                    }
                    else
                    {
                        MessageBox.Show(null, "部门名称重复,请重新设置部门名称!", "错误");
                    }
                }
            }
            if (textBox1.Text.Trim() != "")
            {
                Link.SQL_Update(Update_String, MDI主窗口.Send_Data_2);
                部门设置.UP_SQL = true;
                this.Close();
            }
            else 
            {
                MessageBox.Show("部门名称不能为空");
            }
        }

        private void 部门信息编辑_Load(object sender, EventArgs e)
        {
            if (Auto_BM == "编辑(&E)")
            {
                DataSet DS = Link.SQL_Select("select * from Basic_Bm where " + '"' + "部门名称" + '"' + " ='" + Node_Name + "'", MDI主窗口.Send_Data_2);
                textBox1.Text = DS.Tables[0].Rows[0][0].ToString();
                textBox2.Text = DS.Tables[0].Rows[0][2].ToString();
                textBox3.Text = DS.Tables[0].Rows[0][3].ToString();
                textBox4.Text = DS.Tables[0].Rows[0][4].ToString();
                textBox5.Text = DS.Tables[0].Rows[0][5].ToString();
                textBox6.Text = DS.Tables[0].Rows[0][1].ToString();
            }
            if (Auto_BM == "新增子级部门(&N)" || Auto_BM == "新增部门(&A)") 
            {
                textBox6.Enabled = false;
                textBox6.Text = Node_Name;
            }
        }
    }
}
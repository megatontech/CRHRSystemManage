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
    public partial class 公司资料设置 : Form
    {
        SqlConnection Link_Conn;
        SQL_Link Link;
        DataSet DS;
        DataTable DT;
        public 公司资料设置(SqlConnection Send_Data)
        {
            Link_Conn = Send_Data;
            InitializeComponent();
        }

        private void 公司资料设置_Load(object sender, EventArgs e)
        {
            Link = new SQL_Link();
            DS = Link.SQL_Select("select * from Basic_Gs", Link_Conn);
            DT=DS.Tables[0];
            if (DT.Rows.Count != 0) 
            {
                for (int i = 1; i < DT.Rows[0].ItemArray.Length; i++)
                {
                    this.Controls.Find("textbox" + i.ToString(), true)[0].Text = DT.Rows[0].ItemArray[i].ToString();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DT.Rows.Count != 0)
            {
                string Update_String = "Update Basic_Gs set ";
                for (int i = 1; i < DT.Columns.Count; i++)
                {
                    if (i < DT.Columns.Count - 1) Update_String += DT.Columns[i].ColumnName + " ='" + this.Controls.Find("textbox" + i.ToString(), true)[0].Text + "' , ";
                    else Update_String += DT.Columns[i].ColumnName + " ='" + this.Controls.Find("textbox" + i.ToString(), true)[0].Text + @"' where " + '"' + "索引" + '"' + "=" + DT.Rows[0].ItemArray[0].ToString();
                }
                Link.SQL_Update(Update_String, Link_Conn);
                this.Close();
            }
            else
            {
                string Update_String = "insert into Basic_Gs values (";
                for (int i = 1; i < DT.Columns.Count; i++)
                {
                    if (i < DT.Columns.Count - 1) Update_String += " '" + this.Controls.Find("textbox" + i.ToString(), true)[0].Text + "' ,";
                    else Update_String += " '" + this.Controls.Find("textbox" + i.ToString(), true)[0].Text + "')";
                }
                Link.SQL_Update(Update_String, Link_Conn);
                this.Close();
            }
        }
    }
}
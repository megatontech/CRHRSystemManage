using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 企业人事管理系统
{
    public partial class 自定义字段 : Form
    {
        public 自定义字段()
        {
            InitializeComponent();
        }

        SQL_Link SQL_Linker = new SQL_Link();
        DataTable DT = new DataTable();
        int Table_C_Num = 0;

        #region[函数] [判断表名]
        public void Auto_TableName()
        {
            if (MDI主窗口.自定义字段_Table == "人事资料")
            {
                MDI主窗口.自定义字段_Table = "Person_Info";
                Table_C_Num = 16;
            }
            if (MDI主窗口.自定义字段_Table == "培训管理")
            {
                MDI主窗口.自定义字段_Table = "Person_Pxjl";
                Table_C_Num = 6;
            }
            if (MDI主窗口.自定义字段_Table == "奖惩管理")
            {
                MDI主窗口.自定义字段_Table = "Person_Jcjl";
                Table_C_Num = 8;
            }
            if (MDI主窗口.自定义字段_Table == "调薪管理")
            {
                MDI主窗口.自定义字段_Table = "Person_Txjl";
                Table_C_Num = 19;
            }
            if (MDI主窗口.自定义字段_Table == "考评管理")
            {
                MDI主窗口.自定义字段_Table = "Person_Kpjl";
                Table_C_Num = 8;
            }
            if (MDI主窗口.自定义字段_Table == "合同管理")
            {
                MDI主窗口.自定义字段_Table = "Person_Htjl";
                Table_C_Num = 9;
            }
        }
        #endregion

        #region[函数] [加载窗体]
        public void Load_Data()
        {
            DT = new DataTable();
            string Select_String = @"
SELECT  a.name N'字段名', b.name N'类型', COLUMNPROPERTY(a.id,a.name,'PRECISION') AS N'长度', ISNULL(COLUMNPROPERTY(a.id,a.name,'Scale'),0) AS N'小数位', ISNULL(e.text,'') N'默认值' FROM syscolumns a 
LEFT JOIN systypes b on a.xtype=b.xusertype
INNER JOIN sysobjects d on a.id=d.id AND d.xtype='U' AND d.name<>'dtproperties'and a.colorder >" + Table_C_Num.ToString() + @"
LEFT JOIN syscomments e on a.cdefault=e.id
LEFT JOIN sysproperties g on a.id=g.id AND a.colid=g.smallid  WHERE  d.name = '" + MDI主窗口.自定义字段_Table + @"'
ORDER BY  object_name(a.id), a.colorder";
            SQL_Linker.SQL_Bind(Select_String, MDI主窗口.Send_Data_2, DT, dataGridView1);
            DT.Columns.Add("字段值列表");
            string Data_List = "";
            int i = 0;
            foreach (DataRow DR in DT.Rows)
            {
                Data_List = "";
                if (int.Parse(SQL_Linker.SQL_Select("select   count(*)   from   sysobjects   where   xtype   =   'U'   and   name   =   '_" + DR[0].ToString() + "'", MDI主窗口.Send_Data_2).Tables[0].Rows[0][0].ToString()) != 0)
                {
                    foreach (DataRow DRR in SQL_Linker.SQL_Select("select * from [_" + DR[0].ToString() + "]", MDI主窗口.Send_Data_2).Tables[0].Rows)
                    {
                        if (Data_List == "")
                            Data_List = DRR[0].ToString().Trim();
                        else
                            Data_List += "," + DRR[0].ToString().Trim();
                    }
                    DT.Rows[i][5] = Data_List;
                }
                i++;
            }
            dataGridView1.DataSource = DT;
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.ColumnHeader);
        }
        #endregion

        private void 自定义字段_Load(object sender, EventArgs e)
        {
            Auto_TableName();
            Load_Data();
        }

        #region[事件] [退出按钮]
        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region[添加按钮]
        private void button1_Click(object sender, EventArgs e)
        {
            Control CT = (Control)sender;
            字段编辑 ZD = new 字段编辑(CT.Text, dataGridView1.CurrentRow);
            ZD.ShowDialog();
        }
        #endregion

        #region[事件] [双击单元格]
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            字段编辑 ZD = new 字段编辑("修改", dataGridView1.CurrentRow);
            ZD.ShowDialog();
        }
        #endregion

        #region 窗体获取焦点刷新显示
        private void 自定义字段_Activated(object sender, EventArgs e)
        {
            if (MDI主窗口.Re_Load_ZDY_Form == true)
            {
                Load_Data();
                MDI主窗口.Re_Load_ZDY_Form = false;
            }
        }
        #endregion

        #region[函数] [删除]
        public void Delete_Fun()
        {
            if (dataGridView1.CurrentRow.Cells[4].Value.ToString().Trim() != "")
                SQL_Linker.SQL_Update(@"declare @csname varchar(100) set @csname='' select @csname=[name]  from sysobjects t where id=(select cdefault from syscolumns where id=object_id(N'" + MDI主窗口.自定义字段_Table + @"') and name='" + dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim() + "') exec('alter table " + MDI主窗口.自定义字段_Table + " drop constraint '+@csname)", MDI主窗口.Send_Data_2);
            SQL_Linker.SQL_Update("ALTER table " + MDI主窗口.自定义字段_Table + " drop COLUMN [" + dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim() + "]", MDI主窗口.Send_Data_2);
            if (dataGridView1.CurrentRow.Cells[5].Value.ToString().Trim() != "")
                SQL_Linker.SQL_Update("drop table [_" + dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim() + "]", MDI主窗口.Send_Data_2);
            Load_Data();
        }
        #endregion

        #region[事件] [删除按钮]
        private void button3_Click(object sender, EventArgs e)
        {
            Delete_Fun();
        }
        #endregion
    }
}
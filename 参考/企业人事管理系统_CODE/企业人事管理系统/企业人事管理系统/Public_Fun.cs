using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Text;

namespace 企业人事管理系统
{
    class Public_Fun
    {
        #region[公共变量]
        public DataSet DS;
        DataTable DT;
        SQL_Link Link = new SQL_Link();
        public bool Tree_Node_P = false;
        #endregion

        #region[函数] [TreeView递归函数]

        #region [函数] [树型2级显示]
        public void Fun_Tree(TreeView TREE,SqlConnection Link_Conn)
        {
            DS = Link.SQL_Select("select * from Basic_Bm", Link_Conn);
            DT = DS.Tables[0];
            if (Tree_Node_P == false)
            {
                foreach (DataRow DR in DT.Rows)
                {
                    if (DR.ItemArray[1].ToString() == "0")
                    {
                        TreeNode TN = new TreeNode();
                        TN.Text = DR.ItemArray[0].ToString();
                        TREE.Nodes.Add(TN);
                    }
                }
                Tree_Node_P = true;
            }

            foreach (DataRow DR_2 in DT.Rows)
            {
                foreach (TreeNode TN_2 in TREE.Nodes)
                {
                    if (DR_2.ItemArray[1].ToString() == TN_2.Text)
                    {
                        TreeNode TN_3 = new TreeNode();
                        TN_3.Text = DR_2.ItemArray[0].ToString();
                        TN_2.Nodes.Add(TN_3);
                        Fun_Tree_2(TN_3);
                    }
                }
            }
        }
        #endregion

        #region [函数] [树型>3级递归]
        public void Fun_Tree_2(TreeNode T_Name)
        {
            foreach (DataRow DR_2 in DT.Rows)
            {
                if (DR_2.ItemArray[1].ToString() == T_Name.Text)
                {
                    TreeNode TN_3 = new TreeNode();
                    TN_3.Text = DR_2.ItemArray[0].ToString();
                    T_Name.Nodes.Add(TN_3);
                    Fun_Tree_2(TN_3);
                }
            }
        }
        #endregion

        #endregion

        #region[函数] [人事固定资料载入]
        public void Person_Index_Info_Load(DataGridView DGV_Name, Control Control_Name)
        {
            object Data_Type = DGV_Name.CurrentRow.Cells[DGV_Name.Columns[Control_Name.Name].Index].Value;
            DateTime RS;
            if (DateTime.TryParse(Data_Type.ToString(), out RS))
            {
                Control_Name.Text = RS.ToString("u");
            }
            else
                Control_Name.Text = Data_Type.ToString();
        }
        #endregion


    }
}

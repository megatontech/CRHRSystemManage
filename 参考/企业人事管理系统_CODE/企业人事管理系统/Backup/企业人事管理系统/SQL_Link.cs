using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using SQLDMO;
using System.IO;
using System.Threading;
using System.Text;

namespace 企业人事管理系统
{
    class SQL_Link
    {
        #region 公共变量
        public SqlConnection SQL_Conn;
        SqlDataAdapter DA;
        SqlCommand CMD;
        public DataSet DS;
        DataTable DT;
        bool BackUpData = false;//是否正在备份
        bool RestoreData = false;//是否正在恢复
        delegate void Exit_A();
        
        #endregion

        #region 数据连接
        public SqlConnection Link_SQL(string Server, string DataBase, string User_ID, string PassWord)
        {
            try
            {
                if (User_ID == null && PassWord == null)
                    SQL_Conn = new SqlConnection("Integrated Security = SSPI;database=" + DataBase + ";server=" + Server);
                else
                    SQL_Conn = new SqlConnection(@"server=" + Server + ";database=" + DataBase + ";user id=" + User_ID + ";pwd=" + PassWord);
            }
            catch { }
            return SQL_Conn;
        }
        #endregion

        #region 数据查询
        public DataSet SQL_Select(string Select_String, SqlConnection Link_Conn)
        {
            DS = new DataSet();
            DT = new DataTable();
            if (Link_Conn == null) Link_Conn = SQL_Conn;            
            try
            {
                DA = new SqlDataAdapter(Select_String, Link_Conn);
                DS.Clear();
                DA.Fill(DS);
            }
            catch (Exception err)
            {
                try
                {
                    int num = err.ToString().IndexOf("。");
                    MessageBox.Show(err.ToString().Substring(0, num));
                }
                catch { }
            }
            Link_Conn.Close();
            return DS;
        }
        #endregion

        #region 数据修改
        public int SQL_Update(string Update_String, SqlConnection Link_Conn)
        {
            if (Link_Conn == null) Link_Conn = SQL_Conn;
            CMD = new SqlCommand(Update_String, Link_Conn);
            int Result_Count = 0;
            if (CMD.Connection.State.ToString() == "close") Link_Conn.Open();
            try
            {
                Link_Conn.Open();
                Result_Count = CMD.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                try
                {
                    int num = err.ToString().IndexOf("。");
                    MessageBox.Show(err.ToString().Substring(0, num)); MessageBox.Show(Update_String);
                }
                catch
                {
                    MessageBox.Show(err.ToString());
                }
            }
            Link_Conn.Close();
            return Result_Count;
        }
        #endregion

        #region 数据按条读取
        public object Dr(string Read_String, SqlConnection Link_Conn)
        {
            object Read_Data = null;
            if (Link_Conn == null) Link_Conn = SQL_Conn;
            Link_Conn.Open();
            SqlDataReader dr = CMD.ExecuteReader();
            if (dr.Read())
            {
                Read_Data = dr[Read_String];
            }
            Link_Conn.Close();
            return Read_Data;
        }
        #endregion        

        #region DataGridView数据映射
        public SqlDataAdapter SQL_Bind(string Select_String, SqlConnection Link_Conn, DataTable SDT, DataGridView DG_Name)
        {
            SqlDataAdapter SDA = new SqlDataAdapter();
            try
            {
                SqlCommand SCMD = new SqlCommand(Select_String, Link_Conn);
                SDA.SelectCommand = SCMD;
                SDT.Clear();
                SDA.Fill(SDT);
                DG_Name.DataSource = SDT;
            }
            catch { }
            //catch (Exception err)
            //{
            //    try
            //    {
            //        int num = err.ToString().IndexOf("。");
            //        MessageBox.Show(err.ToString().Substring(0, num));
            //    }
            //    catch
            //    {
            //        MessageBox.Show(err.ToString());
            //    }
            //}
            return SDA;
        }
        #endregion

        #region 数据更新
        public void SQL_Save(SqlDataAdapter CDA, DataTable CDT, SqlConnection Link_Conn)
        {
            SqlCommandBuilder SCB = new SqlCommandBuilder(CDA);
            CDA.Update(CDT);
        }
        #endregion
        
        #region 数据备份
        public void SQL_BackUp(string Server)
        {
            if (BackUpData == true || RestoreData == true)
                return;
            SQLDMO.Backup oBackup = new SQLDMO.BackupClass();
            SQLDMO.SQLServer oSQLServer = new SQLDMO.SQLServerClass();
            Thread TH = null;
            try
            {
                Secret SC = new Secret();
                string[] T_Data = File.ReadAllLines(".//System_Information//System_Information.ini", Encoding.UTF8);
                oSQLServer.LoginSecure = false;
                oSQLServer.Connect(SC.Fun_UnSecret(T_Data[2]), SC.Fun_UnSecret(T_Data[3]), SC.Fun_UnSecret(T_Data[4]));
                oBackup.Action = SQLDMO.SQLDMO_BACKUP_TYPE.SQLDMOBackup_Database;
                oBackup.Database = "嘉源人事管理系统";
                try
                {
                    Directory.CreateDirectory(System.Windows.Forms.Application.StartupPath + @"\BAK");
                }
                catch { }
                if (Server == "l")
                    Server = System.Windows.Forms.Application.StartupPath + "//BAK//嘉源人事管理系统.bak";
                else
                    Server = @"C:\嘉源人事管理系统.bak";
                oBackup.Files = Server;
                oBackup.BackupSetName = "嘉源人事管理系统";
                oBackup.BackupSetDescription = "数据库备份";
                oBackup.Initialize = true;
                TH = new Thread(new ThreadStart(Wait_Form));
                TH.Start();
                oBackup.SQLBackup(oSQLServer);
                BackUpData = true;
                TH.Abort();
                BackUpData = false;
                MessageBox.Show("备份完毕,文件备份到: " + Server);
            }
            catch
            {
                TH.Abort();
                MessageBox.Show("备份失败,失败可能的原因 :\r\n1.您无法将远程数据库备份到本地 \r\n2.远程服务器不存在 " + Server + " 路径");
            }
            finally
            {
                oSQLServer.DisConnect();
            }
        }
        #endregion
        
        #region 调用备份等待窗体
        public void Wait_Form()
        {
            try
            {
                WaitForm WF = new WaitForm();
                WF.ShowDialog();
            }
            catch { }
        }
        #endregion

        #region 数据恢复
        public void RestoreDB(string FilePath)
        {
            if (BackUpData == true || RestoreData == true)
                return;
            if (FilePath == "l")
                FilePath = System.Windows.Forms.Application.StartupPath + @"\BAK\嘉源人事管理系统.bak";
            else if (FilePath == "s")
                FilePath = @"C:\嘉源人事管理系统.bak";
            else
                FilePath = System.Windows.Forms.Application.StartupPath + FilePath;
            Thread TH = null;
            string strDbName = "嘉源人事管理系统";
            string strFileName = FilePath;
            if (FilePath != "s")
            {
                if (!File.Exists(strFileName))
                {
                    if (FilePath == System.Windows.Forms.Application.StartupPath + @"\BAK\嘉源人事管理系统.bak")
                        MessageBox.Show("没有检测到备份文件,你可能还没有备份过");
                    else
                        MessageBox.Show("系统文件被删除或重命名,要解决此问题,请备份当前数据后重新安装本软件");
                    return;
                }
            }
            SQLDMO.SQLServer svr = new SQLDMO.SQLServerClass(); 
            Secret SC = new Secret();
            string[] T_Data = File.ReadAllLines(".//System_Information//System_Information.ini", Encoding.UTF8);
            svr.Connect(SC.Fun_UnSecret(T_Data[2]), SC.Fun_UnSecret(T_Data[3]), SC.Fun_UnSecret(T_Data[4]));
            try
            {                
                SQLDMO.QueryResults qr = svr.EnumProcesses(-1);
                int iColPIDNum = -1;
                int iColDbName = -1;
                for (int i = 1; i <= qr.Columns; i++)
                {
                    string strName = qr.get_ColumnName(i);
                    if (strName.ToUpper().Trim() == "SPID")
                    {
                        iColPIDNum = i;
                    }
                    else if (strName.ToUpper().Trim() == "DBNAME")
                    {
                        iColDbName = i;
                    }
                    if (iColPIDNum != -1 && iColDbName != -1)
                        break;
                }
                for (int i = 1; i <= qr.Rows; i++)
                {
                    int lPID = qr.GetColumnLong(i, iColPIDNum);
                    string strDBName = qr.GetColumnString(i, iColDbName);
                    if (strDBName.ToUpper() == strDbName.ToUpper())
                    {
                        svr.KillProcess(lPID);
                    }
                }

                SQLDMO.Restore res = new SQLDMO.RestoreClass();
                res.Action = 0;
                res.Files = strFileName;
                res.Database = strDbName;
                res.ReplaceDatabase = true;
                TH = new Thread(new ThreadStart(Wait_Form));
                TH.Start();
                res.SQLRestore(svr);
                TH.Abort();
                RestoreData = false;
                MessageBox.Show(@"已经成功恢复数据,系统将自动关闭,请重新启动");
                System.Windows.Forms.Application.ExitThread();
            }
            catch
            {
                TH.Abort();
                if (FilePath == "l" || FilePath == "s")
                    MessageBox.Show("数据恢复失败,请确保以下要求:1.\r\n如果您连接的为远程数据库,则[从服务器恢复数据]\r\n2.如果您连接的为本地数据库,则[从本地数据库恢复数据] 或 [从服务器恢复数据]并在本地拥有C:\\嘉源人事管理系统.bak");
                else
                    MessageBox.Show("数据恢复失败,远程服务器无法从本地初始化,请手动将 Restart.bak 在服务器端进行数据初始化");
            }
            finally
            {
                svr.DisConnect();
            }
        }
        #endregion
        
    }
}

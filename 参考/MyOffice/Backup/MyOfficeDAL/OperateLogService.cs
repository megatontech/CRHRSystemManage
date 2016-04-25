using System;
using System.Collections.Generic;
using System.Text;
using MyOffice.Models;
using System.Data.SqlClient;
using System.Data;

namespace MyOffice.DAL
{
    public static class OperateLogService
    {

        /// <summary>
        /// 查询所有的操作日志
        /// </summary>
        /// <returns>IList<OperateLog></returns>
        public static IList<OperateLog> GetOperateLogAll()
        {
            string sql = "SELECT * FROM VW_OperateLogAll";
            IList<OperateLog> list = new List<OperateLog>();
            using (SqlDataReader dr = DBHelper.ExecuteGetReader(CommandType.Text, sql, null))
            {
                while (dr.Read())
                {
                    OperateLog log = new OperateLog();
                    log.Id = (int)dr["Id"];
                    log.OperateName = dr["OperateName"].ToString();
                    log.OperateDesc = dr["OperateDesc"].ToString();
                    log.OperateTime = (DateTime)dr["OperateTime"];
                   
                    UserInfo user = new UserInfo();
                    user.Id = (int)dr["UserId"];
                    user.UserName = dr["UserName"].ToString();
                    log.User = user;
                    list.Add(log);
                }
            }
            return list;
        }
        /// <summary>
        /// 根据时间查询操作日志
        /// </summary>
        /// <param name="mix"></param>
        /// <param name="max"></param>
        /// <returns>IList<OperateLog></returns>
        public static IList<OperateLog> GetOperateLogByTime(DateTime mix, DateTime max)
        {
            string sql = "SELECT * FROM VW_OperateLogAll WHERE OperateTime between @mix AND @max ORDER BY OperateTime  DESC";
            SqlParameter[] para = new SqlParameter[] { 
                new SqlParameter("@mix",mix),
                new SqlParameter("@max",max)
            };
            IList<OperateLog> list = new List<OperateLog>();
            using (SqlDataReader dr = DBHelper.ExecuteGetReader(CommandType.Text, sql, para))
            {
                while (dr.Read())
                {
                    OperateLog log = new OperateLog();
                    log.Id = (int)dr["Id"];
                    log.OperateName = dr["OperateName"].ToString();
                    log.OperateDesc = dr["OperateDesc"].ToString();
                    log.OperateTime = (DateTime)dr["OperateTime"];

                    UserInfo user = new UserInfo();
                    user.Id = (int)dr["UserId"];
                    user.UserName = dr["UserName"].ToString();
                    log.User = user;
                    list.Add(log);
                }
            }
            return list;
        }
        /// <summary>
        /// 删除操作日志志根据id
        /// </summary>
        /// <param name="operateLogId"></param>
        /// <returns></returns>
        public static bool DeleteOperateLogById(int operateLogId)
        {
            SqlParameter[] para = new SqlParameter[] { 
                new SqlParameter("@Id",operateLogId)
            };
            int count = DBHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_DeleteOperateLogById", para);
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 添加操作日志
        /// </summary>
        /// <param name="log">OperateLog</param>
        /// <returns>bool</returns>
        public static bool AddOperateLog(OperateLog log)
        {

            SqlParameter[] para = new SqlParameter[] { 
                new SqlParameter("@UserId",log.User.Id),
                new SqlParameter("@OperateName",log.OperateName),
                new SqlParameter("@OperateDesc",log.OperateDesc),
                new SqlParameter("@OperateTime",DateTime.Now.ToString())
            
            };
            int count = DBHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_AddOperateLog", para);
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}




using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using MyOffice.Models;

namespace MyOffice.DAL
{
    public static class LoginLogService
    {
        /// <summary>
        /// 查询所有的登录日志
        /// </summary>
        /// <returns>IList<LoginLog></returns>
        public static IList<LoginLog> GetLoginLogAll()
        {
            string sql = "SELECT * FROM VW_LoginLogAll";
            IList<LoginLog> list = new List<LoginLog>();
            using (SqlDataReader dr = DBHelper.ExecuteGetReader(CommandType.Text, sql, null))
            {
                while (dr.Read())
                {
                    LoginLog log = new LoginLog();
                    log.Id = (int)dr["Id"];
                    log.IfSuccess = Convert.ToInt32(dr["IfSuccess"]);
                    log.LoginDesc = dr["LoginDesc"].ToString();
                    log.LoginTime = (DateTime)dr["LoginTime"];
                    log.LoginUserIp = dr["LoginUserIp"].ToString();
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
        /// 根据时间查询登陆日志
        /// </summary>
        /// <param name="mix"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static IList<LoginLog> GetLoginLogByTime(DateTime mix, DateTime max)
        {
            string sql = "SELECT * FROM VW_LoginLogAll WHERE LoginTime between @mix AND @max ORDER BY LoginTime  DESC";
            SqlParameter[] para = new SqlParameter[] { 
                new SqlParameter("@mix",mix),
                new SqlParameter("@max",max)
            };
            IList<LoginLog> list = new List<LoginLog>();
            using (SqlDataReader dr = DBHelper.ExecuteGetReader(CommandType.Text, sql, para))
            {
                while (dr.Read())
                {
                    LoginLog log = new LoginLog();
                    log.Id = (int)dr["Id"];
                    log.IfSuccess = Convert.ToInt32(dr["IfSuccess"]);
                    log.LoginDesc = dr["LoginDesc"].ToString();
                    log.LoginTime = (DateTime)dr["LoginTime"];
                    log.LoginUserIp = dr["LoginUserIp"].ToString();
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
        /// 删除登陆日志根据id
        /// </summary>
        /// <param name="loginLogId"></param>
        /// <returns></returns>
        public static bool DeleteLoginLogById(int loginLogId)
        {
            SqlParameter[] para = new SqlParameter[] { 
                new SqlParameter("@Id",loginLogId)
            };
            int count = DBHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_DeleteLoginLogById", para);
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
        /// 添加日志
        /// </summary>
        /// <param name="log">LoginLog</param>
        /// <returns>bool</returns>
        public static bool AddLoginLog(LoginLog log)
        {

            SqlParameter[] para = new SqlParameter[] { 
                new SqlParameter("@UserId",log.User.Id),
                new SqlParameter("@LoginTime",DateTime.Now.ToString()),
                new SqlParameter("@IfSuccess",log.IfSuccess),
                new SqlParameter("@LoginUserIp","127.0.0.1"),
                new SqlParameter("@LoginDesc",log.LoginDesc)
            };
            int count = DBHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_AddLoginLog", para);
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

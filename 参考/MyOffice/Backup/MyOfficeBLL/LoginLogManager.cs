using System;
using System.Collections.Generic;
using System.Text;
using MyOffice.Models;
using MyOffice.DAL;

namespace MyOffice.BLL
{
    public static class LoginLogManager
    {
        /// <summary>
        /// 查询所有的登录日志
        /// </summary>
        /// <returns>IList<LoginLog></returns>
        public static IList<LoginLog> GetLoginLogAll()
        {
            return LoginLogService.GetLoginLogAll();
        }
        /// <summary>
        /// 根据时间查询登陆日志
        /// </summary>
        /// <param name="mix"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static IList<LoginLog> GetLoginLogByTime(DateTime mix, DateTime max)
        {
            return LoginLogService.GetLoginLogByTime(mix,max);
        }
         /// <summary>
        /// 删除登陆日志根据id
        /// </summary>
        /// <param name="loginLogId"></param>
        /// <returns></returns>
        public static bool DeleteLoginLogById(int loginLogId)
        {
            return LoginLogService.DeleteLoginLogById(loginLogId);
        }
         /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="log">LoginLog</param>
        /// <returns>bool</returns>
        public static bool AddLoginLog(LoginLog log)
        {
            return LoginLogService.AddLoginLog(log);
        }
    }
}

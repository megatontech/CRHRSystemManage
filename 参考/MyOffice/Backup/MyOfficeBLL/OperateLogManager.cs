using System;
using System.Collections.Generic;
using System.Text;
using MyOffice.Models;
using MyOffice.DAL;

namespace MyOffice.BLL
{
    public static class OperateLogManager
    {
        /// <summary>
        /// 查询所有的操作日志
        /// </summary>
        /// <returns>IList<OperateLog></returns>
        public static IList<OperateLog> GetOperateLogAll()
        {
            return OperateLogService.GetOperateLogAll();
        }
         /// <summary>
        /// 根据时间查询操作日志
        /// </summary>
        /// <param name="mix"></param>
        /// <param name="max"></param>
        /// <returns>IList<OperateLog></returns>
        public static IList<OperateLog> GetOperateLogByTime(DateTime mix, DateTime max)
        {
            return OperateLogService.GetOperateLogByTime(mix, max);
        }
         /// <summary>
        /// 删除操作日志志根据id
        /// </summary>
        /// <param name="operateLogId"></param>
        /// <returns></returns>
        public static bool DeleteOperateLogById(int operateLogId)
        {
            return OperateLogService.DeleteOperateLogById(operateLogId);
        }
        /// <summary>
        /// 添加操作日志
        /// </summary>
        /// <param name="log">OperateLog</param>
        /// <returns>bool</returns>
        public static bool AddOperateLog(OperateLog log)
        {
            return OperateLogService.AddOperateLog(log);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using MyOffice.Models;
using MyOffice.DAL;

namespace MyOffice.BLL
{
    public static class ManualSignManager
    {
        /// <summary>
        ///根据用户Id和当前时间获得最大签到或签退信息
       /// </summary>
       /// <param name="userId"></param>
        /// <returns>ManualSign</returns>
        public static ManualSign GetMaxSignIdByUserId(int userId)
        {
            return ManualSignService.GetMaxSignIdByUserId(userId);
        }
         /// <summary>
        /// 添加考勤
        /// </summary>
        /// <param name="sign">ManualSign</param>
        /// <returns>bool</returns>
        public static bool AddManualSign(ManualSign sign)
        {
            return ManualSignService.AddManualSign(sign);
        }
       /// <summary>
        /// 得到所有的考勤信息
       /// </summary>
        /// <param name="mix">DateTime</param>
        /// <param name="max">DateTime</param>
        /// <returns>IList<ManualSign></returns>
        public static IList<ManualSign> GetAllManualSignBySignTime(DateTime mix, DateTime max) 
        {
            return ManualSignService.GetAllManualSignBySignTime( mix,  max) ;
        }
        /// <summary>
        /// 根据所需条件查询所有考勤历史记录
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="userName">姓名</param>
        /// <param name="departId">部门Ｉｄ</param>
        /// <param name="branchId">机构Ｉｄ</param>
        /// <returns>IList<ManualSign></returns>
        public static IList<ManualSign> GetManualSignsBySelectedConditions(DateTime startTime, DateTime endTime, string userName, int departId, int branchId)
        {
            return ManualSignService.GetManualSignsBySelectedConditions(startTime, endTime, userName, departId, branchId);
        }
         /// <summary>
        /// 得到用户在一段时间内的迟到次数
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="startTime">查询开始时间</param>
        /// <param name="endTime">查询结束时间</param>
        /// <returns>迟到次数</returns>
        public static int GetUserArriveLates(int userId, DateTime startTime, DateTime endTime)
        {
            return ManualSignService.GetUserArriveLates(userId, startTime,endTime);
        }
        /// <summary>
        /// 得到用户在一段时间内的早退次数
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="startTime">查询开始时间</param>
        /// <param name="endTime">查询结束时间</param>
        /// <returns>早退次数</returns>       
        public static int GetUserLeaveEarlys(int userId, DateTime startTime, DateTime endTime)
        {
            return ManualSignService.GetUserLeaveEarlys(userId, startTime, endTime);
        }
          /// <summary>
        /// 得到用户在一段时间内的旷工次数
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="startTime">查询开始时间</param>
        /// <param name="endTime">查询结束时间</param>
        /// <returns>旷工次数</returns>   
        public static int GetUserAbsences(int userId, DateTime startTime, DateTime endTime)
        {
            return ManualSignService.GetUserAbsences(userId, startTime, endTime);
        }
         /// <summary>
        /// 得到用户在一段时间内的出勤率
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="startTime">查询开始时间</param>
        /// <param name="endTime">查询结束时间</param>
        /// <returns>出勤率</returns>   
        public static string GetUserAttendances(int userId, DateTime startTime, DateTime endTime)
        {
            return ManualSignService.GetUserAttendances(userId, startTime, endTime);
        }
    }
}

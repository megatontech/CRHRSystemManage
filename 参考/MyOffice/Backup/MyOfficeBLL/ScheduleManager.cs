using System;
using System.Collections.Generic;
using System.Text;

using MyOffice.DAL;
using MyOffice.Models;

namespace MyOffice.BLL
{
    public static class ScheduleManager
    {
         /// <summary>
        /// 查询日程信息
        /// </summary>
        /// <returns></returns>
        public static IList<Schedule> GetSchedule()
        {
            return ScheduleService.GetSchedule();
        }

         /// <summary>
        /// 根据实体添加个人日程信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int AddSchedule(Schedule schedule)
        {
            return ScheduleService.AddSchedule(schedule);
        }

        /// <summary>
        /// 修改日程信息
        /// </summary>
        /// <param name="schedule"></param>
        /// <returns></returns>
        public static bool ModifySchedule(Schedule schedule)
        {
            return ScheduleService.ModifySchedule(schedule);
        }

        /// <summary>
        /// 根据用户ID和日期查找日程
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static IList<Schedule> GetScheduleByUserIdandDate(int userId, DateTime date)
        {
            return ScheduleService.GetScheduleByUserIdandDate(userId,date);
        }

        /// <summary>
        /// 根据Id查询日程
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Schedule GetScheduleById(int id)
        {
            return ScheduleService.GetScheduleById(id);
        }

         /// <summary>
        /// 根据日程ID删除日程信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeleteScheduleById(int id)
        {
            return ScheduleService.DeleteScheduleById(id);
        }
        /// <summary>
        /// 根据不同的条件查询部门日程
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="userName">姓名</param>
        /// <param name="departId">部门Id</param>
        /// <param name="branchId">机构Id</param>
        /// <returns>IList<Schedule></returns>
        public static IList<Schedule> GetScheduleBySelectedConditions(DateTime startTime, DateTime endTime, string userName, int departId, int branchId)
        {
            return ScheduleService.GetScheduleBySelectedConditions(startTime,endTime, userName, departId, branchId);
        }
        /// <summary>
        /// 通过用户Id 创建时间查询一条日程信息
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="createTime">创建时间</param>
        /// <returns>int</returns>
        public static int GetScheduleId(int userId, DateTime createTime)
        {
            return ScheduleService.GetScheduleId(userId, createTime);
        }

        /// <summary>
        /// 判断预约人是否有时间
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool GetScheduleByPreContract(DateTime beginTime, DateTime endTime, int createUserId)
        {
            return ScheduleService.GetScheduleByPreContract(beginTime, endTime, createUserId);
        }

        /// <summary>
        /// 查询自己是否有预约
        /// </summary>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <param name="createUserId"></param>
        /// <returns></returns>
        public static bool GetSchedulebyDateTime(DateTime beginTime, DateTime endTime, int createUserId)
        {
            return ScheduleService.GetSchedulebyDateTime(beginTime, endTime, createUserId);
        }
    }
}

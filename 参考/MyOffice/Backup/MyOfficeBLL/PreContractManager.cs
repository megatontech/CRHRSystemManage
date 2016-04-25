using System;
using System.Collections.Generic;
using System.Text;
using MyOffice.Models;
using MyOffice.DAL;

namespace MyOffice.BLL
{
    public static class PreContractManager
    {
         /// <summary>
        /// 查看所有预约
        /// </summary>
        /// <returns></returns>
        public static IList<PreContract> GetPreContract()
        {
            return PreContractService.GetPreContract();
        }

        /// <summary>
        /// 根据ID删除预约人
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeletePreContract(int id)
        {
            return PreContractService.DeletePreContract(id);
        }
         /// <summary>
        /// 根据ID和用户Id删除预约人
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeletePreContractByIdAndUserId(PreContract pre)
        {
            return PreContractService.DeletePreContractByIdAndUserId(pre);
        }
        /// <summary>
        /// 修改预约人
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static bool UpdatePreContractById(PreContract pre)
        {
            return PreContractService.UpdatePreContractById(pre);
        }

        /// <summary>
        ///添加【预约人】 
        /// </summary>
        /// <param name="preContract"></param>
        /// <returns></returns>
        public static bool AddPreContract(PreContract preContract)
        {
            return PreContractService.AddPreContract(preContract);
        }

        /// <summary>
        /// 根据日程ＩＤ查找预约人
        /// </summary>
        /// <param name="scheduleIdId"></param>
        /// <returns></returns>
        public static IList<PreContract> GetPreContractByScheduleID(int scheduleId)
        {
            return PreContractService.GetPreContractByScheduleID(scheduleId);
        }
        /// <summary>
        /// 得到预约人氏自己的信息
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public static IList<PreContract> GetPreContractByUserIdandDate(int userId, DateTime date)
        {
            return PreContractService.GetPreContractByUserIdandDate(userId, date);
        }

        /// <summary>
        /// 根据用户ID和日程ID查询预约人
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="ScheduleId"></param>
        /// <returns></returns>
        public static bool GetPreContractByUserandSchedule(int UserId, int ScheduleId)
        {
            return PreContractService.GetPreContractByUserandSchedule(UserId, ScheduleId);
        }

        /// <summary>
        /// 根据日程ID和用户ID查询被预约的日程信息
        /// </summary>
        /// <param name="pre"></param>
        /// <returns></returns>
        public static IList<PreContract> SelectPrecontract(int userId, DateTime date)
        {
            return PreContractService.SelectPrecontract(userId, date);
        }
    }
}

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
        /// ��ѯ�ճ���Ϣ
        /// </summary>
        /// <returns></returns>
        public static IList<Schedule> GetSchedule()
        {
            return ScheduleService.GetSchedule();
        }

         /// <summary>
        /// ����ʵ����Ӹ����ճ���Ϣ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int AddSchedule(Schedule schedule)
        {
            return ScheduleService.AddSchedule(schedule);
        }

        /// <summary>
        /// �޸��ճ���Ϣ
        /// </summary>
        /// <param name="schedule"></param>
        /// <returns></returns>
        public static bool ModifySchedule(Schedule schedule)
        {
            return ScheduleService.ModifySchedule(schedule);
        }

        /// <summary>
        /// �����û�ID�����ڲ����ճ�
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static IList<Schedule> GetScheduleByUserIdandDate(int userId, DateTime date)
        {
            return ScheduleService.GetScheduleByUserIdandDate(userId,date);
        }

        /// <summary>
        /// ����Id��ѯ�ճ�
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Schedule GetScheduleById(int id)
        {
            return ScheduleService.GetScheduleById(id);
        }

         /// <summary>
        /// �����ճ�IDɾ���ճ���Ϣ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeleteScheduleById(int id)
        {
            return ScheduleService.DeleteScheduleById(id);
        }
        /// <summary>
        /// ���ݲ�ͬ��������ѯ�����ճ�
        /// </summary>
        /// <param name="startTime">��ʼʱ��</param>
        /// <param name="endTime">����ʱ��</param>
        /// <param name="userName">����</param>
        /// <param name="departId">����Id</param>
        /// <param name="branchId">����Id</param>
        /// <returns>IList<Schedule></returns>
        public static IList<Schedule> GetScheduleBySelectedConditions(DateTime startTime, DateTime endTime, string userName, int departId, int branchId)
        {
            return ScheduleService.GetScheduleBySelectedConditions(startTime,endTime, userName, departId, branchId);
        }
        /// <summary>
        /// ͨ���û�Id ����ʱ���ѯһ���ճ���Ϣ
        /// </summary>
        /// <param name="userId">�û�ID</param>
        /// <param name="createTime">����ʱ��</param>
        /// <returns>int</returns>
        public static int GetScheduleId(int userId, DateTime createTime)
        {
            return ScheduleService.GetScheduleId(userId, createTime);
        }

        /// <summary>
        /// �ж�ԤԼ���Ƿ���ʱ��
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool GetScheduleByPreContract(DateTime beginTime, DateTime endTime, int createUserId)
        {
            return ScheduleService.GetScheduleByPreContract(beginTime, endTime, createUserId);
        }

        /// <summary>
        /// ��ѯ�Լ��Ƿ���ԤԼ
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

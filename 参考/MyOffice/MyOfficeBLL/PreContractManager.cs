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
        /// �鿴����ԤԼ
        /// </summary>
        /// <returns></returns>
        public static IList<PreContract> GetPreContract()
        {
            return PreContractService.GetPreContract();
        }

        /// <summary>
        /// ����IDɾ��ԤԼ��
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeletePreContract(int id)
        {
            return PreContractService.DeletePreContract(id);
        }
         /// <summary>
        /// ����ID���û�Idɾ��ԤԼ��
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeletePreContractByIdAndUserId(PreContract pre)
        {
            return PreContractService.DeletePreContractByIdAndUserId(pre);
        }
        /// <summary>
        /// �޸�ԤԼ��
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static bool UpdatePreContractById(PreContract pre)
        {
            return PreContractService.UpdatePreContractById(pre);
        }

        /// <summary>
        ///��ӡ�ԤԼ�ˡ� 
        /// </summary>
        /// <param name="preContract"></param>
        /// <returns></returns>
        public static bool AddPreContract(PreContract preContract)
        {
            return PreContractService.AddPreContract(preContract);
        }

        /// <summary>
        /// �����ճ̣ɣĲ���ԤԼ��
        /// </summary>
        /// <param name="scheduleIdId"></param>
        /// <returns></returns>
        public static IList<PreContract> GetPreContractByScheduleID(int scheduleId)
        {
            return PreContractService.GetPreContractByScheduleID(scheduleId);
        }
        /// <summary>
        /// �õ�ԤԼ�����Լ�����Ϣ
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public static IList<PreContract> GetPreContractByUserIdandDate(int userId, DateTime date)
        {
            return PreContractService.GetPreContractByUserIdandDate(userId, date);
        }

        /// <summary>
        /// �����û�ID���ճ�ID��ѯԤԼ��
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="ScheduleId"></param>
        /// <returns></returns>
        public static bool GetPreContractByUserandSchedule(int UserId, int ScheduleId)
        {
            return PreContractService.GetPreContractByUserandSchedule(UserId, ScheduleId);
        }

        /// <summary>
        /// �����ճ�ID���û�ID��ѯ��ԤԼ���ճ���Ϣ
        /// </summary>
        /// <param name="pre"></param>
        /// <returns></returns>
        public static IList<PreContract> SelectPrecontract(int userId, DateTime date)
        {
            return PreContractService.SelectPrecontract(userId, date);
        }
    }
}

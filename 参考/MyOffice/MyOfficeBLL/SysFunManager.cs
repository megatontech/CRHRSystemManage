using System;
using System.Collections.Generic;
using System.Text;
using MyOffice.DAL;
using MyOffice.Models;
using System.Data;

namespace MyOffice.BLL
{
    public static class SysFunManager
    {
        /// <summary>
        /// ���ݵ�¼�û��õ���һ���ڵ���Ϣ
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static IList<SysFun> GetAllParentNodeInfoByUserId(UserInfo user)
        {
           return  SysFunService.GetAllParentNodeInfoByUserId(user);
        }
         /// <summary>
        ///  ���ݵ�¼�û��͸����ڵ�õ��ڶ����ڵ���Ϣ
        /// </summary>
        /// <param name="user"></param>
        /// <param name="parentNodeId"></param>
        /// <returns>IList<SysFun></returns>
        public static IList<SysFun> GetSysFunByParentNodeIdAndUserId(UserInfo user, int parentNodeId)
        {
            return SysFunService.GetSysFunByParentNodeIdAndUserId(user, parentNodeId);
        }
         /// <summary>
        /// �õ���һ���ڵ���Ϣ
        /// </summary>
        /// <returns>IList<SysFun></returns>
        public static IList<SysFun> GetAllParentNodeInfo()
        {
            return SysFunService.GetAllParentNodeInfo();
        }
        /// <summary>
        /// ���ݸ����ڵ�õ��ڶ����ڵ���Ϣ
        /// </summary>
        /// <param name="parentNodeId">int</param>
        /// <returns>IList<SysFun></returns>
        public static IList<SysFun> GetSysFunByParentNodeId(int parentNodeId)
        {
            return SysFunService.GetSysFunByParentNodeId(parentNodeId);
        }
        /// <summary>
        /// ����Id��ѯ�˵�
        /// </summary>
        /// <param name="nodeId"></param>
        /// <returns>SysFun</returns>
        public static SysFun GetSysFunById(int nodeId)
        {
            return SysFunService.GetSysFunById(nodeId);
        }
        /// <summary>
        /// �õ���ǰ�ڵ��ǰһ���ڵ㣨��DisplayOrderΪ����˳��
        /// </summary>
        /// <param name="displayOrder">int</param>
        /// <param name="parentNodeId">int</param>
        /// <returns>SysFun</returns>
        public static SysFun GetUpNodeByCurrentNodeId(int displayOrder, int parentNodeId)
        {
            return SysFunService.GetUpNodeByCurrentNodeId(displayOrder, parentNodeId);
        }
         /// <summary>
        /// �õ���ǰ�ڵ������һ���ڵ㣨��DisplayOrderΪ����˳��
        /// </summary>
        /// <param name="displayOrder">int</param>
        /// <param name="parentNodeId">int</param>
        /// <returns>SysFun</returns>
        public static SysFun GetDownNodeByCurrentNodeId(int displayOrder, int parentNodeId)
        {
            return SysFunService.GetDownNodeByCurrentNodeId(displayOrder, parentNodeId);
        }
         /// <summary>
        /// ����Id�޸Ĳ˵�Order
       /// </summary>
       /// <param name="nodeId"></param>
       /// <param name="updateOrder"></param>
       /// <param name="parentNodeId"></param>
        /// <returns>bool</returns>
        public static bool ModifySysFunOrderByNodeId(int nodeId, int displayOrder)
        {
            return SysFunService.ModifySysFunOrderByNodeId(nodeId, displayOrder);
        }

    }
}

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
        /// 根据登录用户得到第一级节点信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static IList<SysFun> GetAllParentNodeInfoByUserId(UserInfo user)
        {
           return  SysFunService.GetAllParentNodeInfoByUserId(user);
        }
         /// <summary>
        ///  根据登录用户和父级节点得到第二级节点信息
        /// </summary>
        /// <param name="user"></param>
        /// <param name="parentNodeId"></param>
        /// <returns>IList<SysFun></returns>
        public static IList<SysFun> GetSysFunByParentNodeIdAndUserId(UserInfo user, int parentNodeId)
        {
            return SysFunService.GetSysFunByParentNodeIdAndUserId(user, parentNodeId);
        }
         /// <summary>
        /// 得到第一级节点信息
        /// </summary>
        /// <returns>IList<SysFun></returns>
        public static IList<SysFun> GetAllParentNodeInfo()
        {
            return SysFunService.GetAllParentNodeInfo();
        }
        /// <summary>
        /// 根据父级节点得到第二级节点信息
        /// </summary>
        /// <param name="parentNodeId">int</param>
        /// <returns>IList<SysFun></returns>
        public static IList<SysFun> GetSysFunByParentNodeId(int parentNodeId)
        {
            return SysFunService.GetSysFunByParentNodeId(parentNodeId);
        }
        /// <summary>
        /// 根据Id查询菜单
        /// </summary>
        /// <param name="nodeId"></param>
        /// <returns>SysFun</returns>
        public static SysFun GetSysFunById(int nodeId)
        {
            return SysFunService.GetSysFunById(nodeId);
        }
        /// <summary>
        /// 得到当前节点的前一个节点（以DisplayOrder为排列顺序）
        /// </summary>
        /// <param name="displayOrder">int</param>
        /// <param name="parentNodeId">int</param>
        /// <returns>SysFun</returns>
        public static SysFun GetUpNodeByCurrentNodeId(int displayOrder, int parentNodeId)
        {
            return SysFunService.GetUpNodeByCurrentNodeId(displayOrder, parentNodeId);
        }
         /// <summary>
        /// 得到当前节点的下面一个节点（以DisplayOrder为排列顺序）
        /// </summary>
        /// <param name="displayOrder">int</param>
        /// <param name="parentNodeId">int</param>
        /// <returns>SysFun</returns>
        public static SysFun GetDownNodeByCurrentNodeId(int displayOrder, int parentNodeId)
        {
            return SysFunService.GetDownNodeByCurrentNodeId(displayOrder, parentNodeId);
        }
         /// <summary>
        /// 根据Id修改菜单Order
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

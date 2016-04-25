using System;
using System.Collections.Generic;
using System.Text;
using MyOffice.DAL;
using MyOffice.Models;

namespace MyOffice.BLL
{
    public static class RoleRightManager
    {
         /// <summary>
        ///  根据父级节点和角色Id得到第二级节点信息
        /// </summary>
        /// <param name="user"></param>
        /// <param name="parentNodeId"></param>
        /// <returns>IList<SysFun></returns>
        public static IList<RoleRight> GetRoleRightByParentNodeIdAndRoleId(int parentNodeId, int RoleId)
        {
            return RoleRightService.GetRoleRightByParentNodeIdAndRoleId(parentNodeId, RoleId);
        }
         /// <summary>
        ///  根据角色Id得到所有节点信息
        /// </summary>       
        /// <param name="parentNodeId"></param>
        /// <returns>IList<SysFun></returns>
        public static IList<RoleRight> GetRoleRightByRoleId(int RoleId)
        {
            return RoleRightService.GetRoleRightByRoleId(RoleId);
        }
        /// <summary>
        /// 添加权限
       /// </summary>
       /// <param name="roleId">角色Id</param>
       /// <param name="nodeId">节点Id</param>
        /// <returns>bool</returns>
        public static bool AddRoleRight(int roleId, int nodeId)
        {
            return RoleRightService.AddRoleRight(roleId,nodeId);
        }
        /// <summary>
        /// 删除权限权限
        /// </summary>
        /// <param name="roleId">角色Id</param>
        /// <param name="nodeId">节点Id</param>
        /// <returns>bool</returns>
        public static bool DeleteRoleRightByRoleIdAndNodeId(int roleId, int nodeId)
        {
            return RoleRightService.DeleteRoleRightByRoleIdAndNodeId(roleId, nodeId);
        }
         /// <summary>
        /// 删除权限权限(根据角色Id)
        /// </summary>
        /// <param name="roleId">角色Id</param>     
        /// <returns>bool</returns>
        public static bool DeleteRoleRightByRoleId(int roleId)
        {
            return RoleRightService.DeleteRoleRightByRoleId(roleId);
        }
    }
}

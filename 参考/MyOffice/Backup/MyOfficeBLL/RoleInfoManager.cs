using System;
using System.Collections.Generic;
using System.Text;
using MyOffice.Models;
using MyOffice.DAL;

namespace MyOffice.BLL
{
    public static class RoleInfoManager
    {
        /// <summary>
        /// 查询所有角色
        /// </summary>
        /// <returns>IList<RoleInfo></returns>
        public static IList<RoleInfo> GetRoleInfoAll()
        {
            return RoleInfoService.GetRoleInfoAll();
        }
         /// <summary>
        /// 通过角色ID查询角色
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns>RoleInfo</returns>
        public static RoleInfo GetRoleInfoById(int roleId)
        {
            return RoleInfoService.GetRoleInfoById(roleId);
        }
        /// <summary>
        /// 删除角色根据id
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public static bool DeleteRoleInfoById(int roleId)
        {
            return RoleInfoService.DeleteRoleInfoById(roleId);
        }
         /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="roleInfo"></param>
        /// <returns></returns>
        public static bool AddRoleInfo(RoleInfo roleInfo)
        {
            return RoleInfoService.AddRoleInfo(roleInfo);
        }
         /// <summary>
        /// 修改角色信息
        /// </summary>
        /// <param name="roleInfo"></param>
        /// <returns></returns>
        public static bool UpdateRoleInfo(RoleInfo roleInfo)
        {
            return RoleInfoService.UpdateRoleInfo(roleInfo);
        }
    }
}

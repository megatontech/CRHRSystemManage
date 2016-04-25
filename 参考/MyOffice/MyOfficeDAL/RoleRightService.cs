using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MyOffice.Models;

namespace MyOffice.DAL
{
    public static class RoleRightService
    {
        /// <summary>
        ///  根据父级节点和角色Id得到第二级节点信息
        /// </summary>
        /// <param name="user"></param>
        /// <param name="parentNodeId"></param>
        /// <returns>IList<SysFun></returns>
        public static IList<RoleRight> GetRoleRightByParentNodeIdAndRoleId(int parentNodeId, int RoleId)
        {
            string sql = "SELECT * FROM VW_RoleRightInfo WHERE ParentNodeId=@ParentNodeId AND RoleId=@RoleId";
            IList<RoleRight> list = new List<RoleRight>();
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@ParentNodeId",parentNodeId),
                 new SqlParameter("@RoleId",RoleId)
                   
            };
            using (SqlDataReader dr = DBHelper.ExecuteGetReader(CommandType.Text, sql, para))
            {
                while (dr.Read())
                {
                    RoleRight roleRight = new RoleRight();
                    roleRight.Id = (int)dr["NodeId"];
                    SysFun sysFun = new SysFun();
                    sysFun.NodeId = (int)dr["NodeId"];
                    sysFun.DisplayName = dr["DisplayName"].ToString();
                    sysFun.DisplayOrder = (int)dr["DisplayOrder"];
                    sysFun.NodeURL = dr["NodeURL"].ToString();
                    sysFun.ParentNodeId = (int)dr["ParentNodeId"];

                    roleRight.Node = sysFun;
                    RoleInfo role = new RoleInfo();
                    role.Id = (int)dr["RoleId"];
                    role.RoleName = dr["RoleName"].ToString();
                    roleRight.Role = role;
                    list.Add(roleRight);
                }
            }
            return list;
        }
        /// <summary>
        ///  根据角色Id得到所有节点信息
        /// </summary>       
        /// <param name="parentNodeId"></param>
        /// <returns>IList<SysFun></returns>
        public static IList<RoleRight> GetRoleRightByRoleId(int RoleId)
        {
            string sql = "SELECT * FROM VW_RoleRightAll WHERE  RoleId=@RoleId";
            IList<RoleRight> list = new List<RoleRight>();
            SqlParameter[] para = new SqlParameter[]
            {
                 new SqlParameter("@RoleId",RoleId)
            };
            using (SqlDataReader dr = DBHelper.ExecuteGetReader(CommandType.Text, sql, para))
            {
                while (dr.Read())
                {
                    RoleRight roleRight = new RoleRight();
                    roleRight.Id = (int)dr["Id"];
                    SysFun sysFun = new SysFun();
                    sysFun.NodeId = (int)dr["NodeId"];
                    sysFun.DisplayName = dr["NodeName"].ToString();                   

                    roleRight.Node = sysFun;
                    RoleInfo role = new RoleInfo();
                    role.Id = (int)dr["RoleId"];
                    role.RoleName = dr["RoleName"].ToString();
                    roleRight.Role = role;
                    list.Add(roleRight);
                }
            }
            return list;
        }
       /// <summary>
        /// 添加权限
       /// </summary>
       /// <param name="roleId">角色Id</param>
       /// <param name="nodeId">节点Id</param>
        /// <returns>bool</returns>
        public static bool AddRoleRight(int roleId , int nodeId)
        {

            SqlParameter[] para = new SqlParameter[] { 
                new SqlParameter("@RoleId",roleId),
                new SqlParameter("@NodeId",nodeId)
            };
            int count = DBHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_AddRoleRight", para);
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 删除权限权限
        /// </summary>
        /// <param name="roleId">角色Id</param>
        /// <param name="nodeId">节点Id</param>
        /// <returns>bool</returns>
        public static bool DeleteRoleRightByRoleIdAndNodeId(int roleId, int nodeId)
        {

            SqlParameter[] para = new SqlParameter[] { 
                new SqlParameter("@RoleId",roleId),
                new SqlParameter("@NodeId",nodeId)
            };
            int count = DBHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_DeleteRoleRight", para);
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 删除权限权限(根据角色Id)
        /// </summary>
        /// <param name="roleId">角色Id</param>     
        /// <returns>bool</returns>
        public static bool DeleteRoleRightByRoleId(int roleId)
        {

            SqlParameter[] para = new SqlParameter[] { 
                new SqlParameter("@RoleId",roleId)
            };
            int count = DBHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_DeleteRoleRightByRoleId", para);
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

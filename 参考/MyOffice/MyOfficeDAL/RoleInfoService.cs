using System;
using System.Collections.Generic;
using System.Text;
using MyOffice.Models;
using System.Data.SqlClient;
using System.Data;

namespace MyOffice.DAL
{
    public static class RoleInfoService
    {
        /// <summary>
        /// 查询所有角色
        /// </summary>
        /// <returns>IList<RoleInfo></returns>
        public static IList<RoleInfo> GetRoleInfoAll()
        {
            string sql = "SELECT * FROM VW_RoleInfoAll";
            IList<RoleInfo> list = new List<RoleInfo>();
            using (SqlDataReader dr = DBHelper.ExecuteGetReader(CommandType.Text, sql, null))
            {
                while (dr.Read())
                {
                    RoleInfo roleInfo = new RoleInfo();
                    roleInfo.Id = (int)dr["Id"];
                    roleInfo.RoleName = dr["RoleName"].ToString();
                    roleInfo.RoleDesc = dr["RoleDesc"].ToString();
                    list.Add(roleInfo);
                }
            }
            return list;
        }
        /// <summary>
        /// 通过角色ID查询角色
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns>RoleInfo</returns>
        public static RoleInfo GetRoleInfoById(int roleId)
        {
            string sql = "select * from VW_RoleInfoAll where Id=@Id";
            SqlParameter[] para = new SqlParameter[] { 
                new SqlParameter("@Id",roleId)
            };
            RoleInfo roleInfo = new RoleInfo();
            using (SqlDataReader dr = DBHelper.ExecuteGetReader(CommandType.Text, sql, para))
            {
                if (dr.Read())
                {
                    roleInfo.Id = (int)dr["Id"];
                    roleInfo.RoleName = dr["RoleName"].ToString();
                    roleInfo.RoleDesc = dr["RoleDesc"].ToString();
                }
            }
            return roleInfo;        
        }
        /// <summary>
        /// 删除角色根据id
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public static bool DeleteRoleInfoById(int roleId)
        {
            SqlParameter[] para = new SqlParameter[] { 
                new SqlParameter("@Id",roleId)
            };
            int count = DBHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_DeleteRoleInfoById", para);
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
        /// 添加角色
        /// </summary>
        /// <param name="roleInfo"></param>
        /// <returns></returns>
        public static bool AddRoleInfo(RoleInfo roleInfo)
        {

            SqlParameter[] para = new SqlParameter[] { 
                new SqlParameter("@RoleName",roleInfo.RoleName),
                new SqlParameter("@RoleDesc",roleInfo.RoleDesc)
            };
            int count = DBHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_AddRoleInfo", para);
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
        /// 修改角色信息
        /// </summary>
        /// <param name="roleInfo"></param>
        /// <returns></returns>
        public static bool UpdateRoleInfo(RoleInfo roleInfo)
        {
            SqlParameter[] para = new SqlParameter[] {
                new SqlParameter("@Id",roleInfo.Id),
                new SqlParameter("@RoleName",roleInfo.RoleName),
                new SqlParameter("@RoleDesc",roleInfo.RoleDesc)
            };
            int count = DBHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_ModifyRoleInfoById", para);
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

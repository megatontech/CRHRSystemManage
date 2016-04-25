using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using MyOffice.Models;

namespace MyOffice.DAL
{
    public static class SysFunService
    {
        /// <summary>
        /// 根据登录用户得到第一级节点信息
        /// </summary>
        /// <param name="user">UserInfo</param>
        /// <returns>IList<SysFun></returns>
        public static IList<SysFun> GetAllParentNodeInfoByUserId(UserInfo user)
        {
            string sql = "SELECT * FROM VW_RoleRightInfo WHERE ParentNodeId='0' AND RoleId=@RoleId ORDER BY DisplayOrder";
            IList<SysFun> list = new List<SysFun>();
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@RoleId",user.Role.Id)                       
            };
            using (SqlDataReader dr = DBHelper.ExecuteGetReader(CommandType.Text, sql, para))
            {
                while (dr.Read())
                {
                    SysFun sysFun = new SysFun();
                    sysFun.NodeId = (int)dr["NodeId"];
                    sysFun.DisplayName = dr["DisplayName"].ToString();
                    sysFun.DisplayOrder = (int)dr["DisplayOrder"];
                    sysFun.NodeURL = dr["NodeURL"].ToString();
                    sysFun.ParentNodeId = (int)dr["ParentNodeId"];
                    list.Add(sysFun);
                }
            }
            return list;
        }
        /// <summary>
        ///  根据登录用户和父级节点得到第二级节点信息
        /// </summary>
        /// <param name="user">UserInfo</param>
        /// <param name="parentNodeId">int</param>
        /// <returns>IList<SysFun></returns>
        public static IList<SysFun> GetSysFunByParentNodeIdAndUserId(UserInfo user, int parentNodeId)
        {
            string sql = "SELECT * FROM VW_RoleRightInfo WHERE ParentNodeId=@ParentNodeId AND RoleId=@RoleId ORDER BY DisplayOrder";
            IList<SysFun> list = new List<SysFun>();
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@ParentNodeId",parentNodeId),  
                new SqlParameter("@RoleId",user.Role.Id)           
            };
            using (SqlDataReader dr = DBHelper.ExecuteGetReader(CommandType.Text, sql, para))
            {
                while (dr.Read())
                {
                    SysFun sysFun = new SysFun();
                    sysFun.NodeId = (int)dr["NodeId"];
                    sysFun.DisplayName = dr["DisplayName"].ToString();
                    sysFun.DisplayOrder = (int)dr["DisplayOrder"];
                    sysFun.NodeURL = dr["NodeURL"].ToString();
                    sysFun.ParentNodeId = (int)dr["ParentNodeId"];
                    list.Add(sysFun);
                }
            }
            return list;
        }
        /// <summary>
        /// 得到第一级节点信息
        /// </summary>
        /// <returns>IList<SysFun></returns>
        public static IList<SysFun> GetAllParentNodeInfo()
        {
            string sql = "SELECT * FROM VW_SysFunAll WHERE ParentNodeId='0'ORDER BY DisplayOrder";
            IList<SysFun> list = new List<SysFun>();
            using (SqlDataReader dr = DBHelper.ExecuteGetReader(CommandType.Text, sql, null))
            {
                while (dr.Read())
                {
                    SysFun sysFun = new SysFun();
                    sysFun.NodeId = (int)dr["NodeId"];
                    sysFun.DisplayName = dr["DisplayName"].ToString();
                    sysFun.DisplayOrder = (int)dr["DisplayOrder"];
                    sysFun.NodeURL = dr["NodeURL"].ToString();
                    sysFun.ParentNodeId = (int)dr["ParentNodeId"];
                    list.Add(sysFun);
                }
            }
            return list;
        }
       /// <summary>
        ///  根据父级节点得到第二级节点信息
       /// </summary>
       /// <param name="parentNodeId"></param>
       /// <returns></returns>
        public static IList<SysFun> GetSysFunByParentNodeId(int parentNodeId)
        {
            string sql = "SELECT * FROM VW_SysFunAll WHERE ParentNodeId=@ParentNodeId ORDER BY DisplayOrder";
            IList<SysFun> list = new List<SysFun>();
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@ParentNodeId",parentNodeId)
                   
            };
            using (SqlDataReader dr = DBHelper.ExecuteGetReader(CommandType.Text, sql, para))
            {
                while (dr.Read())
                {
                    SysFun sysFun = new SysFun();
                    sysFun.NodeId = (int)dr["NodeId"];
                    sysFun.DisplayName = dr["DisplayName"].ToString();
                    sysFun.DisplayOrder = (int)dr["DisplayOrder"];
                    sysFun.NodeURL = dr["NodeURL"].ToString();
                    sysFun.ParentNodeId = (int)dr["ParentNodeId"];
                    list.Add(sysFun);
                }
            }
            return list;
        }
        /// <summary>
        /// 根据Id查询菜单
        /// </summary>
        /// <param name="nodeId"></param>
        /// <returns>SysFun</returns>
        public static SysFun GetSysFunById(int nodeId)
        {
            string sql = "SELECT * FROM  VW_SysFunAll WHERE NodeId=@NodeId ORDER BY DisplayOrder";
            SqlParameter[] para = new SqlParameter[] { 
                new SqlParameter("@NodeId",nodeId)
            };
            using (SqlDataReader dr = DBHelper.ExecuteGetReader(CommandType.Text, sql, para))
            {
                if (dr.Read())
                {
                    SysFun sysFun = new SysFun();
                    sysFun.NodeId = (int)dr["NodeId"];
                    sysFun.DisplayName = dr["DisplayName"].ToString();
                    sysFun.DisplayOrder = (int)dr["DisplayOrder"];
                    sysFun.NodeURL = dr["NodeURL"].ToString();
                    sysFun.ParentNodeId = (int)dr["ParentNodeId"];
                    return sysFun;
                }
                else
                {
                    return null;
                }
            }
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

            SqlParameter[] para = new SqlParameter[] { 
                new SqlParameter("@NodeId",nodeId),
                new SqlParameter("@DisplayOrder",displayOrder)
               
            };
            int count = DBHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_ModifySysFunOrderByNodeId", para);
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
        /// 得到当前节点的前一个节点（以DisplayOrder为排列顺序）
        /// </summary>
        /// <param name="displayOrder">int</param>
        /// <param name="parentNodeId">int</param>
        /// <returns>SysFun</returns>
        public static SysFun GetUpNodeByCurrentNodeId(int displayOrder, int parentNodeId)
        {
            string sql = "select  top 1 * from VW_SysFunAll where  DisplayOrder < " + displayOrder + " and ParentNodeId=" + parentNodeId + " ORDER BY DisplayOrder  DESC ";

            using (SqlDataReader dr = DBHelper.ExecuteGetReader(CommandType.Text, sql, null))
            {
                if (dr.Read())
                {
                    SysFun sysFun = new SysFun();
                    sysFun.NodeId = (int)dr["NodeId"];
                    sysFun.DisplayName = dr["DisplayName"].ToString();
                    sysFun.DisplayOrder = (int)dr["DisplayOrder"];
                    sysFun.NodeURL = dr["NodeURL"].ToString();
                    sysFun.ParentNodeId = (int)dr["ParentNodeId"];
                    return sysFun;
                }
                return null;

            }
        }
        /// <summary>
        /// 得到当前节点的下面一个节点（以DisplayOrder为排列顺序）
        /// </summary>
        /// <param name="displayOrder">int</param>
        /// <param name="parentNodeId">int</param>
        /// <returns>SysFun</returns>
        public static SysFun GetDownNodeByCurrentNodeId(int displayOrder, int parentNodeId)
        {
            string sql = "SELECT  TOP 1  * FROM  VW_SysFunAll WHERE  DisplayOrder > " + displayOrder + " AND ParentNodeId=" + parentNodeId + "  ORDER BY DisplayOrder  ";

            using (SqlDataReader dr = DBHelper.ExecuteGetReader(CommandType.Text, sql, null))
            {
                if (dr.Read())
                {
                    SysFun sysFun = new SysFun();
                    sysFun.NodeId = (int)dr["NodeId"];
                    sysFun.DisplayName = dr["DisplayName"].ToString();
                    sysFun.DisplayOrder = (int)dr["DisplayOrder"];
                    sysFun.NodeURL = dr["NodeURL"].ToString();
                    sysFun.ParentNodeId = (int)dr["ParentNodeId"];
                    return sysFun;
                }
                return null;

            }
        }

    }
}

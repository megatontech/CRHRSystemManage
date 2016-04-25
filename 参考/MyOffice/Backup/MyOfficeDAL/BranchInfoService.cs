using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using MyOffice.Models;

namespace MyOffice.DAL
{
    public static class BranchInfoService
    {
        /// <summary>
        /// 检查机构是否存在
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool CheckBranch(BranchInfo branchInfo)
        {
            string sql = "SELECT  * FROM VW_BranchInfoAll WHERE BranchName=@BranchName ";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@BranchName",branchInfo.BranchName),
                new SqlParameter("@BranchShortName",branchInfo.BranchShortName)
            };
            DataTable temp = DBHelper.ExecuteGetDataTable(CommandType.Text, sql, para);
            if (temp.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 添加机构
        /// </summary>
        /// <param name="branchInfo"></param>
        /// <returns></returns>
        public static bool AddBranch(BranchInfo branchInfo)
        {
            SqlParameter[] para = new SqlParameter[] 
            {
                new SqlParameter("@BranchName",branchInfo.BranchName),
                new SqlParameter("@BranchShortName",branchInfo.BranchShortName)
            };
            int i = DBHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_AddBranch", para);
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        ///<summary>
        ///删除机构
        ///</summary>
        ///<param name="branchInfo"></param>
        ///<returns></returns>
        public static bool DeleteBranchById(int branchid)
        {
            SqlParameter[] para = new SqlParameter[] 
            {
                new SqlParameter("@BranchById",branchid)
            };
            int i = DBHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_DeleteBranchById", para);
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 根据id修改机构
        /// </summary>
        /// <param name="Branch"></param>
        /// <returns></returns>
        public static bool ModifyBranchById(BranchInfo branch)
        {
            SqlParameter[] para = new SqlParameter[] 
            {
                new SqlParameter("@Id",branch.Id),
                new SqlParameter("@BranchName",branch.BranchName),
                new SqlParameter("@BranchShortName",branch.BranchShortName)
            };
            int i = DBHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_ModifyBranchById", para);
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        ///得到机构
        /// </summary>
        /// <returns></returns>
        public static IList<BranchInfo> GetBranchInfo()
        {
            string sql = "select * from BranchInfo";
            IList<BranchInfo> list = new List<BranchInfo>();
            DataTable dt = DBHelper.ExecuteGetDataTable(CommandType.Text, sql, null);
            foreach (DataRow dr in dt.Rows)
            {
                BranchInfo branchInfo = new BranchInfo();
                branchInfo.Id = (int)dr["Id"];
                branchInfo.BranchName = (string)dr["BranchName"];
                branchInfo.BranchShortName = (string)dr["BranchShortName"];

                list.Add(branchInfo);
            }
            return list;
        }
        /// <summary>
        /// 根据id查询机构信息：
        /// </summary>
        /// <param name="Branchid"></param>
        /// <returns></returns>
        public static BranchInfo GetBranchById(int branchid)
        {
            string sql = "select * from VW_BranchInfoAll where Id=@Id";
            SqlParameter[] para = new SqlParameter[] 
            {
                new SqlParameter("@Id",branchid)
            };
            BranchInfo b = new BranchInfo();
            DataTable temp = DBHelper.ExecuteGetDataTable(CommandType.Text, sql, para);
            if (temp.Rows.Count > 0)
            {
                b.Id = int.Parse(temp.Rows[0]["Id"].ToString());
                b.BranchName = temp.Rows[0]["BranchName"].ToString();
                b.BranchShortName = temp.Rows[0]["BranchShortName"].ToString();
            }
            return b;
        }
        /// <summary>
        /// 修改机构验证
        /// </summary>
        /// <param name="Branchid"></param>
        /// <returns></returns>
        public static bool ModifyBranchCheck(BranchInfo branchInfo)
        {
            string sql = "select * from VW_BranchInfoAll where BranchName=@BranchName,BranchShortName=@BranchShortName";
            SqlParameter[] para = new SqlParameter[] 
            {
                new SqlParameter("@BranchName",branchInfo.BranchName),
                new SqlParameter("@BranchShortName",branchInfo.BranchShortName)
            };

            DataTable temp = DBHelper.ExecuteGetDataTable(CommandType.Text, sql, para);
            if (temp.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 删除机构验证
        /// </summary>
        /// <param name="Branchid"></param>
        /// <returns></returns>
        public static bool DeleteBranchCheck(int id)
        {
            string sql = "select * from VW_DepartInfoAll where BranchId=@BranchId";
            SqlParameter[] para = new SqlParameter[] 
            {
                new SqlParameter("@BranchId",id)
            };

            DataTable temp = DBHelper.ExecuteGetDataTable(CommandType.Text, sql, para);
            if (temp.Rows.Count > 0)
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

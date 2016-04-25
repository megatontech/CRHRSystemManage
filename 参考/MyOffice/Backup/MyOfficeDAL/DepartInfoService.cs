using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using MyOffice.Models;

namespace MyOffice.DAL
{
    public static class DepartInfoService
    {
        /// <summary>
        /// 检查部门是否存在
        /// </summary>
        /// <param name="depart"></param>
        /// <returns>bool</returns>
        public static bool CheckDepart(DepartInfo depart)
        {
            string sql = "SELECT  * FROM VW_DepartInfoAll WHERE DepartName=@DepartName And BranchId=@BranchId";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@DepartName",depart.DepartName),
                new SqlParameter("@BranchId",depart.Branch.Id)
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
        /// 添加部门
        /// </summary>
        /// <param name="branchInfo"></param>
        /// <returns></returns>
        public static bool AddDepart(DepartInfo departInfo)
        {
            SqlParameter[] para = new SqlParameter[] 
            {
                new SqlParameter("@DepartName",departInfo.DepartName),
                new SqlParameter("@PrincipalUserId",departInfo.User.Id),
                new SqlParameter("@ConnectTelNo",departInfo.ConnectTelNo),
                new SqlParameter("@ConnectMobileTelNo",departInfo.ConnectMobileTelNo),
                new SqlParameter("@Faxes",departInfo.Faxes),
                new SqlParameter("@BranchId",departInfo.Branch.Id)
            };
            int i = DBHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_AddDepart", para);
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
        ///删除部门
        ///</summary>
        ///<param name="departId"></param>
        ///<returns></returns>
        public static bool DeleteDepartById(int departId)
        {
            SqlParameter[] para = new SqlParameter[] 
            {
                new SqlParameter("@DepartId",departId)
            };
            int i = DBHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_DeleteDepartById", para);
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
        /// 根据机构ID得部门名称  [查询树的方法]
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static IList<DepartInfo> GetDepartInfoByBranchId(int id)
        {
            string sql = "select * from vw_DepartInfoAll where BranchId='" + id + "'";
            IList<DepartInfo> list = new List<DepartInfo>();
            DataTable dt = DBHelper.ExecuteGetDataTable(CommandType.Text, sql, null);

            foreach (DataRow dr in dt.Rows)
            {
                DepartInfo departInfo = new DepartInfo();
                departInfo.Id = (int)dr["Id"];
                departInfo.DepartName = (string)dr["DepartName"];
                UserInfo user = new UserInfo();
                user.Id = (int)dr["PrincipalUserId"];
                user.UserName = (string)dr["principalUserName"];
                departInfo.User = user;
                departInfo.ConnectTelNo = (string)dr["ConnectTelNo"];
                departInfo.ConnectMobileTelNo = (string)dr["ConnectMobileTelNo"];
                departInfo.Faxes = (string)dr["Faxes"];
                BranchInfo branch = new BranchInfo();
                branch.Id = (int)dr["BranchId"];
                branch.BranchName = (string)dr["BranchName"];
                departInfo.Branch = branch;

                list.Add(departInfo);
            }
            return list;
        }
        /// <summary>
        /// 根据id修改部门
        /// </summary>
        /// <param name="Branch"></param>
        /// <returns></returns>
        public static bool ModifyDepartById(DepartInfo depart)
        {
            SqlParameter[] para = new SqlParameter[] 
            {
                new SqlParameter("@Id",depart.Id),
                new SqlParameter("@PrincipalUserId",depart.User.Id),
                new SqlParameter("@ConnectTelNo",depart.ConnectTelNo),
                new SqlParameter("@ConnectMobileTelNo",depart.ConnectMobileTelNo),
                new SqlParameter("@Faxes",depart.Faxes),
                new SqlParameter("@BranchId",depart.Branch.Id),
                new SqlParameter("@DepartName",depart.DepartName)
            };
            int i = DBHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_ModifyDepartById", para);
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
        /// 查询所有部门
        /// </summary>
        /// <returns></returns>
        public static IList<DepartInfo> GetAllDepart()
        {
            string sql = "select * from VW_DepartInfoAll order by Id Desc";
            IList<DepartInfo> list = new List<DepartInfo>();
            using (SqlDataReader dr = DBHelper.ExecuteGetReader(CommandType.Text, sql, null))
            {
                while (dr.Read())
                {
                    DepartInfo d = new DepartInfo();
                    UserInfo u = new UserInfo();
                    BranchInfo b = new BranchInfo();
                    d.Id = int.Parse(dr["Id"].ToString());
                    d.DepartName = dr["DepartName"].ToString();
                    u.Id = int.Parse(dr["PrincipalUserId"].ToString());
                    u.UserName = dr["PrincipalUserName"].ToString();
                    d.ConnectTelNo = dr["ConnectTelNo"].ToString();
                    d.ConnectMobileTelNo = dr["ConnectMobileTelNo"].ToString();
                    d.Faxes = dr["Faxes"].ToString();
                    b.Id = int.Parse(dr["BranchId"].ToString());
                    b.BranchName = dr["BranchName"].ToString();
                    d.User = u;
                    d.Branch = b;
                    list.Add(d);
                }
            }
            return list;
        }
        /// <summary>
        /// 根据id查询机构信息：
        /// </summary>
        /// <param name="Branchid"></param>
        /// <returns></returns>
        public static DepartInfo GetDepartById(int departid)
        {
            string sql = "select * from VW_DepartInfoAll where Id=@Id";
            SqlParameter[] para = new SqlParameter[] 
            {
                new SqlParameter("@Id",departid)
            };
            DepartInfo dt = new DepartInfo();
            DataTable temp = DBHelper.ExecuteGetDataTable(CommandType.Text, sql, para);
            DepartInfo d = new DepartInfo();
            foreach (DataRow dr in temp.Rows)
            {

                UserInfo u = new UserInfo();
                BranchInfo b = new BranchInfo();
                d.Id = int.Parse(dr["Id"].ToString());
                d.DepartName = dr["DepartName"].ToString();
                u.Id = int.Parse(dr["PrincipalUserId"].ToString());
                u.UserName = dr["PrincipalUserName"].ToString();
                d.ConnectTelNo = dr["ConnectTelNo"].ToString();
                d.ConnectMobileTelNo = dr["ConnectMobileTelNo"].ToString();
                d.Faxes = dr["Faxes"].ToString();
                b.Id = int.Parse(dr["BranchId"].ToString());
                b.BranchName = dr["BranchName"].ToString();
                d.User = u;
                d.Branch = b;
            }
            return d;
        }
        /// <summary>
        /// 修改部门验证
        /// </summary>
        /// <param name="Branchid"></param>
        /// <returns></returns>
        public static bool ModifyDepartCheck(DepartInfo departInfo)
        {
            string sql = "select * from VW_DepartInfoAll where DepartName=@DepartName";
            SqlParameter[] para = new SqlParameter[] 
            {
                new SqlParameter("@DepartName",departInfo.DepartName)
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
        /// 删除部门验证
        /// </summary>
        /// <param name="Branchid"></param>
        /// <returns></returns>
        public static bool DeleteDepartCheck(int id)
        {
            string sql = "select * from VW_UserInfoAll where DepartId=@DepartId";
            SqlParameter[] para = new SqlParameter[] 
            {
                new SqlParameter("@DepartId",id)
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

using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using MyOffice.Models;

namespace MyOffice.DAL
{
    public static class UserInfoService
    {
        /// <summary>
        /// 判断该用户是否是合法的
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool Login(ref UserInfo user)
        {
            string sql = "SELECT * FROM VW_UserInfoAll WHERE LoginId=@LoginId AND Password=@Password  AND UserStateId=2";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@LoginId",user.LoginId),
                new SqlParameter("@Password",user.Password)
               
            };
            DataTable temp = DBHelper.ExecuteGetDataTable(CommandType.Text, sql, para);
            if (temp.Rows.Count > 0)
            {
                UserInfo u = new UserInfo();
                u.Id = int.Parse(temp.Rows[0]["Id"].ToString());
                u.LoginId = temp.Rows[0]["LoginId"].ToString();
                u.UserName = temp.Rows[0]["UserName"].ToString();
                RoleInfo role = new RoleInfo();
                role.Id = (int)temp.Rows[0]["RoleId"];
                role.RoleName = temp.Rows[0]["RoleName"].ToString();
                u.Role = role;
                UserState state = new UserState();
                state.Id = (int)temp.Rows[0]["UserStateId"];
                state.UserStateName = temp.Rows[0]["UserStateName"].ToString();
                user.UserState = state;
                BranchInfo branch = new BranchInfo();
                branch.Id = (int)temp.Rows[0]["BranchId"];
                branch.BranchName = temp.Rows[0]["BranchName"].ToString();
                branch.BranchShortName = temp.Rows[0]["BranchShortName"].ToString();
                DepartInfo depart = new DepartInfo();
                depart.Id = (int)temp.Rows[0]["DepartId"];
                depart.DepartName = temp.Rows[0]["DepartName"].ToString();
                depart.Branch = branch;
                u.Depart = depart;
                user = u;
                return true;
            }
            else
            {
                user = null;
                return false;
            }
        }
        /// <summary>
        /// 通过部门和机构的Id查询用户信息
        /// </summary>
        /// <param name="branchId">机构Id</param>
        /// <param name="departId">部门Id</param>
        /// <returns>IList<UserInfo></returns>
        public static IList<UserInfo> GetUserInfoByBranchIdAndDepartId(int branchId, int departId)
        {
            string sqlDepartId = "";
            if (departId != 0)
            {
                sqlDepartId = " AND DepartId=" + departId + " ";
            }
            string sqlBranchId = "";
            if (branchId != 0)
            {
                sqlBranchId = " AND BranchId=" + branchId + " ";
            }
            string sql = "SELECT * FROM VW_UserInfoAll WHERE  UserStateId=2 ";
            sql += sqlDepartId;
            sql += sqlBranchId;
            return GetUserInfoBySql(sql);
        }
        /// <summary>
        /// 通过用户名得到角色Id
        /// </summary>
        /// <param name="user">UserInfo</param>
        /// <returns>int</returns>
        public static int GetUserIdByUserLoginId(UserInfo user)
        {
            string sql = "SELECT Id FROM VW_UserInfoAll WHERE LoginId=@LoginId ";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@LoginId",user.LoginId)              
            };
            return (int)DBHelper.ExecuteScalar(CommandType.Text, sql, para);
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="userInfo">UserInfo</param>
        /// <returns>bool</returns>
        public static bool ModifyPassword(UserInfo userInfo)
        {
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@Id",userInfo.Id),
                new SqlParameter("@Password",userInfo.Password)
            };
            int count = DBHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_ModifyPassword", para);
            if (count > 0)
                return true;
            return false;
        }
        /// <summary>
        /// 修改用户的状态的方法
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="categoryid"></param>
        /// <returns></returns>
        public static bool ModifyUserInfoStates(int StateId, string ids)
        {
            string sql = "UPDATE UserInfo SET UserStateId=" + StateId + " WHERE Id IN(" + ids + ")";
            int count = DBHelper.ExecuteNonQuery(CommandType.Text, sql, null);
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
        /// 修改用户角色的方法
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public static bool ModifyRoleIdByUserId(string ids, int roleId)
        {
            string sql = "UPDATE UserInfo SET RoleId=" + roleId + " WHERE Id IN(" + ids + ")";
            int count = DBHelper.ExecuteNonQuery(CommandType.Text, sql, null);
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
        /// 通过角色Id查询该角色下用户
        /// </summary>
        /// <param name="roleId">int</param>
        /// <returns>IList<UserInfo> </returns>
        public static IList<UserInfo> GetUserInfoByRoleId(int roleId)
        {
            string sql = "SELECT * FROM VW_UserInfoAll WHERE  RoleId=" + roleId + " ";
            return GetUserInfoBySql(sql);
        }
        /// <summary>
        /// 通过角色Id查询该角色下是否有用户
        /// </summary>
        /// <param name="roleId">int</param>
        /// <returns>bool</returns>
        public static bool GetUserIdByRoleId(int roleId)
        {
            string sql = "SELECT count(Id) FROM VW_UserInfoAll WHERE  RoleId=@RoleId ";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@RoleId",roleId)              
            };
            int count = (int)DBHelper.ExecuteScalar(CommandType.Text, sql, para);
            if (count > 0)
                return true;
            return false;
        }
        /// <summary>
        /// 将得到的IList<UserInfo>转换为string数组
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="displaycount"></param>
        /// <returns></returns>
        public static string[] GetHotSearchKeywords(string userName, int displaycount)
        {
            IList<UserInfo> list = new List<UserInfo>();
            List<string> results = new List<string>(displaycount);

            string sqlHot = "select top " + displaycount + " * from VW_UserInfoAll where UserName like '" + userName + "%' order by UserName desc";
            list = GetSearchKeywordsBySql(sqlHot);

            foreach (UserInfo item in list)
            {
                results.Add(item.UserName);
            }
            return results.ToArray();
        }
        /// <summary>
        /// 查询符合要求的Keyword
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns>IList<UserInfo></returns>
        public static IList<UserInfo> GetSearchKeywordsBySql(string sql)
        {
            IList<UserInfo> list = new List<UserInfo>();
            using (SqlDataReader dr = DBHelper.ExecuteGetReader(CommandType.Text, sql, null))
            {
                while (dr.Read())
                {
                    UserInfo user = new UserInfo();

                    user.UserName = dr["UserName"].ToString();
                    list.Add(user);
                }
            }
            return list;
        }
        /// <summary>
        /// 通过用户名得到角色Id
        /// </summary>
        /// <param name="loginId"></param>
        /// <returns></returns>
        public static int GetRoleIdByUserLoginId(UserInfo user)
        {
            string sql = "SELECT RoleId FROM VW_UserInfoAll WHERE LoginId=@LoginId and UserStateId=2";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@LoginId",user.LoginId)              
            };
            return (int)DBHelper.ExecuteScalar(CommandType.Text, sql, para);
        }
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="branchInfo"></param>
        /// <returns></returns>
        public static bool AddUser(UserInfo userInfo)
        {
            SqlParameter[] para = new SqlParameter[] 
            {
                new SqlParameter("@LoginId",userInfo.LoginId),
                new SqlParameter("@UserName",userInfo.UserName),
                new SqlParameter("@PassWord",userInfo.Password),
                new SqlParameter("@DepartId",userInfo.Depart.Id),
                new SqlParameter("@Gender",userInfo.Gender),
                new SqlParameter("@RoleId",userInfo.Role.Id),
                new SqlParameter("@UserStateId",userInfo.UserState.Id)
            };
            int i = DBHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_AddUser", para);
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
        ///删除用户
        ///</summary>
        ///<param name="branchInfo"></param>
        ///<returns></returns>
        public static bool DeleteUserById(int userid, int userStateId)
        {
            SqlParameter[] para = new SqlParameter[] 
            {
                new SqlParameter("@UserId",userid),
                 new SqlParameter("@UserStateId",userStateId)
            };
            int i = DBHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_DeleteUserById", para);
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
        /// 根据部门Id 查询用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static IList<UserInfo> GetUserInfoByDepartId(int id)
        {

            string sql = "select * from vw_UserInfoAll where DepartId=" + id + " and UserStateId=2";
            return GetUserInfoBySql(sql);
        }
        /// <summary>
        /// 根据用户Id 查询用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static UserInfo GetUserInfoById(int id)
        {
            string sql = "select * from VW_UserInfoAll where Id=@Id and UserStateId=2";
            IList<UserInfo> list = new List<UserInfo>();
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@Id",id)              
            };
            DataTable dt = DBHelper.ExecuteGetDataTable(CommandType.Text, sql, para);
            UserInfo user = new UserInfo();
            foreach (DataRow dr in dt.Rows)
            {


                DepartInfo de = new DepartInfo();
                BranchInfo b = new BranchInfo();
                RoleInfo r = new RoleInfo();
                UserState uss = new UserState();
                user.Id = (int)dr["Id"];
                user.LoginId = (string)dr["LoginId"];
                user.UserName = (string)dr["Username"];
                user.Password = (string)dr["Password"];
                de.Id = (int)dr["DepartId"];
                de.DepartName = (string)dr["DepartName"];
                b.Id = (int)dr["BranchId"];
                b.BranchName = (string)dr["BranchName"];
                b.BranchShortName = (string)dr["BranchShortName"];
                de.Branch = b;
                user.Gender = (int)dr["Gender"];
                r.Id = (int)dr["RoleId"];
                r.RoleName = (string)dr["RoleName"];
                r.RoleDesc = (string)dr["RoleDesc"];
                uss.Id = (int)dr["UserStateId"];
                uss.UserStateName = (string)dr["UserStateName"];


                user.Depart = de;
                user.Role = r;
                user.UserState = uss;
            }
            return user;
        }
        /// <summary>
        /// 查询所有用户
        /// </summary>
        /// <returns></returns>
        public static IList<UserInfo> GetAllUserInfo()
        {
            string sql = "select * from VW_UserInfoAll  where UserStateId=2 order by Id Desc";
            return GetUserInfoBySql(sql);
        }
        /// <summary>
        /// 查询所有用户
        /// </summary>
        /// <returns></returns>
        public static IList<UserInfo> GetUserInfos()
        {
            string sql = "select * from VW_UserInfoAll";
            return GetUserInfoBySql(sql);
        }
        /// <summary>
        /// 检查用户是否存在
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool CheckUser(string userLoginId)
        {
            string sql = "SELECT  * FROM VW_UserInfoAll WHERE LoginId=@LoginId";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@LoginId",userLoginId)
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
        /// 根据id修改用户
        /// </summary>
        /// <param name="Branch"></param>
        /// <returns></returns>
        public static bool ModifyUserById(UserInfo userInfo)
        {
            SqlParameter[] para = new SqlParameter[] 
            {
                new SqlParameter("@Id",userInfo.Id),
                new SqlParameter("@LoginId",userInfo.LoginId),
                new SqlParameter("@UserName",userInfo.UserName),
                new SqlParameter("@PassWord",userInfo.Password),
                new SqlParameter("@DepartId",userInfo.Depart.Id),
                new SqlParameter("@Gender",userInfo.Gender),
                new SqlParameter("@RoleId",userInfo.Role.Id),
                new SqlParameter("@UserStateId",userInfo.UserState.Id)

            };
            int i = DBHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_ModifyUserInfoById", para);
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
        /// 根据选择的条件获得所有可选的发送对象
        /// </summary>
        /// <param name="userName">用户姓名</param>
        /// <param name="departId">部门</param>
        /// <param name="branchId">机构</param>
        /// <returns>List</returns>
        public static List<UserInfo> GetUserInfoByUserNameAndDepartIdAndBranchId(string userName, int departId, int branchId)
        {
            //是否添加用户姓名查找条件
            string sqlUserName = "";
            if (userName != "")
            {
                sqlUserName = " and UserName like '%" + userName + "%'";
            }

            //是否添加部门查找条件
            string sqlDepartId = "";
            if (departId != 0)
            {
                sqlDepartId = " and DepartId=" + departId + " ";
            }

            //是否添加机构查找条件
            string sqlBranchId = "";
            if (branchId != 0)
            {
                sqlBranchId = " and BranchId=" + branchId + " ";
            }

            string sql = "select * from VW_UserInfoAll  where UserStateId=2 ";
            sql += sqlUserName;
            sql += sqlDepartId;
            sql += sqlBranchId;
            sql += " order by BranchId, DepartId,UserName";
            return GetUserInfoBySql(sql);

        }
        /// <summary>
        /// 根据选择的条件获得所有可选的发送对象
        /// </summary>
        /// <param name="userName">用户姓名</param>
        /// <param name="departId">部门</param>
        /// <param name="branchId">机构</param>
        /// <returns>IList<UserInfo></returns>
        public static IList<UserInfo> GetUserInfoBySelectedConditions(string userName, int departId, int branchId, int roleId)
        {
            //是否添加用户姓名查找条件
            string sqlUserName = "";
            if (userName != "")
            {
                sqlUserName = " and UserName like '%" + userName + "%'";
            }

            //是否添加部门查找条件
            string sqlDepartId = "";
            if (departId != 0)
            {
                sqlDepartId = " and DepartId=" + departId + " ";
            }

            //是否添加机构查找条件
            string sqlBranchId = "";
            if (branchId != 0)
            {
                sqlBranchId = " and BranchId=" + branchId + " ";
            }
            //是否添加角色查询
            string sqlRoleId = "";
            if (roleId != 0) 
            {
                sqlRoleId = " and RoleId=" + roleId + " ";
            }
            string sql = "select * from VW_UserInfoAll  where UserStateId in(1,2) ";
            sql += sqlUserName;
            sql += sqlDepartId;
            sql += sqlBranchId;
            sql += sqlRoleId;
            sql += " order by BranchId, DepartId,UserName";
            return GetUserInfoBySql(sql);

        }
        /// <summary>
        /// 根据SQL语句查询用户表中的信息
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>List</returns>
        public static List<UserInfo> GetUserInfoBySql(string sql)
        {
            List<UserInfo> list = new List<UserInfo>();
            using (SqlDataReader dr = DBHelper.ExecuteGetReader(CommandType.Text, sql, null))
            {
                while (dr.Read())
                {
                    UserInfo userInfo = new UserInfo();//员工信息
                    userInfo.Id = (int)dr["Id"];  //员工ID
                    userInfo.LoginId = (string)dr["LoginId"]; //登陆名
                    userInfo.UserName = (string)dr["UserName"]; //真实姓名
                    userInfo.Password = (string)dr["Password"]; //密码
                    DepartInfo departInfo = new DepartInfo();  //部门信息
                    departInfo.Id = (int)dr["DepartId"];  //部门ID
                    departInfo.DepartName = (string)dr["DepartName"]; //部门名称  
                    BranchInfo branchInfo = new BranchInfo();  //机构信息
                    branchInfo.Id = (int)dr["BranchId"];  //机构ID
                    branchInfo.BranchName = (string)dr["BranchName"]; //机构名称
                    branchInfo.BranchShortName = (string)dr["BranchShortName"]; //机构简称
                    departInfo.Branch = branchInfo;
                    userInfo.Depart = departInfo;
                    userInfo.Gender = (int)dr["Gender"]; //员工性别
                    RoleInfo roleInfo = new RoleInfo();  //角色信息
                    roleInfo.Id = (int)dr["RoleId"];  //角色Id
                    roleInfo.RoleName = (string)dr["RoleName"]; //角色名称
                    roleInfo.RoleDesc = (string)dr["RoleDesc"]; //角色排序
                    userInfo.Role = roleInfo;

                    UserState userState = new UserState();  //员工状态
                    userState.Id = (int)dr["UserStateId"];  //状态ID
                    userState.UserStateName = (string)dr["UserStateName"]; //状态名称
                    userInfo.UserState = userState;

                    list.Add(userInfo); //把员工信息添加到集合中
                }
            }

            return list;
        }
        /// <summary>
        ///根据用户名的用户
        /// </summary>
        /// <param name="userinfo"></param>
        /// <returns></returns>
        public static int GetUserByUserName(string userName)
        {
            string sql = "select * from UserInfo where UserName=@UserName";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@UserName",userName)
            };
            object obj = DBHelper.ExecuteScalar(CommandType.Text, sql, para);
            if (obj != null)
            {
                return int.Parse(obj.ToString());
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// 得到员工的详细信息[预约人]
        /// </summary>
        /// <returns></returns>
        public static IList<UserInfo> GetUserInfoAll()
        {
            string sql = "select * from vw_UserInfoAll where UserStateId=2";
            return GetUserInfoBySql(sql);

        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using MyOffice.Models;
using MyOffice.DAL;

namespace MyOffice.BLL
{
    public static class UserInfoManager
    {
        /// <summary>
        /// 判断该用户是否是合法的
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool Login(ref UserInfo user) 
        {
            return UserInfoService.Login(ref user);
        }
         /// <summary>
        /// 通过用户名得到角色Id
        /// </summary>
        /// <param name="loginId"></param>
        /// <returns></returns>
        public static int GetUserIdByUserLoginId(UserInfo user) 
        {
            return UserInfoService.GetUserIdByUserLoginId(user);
        }
         /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="userInfo">UserInfo</param>
        /// <returns>bool</returns>
        public static bool ModifyPassword(UserInfo userInfo)
        {
            return UserInfoService.ModifyPassword(userInfo);
        }
         /// <summary>
        /// 修改用户的状态的方法
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="categoryid"></param>
        /// <returns></returns>
        public static bool ModifyUserInfoStates(int StateId, string ids)
        {
            return UserInfoService.ModifyUserInfoStates(StateId, ids);
        }
          /// <summary>
        /// 修改用户角色的方法
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public static bool ModifyRoleIdByUserId(string ids, int roleId)
        {
            return UserInfoService.ModifyRoleIdByUserId(ids,roleId);
        }
        /// <summary>
        /// 通过角色Id查询该角色下用户
        /// </summary>
        /// <param name="roleId">int</param>
        /// <returns>IList<UserInfo> </returns>
        public static IList<UserInfo> GetUserInfoByRoleId(int roleId)
        {
            return UserInfoService.GetUserInfoByRoleId(roleId);
        }
        /// <summary>
        /// 通过角色Id查询该角色下是否有用户
        /// </summary>
        /// <param name="roleId">int</param>
        /// <returns>bool</returns>
        public static bool GetUserIdByRoleId(int roleId)
        {
            return UserInfoService.GetUserIdByRoleId(roleId);
        }
        /// <summary>
        /// 通过部门和机构的Id查询用户信息
        /// </summary>
        /// <param name="branchId">机构Id</param>
        /// <param name="departId">部门Id</param>
        /// <returns>IList<UserInfo></returns>
        public static IList<UserInfo> GetUserInfoByBranchIdAndDepartId(int branchId,int departId)
        {
            return UserInfoService.GetUserInfoByBranchIdAndDepartId(branchId,departId);
        }
         /// <summary>
        /// 将得到的IList<UserInfo>转换为string数组
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="displaycount"></param>
        /// <returns></returns>
        public static string[] GetHotSearchKeywords(string userName, int displaycount)
        {
            return UserInfoService.GetHotSearchKeywords(userName, displaycount);
        }
        /// <summary>
        /// 通过用户名得到角色Id
        /// </summary>
        /// <param name="loginId"></param>
        /// <returns></returns>
        public static int GetRoleIdByUserLoginId(UserInfo user)
        {
            return UserInfoService.GetRoleIdByUserLoginId(user);
        }
        /// <summary>
        /// 根据部么Id 查询该部门下用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static IList<UserInfo> GetUserInfoByDepartId(int id)
        {
            return UserInfoService.GetUserInfoByDepartId(id);
        }
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public static bool AddUser(UserInfo userInfo)
        {
            return UserInfoService.AddUser(userInfo);
        }
        ///<summary>
        ///删除用户
        ///</summary>
        ///<param name="branchInfo"></param>
        ///<returns></returns>
        public static bool DeleteUserById(int userid, int userStateId)
        {
            return UserInfoService.DeleteUserById(userid, userStateId);
        }
        /// <summary>
        /// 根据用户id查询用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static UserInfo GetUserInfoById(int id)
        {
            return UserInfoService.GetUserInfoById(id);
        }
        /// <summary>
        /// 检查用户登录id是否存在
        /// </summary>
        /// <param name="userLoginId"></param>
        /// <returns></returns>
        public static bool CheckUser(string userLoginId)
        {
            return UserInfoService.CheckUser(userLoginId);
        }
        /// <summary>
        /// 根据用户Id修改用户信息
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public static bool ModifyUserById(UserInfo userInfo)
        {
            return UserInfoService.ModifyUserById(userInfo);
        }
        /// <summary>
        /// 查询所有用户
        /// </summary>
        /// <returns></returns>
        public static IList<UserInfo> GetAllUserInfo()
        {
            return UserInfoService.GetAllUserInfo();
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
            return UserInfoService.GetUserInfoByUserNameAndDepartIdAndBranchId(userName, departId, branchId);
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
            return UserInfoService.GetUserInfoBySelectedConditions(userName, departId, branchId, roleId);
        }
        /// <summary>
        ///根据用户名的用户
        /// </summary>
        /// <param name="userinfo"></param>
        /// <returns></returns>
        public static int GetUserByUserName(string userName)
        {
            return UserInfoService.GetUserByUserName(userName);
        }
        /// <summary>
        /// 得到员工的详细信息[预约人]
        /// </summary>
        /// <returns></returns>
        public static IList<UserInfo> GetUserInfoAll()
        {
            return UserInfoService.GetUserInfoAll();
        }
        /// <summary>
        /// 查询所有用户
        /// </summary>
        /// <returns></returns>
        public static IList<UserInfo> GetUserInfos()
        {
            return UserInfoService.GetUserInfos();
        }
    }
}

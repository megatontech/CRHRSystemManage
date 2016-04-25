using System;
using System.Collections.Generic;
using System.Text;
using MyOffice.DAL;
using MyOffice.Models;

namespace MyOffice.BLL
{
    public static class DepartInfoManager
    {
        /// <summary>
        /// 根据机构ID得部门名称  [查询树的方法]
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static IList<DepartInfo> GetDepartInfoByBranchId(int id)
        {
            return DepartInfoService.GetDepartInfoByBranchId(id);
        }
        /// <summary>
        /// 检查部门是否存在
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool CheckDepart(DepartInfo depart)
        {
            return DepartInfoService.CheckDepart(depart);
        }
        /// <summary>
        /// 添加部门
        /// </summary>
        /// <param name="branchInfo"></param>
        /// <returns></returns>
        public static bool AddDepart(DepartInfo departInfo)
        {
            return DepartInfoService.AddDepart(departInfo);
        }
        ///<summary>
        ///删除部门
        ///</summary>
        ///<param name="departId"></param>
        ///<returns></returns>
        public static bool DeleteDepartById(int departId)
        {
            return DepartInfoService.DeleteDepartById(departId);
        }
        /// <summary>
        /// 根据id修改部门
        /// </summary>
        /// <param name="Branch"></param>
        /// <returns></returns>
        public static bool ModifyDepartById(DepartInfo depart)
        {
            return DepartInfoService.ModifyDepartById(depart);
        }
        /// <summary>
        /// 查询所有部门
        /// </summary>
        /// <returns></returns>
        public static IList<DepartInfo> GetAllDepart()
        {
            return DepartInfoService.GetAllDepart();
        }
        /// <summary>
        /// 根据id查询机构信息：
        /// </summary>
        /// <param name="Branchid"></param>
        /// <returns></returns>
        public static DepartInfo GetDepartById(int departid)
        {
            return DepartInfoService.GetDepartById(departid);
        }
        /// <summary>
        /// 修改部门验证
        /// </summary>
        /// <param name="Branchid"></param>
        /// <returns></returns>
        public static bool ModifyDepartCheck(DepartInfo departInfo)
        {
            return DepartInfoService.ModifyDepartCheck(departInfo);
        }
        /// <summary>
        /// 删除部门验证
        /// </summary>
        /// <param name="Branchid"></param>
        /// <returns></returns>
        public static bool DeleteDepartCheck(int id)
        {
            return DepartInfoService.DeleteDepartCheck(id);
        }
    }
}

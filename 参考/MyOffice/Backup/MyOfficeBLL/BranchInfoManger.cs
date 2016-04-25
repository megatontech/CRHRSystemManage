using System;
using System.Collections.Generic;
using System.Text;
using MyOffice.Models;
using MyOffice.DAL;

namespace MyOffice.BLL
{
    public static class BranchInfoManger
    {
        /// <summary>
        /// 检查机构是否存在
        /// </summary>
        /// <param name="branchInfo"></param>
        /// <returns></returns>
        public static bool CheckBranch(BranchInfo branchInfo)
        {
            return BranchInfoService.CheckBranch(branchInfo);
        }
        /// <summary>
        /// 添加机构
        /// </summary>
        /// <param name="branchInfo"></param>
        /// <returns></returns>
        public static bool AddBranch(BranchInfo branchInfo)
        {
            return BranchInfoService.AddBranch(branchInfo);
        }
        ///<summary>
        ///删除机构
        ///</summary>
        ///<param name="branchInfo"></param>
        ///<returns></returns>
        public static bool DeleteBranchById(int branchid)
        {
            return BranchInfoService.DeleteBranchById(branchid);
        }
        /// <summary>
        /// 根据id修改机构
        /// </summary>
        /// <param name="Branch"></param>
        /// <returns></returns>
        public static bool ModifyBranchById(BranchInfo branch)
        {
            return BranchInfoService.ModifyBranchById(branch);
        }
        /// <summary>
        /// 查询所有机构
        /// </summary>
        /// <returns></returns>
        public static IList<BranchInfo> GetBranchInfo()
        {
            return BranchInfoService.GetBranchInfo();
        }
        /// <summary>
        /// 根据id查询机构信息：
        /// </summary>
        /// <param name="Branchid"></param>
        /// <returns></returns>
        public static BranchInfo GetBranchById(int branchid)
        {
            return BranchInfoService.GetBranchById(branchid);
        }
        /// <summary>
        /// 删除机构验证
        /// </summary>
        /// <param name="Branchid"></param>
        /// <returns></returns>
        public static bool DeleteBranchCheck(int branchid)
        {
            return BranchInfoService.DeleteBranchCheck(branchid);
        }
    }
}

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
        /// �������Ƿ����
        /// </summary>
        /// <param name="branchInfo"></param>
        /// <returns></returns>
        public static bool CheckBranch(BranchInfo branchInfo)
        {
            return BranchInfoService.CheckBranch(branchInfo);
        }
        /// <summary>
        /// ��ӻ���
        /// </summary>
        /// <param name="branchInfo"></param>
        /// <returns></returns>
        public static bool AddBranch(BranchInfo branchInfo)
        {
            return BranchInfoService.AddBranch(branchInfo);
        }
        ///<summary>
        ///ɾ������
        ///</summary>
        ///<param name="branchInfo"></param>
        ///<returns></returns>
        public static bool DeleteBranchById(int branchid)
        {
            return BranchInfoService.DeleteBranchById(branchid);
        }
        /// <summary>
        /// ����id�޸Ļ���
        /// </summary>
        /// <param name="Branch"></param>
        /// <returns></returns>
        public static bool ModifyBranchById(BranchInfo branch)
        {
            return BranchInfoService.ModifyBranchById(branch);
        }
        /// <summary>
        /// ��ѯ���л���
        /// </summary>
        /// <returns></returns>
        public static IList<BranchInfo> GetBranchInfo()
        {
            return BranchInfoService.GetBranchInfo();
        }
        /// <summary>
        /// ����id��ѯ������Ϣ��
        /// </summary>
        /// <param name="Branchid"></param>
        /// <returns></returns>
        public static BranchInfo GetBranchById(int branchid)
        {
            return BranchInfoService.GetBranchById(branchid);
        }
        /// <summary>
        /// ɾ��������֤
        /// </summary>
        /// <param name="Branchid"></param>
        /// <returns></returns>
        public static bool DeleteBranchCheck(int branchid)
        {
            return BranchInfoService.DeleteBranchCheck(branchid);
        }
    }
}

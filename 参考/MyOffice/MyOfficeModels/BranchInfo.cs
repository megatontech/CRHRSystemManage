/**
 * 机构信息表
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace MyOffice.Models
{
    [Serializable]
    public class BranchInfo
    {
        private int id;                         //机构编号
        private string branchName;              //机构名称
        private string branchShortName;         //机构简称

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public string BranchName
        {
            get { return this.branchName; }
            set { this.branchName = value; }
        }
        public string BranchShortName
        {
            get { return this.branchShortName; }
            set { this.branchShortName = value; }
        }
    }
}

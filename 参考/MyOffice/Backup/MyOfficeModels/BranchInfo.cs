/**
 * ������Ϣ��
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace MyOffice.Models
{
    [Serializable]
    public class BranchInfo
    {
        private int id;                         //�������
        private string branchName;              //��������
        private string branchShortName;         //�������

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

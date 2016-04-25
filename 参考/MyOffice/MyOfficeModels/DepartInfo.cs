/**
 * 部门基本信息类
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace MyOffice.Models
{
    [Serializable]
    public class DepartInfo
    { 
        private int id;                   //部门编号
        private string departName;        //部门名称
        private UserInfo user;            //部门负责人
        private string connectTelNo;      //联系电话
        private string connectMobileTelNo; //移动电话
        private string faxes;             //传真
        private BranchInfo branch;        //所属机构

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public string DepartName
        {
            get { return this.departName; }
            set { this.departName = value; }
        }
        public UserInfo User
        {
            get { return this.user; }
            set { this.user = value; }
        }
        public string ConnectTelNo
        {
            get { return this.connectTelNo; }
            set { this.connectTelNo = value; }
        }
        public string ConnectMobileTelNo
        {
            get { return this.connectMobileTelNo; }
            set { this.connectMobileTelNo = value; }
        }
        public string Faxes
        {
            get { return this.faxes; }
            set { this.faxes = value; }
        }
        public BranchInfo Branch
        {
            get { return this.branch; }
            set { this.branch = value; }
        }
    }
}

/**
 * ���Ż�����Ϣ��
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace MyOffice.Models
{
    [Serializable]
    public class DepartInfo
    { 
        private int id;                   //���ű��
        private string departName;        //��������
        private UserInfo user;            //���Ÿ�����
        private string connectTelNo;      //��ϵ�绰
        private string connectMobileTelNo; //�ƶ��绰
        private string faxes;             //����
        private BranchInfo branch;        //��������

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

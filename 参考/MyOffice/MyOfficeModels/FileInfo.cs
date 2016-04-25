/**
 * �ļ�������Ϣ��
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace MyOffice.Models
{
    [Serializable]
    public class FileInfo
    {
        private int id;          //�ļ����
        private string fileName;     //�ļ�����
        private FileTypeInfo fileType;   //�ļ�����
        private string remark;       //��ע
        private UserInfo fileOwner;    //�ļ�������
        private DateTime createDate; //����ʱ��
        private int parentId;        //�����
        private string filePath;     //�ļ�·��
        private int ifDelete;        //�Ƿ�ɾ��

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public  string FileName
        {
            get { return this.fileName; }
            set { this.fileName = value; }
        }
        public FileTypeInfo FileTyPe
        {
            get { return this.fileType; }
            set { this.fileType = value; }
        }
        public string Remark
        {
            get { return this.remark; }
            set { this.remark = value; }
        }
        public UserInfo FileOwner
        {
            get { return this.fileOwner; }
            set { this.fileOwner = value; }
        }
        public DateTime CreateDate
        {
            get { return this.createDate; }
            set { this.createDate = value; }
        }
        public int ParentId
        {
            get { return this.parentId; }
            set { this.parentId = value; }
        }
        public string FilePath
        {
            get { return this.filePath; }
            set { this.filePath = value; }
        }
        public int IfDelete
        {
            get { return this.ifDelete; }
            set { this.ifDelete = value; }
        }
    }
}

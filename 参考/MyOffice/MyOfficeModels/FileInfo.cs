/**
 * 文件基本信息类
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace MyOffice.Models
{
    [Serializable]
    public class FileInfo
    {
        private int id;          //文件编号
        private string fileName;     //文件名称
        private FileTypeInfo fileType;   //文件类型
        private string remark;       //备注
        private UserInfo fileOwner;    //文件创建者
        private DateTime createDate; //创建时间
        private int parentId;        //父结点
        private string filePath;     //文件路径
        private int ifDelete;        //是否删除

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

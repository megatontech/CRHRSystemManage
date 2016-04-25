/**
 * 文件附件基本信息表
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace MyOffice.Models
{
    [Serializable]
    public class AccessoryFileInfo
    {
        private int id;               //文件附件编号
        private FileInfo file;                 //文件
        private string accessoryName;          //文件附件名称
        private int accessorySize;             //文件附件大小
        private FileTypeInfo accessoryType;    //文件附件类型
        private DateTime createDate;           //文件附件创建日期
        private string accessoryPath;          //文件附件路径

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public FileInfo File
        {
            get { return this.file; }
            set { this.file = value; }
        }
        public string AccessoryName
        {
            get { return this.accessoryName; }
            set { this.accessoryName = value; }
        }
        public int AccessorySize
        {
            get { return this.accessorySize; }
            set { this.accessorySize = value; }
        }
        public FileTypeInfo AccessoryType
        {
            get { return this.accessoryType; }
            set { this.accessoryType = value; }
        }
        public DateTime CreateDate
        {
            get { return this.createDate; }
            set { this.createDate = value; }
        }
        public string AccessoryPath
        {
            get { return this.accessoryPath; }
            set { this.accessoryPath = value; }
        }
    }
}

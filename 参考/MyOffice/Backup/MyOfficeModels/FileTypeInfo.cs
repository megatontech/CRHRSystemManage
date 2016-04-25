/**
 * 文件类型基本信息类
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace MyOffice.Models
{
    [Serializable]
    public class FileTypeInfo
    {
        private int id;        //文件类型编号
        private string fileTypeName;   //文件类型名称
        private string fileTypeImage;  //文件类型图片
        private string fileTypeSuffix; //文件后缀

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public string FileTypeName
        {
            get { return this.fileTypeName; }
            set { this.fileTypeName = value; }
        }
        public string FileTypeImage
        {
            get { return this.fileTypeImage; }
            set { this.fileTypeImage = value; }
        }
        public string FileTypeSuffix
        {
            get { return this.fileTypeSuffix; }
            set { this.fileTypeSuffix = value; }
        }
    }
}

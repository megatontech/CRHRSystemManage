/**
 * �ļ����ͻ�����Ϣ��
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace MyOffice.Models
{
    [Serializable]
    public class FileTypeInfo
    {
        private int id;        //�ļ����ͱ��
        private string fileTypeName;   //�ļ���������
        private string fileTypeImage;  //�ļ�����ͼƬ
        private string fileTypeSuffix; //�ļ���׺

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

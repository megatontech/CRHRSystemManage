/**
 * �ļ�����������Ϣ��
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace MyOffice.Models
{
    [Serializable]
    public class AccessoryFileInfo
    {
        private int id;               //�ļ��������
        private FileInfo file;                 //�ļ�
        private string accessoryName;          //�ļ���������
        private int accessorySize;             //�ļ�������С
        private FileTypeInfo accessoryType;    //�ļ���������
        private DateTime createDate;           //�ļ�������������
        private string accessoryPath;          //�ļ�����·��

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

using System;
using System.Collections.Generic;
using System.Text;

namespace MyOffice.Models
{
    /// <summary>
    /// ��ǩ
    /// </summary>
    [Serializable]
    public class MyNote
    {
        private int id;//��ǩid
        private string noteTitle;//��ǩ����
        private string noteContent;//��ǩ����
        private DateTime createTime;//����ʱ��
        private UserInfo createUser;//������

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string NoteTitle
        {
            get { return noteTitle; }
            set { noteTitle = value; }
        }
        public string NoteContent
        {
            get { return noteContent; }
            set { noteContent = value; }
        }
        public DateTime CreateTime
        {
            get { return createTime; }
            set { createTime = value; }
        }
        public UserInfo CreateUser
        {
            get { return createUser; }
            set { createUser = value; }
        }
    }
}

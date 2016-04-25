using System;
using System.Collections.Generic;
using System.Text;

namespace MyOffice.Models
{
    /// <summary>
    /// 便签
    /// </summary>
    [Serializable]
    public class MyNote
    {
        private int id;//便签id
        private string noteTitle;//便签标题
        private string noteContent;//便签内容
        private DateTime createTime;//创建时间
        private UserInfo createUser;//创建者

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

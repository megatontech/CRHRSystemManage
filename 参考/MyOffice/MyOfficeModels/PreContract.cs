using System;
using System.Collections.Generic;
using System.Text;

namespace MyOffice.Models
{
    /// <summary>
    /// ԤԼ
    /// </summary>
    [Serializable]
   public class PreContract
    {
        private int id;//ԤԼ���Id
        private Schedule schedule;//�ճ�Id
        private UserInfo user;//ԤԼ��

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public Schedule Schedule
        {
            get { return schedule; }
            set { schedule = value; }
        }
        public UserInfo User
        {
            get { return user; }
            set { user = value; }
        }
    }
}

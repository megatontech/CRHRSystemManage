using System;
using System.Collections.Generic;
using System.Text;

namespace MyOffice.Models
{
    //�û�״̬��
    [Serializable]
    public class UserState
    {
        private int id;//״̬��ʶID
        private string userStateName;//�û�״̬��ϸ

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string UserStateName
        {
            get { return userStateName; }
            set { userStateName = value; }
        }
    }
}

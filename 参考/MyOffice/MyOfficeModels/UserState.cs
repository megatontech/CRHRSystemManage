using System;
using System.Collections.Generic;
using System.Text;

namespace MyOffice.Models
{
    //用户状态类
    [Serializable]
    public class UserState
    {
        private int id;//状态标识ID
        private string userStateName;//用户状态详细

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

using System;
using System.Collections.Generic;
using System.Text;
using MyOffice.Models;
using MyOffice.DAL;

namespace MyOffice.BLL
{
    public static class UserStateManager
    {
        /// <summary>
        /// 查询所有状态
        /// </summary>
        /// <returns></returns>
        public static IList<UserState> GetAllUserState()
        {
            return UserStateService.GetAllUserState();
        }
    }
}

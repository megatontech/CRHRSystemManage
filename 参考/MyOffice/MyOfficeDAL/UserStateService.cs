using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using MyOffice.Models;

namespace MyOffice.DAL
{
    public static class UserStateService
    {
        /// <summary>
        /// 查询所有状态
        /// </summary>
        /// <returns></returns>
        public static IList<UserState> GetAllUserState()
        {
            IList<UserState> list = new List<UserState>();
            string sql = "select * from VW_UserStateAll";
            DataTable dt = DBHelper.ExecuteGetDataTable(CommandType.Text, sql, null);
            foreach (DataRow dr in dt.Rows)
            {
                UserState us = new UserState();
                us.Id = int.Parse(dr["Id"].ToString());
                us.UserStateName = dr["UserStateName"].ToString();
                list.Add(us);
            }
            return list;
        }
    }
}

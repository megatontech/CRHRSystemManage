using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using MyOffice.Models;

namespace MyOffice.DAL
{
    public static class MessageTypeService
    {
        #region 查询
        /// <summary>
        /// 查询所有消息类型
        /// </summary>
        /// <returns>所有消息List</returns>
        public static List<MessageType> GetMessageType()
        {
            string sql = "select * from MessageType";

            List<MessageType> list = new List<MessageType>();
            using (SqlDataReader dr = DBHelper.ExecuteGetReader(CommandType.Text, sql, null))
            {
                while (dr.Read())
                {
                    MessageType messageType = new MessageType();

                    messageType.Id = (int)dr["Id"];
                    messageType.MessageTypeName = dr["MessageTypeName"].ToString();
                    messageType.MessageDesc = dr["MessageDesc"].ToString();

                    list.Add(messageType);
                }
            }
            return list;
        }
        #endregion
    }
}

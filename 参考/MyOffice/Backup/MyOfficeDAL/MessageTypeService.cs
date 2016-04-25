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
        #region ��ѯ
        /// <summary>
        /// ��ѯ������Ϣ����
        /// </summary>
        /// <returns>������ϢList</returns>
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

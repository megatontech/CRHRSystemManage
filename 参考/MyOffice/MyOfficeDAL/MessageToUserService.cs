using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using MyOffice.Models;
namespace MyOffice.DAL
{
    public static class MessageToUserService
    {
        #region 查询
        /// <summary>
        /// 得到新信息条数
        /// </summary>
        /// <param name="user">UserInfo</param>
        /// <returns>int</returns>
        public static int GetMessageCountByUser(UserInfo user)
        {
            string sql = "SELECT COUNT(*) FROM VW_MessageToUser_Message WHERE ToUserId=@ToUserId  AND IfPublish = 1 and IfRead=0 and ToUserIsDelete=0";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@ToUserId",user.Id)              
            };
            return (int)DBHelper.ExecuteScalar(CommandType.Text, sql, para);
        }
        /// <summary>
        /// 判断这条消息是否已被完全阅读
        /// </summary>
        /// <param name="user">UserInfo</param>
        /// <returns>int</returns>
        public static bool MessageIfReadByUser(int messageId)
        {
            string sql = "SELECT COUNT(*) FROM VW_MessageToUser_Message WHERE  MessageId=" + messageId + "  and IfRead=0 ";

            int count = Convert.ToInt32(DBHelper.ExecuteScalar(CommandType.Text, sql, null));
           if (count > 0)
               return false;
           else
               return true;
        }
        /// <summary>
        /// 判断这条消息是否已被完全删除
        /// </summary>
        /// <param name="user">UserInfo</param>
        /// <returns>int</returns>
        public static bool MessageIsDeleteByUser(int messageId)
        {
            string sql = "SELECT COUNT(*) FROM VW_MessageToUser_Message WHERE  MessageId=" + messageId + "  and ToUserIsDelete=0 ";

            int count = Convert.ToInt32(DBHelper.ExecuteScalar(CommandType.Text, sql, null));
            if (count > 0)
                return false;
            else
                return true;
        }
        /// <summary>
        /// 根据消息编号查询所有新消息
        /// </summary>
        /// <param name="id">消息编号</param>
        /// <returns>MessageToUser</returns>
        public static MessageToUser GetMessageToUserById(int id)
        {
            string sql = "select * from VW_MessageToUser_Message where Id=" + id + " and ToUserIsDelete=0 ";
            return GetMessageToUserAllBySql(sql);
        }
        /// <summary>
        /// 根据用户编号查询新消息
        /// </summary>
        /// <param name="userInfoId">用户编号</param>
        /// <returns>List</returns>
        public static List<MessageToUser> GetMessageToUserByUserInfoId(int userInfoId)
        {
            string sql = "select * from VW_MessageToUser_Message where ToUserId in (" + userInfoId + " ) and FromUserId <> " +
               userInfoId + " and IfPublish = 1  and ToUserIsDelete=0 ";//and IsDelete =0
            return GetMessageToUserBySql(sql);
        }
        /// <summary>
        /// 根据消息编号查询新消息
        /// </summary>
        /// <param name="Messageid">消息编号</param>
        /// <returns>MessageToUser</returns>
        public static List<MessageToUser> GetMessageToUserByMessageId(int Messageid)
        {
            string sql = "select * from VW_MessageToUser_Message where MessageId=" + Messageid + "  ";//and ToUserIsDelete=0
            return  GetMessageToUserBySql(sql);
        }
       
        /// <summary>
        /// 根据用户编号,开始时间和结束时间查询该时间内发送的消息
        /// </summary>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="userid">用户编号</param>
        /// <returns>List</returns>
        public static List<MessageToUser> GetMessageToUserByDateTimeAndUserId(DateTime beginTime, DateTime endTime, string userid)
        {
            string sql = "select * from VW_MessageToUser_Message where LoginId='" + userid + "' and  RecordTime between '" + beginTime + "' and '" + endTime + "' and IsDelete =0 ";
            return GetMessageToUserBySql(sql);
        }
        /// <summary>
        /// 这条消息是否发送给所有人
        /// </summary>
        /// <param name="MessageId"></param>
        /// <returns></returns>
        public static int GetToUserIdCount(int MessageId)
        {
            string sql = "select Count(ToUserId) from VW_MessageToUser_Message where messageId=" + MessageId + "";
            return Convert.ToInt32( DBHelper.ExecuteScalar(CommandType.Text, sql, null));
        }
        /// <summary>
        /// 根据用户id和当前时间获得有效时间内的所有收到邮件数量
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <param name="AvailTime">当前时间</param>
        /// <returns>int</returns>
        public static int GetReceiveMessageCountByUserId(int userId)
        {
            string sql = "select count(*) from VW_MessageToUser_Message where " +
              "IfPublish = 1 and ToUserId=" + userId + " and FromUserId <> " + userId + " and ToUserIsDelete=0 ";
            int result = Convert.ToInt32(DBHelper.ExecuteScalar(CommandType.Text, sql, null));          
            return result;
        }
        /// <summary>
        /// 根据用户id和当前时间获得有效时间内的所有收到未读邮件数量
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <param name="AvailTime">当前时间</param>
        /// <returns>int</returns>
        public static int GetUnReadReceiveMessageCountByUserId(int userId)
        {
            //得到该用户接收到的未读特定消息数量
            string sql = "select count(*) from VW_MessageToUser_Message where " +
                "IfPublish = 1 and ToUserId=" + userId + " and FromUserId <> " + userId + " " +
                "and IfRead=0 and ToUserIsDelete=0 ";
            int result = Convert.ToInt32(DBHelper.ExecuteScalar(CommandType.Text, sql, null));
          
            return result;
        }
       
        /// <summary>
        /// 根据SQL语句查询新消息
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>List</returns>
        public static List<MessageToUser> GetMessageToUserBySql(string sql)
        {
            List<MessageToUser> list = new List<MessageToUser>();
            using (SqlDataReader dr = DBHelper.ExecuteGetReader(CommandType.Text, sql, null))
            {
                while (dr.Read())
                {
                    MessageToUser messageToUser = new MessageToUser();
                    messageToUser.Id = (int)dr["Id"];
                    messageToUser.IfRead = Convert.ToInt32(dr["IfRead"]);
                    /****--messageToUser.Message--********/
                    Message message = new Message();
                    message.Id = (int)dr["MessageId"];
                    message.Title = dr["Title"].ToString();
                    message.MessageContent = dr["MessageContent"].ToString();

                    MessageType mtype = new MessageType();
                    mtype.Id = (int)dr["MessageTypeId"];
                    mtype.MessageTypeName = dr["MessageTypeName"].ToString();
                    message.MessageType = mtype;

                    message.BeginTime = (DateTime)dr["BeginTime"];
                    message.EndTime = (DateTime)dr["EndTime"];

                    UserInfo user = new UserInfo();
                    user.Id = (int)dr["FromUserId"];
                    user.UserName = dr["FromUserName"].ToString();
                    message.FromUser = user;

                    message.IfPublish = Convert.ToInt32(dr["IfPublish"]);
                    message.RecordTime = (DateTime)dr["RecordTime"];
                    message.IsDelete = Convert.ToInt32(dr["IsDelete"]);
                    messageToUser.Message = message;
                    /**************************************/
                    UserInfo userinfo = new UserInfo();
                    userinfo.Id = (int)dr["ToUserId"];
                    userinfo.UserName = dr["ToUserName"].ToString();
                    messageToUser.ToUser = userinfo;

                    list.Add(messageToUser);
                }
            }
            return list;
        }
        /// <summary>
        /// 根据SQL语句查询新消息
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>MessageToUser</returns>
        public static MessageToUser GetMessageToUserAllBySql(string sql)
        {
            MessageToUser messageToUser = new MessageToUser();
            using (SqlDataReader dr = DBHelper.ExecuteGetReader(CommandType.Text, sql, null))
            {
                while (dr.Read())
                {
                    messageToUser.Id = (int)dr["Id"];
                    messageToUser.IfRead = Convert.ToInt32(dr["IfRead"]);
                    /****--messageToUser.Message--********/
                    Message message = new Message();
                    message.Id = (int)dr["MessageId"];
                    message.Title = dr["Title"].ToString();
                    message.MessageContent = dr["MessageContent"].ToString();

                    MessageType mtype = new MessageType();
                    mtype.Id = (int)dr["MessageTypeId"];
                    mtype.MessageTypeName = dr["MessageTypeName"].ToString();
                    message.MessageType = mtype;

                    message.BeginTime = (DateTime)dr["BeginTime"];
                    message.EndTime = (DateTime)dr["EndTime"];

                    UserInfo user = new UserInfo();
                    user.Id = (int)dr["FromUserId"];
                    user.UserName = dr["FromUserName"].ToString();
                    message.FromUser = user;

                    message.IfPublish = Convert.ToInt32(dr["IfPublish"]);
                    message.RecordTime = (DateTime)dr["RecordTime"];
                    message.IsDelete = Convert.ToInt32(dr["IsDelete"]);
                    messageToUser.Message = message;
                    /**************************************/
                    UserInfo userinfo = new UserInfo();
                    userinfo.Id = (int)dr["ToUserId"];
                    userinfo.UserName = dr["ToUserName"].ToString();
                    messageToUser.ToUser = userinfo;
                }
            }
            return messageToUser;
        }
        #endregion

        #region 添加
        /// <summary>
        /// 添加新信息
        /// </summary>
        /// <param name="messageToUser"></param>
        /// <returns>bool</returns>
        public static bool AddMessageToUser(MessageToUser messageToUser)
        {
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@MessageId", messageToUser.Message.Id),
                new SqlParameter("@ToUserId", messageToUser.ToUser.Id),
                new SqlParameter("@IfRead", messageToUser.IfRead),
                new SqlParameter("@IsDelete", messageToUser.IsDelete)
            };
            int i = DBHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_AddMessageToUser", para);
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 删除
        /// <summary>
        /// 根据编号删除新消息
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>bool</returns>
        public static bool DelectMessageToUserById(int id)
        {
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@Id",id)              
            };
            int i = DBHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_DelectMessageToUser", para);
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 根据消息编号删除新消息
        /// </summary>
        /// <param name="messageId">消息编号</param>
        /// <returns>bool</returns>
        public static bool DelectMessageToUserByMessageId(int messageId)
        {
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@MessageId",messageId)              
            };
            int i = DBHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_DelectMessageToUserByMessageId", para);
            if (i >0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 修改
        /// <summary>
        /// 修改新消息
        /// </summary>
        /// <param name="messageToUser">消息</param>
        /// <returns>bool</returns>
        public static bool ModifyMessageToUser(MessageToUser messageToUser)
        {
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@Id", messageToUser.Id),
                new SqlParameter("@MessageId", messageToUser.Message.Id),
                new SqlParameter("@ToUserId", messageToUser.ToUser.Id),
                new SqlParameter("@IfRead", messageToUser.IfRead),
                 new SqlParameter("@IsDetele", messageToUser.IsDelete)
            };
            int i = DBHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_ModifyMessageToUser", para);
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 修改新消息
        /// </summary>
        /// <param name="messageToUser">消息</param>
        /// <returns>bool</returns>
        public static bool ModifyMessageToUserIfReadById(int id, int ifRead)
        {
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@Id", id),
                new SqlParameter("@IfRead", ifRead)
            };
            int i = DBHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_ModifyMessageToUserIfReadById", para);
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using MyOffice.Models;

namespace MyOffice.DAL
{
    public static class MessageService
    {

        #region 查询
        /// <summary>
        /// 查询所有消息
        /// </summary>
        /// <returns>List</returns>
        public static List<Message> GetMessage()
        {
            string sql = "select * from VW_MessageAll";
            return GetMessageBySql(sql);
        }
        /// <summary>
        /// 根据编号查询消息
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>Message</returns>
        public static Message GetMessageById(int id)
        {
            string sql = "select * from VW_MessageAll where id=" + id + "";
            return GetMessageAllBySql(sql);
        }
        /// <summary>
        /// 根据人员编号查询已发送消息
        /// </summary>
        /// <param name="id">人员编号</param>
        /// <returns>List</returns>
        public static List<Message> GetMessageByUserInfoId(int UserInfoId)
        {
            string sql = "select * from VW_MessageAll where FromUserId =" + UserInfoId + " and IfPublish=1 and IsDelete =0";
            return GetMessageBySql(sql);
        }
        /// <summary>
        /// 根据消息类型编号查询该类型的消息
        /// </summary>
        /// <param name="MessageTypeid">消息类型编号</param>
        /// <returns>List</returns>
        public static List<Message> GetMessageByMessageTypeId(int MessageTypeid)
        {
            string sql = "select * from VW_MessageAll where MessageTypeId =" + MessageTypeid + "";
            return GetMessageBySql(sql);
        }
        /// <summary>
        /// 根据开始时间和结束时间查询该时间内发送的消息
        /// </summary>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns>List</returns>
        public static List<Message> GetMessageByDateTime(DateTime beginTime, DateTime endTime)
        {
            string sql = "select * from VW_MessageAll where RecordTime between '" + beginTime + "' and '" + endTime.AddDays(1) + "' and IsDelete =0";
            return GetMessageBySql(sql);
        }
        /// <summary>
        /// 根据登陆名,开始时间和结束时间查询该时间内发送的消息
        /// </summary>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="userid">登陆名</param>
        /// <returns>List</returns>
        public static List<Message> GetMessageByDateTimeAndUserId(DateTime beginTime, DateTime endTime, int userid)
        {
            string sql = "select * from VW_MessageAll where FromUserId=" + userid + " and RecordTime between '" +
                beginTime + "' and '" + endTime.AddDays(1) + "'  and IsDelete =0 ";
            return GetMessageBySql(sql);
        }
        /// <summary>
        /// 根据登陆名查询用户发送的消息数量
        /// </summary>
        /// <param name="userid">登陆名</param>
        /// <returns>int</returns>
        public static int GetCountMessageByLoginId(string loginId)
        {
            string sql = "select count(*) from VW_MessageAll where LoginId='" + loginId + "' and IfPublish = 1";
            return Convert.ToInt32(DBHelper.ExecuteScalar(CommandType.Text, sql, null));
        }
        /// <summary>
        /// 根据用户id和当前时间获得有效时间内的所有发送邮件数量
        /// </summary>
        /// <param name="userId">用户id</param>       
        /// <returns>int</returns>
        public static int GetSendMessageCountByUserId(int userId)
        {
            string sql = "select count(*) from VW_MessageAll where FromUserId=" + userId +
                " and IfPublish=1 and IsDelete =0";// and IsDelete =0
            return Convert.ToInt32(DBHelper.ExecuteScalar(CommandType.Text, sql, null));
        }
        /// <summary>
        /// 根据用户id和当前时间获得有效时间内的没有发布邮件数量
        /// </summary>
        /// <param name="userId">用户id</param>      
        /// <returns>int</returns>
        public static int GetDraftFilesMessageCountByUserId(int userId)
        {
            string sql = "select count(*) from VW_MessageAll where FromUserId=" + userId +
                " and IfPublish=0 and IsDelete =0 ";//and IsDelete =0 
            return Convert.ToInt32(DBHelper.ExecuteScalar(CommandType.Text, sql, null));
        }
        /// <summary>
        /// 根据用户id和当前时间获得有效时间内的没有发布邮件
        /// </summary>
        /// <param name="userId">用户id</param>       
        /// <returns>List<Message></returns>
        public static List<Message> GetDraftFilesMessageByUserId(int userId)
        {
            string sql = "select * from VW_MessageAll where FromUserId=" + userId +
                " and IfPublish=0 and IsDelete =0 ";//
            return GetMessageBySql(sql);
        }
        /// <summary>
        /// 根据用户id和当前时间获得有效时间内的已删除邮件
        /// </summary>
        /// <param name="userId">用户id</param>     
        /// <returns>List<Message></returns>
        public static List<Message> GetDeleteFilesMessageByUserId(int userId)
        {
            string sql = "select * from VW_MessageToUser_Message where"+
 " (IsDelete=1  and FromUserId=" + userId + ") or (ToUserIsDelete=1 and ToUserId=" + userId + ") ";
            List<Message> list = new List<Message>();
            using (SqlDataReader dr = DBHelper.ExecuteGetReader(CommandType.Text, sql, null))
            {
                while (dr.Read())
                {
                    Message message = new Message();
                    message.Id = (int)dr["MessageId"];
                    message.Title = dr["Title"].ToString();
                    message.MessageContent = dr["MessageContent"].ToString();
                    UserInfo user = new UserInfo();
                    user.Id = (int)dr["FromUserId"];
                    user.UserName = dr["FromUserName"].ToString();
                    message.FromUser = user;
                    MessageType mtype = new MessageType();
                    mtype.Id = (int)dr["MessageTypeId"];
                    mtype.MessageTypeName = dr["MessageTypeName"].ToString();
                    message.MessageType = mtype;

                    message.BeginTime = (DateTime)dr["BeginTime"];
                    message.EndTime = (DateTime)dr["EndTime"];
                    list.Add(message);
                }
            }
            return list;
        }
        /// <summary>
        /// 根据SQL语句查询消息表中的信息
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>List</returns>
        public static List<Message> GetMessageBySql(string sql)
        {
            List<Message> list = new List<Message>();
            using (SqlDataReader dr = DBHelper.ExecuteGetReader(CommandType.Text, sql, null))
            {
                while (dr.Read())
                {
                    Message message = new Message();
                    message.Id = (int)dr["Id"];
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

                    list.Add(message);
                }
            }
            return list;
        }
        /// <summary>
        /// 根据SQL语句查询消息表中的信息
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>List</returns>
        public static Message GetMessageAllBySql(string sql)
        {
            Message message = new Message();
            using (SqlDataReader dr = DBHelper.ExecuteGetReader(CommandType.Text, sql, null))
            {
                while (dr.Read())
                {
                    message.Id = (int)dr["Id"];
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
                }
            }
            return message;
        }
        #endregion

        #region 添加
        /// <summary>
        /// 添加消息,并返回消息编号
        /// </summary>
        /// <param name="message">消息</param>
        /// <returns>int</returns>
        public static int AddMessage(Message message)
        {
            try
            {
                SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@Title", message.Title),
                new SqlParameter("@MessageContent", message.MessageContent),
                new SqlParameter("@MessageType", message.MessageType.Id), 
                new SqlParameter("@BeginTime", message.BeginTime), 
                new SqlParameter("@EndTime", message.EndTime), 
                new SqlParameter("@FromUser", message.FromUser.Id), 
                new SqlParameter("@IfPublish", message.IfPublish), 
                new SqlParameter("@RecordTime", message.RecordTime), 
                new SqlParameter("@IsDelete", message.IsDelete)
            };
                int i = int.Parse(DBHelper.ExecuteScalar(CommandType.StoredProcedure, "proc_AddMessage", para).ToString());
                return i;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }
        #endregion

        #region 删除
        /// <summary>
        /// 根据编号删除消息
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>bool</returns>
        public static bool DeleteMessageById(int id)
        {
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@Id", id)
            };
            int i = DBHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_DeleteMessageById", para);
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

        #region 修改
        /// <summary>
        /// 修改消息
        /// </summary>
        /// <param name="message">消息</param>
        /// <returns></returns>
        public static bool ModifyMessageById(Message message)
        {
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@Id", message.Id),
                new SqlParameter("@Title", message.Title),
                new SqlParameter("@MessageContent", message.MessageContent),
                new SqlParameter("@MessageType", message.MessageType.Id), 
                new SqlParameter("@BeginTime", message.BeginTime), 
                new SqlParameter("@EndTime", message.EndTime), 
                new SqlParameter("@FromUser", message.FromUser.Id), 
                new SqlParameter("@IfPublish", message.IfPublish), 
                new SqlParameter("@RecordTime", message.RecordTime), 
                new SqlParameter("@IsDelete", message.IsDelete)
            };
            int i = DBHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_ModifyMessageById", para);
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
        /// 根据消息编号将消息修改为已发布
        /// </summary>
        /// <param name="id">消息编号</param>
        /// <param name="IsPublish">是否已发布</param>
        /// <returns>bool</returns>
        public static bool ModifyMessageIsPublishById(int id, int IsPublish)
        {
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@Id", id),
                new SqlParameter("@IsPublish", IsPublish)
            };
            int i = DBHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_ModifyMessageIsPublishById", para);
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
        /// 根据消息编号将消息修改为已删除
        /// </summary>
        /// <param name="id">消息编号</param>
        /// <param name="IsPublish">是否已删除</param>
        /// <returns>bool</returns>
        public static bool ModifyMessageIsDeleteById(int id, int isDelete)
        {
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@Id", id),
                new SqlParameter("@IsDelete", isDelete)
            };
            int i = DBHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_ModifyMessageIsDeleteById", para);
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

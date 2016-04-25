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

        #region ��ѯ
        /// <summary>
        /// ��ѯ������Ϣ
        /// </summary>
        /// <returns>List</returns>
        public static List<Message> GetMessage()
        {
            string sql = "select * from VW_MessageAll";
            return GetMessageBySql(sql);
        }
        /// <summary>
        /// ���ݱ�Ų�ѯ��Ϣ
        /// </summary>
        /// <param name="id">���</param>
        /// <returns>Message</returns>
        public static Message GetMessageById(int id)
        {
            string sql = "select * from VW_MessageAll where id=" + id + "";
            return GetMessageAllBySql(sql);
        }
        /// <summary>
        /// ������Ա��Ų�ѯ�ѷ�����Ϣ
        /// </summary>
        /// <param name="id">��Ա���</param>
        /// <returns>List</returns>
        public static List<Message> GetMessageByUserInfoId(int UserInfoId)
        {
            string sql = "select * from VW_MessageAll where FromUserId =" + UserInfoId + " and IfPublish=1 and IsDelete =0";
            return GetMessageBySql(sql);
        }
        /// <summary>
        /// ������Ϣ���ͱ�Ų�ѯ�����͵���Ϣ
        /// </summary>
        /// <param name="MessageTypeid">��Ϣ���ͱ��</param>
        /// <returns>List</returns>
        public static List<Message> GetMessageByMessageTypeId(int MessageTypeid)
        {
            string sql = "select * from VW_MessageAll where MessageTypeId =" + MessageTypeid + "";
            return GetMessageBySql(sql);
        }
        /// <summary>
        /// ���ݿ�ʼʱ��ͽ���ʱ���ѯ��ʱ���ڷ��͵���Ϣ
        /// </summary>
        /// <param name="beginTime">��ʼʱ��</param>
        /// <param name="endTime">����ʱ��</param>
        /// <returns>List</returns>
        public static List<Message> GetMessageByDateTime(DateTime beginTime, DateTime endTime)
        {
            string sql = "select * from VW_MessageAll where RecordTime between '" + beginTime + "' and '" + endTime.AddDays(1) + "' and IsDelete =0";
            return GetMessageBySql(sql);
        }
        /// <summary>
        /// ���ݵ�½��,��ʼʱ��ͽ���ʱ���ѯ��ʱ���ڷ��͵���Ϣ
        /// </summary>
        /// <param name="beginTime">��ʼʱ��</param>
        /// <param name="endTime">����ʱ��</param>
        /// <param name="userid">��½��</param>
        /// <returns>List</returns>
        public static List<Message> GetMessageByDateTimeAndUserId(DateTime beginTime, DateTime endTime, int userid)
        {
            string sql = "select * from VW_MessageAll where FromUserId=" + userid + " and RecordTime between '" +
                beginTime + "' and '" + endTime.AddDays(1) + "'  and IsDelete =0 ";
            return GetMessageBySql(sql);
        }
        /// <summary>
        /// ���ݵ�½����ѯ�û����͵���Ϣ����
        /// </summary>
        /// <param name="userid">��½��</param>
        /// <returns>int</returns>
        public static int GetCountMessageByLoginId(string loginId)
        {
            string sql = "select count(*) from VW_MessageAll where LoginId='" + loginId + "' and IfPublish = 1";
            return Convert.ToInt32(DBHelper.ExecuteScalar(CommandType.Text, sql, null));
        }
        /// <summary>
        /// �����û�id�͵�ǰʱ������Чʱ���ڵ����з����ʼ�����
        /// </summary>
        /// <param name="userId">�û�id</param>       
        /// <returns>int</returns>
        public static int GetSendMessageCountByUserId(int userId)
        {
            string sql = "select count(*) from VW_MessageAll where FromUserId=" + userId +
                " and IfPublish=1 and IsDelete =0";// and IsDelete =0
            return Convert.ToInt32(DBHelper.ExecuteScalar(CommandType.Text, sql, null));
        }
        /// <summary>
        /// �����û�id�͵�ǰʱ������Чʱ���ڵ�û�з����ʼ�����
        /// </summary>
        /// <param name="userId">�û�id</param>      
        /// <returns>int</returns>
        public static int GetDraftFilesMessageCountByUserId(int userId)
        {
            string sql = "select count(*) from VW_MessageAll where FromUserId=" + userId +
                " and IfPublish=0 and IsDelete =0 ";//and IsDelete =0 
            return Convert.ToInt32(DBHelper.ExecuteScalar(CommandType.Text, sql, null));
        }
        /// <summary>
        /// �����û�id�͵�ǰʱ������Чʱ���ڵ�û�з����ʼ�
        /// </summary>
        /// <param name="userId">�û�id</param>       
        /// <returns>List<Message></returns>
        public static List<Message> GetDraftFilesMessageByUserId(int userId)
        {
            string sql = "select * from VW_MessageAll where FromUserId=" + userId +
                " and IfPublish=0 and IsDelete =0 ";//
            return GetMessageBySql(sql);
        }
        /// <summary>
        /// �����û�id�͵�ǰʱ������Чʱ���ڵ���ɾ���ʼ�
        /// </summary>
        /// <param name="userId">�û�id</param>     
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
        /// ����SQL����ѯ��Ϣ���е���Ϣ
        /// </summary>
        /// <param name="sql">SQL���</param>
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
        /// ����SQL����ѯ��Ϣ���е���Ϣ
        /// </summary>
        /// <param name="sql">SQL���</param>
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

        #region ���
        /// <summary>
        /// �����Ϣ,��������Ϣ���
        /// </summary>
        /// <param name="message">��Ϣ</param>
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

        #region ɾ��
        /// <summary>
        /// ���ݱ��ɾ����Ϣ
        /// </summary>
        /// <param name="id">���</param>
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

        #region �޸�
        /// <summary>
        /// �޸���Ϣ
        /// </summary>
        /// <param name="message">��Ϣ</param>
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
        /// ������Ϣ��Ž���Ϣ�޸�Ϊ�ѷ���
        /// </summary>
        /// <param name="id">��Ϣ���</param>
        /// <param name="IsPublish">�Ƿ��ѷ���</param>
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
        /// ������Ϣ��Ž���Ϣ�޸�Ϊ��ɾ��
        /// </summary>
        /// <param name="id">��Ϣ���</param>
        /// <param name="IsPublish">�Ƿ���ɾ��</param>
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

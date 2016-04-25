using System;
using System.Collections.Generic;
using System.Text;
using MyOffice.Models;
using MyOffice.DAL;

namespace MyOffice.BLL
{
    public static class MessageManager
    {

        #region 查询
        /// <summary>
        /// 查询所有消息
        /// </summary>
        /// <returns>List</returns>
        public static List<Message> GetMessage()
        {
            return MessageService.GetMessage();
        }
        /// <summary>
        /// 根据编号查询消息
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>Message</returns>
        public static Message GetMessageById(int id)
        {
            return MessageService.GetMessageById(id);
        }
        /// <summary>
        /// 根据人员编号查询已发送消息
        /// </summary>
        /// <param name="id">人员编号</param>
        /// <returns>List</returns>
        public static List<Message> GetMessageByUserInfoId(int UserInfoId)
        {
            return MessageService.GetMessageByUserInfoId(UserInfoId);
        }
        /// <summary>
        /// 根据消息类型编号查询该类型的消息
        /// </summary>
        /// <param name="MessageTypeid">消息类型编号</param>
        /// <returns>List</returns>
        public static List<Message> GetMessageByMessageTypeId(int MessageTypeid)
        {
            return MessageService.GetMessageByMessageTypeId(MessageTypeid);
        }
        /// <summary>
        /// 根据开始时间和结束时间查询该时间内发送的消息
        /// </summary>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns>List</returns>
        public static List<Message> GetMessageByDateTime(DateTime beginTime, DateTime endTime)
        {
            return MessageService.GetMessageByDateTime(beginTime, endTime);
        }
        /// <summary>
        /// 根据用户编号,开始时间和结束时间查询该时间内发送的消息
        /// </summary>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="userid">用户编号</param>
        /// <returns>List</returns>
        public static List<Message> GetMessageByDateTimeAndUserId(DateTime beginTime, DateTime endTime, int userid)
        {
            return MessageService.GetMessageByDateTimeAndUserId(beginTime, endTime, userid);
        }
        /// <summary>
        /// 根据登陆名查询用户发送的消息数量
        /// </summary>
        /// <param name="userid">登陆名</param>
        /// <returns>int</returns>
        public static int GetCountMessageByLoginId(string loginId)
        {
            return MessageService.GetCountMessageByLoginId(loginId);
        }
        /// <summary>
        /// 根据用户id和当前时间获得有效时间内的所有发送邮件数量
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <param name="AvailTime">当前时间</param>
        /// <returns>int</returns>
        public static int GetSendMessageCountByUserId(int userId)
        {
            return MessageService.GetSendMessageCountByUserId(userId);
        }
         /// <summary>
        /// 根据用户id和当前时间获得有效时间内的没有发送邮件数量
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <param name="AvailTime">当前时间</param>
        /// <returns>int</returns>
        public static int GetDraftFilesMessageCountByUserId(int userId)
        {
            return MessageService.GetDraftFilesMessageCountByUserId(userId);
        }
        /// <summary>
        /// 根据用户id和当前时间获得有效时间内的没有发布邮件
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <param name="AvailTime">当前时间</param>
        /// <returns>List<Message></returns>
        public static List<Message> GetDraftFilesMessageByUserId(int userId)
        {
            return MessageService.GetDraftFilesMessageByUserId(userId);
        }
         /// <summary>
        /// 根据用户id和当前时间获得有效时间内的已删除邮件
        /// </summary>
        /// <param name="userId">用户id</param>     
        /// <returns>List<Message></returns>
        public static List<Message> GetDeleteFilesMessageByUserId(int userId)
        {
            return MessageService.GetDeleteFilesMessageByUserId(userId);
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
            return MessageService.AddMessage(message);
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
            return MessageService.DeleteMessageById(id);
        }
        #endregion

        #region 修改
        /// <summary>
        /// 修改消息
        /// </summary>
        /// <param name="message">消息</param>
        /// <returns>bool</returns>
        public static bool ModifyMessageById(Message message)
        {
            return MessageService.ModifyMessageById(message);
        }
        /// <summary>
        /// 根据消息编号将消息修改为已发布
        /// </summary>
        /// <param name="id">消息编号</param>
        /// <param name="IsPublish">是否已发布</param>
        /// <returns>bool</returns>
        public static bool ModifyMessageIsPublishById(int id, int IsPublish)
        {
            return MessageService.ModifyMessageIsPublishById(id, IsPublish);
        }
         /// <summary>
        /// 根据消息编号将消息修改为已发布
        /// </summary>
        /// <param name="id">消息编号</param>
        /// <param name="IsPublish">是否已发布</param>
        /// <returns>bool</returns>
        public static bool ModifyMessageIsDeleteById(int id,int isDelete)
        {
            return MessageService.ModifyMessageIsDeleteById(id, isDelete);
        }
        #endregion
    }
}

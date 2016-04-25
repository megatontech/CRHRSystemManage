using System;
using System.Collections.Generic;
using System.Text;
using MyOffice.DAL;
using MyOffice.Models;

namespace MyOffice.BLL
{
    public static class MessageToUserManager
    {
        #region 查询
        /// <summary>
        /// 得到新信息条数
        /// </summary>
        /// <param name="user">UserInfo</param>
        /// <returns>int</returns>
        public static int GetMessageCountByUser(UserInfo user)
        {
            return MessageToUserService.GetMessageCountByUser(user);
        }
         /// <summary>
        /// 判断这条消息是否已被完全阅读
        /// </summary>
        /// <param name="user">UserInfo</param>
        /// <returns>int</returns>
        public static bool MessageIfReadByUser(int messageId)
        {
            return MessageToUserService.MessageIfReadByUser(messageId);
        }
         /// <summary>
        /// 判断这条消息是否已被完全删除
        /// </summary>
        /// <param name="user">UserInfo</param>
        /// <returns>int</returns>
        public static bool MessageIsDeleteByUser(int messageId)
        {
          return MessageToUserService.MessageIsDeleteByUser(messageId);
        }
        /// <summary>
        /// 根据消息编号查询所有新消息
        /// </summary>
        /// <param name="id">消息编号</param>
        /// <returns>MessageToUser</returns>
        public static MessageToUser GetMessageToUserById(int id)
        {
            return MessageToUserService.GetMessageToUserById(id);
        } /// <summary>
        /// 这条消息是否发送给所有人
        /// </summary>
        /// <param name="MessageId"></param>
        /// <returns></returns>
        public static int GetToUserIdCount(int MessageId)
        {
            return MessageToUserService.GetToUserIdCount(MessageId);
        }
        /// <summary>
        /// 根据用户编号查询新消息
        /// </summary>
        /// <param name="UserInfoid">用户编号</param>
        /// <param name="AvailTime">当前时间</param>
        /// <returns>List</returns>
        public static List<MessageToUser> GetMessageToUserByUserInfoId(int UserInfoid)
        {
            return MessageToUserService.GetMessageToUserByUserInfoId(UserInfoid);
        }
        /// <summary>
        /// 根据消息编号查询新消息
        /// </summary>
        /// <param name="Messageid">消息编号</param>
        /// <returns>List<MessageToUser></returns>
        public static List<MessageToUser> GetMessageToUserByMessageId(int Messageid)
        {
            return MessageToUserService.GetMessageToUserByMessageId(Messageid);
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
            return MessageToUserService.GetMessageToUserByDateTimeAndUserId(beginTime, endTime, userid);
        }
        /// <summary>
        /// 根据用户id和当前时间获得有效时间内的所有收到邮件数量
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <param name="AvailTime">当前时间</param>
        /// <returns>int</returns>
        public static int GetReceiveMessageCountByUserId(int userId)
        {
            return MessageToUserService.GetReceiveMessageCountByUserId(userId);
        }
        /// <summary>
        /// 根据用户id和当前时间获得有效时间内的所有收到未读邮件数量
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <param name="AvailTime">当前时间</param>
        /// <returns>int</returns>
        public static int GetUnReadReceiveMessageCountByUserId(int userId)
        {
            return MessageToUserService.GetUnReadReceiveMessageCountByUserId(userId);
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
            return MessageToUserService.AddMessageToUser(messageToUser);
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
            return MessageToUserService.DelectMessageToUserById(id);
        }
        /// <summary>
        /// 根据消息编号删除新消息
        /// </summary>
        /// <param name="messageId">消息编号</param>
        /// <returns>bool</returns>
        public static bool DelectMessageToUserByMessageId(int messageId)
        {
            return MessageToUserService.DelectMessageToUserByMessageId(messageId);
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
            return MessageToUserService.ModifyMessageToUser(messageToUser);
        }
        /// <summary>
        /// 修改新消息
        /// </summary>
        /// <param name="messageToUser">消息</param>
        /// <returns>bool</returns>
        public static bool ModifyMessageToUserIfReadById(int id, int ifRead)
        {
            return MessageToUserService.ModifyMessageToUserIfReadById(id, ifRead);
        }
        #endregion
    }
}

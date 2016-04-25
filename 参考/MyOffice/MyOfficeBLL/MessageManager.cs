using System;
using System.Collections.Generic;
using System.Text;
using MyOffice.Models;
using MyOffice.DAL;

namespace MyOffice.BLL
{
    public static class MessageManager
    {

        #region ��ѯ
        /// <summary>
        /// ��ѯ������Ϣ
        /// </summary>
        /// <returns>List</returns>
        public static List<Message> GetMessage()
        {
            return MessageService.GetMessage();
        }
        /// <summary>
        /// ���ݱ�Ų�ѯ��Ϣ
        /// </summary>
        /// <param name="id">���</param>
        /// <returns>Message</returns>
        public static Message GetMessageById(int id)
        {
            return MessageService.GetMessageById(id);
        }
        /// <summary>
        /// ������Ա��Ų�ѯ�ѷ�����Ϣ
        /// </summary>
        /// <param name="id">��Ա���</param>
        /// <returns>List</returns>
        public static List<Message> GetMessageByUserInfoId(int UserInfoId)
        {
            return MessageService.GetMessageByUserInfoId(UserInfoId);
        }
        /// <summary>
        /// ������Ϣ���ͱ�Ų�ѯ�����͵���Ϣ
        /// </summary>
        /// <param name="MessageTypeid">��Ϣ���ͱ��</param>
        /// <returns>List</returns>
        public static List<Message> GetMessageByMessageTypeId(int MessageTypeid)
        {
            return MessageService.GetMessageByMessageTypeId(MessageTypeid);
        }
        /// <summary>
        /// ���ݿ�ʼʱ��ͽ���ʱ���ѯ��ʱ���ڷ��͵���Ϣ
        /// </summary>
        /// <param name="beginTime">��ʼʱ��</param>
        /// <param name="endTime">����ʱ��</param>
        /// <returns>List</returns>
        public static List<Message> GetMessageByDateTime(DateTime beginTime, DateTime endTime)
        {
            return MessageService.GetMessageByDateTime(beginTime, endTime);
        }
        /// <summary>
        /// �����û����,��ʼʱ��ͽ���ʱ���ѯ��ʱ���ڷ��͵���Ϣ
        /// </summary>
        /// <param name="beginTime">��ʼʱ��</param>
        /// <param name="endTime">����ʱ��</param>
        /// <param name="userid">�û����</param>
        /// <returns>List</returns>
        public static List<Message> GetMessageByDateTimeAndUserId(DateTime beginTime, DateTime endTime, int userid)
        {
            return MessageService.GetMessageByDateTimeAndUserId(beginTime, endTime, userid);
        }
        /// <summary>
        /// ���ݵ�½����ѯ�û����͵���Ϣ����
        /// </summary>
        /// <param name="userid">��½��</param>
        /// <returns>int</returns>
        public static int GetCountMessageByLoginId(string loginId)
        {
            return MessageService.GetCountMessageByLoginId(loginId);
        }
        /// <summary>
        /// �����û�id�͵�ǰʱ������Чʱ���ڵ����з����ʼ�����
        /// </summary>
        /// <param name="userId">�û�id</param>
        /// <param name="AvailTime">��ǰʱ��</param>
        /// <returns>int</returns>
        public static int GetSendMessageCountByUserId(int userId)
        {
            return MessageService.GetSendMessageCountByUserId(userId);
        }
         /// <summary>
        /// �����û�id�͵�ǰʱ������Чʱ���ڵ�û�з����ʼ�����
        /// </summary>
        /// <param name="userId">�û�id</param>
        /// <param name="AvailTime">��ǰʱ��</param>
        /// <returns>int</returns>
        public static int GetDraftFilesMessageCountByUserId(int userId)
        {
            return MessageService.GetDraftFilesMessageCountByUserId(userId);
        }
        /// <summary>
        /// �����û�id�͵�ǰʱ������Чʱ���ڵ�û�з����ʼ�
        /// </summary>
        /// <param name="userId">�û�id</param>
        /// <param name="AvailTime">��ǰʱ��</param>
        /// <returns>List<Message></returns>
        public static List<Message> GetDraftFilesMessageByUserId(int userId)
        {
            return MessageService.GetDraftFilesMessageByUserId(userId);
        }
         /// <summary>
        /// �����û�id�͵�ǰʱ������Чʱ���ڵ���ɾ���ʼ�
        /// </summary>
        /// <param name="userId">�û�id</param>     
        /// <returns>List<Message></returns>
        public static List<Message> GetDeleteFilesMessageByUserId(int userId)
        {
            return MessageService.GetDeleteFilesMessageByUserId(userId);
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
            return MessageService.AddMessage(message);
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
            return MessageService.DeleteMessageById(id);
        }
        #endregion

        #region �޸�
        /// <summary>
        /// �޸���Ϣ
        /// </summary>
        /// <param name="message">��Ϣ</param>
        /// <returns>bool</returns>
        public static bool ModifyMessageById(Message message)
        {
            return MessageService.ModifyMessageById(message);
        }
        /// <summary>
        /// ������Ϣ��Ž���Ϣ�޸�Ϊ�ѷ���
        /// </summary>
        /// <param name="id">��Ϣ���</param>
        /// <param name="IsPublish">�Ƿ��ѷ���</param>
        /// <returns>bool</returns>
        public static bool ModifyMessageIsPublishById(int id, int IsPublish)
        {
            return MessageService.ModifyMessageIsPublishById(id, IsPublish);
        }
         /// <summary>
        /// ������Ϣ��Ž���Ϣ�޸�Ϊ�ѷ���
        /// </summary>
        /// <param name="id">��Ϣ���</param>
        /// <param name="IsPublish">�Ƿ��ѷ���</param>
        /// <returns>bool</returns>
        public static bool ModifyMessageIsDeleteById(int id,int isDelete)
        {
            return MessageService.ModifyMessageIsDeleteById(id, isDelete);
        }
        #endregion
    }
}

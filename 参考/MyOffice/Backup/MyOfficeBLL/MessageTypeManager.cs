using System;
using System.Collections.Generic;
using System.Text;
using MyOffice.Models;
using MyOffice.DAL;

namespace MyOffice.BLL
{
    public static class MessageTypeManager
    {
        #region ��ѯ
        /// <summary>
        /// ��ѯ������Ϣ����
        /// </summary>
        /// <returns>������ϢList</returns>
        public static List<MessageType> GetMessageType()
        {
            return MessageTypeService.GetMessageType();
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using MyOffice.Models;
using MyOffice.DAL;

namespace MyOffice.BLL
{
    public static class MessageTypeManager
    {
        #region 查询
        /// <summary>
        /// 查询所有消息类型
        /// </summary>
        /// <returns>所有消息List</returns>
        public static List<MessageType> GetMessageType()
        {
            return MessageTypeService.GetMessageType();
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using MyOffice.DAL;
using MyOffice.Models;

namespace MyOffice.BLL
{
    public static class MeetingInfoManager
    {
        /// <summary>
        /// 查询会议名称
        /// </summary>
        /// <returns></returns>
        public static IList<MeetingInfo> GetAllMeeting()
        {
            return MeetingInfoService.GetAllMeeting();
        }
    }
}

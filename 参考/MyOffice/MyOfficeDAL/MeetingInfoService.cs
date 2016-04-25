using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using MyOffice.Models;
//[会议信息]
namespace MyOffice.DAL
{
    public static class MeetingInfoService
    {
        /// <summary>
        /// 查询会议名称
        /// </summary>
        /// <returns></returns>
        public static IList<MeetingInfo> GetAllMeeting()
        {
            string sql = "select * from MeetingInfo";
            IList<MeetingInfo> list = new List<MeetingInfo>();

            DataTable dt = DBHelper.ExecuteGetDataTable(CommandType.Text, sql, null);
            foreach (DataRow dr in dt.Rows)
            {
                MeetingInfo meetingInfo = new MeetingInfo();
                meetingInfo.Id=(int)dr["Id"];
                meetingInfo.MeetingName=(string)dr["MeetingName"];
                list.Add(meetingInfo);
            }
            return list;
        }
    }
}

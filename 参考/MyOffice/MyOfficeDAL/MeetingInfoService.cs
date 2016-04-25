using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using MyOffice.Models;
//[������Ϣ]
namespace MyOffice.DAL
{
    public static class MeetingInfoService
    {
        /// <summary>
        /// ��ѯ��������
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

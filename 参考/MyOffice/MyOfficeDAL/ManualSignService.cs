using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using MyOffice.Models;

namespace MyOffice.DAL
{
    public static class ManualSignService
    {
       /// <summary>
        ///根据用户Id和当前时间获得最大签到或签退信息
       /// </summary>
       /// <param name="userId"></param>
        /// <returns>ManualSign</returns>
        public static ManualSign GetMaxSignIdByUserId(int userId)
        {
            string sql = "SELECT  TOP 1 * FROM VW_ManualSignAll  WHERE DATEDIFF(day,SignTime,getdate())=0 and userId="
                + userId + " ORDER BY Id DESC";
            using (SqlDataReader dr = DBHelper.ExecuteGetReader(CommandType.Text, sql, null))
            {
                if (dr.Read())
                {
                    ManualSign sign = new ManualSign();
                    sign.Id = (int)dr["Id"];
                    sign.SignTag = (int)dr["SignTag"];
                    sign.SignDesc = dr["SignDesc"].ToString();
                    return sign;
                }
                return null;

            }
        }
        /// <summary>
        /// 添加考勤
        /// </summary>
        /// <param name="sign">ManualSign</param>
        /// <returns>bool</returns>
        public static bool AddManualSign(ManualSign sign)
        {
            SqlParameter[] para = new SqlParameter[] { 
                new SqlParameter("@UserId",sign.User.Id),
                new SqlParameter("@SignTime",DateTime.Now.ToString()),
                new SqlParameter("@SignDesc",sign.SignDesc),              
                new SqlParameter("@SignTag",sign.SignTag)
            };
            int count = DBHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_AddManualSign", para);
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 得到所有的考勤信息
        /// </summary>
        /// <param name="mix">DateTime</param>
        /// <param name="max">DateTime</param>
        /// <returns>IList<ManualSign></returns>
        public static IList<ManualSign> GetAllManualSignBySignTime(DateTime startTime, DateTime endTime) 
        {
            string sql = "select * from VW_ManualSignAndUserInfo WHERE SignTime between @startTime AND @endTime ORDER BY SignTime  DESC";
          
            SqlParameter[] para = new SqlParameter[] { 
                new SqlParameter("@startTime",startTime),
                new SqlParameter("@endTime",endTime)
            };
            return GetManualSignsBySql(CommandType.Text, sql, para);
            
        }
        private static IList<ManualSign> GetManualSignsBySql(CommandType commandType, string sql, params SqlParameter[] para)
        {
            List<ManualSign> list = new List<ManualSign>();
            using (SqlDataReader dr = DBHelper.ExecuteGetReader(CommandType.Text, sql, para))
            {
                while (dr.Read())
                {
                    ManualSign sign = new ManualSign();
                    sign.Id = (int)dr["Id"];
                    sign.SignTag = (int)dr["SignTag"];
                    sign.SignDesc = dr["SignDesc"].ToString();
                    sign.SignTime = (DateTime)dr["SignTime"];
                    UserInfo user = new UserInfo();
                    user.Id = (int)dr["UserId"];
                    user.LoginId = dr["LoginId"].ToString();
                    user.UserName = dr["UserName"].ToString();
                    DepartInfo depart = new DepartInfo();
                    depart.Id = (int)dr["DepartId"];
                    depart.DepartName = dr["DepartName"].ToString();
                    BranchInfo branch = new BranchInfo();
                    branch.Id = (int)dr["BranchId"];
                    branch.BranchName = dr["BranchName"].ToString();
                    depart.Branch = branch;
                    user.Depart = depart;
                    sign.User = user;
                    list.Add(sign);
                }
            }
            return list;
        }
        
        //根据所需条件查询所有考勤历史记录
        public static IList<ManualSign> GetManualSignsBySelectedConditions(DateTime startTime, DateTime endTime, string userName, int departId, int branchId)
        {
            string sqlDepartId = "";
            if (departId != 0)
            {
                sqlDepartId = " AND DepartId=" + departId + " ";
            }
            string sqlBranchId = "";
            if (branchId != 0)
            {
                sqlBranchId = " AND BranchId=" + branchId + " ";
            }

            string sqlUserName = "";
            if (userName != "")
            {
                sqlUserName = " AND UserName like '%" + userName + "%'";
            }
            string sql = "SELECT * FROM VW_ManualSignAndUserInfo WHERE  SignTime between '" + startTime + "' AND '" + endTime + "' ";
            sql += sqlDepartId;
            sql += sqlBranchId;

            sql += sqlUserName;
            sql += "ORDER BY BranchId, DepartId, UserName, SignTime DESC";
            return GetManualSignsBySql(CommandType.Text, sql, null);
        }
        /// <summary>
        /// 获得上下班时间
        /// </summary>
        /// <param name="dutyTag">上下班时间的列名</param>
        /// <returns>上下班时间</returns>
        public static string GetDutyTime(string dutyTag)
        {
            string sql = "SELECT " + dutyTag + " FROM  VW_WorkTimeAll WHERE Id=1";
            return DBHelper.ExecuteScalar(CommandType.Text, sql, null).ToString();           
        }
        /// <summary>
        /// 得到用户在一段时间内的迟到次数
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="startTime">查询开始时间</param>
        /// <param name="endTime">查询结束时间</param>
        /// <returns>迟到次数</returns>
        public static int GetUserArriveLates(int userId, DateTime startTime, DateTime endTime)
        {
            string onDutyTime = " " + GetDutyTime("OnDutyTime");//得到上班时间
            string sql = "SELECT count(*) FROM VW_ManualSignAll WHERE UserId = " +
                userId + " AND SignTime>Convert(DateTime,convert(varchar(10),SignTime,120)+'" +
                onDutyTime + "') AND SignTag=1 AND SignTime between Convert(DateTime,'" + startTime +
                "') AND Convert(DateTime,'" + endTime + "') ";
            int count = Convert.ToInt32(DBHelper.ExecuteScalar(CommandType.Text, sql, null));// -IsNotSundayAndSaturday(userId, startTime, endTime, 1);
            return count;
        }
        /// <summary>
        /// 得到用户在一段时间内的早退次数
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="startTime">查询开始时间</param>
        /// <param name="endTime">查询结束时间</param>
        /// <returns>早退次数</returns>       
        public static int GetUserLeaveEarlys(int userId, DateTime startTime, DateTime endTime)
        {
            string offDutyTime = " " + GetDutyTime("OffDutyTime");//得到下班时间

            string sql = "SELECT count(*) FROM VW_ManualSignAll WHERE UserId = " +
                userId + " AND SignTime<Convert(DateTime,convert(varchar(10),SignTime,120)+'" +
                offDutyTime + "') AND SignTag=0 AND SignTime between Convert(DateTime,'" +
                startTime + "') AND Convert(DateTime,'" + endTime + "') ";
            int count = Convert.ToInt32(DBHelper.ExecuteScalar(CommandType.Text, sql, null));// -IsNotSundayAndSaturday(userId, startTime, endTime, 0);
            return count;
        }
        /// <summary>
        /// 得到用户在一段时间内的旷工次数
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="startTime">查询开始时间</param>
        /// <param name="endTime">查询结束时间</param>
        /// <returns>旷工次数</returns>   
        public static int GetUserAbsences(int userId, DateTime startTime, DateTime endTime)
        {
            int totalDays = Datediff(startTime, endTime);

            string sql = "SELECT count(*) FROM VW_ManualSignAll WHERE UserId = " +
                userId + " AND SignTime between Convert(DateTime,'" +
                startTime + "') AND Convert(DateTime,'" + endTime + "')  AND SignTag=1";
            int count = Convert.ToInt32(DBHelper.ExecuteScalar(CommandType.Text, sql, null));

            int result = totalDays - count;
           // int result = totalDays - (count-IsNotSundayAndSaturday(userId,startTime,endTime,1) );
            return result;
        }
        /// <summary>
        /// 迟到和早退除去周六和周天
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="startTime">查询开始时间</param>
        /// <param name="endTime">查询结束时间</param>
        /// <param name="signTag">上下班的标记</param>
        /// <returns>int</returns>
        public static int IsNotSundayAndSaturday(int userId, DateTime startTime, DateTime endTime, int signTag) 
        {
            int count = 0;
            string sql1 = "SELECT SignTime FROM VW_ManualSignAll WHERE UserId = " +
              userId + " AND SignTime between Convert(DateTime,'" +
              startTime + "') AND Convert(DateTime,'" + endTime + "')  AND SignTag=" + signTag + "";
            using (SqlDataReader dr = DBHelper.ExecuteGetReader(CommandType.Text, sql1, null))
            {
                while (dr.Read())
                {

                    DateTime dtTemp = Convert.ToDateTime(dr["SignTime"]);
                    bool b=(dtTemp.DayOfWeek == DayOfWeek.Sunday) || (dtTemp.DayOfWeek == DayOfWeek.Saturday);
                    bool b1=false;
                    if (b)
                    {
                        if (signTag == 0)
                        {
                            b1 = DateTime.Parse(dtTemp.ToShortTimeString()) < DateTime.Parse("17:30");
                        }
                        else
                        {
                            b1 = DateTime.Parse(dtTemp.ToShortTimeString()) > DateTime.Parse("08:30");
                        }
                        if (b1)
                        {
                            count++;
                        }
                    }
                }
            }
            return count;
        }
        /// <summary>
        /// 得到用户在一段时间内的出勤率
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="startTime">查询开始时间</param>
        /// <param name="endTime">查询结束时间</param>
        /// <returns>出勤率</returns>   
        public static string GetUserAttendances(int userId, DateTime startTime, DateTime endTime)
        {
            string onDutyTime = " " + GetDutyTime("OnDutyTime");//得到上班时间
            string offDutyTime = " " + GetDutyTime("OffDutyTime");//得到下班时间
            string totalDays = Datediff(startTime, endTime).ToString();

            string sql = "SELECT count(*) FROM VW_ManualSignAll WHERE UserId = " +
                userId + " AND  SignTime<Convert(DateTime,convert(varchar(10),SignTime,120)+'" +
                onDutyTime + "') AND SignTime between Convert(DateTime,'" +
                startTime + "') AND Convert(DateTime,'" + endTime + "') AND SignTag=1";
            string attendDays = DBHelper.ExecuteScalar(CommandType.Text, sql, null).ToString();
            //int count = Convert.ToInt32(attendDays) -(IsNotSundayAndSaturday(userId, startTime, endTime, 1));
            int count = Convert.ToInt32(attendDays);//得到不迟到的天数

            ////得到签到了没签退的个数
            string sql2 = "SELECT count(*) FROM VW_ManualSignAll where" +
                            " SUBSTRING(convert(varchar(10),SignTime,120), 1, 10)" +
                            "in (SELECT  SUBSTRING(convert(varchar(10),SignTime,120), 1, 10) AS SignTime2" +
                            " FROM VW_ManualSignAll WHERE UserId =" + userId + "" +
                            " AND SignTime<Convert(DateTime,convert(varchar(10),SignTime,120)+' " + onDutyTime + "')" +
                            " AND SignTag=1)  and UserId =" + userId + " AND SignTag=0";
            int offDutyCount = Convert.ToInt32(DBHelper.ExecuteScalar(CommandType.Text, sql2, null));

            //得到早退次数
            int LeaveEarlys = GetUserLeaveEarlys(userId, startTime, endTime);//调用早退的方法

            //得到同天中及迟到又早退的天数
            string sql1 = "SELECT  Count(*) FROM VW_ManualSignAll WHERE UserId = " +
            userId + " AND SignTag=0 AND SignTime<Convert(DateTime,convert(varchar(10),SignTime,120)+'" +
            offDutyTime + "') AND SignTime between Convert(DateTime,'" +
               startTime + "') AND Convert(DateTime,'" + endTime + "')and " +
               "SUBSTRING(convert(varchar(10),SignTime,120), 1, 10) in ( SELECT  SUBSTRING(convert(varchar(10),SignTime,120), 1, 10) AS SignTime2"+
              " FROM VW_ManualSignAll WHERE UserId = " +
                userId + " AND SignTime>Convert(DateTime,convert(varchar(10),SignTime,120)+'"+
                 onDutyTime+"') AND SignTag=1 AND SignTime between Convert(DateTime,'"+
                  startTime+"') AND Convert(DateTime,'"+endTime+"'))";
            int EarlysCount =Convert.ToInt32( DBHelper.ExecuteScalar(CommandType.Text, sql1, null));

            if (count == 0) 
            {
                return 0 + "%";
            }
            //签到没迟到的次数减去没签退的个数和减去早退大于迟到的个数 
            double attendsPercent = Convert.ToDouble(count - (LeaveEarlys - EarlysCount) - (count - offDutyCount)) / double.Parse(totalDays) * 100.0;
            double result = Math.Round(attendsPercent, 2);
            return result.ToString() + "%";
        }
        /// <summary>
        /// 计算一共应该上多少天班
        /// </summary>
        /// <param name="startTime">查询开始时间</param>
        /// <param name="endTime">查询结束时间</param>
        /// <returns>上班天数</returns>
        private static int Datediff(DateTime startTime, DateTime endTime)
        {
            int result = 0;//返回值，即endTime和startTime之间的工作日数Datediff
            string sql = "select DATEDIFF(day,Convert(DateTime,'" + startTime + "') ,Convert(DateTime,'" + endTime + "'))";
            //计算endTime和startTime之间相差多少天
            int count = Convert.ToInt32(DBHelper.ExecuteScalar(CommandType.Text, sql, null));
            //循环判断日期的值是不是星期六或星期天，如果既不是星期六，天，则该天为工作日，result加1
            for (int i = 0; i < count; i++)
            {
                DateTime dtTemp = startTime.AddDays(i);
                if ((dtTemp.DayOfWeek != DayOfWeek.Sunday) && (dtTemp.DayOfWeek != DayOfWeek.Saturday))
                {
                    result++;
                }
            }
            return result;

        }
    }
}

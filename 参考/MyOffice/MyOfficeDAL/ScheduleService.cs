using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using MyOffice.Models;

namespace MyOffice.DAL
{
    public static class ScheduleService
    {
        /// <summary>
        /// 查询日程信息
        /// </summary>
        /// <returns></returns>
        public static IList<Schedule> GetSchedule()
        {
            string sql = "select * from vw_ScheduleAll";
            List<Schedule> list = new List<Schedule>();

            using (DataTable dt = DBHelper.ExecuteGetDataTable(CommandType.Text, sql, null))
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Schedule schedule = new Schedule();  //日程信息
                    schedule.Id = (int)dr["Id"];  //日程ID
                    schedule.Title = (string)dr["Title"];  //主题
                    schedule.Address = (string)dr["Address"];  //地点
                    MeetingInfo meetingInfo = new MeetingInfo();  //会议信息
                    meetingInfo.Id = (int)dr["MeetingId"];  //ID
                    meetingInfo.MeetingName = (string)dr["MeetingName"]; //会议名称
                    schedule.Meeting = meetingInfo;
                    schedule.BeginTime = (DateTime)dr["BeginTime"]; //开始时间
                    schedule.EndTime = (DateTime)dr["EndTime"];  //结束时间
                    schedule.SchContent = (string)dr["SchContent"]; //内容
                    UserInfo userInfo = new UserInfo();  //用户信息
                    userInfo.Id = (int)dr["CreateUserId"]; //创建人ID
                    userInfo.UserName = (string)dr["CreateUserName"]; //创建人姓名
                    schedule.CreateUserId = userInfo;
                    schedule.CreateTime = (DateTime)dr["CreateTime"]; //创建时间
                    schedule.IfPrivate = Convert.ToInt32(dr["IfPrivate"]);  //是否公开
                    list.Add(schedule);  //把日程信息添加到集合中
                }
            }
            return list;
        }


        /// <summary>
        /// 根据实体添加个人日程信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int AddSchedule(Schedule schedule)
        {
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@Title",schedule.Title),
                new SqlParameter("@Address",schedule.Address),
                new SqlParameter("@MeetingId",schedule.Meeting.Id),
                new SqlParameter("@BeginTime",schedule.BeginTime),
                new SqlParameter("@EndTime",schedule.EndTime),
                new SqlParameter("@SchContent",schedule.SchContent),
                new SqlParameter("@CreateUserId",schedule.CreateUserId.Id),
                new SqlParameter("@CreateTime",schedule.CreateTime),
                new SqlParameter("@IfPrivate",schedule.IfPrivate)
            };
            return Convert.ToInt32(DBHelper.ExecuteScalar(CommandType.StoredProcedure, "Proc_AddSchedule", para));
        }

        /// <summary>
        /// 修改日程信息
        /// </summary>
        /// <param name="schedule"></param>
        /// <returns></returns>
        public static bool ModifySchedule(Schedule schedule)
        {
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@Id",schedule.Id),
                new SqlParameter("@Title",schedule.Title),
                new SqlParameter("@Address",schedule.Address),
                new SqlParameter("@MeetingId",schedule.Meeting.Id),
                new SqlParameter("@BeginTime",schedule.BeginTime),
                new SqlParameter("@EndTime",schedule.EndTime),
                new SqlParameter("@SchContent",schedule.SchContent),
                new SqlParameter("@CreateUserId",schedule.CreateUserId.Id),
                new SqlParameter("@CreateTime",schedule.CreateTime),
                new SqlParameter("@IfPrivate",schedule.IfPrivate)
            };

            int count = DBHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Proc_UpdateSchedule", para);
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
        /// 根据Id查询日程
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static IList<Schedule> GetScheduleByUserIdandDate(int userId, DateTime date)
        {
            DateTime startDate = DateTime.Parse(date.ToShortDateString());
            DateTime endDate = DateTime.Parse(startDate.AddDays(1).ToShortDateString());

            string sql = "select * from vw_ScheduleAll where CreateUserId=@CreateUserId and  BeginTime between '" + startDate + "' And '" + endDate + "' order by CreateTime desc";
            IList<Schedule> list=new List<Schedule>();

            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@CreateUserId",userId)
               
            };
            using (DataTable dt = DBHelper.ExecuteGetDataTable(CommandType.Text, sql, para))
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Schedule schedule = new Schedule();  //日程信息
                    schedule.Id = (int)dr["Id"];  //日程ID
                    schedule.Title = (string)dr["Title"];  //主题
                    schedule.Address = (string)dr["Address"];  //地点
                    MeetingInfo meetingInfo = new MeetingInfo();  //会议信息
                    meetingInfo.Id = (int)dr["MeetingId"];  //ID
                    meetingInfo.MeetingName = (string)dr["MeetingName"]; //会议名称
                    schedule.Meeting = meetingInfo;
                    schedule.BeginTime = (DateTime)dr["BeginTime"]; //开始时间
                    schedule.EndTime = (DateTime)dr["EndTime"];  //结束时间
                    schedule.SchContent = (string)dr["SchContent"]; //内容
                    UserInfo userInfo = new UserInfo();  //用户信息
                    userInfo.Id = (int)dr["CreateUserId"]; //创建人ID
                    userInfo.UserName = (string)dr["CreateUserName"]; //创建人姓名
                    schedule.CreateUserId = userInfo;
                    schedule.CreateTime = (DateTime)dr["CreateTime"]; //创建时间
                    schedule.IfPrivate = Convert.ToInt32(dr["IfPrivate"]);  //是否公开
                    list.Add(schedule);
                }
            }
            return list;
        }
        /// <summary>
        /// 根据Id查询日程
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Schedule GetScheduleById(int id)
        {
            string sql = "select * from vw_ScheduleAll where Id=@id";
            Schedule schedule = new Schedule();  //日程信息

            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@id",id)
            };
            using (DataTable dt = DBHelper.ExecuteGetDataTable(CommandType.Text, sql, para))
            {
                foreach (DataRow dr in dt.Rows)
                {
                    schedule.Id = (int)dr["Id"];  //日程ID
                    schedule.Title = (string)dr["Title"];  //主题
                    schedule.Address = (string)dr["Address"];  //地点
                    MeetingInfo meetingInfo = new MeetingInfo();  //会议信息
                    meetingInfo.Id = (int)dr["MeetingId"];  //ID
                    meetingInfo.MeetingName = (string)dr["MeetingName"]; //会议名称
                    schedule.Meeting = meetingInfo;
                    schedule.BeginTime = (DateTime)dr["BeginTime"]; //开始时间
                    schedule.EndTime = (DateTime)dr["EndTime"];  //结束时间
                    schedule.SchContent = (string)dr["SchContent"]; //内容
                    UserInfo userInfo = new UserInfo();  //用户信息
                    userInfo.Id = (int)dr["CreateUserId"]; //创建人ID
                    userInfo.UserName = (string)dr["CreateUserName"]; //创建人姓名
                    schedule.CreateUserId = userInfo;
                    schedule.CreateTime = (DateTime)dr["CreateTime"]; //创建时间
                    schedule.IfPrivate = Convert.ToInt32(dr["IfPrivate"]);  //是否公开
                }
            }
            return schedule;
        }
        /// <summary>
        /// 根据日程ID删除日程信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeleteScheduleById(int id)
        {
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@Id",id)
            };

            int count = DBHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Proc_DeleteSchedule", para);
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
        /// 根据不同的条件查询部门日程
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="userName">姓名</param>
        /// <param name="departId">部门Id</param>
        /// <param name="branchId">机构Id</param>
        /// <returns>IList<Schedule></returns>
        public static IList<Schedule> GetScheduleBySelectedConditions(DateTime startTime, DateTime endTime, string userName, int departId, int branchId)
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
                sqlUserName = " AND CreateUserName like '%" + userName + "%'";
            }
            string sql = "SELECT * FROM vw_ScheduleAll WHERE  CreateTime between '" + startTime + "' AND '" + endTime + "'  ";
            sql += sqlDepartId;
            sql += sqlBranchId;

            sql += sqlUserName;
            sql += "ORDER BY BranchId, DepartId, CreateUserName, CreateTime DESC";

            IList<Schedule> list = new List<Schedule>();
            using (SqlDataReader dr = DBHelper.ExecuteGetReader(CommandType.Text, sql, null))
            {
                while(dr.Read())
                {
                    Schedule schedule = new Schedule();
                    schedule.Id = (int)dr["Id"];
                    UserInfo user=new UserInfo ();
                    user.Id = (int)dr["CreateUserId"];
                    user.UserName = dr["CreateUserName"].ToString();
                    schedule.CreateUserId = user;
                    schedule.CreateTime = (DateTime)dr["CreateTime"];
                    schedule.Title = dr["Title"].ToString();
                    
                    list.Add(schedule);
                }
            }
            return list;
        }
        /// <summary>
        /// 通过用户Id 创建时间查询一条日程信息
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="createTime">创建时间</param>
        /// <returns>int</returns>
        public static int GetScheduleId(int userId, DateTime createTime)
        {
            string sql = "SELECT Id FROM vw_ScheduleAll WHERE CreateUserId=" + userId + " AND CreateTime  between '" + createTime + "' And '" + createTime.AddDays(1) + "'";
            return Convert.ToInt32(DBHelper.ExecuteScalar(CommandType.Text, sql, null));
        }

        /// <summary>
        /// 判断预约人是否有时间
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool GetScheduleByPreContract(DateTime beginTime, DateTime endTime, int createUserId)
        {
            string sql = "select count(*) from vw_ScheduleAll "+
                "where ('"+beginTime+"' between BeginTime and EndTime "+
                "or '"+endTime+"' between BeginTime and EndTime "+
                "or ('"+beginTime+"'< BeginTime and '"+endTime+"'> EndTime))and CreateUserId=@createUserId";
            SqlParameter [] para = new SqlParameter[]
            {
                new SqlParameter("@createUserId",createUserId)
            };

            int count = Convert.ToInt32(DBHelper.ExecuteScalar(CommandType.Text, sql, para));
            
            if (count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 查询自己是否有预约
        /// </summary>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <param name="createUserId"></param>
        /// <returns></returns>
        public static bool GetSchedulebyDateTime(DateTime beginTime, DateTime endTime, int createUserId)
        {
            string sql = "select count(*) from vw_Schdule_User_meeing_PreContract" +
                "where ('" + beginTime + "' between BeginTime and EndTime" +
            "or '" + endTime + "' between BeginTime and EndTime " +
            "or ('" + beginTime + "'<BeginTime and '" + endTime + "'>EndTime)) and CreateUserId=" + createUserId + "";

            int count =Convert.ToInt32(DBHelper.ExecuteScalar(CommandType.Text, sql, null));
            if (count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}

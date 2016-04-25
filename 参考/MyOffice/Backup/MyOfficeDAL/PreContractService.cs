using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using MyOffice.Models;

//[预约人表]
namespace MyOffice.DAL
{
    public static class PreContractService
    {
        /// <summary>
        /// 查看所有预约
        /// </summary>
        /// <returns></returns>
        public static IList<PreContract> GetPreContract()
        {
            string sql = "select * from vw_PreContractAll";
            IList<PreContract> list = new List<PreContract>();
            DataTable dt = DBHelper.ExecuteGetDataTable(CommandType.Text, sql, null);

            foreach (DataRow dr in dt.Rows)
            {
                PreContract precontract = new PreContract(); //预约人信息
                precontract.Id = (int)dr["Id"];  //ID
                Schedule schedule = new Schedule(); //日程信息
                schedule.Id = (int)dr["ScheduleId"];  //日程ID
                schedule.Title = (string)dr["ScheduleTitle"]; //主题
                precontract.Schedule = schedule;
                UserInfo userInfo = new UserInfo(); //名称
                userInfo.Id = (int)dr["Id"]; //ID
                userInfo.UserName = (string)dr["UserName"];//姓名
                precontract.User = userInfo;

                list.Add(precontract);
            }

            return list;
        }

        /// <summary>
        /// 根据ID删除预约人
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeletePreContract(int id)
        {
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@Id",id)
            };
            int count = DBHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Proc_DeletePreContract", para);

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
        /// 根据ID和用户Id删除预约人
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeletePreContractByIdAndUserId(PreContract pre)
        {
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@ScheduleId",pre.Schedule.Id),
                 new SqlParameter("@UserId",pre.User.Id)
            };
            int count = DBHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Proc_DeletePreContractByIdAndUserId", para);

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
        /// 修改预约人
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static bool UpdatePreContractById(PreContract pre)
        {
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@scheduleId",pre.Schedule.Id),
                new SqlParameter("@userId",pre.User.Id)
            };
            int count = DBHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Proc_UpdatePreContract", para);
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
        ///添加【预约人】 
        /// </summary>
        /// <param name="preContract"></param>
        /// <returns></returns>
        public static bool AddPreContract(PreContract preContract)
        {
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@ScheduleId",preContract.Schedule.Id),
                new SqlParameter("@UserId",preContract.User.Id)
            };

            int count = DBHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Proc_AddProcedure", para);
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
        /// 根据日程ＩＤ查找预约人
        /// </summary>
        /// <param name="scheduleIdId"></param>
        /// <returns></returns>
        public static IList<PreContract> GetPreContractByScheduleID(int scheduleId)
        {
            string sql = "select * from vw_Schdule_User_meeing_PreContract where ScheduleId=@ScheduleId";
            IList<PreContract> list = new List<PreContract>();
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@ScheduleId",scheduleId)
            };
            using (DataTable dt = DBHelper.ExecuteGetDataTable(CommandType.Text, sql, para))
            {
                foreach (DataRow dr in dt.Rows)
                {
                    PreContract pre = new PreContract();
                    pre.Id = (int)dr["Id"];
                    Schedule schedule = new Schedule();
                    schedule.Id = (int)dr["ScheduleId"];
                    schedule.Title = (string)dr["Title"];
                    schedule.Address = (string)dr["Address"];
                    MeetingInfo meeting = new MeetingInfo();
                    meeting.Id = (int)dr["MeetingId"];
                    meeting.MeetingName = (string)dr["MeetingName"];
                    schedule.Meeting = meeting;
                    schedule.BeginTime = (DateTime)dr["BeginTime"];
                    schedule.EndTime = (DateTime)dr["EndTime"];
                    schedule.SchContent = (string)dr["SchContent"];
                    UserInfo user = new UserInfo();
                    user.Id = (int)dr["CreateUserId"];
                    user.UserName = (string)dr["UserName"];
                    schedule.CreateUserId = user;
                    schedule.CreateTime = (DateTime)dr["CreateTime"];
                    schedule.IfPrivate = Convert.ToInt32(dr["IfPrivate"]);
                    pre.Schedule = schedule;
                    UserInfo userInfo = new UserInfo();
                    userInfo.Id = (int)dr["UserId"];
                    userInfo.UserName = (string)dr["PreUserName"];
                    DepartInfo depart = new DepartInfo();
                    depart.Id = (int)dr["DepartId"];
                    depart.DepartName = (string)dr["DepartName"];
                    userInfo.Depart = depart;
                    pre.User = userInfo;
                    list.Add(pre);
                }
            }
            return list;
        }
        /// <summary>
        /// 得到预约人氏自己的信息
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public static IList<PreContract> GetPreContractByUserIdandDate(int userId, DateTime date)
        {
            DateTime startDate = DateTime.Parse(date.ToShortDateString());
            DateTime endDate = DateTime.Parse(startDate.AddDays(1).ToShortDateString());

            string sql = "select * from vw_Schdule_User_meeing_PreContract where UserId=@UserId and IfPrivate=1and  BeginTime between '" + startDate + "' And '" + endDate + "' order by CreateTime desc";
            IList<PreContract> list = new List<PreContract>();

            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@UserId",userId)
               
            };
            using (DataTable dt = DBHelper.ExecuteGetDataTable(CommandType.Text, sql, para))
            {
                foreach (DataRow dr in dt.Rows)
                {
                    //预约信息
                    PreContract pre = new PreContract();
                    pre.Id = (int)dr["Id"];
                    Schedule schedule = new Schedule();  //日程信息
                    schedule.Id = (int)dr["ScheduleId"];  //日程ID
                    schedule.Title = (string)dr["Title"];  //主题
                    schedule.Address = (string)dr["Address"];  //地点
                    MeetingInfo meetingInfo = new MeetingInfo();  //会议信息
                    meetingInfo.Id = (int)dr["MeetingId"];  //ID
                    meetingInfo.MeetingName = (string)dr["MeetingName"]; //会议名称
                    schedule.Meeting = meetingInfo;
                    schedule.BeginTime = (DateTime)dr["BeginTime"]; //开始时间
                    schedule.EndTime = (DateTime)dr["EndTime"];  //结束时间
                    schedule.SchContent = (string)dr["SchContent"]; //内容
                    UserInfo userInfo = new UserInfo();  //创建人信息
                    userInfo.Id = (int)dr["CreateUserId"]; //创建人ID
                    userInfo.UserName = (string)dr["UserName"]; //创建人姓名
                    schedule.CreateUserId = userInfo;
                    schedule.CreateTime = (DateTime)dr["CreateTime"]; //创建时间
                    schedule.IfPrivate = Convert.ToInt32(dr["IfPrivate"]);  //是否公开
                    pre.Schedule = schedule;
                    UserInfo preUser=new UserInfo ();//预约人信息
                    preUser.Id=(int)dr["UserId"];
                    preUser.UserName=dr["PreUserName"].ToString();
                    pre.User = preUser;
                    list.Add(pre);
                }
            }
            return list;
        }

        /// <summary>
        /// 根据 用户ID和日程ID查询预约人
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="ScheduleId"></param>
        /// <returns></returns>
        public static bool GetPreContractByUserandSchedule(int UserId,int ScheduleId)
        {
            string sql = "select count(*) from VW_PreContractAll where ScheduleId='"+ScheduleId+"' and UserId='"+UserId+"'";
            int count =Convert.ToInt32(DBHelper.ExecuteScalar(CommandType.Text, sql, null));
            if (count > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 根据日程ID和用户ID查询被预约的日程信息
        /// </summary>
        /// <param name="pre"></param>
        /// <returns></returns>
        public static IList<PreContract> SelectPrecontract(int userId, DateTime date)
        {
            DateTime startDate = DateTime.Parse(date.ToShortDateString());
            DateTime endDate = DateTime.Parse(startDate.AddDays(1).ToShortDateString());

            string sql = "select * from vw_Schdule_User_meeing_PreContract where UserId=@UserId and  BeginTime between '" + startDate + "' And '" + endDate + "' order by CreateTime desc";
 
            IList<PreContract> list=new List<PreContract>();
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@UserId",userId)
            };
            DataTable dt= DBHelper.ExecuteGetDataTable(CommandType.Text, sql, para);
            foreach (DataRow dr in dt.Rows)
            {
                //预约信息
                PreContract pre = new PreContract();
                pre.Id = (int)dr["Id"];
                Schedule schedule = new Schedule();  //日程信息
                schedule.Id = (int)dr["ScheduleId"];  //日程ID
                schedule.Title = (string)dr["Title"];  //主题
                schedule.Address = (string)dr["Address"];  //地点
                MeetingInfo meetingInfo = new MeetingInfo();  //会议信息
                meetingInfo.Id = (int)dr["MeetingId"];  //ID
                meetingInfo.MeetingName = (string)dr["MeetingName"]; //会议名称
                schedule.Meeting = meetingInfo;
                schedule.BeginTime = (DateTime)dr["BeginTime"]; //开始时间
                schedule.EndTime = (DateTime)dr["EndTime"];  //结束时间
                schedule.SchContent = (string)dr["SchContent"]; //内容
                UserInfo userInfo = new UserInfo();  //创建人信息
                userInfo.Id = (int)dr["CreateUserId"]; //创建人ID
                userInfo.UserName = (string)dr["UserName"]; //创建人姓名
                schedule.CreateUserId = userInfo;
                schedule.CreateTime = (DateTime)dr["CreateTime"]; //创建时间
                schedule.IfPrivate = Convert.ToInt32(dr["IfPrivate"]);  //是否公开
                pre.Schedule = schedule;
                UserInfo preUser = new UserInfo();//预约人信息
                preUser.Id = (int)dr["UserId"];
                preUser.UserName = dr["PreUserName"].ToString();
                pre.User = preUser;
                list.Add(pre);
            }
            return list;
        }
    }
}

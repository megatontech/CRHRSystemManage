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
        /// ��ѯ�ճ���Ϣ
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
                    Schedule schedule = new Schedule();  //�ճ���Ϣ
                    schedule.Id = (int)dr["Id"];  //�ճ�ID
                    schedule.Title = (string)dr["Title"];  //����
                    schedule.Address = (string)dr["Address"];  //�ص�
                    MeetingInfo meetingInfo = new MeetingInfo();  //������Ϣ
                    meetingInfo.Id = (int)dr["MeetingId"];  //ID
                    meetingInfo.MeetingName = (string)dr["MeetingName"]; //��������
                    schedule.Meeting = meetingInfo;
                    schedule.BeginTime = (DateTime)dr["BeginTime"]; //��ʼʱ��
                    schedule.EndTime = (DateTime)dr["EndTime"];  //����ʱ��
                    schedule.SchContent = (string)dr["SchContent"]; //����
                    UserInfo userInfo = new UserInfo();  //�û���Ϣ
                    userInfo.Id = (int)dr["CreateUserId"]; //������ID
                    userInfo.UserName = (string)dr["CreateUserName"]; //����������
                    schedule.CreateUserId = userInfo;
                    schedule.CreateTime = (DateTime)dr["CreateTime"]; //����ʱ��
                    schedule.IfPrivate = Convert.ToInt32(dr["IfPrivate"]);  //�Ƿ񹫿�
                    list.Add(schedule);  //���ճ���Ϣ��ӵ�������
                }
            }
            return list;
        }


        /// <summary>
        /// ����ʵ����Ӹ����ճ���Ϣ
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
        /// �޸��ճ���Ϣ
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
        /// ����Id��ѯ�ճ�
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
                    Schedule schedule = new Schedule();  //�ճ���Ϣ
                    schedule.Id = (int)dr["Id"];  //�ճ�ID
                    schedule.Title = (string)dr["Title"];  //����
                    schedule.Address = (string)dr["Address"];  //�ص�
                    MeetingInfo meetingInfo = new MeetingInfo();  //������Ϣ
                    meetingInfo.Id = (int)dr["MeetingId"];  //ID
                    meetingInfo.MeetingName = (string)dr["MeetingName"]; //��������
                    schedule.Meeting = meetingInfo;
                    schedule.BeginTime = (DateTime)dr["BeginTime"]; //��ʼʱ��
                    schedule.EndTime = (DateTime)dr["EndTime"];  //����ʱ��
                    schedule.SchContent = (string)dr["SchContent"]; //����
                    UserInfo userInfo = new UserInfo();  //�û���Ϣ
                    userInfo.Id = (int)dr["CreateUserId"]; //������ID
                    userInfo.UserName = (string)dr["CreateUserName"]; //����������
                    schedule.CreateUserId = userInfo;
                    schedule.CreateTime = (DateTime)dr["CreateTime"]; //����ʱ��
                    schedule.IfPrivate = Convert.ToInt32(dr["IfPrivate"]);  //�Ƿ񹫿�
                    list.Add(schedule);
                }
            }
            return list;
        }
        /// <summary>
        /// ����Id��ѯ�ճ�
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Schedule GetScheduleById(int id)
        {
            string sql = "select * from vw_ScheduleAll where Id=@id";
            Schedule schedule = new Schedule();  //�ճ���Ϣ

            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@id",id)
            };
            using (DataTable dt = DBHelper.ExecuteGetDataTable(CommandType.Text, sql, para))
            {
                foreach (DataRow dr in dt.Rows)
                {
                    schedule.Id = (int)dr["Id"];  //�ճ�ID
                    schedule.Title = (string)dr["Title"];  //����
                    schedule.Address = (string)dr["Address"];  //�ص�
                    MeetingInfo meetingInfo = new MeetingInfo();  //������Ϣ
                    meetingInfo.Id = (int)dr["MeetingId"];  //ID
                    meetingInfo.MeetingName = (string)dr["MeetingName"]; //��������
                    schedule.Meeting = meetingInfo;
                    schedule.BeginTime = (DateTime)dr["BeginTime"]; //��ʼʱ��
                    schedule.EndTime = (DateTime)dr["EndTime"];  //����ʱ��
                    schedule.SchContent = (string)dr["SchContent"]; //����
                    UserInfo userInfo = new UserInfo();  //�û���Ϣ
                    userInfo.Id = (int)dr["CreateUserId"]; //������ID
                    userInfo.UserName = (string)dr["CreateUserName"]; //����������
                    schedule.CreateUserId = userInfo;
                    schedule.CreateTime = (DateTime)dr["CreateTime"]; //����ʱ��
                    schedule.IfPrivate = Convert.ToInt32(dr["IfPrivate"]);  //�Ƿ񹫿�
                }
            }
            return schedule;
        }
        /// <summary>
        /// �����ճ�IDɾ���ճ���Ϣ
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
        /// ���ݲ�ͬ��������ѯ�����ճ�
        /// </summary>
        /// <param name="startTime">��ʼʱ��</param>
        /// <param name="endTime">����ʱ��</param>
        /// <param name="userName">����</param>
        /// <param name="departId">����Id</param>
        /// <param name="branchId">����Id</param>
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
        /// ͨ���û�Id ����ʱ���ѯһ���ճ���Ϣ
        /// </summary>
        /// <param name="userId">�û�ID</param>
        /// <param name="createTime">����ʱ��</param>
        /// <returns>int</returns>
        public static int GetScheduleId(int userId, DateTime createTime)
        {
            string sql = "SELECT Id FROM vw_ScheduleAll WHERE CreateUserId=" + userId + " AND CreateTime  between '" + createTime + "' And '" + createTime.AddDays(1) + "'";
            return Convert.ToInt32(DBHelper.ExecuteScalar(CommandType.Text, sql, null));
        }

        /// <summary>
        /// �ж�ԤԼ���Ƿ���ʱ��
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
        /// ��ѯ�Լ��Ƿ���ԤԼ
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

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using MyOffice.Models;

namespace MyOffice.DAL
{
    public static class MyNoteService
    {
        /// <summary>
        /// 根据创建人显示跟人的便签
        /// </summary>
        /// <returns></returns>
        public static IList<MyNote> GetMyNoteByCreateUserId(int createUserId)
        {
            string sql = "select * from vw_MyNOteAll where CreateUserId=@CreateUserId";

            IList<MyNote> list = new List<MyNote>();
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@CreateUserId",createUserId)
            };

            using (DataTable dt = DBHelper.ExecuteGetDataTable(CommandType.Text, sql, para))
            {
                foreach (DataRow dr in dt.Rows)
                {
                    MyNote mynote = new MyNote();
                    mynote.Id=(int)dr["Id"];
                    mynote.NoteTitle = (string)dr["NoteTitle"];
                    list.Add(mynote);
                }
            }
            return list;
        }

        /// <summary>
        /// 根据标题查询便签内容
        /// </summary>
        /// <returns></returns>
        public static IList<MyNote> GetMyNoteBynoteTitle(string noteTitle)
        {
            string sql = "select * from vw_MyNOteAll where NoteTitle='" + noteTitle + "'";
            IList<MyNote> list = new List<MyNote>();            
            using (DataTable dt = DBHelper.ExecuteGetDataTable(CommandType.Text, sql, null))
            {
                foreach (DataRow dr in dt.Rows)
                {
                    MyNote mynote = new MyNote();
                    mynote.Id = (int)dr["Id"];
                    mynote.NoteTitle = (string)dr["NoteTitle"];
                    mynote.NoteContent = (string)dr["NoteContent"];
                    mynote.CreateTime = (DateTime)dr["CreateTime"];
                    UserInfo user = new UserInfo();
                    user.Id=(int)dr["CreateUserId"];
                    user.UserName = (string)dr["CreateUserName"];
                    mynote.CreateUser = user;

                    list.Add(mynote);
                }
            }
            return list;
        }

        /// <summary>
        /// 根据Id查找便签
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static MyNote GetMyNoteById(int id)
        {
            string sql = "select * from vw_MyNOteAll where Id='" + id + "'";
            MyNote mynote = new MyNote();
            using (DataTable dt = DBHelper.ExecuteGetDataTable(CommandType.Text, sql, null))
            {
                foreach (DataRow dr in dt.Rows)
                {
                    mynote.Id = (int)dr["Id"];
                    mynote.NoteTitle = (string)dr["NoteTitle"];
                    mynote.NoteContent = (string)dr["NoteContent"];
                    mynote.CreateTime = (DateTime)dr["CreateTime"];
                    UserInfo user = new UserInfo();
                    user.Id = (int)dr["CreateUserId"];
                    user.UserName = (string)dr["CreateUserName"];
                    mynote.CreateUser = user;
                }
            }
            return mynote;
        }

        /// <summary>
        /// 添加我的便签
        /// </summary>
        /// <param name="mynote"></param>
        /// <returns></returns>
        public static bool AddMyNote(MyNote mynote)
        {
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@NoteTitle",mynote.NoteTitle),
                new SqlParameter("@NoteContent",mynote.NoteContent),
                new SqlParameter("@CreateTime",mynote.CreateTime),
                new SqlParameter("@CreateUserId",mynote.CreateUser.Id)
            };
            int count = DBHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_AddMyNote", para);

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
        /// 修改我的便签
        /// </summary>
        /// <param name="mynote"></param>
        /// <returns></returns>
        public static bool ModifyMyNote(MyNote mynote)
        {
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@Id",mynote.Id),
                new SqlParameter("@NoteTitle",mynote.NoteTitle),
                new SqlParameter("@NoteContent",mynote.NoteContent),
                new SqlParameter("@CreateTime",mynote.CreateTime),
                new SqlParameter("@CreateUserId",mynote.CreateUser.Id)
            };

            int count = DBHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_UpdateMyNote", para);

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
        /// 根据Id删除便签
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeleteMyNotebyId(int id)
        {
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@Id",id)
            };
            int count = DBHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Proc_DeleteMyNote",para);
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

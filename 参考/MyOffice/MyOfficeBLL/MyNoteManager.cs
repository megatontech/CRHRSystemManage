using System;
using System.Collections.Generic;
using System.Text;
using MyOffice.DAL;
using MyOffice.Models;

namespace MyOffice.BLL
{
    public static class MyNoteManager
    {
        /// <summary>
        /// 根据创建人显示跟人的便签
        /// </summary>
        /// <returns></returns>
        public static IList<MyNote> GetMyNoteByCreateUserId(int createUserId)
        {
            return MyNoteService.GetMyNoteByCreateUserId(createUserId);
        }

        /// <summary>
        /// 根据标题查询便签内容
        /// </summary>
        /// <returns></returns>
        public static IList<MyNote> GetMyNoteBynoteTitle(string noteTitle)
        {
            return MyNoteService.GetMyNoteBynoteTitle(noteTitle);
        }

         /// <summary>
        /// 根据Id查找便签
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static MyNote GetMyNoteById(int id)
        {
            return MyNoteService.GetMyNoteById(id);
        }
        /// <summary>
        /// 添加我的便签
        /// </summary>
        /// <param name="mynote"></param>
        /// <returns></returns>
        public static bool AddMyNote(MyNote mynote)
        {
            return MyNoteService.AddMyNote(mynote);
        }

          /// <summary>
        /// 修改我的便签
        /// </summary>
        /// <param name="mynote"></param>
        /// <returns></returns>
        public static bool ModifyMyNote(MyNote mynote)
        {
            return MyNoteService.ModifyMyNote(mynote);
        }

        /// <summary>
        /// 根据Id删除便签
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeleteMyNotebyId(int id)
        {
            return MyNoteService.DeleteMyNotebyId(id);
        }
    }
}

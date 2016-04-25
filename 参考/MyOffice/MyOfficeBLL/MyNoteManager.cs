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
        /// ���ݴ�������ʾ���˵ı�ǩ
        /// </summary>
        /// <returns></returns>
        public static IList<MyNote> GetMyNoteByCreateUserId(int createUserId)
        {
            return MyNoteService.GetMyNoteByCreateUserId(createUserId);
        }

        /// <summary>
        /// ���ݱ����ѯ��ǩ����
        /// </summary>
        /// <returns></returns>
        public static IList<MyNote> GetMyNoteBynoteTitle(string noteTitle)
        {
            return MyNoteService.GetMyNoteBynoteTitle(noteTitle);
        }

         /// <summary>
        /// ����Id���ұ�ǩ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static MyNote GetMyNoteById(int id)
        {
            return MyNoteService.GetMyNoteById(id);
        }
        /// <summary>
        /// ����ҵı�ǩ
        /// </summary>
        /// <param name="mynote"></param>
        /// <returns></returns>
        public static bool AddMyNote(MyNote mynote)
        {
            return MyNoteService.AddMyNote(mynote);
        }

          /// <summary>
        /// �޸��ҵı�ǩ
        /// </summary>
        /// <param name="mynote"></param>
        /// <returns></returns>
        public static bool ModifyMyNote(MyNote mynote)
        {
            return MyNoteService.ModifyMyNote(mynote);
        }

        /// <summary>
        /// ����Idɾ����ǩ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeleteMyNotebyId(int id)
        {
            return MyNoteService.DeleteMyNotebyId(id);
        }
    }
}

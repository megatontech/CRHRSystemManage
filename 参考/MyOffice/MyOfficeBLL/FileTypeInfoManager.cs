/**
 * ����
 * 2008-12-02
 */
using System;
using System.Collections.Generic;
using System.Text;
using MyOffice.Models;
using System.Data.SqlClient;
using System.Data;
using MyOffice.DAL;

namespace MyOffice.BLL
{
    public static class FileTypeInfoManager
    {
        /// <summary>
        /// ��ѯ���е��ļ����ͣ������ļ��У�
        /// </summary>
        /// <returns>���е��ļ�����</returns>
        public static IList<FileTypeInfo> GetAllFileType()
        {
            return FileTypeInfoService.GetAllFileType();
        }

        /// <summary>
        /// �����ļ�����id��ѯ�ļ����͵ĺ�׺
        /// </summary>
        /// <param name="id">�ļ�����id</param>
        /// <returns>�ļ����͵ĺ�׺</returns>
        public static string GetFileTypeSuffixByTypeId(int id)
        {
            return FileTypeInfoService.GetFileTypeSuffixByTypeId(id);
        }

        /// <summary>
        /// �����ļ���׺��ѯ�ļ�������Ϣ
        /// </summary>
        /// <param name="suffix">�ļ���׺</param>
        /// <returns>�ļ�������Ϣ</returns>
        public static FileTypeInfo GetFileTypeInfoByFileTypeSuffix(string suffix)
        {
            return FileTypeInfoService.GetFileTypeInfoByFileTypeSuffix(suffix);
        }
    }
}

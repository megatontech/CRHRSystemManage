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

namespace MyOffice.DAL
{
    public static class FileTypeInfoService
    {
        /// <summary>
        /// ��ѯ���е��ļ����ͣ������ļ��У�
        /// </summary>
        /// <returns>���е��ļ�����</returns>
        public static IList<FileTypeInfo> GetAllFileType()
        {
            string sql = "SELECT *FROM VW_FileTypeInfoAll WHERE Id<>1";
            IList<FileTypeInfo> list = new List<FileTypeInfo>();
            using (SqlDataReader dr = DBHelper.ExecuteGetReader(CommandType.Text, sql, null))
            {
                while (dr.Read())
                {
                    FileTypeInfo fileType = new FileTypeInfo();
                    fileType.Id = (int)dr["Id"];
                    fileType.FileTypeName = (string)dr["FileTypeName"];
                    fileType.FileTypeImage = (string)dr["FileTypeImage"];
                    fileType.FileTypeSuffix = (string)dr["FileTypeSuffix"];

                    list.Add(fileType);
                }
            }

            return list;
        }

        /// <summary>
        /// �����ļ�����id��ѯ�ļ����͵ĺ�׺
        /// </summary>
        /// <param name="id">�ļ�����id</param>
        /// <returns>�ļ����͵ĺ�׺</returns>
        public static string GetFileTypeSuffixByTypeId(int id)
        {
            string sql = "SELECT FileTypeSuffix FROM VW_FileTypeInfoAll WHERE Id=" + id;
            return DBHelper.ExecuteScalar(CommandType.Text, sql, null).ToString();
        }

        /// <summary>
        /// �����ļ���׺��ѯ�ļ�������Ϣ
        /// </summary>
        /// <param name="suffix">�ļ���׺</param>
        /// <returns>�ļ�������Ϣ</returns>
        public static FileTypeInfo GetFileTypeInfoByFileTypeSuffix(string suffix)
        {
            FileTypeInfo fileType = new FileTypeInfo();
            string sql = "SELECT *FROM VW_FileTypeInfoAll WHERE FileTypeSuffix='" + suffix + "'";
            using (SqlDataReader dr = DBHelper.ExecuteGetReader(CommandType.Text, sql, null))
            {
                if (dr.Read())
                {
                    fileType.Id = (int)dr["Id"];
                    fileType.FileTypeName = (string)dr["FileTypeName"];
                    fileType.FileTypeImage = (string)dr["FileTypeImage"];
                    fileType.FileTypeSuffix = (string)dr["FileTypeSuffix"];

                }
            }
            return fileType;
        }
    }
}

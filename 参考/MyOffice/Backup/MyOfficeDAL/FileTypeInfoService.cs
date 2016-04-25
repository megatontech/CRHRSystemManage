/**
 * 杨林
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
        /// 查询所有的文件类型（除了文件夹）
        /// </summary>
        /// <returns>所有的文件类型</returns>
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
        /// 根据文件类型id查询文件类型的后缀
        /// </summary>
        /// <param name="id">文件类型id</param>
        /// <returns>文件类型的后缀</returns>
        public static string GetFileTypeSuffixByTypeId(int id)
        {
            string sql = "SELECT FileTypeSuffix FROM VW_FileTypeInfoAll WHERE Id=" + id;
            return DBHelper.ExecuteScalar(CommandType.Text, sql, null).ToString();
        }

        /// <summary>
        /// 根据文件后缀查询文件类型信息
        /// </summary>
        /// <param name="suffix">文件后缀</param>
        /// <returns>文件类型信息</returns>
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

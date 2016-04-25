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
    public static class AccessoryFileService
    {
        /// <summary>
        /// ����ļ�����
        /// </summary>
        /// <param name="accessoryFile">�ļ�����</param>
        /// <returns>��ӵ��ļ�������id</returns>
        public static int AddAccessoryFile(AccessoryFileInfo accessoryFile)
        {
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@FileId",accessoryFile.File.Id),
                new SqlParameter("@AccessoryName",accessoryFile.AccessoryName),
                new SqlParameter("@AccessorySize",accessoryFile.AccessorySize),
                new SqlParameter("@AccessoryTypeId",accessoryFile.AccessoryType.Id),
                new SqlParameter("@AccessoryPath",accessoryFile.AccessoryPath),
                new SqlParameter("@AccessoryId",DbType.Int32)
            };
            para[5].Direction = ParameterDirection.Output;
            DBHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_AddAccessoryFile", para);

            return (int)para[5].Value;
        }

        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="accessoryFileId">�ļ�����id</param>
        /// <returns>�Ƿ�ɾ���ɹ�</returns>
        public static bool DeleteAccessoryFileById(int accessoryFileId)
        {
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@Id",accessoryFileId)
            };
            int count = DBHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_DeleteAccessoryFileById", para);
            if (count > 0)
                return true;
            return false;
        }

        /// <summary>
        /// ��ѯ���е��ļ�����
        /// </summary>
        /// <returns></returns>
        public static IList<AccessoryFileInfo> GetAllAccessoryFile()
        {
            string sql = "SELECT *FROM VW_AccessoryFileAll";
            return GetField(sql);
        }

        /// <summary>
        /// �����ļ�id��ѯ�ļ�����
        /// </summary>
        /// <param name="fileId">�ļ�id</param>
        /// <returns></returns>
        public static IList<AccessoryFileInfo> GetAccessoryFileByFileId(int fileId)
        {
            string sql = "SELECT *FROM VW_AccessoryFileAll WHERE FileId=" + fileId;
            return GetField(sql);
        }

        /// <summary>
        /// ���ݸ��������������ֲ�ѯ�ļ���id
        /// </summary>
        /// <param name="accessoryName">������</param>
        /// <returns>���е��ļ�id</returns>
        public static IList<int> GetFileIdByAccessoryName(string accessoryName,string beginDate,string endDate)
        {
            IList<int> list = new List<int>();
            string sql = "SELECT FileId FROM VW_AccessoryFileAll WHERE AccessoryName LIKE '%"
                + accessoryName + "%' AND CreateDate BETWEEN '" + beginDate + "' AND '" + endDate + "'";
            using (SqlDataReader dr = DBHelper.ExecuteGetReader(CommandType.Text, sql, null))
            {
                while (dr.Read())
                {
                    list.Add((int)dr["FileId"]);
                }
            }
            return list;
        }

        #region ��ѯ�ֶ�
        private static IList<AccessoryFileInfo> GetField(string sql)
        {
            IList<AccessoryFileInfo> list = new List<AccessoryFileInfo>();
            using (SqlDataReader dr = DBHelper.ExecuteGetReader(CommandType.Text, sql, null))
            {
                while (dr.Read())
                {
                    AccessoryFileInfo accessory = new AccessoryFileInfo();
                    accessory.Id = (int)dr["Id"];

                    FileInfo fileInfo = new FileInfo();
                    fileInfo.Id = (int)dr["FileId"];
                    fileInfo.FileName = (string)dr["FileName"];
                    accessory.File = fileInfo;

                    accessory.AccessoryName = (string)dr["AccessoryName"];
                    accessory.AccessorySize = (int)dr["AccessorySize"];

                    FileTypeInfo accessoryType = new FileTypeInfo();
                    accessoryType.Id = (int)dr["AccessoryTypeId"];
                    accessoryType.FileTypeName = (string)dr["AccessoryTypeName"];
                    accessoryType.FileTypeImage = (string)dr["AccessoryTypeImage"];
                    accessoryType.FileTypeSuffix = (string)dr["AccessoryTypeSuffix"];
                    accessory.AccessoryType = accessoryType;

                    accessory.CreateDate = (DateTime)dr["CreateDate"];
                    accessory.AccessoryPath = (string)dr["AccessoryPath"];

                    list.Add(accessory);

                }
            }
            return list;
        }
        #endregion
    }
}

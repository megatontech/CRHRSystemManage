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
    public static class FileInfoService
    {
        /// <summary>
        /// 查询所有的文件夹,展示树型菜单
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAllFileForTreeView()
        {
            string sql = "SELECT *FROM VW_FileInfoAll WHERE FileTypeId=1 AND IfDelete=0";
            return DBHelper.ExecuteGetDataTable(CommandType.Text, sql, null);
        }

        /// <summary>
        /// 添加文件
        /// 执行存储过程 proc_AddFileInfo
        /// </summary>
        /// <param name="fileInfo">要添加的文件信息</param>
        /// <returns>添加的文件id</returns>
        public static int AddFileInfo(FileInfo fileInfo)
        {
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@FileName",fileInfo.FileName),
                new SqlParameter("@FileTypeId",fileInfo.FileTyPe.Id),
                new SqlParameter("@Remark",fileInfo.Remark),
                new SqlParameter("@FileOwnerId",fileInfo.FileOwner.Id),
                new SqlParameter("@ParentId",fileInfo.ParentId),
                new SqlParameter("@FilePath",fileInfo.FilePath),
                new SqlParameter("@IfDelete",fileInfo.IfDelete),
                new SqlParameter("@Id",DbType.Int32)
            };
            para[7].Direction = ParameterDirection.Output;
            DBHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_AddFileInfo", para);

            return (int)para[7].Value;
        }

        /// <summary>
        /// 根据文件夹id搜索他里面的文件内容,未删除的
        /// </summary>
        /// <param name="parentId">父级节点id</param>
        /// <returns></returns>
        public static IList<FileInfo> GetFileByParentId(int parentId)
        {
            string sql = "SELECT *FROM VW_FileInfoAll WHERE ParentId=" + parentId + " AND IfDelete=0";

            return GetField(sql);
        }

        /// <summary>
        /// 根据文件id搜索他的文件信息
        /// </summary>
        /// <param name="fileId">文件id</param>
        /// <returns></returns>
        public static FileInfo GetFileByFileId(int fileId)
        {
            FileInfo fileInfo = new FileInfo();
            string sql = "SELECT *FROM VW_FileInfoAll WHERE Id=" + fileId + " AND IfDelete=0";
            using (SqlDataReader dr = DBHelper.ExecuteGetReader(CommandType.Text, sql, null))
            {
                if (dr.Read())
                {
                    
                    fileInfo.Id = (int)dr["Id"];
                    fileInfo.FileName = (string)dr["FileName"];

                    FileTypeInfo fileType = new FileTypeInfo();//外键
                    fileType.Id = (int)dr["FileTypeId"];
                    fileType.FileTypeName = (string)dr["FileTypeName"];
                    fileType.FileTypeImage = (string)dr["FileTypeImage"];
                    fileType.FileTypeSuffix = (string)dr["FileTypeSuffix"];
                    fileInfo.FileTyPe = fileType;

                    fileInfo.Remark = (string)dr["Remark"];

                    UserInfo fileOwner = new UserInfo();//外键
                    fileOwner.Id = (int)dr["FileOwnerId"];
                    fileOwner.UserName = (string)dr["FileOwnerName"];
                    fileInfo.FileOwner = fileOwner;

                    fileInfo.CreateDate = (DateTime)dr["CreateDate"];
                    fileInfo.ParentId = (int)dr["ParentId"];
                    fileInfo.FilePath = (string)dr["FilePath"];
                    fileInfo.IfDelete = Convert.ToInt32(dr["IfDelete"]);
                }
            }
            return fileInfo;
        }

        /// <summary>
        /// 修改文件
        /// </summary>
        /// <param name="fileInfo">文件信息</param>
        /// <returns>是否修改成功</returns>
        public static bool ModifyFile(FileInfo fileInfo)
        {
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@Id",fileInfo.Id),
                new SqlParameter("@FileTypeId",fileInfo.FileTyPe.Id),
                new SqlParameter("@FileName",fileInfo.FileName),
                new SqlParameter("@FilePath",fileInfo.FilePath),
                new SqlParameter("@Remark",fileInfo.Remark)
            };

            int count = DBHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_ModifyFile", para);
            if (count > 0)
                return true;
            return false;
        }

        /// <summary>
        /// 得到所有的用户删除的文件（夹）
        /// </summary>
        /// <returns></returns>
        public static IList<FileInfo> GetAllIsDeleteFile(int uid)
        {
            string sql = "SELECT *FROM VW_FileInfoAll WHERE  IfDelete=1 AND FileOwnerId=" + uid;
            return GetField(sql);
        }

        /// <summary>
        /// 修改IfDelete
        /// </summary>
        /// <param name="fileId">要修改的文件的id</param>
        /// <param name="ifDelete">修改的ifDelete</param>
        /// <returns>是否修改成功</returns>
        public static bool ModifyIfDeleteById(int fileId,int ifDelete)
        {
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@Id",fileId),
                new SqlParameter("@IfDelete",ifDelete)
            };
            int count = DBHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_ModifyIfDeleteByFileId", para);
            if (count > 0)
                return true;
            return false;
        }

        /// <summary>
        /// 彻底删除文件
        /// </summary>
        /// <param name="fileId">要删除文件的id</param>
        /// <returns>是否删除成功</returns>
        public static bool DeleteFileById(int fileId)
        {
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@Id",fileId)
            };
            int count = DBHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_DeleteFileById", para);
            if (count > 0)
                return true;
            return false;
        }

        /// <summary>
        /// 查询所有的文件
        /// </summary>
        /// <returns>所有的文件信息</returns>
        public static IList<FileInfo> GetAllFile()
        {
            string sql = "SELECT *FROM VW_FileInfoAll WHERE IfDelete=0";
            return GetField(sql);
        }

        /// <summary>
        /// 根据文件id查询地址
        /// </summary>
        /// <param name="fileId">文件id</param>
        /// <returns>地址</returns>
        public static string GetAddressByFileId(int fileId)
        {
            string sql = "SELECT FilePath FROM VW_FileInfoAll WHERE Id=" + fileId;
            object obj = DBHelper.ExecuteScalar(CommandType.Text, sql, null);
            if (obj != null)
                return obj.ToString();
            return "";
        }

        /// <summary>
        /// 根据地址查询文件的id
        /// </summary>
        /// <param name="address">文件的地址</param>
        /// <returns>文件的id</returns>
        public static int GetFileIdByAddress(string address)
        {
            string sql = "SELECT Id FROM VW_FileInfoAll WHERE FilePath='" + address + "' AND IfDelete=0";
            object obj = DBHelper.ExecuteScalar(CommandType.Text, sql, null);
            if(obj!=null)
                return int.Parse(obj.ToString());
            return -1;
        }

        /// <summary>
        /// 根据文件ｉｄ查询文件类型
        /// </summary>
        /// <param name="fileId">文件ｉｄ</param>
        /// <returns>文件类型</returns>
        public static string GetFileTypeNameByFileId(int fileId)
        {
            string sql = "SELECT FileTypeName FROM VW_FileInfoAll WHERE Id=" + fileId;
            return DBHelper.ExecuteScalar(CommandType.Text, sql, null).ToString();
        }

        /// <summary>
        /// 根据文件ｉｄ查询文件路径
        /// </summary>
        /// <param name="fileId">文件ｉｄ</param>
        /// <returns>文件路径</returns>
        public static string GetFilePathByFileId(int fileId)
        {
            string sql = "SELECT FilePath FROM VW_FileInfoAll WHERE Id=" + fileId;
            return DBHelper.ExecuteScalar(CommandType.Text, sql, null).ToString();
        }


        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        public static IList<FileInfo> GetFileInfoBySearch(string sql)
        {
            return GetField(sql);
        }

        /// <summary>
        /// 修改父级id
        /// </summary>
        /// <param name="fileId">要修改的文件id</param>
        /// <param name="parentId">父级id</param>
        /// <returns>是否修改成功</returns>
        public static bool ModifyParentId(int fileId,int parentId)
        {
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@FileId",fileId),
                new SqlParameter("@ParentId",parentId)
            };
            int count = DBHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_ModifyParentId", para);
            if (count > 0)
                return true;
            return false;
        }

        /// <summary>
        /// 修改文件路径
        /// </summary>
        /// <param name="fileId">要修改的文件id</param>
        /// <param name="path">路径</param>
        /// <returns>是否修改成功</returns>
        public static bool ModifyFilePath(int fileId, string path)
        {
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@FileId",fileId),
                new SqlParameter("@FilePath",path)
            };
            int count = DBHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_ModifyFilePath", para);
            if (count > 0)
                return true;
            return false;
        }

        /// <summary>
        /// 删除所有的的IfDelete=1的文件
        /// </summary>
        /// <returns>是否删除成功</returns>
        public static bool DeleteAllIsDeleteFile()
        {
            int count = DBHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_DeleteAllIsDeleteFile", null);
            if (count > 0)
                return true;
            return false;
        }

        #region 查询字段
        /// <summary>
        /// 查询字段
        /// </summary>
        /// <param name="sql">字符串</param>
        /// <returns></returns>
        private static IList<FileInfo> GetField(string sql)
        {
            IList<FileInfo> list = new List<FileInfo>();
            using (SqlDataReader dr = DBHelper.ExecuteGetReader(CommandType.Text, sql, null))
            {
                while (dr.Read())
                {
                    FileInfo fileInfo = new FileInfo();
                    fileInfo.Id = (int)dr["Id"];
                    fileInfo.FileName = (string)dr["FileName"];

                    FileTypeInfo fileType = new FileTypeInfo();//外键
                    fileType.Id = (int)dr["FileTypeId"];
                    fileType.FileTypeName = (string)dr["FileTypeName"];
                    fileType.FileTypeImage = (string)dr["FileTypeImage"];
                    fileType.FileTypeSuffix = (string)dr["FileTypeSuffix"];
                    fileInfo.FileTyPe = fileType;

                    fileInfo.Remark = (string)dr["Remark"];

                    UserInfo fileOwner = new UserInfo();//外键
                    fileOwner.Id = (int)dr["FileOwnerId"];
                    fileOwner.UserName = (string)dr["FileOwnerName"];
                    fileInfo.FileOwner = fileOwner;

                    fileInfo.CreateDate = (DateTime)dr["CreateDate"];
                    fileInfo.ParentId = (int)dr["ParentId"];
                    fileInfo.FilePath = (string)dr["FilePath"];
                    fileInfo.IfDelete = Convert.ToInt32(dr["IfDelete"]);

                    list.Add(fileInfo);
                }
            }
            return list;
        }
        #endregion
    }
}

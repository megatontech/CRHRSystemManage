/**
 * 杨林
 * 2008-12-02
 */
using System;
using System.Collections.Generic;
using System.Text;
using MyOffice.DAL;
using MyOffice.Models;
using System.Data;

namespace MyOffice.BLL
{
    public static class FileInfoManager
    {
        /// <summary>
        /// 查询所有的文件夹,展示树型菜单
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAllFileForTreeView()
        {
            return FileInfoService.GetAllFileForTreeView();
        }
        /// <summary>
        /// 添加文件
        /// </summary>
        /// <param name="fileInfo">要添加的文件信息</param>
        /// <returns>添加的文件id</returns>
        public static int AddFileInfo(FileInfo fileInfo)
        {
            return FileInfoService.AddFileInfo(fileInfo);
        }
        /// <summary>
        /// 根据文件夹id搜索他里面的文件内容,未删除的
        /// </summary>
        /// <param name="parentId">父级节点id</param>
        /// <returns></returns>
        public static IList<FileInfo> GetFileByParentId(int parentId)
        {
            return FileInfoService.GetFileByParentId(parentId);
        }
        /// <summary>
        /// 根据文件id搜索他的文件信息
        /// </summary>
        /// <param name="fileId">文件id</param>
        /// <returns></returns>
        public static FileInfo GetFileByFileId(int fileId)
        {
            return FileInfoService.GetFileByFileId(fileId);
        }

        /// <summary>
        /// 修改文件
        /// </summary>
        /// <param name="fileInfo">文件信息</param>
        /// <returns>是否修改成功</returns>
        public static bool ModifyFile(FileInfo fileInfo)
        {
            return FileInfoService.ModifyFile(fileInfo);
        }

        /// <summary>
        /// 得到所有的用户删除的文件（夹）
        /// </summary>
        /// <returns></returns>
        public static IList<FileInfo> GetAllIsDeleteFile(int uid)
        {
            return FileInfoService.GetAllIsDeleteFile(uid);
        }

        /// <summary>
        /// 修改IfDelete
        /// </summary>
        /// <param name="fileId">要修改的文件的id</param>
        /// <param name="ifDelete">修改的ifDelete</param>
        /// <returns>是否修改成功</returns>
        public static bool ModifyIfDeleteById(int fileId, int ifDelete)
        {
            return FileInfoService.ModifyIfDeleteById(fileId,ifDelete);
        }

        /// <summary>
        /// 彻底删除文件
        /// </summary>
        /// <param name="fileId">要删除文件的id</param>
        /// <returns>是否删除成功</returns>
        public static bool DeleteFileById(int fileId)
        {
            return FileInfoService.DeleteFileById(fileId);
        }

        /// <summary>
        /// 查询所有的文件
        /// </summary>
        /// <returns>所有的文件信息</returns>
        public static IList<FileInfo> GetAllFile()
        {
            return FileInfoService.GetAllFile();
        }

        /// <summary>
        /// 根据文件id查询地址
        /// </summary>
        /// <param name="fileId">文件id</param>
        /// <returns>地址</returns>
        public static string GetAddressByFileId(int fileId)
        {
            return FileInfoService.GetAddressByFileId(fileId);
        }

        /// <summary>
        /// 根据地址查询文件的id
        /// </summary>
        /// <param name="address">文件的地址</param>
        /// <returns>文件的id</returns>
        public static int GetFileIdByAddress(string address)
        {
            return FileInfoService.GetFileIdByAddress(address);
        }

        /// <summary>
        /// 根据文件ｉｄ查询文件类型
        /// </summary>
        /// <param name="fileId">文件ｉｄ</param>
        /// <returns>文件类型</returns>
        public static string GetFileTypeNameByFileId(int fileId)
        {
            return FileInfoService.GetFileTypeNameByFileId(fileId);
        }

        /// <summary>
        /// 根据文件ｉｄ查询文件路径
        /// </summary>
        /// <param name="fileId">文件ｉｄ</param>
        /// <returns>文件路径</returns>
        public static string GetFilePathByFileId(int fileId)
        {
            return FileInfoService.GetFilePathByFileId(fileId);
        }

        /// <summary>
        /// 搜索 
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="accesoryFile">附件名</param>
        /// <param name="createUser">创建者</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns>搜索出来的文件</returns>
        public static IList<FileInfo> GetFileInfoBySearch(string fileName, string accesoryFile, string createUser, string beginTime, string endTime)
        {
            if (beginTime == "")
            {
                beginTime = "2001-01-01";
            }
            if (endTime == "")
            {
                endTime = DateTime.Now.ToString();
            }

            string sql = "";//sql语句
            IList<FileInfo> li = new List<FileInfo>();

            if (fileName != "")//文件名
            {
                sql = "SELECT *FROM VW_FileInfoAll WHERE FileName LIKE '%" + fileName
                    + "%' AND CreateDate BETWEEN '" + beginTime + "' AND '" + endTime + "' AND IfDelete=0";
                li = FileInfoService.GetFileInfoBySearch(sql);
            }
            if (accesoryFile != "")//附件名
            {
                IList<int> list = AccessoryFileService.GetFileIdByAccessoryName(accesoryFile, beginTime, endTime);
                foreach (int fileId in list)
                {
                    li.Add(FileInfoService.GetFileByFileId(fileId));
                }
            }
            if (createUser != "")//创建者
            {
                sql = "SELECT *FROM VW_FileInfoAll WHERE FileOwnerName = '" + createUser
                    + "' AND CreateDate BETWEEN '" + beginTime + "' AND '" + endTime + "' AND IfDelete=0";
                li = FileInfoService.GetFileInfoBySearch(sql);
            }

            return li;
        }

        /// <summary>
        /// 修改父级id
        /// </summary>
        /// <param name="fileId">要修改的文件id</param>
        /// <param name="parentId">父级id</param>
        /// <returns>是否修改成功</returns>
        public static bool ModifyParentId(int fileId, int parentId)
        {
            return FileInfoService.ModifyParentId(fileId, parentId);
        }

         /// <summary>
        /// 修改文件路径
        /// </summary>
        /// <param name="fileId">要修改的文件id</param>
        /// <param name="path">路径</param>
        /// <returns>是否修改成功</returns>
        public static bool ModifyFilePath(int fileId, string path)
        {
            return FileInfoService.ModifyFilePath(fileId, path);
        }

        /// <summary>
        /// 清空回收站方法
        /// </summary>
        /// <returns></returns>
        public static bool ClearRecycleBin()
        {
            return FileInfoService.DeleteAllIsDeleteFile();
        }
    }
}

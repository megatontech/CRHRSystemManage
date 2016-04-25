/**
 * 杨林
 * 2008-12-02
 */
using System;
using System.Collections.Generic;
using System.Text;
using MyOffice.Models;
using MyOffice.DAL;

namespace MyOffice.BLL
{
    public static class AccessoryFileManager
    {
        /// <summary>
        /// 添加文件附件
        /// </summary>
        /// <param name="accessoryFile">文件附件</param>
        /// <returns>添加的文件附件的id</returns>
        public static int AddAccessoryFile(AccessoryFileInfo accessoryFile)
        {
            return AccessoryFileService.AddAccessoryFile(accessoryFile);
        }

        /// <summary>
        /// 删除附件
        /// </summary>
        /// <param name="accessoryFileId">文件附件id</param>
        /// <returns>是否删除成功</returns>
        public static bool DeleteAccessoryFileById(int accessoryFileId)
        {
            return AccessoryFileService.DeleteAccessoryFileById(accessoryFileId);
        }

        /// <summary>
        /// 查询所有的文件附件
        /// </summary>
        /// <returns></returns>
        public static IList<AccessoryFileInfo> GetAllAccessoryFile()
        {
            return AccessoryFileService.GetAllAccessoryFile();
        }

        /// <summary>
        /// 根据文件id查询文件附件
        /// </summary>
        /// <param name="fileId">文件id</param>
        /// <returns></returns>
        public static IList<AccessoryFileInfo> GetAccessoryFileByFileId(int fileId)
        {
            return AccessoryFileService.GetAccessoryFileByFileId(fileId);
        }

    }
}

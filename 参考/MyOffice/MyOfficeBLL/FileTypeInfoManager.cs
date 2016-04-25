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
using MyOffice.DAL;

namespace MyOffice.BLL
{
    public static class FileTypeInfoManager
    {
        /// <summary>
        /// 查询所有的文件类型（除了文件夹）
        /// </summary>
        /// <returns>所有的文件类型</returns>
        public static IList<FileTypeInfo> GetAllFileType()
        {
            return FileTypeInfoService.GetAllFileType();
        }

        /// <summary>
        /// 根据文件类型id查询文件类型的后缀
        /// </summary>
        /// <param name="id">文件类型id</param>
        /// <returns>文件类型的后缀</returns>
        public static string GetFileTypeSuffixByTypeId(int id)
        {
            return FileTypeInfoService.GetFileTypeSuffixByTypeId(id);
        }

        /// <summary>
        /// 根据文件后缀查询文件类型信息
        /// </summary>
        /// <param name="suffix">文件后缀</param>
        /// <returns>文件类型信息</returns>
        public static FileTypeInfo GetFileTypeInfoByFileTypeSuffix(string suffix)
        {
            return FileTypeInfoService.GetFileTypeInfoByFileTypeSuffix(suffix);
        }
    }
}

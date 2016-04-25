/**
 * ����
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
        /// ����ļ�����
        /// </summary>
        /// <param name="accessoryFile">�ļ�����</param>
        /// <returns>��ӵ��ļ�������id</returns>
        public static int AddAccessoryFile(AccessoryFileInfo accessoryFile)
        {
            return AccessoryFileService.AddAccessoryFile(accessoryFile);
        }

        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="accessoryFileId">�ļ�����id</param>
        /// <returns>�Ƿ�ɾ���ɹ�</returns>
        public static bool DeleteAccessoryFileById(int accessoryFileId)
        {
            return AccessoryFileService.DeleteAccessoryFileById(accessoryFileId);
        }

        /// <summary>
        /// ��ѯ���е��ļ�����
        /// </summary>
        /// <returns></returns>
        public static IList<AccessoryFileInfo> GetAllAccessoryFile()
        {
            return AccessoryFileService.GetAllAccessoryFile();
        }

        /// <summary>
        /// �����ļ�id��ѯ�ļ�����
        /// </summary>
        /// <param name="fileId">�ļ�id</param>
        /// <returns></returns>
        public static IList<AccessoryFileInfo> GetAccessoryFileByFileId(int fileId)
        {
            return AccessoryFileService.GetAccessoryFileByFileId(fileId);
        }

    }
}

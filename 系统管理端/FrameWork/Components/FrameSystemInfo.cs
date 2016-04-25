
using System;
using System.Collections.Generic;
using System.Text;
using FrameWork.Components;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net;
using System.Collections;
using System.Reflection;

namespace FrameWork
{
    /// <summary>
    /// 系统信息操作类
    /// </summary>
    public class FrameSystemInfo
    {
        #region - 变量 -

        /// <summary>
        /// 系统信息类
        /// </summary>
        public static sys_SystemInfoTable GetSystemInfoTable = null;

        #endregion

        #region - 属性 -

        /// <summary>
        /// 获取FrameWork名称
        /// </summary>
        public static string FrameWorkVerName
        {
            get
            {
                string FrameName = "";
                FrameName = GetSystemInfoTable.S_FrameWorkInfo.S_Name + " " + GetSystemInfoTable.S_FrameWorkInfo.S_Version + " " + S_VersionType.Release.ToString();
                return string.Format(" {0}<font size='2'>({1})</font>", FrameName, Common.GetDBType);
            }

        }

        #endregion

        #region - 构造函数 -

        /// <summary>
        /// 构造函数
        /// </summary>
        static FrameSystemInfo()
        {
            if (GetSystemInfoTable == null)
            {
                sys_SystemInfoTable si = new sys_SystemInfoTable();
                QueryParam qp = new QueryParam();
                qp.PageIndex = 1;
                qp.PageSize = 1;
                qp.OrderType = 0;
                int Recount = 0;

                ArrayList lst = BusinessFacade.sys_SystemInfoList(qp, out Recount);
                if (Recount == 0)
                {
                    si.DB_Option_Action_ = "Insert";
                    si.SystemID = BusinessFacade.sys_SystemInfoInsertUpdate(si);
                }
                else
                {
                    si = lst[0] as sys_SystemInfoTable;
                    //更新新加配置
                    sys_ConfigDataTable sys_ConfigDB = si.S_SystemConfigData;
                    sys_ConfigDataTable sys_Config = new sys_ConfigDataTable();
                    //foreach (PropertyInfo pi in new sys_ConfigDataTable().GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
                    foreach (PropertyInfo pi in sys_ConfigDB.GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
                    {
                        if (pi.GetValue(sys_ConfigDB, null) == null)
                        {
                            pi.SetValue(sys_ConfigDB, pi.GetValue(sys_Config, null), null);
                        }
                    }

                }
                GetSystemInfoTable = si;
            }
        }

        #endregion

        #region - 方法 -

        /// <summary>
        /// 序列化sys_FrameWorkInfoTable类
        /// </summary>
        /// <param name="it">sys_FrameWorkInfoTable类</param>
        /// <returns>byte[]字节流</returns>
        public static byte[] Serializable_sys_FrameWorkInfoTable(sys_FrameWorkInfoTable it)
        {
            IFormatter formatter = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            byte[] b;
            formatter.Serialize(ms, it);
            ms.Position = 0;
            b = new byte[ms.Length];
            ms.Read(b, 0, b.Length);
            ms.Close();
            return b;
        }

        /// <summary>
        /// 反序列化字节为sys_FrameWorkInfoTable类
        /// </summary>
        /// <param name="BytArray">字节流</param>
        /// <returns>sys_FrameWorkInfoTable类</returns>
        public static sys_FrameWorkInfoTable Deserialize_sys_FrameWorkInfoTable(byte[] BytArray)
        {
            IFormatter formatter = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            ms.Write(BytArray, 0, BytArray.Length);
            ms.Position = 0;
            sys_FrameWorkInfoTable it = formatter.Deserialize(ms) as sys_FrameWorkInfoTable;
            return it;
        }

        /// <summary>
        /// 序列化sys_ConfigDataTable类
        /// </summary>
        /// <param name="it">sys_ConfigDataTable类</param>
        /// <returns>byte[]字节流</returns>
        public static byte[] Serializable_sys_ConfigDataTable(sys_ConfigDataTable it)
        {
            IFormatter formatter = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            byte[] b;
            formatter.Serialize(ms, it);
            ms.Position = 0;
            b = new byte[ms.Length];
            ms.Read(b, 0, b.Length);
            ms.Close();
            return b;
        }

        /// <summary>
        /// 反序列化字节为sys_ConfigDataTable类
        /// </summary>
        /// <param name="BytArray">字节流</param>
        /// <returns>sys_ConfigDataTable类</returns>
        public static sys_ConfigDataTable Deserialize_sys_ConfigDataTable(byte[] BytArray)
        {
            IFormatter formatter = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            ms.Write(BytArray, 0, BytArray.Length);
            ms.Position = 0;
            sys_ConfigDataTable it = formatter.Deserialize(ms) as sys_ConfigDataTable;
            return it;
        }

        #endregion

    }
}

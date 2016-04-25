using System;
using System.Collections.Generic;
using System.Text;

namespace 企业人事管理系统
{
    class Secret
    {
        #region [函数] [加密]
        public string Fun_Secret(string Send_String)
        {
            byte[] Secret_Byte = UTF8Encoding.UTF8.GetBytes(Send_String);
            string Secret_String = Convert.ToBase64String(Secret_Byte);
            return Secret_String;
        }
        #endregion

        #region [函数] [解密]
        public string Fun_UnSecret(string Get_String)
        {
            byte[] UnSecret_Byte = Convert.FromBase64String(Get_String);
            string UnSecret_String = UTF8Encoding.UTF8.GetString(UnSecret_Byte);
            return UnSecret_String;
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FineOA.Model;

namespace FineOA.Web.Helper
{
    public class ConfigHelper
    {
        #region fields & constructor

        private static List<t_Config> _configs;

        private static List<String> changedKeys = new List<string>();

        public static List<t_Config> Configs
        {
            get
            {
                if (_configs == null)
                {
                    InitConfigs();
                }
                return _configs;
            }
        }

        public static void Reload()
        {
            _configs = null;
        }

        public static void InitConfigs()
        {
            BLL.t_Config bll = new BLL.t_Config();
            _configs = bll.GetModelList("");
        }

        #endregion

        #region methods

        /// <summary>
        /// 获取配置信息
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetValue(string key)
        {
            return Configs.Where(c => c.FConfigKey == key).Select(c => c.FConfigValue).FirstOrDefault();
        }

        /// <summary>
        /// 设置值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void SetValue(string key, string value)
        {
            BLL.t_Config bll = new BLL.t_Config();
            t_Config config = bll.GetModelList("FConfigKey='" + key + "'").FirstOrDefault();
            if (config != null)
            {
                if (config.FConfigValue != value)
                {
                    changedKeys.Add(key);
                    config.FConfigValue = value;
                }
            }
        }

        /// <summary>
        /// 保存所有更改的配置项
        /// </summary>
        public static void SaveAll()
        {
            BLL.t_Config bll = new BLL.t_Config();
            var changedConfigs = bll.GetModelList("").Where(c => changedKeys.Contains(c.FConfigKey));
            foreach (var changed in changedConfigs)
            {
                changed.FConfigValue = GetValue(changed.FConfigKey);
            }

            Reload();
        }

        #endregion

        #region properties

        /// <summary>
        /// 网站标题
        /// </summary>
        public static string Title
        {
            get
            {
                return GetValue("Title");
            }
            set
            {
                SetValue("Title", value);
            }
        }

        /// <summary>
        /// 列表每页显示的个数
        /// </summary>
        public static int PageSize
        {
            get
            {
                return Convert.ToInt32(GetValue("PageSize"));
            }
            set
            {
                SetValue("PageSize", value.ToString());
            }
        }

        /// <summary>
        /// 帮助下拉列表
        /// </summary>
        public static string HelpList
        {
            get
            {
                return GetValue("HelpList");
            }
            set
            {
                SetValue("HelpList", value);
            }
        }


        /// <summary>
        /// 菜单样式
        /// </summary>
        public static string MenuType
        {
            get
            {
                return GetValue("MenuType");
            }
            set
            {
                SetValue("MenuType", value);
            }
        }


        /// <summary>
        /// 网站主题
        /// </summary>
        public static string Theme
        {
            get
            {
                return GetValue("Theme");
            }
            set
            {
                SetValue("Theme", value);
            }
        }

        #endregion
    }
}
using System;
using System.Collections;
using System.Web;
using System.Web.UI;
using FrameWork.Components;

namespace FrameWork.web.Module.FrameWork.SystemState
{
    public partial class _default : System.Web.UI.Page
    {
        #region - 属性 -

        private string GetAppRunTime
        {
            get
            {
                TimeSpan span = DateTime.Now - FrameWorkPermission.AppStartTime;
                string result = span.Days.ToString() + "天 ";
                result += span.Hours.ToString() + "小时 ";
                result += span.Minutes.ToString() + "分 ";
                result += span.Seconds.ToString() + "秒";
                return result;
            }
        }

        private string GetSystemRunTime
        {
            get
            {
                int t = Environment.TickCount;
                if (t < 0) t = t + int.MaxValue;
                t = t / 1000;
                TimeSpan span = TimeSpan.FromSeconds(t);
                string result = span.Days.ToString() + "天 ";
                result += span.Hours.ToString() + "小时 ";
                result += span.Minutes.ToString() + "分 ";
                result += span.Seconds.ToString() + "秒";
                return result;
            }
        }

        #endregion - 属性 -

        #region - 事件 -

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                OnlineUser.Text = FrameWorkPermission.UserOnlineList.AllCount.ToString();
                CacheNum.Text = HttpRuntime.Cache.Count.ToString();
                CacheMax.Text = string.Format("{0}M", HttpRuntime.Cache.EffectivePrivateBytesLimit / 1024 / 1024);
                SystemOsName.Text = Common.GetServerOS;
                SystemRunTime.Text = GetSystemRunTime;
                AppRunTime.Text = GetAppRunTime;

                sys_FrameWorkInfoTable si = FrameSystemInfo.GetSystemInfoTable.S_FrameWorkInfo;
                SystemName.Text = FrameSystemInfo.FrameWorkVerName;
                //SystemName.Text = SystemName.Text + CheckUpdate.GetNewVerInfo;

                System.Diagnostics.Process ps = System.Diagnostics.Process.GetCurrentProcess();
                AppRunMemony.Text = string.Format("{0}M", ps.WorkingSet64 / 1024 / 1024);
                AppRunVirtualMemony.Text = string.Format("{0}M", ps.VirtualMemorySize64 / 1024 / 1024);
            }
            if (!FrameWorkPermission.CheckButtonPermission(PopedomType.Delete))
                TabOptionItem2.Visible = false;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            FrameWorkPermission.CheckPermissionVoid(PopedomType.A);
            FrameWorkLogin.UserOut();
            Response.Clear();
            Response.Write("Web应用程序已经重启, 请点击此处<a href=\"" + Page.ResolveClientUrl("~/") + "Default.aspx\">重新登入</a>.");
            Response.Flush();
            Response.Close();
            EventMessage.EventWriteDB(1, "重启Web应用程序成功!");
            HttpRuntime.UnloadAppDomain();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            FrameWorkPermission.CheckPermissionVoid(PopedomType.A);

            IDictionaryEnumerator id = HttpRuntime.Cache.GetEnumerator();
            while (id.MoveNext())
            {
                DictionaryEntry abc = id.Entry;
                string Tempstring = (string)id.Key;
                HttpRuntime.Cache.Remove(Tempstring);
            }
            EventMessage.MessageBox(1, "清空缓存!", "成功清空所有web缓存.", Icon_Type.OK, Common.GetScriptUrl);
        }

        #endregion - 事件 -
    }
}
using System;
using System.Collections;
using System.Web;
using System.Web.UI;
using FrameWork.Components;

namespace FrameWork.web.Module.FrameWork.SystemState
{
    public partial class _default : System.Web.UI.Page
    {
        #region - ���� -

        private string GetAppRunTime
        {
            get
            {
                TimeSpan span = DateTime.Now - FrameWorkPermission.AppStartTime;
                string result = span.Days.ToString() + "�� ";
                result += span.Hours.ToString() + "Сʱ ";
                result += span.Minutes.ToString() + "�� ";
                result += span.Seconds.ToString() + "��";
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
                string result = span.Days.ToString() + "�� ";
                result += span.Hours.ToString() + "Сʱ ";
                result += span.Minutes.ToString() + "�� ";
                result += span.Seconds.ToString() + "��";
                return result;
            }
        }

        #endregion - ���� -

        #region - �¼� -

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
            Response.Write("WebӦ�ó����Ѿ�����, �����˴�<a href=\"" + Page.ResolveClientUrl("~/") + "Default.aspx\">���µ���</a>.");
            Response.Flush();
            Response.Close();
            EventMessage.EventWriteDB(1, "����WebӦ�ó���ɹ�!");
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
            EventMessage.MessageBox(1, "��ջ���!", "�ɹ��������web����.", Icon_Type.OK, Common.GetScriptUrl);
        }

        #endregion - �¼� -
    }
}
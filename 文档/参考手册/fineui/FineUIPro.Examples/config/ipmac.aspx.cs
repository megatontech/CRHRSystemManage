using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace FineUIPro.Examples
{
    public partial class ipmac : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string[] ipmac = PageManager1.GetRequestIPMAC();
                labResult.Text = String.Format("fineui.com网站的IP地址：{0}<br>对应的MAC地址：{1}", ipmac[0], ipmac[1]);
            }
        }


    }
}

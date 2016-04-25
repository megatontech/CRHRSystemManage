using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FineUIPro.Examples.button
{
    public partial class button_click : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnClientClick2.OnClientClick = Alert.GetShowInTopReference("在Page_Load中注册的客户端事件");
            }
        }


        protected void btnServerClick_Click(object sender, EventArgs e)
        {
            Notify("这是服务器端事件");
        }


        protected void btnChangeClientClick2_Click(object sender, EventArgs e)
        {
            btnClientClick2.OnClientClick = Alert.GetShowInTopReference("客户端事件已改变！");
        }

    }
}

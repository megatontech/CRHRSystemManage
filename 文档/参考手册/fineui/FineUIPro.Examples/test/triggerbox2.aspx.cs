﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FineUIPro.Examples.form
{
    public partial class triggerbox2 : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // 点击 TriggerBox 弹出窗口
        protected void tbxMyBox1_TriggerClick(object sender, EventArgs e)
        {
            Window1.Hidden = false;
        }

        // 关闭弹出窗口
        protected void btnCloseWindow_Click(object sender, EventArgs e)
        {
            Window1.Hidden = true;

            tbxMyBox1.Text = "弹出窗口被关闭了";
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            tbxMyBox1.Enabled = true;
        }

    }
}

﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FineUIPro.Examples.message
{
    public partial class alert_custom_icon : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnHello_Click(object sender, EventArgs e)
        {
            
            Alert alert = new Alert();
            alert.Message = "你好 FineUI！";
            alert.Icon = Icon.Book;
            alert.Show();

        }

        protected void btnHello2_Click(object sender, EventArgs e)
        {
            Alert alert = new Alert();
            alert.Message = "你好 FineUI！";
            alert.IconUrl = "~/res/images/success.png";
            alert.Target = Target.Top;
            alert.Show();

        }

    }
}

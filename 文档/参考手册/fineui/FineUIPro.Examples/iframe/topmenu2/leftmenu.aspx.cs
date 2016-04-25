using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FineUIPro.Examples.iframe.topmenu2
{
    public partial class leftmenu : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string menuType = Request.QueryString["menu"];

                BindLeftTree(menuType);
            }
        }

        private void BindLeftTree(string menuType)
        {
            if (String.IsNullOrEmpty(menuType))
            {
                menuType = "mail";
            }

            if (menuType == "mail")
            {
                XmlDataSource1.DataFile = "~/iframe/topmenu2/data/menuMail.xml";
            }
            else if (menuType == "sys")
            {
                XmlDataSource1.DataFile = "~/iframe/topmenu2/data/menuSYS.xml";
            }
            else if (menuType == "sms")
            {
                XmlDataSource1.DataFile = "~/iframe/topmenu2/data/menuSMS.xml";
            }

            leftTree.DataSource = XmlDataSource1;
            leftTree.DataBind();
        }
    }
}
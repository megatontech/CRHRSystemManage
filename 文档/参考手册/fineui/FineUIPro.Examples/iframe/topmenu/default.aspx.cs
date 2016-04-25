using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace FineUIPro.Examples.iframe.topmenu
{
    public partial class _default : PageBase
    {

        #region Page_Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindLeftTree();
            }
        }

        #endregion

        #region BindLeftTree

        private void BindLeftTree(string menuType)
        {
            if (menuType == "mail")
            {
                XmlDataSource1.DataFile = "~/iframe/topmenu/data/menuMail.xml";
                PageContext.RegisterStartupScript("selectMenu('menu-mail');");
            }
            else if (menuType == "sys")
            {
                XmlDataSource1.DataFile = "~/iframe/topmenu/data/menuSYS.xml";
                PageContext.RegisterStartupScript("selectMenu('menu-sys');");
            }
            else if (menuType == "sms")
            {
                XmlDataSource1.DataFile = "~/iframe/topmenu/data/menuSMS.xml";
                PageContext.RegisterStartupScript("selectMenu('menu-sms');");
            }

            BindLeftTree();
        }

        private void BindLeftTree()
        {
            leftTree.DataSource = XmlDataSource1;
            leftTree.DataBind();
        } 

        #endregion

        #region Events

        protected void btnMail_Click(object sender, EventArgs e)
        {
            BindLeftTree("mail");
        }


        protected void btnSYS_Click(object sender, EventArgs e)
        {
            BindLeftTree("sys");
        }


        protected void btnSMS_Click(object sender, EventArgs e)
        {
            BindLeftTree("sms");
        }

        #endregion
    }

}
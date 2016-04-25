using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

namespace FineUIPro.Examples.basic
{
    public partial class login : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (tbxUserName.Text == "admin" && tbxPassword.Text == "admin")
            {
                Notify("成功登录！", MessageBoxIcon.Success);
            }
            else
            {
                Notify("用户名或密码错误！", MessageBoxIcon.Error);
            }
        }

    }
}

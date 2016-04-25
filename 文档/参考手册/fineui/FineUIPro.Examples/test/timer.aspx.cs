using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FineUIPro.Examples
{
    public partial class timer : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label1.Text = "Label1";
                rblU_Sex.SelectedValue = "2";
                Notify("ss", MessageBoxIcon.Information);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FineUIPro.Examples.message
{
    public partial class alert : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnHello_Click(object sender, EventArgs e)
        {
            Alert alert = new Alert();
            alert.Message = tbxMessage.Text;
            alert.Title = tbxTitle.Text;
            alert.MessageBoxIcon = (MessageBoxIcon)Enum.Parse(typeof(MessageBoxIcon), rblMessageBoxIcon.SelectedValue, true);
            alert.Target = (Target)Enum.Parse(typeof(Target), rblTarget.SelectedValue, true);



            if (!String.IsNullOrEmpty(nbWidth.Text))
            {
                alert.Width = Convert.ToInt32(nbWidth.Text);
            }

            if (!String.IsNullOrEmpty(nbMinWidth.Text))
            {
                alert.MinWidth = Convert.ToInt32(nbMinWidth.Text);
            }

            if (!String.IsNullOrEmpty(nbMaxWidth.Text))
            {
                alert.MaxWidth = Convert.ToInt32(nbMaxWidth.Text);
            }

            if (!String.IsNullOrEmpty(tbxID.Text))
            {
                alert.ID = tbxID.Text;
            }


            alert.Show();

        }


    }
}

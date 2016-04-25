using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FineUIPro.Examples.message
{
    public partial class prompt : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnHello_Click(object sender, EventArgs e)
        {
            Prompt prompt = new Prompt();
            prompt.Message = tbxMessage.Text;
            prompt.Title = tbxTitle.Text;
            prompt.MessageBoxIcon = (MessageBoxIcon)Enum.Parse(typeof(MessageBoxIcon), rblMessageBoxIcon.SelectedValue, true);
            prompt.Target = (Target)Enum.Parse(typeof(Target), rblTarget.SelectedValue, true);
            
            if (cbxIsMultiLine.Checked)
            {
                prompt.MultiLine = true;

                if (!String.IsNullOrEmpty(nbMultiLineHeight.Text))
                {
                    prompt.MultiLineHeight = Convert.ToInt32(nbMultiLineHeight.Text);
                }
            }
            prompt.DefaultValue = tbxDefaultValue.Text;

            if (!String.IsNullOrEmpty(nbWidth.Text))
            {
                prompt.Width = Convert.ToInt32(nbWidth.Text);
            }

            if (!String.IsNullOrEmpty(nbMinWidth.Text))
            {
                prompt.MinWidth = Convert.ToInt32(nbMinWidth.Text);
            }

            if (!String.IsNullOrEmpty(nbMaxWidth.Text))
            {
                prompt.MaxWidth = Convert.ToInt32(nbMaxWidth.Text);
            }

            if (!String.IsNullOrEmpty(tbxID.Text))
            {
                prompt.ID = tbxID.Text;
            }


            // 最后一个参数true，目的是将 "'Prompt$'+arguments[0]" 原样输出
            prompt.OkScript = PageManager1.GetCustomEventReference("'Prompt$'+arguments[0]", false, true);

            prompt.Show();

        }

        protected void PageManager1_CustomEvent(object sender, CustomEventArgs e)
        {
            if (e.EventArgument.IndexOf("Prompt$") == 0)
            {
                string address = e.EventArgument.Substring("Prompt$".Length);
                address = address.Replace("\r\n", "\n").Replace("\r", "\n").Replace("\n", "<br/>");
                Notify("你输入的住址是：" + address);

            }
        }

        protected void cbxIsMultiLine_CheckedChanged(object sender, CheckedEventArgs e)
        {
            nbMultiLineHeight.Hidden = !e.Checked;
        }




    }
}

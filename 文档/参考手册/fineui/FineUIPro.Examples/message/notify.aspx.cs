using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FineUIPro.Examples.message
{
    public partial class notify : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Notify notify = new Notify();
                //notify.Message = "正在加载中...";
                //notify.ShowLoading = true;
                //notify.PositionX = Position.Center;
                //notify.PositionY = Position.Center;

                //btnHello.OnClientClick = notify.GetShowReference();
            }
        }

        protected void btnHello_Click(object sender, EventArgs e)
        {
            Notify notify = new Notify();
            notify.Message = tbxMessage.Text;
           
            notify.MessageBoxIcon = (MessageBoxIcon)Enum.Parse(typeof(MessageBoxIcon), rblMessageBoxIcon.SelectedValue, true);
            notify.Target = (Target)Enum.Parse(typeof(Target), rblTarget.SelectedValue, true);
            
            
            if (!String.IsNullOrEmpty(nbWidth.Text))
            {
                notify.Width = Convert.ToInt32(nbWidth.Text);
            }

            if (cbxShowHeader.Checked)
            {
                notify.ShowHeader = true;

                if (!String.IsNullOrEmpty(tbxTitle.Text))
                {
                    notify.Title = tbxTitle.Text;
                }

                notify.EnableDrag = cbxEnableDrag.Checked;
                notify.EnableClose = cbxEnableClose.Checked;
            }
            else
            {
                notify.ShowHeader = false;
            }


            notify.DisplayMilliseconds = Convert.ToInt32(nbDisplayMilliseconds.Text);

            notify.PositionX = (Position)Enum.Parse(typeof(Position), rblPositionX.SelectedValue, true);
            notify.PositionY = (Position)Enum.Parse(typeof(Position), rblPositionY.SelectedValue, true);

            notify.IsModal = cbxIsModal.Checked;

            if (!String.IsNullOrEmpty(tbxBodyPadding.Text))
            {
                notify.BodyPadding = tbxBodyPadding.Text;
            }

            notify.MessageAlign = (TextAlign)Enum.Parse(typeof(TextAlign), ddlMessageAlign.SelectedValue, true);

            if (cbxShowLoading.Checked)
            {
                notify.ShowLoading = true;
            }

            if (!String.IsNullOrEmpty(nbMinWidth.Text))
            {
                notify.MinWidth = Convert.ToInt32(nbMinWidth.Text);
            }

            if (!String.IsNullOrEmpty(nbMaxWidth.Text))
            {
                notify.MaxWidth = Convert.ToInt32(nbMaxWidth.Text);
            }

            if (!String.IsNullOrEmpty(tbxID.Text))
            {
                notify.ID = tbxID.Text;
            }


            notify.HideScript = PageManager1.GetCustomEventReference("HideNotify");


            notify.Show();

        }


        protected void cbxShowHeader_CheckedChanged(object sender, CheckedEventArgs e)
        {
            tbxTitle.Hidden = !e.Checked;
            cbxEnableDrag.Hidden = !e.Checked;
            cbxEnableClose.Hidden = !e.Checked;
        }

        protected void PageManager1_CustomEvent(object sender, CustomEventArgs e)
        {
            if (e.EventArgument == "HideNotify")
            {
                Notify("通知框消失了！");
            }
        }




    }
}

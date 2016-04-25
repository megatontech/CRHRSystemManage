using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FineUIPro.Examples.form
{
    public partial class form_disabled : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void btnDisableAll_Click(object sender, EventArgs e)
        {
            ResolveFormField(delegate(Field field)
            {
                field.Enabled = false;
            });
        }

        protected void btnEnableAll_Click(object sender, EventArgs e)
        {
            ResolveFormField(delegate(Field field)
            {
                field.Enabled = true;
            });
        }

        protected void btnReadOnlyAll_Click(object sender, EventArgs e)
        {
            ResolveFormField(delegate(Field field)
            {
                if (!(field is Label))
                {
                    field.Readonly = true;
                }
            });
        }

        protected void btnCancelReadOnlyAll_Click(object sender, EventArgs e)
        {
            ResolveFormField(delegate(Field field)
            {
                if (!(field is Label))
                {
                    field.Readonly = false;
                }
            });
        }

        protected void btnMarkInvalid_Click(object sender, EventArgs e)
        {
            ResolveFormField(delegate(Field field)
            {
                if (!(field is Label))
                {
                    field.MarkInvalid("这个字段出错了！");
                }
            });
        }

        protected void btnClearInvalid_Click(object sender, EventArgs e)
        {
            ResolveFormField(delegate(Field field)
            {
                if (!(field is Label))
                {
                    field.ClearInvalid();
                }
            });
        }




        private delegate void ProcessFormField(Field field);

        private void ResolveFormField(ProcessFormField process)
        {
            foreach (FormRow row in Form1.Rows)
            {
                foreach (Field field in row.Items)
                {
                    if (field != null)
                    {
                        process(field);
                    }
                }
            }
        }



        protected void Button1_Click(object sender, EventArgs e)
        {
            Notify("表单提交成功！");
        }

    }
}

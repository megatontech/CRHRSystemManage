using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FineUIPro.Examples.form
{
    public partial class form_update_label : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }

        protected void btnSubmitForm2_Click(object sender, EventArgs e)
        {
            Notify("表单验证并提交成功！");
        }


        protected void btnUpdateLabel_Click(object sender, EventArgs e)
        {
            if (labPhone.Label == "移动电话")
            {
                labPhone.Label = "固定电话";
            }
            else
            {
                labPhone.Label = "移动电话";
            }
        }

        protected void btnRemoveRequired_Click(object sender, EventArgs e)
        {
            tbxEmail.ShowRedStar = false;
            tbxEmail.Required = false;
        }

        protected void btnRemoveRegex_Click(object sender, EventArgs e)
        {
            tbxEmail.RegexPattern = RegexPattern.None;
        }

        protected void btnRemoveMinLength_Click(object sender, EventArgs e)
        {
            taDescription.MinLength = null;
        }

        protected void btnRemoveValue_Click(object sender, EventArgs e)
        {
            nbxApplyNumber.MaxValue = 10;
        }

        protected void btnModifyMinDate_Click(object sender, EventArgs e)
        {
            dpApplyTime.MaxDate = DateTime.Now;
        }

        
    }
}

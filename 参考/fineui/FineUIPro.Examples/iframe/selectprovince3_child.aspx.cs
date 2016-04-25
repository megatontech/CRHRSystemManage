using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FineUIPro.Examples.iframe
{
    public partial class selectprovince3_child : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // 设置图片的 usemap 属性
                imgChina.Attributes["usemap"] = "#ChinaMap";

                labNote.Text = "图片来源：<a href=\"http://www.sbsm.gov.cn/article/zxbs/dtfw/\" target=\"_blank\">http://www.sbsm.gov.cn/article/zxbs/dtfw/</a>";
            }
            else
            {
                string eventArgument = GetRequestEventArgument();
                if (eventArgument.StartsWith("SelectProvince$"))
                {
                    PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference(eventArgument));
                }
            }
        }


    }
}

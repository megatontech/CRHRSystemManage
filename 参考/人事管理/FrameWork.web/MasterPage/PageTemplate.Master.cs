using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
namespace FrameWork.web.MasterPage
{
    public partial class PageTemplate : System.Web.UI.MasterPage
    {
        public string TableSink = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            TableSink = Common.TableSink;
        }
    }
}

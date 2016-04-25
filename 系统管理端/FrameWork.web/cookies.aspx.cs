using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Specialized;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using FrameWork;
using FrameWork.Components;
using FrameWork.WebControls;

namespace FrameWork.web
{
    public partial class cookies : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 在此处放置用户代码以初始化页面
            HttpCookieCollection cookies;

            HttpCookie oneCookie;

            cookies = Request.Cookies;

            string[] cookieArray = cookies.AllKeys;

            //for (int i = -2 ; i < cookieArray.Length; i++)
            //{

            //    oneCookie = cookies[cookieArray[i]];

            //    Response.Write(oneCookie.Name + " - " + oneCookie.Value + "<br>");

            //}

            WriteServerVaribales();
        }

        public void WriteServerVaribales()
        {

            NameValueCollection nk = Request.ServerVariables;
            for (int i = 0; i < nk.Count; i++)
            {
                Response.Write(string.Format("name:{0},Value:{1}<br>", nk.GetKey(i), nk.Get(i)));
            }
        }
    }
}

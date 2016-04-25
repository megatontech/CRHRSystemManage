using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;

namespace FineUIPro.Examples.aspnet
{
    public partial class ckeditor_two : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HtmlEditor1.Text = "<p>FineUI（开源版）<br>基于 ExtJS 的开源 ASP.NET 控件库。<br><br>FineUI的使命<br>创建 No JavaScript，No CSS，No UpdatePanel，No ViewState，No WebServices 的网站应用程序。<br><br>支持的浏览器<br>IE 8.0+、Chrome、Firefox、Opera、Safari<br><br>授权协议<br>Apache License 2.0 (Apache)<br><br>相关链接<br>论坛：http://fineui.com/bbs/<br>示例：http://fineui.com/demo/<br>文档：http://fineui.com/doc/<br>下载：http://fineui.codeplex.com/</p>";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(HtmlEditor1.Text))
            {
                Notify("文章正文不能为空！");
                return;
            }

            Notify("文章标题：" + HttpUtility.HtmlEncode(tbxTitle.Text) +
                "<br/>" + "文章正文：" + HttpUtility.HtmlEncode(HtmlEditor1.Text) +
                "<br/>" + "文章摘要：" + HttpUtility.HtmlEncode(HtmlEditor2.Text));
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"<[^>]+>|</[^>]+>");
            string content = regex.Replace(HtmlEditor1.Text, "");
            if (content.Length > 100)
            {
                content = content.Substring(0, 97) + "...";
            }

            HtmlEditor2.Text = content;
        }





    }
}

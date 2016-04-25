<%@ WebHandler Language="C#" Class="download" %>

using System;
using System.Web;
using System.IO;
using System.Text;
using System.Collections.Specialized;

public class download : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        StringBuilder result = new StringBuilder();
        
        NameValueCollection queries = context.Request.QueryString;
        foreach(string queryName in queries.AllKeys) {
            result.AppendFormat("请求参数：{0}\t\t值：{1}", queryName, queries[queryName]);
            result.AppendLine();
        }
        result.AppendLine();
        result.AppendFormat("请求时间：" + DateTime.Now.ToString());
        
        
        

        context.Response.ClearContent();
        context.Response.AddHeader("content-disposition", "attachment; filename=download.txt");
        context.Response.ContentType = "text/plain";
        context.Response.ContentEncoding = System.Text.Encoding.UTF8;
        context.Response.Write(result);
        context.Response.End();
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}
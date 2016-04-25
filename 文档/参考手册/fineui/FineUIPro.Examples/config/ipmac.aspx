<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ipmac.aspx.cs" Inherits="FineUIPro.Examples.ipmac" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../res/css/main.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server"></f:PageManager>
        <f:Label runat="server" EncodeText="false" ID="labResult"></f:Label>
        <br />
        <br />
        <br />
        页面代码：
        <pre>
protected void Page_Load(object sender, EventArgs e)
{
    if (!IsPostBack)
    {
        string[] ipmac = PageManager1.GetRequestIPMAC();
        labResult.Text = String.Format("fineui.com网站的IP地址：{0} 对应的MAC地址：{1}", ipmac[0], ipmac[1]);
    }
}
        </pre>
    </form>
</body>
</html>

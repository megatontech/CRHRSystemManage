<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hello_aspnet.aspx.cs" Inherits="FineUIPro.Examples.basic.hello_aspnet" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../res/css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button Text="点击弹出对话框" runat="server" ID="btnHello" OnClick="btnHello_Click" />
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tree_document.aspx.cs"
    Inherits="FineUIPro.Examples.tree.databind.tree_document" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <meta name="sourcefiles" content="~/tree/databind/website.xml" />
    <link href="../../res/css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" />
        <f:Tree ID="Tree1" Width="550px" ShowHeader="true" EnableCollapse="true"
            Title="树控件（绑定到 XmlDocument）" runat="server">
        </f:Tree>
        <br />
        <f:Button ID="btnClear" Text="清空树" CssClass="marginr" OnClick="btnClear_Click" runat="server"></f:Button>
        <f:Button ID="btnReBind" Text="重新绑定树" CssClass="marginr" OnClick="btnReBind_Click" runat="server"></f:Button>
    </form>
</body>
</html>

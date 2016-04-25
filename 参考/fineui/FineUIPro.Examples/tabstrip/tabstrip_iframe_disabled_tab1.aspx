<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tabstrip_iframe_disabled_tab1.aspx.cs"
    Inherits="FineUIPro.Examples.tabstrip.tabstrip_iframe_disabled_tab1" %>

<!DOCTYPE html>
<html>
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../res/css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" />
        <f:Button runat="server" ID="btnEnabledTab2" OnClick="btnEnableTabs_Click" Text="启用后两个标签">
        </f:Button>
        <br />
        <br />
        <f:Button runat="server" ID="Button1" OnClick="btnDisableTabs_Click" Text="禁用后两个标签">
        </f:Button>
    </form>
</body>
</html>

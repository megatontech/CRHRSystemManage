<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="button_iconfont.aspx.cs" Inherits="FineUIPro.Examples.button.button_iconfont" %>

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
        <f:Button ID="btnIcon1" Text="图标在左侧" IconFont="Home" runat="server" CssClass="marginr" />
        <f:Button ID="btnIcon2" Text="图标在右侧" IconAlign="Right" IconFont="Car" runat="server" />
        <br />
        <br />
        <f:Button ID="btnIcon3" Text="图标在上面" IconAlign="Top" IconFont="Camera" runat="server"
            CssClass="marginr" />
        <f:Button ID="btnIcon4" Text="图标在下面" IconAlign="Bottom" IconFont="Phone" runat="server" />
        <br />
        <br />
        <f:Button ID="btnCustomIcon" Text="点击修改图标（在三个图标之前切换）" OnClick="btnCustomIcon_Click"
            IconFont="VolumeUp" runat="server" />
        <br />
        <br />
        只有图片的按钮：
        <br />
        <br />
        <f:Button ID="Button1" IconFont="Android" CssClass="marginr" runat="server" />
        <f:Button ID="Button2" IconFont="Apple" runat="server" />
        <br />
    </form>
</body>
</html>

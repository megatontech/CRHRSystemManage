<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="timer.aspx.cs" Inherits="FineUIPro.Examples.other.timer" %>

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
        <f:Timer ID="Timer1" Interval="5" Enabled="false" OnTick="Timer1_Tick" EnableAjaxLoading="false" runat="server">
        </f:Timer>
        <f:Button ID="btnStartTimer" runat="server" CssClass="marginr" Text="启动定时器"
            OnClick="btnStartTimer_Click">
        </f:Button>
        <f:Button ID="btnStopTimer" runat="server" Enabled="false" Text="停止定时器" OnClick="btnStopTimer_Click">
        </f:Button>
        <br />
        <br />
        点击“启动定时器”，下面的文本会每隔 5 秒钟更新一次。
        <br />
        <f:Label ID="labServerTime" runat="server" CssStyle="color:red;">
        </f:Label>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="confirm_cancel2.aspx.cs"
    Inherits="FineUIPro.Examples.message.confirm_cancel2" %>

<!DOCTYPE html>
<html>
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../res/css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" OnCustomEvent="PageManager1_CustomEvent" runat="server" />
        <f:Button Text="操作（点击确定、取消都会回发页面）" runat="server" ID="btnOperation" EnablePostBack="false">
        </f:Button>
    </form>
</body>
</html>

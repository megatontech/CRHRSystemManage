<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="button_custom.aspx.cs" Inherits="FineUIPro.Examples.button.button_custom" %>

<!DOCTYPE html>
<html>
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../res/css/main.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .bgbtn {
            background-image: url(../res/images/login.png) !important;
            width: 320px;
            height: 50px;
            border-width: 0;
            background-color: transparent !important;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" />
        <f:Button ID="Button1" Text="普通按钮" runat="server" Size="Large" OnClick="Button1_Click" />
        <br />
        <br />

        <f:Button ID="Button2" Text="" CssClass="bgbtn" runat="server" OnClick="Button2_Click" />

    </form>
</body>
</html>

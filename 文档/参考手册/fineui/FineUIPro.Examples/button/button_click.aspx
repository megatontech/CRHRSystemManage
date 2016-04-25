<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="button_click.aspx.cs" Inherits="FineUIPro.Examples.button.button_click" %>

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
        <f:Button ID="btnServerClick" Text="服务器端事件" OnClick="btnServerClick_Click" runat="server">
        </f:Button>
        <br />
        <br />
        <f:Button ID="btnClientClick" Text="客户端事件" OnClientClick="alert('这是客户端事件');" EnablePostBack="false"
            CssClass="marginr" runat="server">
        </f:Button>
        <br />
        <br />
        <f:Button ID="btnClientClick2" Text="客户端事件（Page_Load中注册）" EnablePostBack="false" runat="server">
        </f:Button>
        <br />
        <br />
        <f:Button ID="btnChangeClientClick2" Text="改变上个按钮的客户端事件" OnClick="btnChangeClientClick2_Click" runat="server">
        </f:Button>
        <br />
        <br />

    </form>
</body>
</html>

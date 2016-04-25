<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addtab.aspx.cs" Inherits="FineUIPro.Examples.other.addtab" %>

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
        <f:Button ID="Button1" runat="server" EnablePostBack="false" OnClientClick="openHelloFineUI();"
            Text="向父页面添加选项卡">
        </f:Button>
        <br />
        <br />
        <f:Button ID="Button4" runat="server" EnablePostBack="false" OnClientClick="openHelloFineUI2();"
            Text="向父页面添加选项卡（图标字体，与上个按钮添加的选项卡为同一个">
        </f:Button>
        <br />
        <br />
        <f:Button ID="Button2" runat="server" EnablePostBack="false" OnClientClick="closeActiveTab();"
            Text="关闭当前选项卡">
        </f:Button>
        <br />
        <br />
        <f:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="关闭当前选项卡（服务器端注册脚本）">
        </f:Button>
    </form>
    <script type="text/javascript">

        var basePath = '<%= ResolveUrl("~/") %>';

        function openHelloFineUI() {
            parent.addExampleTab({
                id: 'hello_fineui_tab',
                iframeUrl: basePath + 'basic/hello.aspx',
                title: '你好 FineUI',
                icon: basePath + 'res/images/filetype/vs_aspx.png',
                refreshWhenExist: true
            });
        }

        function openHelloFineUI2() {
            // 这里的 id 和上面的相同，所以会使用同一个选项卡
            parent.addExampleTab({
                id: 'hello_fineui_tab',
                iframeUrl: basePath + 'basic/login.aspx',
                title: '登陆页面',
                iconFont: 'sign-in',
                refreshWhenExist: true
            });
        }

        function closeActiveTab() {
            parent.removeActiveTab();
        }
    </script>
</body>
</html>

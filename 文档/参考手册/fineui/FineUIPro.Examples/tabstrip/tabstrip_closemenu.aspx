<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tabstrip_closemenu.aspx.cs"
    Inherits="FineUIPro.Examples.tabstrip.tabstrip_closemenu" %>

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
        <f:TabStrip ID="TabStrip1" Width="850px" Height="350px" EnableTabCloseMenu="true"
            ShowBorder="true" ActiveTabIndex="1" runat="server">
            <Tabs>
                <f:Tab ID="Tab1" Title="标签一" EnableClose="false" BodyPadding="5px" runat="server">
                    <Items>
                        <f:Label ID="Label5" Text="标签一中的文本" runat="server" />
                    </Items>
                </f:Tab>
                <f:Tab ID="Tab2" Title="标签二" BodyPadding="5px" EnableClose="true" runat="server">
                    <Items>
                        <f:Label ID="Label4" Text="标签二中的文本" runat="server" />
                    </Items>
                </f:Tab>
                <f:Tab ID="Tab3" Title="标签三" Hidden="true" BodyPadding="5px" EnableClose="true" runat="server">
                    <Items>
                        <f:Label ID="Label3" Text="标签三中的文本" runat="server" />
                    </Items>
                </f:Tab>
                <f:Tab ID="Tab4" Title="标签四" BodyPadding="5px" EnableClose="true" runat="server">
                    <Items>
                        <f:Label ID="Label2" Text="标签四中的文本" runat="server" />
                    </Items>
                </f:Tab>
                <f:Tab ID="Tab5" EnableClose="true" Title="标签五" BodyPadding="5px" runat="server">
                    <Items>
                        <f:Label ID="Label1" Text="标签五中的文本" runat="server" />
                    </Items>
                </f:Tab>
            </Tabs>
        </f:TabStrip>
        <br />
        <br />
        <f:Button ID="btnShowInClient" Text="显示标签三（客户端代码）" CssClass="marginr"
            EnablePostBack="false" runat="server">
        </f:Button>
        <f:Button ID="btnHideInClient" Text="隐藏标签三（客户端代码）" EnablePostBack="false" runat="server">
        </f:Button>
        <br />
        <br />
        <f:Button ID="btnShowInServer" Text="显示标签三（服务端代码）" CssClass="marginr"
            runat="server" OnClick="btnShowInServer_Click">
        </f:Button>
        <f:Button ID="btnHideInServer" Text="隐藏标签三（服务端代码）" runat="server" OnClick="btnHideInServer_Click">
        </f:Button>
        <br />
        <br />
        <br />
        注：在选项卡上点击鼠标右键，会看到自定义菜单项。
    </form>
    <script>
        var tabStripClientID = '<%= TabStrip1.ClientID %>';

        F.ready(function () {
            var newItem = new F.MenuItem({
                text: '用户自定义菜单项',
                handler: function () {
                    // this.parent: 菜单项所属的菜单对象
                    // this.parent.target: 菜单依附的对象，这里是选项卡
                    var tab = this.parent.target;
                    if (tab.isType('tab')) {
                        F.notify({
                            message: '点击了选项卡 ['+ tab.getTitle() +'] 的自定义菜单项',
                            header: false,
                            displayMilliseconds: 3000,
                            positionX: 'center',
                            positionY: 'top'
                        });
                    }
                }
            })

            var closeMenu = F(tabStripClientID).getCloseMenu();

            // 将自定义菜单项插入开始位置
            //closeMenu.insert(0, [newItem, new F.MenuSeparator()]);

            // 将自定义菜单项插入结束位置
            closeMenu.add([new F.MenuSeparator(), newItem]);
        });
    </script>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tabstrip_iframe.aspx.cs"
    Inherits="FineUIPro.Examples.tabstrip.tabstrip_iframe" %>

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
        <f:TabStrip ID="TabStrip1" Width="850px" Height="450px" ShowBorder="true" ActiveTabIndex="1"
            runat="server">
            <Tabs>
                <f:Tab ID="Tab1" BodyPadding="5px" Title="标签一" runat="server">
                    <Items>
                        <f:Label ID="Label1" Text="文本" runat="server">
                        </f:Label>
                        <f:ContentPanel ID="ContentPanel1" BodyPadding="5px" ShowBorder="true" ShowHeader="true"
                            Title="内容面板" runat="server">
                            这是内容面板中的内容。
                        </f:ContentPanel>
                    </Items>
                </f:Tab>
                <f:Tab ID="Tab2" EnableIFrame="true" BodyPadding="5px" IFrameUrl="../window/group_panel.aspx"
                    Title="标签二 - IFrame - 延迟加载" runat="server">
                    <Listeners>
                        <f:Listener Event="iframeload" Handler="onTab2IFrameLoad" />
                    </Listeners>
                </f:Tab>
                <f:Tab ID="Tab3" EnableIFrame="true" BodyPadding="5px" IFrameUrl="../window/panel.aspx"
                    Title="标签三 - IFrame - 延迟加载" runat="server">
                    <Listeners>
                        <f:Listener Event="iframeload" Handler="onTab3IFrameLoad" />
                    </Listeners>
                </f:Tab>
            </Tabs>
        </f:TabStrip>
        <br />
        <br />
        注：标签二 和 标签三 中的IFrame加载完毕时，会在右下角显示提示框。
    </form>
    <script>

        function onTab2IFrameLoad() {
            F.notify('标签二中的IFrame加载完毕！');
        }

        function onTab3IFrameLoad() {
            F.notify('标签三中的IFrame加载完毕！');
        }

        //var tab2ClientID = '<%= Tab2.ClientID %>';
        //var tab3ClientID = '<%= Tab3.ClientID %>';

        //F.ready(function () {

        //    F(tab2ClientID).on('iframeload', function () {
        //        F.notify('标签二中的IFrame加载完毕！');
        //    });

        //    F(tab3ClientID).on('iframeload', function () {
        //        F.notify('标签三中的IFrame加载完毕！');
        //    });

        //});

    </script>
</body>
</html>

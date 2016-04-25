<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="panel_tools.aspx.cs" Inherits="FineUIPro.Examples.window.panel_tools" %>

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
        <f:Panel ID="Panel1" runat="server" Title="面板" Width="800px" Height="350px"
            BodyPadding="10px" EnableCollapse="True" IconUrl="~/res/images/16/8.png">
            <Items>
                <f:Label runat="server" Text="面板内容"></f:Label>
            </Items>
            <Tools>
                <f:Tool runat="server" IconFont="Gear" ToolTip="设置" EnablePostBack="false">
                    <Listeners>
                        <f:Listener Event="click" Handler="onToolIconClick" />
                    </Listeners>
                </f:Tool>
                <f:Tool ID="Tool13" runat="server" IconFont="Wrench" ToolTip="设置" EnablePostBack="false">
                    <Listeners>
                        <f:Listener Event="click" Handler="onToolIconClick" />
                    </Listeners>
                </f:Tool>
                <f:Tool ID="Tool1" runat="server" IconFont="Download" ToolTip="下载" EnablePostBack="false">
                    <Listeners>
                        <f:Listener Event="click" Handler="onToolIconClick" />
                    </Listeners>
                </f:Tool>
                <f:Tool ID="Tool3" runat="server" IconFont="Upload" ToolTip="上传" EnablePostBack="false">
                    <Listeners>
                        <f:Listener Event="click" Handler="onToolIconClick" />
                    </Listeners>
                </f:Tool>
                <f:Tool ID="Tool2" runat="server" IconFont="Print" ToolTip="打印" EnablePostBack="false">
                    <Listeners>
                        <f:Listener Event="click" Handler="onToolIconClick" />
                    </Listeners>
                </f:Tool>

                <f:Tool ID="Tool4" runat="server" IconFont="Save" ToolTip="保存" EnablePostBack="false">
                    <Listeners>
                        <f:Listener Event="click" Handler="onToolIconClick" />
                    </Listeners>
                </f:Tool>
                <f:Tool ID="Tool18" runat="server" IconFont="Plus" ToolTip="新增" EnablePostBack="false">
                    <Listeners>
                        <f:Listener Event="click" Handler="onToolIconClick" />
                    </Listeners>
                </f:Tool>
                <f:Tool ID="Tool10" runat="server" IconFont="Pencil" ToolTip="编辑" EnablePostBack="false">
                    <Listeners>
                        <f:Listener Event="click" Handler="onToolIconClick" />
                    </Listeners>
                </f:Tool>
                <f:Tool ID="Tool5" runat="server" IconFont="Minus" ToolTip="删除" EnablePostBack="false">
                    <Listeners>
                        <f:Listener Event="click" Handler="onToolIconClick" />
                    </Listeners>
                </f:Tool>
                <f:Tool ID="Tool14" runat="server" IconFont="Trash" ToolTip="删除" EnablePostBack="false">
                    <Listeners>
                        <f:Listener Event="click" Handler="onToolIconClick" />
                    </Listeners>
                </f:Tool>
                <f:Tool ID="Tool15" runat="server" IconFont="Close" ToolTip="删除" EnablePostBack="false">
                    <Listeners>
                        <f:Listener Event="click" Handler="onToolIconClick" />
                    </Listeners>
                </f:Tool>
                <f:Tool ID="Tool6" runat="server" IconFont="SignIn" ToolTip="登陆" EnablePostBack="false">
                    <Listeners>
                        <f:Listener Event="click" Handler="onToolIconClick" />
                    </Listeners>
                </f:Tool>
                <f:Tool ID="Tool11" runat="server" IconFont="PowerOff" ToolTip="退出" EnablePostBack="false">
                    <Listeners>
                        <f:Listener Event="click" Handler="onToolIconClick" />
                    </Listeners>
                </f:Tool>
                <f:Tool ID="Tool8" runat="server" IconFont="Reply" ToolTip="回复" EnablePostBack="false">
                    <Listeners>
                        <f:Listener Event="click" Handler="onToolIconClick" />
                    </Listeners>
                </f:Tool>
                <f:Tool ID="Tool9" runat="server" IconFont="Question" ToolTip="帮助" EnablePostBack="false">
                    <Listeners>
                        <f:Listener Event="click" Handler="onToolIconClick" />
                    </Listeners>
                </f:Tool>
                <f:Tool ID="Tool20" runat="server" IconFont="Info" ToolTip="详细" EnablePostBack="false">
                    <Listeners>
                        <f:Listener Event="click" Handler="onToolIconClick" />
                    </Listeners>
                </f:Tool>
                <f:Tool ID="Tool12" runat="server" IconFont="Search" ToolTip="搜索" EnablePostBack="false">
                    <Listeners>
                        <f:Listener Event="click" Handler="onToolIconClick" />
                    </Listeners>
                </f:Tool>


                <f:Tool ID="Tool16" runat="server" IconFont="Undo" ToolTip="重置" EnablePostBack="false">
                    <Listeners>
                        <f:Listener Event="click" Handler="onToolIconClick" />
                    </Listeners>
                </f:Tool>
                <f:Tool ID="Tool17" runat="server" IconFont="Key" ToolTip="授权" EnablePostBack="false">
                    <Listeners>
                        <f:Listener Event="click" Handler="onToolIconClick" />
                    </Listeners>
                </f:Tool>
                <f:Tool ID="Tool7" runat="server" IconFont="User" ToolTip="用户" EnablePostBack="false">
                    <Listeners>
                        <f:Listener Event="click" Handler="onToolIconClick" />
                    </Listeners>
                </f:Tool>
                <f:Tool ID="Tool19" runat="server" IconFont="Group" ToolTip="分组" EnablePostBack="false">
                    <Listeners>
                        <f:Listener Event="click" Handler="onToolIconClick" />
                    </Listeners>
                </f:Tool>
            </Tools>
        </f:Panel>
        <br />
        <f:Button ID="Button2" CssClass="marginr" Text="检查面板的折叠状态" runat="server" OnClick="Button2_Click">
        </f:Button>
    </form>
    <script>

        function onToolIconClick(event) {
            F.notify({
                message: '你点击了标题栏图标字体：' + this.iconFont,
                header: false,
                displayMilliseconds: 3000,
                positionX: 'center',
                positionY: 'center'
            });
        }

    </script>
</body>
</html>

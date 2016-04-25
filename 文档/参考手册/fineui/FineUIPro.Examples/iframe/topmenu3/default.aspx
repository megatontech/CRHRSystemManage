<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="default.aspx.cs" Inherits="FineUIPro.Examples.iframe.topmenu3._default" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>顶部菜单框架（左侧IFrame中的手风琴）</title>
    <meta name="sourcefiles" content="~/iframe/topmenu3/leftmenu.aspx" />
    <style>
        .centerregion {
            border-left-width: 0;
        }

        #header table {
            width: 100%;
            border-spacing: 0;
            border-collapse: collapse;
        }

            #header table td {
                padding: 0;
            }


        #header .logotd {
            width: 200px;
        }


        #header .logo {
            font-size: 24px;
            font-weight: bold;
            text-decoration: none;
            display: inline-block;
            vertical-align: middle;
            margin: 0 10px;
        }



        #header .f-btn {
            border-width: 0;
            padding: 10px;
        }

        #header .icontopaction .f-btn-icon {
            width: 24px;
            font-size: 24px;
            margin-left: -12px;
            line-height: 24px;
            height: 24px;
        }

        #header .icontopaction .f-btn-text {
            font-size: 12px;
            line-height: 16px;
            padding-top: 24px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="RegionPanel1" runat="server"></f:PageManager>
        <f:Panel ID="RegionPanel1" Layout="Region" ShowBorder="false" ShowHeader="false" runat="server">
            <Items>
                <f:ContentPanel ID="topPanel" CssClass="topregion" RegionPosition="Top" ShowBorder="false" ShowHeader="false" EnableCollapse="true" runat="server">
                    <div id="header" class="ui-widget-header f-mainheader">
                        <table>
                            <tr>
                                <td class="logotd">
                                    <a class="logo" href="./default.aspx" title="某某某管理系统">某某某管理系统
                                    </a>
                                </td>
                                <td>
                                    <f:Button runat="server" CssClass="icontopaction topmenu menu-mail ui-state-active" ID="btnMail" Text="邮件收发"
                                        IconAlign="Top" IconFont="EnvelopeO" EnablePostBack="false" EnableDefaultState="false" EnableDefaultCorner="false">
                                    </f:Button>
                                    <f:Button runat="server" CssClass="icontopaction topmenu menu-sms" ID="btnSMS" Text="短信收发"
                                        IconAlign="Top" IconFont="MobilePhone" EnablePostBack="false" EnableDefaultState="false" EnableDefaultCorner="false">
                                    </f:Button>
                                    <f:Button runat="server" CssClass="icontopaction topmenu menu-sys" ID="btnSYS" Text="系统管理"
                                        IconAlign="Top" IconFont="Cog" EnablePostBack="false" EnableDefaultState="false" EnableDefaultCorner="false">
                                    </f:Button>
                                </td>
                            </tr>
                        </table>
                    </div>
                </f:ContentPanel>
                <f:Panel runat="server" ID="leftPanel" CssClass="leftregion" RegionPosition="Left" RegionSplit="false" EnableCollapse="false"
                    Width="200px" Title="系统菜单" ShowBorder="true" ShowHeader="false"
                    EnableIFrame="true" IFrameName="leftframe" IFrameUrl="./leftmenu.aspx">
                </f:Panel>
                <f:Panel ID="mainPanel" CssClass="centerregion" ShowHeader="false" RegionPosition="Center" ShowBorder="true"
                    EnableIFrame="true" IFrameName="menu3mainframe" runat="server">
                </f:Panel>
            </Items>
        </f:Panel>
    </form>

    <script>

        var leftPanelID = '<%= leftPanel.ClientID %>';

        F.ready(function () {
            var menuLis = $('#header .topmenu');
            menuLis.click(function (e) {
                var cnode = $(this);
                var classNames = /menu\-(\w+)/.exec(cnode.attr('class'));
                if (classNames.length == 2) {
                    var menuType = classNames[1];

                    menuLis.removeClass('ui-state-active');
                    cnode.addClass('ui-state-active');

                    // 在左侧区域内打开链接
                    F(leftPanelID).setIFrameUrl('./leftmenu.aspx?menu=' + encodeURIComponent(menuType));

                    //window.frames['leftframe'].location.href = './leftmenu.aspx?menu=' + encodeURIComponent(menuType);
                }
            });



        });
    </script>
</body>
</html>

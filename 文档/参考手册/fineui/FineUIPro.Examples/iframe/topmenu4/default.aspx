<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="default.aspx.cs" Inherits="FineUIPro.Examples.iframe.topmenu4._default" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>顶部菜单框架（中间区域选项卡）</title>
    <meta name="sourcefiles" content="~/iframe/topmenu4/leftmenu.aspx;~/iframe/topmenu4/data/menuMail.xml;~/iframe/topmenu4/data/menuSMS.xml;~/iframe/topmenu4/data/menuSYS.xml;" />
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
                <f:Panel runat="server" ID="leftPanel" CssClass="leftregion" RegionPosition="Left" RegionSplit="false" EnableCollapse="true"
                    Width="200px" Title="系统菜单" ShowBorder="true" ShowHeader="true" EnableIFrame="true" IFrameName="leftframe" IFrameUrl="./leftmenu.aspx">
                </f:Panel>
                <f:TabStrip ID="mainTabStrip" CssClass="centerregion" RegionPosition="Center" EnableTabCloseMenu="true" ShowBorder="true" runat="server">
                    <Tabs>
                        <f:Tab ID="Tab1" Title="首页" Layout="Fit" Icon="House" CssClass="maincontent" runat="server">
                            <Items>
                                <f:ContentPanel ID="ContentPanel1" ShowBorder="false" BodyPadding="10px" ShowHeader="false" AutoScroll="true"
                                    runat="server">
                                    首页内容
                                </f:ContentPanel>
                            </Items>
                        </f:Tab>
                    </Tabs>
                </f:TabStrip>
            </Items>
        </f:Panel>
    </form>

    <script>
        var mainTabStripClientID = '<%= mainTabStrip.ClientID %>';
        var leftPanelID = '<%= leftPanel.ClientID %>';

        F.ready(function () {

            var menuLis = $('#header .topmenu');

            function updateLeftMenu(menuType) {

                menuLis.removeClass('ui-state-active');
                menuLis.filter('.menu-' + menuType).addClass('ui-state-active');

                // 在左侧区域内打开链接
                F(leftPanelID).setIFrameUrl('./leftmenu.aspx?menu=' + encodeURIComponent(menuType));

                //window.frames['leftframe'].location.href = './leftmenu.aspx?menu=' + encodeURIComponent(menuType);
            }

            // 点击顶部菜单，加载左侧IFrame菜单
            menuLis.click(function (e) {
                var cnode = $(this);
                var classNames = /menu\-(\w+)/.exec(cnode.attr('class'));
                if (classNames.length == 2) {
                    var menuType = classNames[1];

                    updateLeftMenu(menuType);
                }
            });

            // 根据页面的Hash值，来初始化左侧IFrame菜单
            var hash = window.location.hash;
            var hashArray = /.+\/html\/(.+)\-\d+\.html/.exec(hash);
            if (hashArray && hashArray.length === 2) {
                updateLeftMenu(hashArray[1]);
            } else {
                updateLeftMenu('mail');
            }


            window.initTreeTabStrip = function (tree) {
                // 初始化主框架中的树(或者Accordion+Tree)和选项卡互动，以及地址栏的更新
                // treeMenu： 主框架中的树控件实例，或者内嵌树控件的手风琴控件实例
                // mainTabStrip： 选项卡实例
                // addTabCallback： 创建选项卡前的回调函数（接受tabConfig参数）
                // updateLocationHash: 切换Tab时，是否更新地址栏Hash值
                // refreshWhenExist： 添加选项卡时，如果选项卡已经存在，是否刷新内部IFrame
                // refreshWhenTabChange: 切换选项卡时，是否刷新内部IFrame
                // hashWindow：需要更新Hash值的窗口对象，默认为当前window
                F.util.initTreeTabStrip(tree, F(mainTabStripClientID), null, true, false, false);
            };


        });


    </script>
</body>
</html>

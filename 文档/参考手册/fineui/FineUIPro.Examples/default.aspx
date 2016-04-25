<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="FineUIPro.Examples._default" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>FineUI（专业版）在线示例 - 基于 jQuery 的专业 ASP.NET 控件库</title>
    <link rel="shortcut icon" type="image/x-icon" href="favicon.ico" />
    <meta name="Title" content="基于 jQuery 的专业 ASP.NET 控件库(jQuery based professional ASP.NET Controls)" />
    <meta name="Description" content="FineUI 的使命是创建 No JavaScript，No CSS，No UpdatePanel，No ViewState，No WebServices 的网站应用程序" />
    <meta name="Keywords" content="jQuery,jQueryUI,FineUI,ASP.NET,控件库,AJAX,Web2.0" />
    <meta name="sourcefiles" content="~/code/PageBase.cs;~/common/menu.xml;~/common/themes.aspx" />
    <style>
        .leftregion.accordioninside > .f-panel-header {
            border-bottom-width: 0;
        }


        #header table {
            width: 100%;
            border-spacing: 0;
            border-collapse: separate;
        }

            #header table td {
                padding: 0;
            }

        #header .logo {
            font-size: 24px;
            font-weight: bold;
            text-decoration: none;
            display: inline-block;
            vertical-align: middle;
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


        #header .icononlyaction .f-btn-icon,
        #header .icononlyaction .f-btn-text {
            width: 30px;
            font-size: 30px;
            line-height: 40px;
            height: 40px;
        }



        #header .userpicaction .f-btn-icon {
            border-radius: 50%;
            width: 36px;
            height: 36px;
            top: 50%;
            margin-top: -18px;
        }

        #header .userpicaction .f-btn-text {
            margin-left: 45px;
            font-size: 14px;
            line-height: 40px;
        }


        ul.list {
            list-style-type: none;
            padding: 0;
            margin: 0;
        }

            ul.list li {
                margin-bottom: 5px;
            }

        .important {
            border-style: solid;
            border-width: 3px;
            display: inline-block;
            padding: 20px;
            position: absolute;
            top: 10px;
            right: 10px;
        }


        .isnew {
            color: red;
        }

        .tabtool {
            margin-right: 10px;
        }

            .tabtool .ui-icon {
                font-size: 18px;
                font-weight: normal;
                width: 18px;
                height: 18px;
            }


        .bottomtable {
            width: 100%;
            font-size: 12px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="Panel1" runat="server"></f:PageManager>
        <f:Panel ID="Panel1" Layout="Region" ShowBorder="false" ShowHeader="false" runat="server">
            <Items>
                <f:ContentPanel ID="topPanel" CssClass="topregion" RegionPosition="Top" ShowBorder="false" ShowHeader="false" EnableCollapse="true" runat="server">
                    <div id="header" class="ui-widget-header f-mainheader">
                        <table>
                            <tr>
                                <td>
                                    <f:Button runat="server" CssClass="icononlyaction" ID="btnHomePage" ToolTip="官网首页" IconAlign="Top" IconFont="Home"
                                        EnablePostBack="false" EnableDefaultState="false" EnableDefaultCorner="false">
                                        <Listeners>
                                            <f:Listener Event="click" Handler="onHomePageClick" />
                                        </Listeners>
                                    </f:Button>
                                    <a class="logo" href="./default.aspx" title="FineUI首页">FineUI（专业版）在线示例
                                    </a>
                                </td>
                                <td style="text-align: right;">
                                    <f:Button runat="server" CssClass="icontopaction" ID="btnDownloadPublic" Text="下载公测版" IconAlign="Top" IconFont="Download"
                                        EnablePostBack="false" EnableDefaultState="false" EnableDefaultCorner="false">
                                        <Listeners>
                                            <f:Listener Event="click" Handler="onDownloadPublicClick" />
                                        </Listeners>
                                    </f:Button>
                                    <f:Button runat="server" CssClass="icontopaction" ID="btnNextTheme" Text="下一个主题" IconAlign="Top" IconFont="Magic"
                                        EnablePostBack="false" EnableDefaultState="false" EnableDefaultCorner="false">
                                        <Listeners>
                                            <f:Listener Event="click" Handler="onNextThemeClick" />
                                        </Listeners>
                                    </f:Button>
                                    <f:Button runat="server" CssClass="icontopaction" ID="btnThemeSelect" Text="主题仓库" IconAlign="Top" IconFont="Bank"
                                        EnablePostBack="false" EnableDefaultState="false" EnableDefaultCorner="false">
                                        <Listeners>
                                            <f:Listener Event="click" Handler="onThemeSelectClick" />
                                        </Listeners>
                                    </f:Button>
                                    <f:Button runat="server" CssClass="userpicaction" ID="Button1" Text="三生石上" IconUrl="~/res/images/my_face_80.jpg" IconAlign="Left"
                                        EnablePostBack="false" EnableDefaultState="false" EnableDefaultCorner="false">
                                        <Menu runat="server">
                                            <f:MenuButton Text="个人信息" IconFont="User" EnablePostBack="false" runat="server">
                                                <Listeners>
                                                    <f:Listener Event="click" Handler="onUserProfileClick" />
                                                </Listeners>
                                            </f:MenuButton>
                                            <f:MenuSeparator runat="server"></f:MenuSeparator>
                                            <f:MenuButton Text="安全退出" IconFont="SignOut" EnablePostBack="false" runat="server">
                                                <Listeners>
                                                    <f:Listener Event="click" Handler="onSignOutClick" />
                                                </Listeners>
                                            </f:MenuButton>
                                        </Menu>
                                    </f:Button>
                                </td>
                            </tr>
                        </table>
                    </div>
                </f:ContentPanel>
                <f:Panel ID="leftPanel" CssClass="leftregion" RegionPosition="Left" RegionSplit="true" ShowBorder="true" Width="220px" ShowHeader="true" Title="&nbsp;"
                    EnableCollapse="true" Collapsed="false" Layout="Fit" runat="server">
                    <Tools>
                        <f:Tool runat="server" IconFont="Gear" EnablePostBack="false">
                            <Menu runat="server" ID="menuSettings">
                                <f:MenuButton ID="btnExpandAll" Text="展开菜单" EnablePostBack="false" runat="server">
                                    <Listeners>
                                        <f:Listener Event="click" Handler="onExpandAllClick" />
                                    </Listeners>
                                </f:MenuButton>
                                <f:MenuButton ID="btnCollapseAll" Text="折叠菜单" EnablePostBack="false" runat="server">
                                    <Listeners>
                                        <f:Listener Event="click" Handler="onCollapseAllClick" />
                                    </Listeners>
                                </f:MenuButton>
                                <f:MenuSeparator runat="server">
                                </f:MenuSeparator>
                                <f:MenuCheckBox runat="server" ID="cbxShowOnlyNew" Text="仅显示最新示例">
                                    <Listeners>
                                        <f:Listener Event="click" Handler="onShowOnlyNewClick" />
                                    </Listeners>
                                </f:MenuCheckBox>
                                <f:MenuSeparator ID="MenuSeparator1" runat="server">
                                </f:MenuSeparator>
                                <f:MenuButton EnablePostBack="false" Text="菜单样式" ID="MenuStyle" runat="server">
                                    <Menu ID="Menu1" runat="server">
                                        <Items>
                                            <f:MenuCheckBox Text="树菜单" ID="MenuStyleTree" Checked="true" GroupName="MenuStyle" runat="server">
                                            </f:MenuCheckBox>
                                            <f:MenuCheckBox Text="手风琴+树菜单" ID="MenuStyleAccordion" GroupName="MenuStyle" runat="server">
                                            </f:MenuCheckBox>
                                        </Items>
                                        <Listeners>
                                            <f:Listener Event="itemcheckchange" Handler="onMenuStyleItemCheckChange" />
                                        </Listeners>
                                    </Menu>
                                </f:MenuButton>
                                <f:MenuButton EnablePostBack="false" Text="语言" ID="MenuLang" runat="server">
                                    <Menu ID="Menu2" runat="server">
                                        <Items>
                                            <f:MenuCheckBox Text="简体中文" ID="MenuLangZHCN" Checked="true" GroupName="MenuLang" runat="server">
                                            </f:MenuCheckBox>
                                            <f:MenuCheckBox Text="繁體中文" ID="MenuLangZHTW" GroupName="MenuLang" runat="server">
                                            </f:MenuCheckBox>
                                            <f:MenuCheckBox Text="English" ID="MenuLangEN" GroupName="MenuLang" runat="server">
                                            </f:MenuCheckBox>
                                        </Items>
                                        <Listeners>
                                            <f:Listener Event="itemcheckchange" Handler="onMenuLangItemCheckChange" />
                                        </Listeners>
                                    </Menu>
                                </f:MenuButton>
                                <f:MenuSeparator ID="MenuSeparator2" runat="server">
                                </f:MenuSeparator>
                                <f:MenuHyperLink ID="MenuHyperLink2" runat="server" Text="转到开源版示例" NavigateUrl="http://fineui.com/demo/" Target="_blank">
                                </f:MenuHyperLink>
                            </Menu>
                        </f:Tool>
                    </Tools>
                </f:Panel>
                <f:TabStrip ID="mainTabStrip" CssClass="centerregion" RegionPosition="Center" ShowBorder="true" EnableTabCloseMenu="true" runat="server">
                    <Tabs>
                        <f:Tab Title="首页" BodyPadding="10px" AutoScroll="true" IconFont="Home" CssClass="maincontent" runat="server">
                            <Content>
                                <div class="important ui-widget ui-state-highlight">
                                    相比开源版，FineUI（专业版）有明显的性能提升：
                                    <ul>
                                        <li>客户端 JS 库仅 150K（GZIP压缩）
                                        </li>
                                        <li>下载流量减少 70%
                                        </li>
                                        <li>内存占用减少 50%
                                        </li>
                                        <li>速度提升 3 倍以上（第一次访问）
                                        </li>
                                    </ul>
                                    <a href="http://fineui.com/bbs/forum.php?mod=viewthread&tid=5971" target="_blank">查看详细的测试数据&gt;&gt;&gt;&gt;&gt;&gt;</a>
                                </div>
                                <h2>FineUI（专业版）</h2>
                                基于 jQuery 的专业 ASP.NET 控件库
                                        
                                <br />
                                <h2>FineUI的使命</h2>
                                创建 No JavaScript，No CSS，No UpdatePanel，No ViewState，No WebServices 的网站应用程序
                                        
                                <br />
                                <h2>支持的浏览器</h2>
                                IE 8.0+、Chrome、Firefox、Opera、Safari
                                        
                                <br />
                                <h2>授权协议</h2>
                                商业授权
                                            
                                <br />
                                <h2>相关链接</h2>
                                <ul class="list">
                                    <li>首页：<a target="_blank" href="http://fineui.com/pro/">http://fineui.com/pro/</a>
                                    </li>
                                    <li>示例：<a target="_blank" href="http://fineui.com/demo_pro/">http://fineui.com/demo_pro/</a>
                                    </li>
                                    <li>更新：<a target="_blank" href="http://fineui.com/version_pro/">http://fineui.com/version_pro/</a>
                                    </li>
                                    <li>论坛：<a target="_blank" href="http://fineui.com/bbs/">http://fineui.com/bbs/</a>
                                    </li>
                                </ul>
                            </Content>
                        </f:Tab>
                    </Tabs>
                    <Tools>
                        <f:Tool runat="server" EnablePostBack="false" IconFont="Eye" CssClass="tabtool" ToolTip="查看源代码" ID="toolSourceCode">
                            <Listeners>
                                <f:Listener Event="click" Handler="onToolSourceCodeClick" />
                            </Listeners>
                        </f:Tool>
                        <f:Tool runat="server" EnablePostBack="false" IconFont="Refresh" CssClass="tabtool" ToolTip="刷新" ID="toolRefresh">
                            <Listeners>
                                <f:Listener Event="click" Handler="onToolRefreshClick" />
                            </Listeners>
                        </f:Tool>
                        <f:Tool runat="server" EnablePostBack="false" IconFont="ExternalLink" CssClass="tabtool" ToolTip="在新标签页中打开" ID="toolNewWindow">
                            <Listeners>
                                <f:Listener Event="click" Handler="onToolNewWindowClick" />
                            </Listeners>
                        </f:Tool>
                        <f:Tool runat="server" EnablePostBack="false" IconFont="Expand" CssClass="tabtool" ToolTip="最大化" ID="toolMaximize">
                            <Listeners>
                                <f:Listener Event="click" Handler="onToolMaximizeClick" />
                            </Listeners>
                        </f:Tool>
                    </Tools>
                    <Listeners>
                        <f:Listener Event="tabchange" Handler="onMainTabStripChange" />
                        <f:Listener Event="render" Handler="onMainTabStripChange" />
                    </Listeners>
                </f:TabStrip>
                <f:ContentPanel ID="bottomPanel" CssClass="bottomregion" RegionPosition="Bottom" ShowBorder="false" ShowHeader="false" EnableCollapse="false" runat="server">
                    <table class="bottomtable ui-widget-header f-mainheader">
                        <tr>
                            <td style="width: 200px;">&nbsp;版本：<a target="_blank" href="http://fineui.com/version_pro">v<asp:Literal runat="server" ID="litVersion"></asp:Literal></a>
                                &nbsp;&nbsp; <a target="_blank" href="http://wpa.qq.com/msgrd?v=3&uin=2877408506&site=qq&menu=yes">专业版咨询</a></td>
                            <td style="text-align: center;">Copyright &copy; 2014 合肥三生石上软件有限公司</td>
                            <td style="width: 200px; text-align: right;">在线人数：<asp:Literal runat="server" ID="litOnlineUserCount"></asp:Literal>&nbsp;</td>
                        </tr>
                    </table>
                </f:ContentPanel>
            </Items>
        </f:Panel>
        <f:Window ID="windowSourceCode" IconFont="Code" Title="源代码" Hidden="true" EnableIFrame="true"
            runat="server" IsModal="true" Width="1000px" Height="600px" EnableClose="true"
            EnableMaximize="true" EnableResize="true">
        </f:Window>
        <f:Window ID="windowThemeRoller" Title="主题" Hidden="true" EnableIFrame="true" IFrameUrl="./common/themes.aspx" ClearIFrameAfterClose="false"
            runat="server" IsModal="true" Width="1000px" Height="600px" EnableClose="true"
            EnableMaximize="true" EnableResize="true">
        </f:Window>
        <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/common/menu.xml"></asp:XmlDataSource>

    </form>

    <script>

        var toolRefreshClientID = '<%= toolRefresh.ClientID %>';
        var toolNewWindowClientID = '<%= toolNewWindow.ClientID %>';
        var windowSourceCodeClientID = '<%= windowSourceCode.ClientID %>';
        var mainTabStripClientID = '<%= mainTabStrip.ClientID %>';
        var windowThemeRollerClientID = '<%= windowThemeRoller.ClientID %>';
        var MenuStyleClientID = '<%= MenuStyle.ClientID %>';
        var MenuLangClientID = '<%= MenuLang.ClientID %>';
        var leftPanelClientID = '<%= leftPanel.ClientID %>';
        var topPanelClientID = '<%= topPanel.ClientID %>';

        // 点击官网首页
        function onHomePageClick(event) {
            window.open('http://fineui.com/pro/', '_blank');
        }

        // 点击下载公测版
        function onDownloadPublicClick(event) {
            window.open('http://fineui.com/pro/', '_blank');
        }

        // 点击主题仓库
        function onThemeSelectClick(event) {
            var windowThemeRoller = F(windowThemeRollerClientID);
            windowThemeRoller.show();
        }

        // 点击下一个主题
        function onNextThemeClick(event) {
            var themes = [["default", "Default"], ["metro_blue", "Metro Blue"], ["metro_dark_blue", "Metro Dark Blue"], ["metro_gray", "Metro Gray"], ["metro_green", "Metro Green"], ["metro_orange", "Metro Orange"], ["black_tie", "Black Tie"], ["blitzer", "Blitzer"], ["cupertino", "Cupertino"], ["dark_hive", "Dark Hive"], ["dot_luv", "Dot Luv"], ["eggplant", "Eggplant"], ["excite_bike", "Excite Bike"], ["flick", "Flick"], ["hot_sneaks", "Hot Sneaks"], ["humanity", "Humanity"], ["le_frog", "Le Frog"], ["mint_choc", "Mint Choc"], ["overcast", "Overcast"], ["pepper_grinder", "Pepper Grinder"], ["redmond", "Redmond"], ["smoothness", "Smoothness"], ["south_street", "South Street"], ["start", "Start"], ["sunny", "Sunny"], ["swanky_purse", "Swanky Purse"], ["trontastic", "Trontastic"], ["ui_darkness", "UI Darkness"], ["ui_lightness", "UI Lightness"], ["vader", "Vader"]];

            var themeName = F.cookie('Theme_Pro');
            if (!themeName) {
                themeName = 'default';
            }

            var themeIndex = 0, themeCount = themes.length;
            $.each(themes, function (index, item) {
                if (item[0] === themeName) {
                    themeIndex = index;
                }
            });
            themeIndex++;

            if (themeIndex === themeCount) {
                themeIndex = 0;
            }

            var nextTheme = themes[themeIndex];

            //var randomTheme = themes[Math.floor(Math.random() * themes.length)];

            F.cookie('Theme_Pro', nextTheme[0], {
                path: '/',
                expires: 100  // 单位：天
            });
            F.cookie('Theme_Pro_Title', nextTheme[1], {
                path: '/',
                expires: 100  // 单位：天
            });
            top.window.location.reload();
        }

        // 点击展开菜单
        function onExpandAllClick(event) {
            var leftPanel = F(leftPanelClientID);
            var firstChild = leftPanel.items[0];

            if (firstChild.isType('tree')) {
                // 左侧为树控件
                firstChild.expandAll();
            } else {
                // 左侧为树控件+手风琴控件
                var activePane = firstChild.getActivePane();
                if (activePane) {
                    activePane.items[0].expandAll();
                }
            }
        }

        // 点击折叠菜单
        function onCollapseAllClick(event) {
            var leftPanel = F(leftPanelClientID);
            var firstChild = leftPanel.items[0];

            if (firstChild.isType('tree')) {
                // 左侧为树控件
                firstChild.collapseAll();
            } else {
                // 左侧为树控件+手风琴控件
                var activePane = firstChild.getActivePane();
                if (activePane) {
                    activePane.items[0].collapseAll();
                }
            }
        }


        // 点击仅显示最新案例
        function onShowOnlyNewClick(event) {
            F.cookie('ShowOnlyNew_Pro', this.isChecked(), {
                path: '/',
                expires: 100 // 单位：天
            });
            top.window.location.reload();
        }


        // 点击标题栏工具图标 - 查看源代码
        function onToolSourceCodeClick(event) {
            var mainTabStrip = F(mainTabStripClientID);
            var windowSourceCode = F(windowSourceCodeClientID);


            var activeTab = mainTabStrip.getActiveTab();
            var iframeWnd, iframeUrl;
            if (activeTab.iframe) {

                iframeWnd = activeTab.getIFrameWindow();
                iframeUrl = activeTab.getIFrameUrl();

            } else {
                iframeWnd = window;
                iframeUrl = '../default.aspx';
            }

            var files = [iframeUrl];
            var sourcefilesNode = $(iframeWnd.document).find('head meta[name=sourcefiles]');
            if (sourcefilesNode.length) {
                $.merge(files, sourcefilesNode.attr('content').split(';'));
            }
            windowSourceCode.f_show('./common/source.aspx?files=' + encodeURIComponent(files.join(';')));
        }

        // 点击标题栏工具图标 - 刷新
        function onToolRefreshClick(event) {
            var mainTabStrip = F(mainTabStripClientID);

            var activeTab = mainTabStrip.getActiveTab();
            if (activeTab.iframe) {
                var iframeWnd = activeTab.getIFrameWindow();
                iframeWnd.location.reload();
            }
        }

        // 点击标题栏工具图标 - 在新标签页中打开
        function onToolNewWindowClick(event) {
            var mainTabStrip = F(mainTabStripClientID);

            var activeTab = mainTabStrip.getActiveTab();
            if (activeTab.iframe) {
                window.open(activeTab.getIFrameUrl(), '_blank');
            }
        }

        // 点击标题栏工具图标 - 最大化
        function onToolMaximizeClick(event) {
            var topPanel = F(topPanelClientID);
            var leftPanel = F(leftPanelClientID);

            var currentTool = this;
            if (currentTool.iconFont.indexOf('expand') >= 0) {
                topPanel.collapse();
                leftPanel.collapse();
                currentTool.setIconFont('compress');
            } else {
                topPanel.expand();
                leftPanel.expand();
                currentTool.setIconFont('expand');
            }
        }

        // TabStrip的选项卡切换
        function onMainTabStripChange(event, tab) {
            var toolRefresh = F(toolRefreshClientID);
            var toolNewWindow = F(toolNewWindowClientID);

            var mainTabStrip = F(mainTabStripClientID);

            var activeTab = mainTabStrip.getActiveTab();
            if (activeTab.iframe) {
                toolRefresh.enable();
                toolNewWindow.enable();
            } else {
                toolRefresh.disable();
                toolNewWindow.disable();
            }
        }


        // 添加示例标签页
        // id： 选项卡ID
        // iframeUrl: 选项卡IFrame地址 
        // title： 选项卡标题
        // icon： 选项卡图标
        // createToolbar： 创建选项卡前的回调函数（接受tabOptions参数）
        // refreshWhenExist： 添加选项卡时，如果选项卡已经存在，是否刷新内部IFrame
        function addExampleTab(tabOptions) {
            var mainTabStrip = F(mainTabStripClientID);

            if (typeof (id) === 'string') {
                tabOptions = {
                    id: arguments[0],
                    iframeUrl: arguments[1],
                    title: arguments[2],
                    icon: arguments[3],
                    createToolbar: arguments[4],
                    refreshWhenExist: arguments[5]
                };
            }

            F.util.addMainTab(mainTabStrip, tabOptions);
        }


        // 移除选中标签页
        function removeActiveTab() {
            var mainTabStrip = F(mainTabStripClientID);

            var activeTab = mainTabStrip.getActiveTab();
            mainTabStrip.removeTab(activeTab.id);
        }

        // 通知框
        function notify(msg) {
            F.notify({
                message: msg,
                messageIcon: 'information',
                target: '_top',
                header: false,
                displayMilliseconds: 2000,
                positionX: 'center',
                positionY: 'center'
            });
        }

        // 点击菜单样式
        function onMenuStyleItemCheckChange(event, item) {
            var menuStyle = 'accordion';
            if (item.isChecked() && item.id.indexOf('MenuStyleTree') >= 0) {
                menuStyle = 'tree';
            }
            F.cookie('MenuStyle_Pro', menuStyle, {
                path: '/',
                expires: 100 // 单位：天
            });
            top.window.location.reload();
        }

        // 点击语言
        function onMenuLangItemCheckChange(event, item) {
            var lang = 'en';
            if (item.isChecked()) {
                if (item.id.indexOf('MenuLangZHCN') >= 0) {
                    lang = 'zh_CN';
                } else if (item.id.indexOf('MenuLangZHTW') >= 0) {
                    lang = 'zh_TW';
                }
            }
            F.cookie('Language_Pro', lang, {
                path: '/',
                expires: 100 // 单位：天
            });
            top.window.location.reload();
        }

        function onSignOutClick() {
            notify('尚未实现');
        }

        function onUserProfileClick() {
            notify('尚未实现');
        }


        F.ready(function () {

            var mainTabStrip = F(mainTabStripClientID);

            var leftPanel = F(leftPanelClientID);
            var mainMenu = leftPanel.items[0];



            // 初始化主框架中的树(或者Accordion+Tree)和选项卡互动，以及地址栏的更新
            // treeMenu： 主框架中的树控件实例，或者内嵌树控件的手风琴控件实例
            // mainTabStrip： 选项卡实例
            // createToolbar： 创建选项卡前的回调函数（接受tabConfig参数）
            // updateLocationHash: 切换Tab时，是否更新地址栏Hash值
            // refreshWhenExist： 添加选项卡时，如果选项卡已经存在，是否刷新内部IFrame
            // refreshWhenTabChange: 切换选项卡时，是否刷新内部IFrame
            F.util.initTreeTabStrip(mainMenu, mainTabStrip, null, true, false, false);


            var themeTitle = F.cookie('Theme_Pro_Title');
            if (themeTitle) {
                F.removeCookie('Theme_Pro_Title', {
                    path: '/',
                });
                notify('主题更改为：' + themeTitle);
            }

        });


    </script>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="FineOA.Web.main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head runat="server">
    <title>首页</title>
    <link href="Resources/css/main.css" rel="stylesheet" text="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <x:PageManager ID="PageManager1" AutoSizePanelID="regionPanel" HideScrollbar="true"
        runat="server" />
    <x:RegionPanel ID="regionPanel" ShowBorder="false" runat="server">
        <Regions>
            <x:Region ID="regionTop" Height="95px" ShowBorder="false" ShowHeader="false" Position="Top"
                Layout="Fit" runat="server">
                <Toolbars>
                    <x:Toolbar ID="Toolbar1" Position="Bottom" runat="server">
                        <Items>
                            <x:ToolbarText ID="txtUser" runat="server">
                            </x:ToolbarText>
                            <x:ToolbarSeparator runat="server" />
                            <x:ToolbarText ID="txtOnlineUserCount" runat="server">
                            </x:ToolbarText>
                            <x:ToolbarSeparator runat="server" />
                            
                            <x:ToolbarText ID="txtCurrentTime" runat="server">
                            </x:ToolbarText>
                            <x:ToolbarFill runat="server" />
                            <x:Button ID="btnShowHideHeader" runat="server" Icon="SectionExpanded" ToolTip="隐藏标题栏"
                                EnablePostBack="false">
                            </x:Button>
                            <x:ToolbarSeparator ID="ToolbarSeparator1" runat="server" />
                            <x:Button ID="btnRefresh" runat="server" Icon="ArrowRotateClockwise" ToolTip="刷新主区域内容"
                                EnablePostBack="false">
                            </x:Button>
                            <x:ToolbarSeparator runat="server" />
                            <x:Button ID="btnHelp" EnablePostBack="false" Icon="Help" Text="帮助" runat="server">
                            </x:Button>
                            <x:ToolbarSeparator runat="server" />
                            <x:Button ID="btnExit" runat="server" Icon="ControlPowerBlue" Text="安全退出" ConfirmText="确定退出系统？"
                                OnClick="btnExit_Click">
                            </x:Button>
                        </Items>
                    </x:Toolbar>
                </Toolbars>
                <Items>
                    <x:ContentPanel ShowBorder="false" ShowHeader="false" ID="ContentPanel1" runat="server">
                        <div id="titlebar">
                            <div id="left">
                                <div class="minor">
                                    CRSoft 2014</div>
                                <div class="title">
                                    <a href="./main.aspx" style="color: #00568d; text-decoration: none;">
                                        <%= FineOA.Web.Helper.ConfigHelper.Title%></a><span class="title-sub"><asp:Literal
                                            ID="litProductVersion" runat="server"></asp:Literal></span></div>
                               
                            </div>
                            <div id="right">
                                <x:Image runat="server" AjaxLoadingType="Default" ImageWidth="68px" BoxConfigAlign="Center" ImageUrl="~/Resources/images/logo.png"></x:Image>
                                <a href="#"></a>
                            </div>
                            
                        </div>
                    </x:ContentPanel>
                </Items>
            </x:Region>
            <x:Region ID="regionLeft" Split="true" Icon="Outline" EnableCollapse="true" Width="200px"
                ShowHeader="true" Title="系统菜单" Layout="Fit" Position="Left" runat="server">
            </x:Region>
            <x:Region ID="mainRegion" ShowHeader="false" Layout="Fit" Margins="0 0 0 0" Position="Center"
                runat="server">
                <Items>
                    <x:TabStrip ID="mainTabStrip" EnableTabCloseMenu="true" ShowBorder="false" runat="server">
                        <Tabs>
                            <x:Tab ID="Tab1" Title="首页" EnableIFrame="true" IFrameUrl="~/admin/home.aspx" Icon="House"
                                runat="server">
                            </x:Tab>
                        </Tabs>
                    </x:TabStrip>
                </Items>
            </x:Region>
        </Regions>
    </x:RegionPanel>
    <x:Window ID="Window1" runat="server" IsModal="true" Hidden="true" EnableIFrame="true"
        EnableResize="true" EnableMaximize="true" IFrameUrl="about:blank" Width="650px"
        Height="450px">
    </x:Window>
    </form>
    <script src="Resources/js/main.js" type="text/javascript"></script>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="FineOA.Web.admin.Home" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Resources/css/main.css" rel="stylesheet" text="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <x:PageManager ID="PageManager1" AutoSizePanelID="Panel1" runat="server" />
    <x:Panel ID="Panel1" Layout="Column" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
        runat="server">
        <Items>
            <x:Panel Width="300px" ShowBorder="false" EnableBackgroundColor="true"
                ShowHeader="false" runat="server">
                <Items>
                    <x:Panel ID="Panel2" Title="系统公告" Height="200px" runat="server" CssStyle="margin-bottom:5px;"
                        BodyPadding="5px" ShowBorder="true" ShowHeader="true">
                        <Items>
                            <x:Label ID="Label1" runat="server" Text="这是系统公告">
                            </x:Label>
                        </Items>
                    </x:Panel>
                    <x:Panel ID="Panel4" Title="系统公告" Height="200px" runat="server" CssStyle="margin-bottom:5px;"
                        BodyPadding="5px" ShowBorder="true" ShowHeader="true">
                        <Items>
                            <x:Label ID="Label3" runat="server" Text="这是系统公告">
                            </x:Label>
                        </Items>
                    </x:Panel>
                </Items>
            </x:Panel>
            <x:Panel ID="Panel5" ColumnWidth="100%" ShowBorder="false"
                EnableBackgroundColor="true" ShowHeader="false" runat="server">
                <Items>
                    <x:Panel ID="Panel3" Title="代办事宜" ColumnWidth="100%" Height="200px" runat="server"
                        CssStyle="margin-bottom:5px;" BodyPadding="5px" ShowBorder="true" ShowHeader="true">
                        <Items>
                            <x:Label ID="Label2" runat="server" Text="这是代办事宜列表">
                            </x:Label>
                        </Items>
                    </x:Panel>
                    <x:Panel ID="Panel6" Title="注意事项" ColumnWidth="100%" Height="200px" runat="server"
                        CssStyle="margin-bottom:5px;" BodyPadding="5px" ShowBorder="true" ShowHeader="true">
                        <Items>
                            <x:Label ID="Label4" runat="server" Text="这是注意事项列表">
                            </x:Label>
                        </Items>
                    </x:Panel>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    </form>
</body>
</html>

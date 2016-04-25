<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hbox.aspx.cs" Inherits="FineUIPro.Examples.layout.hbox" %>

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
        <f:Panel ID="Panel2" runat="server" Height="350px" Width="850px" ShowBorder="True" EnableCollapse="true"
            Layout="HBox" BoxConfigAlign="Stretch" BoxConfigPosition="Start" BodyPadding="5px"
            BoxConfigChildMargin="0 5 0 0" ShowHeader="True"
            Title="面板（Layout=HBox BoxConfigAlign=Stretch BoxConfigPosition=Start BoxConfigChildMargin=0 5 0 0）">
            <Items>
                <f:Panel ID="Panel1" Title="面板1" BoxFlex="1" runat="server"
                    BodyPadding="5px" ShowBorder="true" ShowHeader="false">
                    <Items>
                        <f:Label ID="Label1" runat="server" Text="BoxFlex=1">
                        </f:Label>
                    </Items>
                </f:Panel>
                <f:Panel ID="Panel3" Title="面板2" Width="150px"
                    runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="false">
                    <Items>
                        <f:Label ID="Label2" runat="server" Text="Width=150px">
                        </f:Label>
                    </Items>
                </f:Panel>
                <f:Panel ID="Panel4" Title="面板3" BoxFlex="2" runat="server"
                    BodyPadding="5px" Margin="0" ShowBorder="true" ShowHeader="false">
                    <Items>
                        <f:Label ID="Label3" runat="server" Text="BoxFlex=2 Margin=0">
                        </f:Label>
                    </Items>
                </f:Panel>
            </Items>
        </f:Panel>
        <br />
        <br />
        <f:Panel ID="Panel5" runat="server" Height="350px" Width="850px" ShowBorder="True" EnableCollapse="true"
            Layout="HBox" BoxConfigAlign="Stretch" BoxConfigPosition="End" BodyPadding="5px"
            BoxConfigChildMargin="0 5 0 0" ShowHeader="True" Title="面板（Layout=HBox BoxConfigAlign=Stretch BoxConfigPosition=End BoxConfigChildMargin=0 5 0 0）">
            <Items>
                <f:Panel ID="Panel6" Title="面板1" Width="200px"
                    runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="false">
                    <Items>
                        <f:Label ID="Label4" runat="server" Text="Width=200px">
                        </f:Label>
                    </Items>
                </f:Panel>
                <f:Panel ID="Panel7" Title="面板2" Width="200px"
                    runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="false">
                    <Items>
                        <f:Label ID="Label5" runat="server" Text="Width=200px">
                        </f:Label>
                    </Items>
                </f:Panel>
                <f:Panel ID="Panel8" Title="面板3" Width="200px"
                    Margin="0" runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="false">
                    <Items>
                        <f:Label ID="Label6" runat="server" Text="Width=200px Margin=0">
                        </f:Label>
                    </Items>
                </f:Panel>
            </Items>
        </f:Panel>
        <br />
        <br />
        <f:Panel ID="Panel9" runat="server" Height="350px" Width="850px" ShowBorder="True" EnableCollapse="true"
            Layout="HBox" BoxConfigAlign="Stretch" BoxConfigPosition="Center" BodyPadding="5px"
            BoxConfigChildMargin="0 5 0 0" ShowHeader="True" Title="面板（Layout=HBox BoxConfigAlign=Stretch BoxConfigPosition=Center BoxConfigChildMargin=0 5 0 0）">
            <Items>
                <f:Panel ID="Panel10" Title="面板1" Width="200px"
                    runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="false">
                    <Items>
                        <f:Label ID="Label7" runat="server" Text="Width=200px">
                        </f:Label>
                    </Items>
                </f:Panel>
                <f:Panel ID="Panel11" Title="面板2" Width="200px"
                    runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="false">
                    <Items>
                        <f:Label ID="Label8" runat="server" Text="Width=200px">
                        </f:Label>
                    </Items>
                </f:Panel>
                <f:Panel ID="Panel12" Title="面板3" Width="200px"
                    Margin="0" runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="false">
                    <Items>
                        <f:Label ID="Label9" runat="server" Text="Width=200px Margin=0">
                        </f:Label>
                    </Items>
                </f:Panel>
            </Items>
        </f:Panel>
        <br />
        <br />
        <f:Panel ID="Panel13" runat="server" Height="350px" Width="850px" ShowBorder="True" EnableCollapse="true"
            Layout="HBox" BoxConfigAlign="Center" BoxConfigPosition="End" BodyPadding="5px"
            BoxConfigChildMargin="0 5 0 0" ShowHeader="True"
            Title="面板（Layout=HBox BoxConfigAlign=Center BoxConfigPosition=End BoxConfigChildMargin=0 5 0 0）">
            <Items>
                <f:Panel ID="Panel14" Title="面板1" Width="200px"
                    Height="100px" runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="false">
                    <Items>
                        <f:Label ID="Label10" runat="server" Text="Width=200px Height=100px">
                        </f:Label>
                    </Items>
                </f:Panel>
                <f:Panel ID="Panel15" Title="面板2" Width="200px" Height="150px"
                    runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="false">
                    <Items>
                        <f:Label ID="Label11" runat="server" Text="Width=200px Height=150px">
                        </f:Label>
                    </Items>
                </f:Panel>
                <f:Panel ID="Panel16" Title="面板3" Width="200px"
                    Margin="0" Height="200px" runat="server" BodyPadding="5px" ShowBorder="true"
                    ShowHeader="false">
                    <Items>
                        <f:Label ID="Label12" runat="server" Text="Width=200px Height=200px Margin=0">
                        </f:Label>
                    </Items>
                </f:Panel>
            </Items>
        </f:Panel>
        <br />
        <br />
        <f:Panel ID="Panel21" runat="server" Height="350px" Width="850px" ShowBorder="True" EnableCollapse="true"
            Layout="HBox" BoxConfigAlign="End" BoxConfigPosition="Center" BodyPadding="5px"
            BoxConfigChildMargin="0 5 0 0" ShowHeader="True"
            Title="面板（Layout=HBox BoxConfigAlign=End BoxConfigPosition=Center BoxConfigChildMargin=0 5 0 0）">
            <Items>
                <f:Panel ID="Panel22" Title="面板1" Width="200px"
                    Height="100px" runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="false">
                    <Items>
                        <f:Label ID="Label16" runat="server" Text="Width=200px Height=100px">
                        </f:Label>
                    </Items>
                </f:Panel>
                <f:Panel ID="Panel23" Title="面板2" Width="200px" Height="150px"
                    runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="false">
                    <Items>
                        <f:Label ID="Label17" runat="server" Text="Width=200px Height=150px">
                        </f:Label>
                    </Items>
                </f:Panel>
                <f:Panel ID="Panel24" Title="面板3" Width="200px"
                    Margin="0" Height="200px" runat="server" BodyPadding="5px" ShowBorder="true"
                    ShowHeader="false">
                    <Items>
                        <f:Label ID="Label18" runat="server" Text="Width=200px Height=200px Margin=0">
                        </f:Label>
                    </Items>
                </f:Panel>
            </Items>
        </f:Panel>
        <br />
        <br />
        <f:Panel ID="Panel17" runat="server" Height="350px" Width="850px" ShowBorder="True" EnableCollapse="true"
            Layout="HBox" BoxConfigAlign="StretchMax" BoxConfigPosition="Center" BodyPadding="5px"
            BoxConfigChildMargin="0 5 0 0" ShowHeader="True"
            Title="面板（Layout=HBox BoxConfigAlign=StretchMax BoxConfigPosition=Center BoxConfigChildMargin=0 5 0 0）">
            <Items>
                <f:Panel ID="Panel18" Title="面板1" Width="200px"
                    Height="100px" runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="false">
                    <Items>
                        <f:Label ID="Label13" runat="server" Text="Width=200px Height=100px">
                        </f:Label>
                    </Items>
                </f:Panel>
                <f:Panel ID="Panel19" Title="面板2" Width="200px" Height="150px"
                    runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="false">
                    <Items>
                        <f:Label ID="Label14" runat="server" Text="Width=200px Height=150px">
                        </f:Label>
                    </Items>
                </f:Panel>
                <f:Panel ID="Panel20" Title="面板3" Width="200px"
                    Margin="0" Height="200px" runat="server" BodyPadding="5px" ShowBorder="true"
                    ShowHeader="false">
                    <Items>
                        <f:Label ID="Label15" runat="server" Text="Width=200px Height=200px Margin=0">
                        </f:Label>
                    </Items>
                </f:Panel>
            </Items>
        </f:Panel>
    </form>
</body>
</html>

﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="triggerbox2.aspx.cs" Inherits="FineUIPro.Examples.form.triggerbox2" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <link href="../res/css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" />
        <f:SimpleForm ID="SimpleForm1" BodyPadding="5px" runat="server" Width="450px" EnableCollapse="true"
            ShowBorder="True" Title="表单" ShowHeader="True">
            <Items>
                <f:TriggerBox ID="tbxMyBox1" ShowLabel="false" TriggerIcon="Search" Enabled="false"
                    OnTriggerClick="tbxMyBox1_TriggerClick" EmptyText="打开弹出窗口" runat="server">
                </f:TriggerBox>
            </Items>
        </f:SimpleForm>

        <f:Button runat="server" OnClick="Unnamed_Click" Text="dddd"></f:Button>

        <f:Window ID="Window1" Title="弹出窗口" BodyPadding="10px" IsModal="true" Hidden="true"
            EnableMaximize="true" EnableResize="true" Target="Top" Width="450px" Height="300px"
            runat="server">
            <Items>
                <f:Button ID="btnCloseWindow" Text="关闭当前窗口" OnClick="btnCloseWindow_Click" runat="server">
                </f:Button>
            </Items>
        </f:Window>
    </form>
</body>
</html>

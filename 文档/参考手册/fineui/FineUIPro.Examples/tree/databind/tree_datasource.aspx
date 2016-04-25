<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tree_datasource.aspx.cs"
    Inherits="FineUIPro.Examples.tree.databind.tree_datasource" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <meta name="sourcefiles" content="~/tree/databind/website.xml" />
    <link href="../../res/css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" />
        <f:Tree ID="Tree1" Width="550px" EnableSingleExpand="true" EnableCollapse="true"
            ShowHeader="true" Title="树控件（绑定到 XmlDataSource）" runat="server">
        </f:Tree>
        <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/tree/databind/website.xml"></asp:XmlDataSource>
        <br />
        注意：这个树启用了 EnableSingleExpand，也就是说同一级目录同时只能展开一个（初始状态除外）。
    </form>
</body>
</html>

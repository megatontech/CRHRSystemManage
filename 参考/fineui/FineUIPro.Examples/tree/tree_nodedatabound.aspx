<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tree_nodedatabound.aspx.cs"
    Inherits="FineUIPro.Examples.tree.databind.tree_nodedatabound" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <meta name="sourcefiles" content="~/tree/databind/website.xml" />
    <link href="../res/css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" />
        <f:Tree ID="Tree1" Width="550px" EnableCollapse="true" OnNodeDataBound="Tree1_NodeDataBound"
            ShowHeader="true" Title="树控件（NodeDataBound事件）" runat="server">
        </f:Tree>
        <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/tree/databind/website.xml"></asp:XmlDataSource>
        <br />
        注：在 NodeDataBound 事件中，将 "驻马店市" 和 "合肥市" 置为高亮状态。 
    </form>
</body>
</html>

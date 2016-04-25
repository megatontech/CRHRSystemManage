<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="leftmenu.aspx.cs" Inherits="FineUIPro.Examples.iframe.topmenu2.leftmenu" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="leftTree" runat="server"></f:PageManager>
        <f:Tree runat="server" ShowBorder="false" ShowHeader="false" ID="leftTree" EnableNodeHyperLink="true">
        </f:Tree>
        <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/iframe/topmenu2/data/menuMail.xml"></asp:XmlDataSource>
    </form>

    <script>
        var leftTreeID = '<%= leftTree.ClientID %>';

        F.ready(function () {

            // 展开树的第一个节点，并选中第一个节点下的第一个子节点（在右侧IFrame中打开）
            var tree = F(leftTreeID);
            var treeFirstChild = tree.getRootNode().children[0];

            // 展开第一个节点（如果想要展开全部节点，调用 tree.expandAll();）
            tree.expandNode(treeFirstChild);


            // 选中第一个链接节点，并在右侧IFrame中打开此链接
            var treeFirstLink = treeFirstChild.children[0];
            tree.selectNode(treeFirstLink);

            parent.window.frames['menu2mainframe'].location.href = treeFirstLink.href;
        });
    </script>
</body>
</html>

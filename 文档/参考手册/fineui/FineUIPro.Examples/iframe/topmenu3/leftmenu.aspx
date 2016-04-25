<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="leftmenu.aspx.cs" Inherits="FineUIPro.Examples.iframe.topmenu3.leftmenu" %>

<!DOCTYPE html>
<html>
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="leftAccordion" runat="server"></f:PageManager>
        <f:Accordion runat="server" EnableFill="false" ShowBorder="false" ShowHeader="false"
            ID="leftAccordion">
        </f:Accordion>
        <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/iframe/topmenu3/data/menuMail.xml"></asp:XmlDataSource>
    </form>
    
    <script>
        var leftAccordionID = '<%= leftAccordion.ClientID %>';

        F.ready(function () {

            // 首先获取手风琴控件第一个面板中的树控件
            var tree = F(leftAccordionID).items[0].items[0];
            var treeFirstChild = tree.getRootNode().children[0];

            // 选中第一个链接节点，并在右侧IFrame中打开此链接
            tree.selectNode(treeFirstChild);

            parent.window.frames['menu3mainframe'].location.href = treeFirstChild.href;

        });
    </script>
</body>
</html>

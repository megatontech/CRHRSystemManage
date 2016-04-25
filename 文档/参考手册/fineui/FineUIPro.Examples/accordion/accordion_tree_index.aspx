<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="accordion_tree_index.aspx.cs" Inherits="FineUIPro.Examples.accordion.accordion_tree_index" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" />
        <f:ContentPanel ShowBorder="false" ShowHeader="false" BodyPadding="5px" runat="server">
            请注意，本示例如何做到如下几点：
            <ul>
                <li>如何将树控件放在Accordion控件中； </li>
                <li>如何从XML文件加载树控件； </li>
                <li>如何在后台通过递归改变每个树节点的Target属性； </li>
                <li>树节点的Target属性是如何影响链接的打开位置。 </li>
            </ul>
            <br />
            <br />
            <br />
            注：必须点击树节点文本才能打开相应的页面。如果希望点击树节点空白的地方也能打开，请设置EnableNodeHyperLink=true。

        </f:ContentPanel>
    </form>
</body>
</html>

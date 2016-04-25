<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tree_sitemap.aspx.cs" Inherits="FineUIPro.Examples.tree.databind.tree_sitemap" %>

<!DOCTYPE html>
<html>
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <meta name="sourcefiles" content="~/tree/databind/Web.sitemap" />
    <link href="../../res/css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" />
        <f:Tree ID="Tree1" Width="550px" ShowHeader="true" Title="树控件（绑定到 SiteMap）"  EnableCollapse="true"
            runat="server">
            <Mappings>
                <f:XmlAttributeMapping From="url" To="NavigateUrl" />
                <f:XmlAttributeMapping From="title" To="Text" />
                <f:XmlAttributeMapping From="description" To="ToolTip" />
                <f:XmlAttributeMapping From="target" To="Target" />
            </Mappings>
        </f:Tree>
        <asp:XmlDataSource ID="XmlDataSource2" runat="server" DataFile="~/tree/databind/Web.sitemap"></asp:XmlDataSource>
    </form>
</body>
</html>

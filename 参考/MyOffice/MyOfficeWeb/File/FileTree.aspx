<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FileTree.aspx.cs" Inherits="File_FileTree" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="../Css/Style.css"type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TreeView ID="tvFile" runat="server" ShowLines="True">
            <Nodes>
                <asp:TreeNode Text="文件管理" Value="0" ImageUrl="~/images/file/folder.gif"></asp:TreeNode>
            </Nodes>
        </asp:TreeView>
        &nbsp;</div>
    </form>
</body>
</html>

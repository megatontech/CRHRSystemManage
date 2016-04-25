<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tree_nodehyperlink.aspx.cs" Inherits="FineUIPro.Examples.tree.tree_nodehyperlink" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../res/css/main.css" rel="stylesheet" type="text/css" />
    <style>
        body.f-body {
            padding: 0;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="RegionPanel1" runat="server" />
        <f:Panel ID="RegionPanel1" Layout="Region" ShowHeader="true" Title="将树节点渲染为超链接（点击节点空白处也能打开链接）" ShowBorder="false" runat="server" Margin="5px">
            <Items>
                <f:Tree ID="Tree1" RegionSplit="false" RegionPosition="Left" Width="200px" 
                    ShowHeader="false" ShowBorder="true" EnableNodeHyperLink="true" runat="server">
                    <Nodes>
                        <f:TreeNode Text="基本用法" Expanded="true">
                            <f:TreeNode Text="你好 FineUI" Target="treemainframe" NavigateUrl="~/basic/hello.aspx">
                            </f:TreeNode>
                            <f:TreeNode Text="登陆页面" Target="treemainframe" NavigateUrl="~/basic/login.aspx">
                            </f:TreeNode>
                        </f:TreeNode>
                        <f:TreeNode Text="表单控件" Expanded="true">
                            <f:TreeNode Text="简单按钮" Target="treemainframe" NavigateUrl="~/button/button.aspx">
                            </f:TreeNode>
                            <f:TreeNode Text="文本输入框" Target="treemainframe" NavigateUrl="~/form/textbox.aspx">
                            </f:TreeNode>
                        </f:TreeNode>
                    </Nodes>
                </f:Tree>
                <f:Panel ID="Region3" ShowHeader="false" EnableIFrame="true"
                    IFrameName="treemainframe" RegionPosition="Center" runat="server">
                </f:Panel>
            </Items>
        </f:Panel>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tree_contextmenu.aspx.cs" Inherits="FineUIPro.Examples.tree.tree_contextmenu" %>

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
        <f:Tree ID="Tree1" Width="550px" ShowHeader="true" Title="树控件（右键菜单）" EnableCollapse="true" EnableSingleClickExpand="false"
            runat="server">
            <Nodes>
                <f:TreeNode Text="中国" Expanded="true">
                    <f:TreeNode Text="河南省">
                        <f:TreeNode Text="驻马店市" NodeID="zhumadian">
                            <f:TreeNode Text="遂平县" Leaf="false" NodeID="suiping">
                                <f:TreeNode Text="槐树乡" Leaf="false" NodeID="huaishu">
                                    <f:TreeNode Text="陈庄村" NodeID="chenzhuang">
                                    </f:TreeNode>
                                </f:TreeNode>
                            </f:TreeNode>
                        </f:TreeNode>
                        <f:TreeNode Text="漯河市" NodeID="luohe" />
                    </f:TreeNode>
                    <f:TreeNode Text="安徽省" Expanded="true" NodeID="anhui">
                        <f:TreeNode Text="合肥市" Expanded="true" NodeID="hefei">
                            <f:TreeNode Text="金色池塘小区" NodeID="golden">
                            </f:TreeNode>
                            <f:TreeNode Text="中国科学技术大学" NodeID="ustc">
                            </f:TreeNode>
                        </f:TreeNode>
                    </f:TreeNode>
                </f:TreeNode>
            </Nodes>
            <Listeners>
                <f:Listener Event="beforenodecontextmenu" Handler="onTreeNodeContextMenu" />
            </Listeners>
        </f:Tree>
        <f:Menu ID="Menu1" runat="server">
            <f:MenuButton ID="btnExpandNode" EnablePostBack="false" runat="server" Text="展开全部">
                <Listeners>
                    <f:Listener Event="click" Handler="onExpandNode" />
                </Listeners>
            </f:MenuButton>
            <f:MenuButton ID="btnCollapseNode" EnablePostBack="false" runat="server" Text="折叠全部">
                 <Listeners>
                    <f:Listener Event="click" Handler="onCollapseNode" />
                </Listeners>
            </f:MenuButton>
        </f:Menu>
    </form>
    <script>

        var treeID = '<%= Tree1.ClientID %>';
        var menuID = '<%= Menu1.ClientID %>';
        var currentNode;

        // 返回false，来阻止浏览器右键菜单
        function onTreeNodeContextMenu(event, node) {
            currentNode = node;
            F(menuID).show();
            return false;
        }

        function onExpandNode() {
            if (currentNode) {
                F(treeID).expandNode(currentNode, true);
            }
        }

        function onCollapseNode() {
            if (currentNode) {
                F(treeID).collapseNode(currentNode, true);
            }
        }

    </script>
</body>
</html>

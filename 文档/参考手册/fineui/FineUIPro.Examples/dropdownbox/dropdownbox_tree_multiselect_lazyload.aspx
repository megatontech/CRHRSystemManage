<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dropdownbox_tree_multiselect_lazyload.aspx.cs" Inherits="FineUIPro.Examples.dropdownbox.dropdownbox_tree_multiselect_lazyload" %>

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
        <f:SimpleForm ID="SimpleForm1" BodyPadding="5px" runat="server" Width="400px" EnableCollapse="true"
            ShowBorder="True" Title="下拉树（多选，延迟加载）" ShowHeader="True">
            <Items>
                <f:DropDownBox runat="server" ID="DropDownBox1" EnableMultiSelect="true" Values="henan,anhui">
                    <PopPanel>
                        <f:Tree ID="Tree1" ShowHeader="false" Hidden="true"
                            AutoLeafIdentification="false" OnNodeLazyLoad="Tree1_NodeLazyLoad"
                            EnableMultiSelect="true" KeepCurrentSelection="true" runat="server">
                            <Nodes>
                                <f:TreeNode Text="中国" Expanded="true" NodeID="china">
                                    <f:TreeNode Text="河南省" Expanded="true" NodeID="henan">
                                        <f:TreeNode Text="驻马店市（此节点延迟加载）" NodeID="zhumadian">
                                        </f:TreeNode>
                                        <f:TreeNode Text="漯河" NodeID="luohe" Leaf="true" />
                                    </f:TreeNode>
                                    <f:TreeNode Text="安徽省" Expanded="true" NodeID="anhui">
                                        <f:TreeNode Text="合肥市" Expanded="true" NodeID="hefei">
                                            <f:TreeNode Text="蜀山区" Expanded="false" NodeID="shushanqu">
                                                <f:TreeNode Text="金色池塘小区" NodeID="golden">
                                                </f:TreeNode>
                                                <f:TreeNode Text="梦圆小区" NodeID="mengyuan">
                                                </f:TreeNode>
                                                <f:TreeNode Text="桂花园小区" NodeID="guihuayuan">
                                                </f:TreeNode>
                                            </f:TreeNode>
                                            <f:TreeNode Text="包河区" Expanded="true" NodeID="baohequ">
                                                <f:TreeNode Text="中国科学技术大学" NodeID="ustc">
                                                </f:TreeNode>
                                            </f:TreeNode>
                                        </f:TreeNode>
                                    </f:TreeNode>
                                </f:TreeNode>
                            </Nodes>
                        </f:Tree>
                    </PopPanel>
                </f:DropDownBox>
                <f:Button ID="btnGetSelection" Text="获取此下拉框的选中值" runat="server" OnClick="btnGetSelection_Click">
                </f:Button>
            </Items>
        </f:SimpleForm>
        <br />
        <f:Label runat="server" ID="labResult">
        </f:Label>
    </form>
</body>
</html>

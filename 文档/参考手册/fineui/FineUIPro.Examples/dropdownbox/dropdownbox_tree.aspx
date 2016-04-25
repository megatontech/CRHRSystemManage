<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dropdownbox_tree.aspx.cs" Inherits="FineUIPro.Examples.dropdownbox.dropdownbox_tree" %>

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
            ShowBorder="True" Title="下拉树" ShowHeader="True">
            <Items>
                <f:DropDownBox runat="server" ID="DropDownBox1" Values="henan">
                    <PopPanel>
                        <f:Tree ID="Tree1" ShowHeader="false" Hidden="true" runat="server">
                            <Nodes>
                                <f:TreeNode Text="中国" NodeID="china" Expanded="true">
                                    <f:TreeNode Text="河南省" NodeID="henan" Expanded="true">
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

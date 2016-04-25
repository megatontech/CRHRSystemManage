<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dropdownlist_datadisplayfields_group_multiselect.aspx.cs"
    Inherits="FineUIPro.Examples.dropdownlist.dropdownlist_datadisplayfields_group_multiselect" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../res/css/main.css" rel="stylesheet" type="text/css" />
    <style>
        .item-name {
            font-size: 13px;
            margin-bottom: 5px;
            display: inline-block;
        }

        .item-desc {
            font-size: 12px;
            color: #999;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" />
        <f:SimpleForm ID="SimpleForm1" BodyPadding="5px" runat="server" Width="450px" EnableCollapse="true"
            ShowBorder="True" Title="分组+自定义列表项+多选+复选框" ShowHeader="True">
            <Items>
                <f:DropDownList runat="server" ID="DropDownList1" EnableGroup="true" EnableMultiSelect="true" EnableCheckBoxSelect="true">
                </f:DropDownList>
                <f:Button ID="btnGetSelection" Text="获取此下拉列表的选中项" runat="server" OnClick="btnGetSelection_Click">
                </f:Button>
            </Items>
        </f:SimpleForm>
        <br />
        <f:Label runat="server" ID="labResult" EncodeText="false">
        </f:Label>
        <br />
    </form>
</body>
</html>

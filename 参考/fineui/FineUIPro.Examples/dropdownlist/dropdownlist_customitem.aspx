<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dropdownlist_customitem.aspx.cs"
    Inherits="FineUIPro.Examples.dropdownlist.dropdownlist_customitem" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../res/css/main.css" rel="stylesheet" type="text/css" />
    <style>
        .item-name {
            font-weight: bold;
            margin-bottom: 5px;
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
            ShowBorder="True" Title="自定义列表项（ItemDataBound）" ShowHeader="True">
            <Items>
                <f:DropDownList runat="server" ID="DropDownList1" OnItemDataBound="DropDownList1_ItemDataBound">
                </f:DropDownList>
                <f:Button ID="btnGetSelection" Text="获取此下拉列表的选中项" runat="server" OnClick="btnGetSelection_Click">
                </f:Button>
            </Items>
        </f:SimpleForm>
        <br />
        <f:Label runat="server" ID="labResult">
        </f:Label>
        <br />
    </form>
</body>
</html>

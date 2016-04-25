<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dropdownlist_itemicon.aspx.cs" Inherits="FineUIPro.Examples.dropdownlist.dropdownlist_itemicon" %>

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
        <f:SimpleForm ID="SimpleForm1" BodyPadding="5px" runat="server" Width="450px" EnableCollapse="true"
            ShowBorder="True" Title="列表项图标" ShowHeader="True">
            <Items>
                <f:DropDownList runat="server" ID="DropDownList1">
                    <f:ListItem Text="中国" Value="cn" Selected="true" />
                    <f:ListItem Text="法国" Value="fr" />
                    <f:ListItem Text="美国" Value="us" />
                    <f:ListItem Text="英国" Value="england" />
                    <f:ListItem Text="澳大利亚" Value="au" />
                    <f:ListItem Text="意大利" Value="it" />
                    <f:ListItem Text="加拿大" Value="ca" />
                </f:DropDownList>

                <f:Button ID="btnSelectItem6" Text="选中“澳大利亚”" runat="server" OnClick="btnSelectItem6_Click"
                    CssClass="marginr">
                </f:Button>
                <f:Button ID="btnGetSelection" Text="获取此下拉列表的选中项" runat="server" OnClick="btnGetSelection_Click">
                </f:Button>
            </Items>
        </f:SimpleForm>
        <br />
        <f:Label runat="server" ID="labResult">
        </f:Label>
    </form>
</body>
</html>

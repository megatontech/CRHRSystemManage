<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="shengshixian.aspx.cs" Inherits="FineUIPro.Examples.data.shengshixian" %>

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
        <f:SimpleForm ID="SimpleForm1" runat="server" BodyPadding="5px" Width="450px" EnableCollapse="true"
            Title="中国省市县联动">
            <Items>
                <f:DropDownList ID="ddlSheng" Label="省份" ShowRedStar="true" CompareType="String"
                    CompareValue="-1" CompareOperator="NotEqual" CompareMessage="请选择省份！" runat="server"
                    AutoPostBack="true" OnSelectedIndexChanged="ddlSheng_SelectedIndexChanged">
                </f:DropDownList>
                <f:DropDownList ID="ddlShi" Label="地区市" ShowRedStar="true" CompareType="String"
                    CompareValue="-1" CompareOperator="NotEqual" CompareMessage="请选择地区市！" runat="server"
                    AutoPostBack="true" OnSelectedIndexChanged="ddlShi_SelectedIndexChanged" Enabled="false">
                </f:DropDownList>
                <f:DropDownList ID="ddlXian" ShowRedStar="true" CompareType="String" CompareValue="-1"
                    CompareOperator="NotEqual" CompareMessage="请选择县区市！" Label="县区市" runat="server" Enabled="false">
                </f:DropDownList>
                <f:Button ID="btnSubmit" runat="server" Text="获取选中的省市县" ValidateForms="SimpleForm1"
                    ValidateTarget="Top" OnClick="btnSubmit_Click">
                </f:Button>
            </Items>
        </f:SimpleForm>
        <br />
        <f:Label ID="labResult" runat="server" ShowLabel="false" CssStyle="font-weight:bold;">
        </f:Label>
        <br />
    </form>
</body>
</html>

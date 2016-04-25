<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="passvalue_iframe_iframe.aspx.cs"
    Inherits="FineUIPro.Examples.iframe.passvalue_iframe_iframe" %>

<!DOCTYPE html>
<html>
<head runat="server">
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
        <f:PageManager ID="PageManager1" AutoSizePanelID="SimpleForm1" runat="server"></f:PageManager>
        <f:SimpleForm ID="SimpleForm1" LabelAlign="Top" ShowBorder="false" ShowHeader="false" Title="SimpleForm"
            BodyPadding="5px" runat="server" EnableCollapse="True" AutoScroll="true">
            <Items>
                <f:RadioButtonList ID="ddlSheng" Label="请选择省份" ColumnNumber="4" ShowRedStar="true" runat="server" AutoPostBack="true"
                    OnSelectedIndexChanged="ddlSheng_SelectedIndexChanged">
                </f:RadioButtonList>
            </Items>
        </f:SimpleForm>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dropdownbox_radiobuttonlist_matchfieldwidth.aspx.cs" Inherits="FineUIPro.Examples.dropdownbox.dropdownbox_radiobuttonlist_matchfieldwidth" %>

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
            ShowBorder="True" Title="下拉单选框列表（MatchFieldWidth）" ShowHeader="True">
            <Items>
                <f:DropDownBox runat="server" ID="DropDownBox1" DataControlID="RadioButtonList1" Value="js" MatchFieldWidth="false">
                    <PopPanel>
                        <f:SimpleForm ID="SimpleForm2" BodyPadding="10px" runat="server" AutoScroll="true"
                            ShowBorder="True" ShowHeader="false" Hidden="true" Width="650px">
                            <Items>
                                <f:Label ID="Label1" runat="server" Text="请选择一种编程语言："></f:Label>
                                <f:RadioButtonList ID="RadioButtonList1" ColumnNumber="3" runat="server">
                                    <f:RadioItem Text="C#" Value="csharp" />
                                    <f:RadioItem Text="JavaScript" Value="js" />
                                    <f:RadioItem Text="JAVA" Value="java" />
                                    <f:RadioItem Text="Ruby" Value="ruby" />
                                    <f:RadioItem Text="PHP" Value="php" />
                                    <f:RadioItem Text="Objective-C" Value="objc" />
                                    <f:RadioItem Text="Python" Value="python" />
                                    <f:RadioItem Text="Perl" Value="perl" />
                                    <f:RadioItem Text="C++" Value="cplusplus" />
                                    <f:RadioItem Text="Basic" Value="basic" />
                                    <f:RadioItem Text="Go" Value="go" />
                                    <f:RadioItem Text="Swift" Value="swift" />
                                </f:RadioButtonList>
                            </Items>
                        </f:SimpleForm>
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

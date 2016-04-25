﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="grid_aspnet.aspx.cs" Inherits="FineUIPro.Examples.grid.grid_aspnet" %>

<!DOCTYPE html>
<html>
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../res/css/main.css" rel="stylesheet" type="text/css" />
    <style>
        body {
            background-color: #fff;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:GridView ID="GridView1" Width="800px" DataKeyNames="Id,Name" AutoGenerateColumns="False"
            runat="server">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Name" HeaderText="姓名" />
                <asp:TemplateField HeaderText="性别">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# GetGender(Eval("Gender")) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="EntranceYear" HeaderText="入学年份" />
                <asp:CheckBoxField DataField="AtSchool" HeaderText="是否在校" />
                <asp:HyperLinkField HeaderText="所学专业" DataTextField="Major" DataTextFormatString="{0}"
                    DataNavigateUrlFields="Major" DataNavigateUrlFormatString="http://gsa.ustc.edu.cn/search?q={0}"
                    Target="_blank" />
                <asp:ImageField DataImageUrlField="Group" DataImageUrlFormatString="~/res/images/16/{0}.png"
                    HeaderText="分组">
                </asp:ImageField>
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>

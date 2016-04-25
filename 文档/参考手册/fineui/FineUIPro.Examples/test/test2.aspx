<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test2.aspx.cs" Inherits="FineUIPro.Examples.test2" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        body.f-body {
            background-color: #fff;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server"></f:PageManager>

        <f:Grid ID="grCount" ShowBorder="true" ShowHeader="False" runat="server" Width="1000px" Height="600px"
            EnableCheckBoxSelect="false" DataKeyNames="Id" EnableHeaderMenu="true"
            AllowColumnLocking="true">
            <Columns>
                <f:RowNumberField runat="server" />
                <f:BoundField ColumnID="Name" DataField="Name" HeaderText="企业名称" ExpandUnusedSpace="true" Width="240px" EnableLock="true" Locked="true"></f:BoundField>
                <f:BoundField ColumnID="CurrStatusName" DataField="CurrStatusName" HeaderText="当前登记状态" EnableLock="true"
                    Width="180px"></f:BoundField>
                <f:BoundField ColumnID="People" DataField="People" HeaderText="责任人" Width="100px" EnableLock="true"></f:BoundField>
                <f:BoundField ColumnID="CreateTime" DataField="CreateTime" HeaderText="创建时间" Width="120px"
                    DataFormatString="{0:yyyy-MM-dd HH:mm}" EnableLock="true"></f:BoundField>
                <f:BoundField ColumnID="ShowTime" DataField="ShowTime" HeaderText="出照时间" Width="120px"
                    DataFormatString="{0:yyyy-MM-dd HH:mm}" EnableLock="true"></f:BoundField>
                <f:BoundField ColumnID="AgentName" DataField="AgentName" HeaderText="所属招商员" Width="100px" EnableLock="true"></f:BoundField>
            </Columns>

        </f:Grid>

        <f:Grid ID="Grid1" ShowBorder="true" ShowHeader="true" Title="表格" Width="1000px" Height="300px" runat="server"
            AllowColumnLocking="true" EnableCollapse="true"
            DataKeyNames="Id">
            <Columns>
                <f:RowNumberField />
                <f:BoundField Width="240px"  EnableLock="true" Locked="true" DataField="Name" ExpandUnusedSpace="true" DataFormatString="{0}" HeaderText="姓名" />

                <f:BoundField Width="100px" EnableLock="true" DataField="EntranceYear" HeaderText="入学年份" />
                <f:CheckBoxField Width="100px" EnableLock="true" RenderAsStaticField="true" DataField="AtSchool" HeaderText="是否在校" />
                <f:HyperLinkField EnableLock="true" HeaderText="所学专业" DataToolTipField="Major" DataTextField="Major"
                    DataTextFormatString="{0}" DataNavigateUrlFields="Major" DataNavigateUrlFormatString="http://gsa.ustc.edu.cn/search?q={0}"
                    UrlEncode="true" Target="_blank" />
                <f:ImageField Width="100px" EnableLock="true" DataImageUrlField="Group" DataImageUrlFormatString="~/res/images/16/{0}.png"
                    HeaderText="分组"></f:ImageField>
                <f:BoundField Width="100px" EnableLock="true" DataField="LogTime" DataFormatString="{0:yy-MM-dd}" HeaderText="注册日期" />
            </Columns>
        </f:Grid>
    </form>
</body>
</html>

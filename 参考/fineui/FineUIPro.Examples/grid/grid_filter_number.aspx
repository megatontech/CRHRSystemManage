<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="grid_filter_number.aspx.cs" Inherits="FineUIPro.Examples.grid.grid_filter_number" %>

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
        <f:Grid ID="Grid1" ShowBorder="true" ShowHeader="true" Title="表格" Width="800px" runat="server" EnableCollapse="true"
            DataKeyNames="Id" AllowFilters="true" OnFilterChange="Grid1_FilterChange">
            <Columns>
                <f:RowNumberField />
                <f:BoundField ColumnID="Name" Width="100px" DataField="Name" DataFormatString="{0}" HeaderText="姓名" EnableFilter="true">
                    <Filter EnableMultiFilter="true" ShowMatcher="false" MatcherDefault="any">
                        <Operator>
                            <f:DropDownList runat="server">
                                <f:ListItem Text="等于" Value="equal" />
                                <f:ListItem Text="包含" Value="contain" Selected="true" />
                                <f:ListItem Text="开始于" Value="start" />
                                <f:ListItem Text="结束于" Value="end" />
                            </f:DropDownList>
                        </Operator>
                    </Filter>
                </f:BoundField>
                <f:TemplateField ColumnID="Gender" Width="80px" HeaderText="性别">
                    <ItemTemplate>
                        <%-- Container.DataItem 的类型是 System.Data.DataRowView 或者用户自定义类型 --%>
                        <%--<asp:Label ID="Label2" runat="server" Text='<%# GetGender(DataBinder.Eval(Container.DataItem, "Gender")) %>'></asp:Label>--%>
                        <asp:Label ID="Label3" runat="server" Text='<%# GetGender(Eval("Gender")) %>'></asp:Label>
                    </ItemTemplate>
                </f:TemplateField>
                <f:BoundField ColumnID="EntranceYear" Width="80px" DataField="EntranceYear" HeaderText="入学年份" EnableFilter="true">
                    <Filter EnableMultiFilter="true">
                        <Operator>
                            <f:DropDownList ID="DropDownList2" runat="server">
                                <f:ListItem Text="大于" Value="greater" Selected="true" />
                                <f:ListItem Text="小于" Value="less" />
                                <f:ListItem Text="等于" Value="equal" />
                            </f:DropDownList>
                        </Operator>
                        <Field>
                            <f:NumberBox runat="server" ID="NumberBox1" Required="true" MinValue="1995"></f:NumberBox>
                        </Field>
                    </Filter>
                </f:BoundField>
                <f:CheckBoxField ColumnID="AtSchool" Width="80px" RenderAsStaticField="true" DataField="AtSchool" HeaderText="是否在校" />
                <f:HyperLinkField ColumnID="Major" HeaderText="所学专业" DataToolTipField="Major" DataTextField="Major"
                    DataTextFormatString="{0}" DataNavigateUrlFields="Major" DataNavigateUrlFormatString="http://gsa.ustc.edu.cn/search?q={0}"
                    UrlEncode="true" Target="_blank" ExpandUnusedSpace="True">
                </f:HyperLinkField>
                <f:ImageField ColumnID="Group" Width="80px" DataImageUrlField="Group" DataImageUrlFormatString="~/res/images/16/{0}.png"
                    HeaderText="分组">
                </f:ImageField>
                <f:BoundField ColumnID="LogTime" Width="100px" DataField="LogTime" DataFormatString="{0:yyyy-MM-dd}" HeaderText="注册日期" EnableFilter="true">
                    <Filter EnableMultiFilter="true" ShowMatcher="true">
                        <Operator>
                            <f:DropDownList ID="DropDownList3" runat="server">
                                <f:ListItem Text="大于" Value="greater" Selected="true" />
                                <f:ListItem Text="小于" Value="less" />
                                <f:ListItem Text="等于" Value="equal" />
                            </f:DropDownList>
                        </Operator>
                        <Field>
                            <f:DatePicker runat="server" Required="true" ID="DatePicker1"></f:DatePicker>
                        </Field>
                    </Filter>
                </f:BoundField>
            </Columns>
        </f:Grid>
        <br />
        <br />
        <f:Label runat="server" ID="labResult" EncodeText="false"></f:Label>
    </form>
</body>
</html>

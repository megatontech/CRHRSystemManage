<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dropdownbox_grid_paging.aspx.cs" Inherits="FineUIPro.Examples.dropdownbox.dropdownbox_grid_paging" %>

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
            ShowBorder="True" Title="下拉表格（内存分页）" ShowHeader="True">
            <Items>
                <f:DropDownBox runat="server" ID="DropDownBox1" EmptyText="请从下拉表格中选择" EnableMultiSelect="true" MatchFieldWidth="false">
                    <PopPanel>
                        <f:Grid ID="Grid1" Width="650px" Hidden="true"
                            DataIDField="Id" DataTextField="Name" EnableMultiSelect="true" KeepCurrentSelection="true"
                            AllowSorting="true" SortField="Name" SortDirection="ASC"
                            PageSize="5" ShowBorder="true" ShowHeader="false" AllowPaging="true"
                            runat="server" EnableCheckBoxSelect="True" DataKeyNames="Id,Name"
                            OnPageIndexChange="Grid1_PageIndexChange" OnSort="Grid1_Sort">
                            <Columns>
                                <f:RowNumberField />
                                <f:BoundField Width="100px" SortField="Name" DataField="Name" DataFormatString="{0}"
                                    HeaderText="姓名" />
                                <f:TemplateField Width="80px" SortField="Gender" HeaderText="性别">
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# GetGender(Eval("Gender")) %>'></asp:Label>
                                    </ItemTemplate>
                                </f:TemplateField>
                                <f:BoundField Width="80px" SortField="EntranceYear" DataField="EntranceYear" HeaderText="入学年份" />
                                <f:CheckBoxField Width="80px" SortField="AtSchool" RenderAsStaticField="true" DataField="AtSchool"
                                    HeaderText="是否在校" />
                                <f:BoundField ExpandUnusedSpace="True" DataField="Major" HeaderText="所学专业" />
                                <f:ImageField Width="80px" DataImageUrlField="Group" DataImageUrlFormatString="~/res/images/16/{0}.png"
                                    HeaderText="分组">
                                </f:ImageField>
                            </Columns>
                        </f:Grid>

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

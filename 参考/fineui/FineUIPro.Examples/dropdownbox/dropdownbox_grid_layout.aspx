<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dropdownbox_grid_layout.aspx.cs" Inherits="FineUIPro.Examples.dropdownbox.dropdownbox_grid_layout" %>

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
            ShowBorder="True" Title="下拉表格（复杂布局）" ShowHeader="True">
            <Items>
                <f:DropDownBox runat="server" ID="DropDownBox1" EmptyText="请从下拉表格中选择" DataControlID="Grid1" EnableMultiSelect="true" MatchFieldWidth="false">
                    <PopPanel>
                        <f:Panel ID="Panel7" runat="server" BodyPadding="5px" Width="650px" Height="300px" Hidden="true"
                            ShowBorder="true" ShowHeader="false" Layout="VBox" BoxConfigAlign="Stretch">
                            <Items>
                                <f:Form ID="Form5" ShowBorder="False" ShowHeader="False" runat="server">
                                    <Rows>
                                        <f:FormRow>
                                            <Items>
                                                <f:TwinTriggerBox Width="300px" runat="server" EmptyText="在姓名中查找" ShowLabel="false" ID="ttbSearch"
                                                    ShowTrigger1="false" OnTrigger1Click="ttbSearch_Trigger1Click" OnTrigger2Click="ttbSearch_Trigger2Click"
                                                    Trigger1Icon="Clear" Trigger2Icon="Search">
                                                </f:TwinTriggerBox>
                                                <f:RadioButtonList ID="rblAtSchool" Label="是否在校" AutoPostBack="true"
                                                    OnSelectedIndexChanged="rblAtSchool_SelectedIndexChanged" runat="server">
                                                    <f:RadioItem Text="全部" Value="-1" Selected="true" />
                                                    <f:RadioItem Text="在校" Value="1" />
                                                    <f:RadioItem Text="离校" Value="0" />
                                                </f:RadioButtonList>
                                            </Items>
                                        </f:FormRow>
                                    </Rows>
                                </f:Form>
                                <f:Grid ID="Grid1" BoxFlex="1"
                                    DataIDField="Id" DataTextField="Name" EnableMultiSelect="true" KeepCurrentSelection="true"
                                    PageSize="10" ShowBorder="true" ShowHeader="false"
                                    AllowPaging="true" runat="server" EnableCheckBoxSelect="True"
                                    DataKeyNames="Id,Name" IsDatabasePaging="true" OnPageIndexChange="Grid1_PageIndexChange"
                                    AllowSorting="true" SortField="Name" SortDirection="ASC"
                                    OnSort="Grid1_Sort">
                                    <Columns>
                                        <f:RowNumberField />
                                        <f:BoundField Width="100px" DataField="Name" SortField="Name" DataFormatString="{0}"
                                            HeaderText="姓名" />
                                        <f:TemplateField Width="80px" SortField="Gender" HeaderText="性别">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# GetGender(Eval("Gender")) %>'></asp:Label>
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
                            </Items>
                        </f:Panel>
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

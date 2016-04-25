<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TUser.aspx.cs" Inherits="FineOA.Web.admin.TUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <x:PageManager ID="PageManager1" AutoSizePanelID="Panel1" runat="server" />
    <x:Panel ID="Panel1" runat="server" ShowBorder="false" Layout="VBox" BoxConfigAlign="Stretch"
        BoxConfigPosition="Start" ShowHeader="false" Title="用户管理">
        <Items>
            <x:Form ID="Form2" runat="server" Height="36px" BodyPadding="5px" ShowHeader="false"
                ShowBorder="false" LabelAlign="Right" EnableBackgroundColor="true">
                <Rows>
                    <x:FormRow ID="FormRow1" runat="server">
                        <Items>
                            <x:TwinTriggerBox ID="ttbSearchMessage" runat="server" ShowLabel="false" EmptyText="在用户名称中搜索"
                                Trigger1Icon="Clear" Trigger2Icon="Search" ShowTrigger1="false" OnTrigger2Click="ttbSearchMessage_Trigger2Click"
                                OnTrigger1Click="ttbSearchMessage_Trigger1Click">
                            </x:TwinTriggerBox>
                            <x:RadioButtonList ID="rblEnableStatus" AutoPostBack="true" OnSelectedIndexChanged="rblEnableStatus_SelectedIndexChanged"
                                Label="启用状态" ColumnNumber="3" runat="server">
                                <x:RadioItem Text="全部" Selected="true" Value="all" />
                                <x:RadioItem Text="启用" Value="enabled" />
                                <x:RadioItem Text="禁用" Value="disabled" />
                            </x:RadioButtonList>
                        </Items>
                    </x:FormRow>
                </Rows>
            </x:Form>
            <x:Grid ID="Grid1" runat="server" BoxFlex="1" ShowBorder="true" ShowHeader="false"
                EnableCheckBoxSelect="true" DataKeyNames="FUserId,FUserName" AllowSorting="false"
                EnableHeaderMenu="false" AllowPaging="true" IsDatabasePaging="true" OnPreDataBound="Grid1_PreDataBound"
                OnPreRowDataBound="Grid1_PreRowDataBound" OnRowCommand="Grid1_RowCommand" OnPageIndexChange="Grid1_PageIndexChange">
                <Toolbars>
                    <x:Toolbar ID="Toolbar1" runat="server">
                        <Items>
                            <x:Button ID="btnDeleteSelected" Icon="Delete" runat="server" Text="删除选中记录" OnClick="btnDeleteSelected_Click">
                            </x:Button>
                            <x:ToolbarSeparator runat="server">
                            </x:ToolbarSeparator>
                            <x:Button ID="btnChangeEnableUsers" Icon="GroupEdit" EnablePostBack="false" runat="server"
                                Text="设置启用状态">
                                <Menu runat="server">
                                    <x:MenuButton ID="btnEnableUsers" OnClick="btnEnableUsers_Click" runat="server" Text="启用选中记录">
                                    </x:MenuButton>
                                    <x:MenuButton ID="btnDisableUsers" OnClick="btnDisableUsers_Click" runat="server"
                                        Text="禁用选中记录">
                                    </x:MenuButton>
                                </Menu>
                            </x:Button>
                            <x:ToolbarFill ID="ToolbarFill1" runat="server">
                            </x:ToolbarFill>
                            <x:Button ID="btnNew" runat="server" Icon="Add" EnablePostBack="false" Text="新增用户">
                            </x:Button>
                        </Items>
                    </x:Toolbar>
                </Toolbars>
                <PageItems>
                    <x:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                    </x:ToolbarSeparator>
                    <x:ToolbarText ID="elaspedTime" runat="server">
                    </x:ToolbarText>
                </PageItems>
                <Columns>
                    <x:RowNumberField EnablePagingNumber="true" Width="30px" />
                    <x:BoundField DataField="FUserName" SortField="FUserName" Width="100px" HeaderText="用户名" />
                    <x:BoundField DataField="FChineseName" SortField="FChineseName" Width="100px" HeaderText="中文名" />
                    <x:CheckBoxField DataField="FEnabled" SortField="FEnabled" HeaderText="启用" RenderAsStaticField="true"
                        Width="50px" />
                    <x:BoundField DataField="FGender" SortField="FGender" Width="50px" HeaderText="性别" />
                    <x:BoundField DataField="FEmail" SortField="FEmail" Width="150px" HeaderText="邮箱" />
                    <x:BoundField DataField="FDescription" ExpandUnusedSpace="true" HeaderText="备注" />
                    <x:WindowField TextAlign="Center" Icon="Information" ToolTip="查看详细信息" Title="查看详细信息"
                        WindowID="Window1" DataIFrameUrlFields="FUserId" DataIFrameUrlFormatString="~/admin/user_view.aspx?id={0}"
                        Width="50px" />
                    <x:WindowField ColumnID="changePasswordField" TextAlign="Center" Icon="Key" ToolTip="修改密码"
                        WindowID="Window1" Title="修改密码" DataIFrameUrlFields="FUserId" DataIFrameUrlFormatString="~/admin/user_changepassword.aspx?id={0}"
                        Width="50px" />
                    <x:WindowField ColumnID="editField" TextAlign="Center" Icon="Pencil" ToolTip="编辑"
                        WindowID="Window1" Title="编辑" DataIFrameUrlFields="FUserId" DataIFrameUrlFormatString="~/admin/TUser_Edit.aspx?id={0}"
                        Width="50px" />
                    <x:LinkButtonField ColumnID="deleteField" TextAlign="Center" Icon="Delete" ToolTip="删除"
                        ConfirmText="确定删除此记录？" ConfirmTarget="Top" CommandName="Delete" Width="50px" />
                </Columns>
            </x:Grid>
        </Items>
    </x:Panel>
    <x:Window ID="Window1" runat="server" IsModal="true" Hidden="true" Target="Top" EnableResize="true"
        EnableMaximize="true" EnableIFrame="true" IFrameUrl="about:blank" Width="650px"
        Height="450px" OnClose="Window1_Close">
    </x:Window>
    </form>
</body>
</html>

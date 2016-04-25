<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TUser_Edit.aspx.cs" Inherits="FineOA.Web.admin.TUser_Edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <x:PageManager ID="PageManager1" AutoSizePanelID="Panel1" runat="server" />
    <x:Panel ID="Panel1" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
        AutoScroll="true" runat="server">
        <Toolbars>
            <x:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <x:Button ID="btnClose" Icon="SystemClose" EnablePostBack="false" runat="server"
                        Text="关闭">
                    </x:Button>
                    <x:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                    </x:ToolbarSeparator>
                    <x:Button ID="btnSaveClose" ValidateForms="SimpleForm1" Icon="SystemSaveClose" OnClick="btnSaveClose_Click"
                        runat="server" Text="保存后关闭">
                    </x:Button>
                </Items>
            </x:Toolbar>
        </Toolbars>
        <Items>
            <x:Form ID="SimpleForm1" ShowBorder="false" ShowHeader="false" runat="server" BodyPadding="10px"
                EnableBackgroundColor="true" Title="SimpleForm">
                <Rows>
                    <x:FormRow runat="server">
                        <Items>
                            <x:Label ID="labName" runat="server" Label="用户名">
                            </x:Label>
                            <x:TextBox ID="tbxRealName" runat="server" Label="中文名" Required="true" ShowRedStar="true">
                            </x:TextBox>
                        </Items>
                    </x:FormRow>
                    <x:FormRow runat="server">
                        <Items>
                            <x:RadioButtonList ID="ddlGender" Label="性别" Required="true" ShowRedStar="true" runat="server">
                                <x:RadioItem Text="男" Value="男" />
                                <x:RadioItem Text="女" Value="女" />
                            </x:RadioButtonList>
                            <x:CheckBox ID="cbxEnabled" runat="server" Label="是否启用">
                            </x:CheckBox>
                        </Items>
                    </x:FormRow>
                    <x:FormRow ID="FormRow1" runat="server">
                        <Items>
                            <x:TextBox ID="tbxEmail" runat="server" Label="邮箱" Required="true" ShowRedStar="true"
                                RegexPattern="EMAIL">
                            </x:TextBox>
                            <x:TextBox ID="tbxCompanyEmail" runat="server" Label="公司邮箱" RegexPattern="EMAIL">
                            </x:TextBox>
                        </Items>
                    </x:FormRow>
                    <x:FormRow ID="FormRow2" runat="server">
                        <Items>
                            <x:TextBox ID="tbxOfficePhone" runat="server" Label="工作电话">
                            </x:TextBox>
                            <x:TextBox ID="tbxOfficePhoneExt" runat="server" Label="分机号">
                            </x:TextBox>
                        </Items>
                    </x:FormRow>
                    <x:FormRow ID="FormRow4" runat="server">
                        <Items>
                            <x:TextBox ID="tbxHomePhone" runat="server" Label="家庭电话">
                            </x:TextBox>
                            <x:TextBox ID="tbxCellPhone" runat="server" Label="手机号">
                            </x:TextBox>
                        </Items>
                    </x:FormRow>
                    <x:FormRow runat="server">
                        <Items>
                            <x:TriggerBox ID="tbSelectedRole" EnableEdit="false" EnablePostBack="false" TriggerIcon="Search"
                                Label="所属角色" runat="server">
                            </x:TriggerBox>
                        </Items>
                    </x:FormRow>
                    <x:FormRow runat="server">
                        <Items>
                            <x:TriggerBox ID="tbSelectedDept" EnableEdit="false" EnablePostBack="false" TriggerIcon="Search"
                                Label="所属部门" runat="server">
                            </x:TriggerBox>
                        </Items>
                    </x:FormRow>
                    <x:FormRow runat="server">
                        <Items>
                            <x:TriggerBox ID="tbSelectedTitle" EnableEdit="false" EnablePostBack="false" TriggerIcon="Search"
                                Label="拥有职称" runat="server">
                            </x:TriggerBox>
                        </Items>
                    </x:FormRow>
                    <x:FormRow runat="server">
                        <Items>
                            <x:TextArea ID="tbxRemark" runat="server" Label="备注">
                            </x:TextArea>
                        </Items>
                    </x:FormRow>
                </Rows>
            </x:Form>
        </Items>
    </x:Panel>
    <x:HiddenField ID="hfSelectedRole" runat="server">
    </x:HiddenField>
    <x:HiddenField ID="hfSelectedDept" runat="server">
    </x:HiddenField>
    <x:HiddenField ID="hfSelectedTitle" runat="server">
    </x:HiddenField>
    <x:Window ID="Window1" Title="编辑" Popup="false" EnableIFrame="true" runat="server"
        EnableMaximize="true" EnableResize="true" Target="Top" IsModal="True" Width="550px"
        Height="350px">
    </x:Window>
    </form>
</body>
</html>

<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="RoleManage.aspx.cs" Inherits="SysManage_RoleManage_RoleManage" Title="自动办公系统 | 角色管理" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphOffice" runat="Server">
    <div style="width: 100%; height: 100%; text-align: center">
        <br />
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" Text="角色管理"></asp:Label>
        <hr /> <asp:UpdatePanel id="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <contenttemplate>
        <table style="width: 480px">
            <tbody>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="角色名称："></asp:Label></td>
                    <td style="width: 182px">
                        <asp:TextBox ID="TxtRoleName" runat="server" Width="165px" CssClass="inputCss"></asp:TextBox></td>
                    <td style="width: 126px">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="None"
                            ControlToValidate="TxtRoleName" ErrorMessage="角色名称不能为空"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td style="height: 69px">
                        <asp:Label ID="Label3" runat="server" Text="角色说明："></asp:Label></td>
                    <td style="width: 182px; height: 69px">
                        <asp:TextBox ID="TxtRoleDesc" runat="server" Height="46px" Width="165px" TextMode="MultiLine"></asp:TextBox></td>
                    <td style="width: 126px; height: 69px">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="None"
                            ControlToValidate="TxtRoleDesc" ErrorMessage="角色说明不能为空"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td style="width: 182px">
                        <asp:Button ID="BtnAddRole" OnClick="BtnAddRole_Click" runat="server" Text="添加" CssClass="buttonCss"
                            BackColor="#EFF3FB"></asp:Button>
                        <asp:Button ID="BtnUpdateRole" OnClick="BtnUpdateRole_Click" runat="server" Enabled="False"
                            Text="保存修改" CssClass="buttonCss" BackColor="#EFF3FB"></asp:Button>
                        <asp:Button ID="btnCancel" OnClick="btnCancel_Click" runat="server" CausesValidation="False"
                            Text="取 消" CssClass="buttonCss" BackColor="#EFF3FB"></asp:Button></td>
                    <td style="width: 126px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 182px">
                    </td>
                    <td style="width: 1px">
                    </td>
                    <td style="width: 126px">
                    </td>
                </tr>
            </tbody>
        </table>
        <table style="width: 604px">
            <tbody>
                <tr>
                    <td style="width: 600px" align="center">
                        <asp:GridView ID="GVRoleInfoAll" runat="server" Width="99%" CssClass="grayBorder"
                            OnRowDataBound="GVRoleInfoAll_RowDataBound" OnRowCommand="GVRoleInfoAll_RowCommand"
                            BorderColor="#00A3FF" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField DataField="RoleName" SortExpression="RoleName" HeaderText="角色名称"></asp:BoundField>
                                <asp:BoundField DataField="RoleDesc" SortExpression="RoleDesc" HeaderText="角色说明"></asp:BoundField>
                                <asp:TemplateField HeaderText="修改">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="IBUpdate" runat="server" Height="15px" ImageUrl="~/images/edit.gif"
                                            Width="16px" CommandArgument='<%# Eval("Id") %>' CausesValidation="False"></asp:ImageButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="权限">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="IBRoleRight" runat="server" Height="15px" ImageUrl="~/images/admin2.gif"
                                            Width="15px" CommandArgument='<%# Eval("Id") %>' CausesValidation="False"></asp:ImageButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="删除">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="IBDelete" runat="server" Height="11px" ImageUrl="~/images/delete.gif"
                                            Width="15px" CommandArgument='<%# Eval("Id") %>' CausesValidation="False" OnClientClick="return confirm('您确认要删除吗？')">
                                        </asp:ImageButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle BackColor="#EFF3FB"></HeaderStyle>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td style="width: 400px; height: 23px" align="right">
                        <webdiyer:AspNetPager ID="anpPager" runat="server" SubmitButtonClass="buttonCss"
                            PrevPageText="上一页" NextPageText="下一页" LastPageText="尾页" FirstPageText="第一页" PageSize="5"
                            ShowBoxThreshold="10" OnPageChanged="anpPager_PageChanged">
                        </webdiyer:AspNetPager>
                    </td>
                </tr>
            </tbody>
        </table>
        </contenttemplate> </asp:UpdatePanel>
    </div>
</asp:Content>

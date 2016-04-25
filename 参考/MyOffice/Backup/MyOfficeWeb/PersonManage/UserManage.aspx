<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="UserManage.aspx.cs" Inherits="PersonManage_UserManage"
    Title="自动办公系统 | 用 户 管 理" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphOffice" runat="Server">
    <div style="width: 100%; text-align: center">
        <div style="width: 100%; text-align: center">
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" Text=" 用 户 管 理"></asp:Label>
            <hr />
        </div> <asp:UpdatePanel id="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <contenttemplate>
        <div style="width: 664px; height: 268px; text-align: right">
            <table width="652">
                <tbody>
                    <tr>
                        <td style="width: 243px">
                            <asp:DropDownList ID="ddlBranchs" runat="server">
                            </asp:DropDownList>
                            <ajax:CascadingDropDown ID="cddBranchs" runat="server" Enabled="True" PromptText="------请选择------"
                                Category="Branch" TargetControlID="ddlBranchs" ServicePath="~/WebService/BranchService.asmx"
                                ServiceMethod="GetBranchIf">
                            </ajax:CascadingDropDown>
                        </td>
                        <td style="width: 201px; height: 33px">
                            <asp:DropDownList ID="ddlDepart" runat="server">
                            </asp:DropDownList>
                            <ajax:CascadingDropDown ID="cddDepart" runat="server" Enabled="True" PromptText="--请选择--"
                                Category="Depart" TargetControlID="ddlDepart" ServicePath="~/WebService/BranchService.asmx"
                                ServiceMethod="GetDepart" ParentControlID="ddlBranchs">
                            </ajax:CascadingDropDown>
                        </td>
                        <td style="width: 166px; height: 33px" align="center">
                            <asp:ImageButton ID="ImagBtnSearch" runat="server" Height="23px" Width="105px" ImageUrl="~/images/search.gif"
                                OnClick="ImagBtnSearch_Click"></asp:ImageButton></td>
                        <td style="width: 100px; height: 33px">
                            <asp:Button ID="Button1" OnClick="Button1_Click" runat="server" Text="添加用户" CssClass="buttonCss">
                            </asp:Button></td>
                    </tr>
                </tbody>
            </table>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <asp:GridView ID="gvUser" runat="server" Width="652px" OnRowDataBound="gvUser_RowDataBound"
                PageSize="5" DataKeyNames="Id" BorderColor="#00A3FF" AutoGenerateColumns="False">
                <Columns>
                    <asp:TemplateField HeaderText="用户ID">
                        <ItemTemplate>
                            <asp:Label ID="lblUserId" runat="server" Text='<%# Eval("LoginId") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="姓名">
                        <ItemTemplate>
                            <asp:Label ID="lalUserName" runat="server" Text='<%# Eval("UserName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="角色">
                        <ItemTemplate>
                            <asp:Label ID="lblUserRole" runat="server" Text='<%# Eval("Role.RoleName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="所属机构">
                        <ItemTemplate>
                            <asp:Label ID="lblBranch" runat="server" Text='<%# Eval("Depart.Branch.BranchName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="所属部门">
                        <ItemTemplate>
                            <asp:Label ID="lblDepart" runat="server" Text='<%# Eval("Depart.DepartName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="用户详情">
                        <ItemTemplate>
                            <asp:HyperLink ID="hlUserInfo" runat="server" NavigateUrl='<%# Eval("Id","UserInfo.aspx?uid={0}") %>'>详情</asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="修改">
                        <ItemTemplate>
                            <asp:ImageButton ID="imgbtnModify" runat="server" Height="16px" ImageUrl="~/images/edit.gif"
                                Width="15px" OnClick="imgbtnModify_Click" CommandArgument='<%# Eval("Id") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="删除">
                        <ItemTemplate>
                            <asp:ImageButton ID="imgbtnDelete" runat="server" Height="7px" ImageUrl="~/images/delete.gif"
                                Width="16px" OnClick="imgbtnDelete_Click" OnClientClick="return confirm('您确认要删除吗？')"
                                CommandArgument='<%# Eval("Id") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <RowStyle HorizontalAlign="Center" Wrap="False" />
                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
            </asp:GridView>
            <webdiyer:AspNetPager ID="anpPager" runat="server" PageSize="5" OnPageChanged="anpPager_PageChanged"
                NumericButtonCount="5" PrevPageText="上一页" NextPageText="下一页" LastPageText="尾页"
                FirstPageText="第一页" ShowBoxThreshold="10">
            </webdiyer:AspNetPager>
        </div>
        </contenttemplate> </asp:UpdatePanel>
    </div>
</asp:Content>

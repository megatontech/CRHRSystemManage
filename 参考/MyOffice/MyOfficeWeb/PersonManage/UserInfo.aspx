<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UserInfo.aspx.cs" Inherits="PersonManage_UserInfo" Title="自动办公系统 | 用户信息" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphOffice" Runat="Server">
    <div style=" width: 769px; height: 301px; text-align: center;">
    <div style="width: 100%; text-align: center">
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" Text="用户信息"></asp:Label>
            <hr />
        </div>
        <table style="border:solid #999999 1px;">
            <tr>
                <td  align="center" valign="middle">
                    <asp:Image ID="imgFace" runat="server" style="width: 160px; height: 160px"  /></td>
                <td style="text-align: center; width: 186px;">
                    <table style="width: 185px; height: 331px">
                        <tr>
                            <td>
                                用户名：</td>
                            <td>
                                <asp:Label ID="lalLoginId" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                姓名：</td>
                            <td>
                                <asp:Label ID="lblUserName" runat="server" Text="Label"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                部门：</td>
                            <td>
                                <asp:Label ID="lblDepart" runat="server" Text="Label"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                性别：</td>
                            <td>
                                <asp:Label ID="lblGender" runat="server" Text="Label"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                角色：</td>
                            <td>
                                <asp:Label ID="lblUserRole" runat="server" Text="Label"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                用户状态：</td>
                            <td>
                                <asp:Label ID="lblUserState" runat="server" Text="Label"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text=" 返  回" CssClass="buttonCss" /></td>
                            <td>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>


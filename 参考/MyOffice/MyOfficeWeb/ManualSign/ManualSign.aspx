<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ManualSign.aspx.cs" Inherits="ManualSign_ManualSign" Title="自动办公系统 | 员工签到、签退" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphOffice" runat="Server">
    <div style="width: 100%; height: 100%; text-align: center">
        <br />
        <asp:Label ID="Label1" runat="server" Text="员工签到、签退" Font-Bold="True" Font-Size="Medium"></asp:Label>
        <hr />
        <table>
            <tr>
                <td>
                </td>
            </tr>
            <tr>
                <td style="text-align: left;">
                    <div id="aa" style="width: 100%; height: 100%" runat="server">
                        <table style="width: 520px; border-left-color: #cccccc; border-bottom-color: #cccccc;
                            border-top-style: double; border-top-color: #cccccc; border-right-style: double;
                            border-left-style: double; border-right-color: #cccccc; border-bottom-style: double;
                            border: 1px;">
                            <tr>
                                <td colspan="4" style="text-align: left; height: 23px;">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text="签卡时间："></asp:Label>
                                </td>
                                <td style="text-align: left;">
                                    <asp:TextBox ID="txtSignDate" runat="server" Enabled="False" CssClass="inputCss"></asp:TextBox></td>
                                <td>
                                    <asp:Button ID="btnArrive" runat="server" Text=" 签 到" BackColor="#EFF3FB" CssClass="buttonCss" Enabled="False" OnClick="btnArrive_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="btnLeave" runat="server" Text=" 签 退" BackColor="#EFF3FB" CssClass="buttonCss"
                                        Enabled="False" OnClick="btnLeave_Click" OnClientClick="return confirm('您确认要签 退吗？')" />
                                </td>
                            </tr>
                            <tr>
                                <td style="vertical-align: top; width: 61px; height: 71px;">
                                    <asp:Label ID="Label3" runat="server" Text="签卡备注："></asp:Label></td>
                                <td colspan="3" style="text-align: left; height: 71px;">
                                    <asp:TextBox ID="TxtSignDescNow" runat="server" Height="67px" TextMode="MultiLine"
                                        Width="100%"></asp:TextBox></td>
                            </tr>
                        </table>
                    </div>
                    <hr style="color: #6dc7fc" />
                </td>
            </tr>
            <tr>
                <td>
                    <div id="divManualSignIn" runat="server" style="width: 100%; height: 100%" visible="false">
                        <table style="width: 520px; border-left-color: #cccccc; border-bottom-color: #cccccc;
                            border-top-style: double; border-top-color: #cccccc; border-right-style: double;
                            border-left-style: double; border-right-color: #cccccc; border-bottom-style: double;
                            border: 1px;">
                            <tr>
                                <td colspan="4" style="background-color: #6dc7fc; text-align: left">
                                    <asp:Label ID="Label11" runat="server" Font-Bold="True" Text="签到信息"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text="用户帐号："></asp:Label></td>
                                <td align="left" style="width: 158px">
                                    <asp:TextBox ID="TxtUserId" runat="server" Enabled="False" CssClass="inputCss"></asp:TextBox>
                                </td>
                                <td style="text-align: right;">
                                    <asp:Label ID="Label5" runat="server" Text="姓名："></asp:Label></td>
                                <td style="width: 133px">
                                    <asp:TextBox ID="TxtUserName" runat="server" Enabled="False" CssClass="inputCss"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label6" runat="server" Text="所属部门："></asp:Label></td>
                                <td align="left" style="width: 158px">
                                    <asp:TextBox ID="TxtDepart" runat="server" Enabled="False" CssClass="inputCss"></asp:TextBox></td>
                                <td>
                                    <asp:Label ID="Label7" runat="server" Text="所属机构："></asp:Label></td>
                                <td style="width: 133px">
                                    <asp:TextBox ID="TxtBranch" runat="server" Enabled="False" CssClass="inputCss" Width="200px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label8" runat="server" Text="签到时间："></asp:Label></td>
                                <td align="left" style="width: 158px">
                                    <asp:TextBox ID="TxtSignTime" runat="server" Enabled="False" CssClass="inputCss"></asp:TextBox></td>
                                <td>
                                </td>
                                <td style="width: 133px">
                                </td>
                            </tr>
                            <tr>
                                <td style="vertical-align: top;">
                                    <asp:Label ID="Label9" runat="server" Text="签卡备注："></asp:Label></td>
                                <td colspan="3" style="text-align: left;">
                                    <asp:TextBox ID="TxtSignDesc" runat="server" Enabled="False" Height="70px" TextMode="MultiLine"
                                        Width="100%"></asp:TextBox></td>
                            </tr>
                        </table>
                    </div>
                    <div id="divManualSignOut" runat="server" style="width: 100%; height: 100%" visible="false">
                        <table style="width: 520px; border-left-color: #cccccc; border-bottom-color: #cccccc;
                            border-top-style: double; border-top-color: #cccccc; border-right-style: double;
                            border-left-style: double; border-right-color: #cccccc; border-bottom-style: double;
                            border: 1px;">
                            <tr>
                                <td colspan="4" style="background-color: #6dc7fc; text-align: left">
                                    <asp:Label ID="Label10" runat="server" Font-Bold="True" Text="签退信息"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label12" runat="server" Text="用户帐号："></asp:Label></td>
                                <td align="left" style="width: 147px">
                                    <asp:TextBox ID="TxtUserId2" runat="server" CssClass="inputCss" Enabled="False"></asp:TextBox>
                                </td>
                                <td style="width: 67px">
                                    <asp:Label ID="Label13" runat="server" Text="姓名："></asp:Label></td>
                                <td style="width: 229px" align="left">
                                    <asp:TextBox ID="TxtUserName2" runat="server" CssClass="inputCss" Enabled="False"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label14" runat="server" Text="所属部门："></asp:Label></td>
                                <td align="left" style="width: 147px">
                                    <asp:TextBox ID="TxtDepart2" runat="server" CssClass="inputCss" Enabled="False"></asp:TextBox></td>
                                <td style="width: 67px">
                                    <asp:Label ID="Label15" runat="server" Text="所属机构："></asp:Label></td>
                                <td style="width: 229px" align="left">
                                    <asp:TextBox ID="TxtBranch2" runat="server" CssClass="inputCss" Enabled="False" Width="200px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label16" runat="server" Text="签退时间："></asp:Label></td>
                                <td align="left" style="width: 147px">
                                    <asp:TextBox ID="TxtSignTime2" runat="server" CssClass="inputCss" Enabled="False"></asp:TextBox></td>
                                <td style="width: 67px">
                                </td>
                                <td style="height: 23px; width: 229px;">
                                </td>
                            </tr>
                            <tr>
                                <td style="vertical-align: top;">
                                    <asp:Label ID="Label17" runat="server" Text="签卡备注："></asp:Label></td>
                                <td colspan="3" style="text-align: left;">
                                    <asp:TextBox ID="TxtSignDesc2" runat="server" Enabled="False" Height="70px"
                                        TextMode="MultiLine" Width="100%"></asp:TextBox></td>
                            </tr>
                        </table>
                    </div>
                    <asp:Label ID="lblMessage" runat="server" Font-Size="20px" ForeColor="Red" Visible="False"></asp:Label>&nbsp;
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

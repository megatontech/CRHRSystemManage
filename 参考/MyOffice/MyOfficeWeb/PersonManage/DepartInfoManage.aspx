<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="DepartInfoManage.aspx.cs" Inherits="PersonManage_DepartInfoManage"
    Title="自动办公系统 | 部 门 信 息" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphOffice" runat="Server">
<script type="text/javascript">
    function show()
    {
        if(divTree.style.display=="block")
            divTree.style.display="none";
        else
            divTree.style.display="block";
    }
</script>
    <div style="width: 100%; width: 98%; text-align: center">
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" Text="部门管理"></asp:Label>
        <hr />  <asp:UpdatePanel id="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <contenttemplate>
        <table style="width: 600px; height: 600px">
            <tbody>
                <tr>
                    <td style="width: 359px; text-align: center" valign="top" align="center">
                        &nbsp;<table style="width: 257px; height: 400px; text-align: left">
                            <tbody>
                                <tr>
                                    <td style="width: 233px; text-align: left">
                                        部门名称：</td>
                                </tr>
                                <tr>
                                    <td style="width: 233px; text-align: left">
                                        <asp:TextBox ID="txtDepartName" runat="server" CssClass="inputCss"></asp:TextBox>&nbsp;
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDepartName"
                                            ErrorMessage="*"></asp:RequiredFieldValidator></td>
                                </tr>
                                <tr style="color: #000000">
                                    <td style="width: 233px; text-align: left">
                                        所属机构：</td>
                                </tr>
                                <tr>
                                    <td style="width: 233px; text-align: left">
                                        <asp:DropDownList ID="ddlBranch" runat="server" DataTextField="BranchName" DataValueField="Id">
                                        </asp:DropDownList>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="width: 233px; text-align: left">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 233px; text-align: left">
                                        部门负责人：</td>
                                </tr>
                                <tr>
                                    <td style="width: 233px; text-align: left">
                                        <table>
                                            <tbody>
                                                <tr>
                                                    <td style="width: 68px">
                                                        <asp:TextBox ID="txtUser" runat="server" CssClass="inputCss" ReadOnly="True"></asp:TextBox></td>
                                                    <td style="width: 8300px">
                                                    </td>
                                                    <td style="width: 100px; color: #000000">
                                                       
                                                            <img alt="" src="../images/admin2.gif" onclick="show()" />
                                                            </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </td>
                                </tr>
                                <tr style="color: #000000">
                                    <td style="width: 233px; height: 23px; text-align: left">
                                        联系电话：</td>
                                </tr>
                                <tr>
                                    <td style="width: 233px; height: 23px; text-align: left">
                                        <asp:TextBox ID="txtConnectTelNo" runat="server" CssClass="inputCss" MaxLength="8"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtconnectMobileTelNo"
                                            ErrorMessage="*"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtConnectTelNo"
                                            ErrorMessage="格式不正确!" ValidationExpression="(\(\d{3}\)|\d{3}-)?\d{8}" __designer:wfdid="w1"></asp:RegularExpressionValidator></td>
                                </tr>
                                <tr>
                                    <td style="width: 233px; text-align: left">
                                        移动电话：</td>
                                </tr>
                                <tr>
                                    <td style="width: 233px; height: 23px; text-align: left">
                                        <asp:TextBox ID="txtconnectMobileTelNo" runat="server" CssClass="inputCss" MaxLength="11"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtConnectTelNo"
                                            ErrorMessage="*"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtconnectMobileTelNo"
                                            ErrorMessage="格式不正确!" ValidationExpression="1(3|5)\d{9}" __designer:wfdid="w2"></asp:RegularExpressionValidator></td>
                                </tr>
                                <tr>
                                    <td style="width: 233px; height: 23px; text-align: left">
                                        传真：</td>
                                </tr>
                                <tr>
                                    <td style="width: 233px; height: 23px; text-align: left">
                                        <asp:TextBox ID="txtfaxes" runat="server" CssClass="inputCss" MaxLength="8"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtfaxes"
                                            ErrorMessage="*"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtfaxes"
                                            ErrorMessage="格式不正确!" ValidationExpression="(\(\d{3}\)|\d{3}-)?\d{8}" __designer:wfdid="w3"></asp:RegularExpressionValidator></td>
                                </tr>
                                <tr>
                                    <td style="width: 233px; height: 18px; text-align: left">
                                        <asp:Button ID="Button1" OnClick="Button1_Click" runat="server" Text="保存部门信息" CssClass="buttonCss">
                                        </asp:Button>
                                        <asp:Button ID="Button2" OnClick="Button2_Click" runat="server" Height="17px" CausesValidation="False"
                                            Text="返回" CssClass="buttonCss"></asp:Button>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                    <td style="vertical-align: top; width: 399px" valign="top" align="center">
                        &nbsp;<div style="width: 98%; display:none;" id="divTree">
                            <asp:TreeView ID="TreeView1" runat="server" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged"
                                OnTreeNodeExpanded="TreeView1_TreeNodeExpanded">
                            </asp:TreeView>
                        </div>
                    </td>
                </tr>
            </tbody>
        </table>
        </contenttemplate> </asp:UpdatePanel>
    </div>
</asp:Content>

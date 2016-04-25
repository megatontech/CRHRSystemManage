<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ModifyPassword.aspx.cs" Inherits="ModifyPassword" Title="自动办公系统 | 修改密码" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphOffice" runat="Server">
    <div style="width: 408px; height: 479px; margin: 0 auto;">
         
        <table style="width: 487px; height: 249px">
            <tbody>
                <tr>
                    <td align="center" colspan="4">
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="4">
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="4">
                        <b style="font-size: 18px">
                            <asp:Image ID="imgModify" runat="server" ImageUrl="~/images/modifypass.gif" Width="20" />修 改 密 码</b></td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 39px">
                    <hr />
                    </td>
                </tr>
                <tr>
                    <td style="width: 58px">
                    </td>
                    <td style="width: 109px">
                        请输入新密码：</td>
                    <td style="width: 101px">
                        <asp:TextBox ID="txtNewPed" runat="server" TextMode="Password" CssClass="inputBox"
                            >*</asp:TextBox></td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="txtNewPed" ErrorMessage="新密码不能为空"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td style="width: 58px; height: 46px;">
                    </td>
                    <td style="width: 109px; height: 46px;">
                        请确认新密码：</td>
                    <td style="width: 101px; height: 46px;">
                        <asp:TextBox ID="txtOkPwd" runat="server" TextMode="Password" CssClass="inputBox"></asp:TextBox></td>
                    <td style="height: 46px;">
                        <asp:CompareValidator ID="CompareValidator1" runat="server"
                            ControlToValidate="txtOkPwd" ErrorMessage="两次输入密码要一致" ControlToCompare="txtNewPed"></asp:CompareValidator></td>
                </tr>
                <tr>
                    <td colspan="4" >
                       
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td style="width: 58px">
                    </td>
                    <td style="width: 109px" align="right">
                        <asp:Button ID="btnOk" OnClick="btnOk_Click" runat="server" CssClass="buttonCss" Text="确　定"></asp:Button></td>
                    <td style="width: 101px" align="center">
                        <asp:Button ID="btnBack" OnClick="btnBack_Click" runat="server" CausesValidation="False"
                            CssClass="buttonCss" Text="返  回"></asp:Button></td>
                    <td>
                    </td>
                </tr>
            </tbody>
        </table>
        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RequiredFieldValidator2">
        </ajax:ValidatorCalloutExtender>
        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="CompareValidator1">
        </ajax:ValidatorCalloutExtender>
       
    </div>
</asp:Content>

<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MenuAdjust.aspx.cs" Inherits="SysManage_MenuAdjust" Title="自动办公系统 | 菜单排序" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphOffice" Runat="Server">
<br />
<div style="width: 100%; height:50px; text-align: center;">
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" Text="菜单排序"></asp:Label>
        <hr />
        </div>
 <div style="width: 50%; height:80%; text-align: left;margin-left: 150px;">
  
       
         <asp:UpdatePanel id="UpdatePanel2" runat="server" UpdateMode="Conditional">
            <contenttemplate> 
        <table>
            <tbody>
                <tr>
                    <td style="text-align: left; height: 18px;">
                        <asp:Button ID="BtnUp" OnClick="BtnUp_Click" runat="server" BackColor="#EFF3FB" Text="上 移" CssClass="buttonCss">
                        </asp:Button>
                    </td>
                    <td style="text-align: right; height: 18px;">
                        <asp:Button ID="BtnDown" OnClick="BtnDown_Click" runat="server" BackColor="#EFF3FB"
                            Text="下 移" CssClass="buttonCss"></asp:Button>
                    </td>
                </tr>
                <tr>
                    <td style="width: 140px; text-align: left; height: 23px;" colspan="2">
                        <asp:Label ID="LblMessage" runat="server" Visible="False" BackColor="White" ForeColor="Red"
                            Text="操作菜单项已经置顶"></asp:Label>&nbsp;</td>
                </tr>
            </tbody>
        </table>
        <table>
            <tbody>
                <tr>
                    <td style="width: 170px; text-align: left;">
                        <asp:TreeView ID="TVSysFunUpdate" runat="server" BackColor="#6DC7FC" ExpandDepth="0"   
                        OnSelectedNodeChanged="TVSysFunUpdate_SelectedNodeChanged">
                        </asp:TreeView>
                        <asp:HiddenField ID="hidNodeId" runat="server"></asp:HiddenField>
                    </td>
                </tr>
            </tbody>
        </table>
       
        </contenttemplate>
       
        </asp:UpdatePanel>
    </div>
</asp:Content>


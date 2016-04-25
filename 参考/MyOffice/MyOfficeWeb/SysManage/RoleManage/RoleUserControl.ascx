<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RoleUserControl.ascx.cs" Inherits="SysManage_RoleManage_RoleUserControl" %>
<asp:CheckBox  ID="chkParentMenu" onClick="CheckAll(this.id)" runat="server" Font-Bold="true" Font-Size="14px" CssClass="cbBg" />
<br />
<asp:CheckBoxList ID="chklstChildMenu" runat="server" RepeatDirection="Horizontal" 
  RepeatColumns="5" CellPadding="0" CellSpacing="0" Font-Size="13px" onClick="CheckOnly(this.id)">
</asp:CheckBoxList>
<input id="hidParentMenu" type="hidden" runat="server" />
<input id="hidRoleId" type="hidden" runat="server" />
<hr style="color:#66ccff;"/>

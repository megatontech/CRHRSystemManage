<%@ Page Language="C#" MasterPageFile="~/MasterPage/PageTemplate.Master" AutoEventWireup="true" CodeBehind="RoleManager.aspx.cs" Inherits="FrameWork.web.Module.FrameWork.RoleManager.RoleManager"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"
        HeadOPTxt="角色资料" HeadTitleTxt="角色资料管理" ButtonList-Capacity="4">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="List" ButtonUrl="RoleList.aspx"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="角色" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server">
        <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
		<tr id="TopTr" runat="server">
			<td class="table_body">
                角色ID</td>
			<td class="table_none">
                <asp:Label ID="RoleID_Txt" runat="server"></asp:Label></td>
		</tr>		
		<tr>
			<td class="table_body">
                角色名称</td>
			<td class="table_none">
                <asp:Label ID="R_RoleName_Txt" runat="server"></asp:Label>
                <asp:TextBox ID="R_RoleName" runat="server" Columns="50" title="请输入角色名称~50:!" CssClass="text_input"></asp:TextBox></td>
		</tr>
		<tr>
			<td class="table_body">
                角色介绍</td>
			<td class="table_none">
                <asp:Label ID="R_Description_Txt" runat="server"></asp:Label>
                <asp:TextBox ID="R_Description" runat="server" Columns="50" title="请输入角色介绍~255:" CssClass="text_input"></asp:TextBox></td>
		</tr>						
		<tr id="SubmitTr" runat="server"><td colspan="2" align="right">
            <asp:Button ID="Button1" runat="server" CssClass="button_bak" Text="确定" OnClick="Button1_Click" />
            <input id="Reset1" class="button_bak" type="reset" value="重填" />&nbsp;
		
		</td></tr>
	   </table>
        </FrameWorkWebControls:TabOptionItem>
    <FrameWorkWebControls:TabOptionItem ID="TabOptionItem2" runat="server" Tab_Name="设定角色应用权限">
        <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
		<tr class="table_title">
			<td style="height: 30px" >
                应用名称(点击应用名称进行角色应用权限修改)
            </td>
            <td style="height: 30px"></td>
		</tr>
		
        <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="GridView1_RowDataBound">
		    <ItemTemplate>
		        <tr class="table_body">
		        <td>
		            <a href="RolePermissionManager.aspx?RoleID=<%# Eval("A_RoleID") %>&ApplicationID=<%# Eval("A_ApplicationID") %>&CMD=Look">
                     <asp:Literal  ID="AppName" runat="server"></asp:Literal>
                     </a>
                </td>
		        <td>
		            <a href="RoleManager.aspx?RoleID=<%# Eval("A_RoleID") %>&ApplicationID=<%# Eval("A_ApplicationID") %>&CMD=Move" onClick="return doConfirm(this.form);">移除</a>
		        </td>
		        </tr>
		    </ItemTemplate>
		</asp:Repeater>
        </table>		


		
    </FrameWorkWebControls:TabOptionItem>
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem3" runat="server" Tab_Name="增加角色应用">
                <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
		<tr class="table_title">
			<td colspan="2">
                增加应用
            </td>
		</tr>	
		<tr>
		    <td class="table_body">应用名称</td>
		    <td class="table_none">
		        <asp:DropDownList ID="NewAppID" runat="server" title="请选择应用名称~!">
                </asp:DropDownList>
                
		    </td>
		</tr>
		<tr><td colspan="2" align="right"><asp:Button ID="Button2" runat="server" Text="确定" CssClass="button_bak" OnClick="Button2_Click" /></td></tr>
		</table>
        </FrameWorkWebControls:TabOptionItem>
    
    </FrameWorkWebControls:TabOptionWebControls>

</asp:Content>

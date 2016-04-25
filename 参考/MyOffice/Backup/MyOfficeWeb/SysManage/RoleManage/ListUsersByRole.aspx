<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="ListUsersByRole.aspx.cs" Inherits="SysManage_RoleManage_ListUsersByRole"
    Title="分配角色" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphOffice" runat="Server">

    <script type="text/javascript">
function CheckBoxBranch(){ 
    var Branch=document.getElementById("<%= chkBranch.ClientID%>");   
      if(Branch.checked==true)
      {
         document.getElementById("<%= ddlBranchs.ClientID%>").disabled=false;
         
      }
      else
      {
       document.getElementById("<%= ddlBranchs.ClientID%>").disabled=true;
        
      }
}
function CheckBoxDepart(){ 
    var Depart=document.getElementById("<%= chkDepart.ClientID%>");   
      if(Depart.checked==true)
      {
         document.getElementById("<%= ddlDeparts.ClientID%>").disabled=false;
      }
      else
      {
       document.getElementById("<%= ddlDeparts.ClientID%>").disabled=true;
      }
}
function CheckBoxUserName(){ 
    var UserName=document.getElementById("<%= chkUserName.ClientID%>");   
      if(UserName.checked==true)
      {
         document.getElementById("<%= txtUserName.ClientID%>").disabled=false;
      }
      else
      {
       document.getElementById("<%= txtUserName.ClientID%>").disabled=true;
      }
}
  function CheckBoxRole(){ 
      var chkRole=document.getElementById("<%= chkRole.ClientID%>");   
      if(chkRole.checked==true)
      {
         document.getElementById("<%= ddlRoles.ClientID%>").disabled=false;
      }
      else
      {
       document.getElementById("<%= ddlRoles.ClientID%>").disabled=true;
      }
}
function CheckBoxAll(){ 
       
        if(document.getElementById("<%= ddlRoles.ClientID%>").disabled==true)
        {
            document.getElementById("<%= chkRole.ClientID%>").checked=false;
        }else{
           document.getElementById("<%= chkRole.ClientID%>").checked=true;
        }
        
        if(document.getElementById("<%= ddlBranchs.ClientID%>").disabled==true)
        {
             document.getElementById("<%= chkBranch.ClientID%>").checked=false;
        }else{
            document.getElementById("<%= chkBranch.ClientID%>").checked=true;
        }
        
        if(document.getElementById("<%= ddlDeparts.ClientID%>").disabled==true)
        {
            document.getElementById("<%= chkDepart.ClientID%>").checked=false;
        }else{
           document.getElementById("<%= chkDepart.ClientID%>").checked=true;
             }
             
         if(document.getElementById("<%= txtUserName.ClientID%>").disabled==true)
        {
            document.getElementById("<%= chkUserName.ClientID%>").checked=false;
        }else{
           document.getElementById("<%= chkUserName.ClientID%>").checked=true;
        }
      
}
    </script>

    <div style="font-size: 14px;">
        <div style="width: 100%; height: 100%; text-align: center">
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" Text="分配角色"></asp:Label>
            <hr />    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <contenttemplate>
            <table>
                <tbody>
                    <tr>
                        <td align="left">
                            <asp:Image ID="img1" runat="server" ImageUrl="~/images/search2.gif"></asp:Image>查找范围：
                            <asp:CheckBox ID="chkBranch" onclick="CheckBoxBranch()" runat="server" Width="76px"
                                Text="按机构" Font-Size="15px" Checked="True"></asp:CheckBox>
                            <asp:CheckBox ID="chkDepart" onclick="CheckBoxDepart()" runat="server" Width="75px"
                                Text="按部门" Font-Size="15px" Checked="True"></asp:CheckBox>&nbsp;
                            <asp:CheckBox ID="chkRole" onclick="CheckBoxRole()" runat="server" Width="76px" Text="按角色"
                                Font-Size="15px"></asp:CheckBox>
                            <asp:CheckBox ID="chkUserName" onclick="CheckBoxUserName()" runat="server" Width="76px"
                                Text="按姓名" Font-Size="15px"></asp:CheckBox>
                            <hr width="98%" color="gray" size="1" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            &nbsp; &nbsp; &nbsp;机构:
                            <asp:DropDownList ID="ddlBranchs" runat="server" Width="160px" Enabled="False" CssClass="ddlCss">
                            </asp:DropDownList>
                            &nbsp; 部门:
                            <asp:DropDownList ID="ddlDeparts" runat="server" Enabled="False" CssClass="ddlCss">
                            </asp:DropDownList>&nbsp;&nbsp;角色：&nbsp;&nbsp;<asp:DropDownList ID="ddlRoles" runat="server"
                                Enabled="False">
                            </asp:DropDownList>&nbsp; 姓名:
                            <asp:TextBox ID="txtUserName" runat="server" Width="64px" Enabled="False" CssClass="inputCss"
                                Columns="10"></asp:TextBox>(模糊查找 eg:李)<br />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:ImageButton ID="imgbtnSearch" OnClick="imgbtnSearch_Click" runat="server" Height="21px"
                                Width="100px" ImageUrl="~/images/search.gif"></asp:ImageButton></td>
                    </tr>
                    <tr>
                        <td align="left">
                            &nbsp;<asp:Button ID="btnEnenable" OnClick="btnEnenable_Click" runat="server" Enabled="False"
                                Text="禁止用户" CssClass="buttonCss"></asp:Button>
                            <asp:Button ID="btnEnable" OnClick="btnEnable_Click" runat="server" Enabled="False"
                                Text="启用用户" CssClass="buttonCss"></asp:Button></td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:GridView ID="gvUser" runat="server" Width="652px" OnRowDataBound="gvUser_RowDataBound"
                                OnRowUpdating="gvUser_RowUpdating" PageSize="5" DataKeyNames="Id" BorderColor="#00A3FF"
                                AutoGenerateColumns="False">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <input id="chkAll" onclick="GetAllCheckBox(this),GetCheckBox(),CheckBoxAll()" type="checkbox" />全选
                                        </HeaderTemplate>
                                        <HeaderStyle Height="20px"></HeaderStyle>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkOne" onclick="GetCheckBox()" runat="server" BorderWidth="0px"></asp:CheckBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
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
                                    <asp:TemplateField HeaderText="机构">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBranchName" runat="server" Text='<%# Eval("Depart.Branch.BranchName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="部门">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDepartName" runat="server" Text='<%# Eval("Depart.DepartName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="用户状态">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="linkbtnUserState" runat="server" ForeColor="Blue" Text='<%# Eval("UserState.UserStateName") %>'
                                                __designer:wfdid="w3" CommandName="update" CommandArgument='<%# Eval("UserState.Id") %>'></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <RowStyle Wrap="False" HorizontalAlign="Center"></RowStyle>
                                <HeaderStyle Wrap="False" HorizontalAlign="Center"></HeaderStyle>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <webdiyer:AspNetPager ID="anpPager" runat="server" PageSize="5" SubmitButtonText="ok"
                                SubmitButtonClass="buttonCss" NumericButtonCount="5" PrevPageText="上一页" NextPageText="下一页"
                                LastPageText="尾页" FirstPageText="第一页" ShowBoxThreshold="10" OnPageChanged="anpPager_PageChanged">
                            </webdiyer:AspNetPager>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            角色名称：&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="ddlUserRoles" runat="server">
                            </asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnOk" OnClick="btnOk_Click" runat="server" Text="分配角色" Enabled="False" CssClass="buttonCss">
                            </asp:Button></td>
                    </tr>
                </tbody>
            </table>
            <br />
            <ajax:CascadingDropDown ID="cddBranchs" runat="server" Enabled="True" ServiceMethod="GetBranchIf"
                ServicePath="~/WebService/BranchService.asmx" TargetControlID="ddlBranchs" Category="Branch"
                PromptText="--请选择--">
            </ajax:CascadingDropDown>
            <ajax:CascadingDropDown ID="cddDepart" runat="server" Enabled="True" ServiceMethod="GetDepart"
                ServicePath="~/WebService/BranchService.asmx" TargetControlID="ddlDeparts" Category="Depart"
                PromptText="--请选择--" ParentControlID="ddlBranchs">
            </ajax:CascadingDropDown>
            </contenttemplate> </asp:UpdatePanel></div>
    </div>
</asp:Content>

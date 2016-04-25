<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DepartManage.aspx.cs" Inherits="PersonManage_DepartManage" Title="自动办公系统 | 部门管理" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphOffice" Runat="Server">
      <div style="width: 100%; text-align: center">
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" Text="部门管理"></asp:Label>
        <hr />
          <table>
              <tr>
                  <td colspan="2">
                      <asp:DropDownList ID="ddlBranch" runat="server" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged" AutoPostBack="True">
                      </asp:DropDownList></td>
                  <td style="width: 100px">
                      <asp:Button ID="btnAddDepart" runat="server" CssClass="buttonCss" OnClick="btnAddDepart_Click"
                          Text="添加部部门" /></td>
              </tr>
          </table>
      </div><div style="width: 100%; text-align: center">
            <asp:UpdatePanel id="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <contenttemplate>
<DIV style="WIDTH: 598px; HEIGHT: 319px; TEXT-ALIGN: right"><BR /><asp:GridView id="GridView1" runat="server" Width="652px" OnRowDataBound="GridView1_RowDataBound" AutoGenerateColumns="False" BorderColor="#00A3FF" DataKeyNames="Id" PageSize="5" __designer:wfdid="w117"><Columns>
<asp:TemplateField HeaderText="部门名称"><ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("DepartName") %>'></asp:Label>
                        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="所属机构"><ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("Branch.BranchName") %>'></asp:Label>
                        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="负责人"><ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("User.UserName") %>'></asp:Label>
                        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="联系电话"><ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("ConnectTelNo") %>'></asp:Label>
                        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="移动电话"><ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("ConnectMobileTelNo") %>'></asp:Label>
                        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="传真"><ItemTemplate>
                            <asp:Label ID="Label6" runat="server" Text='<%# Eval("Faxes") %>'></asp:Label>
                        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="修改"><ItemTemplate>
                            <asp:ImageButton ID="imgbtnModify" runat="server" ImageUrl="~/images/edit.gif" OnClick="imgbtnModify_Click" CommandArgument='<%# Eval("Id") %>' />
                        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="删除"><ItemTemplate>
                            <asp:ImageButton ID="imgbtnDelete" runat="server" Height="9px" ImageUrl="~/images/delete.gif"
                                Width="17px"  CommandArgument='<%# Eval("Id") %>' OnClientClick="return confirm('您确认要删除吗？')" OnClick="imgbtnDelete_Click"/>
                        
</ItemTemplate>
</asp:TemplateField>
</Columns>

<RowStyle Wrap="False" HorizontalAlign="Center"></RowStyle>

<HeaderStyle Wrap="False" HorizontalAlign="Center"></HeaderStyle>
</asp:GridView> <webdiyer:aspnetpager id="anpPager" runat="server" PageSize="5" OnPageChanged="anpPager_PageChanged" ShowBoxThreshold="10" FirstPageText="第一页" LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" __designer:wfdid="w118"></webdiyer:aspnetpager> </DIV>
</contenttemplate> </asp:UpdatePanel>
</div>
</asp:Content>


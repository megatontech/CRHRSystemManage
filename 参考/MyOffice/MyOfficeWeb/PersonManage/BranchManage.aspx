<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BranchManage.aspx.cs" Inherits="PersonManage_BranchManage" Title="自动办公系统 | 机构管理" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphOffice" Runat="Server">

     <div style="width: 100%; text-align: center">
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" Text="机构管理"></asp:Label>
        <hr />
               <asp:UpdatePanel id="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <contenttemplate>
        <table>
            <tr>
                <td>
                    机构名称：</td>
                <td>
                    <asp:TextBox ID="txtBranchName" runat="server" CssClass="inputCss"></asp:TextBox>
                    
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBranchName"
                        ErrorMessage="*"></asp:RequiredFieldValidator></td>
                <td>
                    机构简称：</td>
                <td>
                    <asp:TextBox ID="txtBranchShortName" runat="server" CssClass="inputCss"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtBranchShortName"
                        ErrorMessage="*"></asp:RequiredFieldValidator></td>
                <td style="width: 240px;">
                    &nbsp;<asp:Button ID="btnAdd" runat="server" CssClass="buttonCss" Text="添加" OnClick="Button1_Click" />
                    &nbsp; &nbsp;
                    <asp:Button ID="btnSave" runat="server" CssClass="buttonCss" Text="保存修改" OnClick="btnSave_Click" /></td>
            </tr>
        </table>
    
  
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="650px" CssClass="grayBorder" BorderColor="#00A3FF" DataKeyNames="Id" OnRowDataBound="GridView1_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="机构名称">
                    <EditItemTemplate>
                        &nbsp;
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("BranchName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="机构简称">
                    <EditItemTemplate>
                        &nbsp;
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("BranchShortName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="修改">
                    <ItemTemplate>
                        <asp:ImageButton ID="imgbtnModify" runat="server" ImageUrl="~/images/edit.gif" CommandArgument='<%# Eval("Id") %>' OnClick="imgbtnModify_Click" CausesValidation="False" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="删除">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton2" runat="server" Height="11px" ImageUrl="~/images/delete.gif"
                         Width="15px" CommandArgument='<%# Eval("Id") %>' OnClientClick="return confirm('您确认要删除吗？')" CausesValidation="False" OnClick="ImageButton2_Click" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False" />
                </asp:TemplateField>
            </Columns>
            <RowStyle HorizontalAlign="Center" Wrap="False" />
        </asp:GridView>
        <webdiyer:AspNetPager  ID="anpPager" runat="server" OnPageChanged="anpPager_PageChanged"
                    ShowBoxThreshold="10" PageSize="5" FirstPageText="第一页" LastPageText="尾页" NextPageText="下一页"
                    PrevPageText="上一页" >
        </webdiyer:AspNetPager>
   </contenttemplate> </asp:UpdatePanel>
    </div>
</asp:Content>


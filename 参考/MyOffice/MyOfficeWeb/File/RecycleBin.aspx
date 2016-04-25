<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="RecycleBin.aspx.cs" Inherits="File_RecycleBin" Title="回收站" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphOffice" runat="Server">
    <div align="center">
        <br />
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" Text=" 回 收 站"></asp:Label>
        <hr color="gray" size="1" style="width: 90%; text-align: center" />
        <div style="width: 90%; text-align: center">
            <asp:GridView ID="gvFilesInfo" Width="100%" runat="server" AutoGenerateColumns="False"
                BorderColor="#66CCFF" BorderWidth="1px" CellPadding="4" OnRowDataBound="gvFilesInfo_RowDataBound"
                OnRowCommand="gvFilesInfo_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="文件名称">
                        <ItemTemplate>
                            <asp:Label ID="lblFileName" runat="server" Text='<%# Eval("FileName") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Wrap="False" />
                        <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="文件路径">
                        <ItemStyle HorizontalAlign="Center" Wrap="True" />
                        <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# GetPath(Eval("FilePath")) %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="类型　">
                        <ItemTemplate>
                            <asp:Label ID="lblFileType" runat="server" Text='<%# Eval("FileType.FileTypeName") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Wrap="False" />
                        <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作者">
                        <ItemStyle HorizontalAlign="Center" Wrap="False" />
                        <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("FileOwner.UserName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="删除日期">
                        <ItemStyle HorizontalAlign="Center" Wrap="False" />
                        <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("CreateDate") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="还原">
                        <ItemTemplate>
                            <asp:ImageButton ID="ibtnUpCancel" runat="server" ImageUrl="~/images/file/upcancel.gif"
                                CommandArgument='<%# Eval("Id") %>' CommandName="UpCancel" />
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:LinkButton ID="lbtnClear" runat="server" ForeColor="Red" CommandArgument='<%# Eval("Id") %>' OnClick="lbtnClear_Click" OnClientClick='return confirm("确定清空回收站？")'>全部清空</asp:LinkButton>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:ImageButton ID="ibtnDelete" runat="server" ImageUrl="~/images/file/delete.gif"
                                OnClientClick='return confirm("确定永久的删除吗？")' CommandArgument='<%# Eval("Id") %>'
                                CommandName="Del" />
                        </ItemTemplate>
                        <ItemStyle Width="70px" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>

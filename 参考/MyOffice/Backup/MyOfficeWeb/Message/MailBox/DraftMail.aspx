<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DraftMail.aspx.cs" Inherits="Message_MailBox_DraftMail" Title="信箱 |草 稿 箱" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphOffice" Runat="Server">

    <script language="javascript" type="text/javascript">
    
	/*全选*/
        function GetAllCheckBox(checkAll){
            var items=document.getElementsByTagName("input");  
            for(i=0;i<items.length;i++){
                if(items[i].type=="checkbox")
                {
                    items[i].checked=checkAll.checked;
                }   
            }
        }
    </script>

    <div style="width: 100%; text-align: center">
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" Text="草 稿 箱"></asp:Label>
        <hr />
    </div>
    <div style="text-align: left">
        <table cellspacing="0" cellpadding="0" width="98%" align="center" border="0">
            <tr>
                <td align="left">
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <input type="checkbox" id="btnSelectAll" runat="server" onclick="GetAllCheckBox(this);" />全选</td>
                <td style="width: 9px">
                </td>
            </tr>
            <tr>
                <td valign="top" align="left" colspan="2" height="100%">
                    <asp:GridView ID="gvUnPublishMail" Width="99%" runat="server" DataKeyNames="Id" AutoGenerateColumns="False"
                        CellPadding="2" BackColor="White" CssClass="grayBorder" AllowPaging="True" OnRowDataBound="gvUnPublishMail_RowDataBound">
                        <RowStyle HorizontalAlign="Center" BackColor="White" />
                        <Columns>
                            <asp:TemplateField>
                                <HeaderStyle HorizontalAlign="Center" Width="12%" CssClass="HeaderCenter"></HeaderStyle>
                                <HeaderTemplate>
                                    删除(√)
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelect" runat="server"></asp:CheckBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="收件人">
                                <HeaderStyle HorizontalAlign="Center" Width="12%" CssClass="HeaderCenter"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:HyperLink ID="hlReceiveUsers" runat="server" ForeColor="Blue" Text=""></asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="主题">
                                <ItemTemplate>
                                     <asp:HyperLink ID="hlMessageContent" runat="server"><%# GetCut(Eval("Title"))%></asp:HyperLink>
                                </ItemTemplate>
                                <HeaderStyle CssClass="HeaderCenter" Width="30%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="发送时间">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# GetDate(Eval("Recordtime")) %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="HeaderCenter" Width="15%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="紧急程度">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="HeaderCenter" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td align="left" style="height: 23px">
                    &nbsp;&nbsp;&nbsp;&nbsp;<input id="btnDelete" class="buttonCss" type="submit" value="删除选定项"
                        runat="server" style="height: 24px" onserverclick="btnDelete_ServerClick" disabled="disabled">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <input id="btnPublish" class="buttonCss" type="submit" value="发布 选定项" runat="server"
                        style="height: 24px" onserverclick="btnPublish_ServerClick" disabled="disabled">
                </td>
                <td style="height: 23px; width: 300px;">
                    <input id="btnReturn" style="width: 88px; height: 24px" class="buttonCss" type="submit"
                        value="返回" name="Submit1" runat="server" onserverclick="btnReturn_ServerClick">
                </td>
            </tr>
        </table>
    </div>
</asp:Content>


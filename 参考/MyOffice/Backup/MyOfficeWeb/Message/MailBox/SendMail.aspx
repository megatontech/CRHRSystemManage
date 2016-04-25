<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="SendMail.aspx.cs" Inherits="Message_MailBox_ReceiveMail" Title="信箱 | 已发送文件" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphOffice" runat="server">

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
          function  ScanMessageDetail(messageId)
		{
		 window.showModalDialog("../MessageManage/MessageContent.aspx?messageid="+messageId,"","status=no;dialogWidth=550px;dialogHeight=600px;menu=no;resizeable=yes;scroll=yes;center=yes;edge=raise")
		}
    </script>

    <div style="width: 100%; text-align: center">
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" Text="已发送文件"></asp:Label>
        <hr />
    </div>
    <div style="text-align: left">
        <table cellspacing="0" cellpadding="0" width="98%" align="center" border="0">
            <tr>
                <td align="left">
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <input type="checkbox" id="btnSelectAll" runat="server" onclick="GetAllCheckBox(this);" />全选</td>
                <td colspan="4">
                </td>
            </tr>
            <tr>
                <td valign="top" align="right" colspan="4" height="100%">
                    <asp:GridView ID="gvPersonMessageInfo" Width="96%" runat="server" DataKeyNames="Id"
                        AutoGenerateColumns="False" CellPadding="2" BackColor="White" CssClass="grayBorder"
                        AllowPaging="True" OnRowDataBound="gvPersonMessageInfo_RowDataBound">
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
                            <asp:TemplateField HeaderText="标题">
                                <HeaderStyle HorizontalAlign="Center" Width="12%" CssClass="HeaderCenter"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# GetCut(Eval("Title")) %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="内容">
                                <HeaderStyle HorizontalAlign="Center" Width="12%" CssClass="HeaderCenter"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:HyperLink ID="hlMessageContent" runat="server"><%# GetCut(Eval("MessageContent")) %></asp:HyperLink>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
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
                        runat="server" style="height: 24px" onserverclick="btnDelete_ServerClick">
                    &nbsp;&nbsp;&nbsp;&nbsp;<input id="btnReturn" style="width: 88px; height: 24px" class="buttonCss"
                        type="submit" value="返回" name="Submit1" runat="server" onserverclick="btnReturn_ServerClick"></td>
                <td colspan="4" style="height: 23px">
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ReceiveMail.aspx.cs" Inherits="Message_MailBox_ReceiveMail" Title="信箱 | 收件箱"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphOffice" runat="server">

    <script language="javascript" type="text/javascript">
	    function  ScanMessageDetail(Id)
		{
		    window.showModalDialog("ReceiveMailDetail.aspx?id="+Id,"","status=no;dialogWidth=600px;dialogHeight=600px;menu=no;resizeable=yes;scroll=yes;center=yes;edge=raise")
		}
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
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" Text="收件箱"></asp:Label>
        <hr /></div>
    <div style="text-align: left">
        <table cellspacing="0" cellpadding="0" width="98%" align="center" border="0">
            <tr>
                <td align="left">
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <input type="checkbox" id="btnSelectAll" runat="server" onclick="GetAllCheckBox(this)" />全选</td>
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
                                    <asp:CheckBox ID="chkSelect" runat="server" ></asp:CheckBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="发件人">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Message.FromUser.UserName") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="HeaderCenter" Width="15%" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderStyle HorizontalAlign="Center" Width="12%" CssClass="HeaderCenter"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:Image ID="imgMessage" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="主题">
                                <ItemTemplate>
                                    <asp:HyperLink ID="hlMessageContent" runat="server"><%# GetCut(Eval("Message.title"))%></asp:HyperLink>
                                    <%--<asp:Label ID="Label4" runat="server" Text='<%# GetCut(Eval("Message.title")) %>'></asp:Label>--%>
                                </ItemTemplate>
                                <HeaderStyle CssClass="HeaderCenter" Width="15%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="发送时间">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# GetDate(Eval("Message.Recordtime")) %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="HeaderCenter" Width="15%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="紧急程度">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("Message.MessageType.MessageTypeName") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="HeaderCenter" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td align="left" style="height: 23px">
                    &nbsp;&nbsp;&nbsp;&nbsp;<input id="btnDelete" 
                        class="buttonCss" type="submit" value="删除选定项" runat="server" style="height: 24px"
                        onserverclick="btnDelete_ServerClick">
                    &nbsp;&nbsp;&nbsp;&nbsp;<input id="btnReturn" style="width: 88px; height: 24px" class="buttonCss"
                        type="submit" value="返回" name="Submit1" runat="server" onserverclick="btnReturn_ServerClick"></td>
                <td colspan="4" style="height: 23px">
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

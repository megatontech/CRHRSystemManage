<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="MailBox.aspx.cs" Inherits="Message_MailBox_MailBox" Title="信箱管理" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphOffice" runat="Server">

    <script type="text/javascript" language="javascript" src="../../My97DatePicker/WdatePicker.js"
        charset="gb2312"></script>

    <div style="text-align: center">
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" Text="信箱管理"></asp:Label>
        <hr /></div>
    <div style="text-align: left">
        <table cellspacing="0" cellpadding="0" width="90%" align="center" border="0">
            <tr>
                <td width="90%">
                    <fieldset id="fid1" runat="server">
                        <legend>个人消息管理区：</legend>
                        <table bordercolor="#ffffff" cellspacing="0" cellpadding="0" width="100%" align="center"
                            border="1">
                            <tr bordercolor="#ffffff" height="5">
                                <td colspan="5" style="height: 5px">
                                </td>
                            </tr>
                            <tr bordercolor="gray">
                                <td bordercolor="#ffffff" width="20%" style="height: 28px">
                                </td>
                                <td class="HeaderCenter" valign="top" align="left" width="20%" style="height: 28px">
                                    本地文件夹</td>
                                <td class="HeaderCenter" valign="top" align="left" width="20%" style="height: 28px">
                                    文件个数</td>
                                <td class="HeaderCenter" valign="top" align="left" width="20%" style="height: 28px">
                                    未读邮件</td>
                                <td bordercolor="#ffffff" style="height: 28px">
                                </td>
                            </tr>
                            <tr valign="middle" bordercolor="gray" height="25">
                                <td align="center" bordercolor="#ffffff" rowspan="2" width="26%">
                                    <asp:Image ID="imgMessage" ImageUrl="~/images/message.gif" Width="46px" Height="56px"
                                        runat="server" />
                                </td>
                                <td align="center" width="20%" style="height: 25px">
                                    <asp:ImageButton ID="imgbtnReceiveFiles" runat="server" Width="65px" Height="16px"
                                        ImageUrl="~/images/ReceiveFile.jpg" OnClick="imgbtnReceiveFiles_Click" />
                                </td>
                                <td align="center" width="20%" style="height: 25px">
                                    <asp:Label ID="lblReceiveFiles" runat="server" ForeColor="Blue">0</asp:Label></td>
                                <td align="center" width="20%" style="height: 25px">
                                    <asp:Label ID="lblUnReadReceiveFiles" runat="server" ForeColor="Blue">0</asp:Label></td>
                            </tr>
                            <tr valign="middle" bordercolor="gray" height="25">
                                <td align="center" width="20%">
                                    <asp:ImageButton ID="imgbtnDraftFiles" runat="server" Width="65px" Height="16px"
                                        ImageUrl="~/images/DraftFile.jpg" OnClick="imgbtnDraftFiles_Click" /></td>
                                <td align="center" width="20%">
                                    <asp:Label ID="lblDraftFiles" runat="server" ForeColor="Blue">0</asp:Label></td>
                                <td align="center" width="20%">
                                    <asp:Label ID="lblUnReadDraftFiles" runat="server">0</asp:Label></td>
                            </tr>
                            <tr valign="middle" bordercolor="gray" height="25">
                                <td bordercolor="#ffffff" width="26%" style="height: 25px">
                                </td>
                                <td align="center" width="20%" style="height: 25px">
                                    <asp:ImageButton ID="imgbtnSendFile" runat="server" Width="65px" Height="16px" ImageUrl="~/images/SendFile.jpg"
                                        OnClick="imgbtnSendFile_Click" /></td>
                                <td align="center" width="20%" style="height: 25px">
                                    <asp:Label ID="lblSendFiles" runat="server" ForeColor="Blue">0</asp:Label></td>
                                <td valign="top" align="center" width="20%">
                                    <asp:Label ID="lblUnReadSendFiles" runat="server">0</asp:Label></td>
                            </tr>
                            <tr valign="middle" bordercolor="gray" height="25">
                                <td bordercolor="#ffffff" width="26%" style="height: 25px">
                                </td>
                                <td align="center" width="20%" style="height: 25px">
                                    <asp:ImageButton ID="imgbtnDeletedFile" runat="server" Width="65px" Height="16px"
                                        ImageUrl="~/images/DeletedFile.jpg" OnClick="imgbtnDeletedFile_Click" /></td>
                                <td align="center" width="20%" style="height: 25px">
                                    <asp:Label ID="lblDeletedFiles" runat="server" ForeColor="Blue">0</asp:Label></td>
                                <td align="center" width="20%">
                                    <asp:Label ID="lblUnReadDeletedFiles" runat="server">0</asp:Label></td>
                            </tr>
                        </table>
                    </fieldset>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

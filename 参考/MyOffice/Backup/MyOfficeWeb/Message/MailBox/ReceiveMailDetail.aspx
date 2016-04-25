<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReceiveMailDetail.aspx.cs"
    Inherits="Message_MailBox_ReceiveMailDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>消息详情</title>
    <link href="../../css/style.css" type="text/css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table id="Table2" cellspacing="1" cellpadding="2" border="0" bgcolor="#e6e6e6" width="98%"
                align="left">
                <tr>
                    <td bgcolor="white" align="left" style="width: 90px">
                        消息主题：
                    </td>
                    <td bgcolor="white" width="80%">
                        <asp:Label ID="lblTitle" runat="server" CssClass="title"></asp:Label></td>
                </tr>
                <tr>
                    <td bgcolor="white" valign="top" align="left" style="width: 90px">
                        重要程度：</td>
                    <td bgcolor="white">
                        <asp:Label ID="lblType" runat="server" ForeColor="Red"></asp:Label></td>
                </tr>
                <tr>
                    <td bgcolor="white" valign="top" align="left" style="width: 90px">
                        消息内容：</td>
                    <td bgcolor="white">
                        <textarea id="txtContent" runat="server" class="textarea2" name="Content" style="width: 464px;
                            height: 152px" rows="9" cols="55">
						</textarea></td>
                </tr>
                <tr>
                    <td bgcolor="white" valign="top" align="left" style="width: 90px">
                        发件人：</td>
                    <td bgcolor="white">
                        <asp:Label ID="lblFromUser" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td bgcolor="white" valign="top" align="left" style="width: 90px">
                        发送时间：</td>
                    <td bgcolor="white">
                        <asp:Label ID="lblSendTime" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td bgcolor="white" valign="top" style="width: 90px">
                    </td>
                    <td bgcolor="white" align="center">
                        <input id="btnClose" style="width: 75px; height: 22px" type="button" class="buttonCss"
                            value="关闭" onclick="javascript:window.returnValue='OK';self.close();">&nbsp;
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

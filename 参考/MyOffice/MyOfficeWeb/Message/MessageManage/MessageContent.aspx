<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MessageContent.aspx.cs" Inherits="Message_MessageManage_MessageContent" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>显示消息内容</title>
     <link href="../../css/style.css" type="text/css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table width="60%" height="60%" cellpadding="0" cellspacing="0" border="0">
				<tr>
					<td width="90%" valign="top" align="left">
						<FIELDSET style="BORDER-LEFT-COLOR: transparent; BORDER-BOTTOM-COLOR: transparent; WIDTH: 512px; CLIP: rect(0px 0px 0px 0px); BORDER-TOP-COLOR: transparent; HEIGHT: 396px; BACKGROUND-COLOR: #ffffee; BORDER-RIGHT-COLOR: transparent">
							<legend align="center">
								该消息基本内容如下：</legend>发送对象：<asp:Label ID="lblToUserName" runat="server" Text=""></asp:Label><br />
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; 标题：<asp:Label ID="lblTitle" runat="server"
                                Text=""></asp:Label><br>
							<TEXTAREA id="txtMessageContent" class="inputCss" runat="server" style="WIDTH:504px; HEIGHT:360px" rows="16"
								cols="60">
							</TEXTAREA>
						</FIELDSET>
					</td>
				</tr>
				<tr>
					<td valign="top" align="center"><br>
						<INPUT id="btnClose" style="WIDTH: 75px; HEIGHT: 22px" type="button" class="buttonCss" value="关闭" onclick="self.close();">&nbsp;
					</td>
				</tr>
			</table>
    </div>
    </form>
</body>
</html>

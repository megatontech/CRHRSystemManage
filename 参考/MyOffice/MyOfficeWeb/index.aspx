<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>自动办公系统 | 登陆</title>
    <link media="all" href="Css/Style.css" type="text/css" rel="stylesheet" />
</head>
<body style="background-color: #6699cc;">
    <form id="form1" runat="server">
        <div style="background-image: url(images/login.jpg); width: 512px; height: 380px;
            margin-top: 100px; margin-left: 250px;">
            <asp:ImageButton ID="IBLogin" runat="server" ImageUrl="~/images/denglu.jpg" Style="left: 552px;
                position: absolute; top: 408px" TabIndex="3" Height="26px" OnClick="IBLogin_Click" />
            <asp:TextBox ID="TxtPassword" runat="server" Style="left: 363px; position: absolute;
                top: 434px" Width="126px" TabIndex="2" CssClass="loinBox" TextMode="Password"></asp:TextBox>
            <asp:TextBox ID="TxtUserId" runat="server" Style="left: 364px; position: absolute;
                top: 375px" Width="127px" TabIndex="1" CssClass="loinBox"></asp:TextBox>
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="Red"
                Height="40px" Text="用户名：codepub；密码：codepub" Width="510px"></asp:Label></div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManageFolder.aspx.cs" Inherits="File_ManageFolder" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="../Css/Style.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="width: 650px">
            <tr>
                <td colspan="2" style="height: 45px">
                    <img src="../images/file/fmfolder.gif" alt="" /></td>
            </tr>
            <tr>
                <td colspan="2" style="height: 45px">
                    <img src="../images/file/folderbig.gif" />
                    <asp:TextBox ID="txtFileName" runat="server" BorderColor="Turquoise" Height="25px" Width="480px"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2" style="height: 77px">
                    位置：<asp:Label ID="lblAddress" runat="server"></asp:Label>
                    
                </td>
            </tr>
            <tr>
                <td colspan="2" style="height: 130px">
                    备注：<asp:TextBox ID="txtRemark" runat="server" Height="70px" TextMode="MultiLine"
                        Width="480px" class="textArea"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 300px; height: 58px;">
                    创建时间：<asp:Label ID="lblCreateDate" runat="server"></asp:Label></td>
                <td style="width: 350px; height: 58px;" align="center">
                    所有者：<asp:Label ID="lblFileOwner" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td style="height: 85px;" align="center" colspan="2">
                <hr style="border-right: #9966ff thin solid; border-top: #9966ff thin solid; border-left: #9966ff thin solid; border-bottom: #9966ff thin solid" />
                    <asp:ImageButton ID="ibtnSave" runat="server" Height="20px" ImageUrl="~/images/file/saveexi.gif" OnClick="ibtnSave_Click" />
                    &nbsp; &nbsp; &nbsp;
                    <asp:ImageButton ID="ibtnExit" runat="server" Height="20px" ImageUrl="~/images/file/exit.gif" OnClick="ibtnExit_Click" /></td>
            </tr>
        </table>
    <a id='ss' href='FileManage.aspx' target='_top'></a>
    </div>
    </form>
</body>
</html>

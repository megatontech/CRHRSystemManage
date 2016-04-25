<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManageFile.aspx.cs" Inherits="File_ManageFile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Css/Style.css" type="text/css" rel="stylesheet" />

    <script type="text/javascript">
        function setInfo(fileUpload)
        {
            var mime=fileUpload.value;
            mime=mime.substr(mime.lastIndexOf("\\")+1);
            var file=new Array();
            file=mime.split(".");
            document.getElementById("lblFileName").innerText=file[0];
            
            var rads;
            if(file[1]!=null)
                rads=document.getElementById(file[1]).childNodes;
            else
                rads=document.getElementById("noname").childNodes;
            rads[0].checked=true;
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width: 635px">
                <tr>
                    <td style="width: 300px; height: 40px">
                        <img src="../images/file/filepro.gif" /></td>
                    <td style="width: 350px; height: 40px">
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 40px">
                        <hr style="border-right: #9966ff thin solid; border-top: #9966ff thin solid; border-left: #9966ff thin solid;
                            border-bottom: #9966ff thin solid; font-weight: bold;" />
                        <strong style="font-size:14px;">文件信息： </strong>
                        <br />
                        上传的文件：<asp:FileUpload ID="fupFile" runat="server" CssClass="buttonCss" Width="460px"
                            onchange="setInfo(this)" /></td>
                </tr>
                <tr>
                    <td style="height: 100px;" colspan="2">
                        备&nbsp;&nbsp;&nbsp;&nbsp;注：<asp:TextBox ID="txtRemark" runat="server" class="textArea"
                            Height="70px" TextMode="MultiLine" Width="480px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 40px">
                        文件名：<asp:Label ID="lblFileName" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="2">
                        位&nbsp;&nbsp;&nbsp;&nbsp;置：<asp:Label ID="lblAddress" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 300px">
                        创建时间：<asp:Label ID="lblCreateDate" runat="server"></asp:Label></td>
                    <td style="width: 350px" align="center">
                        所有者：<asp:Label ID="lblFileOwner" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 62px" valign="top">
                        <div style="float: left;">
                            文件图标>>&nbsp;&nbsp;&nbsp;</div>
                        <asp:RadioButtonList ID="radFileType" runat="server" RepeatDirection="Horizontal"
                            RepeatColumns="3" Width="445px">
                        </asp:RadioButtonList></td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 83px">
                        <hr style="border-right: #9966ff thin solid; border-top: #9966ff thin solid; border-left: #9966ff thin solid;
                            border-bottom: #9966ff thin solid" />
                        <strong style="font-size: 14px;">附件信息：</strong><br />
                        上传的附件：
                        <asp:FileUpload ID="fileUpload" runat="server" CssClass="buttonCss" Width="454px" /><br />
                        <br />
                        <asp:GridView ID="gvAccessoryFile" runat="server" AutoGenerateColumns="False" Width="555px"
                            DataKeyNames="Id" OnRowDeleting="gvAccessoryFile_RowDeleting" OnRowDataBound="gvAccessoryFile_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="文件名">
                                    <ItemStyle Width="150px" />
                                    <ItemTemplate>
                                        <a href='<%# Eval("AccessoryPath") %>'>
                                            <%# Eval("AccessoryName") %>
                                        </a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="大小（ＫＢ）">
                                    <ItemStyle Width="100px" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblAccessorySize" runat="server" Text='<%# Eval("AccessorySize") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="类型">
                                    <ItemStyle Width="100px" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblAccessoryType" runat="server" Text='<%# Eval("AccessoryType.FileTypeName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="创建日期">
                                    <ItemStyle Width="150px" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblCreateDate" runat="server" Text='<%# Eval("CreateDate","{0:D}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle Width="50px" />
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ibtnDelete" runat="server" ImageUrl="~/images/file/delete.gif"
                                            CommandName="Delete" OnClientClick='return confirm("您确定删除吗?")' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <RowStyle Wrap="False" HorizontalAlign="Center" BackColor="#CCFFFF" CssClass="grayBorder" />
                            <HeaderStyle BackColor="#66CCFF" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <hr style="border-right: #9966ff thin solid; border-top: #9966ff thin solid; border-left: #9966ff thin solid;
                            border-bottom: #9966ff thin solid" />
                        <asp:ImageButton ID="ibtnSave" runat="server" Height="20px" ImageUrl="~/images/file/saveexi.gif"
                            OnClick="ibtnSave_Click" />
                        &nbsp; &nbsp; &nbsp;
                        <asp:ImageButton ID="ibtnExit" runat="server" Height="20px" ImageUrl="~/images/file/exit.gif"
                            OnClick="ibtnExit_Click" /></td>
                </tr>
            </table>
            <a id='ss' href='FileManage.aspx' target='_top'></a>
        </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FileMain.aspx.cs" Inherits="File_FileMain" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Css/Style.css" type="text/css" rel="stylesheet" />
    
    <script type="text/javascript">
        //关闭和显示文件夹
        function closeFile()
        {
            var w1=parent.document.getElementById("leftFrame").style.width;
            if(w1!="0px")
            {
                parent.document.getElementById("leftFrame").style.width="0px";
                parent.document.getElementById("mainFrame").style.width="840px";
                //document.getElementById("folder").src="../images/file/bseach.gif";
            }
            else
            {
                parent.document.getElementById("leftFrame").style.width="180px";
                parent.document.getElementById("mainFrame").style.width="660px";
                //document.getElementById("folder").src="../images/file/fmfolderShow1.gif";
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div id="divTop" style="height: 33px;">
                    <button id="back" onclick="javascript:history.go(-1)" style="background-color: Transparent;
                        border: 0;" type="button">
                        <img alt="后退" src="../images/file/fmback.gif" border="0" onmouseover="this.src='../images/file/fmback1.gif';"
                            onmouseout="this.src='../images/file/fmback.gif';" /></button>
                    <button id="next" onclick="javascript:history.go(1)" style="background-color: Transparent;
                        border: 0;" type="button"><img alt="前进" src="../images/file/fmforword.gif" border="0" onmouseover="this.src='../images/file/fmforword1.gif';"
                            onmouseout="this.src='../images/file/fmforword.gif';" /></button>
                    <asp:ImageButton ID="btnUp" runat="server" ImageUrl="~/images/file/fmup.gif" AlternateText="返回上一级"
                        onmouseover="this.src='../images/file/fmup1.gif';" onmouseout="this.src='../images/file/fmup.gif';"
                        OnClick="btnUp_Click" />
                    <a href="FileSearch.aspx" target="_top">
                        <img alt="搜索" src="../images/file/fmseach.gif" onmouseover="this.src='../images/file/fmseach1.gif';"
                            onmouseout="this.src='../images/file/fmseach.gif';" border="0" /></a>
                    <img id="folder" alt="" src="../images/file/fmfolderShow1.gif" onclick="closeFile()" />
                    <asp:ImageButton ID="btnNewFolder" runat="server" ImageUrl="~/images/file/fmnewfolder.gif"
                        AlternateText="新增文件夹" OnClick="btnNewFolder_Click" onmouseover="this.src='../images/file/fmnewfolder1.gif';"
                        onmouseout="this.src='../images/file/fmnewfolder.gif';" />
                    <asp:ImageButton ID="btnNewFile" runat="server" ImageUrl="~/images/file/fmnewfile.gif"
                        AlternateText="新增文件" OnClick="btnNewFile_Click" onmouseover="this.src='../images/file/fmnewfile1.gif';"
                        onmouseout="this.src='../images/file/fmnewfile.gif';" /></div>
                <div id="divMiddle" style="height: 33px;">
                    <table style="width: 606px;">
                        <tr>
                            <td style="width: 500px; height: 22px;">
                                地址：<asp:TextBox ID="txtAddress" runat="server" Width="400px" Height="25px"></asp:TextBox>
                                <img alt="文件夹地址" src="../images/file/img-folder.gif" /></td>
                            <td align="right" style="width: 229px; height: 22px;">
                                <asp:ImageButton ID="ibtnGoTo" runat="server" ImageUrl="~/images/file/fmgoto.gif"
                                    OnClick="ibtnGoTo_Click" /></td>
                        </tr>
                    </table>
                </div>
                <asp:GridView ID="gvFiles" runat="server" Width="650px" AutoGenerateColumns="False"
                    DataKeyNames="Id" OnRowDataBound="gvFiles_RowDataBound" OnRowCommand="gvFiles_RowCommand"
                    OnDataBound="gvFiles_DataBound">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Image ID="imgFileType" runat="server" ImageUrl='<%# Eval("FileType.FileTypeImage") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="名称">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtnFileName" runat="server" Text='<%# Eval("FileName") %>' OnClick="lbtnFileName_Click"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="类型">
                            <ItemTemplate>
                                <asp:Label ID="lblFileType" runat="server" Text='<%# Eval("FileType.FileTypeName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="备注">
                            <ItemTemplate>
                                <asp:Label ID="lblRemark" runat="server" Text='<%# Eval("Remark") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="所有者">
                            <ItemTemplate>
                                <asp:Label ID="lblFileOwnerName" runat="server" Text='<%# Eval("FileOwner.UserName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="创建日期">
                            <ItemTemplate>
                                <asp:Label ID="lblCreateDate" runat="server" Text='<%# Eval("CreateDate","{0:D}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="ibtnAttribute" runat="server" ImageUrl="~/images/file/detail.gif"
                                    AlternateText="查看属性" CommandName="Attribute" CommandArgument='<%# Eval("Id") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="ibtnMove" runat="server" ImageUrl="~/images/file/fmmove.gif"
                                    AlternateText="移动" CommandName="Move" OnClientClick="javascript:document.getElementById('divFile').style.visibility='visible';" CommandArgument='<%# Eval("Id") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="ibtnDelete" runat="server" ImageUrl="~/images/file/delete.gif"
                                    OnClientClick='return confirm("您确定删除吗？");' AlternateText="点击删除" CommandName="Dele"
                                    CommandArgument='<%# Eval("Id") %>' target="_top" PostBackUrl="~/File/FileManage.aspx" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle Wrap="False" HorizontalAlign="Center" BackColor="#CCFFFF" CssClass="grayBorder" />
                    <HeaderStyle BackColor="#66CCFF" />
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div id="divFile" style="z-index: 100; left: 215px; width: 224px; position: absolute;
            top: 52px; height: 379px; background-color: #66CCFF; visibility: hidden;">
            请选择您要移动的位置：
            <div style="margin-left: 180px;">
                <a href="#" onclick="javascript:document.getElementById('divFile').style.visibility='hidden';">
                    <关闭>
                </a>
            </div>
            <asp:TreeView ID="tvFile" runat="server" ShowLines="True" OnSelectedNodeChanged="tvFile_SelectedNodeChanged">
            </asp:TreeView>
        </div>
    </form>
    <a id='ss' href='FileManage.aspx' target='_top'></a>
</body>
</html>

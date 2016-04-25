<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="FileManage.aspx.cs" Inherits="File_FileManage" Title="自动办公系统 | 文件管理" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphOffice" runat="Server">
  <div style="width: 100%; text-align: center"> <div style="width: 100%; text-align: center">
            <br />
            
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" Text=" 文件管理"></asp:Label>
            <hr />
        </div>
    <iframe id="leftFrame" name="leftFrame" scrolling="yes" src="FileTree.aspx"
        style="width: 180px; height: 510px; border:0;" frameborder="0"></iframe>
    <iframe id="mainFrame" name="mainFrame" src="FileMain.aspx" style="width: 660px;
        height: 510px"></iframe>
</asp:Content>

<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="AddMyNote.aspx.cs" Inherits="ScheduleManage_AddMyNote" Title="个人便签设置" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphOffice" runat="Server">
    <div id="divTop" align="center" style="width: 843px; height: 163px">
        <br />
        <br />
        <table style="border-left-color: #3399ff; border-bottom-color: #3399ff; border-top-style: dotted;
            border-top-color: #3399ff; border-right-style: dotted; border-left-style: dotted;
            height: 416px; border-right-color: #3399ff; border-bottom-style: dotted; width: 525px;">
            <tr>
                <td rowspan="2" style="width: 489px">
                    <br />
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Medium" Text="个人便签设置"></asp:Label>
                </td>
            </tr>
            <tr>
            </tr>
            <tr>
                <td rowspan="1" style="width: 489px">
                    <hr style="width: 512px" />
                </td>
            </tr>
            <tr>
                <td style="width: 489px">
                    便签标题：<asp:TextBox CssClass="inputCss" ID="txtNoteTitle" runat="server" Width="307px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNoteTitle"
                        ErrorMessage="*">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 489px">
                    便签内容：<asp:TextBox CssClass="inputCss" ID="txtNoteContent" runat="server" Height="197px"
                        TextMode="MultiLine" Width="310px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNoteContent"
                        ErrorMessage="*">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 489px">
                    创建人：
                    <asp:Label ID="lblCreateUser" runat="server"></asp:Label>&nbsp;&nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; 创建时间：
                    <asp:Label ID="lblDataTime" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 489px">
                </td>
            </tr>
            <tr>
                <td style="width: 489px; height: 38px;">
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                    <asp:Button ID="btnAdd" runat="server" CssClass="buttonCss" BackColor="#C0E5FF" Height="26px"
                        Text="保存" Width="67px" OnClick="btnAdd_Click" />
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                    <asp:Button ID="btnDelete" runat="server" CssClass="buttonCss" BackColor="#C0E5FF"
                        Height="27px" Text="删除当前便签" Enabled="False" OnClick="btnDelete_Click" OnClientClick="return confirm('确定要删除吗？')" /><br />
                    <br />
                    <div style="width: 504px; height: 2px; color: #cccccc;" align="right">
                        <a href="PersonNote.aspx">返回上页&gt;&gt;</a></div>
                </td>
            </tr>
        </table>
        <br />
        <br />
    </div>
</asp:Content>

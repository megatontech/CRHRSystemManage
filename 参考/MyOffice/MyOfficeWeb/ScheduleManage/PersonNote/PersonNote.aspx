<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="PersonNote.aspx.cs" Inherits="ScheduleManage_MyNote" Title="我的便签" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphOffice" runat="Server">

    <div id="divTop" align="center" style="width: 833px; height: 100px">
        
        <br />
        <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Medium" Text="我的便签"></asp:Label>
        <hr />
        <div id="divRight" align="right" style="width: 684px; height: 25px">
        <asp:Label ID="Label2" runat="server" Text="新增便签"></asp:Label>
        <a href="AddMyNote.aspx"><img alt="添加便签" border="0" src="../../images/write.gif" id="IMG1" onclick="return IMG1_onclick()"/></a></div>
        <div id="DIV1" style="width: 682px; height: 26px">
        <asp:DataList ID="dtlMyNote"   runat="server" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Both" Width="690px" Height="100px" RepeatColumns="3" DataKeyField="Id">
            <ItemTemplate>
               <table>
               <tr>
               <td>
                   &nbsp;<a href="AddMyNote.aspx"><img alt="新增便签.." border="0" src="../../images/add_Schedule.gif" style="height: 18px" /></a>
               <asp:LinkButton ID="lnkbtntitle" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="lnkbtntitle_Command"><%# GetCut(Eval("NoteTitle")) %></asp:LinkButton>
               </td>
               </tr>
               </table>
            </ItemTemplate>       
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <SelectedItemStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            <AlternatingItemStyle BackColor="#E7E7FF" HorizontalAlign="Left" />
            <ItemStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Left" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
        </asp:DataList>
            <asp:Label ID="lblMessage" runat="server" Height="22px" Style="font-weight: bold; font-size: large;
                color: #ff0066; font-style: italic" Text="您还没有添加便签.." Visible="False" Width="288px"></asp:Label></div>
    </div>
</asp:Content>

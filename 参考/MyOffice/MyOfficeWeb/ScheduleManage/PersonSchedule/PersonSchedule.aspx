<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="PersonSchedule.aspx.cs" Inherits="ScheduleManage_PersonSchedule_PersonSchedule"
    Title="个人日程管理" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphOffice" runat="Server">
    <div style="width: 841px; height: 100px" align="center">
        <div style="width: 100%; text-align: center">
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Medium" Text="个人日程管理"></asp:Label>
            <hr />
            <br />
        </div>
        <asp:Calendar ID="calSchedule" runat="server" Width="98%" Height="115%" BackColor="White"
            BorderColor="#999999" ShowGridLines="True" PrevMonthText="&amp;nbsp;&amp;nbsp;&amp;nbsp;&amp;nbsp;<img src=../../images/left_arrow.gif alt=上一月 border=0 />上一月"
            NextMonthText="下一月<img src=../../images/right_arrow.gif alt=下一月 border=0 />&amp;nbsp;&amp;nbsp;&amp;nbsp;&amp;nbsp;"
            DayNameFormat="Full" OnDayRender="calSchedule_DayRender">
            <TodayDayStyle BorderWidth="2px" BorderStyle="Solid" BorderColor="CornflowerBlue"
                BackColor="#ffff99"></TodayDayStyle>
            <DayStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Top"></DayStyle>
            <NextPrevStyle ForeColor="#223399" CssClass="td"></NextPrevStyle>
            <DayHeaderStyle Font-Size="13px" Height="10px" BackColor="MediumTurquoise"></DayHeaderStyle>
            <TitleStyle BackColor="#66CCFF" CssClass="headcenter" Height="10px"></TitleStyle>
            <WeekendDayStyle ForeColor="Red" HorizontalAlign="Center"></WeekendDayStyle>
            <SelectedDayStyle HorizontalAlign="Center" />
        </asp:Calendar>
    </div>
</asp:Content>

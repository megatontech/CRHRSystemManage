<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="SignStatistic.aspx.cs" Inherits="ManualSign_SignStatistic" Title="自动办公系统 | 员工考勤统计" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphOffice" runat="Server">

    <script type="text/javascript" language="javascript" src="../My97DatePicker/WdatePicker.js"
        charset="gb2312"></script>

    <script type="text/javascript">
  //今天
  function showToDay()
 {
    var Nowdate=new Date();
    M=Number(Nowdate.getMonth())+1//得到月份
    var date= Nowdate.getYear()+"-"+M+"-"+Nowdate.getDate();
    document.getElementById("<%= txtStartDate.ClientID%>").value=date;
     document.getElementById("<%= txtEndDate.ClientID%>").value=date;

 }
   //本周
  function showWeekDay()
 {
     var Nowdate=new Date();
     var WeekFirstDay=new Date(Nowdate-(Nowdate.getDay()-1)*86400000); //本周第一天 
     var WeekLastDay=new Date((WeekFirstDay/1000+6*86400)*1000);//本周最后一天
      M=Number(WeekFirstDay.getMonth())+1//得到月份   
      N=Number(WeekLastDay.getMonth())+1//得到月份     
     document.getElementById("<%= txtStartDate.ClientID%>").value=WeekFirstDay.getYear()+"-"+M+"-"+WeekFirstDay.getDate();
     document.getElementById("<%= txtEndDate.ClientID%>").value=WeekLastDay.getYear()+"-"+N+"-"+WeekLastDay.getDate();
    
 }
  //本月
    function showMonthDay()
 {  
    var Nowdate=new Date();
    var MonthFirstDay=new Date(Nowdate.getYear(),Nowdate.getMonth(),1);//本月第一天
    //本月最后一天
    var MonthNextFirstDay=new Date(Nowdate.getYear(),Nowdate.getMonth()+1,1);
    var MonthLastDay=new Date(MonthNextFirstDay-86400000);
     M=Number(MonthFirstDay.getMonth())+1//得到月份  
     N=Number(MonthLastDay.getMonth())+1//得到月份     
    document.getElementById("<%= txtStartDate.ClientID%>").value=MonthFirstDay.getYear()+"-"+M+"-"+MonthFirstDay.getDate();
    document.getElementById("<%= txtEndDate.ClientID%>").value=MonthLastDay.getYear()+"-"+N+"-"+MonthLastDay.getDate();    
    
}
  //本月
    function showMonthDay()
 {  
    var Nowdate=new Date();
    var MonthFirstDay=new Date(Nowdate.getYear(),Nowdate.getMonth(),1);//本月第一天
    //本月最后一天
    var MonthNextFirstDay=new Date(Nowdate.getYear(),Nowdate.getMonth()+1,1);
    var MonthLastDay=new Date(MonthNextFirstDay-86400000);
     M=Number(MonthFirstDay.getMonth())+1//得到月份  
    document.getElementById("<%= txtStartDate.ClientID%>").value=MonthFirstDay.getYear()+"-"+M+"-"+MonthFirstDay.getDate();
    document.getElementById("<%= txtEndDate.ClientID%>").value=MonthLastDay.getYear()+"-"+M+"-"+MonthLastDay.getDate();    
    
}
    </script>

    <div style="text-align: center">
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" Text="员 工 考 勤 统 计"></asp:Label>
        <hr />
        <table cellspacing="0" cellpadding="0" width="95%" datapagesize="56">
            <tr>
                <td colspan="2">
                 <asp:UpdatePanel id="upManualSignStatistic" runat="server" UpdateMode="conditional">
                        <contenttemplate>
                    <table>
                        <tbody>
                            <tr style="background-color: #6dc7fc">
                                <td style="width: 91px; height: 39px" align="center">
                                    输入时间段：</td>
                                <td style="height: 39px">
                                    &nbsp;&nbsp;开始时间:
                                    <asp:TextBox ID="txtStartDate" onfocus="new WdatePicker(this,'%Y-%M-%D',true,'default')"
                                        runat="server" Width="141px" CssClass="Wdate"></asp:TextBox>&nbsp;-----&nbsp;
                                    结束时间:
                                    <asp:TextBox ID="txtEndDate" onfocus="new WdatePicker(this,'%Y-%M-%D',true,'default')"
                                        runat="server" Width="149px" CssClass="Wdate"></asp:TextBox>&nbsp;
                                    <asp:CompareValidator ID="cvTime" runat="server" Type="Date" Display="Dynamic" ControlToValidate="txtEndDate"
                                        Operator="GreaterThanEqual" ErrorMessage="结束时间不应小于开始时间" ControlToCompare="txtStartDate">*</asp:CompareValidator>&nbsp;&nbsp;&nbsp;
                                    <asp:RadioButton ID="rdoThisDay" onclick="showToDay()" runat="server" Text="本日" GroupName="quickdate">
                                    </asp:RadioButton>
                                    <asp:RadioButton ID="rdoThisWeek" onclick="showWeekDay()" runat="server" Text="本周"
                                        GroupName="quickdate"></asp:RadioButton>
                                    <asp:RadioButton ID="rdoThisMonth" onclick="showMonthDay()" runat="server" Text="本月"
                                        GroupName="quickdate"></asp:RadioButton></td>
                            </tr>
                            <tr>
                                <td style="height: 1px" valign="middle" align="center" colspan="2">
                                    <hr width="95%" color="gray" size="1" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;机构:
                                    <asp:DropDownList ID="ddlBranchs" runat="server" Width="160px" CssClass="ddlCss"
                                        OnSelectedIndexChanged="ddlBranchs_SelectedIndexChanged" AutoPostBack="True">
                                    </asp:DropDownList>&nbsp; 部门:
                                    <asp:DropDownList ID="ddlDeparts" runat="server" Width="184px" CssClass="ddlCss">
                                    </asp:DropDownList>&nbsp; &nbsp;<asp:Button ID="btnStatistic" OnClick="btnStatistic_Click"
                                        runat="server" Height="23px" Width="110px" Text="统　计" CssClass="buttonCss"></asp:Button>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnLoad" runat="server" Height="23px"
                                        Width="110px" Enabled="False" Text="导入Excel打印" CssClass="buttonCss" OnClick="btnLoad_Click">
                                    </asp:Button>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td width="100%" colspan="2">
                                    <table id="print" width="100%" runat="server">
                                        <tbody>
                                            <tr>
                                                <td style="height: 100%" valign="top" align="center" width="90%" colspan="2">
                                                    <asp:GridView ID="gvSignInfoStatistic" runat="server" Width="96%" AutoGenerateColumns="False"
                                                        BorderColor="#66CCFF" BorderWidth="1px" CellPadding="4">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="姓名">
                                                                <ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
                                                                <HeaderStyle Wrap="False" HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("UserName")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="出勤率(%)">
                                                                <ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
                                                                <HeaderStyle Wrap="False" HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemTemplate>
                                                                    <asp:Label runat="server" Text='<%# GetAttendances(Eval("Id"))%>' ID="Label2"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="迟到次数">
                                                                <ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
                                                                <HeaderStyle Wrap="False" HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemTemplate>
                                                                    <asp:Label runat="server" Text='<%# GetArriveLates(Eval("Id")) %>' ID="Label3"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="早退次数">
                                                                <ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
                                                                <HeaderStyle Wrap="False" HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemTemplate>
                                                                    <asp:Label runat="server" Text='<%# GetLeaveEarlys(Eval("Id"))%>' ID="Label4"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="旷工次数">
                                                                <ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
                                                                <HeaderStyle Wrap="False" HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemTemplate>
                                                                    <asp:Label runat="server" Text='<%# GetAbsences(Eval("Id")) %>' ID="Label5"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="所属部门">
                                                                <ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
                                                                <HeaderStyle Wrap="False" HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemTemplate>
                                                                    <asp:Label runat="server" Text='<%#  Eval("Depart.DepartName") %>' ID="Label6"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="所属机构">
                                                                <ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
                                                                <HeaderStyle Wrap="False" HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemTemplate>
                                                                    <asp:Label runat="server" Text='<%# Eval("Depart.Branch.BranchName") %>' ID="Label7"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 100%" valign="top" align="right" width="90%" colspan="2">
                                                    <webdiyer:AspNetPager ID="anpPager" runat="server" CssClass="" PageSize="5" OnPageChanged="anpPager_PageChanged"
                                                        ShowBoxThreshold="10" FirstPageText="第一页" LastPageText="尾页" NextPageText="下一页"
                                                        PrevPageText="上一页" CustomInfoClass="" SubmitButtonClass="buttonCss">
                                                    </webdiyer:AspNetPager>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 23px" align="center" colspan="2">
                                                    <div id="divReportUser" runat="server" visible="false">
                                                        &nbsp;制表人:&nbsp;&nbsp;<asp:Label Style="position: static" ID="lblReportUser" runat="server"
                                                            Width="88px" Font-Bold="True">
                                                        </asp:Label>
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                        &nbsp;&nbsp;&nbsp;&nbsp;上报日期:
                                                        <asp:Label ID="lblReportTime" runat="server" Width="106px" Font-Bold="True"></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    </contenttemplate> </asp:UpdatePanel>
                </td>
            </tr>
        </table>
</asp:Content>

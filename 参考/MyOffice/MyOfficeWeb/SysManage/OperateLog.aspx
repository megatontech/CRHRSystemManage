<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="OperateLog.aspx.cs" Inherits="SysManage_OperateLog" Title="自动办公系统 | 操作日志" %>

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
    </script>

    <div style="width: 100%; height: 100%; text-align: center">
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" Text="操作日志"></asp:Label>
        <hr />  <asp:UpdatePanel id="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <contenttemplate>
        <table width="90%">
            <tbody>
                <tr>
                    <td style="text-align: left">
                    </td>
                </tr>
                <tr>
                    <td style="background-color: #6dc7fc; text-align: left">
                        <table width="100%">
                            <tbody>
                                <tr>
                                    <td style="width: 100px">
                                    </td>
                                    <td>
                                        开始时间:<asp:TextBox ID="txtStartDate" onfocus="new WdatePicker(this,'%Y-%M-%D',true,'default')"
                                            runat="server" CssClass="Wdate"></asp:TextBox></td>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" Text="--"></asp:Label>
                                    </td>
                                    <td>
                                        &nbsp;结束时间:<asp:TextBox ID="txtEndDate" onfocus="new WdatePicker(this,'%Y-%M-%D',true,'default')"
                                            runat="server" CssClass="Wdate"></asp:TextBox>
                                        <asp:CompareValidator ID="cvTime" runat="server" Display="Dynamic" ControlToValidate="txtEndDate"
                                            Operator="GreaterThanEqual" ErrorMessage="结束时间不应小于开始时间" ControlToCompare="txtStartDate"
                                            Type="Date">*</asp:CompareValidator>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:RadioButton ID="radBtnDay" onclick="showToDay()" runat="server" Text="本日" GroupName="time">
                                        </asp:RadioButton>
                                        <asp:RadioButton ID="radBtnWeek" onclick="showWeekDay()" runat="server" Text="本周"
                                            GroupName="time"></asp:RadioButton>
                                        <asp:RadioButton ID="radBtnMonth" onclick="showMonthDay()" runat="server" Text="本月"
                                            GroupName="time"></asp:RadioButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right">
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="None"
                                            ControlToValidate="txtStartDate" ErrorMessage="请输入时间"></asp:RequiredFieldValidator></td>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="None"
                                            ControlToValidate="txtEndDate" ErrorMessage="请输入时间"></asp:RequiredFieldValidator></td>
                                    <td style="text-align: right">
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">
                        <asp:ImageButton ID="ImageButton1" OnClick="ImageButton1_Click" runat="server" ImageUrl="~/images/search.gif">
                        </asp:ImageButton></td>
                </tr>
                <tr>
                    <td style="text-align: left">
                        <asp:Button ID="BtnDelete" OnClick="BtnDelete_Click" runat="server" BackColor="#EFF3FB"
                            Enabled="False" Text="删除选定项" CssClass="buttonCss"></asp:Button></td>
                </tr>
            </tbody>
        </table>
        <table style="width: 90%">
            <tbody>
                <tr>
                    <td style="text-align: right">
                        <asp:GridView ID="GVLoginLogAll" runat="server" Width="100%" CssClass="grayBorder"
                            DataKeyNames="Id" AutoGenerateColumns="False" OnRowDataBound="GVLoginLogAll_RowDataBound"
                            BorderColor="#00A3FF" PageSize="12">
                            <Columns>
                                <asp:TemplateField HeaderText="全选">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chkAll" runat="server" Text="全选" onclick="GetAllCheckBox(this),GetCheckBox()" />
                                    </HeaderTemplate>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkOne" runat="server" onclick="GetCheckBox()" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="操作用户">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemTemplate>
                                        <%# Eval("User.UserName") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="OperateName" HeaderText="事件">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="OperateDesc" HeaderText="操作描述">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="OperateTime" HeaderText="操作时间">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </asp:BoundField>
                            </Columns>
                            <PagerStyle HorizontalAlign="Center"></PagerStyle>
                            <HeaderStyle BackColor="#EFF3FB"></HeaderStyle>
                        </asp:GridView>
                        <webdiyer:AspNetPager ID="anpPager" runat="server" CssClass="" PageSize="5" OnPageChanged="anpPager_PageChanged"
                            SubmitButtonClass="buttonCss" CustomInfoClass="" PrevPageText="上一页" NextPageText="下一页"
                            LastPageText="尾页" FirstPageText="第一页" ShowBoxThreshold="10">
                        </webdiyer:AspNetPager>
                    </td>
                </tr>
            </tbody>
        </table>
        </contenttemplate> </asp:UpdatePanel>
    </div>
</asp:Content>

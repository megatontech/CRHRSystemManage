<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="LoginLog.aspx.cs" Inherits="SysManage_LoginLog" Title="自动办公系统 | 登陆日志" %>

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
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" Text="登陆日志"></asp:Label>
        <hr />
        <asp:UpdatePanel id="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <contenttemplate>
<TABLE width="90%"><TBODY><TR><TD style="TEXT-ALIGN: left"></TD></TR><TR><TD style="BACKGROUND-COLOR: #6dc7fc; TEXT-ALIGN: left"><TABLE width="100%"><TBODY><TR><TD style="WIDTH: 100px"></TD><TD>开始时间:<asp:TextBox id="txtStartDate" onfocus="new WdatePicker(this,'%Y-%M-%D',true,'default')" runat="server" CssClass="Wdate"></asp:TextBox></TD><TD><asp:Label id="Label3" runat="server" Text="--"></asp:Label> </TD><TD>结束时间:<asp:TextBox id="txtEndDate" onfocus="new WdatePicker(this,'%Y-%M-%D',true,'default')" runat="server" CssClass="Wdate"></asp:TextBox> <asp:CompareValidator id="cvTime" runat="server" Type="Date" Display="Dynamic" ControlToValidate="txtEndDate" Operator="GreaterThanEqual" ErrorMessage="结束时间不应小于开始时间" ControlToCompare="txtStartDate">*</asp:CompareValidator> </TD><TD style="WIDTH: 20px"></TD><TD><asp:RadioButton id="radBtnDay" onclick="showToDay()" runat="server" Text="本日" GroupName="time">
                                        </asp:RadioButton> <asp:RadioButton id="radBtnWeek" onclick="showWeekDay()" runat="server" Text="本周" GroupName="time"></asp:RadioButton> <asp:RadioButton id="radBtnMonth" onclick="showMonthDay()" runat="server" Text="本月" GroupName="time"></asp:RadioButton> </TD></TR><TR><TD style="TEXT-ALIGN: right"></TD><TD><asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" Display="None" ControlToValidate="txtStartDate" ErrorMessage="请选择日期"></asp:RequiredFieldValidator></TD><TD></TD><TD><asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" Display="None" ControlToValidate="txtEndDate" ErrorMessage="请选择日期"></asp:RequiredFieldValidator></TD><TD style="TEXT-ALIGN: right"></TD><TD></TD></TR></TBODY></TABLE></TD></TR><TR><TD align=right><asp:ImageButton id="ImageButton1" onclick="ImageButton1_Click" runat="server" ImageUrl="~/images/search.gif">
                        </asp:ImageButton></TD></TR></TBODY></TABLE>
                        <TABLE style="WIDTH: 90%"><TBODY><TR><TD style="VERTICAL-ALIGN: top" align=left>
                        <asp:Button id="BtnDelete" onclick="BtnDelete_Click" runat="server" BackColor="#EFF3FB" Enabled="False" 
                        Text="删除选定项" CssClass="buttonCss" 　 OnClientClick="return confirm('您确认要删除吗？')">
                        </asp:Button></TD></TR><TR><TD style="VERTICAL-ALIGN: top" align=right>
                        <asp:GridView id="GVLoginLogAll" runat="server" Width="100%" CssClass="grayBorder" OnRowDataBound="GVLoginLogAll_RowDataBound" 
                        DataKeyNames="Id" BorderColor="#00A3FF" AutoGenerateColumns="False" PageSize="12">
                            <PagerSettings FirstPageText=""></PagerSettings>
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
                                <asp:TemplateField HeaderText="登录用户">
                                    <ItemStyle HorizontalAlign="Center" Wrap="False" />
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemTemplate>
                                        <%# Eval("User.UserName")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="LoginTime" HeaderText="登陆时间">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="LoginUserIp" HeaderText="IP地址">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="是否成功">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemTemplate>
                                        <%# GetIfSuccess((int)Eval("IfSuccess"))%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="LoginDesc" HeaderText="登陆备注">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </asp:BoundField>
                            </Columns>
                            <PagerStyle HorizontalAlign="Center"></PagerStyle>
                            <HeaderStyle BackColor="#EFF3FB"></HeaderStyle>
                        </asp:GridView>
                         <webdiyer:AspNetPager id="anpPager" runat="server" CssClass="" 
                         PageSize="5" OnPageChanged="anpPager_PageChanged" SubmitButtonClass="buttonCss" 
                         CustomInfoClass="" PrevPageText="上一页" NextPageText="下一页" LastPageText="尾页" FirstPageText="第一页" ShowBoxThreshold="10">
                        </webdiyer:AspNetPager> 
                        </TD></TR></TBODY></TABLE>
</contenttemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

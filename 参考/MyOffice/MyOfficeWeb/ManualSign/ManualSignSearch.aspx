<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ManualSignSearch.aspx.cs" Inherits="ManualSign_ManualSignSearch" Title="自动办公系统 | 考勤历史查询" %>

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
function CheckBoxBranch(){ 
    var Branch=document.getElementById("<%= chkBranch.ClientID%>");   
      if(Branch.checked==true)
      {
         document.getElementById("<%= ddlBranchs.ClientID%>").disabled=false;
      }
      else
      {
       document.getElementById("<%= ddlBranchs.ClientID%>").disabled=true;
      }
}
function CheckBoxDepart(){ 
    var Depart=document.getElementById("<%= chkDepart.ClientID%>");   
      if(Depart.checked==true)
      {
         document.getElementById("<%= ddlDeparts.ClientID%>").disabled=false;
      }
      else
      {
       document.getElementById("<%= ddlDeparts.ClientID%>").disabled=true;
      }
}
function CheckBoxUserName(){ 
    var UserName=document.getElementById("<%= chkUserName.ClientID%>");   
      if(UserName.checked==true)
      {
         document.getElementById("<%= txtUserName.ClientID%>").disabled=false;
      }
      else
      {
       document.getElementById("<%= txtUserName.ClientID%>").disabled=true;
      }
}

    </script>

    <div style="text-align: center">
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" Text="员 工 考 勤 历 史 记 录 查&nbsp; 询"></asp:Label>
        <hr />
    </div>
    <table class="GBText" cellspacing="0" cellpadding="0" width="95%" align="center">
        <tr>
            <td colspan="2">
                <asp:UpdatePanel id="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
<TABLE><TBODY><TR style="BACKGROUND-COLOR: #6dc7fc"><TD style="WIDTH: 80px; HEIGHT: 39px" align=center>输入时间段：</TD><TD style="HEIGHT: 39px">&nbsp;&nbsp;开始时间: <asp:TextBox id="txtStartDate" onfocus="new WdatePicker(this,'%Y-%M-%D',true,'default')" runat="server" Width="141px" CssClass="Wdate"></asp:TextBox>&nbsp; -----&nbsp; 结束时间: <asp:TextBox id="txtEndDate" onfocus="new WdatePicker(this,'%Y-%M-%D',true,'default')" runat="server" Width="149px" CssClass="Wdate"></asp:TextBox>&nbsp; <asp:CompareValidator id="cvTime" runat="server" Type="Date" Display="Dynamic" ControlToValidate="txtEndDate" Operator="GreaterThanEqual" ErrorMessage="结束时间不应小于开始时间" ControlToCompare="txtStartDate">*</asp:CompareValidator>&nbsp;&nbsp;&nbsp; <asp:RadioButton id="rdoThisDay" onclick="showToDay()" runat="server" Text="本日" GroupName="quickdate">
                                </asp:RadioButton> <asp:RadioButton id="rdoThisWeek" onclick="showWeekDay()" runat="server" Text="本周" GroupName="quickdate"></asp:RadioButton> <asp:RadioButton id="rdoThisMonth" onclick="showMonthDay()" runat="server" Text="本月" GroupName="quickdate"></asp:RadioButton></TD></TR><TR><TD vAlign=middle align=center colSpan=2 height=5>
<HR width="98%" color=gray SIZE=1 />
</TD></TR><TR><TD style="WIDTH: 81px; HEIGHT: 26px" vAlign=middle align=right><asp:Image id="img1" runat="server" ImageUrl="~/images/search2.gif"></asp:Image>查找范围：</TD><TD style="HEIGHT: 26px" align=left><asp:CheckBox id="chkBranch" onclick="CheckBoxBranch()" runat="server" Width="76px" Text="按机构" Font-Size="15px"></asp:CheckBox> <asp:CheckBox id="chkDepart" onclick="CheckBoxDepart()" runat="server" Width="75px" CausesValidation="True" Text="按部门" Font-Size="15px" OnCheckedChanged="chkDepart_CheckedChanged">
                                </asp:CheckBox> <asp:CheckBox id="chkUserName" onclick="CheckBoxUserName()" runat="server" Width="76px" Text="按姓名" Font-Size="15px"></asp:CheckBox></TD></TR><TR><TD align=center colSpan=2 height=5>
<HR width="98%" color=gray SIZE=1 />
</TD></TR><TR><TD colSpan=2>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;机构: <asp:DropDownList id="ddlBranchs" runat="server" Width="160px" Enabled="False" CssClass="ddlCss" OnSelectedIndexChanged="ddlBranchs_SelectedIndexChanged" AutoPostBack="True">
                                </asp:DropDownList> &nbsp; 部门: <asp:DropDownList id="ddlDeparts" runat="server" Width="184px" Enabled="False" CssClass="ddlCss">
                                </asp:DropDownList> &nbsp; &nbsp;&nbsp; 姓名: <asp:TextBox id="txtUserName" runat="server" Width="64px" Enabled="False" CssClass="inputCss" Columns="10"></asp:TextBox>(模糊查找 eg:李)<BR /><BR />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:ImageButton id="imgbtnSearch" onclick="imgbtnSearch_Click" runat="server" Height="21px" Width="100px" ImageUrl="~/images/search.gif"></asp:ImageButton> </TD></TR><TR><TD style="HEIGHT: 100%" vAlign=top align=right width="90%" colSpan=2><asp:GridView id="gvUserSignInfo" runat="server" Width="99%" PageSize="6" AutoGenerateColumns="False" BorderColor="#66CCFF" BorderWidth="1px" CellPadding="4">
                                    <Columns>
                                        <asp:TemplateField HeaderText="签到员工">
                                            <ItemStyle HorizontalAlign="Center" Wrap="False" />
                                            <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("User.UserName")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="SignTime" HeaderText="签卡时间">
                                            <ItemStyle HorizontalAlign="Center" Wrap="False" />
                                            <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="签卡标记">
                                            <ItemStyle HorizontalAlign="Center" Wrap="False" />
                                            <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Text='<%# GetSignTag(Eval("SignTag")) %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="签卡备注">
                                            <ItemStyle HorizontalAlign="Center" Wrap="False" />
                                            <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                            <ItemTemplate>
                                                <asp:Label ID="Label5" runat="server" Text='<%# GetCut(Eval("SignDesc")) %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="所属部门">
                                            <ItemStyle HorizontalAlign="Center" Wrap="False" />
                                            <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                            <ItemTemplate>
                                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("User.Depart.DepartName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="所属机构">
                                            <ItemStyle HorizontalAlign="Center" Wrap="False" />
                                            <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                            <ItemTemplate>
                                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("User.Depart.Branch.BranchName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView> </TD></TR><TR><TD style="HEIGHT: 22px" align=right colSpan=2><webdiyer:AspNetPager id="anpPager" runat="server" CssClass="" PageSize="5" OnPageChanged="anpPager_PageChanged" ShowBoxThreshold="10" FirstPageText="第一页" LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" CustomInfoClass="" SubmitButtonClass="buttonCss">
                                </webdiyer:AspNetPager>&nbsp; </TD></TR></TBODY></TABLE>
                                <ajax:AutoCompleteExtender id="AutoCompleteExtender1" runat="server" TargetControlID="txtUserName" ServiceMethod="GetHotSearchKeywords" ServicePath="~/WebService/WebService.asmx" MinimumPrefixLength="1">
                </ajax:AutoCompleteExtender> <asp:Label id="lblMessage" runat="server" ForeColor="Red" Font-Size="18px" ToolTip="没有找到任何数据"></asp:Label> 
</contenttemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>

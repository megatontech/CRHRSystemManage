<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="MessageManage.aspx.cs" Inherits="Message_MessageManage_MessageManage"
    Title="消息管理" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphOffice" runat="Server">

    <script type="text/javascript" language="javascript" src="../../My97DatePicker/WdatePicker.js"
        charset="gb2312"></script>

    <script type="text/javascript">
        function  ScanMessageDetail(messageId)
		{
		 window.showModalDialog("MessageContent.aspx?messageid="+messageId,"","status=no;dialogWidth=550px;dialogHeight=600px;menu=no;resizeable=yes;scroll=yes;center=yes;edge=raise")
		}
      //今天
      function showToDay()
     {
        var Nowdate=new Date();
        M=Number(Nowdate.getMonth())+1//得到月份
        var date= Nowdate.getYear()+"-"+M+"-"+Nowdate.getDate();
        document.getElementById("<%= txtBeginTime.ClientID%>").value=date;
         document.getElementById("<%= txtEndTime.ClientID%>").value=date;

     }
    //本周
  function showWeekDay()
 {
     var Nowdate=new Date();
     var WeekFirstDay=new Date(Nowdate-(Nowdate.getDay()-1)*86400000); //本周第一天 
     var WeekLastDay=new Date((WeekFirstDay/1000+6*86400)*1000);//本周最后一天
      M=Number(WeekFirstDay.getMonth())+1//得到月份   
      N=Number(WeekLastDay.getMonth())+1//得到月份     
     document.getElementById("<%= txtBeginTime.ClientID%>").value=WeekFirstDay.getYear()+"-"+M+"-"+WeekFirstDay.getDate();
     document.getElementById("<%= txtEndTime.ClientID%>").value=WeekLastDay.getYear()+"-"+N+"-"+WeekLastDay.getDate();
    
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
    document.getElementById("<%= txtBeginTime.ClientID%>").value=MonthFirstDay.getYear()+"-"+M+"-"+MonthFirstDay.getDate();
    document.getElementById("<%= txtEndTime.ClientID%>").value=MonthLastDay.getYear()+"-"+N+"-"+MonthLastDay.getDate();    
    
}
    </script>

    <div>
     <br />
        <table style="width: 99%">
            <tr>
                <td colspan="6" style="text-align: center">
                    <strong><span style="font-size: 16pt">消息管理</span></strong>
                    </td>
            </tr>
             <tr>
                <td colspan="6" style="text-align: center">
                     <hr style="width: 100%;" />
                    </td>
            </tr>
            <tr>
                <td colspan="6">
                    <strong><span style="font-size: 12pt">请输入创建消息的时间：<asp:Image ID="imgMessage" runat="server"
                        Height="39px" ImageUrl="~/images/message.gif" /></span></strong></td>
            </tr>
            <tr>
                <td>
                    开始时间：</td>
                <td>
                    <asp:TextBox ID="txtBeginTime" runat="server" CssClass="Wdate" onfocus="new WdatePicker(this,'%Y-%M-%D',true,'default')"
                        Width="96px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvBeginTime" runat="server" ErrorMessage="非空" Display="dynamic"
                        ControlToValidate="txtBeginTime"></asp:RequiredFieldValidator>
                </td>
                <td>
                    结束时间：</td>
                <td>
                    <asp:TextBox ID="txtEndTime" runat="server" CssClass="Wdate" onfocus="new WdatePicker(this,'%Y-%M-%D',true,'default')"
                        Width="93px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="非空"
                        Display="dynamic" ControlToValidate="txtEndTime"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator2" runat="server" Display="Dynamic" ControlToValidate="txtEndTime"
                        Operator="GreaterThanEqual" ErrorMessage="结束时间不应小于开始时间" ControlToCompare="txtBeginTime"></asp:CompareValidator>
                </td>
                <td>
                    <asp:RadioButton ID="rdoToday" runat="server" Text="本日" onclick="showToDay()" GroupName="rdoDateTime" />
                    <asp:RadioButton ID="rdoWeek" runat="server" Text="本周" onclick="showWeekDay()" GroupName="rdoDateTime" />
                    <asp:RadioButton ID="rdoMonth" runat="server" Text="本月" onclick="showMonthDay()"
                        GroupName="rdoDateTime" /></td>
                <td>
                    <asp:ImageButton ID="imgbtnSearch" runat="server" ImageUrl="~/images/search.gif"
                        OnClick="imgbtnSearch_Click" /></td>
            </tr>
            <tr>
                <td colspan="6" style="height: 25px; background-color: #00a3ff; text-align: right">
                    <asp:LinkButton ID="linkbtnAddMessage" runat="server" CausesValidation="False" PostBackUrl="~/Message/MessageManage/MessageAdd.aspx">添加新消息</asp:LinkButton></td>
            </tr>
        </table>
    </div>
    <asp:GridView ID="gvMessage" runat="server" Width="99%" BorderColor="#00A3FF" CssClass="grayBorder"
        AutoGenerateColumns="False" OnRowDataBound="gvMessage_RowDataBound" OnRowCommand="gvMessage_RowCommand" DataKeyNames="Id">
        <Columns>
            <asp:TemplateField HeaderText="标题">
               
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# GetCut(Eval("Title")) %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="类型">
               
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("MessageType.MessageTypeName") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Wrap="False" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="内容">
               
                <ItemTemplate>
                    <%--<asp:Label ID="Label3" runat="server" Text='<%# GetCut(Eval("MessageContent")) %>'></asp:Label>--%>
                    <asp:HyperLink ID="hlMessageContent" runat="server"><%# GetCut(Eval("MessageContent")) %></asp:HyperLink>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="创建者">
               
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("FromUser.UserName") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Wrap="False" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="发布对象">
                
                <ItemTemplate>
                    <asp:HyperLink ID="hlUserName" runat="server" ForeColor="Black"></asp:HyperLink>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Wrap="False" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="开始时间">
              
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# GetDate(Eval("BeginTime")) %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Wrap="False" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="结束时间">
                
                <ItemTemplate>
                    <asp:Label ID="Label7" runat="server" Text='<%# GetDate(Eval("EndTime")) %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Wrap="False" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="创建时间">
               
                <ItemTemplate>
                    <asp:Label ID="Label8" runat="server" Text='<%# GetDate(Eval("RecordTime")) %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Wrap="False" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="修改">
                <ItemTemplate>
                    <asp:ImageButton ID="imgbtnUpdate" Width="15px" Height="15px" runat="server" ImageUrl="~/images/edit.gif"
                        CommandName="messageModify" CausesValidation="False" CommandArgument='<%# Eval("Id") %>' />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Wrap="False" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="删除">
                <ItemTemplate>
                    <asp:ImageButton ID="imgbtnDelete" runat="server" Width="15px" Height="15px" ImageUrl="~/images/delete.gif"
                        CommandName="messageDelete" CausesValidation="False" CommandArgument='<%# Eval("Id") %>' />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Wrap="False" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="发布">
                <ItemTemplate>
                    <asp:Button ID="btnIsPublish" runat="server" Text="发布" CssClass="buttonCss" CommandName="publish"
                        CausesValidation="False" CommandArgument='<%# Eval("Id") %>' />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Wrap="False" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <webdiyer:AspNetPager ID="anpPager" runat="server" ShowBoxThreshold="2" OnPageChanged="anpPager_PageChanged"
        FirstPageText="第一页" LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" SubmitButtonClass="buttonCss">
    </webdiyer:AspNetPager>
    &nbsp;<br />
    &nbsp;
    <asp:Label ID="lblMessage" runat="server" Font-Size="18px" ForeColor="Red" ToolTip="没有找到任何数据"
        Visible="False"></asp:Label><%--<asp:ObjectDataSource ID="odsMessageToUser" runat="server" SelectMethod="GetMessageToUser"
        TypeName="MyOffice.BLL.MessageToUserManager"></asp:ObjectDataSource>--%>
</asp:Content>

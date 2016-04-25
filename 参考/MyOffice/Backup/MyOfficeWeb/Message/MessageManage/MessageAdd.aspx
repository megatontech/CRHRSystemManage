<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="MessageAdd.aspx.cs" Inherits="Message_MessageManage_MessageAdd" Title="编辑消息" %>

<%--<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="cphOffice" runat="Server">

    <script charset="gb2312" language="javascript" src="../../My97DatePicker/WdatePicker.js"
        type="text/javascript"></script>

    <!--复选框点击事件-->

    <script type="text/javascript">
        /*机构复选框点击事件*/
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
        /*部门复选框点击事件*/
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
        /*姓名复选框点击事件*/
        function CheckBoxUserName(){ 
            var UserName=document.getElementById("<%= chkUserName.ClientID%>");   
            if(UserName.checked==true)
            {
                 document.getElementById("<%= txtName.ClientID%>").disabled=false;
            }
            else
            {
                document.getElementById("<%= txtName.ClientID%>").disabled=true;
            }
        }
        /*全选*/
        function GetAllCheckBox(checkAll){
            var items=document.getElementsByTagName("input");  
            for(i=0;i<items.length;i++){
                if(items[i].type=="checkbox")
                {
                    items[i].checked=checkAll.checked;
                }   
            }
        }
    </script>

    <div>
        <div style="width: 100%; text-align: center">
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" Text="编辑消息"></asp:Label>
            <hr style="width: 100%;" />
        </div>   <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <contenttemplate>
<TABLE style="WIDTH: 99%"><TBODY><TR><TD>消息标题：</TD><TD style="WIDTH: 600px"><asp:TextBox id="txtTitle" runat="server" Width="231px" CssClass="inputCss"></asp:TextBox> <asp:RequiredFieldValidator id="rfvTitle" runat="server" ErrorMessage="非空" Display="dynamic" ControlToValidate="txtTitle">非空</asp:RequiredFieldValidator></TD></TR><TR><TD>消息类型：</TD><TD style="WIDTH: 600px"><asp:DropDownList id="ddlMessageTypeName" runat="server" Width="173px" CssClass="ddlCss" DataValueField="Id" DataTextField="MessageTypeName" DataSourceID="odsMessageTypeName">
                        </asp:DropDownList></TD></TR><TR><TD>开始有效时间：</TD><TD style="WIDTH: 600px"><asp:TextBox id="txtBeginTime" onfocus="new WdatePicker(this,'%Y-%M-%D %h:%m:%s',true,'default')" runat="server" Width="140px" CssClass="Wdate"></asp:TextBox> <asp:RequiredFieldValidator id="rfvBeginTime" runat="server" ErrorMessage="非空" Display="dynamic" ControlToValidate="txtBeginTime">非空</asp:RequiredFieldValidator></TD></TR><TR><TD>结束有效时间：</TD><TD style="WIDTH: 600px"><asp:TextBox id="txtEndTime" onfocus="new WdatePicker(this,'%Y-%M-%D %h:%m:%s',true,'default')" runat="server" Width="140px" CssClass="Wdate"></asp:TextBox> <asp:CompareValidator id="CompareValidator1" runat="server" ErrorMessage="CompareValidator" ControlToValidate="txtEndTime" __designer:wfdid="w10" ControlToCompare="txtBeginTime" Operator="GreaterThanEqual">结束时间必须大于开始时间</asp:CompareValidator></TD></TR><TR><TD>发送对象：</TD><TD style="WIDTH: 600px"><asp:RadioButtonList id="rdolstToUser" runat="server" Width="200px" OnSelectedIndexChanged="rdolstToUser_SelectedIndexChanged" AutoPostBack="True" RepeatColumns="2">
                            <asp:ListItem Selected="True" Value="0">所有人</asp:ListItem>
                            <asp:ListItem Value="1">选择特定对象</asp:ListItem>
                        </asp:RadioButtonList></TD></TR><TR><TD bgColor=#ece9d8 colSpan=2 rowSpan=2><asp:Panel id="pnlMessage_1" runat="server" Width="99%" Visible="False">
                            <table width="90%">
                                <tbody>
                                    <tr>
                                        <td style="height: 23px" colspan="2">
                                            <asp:CheckBox ID="chkBranch" onclick="CheckBoxBranch()" runat="server" Width="76px"
                                                Text="按机构" Font-Size="15px"></asp:CheckBox>
                                            <asp:CheckBox ID="chkDepart" onclick="CheckBoxDepart()" runat="server" Width="75px"
                                                Text="按部门" Font-Size="15px"></asp:CheckBox>
                                            <asp:CheckBox ID="chkUserName" onclick="CheckBoxUserName()" runat="server" Width="76px"
                                                Text="按姓名" Font-Size="15px"></asp:CheckBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            机构：<asp:DropDownList ID="ddlBranchs" runat="server" Width="173px" Enabled="False"
                                                AutoPostBack="True" OnSelectedIndexChanged="ddlBranchs_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            部门：<asp:DropDownList ID="ddlDeparts" runat="server" Width="173px" Enabled="False">
                                            </asp:DropDownList>
                                            姓名：<asp:TextBox ID="txtName" runat="server" Width="111px" Enabled="False" CssClass="inputCss"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 18px; text-align: center" colspan="2">
                                            <asp:Button ID="btnOK" OnClick="btnOK_Click" runat="server" CausesValidation="False"
                                                CssClass="buttonCss" Text="确认选择范围"></asp:Button>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </asp:Panel> <asp:Panel id="pnlUserName" runat="server" Height="50px" Width="99%" Visible="False">
                            <asp:CheckBox ID="chkCount" onclick="GetAllCheckBox(this)" runat="server" Text="全选">
                            </asp:CheckBox>
                            <asp:CheckBoxList ID="chkblstUserName" runat="server" RepeatDirection="Horizontal">
                            </asp:CheckBoxList></asp:Panel> </TD></TR><TR></TR><TR><TD style="HEIGHT: 167px; TEXT-ALIGN: left">消息内容：</TD><TD style="WIDTH: 600px; HEIGHT: 167px"><asp:TextBox id="txtMessageContent" runat="server" Height="140px" Width="406px" CssClass="inputCss" TextMode="MultiLine"></asp:TextBox> <asp:RequiredFieldValidator id="rfvMessageContent" runat="server" ErrorMessage="非空" Display="dynamic" ControlToValidate="txtMessageContent">非空</asp:RequiredFieldValidator></TD></TR><TR><TD style="HEIGHT: 18px; TEXT-ALIGN: center" colSpan=3><asp:Button id="btnPublish" runat="server" Text="直接发布消息" CssClass="buttonCss" __designer:wfdid="w8" OnClick="btnPublish_Click"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button id="btnUpdate" onclick="btnUpdate_Click" runat="server" Text="保存消息" CssClass="buttonCss"></asp:Button> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <asp:Button id="btnEnd" onclick="btnEnd_Click" runat="server" CausesValidation="False" Text="返回" CssClass="buttonCss"></asp:Button> </TD></TR></TBODY></TABLE><ajax:AutoCompleteExtender id="AutoCompleteExtender1" runat="server" TargetControlID="txtName" MinimumPrefixLength="1" ServicePath="~/WebService/WebService.asmx" ServiceMethod="GetHotSearchKeywords">
        </ajax:AutoCompleteExtender> 
</contenttemplate> </asp:UpdatePanel>
        <asp:ObjectDataSource ID="odsMessageTypeName" runat="server" SelectMethod="GetMessageType"
            TypeName="MyOffice.BLL.MessageTypeManager"></asp:ObjectDataSource>
    </div>
</asp:Content>

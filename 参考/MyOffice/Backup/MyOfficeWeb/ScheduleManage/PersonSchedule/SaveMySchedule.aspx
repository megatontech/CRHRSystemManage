<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="SaveMySchedule.aspx.cs" Inherits="ScheduleManage_PersonSchedule_SaveMySchedule"
    Title="我的日程安排" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphOffice" runat="Server">

    <script type="text/javascript">
    function show()
    {
        if(divPrecontract.style.display=="block")
            divPrecontract.style.display="none";
        else
            divPrecontract.style.display="block";
    }
    </script>

    <script type="text/javascript" language="javascript" src="../../My97DatePicker/WdatePicker.js"
        charset="gb2312"></script>

    <br />
       <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <contenttemplate>
    <div style="width: 834px; height: 100px; text-align: left" id="divTop" runat="server">
        <table style="width: 761px" id="TABLE1">
            <tbody>
                <tr>
                    <td style="width: 20px">
                    </td>
                    <td style="width: 111px">
                    </td>
                    <td style="width: 156px">
                    </td>
                    <td style="width: 122px">
                    </td>
                    <td style="width: 291px">
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left" colspan="5">
                        <div style="font-weight: bold; background-image: url(../../images/leftmenubg.gif);
                            width: 162px; color: #ffffff; background-repeat: no-repeat; height: 28px; text-align: center">
                            我的日程安排</div>
                        <hr style="width: 721px; color: #66ccff" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 20px">
                    </td>
                    <td style="text-align: left" colspan="4">
                        <asp:Label ID="lblSchedulTitle" runat="server" Text="主题："></asp:Label>
                        <asp:TextBox ID="txtTitle" runat="server" Width="494px" CssClass="inputCss"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle"
                            ErrorMessage="不能为空!"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td style="width: 20px">
                    </td>
                    <td style="text-align: left" colspan="2">
                        <asp:Label ID="lblAddress" runat="server" Width="41px" Text="地点："></asp:Label><asp:TextBox
                            ID="txtAddress" runat="server" CssClass="inputCss"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAddress"
                            ErrorMessage="不能为空!">不能为空!</asp:RequiredFieldValidator></td>
                    <td style="text-align: justify" colspan="2">
                        &nbsp;<asp:Label ID="Label1" runat="server" Text="会议类型："></asp:Label><asp:DropDownList
                            ID="ddlMeeting" runat="server" Width="156px" CssClass="ddlCss" AutoPostBack="True"
                            DataSourceID="obsmeeting" DataTextField="MeetingName" DataValueField="Id">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 20px">
                    </td>
                    <td colspan="3">
                        <asp:Label ID="Label2" runat="server" Width="67px" Text="开始时间：">
                        </asp:Label>
                        -------<asp:TextBox ID="txtBeginTime" onfocus="new WdatePicker(this,'%Y-%M-%D %h:%m:%s',true,'default')"
                            runat="server" CssClass="Wdate"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtBeginTime"
                            ErrorMessage="不能为空!">不能为空!</asp:RequiredFieldValidator></td>
                    <td style="width: 291px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 20px; height: 23px">
                    </td>
                    <td style="height: 23px" colspan="3">
                        <asp:Label ID="Label3" runat="server" Width="66px" Text="结束时间： "></asp:Label>-------
                        <asp:TextBox ID="txtEndTime" onfocus="new WdatePicker(this,'%Y-%M-%D %h:%m:%s',true,'default')"
                            runat="server" CssClass="Wdate"></asp:TextBox>
                        <asp:CompareValidator ID="cvTime" runat="server" ControlToValidate="txtEndTime" ErrorMessage="结束时间不应小于开始时间"
                            Display="Dynamic" Operator="GreaterThanEqual" ControlToCompare="txtBeginTime">结束时间不应小于开始时间</asp:CompareValidator></td>
                    <td style="width: 291px; height: 23px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 20px; height: 44px">
                    </td>
                    <td style="height: 44px; text-align: left" colspan="4">
                        &nbsp;<asp:TextBox ID="txtContent" runat="server" Height="134px" Width="536px" CssClass="inputCss"
                            TextMode="MultiLine"></asp:TextBox>&nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtContent"
                            ErrorMessage="不能为空!">不能为空!</asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td style="width: 20px; height: 15px">
                    </td>
                    <td style="width: 111px; height: 15px; text-align: justify">
                        <asp:Label ID="Label4" runat="server" Width="77px" Text="预约他人： "></asp:Label>
                        <img onclick="show()" alt="" src="../../images/admin2.gif" />
                    </td>
                    <td style="width: 156px; height: 15px">
                    </td>
                    <td style="width: 122px; height: 15px">
                    </td>
                    <td style="width: 291px; height: 15px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 20px">
                    </td>
                    <td style="width: 111px; text-align: justify">
                        <asp:ListBox Style="background-color: #99ccff" ID="lstbPreContract" runat="server"
                            Height="118px" Width="133px" OnSelectedIndexChanged="lstbPreContract_SelectedIndexChanged">
                        </asp:ListBox></td>
                    <td style="width: 156px">
                        <asp:Button ID="btnDeletePreContract" OnClick="btnDeletePreContract_Click" runat="server"
                            Height="26px" CausesValidation="False" Text="删除选定预约人" CssClass="buttonCss" OnClientClick="return confirm('确定要删除吗？')">
                        </asp:Button></td>
                    <td style="width: 122px">
                    </td>
                    <td style="width: 291px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 20px; height: 33px">
                    </td>
                    <td style="width: 111px; height: 33px">
                    </td>
                    <td style="width: 156px; height: 33px">
                        <asp:Label ID="Label5" runat="server" Text="选项："></asp:Label>
                        <asp:CheckBox ID="ckbIfPirvate" runat="server" Text="是否公开"></asp:CheckBox></td>
                    <td style="width: 122px; height: 33px">
                        <asp:Label ID="Label6" runat="server" Text="创建者： "></asp:Label>
                        <asp:Label ID="lblName" runat="server"></asp:Label></td>
                    <td style="width: 291px; height: 33px">
                        <asp:Label ID="Label7" runat="server" Text="创建日期："></asp:Label>
                        <asp:Label ID="lblTime" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 20px; height: 23px">
                    </td>
                    <td style="width: 111px; height: 23px">
                        <asp:Button ID="btnadd" OnClick="btnadd_Click" runat="server" Height="22px" Width="99px"
                            Text="保存退出 " CssClass="buttonCss"></asp:Button></td>
                    <td style="width: 156px; height: 23px">
                        <asp:Button ID="btnDelete" OnClick="btnDelete_Click" runat="server" Height="21px"
                            Width="58px" Text="删除" CssClass="buttonCss" OnClientClick="return confirm('确定要删除吗？')">
                        </asp:Button></td>
                    <td style="width: 122px; height: 23px">
                        <asp:Button ID="btnExit" OnClick="btnExit_Click" runat="server" Height="22px" Width="57px"
                            CausesValidation="False" Text="退出" CssClass="buttonCss"></asp:Button></td>
                    <td style="width: 291px; height: 23px">
                    </td>
                </tr>
            </tbody>
        </table>
        <asp:ObjectDataSource ID="obsmeeting" runat="server" SelectMethod="GetAllMeeting"
            TypeName="MyOffice.BLL.MeetingInfoManager"></asp:ObjectDataSource>
    </div>
    &nbsp; &nbsp;&nbsp;
    <div style="z-index: 150; left: 344px; width: 100px; position: absolute; top: 105px;
        height: 100px; background-color: #99ccff; display:none;" id="divPrecontract"
        visible="false">
        <asp:TreeView Style="background-color: #99ccff" ID="trvPreContract" runat="server"
            Height="222px" Width="149px" OnSelectedNodeChanged="trvPreContract_SelectedNodeChanged">
        </asp:TreeView>
        <a style="color: #ff0000" onclick="javascript:document.getElementById('divPrecontract').style.display='none';"
            href="#">关闭</a> </div>
    </contenttemplate> </asp:UpdatePanel>
</asp:Content>

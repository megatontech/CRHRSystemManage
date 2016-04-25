<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="DepartSchedule.aspx.cs" Inherits="ScheduleManage_DepartSchedule_DepartSchedule"
    Title="部门日程" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphOffice" runat="Server">

    <script type="text/javascript" language="javascript" src="../../My97DatePicker/WdatePicker.js"
        charset="gb2312"></script>
   <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <contenttemplate>
    <div style="width: 128px; height: 102px" id="div1" align="center">
        <table style="width: 752px">
            <tbody>
                <tr>
                    <td colspan="6">
                       
        <br />
        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Medium" Text="部门日程"></asp:Label>
        <hr />
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        <asp:Label ID="lblBranch" runat="server" Text="选择机构--："></asp:Label></td>
                    <td style="width: 100px">
                        <asp:DropDownList ID="ddlBranch" runat="server" Width="162px" CssClass="ddlCss" AutoPostBack="True"
                            OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged">
                        </asp:DropDownList></td>
                    <td style="width: 100px; text-align: right">
                        <asp:Label ID="lblDepart" runat="server" Text="选择部门--："></asp:Label></td>
                    <td style="width: 100px">
                        <asp:DropDownList ID="ddlDepart" runat="server" Width="140px" Enabled="False" CssClass="ddlCss"
                            AutoPostBack="True">
                        </asp:DropDownList></td>
                    <td style="width: 60px; text-align: right">
                        <asp:Label ID="lblName" runat="server" Text="姓名："></asp:Label></td>
                    <td style="width: 138px">
                        <asp:TextBox ID="txtName" runat="server" CssClass="inputCss "></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        <asp:Label ID="lblDate" runat="server" Text="日期------："></asp:Label></td>
                    <td style="width: 100px">
                        <asp:TextBox ID="txtDate" onfocus="new WdatePicker(this,'%Y-%M-%D ',true,'default')"
                            runat="server" CssClass="Wdate"></asp:TextBox>
                    </td>
                    <td style="width: 100px">
                        <asp:ImageButton ID="imgbtnSearch" OnClick="imgbtnSearch_Click" runat="server" ImageUrl="~/images/search.gif"
                            Height="25px"></asp:ImageButton></td>
                    <td style="width: 100px">
                    </td>
                    <td style="width: 60px">
                    </td>
                    <td style="width: 138px">
                    </td>
                </tr>
                <tr>
                    <td style="height: 23px" colspan="6">
                    </td>
                </tr>
            </tbody>
        </table>
        <asp:Label Style="background-color: #66ccff" ID="lblDateTime" runat="server" Height="28px"
            Width="770px"></asp:Label><br />
        <asp:GridView ID="gvdepart" runat="server" Width="771px" CssClass="grayBorder" AutoGenerateColumns="False"
            DataKeyNames="Id" OnRowDataBound="gvdepart_RowDataBound" BorderColor="DeepSkyBlue">
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <table>
                            <tr>
                                <td style="width: 100px">
                                    人员姓名</td>
                                <td style="width: 100px">
                                    <asp:Label ID="Label8" runat="server" Style="color: #ff0066" Text="星期日"></asp:Label>
                                    <asp:Label ID="Label1" runat="server"></asp:Label></td>
                                <td style="width: 100px">
                                    星期一<asp:Label ID="Label2" runat="server"></asp:Label></td>
                                <td style="width: 100px">
                                    星期二<asp:Label ID="Label3" runat="server"></asp:Label></td>
                                <td style="width: 100px">
                                    星期三<asp:Label ID="Label4" runat="server"></asp:Label></td>
                                <td style="width: 100px">
                                    星期四<asp:Label ID="Label5" runat="server"></asp:Label></td>
                                <td style="width: 100px">
                                    星期五<asp:Label ID="Label6" runat="server"></asp:Label></td>
                                <td style="width: 100px">
                                    <asp:Label ID="Label9" runat="server" Style="color: #ff0066" Text="星期六"></asp:Label>
                                    <asp:Label ID="Label7" runat="server"></asp:Label></td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table>
                            <tr>
                                <td style="width: 100px">
                                    <asp:Label ID="lblUserName" runat="server"></asp:Label></td>
                                <td style="width: 100px">
                                    <asp:HyperLink ID="HyperLink1" runat="server"></asp:HyperLink></td>
                                <td style="width: 100px">
                                    <asp:HyperLink ID="HyperLink2" runat="server"></asp:HyperLink></td>
                                <td style="width: 100px">
                                    <asp:HyperLink ID="HyperLink3" runat="server"></asp:HyperLink></td>
                                <td style="width: 100px">
                                    <asp:HyperLink ID="HyperLink4" runat="server"></asp:HyperLink></td>
                                <td style="width: 100px">
                                    <asp:HyperLink ID="HyperLink5" runat="server"></asp:HyperLink></td>
                                <td style="width: 100px">
                                    <asp:HyperLink ID="HyperLink6" runat="server"></asp:HyperLink></td>
                                <td style="width: 100px">
                                    <asp:HyperLink ID="HyperLink7" runat="server"></asp:HyperLink></td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <RowStyle HorizontalAlign="Center" />
        </asp:GridView>
    </div>
    &nbsp;&nbsp;&nbsp;&nbsp;<br />
    <asp:Label Style="font-weight: bold" ID="lblMessage" runat="server" ForeColor="Red"
        Font-Size="18px"></asp:Label><br />
         <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtName"
                    MinimumPrefixLength="1" ServicePath="~/WebService/WebService.asmx" ServiceMethod="GetHotSearchKeywords">
                </ajax:AutoCompleteExtender>
    </contenttemplate> </asp:UpdatePanel>
</asp:Content>

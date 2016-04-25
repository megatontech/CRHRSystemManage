<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ScheduleAll.aspx.cs" Inherits="ScheduleManage_PersonSchedule_ScheduleAll" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphOffice" Runat="Server">
    <div id="div1" align="center" style="width: 741px; height: 205px">
    <asp:Label ID="Label1" runat="server" Text="我的日程信息" Width="338px" style="font-weight: bold"></asp:Label>
        <hr />
        <asp:GridView ID="gvSchedule" runat="server" AutoGenerateColumns="False"
            DataSourceID="odsSchedule" Width="733px" DataKeyNames="Id" style="border-left-color: #33ccff; border-bottom-color: #33ccff; border-top-style: solid; border-top-color: #33ccff; border-right-style: solid; border-left-style: solid; border-right-color: #33ccff; border-bottom-style: solid" OnRowDataBound="gvSchedule_RowDataBound" >
            <Columns>
                <asp:TemplateField HeaderText="主题" SortExpression="Title">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Title") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblTitle" runat="server" Text='<%# GetCut(Eval("Title")) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="内容" SortExpression="SchContent">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("SchContent") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# GetCut(Eval("SchContent")) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="开始时间" SortExpression="BeginTime">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("BeginTime") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("BeginTime", "{0:d}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="结束时间" SortExpression="EndTime">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("EndTime") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("EndTime", "{0:d}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="创建时间" SortExpression="CreateTime">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("CreateTime") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("CreateTime", "{0:d}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Address" HeaderText="地点" SortExpression="Address" />
                <asp:TemplateField HeaderText="查看">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("Id","SaveMySchedule.aspx?scheduleid={0}") %>'>查看详细</asp:HyperLink>&nbsp;
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <RowStyle HorizontalAlign="Center" />
            <HeaderStyle BackColor="DeepSkyBlue" />
        </asp:GridView>
        <br />
        <asp:Label ID="lblPreContract" runat="server" Style="font-weight: bold" Text="被预约日程信息" Width="310px"></asp:Label>&nbsp;
        <br />
        <asp:Panel ID="panHr" runat="server" Height="1px" Width="737px">
            <hr />
            &nbsp;</asp:Panel>
        <br />
        <asp:GridView ID="gvPreSchedule" runat="server" Style="border-left-color: #33ccff; border-bottom-color: #33ccff;
            border-top-style: solid; border-top-color: #33ccff; border-right-style: solid;
            border-left-style: solid; border-right-color: #33ccff; border-bottom-style: solid"
            Width="733px" AutoGenerateColumns="False" OnRowDataBound="gvPreSchedule_RowDataBound">
            <HeaderStyle BackColor="DeepSkyBlue" />
            <Columns>
             <asp:TemplateField HeaderText="发件人" SortExpression="Schedule">
                    
                    <ItemTemplate>
                        <asp:Label ID="lblcreateUserName" runat="server" Text='<%# GetCut(Eval("Schedule.CreateUserId.UserName")) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="主题" SortExpression="Schedule">
                    
                    <ItemTemplate>
                        <asp:Label ID="lblTitle" runat="server" Text='<%# GetCut(Eval("Schedule.Title")) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="内容" SortExpression="Schedule">
                    
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# GetCut(Eval("Schedule.SchContent")) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="开始时间" SortExpression="Schedule">
                   
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Schedule.BeginTime", "{0:d}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="结束时间" SortExpression="Schedule">
                   
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("Schedule.EndTime", "{0:d}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="创建时间" SortExpression="Schedule">
                   
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("Schedule.CreateTime", "{0:d}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
               
                <asp:TemplateField HeaderText="地点" SortExpression="Schedule">
                    
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("Schedule.Address") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="查看">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("Schedule.Id","SaveMySchedule.aspx?scheduleid={0}") %>'>查看详细</asp:HyperLink>&nbsp;
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <div style="width: 730px; height: 2px; color: #cccccc;" align="right">
                        <a href="PersonSchedule.aspx">返回上页&gt;&gt;</a></div>
    </div>
    <asp:ObjectDataSource ID="odsSchedule" runat="server" SelectMethod="GetScheduleByUserIdandDate"
        TypeName="MyOffice.BLL.ScheduleManager">
        <SelectParameters>
            <asp:QueryStringParameter Name="userId" QueryStringField="userId" Type="Int32" />
            <asp:QueryStringParameter Name="date" QueryStringField="date" Type="DateTime" />
        </SelectParameters>
    </asp:ObjectDataSource>
    &nbsp;
    <br />
    <asp:ObjectDataSource ID="odspreSchedule" runat="server" SelectMethod="SelectPrecontract" TypeName="MyOffice.BLL.PreContractManager">
        <SelectParameters>
            <asp:QueryStringParameter Name="userId" QueryStringField="userId" Type="Int32" />
            <asp:QueryStringParameter Name="date" QueryStringField="date" Type="DateTime" />
        </SelectParameters>
    
    </asp:ObjectDataSource>
</asp:Content>


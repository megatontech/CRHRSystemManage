<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test4.aspx.cs" Inherits="FineUIPro.Examples.test4" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../res/css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager runat="server" ID="PageManager1" AutoSizePanelID="RegionPanel1" />

        设计时出错

        <f:RegionPanel ID="RegionPanel1" runat="server" ShowBorder="false">
            <Regions>
                <f:Region ID="region99" runat="server" ShowBorder="false" ShowHeader="false" Position="Center" Layout="Fit">
                    <Items>
                        <f:Grid ID="gridProject" runat="server" ShowGridHeader="true" ShowBorder="false" ShowHeader="false" AutoScroll="true" IsDatabasePaging="true"
                            EnableTextSelection="true" DataKeyNames="ID">
                            <Columns>
                                <f:LinkButtonField ColumnID="gridProject_Edit" HeaderText="操作" TextAlign="Center" Width="40px" Text="编辑" CommandName="Edit_Command" />

                                <%--<f:BoundField DataField="ID" HeaderText="ID" TextAlign="Center" Width="60px" />--%>
                                <f:BoundField DataField="Name" HeaderText="工程名称" TextAlign="Center" Width="200px" />
                                <f:BoundField DataField="strStatus_Bit" HeaderText="投标状态" TextAlign="Center" Width="60px" />
                                <f:BoundField DataField="strStatus_Sign" HeaderText="签合同状态" TextAlign="Center" Width="80px" />
                                <f:BoundField DataField="strStatus_Sing2" HeaderText="签技术协议状态" TextAlign="Center" Width="90px" />
                                <f:BoundField DataField="strStatus_Stock" HeaderText="进货状态" TextAlign="Center" Width="60px" />
                                <f:BoundField DataField="strStatus_Shipment" HeaderText="发货状态" TextAlign="Center" Width="60px" />
                                <f:BoundField DataField="strStatus_Construct" HeaderText="放工状态" TextAlign="Center" Width="60px" />
                                <f:BoundField DataField="strStatus_Check" HeaderText="验收状态" TextAlign="Center" Width="60px" />
                                <f:BoundField DataField="strStatus_Invoice" HeaderText="开发票状态" TextAlign="Center" Width="60px" />
                                <f:BoundField DataField="strStatus_Gather" HeaderText="收款状态" TextAlign="Center" Width="60px" />
                                <f:BoundField DataField="strStatus" HeaderText="状态" TextAlign="Center" Width="60px" />
                                <f:BoundField DataField="FilePath" HeaderText="文档存放目录" TextAlign="Center" Width="100px" />
                                <f:BoundField DataField="DtBegin" HeaderText="开始时间" TextAlign="Center" Width="80px" DataFormatString="{0:yyyy-MM-dd}" />
                                <f:BoundField DataField="DtEnd" HeaderText="结束时间" TextAlign="Center" Width="80px" DataFormatString="{0:yyyy-MM-dd}" />
                                <f:BoundField DataField="SnDescribe" HeaderText="备注" TextAlign="Center" Width="200px" />
                            </Columns>

                        </f:Grid>

                        <f:Grid ID="gridWork" runat="server" ShowGridHeader="true" ShowBorder="false" ShowHeader="true" Title="工作任务-按优先级排序" AutoScroll="true" IsDatabasePaging="true"
                            EnableTextSelection="true" AutoExpandColumn="SnDescribe" EnableRowSelectEvent="true"
                            PageSize="1000" DataKeyNames="ID">
                            <Columns>
                                <f:LinkButtonField ColumnID="gridWork_Edit" HeaderText="操作" TextAlign="Center" Width="40px" Text="编辑" CommandName="Edit_Command" />
                                <f:LinkButtonField ColumnID="gridWork_Delete" HeaderText="操作" TextAlign="Center" Width="40px" Text="删除" CommandName="Delete_Command" ConfirmText="您确定要删除此记录吗？" />

                                <%--<f:BoundField DataField="ID" HeaderText="ID" TextAlign="Center" Width="60px" />--%>
                                <f:BoundField HeaderText="优先级" TextAlign="Center" DataField="priority" Width="60px" />
                                <f:BoundField DataField="Name" HeaderText="任务名称" TextAlign="Center" Width="100px" />
                                <f:BoundField DataField="dtBegin" HeaderText="提出时间" TextAlign="Center" Width="70px" DataFormatString="{0:yyyy-MM-dd}" />
                                <f:BoundField DataField="SubmitUserName" HeaderText="提出人" TextAlign="Center" Width="60px" />
                                <f:BoundField DataField="AssignUserName" HeaderText="处理人" TextAlign="Center" Width="60px" />
                                <f:BoundField DataField="dtRequest" HeaderText="要求完成时间" TextAlign="Center" Width="100px" DataFormatString="{0:yyyy-MM-dd}" />
                                <f:BoundField DataField="dtstrReal" HeaderText="实际完成时间" TextAlign="Center" Width="100px" />
                                <f:BoundField DataField="Status" HeaderText="状态" TextAlign="Center" Width="60px" />
                                <f:BoundField DataField="SnDescribe" HeaderText="任务详细说明" TextAlign="Left" Width="200px" ExpandUnusedSpace="true" />
                            </Columns>


                        </f:Grid>
                    </Items>
                </f:Region>
            </Regions>
        </f:RegionPanel>

    </form>
</body>
</html>

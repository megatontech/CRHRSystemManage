<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="grid_groupheader.aspx.cs"
    Inherits="FineUIPro.Examples.grid.grid_groupheader" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../res/css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" />
        <f:Grid ID="Grid1" ShowBorder="true" ShowHeader="true" Title="表格" EnableCollapse="true" Width="800px" runat="server"
            DataKeyNames="Id">
            <Columns>
                <f:BoundField DataField="Year" Width="80px" HeaderText="统计年份" />
                <f:GroupField HeaderText="安徽省" TextAlign="Center">
                    <Columns>
                        <f:GroupField HeaderText="合肥市" TextAlign="Center">
                            <Columns>
                                <f:BoundField Width="100px" DataField="AHData1" HeaderText="数据一" />
                                <f:BoundField Width="100px" DataField="AHData2" HeaderText="数据二" />
                            </Columns>
                        </f:GroupField>
                    </Columns>
                </f:GroupField>
                <f:GroupField HeaderText="河南省" TextAlign="Center">
                    <Columns>
                        <f:GroupField HeaderText="驻马店市" TextAlign="Center">
                            <Columns>
                                <f:BoundField Width="100px" DataField="HZData1" HeaderText="数据一" />
                                <f:BoundField Width="100px" DataField="HZData2" HeaderText="数据二" />
                            </Columns>
                        </f:GroupField>
                        <f:GroupField HeaderText="漯河市" TextAlign="Center">
                            <Columns>
                                <f:BoundField Width="100px" DataField="HLData1" HeaderText="数据一" />
                                <f:BoundField Width="100px" DataField="HLData2" HeaderText="数据二" />
                            </Columns>
                        </f:GroupField>
                    </Columns>
                </f:GroupField>
                <f:BoundField BoxFlex="1" TextAlign="Center" DataField="LogTime" DataFormatString="{0:yyyy-MM-dd}" HeaderText="记录时间" />
            </Columns>
        </f:Grid>
        <br />
        <br />
    </form>
</body>
</html>

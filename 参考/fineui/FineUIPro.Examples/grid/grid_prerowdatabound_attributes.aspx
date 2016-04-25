<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="grid_prerowdatabound_attributes.aspx.cs"
    Inherits="FineUIPro.Examples.grid.grid_prerowdatabound_attributes" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../res/css/main.css" rel="stylesheet" type="text/css" />
    <style>
        .year1-container {
            background-color: #0094ff;
            color: #fff;
        }

        .year2-container {
            background-color: #0026ff;
            color: #fff;
        }

        .year3-container {
            background-color: #b200ff;
            color: #fff;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" />
        <f:Grid ID="Grid1" Title="表格" EnableCollapse="true" PageSize="3" ShowBorder="true" ShowHeader="true"
            Width="800px" OnPreRowDataBound="Grid1_PreRowDataBound" runat="server"
            EnableCheckBoxSelect="True" DataKeyNames="Id,Name" OnRowCommand="Grid1_RowCommand">
            <Columns>
                <f:RowNumberField />
                <f:BoundField Width="100px" DataField="Name" DataFormatString="{0}" HeaderText="姓名" />
                <f:TemplateField Width="80px" HeaderText="性别">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# GetGender(Eval("Gender")) %>'></asp:Label>
                    </ItemTemplate>
                </f:TemplateField>
                <f:BoundField Width="80px" ColumnID="bfEntranceYear" DataField="EntranceYear" HeaderText="入学年份" />
                <f:CheckBoxField ColumnID="cbxAtSchool" TextAlign="Center" Width="80px" RenderAsStaticField="false" DataField="AtSchool"
                    HeaderText="是否在校" />
                <f:HyperLinkField ColumnID="hlMajor" HeaderText="所学专业" DataToolTipField="Major" DataTextField="Major"
                    DataTextFormatString="{0}" DataNavigateUrlFields="Major" DataNavigateUrlFormatString="http://gsa.ustc.edu.cn/search?q={0}"
                    UrlEncode="true" Target="_blank" ExpandUnusedSpace="True" />
                <f:ImageField Width="80px" Hidden="true" DataImageUrlField="Group" DataImageUrlFormatString="~/res/images/16/{0}.png"
                    HeaderText="分组">
                </f:ImageField>
                <f:LinkButtonField TextAlign="Center" ConfirmText="你确定要这么做么？" ConfirmTarget="Top"
                    ColumnID="lbfAction1" Width="60px" CommandName="Action1" Text="按钮" />
                <f:LinkButtonField TextAlign="Center" ConfirmText="你确定要这么做么？" Icon="Delete" ConfirmTarget="Top"
                    ColumnID="lbfAction2" HeaderText="&nbsp;" Width="60px" CommandName="Action2" />
            </Columns>
            <Listeners>
                <f:Listener Event="dataload" Handler="onGridDataLoad" />
            </Listeners>
        </f:Grid>
        <br />
        <f:Label ID="labResult" EncodeText="false" runat="server">
        </f:Label>
        <br />
        注：本示例对于不同的入学年份显示不同的背景色。
    </form>
    <script>


        function onGridDataLoad() {
            this.el.find('[data-year]').each(function () {
                var cnode = $(this), dataYear = cnode.data('year');
                cnode.parents('.f-grid-cell').addClass(dataYear + '-container');
            });
        }


        // var gridClientID = '<%= Grid1.ClientID %>';

        //F.ready(function () {
        //    var grid = F(gridClientID);

        //    grid.on('dataload', function () {
        //        highlighCells(grid);
        //    });

        //    highlighCells(grid);

        //});

    </script>
</body>
</html>

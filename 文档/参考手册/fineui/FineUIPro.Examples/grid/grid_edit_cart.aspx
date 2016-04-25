<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="grid_edit_cart.aspx.cs"
    Inherits="FineUIPro.Examples.grid.grid_edit_cart" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../res/css/main.css" rel="stylesheet" type="text/css" />
    <style>
        body.f-body {
            padding: 0;
        }

        .totalpanel {
            border-top-width: 0 !important;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="Panel2" runat="server" />
        <f:Panel ID="Panel2" runat="server" ShowBorder="false" Layout="VBox" BoxConfigAlign="Stretch"
            BoxConfigPosition="Start" BodyPadding="5px"
            ShowHeader="false">
            <Items>
                <f:Grid ID="Grid1" ShowBorder="true" BoxFlex="1" ShowHeader="true" Title="购物车"
                    EnableCollapse="true" runat="server" EnableCheckBoxSelect="true"
                    DataKeyNames="Id,Code,Name" EnableTextSelection="true" KeepCurrentSelection="true">
                    <Columns>
                        <f:RowNumberField />
                        <f:BoundField Width="120px" DataField="Code" DataFormatString="{0}" HeaderText="商品代码" />
                        <f:BoundField DataField="Name" ExpandUnusedSpace="true" DataFormatString="{0}" HeaderText="商品名称" />
                        <f:BoundField Width="120px" DataField="Price" HeaderText="商品单价" DataFormatString="¥{0:F}" />
                        <f:TemplateField HeaderText="数量" Width="120px">
                            <ItemTemplate>
                                <input type="hidden" class="price" runat="server" value='<%# Eval("Price") %>' />
                                <asp:TextBox runat="server" Width="98%" ID="tbxNumber" CssClass="number"
                                    TabIndex='<%# Container.DataItemIndex + 10 %>' Text='<%# Eval("Number") %>'></asp:TextBox>
                            </ItemTemplate>
                        </f:TemplateField>
                        <f:TemplateField HeaderText="小计" Width="120px">
                            <ItemTemplate>
                                <asp:Label runat="server" CssClass="xiaoji" Text='<%# "¥" + GetXiaoji(Eval("Price"), Eval("Number")) %>'></asp:Label>
                            </ItemTemplate>
                        </f:TemplateField>
                    </Columns>
                </f:Grid>
                <f:ContentPanel runat="server" CssClass="totalpanel" ShowBorder="true" ShowHeader="false">
                    <div style="text-align: right; margin: 10px;">
                        <div style="margin-bottom: 10px;">
                            <input type="hidden" id="TOTAL_NUMBER" name="TOTAL_NUMBER" />
                            <span id="totalNumber" style="color: red;"></span>
                            件商品
                        </div>
                        <div style="margin-bottom: 10px;">
                            <input type="hidden" id="TOTAL_PRICE" name="TOTAL_PRICE" />
                            总计：<span id="totalPrice" style="color: red; font-size: 1.5em; font-weight: bold;"></span>
                        </div>
                        <div>
                            <f:Button runat="server" Text="去结算" Enabled="false" Size="Large" ID="btnGotoPay" OnClick="btnGotoPay_Click"></f:Button>
                        </div>
                    </div>
                </f:ContentPanel>
            </Items>
        </f:Panel>
    </form>
    <script type="text/javascript">
        var gridClientID = '<%= Grid1.ClientID %>';
        var btnGotoPayClientID = '<%= btnGotoPay.ClientID %>';
        var numberSelector = '.f-grid-tpl input.number';
        var priceSelector = '.f-grid-tpl input.price';

        function getRowNumber(row) {
            return parseInt(row.find(numberSelector).val(), 10) || 0;
        }
        function getRowPrice(row) {
            return parseFloat(row.find(priceSelector).val()) || 0;
        }

        function updateTotal() {
            var grid = F(gridClientID);
            var selectedRows = grid.getSelectedRows();

            var total = 0;
            $.each(selectedRows, function (index, rowIndex) {
                var row = grid.bodyEl.find('.f-grid-row').eq(rowIndex);
                total += getRowNumber(row) * getRowPrice(row);
            });

            $('#totalNumber').text(selectedRows.length);
            $('#totalPrice').text("¥" + total.toFixed(2));

            $('#TOTAL_NUMBER').val(selectedRows.length);
            $('#TOTAL_PRICE').val(total.toFixed(2));

            var gotoPayBtn = F(btnGotoPayClientID);
            if (total === 0) {
                gotoPayBtn.disable();
            } else {
                gotoPayBtn.enable();
            }
        }

        function registerNumberChangeEvents() {
            var grid = F(gridClientID);

            // 数量改变事件
            // http://stackoverflow.com/questions/17384218/jquery-input-event
            grid.el.find(numberSelector).on('input propertychange', function (evt) {
                var $this = $(this);

                var row = $this.parents('.f-grid-row');
                var number = getRowNumber(row);
                var price = getRowPrice(row);
                var resultNode = row.find('.f-grid-tpl span.xiaoji');

                resultNode.text("¥" + (number * price).toFixed(2));

                updateTotal();
            });
        }

        function registerSelectionChangeEvents() {
            var grid = F(gridClientID);

            grid.on('selectionchange', function () {
                updateTotal();
            });
        }

        // 页面第一次加载完成后调用的函数
        F.ready(function () {
            registerNumberChangeEvents();
            registerSelectionChangeEvents();
            updateTotal();
        });

    </script>
</body>
</html>

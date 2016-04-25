<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="grid_edit_save_auto.aspx.cs" EnableViewState="false"
    Inherits="FineUIPro.Examples.grid.grid_edit_save_auto" %>

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

        .success {
            color: Green;
        }

        .error {
            color: Red;
        }

        .bold {
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="Panel2" OnCustomEvent="PageManager1_CustomEvent" runat="server" />
        <f:Panel ID="Panel2" runat="server" ShowBorder="false" Layout="HBox" BoxConfigAlign="Stretch"
            BoxConfigPosition="Start" BodyPadding="5px"
            ShowHeader="false">
            <Items>
                <f:Grid ID="Grid1" ShowBorder="true" BoxFlex="1" ShowHeader="true" Title="表格（每隔30秒自动保存全部数据，并显示提示信息）" runat="server" EnableCollapse="true"
                    DataKeyNames="Id,Name" EnableMultiSelect="false" Margin="0 5 0 0">
                    <Toolbars>
                        <f:Toolbar ID="Toolbar1" runat="server">
                            <Items>
                                <f:ToolbarFill ID="ToolbarFill1" runat="server">
                                </f:ToolbarFill>
                                <f:Button runat="server" OnClick="btnSave_Click" Text="保存用户输入数据" ID="btnSave">
                                </f:Button>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                    <Columns>
                        <f:TemplateField Width="60px" EnableColumnHide="false" EnableHeaderMenu="false">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                            </ItemTemplate>
                        </f:TemplateField>
                        <f:BoundField Width="100px" ColumnID="Name" DataField="Name" DataFormatString="{0}" HeaderText="姓名" />
                        <f:TemplateField Width="80px" ColumnID="Gender" HeaderText="性别">
                            <ItemTemplate>
                                <%-- Container.DataItem 的类型是 System.Data.DataRowView 或者用户自定义类型 --%>
                                <%--<asp:Label ID="Label2" runat="server" Text='<%# GetGender(DataBinder.Eval(Container.DataItem, "Gender")) %>'></asp:Label>--%>
                                <asp:Label ID="Label3" runat="server" Text='<%# GetGender(Eval("Gender")) %>'></asp:Label>
                            </ItemTemplate>
                        </f:TemplateField>
                        <f:BoundField Width="80px" ColumnID="EntranceYear" DataField="EntranceYear" HeaderText="入学年份" />
                        <f:CheckBoxField Width="80px" ColumnID="AtSchool" RenderAsStaticField="true" DataField="AtSchool" HeaderText="是否在校" />
                        <f:HyperLinkField HeaderText="所学专业" ColumnID="Major" DataToolTipField="Major" DataTextField="Major"
                            DataTextFormatString="{0}" DataNavigateUrlFields="Major" DataNavigateUrlFormatString="http://gsa.ustc.edu.cn/search?q={0}"
                            UrlEncode="true" Target="_blank" ExpandUnusedSpace="True" />
                        <f:TemplateField HeaderText="语文成绩" ColumnID="ChineseScore" Width="80px">
                            <ItemTemplate>
                                <asp:TextBox runat="server" Width="98%" ID="tbxTableChineseScore" CssClass="ChineseScore"
                                    TabIndex='<%# Container.DataItemIndex + 10 %>' Text='<%# Eval("ChineseScore") %>'></asp:TextBox>
                            </ItemTemplate>
                        </f:TemplateField>
                        <f:TemplateField HeaderText="数学成绩" ColumnID="MathScore" Width="80px">
                            <ItemTemplate>
                                <asp:TextBox runat="server" Width="98%" ID="tbxTableMathScore" CssClass="MathScore"
                                    TabIndex='<%# Container.DataItemIndex + 100 %>' Text='<%# Eval("MathScore") %>'></asp:TextBox>
                            </ItemTemplate>
                        </f:TemplateField>
                        <f:TemplateField HeaderText="总成绩" ColumnID="TotalScore" Width="80px">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" CssClass="TotalScore" Text='<%# Eval("TotalScore") %>'></asp:Label>
                            </ItemTemplate>
                        </f:TemplateField>
                        <f:BoundField Width="100px" ColumnID="Desc" DataField="Desc" HtmlEncode="false" HeaderText="描述" Hidden="true" />
                    </Columns>
                </f:Grid>
                <f:SimpleForm ID="SimpleForm1" runat="server" Width="300px" LabelAlign="Left" LabelWidth="100px" EnableCollapse="true"
                    Title="详细信息" BodyPadding="5px 10px">
                    <Items>
                        <f:Label runat="server" ID="labName" Label="姓名" Text="">
                        </f:Label>
                        <f:Label runat="server" ID="labGender" Label="性别" Text="">
                        </f:Label>
                        <f:Label runat="server" ID="labEntranceYear" Label="入学年份" Text="">
                        </f:Label>
                        <f:Label runat="server" ID="labAtSchool" Label="是否在校" Text="">
                        </f:Label>
                        <f:Label runat="server" ID="labMajor" Label="所学专业" Text="">
                        </f:Label>
                        <f:Label runat="server" ID="labDesc" Label="个人简介" Text="">
                        </f:Label>
                        <f:Label runat="server" ID="labChineseScore" Label="语文成绩" Text="">
                        </f:Label>
                        <f:Label runat="server" ID="labMathScore" Label="数学成绩" Text="">
                        </f:Label>
                        <f:Label runat="server" ID="labTotalScore" Label="总成绩" Text="">
                        </f:Label>
                    </Items>
                </f:SimpleForm>
            </Items>
        </f:Panel>
    </form>
    <script type="text/javascript">
        var gridClientID = '<%= Grid1.ClientID %>';
        var formClientID = '<%= SimpleForm1.ClientID %>';
        var inputselector = '.f-grid-tpl input';

        function getScore(row, selector) {
            if (typeof (row) === 'number') {
                row = $('#' + gridClientID).find('.f-grid-row:eq(' + row + ')');
            }
            var el = row.find(selector);
            var num = 0;
            if (el.is('input')) {
                num = el.val();
            } else {
                num = el.text();
            }
            num = parseInt(num, 10);
            if (isNaN(num)) {
                num = 0;
            }
            return num;
        }

        function getChineseScore(row) {
            return getScore(row, inputselector + '.ChineseScore');
        }

        function getMathScore(row) {
            return getScore(row, inputselector + '.MathScore');
        }

        function getTotalScore(row) {
            return getScore(row, '.f-grid-tpl span.TotalScore');
        }

        function updateDetailScore(index) {
            // F.noLayout中不进行布局，后面需要手工进行布局
            F.noLayout(function () {
                F('<%= labChineseScore.ClientID %>').setValue(getChineseScore(index));
                F('<%= labMathScore.ClientID %>').setValue(getMathScore(index));
                F('<%= labTotalScore.ClientID %>').setValue(getTotalScore(index));
            });
        }

        function doUpdateDetail(inputNode) {
            inputNode = $(inputNode);

            var row = inputNode.parents('.f-grid-row');
            var num1 = getChineseScore(row);
            var num2 = getMathScore(row);
            var resultNode = row.find('.f-grid-tpl span.TotalScore');

            resultNode.text(num1 + num2);

            updateDetailScore(row.index());

            F(formClientID).doLayout();

        }

        function registerAutoSaveEvent() {
            var grid = F(gridClientID);


            grid.el.on('input', inputselector, function (evt) {
                doUpdateDetail(this);
            });


            // IE8特殊处理：没有 input 事件，同时 propertychange 事件无法使用 delegated 的方式，必须使用直接绑定
            if (F.isIE8()) {

                function registerPropertyChangeEvent() {
                    var inputs = grid.el.find(inputselector);
                    inputs.off('propertychange');
                    inputs.on('propertychange', function (evt) {
                        doUpdateDetail(this);
                    });
                }

                grid.on('dataload', function () {
                    registerPropertyChangeEvent();
                });

                registerPropertyChangeEvent();
            }

        }

        function registerRowSelectEvent() {
            var grid = F(gridClientID);

            grid.on('rowselect', function (event, index) {
                var rowValue = grid.getRowValue(index);

                // F.noLayout中不进行布局，后面需要手工进行布局
                F.noLayout(function () {
                    F('<%= labName.ClientID %>').setValue(rowValue['Name']);
                    F('<%= labGender.ClientID %>').setValue(rowValue['Gender']);
                    F('<%= labEntranceYear.ClientID %>').setValue(rowValue['EntranceYear']);
                    F('<%= labAtSchool.ClientID %>').setValue(rowValue['AtSchool']);
                    F('<%= labMajor.ClientID %>').setValue(rowValue['Major']);
                    F('<%= labDesc.ClientID %>').setValue(rowValue['Desc']);

                });

                updateDetailScore(index);

                F(formClientID).doLayout();

            });
        }


        var hideAutoSaveMessageTimer = null;
        function showAutoSaveSuccessMessage(msg) {

            // 如果正在准备5s消失，则取消此动作
            if (hideAutoSaveMessageTimer) {
                window.clearTimeout(hideAutoSaveMessageTimer);
                hideAutoSaveMessageTimer = null;
            }

            var msgNode = $('#autosave_success_node');
            if (!msgNode.length) {
                msgNode = $('<div>', {
                    id: 'autosave_success_node',
                    'class': 'f-ajax-loading'
                }).appendTo(document.body);
            }
            msgNode.text(msg);
            msgNode.css('left', ($(document.body).width() - msgNode.outerWidth(true)) / 2);
            msgNode.show();

            // 显示自动保存提示信息5s，然后消失
            hideAutoSaveMessageTimer = window.setTimeout(function () {
                msgNode.hide();
            }, 5000);
        }

        // 页面第一次加载完成后调用的函数
        F.ready(function () {
            registerAutoSaveEvent();
            registerRowSelectEvent();

            // 30秒自动保存一次
            window.setInterval(function () {
                F.customEvent('AutoSave');
            }, 1000 * 30);
        });

    </script>
</body>
</html>

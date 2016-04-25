<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="grid_checkboxfield_rowcheckall_contextmenu.aspx.cs"
    Inherits="FineUIPro.Examples.grid.grid_checkboxfield_rowcheckall_contextmenu" %>

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
        <f:Grid ID="Grid1" Title="表格" EnableCollapse="true" Width="800px" ShowBorder="true" ShowHeader="true"
            runat="server" DataKeyNames="Id,Name">
            <Columns>
                <f:RowNumberField />
                <f:BoundField Width="100px" ExpandUnusedSpace="true" DataField="Name" DataFormatString="{0}"
                    HeaderText="姓名" />
                <f:TemplateField Width="80px" HeaderText="性别">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# GetGender(Eval("Gender")) %>'></asp:Label>
                    </ItemTemplate>
                </f:TemplateField>
                <f:BoundField Width="100px" DataField="EntranceYear" HeaderText="入学年份" />
                <f:CheckBoxField Width="80px" RenderAsStaticField="true" DataField="AtSchool" HeaderText="是否在校1" />
                <f:CheckBoxField ColumnID="CheckBoxField1" Width="100px" RenderAsStaticField="false"
                    DataField="AtSchool" HeaderText="是否在校1" />
                <f:CheckBoxField ColumnID="CheckBoxField2" Width="100px" RenderAsStaticField="false"
                    DataField="AtSchool" HeaderText="是否在校2" />
                <f:CheckBoxField ColumnID="CheckBoxField3" Width="100px" RenderAsStaticField="false"
                    DataField="AtSchool" HeaderText="是否在校3" />
            </Columns>
            <Listeners>
                <f:Listener Event="beforerowcontextmenu" Handler="onRowContextMenu" />
            </Listeners>
        </f:Grid>
        <f:Menu ID="Menu1" runat="server">
            <f:MenuButton ID="btnSelectRows" EnablePostBack="false" runat="server" Text="全选行">
                <Listeners>
                    <f:Listener Event="click" Handler="onSelectRows" />
                </Listeners>
            </f:MenuButton>
            <f:MenuButton ID="btnUnselectRows" EnablePostBack="false" runat="server" Text="取消行">
                 <Listeners>
                    <f:Listener Event="click" Handler="onUnselectRows" />
                </Listeners>
            </f:MenuButton>
        </f:Menu>
        <br />
        选中一些行，然后点击鼠标右键。
        <br />
        <br />
        <f:Button ID="Button1" runat="server" Text="选中行复选框的状态" OnClick="Button1_Click">
        </f:Button>
        <br />
        <f:Label ID="labResult" EncodeText="false" runat="server">
        </f:Label>
    </form>

    <script>

        var menuID = '<%= Menu1.ClientID %>';

        // 返回false，来阻止浏览器右键菜单
        function onRowContextMenu(event, rowIndex) {
            F(menuID).show();  //showAt(event.pageX, event.pageY);
            return false;
        }

        function onSelectRows() {
            $('.f-grid-row-selected .f-grid-checkbox').addClass('checked');
        }

        function onUnselectRows() {
            $('.f-grid-row-selected .f-grid-checkbox').removeClass('checked');
        }

    </script>
</body>
</html>

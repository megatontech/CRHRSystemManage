<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="email.aspx.cs" Inherits="FineUIPro.Examples.autocomplete.email" %>

<!DOCTYPE html>
<html>
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../res/css/main.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../res/jqueryuiautocomplete/jquery-ui.min.css" />
    <style>
        .ui-autocomplete {
            border-width: 1px;
            border-style: solid;
        }
        .ui-menu-item.ui-state-focus {
            border-width: 1px;
            border-style: solid;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" />
        <f:SimpleForm ID="SimpleForm1" runat="server" Width="600px" BodyPadding="5px"  EnableCollapse="true"
            Title="简单表单">
            <Items>
                <f:TextBox ID="TextBox1" runat="server" ShowLabel="false" EmptyText="随便输入个字母试试">
                </f:TextBox>
            </Items>
        </f:SimpleForm>
    </form>
    
    <script src="../res/jqueryuiautocomplete/jquery-ui.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        var textbox1ID = '<%= TextBox1.ClientID %>';

        F.ready(function () {
            
            var availableTags = [
                "qq.com",
                "163.com",
                "gmail.com",
                "outlook.com",
                "126.com",
                "sina.com",
                "yahoo.com",
                "sohu.com",
                "foxmail.com",
                "live.com",
                "mail.ustc.edu.cn"];


            function getFullEmails(name) {
                var emails = [];
                for (var i = 0, count = availableTags.length; i < count; i++) {
                    emails.push(name + "@" + availableTags[i]);
                }
                return emails;
            }

            $('#' + textbox1ID + ' input').autocomplete({
                source: function (request, response) {
                    if (request.term.indexOf('@') === -1) {
                        response(getFullEmails(request.term));
                    }
                }
            });

        });

    </script>
</body>
</html>

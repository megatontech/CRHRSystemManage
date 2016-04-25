<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeBehind="test.aspx.cs"
    Inherits="FineUIPro.Examples.test.test" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" />
        <f:Window ID="Window2" Width="650px" Height="300px" Icon="TagBlue" Title="窗体" 
            EnableMaximize="true" EnableCollapse="true" runat="server" EnableResize="true" Layout="Fit"
            IsModal="false" CloseAction="HidePostBack"  AutoScroll="true" BodyPadding="10px">
            <Items>
                <f:TabStrip ID="TabStrip1" Width="850px" Height="350px" ShowBorder="true" TabPosition="Top"
                    EnableTabCloseMenu="false" ActiveTabIndex="0"
                    runat="server">
                    <Tabs>
                        <f:Tab ID="Tab2" Title="<span class='highlight'>标签二（高亮）</span>" BodyPadding="5px"
                            runat="server">
                            <Items>
                                <f:Button ID="Button1" Text="点击显示提示对话框" runat="server">
                                </f:Button>
                            </Items>
                        </f:Tab>
                        <f:Tab ID="Tab3" Title="标签三" BodyPadding="5px" runat="server">
                            <Items>
                                <f:Label ID="Label3" CssClass="highlight" Text="第三个标签的内容（已经应用了高亮样式）" runat="server" />
                            </Items>
                        </f:Tab>
                    </Tabs>
                </f:TabStrip>
            </Items>
        </f:Window>

         <f:ContentPanel ID="Panel133" runat="server">
            <f:TextBox runat="server" ID="tbxPassword" Label="密码" TextMode="Password" Required="true">
            </f:TextBox>
        </f:ContentPanel>
        <f:Button ID="Button2" runat="server" ValidateForms="Panel133" ></f:Button>
    </form>
</body>
</html>

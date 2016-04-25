<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="form_update_label.aspx.cs"
    Inherits="FineUIPro.Examples.form.form_update_label" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../res/css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="_form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" />
        <f:Form Width="600px" LabelWidth="100px" BodyPadding="5px" EnableCollapse="true"
            ID="Form2" runat="server" Title="表单">
            <Rows>
                <f:FormRow>
                    <Items>
                        <f:Label ID="labTitle" Label="标题" HideMode="Display" Text="申请单" runat="server" />
                        <f:Label ID="labLiuShuiHao" Label="流水号" HideMode="Visibility" Text="123456789" runat="server" />
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:Label ID="labPhone" Label="固定电话" Text="0551-1234567" runat="server" />
                        <f:Label ID="Label16" runat="server" Label="申请人" Text="admin">
                        </f:Label>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:Label ID="Label4" Label="编号" Text="200804170006" runat="server" />
                        <f:TextBox ID="tbxEmail" Required="true" ShowRedStar="true" Label="电子邮箱" EmptyText="请输入常用电子邮箱" RegexPattern="EMAIL"
                            RegexMessage="请输入有效的邮箱地址！" runat="server">
                        </f:TextBox>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:DropDownList ID="DropDownList3" Label="审批人" Required="true" EmptyText="请选择审批人" runat="server" ShowRedStar="True" AutoSelectFirstItem="false">
                            <f:ListItem Text="老大甲" Value="0"></f:ListItem>
                            <f:ListItem Text="老大乙" Value="1"></f:ListItem>
                            <f:ListItem Text="老大丙" Value="2"></f:ListItem>
                        </f:DropDownList>
                        <f:DatePicker runat="server" Required="true" Label="审批时间" EmptyText="请输入审批时间" ID="dpApplyTime" ShowRedStar="True" DateFormatString="yyyy-MM-dd">
                        </f:DatePicker>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:NumberBox ID="nbxApplyNumber" Label="申请数量" EmptyText="请输入申请数量" MaxValue="100" Required="true" runat="server"
                            ShowRedStar="True" />
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:TextArea ID="taDescription" runat="server" Label="描述" ShowRedStar="True" Required="True" MinLength="5">
                        </f:TextArea>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:Panel ID="Panel2" runat="server" ShowBorder="false"
                            ShowHeader="false">
                            <Items>
                                <f:Button ID="btnSubmitForm2" Text="验证表单并提交" CssClass="marginr" runat="server" OnClick="btnSubmitForm2_Click"
                                    ValidateForms="Form2">
                                </f:Button>
                            </Items>
                        </f:Panel>
                    </Items>
                </f:FormRow>
            </Rows>
        </f:Form>
        <br />
        <f:Button ID="btnUpdateLabel" Text="更新[固定电话]标签" CssClass="marginr" runat="server" OnClick="btnUpdateLabel_Click">
        </f:Button>
        <br />
        <br />
        <f:Button ID="btnRemoveRequired" Text="去除[电子邮箱]必填项" CssClass="marginr" runat="server" OnClick="btnRemoveRequired_Click">
        </f:Button>
        <f:Button ID="btnRemoveRegex" Text="去除[电子邮箱]的正则表达式验证" CssClass="marginr" runat="server" OnClick="btnRemoveRegex_Click">
        </f:Button>
        <br />
        <br />
        <f:Button ID="btnRemoveMinLength" Text="去除[描述]的最少5个字符限制" CssClass="marginr" runat="server" OnClick="btnRemoveMinLength_Click">
        </f:Button>
        <br />
        <br />
        <f:Button ID="btnRemoveValue" Text="将[申请数量]的最大值100改为10" CssClass="marginr" runat="server" OnClick="btnRemoveValue_Click">
        </f:Button>
         <br />
        <br />
        <f:Button ID="btnModifyMinDate" Text="限制[审批时间]的最大时间为今天" CssClass="marginr" runat="server" OnClick="btnModifyMinDate_Click">
        </f:Button>
        <br />
        <br />
    </form>
</body>
</html>

<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="UserInfoManage.aspx.cs" Inherits="PersonManage_UserInfoManage"
    Title="自动办公系统 | 用户编辑" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphOffice" runat="Server">

    <script type="text/javascript">
    function CheckImg(fileUpload)
    {
        var mime=fileUpload.value;
        mime=mime.toLowerCase().substr(mime.lastIndexOf("."));
        if(mime!=".jpg")
        {
            fileUpload.value="";
            alert("仅支持JPG格式！");
        }
        else
        {
            var imags=document.getElementsByTagName("img");
            for(i=0;i<imags.length;i++)
            {
                if(imags[i].name=='imgFace')
                {
                    imags[i].src=fileUpload.value;
                }
            }
        }
    }
    
    </script>

    <div style="font-size: 11pt; width: 700px; height: 100px; text-align: center">
        <div style="width: 100%; text-align: center">
            <br />
            &nbsp;
            <br />
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" Text=" 保 存 用 户 &nbsp;信 息"></asp:Label>
            <hr />
        </div>      <asp:UpdatePanel id="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <contenttemplate>
        <table style="border-right: 1px; border-top: 1px; font-size: 11pt; border-left: 1px;
            width: 644px; border-bottom: 1px; height: 387px; text-align: center">
            <tbody>
                <tr>
                    <td style="height: 25px; text-align: center">
                        所在 机构：</td>
                    <td style="width: 337px; height: 25px; text-align: left">
                        &nbsp;<asp:DropDownList ID="ddlBranchs" runat="server"  OnSelectedIndexChanged="ddlBranchs_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>
                      
                    </td>
                    <td style="height: 25px; text-align: left">
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        所在 部门：</td>
                    <td style="width: 337px; text-align: left">
                        &nbsp;<asp:DropDownList ID="ddlDepart" runat="server" Width="121px">
                        </asp:DropDownList>
                       
                    </td>
                    <td style="text-align: left">
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        用户登陆名：</td>
                    <td style="width: 337px; text-align: left">
                        &nbsp;<asp:TextBox ID="txtLoginId" runat="server" CssClass="inputCss" ></asp:TextBox></td>
                    <td style="text-align: left">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                            ControlToValidate="txtLoginId">*</asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td style="height: 23px; text-align: center">
                        密&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;码：</td>
                    <td style="width: 337px; height: 23px; text-align: left">
                        &nbsp;<asp:TextBox ID="txtPassword" runat="server" CausesValidation="True" CssClass="inputCss"
                            TextMode="Password"></asp:TextBox></td>
                    <td style="height: 23px; text-align: left">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                            ControlToValidate="txtPassword">*</asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td style="height: 23px; text-align: center">
                        确认 密码：</td>
                    <td style="width: 337px; height: 23px; text-align: left">
                        &nbsp;<asp:TextBox ID="txtPasswordOk" runat="server" CssClass="inputCss" TextMode="Password"></asp:TextBox></td>
                    <td style="height: 23px; text-align: left">
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="密码不一致"
                            ControlToValidate="txtPasswordOk" ControlToCompare="txtPassword">密码不一致</asp:CompareValidator></td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        真实 姓名：</td>
                    <td style="width: 337px; text-align: left">
                        &nbsp;<asp:TextBox ID="txtUserName" runat="server" CssClass="inputCss" ></asp:TextBox></td>
                    <td style="text-align: left">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                            ControlToValidate="txtUserName">*</asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        性 &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;别：</td>
                    <td style="width: 337px; text-align: left">
                        &nbsp;<asp:RadioButtonList ID="rblGender" runat="server" Width="112px" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1" Selected="True">男</asp:ListItem>
                            <asp:ListItem Value="0">女</asp:ListItem>
                        </asp:RadioButtonList></td>
                    <td style="text-align: left">
                    </td>
                </tr>
                <tr>
                    <td style="height: 127px; text-align: center">
                        <asp:Image ID="imgFace" runat="server" Height="100px" Width="100px" 
                            name="imgFace"></asp:Image></td>
                    <td style="width: 337px; height: 127px; text-align: left">
                        <asp:FileUpload ID="fuFace" runat="server" Width="260px" CssClass="buttonCss" onchange="CheckImg(this)">
                        </asp:FileUpload></td>
                    <td style="height: 127px; text-align: left">
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                    </td>
                    <td style="width: 337px; text-align: left">
                    </td>
                    <td style="text-align: left">
                    </td>
                </tr>
                <tr>
                    <td style="height: 23px; text-align: center">
                        角 &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; 色：</td>
                    <td style="width: 337px; height: 23px; text-align: left">
                        &nbsp;<asp:DropDownList ID="ddlRole" runat="server">
                        </asp:DropDownList></td>
                    <td style="height: 23px; text-align: left">
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        当前 状态：</td>
                    <td style="width: 337px; text-align: left">
                        &nbsp;<asp:DropDownList ID="ddlState" runat="server" >
                        </asp:DropDownList></td>
                    <td style="text-align: left">
                    </td>
                </tr>
                <tr>
                    <td style="height: 36px">
                        <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" Text="保存" CssClass="buttonCss">
                        </asp:Button></td>
                    <td style="width: 337px; height: 36px; text-align: center">
                        &nbsp;<asp:Button ID="btnReBuild" OnClick="btnReBuild_Click" runat="server" CausesValidation="False"
                            Text="全部重写" CssClass="buttonCss"></asp:Button></td>
                    <td style="height: 36px; text-align: left">
                        <asp:Button ID="btnBack" OnClick="btnBack_Click" runat="server" CausesValidation="False"
                            Text="返回" CssClass="buttonCss"></asp:Button></td>
                </tr>
            </tbody>
        </table>
        </contenttemplate>
        <triggers>
          
<asp:PostBackTrigger ControlID="btnSave"></asp:PostBackTrigger>
</triggers>
        </asp:UpdatePanel>
    </div>
</asp:Content>

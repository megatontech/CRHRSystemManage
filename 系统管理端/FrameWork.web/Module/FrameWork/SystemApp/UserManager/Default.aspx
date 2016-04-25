﻿<%@ Page Language="C#" MasterPageFile="~/MasterPage/PageTemplate.Master" AutoEventWireup="true"
    Codebehind="Default.aspx.cs" Inherits="FrameWork.web.Module.FrameWork.UserManager.Default"
    %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <link rel="stylesheet" type="text/css" href="<%=Page.ResolveUrl("~/") %>inc/FineMessBox/css/subModal.css" />

    <script type="text/javascript" src="<%=Page.ResolveUrl("~/") %>inc/FineMessBox/js/common.js"></script>

    <script type="text/javascript" src="<%=Page.ResolveUrl("~/") %>inc/FineMessBox/js/subModal.js"></script>

    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"
        ButtonList-Capacity="4" HeadOPTxt="用户资料列表" HeadTitleTxt="用户资料管理" HeadHelpTxt="点击用户名进入用户管理">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="New" ButtonUrlType="Href"
            ButtonVisible="True" ButtonUrl="UserManager.aspx?CMD=New" ButtonName="用户" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="用户资料列表">
            <asp:GridView ID="GridView1" runat="server">
                <Columns>
                    <asp:BoundField HeaderText="员工编号" DataField="U_UserNO" />
                    <asp:HyperLinkField HeaderText="用户名" DataTextField="U_LoginName" DataNavigateUrlFields="UserID"
                        DataNavigateUrlFormatString="UserManager.aspx?UserID={0}&CMD=List" />
                    <asp:BoundField HeaderText="中文名" DataField="U_CName" />
                    <asp:TemplateField HeaderText="部门">
                        <ItemTemplate>
                            <%#Get_U_GroupID((int)Eval("U_GroupID")) %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="到职日期" DataField="U_WorkStartDate" DataFormatString="{0:yyyy/MM/dd}"
                        HtmlEncode="false" />
                    <asp:TemplateField HeaderText="用户类型">
                        <ItemTemplate>
                            <%#Get_U_Type((int)Eval("U_Type")) %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="用户状态">
                        <ItemTemplate>
                            <%#GetStat((int)Eval("U_Status"))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <FrameWorkWebControls:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_PageChanged">
            </FrameWorkWebControls:AspNetPager>
        </FrameWorkWebControls:TabOptionItem>
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem2" runat="server" Tab_Name="查询">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
                <tr>
                    <td class="table_body table_body_NoWidth">
                        用户名</td>
                    <td class="table_none table_none_NoWidth">
                        <asp:TextBox ID="U_LoginName" runat="server" CssClass="text_input"></asp:TextBox></td>
                    <td class="table_body table_body_NoWidth">
                        部门</td>
                    <td class="table_none table_none_NoWidth">
                        <input type="hidden" runat="server" name="U_GroupID" id="U_GroupID" value=""><input
                            runat="server" name="U_GroupID_Txt" id="U_GroupID_Txt" size="15" value="" class="text_input"
                            readonly>
                        <input type="button" value="选择部门" id="button3" name="buttonselect" onclick="javascript:ShowDepartID()"
                            class="cbutton">
                        <input type="button" value="清除" onclick="javascript:ClearSelect();" class="cbutton" />
                    </td>
                </tr>
                <tr>
                    <td class="table_body table_body_NoWidth">
                        中文名</td>
                    <td class="table_none table_none_NoWidth">
                        <asp:TextBox ID="U_CName" runat="server" CssClass="text_input"></asp:TextBox></td>
                    <td class="table_body table_body_NoWidth">
                        员工编号</td>
                    <td class="table_none table_none_NoWidth">
                        <asp:TextBox ID="U_UserNO" runat="server" CssClass="text_input"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="table_body table_body_NoWidth">
                        用户类型</td>
                    <td class="table_none table_none_NoWidth">
                        <asp:DropDownList ID="U_Type" runat="server">
                            <asp:ListItem Value="">不限</asp:ListItem>
                            <asp:ListItem Value="1">普通用户</asp:ListItem>
                            <asp:ListItem Value="0">超级用户</asp:ListItem>
                        </asp:DropDownList></td>
                    <td class="table_body table_body_NoWidth">
                        用户状态</td>
                    <td class="table_none table_none_NoWidth">
                        <asp:DropDownList ID="U_Status" runat="server">
                            <asp:ListItem Value="">不限</asp:ListItem>
                            <asp:ListItem Value="0">正常</asp:ListItem>
                            <asp:ListItem Value="1">停用</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td colspan="4" align="right">
                        <asp:Button ID="Button1" runat="server" CssClass="button_bak" Text="查询" OnClick="Button1_Click" /></td>
                </tr>
            </table>
        </FrameWorkWebControls:TabOptionItem>
    </FrameWorkWebControls:TabOptionWebControls>

    <script language="javascript">
        rnd.today=new Date(); 

    rnd.seed=rnd.today.getTime(); 

    function rnd() { 

　　　　rnd.seed = (rnd.seed*9301+49297) % 233280; 

　　　　return rnd.seed/(233280.0); 

    }; 

    function rand(number) { 

　　　　return Math.ceil(rnd()*number); 

    }; 
    
function AlertMessageBox(file_name)
    {

       	        if (file_name!=undefined){
	            var ShValues = file_name.split('||');
	            if (ShValues[1]!=0)
	            {
	                document.all.<%=U_GroupID_Txt_ID %>.value=ShValues[0];
	                document.all.<%=U_GroupID_ID %>.value=ShValues[1];
	            }
	        }
	         
    }
      function ShowDepartID()
        {
            showPopWin('选择部门','SelectGroup.aspx?'+rand(10000000), 215, 255, AlertMessageBox,true,true)
        }
        function ClearSelect()
        {
   	        document.all.<%=U_GroupID_Txt_ID %>.value="";
            document.all.<%=U_GroupID_ID %>.value="";
        }
    </script>

</asp:Content>

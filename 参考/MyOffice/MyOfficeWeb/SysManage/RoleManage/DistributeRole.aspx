<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="DistributeRole.aspx.cs" Inherits="SysManage_RoleManage_DistributeRole"
    Title="自动办公系统 | 分配权限" %>

<%@ Register Src="~/SysManage/RoleManage/RoleUserControl.ascx" TagName="RoleUserControl" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphOffice" runat="Server">
     <script type="text/javascript">
     function CheckAll(paramId)
     {
       var items=document.getElementsByTagName("input");
 
       for(i=0;i<items.length;i++)
       {
         var e=items[i];
         var eId=e.id;
         var m=eId.indexOf('_chk');
        
         var n=paramId.indexOf('_chk');
         if(eId.substring(0,m)==paramId.substring(0,n) && e.type=='checkbox')
         {
           e.checked=document.getElementById(paramId).checked;
         }
       }
     }
     
    function CheckOnly(paramId)
    {
      var items=document.getElementsByTagName("input");
       for(i=0;i<items.length;i++)
       {
         var e=items[i];
         var eId=e.id;
         var m=eId.indexOf('_chk');
         var n=paramId.indexOf('_chk');
         if(eId.substring(0,m)==paramId.substring(0,n) && e.type=='checkbox')
         {
           if(eId.indexOf('chkParentMenu')!=-1)
             {
                document.getElementById(eId).checked=true;
            }
         }
       }
    }
     </script><br />
   <div style="background-color:#DAF1FC" align="center"> 
   <div style="width:99%;height:30px; text-align:left;">当前位置：分配角色权限</div>
<div style=" float:left;width:99%;background-color:#66CCFF; height:30px;"><b>分配角色权限</b></div>
<div style="width:99%;background-color:#B4E5FD; text-align:left"> &nbsp;权限分配<font color="red">(选定后保存)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font><strong>当前角色 -&gt;</strong><asp:label id="lblCurrentRole" runat="server" Font-Bold="True" Width="125px"></asp:label></div>  
<div style="width:99%;background-color:#B4E5FD">
<div style="width:2%; float:left"></div>
<div style="width:97%;text-align:left;float:left">
<asp:Panel ID="phRoleDistribute" runat="server" EnableViewState="true"></asp:Panel>
</div>
</div>        
   <br/>  
		<br/>   
		<div >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
	<input id="btnSave" type="submit" runat="server" value="提交" class="buttonCss" style="width: 74px; cursor: hand; height: 20px;" onserverclick="btnSave_ServerClick"/>
	&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
	<input id="btnRet" type="submit" runat="server" value="返回" class="buttonCss"  style="width: 74px; cursor: hand; height: 19px;" onserverclick="btnRet_ServerClick"/>	
       </div>	
           
   </div>
</asp:Content>

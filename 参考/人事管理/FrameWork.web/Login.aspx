<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FrameWork.web.Login" %>
<html>
<head>
<link rel="stylesheet" href="css/Site_Css.css" type="text/css"/>
<script language="javascript" src="js/checkform.js"></script>
<title><%=FrameName %></title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
</head>

<body scroll="no" leftMargin="0" topMargin="0" marginheight="0" marginwidth="0">

<table border="0" cellspacing="0" cellpadding="0" width="100%" height="100%">
<tr> 
    <td width="100%" height="50" colspan="3" style="border-bottom: 1px solid #000000">
			<table height="49" border="0" cellspacing="0" cellpadding="0" width="100%" class="font_size">
              <tr> 

			  <td  style="background-image: url(images/top-gray.gif); background-repeat: no-repeat; background-position: right top" >
			  			  <b><%=FrameName %></b><br/>
			<font size="2" color="#999999" face="Verdana, Arial, Helvetica, sans-serif"><%=FrameNameVer %></font>			  

			  </td>
			  </tr>
		   </table>
    </td>

  </tr>
 
  <tr> 
    <td colspan="3"> 

	
<table width="100%" border="0" cellspacing="0" cellpadding="0" height="100%">
  <form name="login" method="post" runat="server" DefaultFocus="LoginName" onsubmit="javascript:return checkForm(this)">
  <tr>
    <td>
	<TABLE WIDTH="431" BORDER="0" CELLPADDING="0" CELLSPACING="0" align="center">
		<TR>
			<TD COLSPAN="2" background="images/Logon/Logon_1.gif" width="431" height="125">
			

	

			</TD>
		</TR>
		<TR>
			<TD COLSPAN="2"><IMG SRC="images/Logon/Logon_2.gif" WIDTH="431" HEIGHT="30" ALT=""/></TD>
		</TR>
		<TR>
			<TD><IMG SRC="images/Logon/Logon_3.gif" WIDTH="194" HEIGHT="28" ALT=""/></TD>
			<TD background="images/Logon/Logon_4.gif" width="237"><asp:TextBox ID="LoginName"  class="text_input" title="请输入帐号~!" runat="server" style="width:138px;"></asp:TextBox></TD>
		</TR>
		<TR>
			<TD><IMG SRC="images/Logon/Logon_5.gif" WIDTH="194" HEIGHT="24" ALT=""/></TD>
			<TD background="images/Logon/Logon_6.gif"><asp:TextBox ID="LoginPass" runat="server" class="text_input" title="请输入密码~!" TextMode="Password" style="width:138px;"></asp:TextBox></TD>
		</TR>
		<TR>
			<TD><IMG SRC="images/Logon/Logon_7.gif" WIDTH="194" HEIGHT="25" ALT=""/></TD>
			<TD background="images/Logon/Logon_8.gif">
			
                <asp:TextBox ID="code_op" class="text_input" runat="server" Columns="4" title="请输入验证码~4:!"></asp:TextBox>请输入<img src="" onload="javascript:Open_Submit();" id="ImageCheck" align="absmiddle" style="cursor:pointer" width="45" height="20"onclick="javascript:ChangeCodeImg();" title="点击更换验证码图片!"/>
			</TD>
		</TR>
		<TR>
			<TD><IMG SRC="images/Logon/Logon_9.gif" WIDTH="194" HEIGHT="40" ALT=""/></TD>
			<TD background="images/Logon/Logon_10.gif">
                
                <asp:Button ID="Button1" disabled="disabled" runat="server" Text="确定" class="button_bak" OnClick="Button1_Click"/>
                <input type="reset"  value="重填" class="button_bak"/></TD>
		</TR>
		<TR>
			<TD COLSPAN="2"><IMG SRC="images/Logon/Logon_11.gif" WIDTH="431" HEIGHT="39" ALT=""/></TD>
		</TR>
		          <TR>
            <TD COLSPAN="2" ><b>提醒 : </b>本管理系统建议议采用Internet Explorer 5.5 (或以上版本) 的浏览器。请开启浏览器的 Cookies 与 JavaScript 功能。</TD>
          </TR>
	</TABLE>	
		
    </td>
  </tr>
</form>
</table>	
	
	
    </td>
  </tr>
  <tr>
  <td colspan="3" height="20">
	<table border="0" cellpadding="0" cellspacing="0" width="100%" height="20">
      <tr>
        <td class="down_text">Powered By <a href="http://www.supesoft.com" target="_blank"><font color="#ffffff">Supesoft.com</font></a> Information Technology Logistics Inc.</td>
  
 
      </tr>
      </table>	  
  </td>
  </tr>
</table>

</body>
</html>

<script language="JavaScript" type="text/javascript"><!-- 

    // The Central Randomizer 1.3 (C) 1997 by Paul Houle (houle@msc.cornell.edu) 

    // See: http://www.msc.cornell.edu/~houle/javascript/randomizer.html 

    rnd.today=new Date(); 

    rnd.seed=rnd.today.getTime(); 

    function rnd() { 

　　　　rnd.seed = (rnd.seed*9301+49297) % 233280; 

　　　　return rnd.seed/(233280.0); 

    }; 

    function rand(number) { 

　　　　return Math.ceil(rnd()*number); 

    }; 

    // end central randomizer. --> 

    </script>
<script language="javascript" type="text/javascript">
    ChangeCodeImg();
    function ChangeCodeImg()
    {
             a = document.getElementById("ImageCheck");
             a.src = "inc/CodeImg.aspx?"+rand(10000000);
             document.all.Button1.disabled = true;
    }
    
    function Open_Submit()
    {
        document.all.Button1.disabled = "";
    }
    
    if(top!=self)
    {
        top.location.href = "login.aspx";
    }
    //alert(navigator.appVersion);
    if(navigator.appVersion.indexOf("MSIE")   ==   -1   ){   
        //alert("提醒 : 本管理系统建议议采用Internet Explorer 5.5 (或以上版本) 的浏览器。请开启浏览器的 Cookies 与 JavaScript 功能。");   
    }   
    
</script>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="FileSearch.aspx.cs" Inherits="File_FileSearch" Title="文件搜索" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphOffice" runat="Server">

    <script type="text/javascript" language="javascript" src="../My97DatePicker/WdatePicker.js"
        charset="gb2312"></script>

<script type="text/javascript">
    //今天
    function showToDay()
    {
        var Nowdate=new Date();
        M=Number(Nowdate.getMonth())+1//得到月份
        var date= Nowdate.getYear()+"-"+M+"-"+Nowdate.getDate();
        document.getElementById("<%= txtStartDate.ClientID%>").value=date;
        document.getElementById("<%= txtEndDate.ClientID%>").value=date;
    }
    //本周
    function showWeekDay()
    {
        var Nowdate=new Date();
        var WeekFirstDay=new Date(Nowdate-(Nowdate.getDay()-1)*86400000); //本周第一天 
        var WeekLastDay=new Date((WeekFirstDay/1000+6*86400)*1000);//本周最后一天
        M=Number(WeekFirstDay.getMonth())+1//得到月份     
        document.getElementById("<%= txtStartDate.ClientID%>").value=WeekFirstDay.getYear()+"-"+M+"-"+WeekFirstDay.getDate();
        document.getElementById("<%= txtEndDate.ClientID%>").value=WeekLastDay.getYear()+"-"+M+"-"+WeekLastDay.getDate();
    }
    //本月
    function showMonthDay()
    {  
        var Nowdate=new Date();
        var MonthFirstDay=new Date(Nowdate.getYear(),Nowdate.getMonth(),1);//本月第一天
        //本月最后一天
        var MonthNextFirstDay=new Date(Nowdate.getYear(),Nowdate.getMonth()+1,1);
        var MonthLastDay=new Date(MonthNextFirstDay-86400000);
        M=Number(MonthFirstDay.getMonth())+1//得到月份  
        document.getElementById("<%= txtStartDate.ClientID%>").value=MonthFirstDay.getYear()+"-"+M+"-"+MonthFirstDay.getDate();
        document.getElementById("<%= txtEndDate.ClientID%>").value=MonthLastDay.getYear()+"-"+M+"-"+MonthLastDay.getDate();    
    }
</script>


<script type="text/javascript">
    function checkOption()
    {
        var option=document.getElementById("option");
        var divOption=document.getElementById("divOption");
        if(divOption.style.visibility=="hidden")
        {
            option.innerText="搜索选项>>";
            divOption.style.visibility="visible";
        }
        else
        {
            option.innerText="搜索选项<<";
            divOption.style.visibility="hidden";
        }
    }
</script>
    <div style="text-align: center">
        <br />
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" Text="文 件 搜 索"></asp:Label></div>
    <hr style="width: 90%; text-align: center;" size="1" color="gray" />
    <div align="center" style="width: 99%;">
        <div style="width: 22%; float: left;">
            <asp:Panel ID="pnlSearch" runat="server" BorderWidth="1" BorderColor="#6DC7FC">
                <div style="width: 100%; height: 22px; text-align: left; padding-top: 11px;">
                    <asp:Image ID="img1" ImageUrl="~/images/search2.gif" runat="server" />文件搜索
                </div>
                <div style="width: 100%; height: 40px; text-align: left; padding-top: 20px;">
                    根据文件名搜索：<br />
                    <asp:TextBox ID="txtFileName" runat="server"></asp:TextBox>
                </div>
                <div style="width: 100%; height: 40px; text-align: left; padding-top: 20px;">
                    根据附件名搜索：<br />
                    <asp:TextBox ID="txtAccessoryFile" runat="server"></asp:TextBox>
                </div>
                <div style="width: 100%; height: 40px; text-align: left; padding-top: 20px;">
                    根据创建者搜索：<br />
                    <asp:TextBox ID="txtCreateUser" runat="server"></asp:TextBox>
                </div>
                <div style="width: 100%; height: 40px; text-align: left; padding-top: 20px;">
                    <asp:ImageButton ID="imgbtnSearch" runat="server" Width="64" Height="20" ImageUrl="~/images/file/bseach.gif"
                        OnClick="imgbtnSearch_Click"></asp:ImageButton>
                        <a href="FileManage.aspx"><img alt="" src="../images/file/exit.gif" border="0" /></a>
                </div>
                <div style="width: 100%; height: 22px; text-align: left; padding-top: 11px;">
                    <a id="option" href="#" onclick="checkOption()">搜索选项<<</a>
                    <div id="divOption">
                        介于：<asp:TextBox ID="txtStartDate" runat="server" onFocus="new WdatePicker(this,'%Y-%M-%D',true,'default')"
                            CssClass="inputCss" Width="109px"></asp:TextBox><br />
                        ---------<asp:TextBox ID="txtEndDate" runat="server" onFocus="new WdatePicker(this,'%Y-%M-%D',true,'default')"
                            CssClass="inputCss" Width="108px"></asp:TextBox>
                        <asp:CompareValidator ID="cvTime" runat="server" ControlToCompare="txtStartDate"
                            ErrorMessage="结束时间不应小于开始时间" Operator="GreaterThanEqual" ControlToValidate="txtEndDate"
                            Display="Dynamic" Type="Date">*</asp:CompareValidator>
                        <br />
                        <asp:RadioButton ID="radBtnDay" onclick="showToDay()" runat="server" Text="本日" GroupName="time">
                        </asp:RadioButton>
                        <asp:RadioButton ID="radBtnWeek" onclick="showWeekDay()" runat="server" Text="本周"
                            GroupName="time"></asp:RadioButton>
                        <asp:RadioButton ID="radBtnMonth" onclick="showMonthDay()" runat="server" Text="本月"
                            GroupName="time"></asp:RadioButton>
                    </div>
                </div>
            </asp:Panel>
        </div>
        <div style="width: 77%; float: left">
            <asp:GridView ID="gvFilesInfo" Width="96%" runat="server" AutoGenerateColumns="False"
                BorderColor="#66CCFF" BorderWidth="1px" CellPadding="4" OnRowDataBound="gvFilesInfo_RowDataBound"
                OnRowCommand="gvFilesInfo_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="文件名称">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkbtnFileName" runat="server" Text='<%# Eval("FileName") %>'
                                CommandArgument='<%# Eval("Id") %>' CommandName="Detail"></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Wrap="False" />
                        <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="所在文件夹">
                        <ItemStyle HorizontalAlign="Center" Wrap="True" />
                        <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# GetPath(Eval("FilePath")) %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="类型　">
                        <ItemTemplate>
                            <asp:Image ID="imgFileType" Width="16px" Height="16px" runat="server" Text='<%# Eval("FileTyPe.FileTypeName") %>'
                                ImageUrl='<%# Eval("FileType.FileTypeImage") %>' />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Wrap="False" />
                        <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="所有者">
                        <ItemStyle HorizontalAlign="Center" Wrap="False" />
                        <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("FileOwner.UserName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="创建日期">
                        <ItemStyle HorizontalAlign="Center" Wrap="False" />
                        <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("CreateDate") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Panel ID="pnlFileDetail" runat="server" Width="96%" Visible="false">
                <div style="width: 100%; text-align: left">
                    文件名：<asp:Label ID="lblFileName" runat="server"></asp:Label><br />
                    文件路径：<asp:Label ID="lblFilePath" runat="server"></asp:Label><br />
                    备注：<asp:TextBox ID="txtRemark" CssClass="textArea" runat="server" Height="41px" Width="435px"
                        TextMode="MultiLine" ReadOnly="True"></asp:TextBox><br />
                    创建时间：<asp:Label ID="lblCreateDate" runat="server"></asp:Label>
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; 创建者：<asp:Label
                        ID="lblFileOwner" runat="server"></asp:Label>
                </div>
                <hr width="100%" size="1" id="HR1" color="#0000ff">
                <asp:GridView ID="gvAccessoryFileInfo" Width="99%" runat="server" BorderColor="#66CCFF"
                    DataKeyNames="Id" BorderWidth="1px" AutoGenerateColumns="False" PageSize="5"
                    OnRowDataBound="gvAccessoryFileInfo_RowDataBound">
                    <RowStyle HorizontalAlign="Center" />
                    <SelectedRowStyle ForeColor="White" />
                    <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <Columns>
                        <asp:TemplateField HeaderText="名称">
                            <ItemTemplate>
                                <asp:LinkButton ID="lblLinkAccessoryName" runat="server" Text=''></asp:LinkButton>
                                <a href='<%# Eval("AccessoryPath") %>'>
                                    <%# Eval("AccessoryName") %>
                                </a>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Wrap="False" />
                            <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="AccessorySize" HeaderText="大小（KB）">
                            <ItemStyle HorizontalAlign="Center" Wrap="False" />
                            <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="类型">
                            <ItemStyle HorizontalAlign="Center" Wrap="False" />
                            <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("AccessoryType.FileTypeName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="CreateDate" HeaderText="创建日期">
                            <ItemStyle HorizontalAlign="Center" Wrap="False" />
                            <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </asp:Panel>
        </div>
        <asp:Label ID="lblMessage" runat="server"></asp:Label></div>
</asp:Content>

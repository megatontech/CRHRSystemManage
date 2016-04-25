<%@ Page Language="C#" MasterPageFile="~/MasterPage.master"
 enableEventValidation="false" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Title="Untitled Page" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphOffice" Runat="Server">
    <asp:DropDownList ID="ddlBranchs" runat="server">
    </asp:DropDownList>
    <asp:DropDownList ID="ddlDepart" runat="server">
    </asp:DropDownList>
    
    <ajax:CascadingDropDown id="cddBranchs" runat="server" Enabled="True" 
    PromptText="--请选择--" Category="Branch" TargetControlID="ddlBranchs"
     ServicePath="~/WebService/BranchService.asmx" ServiceMethod="GetBranchIf">
    </ajax:CascadingDropDown>
    
    <ajax:CascadingDropDown id="cddDepart" runat="server" Enabled="True" 
    PromptText="--请选择--" Category="Depart" TargetControlID="ddlDepart" 
    ServicePath="~/WebService/BranchService.asmx" 
    ServiceMethod="GetDepart" ParentControlID="ddlBranchs">
    </ajax:CascadingDropDown>
    
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
 

</asp:Content>


<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" validateRequest="false"  EnableViewState="false"
    Inherits="MOD.WebTd.ProgramInfo" Title="Untitled Page" Codebehind="ProgramInfo.aspx.cs" %>
<%@ Register Src="UserControls/UC_ProgramChapter.ascx" TagName="ProgramChapter"  TagPrefix="UC" %>
<%@ Register Src="UserControls/UC_ProgramRemark.ascx" TagName="ProgramRemark"  TagPrefix="UC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div id="position"><a href="Default.aspx"><%=this.GetRes("Info_Home") %></a> - <asp:Label ID="lbPosi" runat="server"></asp:Label></div> 
<div id="banner"><img src="Images/depend/banner.gif" alt="banner" /></div>
<div class="mark">
    <div class="left"><img src="Images/depend/pro_detail.gif" alt=""/></div>
    <div class="right"></div>  
</div>
<table id="prminfo">
    <tr>
    <td class="img">
    <table><tr><td><asp:Literal ID="ltrImg" runat="server"></asp:Literal></td></tr></table></td>
    <td class="info"><table>
    <tr><td colspan="2" class="protitle"><asp:Literal ID="ltrName" runat="server"></asp:Literal></td></tr>
    <tr><td><span class="prolab"><%=this.GetRes("INFO_PROGRAM_VIEW")%>:</span><asp:Literal ID="ltrReadCount" runat="server"></asp:Literal></td>
    <td><span class="prolab"><%=this.GetRes("INFO_PROGRAM_KPBS")%>:</span><asp:Literal ID="ltrKbps" runat="server"></asp:Literal></td></tr>
    <tr><td> <span class="prolab"><%=this.GetRes("INFO_PROGRAM_CLASS")%>:</span><asp:Literal ID="ltrClass" runat="server"></asp:Literal></td>
    <td><span class="prolab"><%=this.GetRes("INFO_PROGRAM_ADDTIME")%>:</span><asp:Literal ID="ltrAddtime" runat="server"></asp:Literal></td></tr>
    <tr><td><span class="prolab"><%=this.GetRes("INFO_PROGRAM_ACTOR_LONG")%>:</span><asp:Literal ID="ltrActor" runat="server"></asp:Literal></td>
    <td><span class="prolab"><%=this.GetRes("INFO_PROGRAM_DIRECTOR_LONG")%>:</span><asp:Literal ID="ltrDirector" runat="server"></asp:Literal></td></tr>
    <tr><td><span class="prolab"><%=this.GetRes("INFO_PROGRAM_LENGTH")%>:</span><asp:Literal ID="ltrTime" runat="server"></asp:Literal></td><td><span class="prolab"><%=this.GetRes("INFO_PROGRAM_POINT")%>:</span><asp:Literal ID="ltrPoint" runat="server"></asp:Literal></td></tr>
    <tr><td colspan="2"><asp:Literal ID="ltrPlay" runat="server"></asp:Literal> &nbsp;&nbsp;<asp:Literal ID="ltrDown" runat="server"></asp:Literal> </td></tr>
    </table></td>
</tr></table>

<asp:Panel ID="pnlPrmIntro" runat="server">
    <div class="mark">
        <div class="left"><img src="Images/depend/pro_info.gif" alt=""/></div>
        <div class="right"></div>  
    </div>    
    <div id="prmintro"><asp:Literal ID="ltrIntro" runat="server"></asp:Literal></div>
</asp:Panel>
<UC:ProgramChapter id="UC_ProgramChapter1" runat="server"/>
<UC:ProgramRemark ID="UC_ProgramRemark1" runat="server" />

</asp:Content>

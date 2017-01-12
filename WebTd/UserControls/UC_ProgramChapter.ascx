<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_ProgramChapter.ascx.cs" Inherits="MOD.WebTd.UserControls.UC_ProgramChater" %>
<asp:Repeater ID="rptChapter" runat="server">
    <HeaderTemplate>
    <div class="mark">
        <div class="left"><img src="Images/depend/pro_chapter_list.gif" alt=""/></div>
        <div class="right"></div>  
    </div>    
    <ul id="chapter">
    </HeaderTemplate>
    <ItemTemplate>
        <li>
        <a href="javascript://" onclick="OpenPlay('<%#MOD.WebUtility.WebHelper.EncryptPid(int.Parse(Eval("pcProgramId").ToString()))%>',<%#Eval("pcOrder")%>,<%#Eval("pcMediaKind") %>);">
        <%# MOD.WebUtility.ProgramHelper.GetChapterName(MOD.WebUtility.WebHelper.HtmlEncode(Eval("PcName").ToString())) %></a> 
        <span class="time">(<%#Eval("nTime") %>)</span>                        
        </li>                        
    </ItemTemplate>
    <FooterTemplate></ul></FooterTemplate>
</asp:Repeater>
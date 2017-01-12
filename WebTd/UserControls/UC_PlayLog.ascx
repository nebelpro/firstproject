<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_PlayLog.ascx.cs" Inherits="MOD.WebTd.UserControls.UC_PlayLog" %>
<div class="ListBar">
    <div class="left"><%=this.GetRes("INFO_PLAY_TIME")%>:
        <input type="text" class="txt" id="txtDateBegin" name="dd" /> - <input type="text" class="txt" id="txtDateEnd" name="dd" />(YYYY-MM-DD)
        <input type="image" id="ibtnSearch" class="ibtn" onclick="user.btnPlayLogQuery(1);" src="Images/depend/btn_search.gif" alt="" />
    </div>
</div> 
<asp:Literal ID="ltrListTop" runat="server"></asp:Literal>  
<asp:Repeater ID="rptList" runat="server">
   <HeaderTemplate>  
   <table><tr>     
    <td class="w1"><%=this.GetRes("INFO_PROGRAM_NAME")%></td>
    <td class="w2"><%=this.GetRes("INFO_PLAY_TIME")%></td>
    <td class="w3"><%=this.GetRes("INFO_CARD_VALUE")%></td> 
    </tr></HeaderTemplate>
	<ItemTemplate><tr>      
        <td class="w1"><a href='ProgramInfo.aspx?pid=<%#Eval("PcpProgramId") %>' target="_blank"><%#Eval("PcpProgramName") %></a></td>
        <td class="w2"><%#Eval("PcpDateTime")%></td>
        <td class="w3"><%#Eval("PcpProgramPoint") %></td>                                       
    </tr></ItemTemplate>	
    <FooterTemplate></table></FooterTemplate>
</asp:Repeater>
<asp:Literal ID="ltrEmpty" runat="server"></asp:Literal>
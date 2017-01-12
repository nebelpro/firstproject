<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_ChargeLog.ascx.cs" Inherits="MOD.WebTd.UserControls.UC_ChargeLog" %>
<div class="ListBar">
    <div class="left"><%=this.GetRes("INFO_CARDUSE_DATE")%>:
        <input type="text" class="txt" id="txtDateBegin" name="dd" /> - <input type="text" class="txt" id="txtDateEnd" name="dd" />(YYYY-MM-DD)
        <input type="image" id="ibtnSearch" class="ibtn" onclick="user.btnChargeQuery(1);" src="Images/depend/btn_search.gif" alt="" />
    </div>
</div> 
<asp:Literal ID="ltrListTop" runat="server"></asp:Literal>  
<asp:Repeater ID="rptCardUse" runat="server">
   <HeaderTemplate>  
   <table><tr>     
    <td class="w1"><%=this.GetRes("Info_CardNo")%></td>
    <td class="w2"><%=this.GetRes("INFO_CARDUSE_DATE")%></td>
    <td class="w3"></td> 
    </tr></HeaderTemplate>
	<ItemTemplate><tr>      
        <td class="w1"><%#Eval("CuNumber") %></td>
        <td class="w2"><%#Eval("CuDateTime")%></td>
        <td class="w3"><%#Eval("CuPointValue") %>(<%#MOD.WebUtility.CardHelper.GetCardUnit((Int32)Eval("CuType"))%>)</td>                                       
    </tr></ItemTemplate>	
    <FooterTemplate></table></FooterTemplate>
</asp:Repeater>
<asp:Literal ID="ltrEmpty" runat="server"></asp:Literal>
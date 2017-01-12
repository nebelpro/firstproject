<%@ Page Language="C#" MasterPageFile="~/UserCenter.Master" AutoEventWireup="true" CodeBehind="ChargeLog.aspx.cs" Inherits="MOD.UI.ChargeLog" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cplUser" runat="server">
<h3><img src="Images/depend/ChargeLog.gif" alt="" /></h3>
<div class="ListBar SearchDate"><%=this.GetRes("INFO_CARDUSE_DATE")%> 
        <asp:TextBox ID="tbDateBegin" CssClass="txt" runat="server"></asp:TextBox> - <asp:TextBox ID="tbDateEnd" CssClass="txt" runat="server"></asp:TextBox>
         <%=this.GetRes("Info_DateFormat")%> <asp:ImageButton ID="ibtnSearchCardUse" Width="51px" Height="23px" ImageUrl="Images/depend/m_button_search.gif"  runat="server" OnClick="ibtnSearchCardUse_Click" />
</div>
<div class="ListBar"><div class="right"><asp:Literal ID="ltrNavBottom" runat="server"></asp:Literal></div></div> 
<asp:Repeater ID="rptCardUse" runat="server">
    <HeaderTemplate><table id="ChargeLog">
        <tr class="hdr">
            <td class="w1"><%=this.GetRes("INFO_CARD_NO")%></td>
            <td class="w2"><%=this.GetRes("INFO_CARDUSE_DATE")%></td>
            <td class="w3"></td>
        </tr>
    </HeaderTemplate>
	<ItemTemplate>
        <tr class="item">      
            <td class="w1"><%#Eval("CuNumber") %></td>
            <td class="w2"><%#Eval("CuDateTime")%></td>
            <td class="w3"><%#Eval("CuPointValue") %>(<%#MOD.WebUtility.CardHelper.GetCardUnit((Int32)Eval("CuType"))%>)</td>                                        
        </tr>
    </ItemTemplate>	
    <AlternatingItemTemplate>
        <tr class="alter">      
            <td class="w1"><%#Eval("CuNumber") %></td>
            <td class="w2"><%#Eval("CuDateTime")%></td>
            <td class="w3"><%#Eval("CuPointValue") %>(<%#MOD.WebUtility.CardHelper.GetCardUnit((Int32)Eval("CuType"))%>)</td>                                        
        </tr>
    </AlternatingItemTemplate>
    <FooterTemplate></table></FooterTemplate>
</asp:Repeater> 
<asp:Literal ID="ltrEmpty" runat="server"></asp:Literal>
</asp:Content>

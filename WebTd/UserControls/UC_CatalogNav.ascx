<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_CatalogNav.ascx.cs" Inherits="MOD.WebTd.UserControls.UC_CatalogNav" %>
<div id="naver"><div class="left"></div><asp:Repeater ID="rptNavBar" runat="server">
<HeaderTemplate><ul id="CatalogNav"></HeaderTemplate>
<ItemTemplate><li <%#SetNavStyle(rptNavBar.Items.Count)%>><a class="<%#SetHotColor(Eval("CId").ToString()) %>" href="ViewByClass.aspx?cid=<%#Eval("CId")%>"><%#this.SubMixText(Eval("CName").ToString(),10)%></a></li></ItemTemplate>
 <FooterTemplate></ul></FooterTemplate>
</asp:Repeater><div class="right"></div></div>  
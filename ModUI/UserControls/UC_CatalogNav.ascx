<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_CatalogNav.ascx.cs" Inherits="MOD.UI.UserControls.UC_CatalogNav" %>
<dl id="naver"><dd class="w1"></dd><dd class="w2">
<asp:Repeater ID="rptNavBar" runat="server" OnItemDataBound="rptNavBar_ItemDataBound">
<HeaderTemplate><ul id="CatalogNav"></HeaderTemplate>
<ItemTemplate><li <%#SetNavStyle(rptNavBar.Items.Count)%>><a <%#SetHotColor(Eval("CId").ToString()) %> href="ViewByClass.aspx?cid=<%#Eval("CId")%>"><%#this.SubMixText(Eval("CName").ToString(),10)%></a>
            <asp:Repeater ID="rptSubCatalogList" runat="server">
            <HeaderTemplate><div class="list"></HeaderTemplate>
            <ItemTemplate><a href="ViewByClass.aspx?cid=<%#Eval("CId")%>"><%#Eval("CName")%></a></ItemTemplate>
            <FooterTemplate></div></FooterTemplate>
        </asp:Repeater>
        </li>
</ItemTemplate>
<FooterTemplate></ul></FooterTemplate>
</asp:Repeater></dd><dd class="w3"></dd></dl>
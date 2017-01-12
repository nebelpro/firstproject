<%@ Page Language="C#" MasterPageFile="~/VideoPage.Master" AutoEventWireup="true" CodeBehind="IPTV.aspx.cs" Inherits="MOD.WebTd.IPTV" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/VideoPage.Master" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="channelList">
    <asp:Repeater ID="rptBroad" runat="server">
        <HeaderTemplate><ul></HeaderTemplate>
        <ItemTemplate>
            <li><a href="javascript://" onclick="CastPlay(<%#Eval("CId")%>)"><%#Eval("CName")%></a></li>
        </ItemTemplate>
        <FooterTemplate></ul></FooterTemplate>
    </asp:Repeater>
    
   <asp:Repeater ID="rptIPTV" runat="server">
        <HeaderTemplate><ul></HeaderTemplate>
        <ItemTemplate>
            <li><a href="javascript://" onclick="CastPlay(<%#Eval("CId")%>)"><%#Eval("CName")%></a></li>
        </ItemTemplate>
        <FooterTemplate></ul></FooterTemplate>
    </asp:Repeater>
</asp:Content>

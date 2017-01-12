<%@ Page Language="C#" MasterPageFile="~/VideoPage.Master" AutoEventWireup="true" CodeBehind="Recorder.aspx.cs" Inherits="MOD.WebTd.Recorder" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/VideoPage.Master" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="channelList">
 <asp:Repeater ID="rptLive" runat="server">
        <HeaderTemplate><ul></HeaderTemplate>
        <ItemTemplate>
            <li><a href="javascript://" onclick="CastPlay(<%#Eval("CId")%>)"><%#Eval("CName")%></a></li>
        </ItemTemplate>
        <FooterTemplate></ul></FooterTemplate>
    </asp:Repeater>            
    <asp:Repeater ID="rptMix" runat="server">
        <HeaderTemplate><ul></HeaderTemplate>
        <ItemTemplate>
            <li><a href="javascript://" onclick="CastPlay(<%#Eval("CId")%>)"><%#Eval("CName")%></a></li>
        </ItemTemplate>
        <FooterTemplate></ul></FooterTemplate>
    </asp:Repeater>
</asp:Content>

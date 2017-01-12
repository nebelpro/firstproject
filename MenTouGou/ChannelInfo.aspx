<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ChannelInfo.aspx.cs" Inherits="mentougou.ChannelInfo" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPage.Master" %>
<%@ Register Src="UserControl/UC_ChannelInfo.ascx" TagName="ChannelInfo" TagPrefix="UC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <UC:ChannelInfo id="UC_ChannelInfo1" runat="server"/>
</asp:Content>

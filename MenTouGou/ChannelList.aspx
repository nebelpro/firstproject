<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ChannelList.aspx.cs" Inherits="mentougou.ChannelList" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPage.Master" %>
<%@ Register Src="UserControl/UC_ChannelList.ascx" TagName="UC_ChannelList" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UC_ChannelList ID="UC_ChannelList1" runat="server" />
</asp:Content>

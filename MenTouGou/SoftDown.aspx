<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SoftDown.aspx.cs" Inherits="mentougou.SoftDown" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPage.Master" %>
<%@ Register Src="UserControl/UC_SoftDown.ascx" TagName="SoftDown" TagPrefix="UC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <UC:SoftDown id="UC_SoftDown1" runat="server"/>
    
</asp:Content>

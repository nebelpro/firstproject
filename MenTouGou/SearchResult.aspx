<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SearchResult.aspx.cs" Inherits="mentougou.SearchResult" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPage.Master" %>
<%@ Register Src="UserControl/UC_ProgramList.ascx" TagName="UC_ProgramList" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UC_ProgramList ID="UC_ProgramList1" runat="server" />
</asp:Content>

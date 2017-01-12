<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="MOD.WebTd.SearchResult" Title="Untitled Page" Codebehind="SearchResult.aspx.cs" %>
<%@ Register Src="UserControls/UC_ProgramSearchList.ascx" TagName="ProgramSearchList" TagPrefix="UC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="position"><a href="Default.aspx"><%=this.GetRes("Info_Home") %></a>
 - <span><% = this.GetRes("INFO_SEARCH_RESULT")%></span></div>  
<div id="banner"><img src="Images/depend/banner.gif" alt="banner" /></div>
<UC:ProgramSearchList ID="UC_ProgramSearchList1" runat="server" />
</asp:Content>


<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" EnableViewState="false" AutoEventWireup="true" Inherits="MOD.WebTd.ViewByClass" Title="Untitled Page" Codebehind="ViewByClass.aspx.cs" %>
<%@ Register Src="UserControls/UC_ProgramList.ascx" TagName="ProgramList" TagPrefix="UC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">   
<div id="position"><a href="Default.aspx"><%=this.GetRes("Info_Home") %></a> 
- <asp:Literal ID="lbPosi" runat="server"></asp:Literal></div> 
    <UC:ProgramList ID="UC_ProgramList1" runat="server" />
</asp:Content>


<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="BulletinList.aspx.cs" Inherits="MOD.WebTd.BulletinList" Title="Untitled Page" %>
<%@ Register Src="UserControls/UC_BulletinList.ascx" TagName="BulletinList" TagPrefix="UC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="position"><a href="Default.aspx"><%=this.GetRes("Info_Home")%></a> - <span><%=this.GetRes("Info_BulletinList")%></span></div>
    <div id="banner"><img src="Images/depend/banner.gif" alt="banner" /></div>
    <UC:BulletinList ID="UC_BulletinList1" runat="server" />
</asp:Content>

<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="BulletinList.aspx.cs" Inherits="MOD.UI.BulletinList" Title="Untitled Page" %>
<%@ Register Src="UserControls/UC_BulletinList.ascx" TagName="BulletinList" TagPrefix="UC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="rightHolder" runat="server">
<div id="banner"></div>
<div class="brder">
    <UC:BulletinList ID="UC_BulletinList1" runat="server" />
</div>
</asp:Content>

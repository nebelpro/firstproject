<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    Codebehind="ProgramInfo.aspx.cs" Inherits="MOD.UI.ProgramInfo" Title="Untitled Page" %>
<%@ Register Src="UserControls/UC_ProgramInfo.ascx" TagName="ProgramInfo" TagPrefix="UC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="rightHolder" runat="server">
<div id="banner"></div>
<UC:ProgramInfo id="UC_ProgramInfo1" runat="server" />
</asp:Content>

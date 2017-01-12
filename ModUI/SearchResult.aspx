<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" EnableViewState="false" AutoEventWireup="true" CodeBehind="SearchResult.aspx.cs" Inherits="MOD.UI.SearchResult" Title="MOD" %>
<%@ Register Src="UserControls/UC_ProgramSearchList.ascx" TagName="ProgramSearchList" TagPrefix="UC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="rightHolder" runat="server">
<div id="banner"></div>
<div class="brder">
    <div id="subb">        
        <UC:ProgramSearchList ID="Uc_programlist1" runat="server" />
    </div>
</div>
</asp:Content>

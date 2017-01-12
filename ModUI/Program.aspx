<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" EnableViewState="false" AutoEventWireup="true" CodeBehind="Program.aspx.cs" Inherits="MOD.UI.ProgramVideo" Title="Untitled Page" %>
<%@ Register Src="UserControls/UC_BulletinTop.ascx" TagName="BulletinTop" TagPrefix="UC" %>
<%@ Register Src="UserControls/UC_ProgramNew.ascx" TagName="ProgramNew" TagPrefix="UC" %>
<%@ Register Src="UserControls/UC_ProgramNewView.ascx" TagName="ProgramNewView" TagPrefix="UC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="rightHolder" runat="server">
 <div id="banner"></div>
 <UC:BulletinTop id="UC_BulletinTop1" runat="server"/>
 <UC:ProgramNew id="programnew1" runat="server" />
 <UC:ProgramNewView id="programnew2" runat="server" />
</asp:Content>

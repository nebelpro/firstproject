<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ProgramInfo.aspx.cs" Inherits="mentougou.ProgramInfo" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPage.Master" %>
<%@ Register Src="UserControl/UC_ProgramInfo.ascx" TagName="Info" TagPrefix="UC" %>
<%@ Register Src="UserControl/UC_ProgramChapter.ascx" TagName="Chapter" TagPrefix="UC" %>
<asp:Content ID="ctn1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <UC:Info id="Info" runat="server"/>
    <UC:Chapter id="Chapter" runat="server"/>   
</asp:Content>

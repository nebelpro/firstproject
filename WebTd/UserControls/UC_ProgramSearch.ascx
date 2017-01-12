<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_ProgramSearch.ascx.cs" Inherits="MOD.WebTd.UserControls.UC_ProgramSearch" %>
<asp:Panel ID="panelTop" DefaultButton="btnSearch" runat="server">
<div id="search">
    <asp:TextBox CssClass="txt" ID="tbKey" runat="server"></asp:TextBox>
    <asp:ImageButton CssClass="btn" ID="btnSearch" runat="server" ImageUrl="~/Images/depend/btn_sear.gif" OnClick="btnSearch_Click" />
</div>
</asp:Panel>

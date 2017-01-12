<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_ProgramSearch.ascx.cs" Inherits="MOD.UI.UserControls.UC_ProgramSearch" %>
<div id="search">
<div class="bug">
<asp:Panel ID="pnlSearch" runat="server" DefaultButton="ibtnSearch">
        <asp:TextBox ID="tbKey" CssClass="txt" runat="server"></asp:TextBox>
        <asp:ImageButton ID="ibtnSearch" ImageAlign="AbsMiddle" Width="32px" Height="22px" ImageUrl="~/Images/depend/btn_search.gif" runat="server"  OnClick="ibtnSearch_Click" />
  </asp:Panel>
 </div>
</div>
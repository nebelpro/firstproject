<%@ Page Language="C#" MasterPageFile="~/UserCenter.Master" AutoEventWireup="true" CodeBehind="Charge.aspx.cs" Inherits="MOD.UI.Charge" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cplUser" runat="server">
    <h3><img src="Images/depend/Charge.gif" alt="" /></h3>    
    <table id="Charge">
        <tr><td class="w1"><%=this.GetRes("INFO_CARD_NO")%>: </td><td class="w2"><asp:TextBox ID="tbCardNum" runat="server" CssClass="txt"></asp:TextBox></td></tr>
        <tr><td class="w1"><%=this.GetRes("INFO_CARD_PWD")%>:</td><td class="w2"><asp:TextBox ID="tbCardPwd" TextMode="Password" runat="server" CssClass="txt"></asp:TextBox></td></tr>
        <tr><td class="w1"></td><td class="w2"><asp:ImageButton ID="ibtnAddPoint" CssClass="btn" ImageUrl="Images/depend/btn_ok.gif" runat="server" OnClick="ibtnAddPoint_Click" /></td></tr>
        <tr><td class="w1"></td><td><asp:Label ID="lblTips" runat="server" ForeColor="red"></asp:Label></td></tr>
    </table>
</asp:Content>

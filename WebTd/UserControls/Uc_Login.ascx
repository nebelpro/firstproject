<%@ Control Language="C#" AutoEventWireup="true" EnableViewState="false" CodeBehind="Uc_Login.ascx.cs" Inherits="MOD.WebTd.UserControls.Uc_Login" %>
<asp:Panel ID="panelLogin" runat="server" DefaultButton="btnLogin">
<div class="box-login">  
    <div class="login-left"></div>
    <div class="login-body">
        <div class="login-img"><img src="Images/depend/lgn.gif"/></div>
        <div class="login-input"> 
            <asp:TextBox ID="tbUserName" CssClass="logininput" runat="server" Text="guest"></asp:TextBox> 
            <asp:Literal ID="lbUserName" runat="server"></asp:Literal>           
            <asp:TextBox ID="tbPassWord" CssClass="logininput"  runat="server" TextMode="Password"></asp:TextBox>
            <asp:Literal ID="lbInfo" runat="server"></asp:Literal>     
            <asp:ImageButton ID="btnLogin" ImageUrl="~/Images/depend/btnlgn.gif" Width="105px" Height="28px" runat="server" OnClick="btnLogin_Click" />
            <asp:ImageButton ID="btnLogout" ImageUrl="~/Images/depend/btnexit.gif" Width="105px" Height="28px" runat="server" OnClick="btnLogout_Click"/>
        </div>
    </div>
    <div class="login-right"></div>
</div>
</asp:Panel>
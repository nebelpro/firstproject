<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_Toper.ascx.cs" Inherits="MOD.UI.UserControls.UC_Toper" %>
<div id="toper">
    <div id="logo"><asp:Image ID="imgLogo" runat="server" /></div>   
    <asp:Panel ID="pnlIsLogon" runat="server" Visible="false" DefaultButton="lbtnExit"> 
     <ul class="person_info"> 
        <li><%=String.Format(this.GetRes("INFO_LOGIN_WELCOME"), this.UserName) %> <asp:LinkButton ID="lbtnExit" runat="server" OnClick="lbtnExit_Click"> <%=this.GetRes("BOX_LOGIN_LOGOUT") %></asp:LinkButton></li>            
        <asp:Literal ID="ltrHelpNav" runat="server"></asp:Literal>
     </ul>
    </asp:Panel>        
    <asp:Panel ID="pnlLogin" runat="server" DefaultButton="ibtnLogin">
    <ul class="person_info"> 
        <li><%=this.GetRes("BOX_LOGIN_ACCOUNT")%><asp:TextBox ID="tbUserName" CssClass="txt" runat="server"></asp:TextBox></li> 
        <li><%=this.GetRes("BOX_LOGIN_PWD") %><asp:TextBox ID="tbPassWord" CssClass="txt" TextMode="Password" runat="server"></asp:TextBox></li> 
        <li><asp:ImageButton CssClass="btn" ID="ibtnLogin" ImageUrl="~/Images/depend/btn_login.gif" runat="server" OnClick="ibtnLogin_Click" /></li>
    </ul>
    </asp:Panel>
    <asp:Literal ID="ltrSetting" runat="server"></asp:Literal>
</div>


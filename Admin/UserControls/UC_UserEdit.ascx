<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_UserEdit.ascx.cs" Inherits="MOD.Admin.UserControls.UC_UserEdit" %>
<div class="rRow">
  <h3><%=GetRes("Info_UserInfo") %></h3>
  <form id="formUser" action="">
  <table class="UserInfo">
    <tr><td class="w1"><%=GetRes("Info_UserMask") %>:</td>
        <td class="w2"><asp:Literal ID="ltrMask" runat="server"></asp:Literal>   
       <span class="cRed hidden"><%=GetRes("Info_UserMaskReg") %></span></td>
    </tr>
    <tr><td class="w1"><%=GetRes("Info_UserName") %>:</td><td class="w2"><asp:Literal ID="ltrName" runat="server"></asp:Literal></td></tr>
    <tr><td class="w1"><%=GetRes("Info_UserPasswd") %>:</td><td class="w2"><asp:Literal ID="ltrPass" runat="server"></asp:Literal></td></tr>
    <tr><td class="w1"><%=GetRes("Info_UserConfirmPass") %>:</td><td class="w2"><asp:Literal ID="ltrPassConfirm" runat="server"></asp:Literal></td></tr>
    <tr><td class="w1"><%=GetRes("Info_UserPermit") %>:</td>
        <td class="w2"><asp:Literal ID="ltrChkLogin" runat="server"></asp:Literal><%=GetRes("Info_UserAllowLogin") %>  
        <asp:Literal ID="ltrChkModifyPass" runat="server"></asp:Literal><%=GetRes("Info_UserChangePwd") %></td></tr>    
    <tr><td class="w1"><%=GetRes("Info_UserIntro") %>:</td><td class="w2"><asp:Literal ID="ltrInfo" runat="server"></asp:Literal></td></tr>
    <tr><td class="w1"><%=GetRes("Info_UserGroup") %>:</label></td><td class="w2"> <asp:Literal ID="ltrGroupList" runat="server"></asp:Literal></td></tr>
    <tr><td class="w1"></td><td class="w2"><asp:Literal ID="ltrBtnEdit" runat="server"></asp:Literal></td></tr>  
  </table>  
  </form>
</div>
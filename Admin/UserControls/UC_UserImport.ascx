<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_UserImport.ascx.cs" Inherits="MOD.Admin.UserControls.UC_UserImport" %>
<div class="rRow">
  <h3><%=GetRes("Info_UserImport") %></h3>  
  <div id="divImport">  
  <table class="UserInfo">
    <tr><td colspan="2"><span class="cRed"><%=this.GetRes("Info_ImportUserTip") %></span></td></tr>
    <tr><td class="w1"><%=this.GetRes("Info_SelectFile") %>:</td><td class="w2"><input id="userfile" type="file"  value="" class="file" /></td></tr>
    <tr><td class="w1"></td><td class="w2"><input type="button" onclick="user.ImportUser();" class="btn" id="" value="<%=this.GetRes("Oper_Import")%>" /></td></tr>
   
  </table>
  </div>
  
</div>


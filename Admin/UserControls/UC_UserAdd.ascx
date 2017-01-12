<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_UserAdd.ascx.cs" Inherits="MOD.Admin.UserControls.UC_UserAdd" %>
<div class="rRow">
  <h3><%=GetRes("Info_UserInfo") %></h3>
  <form id="formUser" action="">
  <table  class="UserInfo">
    <tr><td class="w1"><%=GetRes("Info_UserMask")%>:</td>
        <td class="w2"><input type="text" id="txtMask" class="txt"/><span class="cRed"><%=GetRes("Info_UserMaskReg") %></span></td>
    </tr>
    <tr><td class="w1"><%=GetRes("Info_UserName")%>:</td><td class="w2"><input type="text" id="txtName" class="txt"/></td></tr>
    <tr><td class="w1"><%=GetRes("Info_UserPasswd")%>:</td><td class="w2"><input type="password" id="txtPass" class="txt"/></td></tr>
    <tr><td class="w1"><%=GetRes("Info_UserConfirmPass") %>:</td>
        <td class="w2"><input type="password" id="txtPassConfirm" class="txt"/></td>
    </tr>
    <tr><td class="w1"><%=GetRes("Info_UserPermit") %>:</td>
        <td class="w2"><input type="checkbox" id="chkLogin" value="<%=MOD.BLL.PERMIT_TYPE.per_u_login %>" checked="checked" />
           <%=GetRes("Info_UserAllowLogin") %> 
           <input type="checkbox" id="chkModifyPass" value="<%=MOD.BLL.PERMIT_TYPE.per_u_changepwd %>" checked="checked" />
           <%=GetRes("Info_UserChangePwd") %>
        </td></tr>
    <tr><td class="w1"><%=GetRes("Info_UserIntro") %>:</td><td class="w2"><input type="text" id="txtInfo" class="txt"/></td></tr>
    <tr><td class="w1"><%=GetRes("Info_UserGroup") %>:</td><td class="w2"><ul>
       <asp:Repeater ID="rptGroupList" runat="server">
         <ItemTemplate>
             <li><input type="checkbox" name="chkGroup" value="<%#Eval("GMask") %>" /><%#Eval("GName") %></li>
         </ItemTemplate>
       </asp:Repeater>        
     </ul></td></tr>
    <tr><td class="w1"></td><td class="w2"><input type="button" class="btn" value="<%=GetRes("Oper_Submit")%>" onclick="user.Update(0);" /> 
      <input  class="btn" type= "reset" value="<%=GetRes("Oper_Reset") %>" /></td></tr>
  </table>
  
  </form>
</div>
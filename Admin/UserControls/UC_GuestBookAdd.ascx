<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_GuestBookAdd.ascx.cs" Inherits="MOD.Admin.UserControls.UC_GuestBookAdd" %>
<div class="rRow">
  <h3><%=GetRes("Info_GuestBookAddTitle")%></h3>
  <table id="BulletinAdd">
   <tr><td class="w1"><%=GetRes("Info_GuestBookTitle")%></td><td class="w2"><input type="text" id="txtSubject" class="txt" /></td></tr>
   <tr><td class="w1"><%=GetRes("Info_GuestBookInfo")%></td><td><textarea rows="5" id="txtInfo" class="txt" cols="16"></textarea> </td></tr>
   <tr><td class="w1"><%=GetRes("Info_GuestBookType")%></td>
        <td>
           <input type="radio" id="gbType0" name="gbType" checked="checked"/><%=GetRes("Info_GuestBookPublic")%> 
           <input type="radio" id="gbType1" name="gbType" /><%=GetRes("Info_GuestBookPrivate") %>
        </td>        
   </tr>
   <tr><td colspan="2" class="txtRight">
        <input type="button" value="<%=GetRes("Oper_Submit")%>" class="btn" onclick="guestbook.Add();" />
   </td></tr>
  </table>   
</div>
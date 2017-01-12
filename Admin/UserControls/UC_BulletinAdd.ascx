<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_BulletinAdd.ascx.cs" Inherits="MOD.Admin.UserControls.UC_BulletinAdd" %>
<div class="rRow">
  <h3><%=GetRes("Info_BulletinAdd")%></h3>
  <form id="formBulletinadd" action="" onsubmit="bulletin.Update(0); return false;">
  <table id="BulletinAdd">
   <tr><td class="w1"><%=GetRes("Info_BulletinTitle")%></td><td class="w2"><input type="text" id="txtTitle" class="txt" /></td></tr>
   <tr><td class="w1"><%=GetRes("Info_BulletinInfo")%></td><td><textarea rows="5" id="txtInfo" class="txt" cols="16"></textarea> </td></tr>
   <tr><td colspan="2" class="txtRight"><input type="button" id="btnAddBul" value="<%=GetRes("Info_BulletinAdd")%>" class="btn" onclick="bulletin.Update(0);" /></td></tr>
  </table>   
  </form>
</div>
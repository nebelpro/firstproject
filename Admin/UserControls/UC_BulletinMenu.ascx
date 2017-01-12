<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_BulletinMenu.ascx.cs" Inherits="MOD.Admin.UserControls.UC_BulletinMenu" %>
<div class="lRow">
  <h3><%=GetRes("Info_BulletinMng") %></h3>
  <ul id="leftNav">
    <li><a href="javascript://" onclick="bulletin.GetList(1);"><%=GetRes("Info_BulletinList")%></a></li> 
    <li><a href="javascript://"  onclick="bulletin.AreaAdd();"><%=GetRes("Info_BulletinAdd")%></a></li>                      
    <li><a href="javascript://"  onclick="guestbook.GetList(1);"><%=GetRes("Info_GuestBookList")%></a></li>  
   </ul>
</div>
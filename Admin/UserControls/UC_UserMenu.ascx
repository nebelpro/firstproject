<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_UserMenu.ascx.cs" Inherits="MOD.Admin.UserControls.UC_UserMenu" %>
 <div class="lRow">
     <h3><%=GetRes("Info_UserMng") %></h3>
     <ul id="leftNav">
         <li><a href="javascript://" onclick="user.AreaList();"><%=GetRes("Info_UserMng")%></a></li>
         <li><a href="javascript://" onclick="user.AreaAdd();"><%=GetRes("Info_UserAdd") %></a></li>
         <li><a href="javascript://" onclick=" user.AreaImport();"><%=GetRes("Info_UserImport")%></a></li>
         <li><a href="javascript://" onclick=" group.GetList(1);"><%=GetRes("Info_GroupMng")%></a></li>
         <li><a href="javascript://" onclick=" group.AreaAdd();"><%=GetRes("Info_GroupAdd")%></a></li>         
     </ul>
 </div>
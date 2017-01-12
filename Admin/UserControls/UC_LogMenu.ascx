<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_LogMenu.ascx.cs" Inherits="MOD.Admin.UserControls.UC_LogMenu" %>
<div class="lRow">
     <h3><%=GetRes("Info_LogMng") %></h3>
     <ul id="leftNav">
         <li ><a href="javascript://" onclick="log.PlayLog(1,0);"><%=GetRes("Info_PlayLog")%></a></li>
         <li><a href="javascript://" onclick="log.PlayCount(1,0);"><%=GetRes("Info_PlayCount")%></a></li>
     </ul>
 </div>
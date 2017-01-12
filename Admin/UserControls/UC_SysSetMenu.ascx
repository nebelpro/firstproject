<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_SysSetMenu.ascx.cs" Inherits="MOD.Admin.UserControls.UC_SysSetMenu" %>
<div class="lRow" >
     <h3><%=GetRes("Info_SysSetMng") %></h3>
     <ul id="leftNav">         
         <li><a href="javascript://" onclick="sysset.AreaSystem();"><%=GetRes("Info_SysSetSystem") %></a></li>
         <li><a href="javascript://" onclick="sysset.AreaWeige();"><%=GetRes("Info_SysSetWeige") %></a></li>
     </ul>
     <p class="hidden"><a href="javascript://" onclick="sysset.AreaExpand();"><%=GetRes("Info_SysSetExpand") %></a></p>
 </div>
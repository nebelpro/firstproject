<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_CardMenu.ascx.cs" Inherits="MOD.Admin.UserControls.UC_CardMenu" %>
<div class="lRow">
    <h3><%=GetRes("Info_CardMng") %></h3>
    <ul id="leftNav">
        <li><a href="javascript://" onclick="card.AreaCardSet();"><%=GetRes("Info_CardMake")%></a></li>
        <li><a href="javascript://" onclick="card.AreaCardSearch();"><%=GetRes("Info_CardSearch")%></a></li>
        <li><a href="javascript://" onclick="card.AreaPointSearch();"><%=GetRes("Info_CardUseSearch")%></a></li>
    </ul>
</div>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_ChannelMenu.ascx.cs" Inherits="MOD.Admin.UserControls.UC_ChannelMenu" %>
<div class="lRow">
     <h3><%=GetRes("Info_ChannelMng") %></h3>     
     <dl id="leftNav">
        <dt><%=this.GetRes("Info_ChannelIptv")%></dt>
        <dd><a href="javascript://" onclick="channel.SetType(4);channel.GetList(1);"><%=GetRes("Info_ChannelLive")%></a></dd>  
        <dd><a href="javascript://" onclick="channel.SetType(1);channel.GetList(1);"><%=GetRes("Info_ChannelBroad")%></a></dd> 
        <dt><%=this.GetRes("Info_ChannelRecorder")%></dt>
        <dd><a href="javascript://" onclick="channel.SetType(0);channel.GetList(1);"><%=GetRes("Info_ChannelLive")%></a></dd>
        <dd><a href="javascript://" onclick="channel.SetType(3);channel.GetList(1);"><%=GetRes("Info_ChannelMix")%></a></dd>
     </dl>
 </div>
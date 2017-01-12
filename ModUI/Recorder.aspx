<%@ Page Language="C#" MasterPageFile="~/VideoPage.Master" AutoEventWireup="true" CodeBehind="Recorder.aspx.cs" Inherits="MOD.UI.Recorder" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/VideoPage.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="rightHolder" runat="server">
<div id="banner"></div>
<div class="brder">
    <div id="subb"><!-- use the style as subb -->
        <h3><asp:Literal ID="ltrTip" runat="server"></asp:Literal></h3>        
      
         <div class="ListBar">     
            <div class="left">
              <asp:Literal ID="ltrLive" runat="server"></asp:Literal> &nbsp;&nbsp;&nbsp;
              <asp:Literal ID="ltrMixc" runat="server"></asp:Literal>
            </div>      
            <div class="right">
                <asp:Literal ID="ltrListTop" runat="server"></asp:Literal>                
            </div>
        </div>
        <asp:Repeater ID="rptChannelList" runat="server">
        <ItemTemplate>
          <div class="castblock">
            <table class="castimg">
              <tr><td><img src="<%#MOD.WebUtility.ChannelHelper.GetChannelIcon(Int32.Parse(Eval("CType").ToString()),0) %>" alt="" /></td>
              </tr></table>
            <ul class="CastInfo">
              <li class="castTitle"><img src="<%#MOD.WebUtility.ChannelHelper.GetChannelIcon(Int32.Parse(Eval("CType").ToString()),1) %>" alt="">
                <b><%#Server.HtmlEncode(Eval("CName").ToString()) %></b></li>
              <li><%= this.GetRes("INFO_CHANNEL_STATE") %>: <%#MOD.WebUtility.ChannelHelper.GetState(Int32.Parse(Eval("CState").ToString()))%></li>
                      <li><%= this.GetRes("INFO_CHANNEL_USER") %>: <%#Server.HtmlEncode(Eval("UserName").ToString()) %></li>
              <li><%= this.GetRes("INFO_CHANNEL_CREATE") %>: <%#Eval("CCreateTime") %></li>
               <li><%= this.GetRes("INFO_CHANNEL_START") %>: <%#Eval("CBeginTime") %></li>
             <li class="castInfo"><%#Eval("CInfo") %></li>
              <li class="castBtn"><a href="#" onclick="<%# MOD.WebUtility.ChannelHelper.GetChannelUrl(Int32.Parse(Eval("CId").ToString()),0,1)%>"><img src="Images/depend/btn_receive.gif" alt="" /></a>
                    <%#MOD.WebUtility.ChannelHelper.OutChannelDetailLink(Int32.Parse(Eval("CId").ToString()),Int32.Parse(Eval("CType").ToString()),0)%>
              </li>
            </ul>
            <hr class="clear" />
          </div>
        </ItemTemplate>
          <AlternatingItemTemplate>
            <div class="castblock" style="background: #f5f5f3;">
               <table class="castimg">
              <tr><td><img src="<%#MOD.WebUtility.ChannelHelper.GetChannelIcon(Int32.Parse(Eval("CType").ToString()),0) %>" alt="" /></td>
              </tr></table>
            <ul class="CastInfo">
              <li class="castTitle"><img src="<%#MOD.WebUtility.ChannelHelper.GetChannelIcon(Int32.Parse(Eval("CType").ToString()),1) %>" alt="">
                <b><%#Server.HtmlEncode(Eval("CName").ToString()) %></b></li>
              <li><%= this.GetRes("INFO_CHANNEL_STATE") %>: <%#MOD.WebUtility.ChannelHelper.GetState(Int32.Parse(Eval("CState").ToString()))%></li>
                      <li><%= this.GetRes("INFO_CHANNEL_USER") %>: <%#Server.HtmlEncode(Eval("UserName").ToString()) %></li>
              <li><%= this.GetRes("INFO_CHANNEL_CREATE") %>: <%#Eval("CCreateTime") %></li>
               <li><%= this.GetRes("INFO_CHANNEL_START") %>: <%#Eval("CBeginTime") %></li>
             <li class="castInfo"><%#Eval("CInfo") %></li>
              <li class="castBtn"><a href="#" onclick="<%# MOD.WebUtility.ChannelHelper.GetChannelUrl(Int32.Parse(Eval("CId").ToString()),0,1)%>"><img src="Images/depend/btn_receive.gif" alt="" /></a>
                    <%#MOD.WebUtility.ChannelHelper.OutChannelDetailLink(Int32.Parse(Eval("CId").ToString()),Int32.Parse(Eval("CType").ToString()),0)%>
              </li>
            </ul>
            <hr class="clear" />
            </div>
            </AlternatingItemTemplate>    
        </asp:Repeater>     
        <asp:Literal ID="ltrEmpty" runat="server"></asp:Literal>
   
   
   
    </div>
</div>
</asp:Content>

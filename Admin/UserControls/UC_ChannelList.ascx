<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_ChannelList.ascx.cs" Inherits="MOD.Admin.UserControls.UC_ChannelList" %>
<div class="rRow">
  <h3>
    <%=GetRes("Info_ChannelList")%></h3>
  <div class="ListBar">
    <div class="left"><label><asp:Literal ID="ltrOper" runat="server"></asp:Literal></label></div>
    <div class="right"><asp:Literal ID="ltrListTop" runat="server"></asp:Literal></div>
  </div>  
 <asp:Repeater ID="rptList" runat="server">   
   <ItemTemplate>
   <dl class="ChannelList item">
     <dd><img src="<%#MOD.WebUtility.ChannelHelper.GetChannelIcon(Int32.Parse(Eval("CType").ToString()),0) %>" alt="" /></dd>
     <dd class="item">
      
       <ul>
         <li class="titleLi"><img src="<%#MOD.WebUtility.ChannelHelper.GetChannelIcon(Int32.Parse(Eval("CType").ToString()),1) %>"
               alt=""><%#Server.HtmlEncode(Eval("CName").ToString()) %></li>
         <li><ul>
             <li><%=GetRes("Info_ChannelState")%>:<%#MOD.WebUtility.ChannelHelper.GetState(Int32.Parse(Eval("CState").ToString()))%> </li>
             <li><%=GetRes("Info_ChannelBeginTime")%>: <%#Eval("CBeginTime") %> </li>
         </ul></li>
         <li>
           <ul>
             <li><%=GetRes("Info_ChannelMaker")%>: <%#Server.HtmlEncode(Eval("UserName").ToString()) %> </li>
             <li><%=GetRes("Info_ChannelAddTime")%>: <%#Eval("CCreateTime") %> </li>
           </ul>
         </li>
         <li><%#Eval("CInfo") %></li>
         <li class="btnLi">
            <%#MOD.Admin.Helper.GetBtn(int.Parse(Eval("CType").ToString()),int.Parse(Eval("CId").ToString())) %>
           <input type="button" class="btn" onclick="channel.Play('<%# MOD.WebUtility.WebHelper.EncryptPid(Int32.Parse(Eval("CId").ToString()))%>',0,1);" value="<%=GetRes("Oper_ChannelReceive")%>" /></li>
       </ul>
     </dd></dl>
   </ItemTemplate>
   <AlternatingItemTemplate>
   <dl class="ChannelList alter">
     <dd><img src="<%#MOD.WebUtility.ChannelHelper.GetChannelIcon(Int32.Parse(Eval("CType").ToString()),0) %>" alt="" /></dd>
     <dd class="item">
      
       <ul>
         <li class="titleLi"><img src="<%#MOD.WebUtility.ChannelHelper.GetChannelIcon(Int32.Parse(Eval("CType").ToString()),1) %>"
               alt=""><%#Server.HtmlEncode(Eval("CName").ToString()) %></li>
         <li><ul>
             <li><%=GetRes("Info_ChannelState")%>:<%#MOD.WebUtility.ChannelHelper.GetState(Int32.Parse(Eval("CState").ToString()))%> </li>
             <li><%=GetRes("Info_ChannelBeginTime")%>: <%#Eval("CBeginTime") %> </li>
         </ul></li>
         <li>
           <ul>
             <li><%=GetRes("Info_ChannelMaker")%>: <%#Server.HtmlEncode(Eval("UserName").ToString()) %> </li>
             <li><%=GetRes("Info_ChannelAddTime")%>: <%#Eval("CCreateTime") %> </li>
           </ul>
         </li>
         <li><%#Eval("CInfo") %></li>
         <li class="btnLi">
            <%#MOD.Admin.Helper.GetBtn(int.Parse(Eval("CType").ToString()),int.Parse(Eval("CId").ToString())) %>
           <input type="button" class="btn" onclick="channel.Play('<%# MOD.WebUtility.WebHelper.EncryptPid(Int32.Parse(Eval("CId").ToString()))%>',0,1);" value="<%=GetRes("Oper_ChannelReceive")%>" /></li>
       </ul>
     </dd></dl>   
   </AlternatingItemTemplate>
 </asp:Repeater>
<asp:Literal ID="ltrEmpty" runat="server"></asp:Literal>
  <div class="ListBar">
    <div class="left"></div>
    <div class="right"><asp:Literal ID="ltrListBtm" runat="server"></asp:Literal></div>
  </div>  
</div>

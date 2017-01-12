<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_ChannelList.ascx.cs" Inherits="mentougou.UserControl.UC_ChannelList" %>
<div class="subb">
  <h3><img src="Images/depend/h3_channel.gif" alt="" /></h3>
  <div class="subcontent">  
  <div class="ListBar">
    <div class="left">
      <asp:DropDownList ID="ddlType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlType_SelectedIndexChanged">
      </asp:DropDownList></div>
    <div class="right"><asp:Literal ID="ltrListTop" runat="server"></asp:Literal></div>
  </div>  
 <asp:Repeater ID="rptChannelList" runat="server">   
   <ItemTemplate>
   <dl class="ChannelList item">
     <dd><img src="<%#MOD.WebUtility.ChannelHelper.GetChannelIcon(Int32.Parse(Eval("CType").ToString()),0) %>" alt="" /></dd>
     <dd class="item">      
       <ul>
         <li class="titleLi"><img src="<%#MOD.WebUtility.ChannelHelper.GetChannelIcon(Int32.Parse(Eval("CType").ToString()),1) %>"
               alt=""><%#Server.HtmlEncode(Eval("CName").ToString()) %></li>       
         <li><%=GetRes("Info_ChannelState")%>:<%#MOD.WebUtility.ChannelHelper.GetState(Int32.Parse(Eval("CState").ToString()))%> </li>
         <li><%=GetRes("Info_ChannelBeginTime")%>: <%#Eval("CBeginTime") %> </li>
         <li><%=GetRes("Info_ChannelMaker")%>: <%#Server.HtmlEncode(Eval("UserName").ToString()) %> </li>
         <li><%=GetRes("Info_ChannelAddTime")%>: <%#Eval("CCreateTime") %> </li>          
         <li class="infoLi"><%#Eval("CInfo") %></li>
         <li class="btnLi">     
            <%#MOD.WebUtility.ChannelHelper.OutChannelDetailLink(Int32.Parse(Eval("CId").ToString()), Int32.Parse(Eval("CType").ToString()), "btn_channelinfo.gif")%>
            <a href="#" onclick="javascript:if(CheckMedia()){<%# MOD.WebUtility.ChannelHelper.GetChannelUrl(Int32.Parse(Eval("CId").ToString()),0,1)%>}">      
           <img src="Images/depend/btn_receive2.gif" alt="" /></a></li>
       </ul>
       <br class="clear" />
     </dd></dl>
   </ItemTemplate>
   <AlternatingItemTemplate>
   <dl class="ChannelList alter">
     <dd><img src="<%#MOD.WebUtility.ChannelHelper.GetChannelIcon(Int32.Parse(Eval("CType").ToString()),0) %>" alt="" /></dd>
     <dd class="item">      
       <ul>
         <li class="titleLi"><img src="<%#MOD.WebUtility.ChannelHelper.GetChannelIcon(Int32.Parse(Eval("CType").ToString()),1) %>"
               alt=""><%#Server.HtmlEncode(Eval("CName").ToString()) %></li>    
         <li><%=GetRes("Info_ChannelState")%>:<%#MOD.WebUtility.ChannelHelper.GetState(Int32.Parse(Eval("CState").ToString()))%> </li>
         <li><%=GetRes("Info_ChannelBeginTime")%>: <%#Eval("CBeginTime") %> </li>   
         <li><%=GetRes("Info_ChannelMaker")%>: <%#Server.HtmlEncode(Eval("UserName").ToString()) %> </li>
         <li><%=GetRes("Info_ChannelAddTime")%>: <%#Eval("CCreateTime") %> </li>     
         <li class="infoLi"><%#Eval("CInfo") %></li>
        <li class="btnLi">     
            <%#MOD.WebUtility.ChannelHelper.OutChannelDetailLink(Int32.Parse(Eval("CId").ToString()), Int32.Parse(Eval("CType").ToString()), "btn_channelinfo2.gif")%>
            <a href="#" onclick="javascript:if(CheckMedia()){<%# MOD.WebUtility.ChannelHelper.GetChannelUrl(Int32.Parse(Eval("CId").ToString()),0,1)%>}">      
           <img src="Images/depend/btn_receive.gif" alt="" /></a></li>
       </ul>
       <br class="clear" />
     </dd></dl>
   
   </AlternatingItemTemplate>
 </asp:Repeater>
 <asp:Literal ID="ltrEmpty" runat="server"></asp:Literal> 
  <div class="ListBar">
    <div class="left"></div>
    <div class="right"><asp:Literal ID="ltrListBtm" runat="server"></asp:Literal></div>
  </div>
	
</div>
 <div class="subfooter"></div>
 </div>

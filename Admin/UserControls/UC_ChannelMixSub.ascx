<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_ChannelMixSub.ascx.cs" Inherits="MOD.Admin.UserControls.UC_ChannelMixSub" %>
<div class="rRow">
   <h3>
         <asp:Literal ID="ltrTitle" runat="server"></asp:Literal></h3>
   <asp:Repeater ID="rptList" runat="server">
      <HeaderTemplate>
       <table class="subChannel">
         <tr class="hdr"><td class="w1" ></td>
         <td class="w2"><%=GetRes("Info_ChannelName")%></td>
         <td class="w3"><%=GetRes("Info_ChannelState")%></td>
         <td class="w4"><%=GetRes("Info_ChannelBeginTime")%></td></tr>
      </HeaderTemplate>
      <ItemTemplate>
         <tr class="item"><td></td>
         <td><a href="javascript://" onclick="channel.SubMix(<%#Eval("CId")%>,'<%#Eval("CUploadMediaServer")%>')"><%#Eval("CName") %></a> 
         </td><td><%#MOD.WebUtility.ChannelHelper.GetState(int.Parse(Eval("CState").ToString()))%></td><td><%#Eval("CCreateTime") %></td></tr>
      </ItemTemplate>
      <AlternatingItemTemplate>
         <tr class="alter"><td></td>
         <td><a href="javascript://" onclick="channel.SubMix(<%#Eval("CId")%>,'<%#Eval("CUploadMediaServer")%>')"><%#Eval("CName") %></a> </td>
         <td><%#MOD.WebUtility.ChannelHelper.GetState(int.Parse(Eval("CState").ToString()))%></td><td><%#Eval("CCreateTime") %></td></tr>
      </AlternatingItemTemplate>
      <FooterTemplate>
          </table>
      </FooterTemplate>
      
   </asp:Repeater>
   <asp:Literal ID="ltrEmpty" runat="server"></asp:Literal>
</div>

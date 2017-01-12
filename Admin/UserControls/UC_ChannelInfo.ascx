<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_ChannelInfo.ascx.cs" Inherits="MOD.Admin.UserControls.UC_ChannelInfo" %>
<div class="rRow">
  <h3><%=GetRes("Info_ChannelInfo")%></h3>
  <dl class="ChannelList"> 
        <dd><asp:Literal ID="ltrTypeImg" runat="server"></asp:Literal></dd>
        <dd>
          <ul>
            <li class="titleLi">
              <asp:Literal ID="ltrName" runat="server"></asp:Literal></li>
            <li>
              <ul>
                <li><%=GetRes("Info_ChannelState")%>:<asp:Literal ID="ltrState" runat="server"></asp:Literal></li>
                <li><%=GetRes("Info_ChannelBeginTime")%>:<asp:Literal ID="ltrBeginTime" runat="server"></asp:Literal></li>
              </ul>
            </li>
            <li>
              <ul>
                <li><%=GetRes("Info_ChannelMaker")%>:<asp:Literal ID="ltrUserName" runat="server"></asp:Literal></li>
                <li><%=GetRes("Info_ChannelAddTime")%>:<asp:Literal ID="ltrCreateTime" runat="server"></asp:Literal> </li>
              </ul>
            </li>
            <li><asp:Literal ID="ltrInfo" runat="server"></asp:Literal></li>
            
            <li class="btnLi">          
             <asp:Literal ID="ltrBtn" runat="server"></asp:Literal> </li>
          </ul>
        </dd>     
  </dl>
</div>
<div class="rRow">
   <h3><%=GetRes("Info_ChannelReceiveList")%></h3>
   <asp:Literal ID="ltAddressList" runat="server"></asp:Literal>
   
</div>

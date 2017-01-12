<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_ChannelInfo.ascx.cs" Inherits="mentougou.UserControl.UC_ChannelInfo" %>
<div class="subb">
  <h3><img src="Images/depend/h3_channelinfo.gif" alt=""/></h3>
   <div class="subcontent">  
  <dl class="ChannelList"> 
        <dd><asp:Literal ID="ltrTypeImg" runat="server"></asp:Literal></dd>
        <dd>
          <ul>
            <li class="titleLi"><asp:Literal ID="ltrName" runat="server"></asp:Literal></li>
            <li><%=GetRes("Info_ChannelState")%>:<asp:Literal ID="ltrState" runat="server"></asp:Literal></li>
            <li><%=GetRes("Info_ChannelBeginTime")%>:<asp:Literal ID="ltrBeginTime" runat="server"></asp:Literal></li>
            <li><%=GetRes("Info_ChannelMaker")%>:<asp:Literal ID="ltrUserName" runat="server"></asp:Literal></li>
            <li><%=GetRes("Info_ChannelAddTime")%>:<asp:Literal ID="ltrCreateTime" runat="server"></asp:Literal> </li>
            <li class="infoLi"><asp:Literal ID="ltrInfo" runat="server"></asp:Literal></li>            
            <li class="btnLi">          
             <asp:Literal ID="ltrBtn" runat="server"></asp:Literal> </li>
          </ul>
          <br class="clear" />
        </dd>   
  </dl>
  </div>
</div>
<div class="subb">
   <h3><img src="Images/depend/h3_channelreceive.gif" /></h3>
   <div class="subcontent">
        <asp:Literal ID="ltAddressList" runat="server"></asp:Literal>
   </div>
   <div class="subfooter"></div>
</div>
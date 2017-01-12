<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ChannelLink.aspx.cs" Inherits="mentougou.ChannelLink" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPage.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="subb">
  <h3><img src="Images/depend/h3_channel.gif" alt="" /></h3>
  <div class="subcontent">  
  <div class="ListBar">
    <div class="left"><asp:DropDownList ID="ddlType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlType_SelectedIndexChanged">
      </asp:DropDownList>&nbsp;&nbsp;&nbsp;<asp:Literal ID="ltrOper" runat="server"></asp:Literal>&nbsp;&nbsp;<a href="javascript://"  id="LinkDelete" onserverclick="LinkDelete_Click" runat="server"></a></div>
    <div class="right"><asp:Literal ID="ltrListTop" runat="server"></asp:Literal></div>
  </div>
  <asp:Repeater ID="rptChaLink" runat="server">
  <HeaderTemplate><ul id="ChannelLinkList"></HeaderTemplate>
  <ItemTemplate><li><%#this.BindOper2(Eval("c_id").ToString())%><p  onmouseover="ShowTip(this);" onmouseout="HideTip(this);"><a href="<%#Eval("c_info")%>" target="_blank"><%#Eval("c_name")%></a><%#this.BindOper(Eval("c_id").ToString())%></p>
  </li></ItemTemplate>
  <FooterTemplate></ul></FooterTemplate>
  </asp:Repeater> 
 <asp:Literal ID="ltrEmpty" runat="server"></asp:Literal> 
  <div class="ListBar">
    <div class="left"></div>
    <div class="right"><asp:Literal ID="ltrListBtm" runat="server"></asp:Literal></div>
  </div>
	
</div>
 <div class="subfooter"></div>
 </div>
</asp:Content>

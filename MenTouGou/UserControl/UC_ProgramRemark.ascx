<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_ProgramRemark.ascx.cs" Inherits="mentougou.UserControl.UC_ProgramRemark" %>
<div class="subb">
  <h3><%=GetRes("Info_RemarkList")%></h3>
  <div class="ListBar">     
    <div class="left">       
    <asp:Literal ID="ltrOperTop" runat="server"></asp:Literal></div>      
    <div class="right"><asp:Literal ID="ltrListTop" runat="server"></asp:Literal></div>
</div>
  <asp:Repeater ID="rptRemarkList" runat="server">
      <HeaderTemplate><table id="RemarkMng"></HeaderTemplate>
      <ItemTemplate>
         <tr class="rTitle">
            <td class="w1"></td>
            <td class="w2"><%#Eval("PrName") %></td>           
            <td class="w3"><%#Eval("VUserName") %></td>
            <td class="w4"><%#Eval("PrAddTime") %></td>            
         </tr>
         <tr class="rInfo">
            <td colspan="4"><p><%#Eval("PrInfo") %></p></td>
         </tr>
      </ItemTemplate>      
      <FooterTemplate></table></FooterTemplate>  
   </asp:Repeater>   
  <asp:Literal ID="ltrEmpty" runat="server"></asp:Literal>
  <div class="ListBar">     
    <div class="left">
    <asp:Literal ID="ltrOperBtm" runat="server"></asp:Literal></div>      
    <div class="right"><asp:Literal ID="ltrListBtm" runat="server"></asp:Literal></div>
</div>
</div>
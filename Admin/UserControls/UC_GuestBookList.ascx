<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_GuestBookList.ascx.cs" Inherits="MOD.Admin.UserControls.UC_GuestBookList" %>
<div class="rRow">
    <h3><%=GetRes("Info_GuestBook")%></h3>
    <div class="ListBar">  
      <div class="left"><asp:Literal ID="ltrOperTop" runat="server"></asp:Literal>
       </div>      
      <div class="right"><asp:Literal ID="ltrListTop" runat="server"></asp:Literal></div>
   </div>
    <asp:Repeater ID="rptList" runat="server">
    <HeaderTemplate><table id="GuestBookList"></HeaderTemplate>
        <ItemTemplate>
            <tr class="gbTitle ">
                <td class="w1"><input name="gbid" value="<%#Eval("GbId") %>"  type="checkbox"/></td>
                <td class="w2"><%#Eval("GbSubject") %></td>
                <td class="w3"><%#Eval("GbUser") %></td>
                <td class="w4"><%#Eval("GbDate") %></td>
                <td class="W5"><%#MOD.Admin.Helper.GetGuestBookType(int.Parse(Eval("GbType").ToString())) %></td>
            </tr>
            <tr class="gbInfo"><td colspan="5"><p><%#Eval("GbInfo") %></p></td></tr>            
        </ItemTemplate>        
        <FooterTemplate></table></FooterTemplate>
    </asp:Repeater>
    <asp:Literal ID="ltrEmpty" runat="server"></asp:Literal>
   
      
   <div class="ListBar">  
      <div class="left"><asp:Literal ID="ltrOperBtm" runat="server"></asp:Literal>
       </div>      
      <div class="right"><asp:Literal ID="ltrListBtm" runat="server"></asp:Literal></div>
   </div>   
</div>
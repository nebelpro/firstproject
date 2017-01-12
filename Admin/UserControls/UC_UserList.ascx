<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_UserList.ascx.cs" Inherits="MOD.Admin.UserControls.UC_UserList" %>
 <asp:Repeater ID="rptUserList" runat="server">
     <HeaderTemplate>
        <table id="userlist">
        <tr class="hdr">
           <td class="w1"></td>
           <td class="w2"><%=GetRes("Info_UserMask2")%></td>
           <td class="w3"><%=GetRes("Info_UserName")%></td>
        </tr>
     </HeaderTemplate>
       <ItemTemplate>
         <tr class="item"><td class="w1">
         <%#MOD.Admin.Helper.IsDisabled(Eval("UId").ToString())%>   </td>
         <td ><a href="javascript://" onclick="user.AreaEdit(<%#Eval("UId") %>);"><%#Eval("UMask") %></a></td><td><%#Eval("UName") %></td></tr>
       </ItemTemplate>
       <AlternatingItemTemplate>
        <tr class="alter"><td class="w1">
         <%#MOD.Admin.Helper.IsDisabled(Eval("UId").ToString())%>   </td>
         <td><a href="javascript://" onclick="user.AreaEdit(<%#Eval("UId") %>);"><%#Eval("UMask") %></a></td><td><%#Eval("UName") %></td></tr>
       </AlternatingItemTemplate>
       <FooterTemplate></table></FooterTemplate>
     </asp:Repeater>
      <asp:Literal ID="ltrEmpty" runat="server"></asp:Literal>

    <div class="ListBar">
      <div class="left">
         <asp:Literal ID="ltrOperBtm" runat="server"></asp:Literal>
      </div>
      <div class="right"><asp:Literal ID="ltrListBtm" runat="server"></asp:Literal></div>
    </div>
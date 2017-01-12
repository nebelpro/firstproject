<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_ProgramInfo.ascx.cs" Inherits="mentougou.UserControl.UC_ProgramInfo" %>
<div class="subb">
  <h3><img src="Images/depend/h3_programinfo.gif" alt="" /></h3>
  <div class="subcontent">    
  <div id="pInfo">
      <asp:Literal ID="ltrImg" runat="server"></asp:Literal> 
        
      <table>
        <tr><td colspan="4" class="tdTitle"><asp:Literal ID="ltrName" runat="server"></asp:Literal></td></tr>
        <tr><td class="w1"><%=GetRes("Info_ProgramDirector") %>:</td><td class="w2"><asp:Literal ID="ltrDirector" runat="server"></asp:Literal></td>
            <td class="w1"><%=GetRes("Info_ProgramClass") %>:</td><td class="w2"><asp:Literal ID="ltrClass" runat="server"></asp:Literal></td></tr>
        <tr><td class="w1"><%=GetRes("Info_ProgramActor") %>:</td><td class="w2"><asp:Literal ID="ltrActor" runat="server"></asp:Literal></td>
            <td class="w1"><%=GetRes("Info_ProgramPublish") %>:</td><td class="w2"><asp:Literal ID="ltrPublish" runat="server"></asp:Literal></td></tr>
        <tr><td class="w1"><%=GetRes("Info_ProgramTime") %>:</td><td class="w2"><asp:Literal ID="ltrTime" runat="server"></asp:Literal></td>
            <td class="w1"><%=GetRes("Info_ProgramKbps") %>:</td><td class="w2"><asp:Literal ID="ltrKbps" runat="server"></asp:Literal></td></tr>
        <tr><td class="w1"><%=GetRes("Info_ProgramReadCount") %>:</td><td class="w2"><asp:Literal ID="ltrReadCount" runat="server"></asp:Literal></td>
            <td class="w1"><%=GetRes("Info_ProgramAddTime") %>:</td><td class="w2"><asp:Literal ID="ltrAddTime" runat="server"></asp:Literal></td></tr>
        <tr><td class="w1"><%=GetRes("Info_ProgramAddUser") %>:</td><td class="w2"><asp:Literal ID="ltrAddUser" runat="server"></asp:Literal></td>
            <td class="w1"><%=GetRes("Info_ProgramPoint") %>:</td><td class="w2"><asp:Literal ID="ltrPoint" runat="server"></asp:Literal></td></tr>
        <tr><td colspan="4" class="tdInfo"><asp:Literal ID="ltrInfo" runat="server"></asp:Literal> </td></tr>
        <tr><td colspan="4" class="tdBtn"><asp:Literal ID="ltrPlay" runat="server"></asp:Literal></td></tr>
      </table>     
      
  </div> 
  </div>
</div>
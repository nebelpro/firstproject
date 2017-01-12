<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_BulletinEdit.ascx.cs" Inherits="MOD.Admin.UserControls.UC_BulletinEdit" %>
<div class="rRow">
  <h3><%=GetRes("Info_BulletinEdit")%></h3>
  <table id="BulletinAdd">
   <tr><td class="w1"><%=GetRes("Info_BulletinTitle")%></td>
      <td class="w2"><asp:Literal ID="ltrTitle" runat="server"></asp:Literal></td>
   </tr>
   <tr><td class="w1"><%=GetRes("Info_BulletinInfo")%></td><td><asp:Literal ID="ltrInfo" runat="server"></asp:Literal> </td></tr>
   <tr><td colspan="2" class="txtRight"><asp:Literal ID="ltrBtn" runat="server"></asp:Literal></td></tr>
  </table>   
</div>
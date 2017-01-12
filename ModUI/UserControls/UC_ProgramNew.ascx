<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_ProgramNew.ascx.cs" Inherits="MOD.UI.UserControls.UC_ProgramNew" %>
<div id="newpro">
<div class="bug">
     <table class="list">
         <asp:Repeater ID="rptNewList" runat="server">
             <ItemTemplate>
                 <tr>
                     <td class="w1">
                         <a href="ProgramInfo.aspx?pid=<%#Eval("PId") %>" title="<%#Eval("PName") %>">
                             <%#this.SubMixText(Eval("PName").ToString(), 22)%>
                         </a>
                         </td>
                         <td class="w2">
                             <%#Convert.ToDateTime(Eval("PAddTime").ToString()).ToShortDateString()%>                             
                         </td>
                 </tr>
             </ItemTemplate>
         </asp:Repeater>
        
   </table>
 </div>
</div>
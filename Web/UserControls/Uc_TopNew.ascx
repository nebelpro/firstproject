<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Uc_TopNew.ascx.cs" Inherits="MOD.WebTd.UserControls.Uc_TopNew" %>
 <div>
    <div class="topnew-top"></div>
     <div class="blist">
         <ul class="newlist">
        <asp:Repeater ID="rptNewList" runat="server">
         <ItemTemplate>
             <li><a href="ProgramInfo.aspx?pid=<%#Eval("PId") %>">
             <%#MOD.WebUtility.WebHelper.GetSubString(Eval("PName").ToString(), 16)%></a></li>
         </ItemTemplate>
         </asp:Repeater>
         </ul>
     </div>
     <div class="bbtm"></div>
</div>
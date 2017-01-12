<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_ProgramNew.ascx.cs" Inherits="MOD.WebTd.UserControls.UC_ProgramNew" %>
<h3><img src="Images/depend/new.gif" alt=""/></h3>
<ul class="list newpro">
<asp:Repeater ID="rptNewList" runat="server">
     <ItemTemplate>
         <li><a href="ProgramInfo.aspx?pid=<%#Eval("PId") %>"><%#this.SubMixText(Eval("PName").ToString(), 20)%></a></li>
     </ItemTemplate>
 </asp:Repeater>
</ul>
<div class="btm"></div>
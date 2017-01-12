<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_ProgramTop.ascx.cs" Inherits="MOD.WebTd.UserControls.UC_ProgramTop" %>
 <h3><img src="Images/depend/pop.gif" alt=""/></h3>
 <ul class="list pop">
     <asp:Repeater ID="rptPopList" runat="server">    
     <ItemTemplate>
      <li><span class="nb"><%#rptPopList.Items.Count+1%>.</span><a href="ProgramInfo.aspx?pid=<%#Eval("PId") %> ">
      <%#this.SubMixText(Eval("PName").ToString(), 20)%></a><%#Eval("PReadCount")%></li>
     </ItemTemplate>
     </asp:Repeater>  
 </ul>
 <div class="btm"></div>
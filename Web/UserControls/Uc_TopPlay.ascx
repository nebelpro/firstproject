<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Uc_TopPlay.ascx.cs" Inherits="MOD.WebTd.UserControls.Uc_TopPlay" %>
 <div>
     <div class="topplay-top"></div>
     <div class="blist"> 
     <ul class="poplist">
        <ul>
         <asp:Repeater ID="rptPopList" runat="server">    
         <ItemTemplate>
          <li><span class="nb"><%#rptPopList.Items.Count+1%>.</span><a href="ProgramInfo.aspx?pid=<%#Eval("PId") %> ">
          <%#MOD.WebUtility.WebHelper.GetSubString(Eval("PName").ToString(), 10)%></a><%#Eval("PReadCount")%></li>
         </ItemTemplate>
         </asp:Repeater>  
      </ul>
     </div>
     <div class="bbtm"></div>
</div>
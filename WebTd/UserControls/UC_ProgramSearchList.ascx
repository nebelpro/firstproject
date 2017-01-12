<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_ProgramSearchList.ascx.cs" Inherits="MOD.WebTd.UserControls.UC_ProgramSearchList" %>
<asp:Literal ID="lbPage_Top" runat="server"></asp:Literal> 
<div class="programView">
<asp:Repeater ID="rptPrmList" runat="server">
<ItemTemplate>
<div class="view-item">   
<table>
   <tr><td class="view-item-img"><a href="ProgramInfo.aspx?pid=<%#Eval("PId")%>">
            <img src="<%# MOD.WebUtility.ProgramHelper.GetProgramImage((Int32)Eval("PImageId")) %>" 
            <%#MOD.WebUtility.ProgramHelper.OutImageWidthHeight(100,100,Int32.Parse(Eval("PImageId").ToString())) %>  alt="<%#Eval("PName") %>" /></a>
        </td>
        <td class="view-item-info">
            <table>
                <tr><th class="view-item-title"><img title="<%=this.GetRes("INFO_PROGRAM_PLAY") %>" class="hand" onclick="OpenPlay('<%#MOD.WebUtility.WebHelper.EncryptPid(Int32.Parse(Eval("PId").ToString())) %>',0,<%#Eval("PMediaKind") %>);" src="Images/mediatype/<%#MOD.WebUtility.WebHelper.GetMediaType(int.Parse(Eval("PMediaKind").ToString()))%>" alt="" />
                <a href="ProgramInfo.aspx?pid=<%#Eval("PId")%>"><%#this.SubMixText(Eval("PName").ToString(), 16,"...")%> </a></th></tr>               
                <tr><td><%=this.GetRes("INFO_PROGRAM_LENGTH")%>:<span class="movie"> <%#Eval("nTime") %></span></td></tr>
                <tr><td><%=this.GetRes("INFO_PROGRAM_POINT")%>: <span class="movie"><%#Eval("PPoint") %></span></td></tr>
                <tr><td><%=this.GetRes("INFO_PROGRAM_VIEW")%>: <span class="movie"><%#Eval("PReadCount") %></span></td></tr>
            </table>
        </td>
   </tr>
</table>			            
</div>
</ItemTemplate>
</asp:Repeater>
<asp:Literal ID="ltrEmpty" runat="server"></asp:Literal>     
</div>
<asp:Literal ID="lbPage_Bottom" runat="server"></asp:Literal> 

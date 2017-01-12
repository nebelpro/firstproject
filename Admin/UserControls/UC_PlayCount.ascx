<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_playcount.ascx.cs" Inherits="MOD.Admin.UserControls.uc_playcount" %>
<div class="rRow">
    <h3><%=GetRes("Info_PlayCount")%></h3>
    <div class="ListBar"><div class="left"><%=GetRes("Info_PlayTime")%>:
         <input type="text" onclick="PopCal(this);"  readonly="readonly"  id="txtBeginTime" class="txt" /> - 
         <input type="text" onclick="PopCal(this);"  readonly="readonly"  id="txtEndTime" class="txt"/>(YYYY-MM-DD)
    <input type="button" onclick="log.SearchCount();" class="btn" value="<%=GetRes("Oper_Search") %>" /></div></div>
    
<div class="ListBar">     
    <div class="left"></div>      
    <div class="right"><asp:Literal ID="ltrListTop" runat="server"></asp:Literal></div>
</div>
<asp:Repeater ID="rptList" runat="server">
    <HeaderTemplate>
        <table id="PlayCount">
            <tr class="hdr">
            <td class="w1"><%=GetRes("Info_ProgramName") %></td>
            <td class="w2"><%=GetRes("Info_ProgramReadCount") %></td>
            <td class="w3"><%=GetRes("Info_ProgramTime") %></td>
            <td class="w4"><%=GetRes("Info_ProgramKbps") %></td>
            <td class="w5"><%=GetRes("Info_ProgramAddTime") %></td></tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr class="item">
            <td class="w1"><%#Eval("PName") %></td>
            <td class="w2"><%#Eval("PPoint") %></td><!-- ½èÓÃ¿ÕÏÐ×Ö¶Î´æ´¢ lre_count -->
            <td class="w3"><%#Eval("nTime") %></td>
            <td class="w4"><%#Eval("nKbps") %> kbps</td>
            <td class="w5"><%#Eval("PAddTime")%></td>
        </tr>
    </ItemTemplate>
    <AlternatingItemTemplate>
         <tr class="alter">
            <td class="w1"><%#Eval("PName") %></td>
            <td class="w2"><%#Eval("PPoint") %></td>
            <td class="w3"><%#Eval("nTime") %></td>
            <td class="w4"><%#Eval("nKbps") %> kbps</td>
            <td class="w5"><%#Eval("PAddTime")%></td>
        </tr>
    </AlternatingItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>
<asp:Literal ID="ltrEmpty" runat="server"></asp:Literal>
<div class="ListBar">     
     <div class="left"></div>    
     <div class="right"><asp:Literal ID="ltrListBtm" runat="server"></asp:Literal></div>
</div>
</div>


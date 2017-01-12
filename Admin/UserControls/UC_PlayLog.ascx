<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_playlog.ascx.cs" Inherits="MOD.Admin.UserControls.uc_playlog" %>
<div class="rRow">
    <h3><%=GetRes("Info_PlayLog")%></h3>
    <div class="ListBar"><div class="left"><%=GetRes("Info_PlayTime")%>:
      <input type="text" id="txtBeginTime"  readonly="readonly"  onclick="PopCal(this);" class="txt" /> - 
      <input type="text"  readonly="readonly"  onclick="PopCal(this);" id="txtEndTime" class="txt"/>(YYYY-MM-DD)
      <input type="button" class="btn" onclick="log.SearchLog();" value="<%=GetRes("Oper_Search") %>" />
    </div></div>    
<div class="ListBar">     
    <div class="left"><asp:Literal ID="ltrOperTop" runat="server"></asp:Literal></div>           
    <div class="right"><asp:Literal ID="ltrListTop" runat="server"></asp:Literal></div>
</div>   
<asp:Repeater ID="rptList" runat="server">
    <HeaderTemplate>
        <table id="PlayLog">
            <tr class="hdr">
               <td class="w1"></td>
               <td class="w2"><%=GetRes("Info_PlayUser")%></td>
               <td class="w3"><%=GetRes("Info_ProgramName") %></td>
               <td class="w4"><%=GetRes("Info_PlayTime")%></td>
               <td class="w5"><%=GetRes("Info_PlayUsePoint")%></td>
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr class="item">
            <td class="w1"><input name="pcpid" value="<%#Eval("PcpId") %>"  type="checkbox"/></td>
            <td>
                <%#Eval("PcpUserMask")%></td>
            <td>
                <%#Eval("PcpProgramName")%></td>
            <td>
                <%#Eval("PcpDateTime")%></td>
            <td>
                <%#Eval("PcpProgramPoint")%></td>
        </tr>
    </ItemTemplate>
    
    <AlternatingItemTemplate>
      <tr class="alter">
            <td class="w1"><input name="pcpid" value="<%#Eval("PcpId") %>"  type="checkbox"/></td>
            <td>
                <%#Eval("PcpUserMask")%></td>
            <td>
                <%#Eval("PcpProgramName")%></td>
            <td>
                <%#Eval("PcpDateTime")%></td>
            <td>
                <%#Eval("PcpProgramPoint")%></td>
        </tr>
    </AlternatingItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>

   </asp:Repeater>
   <asp:Literal ID="ltrEmpty" runat="server"></asp:Literal>
   <div class="ListBar">  
         <div class="left">
            <asp:Literal ID="ltrOperBtm" runat="server"></asp:Literal></div>        
        <div class="right"><asp:Literal ID="ltrListBtm" runat="server"></asp:Literal></div>
   </div>
</div>
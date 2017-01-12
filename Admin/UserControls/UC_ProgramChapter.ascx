<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_ProgramChapter.ascx.cs" Inherits="MOD.Admin.UserControls.UC_ProgramChapter" %>
<div class="rRow">
  <h3><%=GetRes("Info_Chapter")%></h3> 
  <asp:Repeater ID="rptList" runat="server">
    <HeaderTemplate>
      <table id="pChapter">
      <tr class="hdr">
         <td class="w1"><%=GetRes("Info_ChapterName")%></td>
         <td class="w2"><%=GetRes("Info_ChapterTime")%></td>
         <td class="w3"><%=GetRes("Info_ChapterKbps")%></td>
         <td class="w4"><%=GetRes("Info_ChapterPlay")%></td>
         <td class="w5"><%=GetRes("Info_ChapterDown")%></td>
      </tr>
    </HeaderTemplate>
    <ItemTemplate>
      <tr class="item">
      <td class="w1"><%# MOD.WebUtility.ProgramHelper.GetChapterName(MOD.WebUtility.WebHelper.HtmlEncode(Eval("PcName").ToString())) %></td>
      <td><%#Eval("nTime") %></td>
      <td ><%#Eval("nKbps") %></td>
      <td ><a href="javascript://" onclick="program.Play('<%#MOD.WebUtility.WebHelper.EncryptPid(int.Parse(Eval("PcProgramId").ToString()))%>',<%#Eval("PcOrder")%>,<%#Eval("PcMediaKind")%>)"><%=GetRes("Info_ChapterPlay")%></a></td>
      <td ><a href="javascript://" onclick="program.MediaDown('<%#MOD.WebUtility.WebHelper.EncryptPid(int.Parse(Eval("PcProgramId").ToString()))%>',<%#Eval("PcId")%>,<%#Eval("PcMediaKind")%>);"><%=GetRes("Info_ChapterDown")%></a></td></tr>
    </ItemTemplate>
    <AlternatingItemTemplate>
      <tr class="alter"><td class="w1" ><%# MOD.WebUtility.ProgramHelper.GetChapterName(MOD.WebUtility.WebHelper.HtmlEncode(Eval("PcName").ToString())) %></td>
      <td ><%#Eval("nTime") %></td>
      <td ><%#Eval("nKbps") %></td>
      <td ><a href="javascript://" onclick="program.Play('<%#MOD.WebUtility.WebHelper.EncryptPid(int.Parse(Eval("PcProgramId").ToString()))%>',<%#Eval("PcOrder")%>,<%#Eval("PcMediaKind")%>)"><%=GetRes("Info_ChapterPlay")%></a></td>
      <td ><a href="javascript://" onclick="program.MediaDown('<%#MOD.WebUtility.WebHelper.EncryptPid(int.Parse(Eval("PcProgramId").ToString()))%>',<%#Eval("PcId")%>,<%#Eval("PcMediaKind")%>);"><%=GetRes("Info_ChapterDown")%></a></td></tr>
    </AlternatingItemTemplate>
    <FooterTemplate> </table></FooterTemplate>
  </asp:Repeater>
</div>
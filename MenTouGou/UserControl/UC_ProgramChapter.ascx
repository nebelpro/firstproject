<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_ProgramChapter.ascx.cs" Inherits="mentougou.UserControl.UC_ProgramChapter" %>
<div class="subb">
  <h3><img src="Images/depend/h3_chapter.gif" alt="" /></h3> 
  <div class="subcontent">       
  <asp:Repeater ID="rptChapterList" runat="server" OnItemDataBound="rptChapterList_ItemDataBound">
    <HeaderTemplate>
      <table id="pChapter">
      <tr class="hdr">
         <td class="w0"></td>
         <td class="w1"><%=GetRes("Info_ChapterName")%></td>
         <td class="w2"><%=GetRes("Info_ChapterTime")%></td>
         <td class="w3"><%=GetRes("Info_ChapterKbps")%></td>
         <td class="w4"></td>
        
      </tr>
    </HeaderTemplate>
    <ItemTemplate>
      <tr class="item">
      <td class="w0"><img src="Images/mediatype/<%#MOD.WebUtility.WebHelper.GetMediaType(int.Parse(Eval("PCMediaKind").ToString()))%>" alt="" /></td>
      <td class="w1"><%# MOD.WebUtility.ProgramHelper.GetChapterName(MOD.WebUtility.WebHelper.HtmlEncode(Eval("PcName").ToString())) %></td>
      <td class="w2"><%#Eval("nTime") %></td>
      <td class="w3"><%#Eval("nKbps") %></td>
      <td class="w4"><asp:Literal ID="ltrChapterPlay" runat="server"></asp:Literal>  
       &nbsp;&nbsp;&nbsp;&nbsp;
       <asp:Literal ID="ltrChapterDown" runat="server"></asp:Literal></td>
      </tr>
    </ItemTemplate>
    <AlternatingItemTemplate>
      <tr class="alter">
      <td class="w0"><img src="Images/mediatype/<%#MOD.WebUtility.WebHelper.GetMediaType(int.Parse(Eval("PCMediaKind").ToString()))%>" alt="" /></td>
      <td class="w1"><%# MOD.WebUtility.ProgramHelper.GetChapterName(MOD.WebUtility.WebHelper.HtmlEncode(Eval("PcName").ToString())) %></td>
      <td class="w2"><%#Eval("nTime") %></td>
      <td class="w3"><%#Eval("nKbps") %></td>
      <td class="w4"><asp:Literal ID="ltrChapterPlay" runat="server"></asp:Literal>
      &nbsp;&nbsp;&nbsp;&nbsp;
      <asp:Literal ID="ltrChapterDown" runat="server"></asp:Literal></td>      
      </tr>
    </AlternatingItemTemplate>
    <FooterTemplate> </table></FooterTemplate>
  </asp:Repeater>
  </div>
<div class="subfooter"></div>
</div>
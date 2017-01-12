<%@ Control Language="C#" AutoEventWireup="true" EnableViewState="false" Codebehind="UC_ProgramList.ascx.cs"
    Inherits="MOD.UI.UserControls.UC_ProgramList" %>
<%@ Register Src="~/UserControls/UC_CatalogView.ascx" TagName="CatalogView" TagPrefix="UC" %>

<h3><asp:Literal ID="ltrCatalogName" runat="server"></asp:Literal></h3>
<UC:CatalogView ID="UC_CatalogView1" runat="server" /> 
<asp:Literal ID="ltrListTop" runat="server"></asp:Literal> 
<asp:Repeater ID="rptCataloglist" runat="server">
<ItemTemplate>
<div class="prmblock">
    <table class="view-item">
        <tr><td class="view-item-img"><a href="javascript://" onclick="<%#MOD.WebUtility.ProgramHelper.GetPlayUrl(int.Parse(Eval("PId").ToString()), 0, 0)%>">
        <img title="<%#Eval("PName") %>" src="<%#MOD.WebUtility.ProgramHelper.GetProgramImage(int.Parse(Eval("PImageId").ToString())) %>"
         <%#MOD.WebUtility.ProgramHelper.OutImageWidthHeight(120,100,int.Parse(Eval("PImageId").ToString())) %>  alt="" />
         </a></td>
            <td class="view-item-info"><table>            
                    <tr><th><img title="<%=this.GetRes("INFO_PROGRAM_PLAY") %>" class="hand" onclick="<%#MOD.WebUtility.ProgramHelper.GetPlayUrl(int.Parse(Eval("PId").ToString()), 0, 0)%>" src="Images/mediatype/<%#MOD.WebUtility.WebHelper.GetMediaType(int.Parse(Eval("PMediaKind").ToString()))%>" alt="" />
                    <a href="Programinfo.aspx?pid=<%#Eval("PId")%>"><span class="movie"><%#this.SubMixText(Eval("PName").ToString(),20,"...") %></a></span></th></tr>
                    <tr><td><%=this.GetRes("INFO_PROGRAM_LENGTH")%>: <span class="movie"> <%#Eval("nTime") %></span></td></tr>
                    <tr><td><%=this.GetRes("INFO_PROGRAM_ADDTIME")%>: <span class="movie"><%#Eval("PAddTime") %></span></td></tr>
                    <tr><td><%=this.GetRes("INFO_PROGRAM_VIEW")%>: <span class="movie"><%#Eval("PReadCount") %></span></td></tr>    
                    <tr><td class="play">[<a href="javascript://" onclick="<%#MOD.WebUtility.ProgramHelper.GetPlayUrl(int.Parse(Eval("PId").ToString()), 0, 0)%>"><%=this.GetRes("Info_Play") %></a>]</td></tr>               
             </table></td>
        </tr>        
    </table>    
</div>
</ItemTemplate>
</asp:Repeater>
<asp:Repeater ID="rptProgramList2" runat="server">      
    <HeaderTemplate><table id="ProgramListModel"><tr class="hdr">
            <th class="w1"></th>
            <th class="w2"><%=this.GetRes("INFO_PROGRAM_NAME")%></th>
            <th class="w3"><%=this.GetRes("INFO_PROGRAM_VIEW")%></th>
            <th class="w4"><%=this.GetRes("INFO_PROGRAM_ADDTIME")%></th>
            <th class="w5"><%=this.GetRes("INFO_PROGRAM_LENGTH")%></th>
            <th class="w6"><%=this.GetRes("INFO_PROGRAM_KBPS")%>(kbps)</th>
            <th class="w7"></th>
            </tr></HeaderTemplate>
    <ItemTemplate>
        <tr class="item">
            <td class="w1"><img title="<%=this.GetRes("INFO_PROGRAM_PLAY") %>" class="hand" onclick="<%#MOD.WebUtility.ProgramHelper.GetPlayUrl(int.Parse(Eval("PId").ToString()), 0, 0)%>" src="Images/mediatype/<%#MOD.WebUtility.WebHelper.GetMediaType(int.Parse(Eval("PMediaKind").ToString()))%>" alt="" /></td>
            <td class="w2"><a href="Programinfo.aspx?pid=<%#Eval("PId")%>"><span class="movie"><%#this.SubMixText(Eval("PName").ToString(),20,"...") %></a></td>
            <td class="w3"><%#Eval("PReadCount") %></td>
            <td class="w4"><%#Eval("PAddTime") %></td>
            <td class="w5"><%#Eval("nTime") %></td>
            <td class="w6"><%#Eval("nKbps") %></td>
            <td class="w7"><a href="javascript://" onclick="<%#MOD.WebUtility.ProgramHelper.GetPlayUrl(int.Parse(Eval("PId").ToString()), 0, 0)%>"><%=this.GetRes("Info_Play") %></a></td>
       </tr></ItemTemplate>
    <AlternatingItemTemplate>
        <tr class="alter">
            <td class="w1"><img title="<%=this.GetRes("INFO_PROGRAM_PLAY") %>" class="hand" onclick="<%#MOD.WebUtility.ProgramHelper.GetPlayUrl(int.Parse(Eval("PId").ToString()), 0, 0)%>" src="Images/mediatype/<%#MOD.WebUtility.WebHelper.GetMediaType(int.Parse(Eval("PMediaKind").ToString()))%>" alt="" /></td>
            <td class="w2"><a href="Programinfo.aspx?pid=<%#Eval("PId")%>"><span class="movie"><%#this.SubMixText(Eval("PName").ToString(),20,"...") %></a></td>
            <td class="w3"><%#Eval("PReadCount") %></td>
            <td class="w4"><%#Eval("PAddTime") %></td>
            <td class="w5"><%#Eval("nTime") %></td>
            <td class="w6"><%#Eval("nKbps") %></td>
            <td class="w7"><a href="javascript://" onclick="<%#MOD.WebUtility.ProgramHelper.GetPlayUrl(int.Parse(Eval("PId").ToString()), 0, 0)%>"><%=this.GetRes("Info_Play") %></a></td>
       </tr>
    </AlternatingItemTemplate>
    <FooterTemplate></table></FooterTemplate>
</asp:Repeater>
<asp:Literal ID="ltrEmpty" runat="server"></asp:Literal>
<p style=" clear:both;"></p>
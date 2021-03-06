<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_GroupList.ascx.cs" Inherits="MOD.Admin.UserControls.UC_GroupList" %>
<div class="rRow">
  <h3><%=GetRes("Info_GroupMng")%></h3>     
     <asp:Repeater ID="rptList" runat="server">
       <HeaderTemplate>
        <table id="grouplist">
        <tr class="hdr">
           <td class="w1"></td>
           <td class="w2"><%=GetRes("Info_GroupName")%></td>
           <td class="w3"><%=GetRes("Info_GroupClass")%></td></tr>
       </HeaderTemplate>
       <ItemTemplate>
         <tr class="item">
            <td class="w1"><%#MOD.Admin.Helper.GroupIsDisabled(Eval("GId").ToString())%></td>
            <td><a href="javascript://" onclick="group.AreaEdit(<%#Eval("GId") %>);"><%#Eval("GName") %></a></td>
            <td><%#Eval("GClass") %></td>
         </tr>
       </ItemTemplate>
       <AlternatingItemTemplate>
        <tr class="alter">
            <td class="w1"><%#MOD.Admin.Helper.GroupIsDisabled(Eval("GId").ToString())%></td>
            <td><a href="javascript://" onclick="group.AreaEdit(<%#Eval("GId") %>);"><%#Eval("GName") %></a></td>
            <td><%#Eval("GClass") %></td>
        </tr>
       </AlternatingItemTemplate>
       <FooterTemplate></table></FooterTemplate>
     </asp:Repeater> 
    <asp:Literal ID="ltrEmpty" runat="server"></asp:Literal>
    <div class="ListBar">
      <div class="left"><asp:Literal ID="ltrOperBtm" runat="server"></asp:Literal></div>
      <div class="right"><asp:Literal ID="ltrListBtm" runat="server"></asp:Literal></div>
    </div>
</div>


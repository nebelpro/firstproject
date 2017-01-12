<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_CatalogList.ascx.cs" Inherits="MOD.Admin.UserControls.UC_CatalogList" %>
<div class="rRow">
   <h3><%=GetRes("Info_CatalogList")%></h3>
   <div class="OperBar"><%=GetRes("Info_CatalogPath")%>
      <asp:Literal ID="ltrCatalogStep" runat="server"></asp:Literal></div>        
    <asp:Repeater ID="rptList" runat="server">
      <HeaderTemplate>
         <ul id="CatalogList">         
      </HeaderTemplate>
      <ItemTemplate>
        <li><a href="javascript://" onclick="catalog.GetList(<%#Eval("CId") %>);"><%#Eval("CName") %></a></li>
      </ItemTemplate>         
      <FooterTemplate>
          </ul>
      </FooterTemplate>
     </asp:Repeater>  
   <asp:Literal ID="ltrEmpty" runat="server"></asp:Literal>     
       
   
   <div class="ListBar">
      <div class="left"></div>
      <div class="right">
      <asp:Literal ID="ltrListBtm" runat="server"></asp:Literal></div>
      </div>
</div>
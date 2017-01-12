<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_CatalogMng.ascx.cs" Inherits="MOD.Admin.UserControls.UC_CatalogMng" %>
<div class="rRow">
   <h3><%=GetRes("Oper_CatalogMng") %></h3>
   <ul id="CatalogOper">
      <li><label><%=GetRes("Info_CatalogName")%>:</label>&nbsp;<asp:Literal ID="ltrName" runat="server"></asp:Literal></li>
      <li><label><%=GetRes("Info_CatalogOper") %>:</label><asp:Literal ID="ltrRadioGroup" runat="server"></asp:Literal></li>
      <li id="liName"><label><%=GetRes("Info_CatalogNameValue") %>:</label><input type="text" id="txtName" class="txt"/></li>
      <li><label>&nbsp;</label><asp:Literal ID="ltrBtn" runat="server"></asp:Literal></li>
      
   </ul>
</div>

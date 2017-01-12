<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_CardAddSearch.ascx.cs" Inherits="MOD.Admin.UserControls.uc_searchaddpoint" %>
 <div class="rRow">
<h3><%=GetRes("Info_CardUseSearch")%></h3>
<ul class="cardArea">
    <li>
        <label><%=GetRes("Info_CardUseDate")%>:</label>
        <input type="text" class="txt"  readonly="readonly"  id="txtDateBegin" onclick="PopCal(this);" /> - 
        <input type="text" id="txtDateEnd"  readonly="readonly"  onclick="PopCal(this);" class="txt" />(YYYY-MM-DD) </li>
    <li>
        <label><%=GetRes("Info_CardUsePerson")%>:</label>
        <input type="text" id="txtMask" class="txt"/></li>
    <li>
        <label>&nbsp;</label>
        <input type="button"  class="btn"  value="<%=GetRes("Oper_Search2")%>" onclick="card.SearchAddPoint(1);" />
         <%=GetRes("Warn_InputEmptyOfSearch")%> </li>
</ul>
</div>
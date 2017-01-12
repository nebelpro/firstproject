<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_cardsearch.ascx.cs" Inherits="MOD.Admin.UserControls.uc_cardsearch" %>
 <div class="rRow">
<h3><%=GetRes("Info_CardSearch")%></h3>
<ul class="cardArea">
    <li>
        <label><%=GetRes("Info_CardNo")%>:</label><input type="text" id="txtCardNo" class="txt" /></li>
    <li>
        <label><%=GetRes("Info_CardValid")%>:</label>
        <input type="text" id="txtBeginValid"  readonly="readonly"  class="txt" onclick="PopCal(this);" /> - 
        <input type="text" id="txtEndValid"  readonly="readonly"  onclick="PopCal(this);"  class="txt"/>(YYYY-MM-DD) </li>
    <li>
        <label><%=GetRes("Info_CardState")%>:</label>
        <select id="selCardState" class="sel">
                <option value="-1"><%=GetRes("Info_CardState")%></option>
                <option value="0"><%=GetRes("Info_CardState0")%></option>
                <option value="1"><%=GetRes("Info_CardState1")%></option>
        </select>
    </li>
    <li>
        <label><%=GetRes("Info_CardType")%>:</label>
        <select id="selCardType" class="sel">
            <option value="-1"><%=GetRes("Info_CardType")%></option>
            <option value="0"><%=GetRes("Info_CardTypePoint")%></option>
            <option value="1"><%=GetRes("Info_CardTypeMonth")%></option>
            <option value="2"><%=GetRes("Info_CardTypeConsume")%></option>
        </select>
    </li>
    <li>
        <label><%=GetRes("Info_CardMaker")%>:</label>
        <input type="text" id="txtCardMaker" class="txt"/></li>
    <li>
        <label>&nbsp;</label>
        <input type="button" class="btn" value="<%=GetRes("Oper_Search2") %>" onclick="card.GetList(1);"/>
        <%=GetRes("Warn_InputEmptyOfSearch")%> </li>
</ul>
</div>
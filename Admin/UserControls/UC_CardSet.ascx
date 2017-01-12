<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_cardset.ascx.cs" Inherits="MOD.Admin.UserControls.uc_cardset" %>
<div class="rRow">
<h3><%=GetRes("Info_CardMake")%></h3>
<ul id="error">

</ul>
<ul class="cardArea">
    <li><%=GetRes("Info_CardReg")%></li>
    <li>
        <label><%=GetRes("Info_CardNoPrefix")%>:</label><input id="txtCardPrefix" type="text" class="txt" /><%=GetRes("Info_CardNoPrefixReg")%></li>
    <li>
        <label><%=GetRes("Info_CardNoBeginNo") %>:</label>
        <input id="txtCardNoBegin" type="text" class="txt" /><%=GetRes("Info_CardNoBeginNoReg")%></li>
    <li>
        <label><%=GetRes("Info_CardNoEndNo")%>:</label>
        <input id="txtCardNoEnd" type="text"  class="txt"/> <%=GetRes("Info_CardNoEndNoReg")%></li>
    <li>
        <label><%=GetRes("Info_CardValid") %>:</label>
        <input id="txtCardValid" type="text" readonly="readonly" class="txt" onclick="PopCal(this);" /> (YYYY-MM-DD) </li>
    <li>
        <label><%=GetRes("Info_CardType") %>:</label>
        <input name="cardType" value="0" id="cardType0" onclick="card.SelCardType(0)" checked="checked" type="radio" /><%=GetRes("Info_CardTypePoint")%>
        <input name="cardType" value="1" id="cardType1"onclick="card.SelCardType(1)" type="radio" /><%=GetRes("Info_CardTypeMonth")%>
        <input name="cardType" value="2" id="cardType2" onclick="card.SelCardType(2)" type="radio" /><%=GetRes("Info_CardTypeConsume")%>
    </li>
    <li id="CardValue">
        <label><%=GetRes("Info_CardPointValue") %>:</label><input id="txtCardValue" type="text" class="txt" /> <span id="CardUnit"><%=GetRes("Info_CardPoint")%></span>  
    </li>
    <li><label>&nbsp;</label><input type="button"  class="btn"  onclick="card.CardMake();" value="<%=GetRes("Oper_CardMake")%>" /></li>
  
</ul>
</div>
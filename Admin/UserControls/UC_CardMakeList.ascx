<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UC_CardMakeList.ascx.cs"
    Inherits="MOD.Admin.UserControls.UC_CardMakeList" %>
  <div class="rRow">
    <h3><%=GetRes("Info_CardList")%></h3>
   
        <asp:Repeater ID="rptList" runat="server">
            <HeaderTemplate>
                <table id="CardList">
                <tr class="hdr">
                     <td class="w1"></td>
                    <td class="w2"><%=GetRes("Info_CardNo") %></td>
                    <td class="w3"><%=GetRes("Info_CardPwd") %></td>
                    <td class="w4"><%=GetRes("Info_CardPoint")%></td>
                    <td class="w5"><%=GetRes("Info_CardState")%> </td>
                    <td class="w6"><%=GetRes("Info_CardValid")%></td>
                    <td class="w7"><%=GetRes("Info_CardMaker")%></td>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr class="item">
                    <td class="w1">
                        <input name="cardid" value="<%#Eval("PcId") %>" type="checkbox" /></td>
                    <td class="w2"><%#Eval("PcNumber")%></td>
                    <td class="w3"><%#Eval("PcPasswd")%></td>
                    <td class="w4"><%#Eval("PcPointValue")%><%#MOD.WebUtility.CardHelper.GetCardUnit(int.Parse(Eval("PcType").ToString()))%></td>
                    <td class="w5"><%#MOD.WebUtility.CardHelper.GetCardState(int.Parse(Eval("PcState").ToString()))%></td>
                    <td class="w6"><%#DateTime.Parse(Eval("PcValidDate").ToString()).ToShortDateString()%></td>
                    <td class="w7"><%#Eval("PcMakeUser")%></td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
               <tr class="alter">
                    <td class="w1">
                        <input name="cardid" value="<%#Eval("PcId") %>" type="checkbox" /></td>
                    <td class="w2"><%#Eval("PcNumber")%></td>
                    <td class="w3"><%#Eval("PcPasswd")%></td>
                    <td class="w4"><%#Eval("PcPointValue")%><%#MOD.WebUtility.CardHelper.GetCardUnit(int.Parse(Eval("PcType").ToString()))%></td>
                    <td class=""><%#MOD.WebUtility.CardHelper.GetCardState(int.Parse(Eval("PcState").ToString()))%></td>
                    <td class=""><%#DateTime.Parse(Eval("PcValidDate").ToString()).ToShortDateString()%></td>
                    <td class=""><%#Eval("PcMakeUser")%></td>
                </tr>
            
            </AlternatingItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
     <asp:Literal ID="ltrEmpty" runat="server"></asp:Literal>
    <div class="ListBar">
        <div class="left">
           <asp:Literal ID="ltrOperBtm" runat="server"></asp:Literal>            
        </div>
        <div class="right"><asp:Literal ID="ltrListBtm" runat="server"></asp:Literal></div>
    </div>
    </div>
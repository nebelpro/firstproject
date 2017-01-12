<%@ Control Language="C#" AutoEventWireup="true" EnableViewState="false" CodeBehind="UC_Bulletin.ascx.cs" Inherits="MOD.Admin.UserControls.UC_Bulletin" %>

<div class="rRow">
        <h3><%= GetRes("Info_BulletinList")%></h3>

      <div class="ListBar">  
          <div class="left"><asp:Literal ID="ltrOperTop" runat="server"></asp:Literal>
           </div>      
          <div class="right"><asp:Literal ID="ltrListTop" runat="server"></asp:Literal></div>
      </div>

  <asp:Repeater ID="rptBullist" runat="server">
      <HeaderTemplate>
      <table class="BulletinList">
      <tbody id="BulletinTable"></HeaderTemplate>
    <ItemTemplate>
        <tr class="cTitle">
          <td class="w1"><input name="bid" value="<%#Eval("BId") %>"  type="checkbox"/></td>
          <td class="w2" id="title<%#Eval("BId") %>">
           <a href="javascript://" onclick="bulletin.AreaEdit(<%#Eval("BId") %>)"> <%#Eval("BName")%></a>
          </td>
          <td class="w3"><%#Eval("BUserName") %></td>
          <td class="w4"><%#Eval("BAddTime")%></td>
        </tr>
        <tr class="cInfo"><td id="oper<%#Eval("BId")%>"></td><td colspan="3" id="Info<%#Eval("BId") %>"><%#Eval("BInfo") %></td></tr>
    </ItemTemplate>
    <FooterTemplate>
        </tbody>
         </table>
    </FooterTemplate>    
  </asp:Repeater>
  <asp:Literal ID="ltrEmpty" runat="server"></asp:Literal>
  
  

<div class="ListBar">     
    <div class="left"><asp:Literal ID="ltrOperBtm" runat="server"></asp:Literal>
     </div>      
    <div class="right"><asp:Literal ID="ltrListBtm" runat="server"></asp:Literal></div>
</div>


       
    </div>
       
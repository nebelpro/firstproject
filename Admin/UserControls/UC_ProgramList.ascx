<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_ProgramList.ascx.cs" Inherits="MOD.Admin.UserControls.UC_ProgramList" %>
<div class="rRow">
  <h3><%=GetRes("Info_ProgramList")%></h3>
  <div class="ListBar">
    <div class="left">
       <asp:Literal ID="ltrSelect1" runat="server"></asp:Literal>     
    </div>
    <div class="right"><asp:Literal ID="ltrListTop" runat="server"></asp:Literal></div>
  </div>  
  <!-- View Model 1 -->
   <asp:Repeater ID="rptListOne" runat="server">
    <HeaderTemplate><dl class="ProgramViewModelOne"></HeaderTemplate>
    <ItemTemplate>
         <dd>
          <img src="" alt="" />
          <ul>
            <li class="titleLi"><%#Eval("PName")%></li>
            <li>
              <ul>
                <li><%=GetRes("Info_ProgramTime")%>:<%#Eval("nTime") %></li>
                <li><%=GetRes("Info_ProgramKbps")%>: <%#Eval("nKbps") %> </li>
              </ul>
            </li>
            <li>
              <ul>
                <li><%=GetRes("Info_ProgramReadCount")%>: <%#Eval("PReadCount")%> </li>
                <li><%=GetRes("Info_ProgramAddTime")%>: <%#Eval("PAddTime")%> </li>
              </ul>
            </li>            
            <li class="btnLi">
              <input type="button" value="<%=GetRes("Oper_ProgramDetail")%>" />
              <input type="button" value="<%=GetRes("Oper_ProgramPlayOnline")%>" /></li>
          </ul>
        </dd>
    </ItemTemplate>
    <FooterTemplate></dl></FooterTemplate>
  </asp:Repeater>
  
  <!-- View Model 2 -->
  
  <asp:Repeater ID="rptListTwo" runat="server">
    <HeaderTemplate>
      <table class="ProgramViewModelTwo">
        <tr class="hdr">
           <td class="w0"></td>
           <td class="w1"><%=GetRes("Info_ProgramName")%></td>
           <td class="w2"><%=GetRes("Info_ProgramReadCount")%></td>
           <td class="w3"><%=GetRes("Info_ProgramAddTime")%></td>
           <td class="w4"><%=GetRes("Info_ProgramTime")%></td>
           <td class="w5"><%=GetRes("Info_ProgramKbps")%></td>
        </tr>
    </HeaderTemplate>
    <ItemTemplate>
      <tr class="item">
      <td class="w0"><input name="pid" value="<%#Eval("PId") %>"  type="checkbox"/></td>
      <td class="w1"><a href="javascript://" onclick="program.ShowInfo(<%#Eval("PId") %>)"><%#this.SubMixText(Eval("PName").ToString(),20,"...") %></a></td>
      <td class="w2"><%#Eval("PReadCount") %></td>
      <td class="w3"><%#DateTime.Parse(Eval("PAddTime").ToString()).ToShortDateString() %></td>
      <td class="w4"><%#Eval("nTime") %></td>
      <td class="w5"><%#Eval("nKbps")%></td></tr>
    </ItemTemplate>
    <AlternatingItemTemplate>
     <tr class="alter">
     <td class="w0"><input name="pid" value="<%#Eval("PId") %>"  type="checkbox"/></td>
     <td class="w1"><a href="javascript://" onclick="program.ShowInfo(<%#Eval("PId") %>)"><%#this.SubMixText(Eval("PName").ToString(), 20, "...")%></a></td>
     <td class="w2"><%#Eval("PReadCount") %></td>
     <td class="w3"><%#DateTime.Parse(Eval("PAddTime").ToString()).ToShortDateString() %></td>
     <td class="w4"><%#Eval("nTime") %></td><td class="w5"><%#Eval("nKbps")%></td></tr>
    </AlternatingItemTemplate>
    <FooterTemplate>
      </table>
    </FooterTemplate>
  </asp:Repeater>
 
  <!-- View Model 3 -->
  <asp:Repeater ID="rptListThree" runat="server">
    <HeaderTemplate></HeaderTemplate>
    <ItemTemplate>do you want Model 3 ?<br /></ItemTemplate>
    <FooterTemplate></FooterTemplate>
  </asp:Repeater>
  
  <asp:Literal ID="ltrEmpty" runat="server"></asp:Literal>
  <div class="ListBar">
     <div class="left">
       <asp:Literal ID="ltrOperBtm" runat="server"></asp:Literal>
    </div>
    <div class="right"><asp:Literal ID="ltrListBtm" runat="server"></asp:Literal></div>
  </div>
</div>
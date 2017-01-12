<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_ChannelMix.ascx.cs" Inherits="MOD.Admin.UserControls.UC_ChannelMix" %>
<div class="rRow">
   <h3><%=GetRes("Info_ChannelMixInfo") %></h3>
   <form id="formChannel" action="" <asp:Literal ID="ltrFrom" runat="server"></asp:Literal> >
       
      <table id="MixChannel">
         <tr><td class="w1"><%=GetRes("Info_ChannelMixName") %>:</td>
            <td class="w2">
               <asp:Literal ID="ltrName" runat="server"></asp:Literal></td></tr>
         <tr><td class="w1"><%=GetRes("Info_ChannelMixIntro")%>:</td>
            <td class="w2">
               <asp:Literal ID="ltrInfo" runat="server"></asp:Literal></td></tr>
         <tr>
            <td></td>
            <td class="tdbtn">
               <asp:Literal ID="ltrBtn" runat="server"></asp:Literal>
               <input class="btn" type="reset" value="<%=GetRes("Oper_Reset")%>" />
            </td></tr>
      
      </table>     
      </form>
</div>

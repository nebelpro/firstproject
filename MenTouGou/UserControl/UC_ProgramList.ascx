<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_ProgramList.ascx.cs" Inherits="mentougou.UserControl.UC_ProgramList" %>
 <div class="subb">
        <h3><img src="Images/depend/h3_programlist.gif" alt="" /></h3>
        <div class="subcontent">  
                <asp:Literal ID="ltrListTop" runat="server"></asp:Literal>
          <asp:Repeater ID="rptProgramList" runat="server">
                <HeaderTemplate>
                  <table class="programlist">
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
                      <td class="w0"><img src="Images/mediatype/<%#MOD.WebUtility.WebHelper.GetMediaType(int.Parse(Eval("PMediaKind").ToString()))%>" alt="" /></td>
                      <td class="w1"><a href="ProgramInfo.aspx?pid=<%#Eval("PId") %>"><%#this.SubMixText(Eval("PName").ToString(),30,"...") %></a></td>
                      <td class="w2"><%#Eval("PReadCount") %></td>
                      <td class="w3"><%#DateTime.Parse(Eval("PAddTime").ToString()).ToString() %></td>
                      <td class="w4"><%#Eval("nTime") %></td>
                      <td class="w5"><%#Eval("nKbps")%></td></tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                 <tr class="alter"> 
                     <td class="w0"><img src="Images/mediatype/<%#MOD.WebUtility.WebHelper.GetMediaType(int.Parse(Eval("PMediaKind").ToString()))%>" alt="" /></td>
                     <td class="w1"><a href="ProgramInfo.aspx?pid=<%#Eval("PId") %>"><%#this.SubMixText(Eval("PName").ToString(),30, "...")%></a></td>
                     <td class="w2"><%#Eval("PReadCount") %></td>
                     <td class="w3"><%#DateTime.Parse(Eval("PAddTime").ToString()).ToString() %></td>
                     <td class="w4"><%#Eval("nTime") %></td>
                     <td class="w5"><%#Eval("nKbps")%></td></tr>
                </AlternatingItemTemplate>
                <FooterTemplate>
                  </table>
                </FooterTemplate>
            </asp:Repeater>
            <asp:Literal ID="ltrEmpty" runat="server"></asp:Literal>
               <asp:Literal ID="ltrListBtm" runat="server"></asp:Literal>
             </div>
            <div class="subfooter"></div>
            
    </div>

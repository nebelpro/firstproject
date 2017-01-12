<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_GroupEdit.ascx.cs" Inherits="MOD.Admin.UserControls.UC_GroupEdit" %>
<div class="rRow">
  <h3><%=GetRes("Info_GroupInfo")%></h3>
  <form id="formGroup" action="">
  <table class="GroupInfo">
    <tr><td class="w1"><%=GetRes("Info_GroupName")%>:</td><td class="w2"><asp:Literal ID="ltrName" runat="server"></asp:Literal></td></tr>
    <tr><td class="w1"><%=GetRes("Info_GroupClass")%>:</td><td class="w2"><asp:Literal ID="ltrClass" runat="server"></asp:Literal>0-255</td></tr>
    <tr><td class="w1" style=" vertical-align:top;"><%=GetRes("Info_GroupPermit")%>:</td><td class="w2"><ul>
        <li><asp:Literal ID="ltrChkLogin" runat="server"></asp:Literal><%=GetRes("Per_Login")%></li>
        
        <li><asp:Literal ID="ltrChkUserCourse" runat="server"></asp:Literal><%=GetRes("Per_MyCourse")%></li>
        <li><asp:Literal ID="ltrChkProgram" runat="server"></asp:Literal><%=GetRes("Per_Program")%>
           <ul>
            <asp:Literal ID="ltrChkProgramItem" runat="server"></asp:Literal>
           </ul>
        </li>
        <li><asp:Literal ID="ltrChkCast" runat="server"></asp:Literal><%=GetRes("Per_Channel")%>
          <ul><asp:Literal ID="ltrChkCastItem" runat="server"></asp:Literal>
            </ul>
        </li>
        <li><asp:Literal ID="ltrChkSys" runat="server"></asp:Literal> <%=GetRes("Per_SomeManager")%>
          <ul><asp:Literal ID="ltrChkSysItem" runat="server"></asp:Literal>
            </ul>
        </li>
      </ul></td></tr>
    <tr><td class="w1"><%=GetRes("Info_GroupIntro")%>:</td><td class="w2"><asp:Literal ID="ltrInfo" runat="server"></asp:Literal></td></tr>
    <tr><td class="w1"></td><td class="w2"><asp:Literal ID="ltrBtnEdit" runat="server"></asp:Literal></td></tr>
    <tr><td class="w1"></td><td class="w2"></td></tr>
    <tr><td class="w1"></td><td class="w2"></td></tr>
  </table>  
  </form>
</div>
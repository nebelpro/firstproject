<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_ProgramInfo.ascx.cs" Inherits="MOD.Admin.UserControls.UC_ProgramInfo" %>
<div class="rRow">
  <h3><%=this.GetRes("Info_ProgramInfo")%></h3>
  <div id="pInfo">
     <asp:Literal ID="ltrImg" runat="server"></asp:Literal>
     <asp:Literal ID="ltrImgView" runat="server"></asp:Literal>
  <ul>
    <li class="titleLi"> <asp:Literal ID="ltrName" runat="server"></asp:Literal>
    </li>   
    <li><%=GetRes("Info_ProgramCatalog") %>: <asp:Literal ID="ltrCatalog" runat="server"></asp:Literal></li>
    <li>
      <ul>
        <li><%=GetRes("Info_ProgramDirector") %>: <asp:Literal ID="ltrDirector" runat="server"></asp:Literal></li>
        <li><%=GetRes("Info_ProgramClass") %>: <asp:Literal ID="ltrClass" runat="server"></asp:Literal></li>
      </ul>
    </li>
    <li>
      <ul>
        <li><%=GetRes("Info_ProgramActor") %>: <asp:Literal ID="ltrActor" runat="server"></asp:Literal></li>
        <li><%=GetRes("Info_ProgramPublish") %>: <asp:Literal ID="ltrPublish" runat="server"></asp:Literal></li>
      </ul>
    </li>
    <li>
      <ul>
        <li><%=GetRes("Info_ProgramTime") %>: <asp:Literal ID="ltrTime" runat="server"></asp:Literal></li>
        <li><%=GetRes("Info_ProgramKbps") %>: <asp:Literal ID="ltrKbps" runat="server"></asp:Literal> </li>
      </ul>
    </li>
    <li>
      <ul>
        <li><%=GetRes("Info_ProgramReadCount") %>:  <asp:Literal ID="ltrReadCount" runat="server"></asp:Literal> </li>
        <li><%=GetRes("Info_ProgramAddTime") %>:  <asp:Literal ID="ltrAddTime" runat="server"></asp:Literal> </li>
      </ul>
    </li>    
    <li>
      <ul>
        <li><%=GetRes("Info_ProgramAddUser") %>: <asp:Literal ID="ltrAddUser" runat="server"></asp:Literal></li>
        <li><%=GetRes("Info_ProgramPoint") %>: <asp:Literal ID="ltrPoint" runat="server"></asp:Literal>
        </li>
      </ul>
    </li>        
    <li class="btnLi">
       <asp:Literal ID="ltrOperator" runat="server"></asp:Literal>
          
    </li>
  </ul>
  </div>
</div>


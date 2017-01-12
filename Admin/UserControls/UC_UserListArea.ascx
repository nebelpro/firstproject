<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_UserListArea.ascx.cs" Inherits="MOD.Admin.UserControls.UC_UserListArea" %>
<div class="rRow">
  <h3><%=GetRes("Info_UserMng") %></h3>
  <div class="ListBar" >     
      <div class="left"><%=GetRes("Info_GroupSelect") %>: 
        <select id="selGroup" onchange="user.GetList(1);">
        <option value="0"><%=GetRes("Info_GroupAll") %></option>
        <asp:Repeater ID="rptGroupList" runat="server">
            <ItemTemplate>
              <option value="<%#Eval("GMask") %>"><%#Eval("GName") %></option>
            </ItemTemplate>
        </asp:Repeater>
        </select>
      </div>
      
      <div class="right">
          <%=GetRes("Info_Search2") %>:
          <select id="selSearType">
          <option value="0"><%=GetRes("Info_UserMask")%></option>
          <option value="1"><%=GetRes("Info_UserName")%></option></select>
          <input type="text" id="txtSearValue" class="txt" />
          <input type="button" class="btn" onclick="user.GetList(1);" value="<%=GetRes("Oper_Search") %>" />
      </div>
   </div>
    
    <div id="AreaUserList">
    
    </div>

</div>
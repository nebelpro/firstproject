<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_ProgramRemarkAdd.ascx.cs" Inherits="MOD.Admin.UserControls.UC_ProgramRemarkAdd" %>
<div class="rRow">
  <h3><%=GetRes("Info_RemarkAdd") %></h3>
  <dl id="RemarkAdd">
    <dd><%=GetRes("Info_RemarkTitle")%>: <input type="text" id="txtName" class="txt" /></dd>
    <dd><%=GetRes("Info_RemarkInfo")%>: <textarea rows="5" id="txtInfo" cols="16"></textarea></dd>
    <dd><input type="button" value="<%=GetRes("Oper_RemarkAdd") %>" onclick="program.AddRemark();" /></dd>
  </dl>
</div>
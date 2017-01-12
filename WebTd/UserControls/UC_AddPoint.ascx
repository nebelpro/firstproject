<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_AddPoint.ascx.cs" Inherits="MOD.WebTd.UserControls.UC_AddPoint" %>
<table id="addPoint">
    <tr><td class="w1"><%=this.GetRes("Info_CardNo")%>:</td><td class="w2"><input type="text" class="txt" id="txtNo" name="txtNo" /></td></tr>
    <tr><td class="w1"><%=this.GetRes("Info_CardPwd")%>:</td><td class="w2"><input type="password" class="txt" id="txtPwd" name="txtPwd" /></td></tr>
    <tr><td class="w1"></td><td class="w2"> <input type="image" class="ibtn" src="Images/depend/btn_ok.gif" onclick="user.AddPoint();" alt=""/></td></tr>
</table>
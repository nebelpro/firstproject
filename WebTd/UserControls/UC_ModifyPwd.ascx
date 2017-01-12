<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_ModifyPwd.ascx.cs" Inherits="MOD.WebTd.UserControls.UC_ModifyPwd" %>

<table id="modifyPwd">
    <tr><td class="w1"><%=this.GetRes("INFO_PWD_OLD")%>:</td><td class="w2"><input type="password" id="txtPwdOld" name="txtPwdOld" /></td></tr>
    <tr><td class="w1"><%=this.GetRes("INFO_PWD_NEW")%>:</td><td class="w2"><input type="password" id="txtPwdNew" name="txtPwdNew"  /></td></tr>
    <tr><td class="w1"><%=this.GetRes("INFO_PWD_NEWCONFIRM")%>:</td><td class="w2"><input type="password" id="txtConfirm" name="txtConfirm" /></td></tr>    
    <tr><td class="w1"></td><td class="w2" style=" text-align:right;"><img src="Images/depend/btn_ok.gif" onclick="user.ModifyPwd();" alt="submit"  /></td></tr>
</table>
<form id="modifyPwdForm">
<table id="modifyPwd">
    <tr><td class="w1">$RS.OldPwd$:</td><td class="w2"><input type="password" id="txtPwdOld" name="txtPwdOld" /></td></tr>
    <tr><td class="w1">$RS.NewPwd$:</td><td class="w2"><input type="password" id="txtPwdNew" name="txtPwdNew"  /></td></tr>
    <tr><td class="w1">$RS.Confirm$:</td><td class="w2"><input type="password" id="txtConfirm" name="txtConfirm" /></td></tr>    
    <tr><td class="w1"></td><td class="w2" style=" text-align:right;"><input class="btn"  type="image" src="Theme/default/Images/depend/btn_ok.gif" onclick="user.ModifyPwd();return false;" alt="submit"  /></td></tr>
</table>
</form>
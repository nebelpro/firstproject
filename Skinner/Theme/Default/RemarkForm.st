<form action="" id="RemarkForm">
<table class="addRemark">
    <tr><td class="w1">$RS.RemarkTitle$:</td>
        <td class="w2"><input type="text" id="txtTitle"  name="txtTitle" /></td></tr>
    <tr><td class="w1">$RS.RemarkContent$:</td>
    <td class="w2"><textarea id="txtContent" rows="5" cols="10" name="txtContent"></textarea></td></tr>
    <tr><td></td><td class="rowbtn">
    <input type="image" src="Theme/default/Images/depend/btn_submit.gif" onclick="user.AddRemark($PID$);return false;" />        
    <input type="image" src="Theme/default/Images/depend/btn_reset.gif" onclick="RemarkForm.reset();return false;" alt="" /></td></tr>
</table>
</form>


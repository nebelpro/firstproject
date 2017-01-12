<form action="" id="RemarkForm">
<p>$RS.NewRemark$</p>
<p class="hidden">$RS._RemarkTitle$<input type="text" id="txtTitle" value="NoTitle" name="txtTitle" /></p>
<p>$RS._RemarkContent$<textarea  class="txt" id="txtContent" rows="8" cols="10" name="txtContent"></textarea></p>
<p><input type="image" class="ibtn" src="Theme/webtd/Images/depend/btn_submit.gif" onclick="user.AddRemark($PID$);return false;" />&nbsp;&nbsp;&nbsp;&nbsp;
 <input type="image" class="ibtn" src="Theme/webtd/Images/depend/btn_reset.gif" onclick="RemarkForm.reset();return false;" alt="" />
</p>
</form>
       
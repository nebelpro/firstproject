<div class="ListBar">
    <div class="left">$RS.UseDate$:
        <input type="text" class="txt" id="txtDateBegin" name="dd" /> - <input type="text" class="txt" id="txtDateEnd" name="dd" />(YYYY-MM-DD)
        <input type="image" id="ibtnSearch" class="ibtn" onclick="user.btnChargeQuery(1);" src="Theme/webtd/Images/depend/btn_search.gif" alt="" />
    </div>
</div>
$if(hasCount)$
$ListTop$
<table>
  <tr>
    <td class="w1">$RS.CardNo$</td>
    <td class="w2">$RS.UseDate$</td>
    <td class="w3"></td>
  </tr>
  $Log:{
   <td class="w1">$it.CuNumber$</td>
        <td class="w2">$it.CuDateTime$</td>
        <td class="w3">$it.CuPointValue$($it.CuType$)</td>                                       
    </tr>
  }$
</table>
$else$
$ListEmpty$
$endif$
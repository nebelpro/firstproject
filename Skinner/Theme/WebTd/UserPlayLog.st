<div class="ListBar">
    <div class="left">$RS.PlayTime$:
        <input type="text" class="txt" id="txtDateBegin" name="txtDateBegin" /> - <input type="text" class="txt" id="txtDateEnd" name="txtDateEnd" />(YYYY-MM-DD)
        <input type="image" id="ibtnSearch" class="ibtn" onclick="user.btnPlayLogQuery(1);" src="Theme/webtd/Images/depend/btn_search.gif" alt="" />
    </div>
</div> 
$if(hasCount)$
    $ListTop$
    <table>
        <tr><td class="w1">$RS.ProgramName$</td><td class="w2">$RS.PlayTime$</td><td class="w3">$RS.CardValue$</td></tr>
	$Log:{
	    <tr>      
            <td class="w1"><a href="ProgramInfo.aspx?pid=$it.PcpProgramId$" target="_blank">$it.PcpProgramName$</a></td>
            <td class="w2">$it.PcpDateTime$</td>
            <td class="w3">$it.PcpProgramPoint$</td>                                       
        </tr>
	}$
    </table>
$else$
    $ListEmpty$
$endif$
<div class="mark">
    <div class="left"><img src="Theme/webtd/Images/depend/newpro.gif" alt=""/></div>
    <div class="right"></div>  
</div>    
<div id="prmlist">
    $Program:{
    <div class="view-item">   
        <table>
           <tr><td class="view-item-img"><a href="ProgramInfo.aspx?pid=$it.PId$">
                    <img src="$it.Image$" $it.Style$  alt="$it.PName$" /></a>
                </td>
                <td class="view-item-info">
                    <table>
                        <tr><th class="view-item-title"><img title="$RS.Play$"  class="hand" onclick="OpenPlay('$it.Id$',0,$it.PMediaKind$);" src="Images/mediatype/$it.TypeImg$" alt="" />
                        <a href="ProgramInfo.aspx?pid=$it.PId$">$it.Name$</a></th></tr>               
                        <tr><td>$RS.Length$:<span class="movie">$it.nTime$</span></td></tr>
                        <tr><td>$RS.Point$: <span class="movie">$it.PPoint$</span></td></tr>
                        <tr><td>$RS.View$: <span class="movie">$it.PReadCount$</span></td></tr>                   
                        
                    </table>
                </td>
           </tr>
        </table>			            
    </div>       
    }$
</div>
<div id="position"><a href="Default.aspx">$position$</a> - <span>$RS.Bulletin$</span></div>
$Banner()$
<div class="mark">
    <div class="left"><img src="Theme/webtd/Images/depend/bul_list.gif" alt=""/></div>
    <div class="right"></div>  
</div>       
$ListNav$
$if(HasCount)$
    <table id="BulletinList">$BulletinList:{
    <tr class="item"><td class="w1">
                <a href="#" onclick="user.GetBulletinInfo($it.BId$,'$it.BName$');" title="$it.BName$">
                   $it.BName$
                </a>
            </td>
            <td class="w2">
                $it.BAddTime$
            </td>
        </tr>
    }$
    </table>
$else$
    $ListEmpty$
$endif$


    

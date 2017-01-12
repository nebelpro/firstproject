$if(HasCount)$
    $ListNav$
    <div id="ProgramList">
        <ul>$Program:{
            <li>
                <div class="pimg left">
                    <table><tr><td>
                    <a href="Programinfo.aspx?pid=$it.PId$">
                    <img src="$it.Image$" $it.Style$  alt="$it.PName$" />
                     </a></td></tr></table>
                </div>
                <div class="pitem left">
                    <h4><img title="$RS.Play$" class="hand" onclick="OpenPlay('$it.Id$',0,$it.PMediaKind$);" src="Images/mediatype/$it.TypeImg$" alt="" />
                    <a href="ProgramInfo.aspx?pid=$it.PId$">$it.Name$ </a></h4>               
                    <p>$RS.Length$: <span class="movie">$it.nTime$</span></p>
                    <p>$RS.Point$: <span class="movie">$it.PPoint$</span></p>
                    <p>$RS.View$: <span class="movie">$it.PReadCount$</span></p> 
                </div>
            </li>
        }$</ul>
    </div>
    $ListNav$
$else$
    $ListEmpty$
$endif$
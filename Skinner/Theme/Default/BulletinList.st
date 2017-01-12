<div id="BulletinList">
    <h3><span>$RS.Bulletin$</span></h3>
    $ListNav$
    $if(HasCount)$
        <ul>$BulletinList:{<li><a href="javascript://" 
            onclick="user.GetBulletinInfo($it.BId$,'$it.BName$');">$it.BName$</a> $it.BAddTime$</li>}$
        </ul>
    $else$
        $ListEmpty$
    $endif$
    $ListNav$
</div>
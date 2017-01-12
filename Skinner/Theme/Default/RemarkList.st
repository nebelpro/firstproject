$if(HasCount)$
$ListNav$
$Remark:{
<div class="Remark_item">
    <div class="title"><div class="left">$it.Title$</div><div class="right">$it.AddUser$ [$it.AddTime$]</div></div>
    <p>$it.Info$</p>
</div>}$
$else$
$ListEmpty$
$endif$

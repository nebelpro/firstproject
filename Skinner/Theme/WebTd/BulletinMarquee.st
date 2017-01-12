<div id="naver"><div class="left"></div>
$if(HasCount)$
<div id="bulletinNav"><marquee direction="left" onMouseOver="this.stop();" onMouseOut="this.start()" scrollamount="2" >
<ul>$Bulletin:{
<li><a href="BulletinList.aspx">[$it.BAddTime$] $it.Name$</a></li>
}$</ul></marquee></div>
$endif$
<div class="right"></div></div>
$if(HasCount)$
<marquee direction="left" onMouseOver="this.stop();" onMouseOut="this.start()" scrollamount="2" >
<ul id="bulletinNav">
$Bulletin:{
<li><a href="BulletinList.aspx">[$it.BAddTime$] $it.Name$</a></li>
}$</ul></marquee>
$endif$
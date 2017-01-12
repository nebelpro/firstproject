$if(HasCount)$
<ul id="CatalogList">
    $Catalog:{<li onmouseover="this.className='selected';" onmouseout="this.className='none';">
       <a href="ViewByClass.aspx?cid=$it.CId$">$it.CName$</a>&nbsp;&nbsp;[ $it.Count$ ]
     </li>}$     
</ul>
<p class="clear"></p> 
$endif$
$aa$
$if(HasModule)$
<ul id="module">
  $if(Program)$
    $if(pImg)$
        <li><a href="Program.aspx"><img src="Theme/default/Images/depend/programhot.gif" alt="" /> </a></li>
    $else$
        <li><a href="Program.aspx"><img src="Theme/default/Images/depend/program.gif" alt="" /> </a></li>
    $endif$
  $endif$  
  $if(Iptv)$
    $if(iImg)$
        <li><a href="Iptv.aspx"><img src="Theme/default/Images/depend/Iptvhot.gif" alt="" /></a></li>
    $else$
        <li><a href="Iptv.aspx"><img src="Theme/default/Images/depend/iptv.gif" alt="" /></a></li>
    $endif$
  $endif$  
  $if(Recorder)$  
    $if(rImg)$
        <li><a href="Recorder.aspx"><img src="Theme/default/Images/depend/recorderhot.gif" alt="" /></a></li>
    $else$
        <li><a href="Recorder.aspx"><img src="Theme/default/Images/depend/recorder.gif" alt="" /></a></li>
    $endif$
  $endif$  
</ul>
$endif$


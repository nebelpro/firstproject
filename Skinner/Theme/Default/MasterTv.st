<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" lang="zh-CN">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="Content-Language" content="utf-8" />
    <link rel="stylesheet" href="theme/default/Style/Tv.css" type="text/css"/>
    <script type="text/javascript" src="Scripts/prototype.js"></script>    
    <script type="text/javascript" src="theme/default/view.js"></script>  
    <script type="text/javascript" src="Scripts/mod.js"></script> 
    <title>$title$</title>    
</head>
<body>    
<div id="wrapper">
  <div id="toper">
    <div id="logo"><img src="Theme/default/Images/depend/$logo$" alt=""/></div>
    $Module$
  </div>
  <div id="topdomain"><img src="Theme/default/Images/depend/topdomain.gif" alt="" /></div>
  <div id="nav">$BulletinMarquee$</div>

  <div id="primary">
    <div id="firster">
      <div id="tvList">
        <h3><span>$RS.ChannelTitle$</span></h3>
        <div id="chaList">$ChannelList$</div>
      </div>
     <div id="tvInfo">
        <h3><span>$RS.ChannelInfo$</span></h3>
        <div id="chaInfo">
              <p id="castInfo"></p>
        </div>       
     </div>
     
    </div>
    <div id="seconder">
      <div class="video_player">
        <object id="MWP" classid="clsid:A58688A5-3C99-4B22-B29C-53545CEE03D2" viewastext> </object> 
        <div id="divImg"><img src="Images/depend/novideo.gif" alt="" /></div>
        <div id="Oper">
        <img src="Theme/default/Images/player/play_0.gif" style=" cursor:pointer;" id="imgPlay" onclick="PlayPause();" onmouseover="Mover_Play()" onmouseout="Mout_Play()" alt=""/>                    
        <img src="Theme/default/Images/player/separator.gif" id="separator" />
        <img src="Theme/default/Images/player/stop_0.gif" id="imgStop" onclick="Stop();" onmouseover="Mover_Stop();" onmouseout="Mout_Stop();"  style=" cursor:pointer;" alt="" />
        </div>
        <div id="Time"><span id="spTime"></span></div>
        <div>                    
            <span id="spRec"></span>
            <span id="spNow" style=" display:none;"></span>
        </div>
     </div>
    </div>
  </div> 
  $Footer$        
</div>
 <script type="text/javascript">   
    Event.observe(document.getElementById("chaList"), "click",ChannelSelected);  
    UpdateUserState();
 </script>
</body>
</html>
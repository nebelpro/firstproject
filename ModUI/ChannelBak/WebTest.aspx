<%@ Page Language="C#" AutoEventWireup="true" Codebehind="WebTest.aspx.cs" Inherits="MOD.UI.WebTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
     <script type="text/javascript" src="Scripts/_source/prototype.js"></script>
    <script type="text/javascript" src="Scripts/_source/CastUITest.js"></script>

    <style type="text/css">
<!--
	body {font-size:12px;}	
	.hand{cursor:hand;}
	.nohand{cursor:default;}
	#spVolumeSlider{background:url('Images/Player2/volume_1.gif') no-repeat;height:11px;width:40px;margin-top:3px;position:absolute;left:80px;}
	#spVolumeCur{background:url('Images/Player2/volume_0.gif') no-repeat;height:11px;width:0px;margin-top:-1px;position:absolute;z-Index:100;}
	#spVolumeBtn{margin-top:2px;position:absolute;cursor:hand;left:80px;}
-->
</style>
</head>
<body>
    <form id="form1" runat="server">
        <div style=" margin:0 auto; width:700px;">
            <div id="castcontent" style="width: 400px; height: 300px; float:left; ">
                <object id="MWP" style="width: 400px; height: 300px;" classid="clsid:A58688A5-3C99-4B22-B29C-53545CEE03D2" viewastext>
                </object>
                <div id="divImg">
                    <img src="Images/depend/novideo.gif" alt="" /></div>
            </div>
            <ul style=" float:left;">
                <li>正在播放:<span><%=this.GetRes("TA_NOW")%>:<span id="spNow"></span></span></li>
                <li>播放位率:<span id="spRec"></span>&nbsp;<span id="spBit"></span></li>
                <li>快进/后退:<img src="Images/player2/fr_2.gif">
                    -<img src="Images/player2/ff_2.gif"></li>
                <li>播放/暂停:<img src="Images/player2/play_0.gif" id="imgPlay" onclick="PlayPause();"
                    title="<%=this.GetRes("TA_PLAY")%>" class="hand" onmouseover="Mover_Play()" onmouseout="Mout_Play()"></li>
                <li>停止:<img src="Images/player2/stop_0.gif" id="imgStop" onclick="Stop();" onmouseover="this.src='Images/player2/stop_1.gif'"
                    onmouseout="this.src='Images/player2/stop_0.gif'" class="hand" title="<%=this.GetRes("TA_STOP")%>"></li>
                <li>频道录制:<img src="Images/player2/rec_4.gif" id="imgRec" onclick="Rec();"></li>
                <li>时间状况:<span id="spTime"></span></li>
                <li>全屏:<img id="imgFull" onmouseover="this.src='Images/player2/full_1.gif'" onmouseout="this.src='Images/player2/full_0.gif'"
                    src="Images/player2/full_0.gif" onclick="SetFull()" title="<%=this.GetRes("TA_FULL")%>"
                    class="hand"></li>
                <li>静音:<img id="imgMute" title="<%=this.GetRes("TA_MUTE")%>" src="Images/player2/mute_0.gif"
                    onclick="SetMute()" class="hand"></li>
                <li>声音控制: 
                    <span id="spRight" style="width:60px; margin-top: 4px; right:100px; position: absolute;">
                        <span id="spVolumeSlider"><span id="spVolumeCur"></span>
                    </span>
                    <span id="spVolumeBtn"  style="cursor: hand" onmousemove="SlideVolume(this)" onmouseup="SlideVolumeOver(this)">
                        <img src="Images/player2/volume_2.gif" style="cursor: hand">
                    </span> 
              </li>
              <li><span id="castInfo"></span>  </li>
                <asp:Literal ID="ltrCastPlay" runat="server"></asp:Literal>
            </ul>
        </div>
    </form>
    
</body>
</html>

<script type="text/javascript">
        function init(){  
            //var strPPPPPP="[{'cid':13,'auto':'1','ssrc':646997075,'receive':[{'type':'tcp','port':102,'ip':'192.168.0.113'},{'type':'udp','port':50133,'ip':'225.0.34.71'}]}]";
            var strPrm="<%=this.strParam %>";
           // alert(strPrm);
            if(strPrm=="-1"){
                ShowVideoEmpty();
            }else{
                Load(strPrm,"",0);
            }          
        }
       // window.onload =  init;
        
</script>


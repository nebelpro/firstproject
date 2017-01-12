var Toper=this;function handleMouseClick(e){var evt;if(typeof window.event!="undefined"){evt=window.event;}else{evt=e;}
var target;if(typeof evt.srcElement!="undefined"){target=evt.srcElement;}else{target=evt.target;}
NavSelected(target,"nav");}
function ChannelSelected(e){var eSrc=Event.element(e);if(eSrc.tagName.toUpperCase()=="a".toUpperCase()){var elt=Event.findElement(e,"div");if(elt!=document){for(var j=0;j<elt.childNodes.length;j++){var curNode=elt.childNodes[j];if(curNode.nodeType==1&&curNode.tagName.toUpperCase()=="ul".toUpperCase()){for(var i=0;i<curNode.childNodes.length;i++){var subNode=curNode.childNodes[i];if(subNode.nodeType==1){subNode.className="";}}}}
eSrc.parentNode.className="selected";}}}
function UpdateUserState(){setTimeout("UpdateUserState()",600000);var option={method:"get",parameters:"rnd="+Math.random()+"&oper=online",onSuccess:function(transport){},onFailure:function(transport){}}
var request=new Ajax.Request("ajax.aspx",option);}
var XmlRes=Class.create();XmlRes.prototype={initialize:function(strPath){this.XmlDoc=this.GetXmlDoc(strPath);},GetXmlDoc:function(strPath){if(window.ActiveXObject){var xmlObj=new ActiveXObject("MSXML2.DOMDocument");xmlObj.async=false;var bRet=xmlObj.load(strPath);return xmlObj;}
else{var myDoc=document.implementation.createDocument("","",null);myDoc.async=false;myDoc.load(strPath);return myDoc;}},GetValue:function(strKey){if(window.ActiveXObject){if(this.XmlDoc!=null){var doc=this.XmlDoc.documentElement;if(doc){var node=doc.selectSingleNode("//Client/key[@name='"+strKey+"']");if(node!=null){return node.text;}else{return"?"+strKey+"?";}}}
return"?"+strKey+"?";}else{if(this.XmlDoc!=null){var myRes=this.XmlDoc.getElementsByTagName("Resources");var myClient=myRes[0].getElementsByTagName("Client");var keys=myClient[0].getElementsByTagName("key");for(var i=0;i<keys.length;i++){if(keys[i].getAttribute("name")==strKey){return keys[i].firstChild.data;}}}}}}
var Res=new XmlRes("Resource/ModRes.xml");function RS(strKey){if(Res!=undefined){return Res.GetValue(strKey);}else{Res=new XmlRes("Resource/ModRes.xml");return Res.GetValue(strKey);}}
var bReady=false;var bSeq=false;var objPlayer;function PageLoad(){var bOk=true;if(ChkMediaPlay()){objPlayer=document.Player;objPlayer.uiMode="none";objPlayer.settings.autoStart=true;objPlayer.enableContextMenu=true;objPlayer.stretchToFit=true;bSeq=false;objPlayer.attachEvent("playStateChange",PlayerStateChange);OnTimeOut();GetInitVolume();}}
function OpenWms(url){objPlayer.URL=url;bReady=true;}
function Play(){if(objPlayer.playState==3&&bSeq)Pause();else objPlayer.Controls.play();}
function Pause(){objPlayer.Controls.pause();}
function Stop(){objPlayer.Controls.stop();}
function PlayerStateChange(){var nState=objPlayer.playState;if(nState==0){bReady=false;}else if(nState==1){$("spState").innerHTML="<img src=\"Images/Player/stop.gif\" /> "+RS("State_Stop");$("btnPlay").src="Images/Player/play_nor.gif";$("btnStop").src="Images/Player/stop_dis.gif";}else if(nState==2){$("spState").innerHTML="<img src=\"Images/Player/pause.gif\" /> "+RS("State_Pause");$("btnPlay").src="Images/Player/pause_nor.gif";}else if(nState==3){$("spState").innerHTML="<img src=\"Images/Player/play.gif\" /> "+RS("State_Play");if(bSeq)$("btnPlay").src="Images/Player/pause_nor.gif";else $("btnPlay").src="Images/Player/play_dis.gif";$("btnStop").src="Images/Player/stop_nor.gif";}else if(nState==6){$("spState").innerHTML=RS("State_Buffering");}else if(nState==7){$("spState").innerHTML="777";}else if(nState==8){$("spState").innerHTML="";}else if(nState==9){$("spState").innerHTML=RS("State_Transitioning");}else if(nState==10){$("spState").innerHTML="";}else if(nState==11){$("spState").innerHTML="";}}
function ChkMediaPlay(){var nMajor=0;try{var strVersion=document.Player.versionInfo;if(strVersion!=null){var arrVersion=strVersion.split(".");nMajor=parseInt(arrVersion[0]);}
if(nMajor<9){var bSoft=confirm(RS("Warn_Player")+"\n"+RS("Warn_Player2"));if(bSoft)location.href="Setup/mp9setup.exe";return false;}}
catch(e){var bSoft=confirm(RS("Warn_Player")+"\n"+RS("Warn_Player2"));if(bSoft)location.href="Setup/mp9setup.exe";return false;}
return true;}
function MMover_Play(obj){if(!bReady)return;if(objPlayer.playState!=3)
obj.src="Images/Player/play_hot.gif";else{if(bSeq)obj.src="Images/Player/pause_hot.gif";else obj.src="Images/Player/play_dis.gif";}}
function MMout_Play(obj){if(!bReady)return;if((objPlayer.playState==3)||(objPlayer.playState==9)){if(bSeq)obj.src="Images/Player/pause_nor.gif";else obj.src="Images/Player/play_dis.gif";}
else
obj.src="Images/Player/play_nor.gif";}
function MMover_Stop(obj){if(!bReady)return;if(objPlayer.playState!=1)
obj.src="Images/Player/stop_hot.gif";else
obj.src="Images/Player/stop_dis.gif";}
function MMout_Stop(obj){if(!bReady)return;if(objPlayer.playState!=1)
obj.src="Images/Player/stop_nor.gif";else
obj.src="Images/Player/stop_dis.gif";}
function OnTimeOut()
{var nCurPos=Math.round(objPlayer.controls.currentPosition);var nDuration=0;if(bSeq){nDuration=Math.round(objPlayer.currentMedia.duration);}
if(nCurPos>nDuration)
nCurPos=nCurPos-nDuration;$("spTime").innerText=ConvertToTime(nCurPos);if(bSeq)$("spTime").innerText+=" / "+ConvertToTime(nDuration);setTimeout("OnTimeOut()",1000);}
function ConvertToTime(nTime)
{var nHour=Math.round((nTime-1800)/3600);var nMin=Math.round(((nTime%3600)-30)/60);var nSec=Math.round((nTime%3600)%60);var strsHour=ConvertToString(nHour);var strMin=ConvertToString(nMin);var strSec=ConvertToString(nSec);return strsHour+":"+strMin+":"+strSec;}
function ConvertToString(nValue)
{var strReturn;if(nValue<10)
strReturn="0"+nValue;else
strReturn=nValue;return strReturn;}
function GoVolume()
{if(document.Player.settings.mute==false)
{var nLeftPix=event.offsetX;window.spVolumeCur.style.width=nLeftPix;var nVolume=parseInt(nLeftPix*100/60);document.Player.settings.volume=nVolume;window.spVolumeBtn.style.left=parseInt(window.spVolumeSlider.offsetLeft)+parseInt(window.spVolumeCur.style.pixelWidth);window.spVolumeBtn.style.top=window.spVolumeSlider.offsetTop-8;}}
function GetInitVolume()
{var nCurVolume=document.Player.settings.Volume;window.spVolumeCur.style.width=Math.round(nCurVolume)*60/100;window.spVolumeBtn.style.left=parseInt(window.spVolumeSlider.offsetLeft)+parseInt(window.spVolumeCur.style.pixelWidth);window.spVolumeBtn.style.top=window.spVolumeSlider.offsetTop-8;}
function SlideVolume(obj)
{if(document.Player.settings.mute==false)
{var nMin=parseInt(window.spVolumeSlider.offsetLeft);var nMax=parseInt(window.spVolumeSlider.offsetLeft)+60;if(event.button==1)
{obj.setCapture();var nOffX=event.clientX-248;if(nOffX>=nMin&&nOffX<=nMax){obj.style.pixelLeft=nOffX;var nLeftPix=nOffX-nMin;if(nLeftPix>60)
nLeftPix=0;var nVolume=parseInt(nLeftPix*100/60);window.spVolumeCur.style.width=nLeftPix;document.Player.settings.volume=nVolume;}}}}
function SlideVolumeOver(obj)
{obj.releaseCapture();obj=false;}
function Mute(){var bMute=!objPlayer.settings.mute;objPlayer.settings.mute=bMute;$("spMute").innerHTML=bMute?"<img src='Images/Player/mute_down.gif' title=\""+RS("Volume_Active")+"\" class=\"hand\" />":"<img src='Images/Player/mute_nor.gif' title=\""+RS("Volume_Mute")+"\" class=\"hand\" alt=\"\" />";}
function SetFull()
{if(objPlayer.playState==3){objPlayer.fullScreen=1;}
else alert(RS("Warn_SetFull"));}
function MMover_Full(obj){obj.src="Images/Player/full_hot.gif";}
function MMout_Full(obj){obj.src="Images/Player/full_nor.gif";}
var playSelf=this;function CastPlay(cid,aid){var option={method:"get",parameters:"rnd="+Math.random()+"&oper=GetCastInfo&id="+cid+"&aid="+aid,onSuccess:function(transport){if(transport.responseText=="-10"){alert(RS("WARN_NOLOGINPLAY"));}else{var json=eval('('+transport.responseText+')');if(json.Suc=="True"){if(json.Param!=""){playSelf.OpenWms(json.Param);}
$("castInfo").innerHTML=json.Info;}}},onFailure:function(transport){}}
var request=new Ajax.Request("Ajax.aspx",option);}
var XmlRes=Class.create();XmlRes.prototype={initialize:function(strPath){this.XmlDoc=this.GetXmlDoc(strPath);},GetXmlDoc:function(strPath){if(window.ActiveXObject){var xmlObj=new ActiveXObject("MSXML2.DOMDocument");xmlObj.async=false;var bRet=xmlObj.load(strPath);return xmlObj;}
else{var myDoc=document.implementation.createDocument("","",null);myDoc.async=false;myDoc.load(strPath);return myDoc;}},GetValue:function(strKey){if(window.ActiveXObject){if(this.XmlDoc!=null){var doc=this.XmlDoc.documentElement;if(doc){var node=doc.selectSingleNode("//Client/key[@name='"+strKey+"']");if(node!=null){return node.text;}else{return"?"+strKey+"?";}}}
return"?"+strKey+"?";}else{if(this.XmlDoc!=null){var myRes=this.XmlDoc.getElementsByTagName("Resources");var myClient=myRes[0].getElementsByTagName("Client");var keys=myClient[0].getElementsByTagName("key");for(var i=0;i<keys.length;i++){if(keys[i].getAttribute("name")==strKey){return keys[i].firstChild.data;}}}}}}
var Res=new XmlRes("Resource/ModRes.xml");function RS(strKey){if(Res!=undefined){return Res.GetValue(strKey);}else{Res=new XmlRes();return Res.GetValue(strKey);}}
var Toper=this;function OpenWindow(strurl,strtitle,height,width,top,left){window.showModalDialog(strurl,strtitle,"dialogHeight: "+height+"px; dialogWidth: "+width+"px; dialogTop: "+top+"px; dialogLeft: "+left+"px; edge: Raised; center: Yes; help: Yes; resizable: Yes; status: No;");}
function openwndex(strUrl,strWndName,width,height){var nRnd=Math.random();var bP=false;if(strUrl.toLowerCase().indexOf("AddPlayCount.aspx")>0)
{bP=!CheckPlay("");}
if(!bP)
{strUrl="../"+strUrl;var sFeatures="DialogHeight:"+height+"px;DialogWidth:"+width+"px;help:No;center:Yes;scroll:No; status:No;";n=window.showModalDialog("Scripts/g_DialogTemp.htm?rnd="+nRnd,strUrl+"|"+strWndName+"|"+height+"|"+width,sFeatures);if(n==1)
{location.reload();}}}
function ConvertToTime(nTime){var nHour=Math.round((nTime-1800)/3600);var nMin=Math.round(((nTime%3600)-30)/60);var nSec=Math.round((nTime%3600)%60);var strsHour=ConvertToString(nHour);var strMin=ConvertToString(nMin);var strSec=ConvertToString(nSec);return strsHour+":"+strMin+":"+strSec;}
function ConvertToString(nValue){var strReturn;if(nValue<10)
strReturn="0"+nValue;else
strReturn=nValue;return strReturn;}
function ChannelSelected(e){var eSrc=Event.element(e);if(eSrc.tagName.toUpperCase()=="a".toUpperCase()){var elt=Event.findElement(e,"div");if(elt!=document){for(var j=0;j<elt.childNodes.length;j++){var curNode=elt.childNodes[j];if(curNode.nodeType==1&&curNode.tagName.toUpperCase()=="ul".toUpperCase()){for(var i=0;i<curNode.childNodes.length;i++){var subNode=curNode.childNodes[i];if(subNode.nodeType==1){subNode.className="";}}}}
eSrc.parentNode.className="selected";}}}
function UpdateUserState(){setTimeout("UpdateUserState()",600000);var option={method:"get",parameters:"rnd="+Math.random()+"&oper=online",onSuccess:function(transport){},onFailure:function(transport){}}
var request=new Ajax.Request("ajax.aspx",option);}
var strver3=RS("VER_LOCAL");var strver4=RS("VER_SERVER");var v_mp=3;var strmp1=RS("VER_PLAYER");var strmp2=RS("VER_PLAYERLOW");var v_mn=4;var strmn1=RS("VER_MANAGER");var strmn2=RS("VER_MANAGERLOW");nosetup=RS("INFO_NOSETUP");function IsPlay(point){if(!CheckMediaPlayer())return false;if(point==0)return true;var sMsg=Res.GetValue("INFO_CONFIRMPLAY");sMsg=sMsg.replace("{0}",point);return confirm(sMsg);}
function CheckMediaPlayer(){var objSetup;try{objSetup=new ActiveXObject("LibSetupCheck.SetupPlayer");var mp=objSetup.GetProductVersion(3);if(mp==0){if(confirm(Res.GetValue("WARN_NOPLAYER"))){window.location="SoftDown.aspx";}
return false;}}catch(e){if(confirm(Res.GetValue("WARN_NOPLAYER"))){window.location="SoftDown.aspx";}
return false;}
return true;}
function CheckMedia(strUrl,serVer){var objSetup;try{objSetup=new ActiveXObject("LibSetupCheck.SetupPlayer");}catch(e){if(confirm(Res.GetValue("WARN_NOPLAYER"))){window.location="SoftDown.aspx";return;}else{window.location=strUrl;return;}}
var mp=objSetup.GetProductVersion(3);if(mp==0){if(confirm(Res.GetValue("WARN_NOPLAYER"))){window.location="SoftDown.aspx";return;}else{window.location=strUrl;return;}}
if(!CheckVersion(mp,serVer)){var errstr=strmp1+mp+","+strmp2+serVer+"\n";if(confirm(errstr)){window.location="SoftDown.aspx";}else{window.location=strUrl;}}else{window.location=strUrl;}}
function GetVersion(n,s)
{var c,strout;c=0;try
{objSetup=new ActiveXObject("LibSetupCheck.SetupPlayer");if(n==1)
{c=objSetup.GetProductVersion(v_ce);}
if(n==2)
{c=objSetup.GetProductVersion(v_bc);}
if(n==3)
{c=objSetup.GetProductVersion(v_mp);}
if(n==4)
{c=objSetup.GetProductVersion(v_mn);}
if(n==5)
{c=objSetup.GetProductVersion(v_re);}
if(n==6)
{c=objSetup.GetProductVersion(v_pa)}}
catch(e)
{}
if(!CheckVersion(c,s))
{if(c==0)
{c=nosetup;}
strout=strver4+s+"&nbsp;&nbsp;&nbsp;&nbsp;<font color=red>"+strver3+c+"</font> ";}
else
{if(c==0)
{c=nosetup;}
strout=" "+strver4+s+"&nbsp;&nbsp;&nbsp;&nbsp;"+strver3+c;}
document.writeln(strout);}
function CheckVersion(o,s)
{var oma,omi,ob,sma,smi,sb;ob=sb=0;if((o.length>0)&&(s.length>0))
{if(o==0)
return true;try
{var arrO=o.split(".");var arrS=s.split(".");oma=parseInt(arrO[0]);omi=parseInt(arrO[1]);if(arrO.length==3)
ob=parseInt(arrO[2]);sma=parseInt(arrS[0]);smi=parseInt(arrS[1]);if(arrS.length==3)
sb=parseInt(arrS[2]);if(oma<sma)
{return false;}
else if(oma==sma)
{if(omi<smi)
{return false;}else if(oma==sma){if(ob<sb)
return false;}}}
catch(e)
{}}
return true;}
function ChkAddPoint(){var nonull=Res.GetValue("WARN_NOCARD");var errcardno=Res.GetValue("WARN_ERRCARD");var errcardpwd=Res.GetValue("WARN_ERRPWD");var no=$("tbCardNum").value;if(no.length==0){alert(nonull);return false;}else if(no.length!=10){alert(errcardno);return false;}else{if(/\W/.test(no)){alert(errcardno);return false;}}
var pwd=$("tbCardPwd").value;if(pwd.length!=10){alert(errcardpwd);return false;}}
function CallPlay(url){location.href=url;setTimeout("parent.window.close()",2000);}
function SelChange(obj){var value=obj.options[obj.selectedIndex].value;location.href=value;}
function ContentResize(){var seconder=document.getElementById("seconder");var firster=document.getElementById("firster");var firh=firster.clientHeight;var sech=seconder.clientHeight;if(firh>sech){seconder.style.height=firh+"px";}else if(firh<sech){firster.style.height=sech+"px";}}
function NavSelected(nodeObj,pNav){var menu=$(pNav)
for(var i=0;i<menu.childNodes.length;i++){var curNode=menu.childNodes[i];if(curNode.nodeType==1){curNode.className="";}}
nodeObj.className="selected";}
function handleMouseClick(e){var evt;if(typeof window.event!="undefined"){evt=window.event;}else{evt=e;}
var target;if(typeof evt.srcElement!="undefined"){target=evt.srcElement;}else{target=evt.target;}
NavSelected(target,"nav");}
function dialog(wdh,hgt,strTitle){var strInfo="<h3>AAAAAAAAAA</h3><TABLE><TR><tD>bbbbbbbb</TD></TR></TABLE>";Dialog.info(strInfo,{windowParameters:{className:"alphacube",width:wdh,height:wdh,title:strTitle,resizable:false,minimizable:false,maximizable:false,closable:true,draggable:true}});}
function IECheck(ErrIe){var ua=navigator.userAgent;var ie=(navigator.appName=="Microsoft Internet Explorer");if(ie){var IEversion=parseFloat(ua.substring(ua.indexOf("MSIE ")+5,ua.indexOf(";",ua.indexOf("MSIE "))));if(IEversion<5.5){if(!confirm(ErrIe)){window.close();}}}}
function MyOnload(strUrl,serVer,ErrIe){IECheck(ErrIe);CheckMedia(strUrl,serVer);}
var ERROPENSTREAM=RS("ERR_OPENSTREAM");var R_STATE_CLOSE="TA_STATE_CLOSE";var R_STATE_STOP="TA_STATE_STOP";var R_STATE_PAUSE="TA_STATE_PAUSE";var R_STATE_BUFFER="TA_STATE_BUFFER";var R_NO_OCX="TA_NO_OCX";var R_REC="TA_REC";var R_STOPREC="TA_STOPREC";var R_CURBIT="TA_CURBIT";var R_AVGBIT="TA_AVGBIT";var STATE_NONE=0;var STATE_STOP=1;var STATE_RUN=2;var STATE_PAUSE=3;var STATE_TEMPPAUSE=4;var ERR_NONE=0;var ERR_ABORT=1;var ERR_TERMINATED=2;var VOLUME_LENGTH=40;var VOLUME_MAX=10000;var gVolume=50;var gCurVolume=5000;var gOldVolume=0;var gCurPosition=0;var gTimeSliderMax=0;var castType=2;var gRecPer=0;var gRecState=0;var gbMute=false;var bHasVideo=false;var bHasAudio=false;var bReady=false;var gCanRec=false;var param,img,objMwp,allParam,param1;var gHandle,gCurChapter;function init(){objMwp=$("MWP");objMwp.attachEvent("StateChange",OnCustomEvent);objMwp.attachEvent("ErrorNotify",OnErrorNotify);}
function Page_Load(strParam,nCastType,IsCanRec){allParam=SortRecList(strParam);castType=nCastType;gRecPer=IsCanRec;if(allParam.length>1)
param1=allParam[1];param=allParam[0];img=$("divImg");objMwp=$("MWP");objMwp.attachEvent("StateChange",OnCustomEvent);objMwp.attachEvent("ErrorNotify",OnErrorNotify);Open();OnTimeOut();}
function OnCustomEvent(){var objState=objMwp.currentState;if(objState==STATE_NONE){$("spNow").innerHTML=R_STATE_CLOSE;$("imgPlay").src="Images/Player/play_0.gif";}
else if(objState==STATE_STOP){$("spNow").innerHTML=R_STATE_STOP;$("imgPlay").src="Images/Player/play_0.gif";$("imgStop").src="Images/Player/stop_2.gif";}
else if(objState==STATE_RUN){ShowNow();$("imgPlay").src="Images/Player/play_2.gif";$("imgStop").src="Images/Player/stop_0.gif";img.style.display="none";if(objMwp.hasVideo())
bHasVideo=true;if(objMwp.hasAudio())
bHasAudio=true;InitUI();}}
function GetBit(){if(!bReady)return;var strBit=objMwp.GetBitrate();var strCurBit,strAvgBit;strCurBit=strAvgBit="";if(strBit.length!=0){var xml=new ActiveXObject("Microsoft.XMLDOM");xml.loadXML(strBit);var xmlElt=xml.documentElement;strCurBit=xmlElt.getAttribute("cur");strAvgBit=xmlElt.getAttribute("avg");return R_CURBIT+": "+strCurBit+" Kbps&nbsp;/&nbsp;"+R_AVGBIT+": "+strAvgBit+" Kbps";}else{return"";}}
function OnErrorNotify(){var objErr=objMwp.lastError;}
function Open(){objMwp.style.display="block";bHasVideo=false;bHasAudio=false;try{var ret;objMwp.SetType(castType);if(allParam.length>1)
ret=objMwp.Open(param.ssrc,param1.ssrc);else{ret=objMwp.Open(param.ssrc,0);if(param.auto==1)
objMwp.InsertAuto();}
var objRece,strMs,arrMs;strMs="";var bHasInsert=false;for(var i=0;i<param.receive.length;i++){objRece=param.receive[i];if(objRece.type=="tcp"){objMwp.InsertTCP(objRece.ip,objRece.port,param.ssrc);bHasInsert=true;}else if(objRece.type=="ms"){strMs=GetMSPath(objRece.ip,objRece.port,0,objRece.msid,objRece.uid);if(strMs!=""){arrMs=strMs.split(":");objMwp.InsertTCP(arrMs[0],arrMs[1],param.ssrc);bHasInsert=true;}}
else{objMwp.InsertUDP(objRece.ip,objRece.port);bHasInsert=true;}
if(allParam.length>1){if(bHasInsert)
break;}else{if(param.auto==0&&bHasInsert)
break;}}
bHasInsert=false;if(allParam.length>1){for(var i=0;i<param1.receive.length;i++){objRece=param1.receive[i];if(objRece.type=="tcp"){objMwp.InsertTCP(objRece.ip,objRece.port,param1.ssrc);bHasInsert=true;}else if(objRece.type=="ms"){strMs=GetMSPath(objRece.ip,objRece.port,0,objRece.msid,objRece.uid);if(strMs!=""){arrMs=strMs.split(":");objMwp.InsertTCP(arrMs[0],arrMs[1],param.ssrc);bHasInsert=true;}}else{objMwp.InsertUDP(objRece.ip,objRece.port);bHasInsert=true;}
if(bHasInsert){break;}}}
objMwp.Run();}catch(e){if(confirm(Res.GetValue("WARN_NOPLAYER"))){window.location="SoftDown.aspx";}
return;}
if(ret==true){bReady=true;}else{bReady=false;objMwp.style.display="none";img.style.display="block";alert(ERROPENSTREAM);}}
function SortRecList(allObj){if(allObj==null)return null;var retObj=new Array();for(var i=0;i<allObj.length;i++){var tObj=allObj[i];if(tObj==null)continue;var bOk=false;for(var j=0;j<tObj.receive.length;j++){if(tObj.receive[j].type=="tcp"||tObj.receive[j].type=="ms"){if(j==0){retObj[i]=tObj;bOk=true;break;}else{var temp=tObj.receive[0];tObj.receive[0]=tObj.receive[j];tObj.receive[j]=temp;retObj[i]=tObj;bOk=true;break;}}}
if(!bOk){retObj[i]=tObj;}}
return retObj;}
function InitUI(){if(bHasVideo){objMwp.style.width="507px";objMwp.style.height="334px";img.style.display="none";objMwp.style.display="block";}else{objMwp.style.width=0;objMwp.style.height=0;}}
function ShowNow(){if(!bReady)return;str="strCastName";if(objMwp.currentState==STATE_RUN){$("spNow").innerHTML="<marquee id=\"mqNow\" scrollDelay=20 scrollAmount=1 onmouseover=\"this.stop();\" onmouseout=\"this.start();\">"+str+"</marquee>";$("spNow").style.width=(gTimeSliderMax>350)?parseInt(gTimeSliderMax-350):0;}}
function PlayPause(){if(!bReady)return;var nState=objMwp.currentState;if(nState!=STATE_RUN)
Play();}
function Play(){if(!bReady)return;objMwp.Run();}
function Stop(){if(!bReady)return;objMwp.Stop();}
function SetFull(){if(!bReady)return;objMwp.SetFullScreen();}
function MWPColse(){if(!bReady)return;objMwp.Close();}
function Rec(){if(!bReady)return;if(!gCanRec)return;if(gRecState==0){var ret=objMwp.StartRecord();if(ret)
gRecState=1;}else{objMwp.StopRecord();gRecState=0;}
$("imgRec").title=(gRecState==0)?R_REC:R_STOPREC;}
function GetMSPath(hsip,hsport,pid,msid,uid){var objMP;try{objMP=new ActiveXObject("TaPlayer.HomeServer");return objMP.GetMSAdapter(hsip,hsport,pid,uid,msid);}
catch(e){return"";}}
function GetPosition(){if(!bReady)return;return(objMwp.GetPosition()/1000);}
function Mover_Stop(){if(!bReady)return;if(objMwp.currentState==STATE_STOP)
$("imgStop").src="Images/Player/stop_2.gif";else
$("imgStop").src="Images/Player/stop_1.gif";}
function Mout_Stop(){if(!bReady)return;if(objMwp.currentState==STATE_STOP)
$("imgStop").src="Images/Player/stop_2.gif";else
$("imgStop").src="Images/Player/stop_0.gif";}
function Mover_Play(){if(!bReady)return;if(objMwp.currentState==STATE_RUN)
$("imgPlay").src="Images/Player/play_2.gif";else
$("imgPlay").src="Images/Player/play_1.gif";}
function Mout_Play(){if(!bReady)return;if(objMwp.currentState==STATE_RUN)
$("imgPlay").src="Images/Player/play_2.gif";else
$("imgPlay").src="Images/Player/play_0.gif";}
function OnTimeOut(){if(!bReady){window.clearTimeout(gHandle);return;}
gCurPosition=GetPosition();$("spTime").innerHTML=ConvertToTime(gCurPosition);gHandle=setTimeout("OnTimeOut()",1000);GetBit();}
function ShowVideoEmpty(){$("MWP").style.display="none";$("divImg").style.display="none";}
var playSelf=this;function CastPlay(cid){var option={method:"get",parameters:"rnd="+Math.random()+"&oper=GetCastInfo&id="+cid,onSuccess:function(transport){if(transport.responseText=="-10"){alert(RS("WARN_NOLOGINPLAY"));}else{var json=eval('('+transport.responseText+')');if(json.Suc=="True"){if(json.Param!="-1"){$("castInfo").innerHTML=json.Info;playSelf.Page_Load(json.Param,2,0);}else{alert(RS("ERR_MIXCHANNEL"));}}}},onFailure:function(transport){}}
var request=new Ajax.Request("Ajax.aspx",option);}
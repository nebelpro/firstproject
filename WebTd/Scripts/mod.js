var XmlRes=Class.create();XmlRes.prototype={initialize:function(strPath){this.XmlDoc=this.GetXmlDoc(strPath);},GetXmlDoc:function(strPath){if(window.ActiveXObject){var xmlObj=new ActiveXObject("MSXML2.DOMDocument");xmlObj.async=false;var bRet=xmlObj.load(strPath);return xmlObj;}
else{var myDoc=document.implementation.createDocument("","",null);myDoc.async=false;myDoc.load(strPath);return myDoc;}},GetValue:function(strKey){if(window.ActiveXObject){if(this.XmlDoc!=null){var doc=this.XmlDoc.documentElement;if(doc){var node=doc.selectSingleNode("//Client/key[@name='"+strKey+"']");if(node!=null){return node.text;}else{return"?"+strKey+"?";}}}
return"?"+strKey+"?";}else{if(this.XmlDoc!=null){var myRes=this.XmlDoc.getElementsByTagName("Resources");var myClient=myRes[0].getElementsByTagName("Client");var keys=myClient[0].getElementsByTagName("key");for(var i=0;i<keys.length;i++){if(keys[i].getAttribute("name")==strKey){return keys[i].firstChild.data;}}}}}}
var Res=new XmlRes("Resource/ModRes.xml");function RS(strKey){if(Res!=undefined){return Res.GetValue(strKey);}else{Res=new XmlRes();return Res.GetValue(strKey);}}
var Cookie=new Object();Cookie.setCookie=function(name,value,option){var str=name+"="+escape(value);if(option){if(option.expireDays){var date=new Date();var ms=option.expireDays*24*3600*1000;date.setTime(date.getTime()+ms);str+="; expires="+date.toGMTString();}
if(option.path)str+="; path="+path;if(option.domain)str+="; domain"+domain;if(option.secure)str+="; true";}
document.cookie=str;}
Cookie.getCookie=function(name){var cookieArray=document.cookie.split("; ");var cookie=new Object();for(var i=0;i<cookieArray.length;i++){var arr=cookieArray[i].split("=");if(arr[0]==name)return unescape(arr[1]);}
return"";}
Cookie.deleteCookie=function(name){this.setCookie(name,"",{expireDays:-1});}
var AjaxBase=Class.create();AjaxBase.prototype={initialize:function(){this.oper="";this.url="ajax.aspx";this.param="";this.async=true;this.option={method:"post",asynchronous:true,parameters:"",onSuccess:null,onFailure:function(transport){document.write(transport.responseText);}};},rqst:function(){this.option.parameters="rnd="+Math.random()+"&oper="+this.oper+this.param;this.option.asynchronous=this.async;var request=new Ajax.Request(this.url,this.option);}}
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
objMwp.Run();}catch(e){if(confirm(Res.GetValue("WARN_NOPLAYER"))){window.location="Manager/setup/miniplayer.exe";}
return;}
if(ret==true){bReady=true;}else{bReady=false;objMwp.style.display="none";img.style.display="block";alert(ERROPENSTREAM);}}
function SortRecList(allObj){if(allObj==null)return null;var retObj=new Array();for(var i=0;i<allObj.length;i++){var tObj=allObj[i];if(tObj==null)continue;var bOk=false;for(var j=0;j<tObj.receive.length;j++){if(tObj.receive[j].type=="tcp"||tObj.receive[j].type=="ms"){if(j==0){retObj[i]=tObj;bOk=true;break;}else{var temp=tObj.receive[0];tObj.receive[0]=tObj.receive[j];tObj.receive[j]=temp;retObj[i]=tObj;bOk=true;break;}}}
if(!bOk){retObj[i]=tObj;}}
return retObj;}
function InitUI(){if(bHasVideo){objMwp.style.width="506px";objMwp.style.height="326px";img.style.display="none";objMwp.style.display="block";}else{objMwp.style.width=0;objMwp.style.height=0;}}
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
var Toper=this;function IsDate(tdate)
{var t1,t2,t3,year,month,day;t1=tdate.search("-");if(t1==-1)
return false
else
{t2=tdate.substr(5);t2=t2.search("-")+t1+1;if(t2==-1)
return false;else
{year=tdate.substr(0,t1);month=tdate.substr(t1+1,t2-t1-1);t3=tdate.search(" ");if(t3>1)
day=tdate.substr(t2+1,t3-t2-1);else day=tdate.substr(t2+1);if(isNaN(year)||isNaN(month)||isNaN(day))
return false;else
{if(year<1800)
return false;else if(month<1||month>12)
return false;else if(day<1||day>31)
return false;}}}
return true;}
function ConvertToTime(nTime){var nHour=Math.round((nTime-1800)/3600);var nMin=Math.round(((nTime%3600)-30)/60);var nSec=Math.round((nTime%3600)%60);var strsHour=ConvertToString(nHour);var strMin=ConvertToString(nMin);var strSec=ConvertToString(nSec);return strsHour+":"+strMin+":"+strSec;}
function ConvertToString(nValue){var strReturn;if(nValue<10)
strReturn="0"+nValue;else
strReturn=nValue;return strReturn;}
function ChannelSelected(e){var eSrc=Event.element(e);if(eSrc.tagName.toUpperCase()=="a".toUpperCase()){var elt=Event.findElement(e,"div");if(elt!=document){for(var j=0;j<elt.childNodes.length;j++){var curNode=elt.childNodes[j];if(curNode.nodeType==1&&curNode.tagName.toUpperCase()=="ul".toUpperCase()){for(var i=0;i<curNode.childNodes.length;i++){var subNode=curNode.childNodes[i];if(subNode.nodeType==1){subNode.className="";}}}}
eSrc.parentNode.className="selected";}}}
function UpdateUserState(){setTimeout("UpdateUserState()",600000);var option={method:"get",parameters:"rnd="+Math.random()+"&oper=online",onSuccess:function(transport){},onFailure:function(transport){}}
var request=new Ajax.Request("ajax.aspx",option);}
var Toper=this;function IsDate(tdate)
{var t1,t2,t3,year,month,day;t1=tdate.search("-");if(t1==-1)
return false
else
{t2=tdate.substr(5);t2=t2.search("-")+t1+1;if(t2==-1)
return false;else
{year=tdate.substr(0,t1);month=tdate.substr(t1+1,t2-t1-1);t3=tdate.search(" ");if(t3>1)
day=tdate.substr(t2+1,t3-t2-1);else day=tdate.substr(t2+1);if(isNaN(year)||isNaN(month)||isNaN(day))
return false;else
{if(year<1800)
return false;else if(month<1||month>12)
return false;else if(day<1||day>31)
return false;}}}
return true;}
function ConvertToTime(nTime){var nHour=Math.round((nTime-1800)/3600);var nMin=Math.round(((nTime%3600)-30)/60);var nSec=Math.round((nTime%3600)%60);var strsHour=ConvertToString(nHour);var strMin=ConvertToString(nMin);var strSec=ConvertToString(nSec);return strsHour+":"+strMin+":"+strSec;}
function ConvertToString(nValue){var strReturn;if(nValue<10)
strReturn="0"+nValue;else
strReturn=nValue;return strReturn;}
function ChannelSelected(e){var eSrc=Event.element(e);if(eSrc.tagName.toUpperCase()=="a".toUpperCase()){var elt=Event.findElement(e,"div");if(elt!=document){for(var j=0;j<elt.childNodes.length;j++){var curNode=elt.childNodes[j];if(curNode.nodeType==1&&curNode.tagName.toUpperCase()=="ul".toUpperCase()){for(var i=0;i<curNode.childNodes.length;i++){var subNode=curNode.childNodes[i];if(subNode.nodeType==1){subNode.className="";}}}}
eSrc.parentNode.className="selected";}}}
function UpdateUserState(){setTimeout("UpdateUserState()",600000);var option={method:"get",parameters:"rnd="+Math.random()+"&oper=online",onSuccess:function(transport){},onFailure:function(transport){}}
var request=new Ajax.Request("ajax.aspx",option);}
var strver3=RS("VER_LOCAL");var strver4=RS("VER_SERVER");var v_mp=3;var v_mn=4;nosetup=RS("INFO_NOSETUP");function CheckPlayer(){var objSetup;try{objSetup=new ActiveXObject("LibSetupCheck.SetupPlayer");var mp=objSetup.GetProductVersion(3);if(mp==0){return false;}else{return true;}}catch(e){return false;}}
function CheckPlayerVersion(){var objSetup;try{objSetup=new ActiveXObject("LibSetupCheck.SetupPlayer");var mp=objSetup.GetProductVersion(3);if(mp==0){return-1;}else if(!CheckVersion(mp,Cookie.getCookie("PlayerVersion"))){return-2;}else{return 1;}}
catch(e){return-1;}}
function GetVersion(n,s)
{var c,strout;c=0;try
{objSetup=new ActiveXObject("LibSetupCheck.SetupPlayer");if(n==1){c=objSetup.GetProductVersion(v_ce);}
if(n==2){c=objSetup.GetProductVersion(v_bc);}
if(n==3){c=objSetup.GetProductVersion(v_mp);}
if(n==4){c=objSetup.GetProductVersion(v_mn);}
if(n==5){c=objSetup.GetProductVersion(v_re);}
if(n==6){c=objSetup.GetProductVersion(v_pa)}}
catch(e){}
if(!CheckVersion(c,s)){if(c==0){c=nosetup;}
strout=strver4+s+"&nbsp;&nbsp;&nbsp;&nbsp;<font color=red>"+strver3+c+"</font> ";}else{if(c==0){c=nosetup;}
strout=" "+strver4+s+"&nbsp;&nbsp;&nbsp;&nbsp;"+strver3+c;}
document.writeln(strout);}
function CheckVersion(o,s){var oma,omi,ob,sma,smi,sb;ob=sb=0;if((o.length>0)&&(s.length>0))
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
catch(e){}}
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
function MyDialog(wdh,hgt,title,content){Dialog.info(content,{windowParameters:{className:"alphacube",width:wdh,height:hgt,title:title,resizable:false,minimizable:false,maximizable:false,closable:true,draggable:true}});}
function IECheck(ErrIe){var ua=navigator.userAgent;var ie=(navigator.appName=="Microsoft Internet Explorer");if(ie){var IEversion=parseFloat(ua.substring(ua.indexOf("MSIE ")+5,ua.indexOf(";",ua.indexOf("MSIE "))));if(IEversion<5.5){if(!confirm(ErrIe)){window.close();}}}}
function MyOnload(strUrl,strVersion,ErrIe){IECheck(ErrIe);Cookie.setCookie("PlayerVersion",strVersion);location.href=strUrl;}
var User=Class.create();User.prototype=Object.extend(new AjaxBase(),{initialize:function(){this.pass="";this.mask="";this.begintime="";this.endtime="";this.tips={err_Confirm:Toper.RS("Warn_UserPasswordConfirm"),err_Format:Toper.RS("Warn_UserPwdFormat"),err_Permit:Toper.RS("Warn_UserPermit"),err_OldPwd:Toper.RS("Warn_UserOldPwdError"),suc_modifypwd:Toper.RS("Suc_UserModifyPwd"),err_Null:Toper.RS("Warn_NoNull"),err_CardNo:Toper.RS("Warn_CardNo"),err_CardPwd:Toper.RS("Warn_CardPwd"),err_addPoint:Toper.RS("Warn_AddPoint"),err_cardNotExist:Toper.RS("Warn_CardNotExist"),err_cardUsed:Toper.RS("Warn_CardIsUsed"),err_cardType:Toper.RS("Warn_CardTypeError"),err_CardInvalid:Toper.RS("Warn_CardInvalid"),suc_AddPoint:Toper.RS("Suc_AddPoint"),err_dateformat:Toper.RS("Warn_DateError"),err_daterange:Toper.RS("Warn_DateRange"),PlayConfirm:Toper.RS("Info_PlayConfirm"),err_PlayPermit:Toper.RS("Warn_NoPlayPermit"),err_groupmask:Toper.RS("Warn_NoGroupPermit"),err_nopoint:Toper.RS("Warn_NoPoint"),err_DownPermit:Toper.RS("Warn_NoMediaDownPermit")};this.opers={login:"Login",modifypwd:"UserModifyPwd",htmlmodify:"HtmlModifyPwd",htmlpointadd:"HtmlPointAdd",addpoint:"UserAddPoint",getchargelist:"GetChargeList",getplayloglist:"GetPlayLogList",play:"ProgramPlayStep1",play2:"ProgramPlayStep2",mediadown:"ProgramDown",getbulletin:"GetBulletinInfo"};},ChkMng:function(restext){if(restext==-10){location.href="Default.aspx";return false;}else if(restext==-11){alert(this.tips.err_Permit);return false;}else if(restext==-12){alert(this.tips.err_Confirm);return false;}else if(restext==-13){alert(this.tips.err_OldPwd);return false;}else{return true;}},MngAddPoint:function(restext){if(restext==-10){location.href="Default.aspx";return false;}else if(restext==-21){alert(this.tips.err_addPoint);return false;}else if(restext==-1){alert(this.tips.err_cardNotExist);return false;}else if(restext==-2){alert(this.tips.err_CardPwd);return false;}else if(restext==-3){alert(this.tips.err_CardInvalid);return false;}else if(restext==-4){alert(this.tips.err_cardUsed);return false;}else if(restext==-5){alert(this.tips.err_cardType);return false;}else{return true;}},MngLog:function(text){if(text==-10){location.href="Default.aspx";return false;}else if(text==-21){alert(this.tips.err_dateformat);return false;}else if(text==-22){alert(this.tips.err_daterange);return false;}else{return true;}},ChkOldPass:function(){var oldPwd=$("txtPwdOld").value;if(/\W/.test(oldPwd)){alert(this.tips.err_Format);$("txtPwdOld").focus();return false;}else{return true;}},ChkPass:function(){var strPass=$("txtPwdNew").value;var strPassConfirm=$("txtConfirm").value;if(strPass!=strPassConfirm){alert(this.tips.err_Confirm);$("txtPwdNew").focus();return false;}else if(/\W/.test(strPass)){alert(this.tips.err_Format);$("txtPwdNew").focus();return false;}else{this.pass=strPass;return true;}},CtrlModifyPwd:function(wdh,hgt,title){this.oper=this.opers.htmlmodify;this.option.onSuccess=function(transport){Toper.MyDialog(wdh,hgt,title,transport.responseText);};this.rqst();},ModifyPwd:function(){var self=this;if(this.ChkOldPass()&&this.ChkPass()){this.oper=this.opers.modifypwd;this.param="&old="+encodeURIComponent($("txtPwdOld").value)+"&pass="+encodeURIComponent(this.pass)+"&pconfirm="+encodeURIComponent($("txtConfirm").value);this.option.onSuccess=function(transport){if(self.ChkMng(transport.responseText)){alert(self.tips.suc_modifypwd);Toper.Dialog.okCallback();}};this.rqst();}},ChkPointNo:function(){var no=$("txtNo").value;if(no.length==0){alert(this.tips.err_Null);return false;}else if(no.length!=10){alert(this.tips.err_CardNo);return false;}else if(/\W/.test(no)){alert(this.tips.err_CardNo);return false;}else{return true;}},ChkPointPwd:function(){var pwd=$("txtPwd").value;if(pwd.length!=10){alert(this.tips.err_CardPwd);return false;}else{return true;}},CtrlPointAdd:function(wdh,hgt,title){this.oper=this.opers.htmlpointadd;this.option.onSuccess=function(transport){Toper.MyDialog(wdh,hgt,title,transport.responseText);};this.rqst();},AddPoint:function(){var self=this;if(this.ChkPointNo()&&this.ChkPointPwd()){this.oper=this.opers.addpoint;this.param="&cardno="+$("txtNo").value+"&cardpwd="+$("txtPwd").value;this.option.onSuccess=function(transport){if(self.MngAddPoint(transport.responseText)){alert(self.tips.suc_AddPoint);Toper.Dialog.okCallback();}};this.rqst();}},ChkDate:function(){var dtBegin=$("txtDateBegin").value;var dtEnd=$("txtDateEnd").value;if(dtBegin!=""||dtEnd!=""){if(IsDate(dtBegin)&&IsDate(dtEnd)){this.begintime=dtBegin;this.endtime=dtEnd;$("txtDateBegin").value="";$("txtDateEnd").value="";return true;}else{alert(this.tips.err_dateformat);return false;}}else{this.begintime="";this.endtime="";return true;}},ChargeQuery:function(wdh,hgt,title){this.begintime="";this.endtime="";var listContent=this.GetChargeList(1);var strContainer="<div id=\"Charge\">"+listContent+"</div>";Toper.MyDialog(wdh,hgt,title,strContainer);},GetChargeList:function(page){var temp;this.oper=this.opers.getchargelist;this.async=false;this.param="&begin="+this.begintime+"&end="+this.endtime+"&page="+page;this.option.onSuccess=function(transport){temp=transport.responseText;};this.rqst();return temp;},btnChargeQuery:function(){if(this.ChkDate()){this.GetCharge(1);}},GetCharge:function(page){var strRec=this.GetChargeList(page);if(this.MngLog(strRec)){$("Charge").innerHTML=strRec;}},PlayLogQuery:function(wdh,hgt,title){this.begintime="";this.endtime="";var listContent=this.GetPlayLogList(1);var strContainer="<div id=\"PlayLog\">"+listContent+"</div>";Toper.MyDialog(wdh,hgt,title,strContainer);},GetPlayLogList:function(page){var temp;this.oper=this.opers.getplayloglist;this.async=false;this.param="&begin="+this.begintime+"&end="+this.endtime+"&page="+page;this.option.onSuccess=function(transport){temp=transport.responseText;};this.rqst();return temp;},btnPlayLogQuery:function(){if(this.ChkDate()){this.GetPlayLog(1);}},GetPlayLog:function(page){var strRec=this.GetPlayLogList(page);if(this.MngLog(strRec)){$("PlayLog").innerHTML=strRec;}},MngPlay:function(text){if(text==-10){location.href="Default.aspx";return false;}else if(text==-14){alert(this.tips.err_PlayPermit);return false;}else if(text==-15){alert(this.tips.err_groupmask);return false;}else if(text==-16){alert(this.tips.err_nopoint);return false;}else if(text==-21){alert(this.tips.err_DownPermit);return false;}else{return true;}},Play2:function(pid,index,mtype,point){var self=this;this.oper=this.opers.play2;this.param="&pid="+pid+"&index="+index+"&point="+point+"&mtype="+mtype;this.option.onSuccess=function(transport){if(self.MngPlay(transport.responseText)){window.location.href(transport.responseText);}};this.rqst();},IsPlay:function IsPlay(point){if(point==0)return true;var sMsg=this.tips.PlayConfirm;return confirm(sMsg.replace("{0}",point));},Play:function(EncryptId,index,mType){var self=this;this.oper=this.opers.play;this.param="&pid="+EncryptId;this.option.onSuccess=function(transport){if(self.MngPlay(transport.responseText)){if(self.IsPlay(transport.responseText)){self.Play2(EncryptId,index,mType,transport.responseText);}}};this.rqst();},MediaDown:function(EncryptId,index){var self=this;this.oper=this.opers.mediadown;this.param="&pid="+EncryptId+"&index="+index;this.option.onSuccess=function(transport){if(self.MngPlay(transport.responseText)){window.location.href(transport.responseText);}};this.rqst();},MngBulletin:function(text){if(text==-11){return false;}else{return true;}},GetBulletinInfo:function(bid,bname){var self=this;this.oper=this.opers.getbulletin;this.param="&bid="+bid;this.option.onSuccess=function(transport){if(self.MngBulletin(transport.responseText)){Toper.MyDialog(540,400,"",transport.responseText);}};this.rqst();}});var user=new User();function OpenPlay(pid,index,mtype){var retChk=CheckPlayerVersion();if(retChk==-1){if(confirm(Res.GetValue("WARN_NOPLAYER"))){window.location="Manager/Setup/MiniPlayer.exe";}}else if(retChk==-2&&confirm(RS("Warn_MiniPlayerLower"))){location.href="Manager/Setup/MiniPlayer.exe";}else{Dialog.info(Toper.RS("Warn_Waiting")+"...",{className:"alphacube",width:150,height:50,showProgress:true});setTimeout("user.Play('"+pid+"',"+index+","+mtype+");Dialog.closeInfo();",2000);}}
function OpenDown(pid,index){var retChk=CheckPlayerVersion();if(retChk==-1){if(confirm(Res.GetValue("WARN_NOPLAYER"))){window.location="Manager/Setup/MiniPlayer.exe";}}else if(retChk==-2&&confirm(RS("Warn_MiniPlayerLower"))){window.location="Manager/Setup/MiniPlayer.exe";}else{Dialog.info(Toper.RS("Warn_Waiting")+"...",{className:"alphacube",width:150,height:50,showProgress:true});setTimeout("user.MediaDown('"+pid+"',"+index+");Dialog.closeInfo();",2000);}}
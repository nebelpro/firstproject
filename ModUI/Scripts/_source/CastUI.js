// resource
var ERROPENSTREAM=RS("ERR_OPENSTREAM");

var R_STATE_CLOSE       = "TA_STATE_CLOSE";
var R_STATE_STOP        = "TA_STATE_STOP";
var R_STATE_PAUSE       = "TA_STATE_PAUSE";
var R_STATE_BUFFER      = "TA_STATE_BUFFER";
var R_NO_OCX            = "TA_NO_OCX";
var R_REC               = "TA_REC";
var R_STOPREC           = "TA_STOPREC";
var R_CURBIT            = "TA_CURBIT";
var R_AVGBIT            = "TA_AVGBIT";

var STATE_NONE          = 0;
var STATE_STOP          = 1;
var STATE_RUN           = 2;
var STATE_PAUSE         = 3;
var STATE_TEMPPAUSE     = 4;

var ERR_NONE            = 0;
var ERR_ABORT           = 1;
var ERR_TERMINATED      = 2;

var VOLUME_LENGTH       = 40;
var VOLUME_MAX          = 10000;


var gVolume             = 50;
var gCurVolume          = 5000;
var gOldVolume          = 0;
var gCurPosition        = 0;
var gTimeSliderMax      = 0;
var castType            = 2;
var gRecPer             = 0;
var gRecState           = 0;

var gbMute              = false;
var bHasVideo           = false;
var bHasAudio           = false;
var bReady              = false;
var gCanRec             = false;


var param, img, objMwp, allParam, param1;
var gHandle,gCurChapter;

function init(){
    objMwp = $("MWP");              
	objMwp.attachEvent("StateChange",OnCustomEvent);
	objMwp.attachEvent("ErrorNotify",OnErrorNotify);
	
}

function Page_Load(strParam,nCastType,IsCanRec){       
                
    allParam  = SortRecList(strParam);// allParam  = SortRecList(eval(strParam+";"));               
    castType = nCastType;//2 
    gRecPer = IsCanRec;
	if(allParam.length > 1)		
		param1 = allParam[1];
	param = allParam[0];
	img = $("divImg");
	objMwp = $("MWP");              
	objMwp.attachEvent("StateChange",OnCustomEvent);
	objMwp.attachEvent("ErrorNotify",OnErrorNotify);
	Open();
	OnTimeOut();
}



function OnCustomEvent(){
	var objState = objMwp.currentState;

	if(objState == STATE_NONE){
		$("spNow").innerHTML = R_STATE_CLOSE;
		$("imgPlay").src = "Images/Player/play_nor.gif";
		
	}
	else if(objState == STATE_STOP){
		$("spNow").innerHTML = R_STATE_STOP;
		$("imgPlay").src = "Images/Player/play_nor.gif";
		$("imgStop").src = "Images/Player/stop_dis.gif";
		/*if(gRecPer == 1){
			gCanRec = false;
			$("imgRec").src = "Images/player/rec_4.gif";
			$("imgRec").className = "nohand";
			$("imgRec").onmouseover = function(){};
			$("imgRec").onmouseout = function(){};
		}*/
	}
	else if(objState == STATE_RUN){
		ShowNow();
		$("imgPlay").src = "Images/Player/play_dis.gif";
        $("imgStop").src = "Images/Player/stop_nor.gif";
		img.style.display = "none";
		if(objMwp.hasVideo())
			bHasVideo = true;
		if(objMwp.hasAudio())
			bHasAudio = true;
		
		InitUI();
		/*if(gRecPer == 1){
			gCanRec = true;
			$("imgRec").src = "Images/player/rec_1.gif";
			$("imgRec").className = "hand";
			$("imgRec").onmouseover = function(){$("imgRec").src = "Images/player/rec_2.gif";};
			$("imgRec").onmouseout = function(){
					$("imgRec").src = (gRecState == 0)?"Images/player/rec_1.gif":"Images/player/rec_3.gif";
				};
			$("imgRec").title = R_REC;
			
		}*/
		
	}
		
}

function GetBit(){
	if(!bReady)return;
	var strBit = objMwp.GetBitrate();
	var strCurBit,strAvgBit;
	strCurBit = strAvgBit = "";
	if(strBit.length != 0){
		var xml = new ActiveXObject("Microsoft.XMLDOM");
		xml.loadXML(strBit);
		var xmlElt = xml.documentElement;
		strCurBit = xmlElt.getAttribute("cur");
		strAvgBit = xmlElt.getAttribute("avg");
		//$("spBit").innerHTML = R_CURBIT+": "+strCurBit+" Kbps&nbsp;/&nbsp;"+R_AVGBIT+": "+strAvgBit + " Kbps";
		return R_CURBIT+": "+strCurBit+" Kbps&nbsp;/&nbsp;"+R_AVGBIT+": "+strAvgBit + " Kbps";
	}else{
	    return "";
	}
}

function OnErrorNotify(){
	var objErr = objMwp.lastError;
	
}

function Open(){
    objMwp.style.display="block";
    
	bHasVideo = false;
	bHasAudio = false;
	try{
		var ret;
		objMwp.SetType(castType);
		if(allParam.length > 1)
			ret = objMwp.Open(param.ssrc,param1.ssrc);
		else{
			ret = objMwp.Open(param.ssrc,0);
			if(param.auto == 1)
				objMwp.InsertAuto();
		}
		
		
		var objRece,strMs,arrMs;
		strMs = "";
		var bHasInsert = false;

		for(var i=0;i < param.receive.length;i++){
			objRece = param.receive[i];
			if(objRece.type == "tcp"){
				objMwp.InsertTCP(objRece.ip, objRece.port, param.ssrc);
				bHasInsert = true;
			}else if(objRece.type == "ms"){
				strMs = GetMSPath(objRece.ip,objRece.port,0,objRece.msid,objRece.uid);
				if(strMs != ""){
					arrMs = strMs.split(":");
					objMwp.InsertTCP(arrMs[0], arrMs[1], param.ssrc);
					bHasInsert = true;
				}
			}
			else{
				objMwp.InsertUDP(objRece.ip, objRece.port);
				bHasInsert = true;
			}

			if(allParam.length > 1){
				if(bHasInsert)
					break;
			}else{
				if(param.auto == 0 && bHasInsert)
					break;
			}

		}
		
		bHasInsert = false;
		if(allParam.length > 1){
			for(var i=0;i < param1.receive.length;i++){
				objRece = param1.receive[i];
				if(objRece.type == "tcp"){
					objMwp.InsertTCP(objRece.ip, objRece.port, param1.ssrc);
					bHasInsert = true;
				}else if(objRece.type == "ms"){
					strMs = GetMSPath(objRece.ip,objRece.port,0,objRece.msid,objRece.uid);
					if(strMs != ""){
						arrMs = strMs.split(":");
						objMwp.InsertTCP(arrMs[0], arrMs[1], param.ssrc);
						bHasInsert = true;
					}
				}else{
					objMwp.InsertUDP(objRece.ip, objRece.port);
					bHasInsert = true;
				}

				if(bHasInsert){
						break;
				}
			}	
		}
		objMwp.Run();
		
		
	}catch(e){
		//alert(R_NO_OCX);
		if(confirm(Res.GetValue("WARN_NOPLAYER"))){
		        window.location="SoftDown.aspx";
		}
		return;
	}
	if(ret == true){
		bReady = true;
		//SetVolumeSlider();
	}else{
		bReady = false;
		objMwp.style.display = "none";
		img.style.display = "block";
		alert(ERROPENSTREAM);
	}
	
}



function InitUI(){
	if(bHasVideo){
		objMwp.style.width = "507px";
		objMwp.style.height = "334px";
		img.style.display = "none";
		objMwp.style.display="block";
	}else{
		//img.style.display = "block";
		objMwp.style.width = 0;
		objMwp.style.height = 0;
	}
}
function ShowNow(){
	if(!bReady)return;
	str = "strCastName";	
	if(objMwp.currentState == STATE_RUN){	
		$("spNow").innerHTML = "<marquee id=\"mqNow\" scrollDelay=20 scrollAmount=1 onmouseover=\"this.stop();\" onmouseout=\"this.start();\">"+str+"</marquee>";
		$("spNow").style.width = (gTimeSliderMax > 350)?parseInt(gTimeSliderMax-350):0;
	}
}


function PlayPause(){   
	if(!bReady)return;
	var nState = objMwp.currentState;
	if(nState != STATE_RUN)
		Play();
}

function Play() {
	if(!bReady)return;
	objMwp.Run();
}

function Stop() {
	if(!bReady)return;
	objMwp.Stop();
}
function SetFull(){
	if(!bReady)return;
	objMwp.SetFullScreen();
}

function MWPColse() {
	if(!bReady)return;
	objMwp.Close();
}
function Rec(){
	if(!bReady)return;
	if(!gCanRec)return;
	if(gRecState == 0){
		var ret = objMwp.StartRecord();
		if(ret)
			gRecState = 1;
	}else{
		objMwp.StopRecord();
		gRecState = 0;
	}
	$("imgRec").title = (gRecState == 0)?R_REC:R_STOPREC;
}







function GetPosition(){
	if(!bReady)return;
	return (objMwp.GetPosition() / 1000);
}



function Mover_Stop(){
	if(!bReady)return;
	if(objMwp.currentState == STATE_STOP)
		$("imgStop").src = "Images/Player/stop_dis.gif";
	else
		$("imgStop").src = "Images/Player/stop_hot.gif";		
}
function Mout_Stop(){
	if(!bReady)return;
	if(objMwp.currentState == STATE_STOP)
		$("imgStop").src = "Images/Player/stop_dis.gif";
	else
		$("imgStop").src = "Images/Player/stop_nor.gif";	
}

function Mover_Play(){
	if(!bReady)return;
	if(objMwp.currentState == STATE_RUN)
		$("imgPlay").src = "Images/Player/play_dis.gif";
	else
		$("imgPlay").src = "Images/Player/play_hot.gif";		
}
function Mout_Play(){
	if(!bReady)return;
	if(objMwp.currentState == STATE_RUN)
		$("imgPlay").src = "Images/Player/play_dis.gif";
	else
		$("imgPlay").src = "Images/Player/play_nor.gif";	
}



function OnTimeOut(){	
	if(!bReady){
		window.clearTimeout(gHandle);
		return;
	}
	// time
	gCurPosition = GetPosition();
	$("spTime").innerHTML = ConvertToTime(gCurPosition);

	gHandle = setTimeout("OnTimeOut()",1000);
	
	/*if(gCanRec && gRecState == 1){
		$("spRec").innerHTML = "<font color=red>"+R_REC+"</font>";
	}
	if(gRecState == 0){
		$("spRec").innerHTML = "";	
	}*/
	GetBit();

}
function ShowVideoEmpty(){

    //$("divImg").style.display = "block";
		$("MWP").style.display="none";
		$("divImg").style.display="none";
		
}

var playSelf=this;
function CastPlay(cid){    
	//setTimeout("UpdateUserState()",600000);
	var option={
		  method:"get",
		  parameters:"rnd="+Math.random()+"&oper=GetCastInfo&id="+cid,
		  onSuccess:function(transport){ 		   
		    if(transport.responseText=="-10"){	    
		        alert(RS("WARN_NOLOGINPLAY"));
		    }else{		       
		        var json= eval('('+transport.responseText+')');	
		        if(json.Suc=="True"){
		            if(json.Param!="-1"){		              
		                $("castInfo").innerHTML=json.Info;		        
		                playSelf.Page_Load(json.Param,2,0);
		            }else{
		                alert(RS("ERR_MIXCHANNEL"));
		            }
		        }
		    }
		  },
		  onFailure:function(transport){ 			  
		  }
		}
		var request= new Ajax.Request("Ajax.aspx",option);
}

/* the player pulic function  */

function SortRecList(allObj){
	if(allObj == null)return null;


	var retObj = new Array();
	for(var i=0;i<allObj.length;i++){
		var tObj = allObj[i];
		if(tObj == null) continue;
		var bOk = false;
		for(var j=0;j<tObj.receive.length;j++){
			if(tObj.receive[j].type == "tcp" || tObj.receive[j].type == "ms"){
				if(j == 0){
					 retObj[i] = tObj;
					bOk = true;
					break;
				}else{
					var temp = tObj.receive[0];
					 tObj.receive[0] = tObj.receive[j];
					 tObj.receive[j] = temp;					
					 retObj[i] = tObj;
					 bOk = true;
					 break;
					}
			}
		}
		if(!bOk){
			retObj[i] = tObj;
		}
	}
	
	return retObj;

}

function GetMSPath(hsip,hsport,pid,msid,uid) {
    var objMP;
    try {
        objMP = new ActiveXObject("TaPlayer.HomeServer");
		return objMP.GetMSAdapter(hsip,hsport,pid,uid,msid);		
    }
    catch (e) {
	   return "";
    }
}


/*document.onkeydown = function(){
	event.keyCode = 0;
	event.returnValue = false;
};*/


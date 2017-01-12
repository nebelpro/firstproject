
var R_NO_OCX = "error";


var STATE_NONE = 0;
var STATE_STOP = 1;
var STATE_RUN = 2;
var STATE_PAUSE = 3;
var STATE_TEMPPAUSE = 4;





/*var R_STATE_CLOSE = Res.GetValue("TA_STATE_CLOSE");
var R_STATE_STOP = Res.GetValue("TA_STATE_STOP");
var R_STATE_PAUSE = Res.GetValue("TA_STATE_PAUSE");
var R_STATE_BUFFER = Res.GetValue("TA_STATE_BUFFER");
var R_NO_OCX = Res.GetValue("TA_NO_OCX");
var R_REC = Res.GetValue("TA_REC");
var R_STOPREC =Res.GetValue("TA_STOPREC"); 
var R_CURBIT =Res.GetValue("TA_CURBIT"); 
var R_AVGBIT =Res.GetValue("TA_AVGBIT"); 
*/



function Page_Load(strParam){        
    allParam  = SortRecList(eval(strParam+";"));              
    castType = 2;
	if(allParam.length > 1)		
		param1 = allParam[1];
	param = allParam[0];
	img = $("divImg");	
	objMwp = $("MWP");              
	objMwp.attachEvent("StateChange",OnCustomEvent);
	objMwp.attachEvent("ErrorNotify",OnErrorNotify);
	Open();
}

function OnCustomEvent(){
	var objState = objMwp.currentState;
	if(objState == STATE_NONE){
		img.style.display = "block";
		objMwp.style.width = 0;
		objMwp.style.height = 0;
	}
	else if(objState == STATE_STOP){
		
	}else if(objState == STATE_RUN){
		img.style.display = "none";
		if(objMwp.hasVideo())
			bHasVideo = true;
		if(objMwp.hasAudio())
			bHasAudio = true;
		InitUI();
	}
		
}

function OnErrorNotify(){
	var objErr = objMwp.lastError;
	
}

function Open(){

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
		var cf = confirm(Res.GetValue("Info_WebPlayer"));
	    if(cf){
		    window.location = "Manager/setup/WebPlayer.exe";
	    }
		
	}	
	if(ret!=true){
		bReady = false;
		objMwp.style.display = "none";
		img.style.display = "block";
		//alert(ERROPENSTREAM);
	}
	
}

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

function InitUI(){
	if(bHasVideo){
		objMwp.style.width = "100%";
		objMwp.style.height = "100%";
		img.style.display = "none";
	}else{
		img.style.display = "block";
		objMwp.style.width = 0;
		objMwp.style.height = 0;
	}
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

function $(id){
	return document.getElementById(id);
}
function ShowVideoEmpty(){

    $("divImg").style.display = "block";
		$("MWP").style.display="none";
		
}








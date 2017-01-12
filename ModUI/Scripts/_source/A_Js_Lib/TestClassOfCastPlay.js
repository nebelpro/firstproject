var objMwp;
var State={
            NONE:0,
            STOP:1,
            RUN:2,
            PAUSE:3,
            TEMPPAUSE:4
        };

var WebPlayer = Class.create();
WebPlayer.prototype = {
    initialize:function(){
        
       
        this.Err={
            None:0,
            Abort:1,
            Terminated:2
        };
        this.Volume_Length=40;
        this.Volume_Max=10000;           
        this.Volume = 50;
        
        this.param;
        this.img;
        //objMwp;
        this.allParam;
        this.param1;
        
        this.CurPositon     = 0;
        this.CurVolume      = 5000;
        this.OldVolume      = 0;        
        this.TimeSliderMax  = 0;        
        this.castType       = 2;       
        this.RecPer         = 0;
        this.RecState       = 0;
                
        this.Handle;
        this.CurChapter;
        this.HasVideo   = false;
        this.HasAudio   = false;        
        this.Ready      = false;
        this.Mute       = false;
        this.CanRec     = false;
        
        
    
    },
    Page_Load:function (strParam){        
        this.allParam  = this.SortRecList(eval(strParam+";"));              
        this.castType = 2;
	    if(this.allParam.length > 1)		
		    this.param1 = this.allParam[1];
	    this.param = this.allParam[0];
	    //this.img = $("divImg");	
	    objMwp = $("MWP");   
	    alert(objMwp);  
	    var Self = this;         
	    objMwp.attachEvent("StateChange",this.OnCustomEvent);
	    objMwp.attachEvent("ErrorNotify",this.OnErrorNotify);
	    //alert("aa");
	    this.Open();
	    //alert("aa");
    },



    Load:function(){//Page_Load
        //Paramers
        var strParam;
        var CastType;
        var IsCanRec;
        
        this.allParam  = this.SortRecList(eval(strParam+";"));
	    this.castType = CastType;
	    this.RecPer = IsCanRec;
	    if(this.castType == "")
		    this.castType = 2;
	    else
		    this.castType = parseInt(castType);
	    if(this.allParam.length > 1)		
		    this.param1 = allParam[1];

	    this.param = allParam[0];
	    this.img = $("divImg");	
	    objMwp = $("MWP");
	    objMwp.attachEvent("StateChange",this.OnCustomEvent);
	    objMwp.attachEvent("ErrorNotify",this.OnErrorNotify);
	    this.Open();
	    this.OnTimeOut();
	    this.TimeSliderMax = document.body.clientWidth - 73;
	    try{
		     var objLocal = new ActiveXObject("TaPlayer.LocalSettings");
		     var lastWidth = objLocal.PlayerWidth;
		     var lastHeight = objLocal.PlayerHeight;
		     objLocal = null;
		    var xp,yp;
		    if ((parseInt(navigator.appVersion) >= 4 ))
		    {
			    xp = (screen.width - lastWidth) / 2;
			    yp = (screen.height - lastHeight) / 2;
		    }
		    window.moveTo(xp,yp);
		    window.resizeTo(lastWidth,lastHeight);
	    }catch(e){

	    }
    },
    /* 获取节目接收地址类型  */
    SortRecList:function (allObj){
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

    },        
    Open:function (){
	    this.HasVideo = false;
	    this.HasAudio = false;
	    try{
		    var ret;
		    objMwp.SetType(this.castType);
		    if(this.allParam.length > 1)
			    ret = objMwp.Open(this.param.ssrc,this.param1.ssrc);
		    else{
			    ret = objMwp.Open(this.param.ssrc,0);
			    if(this.param.auto == 1)
				    objMwp.InsertAuto();
		    }
    		
    		
		    var objRece,strMs,arrMs;
		    strMs = "";
		    var bHasInsert = false;

		    for(var i=0;i < this.param.receive.length;i++){
			    objRece = this.param.receive[i];
			    if(objRece.type == "tcp"){
				    objMwp.InsertTCP(objRece.ip, objRece.port, this.param.ssrc);
				    bHasInsert = true;
			    }else if(objRece.type == "ms"){
				    strMs = this.GetMSPath(objRece.ip,objRece.port,0,objRece.msid,objRece.uid);
				    if(strMs != ""){
					    arrMs = strMs.split(":");
					    objMwp.InsertTCP(arrMs[0], arrMs[1], this.param.ssrc);
					    bHasInsert = true;
				    }
			    }
			    else{
				    objMwp.InsertUDP(objRece.ip, objRece.port);
				    bHasInsert = true;
			    }

			    if(this.allParam.length > 1){
				    if(bHasInsert)
					    break;
			    }else{
				    if(this.param.auto == 0 && bHasInsert)
					    break;
			    }

		    }
    		
		    bHasInsert = false;
		    if(this.allParam.length > 1){
			    for(var i=0;i < this.param1.receive.length;i++){
				    objRece = this.param1.receive[i];
				    if(objRece.type == "tcp"){
					    objMwp.InsertTCP(objRece.ip, objRece.port, this.param1.ssrc);
					    bHasInsert = true;
				    }else if(objRece.type == "ms"){
					    strMs = this.GetMSPath(objRece.ip,objRece.port,0,objRece.msid,objRece.uid);
					    if(strMs != ""){
						    arrMs = strMs.split(":");
						    objMwp.InsertTCP(arrMs[0], arrMs[1], this.param.ssrc);
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
		    alert(this.Tips.NoOcx);
	    }
	    if(ret == true){
		    this.Ready = true;
		    //this.SetVolumeSlider();
	    }else{
		    this.Ready = false;
		    objMwp.style.display = "none";
		    //this.img.style.display = "block";
		    this.alert(this.Tips.ErrOpenStream);
	    }
    	
    },
    //Player Oper event
    PlayPause:function(){
	    if(!this.Ready)return;
	    var nState = objMwp.currentState;
	    if(nState != State.RUN)
		this.Play();
    },
    Play:function () {
	    if(!this.Ready)return;
	    objMwp.Run();
    },
    Stop:function () {
	    if(!this.Ready)return;
	    objMwp.Stop();
    },
    SetFull:function(){
	    if(!this.Ready)return;
	    objMwp.SetFullScreen();
    },
    MWPColse:function () {
	    if(!this.Ready)return;
	    objMwp.Close();
    },    
    ConvertToTime:function(nTime){
        var nHour	= Math.round((nTime - 1800) / 3600);
	    var nMin	= Math.round(((nTime % 3600) - 30)/ 60);
	    var nSec	= Math.round((nTime % 3600) % 60);
	    var strsHour	= ConvertToString(nHour);
	    var strMin		= ConvertToString(nMin);
	    var strSec		= ConvertToString(nSec);	
	    return strsHour + ":" + strMin + ":" + strSec;	    
    },
    ConvertToString:function(nValue){
        var strReturn;
	    if (nValue < 10)  strReturn = "0" + nValue;
	    else    strReturn = nValue;
	    return strReturn;    
    },
    Mover_Play:function(){// hover btn_play
	    if(!this.Ready)return;
	    if(objMwp.currentState == State.RUN)
		    $("imgPlay").src = "Images/Player/play_2.gif";
	    else
		    $("imgPlay").src = "Images/Player/play_1.gif";		
    },
    Mout_Play:function (){ // out btn_play
	    if(!this.Ready)return;
	    if(objMwp.currentState == State.RUN)
		    $("imgPlay").src = "Images/Player/play_2.gif";
	    else
		    $("imgPlay").src = "Images/Player/play_0.gif";	
    },
    GetPosition:function (){
	    if(!this.Ready)return;
	    return (objMwp.GetPosition() / 1000);
    },
    //Volume Set And Oper
    SetVolume:function (nPos){
        if(!this.Ready)return;
        objMwp.SetVolume(nPos);
        this.Volume = nPos;
    },
    DrawVolume:function (){
	    var nLeftPix = (this.CurVolume * this.Volume_Length) / this.Volume_Max;
	    $("spVolumeCur").style.width = nLeftPix+"px";		
	    $("spVolumeBtn").style.pixelLeft = parseInt($("spVolumeSlider").offsetLeft) + nLeftPix - 5;
	    $("imgMute").src = this.Mute?"Images/Player/mute_1.gif":"Images/Player/mute_0.gif";
	    this.SetVolume(this.CurVolume);	
    },
    SetMute:function(){
	    if(!this.Ready)return;
	    this.Mute = !this.Mute;
	    if(this.Mute){
		    this.OldVolume = objMwp.GetVolume();
	    }
	    this.CurVolume = this.Mute?0:this.OldVolume;
	    this.DrawVolume();
    },
    SlideVolumeOver:function(obj){
	    obj.releaseCapture();
	    obj=false;
    },
    SlideVolume:function(obj){
	    if (!this.Mute){	
		    var nMin = $("spRight").offsetLeft + $("spVolumeSlider").offsetLeft;
		    var nMax = nMin + this.Volume_Length;
		    if (event.button == 1){
			    obj.setCapture();
			    var nOffX = event.clientX;
    			
			    if (nOffX >= nMin && nOffX <= nMax)
			    {
				    obj.style.pixelLeft = nOffX - $("spRight").offsetLeft - 5;
				    var nLeftPix = nOffX - nMin;
				    if (nLeftPix > this.Volume_Length)
					    nLeftPix = 0;
    				
				    var nVolume = parseInt(nLeftPix * this.Volume_Max / this.Volume_Length);
				    $("spVolumeCur").style.width = nLeftPix;
				    this.CurVolume = nVolume;
				    this.SetVolume(nVolume);
			    }
		    }
	    }	
    },        
    SetVolumeSlider:function (){
	    if(!this.Ready)return;
	    if (!this.Mute){
		    this.CurVolume = objMwp.GetVolume();
		    this.DrawVolume();
	    }
    },

    InitUI:function(wdh,hgt){
	    if(this.HasVideo){
		    objMwp.style.width = wdh;
		    objMwp.style.height = hgt;
		    this.img.style.display = "none";
	    }else{
		    this.img.style.display = "block";
		    objMwp.style.width = 0;
		    objMwp.style.height = 0;
	    }
    },
    GetBit:function(){
	    if(!this.Ready)return;
	    var strBit = objMwp.GetBitrate();
	    var strCurBit,strAvgBit;
	    strCurBit = strAvgBit = "";
	    if(strBit.length != 0){
		    var xml = new ActiveXObject("Microsoft.XMLDOM");
		    xml.loadXML(strBit);
		    var xmlElt = xml.documentElement;
		    strCurBit = xmlElt.getAttribute("cur");
		    strAvgBit = xmlElt.getAttribute("avg");
		    $("spBit").innerHTML = this.Tips.CurBit+": "+strCurBit+" Kbps&nbsp;/&nbsp;"+this.Tips.AvgBit+": "+strAvgBit + " Kbps";
	    }
	},
	ShowNow:function(){
	    if(!this.Ready)return;
	    var str = "strCastName";	
	    if(objMwp.currentState == State.RUN){	
		    $("spNow").innerHTML = "<marquee id=\"mqNow\" scrollDelay=20 scrollAmount=1 onmouseover=\"this.stop();\" onmouseout=\"this.start();\">"+str+"</marquee>";
		    $("spNow").style.width = (this.TimeSliderMax > 350)?parseInt(this.TimeSliderMax-350):0;
	    }
    },
    Rec:function(){
	    if(!this.Ready)return;
	    if(!this.CanRec)return;
	    if(this.RecState == 0){
		    var ret = objMwp.StartRecord();
		    if(ret)
			    this.RecState = 1;
	    }else{
		    objMwp.StopRecord();
		    this.RecState = 0;
	    }
	    $("imgRec").title = (this.RecState == 0)?this.Tips.Rec:this.Tips.StopRec;
    },
    GetMSPath:function(hsip,hsport,pid,msid,uid) {
        var objMP;
        try {
            objMP = new ActiveXObject("TaPlayer.HomeServer");
		    return objMP.GetMSAdapter(hsip,hsport,pid,uid,msid);		
        }
        catch (e) {
	       return "";
        }
    },    
    PageResize:function (){
	    this.TimeSliderMax = document.body.clientWidth - 73;
	    this.ShowNow();
	    if(document.body.clientWidth < 460){
		    $("tbMain").style.width = "460px";
	    }else{
		    $("tbMain").style.width = "100%";
	    }
	    try{
		     var objLocal = new ActiveXObject("TaPlayer.LocalSettings");
		     objLocal.PlayerWidth = objMwp.GetWindowWidth();
		     objLocal.PlayerHeight = objMwp.GetWindowHeight();
		     objLocal = null;
	    }catch(e){

	    }
    },
    OnTimeOut:function (){	
	    if(!this.Ready){
		    window.clearTimeout(this.Handle);
		    return;
	    }
	    // time
	    this.CurPosition = this.GetPosition();
	    $("spTime").innerHTML = this.ConvertToTime(this.CurPosition);

	    this.Handle = setTimeout("OnTimeOut()",1000);
    	
	    if(this.CanRec && this.RecState == 1){
		    $("spRec").innerHTML = "<font color=red>"+this.Tips.Rec+"</font>";
	    }
	    if(this.RecState == 0){
		    $("spRec").innerHTML = "";	
	    }
	    this.GetBit();

    },
    OnCustomEvent:function(){
        
	    var objState = objMwp.currentState;
        var self = this;
	    if(objState == State.NONE){
		    $("spNow").innerHTML = State.Close;
		    $("imgPlay").src = "Images/Player/play_0.gif";
	    }
	    else if(objState == State.STOP){
		    $("spNow").innerHTML = State.Stop;
		    $("imgPlay").src = "Images/Player/play_0.gif";
		    if(this.RecPer == 1){
			    this.CanRec = false;
			    $("imgRec").src = "Images/player/rec_4.gif";
			    $("imgRec").className = "nohand";
			    $("imgRec").onmouseover = function(){};
			    $("imgRec").onmouseout = function(){};
		    }
	    }
	    else if(objState == State.RUN){
		    //this.ShowNow();
		    //$("imgPlay").src = "Images/Player/play_2.gif";

		    this.img.style.display = "none";
		    if(objMwp.hasVideo())
			    this.HasVideo = true;
		    if(objMwp.hasAudio())
			    this.HasAudio = true;
    		
		    this.InitUI();
		    if(this.RecPer == 1){
			    this.CanRec = true;
			    $("imgRec").src = "Images/player/rec_1.gif";
			    $("imgRec").className = "hand";
			    $("imgRec").onmouseover = function(){$("imgRec").src = "Images/player/rec_2.gif";};
			    $("imgRec").onmouseout = function(){
					    $("imgRec").src = (this.RecState == 0)?"Images/player/rec_1.gif":"Images/player/rec_3.gif";
				    };
			    $("imgRec").title = this.Tips.Rec;
    			
		    }    		
	    }    		
    },
    OnErrorNotify:function (){
	    var objErr = objMwp.lastError;
    	
    }
    
    
  

}



document.onkeydown = function(){
	event.keyCode = 0;
	event.returnValue = false;
};

var Player = new WebPlayer();

/*


function ShowVideoEmpty(){

    $("divImg").style.display = "block";
		$("MWP").style.display="none";
		
}

*/







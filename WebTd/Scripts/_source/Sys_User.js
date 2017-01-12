
var User = Class.create();
User.prototype = Object.extend(new AjaxBase(),{
	initialize:function(){
	    this.pass= "";
	    this.mask= "";
	    
	    this.begintime="";
	    this.endtime="";
	    
		this.tips ={
          err_Confirm : Toper.RS("Warn_UserPasswordConfirm"),
          err_Format : Toper.RS("Warn_UserPwdFormat"),          
          err_Permit : Toper.RS("Warn_UserPermit"),
          err_OldPwd : Toper.RS("Warn_UserOldPwdError"),
          suc_modifypwd:Toper.RS("Suc_UserModifyPwd"),
          
          err_Null : Toper.RS("Warn_NoNull"),
          err_CardNo : Toper.RS("Warn_CardNo"),
          err_CardPwd : Toper.RS("Warn_CardPwd"),
          err_addPoint :Toper.RS("Warn_AddPoint"),        
          err_cardNotExist:Toper.RS("Warn_CardNotExist"),
          err_cardUsed:Toper.RS("Warn_CardIsUsed"),
          err_cardType:Toper.RS("Warn_CardTypeError"),         
          err_CardInvalid :Toper.RS("Warn_CardInvalid"),
          suc_AddPoint :Toper.RS("Suc_AddPoint"),
          
          err_dateformat:Toper.RS("Warn_DateError"),
          err_daterange:Toper.RS("Warn_DateRange") ,
          //PLAY
          PlayConfirm:Toper.RS("Info_PlayConfirm") ,
          err_PlayPermit:Toper.RS("Warn_NoPlayPermit"),
          err_groupmask:Toper.RS("Warn_NoGroupPermit"),
          err_nopoint:Toper.RS("Warn_NoPoint"),
          
          err_DownPermit:Toper.RS("Warn_NoMediaDownPermit")     
           
		};
		this.opers ={
		   login:"Login",	
		   modifypwd:"UserModifyPwd",
		   htmlmodify:"HtmlModifyPwd",
		   htmlpointadd:"HtmlPointAdd",
		   addpoint:"UserAddPoint",
		   getchargelist:"GetChargeList",
		   getplayloglist:"GetPlayLogList",
		   play:"ProgramPlayStep1",
		   play2:"ProgramPlayStep2",
		   mediadown:"ProgramDown",
		   getbulletin:"GetBulletinInfo"
		};
	},	
	ChkMng:function(restext){
	   if( restext == -10){       
         location.href="Default.aspx";
			return false;
		}else if(restext == -11){
	      alert(this.tips.err_Permit);
	      return false;
	   }else if(restext == -12 ){
	      alert(this.tips.err_Confirm);
	      return false;
	   }else if(restext == -13){
	      alert(this.tips.err_OldPwd);
	      return false;
	   }else{
	      return true;
	   }
	},
	MngAddPoint:function(restext){
	    if( restext == -10){	            
            location.href="Default.aspx";
			return false;
		}else if(restext==-21){
		    alert(this.tips.err_addPoint);
		    return false;
	    }else if(restext== -1){
	        alert(this.tips.err_cardNotExist);
	         return false;
	    }else if(restext== -2){
	        alert(this.tips.err_CardPwd);
	         return false;
	    }else if(restext== -3){
	        alert(this.tips.err_CardInvalid);
	         return false;
	    }else if(restext== -4){
	        alert(this.tips.err_cardUsed);
	        return false;
	    }else if(restext== -5){
	        alert(this.tips.err_cardType);
	         return false;
	    }else{
	        return true;
	    }
	},
	MngLog:function(text){
	    if(text == -10){
	        location.href="Default.aspx";
			return false;
	    }else if(text == -21){
	        alert(this.tips.err_dateformat);
	        return false;
	    }else if(text == -22){
	        alert(this.tips.err_daterange);
	        return false;
	    }else{
	        return true;
	    }
	},
	ChkOldPass:function(){
	    var oldPwd=$("txtPwdOld").value;
	    if(/\W/.test(oldPwd)){
	       alert(this.tips.err_Format);
		   $("txtPwdOld").focus();
		   return false;
	    }else{
	        return true;	        
	    }
	
	},
	ChkPass:function(){
	   var strPass = $("txtPwdNew").value;
	   var strPassConfirm = $("txtConfirm").value;	   
	   if (strPass != strPassConfirm)  {
		   alert(this.tips.err_Confirm);
		   $("txtPwdNew").focus();
		   return false;
	   } else if (/\W/.test(strPass)) {
		   alert(this.tips.err_Format);
		   $("txtPwdNew").focus();
		   return false;
	   }else{
	      this.pass = strPass;
	      return true;
	   }
	},
	CtrlModifyPwd:function(wdh,hgt,title){
	    this.oper = this.opers.htmlmodify;
		this.option.onSuccess = function(transport){		   
		    Toper.MyDialog(wdh,hgt,title,transport.responseText);
		};
		this.rqst();		
    },
	ModifyPwd:function(){
	    var self = this;
	    if(this.ChkOldPass()&&this.ChkPass()){
	       this.oper = this.opers.modifypwd;
           this.param = "&old="+encodeURIComponent($("txtPwdOld").value)+"&pass="+encodeURIComponent(this.pass)+"&pconfirm="+encodeURIComponent($("txtConfirm").value);               
           this.option.onSuccess=function(transport){               
                if(self.ChkMng(transport.responseText)){
                    alert(self.tips.suc_modifypwd);					  
                    Toper.Dialog.okCallback();
                }		            		 
          };
          this.rqst();
	    }
	
	},
	ChkPointNo:function(){
	    var no = $("txtNo").value;
	    if(no.length == 0){
		    alert(this.tips.err_Null);
		    return false;
	    }else if (no.length != 10){
		    alert(this.tips.err_CardNo);
		    return false;
	    }else  if(/\W/.test(no)){
			    alert(this.tips.err_CardNo);
			    return false;
	    }else{
	        return true;
	    }
	},
	ChkPointPwd:function(){
	    var pwd = $("txtPwd").value;
	    if(pwd.length != 10){
		    alert(this.tips.err_CardPwd);
		    return false;
	    }else{
	        return true;
	    }
    },	
	CtrlPointAdd:function(wdh,hgt,title){
	    this.oper = this.opers.htmlpointadd;
	    this.option.onSuccess = function(transport){
	        Toper.MyDialog(wdh,hgt,title,transport.responseText);
	    };
	    this.rqst();
	},
	AddPoint:function(){
	    var self=this;
	    if(this.ChkPointNo()&&this.ChkPointPwd()){
	       this.oper = this.opers.addpoint;
	       this.param="&cardno="+$("txtNo").value+"&cardpwd="+$("txtPwd").value;
	       this.option.onSuccess=function(transport){	        
	         if(self.MngAddPoint(transport.responseText)){
                    alert(self.tips.suc_AddPoint);					  
                    Toper.Dialog.okCallback();
                }		            		 
	       };
	       this.rqst();	    
	    }
	
	},
	//=======================================================================================
	ChkDate:function(){
	   var dtBegin = $("txtDateBegin").value;
       var dtEnd = $("txtDateEnd").value;    
       if(dtBegin!=""||dtEnd!=""){          
           if(IsDate(dtBegin)&&IsDate(dtEnd)){
               this.begintime = dtBegin;
               this.endtime = dtEnd;
               $("txtDateBegin").value="";
               $("txtDateEnd").value="";
               return true;              
           }else{
               alert(this.tips.err_dateformat);
               return false;
           }
       }else{
           this.begintime = "";
           this.endtime = "";
           return true;
       }
	},
	ChargeQuery:function(wdh,hgt,title){	
	   this.begintime="";
	   this.endtime="";   
	   var listContent= this.GetChargeList(1);
	   var strContainer="<div id=\"Charge\">"+listContent+"</div>";
	   Toper.MyDialog(wdh,hgt,title,strContainer);
	},
	GetChargeList:function(page){	    
	    var temp;
	    this.oper = this.opers.getchargelist;
	    this.async =false;
	    this.param="&begin="+this.begintime+"&end="+this.endtime +"&page="+page;
	    this.option.onSuccess=function(transport){
	            temp= transport.responseText;
	    };
	    this.rqst();
	    return temp;
	},
	btnChargeQuery:function(){
	    if(this.ChkDate()){
	        this.GetCharge(1);
	    }
	},
	GetCharge:function(page){
	    var strRec=this.GetChargeList(page);	    
	    if(this.MngLog(strRec)){
	        $("Charge").innerHTML = strRec;	
	    }
	},
	//==========================================================================
	PlayLogQuery:function(wdh,hgt,title){	
	   this.begintime="";
	   this.endtime="";   
	   var listContent= this.GetPlayLogList(1);
	   var strContainer="<div id=\"PlayLog\">"+listContent+"</div>";
	   Toper.MyDialog(wdh,hgt,title,strContainer);
	},
	GetPlayLogList:function(page){	    
	    var temp;
	    this.oper = this.opers.getplayloglist;
	    this.async =false;
	    this.param="&begin="+this.begintime+"&end="+this.endtime +"&page="+page;
	    this.option.onSuccess=function(transport){
	            temp= transport.responseText;
	    };
	    this.rqst();
	    return temp;
	},
	btnPlayLogQuery:function(){
	     if(this.ChkDate()){
	        this.GetPlayLog(1);
	    }
	
	},
	GetPlayLog:function(page){
	    var strRec=this.GetPlayLogList(page);	    
	    if(this.MngLog(strRec)){
	        $("PlayLog").innerHTML = strRec;	
	    }
	},
	//================ play ,down=============================
	MngPlay:function(text){
	    if(text == -10){
	        location.href="Default.aspx";
			return false;
	    }else if(text == -14){
	        alert(this.tips.err_PlayPermit);
	        return false;
	    }else if(text == -15){
	        alert(this.tips.err_groupmask);
	        return false;
	    }else if(text == -16){
	        alert(this.tips.err_nopoint);
	        return false;
	    }else if(text == -21){
	         alert(this.tips.err_DownPermit);
	        return false;
	    }else{
	        return true;
	    }
	    
	},
   Play2:function(pid,index,mtype,point){       
        var self = this;        
        this.oper = this.opers.play2;
        this.param = "&pid="+pid+"&index="+index+"&point="+point+"&mtype="+mtype;			
        this.option.onSuccess=function(transport){          
          if(self.MngPlay(transport.responseText)){
              window.location.href(transport.responseText);	
              //self.GetDetail();
          }	
        };
        this.rqst();
   },
   IsPlay:function IsPlay(point){
	   if(point == 0)return true;
	   var sMsg = this.tips.PlayConfirm;	   
	   return confirm(sMsg.replace("{0}",point));
   },
   Play:function(EncryptId,index,mType){  
        var self = this;  
        this.oper = this.opers.play;
        this.param = "&pid="+EncryptId;	
        this.option.onSuccess=function(transport){	
	          if(self.MngPlay(transport.responseText)){
	             if(self.IsPlay(transport.responseText)){	
	                 self.Play2(EncryptId,index,mType,transport.responseText);
	            }	
	          }
        };
		this.rqst();
   },
   MediaDown:function(EncryptId,index){
        var self = this;       
        this.oper = this.opers.mediadown;
        this.param = "&pid="+EncryptId+"&index="+index;			
        this.option.onSuccess=function(transport){ 	          
	           if(self.MngPlay(transport.responseText)){
	              window.location.href(transport.responseText);				   
	          }					   
          };
        this.rqst();
   },
   //================== =====================
   MngBulletin:function(text){
       if(text == -11){	       
	        //alert(this.tips.err_bulletinNotExist);
	        return false;	    
	    }else{
	        return true;
	    }
   
   },
   GetBulletinInfo:function(bid,bname){      
        var self = this;
        this.oper = this.opers.getbulletin;
        this.param="&bid="+bid;        
        this.option.onSuccess = function(transport){         
          if(self.MngBulletin(transport.responseText)){
             Toper.MyDialog(540,400,"",transport.responseText);
          }      
        };
        this.rqst();
   
   }
   
	/*---------------------*/
});

var user = new User();

function OpenPlay(pid,index,mtype) {  
    var retChk=CheckPlayerVersion();  
    if(retChk==-1){
        if(confirm(Res.GetValue("WARN_NOPLAYER"))){  
           window.location="Manager/Setup/MiniPlayer.exe";
        }
    }else if(retChk==-2&&confirm(RS("Warn_MiniPlayerLower"))){
        location.href="Manager/Setup/MiniPlayer.exe";
    }else{
        Dialog.info(Toper.RS("Warn_Waiting")+"...",{className: "alphacube",width:150, height:50, showProgress: true});  
        setTimeout("user.Play('"+pid+"',"+index+","+mtype+");Dialog.closeInfo();", 2000);
    }
}
function OpenDown(pid,index) { 
    var retChk=CheckPlayerVersion();
    if(retChk==-1){
        if(confirm(Res.GetValue("WARN_NOPLAYER"))){            
           window.location="Manager/Setup/MiniPlayer.exe";
        }
    }else if(retChk==-2&&confirm(RS("Warn_MiniPlayerLower"))){  
        window.location="Manager/Setup/MiniPlayer.exe";
    }else{
        Dialog.info(Toper.RS("Warn_Waiting")+"...",{className: "alphacube",width:150, height:50, showProgress: true});  
        setTimeout("user.MediaDown('"+pid+"',"+index+");Dialog.closeInfo();", 2000);
    }
}



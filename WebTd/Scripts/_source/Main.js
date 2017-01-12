var Toper = this;

function IsDate(tdate)
{
	var t1,t2,t3,year,month,day;
	t1=tdate.search("-");
	if (t1==-1) 
		return false
	else
	{
		t2=tdate.substr(5);
		t2=t2.search("-")+t1+1;
		if (t2==-1) 
			return false;
		else 
		{
			year=tdate.substr(0,t1);
			month=tdate.substr(t1+1,t2-t1-1);
			t3=tdate.search(" ");
			if (t3>1)
				day=tdate.substr(t2+1,t3-t2-1);
			else day=tdate.substr(t2+1);
			if  (isNaN(year) || isNaN(month) || isNaN(day) )
				return false;
			else
			{	if ( year < 1800 ) 
					return false;   
				else if (month < 1 || month> 12 ) 
					return false;
				else if (day < 1 || day > 31) 
					return false;
			}
		}
	}
	return true;
}

function ConvertToTime(nTime){
	var nHour	= Math.round((nTime - 1800) / 3600);
	var nMin	= Math.round(((nTime % 3600) - 30)/ 60);
	var nSec	= Math.round((nTime % 3600) % 60);
	var strsHour	= ConvertToString(nHour);
	var strMin		= ConvertToString(nMin);
	var strSec		= ConvertToString(nSec);	
	return strsHour + ":" + strMin + ":" + strSec;	
}

function ConvertToString(nValue){
	var strReturn;
	if (nValue < 10)
		strReturn = "0" + nValue;
	else
		strReturn = nValue;
	return strReturn;
}

function ChannelSelected(e){ 
    var eSrc= Event.element(e);      
    if(eSrc.tagName.toUpperCase()=="a".toUpperCase()){
        var elt = Event.findElement(e, "div"); 
        if (elt != document)  {          
            for(var j=0; j< elt.childNodes.length;j++){
                var curNode = elt.childNodes[j];                 
                if(curNode.nodeType ==1&&curNode.tagName.toUpperCase()=="ul".toUpperCase()){
                    for(var i=0; i< curNode.childNodes.length; i++){            
                        var subNode = curNode.childNodes[i];                  
                        if(subNode.nodeType ==1){                           
                            subNode.className="";    
                        }
                    }  
                }
            }           
            eSrc.parentNode.className="selected";
          
        }
    }
}
function UpdateUserState(){
	setTimeout("UpdateUserState()",600000);
	var option={
	  method:"get",
	  parameters:"rnd="+Math.random()+"&oper=online",
	  onSuccess:function(transport){ 		     
	  },
	  onFailure:function(transport){ 			  
	  }
	}
	var request= new Ajax.Request("ajax.aspx",option);
}



	var strver3 = RS("VER_LOCAL");  
	var  strver4 = RS("VER_SERVER"); 
	var v_mp = 3;	
	var v_mn = 4;
	nosetup = RS("INFO_NOSETUP");

	
function CheckPlayer(){
    var objSetup; 
	try	{
		objSetup = new ActiveXObject("LibSetupCheck.SetupPlayer"); 
		var mp =  objSetup.GetProductVersion(3);
		if (mp == 0){
			return false;
		}else{
		    return true;
		}		
	}catch (e)	{
		return false;
	}
}

function CheckPlayerVersion(){     
	var objSetup; 
	try	{
	    objSetup = new ActiveXObject("LibSetupCheck.SetupPlayer");	    
	    var mp =  objSetup.GetProductVersion(3);
	    if (mp == 0){
	        return -1;
	    }else if (!CheckVersion(mp,Cookie.getCookie("PlayerVersion"))){	       
	        return -2;
	   }else{
	        return 1;
	   }
	   
	}
	catch (e){
	  /* if(confirm(Res.GetValue("WARN_NOPLAYER"))){
	        window.location="Manager/Setup/MiniPlayer.exe";	       
	   }*/	
	   return -1;		   
	}	
	
}


function GetVersion(n,s)
{
    //alert(n+",,,"+s);
	var c,strout;
	c = 0;
    try
	{
        objSetup = new ActiveXObject("LibSetupCheck.SetupPlayer"); 		
		if(n == 1){
			c =  objSetup.GetProductVersion(v_ce);
		}
		if(n == 2){
			c =  objSetup.GetProductVersion(v_bc);
		}		
		if(n == 3){
			c =  objSetup.GetProductVersion(v_mp);
		}	
		if(n == 4){
			c =  objSetup.GetProductVersion(v_mn);
		}
		if (n == 5){
			c = objSetup.GetProductVersion(v_re);
		}
		if (n == 6){
			c = objSetup.GetProductVersion(v_pa)
		}
    }
    catch (e){
	}
	if (!CheckVersion(c,s)){
		if (c == 0)	{
			c = nosetup;
		}
		strout = strver4+s+"&nbsp;&nbsp;&nbsp;&nbsp;<font color=red>"+strver3+c+"</font> ";
	}else{
		if (c == 0)	{
			c = nosetup;
		}
		strout = " "+strver4+s+"&nbsp;&nbsp;&nbsp;&nbsp;"+strver3+c;
	}
	document.writeln(strout);
	
}

function CheckVersion(o,s){
	var oma,omi,ob,sma,smi,sb;
	ob = sb = 0;
	if ((o.length > 0) && (s.length > 0))
	{
		if(o == 0)
			return true;
		try
		{
			var arrO = o.split(".");
			var arrS = s.split(".");
			
			oma = parseInt(arrO[0]);
			omi = parseInt(arrO[1]);
			if(arrO.length == 3)
				ob = parseInt(arrO[2]);
			sma = parseInt(arrS[0]);
			smi = parseInt(arrS[1]);
			if(arrS.length == 3)
				sb = parseInt(arrS[2]);
			if (oma < sma)
			{
				return false;
			}
			else if (oma == sma )
			{
				if (omi < smi)
				{
					return false;
				}else if(oma == sma){
					if(ob < sb)
						return false;
				}
			}
		}
		catch(e){			
		}		
	}
	return true;
}

function ChkAddPoint(){
    var nonull = Res.GetValue("WARN_NOCARD");
    var errcardno = Res.GetValue("WARN_ERRCARD");
    var errcardpwd = Res.GetValue("WARN_ERRPWD");
	var no = $("tbCardNum").value;
	if(no.length == 0){
		alert(nonull);
		return false;
	}else if (no.length != 10){
		alert(errcardno);
		return false;
	}else{
		if(/\W/.test(no)){
			alert(errcardno);
			return false;
		}
	}
	var pwd = $("tbCardPwd").value;
	if(pwd.length != 10){
		alert(errcardpwd);
		return false;
	}
}

function CallPlay(url){
    location.href=url;
    setTimeout("parent.window.close()",2000);
}

function SelChange(obj){
    var value = obj.options[obj.selectedIndex].value;
    location.href=value;
}


function ContentResize(){        
    var seconder =document.getElementById("seconder");
    var firster = document.getElementById("firster");       
    var firh=firster.clientHeight;
    var sech=seconder.clientHeight;      
    if(firh>sech){
        seconder.style.height= firh+"px";
    }else if(firh<sech){
        firster.style.height= sech+"px";
    }        
}

function NavSelected(nodeObj,pNav){ 
    var menu = $(pNav)
    for(var i=0; i< menu.childNodes.length; i++){
        var curNode = menu.childNodes[i];
        if(curNode.nodeType ==1){
            curNode.className="";    
        }
    }    
    nodeObj.className="selected";     
}

function handleMouseClick(e){
    var evt;
    if(typeof window.event !="undefined"){
        evt = window.event; 
    }else{
        evt = e;
    }
    var target;
    if(typeof evt.srcElement !="undefined"){
        target = evt.srcElement;
    }else{
        target = evt.target;
    }
   // var pNode = target.parentNode;
    NavSelected(target,"nav");
    //var SelectedId =target.id;
    //var selectedElement = $(SelectedId);
}


/*===============*/

function MyDialog(wdh,hgt,title,content){
  Dialog.info( content, 
               {windowParameters:
                    {className: "alphacube", width:wdh, height:hgt,title:title,resizable:false,minimizable:false,maximizable:false,closable:true,draggable:true}
               }
              );
}

function IECheck(ErrIe) { 
     var ua=navigator.userAgent ;
     var ie=(navigator.appName=="Microsoft Internet Explorer"); 
     if(ie){ 
       var IEversion=parseFloat(ua.substring(ua.indexOf("MSIE ")+5,ua.indexOf(";",ua.indexOf("MSIE ")))) ;
       if(IEversion<5.5) { 
            if(!confirm(ErrIe)){
                window.close();        
            }    
          }
     }
     
} 
function MyOnload(strUrl,strVersion,ErrIe){
    IECheck(ErrIe);    
   // alert(strVersion);
    Cookie.setCookie("PlayerVersion",strVersion);    
    location.href=strUrl;
}
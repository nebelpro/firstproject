	
	
	var strver3 = RS("VER_LOCAL");  
	var  strver4 = RS("VER_SERVER");  
	
	var v_mp = 3;
	var strmp1 = RS("VER_PLAYER"); 
	var strmp2 = RS("VER_PLAYERLOW"); 
	var v_mn = 4;
	var strmn1 = RS("VER_MANAGER");  
	var strmn2 = RS("VER_MANAGERLOW"); 
	nosetup = RS("INFO_NOSETUP");

	









// for play
function IsPlay(point){
    if(!CheckMediaPlayer())return false;
	if(point == 0)return true;
	var sMsg = Res.GetValue("INFO_CONFIRMPLAY");
	sMsg=sMsg.replace("{0}",point);
	return confirm(sMsg);
}
function CheckMediaPlayer(){


    var objSetup; 
	try	{
		objSetup = new ActiveXObject("LibSetupCheck.SetupPlayer"); 
		var mp =  objSetup.GetProductVersion(3);
		if (mp == 0){
		    if(confirm(Res.GetValue("WARN_NOPLAYER"))){
		        window.location="SoftDown.aspx";
		    }
			return false;
		}		
	}catch (e)	{
	   if(confirm(Res.GetValue("WARN_NOPLAYER"))){
	        window.location="SoftDown.aspx";
	    }
		return false;
	}
	return true;
	
	
}

function CheckMedia(strUrl,serVer){     
	var objSetup; 
	try	{
		objSetup = new ActiveXObject("LibSetupCheck.SetupPlayer");		
		
	}catch (e)	{
	   if(confirm(Res.GetValue("WARN_NOPLAYER"))){
	        window.location="SoftDown.aspx";
	        return;	
	   }else{
	        window.location=strUrl;
	        return;	
	   }		   
	}
	var mp =  objSetup.GetProductVersion(3);
	if (mp == 0){
		    if(confirm(Res.GetValue("WARN_NOPLAYER"))){
		        window.location="SoftDown.aspx";
		        return;
		    }else{
	            window.location=strUrl;
	            return;	
	       }			
	}
	
	if (!CheckVersion(mp,serVer)){
	    var errstr = strmp1+mp+","+strmp2+serVer +"\n";
	    if(confirm(errstr)){
	        window.location="SoftDown.aspx";
	    }else{
	         window.location=strUrl;
	    }
		
	}else{	
	     window.location=strUrl;
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
    catch (e)
	{

	}


	if (!CheckVersion(c,s))
	{
		if (c == 0)
		{
			c = nosetup;
		}
		strout = strver4+s+"&nbsp;&nbsp;&nbsp;&nbsp;<font color=red>"+strver3+c+"</font> ";
	}
	else
	{
		if (c == 0)
		{
			c = nosetup;
		}
		strout = " "+strver4+s+"&nbsp;&nbsp;&nbsp;&nbsp;"+strver3+c;
	}
	document.writeln(strout);
	
}

function CheckVersion(o,s)
{
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
		catch(e)
		{
			
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

function dialog(wdh,hgt,strTitle) {
	var strInfo="<h3>AAAAAAAAAA</h3><TABLE><TR><tD>bbbbbbbb</TD></TR></TABLE>";
	
  Dialog.info(strInfo, 
               {windowParameters: {className: "alphacube", width:wdh, height:wdh,title:strTitle,resizable:false,minimizable:false,maximizable:false,closable:true,draggable:true}});
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
function MyOnload(strUrl,serVer,ErrIe){
    IECheck(ErrIe);
    CheckMedia(strUrl,serVer);

}
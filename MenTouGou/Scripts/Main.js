function CallPlay(url){
    location.href=url;
    setTimeout("parent.window.close()",2000);
}
function IsPlay(point){	
	if(!CheckMedia())return false;
	if(point == 0)return true;
	var sMsg = Res.GetValue("INFO_CONFIRMPLAY");
	sMsg = sMsg.replace("{0}",point);
	return confirm(sMsg);
}

function CheckMedia(){
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

 
function ShowSubCatalog(tag){
   var length = tag.childNodes.length;
   if(length>1){  
        for(var i=0; i < length; i++)
        {
            var obj=tag.childNodes(i); 
            if(obj.tagName=="UL"){ 
            obj.style.display="block";
            obj.style.position="absolute";
            
            obj.style.left="56px";
            obj.style.padding="0.2em 0.2em";
            obj.style.border="1px solid #898989";
            obj.style.backgroundColor="#ebebeb";            
            }
        }
    }
}
function HideSubCatalog(tag){
    //setTimeout(HideSubCatalog,60000);
   var length = tag.childNodes.length;
   if(length>1){  
        for(var i=0; i < length; i++)
        {
            var obj=tag.childNodes(i);         
            if(obj.tagName=="UL"){      
            obj.style.display="none";
           
            }
        }
    }
}

function ShowTip(tag){
   var length = tag.childNodes.length;
   if(length>1){  
        for(var i=0; i < length; i++)
        {
            var obj=tag.childNodes(i); 
            if(obj.tagName=="SPAN"){ 
            obj.style.display="block";
            obj.style.position="absolute";
            obj.style.top="0";
            obj.style.left="auto";
            obj.style.padding="0.2em 0.2em";
            obj.style.border="1px solid #898989";
            obj.style.backgroundColor="#ebebeb";            
            }
        }
    }
}
function HideTip(tag){
    //setTimeout(HideSubCatalog,60000);
   var length = tag.childNodes.length;
   if(length>1){  
        for(var i=0; i < length; i++)
        {
            var obj=tag.childNodes(i);         
            if(obj.tagName=="SPAN"){      
            obj.style.display="none";
           
            }
        }
    }
}
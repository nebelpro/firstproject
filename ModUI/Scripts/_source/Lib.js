var Toper = this;
function OpenWindow(strurl ,strtitle,height,width,top,left){
    window.showModalDialog(strurl,strtitle,"dialogHeight: "+height+"px; dialogWidth: "+width+"px; dialogTop: "+top+"px; dialogLeft: "+left+"px; edge: Raised; center: Yes; help: Yes; resizable: Yes; status: No;");
}
function openwndex(strUrl,strWndName,width, height) {
	var nRnd = Math.random();	
	strUrl = "../" + strUrl  ;
	var sFeatures = "DialogHeight:"+height+"px;DialogWidth:"+width+"px;help:No;center:Yes;scroll:No; status:No;";
	n = window.showModalDialog("Scripts/g_DialogTemp.htm?rnd="+nRnd,strUrl +"|"+ strWndName +"|"+height+"|"+width ,sFeatures);
	if (n == 1 )
	{
		location.reload();
	}	
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


function ShowWeige(){
    location.href("Weige.aspx?v="+$("sltView").value+"&s="+$("sltSort").value);
}



var obj;
function menuFix(strId) { 
	var sfEls = $(strId).getElementsByTagName("li"); 
	for (var i=0; i<sfEls.length; i++) { 
		sfEls[i].onmouseover=function() { 
		    this.className+=(this.className.length>0? " ": "") + "sfhover"; 		   
		} 		 
		sfEls[i].onmouseout=function() {
		this.className=this.className.replace(new RegExp('( ?|^)sfhover\\b'),'');
		//	obj=this;
			//window.setTimeout("mouseOut()",1000);
		} 
	} 
} 

function mouseOver(){     
    obj.className+=(obj.className.length>0? " ": "") + "sfhover"; 
}
function mouseOut(){
    
    obj.className=obj.className.replace(new RegExp('( ?|^)sfhover\\b'),'');
   

}

function Over(obj2){      
       obj2.className+=(obj2.className.length>0? " ": "") + "sfhover"; 
}

function Out(obj2){
    obj=obj2;
	window.setTimeout("Out2()",500);
}

function Out2(){
     $("top").innerHTML+=obj.tagName+"o"+"\t";
    obj.className=obj.className.replace(new RegExp('( ?|^)sfhover\\b'),'');
}





/*var Hover = Class.create();
Hover.prototype = {
	initialize:function(id,Tag,styleName){
		this.delay=0;
		this.arrayTag= $(id).getElementsByTagName(Tag);
		this.hoverStyle= styleName;
		this.bindEvent();

	},
	bindEvent:function(){
		for(var i=0;i<this.arrayTag.length;i++){
			Event.observe(this.arrayTag[i],"onmouseover",this.mOver);
			Event.observe(this.arrayTag[i],"onmousedown",this.mDown);
			Event.observe(this.arrayTag[i],"onmouseup",this.mUp);
			Event.observe(this.arrayTag[i],"onmouseout",this.mOut);

		}
	},
	mOver:function(e){
		var obj= Event.element(e);
		obj.className+=(obj.className.length>0? " ": "") + this.hoverStyle;
	},
	mDown:function(e){
		var obj= Event.element(e);
		obj.className+=(obj.className.length>0? " ": "") + this.hoverStyle;
	},
	mUp:function(e){
		var obj= Event.element(e);
		obj.className+=(obj.className.length>0? " ": "") + this.hoverStyle;
	},
	mOut:function(e){
		var obj= Event.element(e);
		obj.className=obj.className.replace(new RegExp("( ?|^)"+this.hoverStyle+"\\b"),"");
	}
}*/
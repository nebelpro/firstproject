var Toper = this;


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
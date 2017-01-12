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

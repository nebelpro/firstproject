var gHomeIp;
var gHomePort;
var strParam;

var params;

function Live_Load(nView){
	params = SortRecList(eval('('+strParam+')'));
	var htmlArea="";
	if(nView==0){
	    htmlArea=View4();
	}else if(nView==1){
	    htmlArea=View6one();
	}else if(nView==2){
	    htmlArea=View6two();
	}else if(nView==3){
	    htmlArea=View9();
	}else if(nView==4){
	    htmlArea=View12();
	}else if(nView==5){
	    htmlArea=View13();
	}else if(nView==6){	    
	    htmlArea=View16();
	}else{
	    htmlArea=View12();
	}
	
	$("mpArea").innerHTML  = htmlArea;	
}

function View12(){
    var html="<table id=\"view12\"><tr>";
	for(var n=0;n<12;n++){		
		if(params[n] != null){
			html+= "<td><OBJECT id=\"MWP_"+n+"\" class=\"player\" classid=\"clsid:A58688A5-3C99-4B22-B29C-53545CEE03D2\" VIEWASTEXT></OBJECT><br/>"
			+"<p>"+params[n].name+"</p></td>";
			setTimeout("Open("+n+")",3000);
		}else{
			html+="<td><img src=\"Images/no_video.gif\"/></td>";
		}
		if( n % 4 == 3){
			if ( n != 11){
				html  += "</tr><tr>";
			}else{
				html+= "</tr>";
			}			
		}
	}
     html += "</table>";	
	return html;
}
function View4(){
    var html= "<table  id=\"view4\"><tr>";
    for(var n=0;n<4;n++){
        if(params[n] != null){
			html += "<td><OBJECT class=\"player\" id=\"MWP_"+n+"\""
			+" classid=\"clsid:A58688A5-3C99-4B22-B29C-53545CEE03D2\" VIEWASTEXT></OBJECT><br/>"
			+"<p>"+params[n].name+"</p></td>";
			setTimeout("Open("+n+")",3000);
		}else{
			html += "<td> <img src=\"Images/no_video.gif\" /></td>";
		}
		if( n % 2 == 1){
			if ( n != 1){
				html  += "</tr><tr>";
			}else{
				html+= "</tr>";
			}			
		}    
    }
      html += "</table>";	
	  return html;
}

function View6one(){
    
    var html= "<table  id=\"view6one\"><tr>";
    for(var n=0;n<6;n++){
        if(params[n] != null){
			html += "<td><OBJECT class=\"player\" id=\"MWP_"+n+"\""
			+" classid=\"clsid:A58688A5-3C99-4B22-B29C-53545CEE03D2\" VIEWASTEXT></OBJECT><br/>"
			+"<p>"+params[n].name+"</p></td>";
			setTimeout("Open("+n+")",3000);
		}else{
			html += "<td> <img src=\"Images/no_video.gif\" /></td>";
		}
		if( n % 3 == 2){
			if ( n != 5){
				html  += "</tr><tr>";
			}else{
				html+= "</tr>";
			}			
		}    
    }
      html += "</table>";	
	  return html;

}
function View6two(){
    var array=[];
    for(var n=0;n<6;n++){
        if(params[n] != null){
			array[n] = "<OBJECT class=\"player\" id=\"MWP_"+n+"\""
			+" classid=\"clsid:A58688A5-3C99-4B22-B29C-53545CEE03D2\" VIEWASTEXT></OBJECT><br/>"
			+"<p>"+params[n].name+"</p>";
			setTimeout("Open("+n+")",3000);
		}else{
			array[n] = "<img src=\"Images/no_video.gif\" />";
		}		
    }
    var html="<table id=\"view6two\"><tr><td class=\"big\" colspan=\"2\" rowspan=\"3\">"+array[0]+"</td></tr>"+
                        "<tr><td class=\"normal\">"+array[1]+"</td></tr>"+
                        "<tr><td class=\"normal\">"+array[2]+"</td></tr>"+               
                "<tr><td class=\"normal\">"+array[3]+"</td><td class=\"normal\">"+array[4]+"</td><td class=\"normal\">"+array[5]+"</td></tr></table>"
     
	return html;
}

function View9(){
    
    var html= "<table id=\"view9\"><tr>";
    for(var n=0;n<9;n++){
        if(params[n] != null){
			html += "<td><OBJECT class=\"player\" id=\"MWP_"+n+"\""
			+" classid=\"clsid:A58688A5-3C99-4B22-B29C-53545CEE03D2\" VIEWASTEXT></OBJECT><br/>"
			+"<p>"+params[n].name+"</p></td>";
			setTimeout("Open("+n+")",3000);
		}else{
			html += "<td> <img src=\"Images/no_video.gif\" /></td>";
		}
		if( n % 3 == 2){
			if ( n != 8){
				html  += "</tr><tr>";
			}else{
				html+= "</tr>";
			}			
		}    
    }
      html += "</table>";	
	  return html;
}

function View16(){
    
    var html= "<table id=\"view16\"><tr>";
    for(var n=0;n<16;n++){
        if(params[n] != null){
			html += "<td><OBJECT class=\"player\" id=\"MWP_"+n+"\""
			+" classid=\"clsid:A58688A5-3C99-4B22-B29C-53545CEE03D2\" VIEWASTEXT></OBJECT><br/>"
			+"<p>"+params[n].name+"</p></td>";
			setTimeout("Open("+n+")",3000);
		}else{
			html += "<td> <img src=\"Images/no_video.gif\" /></td>";
		}
		if( n % 4 == 3){
			if ( n != 15){
				html  += "</tr><tr>";
			}else{
				html+= "</tr>";
			}			
		}    
    }
      html += "</table>";	
	  return html;
}

function View13(){

 var array=[];
    for(var n=0;n<13;n++){
        if(params[n] != null){
			array[n] = "<OBJECT class=\"player\" id=\"MWP_"+n+"\""
			+" classid=\"clsid:A58688A5-3C99-4B22-B29C-53545CEE03D2\" VIEWASTEXT></OBJECT><br/>"
			+"<p>"+params[n].name+"</p>";
			setTimeout("Open("+n+")",3000);
		}else{
			array[n] = "<img src=\"Images/no_video.gif\" />";
		}		
    } 
    var html="<table id=\"view13\"><tr><td class=\"big\" colspan=\"2\"  rowspan=\"3\">"+array[0]+"</td></tr>"+
                        "<tr><td class=\"normal\">"+array[1]+"</td><td class=\"normal\">"+array[2]+"</td></tr>"+
                        "<tr><td class=\"normal\">"+array[3]+"</td><td class=\"normal\">"+array[4]+"</td></tr>"+  
                "<tr><td class=\"normal\">"+array[5]+"</td><td class=\"normal\">"+array[6]+"</td><td class=\"normal\">"+array[7]+"</td><td class=\"normal\">"+array[8]+"</td></tr>"+
                "<tr><td class=\"normal\">"+array[9]+"</td><td class=\"normal\">"+array[10]+"</td><td class=\"normal\">"+array[11]+"</td><td class=\"normal\">"+array[12]+"</td></tr></table>"
     
	return html;


}



function DbClick(cid,ip,port,type){
	var popUrl;
	if (type == 6)
		popUrl = "ummp://127.0.0.1:0/"+gHomeIp+":"+gHomePort+"/"+cid+"."+"0.0.1.131071";
	else
		popUrl = "ummp://"+ip+":"+port+"/"+gHomeIp+":"+gHomePort+"/"+cid+"."+"0.0.1.131071";
    alert(popUrl);
	location.href=popUrl;
	//openwndex("poplive.asp?url="+popUrl.replace("/","_"),"loading...",2,20);
}

function Open(m){
	var param = params[m];
	try{
		var ret;
		var objMwp = $("MWP_"+m);
		
		objMwp.SetType(2);
		ret = objMwp.Open(param.ssrc,0);
	//	objMwp.SetWndClick(1);
		objMwp.SetVolume(0);
		
		if(param.auto == 1)
			objMwp.InsertAuto();

		var objRece,strMs,arrMs;
		strMs = "";
		var bHasInsert = false;

		for(var i=0;i < param.receive.length;i++){
			objRece = param.receive[i];
			
			if(objRece.type == "tcp"){
				objMwp.InsertTCP(objRece.ip, objRece.port, param.ssrc);
				bHasInsert = true;
				objMwp.attachEvent("WndClick",function(){DbClick(param.cid,objRece.ip,objRece.port,objRece.catype);});
			}else if(objRece.type == "ms"){
				strMs = GetMSPath(objRece.ip,objRece.port,0,objRece.msid,objRece.uid);
				if(strMs != ""){
					arrMs = strMs.split(":");
					objMwp.InsertTCP(arrMs[0], arrMs[1], param.ssrc);
					bHasInsert = true;
					objMwp.attachEvent("WndClick",function(){DbClick(param.cid,arrMs[0],arrMs[1],objRece.catype);});
				}
			}
			else{
				objMwp.InsertUDP(objRece.ip, objRece.port);
				objMwp.attachEvent("WndClick",function(){DbClick(param.cid,objRece.ip,objRece.port,objRece.catype);});
				bHasInsert = true;
			}

			if(bHasInsert)
					break;
		}

		
		ret = objMwp.Run();
	
	}catch(e){
		//alert(e.description);
	}
}


/*  public player js */
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



function ChgView(obj){
	var sort = obj.options[obj.selectedIndex].value;
	location.href = "live.aspx?sort="+sort;
}

function Live_Unload() {
	for(var n=0;n<12;n++){
		var objMwp = $("MWP_"+n);
		if(objMwp!=null){
		    objMwp.Close();
		}
	}
}
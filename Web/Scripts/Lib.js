
// 一些通用函数全部放在此文件中

function $(id){
	return document.getElementById(id);
}

function IsEmpty(str){
	return !(/\S/.test(str));
}

function EncodeHtml(str){
	if(str.length == 0)return str;
	str = str.replace(/&/gi,"&amp;");
	str = str.replace(/</gi,"&lt;");
	str = str.replace(/>/gi,"&gt;");
	return str;
}

function DecHtml(str){
	if(str.length == 0)return str;
	str = str.replace(/&amp;/gi,"&");
	str = str.replace(/&gl;/gi,"<");
	str = str.replace(/&gt;/gi,">");
	return str;	
}

function OpenWindow(strurl ,strtitle,height,width,top,left){
    window.showModalDialog(strurl,strtitle,"dialogHeight: "+height+"px; dialogWidth: "+width+"px; dialogTop: "+top+"px; dialogLeft: "+left+"px; edge: Raised; center: Yes; help: Yes; resizable: Yes; status: No;");
}


function openwndex(strUrl,strWndName,width, height) {
	var nRnd = Math.random();
	var bP = false;
	if (strUrl.toLowerCase().indexOf("AddPlayCount.aspx") > 0)
	{
		bP = !CheckPlay("");
	}
	if (!bP)
	{
		strUrl = "../" + strUrl  ;
		var sFeatures = "DialogHeight:"+height+"px;DialogWidth:"+width+"px;help:No;center:Yes;scroll:No; status:No;";
		n = window.showModalDialog("js/g_DialogTemp.htm?rnd="+nRnd,strUrl +"|"+ strWndName +"|"+height+"|"+width ,sFeatures);
		if (n == 1 )
		{
			location.reload();
		}
	}
}


// GetXmlResource
//--------------------------------------------------------------
var Res = {};
Res.GetValue = function(strKey){
    var xmlObj = new ActiveXObject("MSXML2.DOMDocument");
    xmlObj.async = false;
	var bRet = xmlObj.load("Resource/ModRes.xml");
    if(xmlObj != null){    
        var doc = xmlObj.documentElement;
        if(doc){
            var node = doc.selectSingleNode("//Client/key[@name='"+strKey+"']");
            return node.text;
        }
    }
    return "";
}

//--------------------------------------------------------------

var Ajax = {};
Ajax.getXmlHttpObject = function(){
	var objReq;
	if (window.XMLHttpRequest){
		objReq = new XMLHttpRequest();
		if (objReq.overrideMimeType){
			objReq.overrideMimeType("text/xml");
		}
	}else if(window.ActiveXObject){
		try{
			objReq = new ActiveXObject("MSXML2.XMLHTTP");
		}
		catch(e){
			try{
				objReq = new ActiveXObject("Microsoft.XMLHTTP");
			}catch(e){
				objReq = false;
			}
		}
	}
	return objReq;
};

Ajax.getText = function(uri,aysn){
	var obj = this.getXmlHttpObject();
	if (aysn){
		obj.onreadystatechange = function(){
			if (obj.readyState == 4){
				if (obj.Status == 200){
					aysn(obj.responseText);
				}
			}
		}
	}
	if(uri.indexOf("?") != -1)
		uri += "&rnd="+(Math.random());
	else
		uri += "?rnd="+(Math.random());
		
	obj.open("GET",uri,aysn?true:false);
	obj.send(null);
	if(aysn){return null;}
	return obj.responseText;
};

Ajax.PostData = function(uri,data,aysn){
	var obj = this.getXmlHttpObject();
	if (aysn){
		obj.onreadystatechange = function(){
			if (obj.readyState == 4){
				if (obj.Status == 200){
					aysn(obj.responseText);
				}
			}
		}
	}
	if(uri.indexOf("?") != -1)
		uri += "&rnd="+(Math.random());
	else
		uri += "?rnd="+(Math.random());
	
	obj.open("POST",uri,aysn?true:false);
	obj.setRequestHeader("Content-Length",data.length);
	obj.setRequestHeader("Content-Type","application/x-www-form-urlencoded");
	obj.send(data);
	if(aysn){return null;}
	return obj.responseText;
}

Ajax.Update = function(uri,eleid){
	var obj = this.getXmlHttpObject();
	obj.onreadystatechange = function(){
		if (obj.readyState == 4){
			if (obj.Status == 200){
				document.getElementById(eleid).innerHTML = obj.responseText;
			}
		}
	}
	if(uri.indexOf("?") != -1)
		uri += "&rnd="+(Math.random());
	else
		uri += "?rnd="+(Math.random());
		
	obj.open("GET",uri,true);
	obj.send(null);
}

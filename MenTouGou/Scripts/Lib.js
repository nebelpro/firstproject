
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

function PopWindow(strUrl,strWndName,width,height)
{
	var xposition,yposition;
	xposition=0; yposition=0;
	if ((parseInt(navigator.appVersion) >= 4 ))
	{
		xposition = (screen.width - width) / 2;
		yposition = (screen.height - height) / 2;
	}

	var theproperty;
	theproperty= "width=" + width + "," 
	+ "height=" + height + "," 
	+ "location=0," 
	+ "menubar=0,"
	+ "resizable=1,"
	+ "scrollbars=0,"
	+ "status=0," 
	+ "titlebar=0,"
	+ "toolbar=0,"
	+ "left=" + xposition + "," //IE
	+ "top=" + yposition; //IE 

	var wndChild = window.parent.open(strUrl,"_blank",theproperty);
	if(wndChild == null){
		wndChild = window.open(strUrl,"_blank",theproperty);
	}
	return wndChild;
}


function openwndex(strUrl,strWndName,width, height) {
	var nRnd = Math.random();
	strUrl = "../" + strUrl  ;
	var sFeatures = "DialogHeight:"+height+"px;DialogWidth:"+width+"px;help:No;center:Yes;scroll:No; status:No;";
	n = window.showModalDialog("Scripts/g_DialogTemp.htm?rnd="+nRnd,strUrl +"|"+ strWndName +"|"+height+"|"+width ,sFeatures);
	if (n == 1 ){
		location.reload();
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
             if(node != null){
                     return node.text;
                  }else{
                     return "?"+strKey+"?";
             }
        }
    }
    return "";
}

//--------------------------------------------------------------


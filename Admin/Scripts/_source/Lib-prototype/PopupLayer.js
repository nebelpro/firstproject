function addEvent(obj, evType, fn){
 if (obj.addEventListener){
    obj.addEventListener(evType, fn, false);
    return true;
 } else if (obj.attachEvent){
    var r = obj.attachEvent("on"+evType, fn);
    return r;
 } else {
    return false;
 }
}
function removeEvent(obj, evType, fn, useCapture){
  if (obj.removeEventListener){
    obj.removeEventListener(evType, fn, useCapture);
    return true;
  } else if (obj.detachEvent){
    var r = obj.detachEvent("on"+evType, fn);
    return r;
  } else {
    alert("Handler could not be removed");
  }
}
function getViewportHeight() {
	if (window.innerHeight!=window.undefined) return window.innerHeight;
	if (document.compatMode=='CSS1Compat') return document.documentElement.clientHeight;
	if (document.body) return document.body.clientHeight; 
	return window.undefined; 
}
function getViewportWidth() {
	if (window.innerWidth!=window.undefined) return window.innerWidth; 
	if (document.compatMode=='CSS1Compat') return document.documentElement.clientWidth; 
	if (document.body) return document.body.clientWidth; 
	return window.undefined; 
}



var PopupLayer = Class.create();
PopupLayer.prototype={
    initialize:function(){
        this.gi = 0;
        this.Mask = null;
        this.Container = null;
        this.Frame = null;
        this.ReturnFunc;
        this.IsShown = false;
        this.HideSelects = false;
        this.TabIndexs = new Array();
        this.TabableTags = Array("A","BUTTON","TEXTAREA","INPUT","IFRAME");
        if(!document.all){document.onkeypress = this.keyDownHandler;}        
    },       
    init:function () {	
	var theBody = document.getElementsByTagName('BODY')[0];
	var popmask = document.createElement('div');
	popmask.id = 'popupMask';
	var popcont = document.createElement('div');
	popcont.id = 'popupContainer';
	popcont.innerHTML = '' +
		'<div id="popupInner">' +
			'<div id="popupTitleBar">' +
				'<div id="popupTitle">popupTitle</div>' +
				'<div id="popupControls" onclick="hello.hidePopWin(false);">' +
					'CloseText' +
				'</div>' +
			'</div><div id="popupFrame">' +
					"AAAAAAAAAAAAAAA"+
			//'<iframe src="loading.html" style="width:100%;height:100%;background-color:transparent;" scrolling="auto" frameborder="0" allowtransparency="true" id="popupFrame" name="popupFrame" width="100%" height="100%"></iframe>' +
		'</div></div>';
	theBody.appendChild(popmask);
	theBody.appendChild(popcont);
	
	this.Mask = $("popupMask");
	this.Container = $("popupContainer");
	this.Frame = $("popupFrame");		
	this.HideSelects= this.IEVersion();
	
	
	
	addEvent(window, "resize", this.centerPopWin);   
    window.onscroll = this.centerPopWin;
	
	},
	IEVersion:function(){	    
	    var brsVersion = parseInt(window.navigator.appVersion.charAt(0), 10);
	    if (brsVersion <= 6 && window.navigator.userAgent.indexOf("MSIE") > -1) {
		    return true;
	    }else{
	        return false;
	    }	    
	},
	TagClickEvent:function(EventTag,EventStyle){//	a, a-width-height 
	    var self = this;   
	    var elms = document.getElementsByTagName(EventTag);
	    for (i = 0; i < elms.length; i++) {
		    if (elms[i].className.indexOf(EventStyle) == 0) { 
			    elms[i].onclick = function(){				   
				    var width = 400;
				    var height = 200;				    
				    var params = this.className.split('-');
				    if (params.length == 3) {
					    width = parseInt(params[1]);
					    height = parseInt(params[2]);
				    }
				    self.showPopWin(this.href,width,height,null); return false;
			    }
		    }
	    }
	},
	showPopWin:function(url, width, height, returnFunc) {
	    this.IsShown = true;
	    this.disableTabIndexes();
	    this.Mask.style.display = "block";
	    this.Container.style.display = "block";
	    // calculate where to place the window on screen
	    this.centerPopWin(width, height);    	
	    var titleBarHeight = parseInt($("popupTitleBar").offsetHeight, 10);
	    this.setMaskSize();	    
	    this.Frame.style.width = parseInt($("popupTitleBar").offsetWidth, 10) + "px";
	    this.Frame.style.height = (height) + "px";    	
	    this.Frame.src = url;    	
	    this.ReturnFunc = returnFunc;	   
	    if (this.HideSelects == true) { // for IE
		    this.hideSelectBoxes();
	    }    	
	   // window.setTimeout(this.setPopTitle(), 600);
    }, 
    centerPopWin:function(width, height) {
	    if (this.IsShown == true) {
		    if (width == null || isNaN(width)) {
			    width = this.Container.offsetWidth;
		    }
		    if (height == null) {
			    height = this.Container.offsetHeight;
		    }  
		    var theBody = document.getElementsByTagName("BODY")[0];
		    theBody.style.overflow = "hidden";    		
		    var scTop = parseInt(theBody.scrollTop,10);
		    var scLeft = parseInt(theBody.scrollLeft,10);    		
		    this.Mask.style.top = scTop + "px";
		    this.Mask.style.left = scLeft + "px";    	
		    this.setMaskSize();   	
		    var titleBarHeight = parseInt($("popupTitleBar").offsetHeight, 10);    		
		    var fullHeight = getViewportHeight();
		    var fullWidth = getViewportWidth();    		
		    this.Container.style.top = (scTop + ((fullHeight - (height+titleBarHeight)) / 2)) + "px";
		    this.Container.style.left =  (scLeft + ((fullWidth - width) / 2)) + "px";		    
	    }
    },
    setMaskSize:function () {
	    var theBody = document.getElementsByTagName("BODY")[0];
    			
	    var fullHeight = getViewportHeight();
	    var fullWidth = getViewportWidth();
	    if (fullHeight > theBody.scrollHeight) {
		    popHeight = fullHeight;
	    } else {
		    popHeight = theBody.scrollHeight
	    }    	
	    this.Mask.style.height = popHeight + "px";
	    this.Mask.style.width = theBody.scrollWidth + "px";
    },
    hidePopWin:function (callReturnFunc) {
        this.Mask.style.display = "none";
	    this.Container.style.display = "none";
	    /*this.IsShown = false;
	    var theBody = document.getElementsByTagName("BODY")[0];
	    theBody.style.overflow = "";
	    this.restoreTabIndexes();
	    if (this.Mask == null) {
		    return;
	    }
	    this.Mask.style.display = "none";
	    this.Container.style.display = "none";
	    alert(this.Container.style.display);
	    if (callReturnFunc == true &&  this.ReturnFunc != null) {
		     this.ReturnFunc(window.frames["popupFrame"].returnVal);
	    }
	    this.Frame.src = 'loading.html';
	    // display all select boxes
	    if (this.HideSelects == true) {
		    this.displaySelectBoxes();
	    }*/
    },
    setPopTitle:function () {
        $("popupTitle").innerHTML="AAAAAAAAA";
        
	    return;
	    if (window.frames["popupFrame"].document.title == null) {
		    window.setTimeout("setPopTitle();", 10);
	    } else {
		    $("popupTitle").innerHTML = window.frames["popupFrame"].document.title;
	    }
    },
    // For IE.  Go through predefined tags and disable tabbing into them.
    disableTabIndexes:function () {
	    if (document.all) {
		    var i = 0;
		    for (var j = 0; j < this.TabableTags.length; j++) {
			    var tagElements = document.getElementsByTagName(this.TabableTags[j]);
			    for (var k = 0 ; k < tagElements.length; k++) {
				    this.TabIndexs[i] = tagElements[k].tabIndex;
				    tagElements[k].tabIndex="-1";
				    i++;
			    }
		    }
	    }
    },
    // For IE. Restore tab-indexes.
    restoreTabIndexes:function () {
	    if (document.all) {
		    var i = 0;
		    for (var j = 0; j < this.TabableTags.length; j++) {
			    var tagElements = document.getElementsByTagName(this.TabableTags[j]);
			    for (var k = 0 ; k < tagElements.length; k++) {
				    tagElements[k].tabIndex = this.TabIndexs[i];
				    tagElements[k].tabEnabled = true;
				    i++;
			    }
		    }
	    }
    },
    hideSelectBoxes:function(){
	    for(var i = 0; i < document.forms.length; i++) {
		    for(var e = 0; e < document.forms[i].length; e++){
			    if(document.forms[i].elements[e].tagName == "SELECT") {
				    document.forms[i].elements[e].style.visibility="hidden";
			    }
		    }
	    }
    },
    displaySelectBoxes:function () {
	    for(var i = 0; i < document.forms.length; i++) {
		    for(var e = 0; e < document.forms[i].length; e++){
			    if(document.forms[i].elements[e].tagName == "SELECT") {
			    document.forms[i].elements[e].style.visibility="visible";
			    }
		    }
	    }
    },
    sayHello:function(){
        alert("Hello Young Man");
    },
     keyDownHandler:function(e){
        if (this.IsShown && e.keyCode == 9) 
            return false;
    }
    
}


var hello = new PopupLayer();
hello.sayHello();
window.onload=function(){
    hello.init();
    hello.showPopWin("http://localhost/admin", 100, 100, null);

}